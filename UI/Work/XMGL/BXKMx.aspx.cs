using ASP;
using ExtExtenders;
using SoMeTech.CommonDll;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using System;
using System.Collections.Generic;
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
using SMZJ.BLL;
using SMZJ.Model;
using SMZJ.Model;

public class Work_GL_BXKMx : Page, IRequiresSessionState
{
    protected DropDownList ddlPD_FOUND_XZ;
    protected TextBox ddlPD_PROJECT_COUNTRY;
    protected HtmlSelect ddlPD_PROJECT_GROUP;
    protected DropDownList ddlPD_PROJECT_IFXZGL;
    protected DropDownList ddlPD_PROJECT_TYPE;
    protected HtmlSelect ddlPD_PROJECT_VILLAGE;
    protected DropDownList ddlPD_YEAR;
    protected UserControls_FilePostCtr FilePostCtr1;
    public string jsonStr = "";
    public string jsonStrNull = "";
    protected TabPanel Panel_xmgk;
    protected TabPanel Panel_xmsbzl;
    protected TextBox pd_project_cm;
    protected TextBox ShowPD_PROJECT_INPUT_COMPANY;
    protected TextBox ShowPD_PROJECT_INPUT_MAN;
    protected TabContainer TabContainer1;
    protected TextBox txtdepart;
    protected TextBox txtPD_PROJECT_CODE;
    protected TextBox txtPD_PROJECT_CONTENT;
    protected TextBox txtPD_PROJECT_FILENO_LX;
    protected TextBox txtPD_PROJECT_INPUT_COMPANY;
    protected TextBox txtPD_PROJECT_INPUT_DATE;
    protected TextBox txtPD_PROJECT_INPUT_MAN;
    protected HtmlInputHidden txtPD_PROJECT_MONEY_CZ_BJ;
    protected HtmlInputHidden txtPD_PROJECT_MONEY_CZ_SJ;
    protected HtmlInputHidden txtPD_PROJECT_MONEY_QT;
    protected TextBox txtPD_PROJECT_MONEY_TOTAL;
    protected HtmlInputHidden txtPD_PROJECT_MONEY_ZC;
    protected TextBox txtPD_PROJECT_NAME;
    protected TextBox txtPD_PROJECT_SSFW;
    protected TextBox txtPD_PROJECT_SYRS;
    protected TextBox txtPD_PROJECT_XMYT;

    private void addFileJSON(string PD_PROJECT_CODE)
    {
        DataSet list = new PD_PROJECT_ATTACH_SB_Bll().GetList(" PD_PROJECT_CODE='" + PD_PROJECT_CODE + "'");
        this.jsonStr = PublicDal.DataToJSON(list);
        if (list.Tables[0].Rows.Count > 0)
        {
            list.Tables[0].Rows.Clear();
        }
        DataRow row = list.Tables[0].NewRow();
        row[1] = PD_PROJECT_CODE;
        list.Tables[0].Rows.Add(row);
        this.jsonStrNull = PublicDal.DataToJSON(list);
    }

