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

public class Report_zjxxCDdjb : Page, IRequiresSessionState
{
    private string _bianzdw;
    protected Button btnQuery;
    protected DropDownList ddlxz;
    protected SmartGridView gvResult;
    protected tablepage_reprotButtonl reprotButtonl1;
    protected HtmlInputText txtcids;
    protected HtmlInputText txtdepart;
    protected HtmlInputText txtname;
    protected HtmlInputText txtwh;
    protected TextBox txtyear;

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        string strWhere = " 1=1 ";
        if (this.ddlxz.SelectedValue != "0")
        {
            strWhere = strWhere + " and trim(资金性质)='" + this.ddlxz.SelectedValue + "'";
        }
        if (this.txtwh.Value.Trim() != "")
        {
            strWhere = strWhere + " and trim(pd_quota_zbwh) like '%" + this.txtwh.Value + "%'";
        }
        if (this.txtname.Value != "")
        {
            strWhere = strWhere + " and trim(文件名称) like '%" + this.txtname.Value + "%'";
        }
        if (this.txtyear.Text != "")
        {
            strWhere = strWhere + " and trim(pd_year) like '%" + this.txtyear.Text + "%'";
        }
        if (this.txtdepart.Value != "")
        {
            strWhere = strWhere + " and trim(pd_quota_depart)  in('" + this.txtcids.Value.Replace(",", "','") + "')";
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
        DataSet list = new ReportPublicBll().GetList(strWhere, "v_quota_pass");
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

    public string Bianzdw
    {
        get
        {
            return this._bianzdw;
        }
        set
        {
            this._bianzdw = value;
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
