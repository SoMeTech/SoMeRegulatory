using ASP;
using ExceptionLog;
using ExtExtenders;
using SoMeTech.Company.Branch;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Branch_BranchAdd : MainPageClass, IRequiresSessionState
{
    private DB_OPT dbo;
    protected HtmlGenericControl divbh;
    private ExceptionLog.ExceptionLog el;
    protected WebControls_PowerCompany PowerCompany1;
    protected TabContainer TabContainer1;
    protected TabPanel TabPanel1;
    protected TabPanel TabPanel2;
    protected TextBox txtaddress;
    protected TextBox txtbmbh;
    protected TextBox txtemail;
    protected TextBox txtfax;
    protected TextBox txtfzr;
    protected HtmlInputHidden txtfzrpk;
    protected TextBox txtName;
    protected TextBox txtphone;
    protected TextBox txtsjbm;
    protected HtmlInputHidden txtsjbmpk;
    protected TextBox txtssgs;
    protected HtmlInputHidden txtssgspk;

    private void AddBranch()
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
                BranchModel model = new BranchDal();
                if (model.Exists(this.txtbmbh.Text.Trim(), this.dbo) > 0)
                {
                    Const.ShowMessage("部门编码已经存在！", this.Page);
                }
                else
                {
                    BranchModel model2 = new BranchDal();
                    model.FatherPK = this.txtsjbmpk.Value.Trim();
                    if (model.FatherPK != "")
                    {
                        model.BranchPK = model.FatherPK;
                        model = model.GetModel(false, false, false, false, this.dbo);
                        if (model.IsHasBaby == "0")
                        {
                            model2.BranchPK = model.BranchPK;
                            model2.UpdateHasBaby(this.dbo);
                        }
                        model2.PKPath = model.PKPath + model.BranchPK + "|";
                        model2.Grade++;
                    }
                    else
                    {
                        model2.Grade = 0;
                    }
                    model2.FatherPK = this.txtsjbmpk.Value.Trim();
                    model2.IsHasBaby = "0";
                    string power = "";
                    power = this.PowerCompany1.GetPower();
                    model2.CompanyPower = power;
                    model2.Name = this.txtName.Text.Trim();
                    model2.BH = this.txtbmbh.Text.Trim();
                    model2.Address = this.txtaddress.Text.Trim();
                    model2.Manager = this.txtfzrpk.Value.Trim();
                    model2.Email = this.txtemail.Text.Trim();
                    model2.Phone = this.txtphone.Text.Trim();
                    model2.Fax = this.txtfax.Text.Trim();
                    model2.pk_corp = this.txtssgspk.Value.Trim();
                    int count = model2.Add(this.dbo);
                    if (base.Request["reload"] != null)
                    {
                        Const.AddSuccess(count, base.Request["reload"].ToString(), this.Page);
                    }
                    else
                    {
                        Const.AddSuccess(count, "", this.Page);
                    }
                    OperationLogBll.insertOp("新增", "部门列表", "在 " + this.txtssgs.Text.Trim() + " 单位下新增编号为：" + this.txtbmbh.Text.Trim() + " 名称为：" + this.txtName.Text.Trim() + " 的部门，管理范围为：" + this.PowerCompany1.GetPowerText(), "Y", this.Page);
                }
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "AddBranch()";
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
                this.AddBranch();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增部门";
        this.Master.TitlePic = "~/images/页标题/新增部门副本.jpg";
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
                        ButtonsModel model = new ButtonsModel(userName);
                        if (PowerClass.IfHasPower(userName, power, PowerNum.BranchAdd))
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
                            this.PowerCompany1.BindTV(this.dbo);
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
