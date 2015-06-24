using AjaxControlToolkit;
using ASP;
using ExtExtenders;
using SoMeTech.CommonDll;
using SoMeTech.YZXWPageClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.IO;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using YYControls;
using SMZJ.BLL;
using SMZJ.Model;

public class Work_projectBZ_projBzZhiBiaoOper : Page, IRequiresSessionState
{
    private TB_QUOTA_Bll bll = new TB_QUOTA_Bll();
    protected CalendarExtender CalendarExtender2;
    protected CalendarExtender CalendarExtender3;
    protected DropDownList ddlPD_IS_RETURN;
    protected DropDownList ddlPD_ISOUT_QUOTA;
    protected DropDownList ddlPD_PROJ_LAST_AUDIT_STATUS;
    protected DropDownList ddlPD_PROJ_STATUS;
    protected DropDownList ddlPD_QUOTA_ACCEPT_COMPANY;
    protected DropDownList ddlPD_QUOTA_DEPART;
    protected DropDownList ddlPD_QUOTA_IFLLYQS;
    protected DropDownList ddlPD_QUOTA_IFPASS;
    protected DropDownList ddlPD_QUOTA_IFUP;
    protected DropDownList ddlPD_QUOTA_IFXZQS;
    protected DropDownList ddlPD_QUOTA_INPUT_COMPANY;
    protected DropDownList ddlPD_QUOTA_XZ_ACCEPT_COMPANY;
    protected DropDownList ddlPD_QUOTA_ZJXZ;
    protected DropDownList ddlPD_YEAR;
    protected UserControls_FilePostCtr FilePostCtr1;
    protected ImageButton ImageButton2;
    protected ImageButton ImageButton3;
    public string json_btData = "";
    public string json_xzxx = "";
    public string json_xzxxData = "";
    protected Label lblAUTO_ID;
    protected ExtExtenders.TabPanel Panel_JBXX;
    protected ExtExtenders.TabPanel Panel_xzxx;
    public string strid = "";
    protected ExtExtenders.TabContainer TabContainer11;
    protected DataTable tbFile = new DataTable();
    private DataTable tbXiangZhen = new DataTable();
    protected TextBox txtPD_QUOTA_ACCEPT_DATE;
    protected TextBox txtPD_QUOTA_ACCEPT_MAN;
    protected TextBox txtPD_QUOTA_BASIS;
    protected TextBox txtPD_QUOTA_BASIS_JG;
    protected TextBox txtPD_QUOTA_CODE;
    protected TextBox txtPD_QUOTA_INPUT_DATE;
    protected TextBox txtPD_QUOTA_INPUT_MAN;
    protected TextBox txtPD_QUOTA_JGYQ;
    protected TextBox txtPD_QUOTA_LWJG;
    protected TextBox txtPD_QUOTA_LWJG_NAME;
    protected TextBox txtPD_QUOTA_MONEY_TOTAL;
    protected TextBox txtPD_QUOTA_NAME;
    protected TextBox txtPD_QUOTA_PASS_DATE;
    protected TextBox txtPD_QUOTA_PASS_MAN;
    protected TextBox txtPD_QUOTA_STANDARD;
    protected TextBox txtPD_QUOTA_TARGET;
    protected TextBox txtPD_QUOTA_XZ_ACCEPT_DATE;
    protected TextBox txtPD_QUOTA_XZ_ACCEPT_MAN;
    protected HtmlTableCell wj;

    private void Bind1(string PD_QUOTA_CODE, TB_QUOTA_Model model)
    {
        DataSet list = new SMZJ.BLL.TB_QUOTA_DETAIL().GetList(" PD_QUOTA_CODE='" + PD_QUOTA_CODE + "'");
        this.json_xzxxData = PublicDal.DataToJSON(list);
        if (list.Tables[0].Rows.Count > 0)
        {
            list.Tables[0].Rows.Clear();
        }
        DataRow row = list.Tables[0].NewRow();
        row["PD_QUOTA_CODE"] = PD_QUOTA_CODE;
        list.Tables[0].Rows.Add(row);
        this.json_xzxx = PublicDal.DataToJSON(list);
        DataSet ds = new DataSet();
        ds.Tables.Add();
        ds.Tables[0].Columns.Add("AUTO_NO");
        ds.Tables[0].Columns.Add("FILE_NAME");
        ds.Tables[0].Columns.Add("FILE_SYSNAME");
        if (model != null)
        {
            string[] strArray = model.PD_QUOTA_FILE.Split(new char[] { '|' });
            if (strArray.Length > 1)
            {
                DataRow row2 = ds.Tables[0].NewRow();
                row2["AUTO_NO"] = model.AUTO_NO;
                row2["FILE_NAME"] = strArray[1];
                row2["FILE_SYSNAME"] = strArray[0];
                ds.Tables[0].Rows.Add(row2);
            }
        }
        this.json_btData = PublicDal.DataToJSON(ds);
    }

