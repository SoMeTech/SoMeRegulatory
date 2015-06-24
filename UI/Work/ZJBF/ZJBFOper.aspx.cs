using ASP;
using SoMeTech.CommonDll;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SMZJ.BLL;
using SMZJ.Model;

public class Work_ZJBF_ZJBFOper : Page, IRequiresSessionState
{
    private long AUTO_NO;
    private PD_FOUND_OUT_Bll bll = new PD_FOUND_OUT_Bll();
    protected HtmlInputHidden company;
    protected HtmlInputHidden db_name;
    protected DropDownList ddlmonth;
    protected DropDownList ddlPD_CONTRACT_TYPE;
    protected DropDownList ddlPD_FOUND_SOURCES;
    protected DropDownList ddlPD_FOUND_STYLE;
    protected DropDownList ddlPD_FOUND_TYPE;
    protected DropDownList ddlPD_IF_HAVE;
    protected DropDownList ddlPD_YEAR;
    protected DropDownList ddlyear;
    protected HtmlInputHidden Hidden1;
    public string strid = "";
    protected HtmlInputHidden txt_fzhs_DB;
    protected HtmlInputHidden txt_kjkmDB_DF;
    protected HtmlInputHidden txt_kjkmDB_JF;
    protected TextBox txtAUTO_NO;
    protected TextBox txtcontract_name;
    protected TextBox txtPD_CONTRACT_COMPANY;
    protected TextBox txtPD_CONTRACT_MONEY;
    protected TextBox txtPD_FOUND_ACC_TYPE;
    protected TextBox txtPD_FOUND_COMPANY;
    protected TextBox txtPD_FOUND_DATE;
    protected TextBox txtPD_FOUND_FILENAME;
    protected TextBox txtPD_FOUND_MONEY;
    protected TextBox txtPD_FOUND_MONEY_TOTAL;
    protected TextBox txtPD_FOUND_MONEY_WCL;
    protected TextBox txtPD_FOUND_SYS_FILENAME;
    protected TextBox txtPD_FOUND_SYS_JJFL;
    protected TextBox txtPD_FOUND_VOUNO;
    protected TextBox txtPD_PROJECT_CODE;
    protected TextBox txtPD_PROJECT_CONTRACT;
    protected TextBox txtPD_PROJECT_MONEY_TOTAL;
    protected TextBox txtPD_PROJECT_NAME;

    private void BindDDList()
    {
        PublicDal.BindDropDownList(this.ddlPD_YEAR, "PD_BASE_YEAR", "YEAR_NAME", "YEAR_CODE", "");
        this.ddlPD_YEAR.SelectedValue = DateTime.Now.Year.ToString();
        PublicDal.BindDropDownList(this.ddlyear, "PD_BASE_YEAR", "YEAR_NAME", "YEAR_CODE", "");
        this.ddlyear.SelectedValue = DateTime.Now.Year.ToString();
        PublicDal.BindDropDownList(this.ddlPD_IF_HAVE, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_FOUND_STYLE, "PD_BASE_AllocationWay", "AllocationWay_Name", "AllocationWay_Code", "");
        PublicDal.BindDropDownList(this.ddlPD_FOUND_TYPE, "PD_BASE_OUTTYPE", "OUTTYPE_Name", "OUTTYPE_Code", "");
        PublicDal.BindDropDownList(this.ddlPD_FOUND_SOURCES, "PD_BASE_Resource", "Resource_Name", "Resource_Code", "");
        PublicDal.BindDropDownList(this.ddlPD_CONTRACT_TYPE, "PD_BASE_CONTRACTTYPE", "CONTRACTTYPE_NAME", "CONTRACTTYPE_CODE", "");
        UserModel model = (UserModel)this.Session["User"];
        this.company.Value = model.Company.pk_corp;
    }

