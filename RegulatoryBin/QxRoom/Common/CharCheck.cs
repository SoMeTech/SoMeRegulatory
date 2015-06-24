namespace QxRoom.Common
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;

    public sealed class CharCheck
    {
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
            string str;
            if (InPut.Length > 4)
            {
                InPut = InPut.Substring(0, 4);
                return InPut;
            }
            if ((InPut.Length < 4) && ((str = InPut.Length.ToString()) != null))
            {
                if (str == "3")
                {
                    InPut = InPut + "V";
                    return InPut;
                }
                if (str == "2")
                {
                    InPut = InPut + "Vv";
                    return InPut;
                }
                if (str == "1")
                {
                    InPut = InPut + "VvV";
                    return InPut;
                }
                if (str == "0")
                {
                    InPut = "win+";
                }
            }
            return InPut;
        }

        public static string FormatString(string str)
        {
            str = str.Replace(" ", "&nbsp;&nbsp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("\n", "<br>");
            return str;
        }

        public static string FormatStringTB(string str)
        {
            str = str.Replace("&nbsp;&nbsp;", " ");
            str = str.Replace("&lt;", "<");
            str = str.Replace("&gt;", ">");
            str = str.Replace("<br>", "\n");
            return str;
        }

        public static string GetPinyinCode(string unicodeString)
        {
            int index = 0;
            ushort num2 = 0;
            string str = string.Empty;
            Encoding unicode = Encoding.Unicode;
            Encoding encoding = Encoding.GetEncoding(0x3a8);
            byte[] bytes = unicode.GetBytes(unicodeString);
            byte[] buffer2 = Encoding.Convert(unicode, encoding, bytes);
            while (index < buffer2.Length)
            {
                if (buffer2[index] <= 0x7f)
                {
                    str = str + ((char) buffer2[index]);
                    index++;
                }
                else
                {
                    num2 = (ushort) ((buffer2[index] * 0x100) + buffer2[index + 1]);
                    if ((num2 >= 0xb0a1) && (num2 <= 0xb0c4))
                    {
                        str = str + "A";
                    }
                    else if ((num2 >= 0xb0c5) && (num2 <= 0xb2c0))
                    {
                        str = str + "B";
                    }
                    else if ((num2 >= 0xb2c1) && (num2 <= 0xb4ed))
                    {
                        str = str + "C";
                    }
                    else if ((num2 >= 0xb4ee) && (num2 <= 0xb6e9))
                    {
                        str = str + "D";
                    }
                    else if ((num2 >= 0xb6ea) && (num2 <= 0xb7a1))
                    {
                        str = str + "E";
                    }
                    else if ((num2 >= 0xb7a2) && (num2 <= 0xb8c0))
                    {
                        str = str + "F";
                    }
                    else if ((num2 >= 0xb8c1) && (num2 <= 0xb9fd))
                    {
                        str = str + "G";
                    }
                    else if ((num2 >= 0xb9fe) && (num2 <= 0xbbf6))
                    {
                        str = str + "H";
                    }
                    else if ((num2 >= 0xbbf7) && (num2 <= 0xbfa5))
                    {
                        str = str + "J";
                    }
                    else if ((num2 >= 0xbfa6) && (num2 <= 0xc0ab))
                    {
                        str = str + "K";
                    }
                    else if ((num2 >= 0xc0ac) && (num2 <= 0xc2e7))
                    {
                        str = str + "L";
                    }
                    else if ((num2 >= 0xc2e8) && (num2 <= 0xc4c2))
                    {
                        str = str + "M";
                    }
                    else if ((num2 >= 0xc4c3) && (num2 <= 0xc5b5))
                    {
                        str = str + "N";
                    }
                    else if ((num2 >= 0xc5b6) && (num2 <= 0xc5bd))
                    {
                        str = str + "O";
                    }
                    else if ((num2 >= 0xc5be) && (num2 <= 0xc6d9))
                    {
                        str = str + "P";
                    }
                    else if ((num2 >= 0xc6da) && (num2 <= 0xc8ba))
                    {
                        str = str + "Q";
                    }
                    else if ((num2 >= 0xc8bb) && (num2 <= 0xc8f5))
                    {
                        str = str + "R";
                    }
                    else if ((num2 >= 0xc8f6) && (num2 <= 0xcbf9))
                    {
                        str = str + "S";
                    }
                    else if ((num2 >= 0xcbfa) && (num2 <= 0xcdd9))
                    {
                        str = str + "T";
                    }
                    else if ((num2 >= 0xcdda) && (num2 <= 0xcef3))
                    {
                        str = str + "W";
                    }
                    else if ((num2 >= 0xcef4) && (num2 <= 0xd188))
                    {
                        str = str + "X";
                    }
                    else if ((num2 >= 0xd1b9) && (num2 <= 0xd4d0))
                    {
                        str = str + "Y";
                    }
                    else if ((num2 >= 0xd4d1) && (num2 <= 0xd7f9))
                    {
                        str = str + "Z";
                    }
                    else
                    {
                        str = str + "?";
                    }
                    index += 2;
                }
            }
            return str;
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

