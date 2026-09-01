/**
 * 3D Buckling Mode Shape Viewer (Three.js WebGL)
 * Renders 3D deformed shell surface along length with harmonic displacement animation.
 */

class BucklingViewer3D {
  constructor(containerId) {
    this.container = document.getElementById(containerId);
    this.scene = null;
    this.camera = null;
    this.renderer = null;
    this.mesh = null;
    this.wireframeMesh = null;

    this.nodes = [];
    this.strips = [];
    this.currentModeKey = 'local_mode'; // local_mode, dist_mode, glob_mode
    this.amplitude = 15.0; // Deformation scaling factor
    this.time = 0;
    this.isAnimating = true;

    // Camera control states
    this.isDragging = false;
    this.prevMouseX = 0;
    this.prevMouseY = 0;
    this.rotX = 0.5;
    this.rotY = 0.6;
    this.cameraDistance = 400;
    this.theme = 'dark';
    this.ambientLight = null;
    this.dirLight1 = null;
    this.dirLight2 = null;

    this.initThree();
    this.initControls();
    this.animate();
  }

  initThree() {
    const w = this.container.clientWidth || 600;
    const h = this.container.clientHeight || 400;

    this.scene = new THREE.Scene();
    this.scene.background = new THREE.Color(this.theme === 'light' ? 0xf8fafc : 0x0f172a);

    this.camera = new THREE.PerspectiveCamera(45, w / h, 5, 3500);
    this.updateCamera();

    this.renderer = new THREE.WebGLRenderer({ antialias: true, alpha: true, powerPreference: 'high-performance' });
    this.renderer.setSize(w, h);
    this.renderer.setPixelRatio(Math.min(window.devicePixelRatio || 1, 2));
    this.container.appendChild(this.renderer.domElement);

    // Lights
    this.ambientLight = new THREE.AmbientLight(0xffffff, this.theme === 'light' ? 0.9 : 0.7);
    this.scene.add(this.ambientLight);

    this.dirLight1 = new THREE.DirectionalLight(0x38bdf8, this.theme === 'light' ? 1.4 : 1.2);
    this.dirLight1.position.set(200, 300, 400);
    this.scene.add(this.dirLight1);

    this.dirLight2 = new THREE.DirectionalLight(0x818cf8, this.theme === 'light' ? 0.9 : 0.8);
    this.dirLight2.position.set(-200, -200, -300);
    this.scene.add(this.dirLight2);

    window.addEventListener('resize', () => this.onResize());
  }

  setTheme(theme) {
    this.theme = theme;
    if (this.scene) {
      this.scene.background = new THREE.Color(theme === 'light' ? 0xf8fafc : 0x0f172a);
    }
    if (this.ambientLight) {
      this.ambientLight.intensity = theme === 'light' ? 0.9 : 0.7;
    }
    if (this.dirLight1) {
      this.dirLight1.intensity = theme === 'light' ? 1.4 : 1.2;
    }
    if (this.dirLight2) {
      this.dirLight2.intensity = theme === 'light' ? 0.9 : 0.8;
    }
  }

  showLoading(message = '⏳ FSM 좌굴해석 재계산 중...') {
    if (!this.loadingBadge) {
      this.loadingBadge = document.createElement('div');
      this.loadingBadge.className = 'viewer-3d-loading-badge';
      if (this.container && this.container.parentElement) {
        this.container.parentElement.appendChild(this.loadingBadge);
      }
    }
    if (this.loadingBadge) {
      this.loadingBadge.innerText = message;
      this.loadingBadge.style.display = 'flex';
    }
    if (this.container) {
      this.container.classList.add('canvas-blur-loading');
    }
  }

  hideLoading() {
    if (this.loadingBadge) {
      this.loadingBadge.style.display = 'none';
    }
    if (this.container) {
      this.container.classList.remove('canvas-blur-loading');
    }
  }

  initControls() {
    const el = this.renderer.domElement;

    el.addEventListener('mousedown', (e) => {
      this.isDragging = true;
      this.prevMouseX = e.clientX;
      this.prevMouseY = e.clientY;
    });

    window.addEventListener('mousemove', (e) => {
      if (!this.isDragging) return;
      const dx = e.clientX - this.prevMouseX;
      const dy = e.clientY - this.prevMouseY;

      this.rotY += dx * 0.008;
      this.rotX += dy * 0.008;
      this.rotX = Math.max(-Math.PI / 2 + 0.1, Math.min(Math.PI / 2 - 0.1, this.rotX));

      this.prevMouseX = e.clientX;
      this.prevMouseY = e.clientY;
      this.updateCamera();
    });

    window.addEventListener('mouseup', () => {
      this.isDragging = false;
    });

    el.addEventListener('wheel', (e) => {
      e.preventDefault();
      this.cameraDistance *= e.deltaY > 0 ? 1.1 : 0.9;
      this.cameraDistance = Math.max(50, Math.min(2500, this.cameraDistance));
      this.updateCamera();
    });
  }

  updateCamera() {
    this.camera.position.x = this.cameraDistance * Math.cos(this.rotX) * Math.sin(this.rotY);
    this.camera.position.y = this.cameraDistance * Math.sin(this.rotX);
    this.camera.position.z = this.cameraDistance * Math.cos(this.rotX) * Math.cos(this.rotY);
    this.camera.lookAt(0, 0, 0);
  }