    public void Buttons(string ibtid)
    {
        switch (ibtid)
        {
            case "ibtcontrol_ibtadd":
                PageShowText.OpenPage("ZJBFOper.aspx", null, null, this.Page);
                return;

            case "ibtcontrol_ibtupdate":
                if ((base.Request["UpdatePK"] != null) && (base.Request["UpdatePK"].Trim() != ""))
                {
                    this.UpdataData(base.Request["UpdatePK"].Trim());
                }
                return;

            case "ibtcontrol_ibtdelete":
                if ((base.Request["UpdatePK"] != null) && (base.Request["UpdatePK"].Trim() != ""))
                {
                    this.DelData(Convert.ToInt32(base.Request["UpdatePK"].Trim()));
                }
                return;

            case "ibtcontrol_ibtsave":
                if ((base.Request["UpdatePK"] == null) || !(base.Request["UpdatePK"].Trim() != ""))
                {
                    this.CreateData();
                    break;
                }
                this.UpdataData(base.Request["UpdatePK"].Trim());
                return;

            case "ibtcontrol_ibtrefresh":
                break;

            case "ibtcontrol_ibtaudit":
                this.SetServiceStream(1, base.Request.Params["UpdatePK"], "审核");
                return;

            case "ibtcontrol_ibtapply":
                this.SetServiceStream(1, base.Request.Params["UpdatePK"], "审批");
                return;

            case "ibtcontrol_ibtsetback":
                this.SetServiceStream(0, base.Request.Params["UpdatePK"], "弃审");
                return;

            case "ibtcontrol_ibtrollback":
                this.SetServiceStream(0, base.Request.Params["UpdatePK"], "弃审");
                return;

            case "ibtcontrol_ibtlook2":
                this.OutPut_PingZheng(base.Request.Params["UpdatePK"]);
                return;

            default:
                return;
        }
    }

    private void CreateData()
    {
        if (this.PanDuan())
        {
            PD_FOUND_OUT_Model model = this.GetModel(null);
            PD_FOUND_OUT_Bll bll = new PD_FOUND_OUT_Bll();
            model.PD_NOW_SERVERPK = PublicDal.SetCreateServiceStream(this.Page);
            bll.Add(model);
            bll.UpdateLJMoney(model.PD_PROJECT_CODE);
            Const.DoSuccessNoClose("添加成功", this.Page.Request.Url.LocalPath + "?UpdatePK=" + model.AUTO_NO, this.Page);
        }
    }

    protected void ddlPD_QUOTA_FILE_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void DelData(int AUTO_ID)
    {
        new PD_FOUND_OUT_Bll().Delete(AUTO_ID);
        PageShowText.Refurbish("删除成功", this.Page);
    }

