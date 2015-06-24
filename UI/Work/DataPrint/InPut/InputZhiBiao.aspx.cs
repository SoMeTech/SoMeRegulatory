using ASP;
using ExceptionLog;
using SoMeTech.CommonDll;
using SoMeTech.DataAccess;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using YYControls;
using SMZJ.BLL;
using SMZJ.Model;

public class Work_DataPrint_InPut_InputZhiBiao : Page, IRequiresSessionState
{
    private UserBll bll = new UserBll();
    public string count = "0";
    protected DropDownList data;
    private ExceptionLog.ExceptionLog el;
    protected HtmlInputText EndDate;
    protected SmartGridView gvResult;
    protected HtmlInputHidden hiddDatabase;
    public int pageind = 1;
    private PageSizeBll pagesize = new PageSizeBll();
    protected Button ShowData_B;
    protected HtmlInputText StartDate;
    protected HtmlInputHidden txtindex;
    protected HtmlInputHidden txttitle;
    protected UpdatePanel UpdatePanel1;

    private void Bind()
    {
    }

    public void Buttons(string ibtid)
    {
        string str;
        int selectedIndex = this.gvResult.SelectedIndex;
        if ((((str = ibtid) != null) && (str == "ibtcontrol_ibtsave")) && this.ZhiBiaoInPut())
        {
            this.ShowData_Click(null, null);
        }
    }

