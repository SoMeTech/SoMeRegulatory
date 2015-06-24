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

public class Work_BZ_GKGS_BZGKGSMX : Page, IRequiresSessionState
{
    private DB_OPT dbo;
    public static DataSet dssource = null;
    private ExceptionLog.ExceptionLog el;
    protected UserControls_FilePostCtr FilePostCtr1;
    protected SmartGridView gvResult;
    protected HtmlInputHidden json_btData;
    protected Label lblAUTO_NO;
    protected Label lblGKGSAUTO_NO;
    public static int num = 0;
    protected TabPanel Panel_xmgk;
    public static int select_autoid = 0;
    private string str = "";
    public static string str_MXID = "";
    protected TabContainer TabContainer1;
    protected TextBox txt_file;
    protected HtmlInputHidden txtindex;
    protected HtmlInputText txtPD_GS_ADDR;
    protected HtmlInputText txtPD_GS_DATE;
    protected HtmlInputText txtPD_GS_DATE_END;
    protected HtmlInputText txtPD_GS_DETAIL;
    protected HtmlInputText txtPD_GS_STYLE;
    protected DropDownList txtPD_GS_TYPE;
    protected HtmlInputText txtPD_GS_ZHUTI;
    protected HtmlInputText txtPD_JB_TELEPHONE;
    protected TextBox txtPD_PROJECT_BZDX;
    protected HtmlInputText txtPD_PROJECT_BZMONEY;
    protected HtmlInputText txtPD_PROJECT_BZNUM;
    protected TextBox txtPD_PROJECT_BZSTAND_NUM;
    protected HtmlInputText txtPD_PROJECT_CODE;
    protected TextBox txtPD_PROJECT_FILENO_JG;
    protected TextBox txtPD_PROJECT_NAME;
    protected HtmlInputText txtPD_YEAR;
    protected HtmlInputHidden txttitle;
    protected HtmlGenericControl ulimg;
    protected HtmlTable zxzb_bt;

    private void Add()
    {
        PageShowText.Run_javascript("setcolor()", this.Page);
    }

    private void AddImgMethod(PD_PROJECT_GKGS_Model model)
    {
        try
        {
            str = this.txt_file.Text.ToString();
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
                DbHelperOra.ExecuteSql(string.Concat(new object[] { "insert into t_photos (fkid, photoname, photopath, remarks, sortid) values  ( 'BZssGKGS_", model.AUTO_NO, "', '", str3, "', '", str, "', '", str3, "', 1)" }));
            }
        }
        catch (Exception)
        {
        }
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
            DataSet set = DbHelperOra.Query("select * from t_photos where fkid='BZssGKGS_" + str_MXID + "'");
            if (base.Request["doType"].ToString() == "add")
            {
                set = null;
            }
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

    public void Buttons(string ibtid)
    {
        string str;
        switch (ibtid)
        {
            case "ibtcontrol_ibtadd":
                this.Add();
                str = base.Request.Params["UpdatePK"].ToString();
                str_MXID = "";
                base.Response.Redirect(this.Page.Request.Url.LocalPath + "?doType=add&UpdatePK=" + str + "&strTitle=" + base.Request["strTitle"].ToString());
                return;

            case "ibtcontrol_ibtupdate":
                this.Update();
                str = base.Request.Params["UpdatePK"].ToString();
                base.Response.Redirect(this.Page.Request.Url.LocalPath + "?doType=update&UpdatePK=" + str + "&strTitle=" + base.Request["strTitle"].ToString());
                this.ShowInfo_Project(base.Request["UpdatePK"].ToString());
                return;

            case "ibtcontrol_ibtdelete":
                this.Delete();
                this.ShowInfo_Project(base.Request["UpdatePK"].ToString());
                return;

            case "ibtcontrol_ibtsave":
                this.Save();
                break;

            case "ibtcontrol_ibtrefresh":
            case "ibtcontrol_ibtaudit":
            case "ibtcontrol_ibtapply":
            case "ibtcontrol_ibtsetback":
            case "ibtcontrol_ibtrollback":
                break;

            default:
                return;
        }
    }

