using ASP;
using ExceptionLog;
using ExtExtenders;
using SoMeTech.CommonDll;
using SoMeTech.Data;
using SoMeTech.DataAccess;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using System;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using YYControls;
using SMZJ.BLL;
using SMZJ.Model;

public class Work_projectGL_HeTong_HeTongMx : Page, IRequiresSessionState
{
    public static string auto_nos = "0";
    public string count = "0";
    private DB_OPT dbo;
    protected DropDownList ddlPD_YEAR;
    public static string delauto_nos = "0";
    protected HtmlGenericControl div_ht_change;
    public static DataTable dtgvr = null;
    private ExceptionLog.ExceptionLog el;
    protected UserControls_FilePostCtr FilePostCtr1;
    protected UserControls_FilePostCtr FilePostCtr2;
    protected SmartGridView gvResult;
    protected HtmlInputHidden json_btData;
    protected HtmlInputHidden json_btData2;
    protected Label lblAUTO_NO;
    public int lgnum;
    public int pageind = 1;
    private PageSizeBll pagesize = new PageSizeBll();
    protected TabPanel Panel_xmgk;
    protected TabContainer TabContainer1;
    protected HtmlTable Table1;
    protected TextBox txtPD_CONTRACT_ASK_LIMIT;
    protected TextBox txtPD_CONTRACT_ASK_PAYMENT;
    protected HtmlInputText txtPD_CONTRACT_ASK_PROCEED;
    protected HtmlInputText txtPD_CONTRACT_CHANGE_DATE;
    protected HtmlInputText txtPD_CONTRACT_CHANGE_REASON;
    protected DropDownList txtPD_CONTRACT_CHANGE_TYPE;
    protected HtmlInputText txtPD_CONTRACT_CHANGE_WH;
    protected TextBox txtPD_CONTRACT_COMPANY;
    protected HtmlInputText txtPD_CONTRACT_DATE;
    protected HtmlInputText txtPD_CONTRACT_MOENY;
    protected HtmlInputText txtPD_CONTRACT_MOENY_IsFull;
    protected TextBox txtPD_CONTRACT_NAME;
    protected HtmlInputText txtPD_CONTRACT_NO;
    protected TextBox txtPD_CONTRACT_NOTE;
    protected DropDownList txtPD_CONTRACT_TYPE;
    protected HtmlInputText txtPD_PROJECT_CODE;
    protected HtmlInputText txtPD_PROJECT_Name;
    protected HtmlTable zxzb_bt;

    [WebMethod]
    private static void AjxGetFile(int loop, string date)
    {
    }

    private void BindBGList()
    {
        if (base.Request["UpdatePK"] != null)
        {
            DataSet list = new PD_PROJECT_CONTRACT_Bll().GetList(" pd_contract_no='" + Convert.ToInt32(base.Request["UpdatePK"]) + "'");
            if (list != null)
            {
                this.gvResult.DataSource = list.Tables[0];
                this.gvResult.DataBind();
            }
        }
    }