    private void BindDDList()
    {
        PublicDal.BindDropDownList(this.ddlPD_YEAR, "PD_BASE_YEAR", "YEAR_NAME", "YEAR_CODE", "");
        string text = DateTime.Now.Year.ToString();
        this.ddlPD_YEAR.SelectedIndex = this.ddlPD_YEAR.Items.IndexOf(new ListItem(text, text));
        PublicDal.BindDropDownList(this.ddlPD_FOUND_XZ, "PD_BASE_FOUND_PROPERTY", "FOUND_PROPERTY_NAME", "FOUND_PROPERTY_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_TYPE, "PD_BASE_ProjectType", "ProjectType_Name", "PROJECTTYPE_CODE", "projecttype_year=" + this.ddlPD_YEAR.SelectedValue + " and zjxz_type='" + this.ddlPD_FOUND_XZ.SelectedValue + "'");
        this.ddlPD_PROJECT_TYPE.Items.Insert(0, new ListItem("", ""));
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_IFXZGL, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
    }

    private void BindXiangCunZU()
    {
    }

    public void Buttons(string ibtid)
    {
        switch (ibtid)
        {
            case "ibtcontrol_ibtprintnote":
                PageShowText.OpenPage(Public.RelativelyPath("Report/jsxGTable.aspx") + "?UpdatePK=" + base.Request["UpdatePK"].Trim(), null, null, this.Page, true);
                break;

            case "ibtcontrol_ibtadd":
            case "ibtcontrol_ibtupdate":
                break;

            case "ibtcontrol_ibtdelete":
                this.DelData(base.Request["UpdatePK"].Trim());
                return;

            case "ibtcontrol_ibtsave":
                if ((base.Request["UpdatePK"] != null) && (base.Request["UpdatePK"].Trim() != ""))
                {
                    this.UpdataData(base.Request["UpdatePK"].Trim());
                    return;
                }
                this.CreateData();
                return;

            case "ibtcontrol_ibtrefresh":
                return;

            case "ibtcontrol_ibtaudit":
                new TB_PROJECT_Bll().UpdatePFMoney(base.Request.Params["UpdatePK"]);
                this.SetServiceStream(1, base.Request.Params["UpdatePK"], "审核");
                return;

            case "ibtcontrol_ibtapply":
                this.SetServiceStream(1, base.Request.Params["UpdatePK"], "审批");
                return;

            case "ibtcontrol_ibtsetback":
                this.SetServiceStream(0, base.Request.Params["UpdatePK"], "追回");
                return;

            case "ibtcontrol_ibtrollback":
                this.SetServiceStream(0, base.Request.Params["UpdatePK"], "退回");
                return;

            default:
                return;
        }
    }

    private void CreateData()
    {
        TB_PROJECT_Model model = this.GetModel(new TB_PROJECT_Model());
        model.PD_PROJECT_CODE = DateTime.Now.ToString("yyyyMMddhhmmssffffff");
        TB_PROJECT_Bll bll = new TB_PROJECT_Bll();
        bll.Add(model);
        bll.UpdateServerPK("TB_PROJECT", "PD_PROJECT_CODE", model.PD_PROJECT_CODE, PublicDal.SetCreateServiceStream(this.Page), "PD_PROJECT_SERVERPK");
        PD_PROJECT_ATTACH_SB_Bll bll2 = new PD_PROJECT_ATTACH_SB_Bll();
        List<PD_PROJECT_ATTACH_SB_Model> modelList = this.GetAttach_SBModel(model.PD_PROJECT_CODE);
        bll2.AddList(modelList);
        PD_PROJECT_TZJGC_Bll bll3 = new PD_PROJECT_TZJGC_Bll();
        List<PD_PROJECT_TZJGC_Model> listModel = this.getTZJGCModel(model.PD_PROJECT_CODE);
        bll3.Add(listModel);
        Const.DoSuccessNoClose("添加成功", this.Page.Request.Url.LocalPath + "?UpdatePK=" + model.PD_PROJECT_CODE, this.Page);
    }

    private void DelData(string PD_PROJECT_CODE)
    {
        new TB_PROJECT_Bll().Delete(PD_PROJECT_CODE);
        PageShowText.Refurbish("删除成功", this.Page);
    }

    private List<PD_PROJECT_ATTACH_SB_Model> GetAttach_SBModel(string PD_PROJECT_CODE)
    {
        List<PD_PROJECT_ATTACH_SB_Model> list = new List<PD_PROJECT_ATTACH_SB_Model>();
        if (base.Request.Form["table_xmsbzl_PD_PROJECT_CODE"] != null)
        {
            string[] strArray = base.Request.Form["table_xmsbzl_PD_PROJECT_CODE"].Split(new char[] { ',' });
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
            if (defaultView == null)
            {
                return list;
            }
            for (int i = 0; i < strArray.Length; i++)
            {
                defaultView.RowFilter = " tableID='table_xmsbzl' and rowIndex=" + (i + 1);
                if (defaultView.Count > 0)
                {
                    PD_PROJECT_ATTACH_SB_Model item = new PD_PROJECT_ATTACH_SB_Model
                    {
                        PD_PROJECT_CODE = PD_PROJECT_CODE,
                        PD_PROJECT_ATTACH_NAME = defaultView[0]["FileName"].ToString(),
                        PD_PROJECT_ATTACH_NAME_SYSTEM = defaultView[0]["FileSysName"].ToString()
                    };
                    list.Add(item);
                }
            }
        }
        return list;
    }

    private TB_PROJECT_Model GetModel(TB_PROJECT_Model model)
    {
        if (model == null)
        {
            model = new TB_PROJECT_Model();
        }
        model.PD_PROJECT_INPUT_DATE = this.txtPD_PROJECT_INPUT_DATE.Text.ToString();
        model.PD_PROJECT_CODE = this.txtPD_PROJECT_CODE.Text;
        model.PD_PROJECT_NAME = this.txtPD_PROJECT_NAME.Text;
        if (this.ddlPD_YEAR.SelectedValue != "")
        {
            model.PD_YEAR = new int?(int.Parse(this.ddlPD_YEAR.SelectedValue));
        }
        model.PD_PROJECT_TYPE = this.ddlPD_PROJECT_TYPE.SelectedValue;
        model.PD_FOUND_XZ = this.ddlPD_FOUND_XZ.SelectedValue;
        model.PD_PROJECT_COUNTRY = this.ddlPD_PROJECT_COUNTRY.Text;
        model.PD_PROJECT_VILLAGE = "0001";
        model.PD_PROJECT_GROUP = "0001";
        model.PD_PROJECT_MONEY_ADDR = this.ddlPD_PROJECT_COUNTRY.Text;
        model.PD_PROJECT_CONTENT = this.txtPD_PROJECT_CONTENT.Text;
        model.PD_PROJECT_XMYT = this.txtPD_PROJECT_XMYT.Text;
        if (this.ddlPD_PROJECT_IFXZGL.SelectedValue != "")
        {
            model.PD_PROJECT_IFXZGL = new int?(int.Parse(this.ddlPD_PROJECT_IFXZGL.SelectedValue));
        }
        if (PublicDal.PageValidate.IsNumber(this.txtPD_PROJECT_SYRS.Text))
        {
            model.PD_PROJECT_SYRS = new int?(int.Parse(this.txtPD_PROJECT_SYRS.Text));
        }
        model.PD_PROJECT_FILENO_LX = this.txtPD_PROJECT_FILENO_LX.Text;
        model.PD_PROJECT_INPUT_COMPANY = ((UserModel)this.Session["User"]).Company.pk_corp;
        model.PD_PROJECT_INPUT_MAN = ((UserModel)this.Session["User"]).UserName;
        if (this.txtPD_PROJECT_MONEY_TOTAL.Text != "")
        {
            model.PD_PROJECT_MONEY_TOTAL = new decimal?(Math.Round(Convert.ToDecimal(this.txtPD_PROJECT_MONEY_TOTAL.Text), 2));
        }
        if (this.txtPD_PROJECT_MONEY_CZ_SJ.Value != "")
        {
            model.PD_PROJECT_MONEY_CZ_SJ_PF = model.PD_PROJECT_MONEY_CZ_SJ = new decimal?(Math.Round(Convert.ToDecimal(this.txtPD_PROJECT_MONEY_CZ_SJ.Value), 2));
        }
        if (this.txtPD_PROJECT_MONEY_CZ_BJ.Value != "")
        {
            model.PD_PROJECT_MONEY_CZ_BJ = new decimal?(Math.Round(Convert.ToDecimal(this.txtPD_PROJECT_MONEY_CZ_BJ.Value), 2));
        }
        if (this.txtPD_PROJECT_MONEY_ZC.Value != "")
        {
            model.PD_PROJECT_MONEY_ZC = new decimal?(Math.Round(Convert.ToDecimal(this.txtPD_PROJECT_MONEY_ZC.Value), 2));
        }
        if (this.txtPD_PROJECT_MONEY_QT.Value != "")
        {
            model.PD_PROJECT_MONEY_QT = new decimal?(Math.Round(Convert.ToDecimal(this.txtPD_PROJECT_MONEY_QT.Value), 2));
        }
        model.PD_PROJECT_SSFW = this.txtPD_PROJECT_SSFW.Text;
        model.PD_PROJECT_ISBXK = 1;
        model.Free2 = this.pd_project_cm.Text;
        return model;
    }

    [WebMethod]
    public static string getTZJGC(string selectValue)
    {
        DataSet set = PublicDal.getTZJGC();
        string str = "";
        foreach (DataRow row in set.Tables[0].Rows)
        {
            string str2 = "";
            if (row["ID"].ToString().Trim() == selectValue.Trim())
            {
                str2 = " selected=\"selected\"";
            }
            object obj2 = str;
            str = string.Concat(new object[] { obj2, "<option value=\"", row["ID"], "\"", str2, " isGetQuota=", row["ISGETQUOTA"], ">", row["MONEYNAME"], "</option>" });
        }
        return ("<select id=\"PD_BASE_TZJGC\" name=\"PD_BASE_TZJGC\" onchange=\"tzgc_hidde(this)\">" + str + "</select>");
    }

    [WebMethod]
    public static string getTZJGCAll(string PD_PROJECT_CODE)
    {
        DataSet projectList = new PD_PROJECT_TZJGC_Bll().GetProjectList(PD_PROJECT_CODE);
        foreach (DataRow row in projectList.Tables[0].Rows)
        {
            string str = "";
            if (PublicDal.PageValidate.IsInt(row["PD_BASE_TZJGC"]) && (int.Parse(row["ISGETQUOTA"].ToString()) != 1))
            {
                str = " disabled=\"disabled\" ";
            }
            row["CHECKBOX"] = "<input type=\"checkbox\" name=\"tb_tzjgc_1_cb\" >";
            row["PD_BASE_TZJGC"] = getTZJGC(row["PD_BASE_TZJGC"].ToString());
            row["TB_QUOTA_CODE"] = string.Concat(new object[] { "<input id=\"TB_QUOTA_ZBWH_H\" style=\"width: 98%;\" readonly=\"readonly\" value=\"", row["TB_QUOTA_ZBWH_H"], "\" ", str, " onclick=\"javascript:findwindow(1,this);\" /><input type=\"hidden\" name=\"TB_QUOTA_CODE\" id=\"TB_QUOTA_CODE\" value=\"", row["TB_QUOTA_CODE"], "\"/>" });
            row["PD_PROJECT_MONEY_CZ_SJ"] = "<input type=\"text\" name=\"PD_PROJECT_MONEY_CZ_SJ\" id=\"PD_PROJECT_MONEY_CZ_SJ\" onchange=\"SumMoney_TZGC()\" onKeyPress=\"myKeyDown(this,event,0)\" class=\"NumTextCss\" value=\"" + row["PD_PROJECT_MONEY_CZ_SJ"] + "\"/>";
            row["PD_GK_DEPART"] = "<a id=\"PD_GK_DEPART_A\">" + row["PD_GK_DEPART"] + "&nbsp;</a>";
            row["PD_PROJECT_FILENO_JG"] = "<a id=\"PD_PROJECT_FILENO_JG_A\">" + row["PD_PROJECT_FILENO_JG"] + "&nbsp;</a>";
            row["PD_PROJECT_ZJLY"] = "<a id=\"PD_PROJECT_ZJLY_A\">" + row["PD_PROJECT_ZJLY"] + "&nbsp;</a>";
            row["PD_PROJECT_ZGKJ"] = "<a id=\"PD_PROJECT_ZGKJ_A\">" + row["PD_PROJECT_ZGKJ"] + "&nbsp;</a>";
        }
        projectList.Tables[0].Columns.Remove("TB_QUOTA_ZBWH_H");
        projectList.Tables[0].Columns.Remove("ISGETQUOTA");
        return PublicDal.DataToJSON2(projectList);
    }

    private List<PD_PROJECT_TZJGC_Model> getTZJGCModel(string PD_PROJECT_CODE)
    {
        List<PD_PROJECT_TZJGC_Model> list = new List<PD_PROJECT_TZJGC_Model>();
        if (base.Request["PD_BASE_TZJGC"] != null)
        {
            string[] strArray = base.Request["PD_BASE_TZJGC"].Split(new char[] { ',' });
            string[] strArray2 = base.Request["PD_PROJECT_MONEY_CZ_SJ"].Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                PD_PROJECT_TZJGC_Model item = new PD_PROJECT_TZJGC_Model
                {
                    PD_PROJECT_CODE = PD_PROJECT_CODE
                };
                if (PublicDal.PageValidate.IsInt(strArray[i]))
                {
                    item.PD_BASE_TZJGC = new decimal?(int.Parse(strArray[i]));
                }
                if (PublicDal.PageValidate.IsDecimal(strArray2[i]))
                {
                    item.PD_PROJECT_MONEY_CZ_SJ = new decimal?(decimal.Parse(strArray2[i]));
                }
                list.Add(item);
            }
        }
        return list;
    }

