using ASP;
using ExceptionLog;
using SoMeTech.CommonDll;
using SoMeTech.DataAccess;
using SoMeTech.Dictionary.DataDic.DataTable;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using System;
using System.Runtime.InteropServices;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SMZJ.BLL;
using SMZJ.Model;
public class Work_FaGui_messbackoper : Page, IRequiresSessionState
{
    private DB_OPT dbo;
    protected HtmlTextArea areajianyi;
    protected HtmlTextArea areakn;
    protected HtmlTextArea areapz;
    protected HtmlTextArea areaxzyj;
    private MESS_BACK_Bll B_mesback = new MESS_BACK_Bll();
    protected DropDownList ddl_BASE_FKLX;
    protected DropDownList ddlPD_QUOTA_DEPART;
    protected DropDownList ddlPD_YEAR;
    private ExceptionLog.ExceptionLog el;
    protected HtmlInputHidden hgl;
    protected HtmlInputHidden hjj;
    protected Label lblAUTO_ID;
    protected HtmlGenericControl span_fkdx;
    protected HtmlGenericControl span_fklx;
    protected HtmlGenericControl span_wtjkn;
    protected HtmlGenericControl span_xmmc;
    protected HtmlGenericControl span_xmnd;
    protected HtmlInputHidden ssxxCode;
    protected TextBox Textdept;
    protected TextBox txtcompany;
    protected TextBox txtdate;
    protected TextBox txtman;
    protected HtmlInputHidden txtPD_PROJECT_CODE;
    protected HtmlInputText txtProjectName;
    protected TextBox txtshcompany;
    protected TextBox txtshdate;
    protected TextBox txtshdepart;
    protected TextBox txtshman;
    protected HtmlTextArea xcjyj;
    protected HtmlTextArea ywgsyj;

    public void addupdate()
    {
        MESS_BACK_Model model = new MESS_BACK_Model
        {
            MES_COMPANY = ((UserModel)this.Session["User"]).Company.pk_corp,
            MES_DATE = new DateTime?(DateTime.Now),
            MES_DEPT = ((UserModel)this.Session["User"]).Branch.BranchPK,
            MES_FLAG = "0",
            MES_ID = DateTime.Now.ToString("yyyyMMddhhmmss"),
            MES_JIANYI = this.areajianyi.Value,
            MES_KUNAN = this.areakn.Value,
            MES_MAN = ((UserModel)this.Session["User"]).UserName,
            MES_PZ = this.areapz.Value,
            MES_SHCOMPANY = "",
            MES_SHDATE = new DateTime?(DateTime.Now),
            MES_SHDEPT = "",
            MES_SHMAN = "",
            MES_TITLE = "",
            MES_XZYJ = this.areaxzyj.Value,
            MES_YWGSYJ = this.ywgsyj.Value,
            MES_XCJYJ = this.xcjyj.Value,
            PD_PROJECT_CODE = this.txtPD_PROJECT_CODE.Value,
            PD_QUOTA_DEPART = this.ddlPD_QUOTA_DEPART.SelectedValue,
            PD_YEAR = this.ddlPD_YEAR.SelectedValue,
            PD_NOW_SERVERPK = PublicDal.SetCreateServiceStream(this.Page),
            PD_BASE_FKLX = this.ddl_BASE_FKLX.SelectedValue
        };
        this.B_mesback.Add(model);
        Const.DoSuccessNoClose("新增完毕！点确定即将进入编辑页面。", "messbackoper.aspx?PK=" + base.Request["PK"] + "&reload=MainAddUpdate&strTitle=" + base.Server.UrlEncode(this.Master.strTitle.Trim()), this.Page);
    }

    public void Bind()
    {
        PublicDal.BindDropDownList(this.ddlPD_YEAR, "PD_BASE_YEAR", "YEAR_NAME", "YEAR_CODE", "");
        this.ddlPD_YEAR.SelectedValue = DateTime.Now.Year.ToString();
        string str = ((UserModel)this.Session["User"]).Company.pk_corp.Trim().Substring(0, 6);
        PublicDal.BindDropDownList(this.ddlPD_QUOTA_DEPART, "V_company_branch", "NAME", "BH", " comp_ishasbaby=1 and trim(pk_corp) like '" + str + "'");
        this.ddlPD_QUOTA_DEPART.SelectedValue = PublicDal.GetJGBM(str).Tables[0].Rows[0]["BH"].ToString();
        PublicDal.BindDropDownList(this.ddl_BASE_FKLX, "PD_BASE_FKLX", "FKLX_NAME", "PROJECTTYPE", "");
    }

