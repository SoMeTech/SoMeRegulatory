using AjaxPro;
using ASP;
using ExtExtenders;
using SoMeTech.CommonDll;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using YYControls;
using SMZJ.BLL;
using SMZJ.Model;

public class Work_GL_SSMx : Page, IRequiresSessionState
{
    protected TextBox _RowIndex;
    protected DropDownList ddlPD_PROJECT_ISCONTRACT;
    protected DropDownList ddlPD_PROJECT_ZTB_IF_SSFA;
    protected DropDownList ddlPD_PROJECT_ZTB_IF_ZTB;
    protected DropDownList ddlPD_PROJECT_ZTB_STYLE;
    protected UserControls_FilePostCtr FilePostCtr1;
    public string json_htbggl = "";
    public string json_htgl = "";
    public string json_xmccxc = "";
    public string json_xmssjk = "";
    public string json_xmsszl = "";
    public string jsonData_htbggl = "";
    public string jsonData_htgl = "";
    public string jsonData_xmccxc = "";
    public string jsonData_xmssjk = "";
    public string jsonData_xmsszl = "";
    protected TextBox lblAUTO_NO;
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
    protected TabPanel Panel_gkgs;
    protected TabPanel Panel_htbggl;
    protected TabPanel Panel_htgl;
    protected TabPanel Panel_xcsgt;
    protected TabPanel Panel_xmgk;
    protected TabPanel Panel_xmsszl;
    protected TabPanel Panel_ztbgl;
    protected TextBox PD_PROJECT_JG_RESULT;
    protected TextBox PD_PROJECT_JG_SUGGEST;
    protected TextBox PD_PROJECT_JGJL;
    protected TabContainer TabContainer1;
    protected TextBox txtPD_GK_DEPART;
    protected TextBox txtPD_PROJECT_FCXMGCL;
    protected HtmlInputHidden txtPD_PROJECT_FILENO_PF;
    protected TextBox txtPD_PROJECT_GCZLQK;
    protected TextBox txtPD_PROJECT_XXJD;

    private void Bind(string PD_PROJECT_CODE)
    {
        DataSet list = new PD_CONTRACT_CHANGE_Bll().GetList(" PD_PROJECT_CODE='" + PD_PROJECT_CODE + "'");
        this.jsonData_htbggl = PublicDal.DataToJSON(list);
        if (list.Tables[0].Rows.Count > 0)
        {
            list.Tables[0].Rows.Clear();
        }
        DataRow row = list.Tables[0].NewRow();
        row["PD_PROJECT_CODE"] = PD_PROJECT_CODE;
        list.Tables[0].Rows.Add(row);
        this.json_htbggl = PublicDal.DataToJSON(list);
        DataSet ds = new PD_PROJECT_CONTRACT_Bll().GetList(" PD_PROJECT_CODE='" + PD_PROJECT_CODE + "'");
        this.jsonData_htgl = PublicDal.DataToJSON(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ds.Tables[0].Rows.Clear();
        }
        DataRow row2 = ds.Tables[0].NewRow();
        ds.Tables[0].Rows.Add(row2);
        this.json_htgl = PublicDal.DataToJSON(ds);
        DataSet set3 = new PD_PROJECT_ATTACH_SS_Bll().GetList(" PD_PROJECT_CODE='" + PD_PROJECT_CODE + "'");
        this.jsonData_xmsszl = PublicDal.DataToJSON(set3);
        if (set3.Tables[0].Rows.Count > 0)
        {
            set3.Tables[0].Rows.Clear();
        }
        DataRow row3 = set3.Tables[0].NewRow();
        row3[1] = PD_PROJECT_CODE;
        set3.Tables[0].Rows.Add(row3);
        this.json_xmsszl = PublicDal.DataToJSON(set3);
        DataSet set4 = new PD_PROJECT_INSPECTION_Bll().GetList(" PD_PROJECT_CODE='" + PD_PROJECT_CODE + "'");
        this.jsonData_xmccxc = PublicDal.DataToJSON(set4);
        if (set4.Tables[0].Rows.Count > 0)
        {
            set4.Tables[0].Rows.Clear();
        }
        DataRow row4 = set4.Tables[0].NewRow();
        row4[1] = PD_PROJECT_CODE;
        set4.Tables[0].Rows.Add(row4);
        this.json_xmccxc = PublicDal.DataToJSON(set4);
    }

