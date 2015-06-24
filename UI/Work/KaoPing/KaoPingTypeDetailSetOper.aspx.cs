using ASP;
using ExceptionLog;
using SoMeTech.Data;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SMZJ.BLL;
using SMZJ.Model;

public class Work_KaoPing_KaoPingTypeDetailSetOper : MainPageClass, IRequiresSessionState
{
    protected DropDownList ddlIsComfirm;
    protected DropDownList ddlKP_Year;
    private ExceptionLog.ExceptionLog el;
    protected HtmlInputText txtKHType;
    protected HtmlInputText txtKHTypeID;
    protected TextBox txtKP_BiaoZhun;
    protected TextBox txtKPContent;
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
                model.KP_TYPEID = new int?(int.Parse(this.txtKHTypeID.Value));
                DataSet set = DbHelperOra.Query("select khtypeper from PD_BASE_KAOPINGTYPE where auto_id=" + model.KP_TYPEID);
                if (set != null)
                {
                    model.KP_BASECODE = new int?(Convert.ToInt32(set.Tables[0].Rows[0][0].ToString()));
                }
                else
                {
                    model.KP_BASECODE = 0;
                }
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
        switch (ibtid)
        {
            case "ibtcontrol_ibtlook":
            case "ibtcontrol_ibtsearch":
            case "ibtcontrol_ibthuizong":
            case "ibtcontrol_ibtputout":
            case "ibtcontrol_ibtset":
            case "ibtcontrol_ibtsave":
                if (base.Request["PK"] == null)
                {
                    this.AddKHTypeDetail();
                    return;
                }
                this.UpdateKHType();
                return;

            case "ibtcontrol_ibtexit":
            case "ibtcontrol_ibtrefresh":
                return;
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
                if (base.Request["PK"] != null)
                {
                    this.ShowInfo(base.Request["PK"].ToString());
                }
                if (base.Request["DetailTypeID"] != null)
                {
                    Convert.ToInt32(base.Request["DetailTypeID"].ToString());
                }
            }
            else
            {
                Const.GoLoginPath_Open(this.Page);
            }
        }
    }

    private void ShowInfo(string pk)
    {
        PD_BASE_KAOPINGTYPEDETAIL_Model model = new PD_BASE_KAOPINGTYPEDETAIL_Model();
        model = new PD_BASE_KAOPINGTYPEDETAIL_Bll().GetModel(Convert.ToInt32(pk));
        this.txtKPContent.Text = model.KP_CONTENT;
        this.txtKP_BiaoZhun.Text = model.KP_BIAOZHUN;
        this.ddlKP_Year.SelectedValue = model.KP_YEAR;
        this.ddlIsComfirm.SelectedValue = model.ISCOMFIRM.ToString();
        this.txtKHTypeID.Value = model.KP_TYPEID.ToString();
        this.txtKHType.Value = model.typename.ToString();
    }

    private void UpdateKHType()
    {
        PD_BASE_KAOPINGTYPEDETAIL_Model model = new PD_BASE_KAOPINGTYPEDETAIL_Model();
        PD_BASE_KAOPINGTYPEDETAIL_Bll bll = new PD_BASE_KAOPINGTYPEDETAIL_Bll();
        if (base.Request["PK"] != null)
        {
            model.AUTO_ID = new int?(Convert.ToInt32(base.Request["PK"].ToString()));
        }
        model.KP_CONTENT = this.txtKPContent.Text;
        model.KP_BIAOZHUN = this.txtKP_BiaoZhun.Text;
        model.KP_YEAR = this.ddlKP_Year.SelectedValue;
        model.KP_TYPEID = new int?(int.Parse(this.txtKHTypeID.Value));
        model.ISCOMFIRM = this.ddlIsComfirm.SelectedValue.ToString();
        if (bll.Update(model))
        {
            Const.DoSuccessClose("修改成功", this.Page);
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
