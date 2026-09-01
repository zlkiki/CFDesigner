/**
 * CFDesigner Online Help Manual Frontend Script (Bilingual Edition)
 * Handles TOC loading, topic routing, 3-Way bilingual viewing (Korean/Split/English),
 * inline English toggle accordion, glossary tooltips, KaTeX math rendering, and search.
 */

class ManualViewer {
  constructor() {
    this.categories = [];
    this.allTopics = [];
    this.currentTopicId = null;
    this.currentTopicData = null;
    this.viewMode = localStorage.getItem("cfdesigner-manual-mode") || "ko"; // 'ko' | 'split' | 'en'
    this.searchDebounceTimer = null;

    // DOM Elements
    this.tocNav = document.getElementById("manualTocNav");
    this.articleContent = document.getElementById("manualArticleContent");
    this.splitView = document.getElementById("manualSplitView");
    this.splitContentKo = document.getElementById("splitContentKo");
    this.splitContentEn = document.getElementById("splitContentEn");

    this.bcCategory = document.getElementById("bcCategory");
    this.bcTopic = document.getElementById("bcTopic");
    this.currentModeIndicator = document.getElementById("currentModeIndicator");
    this.topicCountBadge = document.getElementById("topicCountBadge");
    
    this.btnPrev = document.getElementById("btnPrevTopic");
    this.btnNext = document.getElementById("btnNextTopic");
    this.prevTitle = document.getElementById("prevTopicTitle");
    this.nextTitle = document.getElementById("nextTopicTitle");

    this.searchInput = document.getElementById("manualSearchInput");
    this.btnClearSearch = document.getElementById("btnClearSearch");
    this.searchResultsArea = document.getElementById("searchResultsArea");
    this.searchResultsList = document.getElementById("searchResultsList");
    this.searchResultsCount = document.getElementById("searchResultsCount");

    this.btnTheme = document.getElementById("btnThemeToggle");
    this.viewModeButtons = document.querySelectorAll(".btn-view-mode");

    this.tooltip = document.getElementById("glossaryTooltip");
    this.tooltipTerm = document.getElementById("tooltipTerm");
    this.tooltipDef = document.getElementById("tooltipDef");

    this.init();
  }

  async init() {
    this.initTheme();
    this.initViewMode();
    this.bindEvents();
    await this.loadCategories();

    // Route based on URL hash
    const initialTopic = window.location.hash.replace("#", "") || "intro";
    this.loadTopic(initialTopic);
  }

  initTheme() {
    const savedTheme = localStorage.getItem("cfdesigner-theme") || "dark";
    document.body.setAttribute("data-theme", savedTheme);
  }

  initViewMode() {
    this.updateViewModeButtons();
  }

  setViewMode(mode) {
    if (!["ko", "split", "en"].includes(mode)) return;
    this.viewMode = mode;
    localStorage.setItem("cfdesigner-manual-mode", mode);
    this.updateViewModeButtons();
    if (this.currentTopicData) {
      this.renderCurrentTopic();
    }
  }

  updateViewModeButtons() {
    this.viewModeButtons.forEach(btn => {
      if (btn.dataset.mode === this.viewMode) {
        btn.classList.add("active");
      } else {
        btn.classList.remove("active");
      }
    });

    if (this.currentModeIndicator) {
      const modeNames = {
        ko: "🇰🇷 한글 뷰 모드",
        split: "🌐 한·영 2열 대조 뷰",
        en: "🇺🇸 English Reference"
      };
      this.currentModeIndicator.textContent = modeNames[this.viewMode] || "한글 뷰";
    }
  }

