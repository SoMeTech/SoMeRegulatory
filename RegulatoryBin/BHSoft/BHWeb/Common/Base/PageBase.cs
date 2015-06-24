namespace BHSoft.BHWeb.Common.Base
{
    using BHSoft.BHWeb.Common;
    using BHSoft.BHWeb.Common.CommonClasses;
    using BHSoft.BHWeb.Common.Configuration;
    using System;
    using System.Data;
    using System.Web;
    using System.Web.UI;

    public class PageBase : Page
    {
        protected string Key = "";

        protected virtual void CheckIsAuthenticated()
        {
            if (base.Request.Url.AbsolutePath.ToLower().IndexOf("websource") <= 0)
            {
                base.Request.Url.AbsolutePath.ToLower().IndexOf("manager");
            }
        }

        protected string ConvToPageStr(object obj)
        {
            return this.ConvToPageStr(obj, 0);
        }

        protected string ConvToPageStr(object obj, int type)
        {
            if ((obj != null) && (obj.ToString().Length != 0))
            {
                return obj.ToString();
            }
            if (type == 1)
            {
                return "&nbsp;";
            }
            return "";
        }

        protected IDbConnection GetConn()
        {
            IDbConnection connection;
            if (this.Context.Cache[Const.DB_Conn_Key] == null)
            {
                connection = CommonUtil.OpenDataBase();
            }
            else
            {
                connection = (IDbConnection) this.Context.Cache[Const.DB_Conn_Key];
                log.DebugLog("从Cache中取得数据库连接！");
            }
            if ((connection != null) && (connection.State == ConnectionState.Closed))
            {
                connection.Open();
                log.DebugLog("GetConn() 取得正常的数据库连接！");
            }
            return connection;
        }

        protected string GetLoginUserName()
        {
            if ((base.Request.Cookies["UserID"] != null) && (base.Request.Cookies["UserName"] != null))
            {
                return HttpUtility.UrlDecode(base.Request.Cookies["UserName"].Value.ToString());
            }
            return "";
        }

        protected string GetLoginUserNo()
        {
            if ((base.Request.Cookies["UserID"] != null) && (base.Request.Cookies["UserName"] != null))
            {
                return HttpUtility.UrlDecode(base.Request.Cookies["UserID"].Value.ToString());
            }
            return "";
        }

        protected override void OnInit(EventArgs e)
        {
            this.Session.Add("Page_Key", this.Key);
            this.CheckIsAuthenticated();
            base.OnInit(e);
            base.Load += new EventHandler(this.PageObject_Load);
        }

        protected virtual void PageObject_Error(object sender, EventArgs e)
        {
            if (!base.Request.UserHostAddress.Equals("127.0.0.1"))
            {
                log.ErrorLog(base.Server.GetLastError());
                base.Server.ClearError();
                if (base.ErrorPage.Length == 0)
                {
                    try
                    {
                        base.ErrorPage = this.PageConfig.PageUrls["ErrorPage"].ToString();
                    }
                    catch
                    {
                    }
                }
                base.Response.Redirect(base.ErrorPage);
            }
        }

        private void PageObject_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.Page.DataBind();
            }
        }

        protected void ShowErrorPage(int argCode, string retUrl)
        {
            base.Response.Redirect(string.Concat(new object[] { this.PageConfig.PageUrls["Message"], "?Type=2&Code=", argCode.ToString(), "&RetUrl=", HttpUtility.UrlEncode(retUrl) }), true);
        }

        protected void ShowInfoPage(int argCode, string retUrl)
        {
            base.Response.Redirect(string.Concat(new object[] { this.PageConfig.PageUrls["Message"], "?Type=0&Code=", argCode.ToString(), "&RetUrl=", HttpUtility.UrlEncode(retUrl) }));
        }

        protected void ShowMemberMsgPage(int argCode, string retUrl)
        {
        }

        protected void ShowWarningPage(int argCode, string retUrl)
        {
            base.Response.Redirect(string.Concat(new object[] { this.PageConfig.PageUrls["Message"], "?Type=1&Code=", argCode.ToString(), "&RetUrl=", HttpUtility.UrlEncode(retUrl) }));
        }

        protected virtual ModuleConfig PageConfig
        {
            get
            {
                return new ModuleConfig();
            }
        }
    }
}

