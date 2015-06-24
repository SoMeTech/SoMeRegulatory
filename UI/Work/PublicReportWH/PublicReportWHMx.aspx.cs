using ASP;
using SoMeTech.CommonDll;
using SoMeTech.User;
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

public class Work_PublicReportWH_PublicReportWHMx : Page, IRequiresSessionState
{
    protected DropDownList ddlPD_YEAR;
    protected UserControls_FilePostCtr FilePostCtr1;
    protected HtmlInputHidden json_btData;
    protected Label lblAUTO_NO;
    protected TextBox txtPD_CONTRACT_ASK_LIMIT;
    protected TextBox txtPD_CONTRACT_ASK_PAYMENT;
    protected HtmlInputText txtPD_CONTRACT_ASK_PROCEED;
    protected TextBox txtPD_CONTRACT_COMPANY;
    protected HtmlInputText txtPD_CONTRACT_DATE;
    protected HtmlInputText txtPD_CONTRACT_MOENY;
    protected HtmlInputText txtPD_CONTRACT_MOENY_CHANGE;
    protected TextBox txtPD_CONTRACT_NAME;
    protected HtmlInputText txtPD_CONTRACT_NO;
    protected TextBox txtPD_CONTRACT_NOTE;
    protected DropDownList txtPD_CONTRACT_TYPE;
    protected HtmlInputText txtPD_PROJECT_CODE;
    protected HtmlInputText txtPD_PROJECT_Name;
    protected HtmlTable zxzb_bt;

