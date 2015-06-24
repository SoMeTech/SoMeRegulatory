using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public class Shared_Test : Page, IRequiresSessionState
{
    protected HtmlInputButton Button1;
    protected HtmlForm form1;
    protected HtmlInputText txtId;
    protected HtmlInputText txtMess;

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
