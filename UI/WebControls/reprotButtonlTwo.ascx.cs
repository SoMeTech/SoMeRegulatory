using ASP;
using System;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class tablepage_reprotButtonlTwo : UserControl
{
    protected HtmlInputButton Daochu;

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

    public HtmlInputButton DaochuBt
    {
        get
        {
            return this.Daochu;
        }
        set
        {
            this.Daochu = value;
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
