using ASP;
using ExtExtenders;
using SoMeTech.CommonDll;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.IO;
using System.Runtime.InteropServices;
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

public class Work_ZB_ZBOper : Page, IRequiresSessionState
{
    private TB_QUOTA_Bll bll = new TB_QUOTA_Bll();
    protected HtmlInputHidden branch;
    protected HtmlInputHidden buttonTxt;
    protected DropDownList ddlPD_IS_RETURN;
    protected DropDownList ddlPD_ISOUT_QUOTA;
    protected DropDownList ddlPD_PROJ_LAST_AUDIT_STATUS;
    protected DropDownList ddlPD_PROJ_STATUS;
    protected DropDownList ddlPD_QUOTA_DEPART;
    protected DropDownList ddlPD_QUOTA_IFUP;
    protected DropDownList ddlPD_QUOTA_YSLX;
    protected DropDownList ddlPD_QUOTA_ZJXZ;
    protected DropDownList ddlPD_YEAR;
    protected DropDownList ddlzgkj;
    protected DropDownList ddlzjly;
    protected HtmlGenericControl div_showZBK;
    protected UserControls_FilePostCtr FilePostCtr1;
    protected HtmlInputHidden hgl;
    protected HtmlInputHidden hjj;
    protected HtmlImage imgSearch;
    protected HtmlInputHidden IsQianShou;
    protected HtmlInputHidden json_btData;
    protected HtmlInputHidden json_xzxx;
    protected HtmlInputHidden json_xzxxData;
    protected TextBox lbl_MONEY;
    protected Label lblAUTO_ID;
    protected TextBox lblPD_QUOTA_PICI;
    protected HtmlInputHidden LoginCompany;
    public string LogUrl = "";
    protected TabPanel Panel_xzxx;
    protected HtmlInputHidden PD_QUOTA_PICI;
    protected HtmlInputHidden serverPK;
    protected HtmlInputHidden serverXFPK;
    public string strid = "";
    protected TabContainer TabContainer11;
    protected DataTable tbFile = new DataTable();
    private DataTable tbXiangZhen = new DataTable();
    protected HtmlTable tr_wjzl;
    protected TextBox txtPD_QUOTA_BASIS;
    protected TextBox txtPD_QUOTA_BASIS_JG;
    protected HtmlInputHidden txtPD_QUOTA_CODE;
    protected TextBox txtPD_QUOTA_COMPANY;
    protected TextBox txtPD_QUOTA_FWDATA;
    protected TextBox txtPD_QUOTA_GLLX;
    protected TextBox txtPD_QUOTA_JGYQ;
    protected TextBox txtPD_QUOTA_JJLX;
    protected DropDownList txtPD_QUOTA_LWJG;
    protected TextBox txtPD_QUOTA_LWJG_NAME;
    protected TextBox txtPD_QUOTA_MONEY_TOTAL;
    protected TextBox txtPD_QUOTA_NAME;
    protected TextBox txtPD_QUOTA_STANDARD;
    protected TextBox txtPD_QUOTA_TARGET;
    protected TextBox txtPD_QUOTA_ZBWH;
    protected TextBox txtPD_QUOTA_ZBXDZH;
    protected TextBox txtPD_QUOTA_ZBYT;
    protected TextBox txtPD_QUOTA_ZGBM;
    protected HtmlTableCell wj;

    private void Bind1(string PD_QUOTA_CODE, TB_QUOTA_Model model, bool IsCreate)
    {
        if (PD_QUOTA_CODE == "")
        {
            this.txtPD_QUOTA_ZGBM.Text = "乡镇人民政府";
        }
        SMZJ.BLL.TB_QUOTA_DETAIL tb_quota_detail = new SMZJ.BLL.TB_QUOTA_DETAIL();
        string strWhere = " PD_QUOTA_CODE='" + PD_QUOTA_CODE + "' and IF_SHOW=1 ";
        if (!IsCreate)
        {
            string str2 = ((UserModel)HttpContext.Current.Session["User"]).Company.pk_corp;
            if (str2.Trim() != model.PD_QUOTA_INPUT_COMPANY.Trim())
            {
                strWhere = strWhere + " and COMPANY_CODE like '" + str2 + "%'";
            }
        }
        else
        {
            strWhere = " 1=0 ";
        }
        DataSet list = tb_quota_detail.GetList(strWhere);
        this.json_xzxxData.Value = base.Server.UrlEncode(PublicDal.DataToJSON(list));
        if (list.Tables[0].Rows.Count > 0)
        {
            list.Tables[0].Rows.Clear();
        }
        DataRow row = list.Tables[0].NewRow();
        row["PD_QUOTA_CODE"] = PD_QUOTA_CODE;
        list.Tables[0].Rows.Add(row);
        this.json_xzxx.Value = base.Server.UrlEncode(PublicDal.DataToJSON(list));
        DataSet ds = new DataSet();
        ds.Tables.Add();
        ds.Tables[0].Columns.Add("AUTO_NO");
        ds.Tables[0].Columns.Add("FILE_NAME");
        ds.Tables[0].Columns.Add("FILE_SYSNAME");
        if ((model != null) && this.tr_wjzl.Visible)
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
        this.json_btData.Value = base.Server.UrlEncode(PublicDal.DataToJSON(ds));
    }

