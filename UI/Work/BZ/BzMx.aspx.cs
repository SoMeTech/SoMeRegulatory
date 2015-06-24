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
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using YYControls;
using SMZJ.BLL;
using SMZJ.Model;

public class Work_BZ_projBzMx : Page, IRequiresSessionState
{
    protected HtmlInputHidden BTFFID;
    protected DropDownList ddlPD_FOUND_XZ;
    protected DropDownList ddlPD_GK_DEPART;
    protected DropDownList ddlPD_PROJECT_IFFF;
    protected DropDownList ddlPD_PROJECT_IFGS;
    protected DropDownList ddlPD_PROJECT_IFGS_BEFORE;
    protected DropDownList ddlPD_PROJECT_STATUS;
    protected DropDownList ddlPD_PROJECT_TYPE;
    protected DropDownList ddlPD_YEAR;
    protected UserControls_FilePostCtr FilePostCtr1;
    public string json_BzGGXX = "";
    public string json_BzGGXX_Data = "";
    public string json_BzXmzl = "";
    public string json_BzXmzl_Data = "";
    protected HtmlInputText lblPD_PROJECT_CODE;
    protected TextBox lblPD_PROJECT_FILENO_ZB;
    protected TabPanel Panel_xmgk;
    protected TabPanel Panel_xmsbzl;
    protected TabContainer TabContainer1;
    protected TextBox txtPD_PROJECT_BZDX;
    protected TextBox txtPD_PROJECT_BZFF_DATE;
    protected TextBox txtPD_PROJECT_BZFW;
    protected TextBox txtPD_PROJECT_BZMONEY;
    protected TextBox txtPD_PROJECT_BZNUM;
    protected TextBox txtPD_PROJECT_BZSTAND_NUM;
    protected TextBox txtPD_PROJECT_BZYJ;
    protected TextBox txtPD_PROJECT_FILENO_JG;
    protected HtmlInputHidden txtPD_PROJECT_FILENO_ZB;
    protected TextBox txtPD_PROJECT_INPUT_COMPANY;
    protected TextBox txtPD_PROJECT_INPUT_DATE;
    protected TextBox txtPD_PROJECT_INPUT_MAN;
    protected TextBox txtPD_PROJECT_JG_RESULT;
    protected TextBox txtPD_PROJECT_JGJL;
    protected TextBox txtPD_PROJECT_JGYQ;
    protected TextBox txtPD_PROJECT_NAME;
    protected TextBox txtPD_PROJECT_OPEN_BODY;
    protected TextBox txtPD_PROJECT_SJFF_DATE;

    private void Bind(string PD_PROJECT_CODE, string CCXC)
    {
        DataSet ds = null;
        PD_PROJECT_INSPECTION_Bll bll = new PD_PROJECT_INSPECTION_Bll();
        string strWhere = " 1=0 ";
        if ((PD_PROJECT_CODE != null) && (PD_PROJECT_CODE != ""))
        {
            strWhere = " PD_PROJECT_CODE='" + PD_PROJECT_CODE.Trim() + "'";
        }
        if ((CCXC != null) && (CCXC.Trim() == "1"))
        {
            ds = bll.GetList(strWhere);
            this.json_BzGGXX_Data = PublicDal.DataToJSON(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Rows.Clear();
            }
            DataRow row = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(row);
            this.json_BzGGXX = PublicDal.DataToJSON(ds);
        }
        ds = new PD_PROJECT_ATTACH_BZ_Bll().GetList(strWhere);
        this.json_BzXmzl_Data = PublicDal.DataToJSON(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ds.Tables[0].Rows.Clear();
        }
        DataRow row2 = ds.Tables[0].NewRow();
        ds.Tables[0].Rows.Add(row2);
        this.json_BzXmzl = PublicDal.DataToJSON(ds);
    }

    private void BindDDList()
    {
        PublicDal.BindDropDownList(this.ddlPD_YEAR, "PD_BASE_YEAR", "YEAR_NAME", "YEAR_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_FOUND_XZ, "PD_BASE_FOUND_PROPERTY", "FOUND_PROPERTY_NAME", "FOUND_PROPERTY_CODE", "");
        this.ddlPD_FOUND_XZ.SelectedValue = "02";
        this.ddlPD_FOUND_XZ.Enabled = false;
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_TYPE, "PD_BASE_ProjectType", "ProjectType_Name", "PROJECTTYPE_CODE", "projecttype_year=" + this.ddlPD_YEAR.SelectedValue + " and zjxz_type='" + this.ddlPD_FOUND_XZ.SelectedValue + "'");
        this.ddlPD_PROJECT_TYPE.Items.Insert(0, new ListItem("", ""));
        PublicDal.BindDropDownList(this.ddlPD_GK_DEPART, "V_company_branch", "NAME", "BH", " comp_ishasbaby=1 ");
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_IFGS, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_IFGS_BEFORE, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_STATUS, "PD_BASE_STATUS", "STATUS_NAME", "STATUS_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_IFFF, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
    }

