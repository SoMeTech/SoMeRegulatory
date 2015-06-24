using ASP;
using ExceptionLog;
using ExtExtenders;
using SoMeTech.Company.Role;
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

public class Role_RoleUpdate : MainPageClass, IRequiresSessionState
{
    private DB_OPT dbo;
    protected DropDownList ddlsfqyqx;
    private ExceptionLog.ExceptionLog el;
    protected Label labBranch;
    protected Label labCompany;
    protected Label labjsbh;
    protected Label labName;
    protected Label labsfqyqx;
    protected Label labssbmpk;
    protected Label labssgspk;
    protected WebControls_PowerMenu PowerMenu1;
    protected WebControls_PowerRow PowerRow1;
    protected WebControls_PowerServices PowerServices1;
    protected TabContainer TabContainer1;
    protected TabPanel TabPanel1;
    protected TabPanel TabPanel2;
    protected TextBox txtBranch;
    protected TextBox txtBranch_bak;
    protected TextBox txtCompany;
    protected TextBox txtCompany_bak;
    protected TextBox txtjsbh;
    protected TextBox txtjsbh_bak;
    protected HtmlInputHidden txtmenubak;
    protected TextBox txtName;
    protected TextBox txtName_bak;
    protected HtmlInputHidden txtrowbak;
    protected HtmlInputHidden txtserbak;
    protected HtmlInputHidden txtssbmpk;
    protected HtmlInputHidden txtssbmpk_bk;
    protected HtmlInputHidden txtssgspk;
    protected HtmlInputHidden txtssgspk_bak;

    private void BingData(string rolepk, DB_OPT dbo)
    {
        RoleModel model = new RoleDal
        {
            RolePK = rolepk
        };
        model = model.GetModel(false, false, dbo);
        this.txtjsbh.Text = model.BH;
        this.txtjsbh_bak.Text = model.BH;
        this.txtName.Text = model.Name;
        this.txtName_bak.Text = model.Name;
        this.ddlsfqyqx.SelectedValue = model.IsUserPower;
        this.txtssbmpk.Value = model.BranchPK;
        this.txtssbmpk_bk.Value = model.BranchPK;
        if (model.Branch != null)
        {
            this.txtBranch.Text = model.Branch.Name;
            this.txtBranch_bak.Text = model.Branch.Name;
        }
        this.txtssgspk.Value = model.pk_corp;
        this.txtssgspk_bak.Value = model.pk_corp;
        if (model.Company != null)
        {
            this.txtCompany.Text = model.Company.Name;
            this.txtCompany_bak.Text = model.Company.Name;
        }
        this.PowerMenu1.SetChecked(model.Power);
        this.PowerServices1.SetChecked(model.ServicesPower);
        this.PowerRow1.SetChecked(model.DataPower);
        this.txtmenubak.Value = this.PowerMenu1.GetPowerText();
        this.txtserbak.Value = this.PowerServices1.GetPowerText();
        this.txtrowbak.Value = this.PowerRow1.GetPowerText();
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
                this.UpdateRole();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改角色信息";
        this.Master.TitlePic = "~/images/页标题/修改角色副本.jpg";
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (!this.Page.IsPostBack && (base.Request.QueryString["PK"] != null))
        {
            if (this.Session["User"] == null)
            {
                Const.GoLoginPath_OpenWindow(this.Page);
            }
            string userName = ((UserModel)this.Session["User"]).UserName;
            string power = ((UserModel)this.Session["User"]).Power;
            string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
            ButtonsModel model = new ButtonsModel(userName);
            if (PowerClass.IfHasPower(userName, power, PowerNum.RoleUpdate))
            {
                model.IfUpdate = false;
                model.IfSave = true;
                model.IfAdd = false;
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
                try
                {
                    try
                    {
                        this.dbo = new DB_OPT();
                        this.dbo.Open();
                        this.PowerMenu1.BindTV(this.dbo);
                        this.PowerServices1.BindTV(this.dbo);
                        this.PowerRow1.BindTV(this.dbo);
                        this.BingData(base.Request.QueryString["PK"].ToString(), this.dbo);
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
            Const.SorryForPower(this.Page);
        }
    }

    private void UpdateRole()
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            if (((this.txtssgspk.Value.Trim() == "") || (this.txtName.Text.Trim() == "")) || (this.txtjsbh.Text.Trim() == ""))
            {
                Const.ShowMessage("带*的数据必须填写！", this.Page);
            }
            else
            {
                string strEditMess = "";
                string powerText = this.PowerMenu1.GetPowerText();
                string cz = this.PowerServices1.GetPowerText();
                string str4 = this.PowerRow1.GetPowerText();
                if ((!PageDo.IsChanged(ref strEditMess, true, this.Page) && (this.txtmenubak.Value == powerText)) && ((this.txtserbak.Value == cz) && (this.txtrowbak.Value == str4)))
                {
                    Const.ShowMessage("没有修改任何信息，请修改信息后再保存！", this.Page);
                }
                else
                {
                    if (this.txtmenubak.Value != powerText)
                    {
                        string str5 = Public.DelRelTxt(this.txtmenubak.Value, powerText, '|');
                        string str6 = Public.DelRelTxt(powerText, this.txtmenubak.Value, '|');
                        string str7 = strEditMess;
                        strEditMess = str7 + "菜单权限去掉了 " + str5 + " 增加了 " + str6;
                    }
                    if (this.txtserbak.Value != cz)
                    {
                        string str8 = Public.DelRelTxt(this.txtserbak.Value, cz, '|');
                        string str9 = Public.DelRelTxt(cz, this.txtserbak.Value, '|');
                        string str10 = strEditMess;
                        strEditMess = str10 + "业务权限去掉了 " + str8 + " 增加了 " + str9;
                    }
                    if (this.txtrowbak.Value != str4)
                    {
                        string str11 = Public.DelRelTxt(this.txtrowbak.Value, str4, '|');
                        string str12 = Public.DelRelTxt(str4, this.txtrowbak.Value, '|');
                        string str13 = strEditMess;
                        strEditMess = str13 + "数据行权限去掉了 " + str11 + " 增加了 " + str12;
                    }
                    RoleModel model = new RoleDal
                    {
                        RolePK = base.Request.QueryString["PK"].ToString().Trim()
                    };
                    string power = "";
                    power = this.PowerMenu1.GetPower();
                    model.Power = power;
                    power = "";
                    power = this.PowerServices1.GetPower();
                    model.ServicesPower = power;
                    power = "";
                    power = this.PowerRow1.GetPower();
                    model.DataPower = power;
                    model.Name = this.txtName.Text.Trim();
                    model.BH = this.txtjsbh.Text.Trim();
                    model.IsUserPower = this.ddlsfqyqx.SelectedValue.Trim();
                    model.BranchPK = this.txtssbmpk.Value.Trim();
                    model.pk_corp = this.txtssgspk.Value.Trim();
                    Const.UpdateSuccess(model.Update(this.dbo), this.Page);
                    strEditMess = "编号为：" + this.txtjsbh.Text.Trim() + " 名称为：" + this.txtName.Text.Trim() + " 的角色修改信息：" + strEditMess;
                    OperationLogBll.insertOp("修改", "角色列表", strEditMess, "Y", this.Page);
                }
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "UpdateRole()";
            this.el.WriteExceptionLog(true);
            Const.OpenErrorPage(" 操作失败，请联系管理员！", this.Page);
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
