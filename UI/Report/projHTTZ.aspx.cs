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

public class Report_projHTTZ : Page, IRequiresSessionState
{
    protected Button btnquery;
    protected DropDownList ddlxz;
    protected SmartGridView gvResult;
    protected tablepage_reprotButtonl reprotButtonl1;
    protected TextBox txtproname;
    protected HtmlInputText txtxz;
    protected HtmlInputText txtxzs;
    protected TextBox txtyear;
    protected HtmlInputHidden upk;

    protected void btnquery_Click(object sender, EventArgs e)
    {
        string strWhere = "1=1 and pd_found_xz='" + this.ddlxz.SelectedValue + "' and pd_year like '%" + this.txtyear.Text + "%'";
        if (this.txtproname.Text != "")
        {
            strWhere = strWhere + " and 项目名称 like '%" + this.txtproname.Text + "%' ";
        }
        if (this.txtxz.Value.Trim() != "")
        {
            strWhere = strWhere + " and trim(申报单位)  in('" + this.txtxzs.Value.Replace(",", "','") + "')";
        }
        this.ShowInfo(strWhere);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.ShowInfo("1<>1");
            this.upk.Value = ((UserModel)this.Session["user"]).UserPK;
        }
    }

    private void ShowInfo(string strWhere)
    {
        UserModel model1 = (UserModel)this.Session["User"];
        DataSet list = new ReportPublicBll().GetList(strWhere, "V_PD_PROJECT_Contract_TZ");
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
