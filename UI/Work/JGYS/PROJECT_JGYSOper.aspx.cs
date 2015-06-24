using ASP;
using ExtExtenders;
using SoMeTech.CommonDll;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using SMZJ.BLL;
using SMZJ.Model;

public class Work_JGYS_PROJECT_JGYS : Page, IRequiresSessionState
{
    protected DropDownList ddlPD_PROJECT_YS_COMPANY;
    protected DropDownList ddlPD_PROJECT_YS_RESULT;
    protected UserControls_FilePostCtr FilePostCtr1;
    public string json_xmyszl = "";
    public string jsonData_xmyszl = "";
    protected Label lblAUTO_NO_JGYS;
    protected TextBox lblPD_FOUND_XZ;
    protected TextBox lblPD_GK_DEPART;
    protected TextBox lblPD_PROJECT_BEGIN_DATE;
    protected TextBox lblPD_PROJECT_CODE;
    protected TextBox lblPD_PROJECT_CONTENT;
    protected TextBox lblPD_PROJECT_COUNTRY;
    protected TextBox lblPD_PROJECT_CWFZR;
    protected TextBox lblPD_PROJECT_END_DATE;
    protected TextBox lblPD_PROJECT_FILENO_JG;
    protected TextBox lblPD_PROJECT_FILENO_PF;
    protected TextBox lblPD_PROJECT_FZR;
    protected TextBox lblPD_PROJECT_IFGS;
    protected TextBox lblPD_PROJECT_IFGS_BEFORE;
    protected TextBox lblPD_PROJECT_IFXZGL;
    protected TextBox lblPD_PROJECT_INPUT_COMPANY;
    protected TextBox lblPD_PROJECT_INPUT_DATE;
    protected TextBox lblPD_PROJECT_INPUT_MAN;
    protected TextBox lblPD_PROJECT_MONEY_ADDR;
    protected TextBox lblPD_PROJECT_NAME;
    protected TextBox lblPD_PROJECT_OPEN_BODY;
    protected TextBox lblPD_PROJECT_REPLY_COMPANY;
    protected TextBox lblPD_PROJECT_REPLY_DATE;
    protected TextBox lblPD_PROJECT_REPLY_MAN2;
    protected TextBox lblPD_PROJECT_STATUS;
    protected TextBox lblPD_PROJECT_SYRS;
    protected TextBox lblPD_PROJECT_TYPE;
    protected TextBox lblPD_PROJECT_XMYT;
    protected TextBox lblPD_PROJECT_YEARS;
    protected TextBox lblPD_PROJECT_ZGKJ;
    protected TextBox lblPD_PROJECT_ZJLY;
    protected TextBox lblPD_YEAR;
    protected TabPanel Panel_jgys;
    protected TabPanel Panel_xmgk;
    protected TabPanel Panel_xmpj;
    protected TabContainer TabContainer11;
    protected TabPanel TabPanel6;
    protected TextBox txtAUTO_NO_APPRAISE;
    protected TextBox txtPD_GK_DEPART;
    protected TextBox txtPD_PROJECT_APP_COMPANY;
    protected TextBox txtPD_PROJECT_APP_COMPANY_LIST;
    protected HtmlInputText txtPD_PROJECT_APP_DATE;
    protected TextBox txtPD_PROJECT_APP_MAN_LIST;
    protected TextBox txtPD_PROJECT_APPRAISE_FILENO;
    protected HtmlInputText txtPD_PROJECT_COMPLETE_DATE;
    protected HtmlInputHidden txtPD_PROJECT_FILENO_PF;
    protected TextBox txtPD_PROJECT_YS_CONDITION;
    protected HtmlInputText txtPD_PROJECT_YS_DATE;
    protected TextBox txtPD_PROJECT_YS_NAME;
    protected TextBox txtPD_PROJECT_YS_SUGGEST;
    protected TextBox txtPD_PROJECT_YS_ZRR;
    protected HtmlInputText txtPD_PROJECT_YSSQ_DATE;

    private void Bind(string PD_PROJECT_CODE)
    {
    }

    private void BindDDList()
    {
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_YS_COMPANY, "DB_Company", "Name", "PK_CORP", "");
        this.ddlPD_PROJECT_YS_COMPANY.SelectedValue = ((UserModel)this.Session["User"]).Company.pk_corp;
        if (this.txtPD_PROJECT_APP_DATE.Value.Trim() == "")
        {
            this.txtPD_PROJECT_APP_DATE.Value = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }

