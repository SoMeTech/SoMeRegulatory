using ASP;
using ExceptionLog;
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

public class Company_newBankInfo : Page, IRequiresSessionState
{
    private BankModel bmd;
    protected HtmlInputHidden CompanyPk;
    private DB_OPT dbo;
    private ExceptionLog.ExceptionLog el;
    protected TextBox txtBankName;
    protected TextBox txtBankNum;
    protected TextBox txtBankNumMan;
    protected TextBox txtCompany;
    protected TextBox txtDiscription;

    public void addUpdate()
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            if (((this.CompanyPk.Value.Trim() == "") || (this.txtBankName.Text.Trim() == "")) || (this.txtBankNum.Text.Trim() == ""))
            {
                Const.ShowMessage("带*的数据必须填写！", this.Page);
            }
            else
            {
                this.bmd = new BankDal();
                this.bmd.BankName = this.txtBankName.Text.Trim();
                this.bmd.BankNum = this.txtBankNum.Text.Trim();
                this.bmd.BankNumMan = this.txtBankNumMan.Text.Trim();
                this.bmd.Discription = this.txtDiscription.Text.Trim();
                this.bmd.pk_corp = this.CompanyPk.Value.Trim();
                if (base.Request["PK"] != null)
                {
                    this.bmd.BankPK = base.Request["PK"].ToString();
                    Const.UpdateSuccess(this.bmd.Update(this.dbo), this.Page);
                }
                else
                {
                    Const.AddSuccess(this.bmd.Add(this.dbo), this.Page);
                }
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "addUpdate()";
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
        switch (ibtid)
        {
            case "ibtcontrol_ibtadd":
            case "ibtcontrol_ibtupdate":
            case "ibtcontrol_ibtdelete":
            case "ibtcontrol_ibtlook":
            case "ibtcontrol_ibtsearch":
            case "ibtcontrol_ibtrefresh":
            case "ibtcontrol_ibthuizong":
            case "ibtcontrol_ibtputout":
            case "ibtcontrol_ibtset":
            case "ibtcontrol_ibtexit":
                break;

            case "ibtcontrol_ibtsave":
                this.addUpdate();
                break;

            default:
                return;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (!base.IsPostBack)
        {
            if (this.Session["user"] == null)
            {
                Const.GoLoginPath_OpenWindow(this.Page);
            }
            else
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                ButtonsModel model = new ButtonsModel(userName)
                {
                    IfAdd = false,
                    IfUpdate = false,
                    IfDelete = false,
                    IfLook = false,
                    IfSearch = false,
                    IfRefresh = true,
                    IfHuiZong = false,
                    IfPutOut = false,
                    IfSet = false,
                    IfExit = true
                };
                this.Master.btModel = model;
                if ((base.Request["PK"] != null) && (base.Request["PK"].ToString() != ""))
                {
                    if (PowerClass.IfHasPower(userName, power, PowerNum.BankCardUpdate))
                    {
                        model.IfSave = true;
                        this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改单位帐户信息";
                        this.Master.TitlePic = "修改单位帐户信息";
                        try
                        {
                            try
                            {
                                this.dbo = new DB_OPT();
                                this.dbo.Open();
                                this.bmd = new BankDal();
                                DataSet list = new DataSet();
                                list = this.bmd.GetList("BankPK='" + base.Request["PK"].ToString() + "'", this.dbo);
                                this.txtCompany.Text = list.Tables[0].Rows[0]["Name"].ToString();
                                this.CompanyPk.Value = list.Tables[0].Rows[0]["pk_corp"].ToString();
                                this.txtBankName.Text = list.Tables[0].Rows[0]["BankName"].ToString();
                                this.txtBankNum.Text = list.Tables[0].Rows[0]["BankNum"].ToString();
                                this.txtDiscription.Text = list.Tables[0].Rows[0]["Discription"].ToString();
                                this.txtBankNumMan.Text = list.Tables[0].Rows[0]["BankNumMan"].ToString();
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
                else if (PowerClass.IfHasPower(userName, power, PowerNum.BankCardAdd))
                {
                    model.IfSave = true;
                    this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增单位帐户信息";
                    this.Master.TitlePic = "新增单位帐户信息";
                }
                else
                {
                    Const.SorryForPower(this.Page);
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
