using ASP;
using ExtExtenders;
using SoMeTech.CommonDll;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using SMZJ.BLL;
using SMZJ.Model;

public class Work_GL_PfMx : Page, IRequiresSessionState
{
    protected UserControls_FilePostCtr FilePostCtr1;
    public string jsonStr_pf = "";
    public string jsonStr_sb = "";
    public string jsonStrNull = "";
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
    protected Label lblPD_PROJECT_MONEY_CZ_BJ;
    protected Label lblPD_PROJECT_MONEY_CZ_SJ;
    protected Label lblPD_PROJECT_MONEY_CZ_TOTAL;
    protected Label lblPD_PROJECT_MONEY_QT;
    protected Label lblPD_PROJECT_MONEY_TOTAL;
    protected Label lblPD_PROJECT_MONEY_ZC;
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
    protected TabPanel Panel_xmgk;
    protected TabPanel Panel_xmsbzl;
    protected TabPanel Panel_xmtzsq;
    protected TabContainer TabContainer1;
    protected TabPanel TabPanel1;
    protected TabPanel TabPanel2;
    protected TextBox txtPD_GK_DEPART;
    protected HtmlInputHidden txtPD_PROJECT_FILENO_PF;
    protected TextBox txtPD_PROJECT_MONEY_CZ_BJ_PF;
    protected TextBox txtPD_PROJECT_MONEY_CZ_SJ_PF;
    protected TextBox txtPD_PROJECT_MONEY_CZ_TOTAL_PF;
    protected TextBox txtPD_PROJECT_MONEY_QT_PF;
    protected TextBox txtPD_PROJECT_MONEY_TOTAL_PF;
    protected TextBox txtPD_PROJECT_MONEY_ZC_PF;

    private void BindDDList()
    {
    }

    public void Buttons(string ibtid)
    {
        switch (ibtid)
        {
            case "ibtcontrol_ibtsave":
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

            case "ibtcontrol_ibthuizong":
                PageShowText.OpenPage("/Report/jsxGTable.aspx", this.Page, 0x400, 600, null, null);
                this.hy_File(null, null);
                return;
        }
    }

