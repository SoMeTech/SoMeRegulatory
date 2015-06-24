using ASP;
using ExceptionLog;
using SoMeTech.CommonDll;
using SoMeTech.Data;
using SoMeTech.DataAccess;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Data;
using System.Data.OracleClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using YYControls;

public class Work_KaoPing_KaoPing : Page, IRequiresSessionState
{
    private int _selectIndex;
    private UserBll bll = new UserBll();
    protected Button btnClose;
    protected Button btnSave;
    public string count = "0";
    protected DropDownList ddlKHType;
    protected DropDownList ddlYear;
    private ExceptionLog.ExceptionLog el;
    protected GridView gvBiaoZhun;
    protected SmartGridView gvResult;
    protected HtmlInputHidden hAuto_ID;
    protected HtmlInputHidden hCompanyPK;
    protected HtmlInputHidden hKH_Type;
    public static string kpcompanyId = "";
    protected Label lbKHFZ;
    protected Label lblKH_Type;
    protected Label lblKP_Company;
    protected Label lblYear;
    protected Button lbtnOk;
    public int pageind = 1;
    private PageSizeBll pagesize = new PageSizeBll();
    protected HtmlInputHidden txtcor;
    protected HtmlInputHidden txtindex;
    protected HtmlInputHidden txtKP_Year;
    protected TextBox txtKPCompany;
    protected HtmlInputHidden txttitle;
    protected UpdatePanel UpdatePanel1;
    protected HtmlInputHidden username;

