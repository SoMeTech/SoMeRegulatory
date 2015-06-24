using ASP;
using System;
using System.Web.Profile;
using System.Web.UI;

public partial class WebControls_TextboxButtonControl : UserControl
{
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
