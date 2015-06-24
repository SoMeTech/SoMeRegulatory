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

public class Work_BZ_CCXC_XCMx : Page, IRequiresSessionState
{
    private DB_OPT dbo;
    protected DropDownList ddlPD_YEAR;
    private ExceptionLog.ExceptionLog el;
    protected UserControls_FilePostCtr FilePostCtr1;
    protected SmartGridView gvResult;
    protected HtmlInputHidden json_btData;
    protected Label lblAUTO_NO;
    protected TabPanel Panel_ccxc;
    public int Pk;
    public static string str_MXID = "";
    protected TabContainer TabContainer1;
    protected TextBox txt_file;
    protected HtmlInputHidden txtindex;
    protected Label txtPD_DB_LOOP;
    protected TextBox txtPD_INSPECTION_ACCOUNTNO;
    protected TextBox txtPD_INSPECTION_ADDR;
    protected TextBox txtPD_INSPECTION_CONCLUSION;
    protected TextBox txtPD_INSPECTION_CONTENT;
    protected HtmlInputText txtPD_INSPECTION_DATE;
    protected TextBox txtPD_INSPECTION_FFMONEY;
    protected TextBox txtPD_INSPECTION_FFNUM;
    protected TextBox txtPD_INSPECTION_FFSTAND;
    protected TextBox txtPD_INSPECTION_IDNO;
    protected TextBox txtPD_INSPECTION_MANS;
    protected TextBox txtPD_INSPECTION_PEASANT;
    protected TextBox txtPD_INSPECTION_PEASANT_ADDR;
    protected DropDownList txtPD_INSPECTION_PROCESS;
    protected TextBox txtPD_INSPECTION_SUGGEST;
    protected TextBox txtPD_MONITOR_TOTAL_MONEY_PAY;
    protected HtmlInputText txtPD_PROJECT_CODE;
    protected HtmlInputText txtPD_PROJECT_Name;
    protected HtmlInputHidden txttitle;
    protected HtmlGenericControl ulimg;
    protected HtmlTable zxzb_bt;

    private void Add()
    {
    }

    private void AddImgMethod(PD_PROJECT_INSPECTION_Model model)
    {
        try
        {
            string str = this.txt_file.Text.ToString();
            if (!string.IsNullOrEmpty(str))
            {
                string str2 = "";
                string str3 = "";
                if (!string.IsNullOrEmpty(str))
                {
                    str2 = str.Substring(str.LastIndexOf("||")).Replace("||", "");
                    str3 = str2;
                    str2 = str2.Substring(0, str2.LastIndexOf("."));
                }
                str = "UserImages/" + str3;
                DbHelperOra.ExecuteSql("insert into t_photos (fkid, photoname, photopath, remarks, sortid) values  ( 'bzCCXCMX_" + model.AUTO_NO + "', '" + str3 + "', '" + str + "', '" + str3 + "', 1)");
            }
        }
        catch (Exception)
        {
        }
    }

    private void BindDll()
    {
        PublicDal.BindDropDownList(this.ddlPD_YEAR, "PD_BASE_YEAR", "YEAR_NAME", "YEAR_CODE", "");
        this.ddlPD_YEAR.SelectedValue = DateTime.Now.Year.ToString();
        this.txtPD_INSPECTION_DATE.Value = DateTime.Now.ToString("yyyy-MM-dd");
    }

    public void BindImg()
    {
        string str = "";
        string str2 = "";
        try
        {
            try
            {
                str_MXID = base.Request["MXID"].ToString();
            }
            catch
            {
                str2 = str_MXID;
            }
            DataSet set = DbHelperOra.Query("select * from t_photos where fkid='bzCCXCMX_" + str_MXID + "'");
            if ((set != null) || (set.Tables[0].Rows.Count > 0))
            {
                if (set.Tables[0].Rows.Count <= 0)
                {
                    str = str + "<li class='li1'><div class='pic'><a href='#' target='_self'>";
                    str = str + "<div id='imgPreview' style='width: 230px; height: 230px;'>";
                    str = str + "<img src='../../../jquery.easyui/imgload/images/no_img.png' id='upimg' title='信息公示'/></div></a></div></li>";
                }
                else
                {
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        string str4 = set.Tables[0].Rows[i]["photopath"].ToString();
                        string str5 = set.Tables[0].Rows[i]["remarks"].ToString();
                        string str6 = set.Tables[0].Rows[i]["PHOTONAME"].ToString();
                        str = str + "<li class='li1'><div class='pic'><a href='#' target='_self'>";
                        str = str + "<div id='imgPreview' style='width: 230px; height: 230px;'>";
                        string str7 = str;
                        str = str7 + "<img src='../../../" + str4 + "' id='upimg' title='" + str5 + "' imgid='" + str6 + "'/></div></a></div></li>";
                    }
                }
                this.ulimg.InnerHtml = str;
            }
        }
        catch
        {
            str = (str + "<li class='li1'><div class='pic'><a href='#' target='_self'>") + "<div id='imgPreview' style='width: 230px; height: 230px;'>" + "<img src='../../../jquery.easyui/imgload/images/no_img.png' id='upimg' title='信息公示'/></div></a></div></li>";
            this.ulimg.InnerHtml = str;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
    }