    private void clearInfo()
    {
        this.txtPD_GS_TYPE.SelectedValue = "";
        this.txtPD_GS_STYLE.Value = "";
        this.txtPD_GS_ZHUTI.Value = "";
        this.txtPD_GS_DATE.Value = "";
        this.txtPD_GS_DATE_END.Value = "";
        this.txtPD_GS_ADDR.Value = "";
        this.txtPD_GS_DETAIL.Value = "";
    }

    private void Delete()
    {
        if (this.lblGKGSAUTO_NO.Text != "")
        {
            new PD_PROJECT_GKGS_Bll().Delete(Convert.ToInt32(this.lblGKGSAUTO_NO.Text));
            Const.DoSuccessNoClose("删除成功", this.Page.Request.Url.LocalPath + "?doType=look&UpdatePK=" + base.Request["UpdatePK"].ToString(), this.Page);
        }
    }

    [WebMethod]
    public static int DelImg(string value1)
    {
        if (!string.IsNullOrEmpty(str_MXID))
        {
            return DbHelperOra.ExecuteSql("delete from t_photos   where fkid='BZssGKGS_" + str_MXID + "' and PHOTONAME='" + value1.Trim() + "'");
        }
        return 0;
    }

    private string getColumns()
    {
        return "  auto_no, pd_project_code, pd_gs_type, pd_gs_style, pd_gs_zhuti, pd_gs_date,pd_gs_date_end, pd_gs_addr, pd_gs_filename, pd_gs_filename_system, pd_gs_detail, pd_project_fileno_zb, pd_project_name, pd_year, pd_project_type, pd_project_type_name, pd_gk_depart_id, pd_gk_depart, pd_found_xz, pd_project_money_total, pd_project_money_cz_total, pd_project_money_cz_sj, pd_project_money_cz_bj, pd_project_money_zc, pd_project_money_qt, pd_project_money_addr, pd_project_content, pd_project_xmyt, pd_project_ifxzgl, pd_project_ifgs, pd_project_ifgs_before, pd_project_open_body, pd_project_fzr, pd_project_cwfzr, pd_project_status, pd_project_begin_date, pd_project_end_date, pd_project_years, pd_project_check_date, pd_project_fileno_lx, pd_project_fileno_jg, pd_project_input_company, pd_project_input_man, pd_project_input_date, pd_project_reply_company, pd_project_reply_man2, pd_project_check_company, pd_project_chenck_man, pd_project_money_total_pf, pd_project_reply_date, pd_project_money_cz_total_pf, pd_project_money_cz_sj_pf, pd_project_money_cz_bj_pf, pd_project_money_zc_pf, pd_project_money_qt_pf, pd_project_country, pd_project_village, pd_project_group, pd_project_fileno_pf, pd_proj_status, pd_proj_last_audit_status, pd_is_return, pd_isout_quota, pd_project_bzyj, pd_project_bzfw, pd_project_bzdx, pd_project_bznum, pd_project_bzstand_num, pd_project_bzmoney, pd_project_syrs, pd_project_bzff_date, pd_project_sjff_date, pd_project_ifff, pd_project_jgyq, pd_project_jgjl, pd_project_jg_result, pd_project_jg_suggest, pd_project_syhs, pd_project_gnfl, pd_project_gnfl_code, pd_project_serverpk, pd_project_jjfl, pd_quota_code, pd_project_zjly, pd_project_zgkj, pd_project_isbxk, pd_project_jbdh ";
    }

    protected string getComfirm(object obj)
    {
        string str = obj.ToString();
        string str2 = "";
        string str3 = str;
        if (str3 == null)
        {
            return str2;
        }
        if (!(str3 == "1"))
        {
            if (str3 != "2")
            {
                if (str3 != "3")
                {
                    return str2;
                }
                return "事后";
            }
        }
        else
        {
            return "事前";
        }
        return "事中";
    }

