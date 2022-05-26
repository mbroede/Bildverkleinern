using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bildverkleinern
{
    public partial class frmOK : Form
    {
        #region -- Variablen --
        private CLanguage _lang = null;
        #endregion

        #region -- properties --
        private CConfig _config;

        internal CConfig Config
        {
            get { return _config; }
            set { _config = value; }
        }
        #endregion

        #region -- ctor --
        public frmOK()
        {
            InitializeComponent();
            _lang = CLanguage.GetInstance();
            this.Text = Application.ProductName;
            this.ShowInTaskbar = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Size = new Size(150, 150);
            this.MinimumSize = this.Size;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BringToFront();

            this.timer1.Interval = 1000;
            this.timer1.Enabled = false;
        }
        #endregion

        #region -- events form --
        private void frmOK_Load(object sender, EventArgs e)
        {
            _config = new CConfig();
            _config.LoadFromIniFile();

            this.pictureBox1.Top = 45;
            this.pictureBox1.Left = Convert.ToInt32((this.Width - this.pictureBox1.Width) / 2) - 1;
            this.lblDone.Top = this.pictureBox1.Top + this.pictureBox1.Height + 5;
            this.lblDone.Left = Convert.ToInt32((this.Width - this.lblDone.Width) / 2);
            this.lblDone.Text = _lang.GetString("OkDone");
            this.timer1.Enabled = true;
        }
        #endregion

        #region -- event timer --
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.Close();
        }
        #endregion
    }
}
