namespace BHSoft.BHWeb.Common.Base
{
    using BHSoft.BHWeb.Common;
    using BHSoft.BHWeb.Common.CommonClasses;
    using BHSoft.BHWeb.Common.Configuration;
    using System;
    using System.Data;
    using System.Web;
    using System.Web.UI;

    public class ControlBase : UserControl
    {
        protected string Key = "";

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
            if ((connection == null) || (connection.State == ConnectionState.Closed))
            {
                base.Response.Redirect(@"\ErrorPage.htm");
            }
            return connection;
        }

        protected string GetLoginUserNo()
        {
            return "";
        }

        protected override void OnInit(EventArgs e)
        {
            base.Session.Add("Page_Key", this.Key);
            base.OnInit(e);
            base.Load += new EventHandler(this.PageObject_Load);
        }

        protected virtual void PageObject_Error(object sender, EventArgs e)
        {
            if (!base.Request.UserHostAddress.Equals("127.0.0.1"))
            {
                log.ErrorLog(base.Server.GetLastError());
                base.Server.ClearError();
            }
        }

        private void PageObject_Load(object sender, EventArgs e)
        {
        }

        protected void ShowErrorPage(int argCode, string retUrl)
        {
            base.Response.Redirect(base.Request.ApplicationPath + "Message.aspx?Type=2&Code=" + argCode.ToString() + "&RetUrl=" + HttpUtility.UrlEncode(retUrl), true);
        }

        protected void ShowInfoPage(int argCode, string retUrl)
        {
            base.Response.Redirect(base.Request.ApplicationPath + "Message.aspx?Type=0&Code=" + argCode.ToString() + "&RetUrl=" + HttpUtility.UrlEncode(retUrl));
        }

        protected void ShowMemberMsgPage(int argCode, string retUrl)
        {
            base.Response.Redirect(base.Request.ApplicationPath + "MemberCenter/MemberMessage.aspx?Type=0&Code=" + argCode.ToString() + "&RetUrl=" + HttpUtility.UrlEncode(retUrl));
        }

        protected void ShowWarningPage(int argCode, string retUrl)
        {
            base.Response.Redirect(base.Request.ApplicationPath + "Message.aspx?Type=1&Code=" + argCode.ToString() + "&RetUrl=" + HttpUtility.UrlEncode(retUrl));
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

