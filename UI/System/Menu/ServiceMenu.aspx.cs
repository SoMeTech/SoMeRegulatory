using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class SystemSetup_menu_ServiceMenu : Page, IRequiresSessionState
{
    protected HtmlForm form1;
    protected SiteMapDataSource SiteMapDataSource1;
    protected TreeView TreeView1;

    protected void Page_Load(object sender, EventArgs e)
    {
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