  onResize() {
    const w = this.container.clientWidth;
    const h = this.container.clientHeight;
    if (w > 0 && h > 0) {
      this.camera.aspect = w / h;
      this.camera.updateProjectionMatrix();
      this.renderer.setSize(w, h);
    }
  }

  setData(nodes, strips, modeKey = 'local_mode') {
    this.hideLoading();
    this.nodes = nodes || [];
    this.strips = strips || [];
    this.currentModeKey = modeKey;
    this.buildGeometry();
  }

  setMode(modeKey) {
    this.currentModeKey = modeKey;
    this.buildGeometry();
  }

  buildGeometry() {
    if (this.mesh) {
      this.scene.remove(this.mesh);
      this.mesh.geometry.dispose();
      this.mesh = null;
    }
    if (this.wireframeMesh) {
      this.scene.remove(this.wireframeMesh);
      this.wireframeMesh.geometry.dispose();
      this.wireframeMesh = null;
    }

    if (!this.nodes || this.nodes.length === 0) return;

    const numZ = 24; // Longitudinal segments
    const lengthZ = 200; // Visual length
    const geometry = new THREE.BufferGeometry();

    const positions = [];
    const colors = [];
    const indices = [];

    // Construct grid of vertices along length Z
    const numNodes = this.nodes.length;

    for (let iz = 0; iz <= numZ; iz++) {
      const zFrac = iz / numZ;
      const z = (zFrac - 0.5) * lengthZ;
      const sinZ = Math.sin(zFrac * Math.PI); // Half-sine buckling wave

      for (let inod = 0; inod < numNodes; inod++) {
        const n = this.nodes[inod];
        const disp = n[this.currentModeKey] || [0, 0, 0, 0];
        const u = disp[0] || 0; // X disp
        const v = disp[1] || 0; // Y disp

        const defX = n.x + u * this.amplitude * sinZ;
        const defY = n.y + v * this.amplitude * sinZ;

        positions.push(defX, defY, z);

        // Color based on displacement magnitude
        const dispMag = Math.sqrt(u * u + v * v) * Math.abs(sinZ);
        const col = new THREE.Color().setHSL(0.6 - Math.min(dispMag * 0.4, 0.6), 1.0, 0.5);
        colors.push(col.r, col.g, col.b);
      }
    }

    // Build Triangles along strips (Single-sided indexed, rendered with THREE.DoubleSide)
    for (let iz = 0; iz < numZ; iz++) {
      const row1 = iz * numNodes;
      const row2 = (iz + 1) * numNodes;

      for (const strip of this.strips) {
        const n1 = strip.node_i;
        const n2 = strip.node_j;

        const a = row1 + n1;
        const b = row1 + n2;
        const c = row2 + n2;
        const d = row2 + n1;

        // Counter-clockwise CCW quad split into 2 triangles
        indices.push(a, b, c);
        indices.push(a, c, d);
      }
    }

    geometry.setAttribute('position', new THREE.Float32BufferAttribute(positions, 3));
    geometry.setAttribute('color', new THREE.Float32BufferAttribute(colors, 3));
    geometry.setIndex(indices);
    geometry.computeVertexNormals();

    // Solid Shell Surface Material with Polygon Offset to prevent Z-Fighting with wireframe
    const material = new THREE.MeshStandardMaterial({
      vertexColors: true,
      roughness: 0.35,
      metalness: 0.15,
      side: THREE.DoubleSide,
      polygonOffset: true,
      polygonOffsetFactor: 1.0,
      polygonOffsetUnits: 4.0
    });

    this.mesh = new THREE.Mesh(geometry, material);
    this.scene.add(this.mesh);

    // Clean overlay wireframe without depth conflicts
    const wireMat = new THREE.MeshBasicMaterial({
      color: 0x64748b,
      wireframe: true,
      transparent: true,
      opacity: 0.35,
      depthTest: true,
      depthWrite: false
    });
    this.wireframeMesh = new THREE.Mesh(geometry, wireMat);
    this.scene.add(this.wireframeMesh);
  }

  animate() {
    requestAnimationFrame(() => this.animate());

    if (this.isAnimating && this.mesh) {
      this.time += 0.04;
      const osc = Math.sin(this.time);
      const positions = this.mesh.geometry.attributes.position.array;
      const numZ = 24;
      const numNodes = this.nodes.length;
      let ptr = 0;

      for (let iz = 0; iz <= numZ; iz++) {
        const zFrac = iz / numZ;
        const sinZ = Math.sin(zFrac * Math.PI) * osc;

        for (let inod = 0; inod < numNodes; inod++) {
          const n = this.nodes[inod];
          const disp = n[this.currentModeKey] || [0, 0, 0, 0];
          positions[ptr] = n.x + disp[0] * this.amplitude * sinZ;
          positions[ptr + 1] = n.y + disp[1] * this.amplitude * sinZ;
          ptr += 3;
        }
      }
      this.mesh.geometry.attributes.position.needsUpdate = true;
      this.mesh.geometry.computeVertexNormals();
    }

    this.renderer.render(this.scene, this.camera);
  }
}
