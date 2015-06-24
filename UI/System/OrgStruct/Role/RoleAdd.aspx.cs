using ASP;
using ExceptionLog;
using ExtExtenders;
using SoMeTech.Company.Role;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Role_RoleAdd : MainPageClass, IRequiresSessionState
{
    private DB_OPT dbo;
    protected DropDownList ddlsfqyqx;
    protected HtmlGenericControl divbh;
    private ExceptionLog.ExceptionLog el;
    protected WebControls_PowerMenu PowerMenu1;
    protected WebControls_PowerRow PowerRow1;
    protected WebControls_PowerServices PowerServices1;
    protected TabContainer TabContainer1;
    protected TabPanel TabPanel1;
    protected TabPanel TabPanel2;
    protected TextBox txtBranch;
    protected TextBox txtCompany;
    protected TextBox txtjsbh;
    protected TextBox txtName;
    protected HtmlInputHidden txtssbmpk;
    protected HtmlInputHidden txtssgspk;

    private void AddRole()
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
                RoleModel model = new RoleDal();
                if (model.Exists(this.txtjsbh.Text.Trim(), this.dbo) > 0)
                {
                    Const.ShowMessage("角色编号已经存在！", this.Page);
                }
                else
                {
                    string power = "";
                    power = this.PowerMenu1.GetPower();
                    model.Power = power;
                    power = "";
                    power = this.PowerServices1.GetPower();
                    model.ServicesPower = power;
                    power = "";
                    power = this.PowerRow1.GetPower();
                    model.DataPower = power;
                    model.BH = this.txtjsbh.Text.Trim();
                    model.Name = this.txtName.Text.Trim();
                    model.IsUserPower = this.ddlsfqyqx.SelectedValue.Trim();
                    model.BranchPK = this.txtssbmpk.Value.Trim();
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
                    OperationLogBll.insertOp("新增", "角色列表", "在 " + this.txtCompany.Text.Trim() + " 单位 " + this.txtBranch.Text.Trim() + " 部门下新增编号为：" + this.txtjsbh.Text.Trim() + " 名称为：" + this.txtName.Text.Trim() + " 的角色，菜单权限为：" + this.PowerMenu1.GetPowerText() + " 服务权限为：" + this.PowerServices1.GetPowerText(), "Y", this.Page);
                }
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "AddRole()";
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
                this.AddRole();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增角色";
        this.Master.TitlePic = "~/images/页标题/新增角色副本.jpg";
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (!this.Page.IsPostBack)
        {
            if (this.Session["User"] == null)
            {
                Const.GoLoginPath_Open(this.Page);
            }
            else
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
                ButtonsModel model = new ButtonsModel(userName);
                if (PowerClass.IfHasPower(userName, power, PowerNum.RoleAdd))
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
