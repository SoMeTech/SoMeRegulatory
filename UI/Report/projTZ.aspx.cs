using ASP;
using SoMeTech.User;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using YYControls;
using SMZJ.BLL;

public class Report_projTZ : Page, IRequiresSessionState
{
    protected Button btnquery;
    protected DropDownList ddlxz;
    protected SmartGridView gvResult;
    protected HtmlInputHidden hcode;
    protected tablepage_reprotButtonl reprotButtonl1;
    protected HtmlInputText txtcids;
    protected TextBox txtproname;
    protected HtmlInputText txtxz;
    protected HtmlInputText txtxzs;
    protected TextBox txtyear;
    protected HtmlInputHidden upk;

    protected void btnquery_Click(object sender, EventArgs e)
    {
        string strWhere = "1=1";
        if (this.txtproname.Text != "")
        {
            strWhere = strWhere + " and 项目名称 like '%" + this.txtproname.Text + "%'";
        }
        strWhere = (strWhere + " and  项目年度 like '%" + this.txtyear.Text + "%'") + " and 资金性质='" + this.ddlxz.SelectedValue + "'";
        if (this.txtxz.Value.Trim() != "")
        {
            strWhere = strWhere + " and trim(pd_project_input_company)  in('" + this.txtxzs.Value.Replace(",", "','") + "')";
        }
        this.ShowInfo(strWhere);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.ShowInfo("1<>1");
        }
    }

    private void ShowInfo(string strWhere)
    {
        UserModel model1 = (UserModel)this.Session["User"];
        DataSet list = new ReportPublicBll().GetList(strWhere, "V_PD_PROJECT_XMTZ");
        if (list.Tables[0].Rows.Count == 0)
        {
            list.Tables[0].Rows.Add(list.Tables[0].NewRow());
        }
        this.gvResult.DataSource = list.Tables[0];
        this.gvResult.DataBind();
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public MainReport Master
    {
        get
        {
            return (MainReport)base.Master;
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