    protected void btnAddSave_Click(object sender, EventArgs e)
    {
        string text = this.lblPD_PROJECT_CODE.Text;
        DateTime time = DateTime.Parse(this.txtPD_PROJECT_COMPLETE_DATE.Value);
        DateTime time2 = DateTime.Parse(this.txtPD_PROJECT_YSSQ_DATE.Value);
        DateTime time3 = DateTime.Parse(this.txtPD_PROJECT_YS_DATE.Value);
        string selectedValue = this.ddlPD_PROJECT_YS_COMPANY.SelectedValue;
        string str3 = this.txtPD_PROJECT_YS_ZRR.Text;
        string str4 = this.txtPD_PROJECT_YS_NAME.Text;
        string str5 = this.txtPD_PROJECT_YS_SUGGEST.Text;
        string str6 = this.ddlPD_PROJECT_YS_RESULT.SelectedItem.Text;
        string str7 = this.txtPD_PROJECT_YS_CONDITION.Text;
        PD_PROJECT_JGYS_Model model = new PD_PROJECT_JGYS_Model
        {
            PD_PROJECT_CODE = text,
            PD_PROJECT_COMPLETE_DATE = new DateTime?(time),
            PD_PROJECT_YSSQ_DATE = new DateTime?(time2),
            PD_PROJECT_YS_DATE = new DateTime?(time3),
            PD_PROJECT_YS_COMPANY = selectedValue,
            PD_PROJECT_YS_ZRR = str3,
            PD_PROJECT_YS_NAME = str4,
            PD_PROJECT_YS_SUGGEST = str5,
            PD_PROJECT_YS_RESULT = str6,
            PD_PROJECT_YS_CONDITION = str7
        };
        new PD_PROJECT_JGYS_Bll().Add(model);
        PageShowText.Refurbish("添加成功", this.Page);
    }

    protected void btnDeleteRow_Click(object sender, EventArgs e)
    {
    }

    protected void btnSave_PingJia_Click(object sender, EventArgs e)
    {
        if (this.Panduan_PingJia())
        {
            int num = int.Parse(this.lblAUTO_NO_JGYS.Text);
            string text = this.lblPD_PROJECT_CODE.Text;
            DateTime time = DateTime.Parse(this.txtPD_PROJECT_APP_DATE.Value);
            string str2 = this.txtPD_PROJECT_APP_COMPANY.Text;
            string str3 = this.txtPD_PROJECT_APP_COMPANY_LIST.Text;
            string str4 = this.txtPD_PROJECT_APP_MAN_LIST.Text;
            string str5 = this.txtPD_PROJECT_APPRAISE_FILENO.Text;
            PD_PROJECT_APPRAISE_Model model = new PD_PROJECT_APPRAISE_Model
            {
                AUTO_NO = num,
                PD_PROJECT_CODE = text,
                PD_PROJECT_APP_DATE = new DateTime?(time),
                PD_PROJECT_APP_COMPANY = str2,
                PD_PROJECT_APP_COMPANY_LIST = str3,
                PD_PROJECT_APP_MAN_LIST = str4,
                PD_PROJECT_APPRAISE_FILENO = str5
            };
            new PD_PROJECT_APPRAISE_Bll().Add(model);
        }
    }

    public void btnUpdateSave_Click(object sender, EventArgs e)
    {
    }

    public void Buttons(string ibtid)
    {
        switch (ibtid)
        {
            case "ibtcontrol_ibtdelete":
                this.DelData(base.Request["UpdatePK"].Trim());
                return;

            case "ibtcontrol_ibtsave":
                if ((base.Request["UpdatePK"] == null) || !(base.Request["UpdatePK"].Trim() != ""))
                {
                    this.CreateData();
                    return;
                }
                this.UpdataData(base.Request["UpdatePK"]);
                return;

            case "ibtcontrol_ibtrefresh":
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
                this.SetServiceStream(0, base.Request.Params["UpdatePK"], "弃审");
                return;
        }
    }

    private void CreateData()
    {
        this.CreateData_JGYS();
    }

