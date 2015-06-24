using ASP;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using YYControls;
using SMZJ.BLL;

public partial class Work_PublicAspx_ShowLog : Page, IRequiresSessionState
{
    protected WebControls_Buttons1 Buttons1_1;
    protected HtmlForm form1;
    protected SmartGridView gvResult;

    public void Buttons(string ibtid)
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            DataSet list = new PD_PROJECT_LOG_Bll().GetList(base.Request["code"], base.Request["type"]);
            int count = list.Tables[0].Rows.Count;
            this.gvResult.DataSource = list;
            this.gvResult.DataBind();
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