    protected void btnSave_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.gvBiaoZhun.Rows.Count; i++)
        {
            decimal num2;
            TextBox box = (TextBox)this.gvBiaoZhun.Rows[i].FindControl("txtKP_Score");
            Label label = (Label)this.gvBiaoZhun.Rows[i].FindControl("kpDetailID");
            if (string.IsNullOrEmpty(box.Text))
            {
                num2 = 0M;
            }
            else
            {
                num2 = Convert.ToDecimal(box.Text.ToString().Trim());
            }
            string str = this.ddlKHType.SelectedValue.ToString();
            string str2 = this.hCompanyPK.Value.ToString();
            if (string.IsNullOrEmpty(str2))
            {
                str2 = kpcompanyId.ToString();
            }
            string text = label.Text;
            int num3 = Convert.ToInt32(label.Text.ToString());
            int num4 = Convert.ToInt32(this.gvResult.SelectedDataKey[this._selectIndex].ToString());
            string str3 = this.ddlYear.SelectedValue.ToString();
            decimal num5 = num2;
            string str4 = "";
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":kp_typeid", num4), new OracleParameter(":kp_detailid", num3), new OracleParameter(":kp_year", str3), new OracleParameter(":kp_companypk", str2), new OracleParameter(":kh_type", str), new OracleParameter(":kp_score", num5), new OracleParameter(":kp_remark", str4) };
            DataSet set = DbHelperOra.Query(string.Concat(new object[] { "select  kp_score from pd_project_kaoping where kp_typeid=", num4, " and kp_detailid=", num3, " and kp_companypk='", str2, "'" }));
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                DbHelperOra.ExecuteSql(string.Concat(new object[] { "update pd_project_kaoping set kp_score=", num5, " where kp_typeid=", num4, " and kp_detailid=", num3, " and kp_companypk='", str2, "'" }));
            }
            else
            {
                string sQLString = "insert into pd_project_kaoping  (auto_id, kp_typeid, kp_detailid, kp_year, kp_companypk, kh_type, kp_score, kp_remark)  values (SQ_KAOPING_Project.Nextval, :kp_typeid, :kp_detailid, :kp_year, :kp_companypk, :kh_type, :kp_score, :kp_remark)";
                DbHelperOra.ExecuteSql(sQLString, cmdParms);
            }
        }
        Const.DoSuccessNoClose("保存成功", this.Page.Request.Url.LocalPath + "?strTitle=" + base.Request["strTitle"].ToString() + "&KPCompanyPK=" + this.hCompanyPK.Value.ToString() + "&KPCompanyName=" + this.txtKPCompany.Text + "&KHType=" + this.ddlKHType.SelectedValue, this.Page);
    }

    public void Buttons(string ibtid)
    {
        if ((ibtid == "ibtcontrol_ibtdo") || (ibtid == "ibtcontrol_ibtlook"))
        {
            int selectedIndex = this.gvResult.SelectedIndex;
            int num2 = 0;
            if ((selectedIndex != -1) && !string.IsNullOrEmpty(this.gvResult.DataKeys[selectedIndex].Value.ToString()))
            {
                num2 = Convert.ToInt32(this.gvResult.DataKeys[selectedIndex].Value.ToString());
            }
            if (this.txtKPCompany.Text == "")
            {
                PageShowText.ShowMessage_List("请选择考评单位！", this.Page);
                return;
            }
            if ((selectedIndex < 0) || (this.gvResult.Rows.Count < selectedIndex))
            {
                PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
                return;
            }
            string str = "1";
            string text = this.ddlYear.Text;
            string str2 = this.hCompanyPK.Value.ToString();
            if (string.IsNullOrEmpty(str2))
            {
                str2 = kpcompanyId.ToString();
            }
            string selectedValue = this.ddlKHType.SelectedValue;
            this._selectIndex = this.gvResult.SelectedIndex;
            new OracleParameter(":KP_COMPANYPK", str2);
            new OracleParameter(":KH_TYPE", selectedValue);
            new OracleParameter(":Auto_ID", str);
            DataSet set = null;
            string str4 = "select b.auto_id as kpDetailID,b.kp_year, b.kp_content, b.kp_typeid, b.kp_biaozhun, b.kp_basecode , a.auto_id,  a.kp_companypk, kh_type, a.kp_score, kp_remark ";
            object obj2 = str4;
            set = DbHelperOra.Query(string.Concat(new object[] { obj2, " from pd_base_kaopingtypedetail b left join pd_project_kaoping a on a.kp_detailid=b.auto_id and a.kp_companypk ='", str2, "'  where b.kp_typeid=", num2 }));
            this.gvBiaoZhun.DataSource = null;
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                this.lbKHFZ.Text = set.Tables[0].Rows[0]["KP_BASECODE"].ToString();
                this.gvBiaoZhun.DataSource = set.Tables[0];
                this.gvBiaoZhun.DataBind();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "alert('请您先添加该项的考核明细指标设置内容');window.location.reload()", true);
                return;
            }
            set = null;
            this.lblKP_Company.Text = this.txtKPCompany.Text;
            this.lblKH_Type.Text = this.ddlKHType.SelectedItem.Text;
            this.lblYear.Text = this.ddlYear.Text;
            string s = base.Request.Cookies["wid1"].Value;
            string str6 = base.Request.Cookies["hei"].Value;
            if (s == null)
            {
                s = "1000";
            }
            if (str6 == null)
            {
                s = "500";
            }
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", string.Concat(new object[] { "showPopup(", int.Parse(s) - 30, ",", int.Parse(str6) - 10, ")" }), true);
        }
        if (ibtid == "ibtcontrol_ibtlook")
        {
            this.btnSave.Visible = false;
        }
        if (ibtid == "ibtcontrol_ibtdo")
        {
            this.btnSave.Visible = true;
        }
    }

    public void lbtnOk_OnClick(object sender, EventArgs e)
    {
        if (this.txtKPCompany.Text == "")
        {
            PageShowText.ShowMessage_List("请选择考评单位！", this.Page);
        }
        else
        {
            this.ShowData("");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.strTitle = "";
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (!this.Page.IsPostBack)
        {
            int year = DateTime.Now.AddYears(-5).Year;
            for (int i = 0; i <= 10; i++)
            {
                ddlYear.Items.Add((year + i).ToString());
                
            }
            ddlYear.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;
            if (this.Session["user"] != null)
            {
                this.txtcor.Value = this.Session["pk_corp"].ToString();
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
                if ((base.Request["KPCompanyPK"] != null) && (base.Request["KPCompanyName"] != null))
                {
                    this.hCompanyPK.Value = base.Request["KPCompanyPK"].ToString();
                    kpcompanyId = base.Request["KPCompanyPK"].ToString();
                    this.txtKPCompany.Text = base.Request["KPCompanyName"].ToString();
                }
                else
                {
                    this.txtKPCompany.Text = this.Session["companyname"].ToString();
                    kpcompanyId = this.txtcor.Value;
                    this.hCompanyPK.Value = kpcompanyId;
                }
                if (base.Request["KHType"] != null)
                {
                    this.ddlKHType.SelectedValue = base.Request["KHType"].ToString();
                }
                if (((UserModel)HttpContext.Current.Session["User"]).TrueName == "")
                {
                    this.username.Value = ((UserModel)HttpContext.Current.Session["User"]).UserName;
                }
                else
                {
                    this.username.Value = ((UserModel)HttpContext.Current.Session["User"]).TrueName;
                }
                try
                {
                    ButtonsModel model = null;
                    PublicDal.ShowListButton(this.Page, out model, "");
                    model.IbtDoText = "评分";
                    this.ShowData("");
                    model.IfLook = true;
                    this.Master.btModel = model;
                }
                catch (Exception exception)
                {
                    this.el = new ExceptionLog.ExceptionLog();
                    this.el.ErrClassName = base.GetType().ToString();
                    this.el.ErrMessage = exception.Message.ToString();
                    this.el.ErrMethod = "bind()";
                    this.el.WriteExceptionLog(true);
                    Const.OpenErrorPage("获取数据失败，请联系管理员！", this.Page);
                }
            }
            else
            {
                Const.GoLoginPath_List(this.Page);
            }
        }
    }

    private void SaveDate()
    {
    }

    public void ShowData(string str)
    {
        try
        {
            string text = this.ddlYear.Text;
            string str3 = this.hCompanyPK.Value.ToString();
            if (string.IsNullOrEmpty(str3))
            {
                str3 = kpcompanyId.ToString();
            }
            string selectedValue = this.ddlKHType.SelectedValue;
            new OracleParameter(":KP_Year", text);
            new OracleParameter(":KP_COMPANYPK", str3);
            new OracleParameter(":KH_TYPE", selectedValue);
            DataSet set = DbHelperOra.Query("select m.Auto_Id,m.Khtypename,m.khtypeper,n.kp_score,n.score,n.kp_companypk from  pd_base_kaopingtype m left join ( select a.auto_id, a.khtypename, Max(a.khtypeper) as khtypeper, sum(b.kp_score) as kp_score,(max(a.khtypeper)-(sum(b.kp_score))) as score,max(b.kp_companypk)  as kp_companypk from pd_base_kaopingtype a left join pd_project_kaoping b on a.auto_id=b.kp_typeid  and b.kh_type=" + selectedValue + " where khyear=" + text + " and (b.kp_companypk='" + str3 + "' or b.kp_companypk is null) group by a.auto_id,a.khtypename ) n on m.auto_id = n.auto_id order by m.Auto_Id");
            if (set != null)
            {
                this.gvResult.DataSource = set.Tables[0];
                this.gvResult.DataBind();
                this.gvResult.SelectedIndex = -1;
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "ShowData()";
            this.el.WriteExceptionLog(true);
            Const.OpenErrorPage("获取数据失败，请联系系统管理员！", this.Page);
        }
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public KP_Master Master
    {
        get
        {
            return (KP_Master)base.Master;
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