    public void Buttons(string ibtid)
    {
        switch (ibtid)
        {
            case "ibtcontrol_ibtprintnote":
                PageShowText.OpenPage(Public.RelativelyPath("Report/bzxJGTable2.aspx") + "?UpdatePK=" + base.Request["UpdatePK"].Trim(), null, null, this.Page, true);
                PageShowText.Refurbish("", this.Page);
                return;

            case "ibtcontrol_ibtadd":
                {
                    this.Add();
                    string str = base.Request.Params["UpdatePK"].ToString();
                    str_MXID = "";
                    base.Response.Redirect("bzCCMx.aspx?CCXCDoType=add&UpdatePK=" + str + "&strTitle=" + base.Request["strTitle"].ToString());
                    return;
                }
            case "ibtcontrol_ibtupdate":
                this.Update();
                return;

            case "ibtcontrol_ibtdelete":
                this.Delete();
                return;

            case "ibtcontrol_ibtsave":
                this.Save();
                break;

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

            default:
                return;
        }
    }

    private void clear()
    {
        this.txtPD_INSPECTION_PEASANT.Text = "";
        this.txtPD_INSPECTION_IDNO.Text = "";
        this.txtPD_INSPECTION_PEASANT_ADDR.Text = "";
        this.txtPD_INSPECTION_FFSTAND.Text = "";
        this.txtPD_INSPECTION_FFNUM.Text = "";
        this.txtPD_INSPECTION_ACCOUNTNO.Text = "";
        this.txtPD_INSPECTION_CONTENT.Text = "";
        this.txtPD_INSPECTION_SUGGEST.Text = "";
        this.txtPD_INSPECTION_CONCLUSION.Text = "";
        this.txtPD_INSPECTION_FFMONEY.Text = "";
    }

    private void Delete()
    {
        if (this.lblAUTO_NO.Text != "")
        {
            new PD_PROJECT_INSPECTION_Bll().Delete((long)Convert.ToInt32(this.lblAUTO_NO.Text));
            Const.DoSuccessNoClose("删除成功", this.Page.Request.Url.LocalPath + "?CCXCDoType=look&UpdatePK=" + base.Request["UpdatePK"].ToString() + "&strTitle=" + base.Request["strTitle"].ToString(), this.Page);
        }
    }

    [WebMethod]
    public static int DelImg(string value1)
    {
        if (!string.IsNullOrEmpty(str_MXID))
        {
            return DbHelperOra.ExecuteSql("delete from t_photos   where fkid='bzCCXCMX_" + str_MXID + "' and PHOTONAME='" + value1.Trim() + "'");
        }
        return 0;
    }

    private string getColumns()
    {
        return " auto_no,pd_project_code,pd_project_name, pd_inspection_process, pd_inspection_date, pd_inspection_mans, pd_inspection_addr, pd_inspection_content, pd_inspection_suggest, pd_inspection_conclusion, pd_inspection_filename, pd_inspection_filename_system, pd_inspection_peasant, pd_inspection_idno, pd_inspection_ffnum, pd_inspection_ffstand, pd_inspection_ffmoney, pd_inspection_accountno, pd_inspection_peasant_addr, pd_monitor_proceed_wcl, pd_project_total_money, pd_monitor_total_money_pay, pd_monitor_total_money_wcl,pd_year,PD_BZFFLIST_DATE,PD_INSPECTION_BTFFID,PD_INSPECTION_BTFFNAME ";
    }