    private void BindDll()
    {
        PublicDal.BindDropDownList(this.txtPD_CONTRACT_TYPE, "PD_BASE_CONTRACTTYPE", "CONTRACTTYPE_NAME", "CONTRACTTYPE_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_YEAR, "PD_BASE_YEAR", "YEAR_NAME", "YEAR_CODE", "");
        this.ddlPD_YEAR.SelectedValue = DateTime.Now.Year.ToString();
    }

    public void Buttons(string ibtid)
    {
        int selectedIndex = this.gvResult.SelectedIndex;
        switch (ibtid)
        {
            case "ibtcontrol_ibtadd":
                PageShowText.Run_javascript("setcolor();", this.Page);
                this.Session["HtDoType"] = "add";
                return;

            case "ibtcontrol_ibtupdate":
                if (!string.IsNullOrEmpty(this.txtPD_PROJECT_CODE.Value))
                {
                    this.Session["HtDoType"] = "update";
                    PageShowText.GoToPage("HeTongMx.aspx?UpdatePK=" + base.Request["UpdatePK"].ToString() + "&doType=update&strTitle=" + base.Request["strTitle"].ToString(), this.Page);
                    this.txtPD_PROJECT_Name.Attributes.Remove("onclick");
                    return;
                }
                PageShowText.ShowMessage_List("请先选择要变更的项目再做操作！", this.Page);
                return;

            case "ibtcontrol_ibtdelete":
                this.lgnum = this.gvResult.Rows.Count;
                if (!string.IsNullOrEmpty(this.txtPD_PROJECT_CODE.Value))
                {
                    if ((selectedIndex < 0) || (this.gvResult.Rows.Count < selectedIndex))
                    {
                        PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
                        return;
                    }
                    if ((selectedIndex + 1) != this.lgnum)
                    {
                        PageShowText.ShowMessage_List("对不起!此记录已经是合同历史数据，不能进行删除！", this.Page);
                        return;
                    }
                    if (this.lgnum == 1)
                    {
                        this.DataDelete(base.Request["UpdatePK"].ToString());
                        return;
                    }
                    delauto_nos = this.gvResult.DataKeys[selectedIndex].Value.ToString();
                    this.Deleted(delauto_nos);
                    PageShowText.GoToPage("HeTongMx.aspx?UpdatePK=" + base.Request["UpdatePK"].ToString() + "&doType=look&strTitle=" + base.Request["strTitle"].ToString(), this.Page);
                    return;
                }
                PageShowText.ShowMessage_List("请先选择要删除的项目再做操作！", this.Page);
                return;

            case "ibtcontrol_ibtsave":
                if ((base.Request["doType"] == "add") || (base.Request["doType"].Trim() == "update"))
                {
                    this.Save();
                }
                if (base.Request["doType"] == "ReUpdate")
                {
                    this.UpdateSave();
                }
                return;

            case "ibtcontrol_ibtlook":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    this.Master.btModel.IfSave = false;
                    this.Master.btModel.IfUpdate = true;
                    PageShowText.Run_javascript("setcolor();", this.Page);
                    this.ShowInfo(int.Parse(this.lblAUTO_NO.Text), int.Parse(this.gvResult.SelectedDataKey[0].ToString()));
                    break;
                }
                PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
                return;

            case "ibtcontrol_ibtrefresh":
                break;

            case "ibtcontrol_ibtaudit":
                this.SetServiceStream(1, base.Request.Params["UpdatePK"], "审核");
                return;

            case "ibtcontrol_ibtapply":
                this.SetServiceStream(1, base.Request.Params["UpdatePK"], "审批");
                return;

            case "ibtcontrol_ibtsetback":
                this.SetServiceStream(0, base.Request.Params["UpdatePK"], "弃审");
                return;

            case "ibtcontrol_ibtrollback":
                this.SetServiceStream(0, base.Request.Params["UpdatePK"], "退回");
                return;

            case "ibtcontrol_ibtset":
                this.lgnum = this.gvResult.Rows.Count;
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    if (string.IsNullOrEmpty(this.txtPD_PROJECT_CODE.Value))
                    {
                        PageShowText.ShowMessage_List("请先选择要修改的记录再做操作！", this.Page);
                    }
                    else if ((selectedIndex + 1) != this.lgnum)
                    {
                        PageShowText.ShowMessage_List("对不起!此记录已经是合同历史数据，不能进行修改！", this.Page);
                    }
                    else
                    {
                        auto_nos = this.gvResult.DataKeys[selectedIndex].Value.ToString();
                        this.Session["HtDoType"] = "ReUpdate";
                        PageShowText.GoToPage("HeTongMx.aspx?UpdatePK=" + base.Request["UpdatePK"].ToString() + "&doType=ReUpdate&strTitle=" + base.Request["strTitle"].ToString(), this.Page);
                        this.txtPD_PROJECT_Name.Attributes.Remove("onclick");
                    }
                    return;
                }
                PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
                return;

            default:
                return;
        }
    }

    private void DataDelete(string strPK)
    {
        try
        {
            PD_PROJECT_CONTRACT_Bll bll = new PD_PROJECT_CONTRACT_Bll();
            new PD_CONTRACT_CHANGE_Bll().DeletePROJECT(bll.GetModel(base.Request["UpdatePK"].ToString()).PD_PROJECT_CODE);
            bll.Delete(strPK);
            Const.DoSuccessNoClose("删除成功", this.Page.Request.Url.LocalPath + "?UpdatePK=" + strPK + "&doType=look&strTitle=", this.Page);
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "DataDelete()";
            this.el.WriteExceptionLog(true);
            Const.OpenErrorPage("操作失败，请联系系统管理员！", this.Page);
        }
    }

    public void Deleted(string auto_no)
    {
        PD_PROJECT_CONTRACT_Bll bll = new PD_PROJECT_CONTRACT_Bll();
        new PD_CONTRACT_CHANGE_Bll();
        PD_CONTRACT_CHANGE_Bll bll2 = new PD_CONTRACT_CHANGE_Bll();
        if (bll2.Delete(long.Parse(auto_no)))
        {
            string sQLString = "  select   * from PD_PROJECT_CONTRACT_BAK    ORDER by id desc ";
            DataTable table = DbHelperOra.Query(sQLString).Tables[0];
            PD_PROJECT_CONTRACT_Model model = bll.GetModel(base.Request["UpdatePK"].ToString());
            model.PD_DB_LOOP = "1";
            new PD_CONTRACT_CHANGE_Model();
            model.PD_CONTRACT_ASK_PROCEED = table.Rows[0]["PD_CONTRACT_ASK_PROCEED"].ToString();
            model.PD_CONTRACT_ASK_PAYMENT = table.Rows[0]["PD_CONTRACT_ASK_PAYMENT"].ToString();
            model.PD_CONTRACT_NAME = table.Rows[0]["PD_CONTRACT_NAME"].ToString();
            model.PD_CONTRACT_MOENY = new decimal?(decimal.Parse(table.Rows[0]["PD_CONTRACT_MOENY"].ToString()));
            model.PD_CONTRACT_MOENY_CHANGE = new decimal?(decimal.Parse(table.Rows[0]["PD_CONTRACT_MOENY_CHANGE"].ToString()));
            model.PD_CONTRACT_ASK_LIMIT = table.Rows[0]["PD_CONTRACT_ASK_LIMIT"].ToString();
            model.PD_CONTRACT_ASK_PROCEED = table.Rows[0]["PD_CONTRACT_ASK_PROCEED"].ToString();
            model.PD_CONTRACT_ASK_PAYMENT = table.Rows[0]["PD_CONTRACT_ASK_PAYMENT"].ToString();
            model.PD_CONTRACT_NOTE = table.Rows[0]["PD_CONTRACT_NOTE"].ToString();
            bll.Update(model);
            Const.DoSuccessNoClose("删除成功", this.Page.Request.Url.LocalPath + "?UpdatePK=" + model.AUTO_NO + "&doType=look&strTitle=", this.Page);
        }
    }

    private string getColumns()
    {
        return " auto_no, pd_project_code,pd_project_name, pd_contract_change_date, pd_contract_change_type, pd_contract_change_reason, pd_contract_type, pd_contract_no, pd_contract_money, pd_contract_change_zj, pd_contract_change_money, pd_contract_change_filename_sq, pd_contract_filename_system_sq, pd_contract_fileno_pf, pd_contract_filename_pf, pd_contract_filename_sys_pf, pd_contract_pici, pd_contract_state, pd_db_loop,PD_CONTRACT_CHANGE_TYPE_NAME,PD_CONTRACT_TYPE_NAME ";
    }

    private void getModel(PD_PROJECT_CONTRACT_Model model, PD_CONTRACT_CHANGE_Model c_model)
    {
        model.PD_PROJECT_CODE = this.txtPD_PROJECT_CODE.Value;
        model.PD_CONTRACT_TYPE = this.txtPD_CONTRACT_TYPE.SelectedValue;
        model.PD_CONTRACT_NO = this.txtPD_CONTRACT_NO.Value;
        model.PD_CONTRACT_COMPANY = this.txtPD_CONTRACT_COMPANY.Text;
        model.PD_CONTRACT_ASK_LIMIT = this.txtPD_CONTRACT_ASK_LIMIT.Text;
        model.PD_CONTRACT_ASK_PROCEED = this.txtPD_CONTRACT_ASK_PROCEED.Value;
        model.PD_CONTRACT_ASK_PAYMENT = this.txtPD_CONTRACT_ASK_PAYMENT.Text;
        model.PD_CONTRACT_NOTE = this.txtPD_CONTRACT_NOTE.Text;
        model.PD_CONTRACT_NAME = this.txtPD_CONTRACT_NAME.Text;
        model.PD_YEAR = this.ddlPD_YEAR.SelectedValue;
        if (PublicDal.PageValidate.IsDateTime(this.txtPD_CONTRACT_DATE.Value))
        {
            model.PD_CONTRACT_DATE = DateTime.Parse(this.txtPD_CONTRACT_DATE.Value);
        }
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_CONTRACT_MOENY.Value))
        {
            decimal? nullable = model.PD_CONTRACT_MOENY;
            decimal num = decimal.Parse(this.txtPD_CONTRACT_MOENY.Value);
            c_model.PD_CONTRACT_CHANGE_MONEY = nullable.HasValue ? new decimal?(nullable.GetValueOrDefault() - num) : null;
            model.PD_CONTRACT_MOENY = new decimal?(decimal.Parse(this.txtPD_CONTRACT_MOENY.Value));
        }
        this.GetQUOTA(model);
        if (PublicDal.PageValidate.IsDateTime(this.txtPD_CONTRACT_CHANGE_DATE.Value))
        {
            c_model.PD_CONTRACT_CHANGE_DATE = new DateTime?(Convert.ToDateTime(this.txtPD_CONTRACT_CHANGE_DATE.Value.ToString()));
        }
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_CONTRACT_MOENY.Value))
        {
            c_model.PD_CONTRACT_CHANGE_MONEY = new decimal?(Convert.ToDecimal(this.txtPD_CONTRACT_MOENY.Value));
        }
        c_model.PD_CONTRACT_NO = this.txtPD_CONTRACT_NO.Value;
        c_model.PD_CONTRACT_CHANGE_REASON = this.txtPD_CONTRACT_CHANGE_REASON.Value;
        c_model.PD_CONTRACT_CHANGE_TYPE = this.txtPD_CONTRACT_CHANGE_TYPE.SelectedValue;
        c_model.PD_CONTRACT_CHANGE_WH = this.txtPD_CONTRACT_CHANGE_WH.Value;
        c_model.PD_CONTRACT_TYPE = this.txtPD_CONTRACT_TYPE.SelectedValue;
        c_model.PD_PROJECT_CODE = model.PD_PROJECT_CODE;
        c_model.PD_CONTRACT_NO = model.PD_CONTRACT_NO;
        this.GetQUOTA(c_model);
    }

    private void getModel_BG(PD_CONTRACT_CHANGE_Model c_model, PD_PROJECT_CONTRACT_Model model)
    {
        if (PublicDal.PageValidate.IsDateTime(this.txtPD_CONTRACT_CHANGE_DATE.Value))
        {
            c_model.PD_CONTRACT_CHANGE_DATE = new DateTime?(Convert.ToDateTime(this.txtPD_CONTRACT_CHANGE_DATE.Value.ToString()));
        }
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_CONTRACT_MOENY.Value))
        {
            c_model.PD_CONTRACT_CHANGE_MONEY = new decimal?(Convert.ToDecimal(this.txtPD_CONTRACT_MOENY.Value));
        }
        c_model.PD_CONTRACT_CHANGE_REASON = this.txtPD_CONTRACT_CHANGE_REASON.Value;
        c_model.PD_CONTRACT_CHANGE_TYPE = this.txtPD_CONTRACT_CHANGE_TYPE.SelectedValue;
        c_model.PD_CONTRACT_CHANGE_WH = this.txtPD_CONTRACT_CHANGE_WH.Value;
        c_model.PD_PROJECT_CODE = model.PD_PROJECT_CODE;
        c_model.PD_CONTRACT_NO = model.PD_CONTRACT_NO;
    }

    private void GetQUOTA(PD_CONTRACT_CHANGE_Model model)
    {
        DataSet set = null;
        DataView defaultView = null;
        string s = base.Server.UrlDecode(this.FilePostCtr2.getFileName);
        if ((s != null) && (s.Trim() != ""))
        {
            set = new DataSet();
            XmlTextReader reader = new XmlTextReader(new StringReader(s));
            set.ReadXml(reader);
        }
        if ((set != null) && (set.Tables.Count > 0))
        {
            defaultView = set.Tables[0].DefaultView;
        }
        if (defaultView != null)
        {
            defaultView.RowFilter = " tableID='zxzb_bt' ";
            if (defaultView.Count > 0)
            {
                model.PD_CONTRACT_CHANGE_FILENAME_SQ = defaultView[0]["FileName"].ToString();
                model.PD_CONTRACT_FILENAME_SYSTEM_SQ = defaultView[0]["FileSysName"].ToString();
            }
        }
    }

    private void GetQUOTA(PD_PROJECT_CONTRACT_Model model)
    {
        DataSet set = null;
        DataView defaultView = null;
        string s = base.Server.UrlDecode(this.FilePostCtr1.getFileName);
        if ((s != null) && (s.Trim() != ""))
        {
            set = new DataSet();
            XmlTextReader reader = new XmlTextReader(new StringReader(s));
            set.ReadXml(reader);
        }
        if ((set != null) && (set.Tables.Count > 0))
        {
            defaultView = set.Tables[0].DefaultView;
        }
        if (defaultView != null)
        {
            defaultView.RowFilter = " tableID='zxzb_bt' ";
            if (defaultView.Count > 0)
            {
                model.PD_CONTRACT_FILENAME = defaultView[0]["FileName"].ToString();
                model.PD_CONTRACT_FILENAME_SYSTEM = defaultView[0]["FileSysName"].ToString();
            }
        }
    }

    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (this.Session["user"] == null)
        {
            Const.GoLoginPath_List(this.Page);
        }
        else
        {
            int num = 0;
            string str = "";
            string userName = ((UserModel)this.Session["User"]).UserName;
            string power = ((UserModel)this.Session["User"]).Power;
            if (Public.IsNumber(e.CommandArgument.ToString()))
            {
                num = int.Parse(e.CommandArgument.ToString());
            }
            string commandName = e.CommandName;
            if (commandName != null)
            {
                if (commandName != "Select")
                {
                    if (!(commandName == "Two"))
                    {
                        bool flag1 = commandName == "Sort";
                    }
                    else
                    {
                        num = int.Parse(e.CommandArgument.ToString());
                        str = this.gvResult.DataKeys[num].Value.ToString();
                    }
                }
                else
                {
                    num = int.Parse(e.CommandArgument.ToString());
                    str = this.gvResult.DataKeys[num].Value.ToString();
                    this.ShowInfo(int.Parse(this.lblAUTO_NO.Text), Convert.ToInt32(str));
                    PageShowText.Run_javascript("setTimeout(\"setMenuHeight()\", 0);setTimeout(Bing_Data(),0);", this.Page);
                }
            }
        }
    }

    protected void gvResult_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        if ((this.ViewState["SortOrder"] != null) && (this.ViewState["OrderDire"] != null))
        {
            if (this.ViewState["SortOrder"].ToString() == sortExpression)
            {
                if (this.ViewState["OrderDire"].ToString() == "Desc")
                {
                    this.ViewState["OrderDire"] = "ASC";
                }
                else
                {
                    this.ViewState["OrderDire"] = "Desc";
                }
            }
            else
            {
                this.ViewState["SortOrder"] = e.SortExpression;
                this.ViewState["OrderDire"] = "ASC";
            }
        }
        else
        {
            this.ViewState["SortOrder"] = e.SortExpression;
            this.ViewState["OrderDire"] = "ASC";
        }
        this.ShowData("");
    }

    public void ListPageLoad(Page page, out ButtonsModel main_bm, string AUTO_NO)
    {
        PublicDal.ShowMxButton(this.Page, out main_bm, "PD_PROJECT_CONTRACT", "AUTO_NO", AUTO_NO, "PD_NOW_SERVERPK");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session["User"] == null)
        {
            Const.GoLoginPath_OpenWindow(this.Page);
        }
        else
        {
            string str2;
            if (base.Request["strTitle"] != null)
            {
                this.Master.strTitle = base.Request["strTitle"];
            }
            this.Master.strTitle = base.Request["strTitle"];
            this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
            ButtonsModel model = null;
            this.ListPageLoad(this.Page, out model, base.Request["UpdatePK"]);
            model.IfAudit = false;
            model.IbtUpdateText = "变更";
            model.IfSet = true;
            model.IbtSetText = "修改";
            model.IfDelete = true;
            model.IbtDeleteText = "删除";
            this.Master.btModel = model;
            if (!base.IsPostBack)
            {
                this.BindDll();
                if ((base.Request["UpdatePK"] != null) && PublicDal.PageValidate.IsDecimal(base.Request["UpdatePK"]))
                {
                    int num;
                    string str = " PD_Contract_NO in (select PD_Contract_NO from view_contract_Mx where AUTO_No=" + base.Request["UpdatePK"].ToString() + ") ";
                    this.ShowData(str);
                    this.gvResult.SelectedIndex = this.gvResult.Rows.Count - 1;
                    if ((this.gvResult.Rows.Count > 0) && (this.gvResult.DataKeys[this.gvResult.Rows.Count - 1].Value != DBNull.Value))
                    {
                        num = Convert.ToInt32(this.gvResult.DataKeys[this.gvResult.Rows.Count - 1].Value);
                    }
                    else
                    {
                        num = -1;
                    }
                    this.ShowInfo(int.Parse(base.Request["UpdatePK"]), num);
                }
                else
                {
                    this.Master.btModel.IfUpdate = false;
                    this.selectHTBH();
                }
            }
            if ((base.Request["doType"] != null) && ((str2 = base.Request["DoType"].ToString()) != null))
            {
                if (!(str2 == "look"))
                {
                    if (!(str2 == "update"))
                    {
                        if (!(str2 == "ReUpdate"))
                        {
                            if (str2 == "add")
                            {
                                model.IfUpdate = false;
                                model.IfSave = true;
                                model.IfSet = false;
                                model.IfDelete = false;
                                this.txtPD_PROJECT_Name.Disabled = false;
                                this.txtPD_CONTRACT_NO.Disabled = false;
                                this.txtPD_CONTRACT_NAME.Enabled = true;
                                this.ddlPD_YEAR.Enabled = true;
                                this.txtPD_CONTRACT_NAME.Enabled = true;
                                this.txtPD_PROJECT_Name.Disabled = true;
                                this.txtPD_PROJECT_CODE.Disabled = false;
                            }
                            return;
                        }
                        model.IfSave = true;
                        model.IfUpdate = false;
                        model.IfSet = false;
                        model.IfDelete = false;
                        this.div_ht_change.Visible = true;
                        this.TabContainer1.Visible = true;
                        if ((dtgvr != null) && string.IsNullOrEmpty(dtgvr.Rows[0]["PD_CONTRACT_CHANGE_REASON"].ToString()))
                        {
                            this.div_ht_change.Visible = false;
                        }
                        this.Master.TabContainer1 = this.TabContainer1;
                        if (!base.IsPostBack)
                        {
                            this.txtPD_CONTRACT_NAME.Enabled = false;
                            this.txtPD_PROJECT_Name.Attributes.Remove("onclick");
                        }
                        return;
                    }
                }
                else
                {
                    model.IfUpdate = true;
                    model.IfSave = false;
                    model.IfSet = true;
                    model.IfDelete = true;
                    this.div_ht_change.Visible = true;
                    this.TabContainer1.Visible = true;
                    this.Master.TabContainer1 = this.TabContainer1;
                    return;
                }
                model.IfSave = true;
                model.IfUpdate = false;
                model.IfSet = false;
                model.IfDelete = false;
                this.div_ht_change.Visible = true;
                this.TabContainer1.Visible = true;
                this.Master.TabContainer1 = this.TabContainer1;
                if (!base.IsPostBack)
                {
                    this.txtPD_CONTRACT_CHANGE_REASON.Value = "";
                    this.txtPD_CONTRACT_CHANGE_DATE.Value = "";
                    this.txtPD_CONTRACT_CHANGE_TYPE.SelectedIndex = 0;
                    this.txtPD_CONTRACT_CHANGE_WH.Value = "";
                    this.txtPD_CONTRACT_NAME.Enabled = false;
                    this.txtPD_PROJECT_Name.Attributes.Remove("onclick");
                }
            }
        }
    }

    private string PanDuan()
    {
        string str = "";
        if (this.txtPD_PROJECT_CODE.Value.Trim().Length == 0)
        {
            str = str + @"项目名称不能为空！\n";
        }
        if (this.txtPD_CONTRACT_TYPE.Text.Trim().Length == 0)
        {
            str = str + @"合同类型不能为空！\n";
        }
        if (this.txtPD_CONTRACT_NO.Value.Trim().Length == 0)
        {
            str = str + @"合同编号不能为空！\n";
        }
        if (this.txtPD_CONTRACT_DATE.Value.Trim().Length == 0)
        {
            str = str + @"合同日期格式错误！\n";
        }
        if (this.txtPD_CONTRACT_COMPANY.Text.Trim().Length == 0)
        {
            str = str + @"合同签约单位不能为空！\n";
        }
        if (!PublicDal.PageValidate.IsNumber(this.txtPD_CONTRACT_MOENY.Value))
        {
            str = str + @"合同金额格式错误！\n";
        }
        if (this.txtPD_CONTRACT_ASK_LIMIT.Text.Trim().Length == 0)
        {
            str = str + @"合同工期要求不能为空！\n";
        }
        if (this.txtPD_CONTRACT_ASK_PROCEED.Value.Trim().Length == 0)
        {
            str = str + @"合同进度要求不能为空！\n";
        }
        if (this.txtPD_CONTRACT_ASK_PAYMENT.Text.Trim().Length == 0)
        {
            str = str + @"合同付款要求不能为空！\n";
        }
        return str;
    }

    [WebMethod]
    public static bool PanDuanHeTongJinE(string PD_PROJECT_CODE, string PD_CONTRACT_MOENY, string Contract_Code)
    {
        PD_PROJECT_CONTRACT_BAK_Bll bll = new PD_PROJECT_CONTRACT_BAK_Bll();
        return bll.GetPd_Contract_Moeny_Total(PD_PROJECT_CODE, PD_CONTRACT_MOENY, Contract_Code);
    }

    private void Save()
    {
        PD_PROJECT_CONTRACT_Bll bll = new PD_PROJECT_CONTRACT_Bll();
        PD_CONTRACT_CHANGE_Bll bll2 = new PD_CONTRACT_CHANGE_Bll();
        if (base.Request["UpdatePK"] != null)
        {
            if (PublicDal.PageValidate.IsDecimal(base.Request["UpdatePK"]))
            {
                PD_PROJECT_CONTRACT_Model model = bll.GetModel(base.Request["UpdatePK"].ToString());
                PD_CONTRACT_CHANGE_Model model2 = new PD_CONTRACT_CHANGE_Model();
                PD_PROJECT_CONTRACT_BAK_Bll bll3 = new PD_PROJECT_CONTRACT_BAK_Bll();
                this.getModel(model, model2);
                if (bll.Update(model))
                {
                    decimal? maxID = bll3.GetMaxID(model.PD_CONTRACT_NO);
                    if (maxID.HasValue)
                    {
                        model2.CONTR_CHANGE_MIAN_ID = maxID.Value;
                    }
                    bll2.Add(model2);
                }
                Const.DoSuccessNoClose("合同变更成功", this.Page.Request.Url.LocalPath + "?UpdatePK=" + base.Request["UpdatePK"].ToString() + "&doType=look&strTitle=" + base.Request["strTitle"].ToString(), this.Page);
                this.Master.btModel.IfUpdate = true;
            }
        }
        else if (this.txtPD_PROJECT_CODE.Value != null)
        {
            PD_PROJECT_CONTRACT_Model model3 = new PD_PROJECT_CONTRACT_Model
            {
                PD_DB_LOOP = "1"
            };
            PD_CONTRACT_CHANGE_Model model4 = new PD_CONTRACT_CHANGE_Model();
            PD_PROJECT_CONTRACT_BAK_Bll bll4 = new PD_PROJECT_CONTRACT_BAK_Bll();
            this.getModel(model3, model4);
            model3.PD_NOW_SERVERPK = PublicDal.SetCreateServiceStream(this.Page);
            bll.Add(model3);
            model4.PD_NOW_SERVERPK = PublicDal.SetCreateServiceStream(this.Page);
            this.getModel_BG(model4, model3);
            decimal? nullable2 = bll4.GetMaxID(model3.PD_CONTRACT_NO);
            if (nullable2.HasValue)
            {
                model4.CONTR_CHANGE_MIAN_ID = nullable2.Value;
            }
            bll2.Add(model4);
            Const.DoSuccessNoClose("添加成功", this.Page.Request.Url.LocalPath + "?UpdatePK=" + model3.AUTO_NO + "&doType=look&strTitle=", this.Page);
        }
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
    }

    private void selectHTBH()
    {
        new PD_PROJECT_CONTRACT_Bll();
        this.txtPD_CONTRACT_NO.Value = DateTime.Now.ToString("yyyyMMddHHmmssffffff");
    }

    public void SetServiceStream(int operation, string AUTO_NO, string Mess)
    {
        PublicDal.SetServiceStream(this.Page, operation, "PD_PROJECT_CONTRACT", "AUTO_NO", AUTO_NO, Mess, "PD_NOW_SERVERPK");
    }

    public void ShowData(string str)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            string companyWhere = PublicDal.GetCompanyWhere();
            if (str != "")
            {
                str = " where " + str + " and  pd_found_xz='01' " + companyWhere;
            }
            else
            {
                str = "where  pd_found_xz='01' " + companyWhere;
            }
            DataSet set = DbHelperOra.Query("select " + this.getColumns() + " from view_contract_change_list " + str + "  order by auto_no  ");
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                DataView defaultView = set.Tables[0].DefaultView;
                if ((this.ViewState["SortOrder"] != null) && (this.ViewState["OrderDire"] != null))
                {
                    string str4 = ((string)this.ViewState["SortOrder"]) + " " + ((string)this.ViewState["OrderDire"]);
                    defaultView.Sort = str4;
                }
                this.gvResult.DataSource = defaultView;
                this.gvResult.DataBind();
                dtgvr = set.Tables[0];
            }
            else
            {
                DataTable table = new DataTable();
                table = set.Tables[0];
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                this.gvResult.DataSource = table.DefaultView;
                this.gvResult.DataBind();
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
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
    }

    private void ShowInfo(int AUTO_NO, int AUTO_NO_BG)
    {
        decimal iD = -1M;
        if (AUTO_NO_BG != -1)
        {
            PD_CONTRACT_CHANGE_Model model = new PD_CONTRACT_CHANGE_Bll().GetModel(AUTO_NO_BG);
            if (model == null)
            {
                return;
            }
            iD = model.CONTR_CHANGE_MIAN_ID;
            if (model.PD_CONTRACT_CHANGE_DATE.HasValue)
            {
                this.txtPD_CONTRACT_CHANGE_DATE.Value = model.PD_CONTRACT_CHANGE_DATE.Value.ToString("yyyy/MM/dd");
            }
            if (model.PD_CONTRACT_CHANGE_TYPE == null)
            {
                this.txtPD_CONTRACT_CHANGE_TYPE.SelectedIndex = 0;
            }
            else
            {
                this.txtPD_CONTRACT_CHANGE_TYPE.SelectedValue = model.PD_CONTRACT_CHANGE_TYPE;
            }
            this.txtPD_CONTRACT_CHANGE_REASON.Value = model.PD_CONTRACT_CHANGE_REASON;
            this.txtPD_CONTRACT_TYPE.SelectedValue = model.PD_CONTRACT_TYPE;
            this.txtPD_CONTRACT_NO.Value = model.PD_CONTRACT_NO;
            this.txtPD_CONTRACT_CHANGE_WH.Value = model.PD_CONTRACT_CHANGE_WH.ToString();
            if (model.PD_YEAR != "")
            {
                this.ddlPD_YEAR.SelectedValue = model.PD_YEAR.ToString();
            }
            DataSet ds = new DataSet();
            ds.Tables.Add();
            ds.Tables[0].Columns.Add("AUTO_NO");
            ds.Tables[0].Columns.Add("FILE_NAME");
            ds.Tables[0].Columns.Add("FILE_SYSNAME");
            if (((model != null) && (model.PD_CONTRACT_FILENAME_SYSTEM_SQ != null)) && (model.PD_CONTRACT_FILENAME_SYSTEM_SQ.Trim() != ""))
            {
                DataRow row = ds.Tables[0].NewRow();
                row["AUTO_NO"] = model.AUTO_NO;
                row["FILE_NAME"] = model.PD_CONTRACT_CHANGE_FILENAME_SQ;
                row["FILE_SYSNAME"] = model.PD_CONTRACT_FILENAME_SYSTEM_SQ;
                ds.Tables[0].Rows.Add(row);
            }
            this.json_btData2.Value = base.Server.UrlEncode(PublicDal.DataToJSON(ds));
        }
        PD_PROJECT_CONTRACT_BAK_Model model2 = new PD_PROJECT_CONTRACT_BAK_Bll().GetModel(iD);
        TB_PROJECT_Bll bll3 = new TB_PROJECT_Bll();
        if (model2 != null)
        {
            TB_PROJECT_Model model3 = bll3.GetModel(model2.PD_PROJECT_CODE);
            this.txtPD_PROJECT_Name.Value = model3.PD_PROJECT_NAME;
            this.lblAUTO_NO.Text = model2.ID.ToString("0");
            this.txtPD_PROJECT_CODE.Value = model2.PD_PROJECT_CODE;
            this.txtPD_CONTRACT_TYPE.SelectedValue = model2.PD_CONTRACT_TYPE;
            this.txtPD_CONTRACT_NO.Value = model2.PD_CONTRACT_NO;
            this.txtPD_CONTRACT_DATE.Value = model2.PD_CONTRACT_DATE.ToString();
            this.txtPD_CONTRACT_COMPANY.Text = model2.PD_CONTRACT_COMPANY;
            this.txtPD_CONTRACT_MOENY.Value = model2.PD_CONTRACT_MOENY.ToString();
            this.txtPD_CONTRACT_ASK_LIMIT.Text = model2.PD_CONTRACT_ASK_LIMIT;
            this.txtPD_CONTRACT_ASK_PROCEED.Value = model2.PD_CONTRACT_ASK_PROCEED;
            this.txtPD_CONTRACT_ASK_PAYMENT.Text = model2.PD_CONTRACT_ASK_PAYMENT;
            this.txtPD_CONTRACT_NOTE.Text = model2.PD_CONTRACT_NOTE;
            this.txtPD_CONTRACT_NAME.Text = model2.PD_CONTRACT_NAME;
            this.txtPD_CONTRACT_TYPE.SelectedValue = model2.PD_CONTRACT_TYPE;
            if (model2.PD_YEAR.HasValue)
            {
                this.ddlPD_YEAR.SelectedValue = model2.PD_YEAR.Value.ToString();
            }
            DataSet set2 = new DataSet();
            set2.Tables.Add();
            set2.Tables[0].Columns.Add("AUTO_NO");
            set2.Tables[0].Columns.Add("FILE_NAME");
            set2.Tables[0].Columns.Add("FILE_SYSNAME");
            if (((model2 != null) && (model2.PD_CONTRACT_FILENAME_SYSTEM != null)) && (model2.PD_CONTRACT_FILENAME_SYSTEM.Trim() != ""))
            {
                DataRow row2 = set2.Tables[0].NewRow();
                row2["AUTO_NO"] = model2.ID;
                row2["FILE_NAME"] = model2.PD_CONTRACT_FILENAME;
                row2["FILE_SYSNAME"] = model2.PD_CONTRACT_FILENAME_SYSTEM;
                set2.Tables[0].Rows.Add(row2);
            }
            this.json_btData.Value = base.Server.UrlEncode(PublicDal.DataToJSON(set2));
        }
    }

    private void UpdateSave()
    {
        PD_PROJECT_CONTRACT_Bll bll = new PD_PROJECT_CONTRACT_Bll();
        PD_CONTRACT_CHANGE_Bll bll2 = new PD_CONTRACT_CHANGE_Bll();
        if ((base.Request["UpdatePK"] != null) && PublicDal.PageValidate.IsDecimal(base.Request["UpdatePK"]))
        {
            PD_PROJECT_CONTRACT_Model model = bll.GetModel(base.Request["UpdatePK"].ToString());
            model.PD_DB_LOOP = "1";
            PD_CONTRACT_CHANGE_Model model2 = new PD_CONTRACT_CHANGE_Model();
            PD_PROJECT_CONTRACT_BAK_Bll bll3 = new PD_PROJECT_CONTRACT_BAK_Bll();
            this.getModel(model, model2);
            model.PD_NOW_SERVERPK = PublicDal.SetCreateServiceStream(this.Page);
            bll.Update(model);
            model2.PD_NOW_SERVERPK = PublicDal.SetCreateServiceStream(this.Page);
            this.getModel_BG(model2, model);
            decimal? maxID = bll3.GetMaxID(model.PD_CONTRACT_NO);
            if (maxID.HasValue)
            {
                model2.CONTR_CHANGE_MIAN_ID = maxID.Value;
            }
            model2.AUTO_NO = auto_nos;
            bll2.Update(model2);
            Const.DoSuccessNoClose("修改成功", this.Page.Request.Url.LocalPath + "?UpdatePK=" + model.AUTO_NO + "&doType=look&strTitle=", this.Page);
        }
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public MainMX Master
    {
        get
        {
            return (MainMX)base.Master;
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
