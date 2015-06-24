using ASP;
using SoMeTech.CommonDll;
using SoMeTech.YZXWPageClass;
using System;
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

public class Work_projectGL_HeTongBG_HeTongBGMx : Page, IRequiresSessionState
{
    protected DropDownList ddlPD_YEAR;
    protected UserControls_FilePostCtr FilePostCtr1;
    protected HtmlInputHidden json_btData;
    protected Label lblAUTO_NO;
    protected HtmlInputText txtPD_CONTRACT_CHANGE_DATE;
    protected HtmlInputText txtPD_CONTRACT_CHANGE_MONEY;
    protected TextBox txtPD_CONTRACT_CHANGE_REASON;
    protected DropDownList txtPD_CONTRACT_CHANGE_TYPE;
    protected HtmlInputText txtPD_CONTRACT_CHANGE_WH;
    protected HtmlInputText txtPD_CONTRACT_CHANGE_ZJ;
    protected HtmlInputText txtPD_CONTRACT_MONEY;
    protected HtmlInputHidden txtPD_CONTRACT_NO;
    protected HtmlInputText txtPD_CONTRACT_NO_Name;
    protected DropDownList txtPD_CONTRACT_TYPE;
    protected HtmlInputText txtPD_PROJECT_CODE;
    protected HtmlInputText txtPD_PROJECT_Name;
    protected HtmlTable zxzb_bt;

    private void BindDll()
    {
        PublicDal.BindDropDownList(this.ddlPD_YEAR, "PD_BASE_YEAR", "YEAR_NAME", "YEAR_CODE", "");
        this.ddlPD_YEAR.SelectedValue = DateTime.Now.Year.ToString();
    }

    public void Buttons(string ibtid)
    {
        switch (ibtid)
        {
            case "ibtcontrol_ibtsave":
                this.Save();
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
                this.SetServiceStream(0, base.Request.Params["UpdatePK"], "退回");
                return;
        }
    }

