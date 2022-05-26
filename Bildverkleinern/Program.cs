using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Bildverkleinern
{
	static class Program
	{
        #region -- Main --
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            // Das Programm nur einmal starten
            bool alwaysrunning = false;
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        alwaysrunning = true;
                        break;
                    }
                }
            }
            if (alwaysrunning)
            {
                Application.Exit();
                return;
            }

            // Parameter übergeben?
            if (args.Length > 0)
            {
                string ImgFileName = args[0];
                if (System.IO.File.Exists(ImgFileName))
                {
                    frmMain frm = new frmMain();
                    try
                    {
                        if (frm.FiletypeIsValid(ImgFileName))
                        {
                            frm.CreateSmallerImage(ImgFileName);
                            frmOK fok = new frmOK();
                            fok.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, frm.ErrorboxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        frm.Close();
                    }
                }
            }
            else
            {
                Application.Run(new frmMain());
            }
		}
        #endregion
    }
}