    private void JS_BindShow(string ShowText)
    {
        if (ShowText != null)
        {
            PageShowText.Run_javascript("bind();alert(\"" + ShowText + "\")", this.Page);
        }
        else
        {
            PageShowText.Run_javascript("bind();", this.Page);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (base.Request["strTitle"] != null)
        {
            this.txttitle.Value = base.Server.UrlDecode(base.Request["strTitle"].ToString().Trim());
        }
        this.Master.strTitle = this.txttitle.Value;
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        this.Master.SearchHasGone = new SearchHandler(this.SearchControl);
        this.Master.PageNavigatorChange = new PageNavigatorHandler(this.PageChangControl);
        if (!this.Page.IsPostBack)
        {
            if (this.Session["user"] != null)
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
                try
                {
                    string[] names = new string[] { "pd_project_name", "pd_project_code" };
                    DataSet searchControlDataSet = Common.GetSearchControlDataSet(names);
                    this.Master.DataSetClo = searchControlDataSet;
                    names[0] = "项目名称";
                    names[1] = "项目编码";
                    DataSet set2 = Common.GetSearchControlDataSet(names);
                    this.Master.DataSetTable = set2;
                    ButtonsModel model = null;
                    PublicDal.ShowListButton(this.Page, out model, "");
                    model.IfSave = true;
                    model.IbtSaveText = "导入";
                    this.Master.btModel = model;
                    if (this.gvResult.DataSource == null)
                    {
                        DataSet set3 = new DataSet();
                        set3.Tables.Add();
                        set3.Tables[0].Columns.Add("");
                        DataRow row = set3.Tables[0].NewRow();
                        row[0] = "无数据";
                        set3.Tables[0].Rows.Add(row);
                        this.gvResult.DataSource = set3;
                        this.gvResult.DataBind();
                    }
                }
                catch (Exception exception)
                {
                    this.el = new ExceptionLog.ExceptionLog();
                    this.el.ErrClassName = base.GetType().ToString();
                    this.el.ErrMessage = exception.Message.ToString();
                    this.el.ErrMethod = "bind()";
                    this.el.WriteExceptionLog(true);
                    Const.OpenErrorPage("获取数据失败，请联系管理员！", this.Page);
                }
                this.Bind();
            }
            else
            {
                Const.GoLoginPath_List(this.Page);
            }
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
    }

    private void ShowData(DateTime start, DateTime end, string databaseName)
    {
        DataSet set = new TB_QUOTA_Bll().GetInputData(start, end, databaseName, base.Server.MapPath("~/") + @"bin\CreateTriZB_MXZB_to_SoMeTech.sql");
        if (set != null)
        {
            if (this.gvResult.Columns.Count <= 1)
            {
                for (int i = 0; i < set.Tables[0].Columns.Count; i++)
                {
                    BoundField field = new BoundField
                    {
                        DataField = set.Tables[0].Columns[i].ColumnName,
                        HeaderText = set.Tables[0].Columns[i].ColumnName,
                        SortExpression = set.Tables[0].Columns[i].ColumnName
                    };
                    field.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.gvResult.Columns.Add(field);
                }
            }
            this.gvResult.DataSource = set;
            this.gvResult.DataBind();
        }
        else
        {
            PageShowText.Run_javascript("bind();ShowLoading('此帐套第一次做导入,正在初始化!切勿关闭窗口,请耐心等待!!')", this.Page);
        }
    }

    protected void ShowData_Click(object sender, EventArgs e)
    {
        if (PublicDal.PageValidate.IsDateTime(this.StartDate.Value) && PublicDal.PageValidate.IsDateTime(this.EndDate.Value))
        {
            this.ShowData(DateTime.Parse(this.StartDate.Value), DateTime.Parse(this.EndDate.Value), "");
            this.JS_BindShow(null);
            PageShowText.Run_javascript("bind();", this.Page);
        }
        else
        {
            this.JS_BindShow("请选择时间!");
        }
    }

    private bool ZhiBiaoInPut()
    {
        if (this.gvResult.Rows.Count > 0)
        {
            TB_QUOTA_Bll bll = new TB_QUOTA_Bll();
            List<TB_QUOTA_Model> modelList = new List<TB_QUOTA_Model>();
            UserModel model = (UserModel)this.Session["User"];
            string userName = model.UserName;
            string str2 = model.Company.pk_corp;
            string bH = model.Branch.BH;
            DateTime now = DateTime.Now;
            string databaseName = this.hiddDatabase.Value;
            PublicDal.SetCreateServiceStream(this.Page, "ZBOper.aspx");
            foreach (GridViewRow row in this.gvResult.Rows)
            {
                if (((CheckBox)row.Cells[0].FindControl("checkbox1")).Checked)
                {
                    TB_QUOTA_Model item = new TB_QUOTA_Model
                    {
                        PD_QUOTA_CODE = DateTime.Now.ToString("yyyyMMddhhmmssffffff")
                    };
                    if (PublicDal.PageValidate.IsDateTime(row.Cells[1].Text))
                    {
                        item.PD_QUOTA_FWDATA = DateTime.Parse(row.Cells[1].Text);
                    }
                    item.PD_QUOTA_ZBWH = row.Cells[2].Text;
                    item.PD_QUOTA_NAME = row.Cells[3].Text;
                    item.PD_YEAR = row.Cells[4].Text;
                    item.PD_QUOTA_ZJXZ = row.Cells[5].Text;
                    if (PublicDal.PageValidate.IsDecimal(row.Cells[6].Text))
                    {
                        item.PD_QUOTA_MONEY_TOTAL = decimal.Parse(row.Cells[6].Text);
                    }
                    item.PD_QUOTA_ZBXDZH = row.Cells[7].Text;
                    item.PD_QUOTA_ZBYT = row.Cells[8].Text;
                    item.PD_QUOTA_GLLX = row.Cells[9].Text;
                    item.PD_QUOTA_JJLX = row.Cells[10].Text;
                    item.PD_QUOTA_INPUT_MAN = userName;
                    item.PD_QUOTA_INPUT_COMPANY = str2;
                    item.PD_QUOTA_INPUT_DATE = new DateTime?(now);
                    item.PD_QUOTA_INPUT_DEPART = bH;
                    modelList.Add(item);
                }
            }
            if (modelList.Count > 0)
            {
                bll.AddList(modelList, databaseName);
                this.JS_BindShow("导入成功!");
                return true;
            }
            this.JS_BindShow("请选择一行数据进行导入!");
        }
        else
        {
            this.JS_BindShow("请先查询数据!");
        }
        return false;
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public MainOne Master
    {
        get
        {
            return (MainOne)base.Master;
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
