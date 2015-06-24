namespace SoMeTech.YZXWPageClass
{
    using SoMeTech.User;
    using QxRoom.Common;
    using System;
    using System.Web;
    using System.Web.UI;

    public sealed class PageShowText
    {
        public static void AddSuccess(int count, Page page)
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

        public static void AddSuccess(int count, string str, Page page)
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

        public static void CloseDiv(Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "closediv", "removeWindowFull();", true);
        }

        public static void DoSuccess(string str, bool isClose, Page page)
        {
            if (str == "")
            {
                str = "操作信息成功！";
            }
            if (isClose)
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "alert('" + str + "', this);window.close();", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "alert('" + str + "');window.opener.location.reload();window.close();", true);
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

        public static void DoSuccessList(string str, Page page)
        {
            if (str == "")
            {
                str = "操作信息成功！";
            }
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "alert('" + str + "');window.location.reload();window.close();", true);
        }

        public static void DoSuccessOpen(string str, Page page)
        {
            if (str == "")
            {
                str = "操作信息成功！";
            }
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "alert('" + str + "');window.opener.location.reload();", true);
        }

        public static string GetBinDir()
        {
            return (AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"bin\");
        }

        public string GetCompanyPower()
        {
            return PowerClass.GetPowerString(((UserModel) HttpContext.Current.Session["User"]).CompanyPower);
        }

        public static string GetOpenDialogPageString(string str)
        {
            return ("window.showModalDialog('" + str + "', window, 'dialogWidth:800px; dialogHeight:500px;resizable:0; help:0; scroll:0; status:0');location.reload();");
        }

        public static void GetWidHei(ref int wid, ref int hei)
        {
            string s = HttpContext.Current.Request.Cookies["wid1"].Value;
            string str2 = "0";
            if (HttpContext.Current.Request.Cookies["wid2"] != null)
            {
                str2 = HttpContext.Current.Request.Cookies["wid2"].Value;
            }
            string str3 = HttpContext.Current.Request.Cookies["stu"].Value;
            string str4 = HttpContext.Current.Request.Cookies["hei"].Value;
            if (str3 == "0")
            {
                wid = int.Parse(s);
            }
            else
            {
                wid = int.Parse(str2);
            }
            hei = int.Parse(str4) - 10;
        }

        public static void GoLoginPath_List(Page page)
        {
            string script = "window.parent.ShowMsg_Login('index.aspx');";
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

        public static void GoToPage(string pageurl, Page page)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "open", "window.location.href = '" + pageurl + "'", true);
        }

        public static void GoToPaperPrintPage(string strTitle, string strFileName, Page page)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "open", "window.location.href = '" + Public.RelativelyPath("Paper/OfficeFramer.aspx") + "?mainPK=&strTitle=" + HttpContext.Current.Server.UrlEncode(strTitle) + "&ModelFile=" + HttpContext.Current.Server.UrlEncode(strFileName) + "'", true);
        }

        public static void OpenDialogPage(string str, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "open", "window.showModalDialog('" + str + "', window, 'dialogWidth:800px; dialogHeight:500px;resizable:0; help:0; scroll:0; status:0');location.reload();", true);
        }

        public static void OpenDialogPage(string str, int width, int height, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "open", "window.showModalDialog('" + str + "', window, 'dialogWidth:" + width.ToString() + "px; dialogHeight:" + height.ToString() + "px;resizable:0; help:0; scroll:0; status:0');location.reload();", true);
        }

        public static void OpenErrorPage(string err, Page page)
        {
            page.Response.Redirect(Public.RelativelyPath("ErrorMsg.aspx") + "?ems=" + page.Server.UrlEncode(err), false);
        }

        public static void OpenPage(string str, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "open", "window.open('" + str + "', '', 'toolbar=no,status=no,resizable=no,width=800px,height=600px,scrollbars=no,location=no,left=150,top=50');", true);
        }

        public static void OpenPage(string str, int? width, int? height, Page page)
        {
            int num = 0x556;
            int num2 = 0x300;
            if ((HttpContext.Current.Request.Cookies["allwid"] != null) && (HttpContext.Current.Request.Cookies["allhei"] != null))
            {
                num = int.Parse(HttpContext.Current.Request.Cookies["allwid"].Value);
                num2 = int.Parse(HttpContext.Current.Request.Cookies["allhei"].Value) - 40;
            }
            if (!width.HasValue)
            {
                width = new int?(num);
            }
            if (!height.HasValue)
            {
                height = new int?(num2);
            }
            int num3 = num;
            int? nullable = (num3 - width) / 2;
            if (nullable <= 0)
            {
                nullable = 1;
            }
            int num4 = num2;
            int? nullable2 = (num4 - height) / 2;
            if (nullable2 <= 0)
            {
                nullable2 = 1;
            }
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "open", "window.open('" + str + "', '', 'toolbar=no,status=no,resizable=no,width=" + width.ToString() + "px,height=" + height.ToString() + "px,scrollbars=no,location=no,left=" + nullable.ToString() + "px,top=" + nullable2.ToString() + "px');", true);
        }

        public static void OpenPage(string str, int? width, int? height, Page page, bool IsScrollbars)
        {
            int num = 0x556;
            int num2 = 0x300;
            if ((HttpContext.Current.Request.Cookies["allwid"] != null) && (HttpContext.Current.Request.Cookies["allhei"] != null))
            {
                num = int.Parse(HttpContext.Current.Request.Cookies["allwid"].Value);
                num2 = int.Parse(HttpContext.Current.Request.Cookies["allhei"].Value);
            }
            if (!width.HasValue)
            {
                width = new int?(num);
            }
            if (!height.HasValue)
            {
                height = new int?(num2);
            }
            int num3 = num;
            int? nullable = (num3 - width) / 2;
            if (nullable <= 0)
            {
                nullable = 1;
            }
            int num4 = num2;
            int? nullable2 = (num4 - height) / 2;
            if (nullable2 <= 0)
            {
                nullable2 = 1;
            }
            if (IsScrollbars)
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "open", "window.open('" + str + "', '', 'toolbar=no,status=no,resizable=no,width=" + width.ToString() + "px,height=" + height.ToString() + "px,scrollbars=yes,location=no,left=" + nullable.ToString() + "px,top=" + nullable2.ToString() + "px');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "open", "window.open('" + str + "', '', 'toolbar=no,status=no,resizable=no,width=" + width.ToString() + "px,height=" + height.ToString() + "px,scrollbars=no,location=no,left=" + nullable.ToString() + "px,top=" + nullable2.ToString() + "px');", true);
            }
        }

        public static void OpenPage(string str, int width, int height, int left, int top, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "open", "window.open('" + str + "', '', 'toolbar=no,status=no,resizable=no,width=" + width.ToString() + "px,height=" + height.ToString() + "px,scrollbars=no,location=no,left=" + left.ToString() + ",top=" + top.ToString() + "');", true);
        }

        public static void OpenPage(string str, Page page, int width, int height, int? left, int? top)
        {
            if (!left.HasValue)
            {
                left = 1;
            }
            if (!top.HasValue)
            {
                top = 1;
            }
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "open", string.Concat(new object[] { "window.open('", str, "', '', 'toolbar=no,status=no,resizable=no,width=", width, "px,height=", height, "px,scrollbars=no,location=no,left=", left, ",top=", top, "');" }), true);
        }

        public static void OpenPageFull(string str, Page page)
        {
            string s = "1000";
            string str3 = "760";
            if ((HttpContext.Current.Request.Cookies["allwid"] != null) && (HttpContext.Current.Request.Cookies["allhei"] != null))
            {
                s = HttpContext.Current.Request.Cookies["allwid"].Value;
                str3 = HttpContext.Current.Request.Cookies["allhei"].Value;
            }
            string[] strArray2 = new string[] { "window.open('", str, "', '', 'toolbar=no,status=no,resizable=no,width=", (int.Parse(s) - 10).ToString(), "px,height=", (int.Parse(str3) - 50).ToString(), "px,scrollbars=no,location=no,left=0,top=20');" };
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "open", string.Concat(strArray2), true);
        }

        public static void PageClose(Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", "window.close();", true);
        }

        public static void PageClose(string str, Page page)
        {
            if (str != "")
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", "window.ShowMsg_TS('" + str + "', this);", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", "window.close();", true);
            }
        }

        public static void PageClose_Alert(string str, Page page)
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

        public static void PageClose_OpenServerWindow(bool isreload, string str, Page page)
        {
            string script = "";
            if (isreload)
            {
                script = "window.opener.location.reload();";
            }
            if (str != "")
            {
                script = script + "window.alert('" + str + "');";
            }
            script = script + "window.close();";
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", script, true);
        }

        public static void PageClose_OpenServerWindow(string linkt, string str, Page page)
        {
            if (str != "")
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", "window.ShowMsg_TS('" + str + "', this);", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", "window.opener.location.reload();window.close();", true);
            }
        }

        public static void PageClose_OpenWindow(string str, Page page)
        {
            if (str != "")
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", "window.ShowMsg_TS('" + str + "', this);", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", "window.close();", true);
            }
        }

        public static void PageClose_OpenWindow(string str, string strReload, Page page)
        {
            if (str != "")
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", strReload + ";window.ShowMsg_TS('" + str + "', this);", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", strReload + ";window.close();", true);
            }
        }

        public static void PageClose_OpenWindowInIframe(string str, Page page)
        {
            if (str != "")
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", "window.parent.ShowMsg_TS('" + str + "', this);", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", "window.close();", true);
            }
        }

        public static void PageClose_OpenWindowInIframe(string str, string strReload, Page page)
        {
            if (str != "")
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", strReload + ";window.parent.ShowMsg_TS('" + str + "', this);", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", strReload + ";window.close();", true);
            }
        }

        public static void PageClose_Window(string str, Page page)
        {
            if (str != "")
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", "window.ShowMsg_TS('" + str + "', this);", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", "window.close();", true);
            }
        }

        public static void Refurbish(string str, Page page)
        {
            string script = "location.reload();";
            if (str != "")
            {
                script = "alert('" + str + "');" + script;
            }
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "refurbish", script, true);
        }

        public static void Run_javascript(string str, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", str, true);
        }

        public static void ShowDiv(Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "showdiv", "windowFull();", true);
        }

        public static void ShowMessage(string str, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "window.alert(\"" + str + "\");", true);
        }

        public static void ShowMessage_Alert(string str, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "alert('" + str + "');", true);
        }

        public static void ShowMessage_AlertClose(string str, bool isOpenClose, Page page)
        {
            string str2 = "";
            if (isOpenClose)
            {
                str2 = "window.opener.close();";
            }
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "alert('" + str + "');" + str2 + "window.close();", true);
        }

        public static void ShowMessage_List(string str, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "window.parent.ShowMsg('" + str + "');", true);
        }

        public static void ShowMessage_OpenWindow(string str, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "window.ShowMsg_TS('" + str + "');", true);
        }

        public static void ShowMessage_OpenWindowInIframe(string str, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "window.parent.ShowMsg_TS('" + str + "');", true);
        }

        public static void ShowMessageAndClose(string str, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "close", "window.ShowMsg('" + str + "', this);", true);
        }

        public static void ShowPopup(string str, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "window.parent.ShowPopup({id:'pop1',title:'" + str + "',caption:'消息窗口',message:'',target:'_blank',action:''},'');", true);
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
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "window.ShowMsg_TS('对不起,您没有此功能的权限！', this);", true);
        }

        public static void SorryForPower_OpenInIframe(Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "show", "window.parent.ShowMsg_TS('对不起,您没有此功能的权限！', this);", true);
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
}