    private void CreateData_JGYS()
    {
        string strErr = "";
        if (!this.Panduan_JGYS(ref strErr))
        {
            this.hy_File(null, strErr);
        }
        else
        {
            string text = this.lblPD_PROJECT_CODE.Text;
            DateTime time = DateTime.Parse(this.txtPD_PROJECT_COMPLETE_DATE.Value);
            DateTime time2 = DateTime.Parse(this.txtPD_PROJECT_YSSQ_DATE.Value);
            DateTime time3 = DateTime.Parse(this.txtPD_PROJECT_YS_DATE.Value);
            string selectedValue = this.ddlPD_PROJECT_YS_COMPANY.SelectedValue;
            string str4 = this.txtPD_PROJECT_YS_ZRR.Text;
            string str5 = this.txtPD_PROJECT_YS_NAME.Text;
            string str6 = this.txtPD_PROJECT_YS_SUGGEST.Text;
            string str7 = this.ddlPD_PROJECT_YS_RESULT.SelectedItem.Text;
            string str8 = this.txtPD_PROJECT_YS_CONDITION.Text;
            PD_PROJECT_JGYS_Model model = new PD_PROJECT_JGYS_Model
            {
                PD_PROJECT_CODE = text,
                PD_PROJECT_COMPLETE_DATE = new DateTime?(time),
                PD_PROJECT_YSSQ_DATE = new DateTime?(time2),
                PD_PROJECT_YS_DATE = new DateTime?(time3),
                PD_PROJECT_YS_COMPANY = selectedValue,
                PD_PROJECT_YS_ZRR = str4,
                PD_PROJECT_YS_NAME = str5,
                PD_PROJECT_YS_SUGGEST = str6,
                PD_PROJECT_YS_RESULT = str7,
                PD_PROJECT_YS_CONDITION = str8
            };
            PD_PROJECT_APPRAISE_Model model2 = new PD_PROJECT_APPRAISE_Model();
            string str9 = this.txtAUTO_NO_APPRAISE.Text;
            string str10 = this.txtPD_PROJECT_APP_COMPANY.Text;
            string str11 = this.txtPD_PROJECT_APP_COMPANY_LIST.Text;
            string str12 = this.txtPD_PROJECT_APP_MAN_LIST.Text;
            string str13 = this.txtPD_PROJECT_APPRAISE_FILENO.Text;
            if (!PublicDal.PageValidate.IsNumber(str9))
            {
                str9 = "-1";
            }
            model2.AUTO_NO = int.Parse(str9);
            model2.PD_PROJECT_CODE = text;
            model2.PD_PROJECT_APP_COMPANY = str10;
            model2.PD_PROJECT_APP_COMPANY_LIST = str11;
            model2.PD_PROJECT_APP_MAN_LIST = str12;
            model2.PD_PROJECT_APPRAISE_FILENO = str13;
            new PD_PROJECT_JGYS_Bll().Add(model);
            new PD_PROJECT_APPRAISE_Bll().Add(model2);
            this.UpdateDateXMPJ("");
            Const.DoSuccessNoClose("添加成功", this.Page.Request.Url.LocalPath + "?UpdatePK=" + model.PD_PROJECT_CODE, this.Page);
        }
    }

    private void DelData(string p)
    {
        throw new NotImplementedException();
    }

