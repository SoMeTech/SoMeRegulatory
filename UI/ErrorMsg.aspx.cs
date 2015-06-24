using ASP;
using ExceptionLog;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ErrorMsg : Page, IRequiresSessionState
{
    private ExceptionLog.ExceptionLog el = new ExceptionLog.ExceptionLog();
    protected HtmlForm form1;
    protected Label labError;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            if ((base.Request["ems"] != null) && (base.Request["ems"].ToString() != ""))
            {
                this.labError.Text = base.Server.UrlDecode(base.Request["ems"].ToString());
            }
            else
            {
                this.labError.Text = "您当前访问的页面不存在或者正在建设中！";
            }
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