    public void Buttons(string ibtid)
    {
        switch (ibtid)
        {
            case "ibtcontrol_ibtdo":
                this.shenhe();
                Const.AddSuccess(1, base.Request["reload"].ToString(), this.Page);
                return;

            case "ibtcontrol_ibtsave":
                if ((base.Request["PK"] == null) || !(base.Request["PK"] != ""))
                {
                    this.addupdate();
                    return;
                }
                this.updatedata(base.Request["PK"]);
                return;

            case "ibtcontrol_ibtprintnote":
                PageShowText.OpenPage(Public.RelativelyPath("Work/Back/messbackoperinput.aspx") + "?UpdatePK=" + base.Request["PK"].Trim(), null, null, this.Page, true);
                PageShowText.Refurbish("", this.Page);
                return;

            case "ibtcontrol_ibtaudit":
                this.SetServiceStream(1, base.Request.Params["PK"], "审核");
                return;

            case "ibtcontrol_ibtapply":
                this.SetServiceStream(1, base.Request.Params["PK"], "审批");
                return;

            case "ibtcontrol_ibtsetback":
                this.SetServiceStream(0, base.Request.Params["PK"], "弃审");
                return;

            case "ibtcontrol_ibtrollback":
                this.SetServiceStream(0, base.Request.Params["PK"], "弃审");
                return;
        }
    }

