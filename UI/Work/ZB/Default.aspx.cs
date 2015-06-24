using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Work_ZB_Default : Page, IRequiresSessionState
{
    protected DropDownList ddlPD_PROJECT_ISCONTRACT;
    protected DropDownList ddlPD_PROJECT_ZTB_IF_SSFA;
    protected DropDownList ddlPD_PROJECT_ZTB_IF_ZTB;
    protected DropDownList ddlPD_PROJECT_ZTB_STYLE;
    protected HtmlForm form1;
    protected TextBox lblAUTO_NO;
    protected TextBox TextBox1;
    protected TextBox txtPD_PROJECT_FCXMGCL;
    protected TextBox txtPD_PROJECT_GCZLQK;
    protected TextBox txtPD_PROJECT_XXJD;
    protected TextBox txtPD_QUOTA_FWDATA;

    protected void Button1_Click(object sender, EventArgs e)
    {
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
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
