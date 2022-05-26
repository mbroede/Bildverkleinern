using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Bildverkleinern
{
    class CConfig
    {
        #region -- DLLImports --
        [DllImport("kernel32.dll")]
        private static extern bool WritePrivateProfileString(
            string lpAppName,  // section name
            string lpKeyName,  // key name
            string lpString,   // string to add
            string lpFileName  // initialization file
            );
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpdefault,
            StringBuilder sbout,
            int nsize,
            string lpFileName
            );
        #endregion

        #region -- IniWrite-Methods --
        private bool IniWriteString(string aSection, string aKey, string aValue)
        {
            return WritePrivateProfileString(aSection, aKey, aValue, _inifilename);
        }

        private bool IniWriteInt32(string aSection, string aKey, Int32 aValue)
        {
            return WritePrivateProfileString(aSection, aKey, aValue.ToString(), _inifilename);
        }

        private bool IniWriteBool(string aSection, string aKey, bool aValue)
        {
            return WritePrivateProfileString(aSection, aKey, aValue ? "1" : "0", _inifilename);
        }

        private bool IniDeleteSection(string aSection)
        {
            return WritePrivateProfileString(aSection, null, null, _inifilename);
        }
        #endregion

        #region -- IniRead-Methods --
        private string IniReadString(string aSection, string aKey)
        {
            return IniReadString(aSection, aKey, string.Empty);
        }

        private string IniReadString(string aSection, string aKey, string aDefault)
        {
            StringBuilder sb = new StringBuilder(1000);
            int rc = GetPrivateProfileString(aSection, aKey, "", sb, sb.Capacity, _inifilename);
            return (rc > 0 ? sb.ToString() : aDefault);
        }

        private int IniReadInt32(string aSection, string aKey)
        {
            return IniReadInt32(aSection, aKey, 0);
        }

        private int IniReadInt32(string aSection, string aKey, int aDefault)
        {
            string s = IniReadString(aSection, aKey);
            if (!string.IsNullOrEmpty(s))
            {
                int i;
                bool ok = Int32.TryParse(s, out i);
                if (ok)
                {
                    return i;
                }
            }
            return aDefault;
        }

        private bool IniReadBool(string aSection, string aKey)
        {
            return IniReadBool(aSection, aKey, false);
        }

        private bool IniReadBool(string aSection, string aKey, bool aDefault)
        {
            string s = IniReadString(aSection, aKey);
            return (s != "0" && s != "1") ? aDefault : s == "1";
        }
        #endregion

        #region -- Variablen --
        private string _inifilename = string.Empty;
        #endregion

        #region -- Properties --
        private int _DropFrameDiameter;

        public int DropFrameDiameter
        {
            get { return _DropFrameDiameter; }
            set { _DropFrameDiameter = value; }
        }

        private int _DropFrameTop;

        public int DropFrameTop
        {
            get { return _DropFrameTop; }
            set { _DropFrameTop = value; }
        }

        private int _DropFrameLeft;

        public int DropFrameLeft
        {
            get { return _DropFrameLeft; }
            set { _DropFrameLeft = value; }
        }

        private bool _KeepRatio;

        public bool KeepRatio
        {
            get { return _KeepRatio; }
            set { _KeepRatio = value; }
        }

        private int _NewMaxImageDimension;

        public int NewMaxImageDimension
        {
            get { return _NewMaxImageDimension; }
            set { _NewMaxImageDimension = value; }
        }

        private int _NewImageWidth;

        public int NewImageWidth
        {
            get { return _NewImageWidth; }
            set { _NewImageWidth = value; }
        }

        private int _NewImageHeight;

        public int NewImageHeight
        {
            get { return _NewImageHeight; }
            set { _NewImageHeight = value; }
        }

        private string _DestinationDirectory;

        public string DestinationDirectory
        {
            get { return _DestinationDirectory; }
            set { _DestinationDirectory = value; }
        }

        private bool _OverwriteDestinationFile;

        public bool OverwriteDestinationFile
        {
            get { return _OverwriteDestinationFile; }
            set { _OverwriteDestinationFile = value; }
        }

        private int _JpegCompression;

        public int JpegCompression
        {
            get { return _JpegCompression; }
            set { _JpegCompression = value; }
        }

        private int _LanguageIndex;

        public int LanguageIndex
        {
            get { return _LanguageIndex; }
            set { _LanguageIndex = value; }
        }
        #endregion

        #region -- ctor --
        public CConfig()
        {
            InitConfig();
        }
        #endregion

        #region -- LoadFromIniFile --
        public void LoadFromIniFile()
        {
            if (!File.Exists(_inifilename))
            {
                InitConfig();
                return;
            }

            string sSection = string.Empty;
            int iValue;
            sSection = "General";
            iValue = IniReadInt32(sSection, "DropFrameDiameter");
            _DropFrameDiameter = iValue >= 80 && iValue <= 200 && iValue % 20 == 0 ? iValue : 100; // TODO Modulo prüfen
            _DropFrameTop = IniReadInt32(sSection, "DropFrameTop", 50);
            _DropFrameLeft = IniReadInt32(sSection, "DropFrameLeft", 50);
            _KeepRatio = IniReadBool(sSection, "KeepRatio", _KeepRatio);
            _NewMaxImageDimension = IniReadInt32(sSection, "NewMaxImageDimension", _NewMaxImageDimension); 
            _NewImageWidth = IniReadInt32(sSection, "NewImageWidth", _NewImageWidth);
            _NewImageHeight = IniReadInt32(sSection, "NewImageHeight", _NewImageHeight);
            _DestinationDirectory = IniReadString(sSection, "DestinationDirectory", _DestinationDirectory);
            _OverwriteDestinationFile = IniReadBool(sSection, "OverwriteDestinationFile", _OverwriteDestinationFile);
            _JpegCompression = IniReadInt32(sSection, "JpegCompression", _JpegCompression);
            _LanguageIndex = IniReadInt32(sSection, "LanguageIndex", _LanguageIndex);
        }
        #endregion

        #region -- SaveToIniFile --
        public void SaveToIniFile()
        {
            if (!File.Exists(_inifilename))
            {
                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(_inifilename)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(_inifilename));
                    }
                    using (var fil = File.Create(_inifilename))
                    {
                    }
                }
                catch
                {
                }
            }

            string sSection = string.Empty;
            sSection = "General";
            IniWriteInt32(sSection, "DropFrameDiameter", _DropFrameDiameter);
            IniWriteInt32(sSection, "DropFrameTop", _DropFrameTop);
            IniWriteInt32(sSection, "DropFrameLeft", _DropFrameLeft);
            IniWriteBool(sSection, "KeepRatio", _KeepRatio);
            IniWriteInt32(sSection, "NewMaxImageDimension", _NewMaxImageDimension);
            IniWriteInt32(sSection, "NewImageWidth", _NewImageWidth);
            IniWriteInt32(sSection, "NewImageHeight", _NewImageHeight);
            IniWriteString(sSection, "DestinationDirectory", _DestinationDirectory);
            IniWriteBool(sSection, "OverwriteDestinationFile", _OverwriteDestinationFile);
            IniWriteInt32(sSection, "JpegCompression", _JpegCompression);
            IniWriteInt32(sSection, "LanguageIndex", _LanguageIndex);
        }
        #endregion

        #region -- InitConfig --
        private void InitConfig()
        {
            _inifilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Path.Combine(Path.GetFileNameWithoutExtension(Application.ExecutablePath),
                Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".ini"));
            _DropFrameDiameter = 100;
            _DropFrameTop = 100;
            _DropFrameLeft = 100;
            _KeepRatio = true;
            _NewMaxImageDimension = 1000;
            _NewImageWidth = 1200;
            _NewImageHeight = 900;
            _DestinationDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            _OverwriteDestinationFile = false;
            _JpegCompression = 90;
            _LanguageIndex = 0;
        }
        #endregion
    }
}
