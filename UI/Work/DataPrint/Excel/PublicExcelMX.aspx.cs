using ASP;
using SoMeTech.CommonDll;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SMZJ.BLL;
using SMZJ.Model;

public class Work_DataPrint_Excel_PublicExcelMX : Page, IRequiresSessionState
{
    protected HtmlInputHidden auto_id;
    private ButtonsHandler bh;
    protected WebControls_Buttons1 Buttons1_1;
    protected DropDownList ddlBranch;
    protected DropDownList ddlCompany;
    protected DropDownList ddlServerPK;
    protected HtmlForm form1;
    protected HtmlInputHidden hBranch;
    protected HtmlInputHidden ibtid;
    protected HtmlInputHidden ModelDataColumns;
    protected HtmlInputHidden ModelDataTable;
    protected TextBox ModelName;

    private void BindDll()
    {
        PublicDal.BindDropDownList(this.ddlCompany, "DB_COMPANY", "name", "pk_corp", "pk_corp like '" + ((UserModel)this.Session["User"]).Company.pk_corp.Trim() + "%'");
        this.ddlCompany.Items.Insert(0, new ListItem(" ==请选择== ", "-1"));
        this.ddlCompany.SelectedValue = "-1";
        PublicDal.BindDropDownList(this.ddlServerPK, "(select t2.name sname,substr(t.serverpks,1, instr(t.serverpks,'|')-1) pk from GOV_TC_DB_OPERATION t inner join GOV_TC_DB_OPRATETACHE t2 on t2.pk=t.operationpk)a", "sname", "pk", "");
    }

    public void Buttons(string ibtid)
    {
        string str;
        if (((str = ibtid) != null) && (str == "sava"))
        {
            if (this.auto_id.Value.Trim().Length == 0)
            {
                this.Create();
            }
            else
            {
                this.Update(this.auto_id.Value.Trim());
            }
        }
    }

    private void Create()
    {
        DataSet set = PublicDal.JsonToDataSet(this.ModelDataColumns.Value);
        PD_PROJECT_PUBLICEXCEL_Bll bll = new PD_PROJECT_PUBLICEXCEL_Bll();
        PD_PROJECT_PUBLICEXCEL_Model model = new PD_PROJECT_PUBLICEXCEL_Model();
        if (this.ddlCompany.SelectedValue != "-1")
        {
            model.COMPANYID = this.ddlCompany.SelectedValue;
        }
        if (this.hBranch.Value != "-1")
        {
            model.BRANCHID = this.hBranch.Value;
        }
        model.NAME = this.ModelName.Text;
        model.TABLENAME = this.ModelDataTable.Value;
        model.PD_PROJECT_SERVERPK = this.ddlServerPK.SelectedValue;
        bll.Add(model);
        PD_PROJECT_PUBLICEXCEL_DETAIL_Bll bll2 = new PD_PROJECT_PUBLICEXCEL_DETAIL_Bll();
        PD_PROJECT_PUBLICEXCEL_DETAIL_Model[] modelAll = new PD_PROJECT_PUBLICEXCEL_DETAIL_Model[set.Tables[0].Rows.Count];
        int num = 0;
        foreach (DataRow row in set.Tables[0].Rows)
        {
            PD_PROJECT_PUBLICEXCEL_DETAIL_Model model2 = new PD_PROJECT_PUBLICEXCEL_DETAIL_Model
            {
                PID = new decimal?(model.AUTO_ID),
                TABLE_ENAME = this.ModelDataTable.Value,
                COLUMN_ENAME = row["column"].ToString(),
                COLUMN_CNAME = base.Server.UrlDecode(row["Ccolumn"].ToString()),
                //TABLE_ENAME = this.ModelDataTable.Value,//此处确实重复，黄文华批注
                ISPRIMARY = "0",
                ISDEFAULTTYPE = row["type"].ToString().Trim(),
                DEFAULTDATA = base.Server.UrlDecode(row["data"].ToString())
            };
            modelAll[num++] = model2;
        }
        bll2.Add(modelAll);
        PageShowText.DoSuccessClose("添加模板成功！", this.Page);
    }

    public void ListPageLoad(Page page, out ButtonsModel main_bm, string AUTO_ID)
    {
        PublicDal.ShowMxButton(this.Page, out main_bm, "PD_PROJECT_PUBLICEXCEL", "AUTO_ID", AUTO_ID, "PD_PROJECT_SERVERPK");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (this.ButtonsPushDown != null)
        {
            this.ButtonsPushDown(this.ibtid.Value);
            this.ibtid.Value = "";
        }
        if (!base.IsPostBack)
        {
            new ButtonsModel();
            this.BindDll();
            this.auto_id.Value = base.Request["auto_id"];
        }
    }

    private void Update(string auto_id)
    {
        if (PublicDal.PageValidate.IsDecimal(auto_id))
        {
            DataSet set = PublicDal.JsonToDataSet(this.ModelDataColumns.Value);
            PD_PROJECT_PUBLICEXCEL_Bll bll = new PD_PROJECT_PUBLICEXCEL_Bll();
            PD_PROJECT_PUBLICEXCEL_Model model = bll.GetModel(decimal.Parse(auto_id));
            model.COMPANYID = this.ddlCompany.SelectedValue;
            model.BRANCHID = this.hBranch.Value;
            model.NAME = this.ModelName.Text;
            model.TABLENAME = this.ModelDataTable.Value;
            model.PD_PROJECT_SERVERPK = this.ddlServerPK.SelectedValue;
            bll.Update(model);
            PD_PROJECT_PUBLICEXCEL_DETAIL_Bll bll2 = new PD_PROJECT_PUBLICEXCEL_DETAIL_Bll();
            bll2.DeleteAll(decimal.Parse(auto_id));
            PD_PROJECT_PUBLICEXCEL_DETAIL_Model[] modelAll = new PD_PROJECT_PUBLICEXCEL_DETAIL_Model[set.Tables[0].Rows.Count];
            int num = 0;
            foreach (DataRow row in set.Tables[0].Rows)
            {
                PD_PROJECT_PUBLICEXCEL_DETAIL_Model model2 = new PD_PROJECT_PUBLICEXCEL_DETAIL_Model
                {
                    PID = new decimal?(model.AUTO_ID),
                    TABLE_ENAME = this.ModelDataTable.Value,
                    COLUMN_ENAME = row["column"].ToString(),
                    COLUMN_CNAME = base.Server.UrlDecode(row["Ccolumn"].ToString()),
                    //TABLE_ENAME = this.ModelDataTable.Value,//此处确实重复，黄文华批注
                    ISPRIMARY = "0",
                    ISDEFAULTTYPE = row["type"].ToString().Trim(),
                    DEFAULTDATA = base.Server.UrlDecode(row["data"].ToString())
                };
                modelAll[num++] = model2;
            }
            bll2.Add(modelAll);
            PageShowText.DoSuccessClose("修改模板成功！", this.Page);
        }
        else
        {
            PageShowText.DoSuccessClose("修改模板失败！找不到记录。", this.Page);
        }
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public ButtonsModel btModel
    {
        get
        {
            return this.Buttons1_1.BM;
        }
        set
        {
            this.Buttons1_1.BM = value;
        }
    }

    public ButtonsHandler ButtonsPushDown
    {
        get
        {
            return this.bh;
        }
        set
        {
            this.bh = value;
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
