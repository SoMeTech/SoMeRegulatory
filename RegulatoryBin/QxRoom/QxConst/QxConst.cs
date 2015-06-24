namespace QxRoom.QxConst
{
    using MSXML2;
    using System;
    using System.Configuration;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;

    public sealed class QxConst
    {
        private const string HEX_TABLE = "0123456789ABCDEF";
        private const int RSA_SIZE = 0x400;

        public static string Byte_To_String(string _val)
        {
            MemoryStream stream = new MemoryStream(Convert.FromBase64String(_val));
            StreamReader reader = new StreamReader(stream);
            string str = reader.ReadToEnd();
            reader.Close();
            stream.Close();
            return str;
        }

        public static string Byte_To_Xml(byte[] _val)
        {
            return Convert.ToBase64String(_val);
        }

        public static void Cre_Pic(byte[] v_pic, string v_path)
        {
            FileStream stream = new FileStream(v_path, FileMode.OpenOrCreate);
            stream.Write(v_pic, 0, v_pic.Length);
            stream.Close();
        }

        public static string Decrypt(string datastr, string _key)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(_key);
            byte[] buffer = Convert.FromBase64String(datastr);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            return Encoding.Unicode.GetString(stream.ToArray());
        }

        public static string Encrypt(string datastr, string _key)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(_key);
            byte[] buffer = Encoding.Unicode.GetBytes(datastr);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            return Convert.ToBase64String(stream.ToArray());
        }

        public static string file_images(string v_path)
        {
            string str = null;
            string str2 = v_path;
            if (str2.Split(new char[] { '/' }).Length > 1)
            {
                for (int i = 0; i < (str2.Split(new char[] { '/' }).Length - int.Parse(ConfigurationManager.AppSettings["dir_dj"].ToString())); i++)
                {
                    str = "../" + str;
                }
            }
            return str;
        }

        public static string file_path(string v_path)
        {
            string str = "";
            string[] strArray = v_path.Split("/".ToCharArray());
            if (strArray.Length > 2)
            {
                str = strArray[strArray.Length - 2] + "/" + strArray[strArray.Length - 1];
            }
            return str;
        }

        public static string Get_err_page(string v_str_err)
        {
            return (ConfigurationManager.AppSettings["page_err"] + "?err=" + v_str_err);
        }

        public static string Get_file_path(string v_path)
        {
            if (ConfigurationManager.AppSettings["dir_name"].Trim().Length > 0)
            {
                return v_path.Replace(ConfigurationManager.AppSettings["dir_name"], "");
            }
            return v_path;
        }

        public static int Get_Page_QX(string v_page_qx, string v_qx)
        {
            int num = -1;
            int index = v_qx.IndexOf(v_page_qx);
            if (index >= 0)
            {
                num = 0;
                int length = v_qx.IndexOf(",", index) - index;
                if (length > 4)
                {
                    return int.Parse(v_qx.Substring(index, length).Substring(4));
                }
                if (index == v_qx.LastIndexOf(v_page_qx))
                {
                    return num;
                }
                index = v_qx.LastIndexOf(v_page_qx);
                v_qx.LastIndexOf(",", index);
                if ((v_qx.LastIndexOf(",", index) - index) > 0)
                {
                    length = v_qx.LastIndexOf(",", index) - index;
                }
                else
                {
                    length = v_qx.Length - index;
                }
                if (length > 4)
                {
                    num = int.Parse(v_qx.Substring(index, length).Substring(4));
                }
            }
            return num;
        }

        public static byte[] Get_Xml_DataB(string _url, string _user, string _pwd)
        {
            if (_user == null)
            {
                _user = "";
            }
            if (_pwd == null)
            {
                _pwd = "";
            }
            XMLHTTP xmlhttp = new XMLHTTPClass();
            xmlhttp.open("GET", _url, false, _user, _pwd);
            xmlhttp.setRequestHeader("content-type", "text/html; charset=gb2312");
            xmlhttp.send("");
            if (xmlhttp.readyState == 4)
            {
                return (byte[]) xmlhttp.responseBody;
            }
            return null;
        }

        public static DataSet Get_Xml_DataD(string v_url, string v_user, string v_pwd)
        {
            if (v_user == null)
            {
                v_user = "";
            }
            if (v_pwd == null)
            {
                v_pwd = "";
            }
            DataSet set = new DataSet();
            XMLHTTP xmlhttp = new XMLHTTPClass();
            xmlhttp.open("GET", v_url, false, v_user, v_pwd);
            xmlhttp.setRequestHeader("content-type", "text/html; charset=gb2312");
            xmlhttp.send("");
            if (xmlhttp.readyState == 4)
            {
                MemoryStream stream = new MemoryStream((byte[]) xmlhttp.responseBody);
                set.ReadXml(stream);
                stream.Close();
            }
            return set;
        }

        public static string Get_Xml_DataS(string _url, string _user, string _pwd)
        {
            if (_user == null)
            {
                _user = "";
            }
            if (_pwd == null)
            {
                _pwd = "";
            }
            XMLHTTP xmlhttp = new XMLHTTPClass();
            xmlhttp.open("GET", _url, false, _user, _pwd);
            xmlhttp.setRequestHeader("content-type", "text/html; charset=gb2312");
            xmlhttp.send("");
            if (xmlhttp.readyState == 4)
            {
                return xmlhttp.responseText;
            }
            return null;
        }

        public static string GetGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public static string GetMD5(Stream stream)
        {
            MD5 md = new MD5CryptoServiceProvider();
            byte[] buffer = md.ComputeHash(stream);
            StringBuilder builder = new StringBuilder {
                Length = buffer.Length * 2
            };
            for (int i = 0; i < buffer.Length; i++)
            {
                builder[i * 2] = "0123456789ABCDEF"[buffer[i] >> 4];
                builder[(i * 2) + 1] = "0123456789ABCDEF"[buffer[i] & 15];
            }
            md.Clear();
            return builder.ToString();
        }

        public static string GetMD5(string s)
        {
            MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(s));
            return GetMD5(stream);
        }

        public static bool IfNumber(string _str)
        {
            try
            {
                int.Parse(_str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void login_nz()
        {
            try
            {
                if (HttpContext.Current.Session["CheckCode"] == null)
                {
                    HttpContext.Current.Response.Redirect(file_images(HttpContext.Current.Request.Path) + "?err=您尚未登陆！");
                }
                else if (HttpContext.Current.Session["CheckCode"] != HttpContext.Current.Session["nz_CheckCode"])
                {
                    HttpContext.Current.Response.Redirect(file_images(HttpContext.Current.Request.Path) + "?err=请重新登陆！");
                }
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Redirect(file_images(HttpContext.Current.Request.Path) + "?err=" + exception.Message + "！");
            }
        }

        public string RSADecrypt(byte[] xmlPrivateKey, string m_strDecryptString)
        {
            string str;
            try
            {
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
                provider.FromXmlString(Encoding.ASCII.GetString(xmlPrivateKey));
                byte[] rgb = Convert.FromBase64String(m_strDecryptString);
                byte[] bytes = provider.Decrypt(rgb, false);
                str = new UnicodeEncoding().GetString(bytes);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        public string RSAEncrypt(byte[] xmlPublicKey, string m_strEncryptString)
        {
            string str;
            try
            {
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider {
                    KeySize = 0x400
                };
                provider.FromXmlString(Encoding.ASCII.GetString(xmlPublicKey));
                byte[] bytes = new UnicodeEncoding().GetBytes(m_strEncryptString);
                str = Convert.ToBase64String(provider.Encrypt(bytes, false));
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        public void RSAKey(out byte[] xmlKeys, out byte[] xmlPublicKey)
        {
            try
            {
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider {
                    KeySize = 0x400
                };
                xmlKeys = Encoding.ASCII.GetBytes(provider.ToXmlString(true));
                xmlPublicKey = Encoding.ASCII.GetBytes(provider.ToXmlString(false));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static string Save_File_Image(HttpPostedFile _UpFile, string _file_dir, out string _err)
        {
            _err = null;
            if (_UpFile.ContentLength == 0)
            {
                _err = "没有确定图片";
                return null;
            }
            _UpFile.SaveAs(HttpContext.Current.Server.MapPath(_file_dir) + "/" + _UpFile.FileName.Substring(_UpFile.FileName.LastIndexOf(@"\") + 1));
            return (_file_dir + "/" + _UpFile.FileName.Substring(_UpFile.FileName.LastIndexOf(@"\") + 1));
        }

        public static string Save_File_Image(HttpPostedFile _UpFile, string _file_dir, string _imgurl, int _alpha, out string _err)
        {
            _err = null;
            if (_UpFile.ContentLength == 0)
            {
                _err = "没有确定图片";
                return null;
            }
            Image image = Image.FromStream(_UpFile.InputStream, true);
            Image original = Image.FromFile(HttpContext.Current.Server.MapPath(_imgurl));
            double num = image.Width / 4;
            double num2 = image.Height / 4;
            Bitmap bitmap = new Bitmap(original, new Size((int) num, (int) num2));
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color pixel = bitmap.GetPixel(i, j);
                    Color color = Color.FromArgb(_alpha, pixel);
                    bitmap.SetPixel(i, j, color);
                }
            }
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawImage(bitmap, new Rectangle(image.Width - bitmap.Width, image.Height - bitmap.Height, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
            graphics.Dispose();
            string filename = HttpContext.Current.Server.MapPath(_file_dir) + "/" + _UpFile.FileName.Substring(_UpFile.FileName.LastIndexOf(@"\") + 1);
            image.Save(filename);
            image.Dispose();
            return (_file_dir + "/" + _UpFile.FileName.Substring(_UpFile.FileName.LastIndexOf(@"\") + 1));
        }

        public static string Save_File_Image(byte[] _UpFile, string _filename, string _file_dir, string _imgurl, int _alpha, out string _err)
        {
            _err = null;
            if (_UpFile.Length == 0)
            {
                _err = "没有确定图片";
                return null;
            }
            Image image = Image.FromStream(new MemoryStream(_UpFile), true);
            Image original = Image.FromFile(HttpContext.Current.Server.MapPath(_imgurl));
            double num = image.Width / 4;
            double num2 = image.Height / 4;
            Bitmap bitmap = new Bitmap(original, new Size((int) num, (int) num2));
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color pixel = bitmap.GetPixel(i, j);
                    Color color = Color.FromArgb(_alpha, pixel);
                    bitmap.SetPixel(i, j, color);
                }
            }
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawImage(bitmap, new Rectangle(image.Width - bitmap.Width, image.Height - bitmap.Height, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
            graphics.Dispose();
            string filename = HttpContext.Current.Server.MapPath(_file_dir) + "/" + _filename;
            image.Save(filename);
            image.Dispose();
            return (_file_dir + "/" + _filename);
        }

        public static byte[] String_To_Byte(string _val)
        {
            return Convert.FromBase64String(_val);
        }

        public static string Up_File(string str_path, HttpPostedFile file1, out string v_err)
        {
            v_err = null;
            string fileName = file1.FileName;
            if (!Directory.Exists(str_path))
            {
                Directory.CreateDirectory(str_path);
            }
            char[] separator = new char[] { '\\' };
            string str = file1.FileName.Split(separator)[file1.FileName.Split(separator).Length - 1];
            if (str == "")
            {
                str_path = "";
                v_err = "客户端文件不存在！";
                return null;
            }
            str_path = str_path + @"\" + str;
            file1.SaveAs(str_path);
            return str;
        }
    }
}