  bindEvents() {
    // Lightbox modal elements & close events
    this.lightboxModal = document.getElementById("imageLightboxModal");
    this.lightboxImg = document.getElementById("lightboxImg");
    this.lightboxCaption = document.getElementById("lightboxCaption");
    this.lightboxClose = document.getElementById("lightboxClose");
    this.lightboxBackdrop = document.getElementById("lightboxBackdrop");

    if (this.lightboxClose) {
      this.lightboxClose.addEventListener("click", () => this.closeLightbox());
    }
    if (this.lightboxBackdrop) {
      this.lightboxBackdrop.addEventListener("click", () => this.closeLightbox());
    }
    document.addEventListener("keydown", (e) => {
      if (e.key === "Escape" && this.lightboxModal && this.lightboxModal.classList.contains("active")) {
        this.closeLightbox();
      }
    });

    // Theme toggle
    if (this.btnTheme) {
      this.btnTheme.addEventListener("click", () => {
        const current = document.body.getAttribute("data-theme") || "dark";
        const nextTheme = current === "dark" ? "light" : "dark";
        document.body.setAttribute("data-theme", nextTheme);
        localStorage.setItem("cfdesigner-theme", nextTheme);
      });
    }

    // View mode buttons
    this.viewModeButtons.forEach(btn => {
      btn.addEventListener("click", () => {
        const mode = btn.dataset.mode;
        this.setViewMode(mode);
      });
    });

    // Hash change routing
    window.addEventListener("hashchange", () => {
      const topicId = window.location.hash.replace("#", "");
      if (topicId && topicId !== this.currentTopicId) {
        this.loadTopic(topicId);
      }
    });

    // Prev / Next topic buttons
    if (this.btnPrev) {
      this.btnPrev.addEventListener("click", () => {
        const idx = this.allTopics.findIndex(t => t.id === this.currentTopicId);
        if (idx > 0) {
          window.location.hash = `#${this.allTopics[idx - 1].id}`;
        }
      });
    }

    if (this.btnNext) {
      this.btnNext.addEventListener("click", () => {
        const idx = this.allTopics.findIndex(t => t.id === this.currentTopicId);
        if (idx >= 0 && idx < this.allTopics.length - 1) {
          window.location.hash = `#${this.allTopics[idx + 1].id}`;
        }
      });
    }

    // Search events
    if (this.searchInput) {
      this.searchInput.addEventListener("input", (e) => {
        const q = e.target.value.trim();
        if (this.btnClearSearch) {
          this.btnClearSearch.style.display = q ? "block" : "none";
        }
        clearTimeout(this.searchDebounceTimer);
        if (!q) {
          this.hideSearchResults();
          return;
        }
        this.searchDebounceTimer = setTimeout(() => this.performSearch(q), 250);
      });
    }

    if (this.btnClearSearch) {
      this.btnClearSearch.addEventListener("click", () => {
        this.searchInput.value = "";
        this.btnClearSearch.style.display = "none";
        this.hideSearchResults();
      });
    }

    // Split view synchronized scrolling
    if (this.splitContentKo && this.splitContentEn) {
      let isSyncing = false;
      const syncScroll = (source, target) => {
        if (!isSyncing) {
          isSyncing = true;
          const percentage = source.scrollTop / (source.scrollHeight - source.clientHeight || 1);
          target.scrollTop = percentage * (target.scrollHeight - target.clientHeight);
          setTimeout(() => { isSyncing = false; }, 20);
        }
      };

      this.splitContentKo.addEventListener("scroll", () => syncScroll(this.splitContentKo, this.splitContentEn));
      this.splitContentEn.addEventListener("scroll", () => syncScroll(this.splitContentEn, this.splitContentKo));
    }
  }

  async loadCategories() {
    try {
      const res = await fetch("/api/manual/categories");
      if (!res.ok) throw new Error("Failed to load categories");
      this.categories = await res.json();
      
      this.allTopics = [];
      this.categories.forEach(cat => {
        cat.topics.forEach(t => {
          this.allTopics.push({
            ...t,
            categoryId: cat.id,
            categoryTitle: cat.title
          });
        });
      });

      if (this.topicCountBadge) {
        this.topicCountBadge.textContent = `${this.allTopics.length} Topics`;
      }

      this.renderTOC();
    } catch (err) {
      console.error("loadCategories error:", err);
      if (this.tocNav) {
        this.tocNav.innerHTML = `<div class="toc-error">목차를 불러오지 못했습니다.</div>`;
      }
    }
  }

  renderTOC() {
    if (!this.tocNav) return;
    this.tocNav.innerHTML = "";

    this.categories.forEach(cat => {
      const catDiv = document.createElement("div");
      catDiv.className = "toc-category";

      const headerDiv = document.createElement("div");
      headerDiv.className = "toc-cat-header";
      headerDiv.innerHTML = `
        <div class="toc-cat-title">
          <span>${cat.icon}</span>
          <span>${cat.title}</span>
        </div>
        <span class="toc-cat-arrow">▼</span>
      `;
      headerDiv.addEventListener("click", () => {
        headerDiv.classList.toggle("collapsed");
      });

      const listUl = document.createElement("ul");
      listUl.className = "toc-topic-list";

      cat.topics.forEach(t => {
        const itemLi = document.createElement("li");
        itemLi.className = "toc-topic-item";
        itemLi.dataset.topicId = t.id;

        const linkA = document.createElement("a");
        linkA.href = `#${t.id}`;
        linkA.textContent = t.title;

        itemLi.appendChild(linkA);
        listUl.appendChild(itemLi);
      });

      catDiv.appendChild(headerDiv);
      catDiv.appendChild(listUl);
      this.tocNav.appendChild(catDiv);
    });
  }

