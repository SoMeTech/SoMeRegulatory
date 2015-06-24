using ASP;
using System;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class UserControls_FilePostCtr : UserControl
{
    protected HtmlInputHidden filedNamelist;
    public string value;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.value = this.filedNamelist.Value;
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public string getFileName
    {
        get
        {
            return this.filedNamelist.Value;
        }
        set
        {
            this.filedNamelist.Value = value;
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
