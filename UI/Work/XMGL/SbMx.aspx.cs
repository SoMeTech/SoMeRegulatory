using ASP;
using ExtExtenders;
using SoMeTech.CommonDll;
using SoMeTech.Data;
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
using YYControls;
using SMZJ.BLL;
using SMZJ.Model;
using SMZJ.Model;

public class Work_GL_SbMx : Page, IRequiresSessionState
{
    protected DropDownList ddlPD_FOUND_XZ;
    protected TextBox ddlPD_PROJECT_COUNTRY;
    protected HtmlSelect ddlPD_PROJECT_GROUP;
    protected DropDownList ddlPD_PROJECT_IFGS;
    protected DropDownList ddlPD_PROJECT_IFGS_BEFORE;
    protected DropDownList ddlPD_PROJECT_IFXZGL;
    protected DropDownList ddlPD_PROJECT_ISCONTRACT;
    protected DropDownList ddlPD_PROJECT_STATUS;
    protected DropDownList ddlPD_PROJECT_TYPE;
    protected HtmlSelect ddlPD_PROJECT_VILLAGE;
    protected DropDownList ddlPD_PROJECT_YS_COMPANY;
    protected DropDownList ddlPD_PROJECT_YS_RESULT;
    protected DropDownList ddlPD_PROJECT_ZTB_IF_SSFA;
    protected DropDownList ddlPD_PROJECT_ZTB_IF_ZTB;
    protected DropDownList ddlPD_PROJECT_ZTB_STYLE;
    protected DropDownList ddlPD_YEAR;
    protected HtmlGenericControl div_showBXK;
    protected UserControls_FilePostCtr FilePostCtr1;
    protected TextBox FREE8;
    protected SmartGridView gvResult_gkgs;
    protected SmartGridView gvResult_HeTong;
    protected SmartGridView gvResult_xmxc;
    protected SmartGridView gvResult_zjbf;
    protected HtmlInputHidden HdFree1;
    protected HtmlGenericControl img_p1;
    protected HtmlGenericControl img_p2;
    protected HtmlGenericControl img_p3;
    protected HtmlImage imgSearch;
    public string jsonStr = "";
    public string jsonStrNull = "";
    protected TextBox lblAUTO_NO;
    protected Label lblAUTO_NO_JGYS;
    protected HtmlInputText lblPD_PROJECT_FILENO_PF;
    protected TabPanel Panel_jgys;
    protected TabPanel Panel_xmgk;
    protected TabPanel Panel_xmpj;
    protected TabPanel Panel_xmsbzl;
    protected TabPanel Panel_ztbgl;
    protected TextBox pd_project_cm;
    protected TextBox pd_project_jsje;
    protected TextBox ShowPD_PROJECT_INPUT_COMPANY;
    protected TextBox ShowPD_PROJECT_INPUT_MAN;
    public static string str_MXID = "";
    protected TabContainer TabContainer1;
    protected TabPanel TabPanel_gkgs;
    protected TabPanel TabPanel_HeTong;
    protected TabPanel TabPanel_xmxc;
    protected TabPanel TabPanel_zjbf;
    protected TabPanel TabPanel1;
    protected TextBox txt_file;
    protected TextBox txt_InputFile1;
    protected TextBox txt_InputFile2;
    protected TextBox txt_InputFile3;
    protected TextBox txtAUTO_NO_APPRAISE;
    protected TextBox txtdepart;
    protected TextBox txtPD_PROJECT_APP_COMPANY;
    protected TextBox txtPD_PROJECT_APP_COMPANY_LIST;
    protected HtmlInputText txtPD_PROJECT_APP_DATE;
    protected TextBox txtPD_PROJECT_APP_MAN_LIST;
    protected TextBox txtPD_PROJECT_APPRAISE_FILENO;
    protected TextBox txtPD_PROJECT_BEGIN_DATE;
    protected TextBox txtPD_PROJECT_CODE;
    protected HtmlInputText txtPD_PROJECT_COMPLETE_DATE;
    protected TextBox txtPD_PROJECT_CONTENT;
    protected TextBox txtPD_PROJECT_CWFZR;
    protected TextBox txtPD_PROJECT_END_DATE;
    protected TextBox txtPD_PROJECT_FCXMGCL;
    protected TextBox txtPD_PROJECT_FILENO_LX;
    protected HtmlInputHidden txtPD_PROJECT_FILENO_PF;
    protected TextBox txtPD_PROJECT_FZR;
    protected TextBox txtPD_PROJECT_GCZLQK;
    protected TextBox txtPD_PROJECT_INPUT_COMPANY;
    protected TextBox txtPD_PROJECT_INPUT_DATE;
    protected TextBox txtPD_PROJECT_INPUT_MAN;
    protected HtmlInputHidden txtPD_PROJECT_MONEY_CZ_BJ;
    protected HtmlInputHidden txtPD_PROJECT_MONEY_CZ_SJ;
    protected TextBox txtPD_PROJECT_MONEY_CZ_TOTAL;
    protected HtmlInputHidden txtPD_PROJECT_MONEY_QT;
    protected TextBox txtPD_PROJECT_MONEY_TOTAL;
    protected HtmlInputHidden txtPD_PROJECT_MONEY_ZC;
    protected TextBox txtPD_PROJECT_NAME;
    protected TextBox txtPD_PROJECT_OPEN_BODY;
    protected TextBox txtPD_PROJECT_SSFW;
    protected TextBox txtPD_PROJECT_SYRS;
    protected TextBox txtPD_PROJECT_XMYT;
    protected TextBox txtPD_PROJECT_XXJD;
    protected TextBox txtPD_PROJECT_YEARS;
    protected TextBox txtPD_PROJECT_YS_CONDITION;
    protected HtmlInputText txtPD_PROJECT_YS_DATE;
    protected TextBox txtPD_PROJECT_YS_NAME;
    protected TextBox txtPD_PROJECT_YS_SUGGEST;
    protected TextBox txtPD_PROJECT_YS_ZRR;
    protected HtmlInputText txtPD_PROJECT_YSSQ_DATE;

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