    private void BindDDList()
    {
        PublicDal.BindDropDownList(this.ddlPD_YEAR, "PD_BASE_YEAR", "YEAR_NAME", "YEAR_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_QUOTA_ZJXZ, "PD_BASE_FOUND_PROPERTY", "FOUND_PROPERTY_NAME", "FOUND_PROPERTY_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_QUOTA_IFUP, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_QUOTA_IFXZQS, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_QUOTA_IFPASS, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_QUOTA_IFLLYQS, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_QUOTA_DEPART, "DB_Company", "NAME", "PK_CORP", " ZXBJ=0");
        PublicDal.BindDropDownList(this.ddlPD_PROJ_STATUS, "PD_BASE_CheckStatus", "CheckStatus_Name", "CheckStatus_Code", "");
        PublicDal.BindDropDownList(this.ddlPD_PROJ_LAST_AUDIT_STATUS, "PD_BASE_CheckStatus", "CheckStatus_Name", "CheckStatus_Code", "");
        PublicDal.BindDropDownList(this.ddlPD_IS_RETURN, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_ISOUT_QUOTA, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_QUOTA_INPUT_COMPANY, "DB_Company", "NAME", "PK_CORP", "");
        PublicDal.BindDropDownList(this.ddlPD_QUOTA_ACCEPT_COMPANY, "DB_Company", "NAME", "PK_CORP", "ZXBJ=0");
        PublicDal.BindDropDownList(this.ddlPD_QUOTA_XZ_ACCEPT_COMPANY, "DB_Company", "NAME", "PK_CORP", "ZXBJ=1");
    }

    protected void bindTbFile()
    {
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
    }

    public void btnUpdate_Click(object sender, EventArgs e)
    {
        string text = this.txtPD_QUOTA_CODE.Text;
        string str2 = this.txtPD_QUOTA_NAME.Text;
        int num = int.Parse(this.txtPD_QUOTA_LWJG.Text);
        string str3 = this.ddlPD_QUOTA_ZJXZ.Text;
        int num2 = int.Parse(this.txtPD_QUOTA_MONEY_TOTAL.Text);
        string selectedValue = this.ddlPD_QUOTA_DEPART.SelectedValue;
        string str5 = this.txtPD_QUOTA_JGYQ.Text;
        DateTime time = DateTime.Parse(this.txtPD_QUOTA_INPUT_DATE.Text);
        string str6 = this.txtPD_QUOTA_INPUT_MAN.Text;
        string str7 = this.txtPD_QUOTA_PASS_DATE.Text;
        string str8 = this.txtPD_QUOTA_PASS_MAN.Text;
        string str9 = this.txtPD_QUOTA_ACCEPT_DATE.Text;
        string str10 = this.txtPD_QUOTA_ACCEPT_MAN.Text;
        string str11 = this.ddlPD_QUOTA_IFLLYQS.SelectedValue;
        string str12 = this.ddlPD_QUOTA_IFXZQS.SelectedValue;
        DateTime time2 = DateTime.Parse(this.txtPD_QUOTA_XZ_ACCEPT_DATE.Text);
        string str13 = this.txtPD_QUOTA_XZ_ACCEPT_MAN.Text;
        TB_QUOTA_Model model = new TB_QUOTA_Model
        {
            PD_QUOTA_CODE = text,
            PD_QUOTA_NAME = str2,
            PD_QUOTA_LWJG = new int?(num),
            PD_QUOTA_ZJXZ = str3,
            PD_QUOTA_MONEY_TOTAL = num2,
            PD_QUOTA_DEPART = selectedValue,
            PD_QUOTA_JGYQ = str5,
            PD_QUOTA_INPUT_DATE = new DateTime?(time),
            PD_QUOTA_INPUT_MAN = str6,
            PD_QUOTA_PASS_DATE = str7,
            PD_QUOTA_PASS_MAN = str8,
            PD_QUOTA_ACCEPT_DATE = str9,
            PD_QUOTA_ACCEPT_MAN = str10,
            PD_QUOTA_IFLLYQS = str11,
            PD_QUOTA_IFXZQS = str12,
            PD_QUOTA_FILE = "",
            PD_QUOTA_XZ_ACCEPT_DATE = new DateTime?(time2),
            PD_QUOTA_XZ_ACCEPT_MAN = str13
        };
        new TB_QUOTA_Bll().Update(model);
        PageShowText.Refurbish("修改成功", this.Page);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        base.Response.Write(this.FilePostCtr1.value);
    }