    private void BindDll()
    {
        PublicDal.BindDropDownList(this.txtPD_CONTRACT_TYPE, "PD_BASE_CONTRACTTYPE", "CONTRACTTYPE_NAME", "CONTRACTTYPE_CODE", "");
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

    private void getModel(PD_PROJECT_CONTRACT_Model model)
    {
        model.PD_PROJECT_CODE = this.txtPD_PROJECT_CODE.Value;
        model.PD_CONTRACT_TYPE = this.txtPD_CONTRACT_TYPE.SelectedValue;
        model.PD_CONTRACT_NO = this.txtPD_CONTRACT_NO.Value;
        model.PD_CONTRACT_COMPANY = this.txtPD_CONTRACT_COMPANY.Text;
        model.PD_CONTRACT_ASK_LIMIT = this.txtPD_CONTRACT_ASK_LIMIT.Text;
        model.PD_CONTRACT_ASK_PROCEED = this.txtPD_CONTRACT_ASK_PROCEED.Value;
        model.PD_CONTRACT_ASK_PAYMENT = this.txtPD_CONTRACT_ASK_PAYMENT.Text;
        model.PD_CONTRACT_NOTE = this.txtPD_CONTRACT_NOTE.Text;
        model.PD_CONTRACT_NAME = this.txtPD_CONTRACT_NAME.Text;
        model.PD_YEAR = this.ddlPD_YEAR.SelectedValue;
        if (PublicDal.PageValidate.IsDateTime(this.txtPD_CONTRACT_DATE.Value))
        {
            model.PD_CONTRACT_DATE = DateTime.Parse(this.txtPD_CONTRACT_DATE.Value);
        }
        else
        {
            model.PD_CONTRACT_DATE = new DateTime();
        }
        if (PublicDal.PageValidate.IsInt(this.txtPD_CONTRACT_MOENY.Value))
        {
            model.PD_CONTRACT_MOENY = new decimal?(int.Parse(this.txtPD_CONTRACT_MOENY.Value));
        }
        if (PublicDal.PageValidate.IsInt(this.txtPD_CONTRACT_MOENY_CHANGE.Value))
        {
            model.PD_CONTRACT_MOENY_CHANGE = new decimal?(int.Parse(this.txtPD_CONTRACT_MOENY_CHANGE.Value));
        }
        this.GetQUOTA(model);
    }

    private void GetQUOTA(PD_PROJECT_CONTRACT_Model model)
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
                model.PD_CONTRACT_FILENAME = defaultView[0]["FileName"].ToString();
                model.PD_CONTRACT_FILENAME_SYSTEM = defaultView[0]["FileSysName"].ToString();
            }
        }
    }

    public void ListPageLoad(Page page, out ButtonsModel main_bm, string AUTO_NO)
    {
        PublicDal.ShowMxButton(this.Page, out main_bm, "PD_PROJECT_CONTRACT", "AUTO_NO", AUTO_NO, "PD_NOW_SERVERPK");
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
            ButtonsModel model = null;
            this.ListPageLoad(this.Page, out model, base.Request["UpdatePK"]);
            this.Master.btModel = model;
            if (!base.IsPostBack)
            {
                this.BindDll();
                if ((base.Request["UpdatePK"] != null) && PublicDal.PageValidate.IsDecimal(base.Request["UpdatePK"]))
                {
                    this.ShowInfo(base.Request["UpdatePK"]);
                }
                else
                {
                    this.selectHTBH();
                }
            }
        }
    }

    private string PanDuan()
    {
        string str = "";
        if (this.txtPD_PROJECT_CODE.Value.Trim().Length == 0)
        {
            str = str + @"项目名称不能为空！\n";
        }
        if (this.txtPD_CONTRACT_TYPE.Text.Trim().Length == 0)
        {
            str = str + @"合同类型不能为空！\n";
        }
        if (this.txtPD_CONTRACT_NO.Value.Trim().Length == 0)
        {
            str = str + @"合同编号不能为空！\n";
        }
        if (this.txtPD_CONTRACT_DATE.Value.Trim().Length == 0)
        {
            str = str + @"合同日期格式错误！\n";
        }
        if (this.txtPD_CONTRACT_COMPANY.Text.Trim().Length == 0)
        {
            str = str + @"合同签约单位不能为空！\n";
        }
        if (!PublicDal.PageValidate.IsNumber(this.txtPD_CONTRACT_MOENY.Value))
        {
            str = str + @"合同金额格式错误！\n";
        }
        if (this.txtPD_CONTRACT_ASK_LIMIT.Text.Trim().Length == 0)
        {
            str = str + @"合同工期要求不能为空！\n";
        }
        if (this.txtPD_CONTRACT_ASK_PROCEED.Value.Trim().Length == 0)
        {
            str = str + @"合同进度要求不能为空！\n";
        }
        if (this.txtPD_CONTRACT_ASK_PAYMENT.Text.Trim().Length == 0)
        {
            str = str + @"合同付款要求不能为空！\n";
        }
        return str;
    }

    private void Save()
    {
        PD_PROJECT_CONTRACT_Bll bll = new PD_PROJECT_CONTRACT_Bll();
        if (base.Request["UpdatePK"] != null)
        {
            if (PublicDal.PageValidate.IsDecimal(base.Request["UpdatePK"]))
            {
                PD_PROJECT_CONTRACT_Model model = bll.GetModel(base.Request["UpdatePK"].ToString());
                this.getModel(model);
                bll.Update(model);
                PageShowText.Refurbish("修改成功", this.Page);
            }
        }
        else if (this.txtPD_PROJECT_CODE.Value != null)
        {
            PD_PROJECT_CONTRACT_Model model2 = new PD_PROJECT_CONTRACT_Model
            {
                PD_DB_LOOP = "1"
            };
            this.getModel(model2);
            model2.PD_NOW_SERVERPK = PublicDal.SetCreateServiceStream(this.Page);
            bll.Add(model2);
            Const.DoSuccessNoClose("添加成功", this.Page.Request.Url.LocalPath + "?UpdatePK=" + model2.AUTO_NO, this.Page);
        }
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
    }

    private void selectHTBH()
    {
        this.txtPD_CONTRACT_NO.Value = new PD_PROJECT_CONTRACT_Bll().GetMaxID(DateTime.Now.Year.ToString(), ((UserModel)this.Session["User"]).Company.pk_corp.Trim());
    }

    public void SetServiceStream(int operation, string AUTO_NO, string Mess)
    {
        PublicDal.SetServiceStream(this.Page, operation, "PD_PROJECT_CONTRACT", "AUTO_NO", AUTO_NO, Mess, "PD_NOW_SERVERPK");
    }

    private void ShowInfo(string AUTO_NO)
    {
        PD_PROJECT_CONTRACT_Model model = new PD_PROJECT_CONTRACT_Bll().GetModel(AUTO_NO);
        TB_PROJECT_Model model2 = new TB_PROJECT_Bll().GetModel(model.PD_PROJECT_CODE);
        this.txtPD_PROJECT_Name.Value = model2.PD_PROJECT_NAME;
        this.lblAUTO_NO.Text = model.AUTO_NO;
        this.txtPD_PROJECT_CODE.Value = model.PD_PROJECT_CODE;
        this.txtPD_CONTRACT_TYPE.SelectedValue = model.PD_CONTRACT_TYPE;
        this.txtPD_CONTRACT_NO.Value = model.PD_CONTRACT_NO;
        this.txtPD_CONTRACT_DATE.Value = model.PD_CONTRACT_DATE.ToString();
        this.txtPD_CONTRACT_COMPANY.Text = model.PD_CONTRACT_COMPANY;
        this.txtPD_CONTRACT_MOENY.Value = model.PD_CONTRACT_MOENY.ToString();
        this.txtPD_CONTRACT_MOENY_CHANGE.Value = model.PD_CONTRACT_MOENY_CHANGE.ToString();
        this.txtPD_CONTRACT_ASK_LIMIT.Text = model.PD_CONTRACT_ASK_LIMIT;
        this.txtPD_CONTRACT_ASK_PROCEED.Value = model.PD_CONTRACT_ASK_PROCEED;
        this.txtPD_CONTRACT_ASK_PAYMENT.Text = model.PD_CONTRACT_ASK_PAYMENT;
        this.txtPD_CONTRACT_NOTE.Text = model.PD_CONTRACT_NOTE;
        this.txtPD_CONTRACT_NAME.Text = model.PD_CONTRACT_NAME;
        this.txtPD_CONTRACT_TYPE.SelectedValue = model.PD_CONTRACT_TYPE;
        this.ddlPD_YEAR.SelectedValue = model.PD_YEAR;
        DataSet ds = new DataSet();
        ds.Tables.Add();
        ds.Tables[0].Columns.Add("AUTO_NO");
        ds.Tables[0].Columns.Add("FILE_NAME");
        ds.Tables[0].Columns.Add("FILE_SYSNAME");
        if (((model != null) && (model.PD_CONTRACT_FILENAME_SYSTEM != null)) && (model.PD_CONTRACT_FILENAME_SYSTEM.Trim() != ""))
        {
            DataRow row = ds.Tables[0].NewRow();
            row["AUTO_NO"] = model.AUTO_NO;
            row["FILE_NAME"] = model.PD_CONTRACT_FILENAME;
            row["FILE_SYSNAME"] = model.PD_CONTRACT_FILENAME_SYSTEM;
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

    public MainAddUpdate Master
    {
        get
        {
            return (MainAddUpdate)base.Master;
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
