using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Work_projectGL_ssProjectCCXC_Default : Page, IRequiresSessionState
{
    protected DropDownList ddlzjly;
    protected HtmlForm form1;
    protected TextBox TextBox1;
    protected HtmlInputText txtPD_INSPECTION_DATE;
    protected TextBox txtPD_QUOTA_BASIS_JG;
    protected TextBox txtPD_QUOTA_COMPANY;
    protected TextBox txtPD_QUOTA_FWDATA;
    protected HtmlTable zxzb_bt;

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void UploadButton_Click(object sender, EventArgs e)
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
