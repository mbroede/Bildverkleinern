using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Bildverkleinern
{
    public partial class frmConfig : Form
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
        public frmConfig()
        {
            InitializeComponent();
            _lang = CLanguage.GetInstance();

            this.cmbDropFrameSize.Items.Clear();
            // Durchmesser immer ein Vielfaches von 20, da die Ringe einen Abstand von 10 px haben.
            this.cmbDropFrameSize.Items.Add("80");
            this.cmbDropFrameSize.Items.Add("100");
            this.cmbDropFrameSize.Items.Add("120");
            this.cmbDropFrameSize.Items.Add("140");
            this.cmbDropFrameSize.Items.Add("160");
            this.cmbDropFrameSize.Items.Add("180");
            this.cmbDropFrameSize.Items.Add("200");
            this.cmbDropFrameSize.SelectedIndex = 0;

            this.cmbNewSize.Items.Clear();
            this.cmbNewSize.Items.Add("100");
            this.cmbNewSize.Items.Add("150");
            this.cmbNewSize.Items.Add("200");
            this.cmbNewSize.Items.Add("250");
            this.cmbNewSize.Items.Add("300");
            this.cmbNewSize.Items.Add("400");
            this.cmbNewSize.Items.Add("500");
            this.cmbNewSize.Items.Add("600");
            this.cmbNewSize.Items.Add("800");
            this.cmbNewSize.Items.Add("1000");
            this.cmbNewSize.Items.Add("1200");
            this.cmbNewSize.Items.Add("1500");
            this.cmbNewSize.Items.Add("2000");
            this.cmbNewSize.SelectedIndex = 0;

            this.udWidth.Minimum = 1;
            this.udWidth.Maximum = 5000;
            this.udHeight.Minimum = 1;
            this.udHeight.Maximum = 5000;

            this.udJpegCompression.Minimum = 1;
            this.udJpegCompression.Maximum = 100;

            this.cmbLanguage.Items.Clear();
            for (int i = 0; i < _lang.LangNames.Length; i++)
            {
                this.cmbLanguage.Items.Add(_lang.LangNames[i].Description);
            }
            this.cmbLanguage.SelectedIndex = 0;
        }
        #endregion

        #region -- events (form) --
        private void frmConfig_Load(object sender, EventArgs e)
        {
            _lang.Index = _config.LanguageIndex;
            this.cmbLanguage.SelectedIndex = _config.LanguageIndex;
            this.cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            FormLoad();
        }

        private void FormLoad()
        {
            _lang.SetObjectText(this, "CnfFormTitle");
            _lang.SetObjectText(this.lblDropFrameSize, "CnfDropFrameSize");
            _lang.SetObjectText(this.lblDragDropInfo, "CnfDragDropInfo");
            _lang.SetObjectText(this.lblDestDir, "CnfDestinationDirectory");
            _lang.SetObjectText(this.chkOverwrite, "CnfOverwriteExistingFile");
            _lang.SetObjectText(this.gbNewSize, "CnfGroupboxNewSizeCaption");
            _lang.SetObjectText(this.rbNewSizeRatio, "CnfNewSizeOptionRatio");
            _lang.SetObjectText(this.rbNewSizeExact, "CnfNewSizeOptionExact");
            _lang.SetObjectText(this.lblNewSizeWidthHeight, "CnfNewSizeWidthHeight");
            _lang.SetObjectText(this.lblNewSizeWidth, "CnfNewSizeWidth");
            _lang.SetObjectText(this.lblNewSizeHeight, "CnfNewSizeHeight");
            _lang.SetObjectText(this.lblNewSizeFitInfo, "CnfNewSizeFitInfo");
            _lang.SetObjectText(this.lblNewSizeExactInfo, "CnfNewSizeExactInfo");
            _lang.SetObjectText(this.lblCompressionPercent, "CnfJpegCompressionPercent");
            _lang.SetObjectText(this.lblLanguage, "CnfLanguage");
            _lang.SetObjectText(this.btnCancel, "CnfAbort");
            // 
            string s = string.Format("{0}", _config.DropFrameDiameter);
            if (this.cmbDropFrameSize.Items.IndexOf(s) >= 0)
            {
                this.cmbDropFrameSize.Text = s;
            }
            else
            {
                this.cmbDropFrameSize.SelectedIndex = 1; // 2=100
            }
            //
            this.txtDestinationDirectory.Text = _config.DestinationDirectory;
            //
            this.udJpegCompression.Value = Convert.ToDecimal(_config.JpegCompression);
            //
            this.udWidth.Value = Convert.ToDecimal(_config.NewImageWidth);
            this.udHeight.Value = Convert.ToDecimal(_config.NewImageHeight);
            //
            if (_config.KeepRatio)
            {
                this.rbNewSizeRatio.Checked = true;
            }
            else
            {
                this.rbNewSizeExact.Checked = true;
            }
            s = string.Format("{0}", _config.NewMaxImageDimension);
            if (this.cmbNewSize.Items.IndexOf(s) >= 0)
            {
                this.cmbNewSize.Text = s;
            }
            else
            {
                this.cmbNewSize.SelectedIndex = 9; //9=1000
            }
            SyncRadioControlsEnabled();
            _lang.SetObjectText(this.lblCnfNewSizeInfo, "CnfNewSizeInfo");
            //
            this.chkOverwrite.Checked = _config.OverwriteDestinationFile;
        }
        #endregion

        #region -- events (buttons) --
        private void btnSelectDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = false;
            dialog.Description = _lang.GetString("FolderBrowserCaption");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtDestinationDirectory.Text = dialog.SelectedPath.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (InputOK())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            CConfig cnf = new CConfig();
            this.cmbDropFrameSize.Text = cnf.DropFrameDiameter.ToString();
            this.txtDestinationDirectory.Text = cnf.DestinationDirectory;
            this.rbNewSizeRatio.Checked = cnf.KeepRatio;
            this.cmbNewSize.Text = cnf.NewMaxImageDimension.ToString();
            this.udHeight.Value = cnf.NewImageHeight;
            this.udWidth.Value = cnf.NewImageWidth;
            this.udJpegCompression.Value = cnf.JpegCompression;
            this.chkOverwrite.Checked = cnf.OverwriteDestinationFile;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void rbNewSizeProfil_CheckedChanged(object sender, EventArgs e)
        {
            SyncRadioControlsEnabled();
        }

        private void rbNewSizeManual_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lang.Index != this.cmbLanguage.SelectedIndex)
            {
                _lang.Index = this.cmbLanguage.SelectedIndex;
                FormLoad();
            }
        }
        #endregion

        #region -- events (linklabel) --
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(((LinkLabel)sender).Text);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(((LinkLabel)sender).Text);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://www.facebook.com/franz.moll.12");
        }
        #endregion

        #region -- privates --
        private bool InputOK()
        {
            bool ok = true;
            errorProvider.SetError(this.txtDestinationDirectory, "");
            if (string.IsNullOrEmpty(this.txtDestinationDirectory.Text))
            {
                errorProvider.SetError(this.txtDestinationDirectory, "Unzulässige Leereingabe"); // TODO Englisch
                ok = false;
            }
            if (!ok)
            {
                return false;
            }
            _config.DropFrameDiameter = Convert.ToInt32(cmbDropFrameSize.Text);
            _config.DestinationDirectory = this.txtDestinationDirectory.Text;
            _config.OverwriteDestinationFile = this.chkOverwrite.Checked;
            _config.JpegCompression = Convert.ToInt32(this.udJpegCompression.Value);
            _config.KeepRatio = this.rbNewSizeRatio.Checked;
            _config.NewMaxImageDimension = Convert.ToInt32(this.cmbNewSize.Text);
            _config.NewImageWidth = Convert.ToInt32(this.udWidth.Value);
            _config.NewImageHeight = Convert.ToInt32(this.udHeight.Value);
            _config.LanguageIndex = this.cmbLanguage.SelectedIndex;
            return true;
        }

        private void SyncRadioControlsEnabled()
        {
            this.lblNewSizeWidthHeight.Enabled = this.rbNewSizeRatio.Checked;
            this.cmbNewSize.Enabled = this.rbNewSizeRatio.Checked;
            this.lblNewSizeWidth.Enabled = this.rbNewSizeExact.Checked;
            this.lblNewSizeHeight.Enabled = this.rbNewSizeExact.Checked;
            this.udWidth.Enabled = this.rbNewSizeExact.Checked;
            this.udHeight.Enabled = this.rbNewSizeExact.Checked;
        }
        #endregion
    }
}
