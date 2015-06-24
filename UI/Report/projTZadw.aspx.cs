using ASP;
using SoMeTech.CommonDll;
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

public class Report_projTZadw : Page, IRequiresSessionState
{
    protected Button btnquery;
    protected DropDownList ddllb;
    protected DropDownList ddlxz;
    protected SmartGridView gvResult;
    protected tablepage_reprotButtonl reprotButtonl1;
    protected TextBox txtproname;
    protected HtmlInputText txtxz;
    protected HtmlInputText txtxzs;
    protected TextBox txtyear;
    protected HtmlInputHidden upk;

    private void BindData()
    {
        PublicDal.BindDropDownList(this.ddllb, "pd_project_type", "project_type_name", "project_type_code", "");
    }

    protected void btnquery_Click(object sender, EventArgs e)
    {
        string strWhere = ("1=1 and pd_year like '%" + this.txtyear.Text + "%' and pd_found_xz='" + this.ddlxz.SelectedValue + "'") + " and 项目类别编码='" + this.ddllb.SelectedValue + "' ";
        if (this.txtxz.Value.Trim() != "")
        {
            strWhere = strWhere + " and trim(项目申报单位编码)  in('" + this.txtxzs.Value.Replace(",", "','") + "')";
        }
        if (this.txtproname.Text != "")
        {
            strWhere = strWhere + " and 项目名称 like '%" + this.txtproname.Text + "%' ";
        }
        this.ShowInfo(strWhere);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.upk.Value = ((UserModel)this.Session["user"]).UserPK;
            this.BindData();
            this.ShowInfo("1<>1");
        }
    }

    private void ShowInfo(string strWhere)
    {
        DataSet list = new ReportPublicBll().GetList(strWhere, "V_PD_PROJECT_XMJSZJJGTZ");
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
