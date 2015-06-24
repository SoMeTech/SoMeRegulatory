using ASP;
using ExceptionLog;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.OperationLog;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public class GlobalSet_Operation_OperationLogLook : Page, IRequiresSessionState
{
    protected TextBox txtnr;
    protected TextBox txttime;
    protected TextBox txttype;
    protected TextBox txtuser;
    protected TextBox txtyw;
    protected UpdatePanel UpdatePanel1;

    public void Buttons(string ibtid)
    {
        string str;
        if (((str = ibtid) != null) && (str == "ibtcontrol_ibtexit"))
        {
            Const.PageClose("", this.Page);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.LBTitle = "乡镇财政资金监管信息系统 - 查看操作日志";
        this.Master.strTitle = "查看操作日志";
        this.Master.TitlePic = "~/images/页标题/查看操作日志.jpg";
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (!this.Page.IsPostBack)
        {
            if (this.Session["User"] != null)
            {
                if (base.Request.QueryString["PK"] == null)
                {
                    return;
                }
                DB_OPT dbo = null;
                try
                {
                    try
                    {
                        string userName = ((UserModel)this.Session["User"]).UserName;
                        string power = ((UserModel)this.Session["User"]).Power;
                        ButtonsModel model = new ButtonsModel(userName);
                        if (PowerClass.IfHasPower(userName, power, PowerNum.ServicesMessUpdate))
                        {
                            model.IfRefresh = true;
                            model.IfExit = true;
                            this.Master.btModel = model;
                            dbo = new DB_OPT();
                            dbo.Open();
                            this.SetValue(dbo);
                        }
                        else
                        {
                            Const.SorryForPower(this.Page);
                        }
                    }
                    catch (Exception exception)
                    {
                        new ExceptionLog.ExceptionLog { ErrClassName = base.GetType().ToString(), ErrMessage = exception.Message.ToString(), ErrMethod = "Page_Load()" }.WriteExceptionLog(true);
                        Const.OpenErrorPage("获取数据失败，请联系管理员！", this.Page);
                    }
                    return;
                }
                finally
                {
                    dbo.Close();
                }
            }
            Const.GoLoginPath_Open(this.Page);
        }
    }

    private void SetValue(DB_OPT dbo)
    {
        OperationLogModel model = new OperationLogDal
        {
            pk = base.Request.QueryString["PK"].ToString()
        };
        model = model.GetModel(dbo);
        this.txtuser.Text = model.UserName;
        this.txttype.Text = model.opType;
        this.txtyw.Text = model.Business;
        this.txttime.Text = model.opTime.ToString();
        this.txtnr.Text = model.Content;
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
