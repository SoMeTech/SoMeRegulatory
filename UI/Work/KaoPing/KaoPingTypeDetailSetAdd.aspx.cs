using ASP;
using ExceptionLog;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SMZJ.BLL;
using SMZJ.Model;

public class Work_KaoPing_KaoPingTypeDetailSetAdd : MainPageClass, IRequiresSessionState
{
    protected DropDownList ddlIsComfirm;
    protected DropDownList ddlKP_Year;
    private ExceptionLog.ExceptionLog el;
    private int KPTypeID;
    protected HtmlInputText txtKHType;
    protected TextBox txtKP_BiaoZhun;
    protected TextBox txtKPContent;
    protected TextBox txtOrderID;
    protected TextBox txtRemark;
    protected UpdatePanel UpdatePanel1;

    private void AddKHTypeDetail()
    {
        try
        {
            if (this.txtKPContent.Text.Trim() == "")
            {
                Const.ShowMessage("请输入考评内容！", this.Page);
            }
            if (this.txtKP_BiaoZhun.Text.Trim() == "")
            {
                Const.ShowMessage("请输入扣分标准！", this.Page);
            }
            else
            {
                PD_BASE_KAOPINGTYPEDETAIL_Model model = new PD_BASE_KAOPINGTYPEDETAIL_Model();
                PD_BASE_KAOPINGTYPEDETAIL_Bll bll = new PD_BASE_KAOPINGTYPEDETAIL_Bll();
                model.KP_CONTENT = this.txtKPContent.Text;
                model.KP_BIAOZHUN = this.txtKP_BiaoZhun.Text;
                model.KP_YEAR = this.ddlKP_Year.SelectedValue;
                model.KP_TYPEID = new int?(this.KPTypeID);
                model.ISCOMFIRM = this.ddlIsComfirm.SelectedValue.ToString();
                bll.Add(model);
                Const.DoSuccessOpen("", this.Page);
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "AddMenu()";
            this.el.WriteExceptionLog(true);
            Const.OpenErrorPage("操作失败，请联系管理员！", this.Page);
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
                this.AddKHTypeDetail();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.LBTitle = "新增考核明细";
        this.Master.TitlePic = "~/images/页标题/新增菜单副本.jpg";
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (!this.Page.IsPostBack)
        {
            if (this.Session["User"] != null)
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                ButtonsModel model = new ButtonsModel(userName)
                {
                    IfAdd = false,
                    IfUpdate = false,
                    IfSave = true,
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
                if (base.Request["TypeID"] != null)
                {
                    this.KPTypeID = Convert.ToInt32(base.Request["TypeID"].ToString());
                }
            }
            else
            {
                Const.GoLoginPath_Open(this.Page);
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
