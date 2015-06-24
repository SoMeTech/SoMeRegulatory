using ASP;
using ExceptionLog;
using ExtExtenders;
using SoMeTech.Company;
using SoMeTech.Company.Bank;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Company_CompanyAdd : Page, IRequiresSessionState
{
    private DB_OPT dbo;
    protected HtmlGenericControl divbh;
    protected DropDownList dropBankPK;
    private ExceptionLog.ExceptionLog el;
    protected TabContainer TabContainer1;
    protected TabPanel TabPanel1;
    protected TabPanel TabPanel2;
    protected TextBox txtAddress;
    protected TextBox txtArea;
    protected HtmlInputHidden txtcmbh;
    protected TextBox txtCountry;
    protected TextBox txtDiscription;
    protected TextBox txtDutyNum;
    protected TextBox txtEmail1;
    protected TextBox txtEmail2;
    protected TextBox txtEmail3;
    protected TextBox txtFax1;
    protected TextBox txtFax2;
    protected TextBox txtFax3;
    protected TextBox txtFPDWM;
    protected TextBox txtHolder;
    protected TextBox txtInvoiceType;
    protected HtmlInputHidden txtishasbaby;
    protected TextBox txtKeyChar;
    protected TextBox txtlinkman1;
    protected TextBox txtlinkman2;
    protected TextBox txtName;
    protected TextBox txtPhone1;
    protected TextBox txtPhone2;
    protected TextBox txtPhone3;
    protected TextBox txtpk_corp;
    protected TextBox txtPostalCode;
    protected TextBox txtProvince;
    protected TextBox txtRegMoney;
    protected TextBox txtShortName;
    protected TextBox txtsjgs;
    protected HtmlInputHidden txtsjgspk;
    protected TextBox txtUrl;

    private void AddCompany()
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            if ((this.txtName.Text.Trim() == "") || (this.txtpk_corp.Text.Trim() == ""))
            {
                Const.ShowMessage("带*的数据必须填写！", this.Page);
            }
            else
            {
                CompanyModel model = new CompanyDal();
                CompanyModel model2 = new CompanyDal();
                if (model.Exists(this.txtpk_corp.Text.Trim(), this.dbo) > 0)
                {
                    Const.ShowMessage("公司编号已经存在！", this.Page);
                }
                else
                {
                    model2.FatherPK = this.txtsjgspk.Value.Trim();
                    if (model2.FatherPK != "")
                    {
                        model2.pk_corp = model2.FatherPK.Trim();
                        model2 = model2.GetModel(false, false, false, this.dbo);
                        if (model2.IsHasBaby == "0")
                        {
                            model.pk_corp = model2.pk_corp;
                            model.UpdateHasBaby(this.dbo);
                        }
                        model.PKPath = model2.PKPath + model2.pk_corp + "|";
                        model.Grade = model2.Grade + 1;
                    }
                    else
                    {
                        model.Grade = 0;
                    }
                    model.ZXBJ = "0";
                    model.FatherPK = this.txtsjgspk.Value.Trim();
                    model.IsHasBaby = "0";
                    model.pk_corp = this.txtpk_corp.Text.Trim();
                    model.Name = this.txtName.Text.Trim();
                    model.Address = this.txtAddress.Text.Trim();
                    model.Area = this.txtArea.Text.Trim();
                    model.Country = this.txtCountry.Text.Trim();
                    model.Discription = this.txtDiscription.Text.Trim();
                    model.DutyNum = this.txtDutyNum.Text.Trim();
                    model.Email1 = this.txtEmail1.Text.Trim();
                    model.Email2 = this.txtEmail2.Text.Trim();
                    model.Email3 = this.txtEmail3.Text.Trim();
                    model.Fax1 = this.txtFax1.Text.Trim();
                    model.Fax2 = this.txtFax2.Text.Trim();
                    model.Fax3 = this.txtFax3.Text.Trim();
                    model.FPDWM = this.txtFPDWM.Text.Trim();
                    model.Holder = this.txtHolder.Text.Trim();
                    model.InvoiceType = this.txtInvoiceType.Text.Trim();
                    model.KeyChar = this.txtKeyChar.Text.Trim();
                    model.linkman1 = this.txtlinkman1.Text.Trim();
                    model.linkman2 = this.txtlinkman2.Text.Trim();
                    model.Name = this.txtName.Text.Trim();
                    model.Phone1 = this.txtPhone1.Text.Trim();
                    model.Phone2 = this.txtPhone2.Text.Trim();
                    model.Phone3 = this.txtPhone3.Text.Trim();
                    model.PostalCode = this.txtPostalCode.Text.Trim();
                    model.Province = this.txtProvince.Text.Trim();
                    if (this.txtRegMoney.Text.Trim() != "")
                    {
                        model.RegMoney = decimal.Parse(this.txtRegMoney.Text.Trim());
                    }
                    model.ShortName = this.txtShortName.Text.Trim();
                    model.Url = this.txtUrl.Text.Trim();
                    model.PostalCode = this.txtPostalCode.Text.Trim();
                    int count = model.Add(this.dbo);
                    if (base.Request["reload"] != null)
                    {
                        Const.AddSuccess(count, base.Request["reload"].ToString(), this.Page);
                    }
                    else
                    {
                        Const.AddSuccess(count, "", this.Page);
                    }
                }
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "AddCompany()";
            this.el.WriteExceptionLog(true);
            Const.OpenErrorPage("操作失败，请联系管理员！", this.Page);
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
    }

    private void BindDropDown(DB_OPT dbo)
    {
        DataSet list = new BankDal().GetList("", dbo);
        if ((list != null) && (list.Tables[0].Rows.Count > 0))
        {
            this.dropBankPK.DataSource = list;
            this.dropBankPK.DataTextField = "BankName";
            this.dropBankPK.DataValueField = "BankPK";
            this.dropBankPK.DataBind();
        }
    }

    public void Buttons(string ibtid)
    {
        string str;
        if (((str = ibtid) != null) && (str != "ibtcontrol_ibtadd"))
        {
            if (!(str == "ibtcontrol_ibtsave"))
            {
                if (((str == "ibtcontrol_ibtrefresh") || (str == "ibtcontrol_ibtset")) || (str != "ibtcontrol_ibtexit"))
                {
                }
            }
            else
            {
                this.AddCompany();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增单位信息";
        this.Master.TitlePic = "新增单位信息";
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (!this.Page.IsPostBack)
        {
            if (this.Session["User"] != null)
            {
                try
                {
                    try
                    {
                        string userName = ((UserModel)this.Session["User"]).UserName;
                        string power = ((UserModel)this.Session["User"]).Power;
                        string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
                        ButtonsModel model = new ButtonsModel(userName);
                        if (PowerClass.IfHasPower(userName, power, PowerNum.CompanyAdd))
                        {
                            model.IfAdd = false;
                            model.IfSave = true;
                            model.IfUpdate = false;
                            model.IfDelete = false;
                            model.IfLook = false;
                            model.IfSearch = false;
                            model.IfRefresh = true;
                            model.IfHuiZong = false;
                            model.IfPutOut = false;
                            model.IfSet = false;
                            model.IfDispose = false;
                            model.IfExit = true;
                            this.Master.btModel = model;
                            this.dbo = new DB_OPT();
                            this.dbo.Open();
                            this.BindDropDown(this.dbo);
                        }
                        else
                        {
                            Const.SorryForPower(this.Page);
                        }
                    }
                    catch (Exception exception)
                    {
                        this.el = new ExceptionLog.ExceptionLog();
                        this.el.ErrClassName = base.GetType().ToString();
                        this.el.ErrMessage = exception.Message.ToString();
                        this.el.ErrMethod = "Page_Load()";
                        this.el.WriteExceptionLog(true);
                        Const.OpenErrorPage("获取数据失败，请联系管理员！", this.Page);
                    }
                    return;
                }
                finally
                {
                    if (this.dbo != null)
                    {
                        this.dbo.Close();
                    }
                }
            }
            Const.GoLoginPath_Open(this.Page);
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
