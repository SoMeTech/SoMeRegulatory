using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class PublicMode_DiagList_GetServerInfo : Page, IRequiresSessionState
{
    protected Button btnCreate;
    protected Button btnSave;
    protected HtmlTextArea content_1;
    protected HtmlForm form1;
    protected Label Label1;

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        this.content_1.Value = new GetServerInfo().GetInfo();
    }

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
