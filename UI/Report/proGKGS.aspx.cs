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

public class Report_proGKGS : Page, IRequiresSessionState
{
    protected Button btnquery;
    protected DropDownList ddlprocess;
    protected DropDownList ddlxz;
    protected DropDownList ddlyear;
    protected SmartGridView gvResult;
    protected HtmlInputHidden hcode;
    private ReportPublicBll reportPublicBll = new ReportPublicBll();
    protected tablepage_reprotButtonl reprotButtonl1;
    protected HtmlInputText txtcids;
    protected TextBox txtproname;
    protected HtmlInputText txtxz;

    protected void btnquery_Click(object sender, EventArgs e)
    {
        string strWhere = " PD_YEAR=" + this.ddlyear.SelectedValue;
        if (this.ddlxz.SelectedValue != "0")
        {
            strWhere = strWhere + " and pd_found_xz='" + this.ddlxz.SelectedValue + "'";
        }
        if (((UserModel)this.Session["user"]).Company.IsHasBaby == "1")
        {
            if (this.txtcids.Value != "")
            {
                strWhere = strWhere + " and trim(pd_project_input_company )  in('" + this.txtcids.Value.Replace(",", "','") + "')";
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
        this.ShowInfo(strWhere);
        switch (this.ddlprocess.SelectedValue)
        {
            case "1":
                this.gvResult.Columns[3].Visible = true;
                this.gvResult.Columns[5].Visible = true;
                this.gvResult.Columns[6].Visible = true;
                this.gvResult.Columns[7].Visible = false;
                this.gvResult.Columns[8].Visible = false;
                this.gvResult.Columns[9].Visible = false;
                this.gvResult.Columns[10].Visible = false;
                this.gvResult.Columns[11].Visible = false;
                this.gvResult.Columns[12].Visible = false;
                return;

            case "2":
                this.gvResult.Columns[3].Visible = false;
                this.gvResult.Columns[5].Visible = false;
                this.gvResult.Columns[6].Visible = false;
                this.gvResult.Columns[7].Visible = true;
                this.gvResult.Columns[8].Visible = true;
                this.gvResult.Columns[9].Visible = true;
                this.gvResult.Columns[10].Visible = true;
                this.gvResult.Columns[11].Visible = false;
                this.gvResult.Columns[12].Visible = false;
                break;

            case "3":
                this.gvResult.Columns[3].Visible = true;
                this.gvResult.Columns[5].Visible = false;
                this.gvResult.Columns[6].Visible = false;
                this.gvResult.Columns[7].Visible = false;
                this.gvResult.Columns[8].Visible = false;
                this.gvResult.Columns[9].Visible = false;
                this.gvResult.Columns[10].Visible = false;
                this.gvResult.Columns[11].Visible = true;
                this.gvResult.Columns[12].Visible = true;
                break;
        }
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
            DataSet list = this.reportPublicBll.GetList("1<>1", "V_GKGS");
            DataTable table = new DataTable();
            table = list.Tables[0];
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            this.gvResult.DataSource = table.DefaultView;
            this.gvResult.DataBind();
        }
    }

    private void ShowInfo(string strWhere)
    {
        DataSet list = new ReportPublicBll().GetList(strWhere, "V_GKGS");
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

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }
}
