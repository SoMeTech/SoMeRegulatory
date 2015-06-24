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

public class Company_CompanyUpdate : Page, IRequiresSessionState
{
    private DB_OPT dbo;
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

    private string BingData(string pk_corp, DB_OPT dbo)
    {
        CompanyModel model = new CompanyDal
        {
            pk_corp = pk_corp
        };
        model = model.GetModel(false, true, false, dbo);
        this.txtpk_corp.Text = base.Request["PK"].ToString();
        this.txtcmbh.Value = model.BH;
        this.txtName.Text = model.Name;
        this.txtishasbaby.Value = model.IsHasBaby;
        this.txtAddress.Text = model.Address;
        this.txtArea.Text = model.Area;
        this.txtCountry.Text = model.Country;
        this.txtDiscription.Text = model.Discription;
        this.txtDutyNum.Text = model.DutyNum;
        this.txtEmail1.Text = model.Email1;
        this.txtEmail2.Text = model.Email2;
        this.txtEmail3.Text = model.Email3;
        this.txtFax1.Text = model.Fax1;
        this.txtFax2.Text = model.Fax2;
        this.txtFax3.Text = model.Fax3;
        this.txtFPDWM.Text = model.FPDWM;
        this.txtHolder.Text = model.Holder;
        this.txtInvoiceType.Text = model.InvoiceType;
        this.txtKeyChar.Text = model.KeyChar;
        this.txtlinkman1.Text = model.linkman1;
        this.txtlinkman2.Text = model.linkman2;
        this.txtName.Text = model.Name;
        this.txtPhone1.Text = model.Phone1;
        this.txtPhone2.Text = model.Phone2;
        this.txtPhone3.Text = model.Phone3;
        if (model.FatherInfo != null)
        {
            this.txtsjgs.Text = model.FatherInfo.Name;
        }
        this.txtsjgspk.Value = model.FatherPK;
        this.txtPostalCode.Text = model.PostalCode;
        this.txtProvince.Text = model.Province;
        this.txtRegMoney.Text = model.RegMoney.ToString();
        this.txtShortName.Text = model.ShortName;
        this.txtUrl.Text = model.Url;
        this.txtPostalCode.Text = model.PostalCode;
        return model.PKPath;
    }

    public void Buttons(string ibtid)
    {
        string str;
        if (((str = ibtid) != null) && (str != "ibtcontrol_ibtupdate"))
        {
            if (!(str == "ibtcontrol_ibtsave"))
            {
                if (((str == "ibtcontrol_ibtrefresh") || (str == "ibtcontrol_ibtset")) || (str != "ibtcontrol_ibtexit"))
                {
                }
            }
            else
            {
                this.UpdateCompany();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改单位信息";
        this.Master.TitlePic = "修改单位信息";
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (!this.Page.IsPostBack)
        {
            if (this.Session["User"] != null)
            {
                if (base.Request.QueryString["PK"] == null)
                {
                    return;
                }
                try
                {
                    try
                    {
                        string userName = ((UserModel)this.Session["User"]).UserName;
                        string power = ((UserModel)this.Session["User"]).Power;
                        string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
                        ButtonsModel model = new ButtonsModel(userName);
                        if (PowerClass.IfHasPower(userName, power, PowerNum.CompanyUpdate))
                        {
                            model.IfAdd = false;
                            model.IfUpdate = false;
                            model.IfSave = true;
                            model.IfDelete = false;
                            model.IfLook = false;
                            model.IfSearch = false;
                            model.IfRefresh = true;
                            model.IfHuiZong = false;
                            model.IfPutOut = false;
                            model.IfSet = false;
                            model.IfExit = true;
                            this.Master.btModel = model;
                            this.dbo = new DB_OPT();
                            this.dbo.Open();
                            this.BindDropDown(this.dbo);
                            this.BingData(base.Request.QueryString["PK"].ToString(), this.dbo);
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

    private void UpdateCompany()
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
                CompanyModel model2 = new CompanyDal
                {
                    FatherPK = this.txtsjgspk.Value.Trim()
                };
                if (model2.FatherPK != "")
                {
                    model2.pk_corp = model2.FatherPK;
                    model2 = model2.GetModel(false, false, false, this.dbo);
                    if (model2.IsHasBaby == "0")
                    {
                        model.pk_corp = model2.pk_corp;
                        model.UpdateHasBaby(this.dbo);
                    }
                    model.PKPath = model2.PKPath + model2.pk_corp + "|";
                    if (this.txtishasbaby.Value == "1")
                    {
                        Companybll.ChangeChildPkPath(base.Request.QueryString["PK"].ToString(), model.PKPath + base.Request.QueryString["PK"].ToString() + "|", model2.Grade + 2, this.dbo);
                    }
                    model.Grade = model2.Grade + 1;
                }
                else
                {
                    model.Grade = 0;
                }
                model.FatherPK = this.txtsjgspk.Value.Trim();
                model.IsHasBaby = this.txtishasbaby.Value;
                model.pk_corp = this.txtpk_corp.Text.Trim();
                model.BH = this.txtcmbh.Value.Trim();
                model.Name = this.txtName.Text.Trim();
                model.IsHasBaby = this.txtishasbaby.Value.Trim();
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
                Const.UpdateSuccess(model.Update(base.Request.QueryString["PK"].ToString().Trim(), this.dbo), this.Page);
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "UpdateCompany()";
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