    private void getModel(PD_PROJECT_GKGS_Model model)
    {
        model.PD_PROJECT_CODE = this.txtPD_PROJECT_CODE.Value;
        model.PD_GS_ADDR = this.txtPD_GS_ADDR.Value;
        if (PublicDal.PageValidate.IsDateTime(this.txtPD_GS_DATE.Value))
        {
            model.PD_GS_DATE = new DateTime?(DateTime.Parse(this.txtPD_GS_DATE.Value));
        }
        if (PublicDal.PageValidate.IsDateTime(this.txtPD_GS_DATE_END.Value))
        {
            model.PD_GS_DATE_END = new DateTime?(DateTime.Parse(this.txtPD_GS_DATE_END.Value));
        }
        model.PD_GS_DETAIL = this.txtPD_GS_DETAIL.Value.ToString();
        model.PD_GS_STYLE = this.txtPD_GS_STYLE.Value.ToString();
        model.PD_GS_TYPE = new int?(Convert.ToInt32(this.txtPD_GS_TYPE.SelectedValue.ToString()));
        model.PD_GS_ZHUTI = this.txtPD_GS_ZHUTI.Value.ToString();
        model.PD_PROJECT_CODE = this.txtPD_PROJECT_CODE.Value.ToString();
        this.GetQUOTA(model);
    }

