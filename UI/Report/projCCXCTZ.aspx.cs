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

public class Report_projCCXCTZ : Page, IRequiresSessionState
{
    protected Button btnquery;
    protected DropDownList ddlproc;
    protected DropDownList ddlyear;
    protected SmartGridView gvResult;
    protected HtmlInputHidden hcode;
    protected tablepage_reprotButtonl reprotButtonl1;
    protected TextBox txtproname;
    protected HtmlInputText txtxz;
    protected HtmlInputText txtxzs;
    protected HtmlInputHidden upk;

    protected void btnquery_Click(object sender, EventArgs e)
    {
        string strWhere = " PD_YEAR=" + this.ddlyear.SelectedValue + " and  trim(pd_inspection_process)='" + this.ddlproc.SelectedValue + "' ";
        if (((UserModel)this.Session["user"]).Company.IsHasBaby == "1")
        {
            if (this.txtxzs.Value != "")
            {
                strWhere = strWhere + " and trim(pd_project_input_company )  in('" + this.txtxzs.Value.Replace(",", "','") + "')";
            }
            else
            {
                strWhere = strWhere + " and pd_project_input_company in(select pk_corp from db_company where fatherpk='" + ((UserModel)this.Session["user"]).Company.pk_corp + "')";
            }
        }
        else
        {
            strWhere = strWhere + " and pd_project_input_company='" + ((UserModel)this.Session["user"]).Company.pk_corp + "'";
        }
        if (this.txtproname.Text != "")
        {
            strWhere = strWhere + " pd_project_name like '%" + this.txtproname.Text + "%' ";
        }
        this.ShowInfo(strWhere);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            int year = DateTime.Now.AddYears(-5).Year;
            for (int i = 0; i <= 10; i++)
            {
                ddlyear.Items.Add((year + i).ToString());

            }
            ddlyear.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;
            this.ShowInfo("");
        }
    }

    private void ShowInfo(string strWhere)
    {
        DataSet list = new ReportPublicBll().GetList(strWhere, "view_inspection_list");
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
