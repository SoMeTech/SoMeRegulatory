using SoMeTech.User;
using QxRoom.Common;
using QxRoom.QxConst;
using System;
using System.Web;
using System.Web.UI;

public sealed class Const
{
    public static void AddSuccess(int count, Page page)
    {
        if (count > 0)
        {
            DoSuccessOpen("", "", page);
        }
        else
        {
            OpenErrorPage("操作失败，请联系管理员！", page);
        }
    }

    public static void AddSuccess(int count, string reload, Page page)
    {
        if (count > 0)
        {
            DoSuccessOpen("", reload, page);
        }
        else
        {
            OpenErrorPage("操作失败，请联系管理员！", page);
        }
    }

    public static void DoSuccessClose(string str, Page page)
    {
        if (str == "")
        {
            str = "操作信息成功！";
        }
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "alert('" + str + "');window.opener.location.reload();window.close();", true);
    }

    public static void DoSuccessClose(string str, string reload, Page page)
    {
        if (str == "")
        {
            str = "操作信息成功！";
        }
        if (reload == "MainAddUpdate")
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "window.opener.parent.ShowMsg_TS('" + str + "');window.close();", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "alert('" + str + "');window.opener.location.reload();window.close();", true);
        }
    }

    public static void DoSuccessNoClose(Page page)
    {
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "window.opener.location.reload();", true);
    }

    public static void DoSuccessNoClose(string str, string url, Page page)
    {
        if (str == "")
        {
            str = "操作信息成功！";
        }
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "alert('" + str + "');document.location.href='" + url + "';window.opener.location.reload();", true);
    }

    public static void DoSuccessOpen(string str, Page page)
    {
        if (str == "")
        {
            str = "操作信息成功！";
        }
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "window.alert('" + str + "');window.opener.location.reload();window.close();", true);
    }

    public static void DoSuccessOpen(string str, bool bj, Page page)
    {
        if (str == "")
        {
            str = "操作信息成功！";
        }
        if (bj)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "window.ShowMsg_TS_Open(this,'" + str + "');window.opener.location.reload();window.close();", true);
        }
    }

    public static void DoSuccessOpen(string str, string reload, Page page)
    {
        if (str == "")
        {
            str = "操作信息成功！";
        }
        if (reload.Trim() == "MainAddUpdate")
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "alert('" + str + "');window.opener.location.reload();window.close();", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "alert('" + str + "');window.close();", true);
        }
    }

    public static string GetBinDir()
    {
        return (AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"bin\");
    }

    public string GetCompanyPower()
    {
        return PowerClass.GetPowerString(((UserModel) HttpContext.Current.Session["User"]).CompanyPower);
    }

    public static void GoLoginPath_List(Page page)
    {
        HttpCookie cookie = new HttpCookie("UserCookie");
        UserBll bll = new UserBll();
        string script = "";
        if (((cookie != null) && (page.Request.Cookies["UserCookie"] != null)) && (page.Request.Cookies["UserCookie"].Values["pwd"] != null))
        {
            string str2 = QxRoom.QxConst.QxConst.Decrypt(page.Server.UrlDecode(page.Request.Cookies["UserCookie"].Values["pwd"]), "powerich");
            UserModel model = bll.Login(page.Server.UrlDecode(page.Request.Cookies["UserCookie"].Values["UserName"].Trim()));
            if (((model.UserName == page.Server.UrlDecode(page.Request.Cookies["UserCookie"].Values["UserName"].Trim())) && (model.Password != null)) && (QxRoom.QxConst.QxConst.Decrypt(model.Password, "powerich") == str2))
            {
                page.Session["User"] = model;
                page.Session["companyname"] = page.Server.UrlDecode(page.Request.Cookies["UserCookie"].Values["CompanyName"].Trim());
                page.Session["pk_corp"] = page.Server.UrlDecode(page.Request.Cookies["UserCookie"].Values["CompanyPK"].Trim());
                script = "window.location.reload();";
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "login", script, true);
            }
            else
            {
                script = "window.parent.CloseXtit(); window.parent.ShowMsg_Login('index.aspx');";
            }
        }
        else
        {
            script = "window.parent.CloseXtit(); window.parent.ShowMsg_Login('index.aspx');";
        }
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "login", script, true);
    }

    public static void GoLoginPath_Open(Page page)
    {
        GoLoginPath_OpenWindow(page);
    }

    public static void GoLoginPath_OpenDialog(Page page)
    {
        string script = "window.returnValue='timeup';window.close();";
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "login", script, true);
    }

    public static void GoLoginPath_OpenWindow(Page page)
    {
        string script = "window.opener.parent.ShowMsg_Login('index.aspx');window.close();";
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "login", script, true);
    }

    public static void OpenErrorPage(string err, Page page)
    {
        try
        {
            page.Response.Redirect(Public.RelativelyPath("ErrorMsg.aspx") + "?ems=" + page.Server.UrlEncode(err), false);
        }
        catch (Exception)
        {
        }
    }

    public static void PageClose(string str, Page page)
    {
        PageClose_OpenWindow(str, page);
    }

    public static void PageClose_OpenWindow(string str, Page page)
    {
        if (str != "")
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", "window.opener.parent.ShowMsg_TS('" + str + "');window.close();", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", "window.close();", true);
        }
    }

    public static void PageClose_Window(string str, Page page)
    {
        if (str != "")
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", "alert('" + str + "');window.close();", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", "window.close();", true);
        }
    }

    public static void ShowMessage(string str, Page page)
    {
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "alert('" + str + "');", true);
    }

    public static void ShowMessage_List(string str, Page page)
    {
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "window.parent.ShowMsg_TS('" + str + "');", true);
    }

    public static void ShowMessage_OpenWindow(string str, Page page)
    {
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "window.opener.parent.ShowMsg_TS_Open(this, '" + str + "');", true);
    }

    public static void ShowMessageAndClose(string str, Page page)
    {
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", "alert('" + str + "');window.close();window.opener.location.reload();", true);
    }

    public static void SorryForPower(Page page)
    {
        SorryForPower_Open(page);
    }

    public static void SorryForPower_List(Page page)
    {
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "window.parent.ShowMsg_TS('对不起,您没有此功能的权限！');", true);
    }

    public static void SorryForPower_Open(Page page)
    {
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "window.opener.parent.ShowMsg_TS('对不起,您没有此功能的权限！'); window.close();", true);
    }

    public static void UpdateSuccess(int count, Page page)
    {
        if (count > 0)
        {
            DoSuccessClose("", page);
        }
        else
        {
            OpenErrorPage("操作失败，请联系管理员！", page);
        }
    }

    public static void UpdateSuccess(int count, string str, Page page)
    {
        if (count > 0)
        {
            DoSuccessClose(str, page);
        }
        else
        {
            OpenErrorPage("操作失败，请联系管理员！", page);
        }
    }
}