    private void hy_File(List<PD_PROJECT_ATTACH_SB_Model> SS_Model, string ShowText)
    {
        if (SS_Model == null)
        {
            SS_Model = this.GetAttach_SBModel(base.Request["UpdatePK"]);
        }
        DataSet ds = new DataSet();
        ds.Tables.Add();
        ds.Tables[0].Columns.Add("AUTO_NO");
        ds.Tables[0].Columns.Add("PD_PROJECT_CODE");
        ds.Tables[0].Columns.Add("PD_PROJECT_ATTACH_NAME");
        ds.Tables[0].Columns.Add("PD_PROJECT_ATTACH_NAME_SYSTEM");
        int num = 0;
        foreach (PD_PROJECT_ATTACH_SB_Model model in SS_Model)
        {
            DataRow row = ds.Tables[0].NewRow();
            row["AUTO_NO"] = num++;
            row["PD_PROJECT_CODE"] = model.PD_PROJECT_CODE;
            row["PD_PROJECT_ATTACH_NAME"] = model.PD_PROJECT_ATTACH_NAME;
            row["PD_PROJECT_ATTACH_NAME_SYSTEM"] = model.PD_PROJECT_ATTACH_NAME_SYSTEM;
            ds.Tables[0].Rows.Add(row);
        }
        string str = " RunBindData();try{PostLoadxmsszl('table_xmsbzl',eval(decodeURIComponent(\"" + base.Server.UrlEncode(PublicDal.DataToJSON(ds)) + "\")),'xmss_5');}catch(e){alert(e)};";
        if (ShowText != null)
        {
            str = "alert(\"" + ShowText + "\");" + str;
        }
        this.FilePostCtr1.value = "";
        PageShowText.Run_javascript(str, this.Page);
    }