    private void BindDDList()
    {
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_ZTB_IF_SSFA, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_ZTB_IF_ZTB, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_ISCONTRACT, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_PROJECT_ZTB_STYLE, "PD_BASE_TenderType", "TenderType_Name", "TenderType_Code", "");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.UpLoadFile(@"C:\Documents and Settings\Administrator\桌面\C# 便签.txt", @"WebControls\UserControl\upfile");
    }

    public void Buttons(string ibtid)
    {
        switch (ibtid)
        {
            case "ibtcontrol_ibtprintnote":
                PageShowText.OpenPage(Public.RelativelyPath("Report/jsxGTable.aspx") + "?UpdatePK=" + base.Request["UpdatePK"].Trim(), null, null, this.Page, true);
                return;

            case "ibtcontrol_ibtsave":
                this.UpdataData(base.Request["UpdatePK"]);
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
                this.SetServiceStream(0, base.Request.Params["UpdatePK"], "弃审");
                return;

            default:
                return;
        }
    }

    [AjaxMethod]
    public void DownFile(string str, string FileName)
    {
        int index = FileName.IndexOf(str);
        int num2 = FileName.LastIndexOf("|", index);
        int length = -1;
        if (num2 == -1)
        {
            length = FileName.IndexOf("|", (int)(index + 1));
        }
        if ((num2 != -1) && (length != -1))
        {
            FileName = FileName.Substring(num2 + 1, (length - num2) - 1);
        }
        else if (num2 != -1)
        {
            FileName = FileName.Substring(num2 + 1);
        }
        else if (length != -1)
        {
            FileName = FileName.Substring(0, length);
        }
        string[] strArray = FileName.Split(new char[] { ':' });
        PageShowText.OpenPage(Public.RelativelyPath("WebControls/UserControl/DownFile.aspx?filename=" + strArray[1] + "&systemName=" + strArray[0]), this.Page);
    }

    private List<PD_PROJECT_ATTACH_SS_Model> GetAttach_SSModel(string PD_PROJECT_CODE, ref string strErr)
    {
        List<PD_PROJECT_ATTACH_SS_Model> list = new List<PD_PROJECT_ATTACH_SS_Model>();
        if (base.Request.Form["table_xmsszl_PD_PROJECT_CODE"] != null)
        {
            string[] strArray = base.Request.Form["table_xmsszl_PD_PROJECT_CODE"].Split(new char[] { ',' });
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
                PD_PROJECT_ATTACH_SS_Model item = new PD_PROJECT_ATTACH_SS_Model
                {
                    PD_PROJECT_CODE = strArray[i]
                };
                if (defaultView != null)
                {
                    defaultView.RowFilter = " tableID='table_xmsszl' and rowIndex=" + (i + 1);
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

    private List<PD_CONTRACT_CHANGE_Model> GetChangeModel(string PD_PROJECT_CODE, ref string strErr)
    {
        List<PD_CONTRACT_CHANGE_Model> list = new List<PD_CONTRACT_CHANGE_Model>();
        if (base.Request.Form["htbggl_PD_PROJECT_CODE"] != null)
        {
            string[] strArray = base.Request.Form["htbggl_PD_CONTRACT_PICI"].Split(new char[] { ',' });
            base.Request.Form["htbggl_AUTO_NO"].Split(new char[] { ',' });
            string[] strArray2 = base.Request.Form["htbggl_PD_CONTRACT_NO"].Split(new char[] { ',' });
            string[] strArray3 = base.Request.Form["htbggl_PD_PROJECT_CODE"].Split(new char[] { ',' });
            string[] strArray4 = base.Request.Form["htbggl_PD_CONTRACT_CHANGE_DATE"].Split(new char[] { ',' });
            string[] strArray5 = base.Request.Form["htbggl_PD_CONTRACT_CHANGE_REASON"].Split(new char[] { ',' });
            string[] strArray6 = base.Request.Form["htbggl_PD_CONTRACT_MONEY"].Split(new char[] { ',' });
            string[] strArray7 = base.Request.Form["htbggl_PD_CONTRACT_CHANGE_ZJ"].Split(new char[] { ',' });
            string[] strArray8 = base.Request.Form["htbggl_PD_CONTRACT_CHANGE_MONEY"].Split(new char[] { ',' });
            string[] strArray9 = base.Request.Form["htbggl_PD_CONTRACT_STATE"].Split(new char[] { ',' });
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
            for (int i = 0; i < strArray3.Length; i++)
            {
                PD_CONTRACT_CHANGE_Model item = new PD_CONTRACT_CHANGE_Model
                {
                    PD_CONTRACT_PICI = new int?(int.Parse(strArray[i])),
                    PD_PROJECT_CODE = PD_PROJECT_CODE,
                    AUTO_NO = i.ToString(),
                    PD_CONTRACT_NO = strArray2[i],
                    PD_CONTRACT_CHANGE_DATE = new DateTime?(DateTime.Parse(strArray4[i])),
                    PD_CONTRACT_CHANGE_REASON = strArray5[i],
                    PD_CONTRACT_MONEY = new decimal?(int.Parse(strArray6[i])),
                    PD_CONTRACT_CHANGE_ZJ = strArray7[i],
                    PD_CONTRACT_CHANGE_MONEY = new decimal?(int.Parse(strArray8[i])),
                    PD_CONTRACT_STATE = new int?(int.Parse(strArray9[i]))
                };
                if (defaultView != null)
                {
                    defaultView.RowFilter = " tableID='table_htbggl' and rowIndex=" + (i + 1);
                    if (defaultView.Count > 0)
                    {
                        item.PD_CONTRACT_CHANGE_FILENAME_SQ = defaultView[0]["FileName"].ToString();
                        item.PD_CONTRACT_FILENAME_SYSTEM_SQ = defaultView[0]["FileSysName"].ToString();
                    }
                }
                list.Add(item);
            }
        }
        return list;
    }

    private List<PD_PROJECT_CONTRACT_Model> GetContractModel(string PD_PROJECT_CODE, ref string strErr)
    {
        List<PD_PROJECT_CONTRACT_Model> list = new List<PD_PROJECT_CONTRACT_Model>();
        if (base.Request.Form["htgl_PD_CONTRACT_NO"] != null)
        {
            string[] strArray = base.Request.Form["htgl_PD_CONTRACT_NO"].Split(new char[] { ',' });
            string[] strArray2 = base.Request.Form["htgl_PD_CONTRACT_NAME"].Split(new char[] { ',' });
            string[] strArray3 = base.Request.Form["htgl_PD_CONTRACT_DATE"].Split(new char[] { ',' });
            string[] strArray4 = base.Request.Form["htgl_PD_CONTRACT_COMPANY"].Split(new char[] { ',' });
            string[] strArray5 = base.Request.Form["htgl_PD_CONTRACT_MOENY"].Split(new char[] { ',' });
            string[] strArray6 = base.Request.Form["htgl_PD_CONTRACT_ASK_LIMIT"].Split(new char[] { ',' });
            string[] strArray7 = base.Request.Form["htgl_PD_CONTRACT_ASK_PROCEED"].Split(new char[] { ',' });
            string[] strArray8 = base.Request.Form["htgl_PD_CONTRACT_ASK_PAYMENT"].Split(new char[] { ',' });
            string[] strArray9 = base.Request.Form["htgl_PD_CONTRACT_NOTE"].Split(new char[] { ',' });
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
                PD_PROJECT_CONTRACT_Model item = new PD_PROJECT_CONTRACT_Model
                {
                    PD_PROJECT_CODE = PD_PROJECT_CODE,
                    PD_CONTRACT_NAME = strArray2[i],
                    PD_CONTRACT_NO = strArray[i],
                    PD_CONTRACT_DATE = DateTime.Parse(strArray3[i]),
                    PD_CONTRACT_COMPANY = strArray4[i],
                    PD_CONTRACT_MOENY = new decimal?(int.Parse(strArray5[i])),
                    PD_CONTRACT_ASK_LIMIT = strArray6[i],
                    PD_CONTRACT_ASK_PROCEED = strArray7[i],
                    PD_CONTRACT_ASK_PAYMENT = strArray8[i]
                };
                if (defaultView != null)
                {
                    item.PD_CONTRACT_NOTE = strArray9[i];
                    defaultView.RowFilter = " tableID='table_htgl' and rowIndex=" + (i + 1);
                    if (defaultView.Count > 0)
                    {
                        item.PD_CONTRACT_FILENAME = defaultView[0]["FileName"].ToString();
                        item.PD_CONTRACT_FILENAME_SYSTEM = defaultView[0]["FileSysName"].ToString();
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
                            case "ddlPD_CONTRACT_CHANGE_TYPE":
                            case "ddlPD_CONTRACT_TYPE":
                            case "ddlPD_CONTRACT_CHANGE_ZJ":
                            case "PD_CONTRACT_PiCi":
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

    private List<PD_PROJECT_INSPECTION_Model> GetInspectionModel(string PD_PROJECT_CODE, ref string strErr)
    {
        List<PD_PROJECT_INSPECTION_Model> list = new List<PD_PROJECT_INSPECTION_Model>();
        if (base.Request.Form["xmccxc_PD_PROJECT_CODE"] != null)
        {
            string[] strArray = base.Request.Form["xmccxc_PD_PROJECT_CODE"].Split(new char[] { ',' });
            string[] strArray2 = base.Request.Form["xmccxc_PD_INSPECTION_PROCESS"].Split(new char[] { ',' });
            string[] strArray3 = base.Request.Form["xmccxc_PD_INSPECTION_DATE"].Split(new char[] { ',' });
            string[] strArray4 = base.Request.Form["xmccxc_PD_INSPECTION_MANS"].Split(new char[] { ',' });
            string[] strArray5 = base.Request.Form["xmccxc_PD_INSPECTION_ADDR"].Split(new char[] { ',' });
            string[] strArray6 = base.Request.Form["xmccxc_PD_INSPECTION_CONTENT"].Split(new char[] { ',' });
            string[] strArray7 = base.Request.Form["xmccxc_PD_INSPECTION_SUGGEST"].Split(new char[] { ',' });
            string[] strArray8 = base.Request.Form["xmccxc_PD_INSPECTION_CONCLUSION"].Split(new char[] { ',' });
            string[] strArray9 = base.Request.Form["xmccxc_PD_MONITOR_PROCEED_WCL"].Split(new char[] { ',' });
            string[] strArray10 = base.Request.Form["xmccxc_PD_PROJECT_TOTAL_MONEY"].Split(new char[] { ',' });
            string[] strArray11 = base.Request.Form["xmccxc_PD_MONITOR_TOTAL_MONEY_PAY"].Split(new char[] { ',' });
            string[] strArray12 = base.Request.Form["xmccxc_PD_MONITOR_TOTAL_MONEY_WCL"].Split(new char[] { ',' });
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
                PD_PROJECT_INSPECTION_Model item = new PD_PROJECT_INSPECTION_Model
                {
                    PD_PROJECT_CODE = PD_PROJECT_CODE,
                    AUTO_NO = i.ToString(),
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
                if (PublicDal.PageValidate.IsDecimal(strArray9[i]))
                {
                    item.PD_MONITOR_PROCEED_WCL = new decimal?(decimal.Parse(strArray9[i]));
                }
                if (PublicDal.PageValidate.IsDecimal(strArray10[i]))
                {
                    item.PD_PROJECT_TOTAL_MONEY = new decimal?(decimal.Parse(strArray10[i]));
                }
                if (PublicDal.PageValidate.IsDecimal(strArray11[i]))
                {
                    item.PD_MONITOR_TOTAL_MONEY_PAY = new decimal?(decimal.Parse(strArray11[i]));
                }
                if (PublicDal.PageValidate.IsDecimal(strArray12[i]))
                {
                    item.PD_MONITOR_TOTAL_MONEY_WCL = new decimal?(decimal.Parse(strArray12[i]));
                }
                if (defaultView != null)
                {
                    defaultView.RowFilter = " tableID='table_xmccxc' and rowIndex=" + (i + 1);
                    if (defaultView.Count > 0)
                    {
                        item.PD_INSPECTION_FILENAME = defaultView[0]["FileName"].ToString();
                        item.PD_INSPECTION_FILENAME_SYSTEM = defaultView[0]["FileSysName"].ToString();
                    }
                }
                list.Add(item);
            }
        }
        return list;
    }

    private bool GetModel(string PD_PROJECT_CODE, ref List<PD_CONTRACT_CHANGE_Model> CHANGE_Model, ref List<PD_PROJECT_ATTACH_SS_Model> SS_Model, ref List<PD_PROJECT_CONTRACT_Model> CONTRACT_Model, ref List<PD_PROJECT_INSPECTION_Model> INSPECTION_Model, ref List<PD_PROJECT_MONITOR_Model> MONITOR_Model, ref PD_PROJECT_ZTB_Model ZTB_Model, ref string errText)
    {
        SS_Model = this.GetAttach_SSModel(PD_PROJECT_CODE, ref errText);
        if (SS_Model == null)
        {
            this.TabContainer1.ActiveTabIndex = 4;
            return false;
        }
        this.GetZtbModel(ref ZTB_Model, PD_PROJECT_CODE, ref errText);
        if (ZTB_Model == null)
        {
            this.TabContainer1.ActiveTabIndex = 1;
            return false;
        }
        return true;
    }

    private List<PD_PROJECT_MONITOR_Model> GetMonitorModel(string PD_PROJECT_CODE, ref string strErr)
    {
        List<PD_PROJECT_MONITOR_Model> list = new List<PD_PROJECT_MONITOR_Model>();
        if (base.Request.Form["xmssjk_PD_PROJECT_CODE"] != null)
        {
            string[] strArray = base.Request.Form["xmssjk_PD_PROJECT_CODE"].Split(new char[] { ',' });
            string[] strArray2 = base.Request.Form["xmssjk_PD_MONITOR_INPUT_DATE"].Split(new char[] { ',' });
            string[] strArray3 = base.Request.Form["xmssjk_PD_MONITOR_PROCEED_WCL"].Split(new char[] { ',' });
            string[] strArray4 = base.Request.Form["xmssjk_PD_PROJECT_TOTAL_MONEY"].Split(new char[] { ',' });
            string[] strArray5 = base.Request.Form["xmssjk_PD_MONITOR_TOTAL_MONEY_PAY"].Split(new char[] { ',' });
            string[] strArray6 = base.Request.Form["xmssjk_PD_MONITOR_TOTAL_MONEY_WCL"].Split(new char[] { ',' });
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
                PD_PROJECT_MONITOR_Model item = new PD_PROJECT_MONITOR_Model
                {
                    AUTO_NO = "0",
                    PD_PROJECT_CODE = PD_PROJECT_CODE
                };
                if (PublicDal.PageValidate.IsDateTime(strArray2[i]))
                {
                    item.PD_MONITOR_INPUT_DATE = new DateTime?(DateTime.Parse(strArray2[i]));
                }
                if (PublicDal.PageValidate.IsDecimal(strArray3[i]))
                {
                    item.PD_MONITOR_PROCEED_WCL = new decimal?(decimal.Parse(strArray3[i]));
                }
                if (PublicDal.PageValidate.IsDecimal(strArray4[i]))
                {
                    item.PD_PROJECT_TOTAL_MONEY = new decimal?(decimal.Parse(strArray4[i]));
                }
                if (PublicDal.PageValidate.IsDecimal(strArray5[i]))
                {
                    item.PD_MONITOR_TOTAL_MONEY_PAY = new decimal?(decimal.Parse(strArray5[i]));
                }
                if (PublicDal.PageValidate.IsDecimal(strArray6[i]))
                {
                    item.PD_MONITOR_TOTAL_MONEY_WCL = new decimal?(decimal.Parse(strArray6[i]));
                }
                if (defaultView != null)
                {
                    defaultView.RowFilter = " tableID='table_xmssjk' and rowIndex=" + (i + 1);
                    if (defaultView.Count > 0)
                    {
                        item.PD_MONITOR_FILENAME = defaultView[0]["FileName"].ToString();
                        item.PD_MONITOR_FILENAME_SYSTEM = defaultView[0]["FileSysName"].ToString();
                    }
                }
                list.Add(item);
            }
        }
        return list;
    }

    private void GetZtbModel(ref PD_PROJECT_ZTB_Model model, string PD_PROJECT_CODE, ref string strErr)
    {
        if (!PageValidate.IsNumber(this.ddlPD_PROJECT_ZTB_IF_SSFA.SelectedValue))
        {
            strErr = strErr + @"是否完成实施方案编制格式错误！\n";
        }
        if (!PageValidate.IsNumber(this.ddlPD_PROJECT_ZTB_IF_ZTB.SelectedValue))
        {
            strErr = strErr + @"是否招投标格式错误！\n";
        }
        if (this.ddlPD_PROJECT_ZTB_STYLE.SelectedValue.Trim().Length == 0)
        {
            strErr = strErr + @"招标方式不能为空！\n";
        }
        if (strErr != "")
        {
            model = null;
        }
        else
        {
            int num = int.Parse(this.ddlPD_PROJECT_ZTB_IF_SSFA.SelectedValue);
            int num2 = int.Parse(this.ddlPD_PROJECT_ZTB_IF_ZTB.SelectedValue);
            string selectedValue = this.ddlPD_PROJECT_ZTB_STYLE.SelectedValue;
            model.PD_PROJECT_CODE = PD_PROJECT_CODE;
            model.PD_PROJECT_ZTB_IF_SSFA = new int?(num);
            model.PD_PROJECT_ZTB_IF_ZTB = new int?(num2);
            model.PD_PROJECT_ZTB_STYLE = selectedValue;
            model.PD_PROJECT_ISCONTRACT = this.ddlPD_PROJECT_ISCONTRACT.SelectedValue;
            model.PD_PROJECT_XXJD = this.txtPD_PROJECT_XXJD.Text;
            model.PD_PROJECT_FCXMGCL = this.txtPD_PROJECT_FCXMGCL.Text;
            model.PD_PROJECT_GCZLQK = this.txtPD_PROJECT_GCZLQK.Text;
        }
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

    private void hy_File(List<PD_PROJECT_ATTACH_SS_Model> SS_Model, List<PD_PROJECT_CONTRACT_Model> CONTRACT_Model, List<PD_CONTRACT_CHANGE_Model> CHANGE_Model, List<PD_PROJECT_MONITOR_Model> MONITOR_Model, List<PD_PROJECT_INSPECTION_Model> INSPECTION_Model, string ShowText)
    {
        string strErr = "";
        if (SS_Model == null)
        {
            SS_Model = this.GetAttach_SSModel(base.Request["UpdatePK"], ref strErr);
        }
        DataSet ds = new DataSet();
        ds.Tables.Add();
        ds.Tables[0].Columns.Add("AUTO_NO");
        ds.Tables[0].Columns.Add("PD_PROJECT_CODE");
        ds.Tables[0].Columns.Add("PD_PROJECT_ATTACH_NAME");
        ds.Tables[0].Columns.Add("PD_PROJECT_ATTACH_NAME_SYSTEM");
        int num = 0;
        foreach (PD_PROJECT_ATTACH_SS_Model model in SS_Model)
        {
            DataRow row = ds.Tables[0].NewRow();
            row["AUTO_NO"] = num++;
            row["PD_PROJECT_CODE"] = model.PD_PROJECT_CODE;
            row["PD_PROJECT_ATTACH_NAME"] = model.PD_PROJECT_ATTACH_NAME;
            row["PD_PROJECT_ATTACH_NAME_SYSTEM"] = model.PD_PROJECT_ATTACH_NAME_SYSTEM;
            ds.Tables[0].Rows.Add(row);
        }
        string str = "PostLoadxmsszl('table_xmsszl',eval(decodeURIComponent(\"" + base.Server.UrlEncode(PublicDal.DataToJSON(ds)) + "\")),'xmss_5');";
        if (CONTRACT_Model == null)
        {
            CONTRACT_Model = this.GetContractModel(base.Request["UpdatePK"], ref strErr);
        }
        ds = new DataSet();
        ds.Tables.Add();
        ds.Tables[0].Columns.Add("PD_CONTRACT_NO");
        ds.Tables[0].Columns.Add("PD_CONTRACT_NAME");
        ds.Tables[0].Columns.Add("PD_CONTRACT_DATE");
        ds.Tables[0].Columns.Add("PD_CONTRACT_COMPANY");
        ds.Tables[0].Columns.Add("PD_CONTRACT_MOENY");
        ds.Tables[0].Columns.Add("PD_CONTRACT_MOENY_CHANGE");
        ds.Tables[0].Columns.Add("PD_CONTRACT_ASK_LIMIT");
        ds.Tables[0].Columns.Add("PD_CONTRACT_ASK_PROCEED");
        ds.Tables[0].Columns.Add("PD_CONTRACT_ASK_PAYMENT");
        ds.Tables[0].Columns.Add("PD_CONTRACT_NOTE");
        ds.Tables[0].Columns.Add("PD_CONTRACT_FILENAME");
        ds.Tables[0].Columns.Add("PD_CONTRACT_FILENAME_SYSTEM");
        foreach (PD_PROJECT_CONTRACT_Model model2 in CONTRACT_Model)
        {
            DataRow row2 = ds.Tables[0].NewRow();
            row2["PD_CONTRACT_NO"] = model2.PD_CONTRACT_NO;
            row2["PD_CONTRACT_NAME"] = model2.PD_CONTRACT_NAME;
            row2["PD_CONTRACT_DATE"] = model2.PD_CONTRACT_DATE.ToString("yyyy-M-d");
            row2["PD_CONTRACT_COMPANY"] = model2.PD_CONTRACT_COMPANY;
            row2["PD_CONTRACT_MOENY"] = model2.PD_CONTRACT_MOENY;
            row2["PD_CONTRACT_MOENY_CHANGE"] = model2.PD_CONTRACT_MOENY_CHANGE;
            row2["PD_CONTRACT_ASK_LIMIT"] = model2.PD_CONTRACT_ASK_LIMIT;
            row2["PD_CONTRACT_ASK_PROCEED"] = model2.PD_CONTRACT_ASK_PROCEED;
            row2["PD_CONTRACT_ASK_PAYMENT"] = model2.PD_CONTRACT_ASK_PAYMENT;
            row2["PD_CONTRACT_NOTE"] = model2.PD_CONTRACT_NOTE;
            row2["PD_CONTRACT_FILENAME"] = model2.PD_CONTRACT_FILENAME;
            row2["PD_CONTRACT_FILENAME_SYSTEM"] = model2.PD_CONTRACT_FILENAME_SYSTEM;
            ds.Tables[0].Rows.Add(row2);
        }
        str = str + "PostLoadxmsszl('table_htgl',eval(decodeURIComponent(\"" + base.Server.UrlEncode(PublicDal.DataToJSON(ds)) + "\")),'ss_table_htgl');";
        if (CHANGE_Model == null)
        {
            CHANGE_Model = this.GetChangeModel(base.Request["UpdatePK"], ref strErr);
        }
        ds = new DataSet();
        ds.Tables.Add();
        ds.Tables[0].Columns.Add("PD_CONTRACT_PICI");
        ds.Tables[0].Columns.Add("AUTO_NO");
        ds.Tables[0].Columns.Add("PD_CONTRACT_NO");
        ds.Tables[0].Columns.Add("PD_PROJECT_CODE");
        ds.Tables[0].Columns.Add("PD_CONTRACT_CHANGE_DATE");
        ds.Tables[0].Columns.Add("PD_CONTRACT_CHANGE_REASON");
        ds.Tables[0].Columns.Add("PD_CONTRACT_MONEY");
        ds.Tables[0].Columns.Add("PD_CONTRACT_CHANGE_ZJ");
        ds.Tables[0].Columns.Add("PD_CONTRACT_CHANGE_MONEY");
        ds.Tables[0].Columns.Add("PD_CONTRACT_STATE");
        ds.Tables[0].Columns.Add("PD_CONTRACT_CHANGE_FILENAME_SQ");
        ds.Tables[0].Columns.Add("PD_CONTRACT_FILENAME_SYSTEM_SQ");
        foreach (PD_CONTRACT_CHANGE_Model model3 in CHANGE_Model)
        {
            DataRow row3 = ds.Tables[0].NewRow();
            row3["PD_CONTRACT_PICI"] = model3.PD_CONTRACT_PICI;
            row3["AUTO_NO"] = model3.AUTO_NO;
            row3["PD_CONTRACT_NO"] = model3.PD_CONTRACT_NO;
            row3["PD_PROJECT_CODE"] = model3.PD_PROJECT_CODE;
            row3["PD_CONTRACT_CHANGE_DATE"] = model3.PD_CONTRACT_CHANGE_DATE;
            row3["PD_CONTRACT_CHANGE_REASON"] = model3.PD_CONTRACT_CHANGE_REASON;
            row3["PD_CONTRACT_MONEY"] = model3.PD_CONTRACT_MONEY;
            row3["PD_CONTRACT_CHANGE_ZJ"] = model3.PD_CONTRACT_CHANGE_ZJ;
            row3["PD_CONTRACT_CHANGE_MONEY"] = model3.PD_CONTRACT_CHANGE_MONEY;
            row3["PD_CONTRACT_STATE"] = model3.PD_CONTRACT_STATE;
            row3["PD_CONTRACT_CHANGE_FILENAME_SQ"] = model3.PD_CONTRACT_CHANGE_FILENAME_SQ;
            row3["PD_CONTRACT_FILENAME_SYSTEM_SQ"] = model3.PD_CONTRACT_FILENAME_SYSTEM_SQ;
            ds.Tables[0].Rows.Add(row3);
        }
        str = str + "PostLoadxmsszl('table_htbggl',eval(decodeURIComponent(\"" + base.Server.UrlEncode(PublicDal.DataToJSON(ds)) + "\")),'ss_table_htbggl');";
        if (INSPECTION_Model == null)
        {
            INSPECTION_Model = this.GetInspectionModel(base.Request["UpdatePK"], ref strErr);
        }
        ds = new DataSet();
        ds.Tables.Add();
        ds.Tables[0].Columns.Add("AUTO_NO");
        ds.Tables[0].Columns.Add("PD_PROJECT_CODE");
        ds.Tables[0].Columns.Add("PD_INSPECTION_PROCESS");
        ds.Tables[0].Columns.Add("PD_INSPECTION_DATE");
        ds.Tables[0].Columns.Add("PD_INSPECTION_MANS");
        ds.Tables[0].Columns.Add("PD_INSPECTION_ADDR");
        ds.Tables[0].Columns.Add("PD_INSPECTION_CONTENT");
        ds.Tables[0].Columns.Add("PD_INSPECTION_SUGGEST");
        ds.Tables[0].Columns.Add("PD_INSPECTION_CONCLUSION");
        ds.Tables[0].Columns.Add("PD_INSPECTION_FILENAME");
        ds.Tables[0].Columns.Add("PD_INSPECTION_FILENAME_SYSTEM");
        ds.Tables[0].Columns.Add("PD_MONITOR_PROCEED_WCL");
        ds.Tables[0].Columns.Add("PD_PROJECT_TOTAL_MONEY");
        ds.Tables[0].Columns.Add("PD_MONITOR_TOTAL_MONEY_PAY");
        ds.Tables[0].Columns.Add("PD_MONITOR_TOTAL_MONEY_WCL");
        foreach (PD_PROJECT_INSPECTION_Model model4 in INSPECTION_Model)
        {
            DataRow row4 = ds.Tables[0].NewRow();
            row4["AUTO_NO"] = model4.AUTO_NO;
            row4["PD_PROJECT_CODE"] = model4.PD_PROJECT_CODE;
            row4["PD_INSPECTION_PROCESS"] = model4.PD_INSPECTION_PROCESS;
            row4["PD_INSPECTION_DATE"] = model4.PD_INSPECTION_DATE;
            row4["PD_INSPECTION_MANS"] = model4.PD_INSPECTION_MANS;
            row4["PD_INSPECTION_ADDR"] = model4.PD_INSPECTION_ADDR;
            row4["PD_INSPECTION_CONTENT"] = model4.PD_INSPECTION_CONTENT;
            row4["PD_INSPECTION_SUGGEST"] = model4.PD_INSPECTION_SUGGEST;
            row4["PD_INSPECTION_CONCLUSION"] = model4.PD_INSPECTION_CONCLUSION;
            row4["PD_INSPECTION_FILENAME"] = model4.PD_INSPECTION_FILENAME;
            row4["PD_INSPECTION_FILENAME_SYSTEM"] = model4.PD_INSPECTION_FILENAME_SYSTEM;
            row4["PD_MONITOR_PROCEED_WCL"] = model4.PD_MONITOR_PROCEED_WCL;
            row4["PD_PROJECT_TOTAL_MONEY"] = model4.PD_PROJECT_TOTAL_MONEY;
            row4["PD_MONITOR_TOTAL_MONEY_PAY"] = model4.PD_MONITOR_TOTAL_MONEY_PAY;
            row4["PD_MONITOR_TOTAL_MONEY_WCL"] = model4.PD_MONITOR_TOTAL_MONEY_WCL;
            ds.Tables[0].Rows.Add(row4);
        }
        str = str + "PostLoadxmsszl('table_xmccxc',eval(decodeURIComponent(\"" + base.Server.UrlEncode(PublicDal.DataToJSON(ds)) + "\")),'ss_table_htgl');";
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
        this.ListPageLoad(this.Page, out model, base.Request["UpdatePK"]);
        this.Master.btModel = model;
        model.IfPrintNote = true;
        model.IbtPrintNoteText = "打印";
        if ((!base.IsPostBack && (base.Request["UpdatePK"] != null)) && (base.Request["UpdatePK"].Trim() != ""))
        {
            this.BindDDList();
            this.ShowInfo(base.Request["UpdatePK"].Trim());
            this.Bind(base.Request["UpdatePK"]);
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
    }

    public void SetServiceStream(int operation, string PD_PROJECT_CODE, string Mess)
    {
        PublicDal.SetServiceStream(this.Page, operation, "TB_PROJECT", "PD_PROJECT_CODE", PD_PROJECT_CODE, Mess, "PD_PROJECT_SERVERPK");
    }

    private void ShowDropList(DataTable table, SmartGridView objGridView, string DropListName)
    {
        string[] strArray = DropListName.Split(new char[] { ',' });
        foreach (GridViewRow row in objGridView.Rows)
        {
            TextBox box = (TextBox)row.FindControl("AUTO_NO");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (box.Text.Trim() == table.Rows[i]["AUTO_NO"].ToString().Trim())
                {
                    foreach (string str in strArray)
                    {
                        ((DropDownList)row.FindControl(str)).SelectedValue = table.Rows[i][str].ToString();
                    }
                    break;
                }
            }
        }
    }

    private void ShowHtbgglLogic(DataTable table, SmartGridView objGridView)
    {
        int num = 0;
        int num2 = 0;
        foreach (GridViewRow row in objGridView.Rows)
        {
            TextBox box = (TextBox)row.FindControl("AUTO_NO");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (box.Text.Trim() == table.Rows[i]["AUTO_NO"].ToString().Trim())
                {
                    PublicDal.BindDropDownList((DropDownList)row.FindControl("ddlPD_CONTRACT_CHANGE_ZJ"), "pd_base_adjusttype", "adjusttype_name", "adjusttype_code", "");
                    if (PageValidate.IsNumber(table.Rows[i][row.Cells[1].Controls[1].ID].ToString()))
                    {
                        int num4 = int.Parse(table.Rows[i][row.Cells[1].Controls[1].ID].ToString());
                        ((DropDownList)row.FindControl("PD_CONTRACT_PiCi")).Items[num4 - 1].Selected = true;
                        num = (num > num4) ? num : num4;
                        TextBox box2 = (TextBox)row.FindControl("PD_CONTRACT_STATE");
                        if ((PageValidate.IsNumber(box2.Text) && (int.Parse(box2.Text) > 0)) && ((num4 + 1) > num2))
                        {
                            num2 = num4 + 1;
                        }
                        break;
                    }
                }
            }
        }
        num = (num > num2) ? num : num2;
        foreach (GridViewRow row2 in objGridView.Rows)
        {
            DropDownList list = (DropDownList)row2.FindControl("PD_CONTRACT_PiCi");
            if (PageValidate.IsNumber(((TextBox)row2.FindControl("PD_CONTRACT_STATE")).Text))
            {
                if (int.Parse(((TextBox)row2.FindControl("PD_CONTRACT_STATE")).Text) == 1)
                {
                    row2.Enabled = false;
                }
                else
                {
                    foreach (ListItem item in list.Items)
                    {
                        if (int.Parse(item.Text) < num)
                        {
                            item.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                foreach (ListItem item2 in list.Items)
                {
                    if (int.Parse(item2.Text) < num)
                    {
                        item2.Enabled = false;
                    }
                }
            }
        }
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
        this.lblPD_PROJECT_REPLY_COMPANY.Text = modelName.PD_PROJECT_REPLY_COMPANY_Name;
        this.lblPD_PROJECT_FILENO_PF.Text = modelName.PD_PROJECT_FILENO_PF.ToString();
        this.PD_PROJECT_JGJL.Text = modelName.PD_PROJECT_JGJL;
        this.PD_PROJECT_JG_RESULT.Text = modelName.PD_PROJECT_JG_RESULT;
        this.PD_PROJECT_JG_SUGGEST.Text = modelName.PD_PROJECT_JG_SUGGEST;
        this.lblPD_PROJECT_ZJLY.Text = modelName.PD_PROJECT_ZJLY;
        this.lblPD_PROJECT_ZGKJ.Text = modelName.PD_PROJECT_ZGKJ;
        PD_PROJECT_ZTB_Model modelPROJECT = new PD_PROJECT_ZTB_Bll().GetModelPROJECT(PD_PROJECT_CODE);
        if (modelPROJECT != null)
        {
            this.ddlPD_PROJECT_ZTB_IF_SSFA.SelectedValue = modelPROJECT.PD_PROJECT_ZTB_IF_SSFA.ToString();
            this.ddlPD_PROJECT_ZTB_IF_ZTB.SelectedValue = modelPROJECT.PD_PROJECT_ZTB_IF_ZTB.ToString();
            this.ddlPD_PROJECT_ZTB_STYLE.SelectedValue = modelPROJECT.PD_PROJECT_ZTB_STYLE;
            this.ddlPD_PROJECT_ISCONTRACT.SelectedValue = modelPROJECT.PD_PROJECT_ISCONTRACT;
            this.txtPD_PROJECT_XXJD.Text = modelPROJECT.PD_PROJECT_XXJD;
            this.txtPD_PROJECT_FCXMGCL.Text = modelPROJECT.PD_PROJECT_FCXMGCL;
            this.txtPD_PROJECT_GCZLQK.Text = modelPROJECT.PD_PROJECT_GCZLQK;
        }
    }

    private void UpdataData(string PD_PROJECT_CODE)
    {
        List<PD_CONTRACT_CHANGE_Model> list = null;
        List<PD_PROJECT_ATTACH_SS_Model> list2 = null;
        List<PD_PROJECT_CONTRACT_Model> list3 = null;
        List<PD_PROJECT_INSPECTION_Model> list4 = null;
        List<PD_PROJECT_MONITOR_Model> list5 = null;
        PD_PROJECT_ZTB_Model model = new PD_PROJECT_ZTB_Model();
        string errText = "";
        if (!this.GetModel(PD_PROJECT_CODE, ref list, ref list2, ref list3, ref list4, ref list5, ref model, ref errText))
        {
            this.hy_File(list2, list3, list, list5, list4, errText);
        }
        else
        {
            PD_PROJECT_ATTACH_SS_Bll bll = new PD_PROJECT_ATTACH_SS_Bll();
            bll.Delete(PD_PROJECT_CODE);
            bll.AddList(list2);
            PD_PROJECT_ZTB_Bll bll2 = new PD_PROJECT_ZTB_Bll();
            bll2.DeletePROJECT(PD_PROJECT_CODE);
            bll2.Add(model);
            TB_PROJECT_Bll bll3 = new TB_PROJECT_Bll();
            TB_PROJECT_Model model2 = new TB_PROJECT_Model
            {
                PD_PROJECT_CODE = PD_PROJECT_CODE,
                PD_PROJECT_JGJL = this.PD_PROJECT_JGJL.Text,
                PD_PROJECT_JG_RESULT = this.PD_PROJECT_JG_RESULT.Text,
                PD_PROJECT_JG_SUGGEST = this.PD_PROJECT_JG_SUGGEST.Text
            };
            bll3.UpdateJGJL(model2);
            PageShowText.Refurbish("修改成功", this.Page);
        }
    }

    public bool UpLoadFile(string fileNameFullPath, string strUrlDirPath)
    {
        string str = fileNameFullPath.Substring(fileNameFullPath.LastIndexOf(@"\") + 1);
        string str2 = DateTime.Now.ToString("yyyyMMddhhmmss") + DateTime.Now.Millisecond.ToString() + fileNameFullPath.Substring(fileNameFullPath.LastIndexOf("."));
        str.Substring(str.LastIndexOf(".") + 1);
        if (!strUrlDirPath.EndsWith("/"))
        {
            strUrlDirPath = strUrlDirPath + "/";
        }
        if (Directory.Exists(base.Server.MapPath(strUrlDirPath)))
        {
            Directory.CreateDirectory(base.Server.MapPath(strUrlDirPath));
        }
        strUrlDirPath = strUrlDirPath + str2;
        WebClient client = new WebClient
        {
            Credentials = CredentialCache.DefaultCredentials
        };
        FileStream input = new FileStream(fileNameFullPath, FileMode.Open, FileAccess.Read);
        BinaryReader reader = new BinaryReader(input);
        try
        {
            byte[] buffer = reader.ReadBytes((int)input.Length);
            Stream stream2 = client.OpenWrite(strUrlDirPath, "PUT");
            if (stream2.CanWrite)
            {
                stream2.Write(buffer, 0, buffer.Length);
            }
            stream2.Close();
            return true;
        }
        catch (Exception)
        {
            return false;
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
