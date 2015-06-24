using ASP;
using ExceptionLog;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.ServicesClass.Operation;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public class SystemSetup_Dictionary_NewBusinessMess : Page, IRequiresSessionState
{
    private BusinessMessModel bmm;
    private DB_OPT dbo;
    private ExceptionLog.ExceptionLog el;
    protected TextBox txtName;
    protected TextBox txtRemark;

    public void addupdate()
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            if (this.txtName.Text.Trim() == "")
            {
                Const.ShowMessage("带*号的数据必须填写！", this.Page);
            }
            else
            {
                this.bmm = new BusinessMessDal();
                this.bmm.Name = this.txtName.Text.Trim();
                this.bmm.Remark = this.txtRemark.Text.Trim();
                this.bmm.Remark = "";
                int count = 0;
                if ((base.Request["PK"] != null) && (base.Request["PK"].ToString().Trim() != ""))
                {
                    this.bmm.PK = base.Request["PK"].ToString();
                    Const.UpdateSuccess(this.bmm.Update(this.dbo), this.Page);
                }
                else
                {
                    count = this.bmm.Add(this.dbo);
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
            this.el.ErrMethod = "addupdate()";
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
                break;

            case "ibtcontrol_ibtsave":
                this.addupdate();
                return;

            case "ibtcontrol_ibtexit":
                Const.PageClose_OpenWindow("", this.Page);
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
                    if (PowerClass.IfHasPower(userName, power, PowerNum.BusinessMessUpdate))
                    {
                        try
                        {
                            try
                            {
                                this.Master.LBTitle = "字典设置 - 修改业务环节信息";
                                this.Master.TitlePic = "~/images/页标题/修改系统业务.jpg";
                                model.IfSave = true;
                                this.dbo = new DB_OPT();
                                this.dbo.Open();
                                this.bmm = new BusinessMessDal();
                                this.bmm.PK = base.Request["PK"].ToString().Trim();
                                this.bmm = this.bmm.GetModel(this.dbo);
                                this.txtName.Text = this.bmm.Name;
                                this.txtRemark.Text = this.bmm.Remark;
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
                else if (PowerClass.IfHasPower(userName, power, PowerNum.BusinessMessAdd))
                {
                    model.IfSave = true;
                    this.Master.LBTitle = "字典设置 - 新增业务环节信息";
                    this.Master.TitlePic = "~/images/页标题/新增系统业务.jpg";
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