    public void ListPageLoad(Page page, out ButtonsModel main_bm, string PD_PROJECT_CODE)
    {
        PublicDal.ShowMxButton(this.Page, out main_bm, "TB_PROJECT", "PD_PROJECT_CODE", PD_PROJECT_CODE, "PD_PROJECT_SERVERPK");
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
            this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
            this.Master.SearchHasGone = new SearchHandler(this.SearchControl);
            if (base.Request["UpdatePK"] == null)
            {
            }
            ButtonsModel model = null;
            this.ListPageLoad(this.Page, out model, base.Request["UpdatePK"]);
            model.IfAudit = false;
            this.Master.btModel = model;
            if (!base.IsPostBack)
            {
                this.Master.TabContainer1 = this.TabContainer1;
                this.txtdepart.Text = ((UserModel)this.Session["user"]).Branch.Name;
                this.BindDDList();
                this.BindXiangCunZU();
                if ((base.Request["UpdatePK"] != null) && (base.Request["UpdatePK"].Trim() != ""))
                {
                    this.ShowInfo(base.Request["UpdatePK"].Trim());
                    this.addFileJSON(base.Request["UpdatePK"].Trim());
                    model.IfPrintNote = false;
                    model.IbtPrintNoteText = "打印";
                }
                else
                {
                    this.txtPD_PROJECT_CODE.Enabled = true;
                    this.txtPD_PROJECT_NAME.Enabled = true;
                    this.txtPD_PROJECT_INPUT_DATE.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    if (((UserModel)this.Session["user"]).Company != null)
                    {
                        this.txtPD_PROJECT_INPUT_COMPANY.Text = ((UserModel)this.Session["user"]).Company.pk_corp;
                        this.ShowPD_PROJECT_INPUT_COMPANY.Text = ((UserModel)this.Session["user"]).Company.Name;
                    }
                    if (((UserModel)this.Session["user"]).UserName != null)
                    {
                        this.txtPD_PROJECT_INPUT_MAN.Text = ((UserModel)this.Session["user"]).UserName;
                        this.ShowPD_PROJECT_INPUT_MAN.Text = ((UserModel)this.Session["user"]).TrueName;
                    }
                    this.addFileJSON("");
                }
            }
            this.ShowCS();
        }
    }

    private bool Panduan(ref string strErr)
    {
        new TB_PROJECT_Bll();
        if (this.txtPD_PROJECT_NAME.Text.Trim().Length == 0)
        {
            strErr = strErr + @"项目名称不能为空！\n";
        }
        else if (!PageValidate.IsNumber(this.ddlPD_YEAR.SelectedValue))
        {
            strErr = strErr + @"项目年度格式错误！\n";
        }
        else if (this.ddlPD_PROJECT_TYPE.SelectedValue.Trim().Length == 0)
        {
            strErr = strErr + @"项目类别不能为空！\n";
        }
        else if (this.ddlPD_FOUND_XZ.SelectedValue.Trim().Length == 0)
        {
            strErr = strErr + @"资金性质不能为空！\n";
        }
        if (this.txtPD_PROJECT_CONTENT.Text.Trim().Length == 0)
        {
            strErr = strErr + @"主要建设内容不能为空！\n";
        }
        if (this.ddlPD_PROJECT_COUNTRY.Text.Trim().Length == 0)
        {
            strErr = strErr + @"项目建设地点不能为空！\n";
        }
        if (this.txtPD_PROJECT_MONEY_TOTAL.Text.Trim().Length == 0)
        {
            strErr = strErr + @"申请投资总额不能为空,且需要大于等于0 \n";
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

    public void SetServiceStream(int operation, string PD_PROJECT_CODE, string Mess)
    {
        PublicDal.SetServiceStream(this.Page, operation, "TB_PROJECT", "PD_PROJECT_CODE", PD_PROJECT_CODE, Mess, "PD_PROJECT_SERVERPK");
    }

    private void ShowCS()
    {
        this.txtPD_PROJECT_CODE.Attributes.Add("onchange", "findcompany(this)");
        this.txtPD_PROJECT_NAME.Attributes.Add("onchange", "findcompany(this)");
        this.txtPD_PROJECT_MONEY_CZ_SJ.Attributes.Add("onKeyPress", "myKeyDown(this,event,0)");
        this.txtPD_PROJECT_MONEY_CZ_BJ.Attributes.Add("onKeyPress", "myKeyDown(this,event,0)");
        this.txtPD_PROJECT_MONEY_ZC.Attributes.Add("onKeyPress", "myKeyDown(this,event,0)");
        this.txtPD_PROJECT_MONEY_QT.Attributes.Add("onKeyPress", "myKeyDown(this,event,0)");
        this.txtPD_PROJECT_SYRS.Attributes.Add("onKeyPress", "myKeyDown(this,event,1)");
        this.txtPD_PROJECT_MONEY_CZ_SJ.Attributes.Add("onBlur", "Sum_sqzjze()");
        this.txtPD_PROJECT_MONEY_CZ_BJ.Attributes.Add("onBlur", "Sum_sqzjze()");
        this.txtPD_PROJECT_MONEY_ZC.Attributes.Add("onBlur", "Sum_sqzjze()");
        this.txtPD_PROJECT_MONEY_QT.Attributes.Add("onBlur", "Sum_sqzjze()");
    }

    private void ShowInfo(string PD_PROJECT_CODE)
    {
        TB_PROJECT_Model model = new TB_PROJECT_Bll().GetModel(PD_PROJECT_CODE);
        this.txtPD_PROJECT_CODE.Enabled = false;
        this.txtPD_PROJECT_NAME.Enabled = false;
        this.txtPD_PROJECT_CODE.Text = model.PD_PROJECT_CODE;
        this.txtPD_PROJECT_NAME.Text = model.PD_PROJECT_NAME;
        this.ddlPD_YEAR.SelectedValue = model.PD_YEAR.ToString();
        this.ddlPD_PROJECT_TYPE.SelectedValue = model.PD_PROJECT_TYPE;
        this.ddlPD_FOUND_XZ.SelectedValue = model.PD_FOUND_XZ;
        this.ddlPD_PROJECT_COUNTRY.Text = model.PD_PROJECT_COUNTRY;
        this.ddlPD_PROJECT_VILLAGE.Value = model.PD_PROJECT_VILLAGE;
        this.ddlPD_PROJECT_GROUP.Value = model.PD_PROJECT_GROUP;
        this.txtPD_PROJECT_CONTENT.Text = model.PD_PROJECT_CONTENT;
        this.txtPD_PROJECT_XMYT.Text = model.PD_PROJECT_XMYT;
        this.ddlPD_PROJECT_IFXZGL.SelectedValue = model.PD_PROJECT_IFXZGL.ToString();
        this.txtPD_PROJECT_SYRS.Text = model.PD_PROJECT_SYRS.ToString();
        this.txtPD_PROJECT_FILENO_LX.Text = model.PD_PROJECT_FILENO_LX;
        this.ShowPD_PROJECT_INPUT_COMPANY.Text = model.ShowPD_PROJECT_INPUT_COMPANY;
        this.ShowPD_PROJECT_INPUT_MAN.Text = model.ShowPD_PROJECT_INPUT_MAN;
        this.txtPD_PROJECT_INPUT_COMPANY.Text = model.PD_PROJECT_INPUT_COMPANY;
        this.txtPD_PROJECT_INPUT_MAN.Text = model.PD_PROJECT_INPUT_MAN;
        this.txtPD_PROJECT_INPUT_DATE.Text = model.PD_PROJECT_INPUT_DATE;
        this.ddlPD_PROJECT_COUNTRY.Text = model.PD_PROJECT_COUNTRY;
        this.txtPD_PROJECT_MONEY_TOTAL.Text = model.PD_PROJECT_MONEY_TOTAL.ToString();
        this.txtPD_PROJECT_MONEY_CZ_SJ.Value = model.PD_PROJECT_MONEY_CZ_SJ.ToString();
        this.txtPD_PROJECT_MONEY_CZ_BJ.Value = model.PD_PROJECT_MONEY_CZ_BJ.ToString();
        this.txtPD_PROJECT_MONEY_ZC.Value = model.PD_PROJECT_MONEY_ZC.ToString();
        this.txtPD_PROJECT_MONEY_QT.Value = model.PD_PROJECT_MONEY_QT.ToString();
        this.txtPD_PROJECT_SSFW.Text = model.PD_PROJECT_SSFW;
        this.pd_project_cm.Text = model.Free2;
    }

    private void UpdataData(string PD_PROJECT_CODE)
    {
        TB_PROJECT_Bll bll = new TB_PROJECT_Bll();
        TB_PROJECT_Model model = this.GetModel(bll.GetModel(PD_PROJECT_CODE));
        model.PD_PROJECT_CODE = PD_PROJECT_CODE;
        bll.Update(model);
        PD_PROJECT_ATTACH_SB_Bll bll2 = new PD_PROJECT_ATTACH_SB_Bll();
        bll2.Delete(PD_PROJECT_CODE);
        List<PD_PROJECT_ATTACH_SB_Model> modelList = this.GetAttach_SBModel(PD_PROJECT_CODE);
        bll2.AddList(modelList);
        PD_PROJECT_TZJGC_Bll bll3 = new PD_PROJECT_TZJGC_Bll();
        bll3.DeleteAll(PD_PROJECT_CODE);
        List<PD_PROJECT_TZJGC_Model> listModel = this.getTZJGCModel(PD_PROJECT_CODE);
        bll3.Add(listModel);
        PageShowText.Refurbish("修改成功", this.Page);
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

    private static class PageValidate
    {
        public static bool IsDateTime(string text)
        {
            DateTime time;
            return DateTime.TryParse(text, out time);
        }

        public static bool IsNumber(string text)
        {
            int num;
            return int.TryParse(text, out num);
        }
    }
}
