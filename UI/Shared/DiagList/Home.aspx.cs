using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

public class Shared_Home : Page, IRequiresSessionState
{
    public string MSSQL = "";
    protected string pageTitle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (base.Request["MSSQL"] != null)
        {
            this.MSSQL = "?MSSQL=" + base.Request["MSSQL"];
        }
        if (this.Session["UsualBookTable"] != null)
        {
            UsualBookTable table = new UsualBookTable();
            table = (UsualBookTable)this.Session["UsualBookTable"];
            this.pageTitle = table.PageTitle;
        }
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }
}