    public void Buttons(string ibtid)
    {
        switch (ibtid)
        {
            case "ibtcontrol_ibtprintnote":
                PageShowText.OpenPage(Public.RelativelyPath("Work/XMGL/proBuildAndAllowance.aspx") + "?UpdatePK=" + base.Request["UpdatePK"].Trim() + "&titlename=2", null, null, this.Page, true);
                PageShowText.Refurbish("", this.Page);
                break;

            case "ibtcontrol_ibtadd":
            case "ibtcontrol_ibtupdate":
                break;

            case "ibtcontrol_ibtdelete":
                this.DelData(base.Request["UpdatePK"].Trim(), base.Request["ccxc"]);
                return;

            case "ibtcontrol_ibtsave":
                if ((base.Request["UpdatePK"] != null) && (base.Request["UpdatePK"].Trim() != ""))
                {
                    this.UpdataData(base.Request["UpdatePK"].Trim(), base.Request["ccxc"]);
                    return;
                }
                this.CreateData(base.Request["ccxc"]);
                return;

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

    private void CreateData(string CCXC)
    {
        string strErr = "";
        if (!this.Panduan(ref strErr))
        {
            this.TabContainer1.ActiveTabIndex = 0;
        }
        else
        {
            TB_PROJECT_BZ_Model model = this.GetModel(null);
            model.PD_PROJECT_SERVERPK = PublicDal.SetCreateServiceStream(this.Page);
            new TB_PROJECT_BZ_Bll().Add(model);
            PD_PROJECT_ATTACH_BZ_Bll bll2 = new PD_PROJECT_ATTACH_BZ_Bll();
            List<PD_PROJECT_ATTACH_BZ_Model> modelList = this.GetATTACH_BZ_Model(model.PD_PROJECT_CODE);
            bll2.AddList(modelList);
            PD_PROJECT_INSPECTION_Bll bll3 = new PD_PROJECT_INSPECTION_Bll();
            List<PD_PROJECT_INSPECTION_Model> inspectionModel = this.GetInspectionModel(model.PD_PROJECT_CODE);
            bll3.AddList(inspectionModel);
            Const.DoSuccessNoClose("添加成功", this.Page.Request.Url.LocalPath + "?UpdatePK=" + model.PD_PROJECT_CODE, this.Page);
        }
    }

    private void DelData(string PD_PROJECT_CODE, string CCXC)
    {
        new TB_PROJECT_BZ_Bll().Delete(PD_PROJECT_CODE);
        if ((CCXC != null) && (CCXC.Trim() == "1"))
        {
            new PD_PROJECT_INSPECTION_Bll().Delete(PD_PROJECT_CODE, " and PD_DB_LOOP=0 ");
        }
        new PD_PROJECT_ATTACH_BZ_Bll().DeletePROJECT(PD_PROJECT_CODE);
        PageShowText.Refurbish("删除成功", this.Page);
    }

    private List<PD_PROJECT_ATTACH_BZ_Model> GetATTACH_BZ_Model(string PD_PROJECT_CODE)
    {
        List<PD_PROJECT_ATTACH_BZ_Model> list = new List<PD_PROJECT_ATTACH_BZ_Model>();
        if (base.Request.Form["table_BzXmzl_file_type"] != null)
        {
            string[] strArray = base.Request.Form["table_BzXmzl_file_type"].Split(new char[] { ',' });
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
                PD_PROJECT_ATTACH_BZ_Model item = new PD_PROJECT_ATTACH_BZ_Model
                {
                    PD_PROJECT_CODE = PD_PROJECT_CODE
                };
                if (defaultView != null)
                {
                    defaultView.RowFilter = " tableID='table_BzXmzl' and rowIndex=" + (i + 1);
                    if (defaultView.Count > 0)
                    {
                        item.PD_PROJECT_ATTACH_NAME = defaultView[0]["FileName"].ToString();
                        item.PD_PROJECT_ATTACH_NAME_SYSTEM = defaultView[0]["FileSysName"].ToString();
                    }
                }
                list.Add(item);
            }
        }
        return list;
    }

    private DataTable GetGridViewData(SmartGridView objGridView, bool Del)
    {
        DataTable table = new DataTable();
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
                            case "PD_CONTRACT_PiCi":
                                {
                                    row2[num2++] = ((DropDownList)row.Cells[j].Controls[2]).Text;
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

    private List<PD_PROJECT_INSPECTION_Model> GetInspectionModel(string PD_PROJECT_CODE)
    {
        List<PD_PROJECT_INSPECTION_Model> list = new List<PD_PROJECT_INSPECTION_Model>();
        if (base.Request.Form["BzGGXX_PD_PROJECT_CODE"] != null)
        {
            string[] strArray = base.Request.Form["BzGGXX_PD_PROJECT_CODE"].Split(new char[] { ',' });
            string[] strArray2 = base.Request.Form["BzGGXX_PD_INSPECTION_PROCESS"].Split(new char[] { ',' });
            string[] strArray3 = base.Request.Form["BzGGXX_PD_INSPECTION_DATE"].Split(new char[] { ',' });
            string[] strArray4 = base.Request.Form["BzGGXX_PD_INSPECTION_MANS"].Split(new char[] { ',' });
            string[] strArray5 = base.Request.Form["BzGGXX_PD_INSPECTION_ADDR"].Split(new char[] { ',' });
            string[] strArray6 = base.Request.Form["BzGGXX_PD_INSPECTION_CONTENT"].Split(new char[] { ',' });
            string[] strArray7 = base.Request.Form["BzGGXX_PD_INSPECTION_SUGGEST"].Split(new char[] { ',' });
            string[] strArray8 = base.Request.Form["BzGGXX_PD_INSPECTION_CONCLUSION"].Split(new char[] { ',' });
            string[] strArray9 = base.Request.Form["BzGGXX_PD_INSPECTION_FILENAME"].Split(new char[] { ',' });
            string[] strArray10 = base.Request.Form["BzGGXX_PD_INSPECTION_PEASANT"].Split(new char[] { ',' });
            string[] strArray11 = base.Request.Form["BzGGXX_PD_INSPECTION_IDNO"].Split(new char[] { ',' });
            string[] strArray12 = base.Request.Form["BzGGXX_PD_INSPECTION_FFNUM"].Split(new char[] { ',' });
            string[] strArray13 = base.Request.Form["BzGGXX_PD_INSPECTION_FFSTAND"].Split(new char[] { ',' });
            string[] strArray14 = base.Request.Form["BzGGXX_PD_INSPECTION_FFMONEY"].Split(new char[] { ',' });
            string[] strArray15 = base.Request.Form["BzGGXX_PD_INSPECTION_ACCOUNTNO"].Split(new char[] { ',' });
            string[] strArray16 = base.Request.Form["BzGGXX_PD_INSPECTION_PEASANT_ADDR"].Split(new char[] { ',' });
            string[] strArray17 = base.Request.Form["Hidden_PD_INSPECTION_BTFFID"].Split(new char[] { ',' });
            string[] strArray18 = base.Request.Form["BzGGXX_PD_INSPECTION_BTFFNAME"].Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                PD_PROJECT_INSPECTION_Model item = new PD_PROJECT_INSPECTION_Model
                {
                    PD_PROJECT_CODE = PD_PROJECT_CODE,
                    PD_INSPECTION_PROCESS = strArray2[i]
                };
                if (PublicDal.PageValidate.IsDateTime(strArray3[i]))
                {
                    item.PD_INSPECTION_DATE = new DateTime?(DateTime.Parse(strArray3[i]));
                }
                item.PD_INSPECTION_MANS = strArray4[i];
                item.PD_INSPECTION_ADDR = strArray5[i];
                item.PD_INSPECTION_CONTENT = strArray6[i];
                item.PD_INSPECTION_SUGGEST = strArray7[i];
                item.PD_INSPECTION_CONCLUSION = strArray8[i];
                item.PD_INSPECTION_FILENAME = strArray9[i];
                item.PD_INSPECTION_PEASANT = strArray10[i];
                item.PD_INSPECTION_IDNO = strArray11[i];
                if (PublicDal.PageValidate.IsNumber(strArray12[i]))
                {
                    item.PD_INSPECTION_FFNUM = new int?(int.Parse(strArray12[i]));
                }
                if (PublicDal.PageValidate.IsNumber(strArray12[i]))
                {
                    item.PD_INSPECTION_FFSTAND = new decimal?(int.Parse(strArray13[i]));
                }
                if (PublicDal.PageValidate.IsNumber(strArray12[i]))
                {
                    item.PD_INSPECTION_FFMONEY = new decimal?(int.Parse(strArray14[i]));
                }
                item.PD_INSPECTION_ACCOUNTNO = strArray15[i];
                item.PD_INSPECTION_PEASANT_ADDR = strArray16[i];
                item.PD_INSPECTION_BTFFID = strArray17[i];
                item.PD_INSPECTION_BTFFNAME = strArray18[i];
                list.Add(item);
            }
        }
        return list;
    }

    private TB_PROJECT_BZ_Model GetModel(TB_PROJECT_BZ_Model model)
    {
        if (model == null)
        {
            model = new TB_PROJECT_BZ_Model();
            this.txtPD_PROJECT_INPUT_COMPANY.Text = ((UserModel)HttpContext.Current.Session["User"]).Company.pk_corp;
            this.txtPD_PROJECT_INPUT_MAN.Text = ((UserModel)HttpContext.Current.Session["User"]).UserName;
        }
        string str = this.txtPD_PROJECT_FILENO_ZB.Value;
        string text = this.txtPD_PROJECT_NAME.Text;
        int num = int.Parse(this.ddlPD_YEAR.SelectedValue);
        string selectedValue = this.ddlPD_PROJECT_TYPE.SelectedValue;
        string str4 = this.ddlPD_GK_DEPART.SelectedValue;
        string str5 = this.ddlPD_FOUND_XZ.SelectedValue;
        if (PublicDal.PageValidate.IsNumber(this.ddlPD_PROJECT_IFGS.SelectedValue))
        {
            model.PD_PROJECT_IFGS = new int?(int.Parse(this.ddlPD_PROJECT_IFGS.SelectedValue));
        }
        if (PublicDal.PageValidate.IsNumber(this.ddlPD_PROJECT_IFGS_BEFORE.SelectedValue))
        {
            model.PD_PROJECT_IFGS_BEFORE = new int?(int.Parse(this.ddlPD_PROJECT_IFGS_BEFORE.SelectedValue));
        }
        string str6 = this.txtPD_PROJECT_OPEN_BODY.Text;
        string str7 = this.ddlPD_PROJECT_STATUS.SelectedValue;
        string str8 = this.txtPD_PROJECT_FILENO_JG.Text;
        string str9 = this.txtPD_PROJECT_BZYJ.Text;
        string str10 = this.txtPD_PROJECT_BZFW.Text;
        string str11 = this.txtPD_PROJECT_BZDX.Text;
        if (PublicDal.PageValidate.IsNumber(this.txtPD_PROJECT_BZNUM.Text))
        {
            model.PD_PROJECT_BZNUM = new decimal?(decimal.Parse(this.txtPD_PROJECT_BZNUM.Text));
        }
        model.PD_PROJECT_BZSTAND_NUM = this.txtPD_PROJECT_BZSTAND_NUM.Text;
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_PROJECT_BZMONEY.Text))
        {
            model.PD_PROJECT_BZMONEY = new decimal?(decimal.Parse(this.txtPD_PROJECT_BZMONEY.Text));
        }
        if (PublicDal.PageValidate.IsDateTime(this.txtPD_PROJECT_BZFF_DATE.Text))
        {
            model.PD_PROJECT_BZFF_DATE = new DateTime?(DateTime.Parse(this.txtPD_PROJECT_BZFF_DATE.Text));
        }
        if (PublicDal.PageValidate.IsDateTime(this.txtPD_PROJECT_SJFF_DATE.Text))
        {
            model.PD_PROJECT_SJFF_DATE = new DateTime?(DateTime.Parse(this.txtPD_PROJECT_SJFF_DATE.Text));
        }
        if (PublicDal.PageValidate.IsNumber(this.ddlPD_PROJECT_IFFF.SelectedValue))
        {
            model.PD_PROJECT_IFFF = new int?(int.Parse(this.ddlPD_PROJECT_IFFF.SelectedValue));
        }
        string str12 = this.txtPD_PROJECT_JGYQ.Text;
        string str13 = this.txtPD_PROJECT_JGJL.Text;
        string str14 = this.txtPD_PROJECT_JG_RESULT.Text;
        model.PD_PROJECT_FILENO_ZB = str;
        model.PD_PROJECT_NAME = text;
        model.PD_YEAR = new int?(num);
        model.PD_PROJECT_TYPE = selectedValue;
        model.PD_GK_DEPART = str4;
        model.PD_FOUND_XZ = str5;
        model.PD_PROJECT_OPEN_BODY = str6;
        model.PD_PROJECT_STATUS = str7;
        model.PD_PROJECT_FILENO_JG = str8;
        model.PD_PROJECT_BZYJ = str9;
        model.PD_PROJECT_BZFW = str10;
        model.PD_PROJECT_BZDX = str11;
        model.PD_PROJECT_JGYQ = str12;
        model.PD_PROJECT_JGJL = str13;
        model.PD_PROJECT_JG_RESULT = str14;
        model.PD_PROJECT_INPUT_DATE = DateTime.Now.ToString("yyyy-MM-dd");
        model.PD_PROJECT_INPUT_COMPANY = ((UserModel)this.Session["User"]).Company.pk_corp;
        model.PD_PROJECT_INPUT_MAN = ((UserModel)this.Session["User"]).UserName;
        return model;
    }

    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }

    protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void gvResult_Sorting(object sender, GridViewSortEventArgs e)
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
            this.Master.strTitle = "补助性项目登记";
            this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
            this.Master.SearchHasGone = new SearchHandler(this.SearchControl);
            ButtonsModel model = null;
            if (base.Request["UpdatePK"] != null)
            {
                PublicDal.ShowMxButton(this.Page, out model, "TB_PROJECT", "PD_PROJECT_CODE", base.Request["UpdatePK"].Trim(), "PD_PROJECT_SERVERPK");
            }
            else
            {
                PublicDal.ShowMxButton(this.Page, out model, "TB_PROJECT", "PD_PROJECT_CODE", "", "PD_PROJECT_SERVERPK");
            }
            this.Master.btModel = model;
            if (!base.IsPostBack)
            {
                this.Master.TabContainer1 = this.TabContainer1;
                this.BindDDList();
                this.txtPD_PROJECT_INPUT_DATE.Text = Convert.ToDateTime(DateTime.Now.ToString()).ToString("yyyy-MM-dd");
                this.txtPD_PROJECT_INPUT_COMPANY.Text = ((UserModel)HttpContext.Current.Session["User"]).Company.Name;
                this.txtPD_PROJECT_INPUT_MAN.Text = ((UserModel)HttpContext.Current.Session["User"]).UserName;
                if ((base.Request["UpdatePK"] != null) && (base.Request["UpdatePK"].Trim() != ""))
                {
                    model.IfPrintNote = true;
                    model.IbtPrintNoteText = "打印";
                    this.ShowInfo(base.Request["UpdatePK"].Trim());
                    this.Bind(base.Request["UpdatePK"], base.Request["ccxc"]);
                }
                else
                {
                    this.Bind(null, base.Request["ccxc"]);
                }
            }
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
    }

    private bool Panduan(ref string strErr)
    {
        if (this.txtPD_PROJECT_FILENO_ZB.Value.Trim().Length == 0)
        {
            strErr = strErr + @"上级指标文号不能为空！\n";
        }
        if (this.txtPD_PROJECT_NAME.Text.Trim().Length == 0)
        {
            strErr = strErr + @"项目名称不能为空！\n";
        }
        if (!PageValidate.IsNumber(this.ddlPD_YEAR.SelectedValue))
        {
            strErr = strErr + @"项目年度格式错误！\n";
        }
        if (this.ddlPD_PROJECT_TYPE.SelectedValue.Trim().Length == 0)
        {
            strErr = strErr + @"项目类别不能为空！\n";
        }
        if (this.ddlPD_GK_DEPART.SelectedValue.Trim().Length == 0)
        {
            strErr = strErr + @"归口部门编码不能为空！\n";
        }
        if (this.ddlPD_FOUND_XZ.SelectedValue.Trim().Length == 0)
        {
            strErr = strErr + @"资金性质不能为空！\n";
        }
        if (strErr != "")
        {
            PageShowText.ShowMessage(strErr, this.Page);
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

    private void ShowInfo(string PD_PROJECT_CODE)
    {
        TB_PROJECT_BZ_Model modelName = new TB_PROJECT_BZ_Bll().GetModelName(PD_PROJECT_CODE);
        this.lblPD_PROJECT_FILENO_ZB.Text = modelName.PD_PROJECT_FILENO_ZB;
        this.txtPD_PROJECT_FILENO_ZB.Value = modelName.PD_PROJECT_FILENO_ZB_CODE;
        this.lblPD_PROJECT_CODE.Value = modelName.PD_PROJECT_CODE;
        this.txtPD_PROJECT_NAME.Text = modelName.PD_PROJECT_NAME;
        this.ddlPD_YEAR.SelectedValue = modelName.PD_YEAR.ToString();
        this.ddlPD_PROJECT_TYPE.SelectedValue = modelName.PD_PROJECT_TYPE;
        this.ddlPD_GK_DEPART.SelectedValue = modelName.PD_GK_DEPART;
        this.ddlPD_FOUND_XZ.SelectedValue = modelName.PD_FOUND_XZ;
        this.ddlPD_PROJECT_IFGS.SelectedValue = modelName.PD_PROJECT_IFGS.ToString();
        this.ddlPD_PROJECT_IFGS_BEFORE.SelectedValue = modelName.PD_PROJECT_IFGS_BEFORE.ToString();
        this.txtPD_PROJECT_OPEN_BODY.Text = modelName.PD_PROJECT_OPEN_BODY;
        this.ddlPD_PROJECT_STATUS.SelectedValue = modelName.PD_PROJECT_STATUS;
        this.txtPD_PROJECT_FILENO_JG.Text = modelName.PD_PROJECT_FILENO_JG;
        this.txtPD_PROJECT_INPUT_COMPANY.Text = modelName.PD_PROJECT_INPUT_COMPANY;
        this.txtPD_PROJECT_INPUT_MAN.Text = modelName.PD_PROJECT_INPUT_MAN;
        this.txtPD_PROJECT_INPUT_DATE.Text = modelName.PD_PROJECT_INPUT_DATE;
        this.txtPD_PROJECT_BZYJ.Text = modelName.PD_PROJECT_BZYJ;
        this.txtPD_PROJECT_BZFW.Text = modelName.PD_PROJECT_BZFW;
        this.txtPD_PROJECT_BZDX.Text = modelName.PD_PROJECT_BZDX;
        this.txtPD_PROJECT_BZNUM.Text = modelName.PD_PROJECT_BZNUM.ToString();
        this.txtPD_PROJECT_BZSTAND_NUM.Text = modelName.PD_PROJECT_BZSTAND_NUM.ToString();
        this.txtPD_PROJECT_BZMONEY.Text = Convert.ToDecimal(!modelName.PD_PROJECT_BZMONEY.HasValue ? 0 : modelName.PD_PROJECT_BZMONEY).ToString("F2");
        this.txtPD_PROJECT_BZFF_DATE.Text = modelName.PD_PROJECT_BZFF_DATE.ToString();
        this.txtPD_PROJECT_SJFF_DATE.Text = modelName.PD_PROJECT_SJFF_DATE.ToString();
        this.ddlPD_PROJECT_IFFF.SelectedValue = modelName.PD_PROJECT_IFFF.ToString();
        this.txtPD_PROJECT_JGYQ.Text = modelName.PD_PROJECT_JGYQ;
        this.txtPD_PROJECT_JGJL.Text = modelName.PD_PROJECT_JGJL;
        this.txtPD_PROJECT_JG_RESULT.Text = modelName.PD_PROJECT_JG_RESULT;
    }

    private void UpdataData(string PD_PROJECT_CODE, string CCXC)
    {
        string strErr = "";
        if (!this.Panduan(ref strErr))
        {
            this.TabContainer1.ActiveTabIndex = 0;
        }
        else
        {
            TB_PROJECT_BZ_Bll bll = new TB_PROJECT_BZ_Bll();
            TB_PROJECT_BZ_Model model = this.GetModel(bll.GetModel(PD_PROJECT_CODE));
            model.PD_PROJECT_CODE = PD_PROJECT_CODE;
            bll.Update(model);
            PD_PROJECT_ATTACH_BZ_Bll bll2 = new PD_PROJECT_ATTACH_BZ_Bll();
            List<PD_PROJECT_ATTACH_BZ_Model> modelList = this.GetATTACH_BZ_Model(model.PD_PROJECT_CODE);
            bll2.Delete(model.PD_PROJECT_CODE);
            bll2.AddList(modelList);
            PD_PROJECT_INSPECTION_Bll bll3 = new PD_PROJECT_INSPECTION_Bll();
            List<PD_PROJECT_INSPECTION_Model> inspectionModel = this.GetInspectionModel(model.PD_PROJECT_CODE);
            bll3.Delete(model.PD_PROJECT_CODE, " and PD_DB_LOOP=0 ");
            bll3.AddList(inspectionModel);
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
