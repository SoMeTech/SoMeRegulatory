using ASP;
using ExceptionLog;
using ExtExtenders;
using SoMeTech.Company.Branch;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using QxRoom.Common.ControlDo;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Branch_BranchUpdate : MainPageClass, IRequiresSessionState
{
    private DB_OPT dbo;
    private ExceptionLog.ExceptionLog el;
    protected Label labaddress;
    protected Label labbmbh;
    protected Label labemail;
    protected Label labfax;
    protected Label labfzr;
    protected Label labfzrpk;
    protected Label labName;
    protected Label labphone;
    protected Label labsjbm;
    protected Label labssbmpk;
    protected Label labssgs;
    protected Label labssgspk;
    protected WebControls_PowerCompany PowerCompany1;
    protected TabContainer TabContainer1;
    protected TabPanel TabPanel1;
    protected TabPanel TabPanel2;
    protected TextBox txtaddress;
    protected TextBox txtaddress_bak;
    protected TextBox txtbmbh;
    protected TextBox txtbmbh_bak;
    protected TextBox txtemail;
    protected TextBox txtemail_bak;
    protected TextBox txtfax;
    protected TextBox txtfax_bak;
    protected TextBox txtfzr;
    protected HtmlInputHidden txtfzrpk;
    protected HtmlInputHidden txtfzrpk_bak;
    protected HtmlInputHidden txtishasbaby;
    protected TextBox txtName;
    protected TextBox txtName_bak;
    protected TextBox txtphone;
    protected TextBox txtphone_bak;
    protected HtmlInputHidden txtpowerbak;
    protected TextBox txtsjbm;
    protected HtmlInputHidden txtsjbmpk;
    protected HtmlInputHidden txtsjbmpk_bak;
    protected TextBox txtssgs;
    protected HtmlInputHidden txtssgspk;
    protected HtmlInputHidden txtssgspk_bak;

    private string BingData(string bmpk, DB_OPT dbo)
    {
        BranchModel model = new BranchDal
        {
            BranchPK = bmpk
        };
        model = model.GetModel(false, true, true, true, dbo);
        this.txtbmbh.Text = model.BH;
        this.txtbmbh_bak.Text = model.BH;
        this.txtName.Text = model.Name;
        this.txtName_bak.Text = model.Name;
        this.txtaddress.Text = model.Address;
        this.txtaddress_bak.Text = model.Address;
        this.txtfzrpk.Value = model.Manager;
        this.txtfzrpk_bak.Value = model.Manager;
        if (model.ManagerInfo != null)
        {
            this.txtfzr.Text = model.ManagerInfo.Name;
        }
        this.txtemail.Text = model.Email;
        this.txtemail_bak.Text = model.Email;
        this.txtphone.Text = model.Phone;
        this.txtphone_bak.Text = model.Phone;
        this.txtfax.Text = model.Fax;
        this.txtfax_bak.Text = model.Fax;
        this.txtishasbaby.Value = model.IsHasBaby;
        this.txtsjbmpk.Value = model.FatherPK;
        this.txtsjbmpk_bak.Value = model.FatherPK;
        if (model.FatherInfo != null)
        {
            this.txtsjbm.Text = model.FatherInfo.Name;
        }
        this.txtssgspk.Value = model.pk_corp;
        this.txtssgspk_bak.Value = model.pk_corp;
        if (model.PK_Corp_Info != null)
        {
            this.txtssgs.Text = model.PK_Corp_Info.Name;
        }
        this.PowerCompany1.SetChecked(model.CompanyPower);
        this.txtpowerbak.Value = this.PowerCompany1.GetPowerText();
        return model.PKPath;
    }

    public void Buttons(string ibtid)
    {
        string str = ibtid;
        if (str != null)
        {
            if (!(str == "ibtcontrol_ibtsave"))
            {
                if (((str == "ibtcontrol_ibtrefresh") || (str == "ibtcontrol_ibtset")) || (str != "ibtcontrol_ibtexit"))
                {
                }
            }
            else
            {
                this.UpdateBranch();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改部门信息";
        this.Master.TitlePic = "~/images/页标题/修改部门信息.jpg";
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (!this.Page.IsPostBack && (this.Session["User"] != null))
        {
            if (base.Request.QueryString["PK"] != null)
            {
                try
                {
                    try
                    {
                        string userName = ((UserModel)this.Session["User"]).UserName;
                        string power = ((UserModel)this.Session["User"]).Power;
                        ButtonsModel model = new ButtonsModel(userName);
                        if (PowerClass.IfHasPower(userName, power, PowerNum.BranchUpdate))
                        {
                            this.dbo = new DB_OPT();
                            this.dbo.Open();
                            this.PowerCompany1.BindTV(this.dbo);
                            this.BingData(base.Request.QueryString["PK"].ToString(), this.dbo);
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
                            model.IfExit = true;
                            this.Master.btModel = model;
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

    private void UpdateBranch()
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            if (((this.txtssgspk.Value.Trim() == "") || (this.txtName.Text.Trim() == "")) || (this.txtbmbh.Text.Trim() == ""))
            {
                Const.ShowMessage("带*号的数据必须填写！", this.Page);
            }
            else
            {
                string strEditMess = "";
                string powerText = this.PowerCompany1.GetPowerText();
                if (!PageDo.IsChanged(ref strEditMess, true, this.Page) && (this.txtpowerbak.Value == powerText))
                {
                    Const.ShowMessage("没有修改任何信息，请修改信息后再保存！", this.Page);
                }
                else
                {
                    if (this.txtpowerbak.Value != powerText)
                    {
                        string str3 = Public.DelRelTxt(this.txtpowerbak.Value, powerText, '|');
                        string str4 = Public.DelRelTxt(powerText, this.txtpowerbak.Value, '|');
                        string str5 = strEditMess;
                        strEditMess = str5 + "管理范围去掉了 " + str3 + " 增加了 " + str4;
                    }
                    BranchModel model = new BranchDal();
                    BranchModel model2 = new BranchDal();
                    model.FatherPK = this.txtsjbmpk.Value.Trim();
                    if (model.FatherPK != "")
                    {
                        model.BranchPK = model.FatherPK.Trim();
                        model = model.GetModel(false, false, false, false, this.dbo);
                        if (model.IsHasBaby == "0")
                        {
                            model2.BranchPK = model.BranchPK;
                            model2.UpdateHasBaby(this.dbo);
                        }
                        model2.PKPath = model.PKPath + model.BranchPK + "|";
                        if (this.txtishasbaby.Value == "1")
                        {
                            BranchBll.ChangeChildPkPath(base.Request.QueryString["PK"].ToString(), model2.PKPath + base.Request.QueryString["PK"].ToString() + "|", model.Grade + 2, this.dbo);
                        }
                        model2.Grade = model.Grade + 1;
                    }
                    else
                    {
                        model2.Grade = 0;
                    }
                    model2.FatherPK = this.txtsjbmpk.Value.Trim();
                    model2.IsHasBaby = this.txtishasbaby.Value.Trim();
                    string power = "";
                    power = this.PowerCompany1.GetPower();
                    model2.CompanyPower = power;
                    model2.BranchPK = base.Request.QueryString["PK"].ToString();
                    model2.Name = this.txtName.Text;
                    model2.BH = this.txtbmbh.Text;
                    model2.Address = this.txtaddress.Text.Trim();
                    model2.Manager = this.txtfzrpk.Value.Trim();
                    model2.Email = this.txtemail.Text.Trim();
                    model2.Phone = this.txtphone.Text.Trim();
                    model2.Fax = this.txtfax.Text.Trim();
                    model2.pk_corp = this.txtssgspk.Value.Trim();
                    Const.UpdateSuccess(model2.Update(this.dbo), this.Page);
                    strEditMess = "编号为：" + this.txtbmbh.Text.Trim() + " 名称为：" + this.txtName.Text.Trim() + " 的部门修改信息：" + strEditMess;
                    OperationLogBll.insertOp("修改", "部门列表", strEditMess, "Y", this.Page);
                }
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "UpdateBranch()";
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
