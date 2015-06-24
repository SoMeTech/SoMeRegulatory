namespace BHSoft.BHWeb.Common
{
    using System;

    public class CharTran
    {
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

        public static string tranStringValue(string s)
        {
            if (s == "False")
            {
                return "男";
            }
            return "女";
        }
    }
}

