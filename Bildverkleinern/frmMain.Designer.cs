namespace Bildverkleinern
{
	partial class frmMain
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ContextMenuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuMainClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuMainConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.ContextMenuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContextMenuMain
            // 
            this.ContextMenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuMainClose,
            this.toolStripMenuItem1,
            this.cmnuMainConfig});
            this.ContextMenuMain.Name = "ContextMenuMain";
            this.ContextMenuMain.Size = new System.Drawing.Size(181, 54);
            // 
            // cmnuMainClose
            // 
            this.cmnuMainClose.Image = global::Bildverkleinern.Properties.Resources.standby_16x16;
            this.cmnuMainClose.Name = "cmnuMainClose";
            this.cmnuMainClose.Size = new System.Drawing.Size(180, 22);
            this.cmnuMainClose.Text = "Programm beenden";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // cmnuMainConfig
            // 
            this.cmnuMainConfig.Image = global::Bildverkleinern.Properties.Resources.gear_16x16;
            this.cmnuMainConfig.Name = "cmnuMainConfig";
            this.cmnuMainConfig.Size = new System.Drawing.Size(180, 22);
            this.cmnuMainConfig.Text = "Konfiguration";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 286);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ContextMenuMain.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip ContextMenuMain;
		private System.Windows.Forms.ToolStripMenuItem cmnuMainClose;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem cmnuMainConfig;
        private System.Windows.Forms.Timer timerRefresh;
    }
}