    public void ListPageLoad(Page page, out ButtonsModel main_bm, string MES_ID)
    {
        PublicDal.ShowMxButton(this.Page, out main_bm, "MESS_BACK", "MES_ID", MES_ID, "PD_NOW_SERVERPK");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (base.Request["strTitle"] != null)
        {
            this.Master.strTitle = base.Request["strTitle"];
        }
        if (!base.IsPostBack)
        {
            if (this.Session["user"] == null)
            {
                Const.GoLoginPath_OpenWindow(this.Page);
            }
            else
            {
                this.Bind();
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                ButtonsModel model = null;
                this.ListPageLoad(this.Page, out model, base.Request["PK"]);
                this.SetTxtEnabled();
                if ((base.Request["PK"] != null) && (base.Request["PK"] != ""))
                {
                    model.IfPrintNote = true;
                    model.IbtPrintNoteText = "打印";
                    try
                    {
                        MESS_BACK_Model model2 = new MESS_BACK_Model();
                        model2 = this.B_mesback.GetModel(base.Request["PK"]);
                        this.txtcompany.Text = model2.MES_COMPANY_NAME;
                        this.txtdate.Text = model2.MES_DATE.ToString();
                        this.Textdept.Text = model2.MES_DEPT;
                        this.areajianyi.Value = model2.MES_JIANYI;
                        this.areakn.Value = model2.MES_KUNAN;
                        this.txtman.Text = model2.MES_MAN;
                        this.areapz.Value = model2.MES_PZ;
                        this.txtshcompany.Text = model2.MES_SHCOMPANY;
                        this.txtshdate.Text = model2.MES_SHDATE.ToString();
                        this.txtshdepart.Text = model2.MES_SHDEPT;
                        this.txtshman.Text = model2.MES_SHMAN;
                        this.areaxzyj.Value = model2.MES_XZYJ;
                        this.txtPD_PROJECT_CODE.Value = model2.PD_PROJECT_CODE;
                        this.txtProjectName.Value = model2.PD_PROJECT_NAME;
                        this.ddlPD_QUOTA_DEPART.SelectedValue = model2.PD_QUOTA_DEPART;
                        this.ddlPD_YEAR.SelectedValue = model2.PD_YEAR;
                        this.ddl_BASE_FKLX.SelectedValue = model2.PD_BASE_FKLX;
                        this.ywgsyj.Value = model2.MES_YWGSYJ;
                        this.xcjyj.Value = model2.MES_XCJYJ;
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
                else
                {
                    this.txtcompany.Text = ((UserModel)this.Session["User"]).Company.Name;
                    this.txtdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    this.txtman.Text = ((UserModel)this.Session["User"]).UserName;
                    this.Textdept.Text = ((UserModel)this.Session["User"]).Branch.Name;
                }
                this.Master.LBTitle = "字典设置 - 新增数据字典——表信息";
                this.Master.TitlePic = "~/images/页标题/修改税费项目.jpg";
                this.Master.btModel = model;
            }
        }
    }

    public void SetServiceStream(int operation, string MES_ID, string Mess)
    {
        PublicDal.SetServiceStream(this.Page, operation, "MESS_BACK", "MES_ID", MES_ID, Mess, "PD_NOW_SERVERPK");
    }

    private void SetTxtEnabled()
    {
        string bH = ((UserModel)this.Session["User"]).Branch.BH;
        string s = PublicDal.PD_Coding_Level("2", bH);
        this.ssxxCode.Value = s;
        if (((s == null) || (int.Parse(s) == 11)) || (int.Parse(s) == 12))
        {
            this.ddl_BASE_FKLX.Enabled = false;
            this.ddlPD_YEAR.Enabled = false;
            this.txtProjectName.Attributes.Add("disabled", "disabled");
            this.txtProjectName.Attributes.Remove("onclick");
            this.ddlPD_QUOTA_DEPART.Enabled = false;
            this.areakn.Attributes.Add("disabled", "disabled");
            this.areajianyi.Attributes.Add("disabled", "disabled");
            this.txtdate.Enabled = false;
            this.areaxzyj.Attributes.Add("disabled", "disabled");
            this.areapz.Attributes.Add("disabled", "disabled");
            this.ywgsyj.Attributes.Add("disabled", "disabled");
            this.xcjyj.Attributes.Add("disabled", "disabled");
            this.span_fkdx.Visible = false;
            this.span_fklx.Visible = false;
            this.span_wtjkn.Visible = false;
            this.span_xmmc.Visible = false;
            this.span_xmnd.Visible = false;
        }
        else if (int.Parse(s) == 13)
        {
            this.ddl_BASE_FKLX.Enabled = false;
            this.ddlPD_YEAR.Enabled = false;
            this.txtProjectName.Attributes.Add("disabled", "disabled");
            this.txtProjectName.Attributes.Remove("onclick");
            this.ddlPD_QUOTA_DEPART.Enabled = false;
            this.areakn.Attributes.Add("disabled", "disabled");
            this.areajianyi.Attributes.Add("disabled", "disabled");
            this.txtdate.Enabled = false;
            this.areaxzyj.Attributes.Add("disabled", "disabled");
            this.areapz.Attributes.Add("disabled", "disabled");
            if (!PublicDal.IsJGBM(bH))
            {
                this.xcjyj.Attributes.Add("disabled", "disabled");
            }
            else
            {
                this.ywgsyj.Attributes.Add("disabled", "disabled");
            }
            this.span_fkdx.Visible = false;
            this.span_fklx.Visible = false;
            this.span_wtjkn.Visible = false;
            this.span_xmmc.Visible = false;
            this.span_xmnd.Visible = false;
        }
        else if (int.Parse(s) == 14)
        {
            this.ywgsyj.Attributes.Add("disabled", "disabled");
            this.xcjyj.Attributes.Add("disabled", "disabled");
        }
    }

    private void shenhe()
    {
        MESS_BACK_Model model = new MESS_BACK_Model();
        model = this.B_mesback.GetModel(base.Request["PK"]);
        MESS_BACK_Model model2 = new MESS_BACK_Model
        {
            MES_COMPANY = model.MES_COMPANY,
            MES_DATE = model.MES_DATE,
            MES_DEPT = model.MES_DEPT,
            MES_FLAG = "1",
            MES_ID = base.Request["PK"].ToString(),
            MES_JIANYI = this.areajianyi.Value,
            MES_KUNAN = this.areakn.Value,
            MES_MAN = model.MES_MAN,
            MES_PZ = this.areapz.Value,
            MES_SHCOMPANY = ((UserModel)this.Session["User"]).Company.pk_corp,
            MES_SHDATE = new DateTime?(DateTime.Now),
            MES_SHDEPT = ((UserModel)this.Session["User"]).Branch.BranchPK,
            MES_SHMAN = ((UserModel)this.Session["User"]).UserName,
            MES_TITLE = "",
            MES_XZYJ = this.areaxzyj.Value,
            MES_YWGSYJ = this.ywgsyj.Value,
            MES_XCJYJ = this.xcjyj.Value,
            PD_PROJECT_CODE = this.txtPD_PROJECT_CODE.Value,
            PD_QUOTA_DEPART = this.ddlPD_QUOTA_DEPART.SelectedValue,
            PD_YEAR = this.ddlPD_YEAR.SelectedValue
        };
        this.B_mesback.Update(model2);
        Const.AddSuccess(1, base.Request["reload"].ToString(), this.Page);
    }

    private void updatedata(string MES_ID)
    {
        MESS_BACK_Model model = this.B_mesback.GetModel(MES_ID);
        model.MES_JIANYI = this.areajianyi.Value;
        model.MES_KUNAN = this.areakn.Value;
        model.MES_PZ = this.areapz.Value;
        model.MES_XZYJ = this.areaxzyj.Value;
        model.PD_PROJECT_CODE = this.txtPD_PROJECT_CODE.Value;
        model.PD_QUOTA_DEPART = this.ddlPD_QUOTA_DEPART.SelectedValue;
        model.PD_YEAR = this.ddlPD_YEAR.SelectedValue;
        model.PD_BASE_FKLX = this.ddl_BASE_FKLX.SelectedValue;
        model.MES_YWGSYJ = this.ywgsyj.Value;
        model.MES_XCJYJ = this.xcjyj.Value;
        this.B_mesback.Update(model);
        Const.DoSuccessNoClose("修改完毕！点确定即将再次进入编辑页面。", "messbackoper.aspx?PK=" + base.Request["PK"] + "&reload=MainAddUpdate&strTitle=" + base.Server.UrlEncode(this.Master.strTitle.Trim()), this.Page);
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