    private void getModel(PD_CONTRACT_CHANGE_Model model)
    {
        model.PD_PROJECT_CODE = this.txtPD_PROJECT_CODE.Value;
        model.PD_CONTRACT_CHANGE_TYPE = this.txtPD_CONTRACT_CHANGE_TYPE.SelectedValue;
        model.PD_CONTRACT_CHANGE_REASON = this.txtPD_CONTRACT_CHANGE_REASON.Text;
        model.PD_CONTRACT_TYPE = this.txtPD_CONTRACT_TYPE.SelectedValue;
        model.PD_CONTRACT_NO = this.txtPD_CONTRACT_NO.Value;
        model.PD_CONTRACT_CHANGE_ZJ = this.txtPD_CONTRACT_CHANGE_ZJ.Value;
        model.PD_CONTRACT_CHANGE_WH = this.txtPD_CONTRACT_CHANGE_WH.Value;
        model.PD_YEAR = this.ddlPD_YEAR.SelectedValue;
        if (PublicDal.PageValidate.IsDateTime(this.txtPD_CONTRACT_CHANGE_DATE.Value))
        {
            model.PD_CONTRACT_CHANGE_DATE = new DateTime?(DateTime.Parse(this.txtPD_CONTRACT_CHANGE_DATE.Value));
        }
        else
        {
            model.PD_CONTRACT_CHANGE_DATE = new DateTime();
        }
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_CONTRACT_MONEY.Value))
        {
            model.PD_CONTRACT_MONEY = new decimal?(decimal.Parse(this.txtPD_CONTRACT_MONEY.Value));
        }
        if (PublicDal.PageValidate.IsDecimal(this.txtPD_CONTRACT_CHANGE_MONEY.Value))
        {
            model.PD_CONTRACT_CHANGE_MONEY = new decimal?(decimal.Parse(this.txtPD_CONTRACT_CHANGE_MONEY.Value));
        }
        this.GetQUOTA(model);
    }

    private void GetQUOTA(PD_CONTRACT_CHANGE_Model model)
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
                model.PD_CONTRACT_CHANGE_FILENAME_SQ = defaultView[0]["FileName"].ToString();
                model.PD_CONTRACT_FILENAME_SYSTEM_SQ = defaultView[0]["FileSysName"].ToString();
            }
        }
    }

    public void ListPageLoad(Page page, out ButtonsModel main_bm, string PD_PROJECT_CODE)
    {
        PublicDal.ShowMxButton(this.Page, out main_bm, "PD_CONTRACT_CHANGE", "AUTO_NO", PD_PROJECT_CODE, "PD_NOW_SERVERPK");
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
        model.IfSave = true;
        this.Master.btModel = model;
        if (!base.IsPostBack)
        {
            this.BindDll();
            if ((base.Request["UpdatePK"] != null) && PublicDal.PageValidate.IsDecimal(base.Request["UpdatePK"]))
            {
                string str = base.Request["bgType"].ToString();
                if (str == "bgList")
                {
                    this.ShowInfo(int.Parse(base.Request["UpdatePK"]));
                }
                else
                {
                    bool flag1 = str == "HeTongMX";
                }
            }
        }
    }

    private void PanDuan()
    {
    }

    private void Save()
    {
        PD_CONTRACT_CHANGE_Bll bll = new PD_CONTRACT_CHANGE_Bll();
        if (base.Request["UpdatePK"] != null)
        {
            if (PublicDal.PageValidate.IsDecimal(base.Request["UpdatePK"]))
            {
                PD_CONTRACT_CHANGE_Model model = bll.GetModel(int.Parse(base.Request["UpdatePK"].ToString()));
                this.getModel(model);
                bll.Update(model);
                PageShowText.Refurbish("修改成功", this.Page);
            }
        }
        else if (this.txtPD_PROJECT_CODE.Value != null)
        {
            PD_CONTRACT_CHANGE_Model model2 = new PD_CONTRACT_CHANGE_Model
            {
                PD_DB_LOOP = "1",
                PD_NOW_SERVERPK = PublicDal.SetCreateServiceStream(this.Page)
            };
            this.getModel(model2);
            bll.Add(model2);
            Const.DoSuccessNoClose("添加成功", this.Page.Request.Url.LocalPath + "?UpdatePK=" + model2.AUTO_NO, this.Page);
        }
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
    }

    public void SetServiceStream(int operation, string AUTO_NO, string Mess)
    {
        PublicDal.SetServiceStream(this.Page, operation, "PD_CONTRACT_CHANGE", "AUTO_NO", AUTO_NO, Mess, "PD_NOW_SERVERPK");
    }

    private void ShowInfo(int AUTO_NO)
    {
        PD_CONTRACT_CHANGE_Model model = new PD_CONTRACT_CHANGE_Bll().GetModel(AUTO_NO);
        TB_PROJECT_Model model2 = new TB_PROJECT_Bll().GetModel(model.PD_PROJECT_CODE);
        this.txtPD_PROJECT_Name.Value = model2.PD_PROJECT_NAME;
        this.lblAUTO_NO.Text = model.AUTO_NO.ToString();
        this.txtPD_PROJECT_CODE.Value = model.PD_PROJECT_CODE;
        this.txtPD_CONTRACT_CHANGE_DATE.Value = model.PD_CONTRACT_CHANGE_DATE.ToString();
        this.txtPD_CONTRACT_CHANGE_TYPE.SelectedValue = model.PD_CONTRACT_CHANGE_TYPE;
        this.txtPD_CONTRACT_CHANGE_REASON.Text = model.PD_CONTRACT_CHANGE_REASON;
        this.txtPD_CONTRACT_TYPE.SelectedValue = model.PD_CONTRACT_TYPE;
        this.txtPD_CONTRACT_NO.Value = model.PD_CONTRACT_NO;
        this.txtPD_CONTRACT_NO_Name.Value = model.PD_CONTRACT_NO_Name;
        this.txtPD_CONTRACT_MONEY.Value = model.PD_CONTRACT_MONEY.ToString();
        this.txtPD_CONTRACT_CHANGE_ZJ.Value = model.PD_CONTRACT_CHANGE_ZJ;
        this.txtPD_CONTRACT_CHANGE_MONEY.Value = model.PD_CONTRACT_CHANGE_MONEY.ToString();
        this.txtPD_CONTRACT_CHANGE_WH.Value = model.PD_CONTRACT_CHANGE_WH.ToString();
        this.ddlPD_YEAR.SelectedValue = model.PD_YEAR.ToString();
        DataSet ds = new DataSet();
        ds.Tables.Add();
        ds.Tables[0].Columns.Add("AUTO_NO");
        ds.Tables[0].Columns.Add("FILE_NAME");
        ds.Tables[0].Columns.Add("FILE_SYSNAME");
        if (((model != null) && (model.PD_CONTRACT_FILENAME_SYSTEM_SQ != null)) && (model.PD_CONTRACT_FILENAME_SYSTEM_SQ.Trim() != ""))
        {
            DataRow row = ds.Tables[0].NewRow();
            row["AUTO_NO"] = model.AUTO_NO;
            row["FILE_NAME"] = model.PD_CONTRACT_CHANGE_FILENAME_SQ;
            row["FILE_SYSNAME"] = model.PD_CONTRACT_FILENAME_SYSTEM_SQ;
            ds.Tables[0].Rows.Add(row);
        }
        this.json_btData.Value = PublicDal.DataToJSON(ds);
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