    private void AddImgMethod(TB_PROJECT_Model model)
    {
        try
        {
            string str = this.txt_InputFile1.Text.ToString();
            string str2 = this.txt_InputFile2.Text.ToString();
            string str3 = this.txt_InputFile3.Text.ToString();
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            string str8 = "";
            string str9 = "";
            if (!string.IsNullOrEmpty(str))
            {
                str6 = str.Substring(str.LastIndexOf("||")).Replace("||", "");
                str7 = str6;
                str6 = str6.Substring(0, str6.LastIndexOf("."));
                str = "UserImages/" + str7;
                DataSet set = DbHelperOra.Query(" select * from t_photos where fkid =  'ssSB1_" + model.PD_PROJECT_CODE + "' ");
                if ((set != null) && (set.Tables[0].Rows.Count > 0))
                {
                    DbHelperOra.ExecuteSql(" delete t_photos   where fkid =  'ssSB1_" + model.PD_PROJECT_CODE + "'");
                }
                DbHelperOra.ExecuteSql("insert into t_photos (fkid, photoname, photopath, remarks, sortid) values  ( 'ssSB1_" + model.PD_PROJECT_CODE + "', '" + str7 + "', '" + str + "', '" + str7 + "', 1)");
            }
            if (!string.IsNullOrEmpty(str2))
            {
                str8 = str2.Substring(str2.LastIndexOf("||")).Replace("||", "");
                str9 = str8;
                str8 = str8.Substring(0, str8.LastIndexOf("."));
                str2 = "UserImages/" + str9;
                DataSet set2 = DbHelperOra.Query(" select * from t_photos where fkid =  'ssSB2_" + model.PD_PROJECT_CODE + "' ");
                if ((set2 != null) && (set2.Tables[0].Rows.Count > 0))
                {
                    DbHelperOra.ExecuteSql(" delete t_photos   where fkid =  'ssSB2_" + model.PD_PROJECT_CODE + "'");
                }
                DbHelperOra.ExecuteSql("insert into t_photos (fkid, photoname, photopath, remarks, sortid) values  ( 'ssSB2_" + model.PD_PROJECT_CODE + "', '" + str9 + "', '" + str2 + "', '" + str9 + "', 1)");
            }
            if (!string.IsNullOrEmpty(str3))
            {
                str4 = str3.Substring(str3.LastIndexOf("||")).Replace("||", "");
                str5 = str4;
                str4 = str4.Substring(0, str4.LastIndexOf("."));
                str3 = "UserImages/" + str5;
                DataSet set3 = DbHelperOra.Query(" select * from t_photos where fkid =  'ssSB3_" + model.PD_PROJECT_CODE + "' ");
                if ((set3 != null) && (set3.Tables[0].Rows.Count > 0))
                {
                    DbHelperOra.ExecuteSql(" delete t_photos   where fkid =  'ssSB3_" + model.PD_PROJECT_CODE + "'");
                }
                DbHelperOra.ExecuteSql("insert into t_photos (fkid, photoname, photopath, remarks, sortid) values  ( 'ssSB3_" + model.PD_PROJECT_CODE + "', '" + str5 + "', '" + str3 + "', '" + str5 + "', 1)");
            }
        }
        catch
        {
        }
    }

