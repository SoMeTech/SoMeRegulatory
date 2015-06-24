using System;
using System.Web;
using System.Web.UI;

public sealed class OpenServices : Page
{
    public static string GetOpenDialogPageString(string str)
    {
        return ("window.showModalDialog('" + str + "', window, 'dialogWidth:800px; dialogHeight:500px;resizable:0; help:0; scroll:0; status:0');location.reload();");
    }

    public static void OpenDialogPage(string str, Page page)
    {
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "open", "window.showModalDialog('" + str + "', window, 'dialogWidth:800px; dialogHeight:500px;resizable:0; help:0; scroll:0; status:0');location.reload();", true);
    }

    public static void OpenDialogPage(string str, int width, int height, Page page)
    {
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "open", "window.showModalDialog('" + str + "', window, 'dialogWidth:" + width.ToString() + "px; dialogHeight:" + height.ToString() + "px;resizable:0; help:0; scroll:0; status:0');location.reload();", true);
    }

    public static void OpenPage(string str, int width, int height, Page page)
    {
        string s = HttpContext.Current.Request.Cookies["allwid"].Value;
        string str3 = HttpContext.Current.Request.Cookies["allhei"].Value;
        int num = ((int.Parse(s) - 10) - width) / 2;
        int num2 = ((int.Parse(str3) - 30) - height) / 2;
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "open", "window.open('" + str + "', '', 'toolbar=no,status=no,resizable=no,width=" + width.ToString() + "px,height=" + height.ToString() + "px,scrollbars=no,location=no,left=" + num.ToString() + "px,top=" + num2.ToString() + "px');", true);
    }

    public static void OpenPage(string str, int width, int height, int left, int top, Page page)
    {
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "open", "window.open('" + str + "', '', 'toolbar=no,status=no,resizable=no,width=" + width.ToString() + "px,height=" + height.ToString() + "px,scrollbars=no,location=no,left=" + left.ToString() + ",top=" + top.ToString() + "');", true);
    }
}

