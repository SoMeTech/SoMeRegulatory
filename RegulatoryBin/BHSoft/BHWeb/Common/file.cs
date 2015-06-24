namespace BHSoft.BHWeb.Common
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Web;
    using System.Web.UI.HtmlControls;

    public class file
    {
        public static void CreateFolder(string path)
        {
            string str = HttpContext.Current.Server.MapPath(path);
            if (!Directory.Exists(str))
            {
                Directory.CreateDirectory(str);
            }
        }

        public static void DelImgFile(string FilePath)
        {
            try
            {
                if (File.Exists(HttpContext.Current.Server.MapPath(FilePath)))
                {
                    File.Delete(HttpContext.Current.Server.MapPath(FilePath));
                }
            }
            catch
            {
            }
        }

        public static bool DownFile(HttpRequest _Request, HttpResponse _Response, string _fileName, string _fullPath, long _speed)
        {
            try
            {
                FileStream input = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader reader = new BinaryReader(input);
                try
                {
                    _Response.AddHeader("Accept-Ranges", "bytes");
                    _Response.Buffer = false;
                    long length = input.Length;
                    long num2 = 0L;
                    int count = 0x2800;
                    double d = ((long) (0x3e8 * count)) / _speed;
                    int millisecondsTimeout = ((int) Math.Floor(d)) + 1;
                    if (_Request.Headers["Range"] != null)
                    {
                        _Response.StatusCode = 0xce;
                        num2 = Convert.ToInt64(_Request.Headers["Range"].Split(new char[] { '=', '-' })[1]);
                    }
                    _Response.AddHeader("Content-Length", (length - num2).ToString());
                    if (num2 != 0L)
                    {
                        _Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", num2, length - 1L, length));
                    }
                    _Response.AddHeader("Connection", "Keep-Alive");
                    _Response.ContentType = "application/octet-stream";
                    _Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(_fileName, Encoding.UTF8));
                    reader.BaseStream.Seek(num2, SeekOrigin.Begin);
                    double num6 = (length - num2) / ((long) count);
                    int num7 = ((int) Math.Floor(num6)) + 1;
                    for (int i = 0; i < num7; i++)
                    {
                        if (_Response.IsClientConnected)
                        {
                            _Response.BinaryWrite(reader.ReadBytes(count));
                            Thread.Sleep(millisecondsTimeout);
                        }
                        else
                        {
                            i = num7;
                        }
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    reader.Close();
                    input.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool ExsitFile(string path)
        {
            bool flag = false;
            if (!File.Exists(HttpContext.Current.Server.MapPath(path)))
            {
                flag = true;
            }
            return flag;
        }

        public static string GetMapPath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }

        public static string UpFile(string SaveFolder, HtmlInputFile upControl)
        {
            string fileName = string.Empty;
            fileName = Path.GetFileName(upControl.PostedFile.FileName);
            string str2 = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
            if ((str2 != "jpg") && (str2 != "gif"))
            {
                return string.Empty;
            }
            fileName = Guid.NewGuid().ToString("n") + "." + str2;
            CreateFolder(SaveFolder);
            string filename = HttpContext.Current.Request.PhysicalApplicationPath + SaveFolder + fileName;
            upControl.PostedFile.SaveAs(filename);
            return fileName;
        }
    }
}

