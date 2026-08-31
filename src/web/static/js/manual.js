/**
 * CFDesigner Online Help Manual Frontend Script
 * Handles TOC loading, topic routing, real-time search, KaTeX math rendering, and theme toggling.
 */

class ManualViewer {
  constructor() {
    this.categories = [];
    this.allTopics = [];
    this.currentTopicId = null;
    this.searchDebounceTimer = null;

    // DOM Elements
    this.tocNav = document.getElementById("manualTocNav");
    this.articleContent = document.getElementById("manualArticleContent");
    this.bcCategory = document.getElementById("bcCategory");
    this.bcTopic = document.getElementById("bcTopic");
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

    this.init();
  }

  async init() {
    this.initTheme();
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

  bindEvents() {
    // Theme toggle
    if (this.btnTheme) {
      this.btnTheme.addEventListener("click", () => {
        const current = document.body.getAttribute("data-theme") || "dark";
        const nextTheme = current === "dark" ? "light" : "dark";
        document.body.setAttribute("data-theme", nextTheme);
        localStorage.setItem("cfdesigner-theme", nextTheme);
      });
    }

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
        // Ensure parent category is not collapsed
        const header = item.closest(".toc-category")?.querySelector(".toc-cat-header");
        if (header && header.classList.contains("collapsed")) {
          header.classList.remove("collapsed");
        }
      } else {
        item.classList.remove("active");
      }
    });

    // Render loading state
    this.articleContent.innerHTML = `
      <div class="article-loading">
        <div class="spinner"></div>
        <p>문서를 불러오는 중입니다...</p>
      </div>
    `;

    try {
      const res = await fetch(`/api/manual/topic/${topicId}`);
      if (!res.ok) throw new Error("Topic not found");
      const topicData = await res.json();

      // Update Breadcrumbs
      if (this.bcCategory) this.bcCategory.textContent = topicData.category_title;
      if (this.bcTopic) this.bcTopic.textContent = topicData.title;

      // Render content
      this.articleContent.innerHTML = topicData.content_html;

      // Render KaTeX equations
      this.renderEquations();

      // Update Pager buttons
      this.updatePager();

      // Scroll top of reader
      const wrapper = document.querySelector(".manual-content-wrapper");
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

  renderEquations() {
    if (window.renderMathInElement) {
      window.renderMathInElement(this.articleContent, {
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
        <div class="search-res-title">${r.title}</div>
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