  async loadTopic(topicId) {
    if (!topicId) topicId = "intro";
    this.currentTopicId = topicId;

    // Highlight TOC item
    document.querySelectorAll(".toc-topic-item").forEach(item => {
      if (item.dataset.topicId === topicId) {
        item.classList.add("active");
        const header = item.closest(".toc-category")?.querySelector(".toc-cat-header");
        if (header && header.classList.contains("collapsed")) {
          header.classList.remove("collapsed");
        }
      } else {
        item.classList.remove("active");
      }
    });

    // Render loading state
    this.articleContent.style.display = "block";
    this.splitView.style.display = "none";
    this.articleContent.innerHTML = `
      <div class="article-loading">
        <div class="spinner"></div>
        <p>문서를 불러오는 중입니다...</p>
      </div>
    `;

    try {
      const res = await fetch(`/api/manual/topic/${topicId}`);
      if (!res.ok) throw new Error("Topic not found");
      this.currentTopicData = await res.json();

      // Update Breadcrumbs
      if (this.bcCategory) this.bcCategory.textContent = this.currentTopicData.category_title;
      if (this.bcTopic) {
        this.bcTopic.textContent = this.viewMode === "en" ? (this.currentTopicData.title_en || this.currentTopicData.title) : this.currentTopicData.title;
      }

      this.renderCurrentTopic();

      // Update Pager buttons
      this.updatePager();

      // Scroll top
      const wrapper = document.getElementById("manualContentWrapper");
      if (wrapper) wrapper.scrollTop = 0;

    } catch (err) {
      console.error("loadTopic error:", err);
      this.articleContent.innerHTML = `
        <div class="callout callout-warning">
          <h4>문서를 불러올 수 없습니다</h4>
          <p>요청하신 토픽 '${topicId}' 정보를 찾을 수 없습니다.</p>
        </div>
      `;
    }
  }

  renderCurrentTopic() {
    if (!this.currentTopicData) return;

    if (this.viewMode === "split") {
      this.articleContent.style.display = "none";
      this.splitView.style.display = "grid";
      
      this.splitContentKo.innerHTML = this.currentTopicData.content_html || "";
      this.splitContentEn.innerHTML = this.currentTopicData.content_en_html || this.currentTopicData.content_html || "";

      this.renderEquations(this.splitContentKo);
      this.renderEquations(this.splitContentEn);
      this.bindGlossaryTooltips(this.splitContentKo);
      this.bindGlossaryTooltips(this.splitContentEn);
      this.setupLightbox(this.splitContentKo);
      this.setupLightbox(this.splitContentEn);
    } else {
      this.splitView.style.display = "none";
      this.articleContent.style.display = "block";

      if (this.viewMode === "en") {
        this.articleContent.innerHTML = this.currentTopicData.content_en_html || this.currentTopicData.content_html || "";
      } else {
        // 'ko' mode
        this.articleContent.innerHTML = this.currentTopicData.content_html || "";
      }

      this.renderEquations(this.articleContent);
      this.bindGlossaryTooltips(this.articleContent);
      this.setupLightbox(this.articleContent);
    }
  }

  setupLightbox(container) {
    if (!container) return;
    const images = container.querySelectorAll(".manual-img-card img, img.zoomable");
    images.forEach(img => {
      img.style.cursor = "zoom-in";
      img.addEventListener("click", () => {
        const card = img.closest(".manual-img-card");
        let caption = img.alt || "";
        if (card) {
          const capEl = card.querySelector(".img-caption");
          if (capEl) caption = capEl.textContent.trim();
        }
        this.openLightbox(img.src, caption);
      });
    });
  }

  openLightbox(src, caption) {
    if (!this.lightboxModal || !this.lightboxImg) return;
    this.lightboxImg.src = src;
    if (this.lightboxCaption) {
      this.lightboxCaption.textContent = caption || "";
      this.lightboxCaption.style.display = caption ? "block" : "none";
    }
    this.lightboxModal.classList.add("active");
  }

