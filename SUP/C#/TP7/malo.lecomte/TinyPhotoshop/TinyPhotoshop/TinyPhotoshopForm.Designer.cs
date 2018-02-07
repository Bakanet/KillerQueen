namespace TinyPhotoshop
{
	partial class TinyPhotoshopForm
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.ToolStripMenuItem textEncrypt;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TinyPhotoshopForm));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.Open = new System.Windows.Forms.ToolStripButton();
			this.Save = new System.Windows.Forms.ToolStripButton();
			this.Reset = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.Encrypt = new System.Windows.Forms.ToolStripDropDownButton();
			this.TextToEncrypt = new System.Windows.Forms.ToolStripTextBox();
			this.imageEncrypt = new System.Windows.Forms.ToolStripMenuItem();
			this.Decrypt = new System.Windows.Forms.ToolStripDropDownButton();
			this.textDecrypt = new System.Windows.Forms.ToolStripMenuItem();
			this.imageDecrypt = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.Filter = new System.Windows.Forms.ToolStripDropDownButton();
			this.greyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.binarizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.binarizeColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.negativeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tinterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Geometry = new System.Windows.Forms.ToolStripDropDownButton();
			this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.shiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mirrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.horizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.verticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.leftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.widthStripTextBox = new System.Windows.Forms.ToolStripTextBox();
			this.Width = new System.Windows.Forms.ToolStripTextBox();
			this.heightStripTextBox = new System.Windows.Forms.ToolStripTextBox();
			this.Height = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.Convolution = new System.Windows.Forms.ToolStripDropDownButton();
			this.Gauss = new System.Windows.Forms.ToolStripMenuItem();
			this.contrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.blurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.edgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rehToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.detectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.embossToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Advanced = new System.Windows.Forms.ToolStripDropDownButton();
			this.nashvilleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.Auto_Contrast = new System.Windows.Forms.ToolStripButton();
			this.Mine = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.Image = new System.Windows.Forms.PictureBox();
			this.OpenFile = new System.Windows.Forms.OpenFileDialog();
			this.SaveFile = new System.Windows.Forms.SaveFileDialog();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.colorButton = new System.Windows.Forms.ToolStripButton();
			this.showColor = new System.Windows.Forms.ToolStripButton();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.transparentIn = new System.Windows.Forms.NumericUpDown();
			textEncrypt = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Image)).BeginInit();
			this.toolStrip2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.transparentIn)).BeginInit();
			this.SuspendLayout();
			// 
			// textEncrypt
			// 
			textEncrypt.Name = "textEncrypt";
			textEncrypt.Size = new System.Drawing.Size(160, 22);
			textEncrypt.Text = "Text";
			textEncrypt.Click += new System.EventHandler(this.textEncrypt_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open,
            this.Save,
            this.Reset,
            this.toolStripSeparator2,
            this.Encrypt,
            this.Decrypt,
            this.toolStripSeparator1,
            this.Filter,
            this.Geometry,
            this.toolStripSeparator3,
            this.Convolution,
            this.Advanced,
            this.toolStripSeparator4,
            this.Auto_Contrast,
            this.Mine,
            this.toolStripSeparator8,
            this.toolStripProgressBar1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(947, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// Open
			// 
			this.Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Open.Image = ((System.Drawing.Image)(resources.GetObject("Open.Image")));
			this.Open.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Open.Name = "Open";
			this.Open.Size = new System.Drawing.Size(40, 22);
			this.Open.Text = "Open";
			this.Open.Click += new System.EventHandler(this.Open_Click);
			// 
			// Save
			// 
			this.Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Save.Image = ((System.Drawing.Image)(resources.GetObject("Save.Image")));
			this.Save.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Save.Name = "Save";
			this.Save.Size = new System.Drawing.Size(35, 22);
			this.Save.Text = "Save";
			this.Save.Click += new System.EventHandler(this.Save_Click);
			// 
			// Reset
			// 
			this.Reset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Reset.Image = ((System.Drawing.Image)(resources.GetObject("Reset.Image")));
			this.Reset.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Reset.Name = "Reset";
			this.Reset.Size = new System.Drawing.Size(39, 22);
			this.Reset.Text = "Reset";
			this.Reset.Click += new System.EventHandler(this.Reset_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// Encrypt
			// 
			this.Encrypt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Encrypt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            textEncrypt,
            this.TextToEncrypt,
            this.imageEncrypt});
			this.Encrypt.Image = ((System.Drawing.Image)(resources.GetObject("Encrypt.Image")));
			this.Encrypt.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Encrypt.Name = "Encrypt";
			this.Encrypt.Size = new System.Drawing.Size(60, 22);
			this.Encrypt.Text = "Encrypt";
			this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
			// 
			// TextToEncrypt
			// 
			this.TextToEncrypt.Name = "TextToEncrypt";
			this.TextToEncrypt.Size = new System.Drawing.Size(100, 23);
			this.TextToEncrypt.Click += new System.EventHandler(this.TextToEncrypt_Click);
			// 
			// imageEncrypt
			// 
			this.imageEncrypt.Name = "imageEncrypt";
			this.imageEncrypt.Size = new System.Drawing.Size(160, 22);
			this.imageEncrypt.Text = "Image";
			this.imageEncrypt.Click += new System.EventHandler(this.imageEncrypt_Click);
			// 
			// Decrypt
			// 
			this.Decrypt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Decrypt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textDecrypt,
            this.imageDecrypt});
			this.Decrypt.Image = ((System.Drawing.Image)(resources.GetObject("Decrypt.Image")));
			this.Decrypt.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Decrypt.Name = "Decrypt";
			this.Decrypt.Size = new System.Drawing.Size(61, 22);
			this.Decrypt.Text = "Decrypt";
			this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
			// 
			// textDecrypt
			// 
			this.textDecrypt.Name = "textDecrypt";
			this.textDecrypt.Size = new System.Drawing.Size(107, 22);
			this.textDecrypt.Text = "Text";
			this.textDecrypt.Click += new System.EventHandler(this.textDecrypt_Click);
			// 
			// imageDecrypt
			// 
			this.imageDecrypt.Name = "imageDecrypt";
			this.imageDecrypt.Size = new System.Drawing.Size(107, 22);
			this.imageDecrypt.Text = "Image";
			this.imageDecrypt.Click += new System.EventHandler(this.imageDecrypt_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// Filter
			// 
			this.Filter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Filter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.greyToolStripMenuItem,
            this.binarizeToolStripMenuItem,
            this.binarizeColorToolStripMenuItem,
            this.negativeToolStripMenuItem,
            this.tinterToolStripMenuItem});
			this.Filter.Image = ((System.Drawing.Image)(resources.GetObject("Filter.Image")));
			this.Filter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Filter.Name = "Filter";
			this.Filter.Size = new System.Drawing.Size(46, 22);
			this.Filter.Text = "Filter";
			this.Filter.Click += new System.EventHandler(this.Filter_Click);
			// 
			// greyToolStripMenuItem
			// 
			this.greyToolStripMenuItem.Name = "greyToolStripMenuItem";
			this.greyToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.greyToolStripMenuItem.Text = "Grey";
			this.greyToolStripMenuItem.Click += new System.EventHandler(this.greyToolStripMenuItem_Click);
			// 
			// binarizeToolStripMenuItem
			// 
			this.binarizeToolStripMenuItem.Name = "binarizeToolStripMenuItem";
			this.binarizeToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.binarizeToolStripMenuItem.Text = "Binarize";
			this.binarizeToolStripMenuItem.Click += new System.EventHandler(this.binarizeToolStripMenuItem_Click);
			// 
			// binarizeColorToolStripMenuItem
			// 
			this.binarizeColorToolStripMenuItem.Name = "binarizeColorToolStripMenuItem";
			this.binarizeColorToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.binarizeColorToolStripMenuItem.Text = "Binarize Color";
			this.binarizeColorToolStripMenuItem.Click += new System.EventHandler(this.binarizeColorToolStripMenuItem_Click);
			// 
			// negativeToolStripMenuItem
			// 
			this.negativeToolStripMenuItem.Name = "negativeToolStripMenuItem";
			this.negativeToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.negativeToolStripMenuItem.Text = "Negative";
			this.negativeToolStripMenuItem.Click += new System.EventHandler(this.negativeToolStripMenuItem_Click);
			// 
			// tinterToolStripMenuItem
			// 
			this.tinterToolStripMenuItem.Name = "tinterToolStripMenuItem";
			this.tinterToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.tinterToolStripMenuItem.Text = "Tinter";
			this.tinterToolStripMenuItem.Click += new System.EventHandler(this.tinterToolStripMenuItem_Click);
			// 
			// Geometry
			// 
			this.Geometry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Geometry.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeToolStripMenuItem,
            this.shiftToolStripMenuItem,
            this.mirrorToolStripMenuItem,
            this.rotationToolStripMenuItem,
            this.toolStripSeparator5,
            this.widthStripTextBox,
            this.Width,
            this.heightStripTextBox,
            this.Height});
			this.Geometry.Image = ((System.Drawing.Image)(resources.GetObject("Geometry.Image")));
			this.Geometry.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Geometry.Name = "Geometry";
			this.Geometry.Size = new System.Drawing.Size(72, 22);
			this.Geometry.Text = "Geometry";
			this.Geometry.Click += new System.EventHandler(this.Geometry_Click);
			// 
			// resizeToolStripMenuItem
			// 
			this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
			this.resizeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.resizeToolStripMenuItem.Text = "Resize";
			this.resizeToolStripMenuItem.Click += new System.EventHandler(this.resizeToolStripMenuItem_Click);
			// 
			// shiftToolStripMenuItem
			// 
			this.shiftToolStripMenuItem.Name = "shiftToolStripMenuItem";
			this.shiftToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.shiftToolStripMenuItem.Text = "Shift";
			this.shiftToolStripMenuItem.Click += new System.EventHandler(this.shiftToolStripMenuItem_Click);
			// 
			// mirrorToolStripMenuItem
			// 
			this.mirrorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontallyToolStripMenuItem,
            this.verticallyToolStripMenuItem,
            this.pointToolStripMenuItem});
			this.mirrorToolStripMenuItem.Name = "mirrorToolStripMenuItem";
			this.mirrorToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.mirrorToolStripMenuItem.Text = "Symmetry";
			this.mirrorToolStripMenuItem.Click += new System.EventHandler(this.mirrorToolStripMenuItem_Click);
			// 
			// horizontallyToolStripMenuItem
			// 
			this.horizontallyToolStripMenuItem.Name = "horizontallyToolStripMenuItem";
			this.horizontallyToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.horizontallyToolStripMenuItem.Text = "Horizontal";
			this.horizontallyToolStripMenuItem.Click += new System.EventHandler(this.horizontallyToolStripMenuItem_Click);
			// 
			// verticallyToolStripMenuItem
			// 
			this.verticallyToolStripMenuItem.Name = "verticallyToolStripMenuItem";
			this.verticallyToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.verticallyToolStripMenuItem.Text = "Vertical";
			this.verticallyToolStripMenuItem.Click += new System.EventHandler(this.verticallyToolStripMenuItem_Click);
			// 
			// pointToolStripMenuItem
			// 
			this.pointToolStripMenuItem.Name = "pointToolStripMenuItem";
			this.pointToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.pointToolStripMenuItem.Text = "Point";
			this.pointToolStripMenuItem.Click += new System.EventHandler(this.pointToolStripMenuItem_Click);
			// 
			// rotationToolStripMenuItem
			// 
			this.rotationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftToolStripMenuItem,
            this.rightToolStripMenuItem});
			this.rotationToolStripMenuItem.Name = "rotationToolStripMenuItem";
			this.rotationToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.rotationToolStripMenuItem.Text = "Rotation";
			this.rotationToolStripMenuItem.Click += new System.EventHandler(this.rotationToolStripMenuItem_Click);
			// 
			// leftToolStripMenuItem
			// 
			this.leftToolStripMenuItem.Name = "leftToolStripMenuItem";
			this.leftToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
			this.leftToolStripMenuItem.Text = "Left";
			this.leftToolStripMenuItem.Click += new System.EventHandler(this.leftToolStripMenuItem_Click);
			// 
			// rightToolStripMenuItem
			// 
			this.rightToolStripMenuItem.Name = "rightToolStripMenuItem";
			this.rightToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
			this.rightToolStripMenuItem.Text = "Right";
			this.rightToolStripMenuItem.Click += new System.EventHandler(this.rightToolStripMenuItem_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(157, 6);
			// 
			// widthStripTextBox
			// 
			this.widthStripTextBox.Name = "widthStripTextBox";
			this.widthStripTextBox.ReadOnly = true;
			this.widthStripTextBox.Size = new System.Drawing.Size(100, 23);
			this.widthStripTextBox.Text = "X :";
			this.widthStripTextBox.Click += new System.EventHandler(this.widthStripTextBox_Click);
			// 
			// Width
			// 
			this.Width.Name = "Width";
			this.Width.Size = new System.Drawing.Size(100, 23);
			this.Width.Click += new System.EventHandler(this.Width_Click);
			// 
			// heightStripTextBox
			// 
			this.heightStripTextBox.Name = "heightStripTextBox";
			this.heightStripTextBox.ReadOnly = true;
			this.heightStripTextBox.Size = new System.Drawing.Size(100, 23);
			this.heightStripTextBox.Text = "Y :";
			this.heightStripTextBox.Click += new System.EventHandler(this.heightStripTextBox_Click);
			// 
			// Height
			// 
			this.Height.Name = "Height";
			this.Height.Size = new System.Drawing.Size(100, 23);
			this.Height.Click += new System.EventHandler(this.Height_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// Convolution
			// 
			this.Convolution.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Convolution.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Gauss,
            this.contrastToolStripMenuItem,
            this.blurToolStripMenuItem,
            this.edgeToolStripMenuItem,
            this.embossToolStripMenuItem});
			this.Convolution.Image = ((System.Drawing.Image)(resources.GetObject("Convolution.Image")));
			this.Convolution.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Convolution.Name = "Convolution";
			this.Convolution.Size = new System.Drawing.Size(86, 22);
			this.Convolution.Text = "Convolution";
			this.Convolution.Click += new System.EventHandler(this.Convolution_Click);
			// 
			// Gauss
			// 
			this.Gauss.Name = "Gauss";
			this.Gauss.Size = new System.Drawing.Size(117, 22);
			this.Gauss.Text = "Gauss";
			this.Gauss.Click += new System.EventHandler(this.Gauss_Click);
			// 
			// contrastToolStripMenuItem
			// 
			this.contrastToolStripMenuItem.Name = "contrastToolStripMenuItem";
			this.contrastToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.contrastToolStripMenuItem.Text = "Sharpen";
			this.contrastToolStripMenuItem.Click += new System.EventHandler(this.contrastToolStripMenuItem_Click);
			// 
			// blurToolStripMenuItem
			// 
			this.blurToolStripMenuItem.Name = "blurToolStripMenuItem";
			this.blurToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.blurToolStripMenuItem.Text = "Blur";
			this.blurToolStripMenuItem.Click += new System.EventHandler(this.blurToolStripMenuItem_Click);
			// 
			// edgeToolStripMenuItem
			// 
			this.edgeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rehToolStripMenuItem,
            this.detectionToolStripMenuItem});
			this.edgeToolStripMenuItem.Name = "edgeToolStripMenuItem";
			this.edgeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.edgeToolStripMenuItem.Text = "Edge";
			this.edgeToolStripMenuItem.Click += new System.EventHandler(this.edgeToolStripMenuItem_Click);
			// 
			// rehToolStripMenuItem
			// 
			this.rehToolStripMenuItem.Name = "rehToolStripMenuItem";
			this.rehToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
			this.rehToolStripMenuItem.Text = "Enhance";
			this.rehToolStripMenuItem.Click += new System.EventHandler(this.rehToolStripMenuItem_Click);
			// 
			// detectionToolStripMenuItem
			// 
			this.detectionToolStripMenuItem.Name = "detectionToolStripMenuItem";
			this.detectionToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
			this.detectionToolStripMenuItem.Text = "Detect";
			this.detectionToolStripMenuItem.Click += new System.EventHandler(this.detectionToolStripMenuItem_Click);
			// 
			// embossToolStripMenuItem
			// 
			this.embossToolStripMenuItem.Name = "embossToolStripMenuItem";
			this.embossToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.embossToolStripMenuItem.Text = "Emboss";
			this.embossToolStripMenuItem.Click += new System.EventHandler(this.embossToolStripMenuItem_Click);
			// 
			// Advanced
			// 
			this.Advanced.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Advanced.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nashvilleToolStripMenuItem,
            this.toasterToolStripMenuItem});
			this.Advanced.Image = ((System.Drawing.Image)(resources.GetObject("Advanced.Image")));
			this.Advanced.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Advanced.Name = "Advanced";
			this.Advanced.Size = new System.Drawing.Size(73, 22);
			this.Advanced.Text = "Advanced";
			this.Advanced.Click += new System.EventHandler(this.Advanced_Click);
			// 
			// nashvilleToolStripMenuItem
			// 
			this.nashvilleToolStripMenuItem.Name = "nashvilleToolStripMenuItem";
			this.nashvilleToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.nashvilleToolStripMenuItem.Text = "Nashville";
			this.nashvilleToolStripMenuItem.Click += new System.EventHandler(this.nashvilleToolStripMenuItem_Click);
			// 
			// toasterToolStripMenuItem
			// 
			this.toasterToolStripMenuItem.Name = "toasterToolStripMenuItem";
			this.toasterToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.toasterToolStripMenuItem.Text = "Toaster";
			this.toasterToolStripMenuItem.Click += new System.EventHandler(this.toasterToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// Auto_Contrast
			// 
			this.Auto_Contrast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Auto_Contrast.Image = ((System.Drawing.Image)(resources.GetObject("Auto_Contrast.Image")));
			this.Auto_Contrast.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Auto_Contrast.Name = "Auto_Contrast";
			this.Auto_Contrast.Size = new System.Drawing.Size(85, 22);
			this.Auto_Contrast.Text = "Auto Contrast";
			this.Auto_Contrast.Click += new System.EventHandler(this.Auto_Contrast_Click);
			// 
			// Mine
			// 
			this.Mine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Mine.Image = ((System.Drawing.Image)(resources.GetObject("Mine.Image")));
			this.Mine.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Mine.Name = "Mine";
			this.Mine.Size = new System.Drawing.Size(38, 22);
			this.Mine.Text = "Mine";
			this.Mine.Click += new System.EventHandler(this.Mine_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(268, 22);
			this.toolStripProgressBar1.Step = 1;
			this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.toolStripProgressBar1.Click += new System.EventHandler(this.toolStripProgressBar1_Click);
			// 
			// Image
			// 
			this.Image.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Image.Image = ((System.Drawing.Image)(resources.GetObject("Image.Image")));
			this.Image.Location = new System.Drawing.Point(12, 54);
			this.Image.Name = "Image";
			this.Image.Size = new System.Drawing.Size(932, 615);
			this.Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Image.TabIndex = 1;
			this.Image.TabStop = false;
			this.Image.Click += new System.EventHandler(this.Image_Click);
			// 
			// OpenFile
			// 
			this.OpenFile.FileName = "OpenFile";
			// 
			// toolStrip2
			// 
			this.toolStrip2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorButton,
            this.showColor,
            this.toolStripLabel2});
			this.toolStrip2.Location = new System.Drawing.Point(0, 25);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(155, 25);
			this.toolStrip2.TabIndex = 2;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// colorButton
			// 
			this.colorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.colorButton.Image = ((System.Drawing.Image)(resources.GetObject("colorButton.Image")));
			this.colorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.colorButton.Name = "colorButton";
			this.colorButton.Size = new System.Drawing.Size(40, 22);
			this.colorButton.Text = "Color";
			this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
			// 
			// showColor
			// 
			this.showColor.AutoToolTip = false;
			this.showColor.BackColor = System.Drawing.Color.Black;
			this.showColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
			this.showColor.Enabled = false;
			this.showColor.ForeColor = System.Drawing.Color.Black;
			this.showColor.Image = ((System.Drawing.Image)(resources.GetObject("showColor.Image")));
			this.showColor.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.showColor.Name = "showColor";
			this.showColor.Size = new System.Drawing.Size(23, 22);
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(80, 22);
			this.toolStripLabel2.Text = "Transparency:";
			// 
			// transparentIn
			// 
			this.transparentIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.transparentIn.Location = new System.Drawing.Point(150, 28);
			this.transparentIn.Name = "transparentIn";
			this.transparentIn.Size = new System.Drawing.Size(50, 20);
			this.transparentIn.TabIndex = 3;
			// 
			// TinyPhotoshopForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(956, 681);
			this.Controls.Add(this.transparentIn);
			this.Controls.Add(this.toolStrip2);
			this.Controls.Add(this.Image);
			this.Controls.Add(this.toolStrip1);
			this.Name = "TinyPhotoshopForm";
			this.Text = "TinyPhotoshop";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Image)).EndInit();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.transparentIn)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton Open;
		private System.Windows.Forms.ToolStripButton Save;
		private System.Windows.Forms.OpenFileDialog OpenFile;
		private System.Windows.Forms.SaveFileDialog SaveFile;
		private System.Windows.Forms.ToolStripButton Reset;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripDropDownButton Filter;
		private System.Windows.Forms.ToolStripMenuItem greyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem binarizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem binarizeColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem negativeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tinterToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton Geometry;
		private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem shiftToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mirrorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem horizontallyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem verticallyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pointToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rotationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem leftToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rightToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripDropDownButton Convolution;
		private System.Windows.Forms.ToolStripDropDownButton Advanced;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton Auto_Contrast;
		private System.Windows.Forms.ToolStripButton Mine;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripMenuItem contrastToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem blurToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem edgeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rehToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem detectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem embossToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nashvilleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toasterToolStripMenuItem;
		public System.Windows.Forms.PictureBox Image;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripTextBox widthStripTextBox;
		private System.Windows.Forms.ToolStripTextBox Width;
		private System.Windows.Forms.ToolStripTextBox heightStripTextBox;
		private System.Windows.Forms.ToolStripTextBox Height;
		private System.Windows.Forms.ToolStripMenuItem Gauss;
		private System.Windows.Forms.ToolStripDropDownButton Encrypt;
		private System.Windows.Forms.ToolStripTextBox TextToEncrypt;
		private System.Windows.Forms.ToolStripMenuItem imageEncrypt;
		private System.Windows.Forms.ToolStripDropDownButton Decrypt;
		private System.Windows.Forms.ToolStripMenuItem textDecrypt;
		private System.Windows.Forms.ToolStripMenuItem imageDecrypt;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton showColor;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton colorButton;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.NumericUpDown transparentIn;
    }
}