    public void Buttons(string ibtid)
    {
        switch (ibtid)
        {
            case "ibtcontrol_ibtupdate":
                if ((base.Request["UpdatePK"] != null) && (base.Request["UpdatePK"].Trim() != ""))
                {
                    this.UpdataData(base.Request["UpdatePK"].Trim());
                }
                return;

            case "ibtcontrol_ibtdelete":
                if ((base.Request["UpdatePK"] != null) && (base.Request["UpdatePK"].Trim() != ""))
                {
                    this.DelData(base.Request["UpdatePK"].Trim());
                }
                return;

            case "ibtcontrol_ibtsave":
                if ((base.Request["UpdatePK"] == null) || !(base.Request["UpdatePK"].Trim() != ""))
                {
                    this.CreateData();
                    return;
                }
                this.UpdataData(base.Request["UpdatePK"].Trim());
                return;

            case "ibtcontrol_ibtdo":
                {
                    TB_QUOTA_Bll bll = new TB_QUOTA_Bll();
                    if (bll.SetZbState(base.Request["UpdatePK"].Trim()) > 0)
                    {
                        PageShowText.Refurbish("下发成功", this.Page);
                    }
                    return;
                }
            case "ibtcontrol_ibtrefresh":
            case "ibtcontrol_ibtaudit":
            case "ibtcontrol_ibtsetback":
            case "ibtcontrol_ibtrollback":
                return;
        }
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
    }

    private void CreateData()
    {
        string strErr = "";
        if (!this.PanDuan(ref strErr))
        {
            this.hy_File(null, strErr);
        }
        else
        {
            TB_QUOTA_Model model = this.GetModel();
            new TB_QUOTA_Bll().Add(model, "");
            string str2 = model.PD_QUOTA_CODE;
            SMZJ.BLL.TB_QUOTA_DETAIL tb_quota_detail = new SMZJ.BLL.TB_QUOTA_DETAIL();
            List<SMZJ.Model.TB_QUOTA_DETAIL> qUOTAModel = this.GetQUOTAModel(str2);
            tb_quota_detail.DeleteProject(str2);
            tb_quota_detail.AddList(qUOTAModel);
            PageShowText.Refurbish("添加成功", this.Page);
        }
    }

