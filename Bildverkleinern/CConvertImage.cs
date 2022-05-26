using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using System.Drawing.Imaging;

namespace Bildverkleinern
{
    #region -- enum ConvertError --
    public enum ConvertError
    {
        OriImageFileNotFount = 1,
        DestinationDirectoryNotFount = 2,
        FileAlreadyExists = 3,
        UnknownImageFormat = 4,
    }
    #endregion

    class CConvertImage
    {
        #region -- properties --
        private string _PathNameOri = string.Empty;

        public string PathNameOri
        {
            get { return _PathNameOri; }
            set { _PathNameOri = value; }
        }

        private string _PathNameNew = string.Empty;

        public string PathNameNew
        {
            get { return _PathNameNew; }
            set { _PathNameNew = value; }
        }

        private bool _KeepRatio = true;

        public bool KeepRatio
        {
            get { return _KeepRatio; }
            set { _KeepRatio = value; }
        }

        private Size _SizeNew = new Size(-1, -1);

        public Size SizeNew
        {
            get { return _SizeNew; }
            set { _SizeNew = value; }
        }

        private int _JpegCompression = 90;

        public int JpegCompression
        {
            get { return _JpegCompression; }
            set { _JpegCompression = value; }
        }

        private int _ErrorNumber = 0;

        public int ErrorNumber
        {
            get { return _ErrorNumber; }
        }

        private string _ErrorMessage = string.Empty;

        public string ErrorMessage
        {
            get { return _ErrorMessage; }
        }

        private bool _OverwriteDestinationFile;

        public bool OverwriteDestinationFile
        {
            get { return _OverwriteDestinationFile; }
            set { _OverwriteDestinationFile = value; }
        }
        #endregion

        #region -- CreateNewImageFile --
        public bool CreateNewImageFile()
        {
            _ErrorNumber = 0;
            bool ok = false;
            try
            {
                // Originaldatei muss vorhanden sein
                if (!File.Exists(_PathNameOri))
                {
                    _ErrorNumber = (int)ConvertError.OriImageFileNotFount;
                    throw new Exception();
                }

                // Zieldirectory
                string sDir = Path.GetDirectoryName(_PathNameNew);
                if (!Directory.Exists(sDir))
                {
                    Directory.CreateDirectory(sDir);
                }
                if (!Directory.Exists(sDir))
                {
                    _ErrorNumber = (int)ConvertError.DestinationDirectoryNotFount;
                    throw new Exception();
                }

                // Vorhandene Dateien überschreiben?
                if (File.Exists(_PathNameNew))
                {
                    if (_OverwriteDestinationFile)
                    {
                        try
                        {
                            File.Delete(_PathNameNew);
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        //Datei mit dem Namen {0} existiert bereits!
                        _ErrorNumber = (int)ConvertError.FileAlreadyExists;
                        throw new Exception();
                    }
                }

                // Originalfile aufnehmen
                System.Drawing.Image oriImg = new Bitmap(_PathNameOri);
                if (oriImg.Width == 0 || oriImg.Height == 0)
                {
                    //Fehlerhaftes Imageformat in Original-Datei {0}!"
                    _ErrorNumber = (int)ConvertError.UnknownImageFormat;
                    throw new Exception();
                }

                // Kleinere Bilder nicht vergrößern
                if (oriImg.Width <= _SizeNew.Width && oriImg.Height <= _SizeNew.Height)
                {
                    // Keine Konvertierung von bmp nach jpg oder so durchführen!
                    oriImg.Save(_PathNameNew);
                }
                else
                {
                    // Neue Breite und Höhe festlegen
                    // _SizeNew ist entweder die konkrete Width/Heigt-Vorgabe (_KeepRatio = false)
                    // oder die Größe des umschreibenen Quadrats (_KeepRatio = true)
                    int newWidth = 0;
                    int newHeight = 0;
                    if (_KeepRatio)
                    {
                        int maxWidthHeight = _SizeNew.Width > _SizeNew.Height ? _SizeNew.Width : _SizeNew.Height;
                        double fac = (double)maxWidthHeight / (double)oriImg.Width;

                        if (fac * oriImg.Height > maxWidthHeight)
                            fac = (double)maxWidthHeight / (double)oriImg.Height;

                        newWidth = (int)(fac * oriImg.Width);
                        newHeight = (int)(fac * oriImg.Height);
                    }
                    else
                    {
                        newWidth = _SizeNew.Width;
                        newHeight = _SizeNew.Height;
                    }

                    // Konvertieren

                    Bitmap newImg = new Bitmap(newWidth, newHeight);
                    using (Graphics g = Graphics.FromImage(newImg))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(oriImg, new Rectangle(0, 0, newWidth, newHeight));
                    }
                    switch (Path.GetExtension(_PathNameNew).ToUpper())
                    {
                        case ".JPG":
                        case ".JPEG":
                            ImageCodecInfo codecInfo = GetCodecInfo(ImageFormat.Jpeg);
                            System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;
                            EncoderParameter encoderParameter = new EncoderParameter(encoder, Convert.ToInt64(_JpegCompression));
                            EncoderParameters encoderParameters = new EncoderParameters(1);
                            encoderParameters.Param[0] = encoderParameter;
                            newImg.Save(_PathNameNew, codecInfo, encoderParameters);
                            break;
                        case ".BMP":
                            newImg.Save(_PathNameNew, ImageFormat.Bmp);
                            break;
                        case ".PNG":
                            newImg.Save(_PathNameNew, ImageFormat.Png);
                            break;
                    }
                    oriImg.Dispose();
                    newImg.Dispose();
                }
                ok = true;
            }
            catch (Exception ex)
            {
                _ErrorMessage = _ErrorNumber == 0 ? ex.Message : "Check ErrorNumber";
                ok = false;
            }
            return ok;
        }

        private ImageCodecInfo GetCodecInfo(ImageFormat aFormat)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == aFormat.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        #endregion
    }
}
