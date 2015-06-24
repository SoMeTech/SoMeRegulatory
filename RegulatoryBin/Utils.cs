using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

public class Utils
{
    public static string Domain = ConfigurationManager.AppSettings["Domain"].ToString();

    public static bool DirectoryExists(string path)
    {
        if (!Directory.Exists(path))
        {
            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
        return true;
    }

    public static bool FileDelete(string path)
    {
        try
        {
            FileInfo info = new FileInfo(path);
            if (info.Exists)
            {
                info.Delete();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool FileExists(string path)
    {
        if (!File.Exists(path))
        {
            return false;
        }
        return true;
    }

    public static string GetCnSubString(string str_input, int length)
    {
        int num = 0;
        if (str_input.Length > length)
        {
            num = HasChineseCount(str_input.Substring(0, length));
            return str_input.Substring(0, length - num);
        }
        return str_input;
    }

    public static double GetFileSize(string str)
    {
        try
        {
            FileStream stream = new FileStream(str, FileMode.Open, FileAccess.Read);
            return Convert.ToDouble(stream.Length);
        }
        catch
        {
            return 0.0;
        }
    }

    public static double GetFileSizeKB(double size)
    {
        return Math.Round((double) (size / 1024.0), 2);
    }

    public static double GetFileSizeMB(double size)
    {
        return Math.Round((double) (size / 1048576.0), 2);
    }

    public static string GetFormatFileSize(string str)
    {
        try
        {
            return GetFormatString(GetFileSize(str));
        }
        catch
        {
            return "0.0 Byte";
        }
    }

    public static string GetFormatString(double size)
    {
        if (size >= 1048576.0)
        {
            return (Math.Round((double) (size / 1048576.0), 2) + "MB");
        }
        if (size >= 1024.0)
        {
            return (Math.Round((double) (size / 1024.0), 2) + "KB");
        }
        return (size + "Byte");
    }

    public static string GetGuid()
    {
        return Guid.NewGuid().ToString();
    }

    public static double GetPercent(double divisor, double dividend)
    {
        double num = Math.Round((double) (((divisor - dividend) / divisor) * 100.0), 2);
        if (num > 100.0)
        {
            return 100.0;
        }
        return num;
    }

    public static string GetSubString(string srcString, int p_Length, string tailString)
    {
        string str = srcString;
        if (p_Length <= 0)
        {
            return str;
        }
        byte[] bytes = Encoding.Default.GetBytes(srcString);
        if (bytes.Length <= p_Length)
        {
            return str;
        }
        int length = p_Length;
        int[] numArray = new int[p_Length];
        byte[] destinationArray = null;
        int num2 = 0;
        for (int i = 0; i < p_Length; i++)
        {
            if (bytes[i] > 0x7f)
            {
                num2++;
                if (num2 == 3)
                {
                    num2 = 1;
                }
            }
            else
            {
                num2 = 0;
            }
            numArray[i] = num2;
        }
        if ((bytes[p_Length - 1] > 0x7f) && (numArray[p_Length] == 1))
        {
            length = p_Length + 1;
        }
        destinationArray = new byte[length];
        Array.Copy(bytes, destinationArray, length);
        return (Encoding.Default.GetString(destinationArray) + tailString);
    }

    public static int HasChineseCount(string str_input)
    {
        int num = 0;
        int num2 = 0;
        int num3 = Convert.ToInt32("4e00", 0x10);
        int num4 = Convert.ToInt32("9fff", 0x10);
        if (str_input != "")
        {
            for (int i = 0; i < str_input.Length; i++)
            {
                num = char.ConvertToUtf32(str_input, i);
                if ((num >= num3) && (num <= num4))
                {
                    num2++;
                }
            }
        }
        return num2;
    }

    public static int IndexOf(string str, string key)
    {
        string str2 = str;
        str2 = str2.Replace(key, "");
        int num = str.Length - str2.Length;
        int num2 = 0;
        if (num > 0)
        {
            num2 = num / key.Length;
        }
        return num2;
    }

    public static bool IsNumber(string strNumber)
    {
        return new Regex(@"^([0-9])[0-9]*(\.\w*)?$").IsMatch(strNumber);
    }

    public static void javaAlert(string msg)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("<script type=\"text/javascript\" language=\"javascript\">");
        builder.AppendLine("//<![CDATA[");
        builder.AppendLine("alert('" + msg + "');");
        builder.AppendLine("//]]>");
        builder.AppendLine("</script>");
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Write(builder.ToString());
        HttpContext.Current.Response.End();
    }

    public static void javaAlertRedirect(string msg, string url)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("<script type=\"text/javascript\" language=\"javascript\">");
        builder.AppendLine("//<![CDATA[");
        builder.AppendLine("alert('" + msg + "');");
        builder.AppendLine("//]]>");
        builder.AppendLine("</script>");
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Write(builder.ToString());
        HttpContext.Current.Response.Redirect(url);
        HttpContext.Current.Response.End();
    }

    public static void javaFunction(string msg, string function)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("<script type=\"text/javascript\" language=\"javascript\">");
        builder.AppendLine("//<![CDATA[");
        builder.AppendLine("document.domain = '" + Domain + "';");
        if ((function != "") && (function != string.Empty))
        {
            builder.AppendLine(function);
        }
        builder.AppendLine("alert('" + msg + "');");
        builder.AppendLine("//]]>");
        builder.AppendLine("</script>");
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Write(builder.ToString());
        HttpContext.Current.Response.End();
    }

    public static string MD5(string str)
    {
        byte[] bytes = new UnicodeEncoding().GetBytes(str);
        return BitConverter.ToString(((HashAlgorithm) CryptoConfig.CreateFromName("MD5")).ComputeHash(bytes));
    }

    public static string QueryString(string str)
    {
        if (HttpContext.Current.Request.QueryString[str].ToString() != null)
        {
            return HttpContext.Current.Request.QueryString[str].ToString();
        }
        return "";
    }

    public static string ReCharacter(string str)
    {
        str = str.Replace("--", "&amp");
        str = str.Replace("&", "&amp;");
        str = str.Replace("<", "&lt;");
        str = str.Replace(">", "&gt;");
        str = str.Replace("'", "''");
        str = str.Replace("*", "");
        str = str.Replace("\n", "<br />");
        str = str.Replace("\r\n", "<br />");
        str = str.Replace("delcare", "delcar&#101;");
        str = str.Replace(" ", "&nbsp;");
        str = str.Replace("select", "sel&#101;ct");
        str = str.Replace("join", "jo&#105;n");
        str = str.Replace("union", "un&#105;on");
        str = str.Replace("where", "wh&#101;re");
        str = str.Replace("insert", "ins&#101;rt");
        str = str.Replace("delete", "del&#101;te");
        str = str.Replace("update", "up&#100;ate");
        str = str.Replace("like", "lik&#101;");
        str = str.Replace("drop", "dro&#112;");
        str = str.Replace("create", "cr&#101;ate");
        str = str.Replace("modify", "mod&#105;fy");
        str = str.Replace("rename", "ren&#097;me");
        str = str.Replace("and", "&#097;nd");
        str = str.Replace("alter", "alt&#101;r");
        str = str.Replace("cast", "ca&#115;t");
        str = str.Trim();
        return str;
    }

    public static string ReHtmlDecode(string str)
    {
        str = str.Replace("&quot;", "\"");
        str = str.Replace("&amp;", "&");
        str = str.Replace("&lt;", "<");
        str = str.Replace("&gt;", ">");
        return str;
    }

    public static string ReHtmlEncode(string str)
    {
        str = str.Replace("\"", "&quot;");
        str = str.Replace("&", "&amp;");
        str = str.Replace("<", "&lt;");
        str = str.Replace(">", "&gt;");
        return str;
    }

    public static string ReTrim(string str)
    {
        for (int i = str.Length; i >= 0; i++)
        {
            char ch = str[i];
            if (!ch.Equals(" "))
            {
                char ch2 = str[i];
                if (!ch2.Equals("\r"))
                {
                    char ch3 = str[i];
                    if (!ch3.Equals("\n"))
                    {
                        continue;
                    }
                }
            }
            str.Remove(i, 1);
        }
        return str;
    }

    public static decimal StrToDecimal(string str)
    {
        try
        {
            return Convert.ToDecimal(str);
        }
        catch
        {
            return 0M;
        }
    }

    public static int StrToInt(string str)
    {
        try
        {
            return Convert.ToInt32(str);
        }
        catch
        {
            return 0;
        }
    }

    public static int StrToInt(object strValue, int defValue)
    {
        if (((strValue == null) || (strValue.ToString() == string.Empty)) || (strValue.ToString().Length > 10))
        {
            return defValue;
        }
        string str = strValue.ToString();
        string strNumber = str[0].ToString();
        if (((str.Length == 10) && IsNumber(strNumber)) && (int.Parse(strNumber) > 1))
        {
            return defValue;
        }
        if ((str.Length == 10) && !IsNumber(strNumber))
        {
            return defValue;
        }
        int num = defValue;
        if ((strValue != null) && new Regex("^([-]|[0-9])[0-9]*$").IsMatch(strValue.ToString()))
        {
            num = Convert.ToInt32(strValue);
        }
        return num;
    }

    public static string Substring(string str, int start, int length)
    {
        if ((start < 0) || (length < 0))
        {
            start = Math.Abs(start);
            length = Math.Abs(length);
        }
        if (str == null)
        {
            str = "";
            return str;
        }
        if (str.Length < (start + length))
        {
            return str;
        }
        try
        {
            return str.Substring(start, length);
        }
        catch
        {
            return str;
        }
    }
}