    protected void ddlPD_QUOTA_FILE_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList list = (DropDownList)sender;
        if ((list.SelectedValue != null) && (list.SelectedValue != "请选择"))
        {
            string url = list.SelectedValue.ToString();
            string text = list.SelectedItem.Text;
            if (text != null)
            {
                if (!(text == "打开"))
                {
                    if (!(text == "上传"))
                    {
                        if (!(text == "删除"))
                        {
                            return;
                        }
                        return;
                    }
                }
                else
                {
                    base.Response.Redirect(url);
                    return;
                }
                new FileUpload();
            }
        }
    }

    public OracleDataReader ddlxzbind()
    {
        return PublicDal.GetPDBaseReaderValues("DB_Company", " ZXBJ=1");
    }

    private void DelData(string PD_QUOTA_CODE)
    {
        new TB_QUOTA_Bll().Delete(PD_QUOTA_CODE);
        PageShowText.Refurbish("删除成功", this.Page);
    }

    private DataTable GetGridViewData(SmartGridView objGridView, bool Del)
    {
        DataTable table = new DataTable();
        if (objGridView.Rows.Count == 0)
        {
            return null;
        }
        for (int i = 0; i < objGridView.Rows[0].Cells.Count; i++)
        {
            if ((objGridView.Rows[0].Cells[i].Controls.Count > 1) && (objGridView.Rows[0].Cells[i].Controls[1].ID != "CheckBoxNode"))
            {
                string iD = objGridView.Rows[0].Cells[i].Controls[1].ID;
                table.Columns.Add(new DataColumn(iD));
            }
        }
        foreach (GridViewRow row in objGridView.Rows)
        {
            DataRow row2 = table.NewRow();
            int num2 = 0;
            if (!Del || !((CheckBox)row.FindControl("CheckBoxNode")).Checked)
            {
                for (int j = 0; j < row.Cells.Count; j++)
                {
                    if (row.Cells[j].Controls.Count > 1)
                    {
                        switch (row.Cells[j].Controls[1].ID)
                        {
                            case "CheckBoxNode":
                                {
                                    continue;
                                }
                            case "ddlPD_Company_NAME":
                                {
                                    row2[num2++] = ((DropDownList)row.Cells[j].Controls[1]).Text;
                                    continue;
                                }
                        }
                        row2[num2++] = ((TextBox)row.Cells[j].Controls[1]).Text;
                    }
                }
                table.Rows.Add(row2);
            }
        }
        return table;
    }

    private TB_QUOTA_Model GetModel()
    {
        string str = "";
        string text = this.txtPD_QUOTA_CODE.Text;
        string str3 = this.txtPD_QUOTA_NAME.Text;
        string selectedValue = this.ddlPD_YEAR.SelectedValue;
        int num = int.Parse(this.txtPD_QUOTA_LWJG.Text);
        string str5 = this.ddlPD_QUOTA_IFUP.SelectedValue;
        string str6 = this.ddlPD_QUOTA_ZJXZ.Text;
        string str7 = this.txtPD_QUOTA_TARGET.Text;
        string str8 = this.txtPD_QUOTA_STANDARD.Text;
        string str9 = this.txtPD_QUOTA_BASIS.Text;
        string str10 = this.ddlPD_QUOTA_IFXZQS.SelectedValue;
        string str11 = this.ddlPD_QUOTA_IFPASS.SelectedValue;
        string str12 = this.txtPD_QUOTA_BASIS_JG.Text;
        string str13 = this.txtPD_QUOTA_INPUT_MAN.Text;
        string str14 = this.txtPD_QUOTA_PASS_DATE.Text;
        string str15 = this.txtPD_QUOTA_ACCEPT_MAN.Text;
        string str16 = this.txtPD_QUOTA_PASS_MAN.Text;
        string str17 = this.ddlPD_QUOTA_ACCEPT_COMPANY.SelectedValue;
        string str18 = this.txtPD_QUOTA_ACCEPT_DATE.Text;
        string str19 = this.ddlPD_QUOTA_IFLLYQS.SelectedValue;
        string str20 = this.ddlPD_QUOTA_XZ_ACCEPT_COMPANY.SelectedValue;
        DateTime time = DateTime.Parse(this.txtPD_QUOTA_XZ_ACCEPT_DATE.Text);
        int num2 = int.Parse(this.txtPD_QUOTA_MONEY_TOTAL.Text);
        string str21 = this.ddlPD_QUOTA_DEPART.SelectedValue;
        string str22 = this.txtPD_QUOTA_JGYQ.Text;
        DateTime time2 = DateTime.Parse(this.txtPD_QUOTA_INPUT_DATE.Text);
        string str23 = this.ddlPD_QUOTA_INPUT_COMPANY.SelectedValue;
        string str24 = this.txtPD_QUOTA_XZ_ACCEPT_MAN.Text;
        string str25 = this.ddlPD_PROJ_STATUS.SelectedValue;
        string str26 = this.ddlPD_PROJ_LAST_AUDIT_STATUS.SelectedValue;
        int num3 = int.Parse(this.ddlPD_IS_RETURN.SelectedValue);
        int num4 = int.Parse(this.ddlPD_ISOUT_QUOTA.SelectedValue);
        return new TB_QUOTA_Model
        {
            AUTO_NO = str,
            PD_QUOTA_CODE = text,
            PD_QUOTA_NAME = str3,
            PD_YEAR = selectedValue,
            PD_QUOTA_LWJG = new int?(num),
            PD_QUOTA_IFUP = str5,
            PD_QUOTA_ZJXZ = str6,
            PD_QUOTA_TARGET = str7,
            PD_QUOTA_STANDARD = str8,
            PD_QUOTA_BASIS = str9,
            PD_QUOTA_IFXZQS = str10,
            PD_QUOTA_IFPASS = str11,
            PD_QUOTA_BASIS_JG = str12,
            PD_QUOTA_INPUT_MAN = str13,
            PD_QUOTA_PASS_DATE = str14,
            PD_QUOTA_ACCEPT_MAN = str15,
            PD_QUOTA_PASS_MAN = str16,
            PD_QUOTA_ACCEPT_COMPANY = str17,
            PD_QUOTA_ACCEPT_DATE = str18,
            PD_QUOTA_IFLLYQS = str19,
            PD_QUOTA_FILE = "",
            PD_QUOTA_XZ_ACCEPT_COMPANY = str20,
            PD_QUOTA_XZ_ACCEPT_DATE = new DateTime?(time),
            PD_QUOTA_MONEY_TOTAL = num2,
            PD_QUOTA_DEPART = str21,
            PD_QUOTA_JGYQ = str22,
            PD_QUOTA_INPUT_DATE = new DateTime?(time2),
            PD_QUOTA_INPUT_COMPANY = str23,
            PD_QUOTA_XZ_ACCEPT_MAN = str24,
            PD_PROJ_STATUS = str25,
            PD_PROJ_LAST_AUDIT_STATUS = str26,
            PD_IS_RETURN = new int?(num3),
            PD_ISOUT_QUOTA = new int?(num4)
        };
    }

    private void GetQUOTA(TB_QUOTA_Model model)
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
                model.PD_QUOTA_FILE = defaultView[0]["FileSysName"].ToString() + "|" + defaultView[0]["FileName"].ToString();
            }
        }
    }

    private List<SMZJ.Model.TB_QUOTA_DETAIL> GetQUOTAModel(string PD_QUOTA_CODE)
    {
        List<SMZJ.Model.TB_QUOTA_DETAIL> list = new List<SMZJ.Model.TB_QUOTA_DETAIL>();
        if (base.Request.Form["table_xzxx_PD_QUOTA_CODE"] != null)
        {
            string[] strArray = base.Request.Form["table_xzxx_PD_QUOTA_CODE"].Split(new char[] { ',' });
            string[] strArray2 = base.Request.Form["PD_Company_NAME"].Split(new char[] { ',' });
            int length = strArray.Length;
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
            for (int i = 0; i < strArray.Length; i++)
            {
                SMZJ.Model.TB_QUOTA_DETAIL item = new SMZJ.Model.TB_QUOTA_DETAIL
                {
                    PD_QUOTA_CODE = strArray[i],
                    COMPANY_CODE = strArray2[i]
                };
                if (defaultView != null)
                {
                    defaultView.RowFilter = " tableID='table_xzxx' and rowIndex=" + (i + 1);
                    if (defaultView.Count > 0)
                    {
                        item.FILE_NAME = defaultView[0]["FileName"].ToString();
                        item.FILE_SYSNAME = defaultView[0]["FileSysName"].ToString();
                    }
                }
                list.Add(item);
            }
        }
        return list;
    }

    protected void GridView1_OnLoad(object sender, EventArgs e)
    {
    }

    protected void GridView1_RowEditing(object sender, GridViewUpdateEventArgs e)
    {
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }

    protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row != null)
        {
            SmartGridView view = (SmartGridView)sender;
            for (int i = 0; i <= view.Rows.Count; i++)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#8C9FF0'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                }
            }
        }
    }

    protected void gvResult_Sorting(object sender, GridViewSortEventArgs e)
    {
    }

    private void hy_File(List<SMZJ.Model.TB_QUOTA_DETAIL> de_Model, string ShowText)
    {
        if (de_Model == null)
        {
            de_Model = this.GetQUOTAModel(base.Request["UpdatePK"]);
        }
        DataSet ds = new DataSet();
        ds.Tables.Add();
        ds.Tables[0].Columns.Add("AUTO_NO");
        ds.Tables[0].Columns.Add("PD_QUOTA_CODE");
        ds.Tables[0].Columns.Add("COMPANY_CODE");
        ds.Tables[0].Columns.Add("FILE_NAME");
        ds.Tables[0].Columns.Add("FILE_SYSNAME");
        int num = 0;
        foreach (SMZJ.Model.TB_QUOTA_DETAIL tb_quota_detail in de_Model)
        {
            DataRow row = ds.Tables[0].NewRow();
            row["AUTO_NO"] = num++;
            row["PD_QUOTA_CODE"] = tb_quota_detail.PD_QUOTA_CODE;
            row["COMPANY_CODE"] = tb_quota_detail.COMPANY_CODE;
            row["FILE_NAME"] = tb_quota_detail.FILE_NAME;
            row["FILE_SYSNAME"] = tb_quota_detail.FILE_SYSNAME;
            ds.Tables[0].Rows.Add(row);
        }
        string str = "PostLoadxmsszl('table_xzxx',eval(decodeURIComponent(\"" + base.Server.UrlEncode(PublicDal.DataToJSON(ds)) + "\")),'bz_xzxx');";
        if (ShowText != null)
        {
            str = "alert(\"" + ShowText + "\");" + str;
        }
        this.FilePostCtr1.value = "";
        PageShowText.Run_javascript(str, this.Page);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
    }

    protected void OK_Click(object sender, EventArgs e)
    {
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
            this.Master.SearchHasGone = new SearchHandler(this.SearchControl);
            ButtonsModel model = null;
            PublicDal.ShowMxButton(this.Page, out model, "TB_QUOTA", "PD_QUOTA_CODE", base.Request["UpdatePK"], "PD_QUOTA_SERVERPK");
            this.Master.btModel = model;
            this.BindDDList();
            if ((!base.IsPostBack && (base.Request["UpdatePK"] != null)) && (base.Request["UpdatePK"].Trim() != ""))
            {
                this.ShowInfo(base.Request["UpdatePK"].Trim());
            }
            else if (!base.IsPostBack)
            {
                this.Bind1("", null);
                this.txtPD_QUOTA_INPUT_DATE.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.txtPD_QUOTA_PASS_DATE.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
    }

    private bool PanDuan(ref string strErr)
    {
        if (this.txtPD_QUOTA_CODE.Text.Trim().Length == 0)
        {
            strErr = strErr + @"文件编号不能为空！\n";
        }
        if (this.txtPD_QUOTA_NAME.Text.Trim().Length == 0)
        {
            strErr = strErr + @"文件名称不能为空！\n";
        }
        if (this.ddlPD_YEAR.SelectedValue.Trim().Length == 0)
        {
            strErr = strErr + @"文件年度不能为空！\n";
        }
        if (!PublicDal.PageValidate.IsNumber(this.txtPD_QUOTA_LWJG.Text))
        {
            strErr = strErr + @"来文机关格式错误！\n";
        }
        if (this.ddlPD_QUOTA_IFUP.SelectedValue.Trim().Length == 0)
        {
            strErr = strErr + @"是否统一下发不能为空！\n";
        }
        if (this.ddlPD_QUOTA_ZJXZ.SelectedValue.Trim().Length == 0)
        {
            strErr = strErr + @"资金性质不能为空！\n";
        }
        if (this.txtPD_QUOTA_TARGET.Text.Trim().Length == 0)
        {
            strErr = strErr + @"补助对象不能为空！\n";
        }
        if (this.txtPD_QUOTA_STANDARD.Text.Trim().Length == 0)
        {
            strErr = strErr + @"补助标准不能为空！\n";
        }
        if (this.txtPD_QUOTA_BASIS.Text.Trim().Length == 0)
        {
            strErr = strErr + @"补助依据不能为空！\n";
        }
        if (!PublicDal.PageValidate.IsNumber(this.ddlPD_QUOTA_IFXZQS.SelectedValue))
        {
            strErr = strErr + @"是否乡镇已签收格式错误！\n";
        }
        if (this.ddlPD_QUOTA_IFPASS.SelectedValue.Trim().Length == 0)
        {
            strErr = strErr + @"是否已传出不能为空！\n";
        }
        if (this.txtPD_QUOTA_BASIS_JG.Text.Trim().Length == 0)
        {
            strErr = strErr + @"监管依据不能为空！\n";
        }
        if (this.txtPD_QUOTA_INPUT_MAN.Text.Trim().Length == 0)
        {
            strErr = strErr + @"录入人员不能为空！\n";
        }
        if (!PublicDal.PageValidate.IsDateTime(this.txtPD_QUOTA_PASS_DATE.Text))
        {
            strErr = strErr + @"传出日期格式错误！\n";
        }
        if (this.txtPD_QUOTA_ACCEPT_MAN.Text.Trim().Length == 0)
        {
            strErr = strErr + @"联络员签收经办人不能为空！\n";
        }
        if (this.txtPD_QUOTA_PASS_MAN.Text.Trim().Length == 0)
        {
            strErr = strErr + @"传出经办人不能为空！\n";
        }
        if (this.ddlPD_QUOTA_ACCEPT_COMPANY.SelectedValue.Trim().Length == 0)
        {
            strErr = strErr + @"联络员单位不能为空！\n";
        }
        if (!PublicDal.PageValidate.IsDateTime(this.txtPD_QUOTA_ACCEPT_DATE.Text))
        {
            strErr = strErr + @"联络员签收日期格式错误！\n";
        }
        if (!PublicDal.PageValidate.IsNumber(this.ddlPD_QUOTA_IFLLYQS.SelectedValue))
        {
            strErr = strErr + @"是否联络员已签收格式错误！\n";
        }
        if (this.ddlPD_QUOTA_XZ_ACCEPT_COMPANY.SelectedValue.Trim().Length == 0)
        {
            strErr = strErr + @"乡镇签收单位不能为空！\n";
        }
        if (!PublicDal.PageValidate.IsDateTime(this.txtPD_QUOTA_XZ_ACCEPT_DATE.Text))
        {
            strErr = strErr + @"乡镇签收日期格式错误！\n";
        }
        if (!PublicDal.PageValidate.IsNumber(this.txtPD_QUOTA_MONEY_TOTAL.Text))
        {
            strErr = strErr + @"预算资金格式错误！\n";
        }
        if (this.ddlPD_QUOTA_DEPART.SelectedValue.Trim().Length == 0)
        {
            strErr = strErr + @"归口部门不能为空！\n";
        }
        if (this.txtPD_QUOTA_JGYQ.Text.Trim().Length == 0)
        {
            strErr = strErr + @"监管要求不能为空！\n";
        }
        if (!PublicDal.PageValidate.IsDateTime(this.txtPD_QUOTA_INPUT_DATE.Text))
        {
            strErr = strErr + @"录入日期格式错误！\n";
        }
        if (this.ddlPD_QUOTA_INPUT_COMPANY.SelectedValue.Trim().Length == 0)
        {
            strErr = strErr + @"录入单位不能为空！\n";
        }
        if (this.txtPD_QUOTA_XZ_ACCEPT_MAN.Text.Trim().Length == 0)
        {
            strErr = strErr + @"乡镇签收经办人不能为空！\n";
        }
        if (!PublicDal.PageValidate.IsNumber(this.ddlPD_IS_RETURN.SelectedValue))
        {
            strErr = strErr + @"是否退回格式错误！\n";
        }
        if (!PublicDal.PageValidate.IsNumber(this.ddlPD_ISOUT_QUOTA.SelectedValue))
        {
            strErr = strErr + @"是否立项格式错误！\n";
        }
        if (strErr != "")
        {
            return false;
        }
        return true;
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
    }

    private void ShowInfo(string PD_QUOTA_CODE)
    {
        if (!string.IsNullOrEmpty(PD_QUOTA_CODE))
        {
            TB_QUOTA_Bll bll = new TB_QUOTA_Bll();
            if (bll.GetList(" PD_QUOTA_CODE='" + PD_QUOTA_CODE + "'") != null)
            {
                TB_QUOTA_Model modelByCODE = bll.GetModelByCODE(PD_QUOTA_CODE);
                this.txtPD_QUOTA_CODE.Enabled = false;
                this.lblAUTO_ID.Text = modelByCODE.AUTO_NO.ToString();
                this.txtPD_QUOTA_CODE.Text = modelByCODE.PD_QUOTA_CODE;
                this.txtPD_QUOTA_NAME.Text = modelByCODE.PD_QUOTA_NAME;
                this.ddlPD_YEAR.SelectedValue = modelByCODE.PD_YEAR;
                this.txtPD_QUOTA_LWJG.Text = modelByCODE.PD_QUOTA_LWJG.ToString();
                this.txtPD_QUOTA_LWJG_NAME.Text = modelByCODE.PD_QUOTA_LWJG_NAME.ToString();
                this.ddlPD_QUOTA_IFUP.SelectedValue = modelByCODE.PD_QUOTA_IFUP;
                this.ddlPD_QUOTA_ZJXZ.Text = modelByCODE.PD_QUOTA_ZJXZ;
                this.txtPD_QUOTA_TARGET.Text = modelByCODE.PD_QUOTA_TARGET;
                this.txtPD_QUOTA_STANDARD.Text = modelByCODE.PD_QUOTA_STANDARD;
                this.txtPD_QUOTA_BASIS.Text = modelByCODE.PD_QUOTA_BASIS;
                this.ddlPD_QUOTA_IFXZQS.SelectedValue = modelByCODE.PD_QUOTA_IFXZQS.ToString();
                this.ddlPD_QUOTA_IFPASS.SelectedValue = modelByCODE.PD_QUOTA_IFPASS;
                this.txtPD_QUOTA_BASIS_JG.Text = modelByCODE.PD_QUOTA_BASIS_JG;
                this.txtPD_QUOTA_INPUT_MAN.Text = modelByCODE.PD_QUOTA_INPUT_MAN;
                this.txtPD_QUOTA_PASS_DATE.Text = modelByCODE.PD_QUOTA_PASS_DATE.ToString();
                this.txtPD_QUOTA_ACCEPT_MAN.Text = modelByCODE.PD_QUOTA_ACCEPT_MAN;
                this.txtPD_QUOTA_PASS_MAN.Text = modelByCODE.PD_QUOTA_PASS_MAN;
                this.ddlPD_QUOTA_ACCEPT_COMPANY.SelectedValue = modelByCODE.PD_QUOTA_ACCEPT_COMPANY;
                this.txtPD_QUOTA_ACCEPT_DATE.Text = modelByCODE.PD_QUOTA_ACCEPT_DATE.ToString();
                this.ddlPD_QUOTA_IFLLYQS.SelectedValue = modelByCODE.PD_QUOTA_IFLLYQS.ToString();
                this.ddlPD_QUOTA_XZ_ACCEPT_COMPANY.SelectedValue = modelByCODE.PD_QUOTA_XZ_ACCEPT_COMPANY;
                this.txtPD_QUOTA_XZ_ACCEPT_DATE.Text = modelByCODE.PD_QUOTA_XZ_ACCEPT_DATE.ToString();
                this.txtPD_QUOTA_MONEY_TOTAL.Text = modelByCODE.PD_QUOTA_MONEY_TOTAL.ToString();
                this.ddlPD_QUOTA_DEPART.SelectedValue = modelByCODE.PD_QUOTA_DEPART;
                this.txtPD_QUOTA_JGYQ.Text = modelByCODE.PD_QUOTA_JGYQ;
                this.txtPD_QUOTA_INPUT_DATE.Text = modelByCODE.PD_QUOTA_INPUT_DATE.ToString();
                this.ddlPD_QUOTA_INPUT_COMPANY.SelectedValue = modelByCODE.PD_QUOTA_INPUT_COMPANY;
                this.txtPD_QUOTA_XZ_ACCEPT_MAN.Text = modelByCODE.PD_QUOTA_XZ_ACCEPT_MAN;
                this.ddlPD_PROJ_STATUS.SelectedValue = modelByCODE.PD_PROJ_STATUS;
                this.ddlPD_PROJ_LAST_AUDIT_STATUS.SelectedValue = modelByCODE.PD_PROJ_LAST_AUDIT_STATUS;
                this.ddlPD_IS_RETURN.SelectedValue = modelByCODE.PD_IS_RETURN.ToString();
                this.ddlPD_ISOUT_QUOTA.SelectedValue = modelByCODE.PD_ISOUT_QUOTA.ToString();
                this.Bind1(PD_QUOTA_CODE, modelByCODE);
            }
        }
    }

    private void UpdataData(string PD_QUOTA_CODE)
    {
        string strErr = "";
        if (!this.PanDuan(ref strErr))
        {
            this.hy_File(null, strErr);
        }
        else
        {
            TB_QUOTA_Model model = this.GetModel();
            TB_QUOTA_Bll bll = new TB_QUOTA_Bll();
            model.PD_QUOTA_CODE = PD_QUOTA_CODE;
            this.GetQUOTA(model);
            bll.Update(model);
            SMZJ.BLL.TB_QUOTA_DETAIL tb_quota_detail = new SMZJ.BLL.TB_QUOTA_DETAIL();
            List<SMZJ.Model.TB_QUOTA_DETAIL> qUOTAModel = this.GetQUOTAModel(PD_QUOTA_CODE);
            tb_quota_detail.DeleteProject(PD_QUOTA_CODE);
            tb_quota_detail.AddList(qUOTAModel);
            PageShowText.Refurbish("修改成功", this.Page);
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