    private List<PD_PROJECT_ATTACH_PF_Model> GetAttach_SBModel(string PD_PROJECT_CODE)
    {
        List<PD_PROJECT_ATTACH_PF_Model> list = new List<PD_PROJECT_ATTACH_PF_Model>();
        if (base.Request.Form["table_xmpfzl_PD_PROJECT_CODE"] != null)
        {
            string[] strArray = base.Request.Form["table_xmpfzl_PD_PROJECT_CODE"].Split(new char[] { ',' });
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
                PD_PROJECT_ATTACH_PF_Model item = new PD_PROJECT_ATTACH_PF_Model
                {
                    PD_PROJECT_CODE = strArray[i]
                };
                if (defaultView != null)
                {
                    defaultView.RowFilter = " tableID='table_xmpfzl' and rowIndex=" + (i + 1);
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

    private TB_PROJECT_Model GetModel(TB_PROJECT_Model model)
    {
        if (model == null)
        {
            model = new TB_PROJECT_Model();
        }
        string str = this.txtPD_PROJECT_FILENO_PF.Value;
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_PROJECT_MONEY_TOTAL_PF.Text))
        {
            model.PD_PROJECT_MONEY_TOTAL_PF = new decimal?(decimal.Parse(this.txtPD_PROJECT_MONEY_TOTAL_PF.Text));
        }
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_PROJECT_MONEY_CZ_TOTAL_PF.Text))
        {
            model.PD_PROJECT_MONEY_CZ_TOTAL_PF = new decimal?(decimal.Parse(this.txtPD_PROJECT_MONEY_CZ_TOTAL_PF.Text));
        }
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_PROJECT_MONEY_CZ_SJ_PF.Text))
        {
            model.PD_PROJECT_MONEY_CZ_SJ_PF = new decimal?(decimal.Parse(this.txtPD_PROJECT_MONEY_CZ_SJ_PF.Text));
        }
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_PROJECT_MONEY_CZ_BJ_PF.Text))
        {
            model.PD_PROJECT_MONEY_CZ_BJ_PF = new decimal?(decimal.Parse(this.txtPD_PROJECT_MONEY_CZ_BJ_PF.Text));
        }
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_PROJECT_MONEY_ZC_PF.Text))
        {
            model.PD_PROJECT_MONEY_ZC_PF = new decimal?(decimal.Parse(this.txtPD_PROJECT_MONEY_ZC_PF.Text));
        }
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_PROJECT_MONEY_QT_PF.Text))
        {
            model.PD_PROJECT_MONEY_QT_PF = new decimal?(decimal.Parse(this.txtPD_PROJECT_MONEY_QT_PF.Text));
        }
        model.PD_PROJECT_REPLY_DATE = DateTime.Now.ToString("yyyy-MM-dd");
        model.PD_PROJECT_REPLY_COMPANY = ((UserModel)this.Session["User"]).Company.pk_corp;
        model.PD_PROJECT_REPLY_MAN2 = ((UserModel)this.Session["User"]).UserName;
        model.PD_PROJECT_FILENO_PF = str;
        model.PD_GK_DEPART = this.txtPD_GK_DEPART.Text;
        return model;
    }

    private void hy_File(List<PD_PROJECT_ATTACH_PF_Model> SS_Model, string ShowText)
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
        foreach (PD_PROJECT_ATTACH_PF_Model model in SS_Model)
        {
            DataRow row = ds.Tables[0].NewRow();
            row["AUTO_NO"] = num++;
            row["PD_PROJECT_CODE"] = model.PD_PROJECT_CODE;
            row["PD_PROJECT_ATTACH_NAME"] = model.PD_PROJECT_ATTACH_NAME;
            row["PD_PROJECT_ATTACH_NAME_SYSTEM"] = model.PD_PROJECT_ATTACH_NAME_SYSTEM;
            ds.Tables[0].Rows.Add(row);
        }
        string str = "try{PostLoadxmsszl('table_xmpfzl',eval(decodeURIComponent(\"" + base.Server.UrlEncode(PublicDal.DataToJSON(ds)) + "\")),'xmss_5');}catch(e){alert(e)};";
        DataSet list = new PD_PROJECT_ATTACH_SB_Bll().GetList(" PD_PROJECT_CODE='" + base.Request["UpdatePK"] + "'");
        str = str + "try{PostLoadxmsszl('table_xmsbzl',eval(decodeURIComponent(\"" + base.Server.UrlEncode(PublicDal.DataToJSON(list)) + "\")),'xmpf_4');}catch(e){alert(e)};";
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
        if (base.Request["strTitle"] != null)
        {
            this.Master.strTitle = base.Request["strTitle"];
        }
        this.Master.strTitle = base.Request["strTitle"];
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        this.Master.SearchHasGone = new SearchHandler(this.SearchControl);
        ButtonsModel model = null;
        this.ListPageLoad(this.Page, out model, base.Request["UpdatePK"].Trim());
        this.Master.btModel = model;
        if ((!base.IsPostBack && (base.Request["UpdatePK"] != null)) && (base.Request["UpdatePK"].Trim() != ""))
        {
            this.ShowInfo(base.Request["UpdatePK"].Trim());
            this.lblPD_PROJECT_REPLY_DATE.Text = DateTime.Now.ToString("yyyy-MM-dd");
            if (((UserModel)this.Session["user"]).Company != null)
            {
                this.lblPD_PROJECT_REPLY_COMPANY.Text = ((UserModel)this.Session["user"]).Company.Name;
            }
            if (((UserModel)this.Session["user"]).UserName != null)
            {
                this.lblPD_PROJECT_REPLY_MAN2.Text = ((UserModel)this.Session["user"]).UserName;
            }
        }
        this.ShowCS();
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
    }

    private bool Panduan(ref string strErr)
    {
        if (this.txtPD_PROJECT_FILENO_PF.Value.Trim().Length == 0)
        {
            strErr = strErr + @"上级指标文号不能为空！\n";
        }
        if ((this.txtPD_PROJECT_MONEY_TOTAL_PF.Text.Trim().Length == 0) || ((this.txtPD_PROJECT_MONEY_TOTAL_PF.Text.Trim().Length > 0) && (decimal.Parse(this.txtPD_PROJECT_MONEY_TOTAL_PF.Text) < 0M)))
        {
            strErr = strErr + @"批复投资总额不能为空,且需要大于等于0 \n";
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
        this.txtPD_PROJECT_MONEY_TOTAL_PF.Attributes.Add("onKeyPress", "myKeyDown(this,event,0)");
        this.txtPD_PROJECT_MONEY_CZ_TOTAL_PF.Attributes.Add("onKeyPress", "myKeyDown(this,event,0)");
        this.txtPD_PROJECT_MONEY_CZ_SJ_PF.Attributes.Add("onKeyPress", "myKeyDown(this,event,0)");
        this.txtPD_PROJECT_MONEY_CZ_BJ_PF.Attributes.Add("onKeyPress", "myKeyDown(this,event,0)");
        this.txtPD_PROJECT_MONEY_ZC_PF.Attributes.Add("onKeyPress", "myKeyDown(this,event,0)");
        this.txtPD_PROJECT_MONEY_QT_PF.Attributes.Add("onKeyPress", "myKeyDown(this,event,0)");
        this.txtPD_PROJECT_MONEY_CZ_SJ_PF.Attributes.Add("onBlur", "Sum_sqzjze()");
        this.txtPD_PROJECT_MONEY_CZ_BJ_PF.Attributes.Add("onBlur", "Sum_sqzjze()");
        this.txtPD_PROJECT_MONEY_ZC_PF.Attributes.Add("onBlur", "Sum_sqzjze()");
        this.txtPD_PROJECT_MONEY_QT_PF.Attributes.Add("onBlur", "Sum_sqzjze()");
    }

    private void ShowDDList(Label lbl, string tableName, string code, string name)
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
        this.lblPD_GK_DEPART.Text = modelName.PD_GK_DEPART;
        this.txtPD_GK_DEPART.Text = modelName.PD_GK_DEPART_ID;
        this.lblPD_YEAR.Attributes.Add("Code", modelName.PD_GK_DEPART_ID.ToString());
        this.lblPD_FOUND_XZ.Text = modelName.PD_FOUND_XZ_Name;
        this.lblPD_PROJECT_MONEY_TOTAL.Text = modelName.PD_PROJECT_MONEY_TOTAL.ToString();
        this.lblPD_PROJECT_MONEY_CZ_TOTAL.Text = modelName.PD_PROJECT_MONEY_CZ_TOTAL.ToString();
        this.lblPD_PROJECT_MONEY_CZ_SJ.Text = modelName.PD_PROJECT_MONEY_CZ_SJ.ToString();
        this.lblPD_PROJECT_MONEY_CZ_BJ.Text = modelName.PD_PROJECT_MONEY_CZ_BJ.ToString();
        this.lblPD_PROJECT_MONEY_ZC.Text = modelName.PD_PROJECT_MONEY_ZC.ToString();
        this.lblPD_PROJECT_MONEY_QT.Text = modelName.PD_PROJECT_MONEY_QT.ToString();
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
        this.txtPD_PROJECT_MONEY_TOTAL_PF.Text = modelName.PD_PROJECT_MONEY_TOTAL_PF.ToString();
        this.txtPD_PROJECT_MONEY_CZ_TOTAL_PF.Text = modelName.PD_PROJECT_MONEY_CZ_TOTAL_PF.ToString();
        this.txtPD_PROJECT_MONEY_CZ_SJ_PF.Text = modelName.PD_PROJECT_MONEY_CZ_SJ_PF.ToString();
        this.txtPD_PROJECT_MONEY_CZ_BJ_PF.Text = modelName.PD_PROJECT_MONEY_CZ_BJ_PF.ToString();
        this.txtPD_PROJECT_MONEY_ZC_PF.Text = modelName.PD_PROJECT_MONEY_ZC_PF.ToString();
        this.txtPD_PROJECT_MONEY_QT_PF.Text = modelName.PD_PROJECT_MONEY_QT_PF.ToString();
        this.lblPD_PROJECT_FILENO_PF.Text = modelName.PD_PROJECT_FILENO_PF;
        this.txtPD_PROJECT_FILENO_PF.Value = modelName.PD_PROJECT_FILENO_PF_CODE;
        this.lblPD_PROJECT_ZJLY.Text = modelName.PD_PROJECT_ZJLY;
        this.lblPD_PROJECT_ZGKJ.Text = modelName.PD_PROJECT_ZGKJ;
        DataSet list = new PD_PROJECT_ATTACH_SB_Bll().GetList(" PD_PROJECT_CODE='" + PD_PROJECT_CODE + "'");
        this.jsonStr_sb = PublicDal.DataToJSON(list);
        DataSet ds = new PD_PROJECT_ATTACH_PF_Bll().GetList(" PD_PROJECT_CODE='" + PD_PROJECT_CODE + "'");
        this.jsonStr_pf = PublicDal.DataToJSON(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ds.Tables[0].Rows.Clear();
        }
        DataRow row = ds.Tables[0].NewRow();
        row[1] = PD_PROJECT_CODE;
        ds.Tables[0].Rows.Add(row);
        this.jsonStrNull = PublicDal.DataToJSON(ds);
    }

    private void UpdataData(string PD_PROJECT_CODE)
    {
        string strErr = "";
        if (!this.Panduan(ref strErr))
        {
            this.hy_File(null, strErr);
        }
        else
        {
            TB_PROJECT_Bll bll = new TB_PROJECT_Bll();
            TB_PROJECT_Model model = this.GetModel(bll.GetModel(PD_PROJECT_CODE));
            model.PD_PROJECT_CODE = PD_PROJECT_CODE;
            bll.Update(model);
            PD_PROJECT_ATTACH_PF_Bll bll2 = new PD_PROJECT_ATTACH_PF_Bll();
            bll2.Delete(PD_PROJECT_CODE);
            bll2.AddList(this.GetAttach_SBModel(PD_PROJECT_CODE));
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