  closeLightbox() {
    if (!this.lightboxModal) return;
    this.lightboxModal.classList.remove("active");
  }

  toggleInlineEn(btn) {
    const wrapper = btn.closest(".en-toggle-wrapper");
    if (!wrapper) return;
    const box = wrapper.querySelector(".inline-en-box");
    if (!box) return;

    if (box.style.display === "none" || !box.style.display) {
      box.style.display = "block";
      btn.textContent = "🌐 원문 접기 (Hide Original)";
      btn.classList.add("active");
    } else {
      box.style.display = "none";
      btn.textContent = "🌐 원문 보기 (View Original)";
      btn.classList.remove("active");
    }
  }

  bindGlossaryTooltips(container) {
    if (!container || !this.tooltip) return;
    const terms = container.querySelectorAll(".glossary-term");

    terms.forEach(term => {
      term.addEventListener("mouseenter", (e) => {
        const enTitle = term.dataset.en || "";
        const def = term.dataset.def || "";
        if (!enTitle && !def) return;

        this.tooltipTerm.textContent = enTitle;
        this.tooltipDef.textContent = def;
        this.tooltip.style.display = "block";

        const rect = term.getBoundingClientRect();
        let left = rect.left + window.scrollX;
        let top = rect.bottom + window.scrollY + 8;

        if (left + 320 > window.innerWidth) {
          left = window.innerWidth - 330;
        }

        this.tooltip.style.left = `${Math.max(10, left)}px`;
        this.tooltip.style.top = `${top}px`;
      });

      term.addEventListener("mouseleave", () => {
        this.tooltip.style.display = "none";
      });
    });
  }

  renderEquations(targetElement) {
    if (window.renderMathInElement && targetElement) {
      window.renderMathInElement(targetElement, {
        delimiters: [
          { left: "$$", right: "$$", display: true },
          { left: "$", right: "$", display: false },
          { left: "\\(", right: "\\)", display: false },
          { left: "\\[", right: "\\]", display: true }
        ],
        throwOnError: false
      });
    }
  }

  updatePager() {
    const idx = this.allTopics.findIndex(t => t.id === this.currentTopicId);
    
    if (idx > 0) {
      this.btnPrev.classList.remove("disabled");
      this.prevTitle.textContent = this.allTopics[idx - 1].title;
    } else {
      this.btnPrev.classList.add("disabled");
      this.prevTitle.textContent = "-";
    }

    if (idx >= 0 && idx < this.allTopics.length - 1) {
      this.btnNext.classList.remove("disabled");
      this.nextTitle.textContent = this.allTopics[idx + 1].title;
    } else {
      this.btnNext.classList.add("disabled");
      this.nextTitle.textContent = "-";
    }
  }

  async performSearch(query) {
    try {
      const res = await fetch(`/api/manual/search?q=${encodeURIComponent(query)}`);
      if (!res.ok) throw new Error("Search failed");
      const results = await res.json();
      this.showSearchResults(results);
    } catch (err) {
      console.error("performSearch error:", err);
    }
  }

  showSearchResults(results) {
    if (!this.searchResultsArea || !this.searchResultsList) return;

    this.searchResultsArea.style.display = "block";
    this.searchResultsCount.textContent = `검색 결과 (${results.length}건)`;
    this.searchResultsList.innerHTML = "";

    if (results.length === 0) {
      this.searchResultsList.innerHTML = `<li class="search-no-res" style="font-size:12px; color:var(--text-muted); padding:8px;">일치하는 토픽이 없습니다.</li>`;
      return;
    }

    results.forEach(r => {
      const item = document.createElement("li");
      item.className = "search-result-item";
      item.innerHTML = `
        <div class="search-res-cat">${r.category_title}</div>
        <div class="search-res-title">${r.title} <span style="font-size:11px; font-weight:400; color:var(--text-muted);">(${r.title_en})</span></div>
        <div class="search-res-summary">${r.summary}</div>
      `;
      item.addEventListener("click", () => {
        window.location.hash = `#${r.id}`;
        this.hideSearchResults();
      });
      this.searchResultsList.appendChild(item);
    });
  }

  hideSearchResults() {
    if (this.searchResultsArea) {
      this.searchResultsArea.style.display = "none";
    }
  }
}

// Initialize on DOM ready
document.addEventListener("DOMContentLoaded", () => {
  window.manualViewer = new ManualViewer();
});