    private void getModel(PD_PROJECT_INSPECTION_Model model)
    {
        model.PD_PROJECT_CODE = base.Request["UpdatePK"].ToString();
        model.PD_INSPECTION_PROCESS = this.txtPD_INSPECTION_PROCESS.SelectedValue;
        model.PD_INSPECTION_MANS = this.txtPD_INSPECTION_MANS.Text;
        model.PD_INSPECTION_ADDR = this.txtPD_INSPECTION_ADDR.Text;
        model.PD_INSPECTION_CONTENT = this.txtPD_INSPECTION_CONTENT.Text;
        model.PD_INSPECTION_SUGGEST = this.txtPD_INSPECTION_SUGGEST.Text;
        model.PD_INSPECTION_CONCLUSION = this.txtPD_INSPECTION_CONCLUSION.Text;
        model.PD_YEAR = this.ddlPD_YEAR.SelectedValue;
        if (PublicDal.PageValidate.IsDateTime(this.txtPD_INSPECTION_DATE.Value))
        {
            model.PD_INSPECTION_DATE = new DateTime?(DateTime.Parse(this.txtPD_INSPECTION_DATE.Value));
        }
        else
        {
            model.PD_INSPECTION_DATE = new DateTime();
        }
        model.PD_INSPECTION_PEASANT = this.txtPD_INSPECTION_PEASANT.Text;
        model.PD_INSPECTION_IDNO = this.txtPD_INSPECTION_IDNO.Text;
        if (PublicDal.PageValidate.IsInt(this.txtPD_INSPECTION_FFNUM.Text))
        {
            model.PD_INSPECTION_FFNUM = new int?(int.Parse(this.txtPD_INSPECTION_FFNUM.Text));
        }
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_INSPECTION_FFSTAND.Text))
        {
            model.PD_INSPECTION_FFSTAND = new decimal?(decimal.Parse(this.txtPD_INSPECTION_FFSTAND.Text));
        }
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_INSPECTION_FFMONEY.Text))
        {
            model.PD_INSPECTION_FFMONEY = new decimal?(decimal.Parse(this.txtPD_INSPECTION_FFMONEY.Text));
        }
        model.PD_INSPECTION_ACCOUNTNO = this.txtPD_INSPECTION_ACCOUNTNO.Text;
        model.PD_INSPECTION_PEASANT_ADDR = this.txtPD_INSPECTION_PEASANT_ADDR.Text;
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_MONITOR_TOTAL_MONEY_PAY.Text))
        {
            model.PD_MONITOR_TOTAL_MONEY_PAY = new decimal?(decimal.Parse(this.txtPD_MONITOR_TOTAL_MONEY_PAY.Text));
        }
        this.GetQUOTA(model);
    }

    private void GetQUOTA(PD_PROJECT_INSPECTION_Model model)
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
                model.PD_INSPECTION_FILENAME = defaultView[0]["FileName"].ToString();
                model.PD_INSPECTION_FILENAME_SYSTEM = defaultView[0]["FileSysName"].ToString();
            }
        }
    }

    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (this.Session["user"] == null)
        {
            Const.GoLoginPath_List(this.Page);
        }
        else if (base.Request["CCXCDoType"] != "add")
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
                        this.Session["CCXCDoType"] = "look";
                    }
                }
                else
                {
                    num = int.Parse(e.CommandArgument.ToString());
                    str = this.gvResult.DataKeys[num].Value.ToString();
                    try
                    {
                        base.Response.Redirect("bzCCMx.aspx?CCXCDoType=look&UpdatePK=" + base.Request["UpdatePK"].ToString() + "&MXID=" + str + "&strTitle=" + base.Request["strTitle"].ToString());
                    }
                    catch
                    {
                        base.Response.Redirect("bzCCMx.aspx?CCXCDoType=look&UpdatePK=" + base.Request["UpdatePK"].ToString() + "&MXID=" + str + "&strTitle=项目建设资金巡查");
                    }
                }
            }
        }
    }

    protected void gvResult_Sorting(object sender, GridViewSortEventArgs e)
    {
    }

    private void HeDuiData(string PD_PROJECT_CODE)
    {
    }

    public void ListPageLoad(Page page, out ButtonsModel main_bm, string PD_PROJECT_CODE)
    {
        PublicDal.ShowMxButton(this.Page, out main_bm, "PD_PROJECT_INSPECTION", "AUTO_NO", PD_PROJECT_CODE, "PD_NOW_SERVERPK");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session["User"] == null)
        {
            Const.GoLoginPath_OpenWindow(this.Page);
        }
        else
        {
            if (base.Request["strTitle"] != null)
            {
                this.Master.strTitle = base.Request["strTitle"];
            }
            this.Master.strTitle = base.Request["strTitle"];
            this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
            this.BindImg();
            if (!base.IsPostBack)
            {
                this.Master.TabContainer1 = this.TabContainer1;
                ButtonsModel model = null;
                this.ListPageLoad(this.Page, out model, base.Request["UpdatePK"]);
                if ((base.Request["CCXCDoType"] == "look") || (base.Request["CCXCDoType"] == "looklist"))
                {
                    model.IfAdd = true;
                    model.IfUpdate = true;
                    model.IfDelete = true;
                    model.IfSave = false;
                }
                else if (base.Request["CCXCDoType"] == "update")
                {
                    model.IfAdd = false;
                    model.IfUpdate = false;
                    model.IfDelete = false;
                    model.IfSave = true;
                    PageShowText.Run_javascript("setTimeout(\"setMenuHeight()\", 0);", this.Page);
                }
                else if (base.Request["CCXCDoType"] == "add")
                {
                    model.IfAdd = false;
                    model.IfUpdate = false;
                    model.IfDelete = false;
                    model.IfSave = true;
                    this.gvResult.Enabled = false;
                }
                this.Master.btModel = model;
                this.BindDll();
                if ((base.Request["UpdatePK"] != null) && PublicDal.PageValidate.IsDecimal(base.Request["UpdatePK"]))
                {
                    this.ShowData(" PD_Project_Code = '" + base.Request["UpdatePK"].ToString() + "'");
                    if (this.gvResult.Rows.Count > 0)
                    {
                        model.IfPrintNote = true;
                        model.IbtPrintNoteText = "打印";
                        if (base.Request["CCXCDoType"] == "add")
                        {
                            this.ShowInfoProject(base.Request["UpdatePK"]);
                        }
                        else if ((base.Request["MXID"] != null) && PublicDal.PageValidate.IsInt(base.Request["MXID"]))
                        {
                            this.ShowInfo(Convert.ToInt32(base.Request["MXID"]));
                            for (int i = 0; i < this.gvResult.DataKeys.Count; i++)
                            {
                                if (this.gvResult.DataKeys[i].Value.ToString() == base.Request["MXID"])
                                {
                                    this.gvResult.SelectedIndex = i;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            string str = this.gvResult.DataKeys[this.gvResult.Rows.Count - 1].Value.ToString();
                            this.Session["PrintId"] = str;
                            this.Session["CCXCDoType"] = "add";
                            if (!string.IsNullOrEmpty(str))
                            {
                                this.ShowInfo(Convert.ToInt32(str));
                                this.gvResult.SelectedIndex = this.gvResult.Rows.Count - 1;
                                this.BindImg();
                            }
                            else
                            {
                                this.ShowData(" PD_Project_Code = '" + base.Request["UpdatePK"].ToString() + "'");
                                this.Session["CCXCDoType"] = "add";
                                model.IfUpdate = false;
                                model.IfDelete = false;
                                this.gvResult.Enabled = false;
                                str_MXID = "";
                                this.BindImg();
                            }
                        }
                    }
                    else
                    {
                        this.ShowData(base.Request["UpdatePK"].ToString());
                        this.Session["CCXCDoType"] = "add";
                    }
                }
            }
        }
    }

    private void PanDuan()
    {
    }

    private void Save()
    {
        PD_PROJECT_INSPECTION_Bll bll = new PD_PROJECT_INSPECTION_Bll();
        if (base.Request["CCXCDoType"] != null)
        {
            if (base.Request["CCXCDoType"] == "update")
            {
                if (PublicDal.PageValidate.IsDecimal(this.txtPD_PROJECT_CODE.Value))
                {
                    PD_PROJECT_INSPECTION_Model model = bll.GetModel(int.Parse(this.lblAUTO_NO.Text));
                    this.getModel(model);
                    if (bll.Update(model))
                    {
                        this.AddImgMethod(model);
                        Const.DoSuccessNoClose("修改成功", this.Page.Request.Url.LocalPath + "?CCXCDoType=look&UpdatePK=" + base.Request["UpdatePK"].ToString(), this.Page);
                    }
                    else
                    {
                        Const.DoSuccessNoClose("修改失败", this.Page.Request.Url.LocalPath + "?CCXCDoType=look&UpdatePK=" + base.Request["UpdatePK"].ToString(), this.Page);
                    }
                }
            }
            else if (base.Request["CCXCDoType"] == "add")
            {
                if (base.Request["UpdatePK"] != null)
                {
                    PD_PROJECT_INSPECTION_Model model2 = new PD_PROJECT_INSPECTION_Model
                    {
                        PD_DB_LOOP = "1",
                        PD_NOW_SERVERPK = PublicDal.SetCreateServiceStream(this.Page)
                    };
                    this.getModel(model2);
                    this.txt_file.Text.ToString();
                    if (bll.Add(model2))
                    {
                        this.AddImgMethod(model2);
                        Const.DoSuccessNoClose("添加成功", this.Page.Request.Url.LocalPath + "?CCXCDoType=look&UpdatePK=" + model2.PD_PROJECT_CODE + "&strTitle=" + base.Request["strTitle"].ToString(), this.Page);
                    }
                    else
                    {
                        Const.DoSuccessNoClose("添加失败", this.Page.Request.Url.LocalPath + "?CCXCDoType=look&UpdatePK=" + base.Request["UpdatePK"].ToString(), this.Page);
                    }
                }
                else
                {
                    PageShowText.Refurbish("主项目信息不明确", this.Page);
                }
            }
        }
    }

    public void SetServiceStream(int operation, string AUTO_NO, string Mess)
    {
        PublicDal.SetServiceStream(this.Page, operation, "PD_PROJECT_INSPECTION", "AUTO_NO", AUTO_NO, Mess, "PD_NOW_SERVERPK");
    }

    public bool ShowData(string str)
    {
        try
        {
            TB_PROJECT_Model model = new TB_PROJECT_Bll().GetModel(base.Request["UpdatePK"].ToString());
            this.txtPD_PROJECT_Name.Value = model.PD_PROJECT_NAME;
            this.txtPD_PROJECT_CODE.Value = model.PD_PROJECT_CODE;
            this.dbo = new DB_OPT();
            this.dbo.Open();
            string companyWhere = PublicDal.GetCompanyWhere();
            if (str != "")
            {
                str = " where " + str + " and  pd_found_xz='02' " + companyWhere;
            }
            else
            {
                str = "where  pd_found_xz='02' " + companyWhere;
            }
            str = "select " + this.getColumns() + " from  view_inspection_list " + str + " order by pd_project_code,auto_no desc ";
            DataSet set = DbHelperOra.Query(str);
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                DataView defaultView = set.Tables[0].DefaultView;
                if ((this.ViewState["SortOrder"] != null) && (this.ViewState["OrderDire"] != null))
                {
                    string str3 = ((string)this.ViewState["SortOrder"]) + " " + ((string)this.ViewState["OrderDire"]);
                    defaultView.Sort = str3;
                }
                this.gvResult.DataSource = defaultView;
                this.gvResult.DataBind();
                return true;
            }
            DataTable table = new DataTable();
            table = set.Tables[0];
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            this.gvResult.DataSource = table.DefaultView;
            this.gvResult.DataBind();
            return false;
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
        return false;
    }

    private void ShowInfo(int AUTO_NO_XC)
    {
        this.Session["PrintId"] = AUTO_NO_XC.ToString();
        PD_PROJECT_INSPECTION_Model model = new PD_PROJECT_INSPECTION_Bll().GetModel(AUTO_NO_XC);
        if (model != null)
        {
            TB_PROJECT_Model model2 = new TB_PROJECT_Bll().GetModel(model.PD_PROJECT_CODE);
            this.lblAUTO_NO.Text = model.AUTO_NO.ToString();
            str_MXID = this.lblAUTO_NO.Text;
            this.txtPD_PROJECT_CODE.Value = model.PD_PROJECT_CODE;
            this.txtPD_PROJECT_Name.Value = model2.PD_PROJECT_NAME;
            this.txtPD_INSPECTION_PROCESS.SelectedValue = model.PD_INSPECTION_PROCESS;
            this.txtPD_INSPECTION_DATE.Value = model.PD_INSPECTION_DATE.ToString();
            this.txtPD_INSPECTION_MANS.Text = model.PD_INSPECTION_MANS;
            this.txtPD_INSPECTION_ADDR.Text = model.PD_INSPECTION_ADDR;
            this.txtPD_INSPECTION_CONTENT.Text = model.PD_INSPECTION_CONTENT;
            this.txtPD_INSPECTION_SUGGEST.Text = model.PD_INSPECTION_SUGGEST;
            this.txtPD_INSPECTION_CONCLUSION.Text = model.PD_INSPECTION_CONCLUSION;
            this.txtPD_INSPECTION_PEASANT.Text = model.PD_INSPECTION_PEASANT;
            this.txtPD_INSPECTION_IDNO.Text = model.PD_INSPECTION_IDNO;
            this.txtPD_INSPECTION_FFNUM.Text = model.PD_INSPECTION_FFNUM.ToString();
            this.txtPD_INSPECTION_FFSTAND.Text = Convert.ToDecimal(!model.PD_INSPECTION_FFSTAND.HasValue ? 0 : model.PD_INSPECTION_FFSTAND).ToString("F2");
            this.txtPD_INSPECTION_FFMONEY.Text = Convert.ToDecimal(!model.PD_INSPECTION_FFMONEY.HasValue ? 0 : model.PD_INSPECTION_FFMONEY).ToString("F2");
            this.txtPD_INSPECTION_ACCOUNTNO.Text = model.PD_INSPECTION_ACCOUNTNO;
            this.txtPD_INSPECTION_PEASANT_ADDR.Text = model.PD_INSPECTION_PEASANT_ADDR;
            this.txtPD_MONITOR_TOTAL_MONEY_PAY.Text = model.PD_MONITOR_TOTAL_MONEY_PAY.Value.ToString();
            if (model.PD_BZFFLIST_DATE.HasValue)
            {
                this.txtPD_DB_LOOP.Text = model.PD_DB_LOOP;
            }
            this.ddlPD_YEAR.SelectedValue = model.PD_YEAR;
            DataSet ds = new DataSet();
            ds.Tables.Add();
            ds.Tables[0].Columns.Add("AUTO_NO");
            ds.Tables[0].Columns.Add("FILE_NAME");
            ds.Tables[0].Columns.Add("FILE_SYSNAME");
            if (((model != null) && (model.PD_INSPECTION_FILENAME_SYSTEM != null)) && (model.PD_INSPECTION_FILENAME_SYSTEM.Trim() != ""))
            {
                DataRow row = ds.Tables[0].NewRow();
                row["AUTO_NO"] = model.AUTO_NO;
                row["FILE_NAME"] = model.PD_INSPECTION_FILENAME;
                row["FILE_SYSNAME"] = model.PD_INSPECTION_FILENAME_SYSTEM;
                ds.Tables[0].Rows.Add(row);
            }
            this.json_btData.Value = PublicDal.DataToJSON(ds);
            this.BindImg();
        }
    }

    private void ShowInfoProject(string ProjectCode)
    {
        TB_PROJECT_Model model = new TB_PROJECT_Bll().GetModel(ProjectCode);
        this.txtPD_PROJECT_CODE.Value = model.PD_PROJECT_CODE;
        this.txtPD_PROJECT_Name.Value = model.PD_PROJECT_NAME;
        this.ddlPD_YEAR.SelectedValue = model.PD_YEAR.ToString();
    }

    private void Update()
    {
        this.Session["CCXCDoType"] = "update";
        if (this.gvResult.SelectedIndex == -1)
        {
            PageShowText.Run_javascript("alert('需要先选择一条记录才能进行修改，请在下面的表格中选择后再进行操作！');setTimeout(\"setMenuHeight()\", 0);", this.Page);
        }
        else
        {
            string str = this.gvResult.SelectedValue.ToString();
            PageShowText.GoToPage(string.Concat(new object[] { this.Page.Request.Url.LocalPath, "?MXIndex=", this.gvResult.SelectedIndex, "&MXID=", str, "&CCXCDoType=update&UpdatePK=", base.Request.Params["UpdatePK"].ToString(), "&strTitle=", base.Request["strTitle"].ToString() }), this.Page);
            this.ShowData(" PD_Project_Code = '" + base.Request["UpdatePK"].ToString() + "'");
        }
    }

    [WebMethod]
    public static int UpdateImgDscript(string value1, string value2, string value3)
    {
        string str2 = value2;
        str2 = str2.Substring(str2.LastIndexOf("/")).Replace("/", "");
        if (!string.IsNullOrEmpty(str_MXID))
        {
            return DbHelperOra.ExecuteSql("update t_photos set remarks='" + value1 + "' where fkid='bzCCXCMX_" + str_MXID + "'and photoname='" + value3 + "'");
        }
        return 0;
    }

    protected void UploadButton_Click(object sender, EventArgs e)
    {
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public MainMX_cs Master
    {
        get
        {
            return (MainMX_cs)base.Master;
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
