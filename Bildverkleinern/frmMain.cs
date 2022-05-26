using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Bildverkleinern
{
	public partial class frmMain : Form
	{
		#region -- Enums --
		enum ProcessState
        {
			Normal,
			Error,
			Ok
        }
		#endregion

		#region -- Variablen --
		private int _x;
		private int _y;
		private bool _mousedown = false;
		private CConfig _config;
		private CLanguage _lang = null;
		private string _allowedFormats = ",.BMP,.JPG,.JPEG,.PNG,";
		private string _err = string.Empty;
		private List<Rectangle> lstAllWorkareas = new List<Rectangle>();
        #endregion

        #region -- Properties --
        public string ErrorboxCaption
		{ 
			get
            {
				return _lang.GetString("ErrorBoxCaption");
			}
		}
		#endregion

		#region -- ctor --
		public frmMain()
		{
			InitializeComponent();
			_lang = CLanguage.GetInstance();
			this.Text = Application.ProductName;
			this.StartPosition = FormStartPosition.Manual;
			this.Location = new Point(50, 50);
			this.Size = new Size(0, 0);
			this.Text = Application.ProductName;
		}
		#endregion

		#region -- Events (Form) --
		private void frmMain_Load(object sender, EventArgs e)
		{
			this.ContextMenuStrip = this.ContextMenuMain;
			foreach (var screen in Screen.AllScreens)
			{
				lstAllWorkareas.Add(screen.WorkingArea);
			}

			this.FormBorderStyle = FormBorderStyle.None;
			this.AllowDrop = true;
			this.MinimizeBox = false;
			this.MaximizeBox = false;
			this.TopMost = true;
			this.BringToFront();

			// config
			_config = new CConfig();
			_config.LoadFromIniFile();
			this.Width = _config.DropFrameDiameter;
			this.Height = _config.DropFrameDiameter;
			this.Top = _config.DropFrameTop;
			this.Left = _config.DropFrameLeft;
			SyncFormPosition();
			LoadLanguage();

			// Ein Timer für Fehlermeldungen (Zeit geben für invalidate & co)
			this.timerRefresh.Enabled = false;
			this.timerRefresh.Interval = 300;

			// Events zuweisen
			this.Paint += FrmMain_Paint;
			this.MouseDown += new MouseEventHandler(frmMain_MouseDown);
			this.MouseMove += new MouseEventHandler(frmMain_MouseMove);
			this.MouseUp += new MouseEventHandler(frmMain_MouseUp);
			this.MouseDoubleClick += new MouseEventHandler(frmMain_MouseDoubleClick);
			this.DragEnter += frmMain_DragEnter;
			this.DragDrop += frmMain_DragDrop;
            this.timerRefresh.Tick += timerRefresh_Tick;
            this.cmnuMainConfig.Click += cmnuMainConfig_Click;
            this.cmnuMainClose.Click += cmnuMainClose_Click;
		}

		private void FrmMain_Paint(object sender, PaintEventArgs e)
		{
			SetFrameGraphics(e.Graphics, ProcessState.Normal);
		}

		private void frmMain_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			// Programm beenden
			_config.DropFrameTop = this.Top;
			_config.DropFrameLeft = this.Left;
			_config.SaveToIniFile();
			this.Close();
		}

		private void frmMain_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				_x = e.X;
				_y = e.Y;
				_mousedown = true;
			}
		}

		private void frmMain_MouseMove(object sender, MouseEventArgs e)
		{
			if (_mousedown)
			{
				Point ptOL = this.PointToScreen(new Point(e.X - _x, e.Y - _y));
				Point ptOR = new Point(ptOL.X + this.Width, ptOL.Y);
				Point ptUR = new Point(ptOL.X + this.Width, ptOL.Y + this.Height);
				Point ptUL = new Point(ptOL.X, ptOL.Y + this.Height);
				foreach (var rect in lstAllWorkareas)
				{
					if (rect.Contains(ptOL) && rect.Contains(ptOR) && rect.Contains(ptUR) && rect.Contains(ptUL))
					{
						this.Location = ptOL;
						return;
					}
				}
			}
		}

		private void frmMain_MouseUp(object sender, MouseEventArgs e)
		{
			_mousedown = false;
		}
		#endregion

		#region -- Events (drag) --
		private void frmMain_DragEnter(object sender, DragEventArgs e)
		{
			if (!e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.None; // Unknown data, ignore it
				return;
			}

			string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			if (fileList.Length != 1)
			{
				e.Effect = DragDropEffects.None;
				return;
			}

			bool ok = FiletypeIsValid(fileList[0]);
			if (!ok)
			{
				e.Effect = DragDropEffects.None;
				return;
			}

			// Alles ok
			e.Effect = DragDropEffects.Copy;
		}

		private void frmMain_DragDrop(object sender, DragEventArgs e)
		{
			string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			_err = string.Empty;
			try
			{
				CreateSmallerImage(fileList[0]);
			}
			catch (Exception ex)
			{
				_err = ex.Message;
			}
			if (string.IsNullOrEmpty(_err))
			{
				SetFrameGraphics(null, ProcessState.Ok);
			}
			else
			{
				SetFrameGraphics(null, ProcessState.Error);
			}
			this.timerRefresh.Enabled = true;
		}
		#endregion

		#region -- Events (Contextmenu) --
		private void cmnuMainConfig_Click(object sender, EventArgs e)
		{
			frmConfig frm = new frmConfig();
			frm.Config = _config;
			if (frm.ShowDialog() == DialogResult.OK)
			{
				this.Width = _config.DropFrameDiameter;
				this.Height = _config.DropFrameDiameter;
				SyncFormPosition();
				this.Invalidate();
				LoadLanguage();
			}
		}

		private void cmnuMainClose_Click(object sender, EventArgs e)
		{
			this.frmMain_MouseDoubleClick(null, null);
		}
		#endregion

		#region -- Events (timer) --
		private void timerRefresh_Tick(object sender, EventArgs e)
		{
			this.timerRefresh.Enabled = false;
			if (!string.IsNullOrEmpty(_err))
			{
				MessageBox.Show(_err, _lang.GetString("ErrorboxTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			SetFrameGraphics(null, ProcessState.Normal);
		}
		#endregion

		#region -- public methods --
		public bool FiletypeIsValid(string aImgFileName)
		{
			string sSuffix = Path.GetExtension(aImgFileName).ToUpper();
			bool ok = false;
			foreach (string s in _allowedFormats.Split(','))
			{
				if (s.Equals(sSuffix))
				{
					ok = true;
					break;
				}
			}
			return ok;
		}

		public void CreateSmallerImage(string originalName)
		{
			// Beim Aufruf via Parameterübergabe wird das Load-Event des Formulars nicht ausgeführt, so dass _config noch null ist. 
			if (_config == null)
			{
				_config = new CConfig();
				_config.LoadFromIniFile();
				LoadLanguage();
			}
			string fname = string.Concat(_lang.GetString("NewFilenamePraefix"), Path.GetFileNameWithoutExtension(originalName));
			CConvertImage cnv = new CConvertImage();
			cnv.PathNameNew = Path.Combine(_config.DestinationDirectory, string.Concat(fname, Path.GetExtension(originalName).ToLower()));
			cnv.PathNameOri = originalName;
			cnv.KeepRatio = _config.KeepRatio;
			if (_config.KeepRatio)
			{
				cnv.SizeNew = new System.Drawing.Size(_config.NewMaxImageDimension, _config.NewMaxImageDimension);
			}
			else
			{
				cnv.SizeNew = new System.Drawing.Size(_config.NewImageWidth, _config.NewImageHeight);
			}
			cnv.OverwriteDestinationFile = _config.OverwriteDestinationFile;
			cnv.JpegCompression = _config.JpegCompression;
			bool ok = cnv.CreateNewImageFile();
			if (!ok)
			{
				string sErr = string.Empty;
				switch (cnv.ErrorNumber)
				{
					case (int)ConvertError.DestinationDirectoryNotFount:
						sErr = string.Format(_lang.GetString("CnvDestinationDirectoryNotFount"), _config.DestinationDirectory);
						break;
					case (int)ConvertError.FileAlreadyExists:
						sErr = string.Format(_lang.GetString("CnvFileAlreadyExists"), cnv.PathNameNew);
						break;
					case (int)ConvertError.OriImageFileNotFount:
						sErr = string.Format(_lang.GetString("CnvOriImageFileNotFount"), cnv.PathNameOri);
						break;
					case (int)ConvertError.UnknownImageFormat:
						sErr = string.Format(_lang.GetString("CnvUnknownImageFormat"), cnv.PathNameOri);
						break;
					default:
						sErr = cnv.ErrorMessage;
						break;
				}
				throw new Exception(String.Format(_lang.GetString("ProcessErrorEx"), sErr));
			}
		}
		#endregion

		#region -- SyncFormPosition --
		private void SyncFormPosition()
		{
			// Zwei Bildschirme haben z.B. folgende Rectangles
			// rect	{X =     0   Y = 0   Width = 1920   Height = 1040} -- Bildschirm 1
			// rect	{X = -1920   Y = 4   Width = 1920   Height = 1040} -- Bildschirm 2
			bool ok = false;
			Point pt = new Point(this.Left, this.Top); 
			foreach (var rect in lstAllWorkareas)
			{
				if (rect.Contains(pt))
				{
					if (pt.X + this.Width > rect.X + rect.Width)
                    {
						pt.X = rect.X + rect.Width - this.Width;
					}
					if (pt.Y + this.Height > rect.Height)
                    {
						pt.Y = rect.Height - this.Height;
                    }
					ok = true;
					break;
				}
			}
			this.Location = ok ? pt : new Point(20, 20);
		}
		#endregion

		#region -- SetFrameGraphics --
		private void SetFrameGraphics(Graphics graph, ProcessState procstate)
		{
			Color colBase, colCentre, colBorder;
			int durchm = _config.DropFrameDiameter;

			if (graph == null)
			{
				graph = this.CreateGraphics();
			}
			graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; // HighQuality; // .AntiAlias;

			switch (procstate)
			{
				case ProcessState.Normal:
					colBase = Color.White;
					colCentre = Color.Black;
					colBorder = Color.SkyBlue;
					break;
				case ProcessState.Error:
					colBase = Color.Red;
					colCentre = Color.Black;
					colBorder = Color.Red;
					break;
				case ProcessState.Ok:
					colBase = Color.LightGreen;
					colCentre = Color.Black;
					colBorder = Color.LightGreen;
					break;
				default:
					colBase = Color.White;
					colCentre = Color.Black;
					colBorder = Color.SkyBlue;
					break;
			}

			// Das rundet das Frame ab
			System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
			path.AddEllipse(new Rectangle(0, 0, durchm, durchm));
			this.Region = new Region(path);

			// Die Grundfarbe des nunmehr runden Frames
			graph.FillEllipse(new SolidBrush(colBase), 0, 0, durchm, durchm);

			// Einen ausgefüllten Kreis in der Mitte
			int radFilled = Convert.ToInt32(Math.Floor /*Ceiling*/ (durchm / 2 / 2 / 10.0) * 10.0);
			graph.FillEllipse(new SolidBrush(colCentre), durchm / 2 - radFilled, durchm / 2 - radFilled, radFilled * 2, radFilled * 2);

			// Die Ringe (im Zentrum weiß, außen schwarz)
			Pen penCircleW = new Pen(Color.White, 1);
			Pen penCircleB = new Pen(Color.Black, 1);
			for (int r = 0; r * 2 < durchm; r += 10) // Den äußeren Ring wegen Alias-Problemen hier nicht zeichnen. 
			{
				graph.DrawEllipse(r > radFilled ? penCircleB : penCircleW, durchm / 2 - r, durchm / 2 - r, r * 2, r * 2);
			}

			// Jetzt der äußere Ring als dicke Randlinie andersfarbig)
			graph.DrawEllipse(new Pen(colBorder, 19), 0, 0, durchm, durchm);

			// Das Fadenkreuz
			graph.DrawLine(penCircleB,
				new Point(durchm / 2, 0),
				new Point(durchm / 2, durchm));
			graph.DrawLine(penCircleW,
				new Point(durchm / 2, durchm / 2 - radFilled),
				new Point(durchm / 2, durchm / 2 + radFilled));
			graph.DrawLine(penCircleB,
				new Point(0, durchm / 2),
				new Point(durchm, durchm / 2));
			graph.DrawLine(penCircleW,
				new Point(durchm / 2 - radFilled, durchm / 2),
				new Point(durchm / 2 + radFilled, durchm / 2));
		}
		#endregion

		#region -- privates --
		private void LoadLanguage()
		{
			_lang.Index = _config.LanguageIndex;
			_lang.SetObjectText(this.cmnuMainClose, "MainCmnuMainClose");
			_lang.SetObjectText(this.cmnuMainConfig, "MainCmnuMainConfig");
		}
		#endregion
	}
}