    private void BindDDList()
    {
        PublicDal.BindDropDownList(this.ddlPD_YEAR, "PD_BASE_YEAR", "YEAR_NAME", "YEAR_CODE", "");
        string text = DateTime.Now.Year.ToString();
        this.ddlPD_YEAR.SelectedIndex = this.ddlPD_YEAR.Items.IndexOf(new ListItem(text, text));
        PublicDal.BindDropDownList(this.ddlPD_FOUND_XZ, "PD_BASE_FOUND_PROPERTY", "FOUND_PROPERTY_NAME", "FOUND_PROPERTY_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_TYPE, "PD_BASE_ProjectType", "ProjectType_Name", "PROJECTTYPE_CODE", "projecttype_year=" + this.ddlPD_YEAR.SelectedValue + " and zjxz_type='" + this.ddlPD_FOUND_XZ.SelectedValue + "'");
        this.ddlPD_PROJECT_TYPE.Items.Insert(0, new ListItem("", ""));
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_IFGS, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_IFXZGL, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_IFGS_BEFORE, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_STATUS, "PD_BASE_STATUS", "STATUS_NAME", "STATUS_CODE", "");
        this.ddlPD_PROJECT_YS_COMPANY.Items.Add(new ListItem(((UserModel)this.Session["User"]).Company.Name, ((UserModel)this.Session["User"]).Company.pk_corp));
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_ZTB_IF_SSFA, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_ZTB_IF_ZTB, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_ISCONTRACT, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_ZTB_STYLE, "PD_BASE_TenderType", "TenderType_Name", "TenderType_Code", "");
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
            str2 = str_MXID;
            DataSet set = DbHelperOra.Query("select * from t_photos where fkid='ssSB1_" + str2 + "'");
            DataSet set2 = DbHelperOra.Query("select * from t_photos where   fkid='ssSB2_" + str2 + "' ");
            DataSet set3 = DbHelperOra.Query("select * from t_photos where  fkid='ssSB3_" + str2 + "'");
            if (((set != null) || (set.Tables[0].Rows.Count > 0)) && (set.Tables[0].Rows.Count > 0))
            {
                string str6 = set.Tables[0].Rows[0]["photopath"].ToString();
                str = "<img id='upimg1' src='../../../" + str6 + "' ' style='width: 230px; height: 230px;' />";
                this.img_p1.InnerHtml = str;
            }
            if (((set2 != null) || (set2.Tables[0].Rows.Count > 0)) && (set2.Tables[0].Rows.Count > 0))
            {
                string str7 = set2.Tables[0].Rows[0]["photopath"].ToString();
                str = "<img id='upimg1' src='../../../" + str7 + "' ' style='width: 230px; height: 230px;' />";
                this.img_p2.InnerHtml = str;
            }
            if (((set3 != null) || (set3.Tables[0].Rows.Count > 0)) && (set3.Tables[0].Rows.Count > 0))
            {
                string str8 = set3.Tables[0].Rows[0]["photopath"].ToString();
                str = "<img id='upimg1' src='../../../" + str8 + "' ' style='width: 230px; height: 230px;' />";
                this.img_p3.InnerHtml = str;
            }
        }
        catch
        {
        }
    }

    private void BindXiangCunZU()
    {
    }

    public void Buttons(string ibtid)
    {
        switch (ibtid)
        {
            case "ibtcontrol_ibtprintnote":
                PageShowText.OpenPage(Public.RelativelyPath("Work/XMGL/proBuildAndAllowance.aspx") + "?UpdatePK=" + base.Request["UpdatePK"].Trim() + "&titlename=1", null, null, this.Page, true);
                PageShowText.Refurbish("", this.Page);
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
        PD_PROJECT_JGYS_Model model2 = this.getModer_jgys(null, model.PD_PROJECT_CODE);
        new PD_PROJECT_JGYS_Bll().Add(model2);
        PD_PROJECT_APPRAISE_Model model3 = this.getModer_jgys_pj(null, model.PD_PROJECT_CODE);
        new PD_PROJECT_APPRAISE_Bll().Add(model3);
        PD_PROJECT_ZTB_Model model4 = this.GetModel_Ztb(null, model.PD_PROJECT_CODE);
        new PD_PROJECT_ZTB_Bll().Add(model4);
        this.AddImgMethod(model);
        bll.UpdateServerPK("TB_PROJECT", "PD_PROJECT_CODE", model.PD_PROJECT_CODE, PublicDal.SetCreateServiceStream(this.Page), "PD_PROJECT_SERVERPK");
        PD_PROJECT_ATTACH_SB_Bll bll5 = new PD_PROJECT_ATTACH_SB_Bll();
        List<PD_PROJECT_ATTACH_SB_Model> modelList = this.GetAttach_SBModel(model.PD_PROJECT_CODE);
        bll5.AddList(modelList);
        PD_PROJECT_TZJGC_Bll bll6 = new PD_PROJECT_TZJGC_Bll();
        List<PD_PROJECT_TZJGC_Model> listModel = this.getTZJGCModel(model.PD_PROJECT_CODE);
        bll6.Add(listModel);
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
        if (base.Request.Form["table_xmsbzl_file_type"] != null)
        {
            string[] strArray = base.Request.Form["table_xmsbzl_file_type"].Split(new char[] { ',' });
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
                PD_PROJECT_ATTACH_SB_Model item = new PD_PROJECT_ATTACH_SB_Model
                {
                    PD_PROJECT_CODE = PD_PROJECT_CODE,
                    PD_PROJECT_ATTACH_TYPE = strArray[i]
                };
                if (defaultView != null)
                {
                    defaultView.RowFilter = " tableID='table_xmsbzl' and rowIndex=" + (i + 1);
                    if ((defaultView.Count > 0) && (defaultView[0]["FileSysName"].ToString().Trim().Length > 0))
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

    private TB_PROJECT_Model GetModel(TB_PROJECT_Model model)
    {
        if (model == null)
        {
            model = new TB_PROJECT_Model();
        }
        model.PD_PROJECT_CODE = this.txtPD_PROJECT_CODE.Text;
        model.PD_PROJECT_NAME = this.txtPD_PROJECT_NAME.Text;
        if (!string.IsNullOrEmpty(this.txtPD_PROJECT_FILENO_PF.Value.ToString()))
        {
            model.PD_PROJECT_FILENO_ZB = this.txtPD_PROJECT_FILENO_PF.Value.ToString();
            model.PD_PROJECT_FILENO_PF = this.txtPD_PROJECT_FILENO_PF.Value;
        }
        else
        {
            model.PD_PROJECT_FILENO_ZB = this.lblPD_PROJECT_FILENO_PF.Value.ToString();
            model.PD_PROJECT_FILENO_PF = this.lblPD_PROJECT_FILENO_PF.Value;
        }
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
        if (this.ddlPD_PROJECT_IFGS.SelectedValue != "")
        {
            model.PD_PROJECT_IFGS = new int?(int.Parse(this.ddlPD_PROJECT_IFGS.SelectedValue));
        }
        if (this.ddlPD_PROJECT_IFGS_BEFORE.SelectedValue != "")
        {
            model.PD_PROJECT_IFGS_BEFORE = new int?(int.Parse(this.ddlPD_PROJECT_IFGS_BEFORE.SelectedValue));
        }
        model.PD_PROJECT_OPEN_BODY = this.txtPD_PROJECT_OPEN_BODY.Text;
        model.PD_PROJECT_FZR = this.txtPD_PROJECT_FZR.Text;
        model.PD_PROJECT_CWFZR = this.txtPD_PROJECT_CWFZR.Text;
        if (PublicDal.PageValidate.IsNumber(this.txtPD_PROJECT_SYRS.Text))
        {
            model.PD_PROJECT_SYRS = new int?(int.Parse(this.txtPD_PROJECT_SYRS.Text));
        }
        else
        {
            model.PD_PROJECT_SYRS = 0;
        }
        model.PD_PROJECT_STATUS = this.ddlPD_PROJECT_STATUS.SelectedValue;
        if (this.txtPD_PROJECT_BEGIN_DATE.Text != "")
        {
            model.PD_PROJECT_BEGIN_DATE = new DateTime?(DateTime.Parse(this.txtPD_PROJECT_BEGIN_DATE.Text));
        }
        if (this.txtPD_PROJECT_END_DATE.Text != "")
        {
            model.PD_PROJECT_END_DATE = new DateTime?(DateTime.Parse(this.txtPD_PROJECT_END_DATE.Text));
        }
        if ((this.txtPD_PROJECT_END_DATE.Text != "") && (this.txtPD_PROJECT_BEGIN_DATE.Text != ""))
        {
            model.PD_PROJECT_YEARS = new int?(PublicDal.CalDateTime(DateTime.Parse(this.txtPD_PROJECT_END_DATE.Text), DateTime.Parse(this.txtPD_PROJECT_BEGIN_DATE.Text), false));
        }
        this.txtPD_PROJECT_YEARS.Text = model.PD_PROJECT_YEARS.ToString();
        model.PD_PROJECT_FILENO_LX = this.txtPD_PROJECT_FILENO_LX.Text;
        model.PD_PROJECT_INPUT_DATE = DateTime.Now.ToString("yyyy-MM-dd");
        model.PD_PROJECT_INPUT_COMPANY = ((UserModel)this.Session["User"]).Company.pk_corp;
        model.PD_PROJECT_INPUT_MAN = ((UserModel)this.Session["User"]).UserName;
        if (this.txtPD_PROJECT_MONEY_CZ_SJ.Value != "")
        {
            model.PD_PROJECT_MONEY_CZ_SJ = new decimal?(Math.Round(Convert.ToDecimal(this.txtPD_PROJECT_MONEY_CZ_SJ.Value), 2));
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
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_PROJECT_MONEY_TOTAL.Text))
        {
            model.PD_PROJECT_MONEY_TOTAL = new decimal?(Math.Round(decimal.Parse(this.txtPD_PROJECT_MONEY_TOTAL.Text), 2));
        }
        else
        {
            model.PD_PROJECT_MONEY_TOTAL = 0;
        }
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_PROJECT_MONEY_CZ_TOTAL.Text))
        {
            model.PD_PROJECT_MONEY_CZ_TOTAL = new decimal?(Math.Round(decimal.Parse(this.txtPD_PROJECT_MONEY_CZ_TOTAL.Text), 2));
        }
        else
        {
            model.PD_PROJECT_MONEY_CZ_TOTAL = 0;
        }
        model.Free1 = this.HdFree1.Value;
        model.Free2 = this.pd_project_cm.Text;
        if (PublicDal.PageValidate.IsDecimal(this.FREE8.Text))
        {
            model.Free8 = decimal.Parse(this.FREE8.Text);
        }
        else
        {
            model.Free8 = 0M;
        }
        model.PD_PROJECT_SSFW = this.txtPD_PROJECT_SSFW.Text;
        return model;
    }

    private PD_PROJECT_ZTB_Model GetModel_Ztb(PD_PROJECT_ZTB_Model model, string PD_PROJECT_CODE)
    {
        if (model == null)
        {
            model = new PD_PROJECT_ZTB_Model();
        }
        if (PublicDal.PageValidate.IsInt(this.ddlPD_PROJECT_ZTB_IF_SSFA.SelectedValue))
        {
            model.PD_PROJECT_ZTB_IF_SSFA = new int?(int.Parse(this.ddlPD_PROJECT_ZTB_IF_SSFA.SelectedValue));
        }
        if (PublicDal.PageValidate.IsInt(this.ddlPD_PROJECT_ZTB_IF_ZTB.SelectedValue))
        {
            model.PD_PROJECT_ZTB_IF_ZTB = new int?(int.Parse(this.ddlPD_PROJECT_ZTB_IF_ZTB.SelectedValue));
        }
        model.PD_PROJECT_ZTB_STYLE = this.ddlPD_PROJECT_ZTB_STYLE.SelectedValue;
        model.PD_PROJECT_CODE = PD_PROJECT_CODE;
        model.PD_PROJECT_ISCONTRACT = this.ddlPD_PROJECT_ISCONTRACT.SelectedValue;
        model.PD_PROJECT_XXJD = this.txtPD_PROJECT_XXJD.Text;
        model.PD_PROJECT_FCXMGCL = this.txtPD_PROJECT_FCXMGCL.Text;
        model.PD_PROJECT_GCZLQK = this.txtPD_PROJECT_GCZLQK.Text;
        return model;
    }

    private PD_PROJECT_JGYS_Model getModer_jgys(PD_PROJECT_JGYS_Model model, string PD_PROJECT_CODE)
    {
        if (model == null)
        {
            model = new PD_PROJECT_JGYS_Model();
        }
        model.PD_PROJECT_CODE = PD_PROJECT_CODE;
        if (PublicDal.PageValidate.IsDateTime(this.txtPD_PROJECT_COMPLETE_DATE.Value))
        {
            model.PD_PROJECT_COMPLETE_DATE = new DateTime?(DateTime.Parse(this.txtPD_PROJECT_COMPLETE_DATE.Value));
        }
        if (PublicDal.PageValidate.IsDateTime(this.txtPD_PROJECT_YSSQ_DATE.Value))
        {
            model.PD_PROJECT_YSSQ_DATE = new DateTime?(DateTime.Parse(this.txtPD_PROJECT_YSSQ_DATE.Value));
        }
        if (PublicDal.PageValidate.IsDateTime(this.txtPD_PROJECT_YS_DATE.Value))
        {
            model.PD_PROJECT_YS_DATE = new DateTime?(DateTime.Parse(this.txtPD_PROJECT_YS_DATE.Value));
        }
        model.PD_PROJECT_YS_COMPANY = this.ddlPD_PROJECT_YS_COMPANY.SelectedValue;
        model.PD_PROJECT_YS_ZRR = this.txtPD_PROJECT_YS_ZRR.Text;
        model.PD_PROJECT_YS_NAME = this.txtPD_PROJECT_YS_NAME.Text;
        model.PD_PROJECT_YS_SUGGEST = this.txtPD_PROJECT_YS_SUGGEST.Text;
        model.PD_PROJECT_YS_RESULT = this.ddlPD_PROJECT_YS_RESULT.SelectedItem.Text;
        model.PD_PROJECT_YS_CONDITION = this.txtPD_PROJECT_YS_CONDITION.Text;
        return model;
    }

    private PD_PROJECT_APPRAISE_Model getModer_jgys_pj(PD_PROJECT_APPRAISE_Model APPRAISE_Model, string PD_PROJECT_CODE)
    {
        if (APPRAISE_Model == null)
        {
            APPRAISE_Model = new PD_PROJECT_APPRAISE_Model();
        }
        string text = this.txtAUTO_NO_APPRAISE.Text;
        if (!PublicDal.PageValidate.IsNumber(text))
        {
            text = "-1";
        }
        APPRAISE_Model.AUTO_NO = int.Parse(text);
        if (PublicDal.PageValidate.IsDateTime(this.txtPD_PROJECT_APP_DATE.Value))
        {
            APPRAISE_Model.PD_PROJECT_APP_DATE = new DateTime?(DateTime.Parse(this.txtPD_PROJECT_APP_DATE.Value));
        }
        APPRAISE_Model.PD_PROJECT_CODE = PD_PROJECT_CODE;
        APPRAISE_Model.PD_PROJECT_APP_COMPANY = this.txtPD_PROJECT_APP_COMPANY.Text;
        APPRAISE_Model.PD_PROJECT_APP_COMPANY_LIST = this.txtPD_PROJECT_APP_COMPANY_LIST.Text;
        APPRAISE_Model.PD_PROJECT_APP_MAN_LIST = this.txtPD_PROJECT_APP_MAN_LIST.Text;
        APPRAISE_Model.PD_PROJECT_APPRAISE_FILENO = this.txtPD_PROJECT_APPRAISE_FILENO.Text;
        return APPRAISE_Model;
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
            string str2 = "onclick=\"javascript:findwindow(1,this);\"";
            if (PublicDal.PageValidate.IsInt(row["PD_BASE_TZJGC"]) && (int.Parse(row["ISGETQUOTA"].ToString()) != 1))
            {
                str = " disabled=\"disabled\" ";
                str2 = "";
            }
            row["CHECKBOX"] = "<input type=\"checkbox\" name=\"tb_tzjgc_1_cb\" >";
            row["PD_BASE_TZJGC"] = getTZJGC(row["PD_BASE_TZJGC"].ToString());
            row["TB_QUOTA_CODE"] = string.Concat(new object[] { "<input id=\"TB_QUOTA_ZBWH_H\" style=\"width: 98%;\" readonly=\"readonly\" value=\"", row["TB_QUOTA_ZBWH_H"], "\" ", str, " ", str2, " /><input type=\"hidden\" name=\"TB_QUOTA_CODE\" id=\"TB_QUOTA_CODE\" value=\"", row["TB_QUOTA_CODE"], "\"/>" });
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
            string[] strArray = base.Request["TB_QUOTA_CODE"].Split(new char[] { ',' });
            string[] strArray2 = base.Request["PD_BASE_TZJGC"].Split(new char[] { ',' });
            string[] strArray3 = base.Request["PD_PROJECT_MONEY_CZ_SJ"].Split(new char[] { ',' });
            for (int i = 0; i < strArray2.Length; i++)
            {
                PD_PROJECT_TZJGC_Model item = new PD_PROJECT_TZJGC_Model
                {
                    PD_PROJECT_CODE = PD_PROJECT_CODE,
                    TB_QUOTA_CODE = strArray[i].Trim()
                };
                if (PublicDal.PageValidate.IsInt(strArray2[i]))
                {
                    item.PD_BASE_TZJGC = new decimal?(int.Parse(strArray2[i]));
                }
                if (PublicDal.PageValidate.IsDecimal(strArray3[i]))
                {
                    item.PD_PROJECT_MONEY_CZ_SJ = new decimal?(decimal.Parse(strArray3[i]));
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
            string str = base.Request["UpdatePK"];
            str_MXID = str;
            if (str == null)
            {
                str = "";
            }
            ButtonsModel model = null;
            this.ListPageLoad(this.Page, out model, base.Request["UpdatePK"]);
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
                    model.IfPrintNote = true;
                    model.IbtPrintNoteText = "打印";
                }
                else
                {
                    if ((base.Request["CreatePK"] != null) && (base.Request["CreatePK"].Trim() != ""))
                    {
                        this.ShowInfo(base.Request["CreatePK"].Trim());
                        this.addFileJSON(base.Request["CreatePK"].Trim());
                        this.HdFree1.Value = base.Request["CreatePK"].Trim();
                    }
                    else
                    {
                        this.RemoveTab();
                        this.addFileJSON("");
                    }
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
                }
            }
            this.ShowCS();
            if (this.ddlPD_PROJECT_STATUS.SelectedIndex != (this.ddlPD_PROJECT_STATUS.Items.Count - 1))
            {
                model.IfAudit = false;
            }
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
        if (this.txtPD_PROJECT_FZR.Text.Trim().Length == 0)
        {
            strErr = strErr + @"项目负责人不能为空！\n";
        }
        if (this.txtPD_PROJECT_CWFZR.Text.Trim().Length == 0)
        {
            strErr = strErr + @"财务负责人不能为空！\n";
        }
        if (this.txtPD_PROJECT_CONTENT.Text.Trim().Length == 0)
        {
            strErr = strErr + @"主要建设内容不能为空！\n";
        }
        if (this.ddlPD_PROJECT_COUNTRY.Text.Trim().Length == 0)
        {
            strErr = strErr + @"项目建设地点不能为空！\n";
        }
        if ((this.txtPD_PROJECT_MONEY_TOTAL.Text.Trim().Length == 0) || ((this.txtPD_PROJECT_MONEY_TOTAL.Text.Trim().Length > 0) && (decimal.Parse(this.txtPD_PROJECT_MONEY_TOTAL.Text) < 0M)))
        {
            strErr = strErr + @"投资总额不能为空,且需要大于等于0 \n";
        }
        if (strErr != "")
        {
            return false;
        }
        return true;
    }

    private void RemoveTab()
    {
        this.TabContainer1.Tabs.Remove(this.TabPanel_gkgs);
        this.TabContainer1.Tabs.Remove(this.TabPanel_xmxc);
        this.TabContainer1.Tabs.Remove(this.TabPanel_HeTong);
        this.TabContainer1.Tabs.Remove(this.TabPanel_zjbf);
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
        this.txtPD_PROJECT_BEGIN_DATE.Attributes.Add("readonly", "readonly");
        this.txtPD_PROJECT_END_DATE.Attributes.Add("readonly", "readonly");
    }

    private void ShowInfo(string PD_PROJECT_CODE)
    {
        TB_PROJECT_Model model = new TB_PROJECT_Bll().GetModel(PD_PROJECT_CODE);
        this.txtPD_PROJECT_CODE.Enabled = false;
        this.txtPD_PROJECT_NAME.Enabled = false;
        this.imgSearch.Attributes.Remove("onclick");
        this.txtPD_PROJECT_NAME.Attributes.Remove("QiPao");
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
        this.ddlPD_PROJECT_IFGS.SelectedValue = model.PD_PROJECT_IFGS.ToString();
        this.ddlPD_PROJECT_IFGS_BEFORE.SelectedValue = model.PD_PROJECT_IFGS_BEFORE.ToString();
        this.txtPD_PROJECT_OPEN_BODY.Text = model.PD_PROJECT_OPEN_BODY;
        this.txtPD_PROJECT_FZR.Text = model.PD_PROJECT_FZR;
        this.txtPD_PROJECT_CWFZR.Text = model.PD_PROJECT_CWFZR;
        this.txtPD_PROJECT_SYRS.Text = model.PD_PROJECT_SYRS.ToString();
        this.ddlPD_PROJECT_STATUS.SelectedValue = model.PD_PROJECT_STATUS;
        this.txtPD_PROJECT_BEGIN_DATE.Text = model.PD_PROJECT_BEGIN_DATE.ToString();
        this.txtPD_PROJECT_END_DATE.Text = model.PD_PROJECT_END_DATE.ToString();
        this.txtPD_PROJECT_YEARS.Text = model.PD_PROJECT_YEARS.ToString();
        this.txtPD_PROJECT_FILENO_LX.Text = model.PD_PROJECT_FILENO_LX;
        this.ShowPD_PROJECT_INPUT_COMPANY.Text = model.ShowPD_PROJECT_INPUT_COMPANY;
        this.ShowPD_PROJECT_INPUT_MAN.Text = model.ShowPD_PROJECT_INPUT_MAN;
        this.txtPD_PROJECT_INPUT_COMPANY.Text = model.PD_PROJECT_INPUT_COMPANY;
        this.txtPD_PROJECT_INPUT_MAN.Text = model.PD_PROJECT_INPUT_MAN;
        this.txtPD_PROJECT_INPUT_DATE.Text = model.PD_PROJECT_INPUT_DATE;
        this.ddlPD_PROJECT_COUNTRY.Text = model.PD_PROJECT_COUNTRY;
        this.txtPD_PROJECT_MONEY_TOTAL.Text = model.PD_PROJECT_MONEY_TOTAL.ToString();
        this.txtPD_PROJECT_MONEY_CZ_TOTAL.Text = model.PD_PROJECT_MONEY_CZ_TOTAL.ToString();
        this.txtPD_PROJECT_MONEY_CZ_SJ.Value = model.PD_PROJECT_MONEY_CZ_SJ.ToString();
        this.txtPD_PROJECT_MONEY_CZ_BJ.Value = model.PD_PROJECT_MONEY_CZ_BJ.ToString();
        this.txtPD_PROJECT_MONEY_ZC.Value = model.PD_PROJECT_MONEY_ZC.ToString();
        this.txtPD_PROJECT_MONEY_QT.Value = model.PD_PROJECT_MONEY_QT.ToString();
        this.lblPD_PROJECT_FILENO_PF.Value = model.PD_PROJECT_FILENO_PF;
        this.txtPD_PROJECT_FILENO_PF.Value = model.PD_PROJECT_FILENO_PF_CODE;
        this.txtPD_PROJECT_SSFW.Text = model.PD_PROJECT_SSFW;
        this.HdFree1.Value = model.Free1;
        this.pd_project_cm.Text = model.Free2;
        this.FREE8.Text = model.Free8.ToString();
        decimal num = new PD_FOUND_OUT_Bll().getLJMoney(model.PD_PROJECT_CODE, -1L);
        if (model.Free8 != 0M)
        {
            this.pd_project_jsje.Text = (((num / model.Free8) * 100M)).ToString("0.00") + "%";
        }
        else
        {
            this.pd_project_jsje.Text = "0%";
        }
        PD_PROJECT_ZTB_Model modelPROJECT = new PD_PROJECT_ZTB_Bll().GetModelPROJECT(PD_PROJECT_CODE);
        if (modelPROJECT != null)
        {
            this.ddlPD_PROJECT_ZTB_IF_SSFA.SelectedValue = modelPROJECT.PD_PROJECT_ZTB_IF_SSFA.ToString();//黄文华加tostring()
            this.ddlPD_PROJECT_ZTB_IF_ZTB.SelectedValue = modelPROJECT.PD_PROJECT_ZTB_IF_ZTB.ToString();//黄文华加tostring()
            this.ddlPD_PROJECT_ZTB_STYLE.SelectedValue = modelPROJECT.PD_PROJECT_ZTB_STYLE;
            this.ddlPD_PROJECT_ISCONTRACT.SelectedValue = modelPROJECT.PD_PROJECT_ISCONTRACT;
            this.txtPD_PROJECT_XXJD.Text = modelPROJECT.PD_PROJECT_XXJD;
            this.txtPD_PROJECT_FCXMGCL.Text = modelPROJECT.PD_PROJECT_FCXMGCL;
            this.txtPD_PROJECT_GCZLQK.Text = modelPROJECT.PD_PROJECT_GCZLQK;
        }
        this.BindImg();
        PD_PROJECT_JGYS_Model modelByProCode = new PD_PROJECT_JGYS_Bll().GetModelByProCode(PD_PROJECT_CODE);
        if (modelByProCode != null)
        {
            if (PublicDal.PageValidate.IsDateTime(modelByProCode.PD_PROJECT_COMPLETE_DATE))
            {
                this.txtPD_PROJECT_COMPLETE_DATE.Value = modelByProCode.PD_PROJECT_COMPLETE_DATE.ToString();
            }
            if (PublicDal.PageValidate.IsDateTime(modelByProCode.PD_PROJECT_YSSQ_DATE))
            {
                this.txtPD_PROJECT_YSSQ_DATE.Value = modelByProCode.PD_PROJECT_YSSQ_DATE.Value.ToShortDateString();
            }
            if (PublicDal.PageValidate.IsDateTime(modelByProCode.PD_PROJECT_YS_DATE))
            {
                this.txtPD_PROJECT_YS_DATE.Value = modelByProCode.PD_PROJECT_YS_DATE.Value.ToShortDateString();
            }
            this.ddlPD_PROJECT_YS_COMPANY.SelectedValue = modelByProCode.PD_PROJECT_YS_COMPANY;
            this.txtPD_PROJECT_YS_ZRR.Text = modelByProCode.PD_PROJECT_YS_ZRR;
            this.txtPD_PROJECT_YS_NAME.Text = modelByProCode.PD_PROJECT_YS_NAME;
            this.txtPD_PROJECT_YS_SUGGEST.Text = modelByProCode.PD_PROJECT_YS_SUGGEST;
            this.ddlPD_PROJECT_YS_RESULT.SelectedValue = modelByProCode.PD_PROJECT_YS_RESULT;
            this.txtPD_PROJECT_YS_CONDITION.Text = modelByProCode.PD_PROJECT_YS_CONDITION;
        }
        PD_PROJECT_APPRAISE_Model modelByProjectCode = new PD_PROJECT_APPRAISE_Bll().GetModelByProjectCode(PD_PROJECT_CODE);
        if (modelByProjectCode != null)
        {
            this.txtAUTO_NO_APPRAISE.Text = modelByProjectCode.AUTO_NO.ToString();
            if (PublicDal.PageValidate.IsDateTime(modelByProjectCode.PD_PROJECT_APP_DATE))
            {
                this.txtPD_PROJECT_APP_DATE.Value = modelByProjectCode.PD_PROJECT_APP_DATE.Value.ToShortDateString();
            }
            this.txtPD_PROJECT_APP_COMPANY.Text = modelByProjectCode.PD_PROJECT_APP_COMPANY;
            this.txtPD_PROJECT_APP_COMPANY_LIST.Text = modelByProjectCode.PD_PROJECT_APP_COMPANY_LIST;
            this.txtPD_PROJECT_APP_MAN_LIST.Text = modelByProjectCode.PD_PROJECT_APP_MAN_LIST;
            this.txtPD_PROJECT_APPRAISE_FILENO.Text = modelByProjectCode.PD_PROJECT_APPRAISE_FILENO.ToString();
        }
        if (this.ddlPD_PROJECT_STATUS.SelectedValue.Trim() == "05")
        {
            DataSet ds = DbHelperOra.Query("select * from  view_pd_project_gkgs where PD_Project_Code = '" + PD_PROJECT_CODE + "'  order by pd_project_code,auto_no desc ");
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                this.gvResult_gkgs.DataSource = ds.Tables[0];
                this.gvResult_gkgs.DataBind();
            }
            else
            {
                DataTable table = new DataTable();
                table = ds.Tables[0];
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                this.gvResult_gkgs.DataSource = table.DefaultView;
                this.gvResult_gkgs.DataBind();
            }
            ds = DbHelperOra.Query("select * from view_inspection_list where PD_Project_Code = '" + PD_PROJECT_CODE + "' order by pd_project_code,auto_no desc ");
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                DataView defaultView = ds.Tables[0].DefaultView;
                if ((this.ViewState["SortOrder"] != null) && (this.ViewState["OrderDire"] != null))
                {
                    string str2 = ((string)this.ViewState["SortOrder"]) + " " + ((string)this.ViewState["OrderDire"]);
                    defaultView.Sort = str2;
                }
                this.gvResult_xmxc.DataSource = defaultView;
                this.gvResult_xmxc.DataBind();
            }
            else
            {
                DataTable table2 = new DataTable();
                table2 = ds.Tables[0];
                DataRow row2 = table2.NewRow();
                table2.Rows.Add(row2);
                this.gvResult_xmxc.DataSource = table2.DefaultView;
                this.gvResult_xmxc.DataBind();
            }
            ds = DbHelperOra.Query("select * from view_contract_change_list where pd_project_code='" + PD_PROJECT_CODE + "' order by auto_no  ");
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                this.gvResult_HeTong.DataSource = ds;
                this.gvResult_HeTong.DataBind();
            }
            else
            {
                DataTable table3 = new DataTable();
                table3 = ds.Tables[0];
                DataRow row3 = table3.NewRow();
                table3.Rows.Add(row3);
                this.gvResult_HeTong.DataSource = table3.DefaultView;
                this.gvResult_HeTong.DataBind();
            }
            ds = DbHelperOra.Query("select * from v_pd_found_out_xmlist where pd_project_code='" + PD_PROJECT_CODE + "' order by auto_no  ");
            if (this.gvResult_zjbf.Columns.Count == 0)
            {
                PublicDal.setGViewColumns(ds, this.gvResult_zjbf);
            }
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                this.gvResult_zjbf.DataSource = ds;
                this.gvResult_zjbf.DataBind();
            }
            else
            {
                DataTable table4 = new DataTable();
                table4 = ds.Tables[0];
                DataRow row4 = table4.NewRow();
                table4.Rows.Add(row4);
                this.gvResult_zjbf.DataSource = table4.DefaultView;
                this.gvResult_zjbf.DataBind();
            }
        }
        else
        {
            this.RemoveTab();
        }
    }

    private void UpdataData(string PD_PROJECT_CODE)
    {
        TB_PROJECT_Bll bll = new TB_PROJECT_Bll();
        TB_PROJECT_Model model = bll.GetModel(PD_PROJECT_CODE);
        string text1 = model.PD_PROJECT_STATUS;
        TB_PROJECT_Model model2 = this.GetModel(model);
        model2.PD_PROJECT_CODE = PD_PROJECT_CODE;
        bll.Update(model2);
        PD_PROJECT_ATTACH_SB_Bll bll2 = new PD_PROJECT_ATTACH_SB_Bll();
        bll2.Delete(PD_PROJECT_CODE);
        List<PD_PROJECT_ATTACH_SB_Model> modelList = this.GetAttach_SBModel(PD_PROJECT_CODE);
        bll2.AddList(modelList);
        PD_PROJECT_JGYS_Bll bll3 = new PD_PROJECT_JGYS_Bll();
        PD_PROJECT_JGYS_Model model3 = bll3.GetModel(PD_PROJECT_CODE);
        if (model3 != null)
        {
            model3 = this.getModer_jgys(model3, PD_PROJECT_CODE);
            bll3.Update(model3);
        }
        else
        {
            model3 = this.getModer_jgys(model3, PD_PROJECT_CODE);
            bll3.Add(model3);
        }
        PD_PROJECT_APPRAISE_Bll bll4 = new PD_PROJECT_APPRAISE_Bll();
        PD_PROJECT_APPRAISE_Model modelByProjectCode = bll4.GetModelByProjectCode(PD_PROJECT_CODE);
        if (modelByProjectCode != null)
        {
            modelByProjectCode = this.getModer_jgys_pj(modelByProjectCode, PD_PROJECT_CODE);
            bll4.Update(modelByProjectCode);
        }
        else
        {
            modelByProjectCode = this.getModer_jgys_pj(modelByProjectCode, PD_PROJECT_CODE);
            bll4.Add(modelByProjectCode);
        }
        PD_PROJECT_ZTB_Bll bll5 = new PD_PROJECT_ZTB_Bll();
        PD_PROJECT_ZTB_Model modelPROJECT = bll5.GetModelPROJECT(PD_PROJECT_CODE);
        if (modelPROJECT != null)
        {
            modelPROJECT = this.GetModel_Ztb(modelPROJECT, PD_PROJECT_CODE);
            bll5.Update(modelPROJECT);
        }
        else
        {
            modelPROJECT = this.GetModel_Ztb(modelPROJECT, PD_PROJECT_CODE);
            bll5.Add(modelPROJECT);
        }
        this.AddImgMethod(model2);
        PD_PROJECT_TZJGC_Bll bll6 = new PD_PROJECT_TZJGC_Bll();
        bll6.DeleteAll(PD_PROJECT_CODE);
        List<PD_PROJECT_TZJGC_Model> listModel = this.getTZJGCModel(PD_PROJECT_CODE);
        bll6.Add(listModel);
        new PD_FOUND_OUT_Bll().UpdateLJMoney(PD_PROJECT_CODE);
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