    private List<PD_PROJECT_ATTACH_YS_Model> GetAttach_SSModel(string PD_PROJECT_CODE)
    {
        List<PD_PROJECT_ATTACH_YS_Model> list = new List<PD_PROJECT_ATTACH_YS_Model>();
        if (base.Request.Form["table_xmyszl_PD_PROJECT_CODE"] != null)
        {
            string[] strArray = base.Request.Form["table_xmyszl_PD_PROJECT_CODE"].Split(new char[] { ',' });
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
                PD_PROJECT_ATTACH_YS_Model item = new PD_PROJECT_ATTACH_YS_Model
                {
                    PD_PROJECT_CODE = strArray[i]
                };
                if (defaultView != null)
                {
                    defaultView.RowFilter = " tableID='table_xmyszl' and rowIndex=" + (i + 1);
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

    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }

    protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void gvResult_Sorting(object sender, GridViewSortEventArgs e)
    {
    }

    private void hy_File(List<PD_PROJECT_ATTACH_YS_Model> SS_Model, string ShowText)
    {
        if (SS_Model == null)
        {
            SS_Model = this.GetAttach_SSModel(base.Request["UpdatePK"]);
        }
        DataSet ds = new DataSet();
        ds.Tables.Add();
        ds.Tables[0].Columns.Add("AUTO_NO");
        ds.Tables[0].Columns.Add("PD_PROJECT_CODE");
        ds.Tables[0].Columns.Add("PD_PROJECT_ATTACH_NAME");
        ds.Tables[0].Columns.Add("PD_PROJECT_ATTACH_NAME_SYSTEM");
        int num = 0;
        foreach (PD_PROJECT_ATTACH_YS_Model model in SS_Model)
        {
            DataRow row = ds.Tables[0].NewRow();
            row["AUTO_NO"] = num++;
            row["PD_PROJECT_CODE"] = model.PD_PROJECT_CODE;
            row["PD_PROJECT_ATTACH_NAME"] = model.PD_PROJECT_ATTACH_NAME;
            row["PD_PROJECT_ATTACH_NAME_SYSTEM"] = model.PD_PROJECT_ATTACH_NAME_SYSTEM;
            ds.Tables[0].Rows.Add(row);
        }
        string str = "BindDateAll();PostLoadxmsszl('table_xmyszl',eval(decodeURIComponent(\"" + base.Server.UrlEncode(PublicDal.DataToJSON(ds)) + "\")),'xmss_5');";
        if (ShowText != null)
        {
            str = "alert(\"" + ShowText + "\");" + str;
        }
        this.FilePostCtr1.value = "";
        PageShowText.Run_javascript(str, this.Page);
    }

    protected void lbtnAddRow_Click(object sender, EventArgs e)
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (base.Request["strTitle"] != null)
        {
            this.Master.strTitle = base.Request["strTitle"];
        }
        this.Master.strTitle = base.Request["strTitle"];
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        this.Master.SearchHasGone = new SearchHandler(this.SearchControl);
        ButtonsModel model = null;
        PublicDal.ShowMxButton(this.Page, out model, "TB_PROJECT", "PD_PROJECT_CODE", base.Request["UpdatePK"], "PD_PROJECT_SERVERPK");
        this.Master.btModel = model;
        if (!base.IsPostBack)
        {
            if ((base.Request["UpdatePK"] != null) && (base.Request["UpdatePK"].Trim() != ""))
            {
                this.ShowInfo(base.Request["UpdatePK"].Trim());
                this.ShowInfo1(base.Request["UpdatePK"].Trim());
                this.Bind(base.Request["UpdatePK"]);
            }
            this.BindDDList();
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
    }

    private bool Panduan_JGYS(ref string strErr)
    {
        if (this.lblPD_PROJECT_CODE.Text.Trim().Length == 0)
        {
            strErr = strErr + @"项目编码不能为空！\n";
        }
        if (!PublicDal.PageValidate.IsDateTime(this.txtPD_PROJECT_COMPLETE_DATE.Value))
        {
            strErr = strErr + @"项目竣工日期格式错误！\n";
        }
        if (!PublicDal.PageValidate.IsDateTime(this.txtPD_PROJECT_YSSQ_DATE.Value))
        {
            strErr = strErr + @"项目验收申请日期格式错误！\n";
        }
        if (!PublicDal.PageValidate.IsDateTime(this.txtPD_PROJECT_YS_DATE.Value))
        {
            strErr = strErr + @"项目验收日期格式错误！\n";
        }
        if (this.ddlPD_PROJECT_YS_COMPANY.SelectedValue.Trim().Length == 0)
        {
            strErr = strErr + @"项目验收单位不能为空！\n";
        }
        if (this.txtPD_PROJECT_YS_ZRR.Text.Trim().Length == 0)
        {
            strErr = strErr + @"项目验收责任人不能为空！\n";
        }
        if (this.txtPD_PROJECT_YS_NAME.Text.Trim().Length == 0)
        {
            strErr = strErr + @"项目验收人员名单不能为空！\n";
        }
        if (this.txtPD_PROJECT_YS_SUGGEST.Text.Trim().Length == 0)
        {
            strErr = strErr + @"项目验收意见不能为空！\n";
        }
        if (this.ddlPD_PROJECT_YS_RESULT.SelectedItem.Text.Trim().Length == 0)
        {
            strErr = strErr + @"项目验收结论不能为空！\n";
        }
        if (this.txtPD_PROJECT_YS_CONDITION.Text.Trim().Length == 0)
        {
            strErr = strErr + @"存在主要问题整改不能为空！\n";
        }
        if (strErr != "")
        {
            return false;
        }
        return true;
    }

    private bool Panduan_PingJia()
    {
        return true;
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
    }

    public void SetServiceStream(int operation, string PD_PROJECT_CODE, string Mess)
    {
        PublicDal.SetServiceStream(this.Page, operation, "TB_PROJECT", "PD_PROJECT_CODE", PD_PROJECT_CODE, Mess, "PD_PROJECT_SERVERPK");
    }

    private void ShowInfo(int AUTO_NO)
    {
    }

    private void ShowInfo(string PD_PROJECT_CODE)
    {
        TB_PROJECT_Model modelName = new TB_PROJECT_Bll().GetModelName(PD_PROJECT_CODE);
        this.lblPD_PROJECT_CODE.Text = modelName.PD_PROJECT_CODE;
        this.lblPD_PROJECT_NAME.Text = modelName.PD_PROJECT_NAME;
        this.lblPD_YEAR.Text = modelName.PD_YEAR.ToString();
        this.lblPD_YEAR.Attributes.Add("Code", modelName.PD_YEAR.ToString());
        this.lblPD_PROJECT_TYPE.Text = modelName.PD_PROJECT_TYPE_NAME;
        this.lblPD_YEAR.Attributes.Add("Code", modelName.PD_PROJECT_TYPE.ToString());
        this.lblPD_GK_DEPART.Text = "dfd";
        this.lblPD_YEAR.Attributes.Add("Code", modelName.PD_GK_DEPART_ID.ToString());
        this.lblPD_FOUND_XZ.Text = modelName.PD_FOUND_XZ_Name;
        this.lblPD_PROJECT_MONEY_ADDR.Text = modelName.PD_PROJECT_MONEY_ADDR;
        this.lblPD_PROJECT_CONTENT.Text = modelName.PD_PROJECT_CONTENT;
        this.lblPD_PROJECT_XMYT.Text = modelName.PD_PROJECT_XMYT;
        this.lblPD_PROJECT_IFXZGL.Text = (modelName.PD_PROJECT_IFXZGL.ToString() == "1") ? "是" : "否";
        this.lblPD_PROJECT_IFGS.Text = (modelName.PD_PROJECT_IFGS.ToString() == "1") ? "是" : "否";
        this.lblPD_PROJECT_IFGS_BEFORE.Text = (modelName.PD_PROJECT_IFGS_BEFORE.ToString() == "1") ? "是" : "否";
        this.lblPD_PROJECT_OPEN_BODY.Text = modelName.PD_PROJECT_OPEN_BODY;
        this.lblPD_PROJECT_FZR.Text = modelName.PD_PROJECT_FZR;
        this.lblPD_PROJECT_CWFZR.Text = modelName.PD_PROJECT_CWFZR;
        this.lblPD_PROJECT_SYRS.Text = modelName.PD_PROJECT_SYRS.ToString();
        this.lblPD_PROJECT_STATUS.Text = modelName.PD_PROJECT_STATUS_Name;
        this.lblPD_PROJECT_STATUS.Attributes.Add("Code", modelName.PD_PROJECT_STATUS);
        this.lblPD_PROJECT_BEGIN_DATE.Text = modelName.PD_PROJECT_BEGIN_DATE.Value.ToShortDateString();
        this.lblPD_PROJECT_END_DATE.Text = modelName.PD_PROJECT_END_DATE.Value.ToShortDateString();
        this.lblPD_PROJECT_YEARS.Text = modelName.PD_PROJECT_YEARS.ToString() + "月";
        this.lblPD_PROJECT_FILENO_JG.Text = modelName.PD_PROJECT_FILENO_JG;
        this.lblPD_PROJECT_INPUT_COMPANY.Text = modelName.PD_PROJECT_INPUT_COMPANY_Name;
        this.lblPD_PROJECT_INPUT_MAN.Text = modelName.PD_PROJECT_INPUT_MAN;
        this.lblPD_PROJECT_INPUT_DATE.Text = modelName.PD_PROJECT_INPUT_DATE;
        this.lblPD_PROJECT_REPLY_COMPANY.Text = modelName.PD_PROJECT_REPLY_COMPANY_Name;
        this.lblPD_PROJECT_REPLY_MAN2.Text = modelName.PD_PROJECT_REPLY_MAN2;
        this.lblPD_PROJECT_REPLY_DATE.Text = modelName.PD_PROJECT_REPLY_DATE;
        this.lblPD_PROJECT_COUNTRY.Text = modelName.PD_PROJECT_COUNTRY_Name;
        this.lblPD_PROJECT_COUNTRY.Attributes.Add("Code", modelName.PD_PROJECT_COUNTRY);
        this.lblPD_PROJECT_ZJLY.Text = modelName.PD_PROJECT_ZJLY;
        this.lblPD_PROJECT_ZGKJ.Text = modelName.PD_PROJECT_ZGKJ;
        this.lblPD_PROJECT_REPLY_COMPANY.Text = modelName.PD_PROJECT_REPLY_COMPANY_Name;
        this.lblPD_PROJECT_FILENO_PF.Text = modelName.PD_PROJECT_FILENO_PF.ToString();
    }

    private void ShowInfo1(string pd_PROJECT_CODE)
    {
        this.ShowJGYS(pd_PROJECT_CODE);
        this.ShowJGZL(pd_PROJECT_CODE);
        this.ShowXMPJ(pd_PROJECT_CODE);
    }

    private void ShowJGYS(string PD_PROJECT_CODE)
    {
        PD_PROJECT_JGYS_Model modelByProCode = new PD_PROJECT_JGYS_Bll().GetModelByProCode(PD_PROJECT_CODE);
        if (modelByProCode != null)
        {
            this.lblAUTO_NO_JGYS.Text = modelByProCode.AUTO_NO.ToString();
            this.txtPD_PROJECT_COMPLETE_DATE.Value = modelByProCode.PD_PROJECT_COMPLETE_DATE.ToString();
            this.txtPD_PROJECT_YSSQ_DATE.Value = modelByProCode.PD_PROJECT_YSSQ_DATE.Value.ToShortDateString();
            this.txtPD_PROJECT_YS_DATE.Value = modelByProCode.PD_PROJECT_YS_DATE.Value.ToShortDateString();
            this.ddlPD_PROJECT_YS_COMPANY.SelectedValue = modelByProCode.PD_PROJECT_YS_COMPANY;
            this.txtPD_PROJECT_YS_ZRR.Text = modelByProCode.PD_PROJECT_YS_ZRR;
            this.txtPD_PROJECT_YS_NAME.Text = modelByProCode.PD_PROJECT_YS_NAME;
            this.txtPD_PROJECT_YS_SUGGEST.Text = modelByProCode.PD_PROJECT_YS_SUGGEST;
            this.ddlPD_PROJECT_YS_RESULT.SelectedValue = modelByProCode.PD_PROJECT_YS_RESULT;
            this.txtPD_PROJECT_YS_CONDITION.Text = modelByProCode.PD_PROJECT_YS_CONDITION;
        }
    }

    private void ShowJGZL(string PD_PROJECT_CODE)
    {
        DataSet list = new PD_PROJECT_ATTACH_YS_Bll().GetList(" PD_PROJECT_CODE='" + PD_PROJECT_CODE + "'");
        this.jsonData_xmyszl = PublicDal.DataToJSON(list);
        if (list.Tables[0].Rows.Count > 0)
        {
            list.Tables[0].Rows.Clear();
        }
        DataRow row = list.Tables[0].NewRow();
        row[1] = PD_PROJECT_CODE;
        list.Tables[0].Rows.Add(row);
        this.json_xmyszl = PublicDal.DataToJSON(list);
    }

    private void ShowXMPJ(string PD_PROJECT_CODE)
    {
        PD_PROJECT_APPRAISE_Model modelByProjectCode = new PD_PROJECT_APPRAISE_Bll().GetModelByProjectCode(PD_PROJECT_CODE);
        if (modelByProjectCode != null)
        {
            this.txtAUTO_NO_APPRAISE.Text = modelByProjectCode.AUTO_NO.ToString();
            this.txtPD_PROJECT_APP_DATE.Value = modelByProjectCode.PD_PROJECT_APP_DATE.Value.ToShortDateString();
            this.txtPD_PROJECT_APP_COMPANY.Text = modelByProjectCode.PD_PROJECT_APP_COMPANY;
            this.txtPD_PROJECT_APP_COMPANY_LIST.Text = modelByProjectCode.PD_PROJECT_APP_COMPANY_LIST;
            this.txtPD_PROJECT_APP_MAN_LIST.Text = modelByProjectCode.PD_PROJECT_APP_MAN_LIST;
            this.txtPD_PROJECT_APPRAISE_FILENO.Text = modelByProjectCode.PD_PROJECT_APPRAISE_FILENO.ToString();
        }
    }

    private void UpdataData(string PD_OROHECT_CODE)
    {
        this.UpdateDateJGYS(PD_OROHECT_CODE);
    }

    private void UpdateDateJGYS(string PD_OROHECT_CODE)
    {
        string strErr = "";
        if (!this.Panduan_JGYS(ref strErr))
        {
            this.hy_File(null, strErr);
        }
        else
        {
            string text = this.lblPD_PROJECT_CODE.Text;
            DateTime time = DateTime.Parse(this.txtPD_PROJECT_COMPLETE_DATE.Value);
            DateTime time2 = DateTime.Parse(this.txtPD_PROJECT_YSSQ_DATE.Value);
            DateTime time3 = DateTime.Parse(this.txtPD_PROJECT_YS_DATE.Value);
            string selectedValue = this.ddlPD_PROJECT_YS_COMPANY.SelectedValue;
            string str4 = this.txtPD_PROJECT_YS_ZRR.Text;
            string str5 = this.txtPD_PROJECT_YS_NAME.Text;
            string str6 = this.txtPD_PROJECT_YS_SUGGEST.Text;
            string str7 = this.ddlPD_PROJECT_YS_RESULT.SelectedItem.Text;
            string str8 = this.txtPD_PROJECT_YS_CONDITION.Text;
            PD_PROJECT_JGYS_Model model = new PD_PROJECT_JGYS_Model
            {
                PD_PROJECT_CODE = text,
                PD_PROJECT_COMPLETE_DATE = new DateTime?(time),
                PD_PROJECT_YSSQ_DATE = new DateTime?(time2),
                PD_PROJECT_YS_DATE = new DateTime?(time3),
                PD_PROJECT_YS_COMPANY = selectedValue,
                PD_PROJECT_YS_ZRR = str4,
                PD_PROJECT_YS_NAME = str5,
                PD_PROJECT_YS_SUGGEST = str6,
                PD_PROJECT_YS_RESULT = str7,
                PD_PROJECT_YS_CONDITION = str8
            };
            PD_PROJECT_APPRAISE_Model model2 = new PD_PROJECT_APPRAISE_Model();
            string str9 = this.txtAUTO_NO_APPRAISE.Text;
            string str10 = this.txtPD_PROJECT_APP_COMPANY.Text;
            string str11 = this.txtPD_PROJECT_APP_COMPANY_LIST.Text;
            string str12 = this.txtPD_PROJECT_APP_MAN_LIST.Text;
            string str13 = this.txtPD_PROJECT_APPRAISE_FILENO.Text;
            if (!PublicDal.PageValidate.IsNumber(str9))
            {
                str9 = "-1";
            }
            model2.AUTO_NO = int.Parse(str9);
            model2.PD_PROJECT_CODE = text;
            model2.PD_PROJECT_APP_COMPANY = str10;
            model2.PD_PROJECT_APP_COMPANY_LIST = str11;
            model2.PD_PROJECT_APP_MAN_LIST = str12;
            model2.PD_PROJECT_APPRAISE_FILENO = str13;
            PD_PROJECT_JGYS_Bll bll = new PD_PROJECT_JGYS_Bll();
            if (bll.Exists(text))
            {
                bll.Update(model);
            }
            else
            {
                bll.Add(model);
            }
            PD_PROJECT_APPRAISE_Bll bll2 = new PD_PROJECT_APPRAISE_Bll();
            if (bll2.Exists(text))
            {
                bll2.Update(model2);
            }
            else
            {
                bll2.Add(model2);
            }
            this.UpdateDateXMPJ(PD_OROHECT_CODE);
            PageShowText.Refurbish("修改成功", this.Page);
        }
    }

    private void UpdateDateXMPJ(string PD_PROJECT_CODE)
    {
        List<PD_PROJECT_ATTACH_YS_Model> modelList = this.GetAttach_SSModel(PD_PROJECT_CODE);
        PD_PROJECT_ATTACH_YS_Bll bll = new PD_PROJECT_ATTACH_YS_Bll();
        bll.Delete(PD_PROJECT_CODE);
        bll.AddList(modelList);
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
