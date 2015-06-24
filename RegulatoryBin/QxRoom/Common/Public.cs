namespace QxRoom.Common
{
    using MSXML2;
    using System;
    using System.Configuration;
    using System.Data;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public sealed class Public
    {
        private const string HEX_TABLE = "0123456789ABCDEF";
        private const string RANDOM_STRING_SOURCE = "0123456789abcdefghijklmnopqrstuvwxyz";
        private static Regex RegCHZN = new Regex("[一-龥]");
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$");
        private static Regex RegEmail = new Regex(@"^[\w-]+@[\w-]+\.(com|net|org|edu|mil|tv|biz|info)$");
        private static Regex RegNumber = new Regex("^[0-9]+$");
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
        private const int RSA_SIZE = 0x400;

        public static string AddZero(string str, int len)
        {
            string str2 = "";
            if (str.Length >= len)
            {
                return str;
            }
            for (int i = 0; i < (len - str.Length); i++)
            {
                str2 = str2 + "0";
            }
            return (str2 + str);
        }

        public string BarCode(object str, int ch, int cw, int type_code)
        {
            string str2 = str.ToString();
            string str3 = str2;
            str2 = str2.ToLower();
            int num = ch;
            int num2 = cw;
            str2 = str2.Replace("0", "_|_|__||_||_|").Replace("1", "_||_|__|_|_||").Replace("2", "_|_||__|_|_||").Replace("3", "_||_||__|_|_|").Replace("4", "_|_|__||_|_||").Replace("5", "_||_|__||_|_|").Replace("7", "_|_|__|_||_||").Replace("6", "_|_||__||_|_|").Replace("8", "_||_|__|_||_|").Replace("9", "_|_||__|_||_|").Replace("a", "_||_|_|__|_||").Replace("b", "_|_||_|__|_||").Replace("c", "_||_||_|__|_|").Replace("d", "_|_|_||__|_||").Replace("e", "_||_|_||__|_|").Replace("f", "_|_||_||__|_|").Replace("g", "_|_|_|__||_||").Replace("h", "_||_|_|__||_|").Replace("i", "_|_||_|__||_|").Replace("j", "_|_|_||__||_|").Replace("k", "_||_|_|_|__||").Replace("l", "_|_||_|_|__||").Replace("m", "_||_||_|_|__|").Replace("n", "_|_|_||_|__||").Replace("o", "_||_|_||_|__|").Replace("p", "_|_||_||_|__|").Replace("r", "_||_|_|_||__|").Replace("q", "_|_|_|_||__||").Replace("s", "_|_||_|_||__|").Replace("t", "_|_|_||_||__|").Replace("u", "_||__|_|_|_||").Replace("v", "_|__||_|_|_||").Replace("w", "_||__||_|_|_|").Replace("x", "_|__|_||_|_||").Replace("y", "_||__|_||_|_|").Replace("z", "_|__||_||_|_|").Replace("-", "_|__|_|_||_||").Replace("*", "_|__|_||_||_|").Replace("/", "_|__|__|_|__|").Replace("%", "_|_|__|__|__|").Replace("+", "_|__|_|__|__|").Replace(".", "_||__|_|_||_|").Replace("_", string.Concat(new object[] { "<span style='height:", num, ";width:", num2, ";background:#FFFFFF;'></span>" })).Replace("|", string.Concat(new object[] { "<span style='height:", num, ";width:", num2, ";background:#000000;'></span>" }));
            if (type_code == 1)
            {
                return (str2 + "<BR>" + str3);
            }
            return str2;
        }

        public static void CreatPic(byte[] BitPic, string Path)
        {
            FileStream stream = new FileStream(Path, FileMode.OpenOrCreate);
            stream.Write(BitPic, 0, BitPic.Length);
            stream.Close();
        }

        public static string DataTime(string Time)
        {
            return (DateTime.Parse(Time).Month.ToString() + "-" + DateTime.Parse(Time).Day.ToString());
        }

        public static string DateFormat()
        {
            return DateFormat(DateTime.Now);
        }

        public static string DateFormat(DateTime date)
        {
            return DateFormat(date, "yyyy-MM-dd");
        }

        public static string DateFormat(string date)
        {
            return DateFormat(Convert.ToDateTime(date));
        }

        public static string DateFormat(DateTime date, string format)
        {
            return date.ToString(format);
        }

        public static string DateFormat(string date, string format)
        {
            return DateFormat(Convert.ToDateTime(date), format);
        }

        public static string DateTimeFormat(DateTime datetime)
        {
            return DateTimeFormat(datetime, "yyyy-MM-dd HH:mm");
        }

        public static string DateTimeFormat(DateTime datetime, string format)
        {
            return datetime.ToString(format);
        }

        public static string Decrypt(string datastr)
        {
            PasswordDeriveBytes bytes = new PasswordDeriveBytes("qianxun8", null);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] rgbKey = bytes.CryptDeriveKey("DES", "SHA1", 0, new byte[8]);
            byte[] buffer = Encoding.Unicode.GetBytes(datastr);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(rgbKey, rgbKey), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            return Encoding.Unicode.GetString(stream.ToArray());
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

        public static string DelRelTxt(string chongFu, char bj)
        {
            string str = "";
            string[] strArray = chongFu.Split(new char[] { bj });
            for (int i = 0; i < strArray.Length; i++)
            {
                for (int k = i + 1; k < strArray.Length; k++)
                {
                    if (strArray[i] == strArray[k])
                    {
                        strArray[k] = "";
                    }
                }
            }
            for (int j = 0; j < strArray.Length; j++)
            {
                if (strArray[j] != "")
                {
                    str = (str == "") ? strArray[j] : (str + bj.ToString() + strArray[j]);
                }
            }
            return str;
        }

        public static string DelRelTxt(string str, string cz, char bj)
        {
            string str2 = "";
            string[] strArray = str.Split(new char[] { bj });
            string[] strArray2 = cz.Split(new char[] { bj });
            for (int i = 0; i < strArray.Length; i++)
            {
                for (int k = 0; k < strArray2.Length; k++)
                {
                    if (strArray[i] == strArray2[k])
                    {
                        strArray[i] = "";
                    }
                }
            }
            for (int j = 0; j < strArray.Length; j++)
            {
                if (strArray[j] != "")
                {
                    str2 = (str2 == "") ? strArray[j] : (str2 + bj.ToString() + strArray[j]);
                }
            }
            return str2;
        }

        public static int DiffYear(DateTime start)
        {
            return DiffYear(start, DateTime.Now);
        }

        public static int DiffYear(string start)
        {
            return DiffYear(Convert.ToDateTime(start));
        }

        public static int DiffYear(DateTime start, DateTime end)
        {
            return (end.Year - start.Year);
        }

        public static int DiffYear(string start, string end)
        {
            return DiffYear(Convert.ToDateTime(start), Convert.ToDateTime(end));
        }

        public static string Drop(string src, string pattern)
        {
            return Replace(src, pattern, "");
        }

        public static string DropHtmlTag(string content)
        {
            return Drop(content, @"<[^\>]*>");
        }

        public static string DropHtmlTag(string content, string tagName)
        {
            return DropIgnoreCase(content, "<[/]{0,1}" + tagName + @"[^\>]*\>");
        }

        public static string DropIgnoreCase(string src, string pattern)
        {
            return ReplaceIgnoreCase(src, pattern, "");
        }

        public static string Encrypt(string datastr)
        {
            PasswordDeriveBytes bytes = new PasswordDeriveBytes("qianxun8", null);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] rgbKey = bytes.CryptDeriveKey("DES", "SHA1", 0, new byte[8]);
            byte[] buffer = Encoding.Unicode.GetBytes(datastr);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(rgbKey, rgbKey), CryptoStreamMode.Write);
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

        public static string EscapeHtml(string src)
        {
            if (src == null)
            {
                return null;
            }
            string str = src;
            return Replace(Replace(str, ">", "&gt;"), "<", "&lt;");
        }

        public static string FetchInputDigit(HttpRequest req, string inputKey, int maxLen)
        {
            string sqlInput = string.Empty;
            if ((inputKey != null) && (inputKey != string.Empty))
            {
                sqlInput = req.QueryString[inputKey];
                if (sqlInput == null)
                {
                    sqlInput = req.Form[inputKey];
                }
                if (sqlInput != null)
                {
                    sqlInput = SqlText(sqlInput, maxLen);
                    if (!IsNumber(sqlInput))
                    {
                        sqlInput = string.Empty;
                    }
                }
            }
            if (sqlInput == null)
            {
                sqlInput = string.Empty;
            }
            return sqlInput;
        }

        public static string FileImages(string str_path)
        {
            string str = null;
            string str2 = str_path;
            if (str2.Split(new char[] { '/' }).Length > 1)
            {
                for (int i = 0; i < (str2.Split(new char[] { '/' }).Length - int.Parse(ConfigurationManager.AppSettings["dir_dj"].ToString())); i++)
                {
                    str = "../" + str;
                }
            }
            return str;
        }

        public static string GetFilePath(string Path)
        {
            if (ConfigurationManager.AppSettings["dir_name"].Trim().Length > 0)
            {
                return Path.Replace(ConfigurationManager.AppSettings["dir_name"], "");
            }
            return Path;
        }

        public static int GetMaxNumber(int len)
        {
            int num = 0;
            if (len > 1)
            {
                num = 10;
                for (int i = 1; i < len; i++)
                {
                    num *= 10;
                }
            }
            return (num - 1);
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

        public static int GetMinNumber(int len)
        {
            int num = 0;
            if (len > 1)
            {
                num = 1;
                for (int i = 1; i < len; i++)
                {
                    num *= 10;
                }
            }
            return num;
        }

        public static string GetPageUrlPath()
        {
            return HttpContext.Current.Request.Url.PathAndQuery;
        }

        public static string GetRandom(int minlen, int maxlen)
        {
            Random random = new Random();
            return random.Next(GetMinNumber(minlen), GetMaxNumber(maxlen)).ToString();
        }

        public static string GetRandomString(int num)
        {
            string str = "";
            Random random = new Random();
            for (int i = 0; i < num; i++)
            {
                str = str + "0123456789abcdefghijklmnopqrstuvwxyz".Substring(Convert.ToInt32(Math.Round((double) (random.NextDouble() * 36.0), 0)), 1);
            }
            return str;
        }

        public static string GetServerPath()
        {
            return AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        }

        public static string GetUrlArea()
        {
            string pathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
            if (RelTxtCount(pathAndQuery, "/") > 1)
            {
                return pathAndQuery.Remove(pathAndQuery.IndexOf('/', 1), pathAndQuery.Length - pathAndQuery.IndexOf('/', 1));
            }
            return "";
        }

        public static DataSet GetXmlData(string Url, string User, string Pwd)
        {
            if (User == null)
            {
                User = "";
            }
            if (Pwd == null)
            {
                Pwd = "";
            }
            DataSet set = new DataSet();
            XMLHTTPClass class2 = new XMLHTTPClass();
            class2.open("post", Url, false, User, Pwd);
            class2.setRequestHeader("content-type", "text/html; charset=gb2312");
            class2.send("");
            if (class2.readyState == 4)
            {
                MemoryStream stream = new MemoryStream((byte[]) class2.responseBody);
                set.ReadXml(stream);
                stream.Close();
            }
            return set;
        }

        public static string HtmlEncode(string inputData)
        {
            return HttpUtility.HtmlEncode(inputData);
        }

        public static string InputText(string inputString)
        {
            StringBuilder builder = new StringBuilder();
            inputString = HttpContext.Current.Server.HtmlEncode(inputString);
            if ((inputString != null) && (inputString != string.Empty))
            {
                inputString = inputString.Trim();
                for (int i = 0; i < inputString.Length; i++)
                {
                    switch (inputString[i])
                    {
                        case ' ':
                        {
                            builder.Append("&nbsp;");
                            continue;
                        }
                        case '"':
                        {
                            builder.Append("&quot;");
                            continue;
                        }
                        case '<':
                        {
                            builder.Append("&lt;");
                            continue;
                        }
                        case '>':
                        {
                            builder.Append("&gt;");
                            continue;
                        }
                    }
                    builder.Append(inputString[i]);
                }
            }
            return builder.ToString().Replace("\n", "<br>").Replace(" ", "&nbsp;").Replace("'", "‘");
        }

        public static bool IsAllowedExtension(HtmlInputFile hifile)
        {
            string fileName = "";
            string str2 = "";
            string[] strArray = new string[] { ".gif", ".jpg", ".jpeg", ".bmp", ".png", ".GIF", ".JPG", ".JPEG", ".BMP", ".PNG" };
            if (hifile.PostedFile.FileName != string.Empty)
            {
                fileName = hifile.PostedFile.FileName;
                str2 = fileName.Substring(fileName.LastIndexOf("."));
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (str2.Equals(strArray[i]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool IsDateTime(string strdate)
        {
            try
            {
                DateTime.Parse(strdate);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsDecimal(string inputData)
        {
            bool flag = false;
            try
            {
                decimal.Parse(inputData);
                flag = true;
            }
            catch (Exception)
            {
            }
            return flag;
        }

        public static bool IsDecimalSign(string inputData)
        {
            return RegDecimalSign.Match(inputData).Success;
        }

        public static bool IsEmail(string inputData)
        {
            return RegEmail.Match(inputData).Success;
        }

        public static bool IsHasCHZN(string inputData)
        {
            return RegCHZN.Match(inputData).Success;
        }

        public static bool IsNumber(string inputData)
        {
            return RegNumber.Match(inputData).Success;
        }

        public static bool IsNumberSign(string inputData)
        {
            return RegNumberSign.Match(inputData).Success;
        }

        public static bool IsNumeric(string inputData)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.Match(inputData).Success;
        }

        public static void LocationHref(string filename, bool bend)
        {
            HttpContext.Current.Response.Write("<script language=\"javascript\">location.href=\"" + filename + "\";</script>");
            if (bend)
            {
                try
                {
                    HttpContext.Current.Response.End();
                }
                catch (ThreadAbortException)
                {
                    throw;
                }
            }
        }

        public static void Login()
        {
            try
            {
                if (HttpContext.Current.Session["CheckCode"] == null)
                {
                    HttpContext.Current.Response.Redirect(FileImages(HttpContext.Current.Request.Path) + "?err=您尚未登陆！");
                }
                else if (HttpContext.Current.Session["CheckCode"] != HttpContext.Current.Session["nz_CheckCode"])
                {
                    HttpContext.Current.Response.Redirect(FileImages(HttpContext.Current.Request.Path) + "?err=请重新登陆！");
                }
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Redirect(FileImages(HttpContext.Current.Request.Path) + "?err=" + exception.Message + "！");
            }
        }

        public void readFile(string strPath, string strValue)
        {
            FileStream stream = new FileStream(strPath, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("GB2312"));
            reader.BaseStream.Seek(0L, SeekOrigin.Begin);
            strValue = " ";
            for (string str = reader.ReadToEnd(); str != null; str = reader.ReadLine())
            {
                strValue = strValue + str + "\n";
            }
            reader.Close();
        }

        public static string RelativelyPath(string oldpath)
        {
            string str = oldpath;
            if ((oldpath == null) || (oldpath.Trim() == ""))
            {
                return "";
            }
            string str2 = HttpContext.Current.Server.MapPath(".").Replace(HttpContext.Current.Server.MapPath("~"), "");
            if (str2 != "")
            {
                str2 = str2.Replace(@"\", "/");
                if (str2.Substring(0, 1) == "/")
                {
                    str2 = str2.Substring(1);
                }
                string[] strArray = str2.Split("/".ToCharArray());
                for (int i = 0; i < strArray.Length; i++)
                {
                    str = "../" + str;
                }
            }
            return str;
        }

        public static int RelTxtCount(string chongFu, string str)
        {
            int num = 0;
            for (int i = 0; i <= (chongFu.Length - str.Length); i++)
            {
                if (chongFu.Substring(i, str.Length) == str)
                {
                    num++;
                }
            }
            return num;
        }

        public static string Replace(string src, string pattern, string replacement)
        {
            return Replace(src, pattern, replacement, RegexOptions.None);
        }

        public static string Replace(string src, string pattern, string replacement, RegexOptions options)
        {
            Regex regex = new Regex(pattern, options | RegexOptions.Compiled);
            return regex.Replace(src, replacement);
        }

        public static string ReplaceIgnoreCase(string src, string pattern, string replacement)
        {
            return Replace(src, pattern, replacement, RegexOptions.IgnoreCase);
        }

        public static void ResponseScript(Page page, string script)
        {
            //page.RegisterStartupScript("message", "<script language='javascript' defer>" + script + "</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + script + "');</script>");
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

        public static void SetLabel(Label lbl, object inputObj)
        {
            SetLabel(lbl, inputObj.ToString());
        }

        public static void SetLabel(Label lbl, string txtInput)
        {
            lbl.Text = HtmlEncode(txtInput);
        }

        public static void Show(string msg)
        {
            msg = msg.Replace("\"", " ");
            msg = msg.Replace("'", " ");
            HttpContext.Current.Response.Write("<script  language='javascript'>alert('" + msg + "');</script>");
        }

        public static void Show(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }

        public static void Show(Control con, string msg, Page page)
        {
            //page.RegisterClientScriptBlock("click", "<script  language='javascript'>alert('" + msg + "');</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "click", "<script language='javascript' defer>alert('" + msg + "');</script>");
        }

        public static void ShowAndRedirect(Page page, string msg, string url)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<script language='javascript' defer>");
            builder.AppendFormat("alert('{0}');", msg);
            builder.AppendFormat("top.location.href='{0}'", url);
            builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", builder.ToString());
        }

        public static void ShowConfirm(WebControl Control, string msg)
        {
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }

        public static void ShowConfirm(WebControl Control, string eventType, string msg)
        {
            Control.Attributes.Add(eventType, msg);
        }

        public static string SqlText(string sqlInput, int maxLength)
        {
            if ((sqlInput != null) && (sqlInput != string.Empty))
            {
                sqlInput = sqlInput.Trim();
                if (sqlInput.Length > maxLength)
                {
                    sqlInput = sqlInput.Substring(0, maxLength);
                }
            }
            return sqlInput;
        }

        public static string StrZFXD(int intLenth, string strCount)
        {
            if (strCount.Length < intLenth)
            {
                return strCount;
            }
            return strCount.Substring(0, intLenth).Trim().ToString();
        }

        public static string SubstrByChar(string str, char sep, int num)
        {
            if (str.Split(new char[] { sep }).Length > num)
            {
                return str.Split(new char[] { sep })[num];
            }
            return "";
        }

        public static string ToHtml(string str)
        {
            if ((str == null) || str.Equals(""))
            {
                return str;
            }
            StringBuilder builder = new StringBuilder(str);
            builder.Replace("&", "&amp;");
            builder.Replace("<", "&lt;");
            builder.Replace(">", "&gt;");
            builder.Replace("\r\n", "<br>");
            builder.Replace("\n", "<br>");
            builder.Replace("\t", " ");
            builder.Replace(" ", "&nbsp;");
            return builder.ToString();
        }

        public static string ToSQL(string src)
        {
            if (src == null)
            {
                return null;
            }
            return Replace(src, "'", "''");
        }

        public static string ToTxt(string str)
        {
            if ((str == null) || str.Equals(""))
            {
                return str;
            }
            StringBuilder builder = new StringBuilder(str);
            builder.Replace("&nbsp;", " ");
            builder.Replace("<br>", "\r\n");
            builder.Replace("&lt;", "<");
            builder.Replace("&gt;", ">");
            builder.Replace("&amp;", "&");
            return builder.ToString();
        }

        public static string UpFile(string str_path, HttpPostedFile file1)
        {
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
                throw new Exception("客户端文件不存在！");
            }
            str_path = str_path + @"\" + str;
            if (File.Exists(str_path))
            {
                throw new CommonException("文件在文件夹内有同名的文件");
            }
            file1.SaveAs(str_path);
            return str;
        }

        public static string UpFile(string str_path, HttpPostedFile file1, out string v_err)
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

        public static bool Validate(string _ValidateString, enumValidateType _ValidateType)
        {
            _ValidateString = _ValidateString.Replace("'", "‘");
            switch (_ValidateType)
            {
                case enumValidateType.Number:
                    if (!Regex.IsMatch(_ValidateString, "^[0-9]+$"))
                    {
                        break;
                    }
                    return true;

                case enumValidateType.Phone:
                    if (!Regex.IsMatch(_ValidateString, @"^\d{7,8}$|^\d{11,12}$"))
                    {
                        break;
                    }
                    return true;

                case enumValidateType.HandSet:
                    if (!Regex.IsMatch(_ValidateString, @"^\d{11}$"))
                    {
                        break;
                    }
                    return true;

                case enumValidateType.IdCard:
                    if (!Regex.IsMatch(_ValidateString, @"^\d{18}$|^\d{15}$"))
                    {
                        break;
                    }
                    return true;

                case enumValidateType.Date:
                    if (!Regex.IsMatch(_ValidateString, @"^\d{4}-\d{1,2}-\d{1,2}$"))
                    {
                        break;
                    }
                    return true;

                case enumValidateType.Decimal:
                    if (!Regex.IsMatch(_ValidateString, @"^(0|\d+)(.\d+)?$"))
                    {
                        break;
                    }
                    return true;

                case enumValidateType.PostMunber:
                    if (!Regex.IsMatch(_ValidateString, @"^\d{6}"))
                    {
                        break;
                    }
                    return true;

                case enumValidateType.EMail:
                    if (!Regex.IsMatch(_ValidateString, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$"))
                    {
                        break;
                    }
                    return true;

                case enumValidateType.NegNumber:
                    if (!Regex.IsMatch(_ValidateString, @"^[1-9]\d*$|^\d+.\d+$|^0$|^-\d+.\d+$|^-[1-9]\d*$"))
                    {
                        break;
                    }
                    return true;
            }
            return false;
        }

        public void writeFile(string strPath, string strValue)
        {
            FileStream stream = new FileStream(strPath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.Flush();
            writer.BaseStream.Seek(0L, SeekOrigin.Begin);
            writer.Write(strValue);
            writer.Flush();
            writer.Close();
        }
    }
}

