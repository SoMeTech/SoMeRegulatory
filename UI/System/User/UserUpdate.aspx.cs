using ASP;
using ExceptionLog;
using ExtExtenders;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using QxRoom.Common.ControlDo;
using QxRoom.QxConst;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class User_UserUpdate : MainPageClass, IRequiresSessionState
{
    private DB_OPT dbo;
    protected HtmlGenericControl divbh;
    private ExceptionLog.ExceptionLog el;
    protected Label labcompower;
    protected Label Label6;
    protected Label labPwd;
    protected Label labrolepower;
    protected Label labserpower;
    protected Label labssbm;
    protected Label labssbmpk;
    protected Label labssgs;
    protected Label labssgspk;
    protected Label labssjs;
    protected Label labssjspk;
    protected Label labTrueName;
    protected Label labUserName;
    protected WebControls_PowerCompany PowerCompany1;
    protected WebControls_PowerMenu PowerMenu1;
    protected WebControls_PowerRow PowerRow1;
    protected TabContainer TabContainer1;
    protected TabPanel TabPanel1;
    protected TabPanel TabPanel2;
    protected HtmlInputHidden txtcombak;
    protected HtmlInputHidden txtcompower;
    protected HtmlInputHidden txtcompower_bak;
    protected HtmlInputHidden txtmenubak;
    protected TextBox txtpass;
    protected TextBox txtPwd;
    protected TextBox txtPwd_bak;
    protected HtmlInputHidden txtrolepower;
    protected HtmlInputHidden txtrolepower_bak;
    protected HtmlInputHidden txtrowbak;
    protected HtmlInputHidden txtserpower;
    protected HtmlInputHidden txtserpower_bak;
    protected TextBox txtssbm;
    protected TextBox txtssbm_bak;
    protected HtmlInputHidden txtssbmpk;
    protected HtmlInputHidden txtssbmpk_bak;
    protected TextBox txtssgs;
    protected TextBox txtssgs_bak;
    protected HtmlInputHidden txtssgspk;
    protected HtmlInputHidden txtssgspk_bak;
    protected TextBox txtssjs;
    protected TextBox txtssjs_bak;
    protected HtmlInputHidden txtssjspk;
    protected HtmlInputHidden txtssjspk_bak;
    protected TextBox txtTrueName;
    protected TextBox txtTrueName_bak;
    protected TextBox txtUserName;
    protected TextBox txtUserName_bak;

    private string BingData(string userpk, DB_OPT dbo)
    {
        UserModel model = new UserDal
        {
            UserPK = userpk
        };
        model.GetModel(dbo);
        this.txtUserName.Text = model.UserName;
        this.txtUserName_bak.Text = model.UserName;
        this.txtTrueName.Text = model.TrueName;
        this.txtTrueName_bak.Text = model.TrueName;
        if (model.Password != "")
        {
            this.txtpass.Text = QxRoom.QxConst.QxConst.Decrypt(model.Password, "powerich");
            this.txtPwd.Text = QxRoom.QxConst.QxConst.Decrypt(model.Password, "powerich");
            this.txtPwd_bak.Text = QxRoom.QxConst.QxConst.Decrypt(model.Password, "powerich");
        }
        if ((model.Branch != null) && (model.Branch.CompanyPower != null))
        {
            this.txtcompower.Value = model.Branch.CompanyPower;
            this.txtcompower_bak.Value = model.Branch.CompanyPower;
        }
        if (model.Role != null)
        {
            this.txtrolepower.Value = model.Role.Power;
            this.txtrolepower_bak.Value = model.Role.Power;
            this.txtserpower.Value = model.Role.ServicesPower;
            this.txtserpower_bak.Value = model.Role.ServicesPower;
        }
        this.txtssgspk.Value = model.pk_corp.Trim();
        this.txtssgspk_bak.Value = model.pk_corp.Trim();
        this.txtssgs.Text = model.cName.Trim();
        this.txtssgs_bak.Text = model.cName.Trim();
        this.txtssbmpk.Value = model.BranchPK.Trim();
        this.txtssbmpk_bak.Value = model.BranchPK.Trim();
        this.txtssbm.Text = model.bName.Trim();
        this.txtssbm_bak.Text = model.bName.Trim();
        this.txtssjspk.Value = model.RolePK.Trim();
        this.txtssjspk_bak.Value = model.RolePK.Trim();
        this.txtssjs.Text = model.rName.Trim();
        this.txtssjs_bak.Text = model.rName.Trim();
        this.PowerCompany1.SetChecked(model.CompanyPower);
        this.PowerMenu1.SetChecked(model.Power);
        this.txtcombak.Value = this.PowerCompany1.GetPowerText();
        this.txtmenubak.Value = this.PowerMenu1.GetPowerText();
        return "";
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
                this.UpdateUser();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改用户信息";
        this.Master.TitlePic = "~/images/页标题/修改用户副本.jpg";
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (!this.Page.IsPostBack && (base.Request.QueryString["PK"] != null))
        {
            try
            {
                if (this.Session["User"] == null)
                {
                    Const.GoLoginPath_Open(this.Page);
                }
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
                ButtonsModel model = new ButtonsModel(userName);
                if (PowerClass.IfHasPower(userName, power, PowerNum.UserUpdate))
                {
                    this.dbo = new DB_OPT();
                    this.dbo.Open();
                    this.PowerCompany1.BindTV(this.dbo);
                    this.PowerMenu1.BindTV(this.dbo);
                    this.PowerRow1.BindTV(this.dbo);
                    this.BingData(base.Request.QueryString["PK"].ToString(), this.dbo);
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
            finally
            {
                if (this.dbo != null)
                {
                    this.dbo.Close();
                }
            }
        }
    }

    private void UpdateUser()
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            if (((this.txtUserName.Text.Trim() == "") || (this.txtssbmpk.Value.Trim() == "")) || ((this.txtssgspk.Value.Trim() == "") || (this.txtssjspk.Value.Trim() == "")))
            {
                Const.ShowMessage("带*的数据必须填写！", this.Page);
            }
            else
            {
                string strEditMess = "";
                string powerText = this.PowerMenu1.GetPowerText();
                string cz = this.PowerCompany1.GetPowerText();
                string str4 = this.PowerRow1.GetPowerText();
                if ((!PageDo.IsChanged(ref strEditMess, true, this.Page) && (this.txtmenubak.Value == powerText)) && ((this.txtcombak.Value == cz) && (this.txtrowbak.Value == str4)))
                {
                    Const.ShowMessage("没有修改任何信息，请修改信息后再保存！", this.Page);
                }
                else
                {
                    if (this.txtmenubak.Value != powerText)
                    {
                        string str5 = PowerClass.SubTwoPower(this.txtmenubak.Value, powerText, "|");
                        string str6 = PowerClass.SubTwoPower(powerText, this.txtmenubak.Value, "|");
                        string str7 = strEditMess;
                        strEditMess = str7 + "菜单权限去掉了 " + str5 + " 增加了 " + str6;
                    }
                    if (this.txtcombak.Value != cz)
                    {
                        string str8 = Public.DelRelTxt(this.txtcombak.Value, cz, '|');
                        string str9 = Public.DelRelTxt(cz, this.txtcombak.Value, '|');
                        string str10 = strEditMess;
                        strEditMess = str10 + "管理范围去掉了 " + str8 + " 增加了 " + str9;
                    }
                    if (this.txtrowbak.Value != str4)
                    {
                        string str11 = Public.DelRelTxt(this.txtrowbak.Value, str4, '|');
                        string str12 = Public.DelRelTxt(str4, this.txtrowbak.Value, '|');
                        string str13 = strEditMess;
                        strEditMess = str13 + "数据行权限去掉了 " + str11 + " 增加了 " + str12;
                    }
                    UserModel model = new UserDal
                    {
                        UserPK = base.Request.QueryString["PK"].ToString().Trim()
                    };
                    model.GetModel(this.dbo);
                    string str14 = PowerClass.SubTwoPower(this.PowerMenu1.GetPower(), this.txtrolepower.Value, "|");
                    model.Power = str14;
                    string str15 = PowerClass.SubTwoPower(this.PowerCompany1.GetPower(), this.txtcompower.Value, "|");
                    model.CompanyPower = str15;
                    model.UserName = this.txtUserName.Text.Trim();
                    model.TrueName = this.txtTrueName.Text.Trim();
                    model.BranchPK = this.txtssbmpk.Value.Trim();
                    model.RolePK = this.txtssjspk.Value.Trim();
                    if (this.txtPwd.Text.Trim() != "")
                    {
                        model.Password = QxRoom.QxConst.QxConst.Encrypt(this.txtPwd.Text.Trim(), "powerich").Trim();
                    }
                    model.pk_corp = this.txtssgspk.Value.Trim();
                    Const.UpdateSuccess(model.Update(UserUpdatePowerType.All, UserUpdateIndex.AllowUserPK, this.dbo), this.Page);
                    strEditMess = "用户名为：" + this.txtUserName.Text.Trim() + " 真实姓名为：" + this.txtTrueName.Text.Trim() + " 的用户修改信息：" + strEditMess;
                    OperationLogBll.insertOp("修改", "用户列表", strEditMess, "Y", this.Page);
                }
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "UpdateUser()";
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