    private void BindData()
    {
        if (this.ddlzjly.SelectedValue == "01")
        {
            this.ddlzgkj.Enabled = true;
        }
        else
        {
            this.ddlzjly.Enabled = true;
        }
        this.branch.Value = ((UserModel)HttpContext.Current.Session["User"]).Branch.BH;
        this.LoginCompany.Value = ((UserModel)HttpContext.Current.Session["User"]).Company.pk_corp;
    }

    private void BindDDList()
    {
        this.ddlzgkj.Items.Clear();
        PublicDal.BindDropDownList(this.ddlzgkj, "PD_PROJECT_ZGKJ", "ZGKJ_NAME", "ZGKJ_CODE", "");
        this.ddlzgkj.Items.Insert(0, new ListItem(" ==选择科局== ", "-1"));
        this.ddlzgkj.SelectedValue = "-1";
        PublicDal.BindDropDownList(this.ddlPD_YEAR, "PD_BASE_YEAR", "YEAR_NAME", "YEAR_CODE", "");
        this.ddlPD_YEAR.SelectedValue = DateTime.Now.Year.ToString();
        PublicDal.BindDropDownList(this.ddlPD_QUOTA_ZJXZ, "PD_BASE_FOUND_PROPERTY", "FOUND_PROPERTY_NAME", "FOUND_PROPERTY_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_QUOTA_IFUP, "PD_BASE_SELECT", "SELECT_NAME", "SELECT_CODE", "");
        PublicDal.BindDropDownList(this.ddlPD_QUOTA_DEPART, "V_company_branch", "NAME", "BH", " comp_ishasbaby=1 and trim(pk_corp) = '" + ((UserModel)this.Session["User"]).Company.pk_corp.Trim() + "'");
        if (this.ddlPD_QUOTA_DEPART.Items.Count == 0)
        {
            this.ddlPD_QUOTA_DEPART.Items.Add(new ListItem(((UserModel)this.Session["User"]).Branch.Name, ((UserModel)this.Session["User"]).Branch.BH));
        }
        this.ddlPD_QUOTA_DEPART.SelectedValue = ((UserModel)this.Session["User"]).Branch.BH;
        if (!PublicDal.IsJGBM(((UserModel)this.Session["User"]).Branch.BH.Trim()))
        {
            this.ddlPD_QUOTA_DEPART.Enabled = false;
        }
        this.txtPD_QUOTA_MONEY_TOTAL.Attributes.Add("onKeyPress", "myKeyDown(this,event,0)");
        this.txtPD_QUOTA_ZBXDZH.Attributes.Add("onKeyPress", "myKeyDown(this,event,0)");
        PublicDal.BindDropDownList(this.ddlPD_QUOTA_YSLX, "PD_BASE_YSLX", "YSLX_NAME", "YSLX_CODE", "");
        this.LogUrl = "/Work/PublicAspx/ShowLog.aspx?code=" + base.Request["UpdatePK"] + "&type=2";
    }

    protected void bindTbFile()
    {
    }

    private void bindZBK()
    {
        new TB_QUOTA_Bll();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
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
                return;

            case "ibtcontrol_ibtaudit":
                {
                    TB_QUOTA_Bll bll = new TB_QUOTA_Bll();
                    if (!PublicDal.PageValidate.IsDecimal(bll.GetModel(base.Request.Params["UpdatePK"]).PD_QUOTA_ZBXDZH))
                    {
                        PageShowText.Refurbish("无分配方案,不允许下发!如输入了分配方案,请先保存!", this.Page);
                        return;
                    }
                    this.UpdateXiaFaOld(1, base.Request.Params["UpdatePK"], this.buttonTxt.Value);
                    return;
                }
            case "ibtcontrol_ibtapply":
                this.SetBZ_ServiceStream(1, base.Request.Params["UpdatePK"], this.buttonTxt.Value);
                return;

            case "ibtcontrol_ibtsetback":
                this.SetBZ_ServiceStream(0, base.Request.Params["UpdatePK"], "追回");
                return;

            case "ibtcontrol_ibtrollback":
                this.SetBZ_ServiceStream(0, base.Request.Params["UpdatePK"], "退回");
                return;

            case "ibtcontrol_ibtlook":
                PageShowText.OpenPage("/Work/PublicAspx/ShowLog.aspx?code=" + base.Request["UpdatePK"] + "&type=2", this.Page);
                return;

            case "ibtcontrol_ibtprintnote":
                PageShowText.Refurbish("", this.Page);
                PageShowText.OpenPage("ZPRINT.aspx?pk=" + base.Server.UrlEncode(base.Request.Params["UpdatePK"]), null, null, this.Page);
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
            TB_QUOTA_Model model = this.GetModel(null);
            model.PD_QUOTA_CODE = DateTime.Now.ToString("yyyyMMddhhmmssffffff");
            TB_QUOTA_Bll bll = new TB_QUOTA_Bll();
            if ((base.Request["CreatePK"] != null) && (base.Request["CreatePK"].Trim() != ""))
            {
                model.PD_QUOTA_PICI = bll.GetMaxPiCi(model.PD_QUOTA_ZBWH).ToString();
            }
            UserModel model2 = (UserModel)this.Session["User"];
            model.PD_QUOTA_SERVERPK = PublicDal.SetCreateServiceStream(this.Page);
            model.PD_QUOTA_INPUT_COMPANY = this.Session["pk_corp"].ToString();
            model.PD_QUOTA_INPUT_MAN = model2.UserName;
            model.PD_QUOTA_INPUT_DEPART = model2.Branch.BH;
            model.PD_QUOTA_INPUT_DATE = new DateTime?(DateTime.Now);
            string wh = ((UserModel)this.Session["user"]).Company.Name.Substring(0, 1) + ((UserModel)this.Session["user"]).Branch.Name.Substring(0, 1);
            this.GetQUOTA(model);
            bll.Add(model, wh);
            string str3 = model.PD_QUOTA_CODE;
            SMZJ.BLL.TB_QUOTA_DETAIL tb_quota_detail = new SMZJ.BLL.TB_QUOTA_DETAIL();
            List<SMZJ.Model.TB_QUOTA_DETAIL> qUOTAModel = this.GetQUOTAModel(model.PD_QUOTA_CODE);
            tb_quota_detail.DeleteProject(str3);
            tb_quota_detail.AddList(qUOTAModel);
            this.UpdateLog(str3, "新建指标", "执行 新建 成功", "", str3, "", "");
            Const.DoSuccessNoClose("添加成功", this.Page.Request.Url.LocalPath + "?UpdatePK=" + model.PD_QUOTA_CODE, this.Page);
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

    private TB_QUOTA_Model GetModel(TB_QUOTA_Model model)
    {
        if (model == null)
        {
            model = new TB_QUOTA_Model();
        }
        model.PD_QUOTA_ZJLY = this.ddlzjly.SelectedValue;
        model.PD_QUOTA_ZGKJ = this.ddlzgkj.SelectedValue;
        model.PD_QUOTA_JJLX = this.hjj.Value;
        model.PD_QUOTA_GLLX = this.hgl.Value;
        model.PD_QUOTA_ZBXDZH = this.txtPD_QUOTA_ZBXDZH.Text;
        model.AUTO_NO = "";
        model.PD_QUOTA_NAME = this.txtPD_QUOTA_NAME.Text;
        model.PD_YEAR = this.ddlPD_YEAR.SelectedValue;
        model.PD_QUOTA_LWJG = 0;
        if (this.txtPD_QUOTA_LWJG.SelectedValue.Trim() != "")
        {
            model.PD_QUOTA_LWJG = new int?(int.Parse(this.txtPD_QUOTA_LWJG.SelectedValue));
        }
        model.PD_QUOTA_IFUP = this.ddlPD_QUOTA_IFUP.SelectedValue;
        model.PD_QUOTA_ZJXZ = this.ddlPD_QUOTA_ZJXZ.SelectedValue;
        model.PD_QUOTA_TARGET = this.txtPD_QUOTA_TARGET.Text;
        model.PD_QUOTA_STANDARD = this.txtPD_QUOTA_STANDARD.Text;
        model.PD_QUOTA_BASIS = this.txtPD_QUOTA_BASIS.Text;
        model.PD_QUOTA_BASIS_JG = this.txtPD_QUOTA_BASIS_JG.Text;
        model.PD_QUOTA_MONEY_TOTAL = 0M;
        if (this.txtPD_QUOTA_MONEY_TOTAL.Text.Trim() != "")
        {
            model.PD_QUOTA_MONEY_TOTAL = decimal.Parse(this.txtPD_QUOTA_MONEY_TOTAL.Text);
        }
        model.PD_QUOTA_DEPART = this.ddlPD_QUOTA_DEPART.SelectedValue;
        model.PD_QUOTA_JGYQ = this.txtPD_QUOTA_JGYQ.Text;
        model.PD_PROJ_STATUS = this.ddlPD_PROJ_STATUS.SelectedValue;
        model.PD_PROJ_LAST_AUDIT_STATUS = this.ddlPD_PROJ_LAST_AUDIT_STATUS.SelectedValue;
        if (this.ddlPD_IS_RETURN.SelectedValue.Trim() != "")
        {
            model.PD_IS_RETURN = new int?(int.Parse(this.ddlPD_IS_RETURN.SelectedValue));
        }
        if (this.ddlPD_ISOUT_QUOTA.SelectedValue.Trim() != "")
        {
            model.PD_ISOUT_QUOTA = new int?(int.Parse(this.ddlPD_ISOUT_QUOTA.SelectedValue));
        }
        model.PD_QUOTA_ZBWH = this.txtPD_QUOTA_ZBWH.Text;
        if (this.txtPD_QUOTA_FWDATA.Text.Trim() != "")
        {
            model.PD_QUOTA_FWDATA = DateTime.Parse(this.txtPD_QUOTA_FWDATA.Text);
        }
        model.PD_QUOTA_COMPANY = this.txtPD_QUOTA_COMPANY.Text;
        model.PD_QUOTA_ZBYT = this.txtPD_QUOTA_ZBYT.Text;
        model.PD_QUOTA_ZGBM = this.txtPD_QUOTA_ZGBM.Text;
        model.PD_QUOTA_PICI = this.PD_QUOTA_PICI.Value;
        model.PD_QUOTA_YSLX = this.ddlPD_QUOTA_YSLX.SelectedValue;
        return model;
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
            string[] strArray3 = base.Request.Form["table_xzxx_AUTO_NO"].Split(new char[] { ',' });
            string[] strArray4 = base.Request.Form["table_xzxx_PD_UP_MONEY"].Split(new char[] { ',' });
            string[] strArray5 = base.Request.Form["table_xzxx_PD_QUOTA_SERVERPK"].Split(new char[] { ',' });
            string[] strArray6 = base.Request.Form["table_xzxx_ISRECEIVE"].Split(new char[] { ',' });
            string[] strArray7 = base.Request.Form["table_xzxx_IF_SHOW"].Split(new char[] { ',' });
            string[] strArray8 = base.Request.Form["table_xzxx_ISHUIZHI"].Split(new char[] { ',' });
            string[] strArray9 = base.Request.Form["table_xzxx_RECEIVE_MAN"].Split(new char[] { ',' });
            string[] strArray10 = base.Request.Form["table_xzxx_HUIZHI_MAN"].Split(new char[] { ',' });
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
                SMZJ.Model.TB_QUOTA_DETAIL item = new SMZJ.Model.TB_QUOTA_DETAIL();
                if (PublicDal.PageValidate.IsNumber(strArray3[i]))
                {
                    item.AUTO_NO = int.Parse(strArray3[i]);
                }
                else
                {
                    item.AUTO_NO = 0M;
                }
                item.PD_QUOTA_CODE = PD_QUOTA_CODE;
                item.COMPANY_CODE = strArray2[i];
                item.PD_UP_MONEY = strArray4[i];
                item.PD_QUOTA_SERVERPK = strArray5[i];
                item.ISRECEIVE = strArray6[i];
                if (base.Request["UpdatePK"] == null)
                {
                    strArray7[i] = "1";
                }
                item.IF_SHOW = strArray7[i];
                item.ISHUIZHI = strArray8[i];
                item.RECEIVE_MAN = strArray9[i];
                item.HUIZHI_MAN = strArray10[i];
                if (defaultView != null)
                {
                    if ((this.ddlPD_QUOTA_IFUP.SelectedValue.Trim() != null) && (this.ddlPD_QUOTA_IFUP.SelectedValue.Trim() == "1"))
                    {
                        defaultView.RowFilter = " tableID='zxzb_bt' ";
                        if (defaultView.Count > 0)
                        {
                            item.FILE_NAME = defaultView[0]["FileName"].ToString();
                            item.FILE_SYSNAME = defaultView[0]["FileSysName"].ToString();
                        }
                    }
                    else
                    {
                        defaultView.RowFilter = " tableID='table_xzxx' and rowIndex=" + (i + 1);
                        if (defaultView.Count > 0)
                        {
                            item.FILE_NAME = defaultView[0]["FileName"].ToString();
                            item.FILE_SYSNAME = defaultView[0]["FileSysName"].ToString();
                        }
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
        ds.Tables[0].Columns.Add("PD_QUOTA_SERVERPK");
        ds.Tables[0].Columns.Add("ISRECEIVE");
        ds.Tables[0].Columns.Add("RECEIVE_MANNAME");
        ds.Tables[0].Columns.Add("ISHUIZHI");
        ds.Tables[0].Columns.Add("HUIZHI_MANNAME");
        int num = 0;
        foreach (SMZJ.Model.TB_QUOTA_DETAIL tb_quota_detail in de_Model)
        {
            DataRow row = ds.Tables[0].NewRow();
            row["AUTO_NO"] = num++;
            row["PD_QUOTA_CODE"] = tb_quota_detail.PD_QUOTA_CODE;
            row["COMPANY_CODE"] = tb_quota_detail.COMPANY_CODE;
            row["FILE_NAME"] = tb_quota_detail.FILE_NAME;
            row["FILE_SYSNAME"] = tb_quota_detail.FILE_SYSNAME;
            row["PD_QUOTA_SERVERPK"] = tb_quota_detail.PD_QUOTA_SERVERPK;
            row["ISRECEIVE"] = tb_quota_detail.ISRECEIVE;
            row["RECEIVE_MANNAME"] = tb_quota_detail.RECEIVE_MAN;
            row["ISHUIZHI"] = tb_quota_detail.ISHUIZHI;
            row["HUIZHI_MANNAME"] = tb_quota_detail.HUIZHI_MAN;
            ds.Tables[0].Rows.Add(row);
        }
        this.json_xzxx.Value = base.Server.UrlEncode(PublicDal.DataToJSON(ds));
        TB_QUOTA_Model model = this.GetModel(null);
        this.GetQUOTA(model);
        DataSet set2 = new DataSet();
        set2.Tables.Add();
        set2.Tables[0].Columns.Add("AUTO_NO");
        set2.Tables[0].Columns.Add("FILE_NAME");
        set2.Tables[0].Columns.Add("FILE_SYSNAME");
        if ((model.PD_QUOTA_FILE != null) && (model.PD_QUOTA_FILE.Trim() != ""))
        {
            string[] strArray = model.PD_QUOTA_FILE.Split(new char[] { '|' });
            DataRow row2 = set2.Tables[0].NewRow();
            row2["AUTO_NO"] = model.AUTO_NO;
            row2["FILE_NAME"] = strArray[1];
            row2["FILE_SYSNAME"] = strArray[0];
        }
        this.json_btData.Value = base.Server.UrlEncode(PublicDal.DataToJSON(ds));
        string str = "RunBindJS();";
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
            if (!base.IsPostBack)
            {
                this.Master.TabContainer1 = this.TabContainer11;
                ButtonsModel model = null;
                this.IsQianShou.Value = this.ShowBZ_MxButton(out model).ToString();
                this.Master.btModel = model;
                if ((base.Request["UpdatePK"] != null) && (base.Request["UpdatePK"].Trim() != ""))
                {
                    model.IfLook = true;
                    model.IbtLookText = "查看日志";
                    model.IfPrintNote = true;
                    model.IbtPrintNoteText = "打印";
                    this.BindDDList();
                    this.ShowInfo(base.Request["UpdatePK"].Trim());
                    this.BindData();
                    this.div_showZBK.Visible = false;
                    if (this.txtPD_QUOTA_MONEY_TOTAL.Text == "*****")
                    {
                        model.IfSave = false;
                    }
                }
                else if ((base.Request["CreatePK"] != null) && (base.Request["CreatePK"].Trim() != ""))
                {
                    this.BindDDList();
                    this.ShowInfo(base.Request["CreatePK"].Trim());
                    this.BindData();
                    this.bindZBK();
                }
                else
                {
                    this.BindDDList();
                    this.Bind1("", null, true);
                    this.BindData();
                }
                if (base.Request["look"] == "looklist")
                {
                    this.txtPD_QUOTA_FWDATA.Enabled = false;
                }
                else
                {
                    this.txtPD_QUOTA_FWDATA.Enabled = true;
                }
            }
            this.setRead(this.ddlPD_QUOTA_DEPART.SelectedValue);
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
    }

    private bool PanDuan(ref string strErr)
    {
        if (this.txtPD_QUOTA_NAME.Text.Trim().Length == 0)
        {
            strErr = strErr + @"文件名称不能为空\n";
        }
        if (this.ddlPD_YEAR.SelectedValue.Trim().Length == 0)
        {
            strErr = strErr + @"文件年度不能为空！\n";
        }
        if (this.txtPD_QUOTA_FWDATA.Text.Trim().Length == 0)
        {
            strErr = strErr + @"发文日期不能为空！\n";
        }
        if (this.ddlPD_QUOTA_ZJXZ.SelectedValue.Trim().Length == 0)
        {
            strErr = strErr + @"资金性质不能为空！\n";
        }
        if (this.txtPD_QUOTA_COMPANY.Text.Trim().Length == 0)
        {
            strErr = strErr + @"资金使用不能为空！\n";
        }
        if (this.txtPD_QUOTA_MONEY_TOTAL.Text.Trim().Length == 0)
        {
            strErr = strErr + @"指标额度不能为空！\n";
        }
        if (this.txtPD_QUOTA_ZBYT.Text.Trim().Length == 0)
        {
            strErr = strErr + @"财政资金用途不能为空！\n";
        }
        if (this.txtPD_QUOTA_GLLX.Text.Trim().Length == 0)
        {
            strErr = strErr + @"功能分类科目不能为空！\n";
        }
        if (this.txtPD_QUOTA_JJLX.Text.Trim().Length == 0)
        {
            strErr = strErr + @"经济分类科目不能为空！\n";
        }
        if (this.txtPD_QUOTA_JGYQ.Text.Trim().Length == 0)
        {
            strErr = strErr + @"监管要求不能为空！\n";
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

    public void SetBZ_ServiceStream(int operation, string PD_PROJECT_CODE, string Mess)
    {
        int num = 0;
        UserModel model = (UserModel)HttpContext.Current.Session["User"];
        model.Branch.BH.Trim();
        string str = model.Company.pk_corp;
        try
        {
            TB_QUOTA_Bll bll = new TB_QUOTA_Bll();
            TB_QUOTA_Model isUpModel = bll.GetIsUpModel(PD_PROJECT_CODE);
            SMZJ.BLL.TB_QUOTA_DETAIL tb_quota_detail = new SMZJ.BLL.TB_QUOTA_DETAIL();
            if (operation == 0)
            {
                if (isUpModel.PD_QUOTA_ISUP == "1")
                {
                    if (!tb_quota_detail.GetShiDFouJS_Model(PD_PROJECT_CODE, 1))
                    {
                        PageShowText.Refurbish("已有乡镇已签收，无法进行此操作！", this.Page);
                        num = 0;
                        return;
                    }
                    num = bll.UpdateIsXiaFa(PD_PROJECT_CODE, "0", "0", "0");
                    tb_quota_detail.UpdateSonServerPK(PD_PROJECT_CODE, "", "0", "0", "", "");
                }
                this.SetServiceStream(operation, PD_PROJECT_CODE, Mess);
                num = 1;
            }
            else if (isUpModel.PD_QUOTA_ISUP == "1")
            {
                SMZJ.Model.TB_QUOTA_DETAIL tb_quota_detail2 = tb_quota_detail.GetSonServerPK_Model(str, PD_PROJECT_CODE);
                string newServerPK = "";
                if (tb_quota_detail2 != null)
                {
                    PublicDal.GetUpDownStream(this.Page, tb_quota_detail2.PD_QUOTA_SERVERPK, 2, out newServerPK);
                    string iSRECEIVE = "";
                    string iSHUIZHI = "";
                    string rECEIVEMAN = "";
                    string hUIZHIMAN = "";
                    iSRECEIVE = "1";
                    iSHUIZHI = "1";
                    rECEIVEMAN = tb_quota_detail2.RECEIVE_MAN;
                    hUIZHIMAN = model.UserName;
                    if ((isUpModel.PD_QUOTA_IFXZHZ != null) && (isUpModel.PD_QUOTA_IFXZHZ.Trim() != "1"))
                    {
                        bll.UpdateIsXiaFa(PD_PROJECT_CODE, "1", "1", "1");
                    }
                    if (tb_quota_detail.UpdateSonServerPK(PD_PROJECT_CODE, str, newServerPK, iSRECEIVE, iSHUIZHI, rECEIVEMAN, hUIZHIMAN))
                    {
                        num = 1;
                        newServerPK = "";
                        PublicDal.GetUpDownStream(this.Page, isUpModel.PD_QUOTA_SERVERPK, 1, out newServerPK);
                        if (tb_quota_detail.IsHuiZhi(PD_PROJECT_CODE) && (newServerPK != isUpModel.PD_QUOTA_SERVERPK))
                        {
                            this.SetServiceStream(1, PD_PROJECT_CODE, null);
                            this.SetServiceStream(1, PD_PROJECT_CODE, null);
                        }
                        PageShowText.Refurbish(Mess + "成功", this.Page);
                    }
                    else
                    {
                        num = 0;
                        PageShowText.Refurbish(Mess + "失败", this.Page);
                    }
                }
                else
                {
                    PageShowText.Refurbish(Mess + "签收失败，没有您需要签收的附件！", this.Page);
                }
            }
            else
            {
                this.SetServiceStream(operation, PD_PROJECT_CODE, Mess);
                num = 1;
            }
        }
        finally
        {
            if (num == 1)
            {
                this.UpdateLog(PD_PROJECT_CODE, Mess, "执行 " + Mess + " 成功", "", PD_PROJECT_CODE, "", "");
            }
            else
            {
                this.UpdateLog(PD_PROJECT_CODE, Mess, "执行 " + Mess + " 失败", "", PD_PROJECT_CODE, "", "");
            }
        }
    }

    private void SetInputEnabled(ButtonsModel model)
    {
        if (!model.IfSave)
        {
            PageShowText.Run_javascript("", this.Page);
        }
    }

    private void setRead(string depart)
    {
        if (PublicDal.IsJGBM(((UserModel)this.Session["user"]).Branch.BH) && PublicDal.IsYwgs(depart))
        {
            this.txtPD_QUOTA_MONEY_TOTAL.Enabled = false;
            this.txtPD_QUOTA_ZBXDZH.Enabled = false;
        }
    }

    public string SetServiceStream(int operation, string PD_PROJECT_CODE, string Mess)
    {
        return PublicDal.SetServiceStream(this.Page, operation, "TB_QUOTA", "PD_QUOTA_CODE", PD_PROJECT_CODE, Mess, "PD_QUOTA_SERVERPK");
    }

    private bool ShowBZ_MxButton(out ButtonsModel model)
    {
        string str = base.Request["UpdatePK"];
        string str2 = ((UserModel)HttpContext.Current.Session["User"]).Company.pk_corp;
        ((UserModel)HttpContext.Current.Session["User"]).Branch.BH.Trim();
        bool isQianShou = false;
        model = new ButtonsModel();
        if (str != null)
        {
            TB_QUOTA_Model isUpModel = new TB_QUOTA_Bll().GetIsUpModel(str);
            if (isUpModel.PD_QUOTA_ISUP == "1")
            {
                SMZJ.BLL.TB_QUOTA_DETAIL tb_quota_detail = new SMZJ.BLL.TB_QUOTA_DETAIL();
                SMZJ.Model.TB_QUOTA_DETAIL tb_quota_detail2 = tb_quota_detail.GetSonServerPK_Model(str2, str);
                if (tb_quota_detail2 != null)
                {
                    this.buttonTxt.Value = PublicDal.ShowBZ_MxButton_IsUP(this.Page, out model, tb_quota_detail2.PD_QUOTA_SERVERPK, isQianShou);
                    model.IfSave = false;
                    model.IfSetBack = false;
                    model.IfRollBack = false;
                    return isQianShou;
                }
                isQianShou = !tb_quota_detail.GetShiDFouJS_Model(str, 1);
                this.buttonTxt.Value = PublicDal.ShowBZ_MxButton_IsUP(this.Page, out model, isUpModel.PD_QUOTA_SERVERPK, isQianShou);
                if (!PublicDal.IsJGBM(((UserModel)this.Session["User"]).Branch.BH.Trim()))
                {
                    model.IfSave = false;
                }
                if (model.IfSave)
                {
                }
                return isQianShou;
            }
            this.buttonTxt.Value = PublicDal.ShowMxButton(this.Page, out model, "TB_QUOTA", "PD_QUOTA_CODE", str, "PD_QUOTA_SERVERPK");
            return isQianShou;
        }
        this.buttonTxt.Value = PublicDal.ShowMxButton(this.Page, out model, "TB_QUOTA", "PD_QUOTA_CODE", null, "PD_QUOTA_SERVERPK");
        return isQianShou;
    }

    private void ShowInfo(string PD_QUOTA_CODE)
    {
        if (!string.IsNullOrEmpty(PD_QUOTA_CODE))
        {
            this.imgSearch.Attributes.Remove("onclick");
            this.txtPD_QUOTA_ZBWH.Attributes.Remove("QiPao");
            TB_QUOTA_Bll bll = new TB_QUOTA_Bll();
            TB_QUOTA_Model modelByCODE = bll.GetModelByCODE(PD_QUOTA_CODE);
            if (modelByCODE != null)
            {
                this.lblAUTO_ID.Text = modelByCODE.AUTO_NO.ToString();
                this.txtPD_QUOTA_NAME.Text = modelByCODE.PD_QUOTA_NAME;
                this.ddlPD_YEAR.SelectedValue = modelByCODE.PD_YEAR;
                this.txtPD_QUOTA_LWJG.SelectedValue = modelByCODE.PD_QUOTA_LWJG.ToString();
                this.txtPD_QUOTA_LWJG_NAME.Text = modelByCODE.PD_QUOTA_LWJG_NAME.ToString();
                this.ddlPD_QUOTA_IFUP.SelectedValue = modelByCODE.PD_QUOTA_IFUP;
                this.ddlPD_QUOTA_ZJXZ.SelectedValue = modelByCODE.PD_QUOTA_ZJXZ;
                this.txtPD_QUOTA_TARGET.Text = modelByCODE.PD_QUOTA_TARGET;
                this.txtPD_QUOTA_STANDARD.Text = modelByCODE.PD_QUOTA_STANDARD;
                this.txtPD_QUOTA_BASIS.Text = modelByCODE.PD_QUOTA_BASIS;
                this.txtPD_QUOTA_BASIS_JG.Text = modelByCODE.PD_QUOTA_BASIS_JG;
                if ((modelByCODE.PD_QUOTA_DEPART != null) && (modelByCODE.PD_QUOTA_DEPART.Trim().Length != 0))
                {
                    bool flag = true;
                    foreach (ListItem item in this.ddlPD_QUOTA_DEPART.Items)
                    {
                        if (item.Value == modelByCODE.PD_QUOTA_DEPART)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        object branchName = PublicDal.GetBranchName(modelByCODE.PD_QUOTA_DEPART);
                        if (branchName != null)
                        {
                            this.ddlPD_QUOTA_DEPART.Items.Add(new ListItem(branchName.ToString(), modelByCODE.PD_QUOTA_DEPART));
                        }
                        else
                        {
                            this.ddlPD_QUOTA_DEPART.Items.Add(new ListItem("", modelByCODE.PD_QUOTA_DEPART));
                        }
                    }
                }
                this.ddlPD_QUOTA_DEPART.SelectedValue = modelByCODE.PD_QUOTA_DEPART;
                this.txtPD_QUOTA_JGYQ.Text = modelByCODE.PD_QUOTA_JGYQ;
                this.ddlPD_PROJ_STATUS.SelectedValue = modelByCODE.PD_PROJ_STATUS;
                this.ddlPD_PROJ_LAST_AUDIT_STATUS.SelectedValue = modelByCODE.PD_PROJ_LAST_AUDIT_STATUS;
                this.ddlPD_IS_RETURN.SelectedValue = modelByCODE.PD_IS_RETURN.ToString();
                this.ddlPD_ISOUT_QUOTA.SelectedValue = modelByCODE.PD_ISOUT_QUOTA.ToString();
                this.txtPD_QUOTA_ZBWH.Text = modelByCODE.PD_QUOTA_ZBWH.ToString();
                if (modelByCODE.PD_QUOTA_FWDATA.Year != 1)
                {
                    this.txtPD_QUOTA_FWDATA.Text = modelByCODE.PD_QUOTA_FWDATA.ToString();
                }
                this.txtPD_QUOTA_COMPANY.Text = modelByCODE.PD_QUOTA_COMPANY;
                this.txtPD_QUOTA_ZBYT.Text = modelByCODE.PD_QUOTA_ZBYT;
                this.hjj.Value = modelByCODE.PD_QUOTA_JJLX;
                this.hgl.Value = modelByCODE.PD_QUOTA_GLLX;
                this.txtPD_QUOTA_GLLX.Text = modelByCODE.PD_QUOTA_GLLX;
                this.txtPD_QUOTA_JJLX.Text = modelByCODE.PD_QUOTA_JJLX;
                this.ddlzjly.SelectedValue = modelByCODE.PD_QUOTA_ZJLY;
                this.ddlzgkj.SelectedValue = modelByCODE.PD_QUOTA_ZGKJ;
                this.txtPD_QUOTA_ZGBM.Text = modelByCODE.PD_QUOTA_ZGBM;
                if ((((UserModel)this.Session["User"]).Company.pk_corp.Trim() == modelByCODE.PD_QUOTA_INPUT_COMPANY.Trim()) || PublicDal.IsJGBM(((UserModel)this.Session["User"]).Branch.BH.Trim()))
                {
                    this.txtPD_QUOTA_ZBXDZH.Text = modelByCODE.PD_QUOTA_ZBXDZH;
                    this.txtPD_QUOTA_MONEY_TOTAL.Text = modelByCODE.PD_QUOTA_MONEY_TOTAL.ToString();
                    this.tr_wjzl.Visible = true;
                }
                else
                {
                    this.lbl_MONEY.Text = "*****";
                    this.txtPD_QUOTA_ZBXDZH.Text = "*****";
                    this.txtPD_QUOTA_MONEY_TOTAL.Text = "*****";
                    object obj3 = bll.tFileIsShow(PublicDal.getURL(this.Page), this.tr_wjzl.ID);
                    if ((obj3 != null) && (int.Parse(obj3.ToString()) == 1))
                    {
                        this.tr_wjzl.Visible = true;
                    }
                    else
                    {
                        this.tr_wjzl.Visible = false;
                    }
                }
                this.txtPD_QUOTA_ZGBM.Text = modelByCODE.PD_QUOTA_ZGBM;
                if ((base.Request["CreatePK"] != null) && (base.Request["CreatePK"].Trim() != ""))
                {
                    this.Bind1(PD_QUOTA_CODE, modelByCODE, true);
                    this.txtPD_QUOTA_ZBXDZH.Text = "0.00";
                    this.txtPD_QUOTA_ZBWH.Enabled = false;
                    this.txtPD_QUOTA_NAME.Enabled = false;
                    this.txtPD_QUOTA_MONEY_TOTAL.Enabled = false;
                    this.lblPD_QUOTA_PICI.Text = "第 " + (int.Parse(modelByCODE.PD_QUOTA_PICI) + 1) + "  批";
                    this.lbl_MONEY.Text = modelByCODE.PD_JY_MONEY;
                    this.PD_QUOTA_PICI.Value = (int.Parse(modelByCODE.PD_QUOTA_PICI) + 1).ToString();
                }
                else
                {
                    this.txtPD_QUOTA_CODE.Value = modelByCODE.PD_QUOTA_CODE;
                    this.Bind1(PD_QUOTA_CODE, modelByCODE, false);
                    if (PublicDal.PageValidate.IsInt(modelByCODE.PD_QUOTA_PICI) && (int.Parse(modelByCODE.PD_QUOTA_PICI) > 1))
                    {
                        this.txtPD_QUOTA_ZBWH.Enabled = false;
                        this.txtPD_QUOTA_NAME.Enabled = false;
                        this.txtPD_QUOTA_MONEY_TOTAL.Enabled = false;
                    }
                    this.lblPD_QUOTA_PICI.Text = "第 " + modelByCODE.PD_QUOTA_PICI.Trim() + "  批";
                    if (!PublicDal.PageValidate.IsDecimal(modelByCODE.PD_JY_MONEY))
                    {
                        modelByCODE.PD_JY_MONEY = "0.00";
                    }
                    if (!PublicDal.PageValidate.IsDecimal(modelByCODE.PD_QUOTA_ZBXDZH))
                    {
                        modelByCODE.PD_QUOTA_ZBXDZH = "0.00";
                    }
                    if (this.lbl_MONEY.Text != "*****")
                    {
                        this.lbl_MONEY.Text = (decimal.Parse(modelByCODE.PD_JY_MONEY) + decimal.Parse(modelByCODE.PD_QUOTA_ZBXDZH)).ToString();
                    }
                    this.PD_QUOTA_PICI.Value = modelByCODE.PD_QUOTA_PICI;
                }
                this.ddlPD_YEAR.SelectedValue = modelByCODE.PD_YEAR.Trim();
                this.ddlPD_QUOTA_ZJXZ.SelectedValue = modelByCODE.PD_QUOTA_ZJXZ.Trim();
                this.ddlPD_QUOTA_IFUP.SelectedValue = modelByCODE.PD_QUOTA_IFUP.Trim();
                this.ddlPD_QUOTA_YSLX.SelectedValue = modelByCODE.PD_QUOTA_YSLX;
                this.serverPK.Value = modelByCODE.PD_QUOTA_SERVERPK;
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
            TB_QUOTA_Bll bll = new TB_QUOTA_Bll();
            TB_QUOTA_Model model = new TB_QUOTA_Model();
            model = bll.GetModel(PD_QUOTA_CODE);
            model = this.GetModel(model);
            model.PD_QUOTA_CODE = PD_QUOTA_CODE;
            this.GetQUOTA(model);
            bll.Update(model);
            SMZJ.BLL.TB_QUOTA_DETAIL tb_quota_detail = new SMZJ.BLL.TB_QUOTA_DETAIL();
            List<SMZJ.Model.TB_QUOTA_DETAIL> qUOTAModel = this.GetQUOTAModel(PD_QUOTA_CODE);
            tb_quota_detail.DeleteProject(PD_QUOTA_CODE);
            tb_quota_detail.AddList(qUOTAModel);
            this.UpdateLog(PD_QUOTA_CODE, "修改指标", "执行 修改 成功", "", PD_QUOTA_CODE, "", "");
            PageShowText.Refurbish("修改成功", this.Page);
        }
    }

    private void UpdateLog(string PD_PROJECT_CODE, string EXE_CZ, string EXE_JG, string EXE_TXT, string FREE1, string FREE2, string FREE3)
    {
        PublicDal.UpdateLog("2", PD_PROJECT_CODE, EXE_CZ, EXE_JG, EXE_TXT, FREE1, FREE2, FREE3, this.Page);
    }

    private void UpdateXiaFaOld(int operation, string PD_QUOTA_CODE, string Mess)
    {
        TB_QUOTA_Bll bll = new TB_QUOTA_Bll();
        if (bll.UpdateIsXiaFa(PD_QUOTA_CODE, "1", "0", "0") > 0)
        {
            string str = this.SetServiceStream(operation, PD_QUOTA_CODE, Mess);
            SMZJ.BLL.TB_QUOTA_DETAIL tb_quota_detail = new SMZJ.BLL.TB_QUOTA_DETAIL();
            if (tb_quota_detail.UpdateSonServerPK(PD_QUOTA_CODE, str, "0", "0", "", ""))
            {
                this.UpdateLog(PD_QUOTA_CODE, Mess, "执行 " + Mess + " 成功", "", PD_QUOTA_CODE, "", "");
            }
            else
            {
                this.UpdateLog(PD_QUOTA_CODE, Mess, "执行 " + Mess + " 失败", "", PD_QUOTA_CODE, "", "");
            }
        }
        else
        {
            PageShowText.Refurbish(Mess + "失败", this.Page);
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

    protected void ddlzgkj_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtPD_QUOTA_ZGBM.Text = ddlzgkj.SelectedItem.ToString();
    }
}