    private void GetQUOTA(PD_PROJECT_GKGS_Model model)
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
                model.PD_GS_FILENAME = defaultView[0]["FileName"].ToString();
                model.PD_GS_FILENAME_SYSTEM = defaultView[0]["FileSysName"].ToString();
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
            string userName = ((UserModel)this.Session["User"]).UserName;
            string power = ((UserModel)this.Session["User"]).Power;
            if (Public.IsNumber(e.CommandArgument.ToString()))
            {
                num = int.Parse(e.CommandArgument.ToString());
                if (num >= 5)
                {
                    this.txtindex.Value = (num - 2).ToString();
                }
                else
                {
                    this.txtindex.Value = "0";
                }
            }
            string commandName = e.CommandName;
            if (commandName != null)
            {
                if (!(commandName == "Select"))
                {
                    if (!(commandName == "Two"))
                    {
                        bool flag1 = commandName == "Sort";
                    }
                }
                else
                {
                    num = int.Parse(e.CommandArgument.ToString());
                    this.str = this.gvResult.DataKeys[num].Value.ToString();
                    string url = this.Page.Request.Url.LocalPath + "?UpdatePK=" + base.Request["UpdatePK"].ToString() + "&GS_ID=" + this.gvResult.DataKeys[num].Value.ToString() + "&MXID=" + this.str + "&doType=look&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim());
                    this.Page.Response.Redirect(url);
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
                str = txt_file.Text.ToString();
                ButtonsModel model = null;
                PublicDal.ShowListButton(this.Page, out model, "");
                this.Master.TabContainer1 = this.TabContainer1;
                if ((base.Request["doType"] == "look") || (base.Request["doType"] == "looklist"))
                {
                    model.IfAdd = true;
                    model.IfUpdate = true;
                    model.IfDelete = true;
                    model.IfSave = false;
                }
                else if (base.Request["doType"] == "update")
                {
                    model.IfAdd = false;
                    model.IfUpdate = false;
                    model.IfDelete = false;
                    model.IfSave = true;
                }
                else if (base.Request["doType"] == "add")
                {
                    model.IfAdd = false;
                    model.IfUpdate = false;
                    model.IfDelete = false;
                    model.IfSave = true;
                }
                this.Master.btModel = model;
                if ((base.Request["UpdatePK"] != null) && PublicDal.PageValidate.IsDecimal(base.Request["UpdatePK"]))
                {
                    string str8 = "";
                    this.ShowData(" PD_Project_Code = '" + base.Request["UpdatePK"].ToString() + "'");
                    if (base.Request["doType"] == "add")
                    {
                        this.ShowInfo_Project(base.Request["UpdatePK"].ToString());
                        this.clearInfo();
                    }
                    else
                    {
                        if (base.Request["doType"] == "look")
                        {
                            try
                            {
                                str8 = base.Request["GS_ID"].ToString();
                                select_autoid = Convert.ToInt32(str8);
                            }
                            catch
                            {
                            }
                        }
                        else if (base.Request["doType"] == "looklist")
                        {
                            if ((this.gvResult.Rows.Count > 0) && (this.gvResult.Rows[0].Cells[0].Text != ""))
                            {
                                str8 = this.gvResult.DataKeys[this.gvResult.Rows.Count - 1].Value.ToString();
                            }
                            else
                            {
                                this.ShowInfo_Project(base.Request["UpdatePK"].ToString());
                            }
                        }
                        if (!string.IsNullOrEmpty(str8))
                        {
                            this.ShowInfo(Convert.ToInt32(str8));
                        }
                        else
                        {
                            this.ShowInfo_Project(base.Request["UpdatePK"].ToString());
                            if (dssource == null)
                            {
                                this.Session["doType"] = "add";
                                model.IfUpdate = false;
                                model.IfDelete = false;
                                this.gvResult.Enabled = false;
                                str_MXID = "";
                                this.BindImg();
                            }
                        }
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
        PD_PROJECT_GKGS_Bll bll = new PD_PROJECT_GKGS_Bll();
        if (base.Request["doType"] == "add")
        {
            if (this.txtPD_PROJECT_CODE.Value != null)
            {
                PD_PROJECT_GKGS_Model model = new PD_PROJECT_GKGS_Model();
                this.getModel(model);
                if (bll.Add(model))
                {
                    this.AddImgMethod(model);
                    Const.DoSuccessNoClose("添加成功", this.Page.Request.Url.LocalPath + "?doType=look&UpdatePK=" + model.PD_PROJECT_CODE, this.Page);
                }
                else
                {
                    Const.DoSuccessNoClose("添加成功", this.Page.Request.Url.LocalPath + "?doType=look&UpdatePK=" + base.Request["UpdatePK"].ToString(), this.Page);
                }
            }
        }
        else if (base.Request["DoType"].ToString() == "update")
        {
            if (PublicDal.PageValidate.IsDecimal(this.lblAUTO_NO.Text))
            {
                PD_PROJECT_GKGS_Model model2 = bll.GetModel(int.Parse(this.lblAUTO_NO.Text));
                this.getModel(model2);
                if (bll.Update(model2))
                {
                    this.AddImgMethod(model2);
                    Const.DoSuccessNoClose("修改成功", this.Page.Request.Url.LocalPath + "?doType=look&UpdatePK=" + base.Request["UpdatePK"].ToString(), this.Page);
                }
                else
                {
                    Const.DoSuccessNoClose("修改失败", this.Page.Request.Url.LocalPath + "?doType=look&UpdatePK=" + base.Request["UpdatePK"].ToString(), this.Page);
                }
            }
        }
        else if (this.txtPD_PROJECT_CODE.Value != null)
        {
            PD_PROJECT_GKGS_Model model3 = new PD_PROJECT_GKGS_Model();
            this.getModel(model3);
            if (bll.Add(model3))
            {
                this.AddImgMethod(model3);
                Const.DoSuccessNoClose("添加成功", this.Page.Request.Url.LocalPath + "?doType=look&UpdatePK=" + model3.PD_PROJECT_CODE, this.Page);
            }
            Const.DoSuccessNoClose("添加成功", this.Page.Request.Url.LocalPath + "?doType=look&UpdatePK=" + model3.PD_PROJECT_CODE, this.Page);
        }
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
                str = " where " + str + " and  pd_found_xz='02' " + companyWhere;
            }
            else
            {
                str = "where  pd_found_xz='02' " + companyWhere;
            }
            str = "select " + this.getColumns() + " from  view_pd_project_gkgs " + str + " order by pd_project_code,auto_no desc ";
            DataSet set = DbHelperOra.Query(str);
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                DataView defaultView = set.Tables[0].DefaultView;
                if ((this.ViewState["SortOrder"] != null) && (this.ViewState["OrderDire"] != null))
                {
                    string str3 = ((string)this.ViewState["SortOrder"]) + " " + ((string)this.ViewState["OrderDire"]);
                    defaultView.Sort = str3;
                }
                this.TabContainer1.Height = (set.Tables[0].Rows.Count * 0x15) + 0x31;
                this.gvResult.DataSource = defaultView;
                this.gvResult.DataBind();
                dssource = set;
            }
            else
            {
                DataTable table = new DataTable();
                table = set.Tables[0];
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                this.gvResult.DataSource = table.DefaultView;
                this.gvResult.DataBind();
                dssource = null;
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

    private void ShowInfo(int AUTO_NO_GS)
    {
        this.ShowInfo_Project(base.Request["UpdatePK"].ToString());
        PD_PROJECT_GKGS_Model model = new PD_PROJECT_GKGS_Bll().GetModel(AUTO_NO_GS);
        TB_PROJECT_Model model2 = new TB_PROJECT_Bll().GetModel(model.PD_PROJECT_CODE);
        this.lblGKGSAUTO_NO.Text = model.AUTO_NO.ToString();
        this.lblAUTO_NO.Text = model.PD_PROJECT_CODE.ToString();
        str_MXID = model.AUTO_NO.ToString();
        this.txtPD_GS_ADDR.Value = model.PD_GS_ADDR.ToString();
        this.txtPD_GS_DATE.Value = model.PD_GS_DATE.Value.ToString();
        this.txtPD_GS_DATE_END.Value = model.PD_GS_DATE_END.Value.ToString();
        this.txtPD_GS_STYLE.Value = model.PD_GS_STYLE.ToString();
        this.txtPD_GS_TYPE.SelectedValue = model.PD_GS_TYPE.Value.ToString();
        this.txtPD_GS_ZHUTI.Value = model.PD_GS_ZHUTI.ToString();
        this.txtPD_GS_DETAIL.Value = model.PD_GS_DETAIL.ToString();
        this.txtPD_PROJECT_CODE.Value = model2.PD_PROJECT_CODE.ToString();
        this.txtPD_JB_TELEPHONE.Value = model2.PD_JB_TELEPHONE.ToString();
        this.txtPD_PROJECT_BZDX.Text = model2.PD_PROJECT_BZDX.ToString();
        try
        {
            this.txtPD_PROJECT_BZMONEY.Value = model2.PD_PROJECT_BZMONEY.Value.ToString();
            this.txtPD_PROJECT_BZNUM.Value = model2.PD_PROJECT_BZNUM.Value.ToString();
        }
        catch
        {
            this.txtPD_PROJECT_BZMONEY.Value = "0";
            this.txtPD_PROJECT_BZNUM.Value = "0";
        }
        this.txtPD_PROJECT_BZSTAND_NUM.Text = model2.PD_PROJECT_BZSTAND_NUM.ToString();
        this.txtPD_PROJECT_FILENO_JG.Text = model2.PD_PROJECT_BZYJ.ToString();
        this.txtPD_PROJECT_NAME.Text = model2.PD_PROJECT_NAME.ToString();
        this.txtPD_YEAR.Value = model2.PD_YEAR.Value.ToString();
        DataSet ds = new DataSet();
        ds.Tables.Add();
        ds.Tables[0].Columns.Add("AUTO_NO");
        ds.Tables[0].Columns.Add("FILE_NAME");
        ds.Tables[0].Columns.Add("FILE_SYSNAME");
        if (((model != null) && (model.PD_GS_FILENAME_SYSTEM != null)) && (model.PD_GS_FILENAME_SYSTEM.Trim() != ""))
        {
            DataRow row = ds.Tables[0].NewRow();
            row["AUTO_NO"] = model.AUTO_NO;
            row["FILE_NAME"] = model.PD_GS_FILENAME;
            row["FILE_SYSNAME"] = model.PD_GS_FILENAME_SYSTEM;
            ds.Tables[0].Rows.Add(row);
        }
        this.json_btData.Value = PublicDal.DataToJSON(ds);
    }

    private void ShowInfo_Project(string PD_PROJECT_CODE)
    {
        TB_PROJECT_Model model = new TB_PROJECT_Bll().GetModel(PD_PROJECT_CODE);
        this.txtPD_PROJECT_CODE.Value = model.PD_PROJECT_CODE.ToString();
        if (model.PD_JB_TELEPHONE != null)
        {
            this.txtPD_JB_TELEPHONE.Value = model.PD_JB_TELEPHONE.ToString();
        }
        if (model.PD_PROJECT_BZDX != null)
        {
            this.txtPD_PROJECT_BZDX.Text = model.PD_PROJECT_BZDX.ToString();
        }
        if (model.PD_PROJECT_BZMONEY.HasValue)
        {
            this.txtPD_PROJECT_BZMONEY.Value = model.PD_PROJECT_BZMONEY.Value.ToString();
        }
        if (model.PD_PROJECT_BZNUM.HasValue)
        {
            this.txtPD_PROJECT_BZNUM.Value = model.PD_PROJECT_BZNUM.Value.ToString();
        }
        if (model.PD_PROJECT_BZSTAND_NUM != null)
        {
            this.txtPD_PROJECT_BZSTAND_NUM.Text = model.PD_PROJECT_BZSTAND_NUM.ToString();
        }
        if (model.PD_PROJECT_FILENO_JG != null)
        {
            this.txtPD_PROJECT_FILENO_JG.Text = model.PD_PROJECT_FILENO_JG.ToString();
        }
        this.txtPD_PROJECT_NAME.Text = model.PD_PROJECT_NAME.ToString();
        this.txtPD_YEAR.Value = model.PD_YEAR.Value.ToString();
        string sQLString = "";
        int num = 0;
        try
        {
            num = Convert.ToInt32(this.gvResult.DataKeys[Work_BZ_GKGS_BZGKGSMX.num].Value.ToString());
            sQLString = string.Concat(new object[] { "select * from view_pd_project_gkgs where pd_project_code='", PD_PROJECT_CODE, "' and auto_no=", num });
        }
        catch
        {
            sQLString = "select * from view_pd_project_gkgs where pd_project_code='" + PD_PROJECT_CODE + "'";
        }
        DataSet set = DbHelperOra.Query(sQLString);
        if ((set != null) && (set.Tables[0].Rows.Count > 0))
        {
            this.lblAUTO_NO.Text = set.Tables[0].Rows[0]["auto_no"].ToString();
            this.lblGKGSAUTO_NO.Text = set.Tables[0].Rows[0]["auto_no"].ToString();
            str_MXID = this.lblAUTO_NO.Text;
            this.txtPD_GS_TYPE.SelectedValue = set.Tables[0].Rows[0]["PD_GS_TYPE"].ToString();
            this.txtPD_GS_STYLE.Value = set.Tables[0].Rows[0]["PD_GS_STYLE"].ToString();
            this.txtPD_GS_ZHUTI.Value = set.Tables[0].Rows[0]["PD_GS_ZHUTI"].ToString();
            this.txtPD_GS_DATE.Value = set.Tables[0].Rows[0]["PD_GS_DATE"].ToString();
            this.txtPD_GS_DATE_END.Value = set.Tables[0].Rows[0]["PD_GS_DATE_END"].ToString();
            this.txtPD_GS_ADDR.Value = set.Tables[0].Rows[0]["PD_GS_ADDR"].ToString();
            this.txtPD_GS_DETAIL.Value = set.Tables[0].Rows[0]["PD_GS_DETAIL"].ToString();
            DataSet ds = new DataSet();
            ds.Tables.Add();
            ds.Tables[0].Columns.Add("AUTO_NO");
            ds.Tables[0].Columns.Add("FILE_NAME");
            ds.Tables[0].Columns.Add("FILE_SYSNAME");
            if (((set != null) && (set.Tables[0].Rows[0]["PD_GS_FILENAME"].ToString() != null)) && (set.Tables[0].Rows[0]["PD_GS_FILENAME_SYSTEM"].ToString().Trim() != ""))
            {
                DataRow row = ds.Tables[0].NewRow();
                row["AUTO_NO"] = set.Tables[0].Rows[0]["AUTO_NO"].ToString();
                row["FILE_NAME"] = set.Tables[0].Rows[0]["PD_GS_FILENAME"].ToString();
                row["FILE_SYSNAME"] = set.Tables[0].Rows[0]["PD_GS_FILENAME_SYSTEM"].ToString();
                ds.Tables[0].Rows.Add(row);
            }
            this.json_btData.Value = PublicDal.DataToJSON(ds);
            this.BindImg();
        }
    }

    private void Update()
    {
        PageShowText.Run_javascript("setcolor()", this.Page);
    }

    [WebMethod]
    public static int UpdateImgDscript(string value1, string value2, string value3)
    {
        if (!string.IsNullOrEmpty(str_MXID))
        {
            return DbHelperOra.ExecuteSql("update t_photos set remarks='" + value1 + "' where fkid='BZssGKGS_" + str_MXID + "' and photoname='" + value3 + "'");
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
