using ASP;
using ExceptionLog;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMZJ.BLL;
using SMZJ.Model;

public class Work_KaoPing_KaoPingTypeSetAdd : MainPageClass, IRequiresSessionState
{
    protected DropDownList ddlIsComfirm;
    protected DropDownList ddlKH_Year;
    private ExceptionLog.ExceptionLog el;
    protected TextBox txtKHTypeName;
    protected TextBox txtKHTypePer;
    protected TextBox txtOrderID;
    protected TextBox txtRemark;
    protected UpdatePanel UpdatePanel1;

    private void AddKHType()
    {
        try
        {
            if (this.txtKHTypeName.Text.Trim() == "")
            {
                Const.ShowMessage("请输入考核内容！", this.Page);
            }
            if (this.txtKHTypePer.Text.Trim() == "")
            {
                Const.ShowMessage("请输入考核项目分值！", this.Page);
            }
            else
            {
                PD_BASE_KAOPINGTYPE_Model model = new PD_BASE_KAOPINGTYPE_Model();
                PD_BASE_KAOPINGTYPE_Bll bll = new PD_BASE_KAOPINGTYPE_Bll();
                model.KHTYPENAME = this.txtKHTypeName.Text.Trim();
                model.KHTYPEPER = new int?(Convert.ToInt32(this.txtKHTypePer.Text.Trim()));
                model.KHYEAR = this.ddlKH_Year.SelectedValue.ToString();
                if (string.IsNullOrEmpty(this.txtOrderID.Text.Trim()))
                {
                    model.ORDERID = 0;
                }
                else
                {
                    model.ORDERID = new int?(Convert.ToInt32(this.txtOrderID.Text.Trim()));
                }
                model.REMARK = this.txtRemark.Text.Trim();
                model.ISCOMFIRM = this.ddlIsComfirm.SelectedValue;
                bll.Add(model);
                Const.DoSuccessClose("添加成功", this.Page);
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
                    this.AddKHType();
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
        this.txtKHTypePer.Attributes.Add("onkeypress", "javascript:return onlyNum();");
        this.Master.LBTitle = "新增考核大类";
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
            }
            else
            {
                Const.GoLoginPath_Open(this.Page);
            }
        }
    }

    private void SetMenuDefault()
    {
    }

    private void ShowInfo(string pk)
    {
        PD_BASE_KAOPINGTYPE_Model model = new PD_BASE_KAOPINGTYPE_Model();
        model = new PD_BASE_KAOPINGTYPE_Bll().GetModel(Convert.ToInt32(pk));
        this.txtKHTypeName.Text = model.KHTYPENAME;
        this.txtKHTypePer.Text = model.KHTYPEPER.ToString();
        this.txtOrderID.Text = model.ORDERID.ToString();
        this.txtRemark.Text = model.REMARK;
        this.ddlIsComfirm.SelectedValue = model.ISCOMFIRM;
        this.ddlKH_Year.SelectedValue = model.KHYEAR;
    }

    private void UpdateKHType()
    {
        PD_BASE_KAOPINGTYPE_Model model = new PD_BASE_KAOPINGTYPE_Model();
        PD_BASE_KAOPINGTYPE_Bll bll = new PD_BASE_KAOPINGTYPE_Bll();
        if (base.Request["PK"] != null)
        {
            model.AUTO_ID = new int?(Convert.ToInt32(base.Request["PK"].ToString()));
        }
        model.KHTYPENAME = this.txtKHTypeName.Text.Trim();
        model.KHTYPEPER = new int?(Convert.ToInt32(this.txtKHTypePer.Text.Trim()));
        model.KHYEAR = this.ddlKH_Year.SelectedValue.ToString();
        if (string.IsNullOrEmpty(this.txtOrderID.Text.Trim()))
        {
            model.ORDERID = 0;
        }
        else
        {
            model.ORDERID = new int?(Convert.ToInt32(this.txtOrderID.Text.Trim()));
        }
        model.REMARK = this.txtRemark.Text.Trim();
        model.ISCOMFIRM = this.ddlIsComfirm.SelectedValue;
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
