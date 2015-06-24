using ASP;
using ExtExtenders;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Default0 : Page, IRequiresSessionState
{
    protected Button button1;
    protected HtmlForm form1;
    protected ScriptManager ScriptManager1;
    protected TabContainer tabs;
    protected TabPanel tp1;
    protected HtmlInputText txt1;
    protected HtmlInputText txt2;
    protected UpdatePanel UpdatePanel1;

    protected void button1_Click(object sender, EventArgs e)
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.tabs.ActiveTabIndex = 0;
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
