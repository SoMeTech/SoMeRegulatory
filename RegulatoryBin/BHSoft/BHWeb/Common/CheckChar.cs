namespace BHSoft.BHWeb.Common
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;

    public class CheckChar
    {
        public static string changclass(string str1, string str2, int Myint)
        {
            string[] strArray = null;
            strArray = str1.Split(new char[] { '|' });
            if (((strArray.Length - 1) == 1) & (Myint == 0))
            {
                return string.Concat(new object[] { "<img align=\"absmiddle\" src=\"", PageBase.PathPrefix, "/admin/images/admin_tree_minusmiddle.gif\"/><img align=\"absmiddle\" src=\"", PageBase.PathPrefix, "/admin/images/admin_tree_folder.gif\"/>", str2, "  <font color=\"#000000\">(", Myint, ")</font>" });
            }
            if (((strArray.Length - 1) == 1) & (Myint != 0))
            {
                return string.Concat(new object[] { "<img align=\"absmiddle\" src=\"", PageBase.PathPrefix, "/admin/images/admin_tree_plusmiddle.gif\"/><img align=\"absmiddle\" src=\"", PageBase.PathPrefix, "/admin/images/admin_tree_folder.gif\"/>", str2, "  <font color=\"#000000\">(", Myint, ")</font>" });
            }
            if ((strArray.Length - 1) < 2)
            {
                return (str2 + Myint);
            }
            string str = null;
            for (int i = 0; i < (strArray.Length - 2); i++)
            {
                str = str + "&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            if (Myint == 0)
            {
                return string.Concat(new object[] { "<img align=\"absmiddle\" src=\"", PageBase.PathPrefix, "/admin/images/admin_tree_line.gif\"/>", str, "<img align=\"absmiddle\" src=\"", PageBase.PathPrefix, "/admin/images/admin_tree_minusmiddle.gif\"/><img align=\"absmiddle\" src=\"", PageBase.PathPrefix, "/admin/images/admin_tree_folder.gif\"/>", str2, " <font color=\"#000000\">(", Myint, ")</font>" });
            }
            return string.Concat(new object[] { "<img align=\"absmiddle\" src=\"", PageBase.PathPrefix, "/admin/images/admin_tree_line.gif\"/>", str, "<img align=\"absmiddle\" src=\"", PageBase.PathPrefix, "/admin/images/admin_tree_plusmiddle.gif\"/><img align=\"absmiddle\" src=\"", PageBase.PathPrefix, "/admin/images/admin_tree_folder.gif\"/>", str2, " <font color=\"#000000\">(", Myint, ")</font>" });
        }

        public static string ChangClass(string str1, string str2, int Myint)
        {
            string[] strArray = null;
            strArray = str1.Split(new char[] { '|' });
            if ((strArray.Length - 1) == 1)
            {
                return str2;
            }
            string str = null;
            for (int i = 0; i < (strArray.Length - 2); i++)
            {
                str = str + "　";
            }
            return (str + "└ " + str2);
        }

        public static string CutStr(string str, int len)
        {
            string str2 = str;
            if (str2.Length > len)
            {
                str2 = str2.Substring(0, len);
            }
            return str2;
        }

        public static string CutStr_New(string mText, int byteCount)
        {
            if (byteCount < 1)
            {
                return mText;
            }
            if (Encoding.Default.GetByteCount(mText) <= byteCount)
            {
                return mText;
            }
            byte[] bytes = Encoding.Default.GetBytes(mText);
            byte[] buffer2 = new byte[byteCount - 4];
            for (int i = 0; i < (byteCount - 4); i++)
            {
                buffer2[i] = bytes[i];
            }
            return (Encoding.Default.GetString(buffer2) + "...");
        }

        public static string FormatKey(string InPut)
        {
            if (InPut.Length > 4)
            {
                InPut = InPut.Substring(0, 4);
                return InPut;
            }
            if (InPut.Length < 4)
            {
                switch (InPut.Length.ToString())
                {
                    case null:
                        return InPut;

                    case "3":
                        InPut = InPut + "V";
                        return InPut;

                    case "2":
                        InPut = InPut + "Vv";
                        return InPut;

                    case "1":
                        InPut = InPut + "VvV";
                        return InPut;

                    case "0":
                        InPut = "win+";
                        break;
                }
            }
            return InPut;
        }

        public static bool IsDate(string str)
        {
            Regex regex = new Regex(@"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$");
            return regex.IsMatch(str);
        }

        public static bool IsEmail(string str)
        {
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            return regex.IsMatch(str);
        }

        public static bool isNotDecimals(string v)
        {
            try
            {
                Convert.ToDecimal(v);
                return false;
            }
            catch
            {
                return true;
            }
        }

        public static bool IsNumeric(string str)
        {
            Regex regex = new Regex(@"^[+]?\d*$");
            return regex.IsMatch(str);
        }

        public static string NoHTML(string Htmlstring)
        {
            Htmlstring = Regex.Replace(Htmlstring, "<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(iexcl|#161);", "\x00a1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(cent|#162);", "\x00a2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(pound|#163);", "\x00a3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(copy|#169);", "\x00a9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }

        public static string ReplaceBadChar(string strChar)
        {
            if (strChar.Trim() == "")
            {
                return "";
            }
            strChar = strChar.Replace("'", "");
            strChar = strChar.Replace("*", "");
            strChar = strChar.Replace("?", "");
            strChar = strChar.Replace("(", "");
            strChar = strChar.Replace(")", "");
            strChar = strChar.Replace("<", "");
            strChar = strChar.Replace("=", "");
            return strChar.Trim();
        }
    }
}