    private PD_FOUND_OUT_Model GetModel(PD_FOUND_OUT_Model model)
    {
        if (model == null)
        {
            model = new PD_FOUND_OUT_Model();
            PD_FOUND_OUT_Bll bll = new PD_FOUND_OUT_Bll();
            decimal num = bll.getProjectJSZJE(this.txtPD_PROJECT_CODE.Text);
            DateTime? nullable = null;
            if (PublicDal.PageValidate.IsDateTime(this.txtPD_FOUND_DATE.Text))
            {
                nullable = new DateTime?(DateTime.Parse(this.txtPD_FOUND_DATE.Text));
            }
            decimal num2 = bll.getLJMoney(this.txtPD_PROJECT_CODE.Text, -1L, nullable) + decimal.Parse(this.txtPD_FOUND_MONEY.Text);
            model.PD_FOUND_MONEY_TOTAL = new decimal?(num2);
            model.PD_FOUND_MONEY_WCL = ((model.PD_FOUND_MONEY_TOTAL.Value / num) * 100M).ToString("0.00");
        }
        else
        {
            PD_FOUND_OUT_Bll bll2 = new PD_FOUND_OUT_Bll();
            decimal num3 = bll2.getProjectJSZJE(this.txtPD_PROJECT_CODE.Text);
            DateTime? nullable2 = null;
            if (PublicDal.PageValidate.IsDateTime(this.txtPD_FOUND_DATE.Text))
            {
                nullable2 = new DateTime?(DateTime.Parse(this.txtPD_FOUND_DATE.Text));
            }
            decimal num4 = bll2.getLJMoney(this.txtPD_PROJECT_CODE.Text, model.AUTO_NO, nullable2) + decimal.Parse(this.txtPD_FOUND_MONEY.Text);
            model.PD_FOUND_MONEY_TOTAL = new decimal?(num4);
            model.PD_FOUND_MONEY_WCL = ((model.PD_FOUND_MONEY_TOTAL.Value / num3) * 100M).ToString("0.00");
        }
        if (PublicDal.PageValidate.IsInt(this.ddlPD_YEAR.SelectedValue))
        {
            model.PD_YEAR = new int?(int.Parse(this.ddlPD_YEAR.SelectedValue));
        }
        if (PublicDal.PageValidate.IsInt(this.ddlmonth.SelectedValue))
        {
            model.PD_PZ_MONTH = new int?(int.Parse(this.ddlmonth.SelectedValue));
        }
        if (PublicDal.PageValidate.IsDateTime(this.txtPD_FOUND_DATE.Text))
        {
            model.PD_FOUND_DATE = new DateTime?(DateTime.Parse(this.txtPD_FOUND_DATE.Text));
        }
        if (PublicDal.PageValidate.IsInt(this.ddlPD_IF_HAVE.SelectedValue))
        {
            model.PD_IF_HAVE = new int?(int.Parse(this.ddlPD_IF_HAVE.SelectedValue));
        }
        model.PD_PROJECT_CODE = this.txtPD_PROJECT_CODE.Text;
        model.PD_PROJECT_NAME = this.txtPD_PROJECT_NAME.Text;
        model.PD_CONTRACT_COMPANY = this.txtPD_CONTRACT_COMPANY.Text;
        model.PD_FOUND_COMPANY = this.txtPD_FOUND_COMPANY.Text;
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_CONTRACT_MONEY.Text))
        {
            model.PD_CONTRACT_MONEY = new decimal?(decimal.Parse(this.txtPD_CONTRACT_MONEY.Text));
        }
        model.PD_FOUND_SOURCES = this.ddlPD_FOUND_SOURCES.SelectedValue;
        model.PD_FOUND_TYPE = this.ddlPD_FOUND_TYPE.SelectedValue;
        model.PD_FOUND_STYLE = this.ddlPD_FOUND_STYLE.SelectedValue;
        model.PD_FOUND_ACC_TYPE = this.txtPD_FOUND_ACC_TYPE.Text;
        model.PD_FOUND_VOUNO = this.txtPD_FOUND_VOUNO.Text;
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_FOUND_MONEY.Text))
        {
            model.PD_FOUND_MONEY = new decimal?(decimal.Parse(this.txtPD_FOUND_MONEY.Text));
        }
        model.PD_FOUND_FILENAME = this.txtPD_FOUND_FILENAME.Text;
        model.PD_FOUND_SYS_FILENAME = this.txtPD_FOUND_SYS_FILENAME.Text;
        model.PD_PROJECT_CONTRACT = this.txtPD_PROJECT_CONTRACT.Text;
        model.PD_CONTRACT_TYPE = this.ddlPD_CONTRACT_TYPE.SelectedValue;
        model.PD_CONTRACT_NO = this.txtPD_PROJECT_CONTRACT.Text;
        model.PD_PZ_YEAR = new int?(int.Parse(this.ddlyear.SelectedValue));
        return model;
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    public void OutPut_PingZheng(string auto_no)
    {
        PD_FOUND_OUT_Bll bll = new PD_FOUND_OUT_Bll();
        string str = this.txt_kjkmDB_JF.Value.Trim();
        string str2 = this.txt_kjkmDB_DF.Value.Trim();
        string fzhs = this.txt_fzhs_DB.Value.Trim();
        string databaseName = this.db_name.Value.Trim();
        string str5 = bll.OutPut_PingZheng(auto_no, databaseName, str, str2, fzhs);
        if (str5 == null)
        {
            str5 = "拨付成功，已导入凭证";
        }
        PageShowText.Refurbish(str5, this.Page);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session["User"] == null)
        {
            Const.GoLoginPath_OpenWindow(this.Page);
        }
        else
        {
            if (base.Request["strTitle"] != null)
            {
                this.Master.strTitle = base.Request["strTitle"];
            }
            this.Master.strTitle = base.Request["strTitle"];
            this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
            if (!this.Page.IsPostBack)
            {
                this.BindDDList();
                this.ShowCS();
                ButtonsModel model = null;
                PublicDal.ShowMxButton(this.Page, out model, "PD_FOUND_OUT", "AUTO_NO", base.Request["UpdatePK"], "PD_NOW_SERVERPK");
                if (((base.Request["UpdatePK"] != null) && (base.Request["UpdatePK"].Trim() != "")) && !base.IsPostBack)
                {
                    this.ShowInfo(base.Request["UpdatePK"].Trim());
                }
                this.Master.btModel = model;
            }
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
    }

    private bool PanDuan()
    {
        return true;
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
    }

    public void SetServiceStream(int operation, string AUTO_NO, string Mess)
    {
        PublicDal.SetServiceStream(this.Page, operation, "PD_FOUND_OUT", "AUTO_NO", AUTO_NO, Mess, "PD_NOW_SERVERPK");
    }

    private void ShowCS()
    {
        this.txtPD_FOUND_MONEY.Attributes.Add("onKeyPress", "myKeyDown(this,event,0)");
    }

    private void ShowInfo(string _AUTO_ID)
    {
        if (!string.IsNullOrEmpty(_AUTO_ID))
        {
            this.AUTO_NO = long.Parse(_AUTO_ID);
            PD_FOUND_OUT_Bll bll = new PD_FOUND_OUT_Bll();
            if (bll.Exists(this.AUTO_NO))
            {
                PD_FOUND_OUT_Model modelName = bll.GetModelName(this.AUTO_NO);
                this.txtAUTO_NO.Text = modelName.AUTO_NO.ToString();
                this.ddlPD_YEAR.SelectedValue = modelName.PD_YEAR.ToString();
                this.txtPD_FOUND_DATE.Text = modelName.PD_FOUND_DATE.ToString();
                this.ddlPD_IF_HAVE.SelectedValue = modelName.PD_IF_HAVE.ToString();
                this.txtPD_PROJECT_CODE.Text = modelName.PD_PROJECT_CODE;
                this.txtPD_PROJECT_NAME.Text = modelName.PD_PROJECT_NAME;
                this.txtPD_CONTRACT_COMPANY.Text = modelName.PD_CONTRACT_COMPANY;
                this.txtPD_FOUND_COMPANY.Text = modelName.PD_FOUND_COMPANY;
                this.txtPD_CONTRACT_MONEY.Text = modelName.PD_CONTRACT_MONEY.ToString();
                this.ddlPD_FOUND_SOURCES.SelectedValue = modelName.PD_FOUND_SOURCES;
                this.ddlPD_FOUND_TYPE.SelectedValue = modelName.PD_FOUND_TYPE;
                this.ddlPD_FOUND_STYLE.SelectedValue = modelName.PD_FOUND_STYLE;
                this.txtPD_FOUND_ACC_TYPE.Text = modelName.PD_FOUND_ACC_TYPE;
                this.txtPD_FOUND_VOUNO.Text = modelName.PD_FOUND_VOUNO;
                this.txtPD_FOUND_MONEY.Text = modelName.PD_FOUND_MONEY.ToString();
                this.txtPD_FOUND_MONEY_TOTAL.Text = modelName.PD_FOUND_MONEY_TOTAL.Value.ToString("0.00");
                if ((modelName.PD_FOUND_MONEY_WCL != null) && (modelName.PD_FOUND_MONEY_WCL.Trim().Length != 0))
                {
                    this.txtPD_FOUND_MONEY_WCL.Text = modelName.PD_FOUND_MONEY_WCL + "%";
                }
                else
                {
                    this.txtPD_FOUND_MONEY_WCL.Text = "0%";
                }
                this.txtPD_FOUND_FILENAME.Text = modelName.PD_FOUND_FILENAME;
                this.txtPD_FOUND_SYS_FILENAME.Text = modelName.PD_FOUND_SYS_FILENAME;
                this.txtPD_PROJECT_CONTRACT.Text = modelName.PD_PROJECT_CONTRACT;
                this.txtPD_PROJECT_MONEY_TOTAL.Text = modelName.PD_PROJECT_MONEY_TOTAL;
                this.txtPD_FOUND_ACC_TYPE.Text = modelName.PD_PROJECT_GNFL;
                this.txtPD_FOUND_SYS_JJFL.Text = modelName.PD_PROJECT_JJFL;
                this.ddlyear.SelectedValue = modelName.PD_PZ_YEAR.ToString();
                this.ddlmonth.SelectedValue = modelName.PD_PZ_MONTH.ToString();
                this.ddlPD_CONTRACT_TYPE.SelectedValue = modelName.PD_CONTRACT_TYPE.ToString();
                this.txtPD_PROJECT_CONTRACT.Text = modelName.PD_PROJECT_CONTRACT;
                this.txtcontract_name.Text = modelName.PD_PROJECT_CONTRACT_NAME;
            }
        }
    }

    private void UpdataData(string auto_no)
    {
        if (this.PanDuan())
        {
            PD_FOUND_OUT_Bll bll = new PD_FOUND_OUT_Bll();
            if (bll.Exists(long.Parse(auto_no)))
            {
                PD_FOUND_OUT_Model model = this.GetModel(bll.GetModel(long.Parse(auto_no)));
                bll.Update(model);
                bll.UpdateLJMoney(model.PD_PROJECT_CODE);
                PageShowText.Refurbish("修改成功", this.Page);
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

    public MainAddUpdate Master
    {
        get
        {
            return (MainAddUpdate)base.Master;
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
