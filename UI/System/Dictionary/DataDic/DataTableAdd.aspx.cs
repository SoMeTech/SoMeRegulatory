using ASP;
using ExceptionLog;
using SoMeTech.DataAccess;
using SoMeTech.Dictionary.DataDic.DataTable;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.WebControls;

public class SystemSetup_Dictionary_DataDic_DataTableAdd : MainPageClass, IRequiresSessionState
{
    private DB_OPT dbo;
    private ExceptionLog.ExceptionLog el;
    private DataTableModel model;
    private DataTableDal sd;
    protected TextBox txtRemark;
    protected TextBox txtYWName;
    protected TextBox txtZWName;

    public void addupdate()
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            if ((this.txtZWName.Text.Trim() == "") || (this.txtYWName.Text.Trim() == ""))
            {
                Const.ShowMessage("带*号的数据必须填写！", this.Page);
            }
            else
            {
                this.model = new DataTableModel();
                this.sd = new DataTableDal();
                this.model.TABLEREMARK = this.txtZWName.Text.Trim();
                this.model.TABLENAME = this.txtYWName.Text.Trim();
                this.model.REMARK = this.txtRemark.Text.Trim();
                int count = 0;
                if ((base.Request["PK"] != null) && (base.Request["PK"].ToString() != ""))
                {
                    this.model.PK = base.Request["PK"].ToString();
                    Const.UpdateSuccess(this.sd.Update(this.model, this.dbo), this.Page);
                }
                else
                {
                    count = this.sd.Add(this.model, this.dbo);
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
        if (base.IsPostBack)
        {
            return;
        }
        if (this.Session["user"] == null)
        {
            Const.GoLoginPath_OpenWindow(this.Page);
            return;
        }
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
            IfSave = true,
            IfExit = true
        };
        if ((base.Request["PK"] != null) && (base.Request["PK"] != ""))
        {
            try
            {
                try
                {
                    this.Master.LBTitle = "字典设置 - 修改数据字典——表信息";
                    this.Master.TitlePic = "~/images/页标题/修改税费项目.jpg";
                    this.dbo = new DB_OPT();
                    this.dbo.Open();
                    this.sd = new DataTableDal();
                    this.model = this.sd.GetModel(base.Request.QueryString["PK"].ToString(), this.dbo);
                    this.txtZWName.Text = this.model.TABLEREMARK.Trim();
                    this.txtYWName.Text = this.model.TABLENAME.Trim();
                    this.txtRemark.Text = this.model.REMARK.Trim();
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
                goto Label_025D;
            }
            finally
            {
                if (this.dbo != null)
                {
                    this.dbo.Close();
                }
            }
        }
        this.Master.LBTitle = "字典设置 - 新增数据字典——表信息";
        this.Master.TitlePic = "~/images/页标题/修改税费项目.jpg";
    Label_025D:
        this.Master.btModel = model;
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
