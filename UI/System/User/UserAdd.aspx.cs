using ASP;
using ExceptionLog;
using ExtExtenders;
using SoMeTech.Company.Branch;
using SoMeTech.Company.Role;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.QxConst;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class User_UserAdd : MainPageClass, IRequiresSessionState
{
    private DB_OPT dbo;
    protected HtmlGenericControl divbh;
    private ExceptionLog.ExceptionLog el;
    protected WebControls_PowerCompany PowerCompany1;
    protected WebControls_PowerMenu PowerMenu1;
    protected WebControls_PowerRow PowerRow1;
    protected TabContainer TabContainer1;
    protected TabPanel TabPanel1;
    protected TabPanel TabPanel2;
    protected TextBox txtpass;
    protected TextBox txtPwd;
    protected TextBox txtssbm;
    protected HtmlInputHidden txtssbmpk;
    protected TextBox txtssgs;
    protected HtmlInputHidden txtssgspk;
    protected TextBox txtssjs;
    protected HtmlInputHidden txtssjspk;
    protected TextBox txtTrueName;
    protected TextBox txtUserName;

    private void AddUser()
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
                UserModel model = new UserDal
                {
                    UserName = this.txtUserName.Text.Trim(),
                    TrueName = this.txtTrueName.Text.Trim()
                };
                if (model.ExistsByUserName(this.dbo) > 0)
                {
                    Const.ShowMessage("用户名已经存在！", this.Page);
                }
                else
                {
                    RoleModel model2 = new RoleDal
                    {
                        RolePK = this.txtssjspk.Value.Trim()
                    };
                    model2 = model2.GetModel(false, false, this.dbo);
                    BranchModel model3 = new BranchDal
                    {
                        BranchPK = this.txtssbmpk.Value.Trim()
                    };
                    model3 = model3.GetModel(false, false, false, false, this.dbo);
                    string str = PowerClass.SubTwoPower(this.PowerMenu1.GetPower(), model2.Power, "|");
                    model.Power = str;
                    string str2 = PowerClass.SubTwoPower(this.PowerCompany1.GetPower(), model3.CompanyPower, "|");
                    model.CompanyPower = str2;
                    model.BranchPK = this.txtssbmpk.Value.Trim();
                    model.RolePK = this.txtssjspk.Value.Trim();
                    if (this.txtPwd.Text.Trim() == "")
                    {
                        model.Password = QxRoom.QxConst.QxConst.Encrypt("123456", "powerich").Trim();
                    }
                    else
                    {
                        model.Password = QxRoom.QxConst.QxConst.Encrypt(this.txtPwd.Text.Trim(), "powerich").Trim();
                    }
                    model.pk_corp = this.txtssgspk.Value.Trim();
                    int count = 0;
                    count = model.Add(this.dbo);
                    if (base.Request["reload"] != null)
                    {
                        Const.AddSuccess(count, base.Request["reload"].ToString(), this.Page);
                    }
                    else
                    {
                        Const.AddSuccess(count, "", this.Page);
                    }
                    OperationLogBll.insertOp("新增", "用户列表", "在 " + this.txtssgs.Text.Trim() + " 单位 " + this.txtssbm.Text.Trim() + " 部门下新增用户名为：" + this.txtUserName.Text.Trim() + " 真实姓名为：" + this.txtTrueName.Text.Trim() + " 角色为：" + this.txtssjs.Text.Trim() + " 的用户，菜单权限为：" + this.PowerMenu1.GetPowerText() + " 管理范围为：" + this.PowerCompany1.GetPowerText(), "Y", this.Page);
                }
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "AddUser()";
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
                this.AddUser();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增用户信息";
        this.Master.TitlePic = "~/images/页标题/新增用户副本.jpg";
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (!this.Page.IsPostBack)
        {
            try
            {
                this.dbo = new DB_OPT();
                this.dbo.Open();
                if (this.Session["User"] == null)
                {
                    Const.GoLoginPath_OpenWindow(this.Page);
                }
                else
                {
                    string userName = ((UserModel)this.Session["User"]).UserName;
                    string power = ((UserModel)this.Session["User"]).Power;
                    string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
                    ButtonsModel model = new ButtonsModel(userName);
                    if (PowerClass.IfHasPower(userName, power, PowerNum.UserAdd))
                    {
                        this.PowerCompany1.BindTV(this.dbo);
                        this.PowerMenu1.BindTV(this.dbo);
                        this.PowerRow1.BindTV(this.dbo);
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
