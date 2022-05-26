namespace Bildverkleinern
{
    partial class frmConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.txtDestinationDirectory = new System.Windows.Forms.TextBox();
            this.lblDestDir = new System.Windows.Forms.Label();
            this.btnSelectDirectory = new System.Windows.Forms.Button();
            this.cmbNewSize = new System.Windows.Forms.ComboBox();
            this.rbNewSizeRatio = new System.Windows.Forms.RadioButton();
            this.gbNewSize = new System.Windows.Forms.GroupBox();
            this.lblCnfNewSizeInfo = new System.Windows.Forms.Label();
            this.lblNewSizeExactInfo = new System.Windows.Forms.Label();
            this.lblNewSizeFitInfo = new System.Windows.Forms.Label();
            this.udHeight = new System.Windows.Forms.NumericUpDown();
            this.udWidth = new System.Windows.Forms.NumericUpDown();
            this.lblNewSizeHeight = new System.Windows.Forms.Label();
            this.lblNewSizeWidth = new System.Windows.Forms.Label();
            this.lblNewSizeWidthHeight = new System.Windows.Forms.Label();
            this.rbNewSizeExact = new System.Windows.Forms.RadioButton();
            this.cmbDropFrameSize = new System.Windows.Forms.ComboBox();
            this.lblDropFrameSize = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCompressionPercent = new System.Windows.Forms.Label();
            this.udJpegCompression = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDefault = new System.Windows.Forms.Button();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.lblDragDropInfo = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.gbNewSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udWidth)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udJpegCompression)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDestinationDirectory
            // 
            this.errorProvider.SetIconAlignment(this.txtDestinationDirectory, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtDestinationDirectory.Location = new System.Drawing.Point(28, 72);
            this.txtDestinationDirectory.Name = "txtDestinationDirectory";
            this.txtDestinationDirectory.Size = new System.Drawing.Size(461, 20);
            this.txtDestinationDirectory.TabIndex = 1;
            // 
            // lblDestDir
            // 
            this.lblDestDir.AutoSize = true;
            this.lblDestDir.Location = new System.Drawing.Point(26, 56);
            this.lblDestDir.Name = "lblDestDir";
            this.lblDestDir.Size = new System.Drawing.Size(77, 13);
            this.lblDestDir.TabIndex = 3;
            this.lblDestDir.Text = "Zielverzeichnis";
            // 
            // btnSelectDirectory
            // 
            this.btnSelectDirectory.Image = global::Bildverkleinern.Properties.Resources.folder_16x16;
            this.btnSelectDirectory.Location = new System.Drawing.Point(491, 70);
            this.btnSelectDirectory.Name = "btnSelectDirectory";
            this.btnSelectDirectory.Size = new System.Drawing.Size(28, 23);
            this.btnSelectDirectory.TabIndex = 2;
            this.btnSelectDirectory.UseVisualStyleBackColor = true;
            this.btnSelectDirectory.Click += new System.EventHandler(this.btnSelectDirectory_Click);
            // 
            // cmbNewSize
            // 
            this.cmbNewSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewSize.FormattingEnabled = true;
            this.cmbNewSize.Location = new System.Drawing.Point(168, 20);
            this.cmbNewSize.Name = "cmbNewSize";
            this.cmbNewSize.Size = new System.Drawing.Size(75, 21);
            this.cmbNewSize.TabIndex = 1;
            // 
            // rbNewSizeRatio
            // 
            this.rbNewSizeRatio.AutoSize = true;
            this.rbNewSizeRatio.Location = new System.Drawing.Point(13, 21);
            this.rbNewSizeRatio.Name = "rbNewSizeRatio";
            this.rbNewSizeRatio.Size = new System.Drawing.Size(61, 17);
            this.rbNewSizeRatio.TabIndex = 0;
            this.rbNewSizeRatio.TabStop = true;
            this.rbNewSizeRatio.Text = "Viereck";
            this.rbNewSizeRatio.UseVisualStyleBackColor = true;
            this.rbNewSizeRatio.CheckedChanged += new System.EventHandler(this.rbNewSizeProfil_CheckedChanged);
            // 
            // gbNewSize
            // 
            this.gbNewSize.Controls.Add(this.lblCnfNewSizeInfo);
            this.gbNewSize.Controls.Add(this.lblNewSizeExactInfo);
            this.gbNewSize.Controls.Add(this.lblNewSizeFitInfo);
            this.gbNewSize.Controls.Add(this.udHeight);
            this.gbNewSize.Controls.Add(this.udWidth);
            this.gbNewSize.Controls.Add(this.lblNewSizeHeight);
            this.gbNewSize.Controls.Add(this.lblNewSizeWidth);
            this.gbNewSize.Controls.Add(this.lblNewSizeWidthHeight);
            this.gbNewSize.Controls.Add(this.rbNewSizeExact);
            this.gbNewSize.Controls.Add(this.rbNewSizeRatio);
            this.gbNewSize.Controls.Add(this.cmbNewSize);
            this.gbNewSize.Location = new System.Drawing.Point(29, 137);
            this.gbNewSize.Name = "gbNewSize";
            this.gbNewSize.Size = new System.Drawing.Size(333, 170);
            this.gbNewSize.TabIndex = 6;
            this.gbNewSize.TabStop = false;
            this.gbNewSize.Text = "Neue Bildgröße (Pixel)";
            // 
            // lblCnfNewSizeInfo
            // 
            this.lblCnfNewSizeInfo.AutoSize = true;
            this.lblCnfNewSizeInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCnfNewSizeInfo.Location = new System.Drawing.Point(11, 147);
            this.lblCnfNewSizeInfo.Name = "lblCnfNewSizeInfo";
            this.lblCnfNewSizeInfo.Size = new System.Drawing.Size(189, 13);
            this.lblCnfNewSizeInfo.TabIndex = 16;
            this.lblCnfNewSizeInfo.Text = "Ein kleineres Bild wird nicht vergrößert.";
            // 
            // lblNewSizeExactInfo
            // 
            this.lblNewSizeExactInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNewSizeExactInfo.Location = new System.Drawing.Point(29, 109);
            this.lblNewSizeExactInfo.Name = "lblNewSizeExactInfo";
            this.lblNewSizeExactInfo.Size = new System.Drawing.Size(238, 30);
            this.lblNewSizeExactInfo.TabIndex = 15;
            this.lblNewSizeExactInfo.Text = "(Das Bild erhält genau die angegebene Größe. Das Seitenverhältnis des Originals w" +
    "ird ignoriert.)";
            // 
            // lblNewSizeFitInfo
            // 
            this.lblNewSizeFitInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNewSizeFitInfo.Location = new System.Drawing.Point(29, 43);
            this.lblNewSizeFitInfo.Name = "lblNewSizeFitInfo";
            this.lblNewSizeFitInfo.Size = new System.Drawing.Size(278, 32);
            this.lblNewSizeFitInfo.TabIndex = 14;
            this.lblNewSizeFitInfo.Text = "(Das Bild wird in das Viereck eingepaßt, wobei das Seitenverhältnis des Originals" +
    " erhalten bleibt.)";
            // 
            // udHeight
            // 
            this.udHeight.Location = new System.Drawing.Point(243, 86);
            this.udHeight.Name = "udHeight";
            this.udHeight.Size = new System.Drawing.Size(64, 20);
            this.udHeight.TabIndex = 4;
            // 
            // udWidth
            // 
            this.udWidth.Location = new System.Drawing.Point(130, 86);
            this.udWidth.Name = "udWidth";
            this.udWidth.Size = new System.Drawing.Size(64, 20);
            this.udWidth.TabIndex = 3;
            // 
            // lblNewSizeHeight
            // 
            this.lblNewSizeHeight.AutoSize = true;
            this.lblNewSizeHeight.Location = new System.Drawing.Point(205, 89);
            this.lblNewSizeHeight.Name = "lblNewSizeHeight";
            this.lblNewSizeHeight.Size = new System.Drawing.Size(36, 13);
            this.lblNewSizeHeight.TabIndex = 9;
            this.lblNewSizeHeight.Text = "Höhe:";
            // 
            // lblNewSizeWidth
            // 
            this.lblNewSizeWidth.AutoSize = true;
            this.lblNewSizeWidth.Location = new System.Drawing.Point(90, 88);
            this.lblNewSizeWidth.Name = "lblNewSizeWidth";
            this.lblNewSizeWidth.Size = new System.Drawing.Size(37, 13);
            this.lblNewSizeWidth.TabIndex = 8;
            this.lblNewSizeWidth.Text = "Breite:";
            // 
            // lblNewSizeWidthHeight
            // 
            this.lblNewSizeWidthHeight.AutoSize = true;
            this.lblNewSizeWidthHeight.Location = new System.Drawing.Point(91, 23);
            this.lblNewSizeWidthHeight.Name = "lblNewSizeWidthHeight";
            this.lblNewSizeWidthHeight.Size = new System.Drawing.Size(65, 13);
            this.lblNewSizeWidthHeight.TabIndex = 7;
            this.lblNewSizeWidthHeight.Text = "Breite/Höhe";
            // 
            // rbNewSizeExact
            // 
            this.rbNewSizeExact.AutoSize = true;
            this.rbNewSizeExact.Location = new System.Drawing.Point(13, 86);
            this.rbNewSizeExact.Name = "rbNewSizeExact";
            this.rbNewSizeExact.Size = new System.Drawing.Size(57, 17);
            this.rbNewSizeExact.TabIndex = 2;
            this.rbNewSizeExact.TabStop = true;
            this.rbNewSizeExact.Text = "Genau";
            this.rbNewSizeExact.UseVisualStyleBackColor = true;
            this.rbNewSizeExact.CheckedChanged += new System.EventHandler(this.rbNewSizeManual_CheckedChanged);
            // 
            // cmbDropFrameSize
            // 
            this.cmbDropFrameSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDropFrameSize.FormattingEnabled = true;
            this.cmbDropFrameSize.Location = new System.Drawing.Point(225, 21);
            this.cmbDropFrameSize.Name = "cmbDropFrameSize";
            this.cmbDropFrameSize.Size = new System.Drawing.Size(73, 21);
            this.cmbDropFrameSize.TabIndex = 0;
            // 
            // lblDropFrameSize
            // 
            this.lblDropFrameSize.AutoSize = true;
            this.lblDropFrameSize.Location = new System.Drawing.Point(26, 24);
            this.lblDropFrameSize.Name = "lblDropFrameSize";
            this.lblDropFrameSize.Size = new System.Drawing.Size(193, 13);
            this.lblDropFrameSize.TabIndex = 8;
            this.lblDropFrameSize.Text = "Durchmesser des Fadenkreuzes (Pixel):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCompressionPercent);
            this.groupBox1.Controls.Add(this.udJpegCompression);
            this.groupBox1.Location = new System.Drawing.Point(375, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 66);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Jpeg-Compression";
            // 
            // lblCompressionPercent
            // 
            this.lblCompressionPercent.AutoSize = true;
            this.lblCompressionPercent.Location = new System.Drawing.Point(9, 32);
            this.lblCompressionPercent.Name = "lblCompressionPercent";
            this.lblCompressionPercent.Size = new System.Drawing.Size(46, 13);
            this.lblCompressionPercent.TabIndex = 1;
            this.lblCompressionPercent.Text = "Prozent:";
            // 
            // udJpegCompression
            // 
            this.udJpegCompression.Location = new System.Drawing.Point(69, 29);
            this.udJpegCompression.Name = "udJpegCompression";
            this.udJpegCompression.Size = new System.Drawing.Size(59, 20);
            this.udJpegCompression.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Image = global::Bildverkleinern.Properties.Resources.ok_16x16;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(160, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(92, 29);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Bildverkleinern.Properties.Resources.cancel_16x16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(264, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.btnDefault);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 371);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 40);
            this.panel1.TabIndex = 10;
            // 
            // btnDefault
            // 
            this.btnDefault.Image = global::Bildverkleinern.Properties.Resources.action_undo_16x16;
            this.btnDefault.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDefault.Location = new System.Drawing.Point(450, 9);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(67, 23);
            this.btnDefault.TabIndex = 11;
            this.btnDefault.Text = "Default";
            this.btnDefault.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Location = new System.Drawing.Point(30, 101);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(194, 17);
            this.chkOverwrite.TabIndex = 3;
            this.chkOverwrite.Text = "Vorhandene Dateien überschreiben";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // lblDragDropInfo
            // 
            this.lblDragDropInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDragDropInfo.Location = new System.Drawing.Point(310, 21);
            this.lblDragDropInfo.Name = "lblDragDropInfo";
            this.lblDragDropInfo.Size = new System.Drawing.Size(207, 35);
            this.lblDragDropInfo.TabIndex = 16;
            this.lblDragDropInfo.Text = "(Um ein Bild zu verkleinern ziehen Sie es per Drag && Drop auf das Fadenkreuz.)";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            "Deutsch",
            "English"});
            this.cmbLanguage.Location = new System.Drawing.Point(387, 251);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(121, 21);
            this.cmbLanguage.TabIndex = 17;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(386, 233);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(50, 13);
            this.lblLanguage.TabIndex = 18;
            this.lblLanguage.Text = "Sprache:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(56, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "Main icon by Icojam, Blue Bits Icons, ";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.linkLabel1.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.linkLabel1.Location = new System.Drawing.Point(213, 323);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(279, 12);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.iconarchive.com/show/blue-bits-icons-by-icojam.html";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(137, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "Control images by Axialis Team,";
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.linkLabel2.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.linkLabel2.Location = new System.Drawing.Point(274, 336);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(104, 12);
            this.linkLabel2.TabIndex = 22;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "http://www.axialis.com";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(28, 313);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(488, 1);
            this.panel2.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(152, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "Allowed image types: BMP, JPG, JPEG, PNG";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 411);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.lblDragDropInfo);
            this.Controls.Add(this.chkOverwrite);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDropFrameSize);
            this.Controls.Add(this.cmbDropFrameSize);
            this.Controls.Add(this.gbNewSize);
            this.Controls.Add(this.lblDestDir);
            this.Controls.Add(this.btnSelectDirectory);
            this.Controls.Add(this.txtDestinationDirectory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConfig";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.gbNewSize.ResumeLayout(false);
            this.gbNewSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udWidth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udJpegCompression)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDestinationDirectory;
        private System.Windows.Forms.Button btnSelectDirectory;
        private System.Windows.Forms.Label lblDestDir;
        private System.Windows.Forms.ComboBox cmbNewSize;
        private System.Windows.Forms.RadioButton rbNewSizeRatio;
        private System.Windows.Forms.GroupBox gbNewSize;
        private System.Windows.Forms.Label lblNewSizeFitInfo;
        private System.Windows.Forms.NumericUpDown udHeight;
        private System.Windows.Forms.NumericUpDown udWidth;
        private System.Windows.Forms.Label lblNewSizeHeight;
        private System.Windows.Forms.Label lblNewSizeWidth;
        private System.Windows.Forms.Label lblNewSizeWidthHeight;
        private System.Windows.Forms.RadioButton rbNewSizeExact;
        private System.Windows.Forms.ComboBox cmbDropFrameSize;
        private System.Windows.Forms.Label lblDropFrameSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCompressionPercent;
        private System.Windows.Forms.NumericUpDown udJpegCompression;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Label lblNewSizeExactInfo;
        private System.Windows.Forms.Label lblDragDropInfo;
        private System.Windows.Forms.Label lblCnfNewSizeInfo;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
    }
}