namespace BHSoft.BHWeb.Common
{
    using System;
    using System.Web;
    using System.Web.UI;

    public class Location
    {
        public static void alert_history(string _Msg, int BackLong)
        {
            string s = "<script language=javascript>";
            object obj2 = s + "alert('" + _Msg + "');";
            s = string.Concat(new object[] { obj2, "history.go('", BackLong, "')" }) + "</script>";
            HttpContext.Current.Response.Write(s);
        }

        public static void alert_reloadwin(string _Msg)
        {
            HttpContext.Current.Response.Write("<script  language='javascript'>alert('" + _Msg + "');window.opener.location=window.opener.location;window.opener=null;window.close();</script>");
        }

        public static void GetFocus(string Ctl_Name, Page page)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), Ctl_Name, "<script  language='javascript'>document.forms(0)." + Ctl_Name + ".focus(); document.forms(0)." + Ctl_Name + ".select();</script>");
        }

        public static void GoBackToPage(string page)
        {
            HttpContext.Current.Response.Write("<script  language='javascript'>location.href='" + page + "';self.close();</script>");
        }

        public static void history()
        {
            HttpContext.Current.Response.Write("<script  language='javascript'>window.history.back(-1);</script>");
        }

        public static void Judge(int ret, string msg, string err, string page)
        {
            if (ret > 0)
            {
                MsgBoxToPage(msg, page);
            }
            else
            {
                MsgBox(err);
            }
        }

        public static void location(string page)
        {
            HttpContext.Current.Response.Write("<script  language='javascript'>window.location.href='" + page + "';</script>");
        }

        public static void LocationToPage(string msg, string page)
        {
            HttpContext.Current.Response.Write("<script  language='javascript'>alert('" + msg + "');window.parent.document.location.href='" + page + "';</script>");
        }

        public static void lointimeout(string page)
        {
            HttpContext.Current.Response.Write("<script  language='javascript'>window.parent.document.location.href='" + page + "?err=timeout';</script>");
        }

        public static void MsgBox(string msg)
        {
            HttpContext.Current.Response.Write("<script  language='javascript'>alert('" + msg + "');</script>");
        }

        public static void MsgBoxToPage(string msg, string page)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>alert('" + msg + "');location.href='" + page + "';</script>");
        }

        public static void open(string page)
        {
            HttpContext.Current.Response.Write("<script language=\"javascript\">window.open('" + page + "',\"查看资料\",\"toolbar=yes,location=no,directories=yes,status=yes,menubar=yes,resizable=yes,scrollbars=yes\");</script>");
        }

        public static void openClose(string msg, string page)
        {
            HttpContext.Current.Response.Write("<script language=\"javascript\">alert('" + msg + "');window.open('" + page + "',\"\",\"toolbar=yes,location=no,directories=yes,status=yes,menubar=yes,resizable=yes,scrollbars=yes\");window.opener=null;window.close();</script>");
        }

        public static void ShowError(string errorStr)
        {
            HttpContext.Current.Response.Write("ERROR : " + errorStr);
        }
    }
}

