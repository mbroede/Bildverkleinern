using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Bildverkleinern
{
    class CLanguage
    {
        #region -- struct langName --
        public struct langName
        {
            public string Name; // "en"
            public string Description; // "English"
        }
        #endregion

        #region -- variablen --
        private static CLanguage _lang = null;
        private XmlDocument _xdoc = null;
        private int _index = 0;
        private langName[] _langNames;
        #endregion

        #region -- GetInstance --
        internal static CLanguage GetInstance()
        {
            if (_lang == null)
                _lang = new CLanguage();
            return _lang;
        }
        #endregion

        #region -- ctor --
        private CLanguage()
        {
            this.Load();
        }
        #endregion

        #region -- properties --
        /// <summary>
        /// 0=Deutsch, 1=English
        /// </summary>
        internal int Index
        {
            get 
            { 
                return _index; 
            }
            set 
            {
                if (_index != value)
                {
                    _index = value;
                }
            }
        }

        internal langName[] LangNames { get => _langNames; set => _langNames = value; }
        #endregion

        #region -- Load --
        private void Load()
        {
            _xdoc = new XmlDocument();
            MemoryStream ms = new MemoryStream();
            try
            {
                string langFilename = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), 
                    "Bildverkleinern_Languages.xml");
                if (File.Exists(langFilename))
                {
                    _xdoc.Load(langFilename);
                }
                else
                {
                    string sXml = Properties.Resources.Bildverkleinern_Languages;
                    byte[] bytes = System.Text.Encoding.Default.GetBytes(sXml);
                    ms.Write(bytes, 0, bytes.Length);
                    ms.Position = 0;
                    _xdoc.Load(ms);
                }
            }
            catch (Exception)
            {
                throw;
            }

            // Languages auslesen
            try
            {
                XmlNode root, node;
                root = _xdoc.SelectSingleNode("Bildverkleinern");
                node = root.SelectSingleNode("Languages");
                int i = 0;
                _langNames = new langName[node.ChildNodes.Count];
                foreach (XmlNode child in node.ChildNodes)
                {
                    _langNames[i].Name = child.InnerText; // de
                    _langNames[i].Description = child.Name; // Deutsch
                    i++;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region -- SetObjectText --
        internal void SetObjectText(object aObject, string aKey)
        {
            string s = this.GetString(aKey);
            if (string.IsNullOrEmpty(s))
                return;

            Type t = aObject.GetType();
            switch (t.Name)
            {
                case "ToolStripMenuItem":
                    ((ToolStripMenuItem)aObject).Text = s;
                    break;
                case "frmConfig":
                    ((frmConfig)aObject).Text = s;
                    break;
                case "Label":
                    ((Label)aObject).Text = s;
                    break;
                case "CheckBox":
                    ((CheckBox)aObject).Text = s;
                    break;
                case "GroupBox":
                    ((GroupBox)aObject).Text = s;
                    break;
                case "RadioButton":
                    ((RadioButton)aObject).Text = s;
                    break;
                case "Button":
                    ((Button)aObject).Text = s;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region -- GetString --
        internal string GetString(string aKey)
        {
            XmlNode root, node, child;
            root = _xdoc.SelectSingleNode("Bildverkleinern");
            node = root.SelectSingleNode(aKey);
            child = node.SelectSingleNode(_langNames[_index].Name);
            return child.InnerText.Replace(@"\n", Environment.NewLine);
        }
        #endregion
    }
}
