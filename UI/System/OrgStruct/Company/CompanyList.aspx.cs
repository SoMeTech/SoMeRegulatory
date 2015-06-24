using ASP;
using ExceptionLog;
using ExtExtenders;
using SoMeTech.Company;
using SoMeTech.Company.Bank;
using SoMeTech.Company.Branch;
using SoMeTech.Company.Employee;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using QxRoom.Common.ControlDo;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using YYControls;

public class Company_CompanyList : Page, IRequiresSessionState
{
    private BranchModel branch;
    protected Button btsx;
    public string count = "0";
    private DB_OPT dbo;
    protected DropDownList ddlbranch;
    private ExceptionLog.ExceptionLog el;
    private EmployeeModel em;
    protected SmartGridView gv_Employee;
    protected SmartGridView gvResult;
    protected SmartGridView gvResult_child_bank;
    protected SmartGridView gvResult_child_employee;
    private CompanyModel mm;
    public int pageind = 1;
    private PageSizeBll pagesize = new PageSizeBll();
    protected Panel Panel1;
    protected Panel Panel2;
    protected Panel Panel3;
    protected TabContainer TabContainer1;
    protected TabPanel TabPanel1;
    protected TabPanel TabPanel2;
    protected TabPanel TabPanel3;
    protected HtmlInputHidden txtindex;
    protected HtmlInputHidden txtindex1;
    protected HtmlInputHidden txttitle;
    protected HtmlInputHidden txttj;
    protected UpdatePanel UpdatePanel1;
    protected UpdatePanel UpdatePanel2;
    protected UpdatePanel UpdatePanel3;
    protected UpdatePanel UpdatePanel4;

    private void BindDrop(DB_OPT dbo)
    {
        BranchModel[] modelArray = new BranchDal().GetModels("", false, false, false, false, dbo);
        this.ddlbranch.DataSource = modelArray;
        this.ddlbranch.DataTextField = "Name";
        this.ddlbranch.DataValueField = "BranchPK";
        this.ddlbranch.DataBind();
    }

    protected void btsx_Click(object sender, EventArgs e)
    {
        this.ShowData(this.txttj.Value);
    }

    public void Buttons(string ibtid)
    {
        int selectedIndex = this.gvResult.SelectedIndex;
        switch (ibtid)
        {
            case "ibtcontrol_ibtadd":
                PageShowText.OpenPage("CompanyAdd.aspx?strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()) + "&reload=MainAddUpdate", 0x3e8, 500, this.Page);
                return;

            case "ibtcontrol_ibtupdate":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    this.DataUpdate(this.gvResult.DataKeys[selectedIndex].Value.ToString());
                    return;
                }
                Const.ShowMessage_List("请选择一行数据再操作！", this.Page);
                return;

            case "ibtcontrol_ibtdelete":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    this.DataDelete(this.gvResult.DataKeys[selectedIndex].Value.ToString());
                    return;
                }
                Const.ShowMessage_List("请选择一行数据再操作！", this.Page);
                return;

            case "ibtcontrol_ibtlook":
            case "ibtcontrol_ibtsearch":
            case "ibtcontrol_ibthuizong":
            case "ibtcontrol_ibtset":
                break;

            case "ibtcontrol_ibtrefresh":
                if (this.Master.PageIndex > 1)
                {
                    this.pageind = this.Master.PageIndex;
                }
                this.ShowData(this.Master.StrSelect);
                return;

            case "ibtcontrol_ibtputout":
                DataListDo.OutExcel(this.Page, this.gvResult, base.Server.UrlDecode(base.Request.QueryString["strTitle"].Trim()), "");
                return;

            case "ibtcontrol_ibtexit":
                ScriptManager.RegisterClientScriptBlock(this.Master.MainUpdatePanel, base.GetType(), "click", "window.parent.close();", true);
                break;

            default:
                return;
        }
    }

    public void ChildDataBind(string strPK)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            this.branch = new BranchDal();
            DataSet viewList = this.branch.GetViewList("pk_corp='" + strPK + "'", this.dbo);
            if ((viewList != null) && (viewList.Tables[0].Rows.Count > 0))
            {
                this.gvResult_child_employee.DataSource = viewList;
                this.gvResult_child_employee.DataBind();
            }
            else
            {
                DataTable table = viewList.Tables[0];
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                this.gvResult_child_employee.DataSource = table.DefaultView;
                this.gvResult_child_employee.DataBind();
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "ChildDataBind()";
            this.el.WriteExceptionLog(true);
            Const.OpenErrorPage("获取数据失败，请联系系统管理员！", this.Page);
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
    }

    public void ChildDataBindBank(string strPK)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            DataSet list = new BankDal().GetList(" pk_corp='" + strPK + "'", this.dbo);
            if ((list != null) && (list.Tables[0].Rows.Count > 0))
            {
                this.gvResult_child_bank.DataSource = list;
                this.gvResult_child_bank.DataBind();
            }
            else
            {
                DataTable table = list.Tables[0];
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                this.gvResult_child_bank.DataSource = table.DefaultView;
                this.gvResult_child_bank.DataBind();
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "ChildDataBindBank()";
            this.el.WriteExceptionLog(true);
            Const.OpenErrorPage("获取数据失败，请联系系统管理员！", this.Page);
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
    }

    private void DataDelete(string strPK)
    {
        try
        {
            this.mm = new CompanyDal();
            this.dbo = new DB_OPT();
            this.dbo.Open();
            this.mm.pk_corp = strPK.Trim();
            if (this.mm.Delete(this.dbo) > 0)
            {
                if (this.Master.PageIndex > 1)
                {
                    this.pageind = this.Master.PageIndex;
                }
                this.ShowData(this.Master.StrSelect);
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "DataDelete()";
            this.el.WriteExceptionLog(true);
            Const.OpenErrorPage("操作失败，请联系系统管理员！", this.Page);
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
    }

    private void DataUpdate(string strPK)
    {
        PageShowText.OpenPage("CompanyUpdate.aspx?PK=" + strPK + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 0x3e8, 500, this.Page);
    }

    private void EmployeeDataBind(string strPK)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            this.em = new EmployeeDal();
            DataSet list = new DataSet();
            list = this.em.GetList(" pk_corp='" + strPK + "'", this.dbo);
            if ((list != null) && (list.Tables[0].Rows.Count > 0))
            {
                this.gv_Employee.DataSource = list;
                this.gv_Employee.DataBind();
            }
            else
            {
                DataTable table = new DataTable();
                table = list.Tables[0];
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                this.gv_Employee.DataSource = table.DefaultView;
                this.gv_Employee.DataBind();
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "EmployeeDataBind()";
            this.el.WriteExceptionLog(true);
            Const.OpenErrorPage("获取数据失败，请联系系统管理员！", this.Page);
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
    }

    public string GetFather(string str)
    {
        if ((str.Trim() != "") && (str.Trim() != "0"))
        {
            try
            {
                this.ddlbranch.SelectedValue = str;
                return this.ddlbranch.SelectedItem.Text;
            }
            catch (Exception)
            {
                return "";
            }
        }
        return "";
    }

    protected void gv_Employee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i <= this.gv_Employee.Rows.Count; i++)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#8C9FF0'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
        }
    }

    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (this.Session["user"] == null)
        {
            Const.GoLoginPath_Open(this.Page);
        }
        else
        {
            int num = 0;
            string strPK = "";
            string userName = ((UserModel)this.Session["User"]).UserName;
            string power = ((UserModel)this.Session["User"]).Power;
            if (Public.IsNumber(e.CommandArgument.ToString()))
            {
                num = int.Parse(e.CommandArgument.ToString());
                if (num >= 5)
                {
                    this.txtindex.Value = (num - 2).ToString();
                }
                else
                {
                    this.txtindex.Value = "0";
                }
            }
            string commandName = e.CommandName;
            if (commandName != null)
            {
                if (!(commandName == "Select"))
                {
                    if (!(commandName == "two"))
                    {
                        bool flag1 = commandName == "Sort";
                        return;
                    }
                }
                else
                {
                    num = int.Parse(e.CommandArgument.ToString());
                    strPK = this.gvResult.DataKeys[num].Value.ToString();
                    this.ChildDataBind(strPK);
                    this.ChildDataBindBank(strPK);
                    this.EmployeeDataBind(strPK);
                    this.UpdatePanel1.Update();
                    this.UpdatePanel2.Update();
                    this.UpdatePanel4.Update();
                    return;
                }
                if (PowerClass.IfHasPower(userName, power, PowerNum.CompanyUpdate))
                {
                    num = int.Parse(e.CommandArgument.ToString());
                    strPK = this.gvResult.DataKeys[num].Value.ToString();
                    this.DataUpdate(strPK);
                }
            }
        }
    }

    protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i <= this.gvResult.Rows.Count; i++)
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
        string sortExpression = e.SortExpression;
        if ((this.ViewState["SortOrder"] != null) && (this.ViewState["OrderDire"] != null))
        {
            if (this.ViewState["SortOrder"].ToString() == sortExpression)
            {
                if (this.ViewState["OrderDire"].ToString() == "Desc")
                {
                    this.ViewState["OrderDire"] = "ASC";
                }
                else
                {
                    this.ViewState["OrderDire"] = "Desc";
                }
            }
            else
            {
                this.ViewState["SortOrder"] = e.SortExpression;
                this.ViewState["OrderDire"] = "ASC";
            }
        }
        else
        {
            this.ViewState["SortOrder"] = e.SortExpression;
            this.ViewState["OrderDire"] = "ASC";
        }
        this.ShowData(this.Master.StrSelect);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.TitlePic = "单位信息列表";
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        this.Master.SearchHasGone = new SearchHandler(this.SearchControl);
        this.Master.PageNavigatorChange = new PageNavigatorHandler(this.PageChangControl);
        ((ScriptManager)this.Master.FindControl("ScriptManager1")).RegisterAsyncPostBackControl(this.gvResult);
        if (!base.IsPostBack)
        {
            if (this.Session["User"] != null)
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
                ButtonsModel model = new ButtonsModel(userName);
                if (PowerClass.IfHasPower(userName, power, PowerNum.CompanyList))
                {
                    string[] names = new string[] { "Name", "pk_corp" };
                    DataSet searchControlDataSet = Common.GetSearchControlDataSet(names);
                    this.Master.DataSetClo = searchControlDataSet;
                    names[0] = "单位名称";
                    names[1] = "单位编号";
                    DataSet set2 = Common.GetSearchControlDataSet(names);
                    this.Master.DataSetTable = set2;
                    if (PowerClass.IfHasPower(userName, power, PowerNum.CompanyAdd))
                    {
                        model.IfAdd = true;
                    }
                    if (PowerClass.IfHasPower(userName, power, PowerNum.CompanyUpdate))
                    {
                        model.IfUpdate = true;
                    }
                    if (PowerClass.IfHasPower(userName, power, PowerNum.CompanyDelete))
                    {
                        model.IfDelete = true;
                    }
                    this.ChildDataBind("");
                    this.ChildDataBindBank("");
                    this.EmployeeDataBind("");
                    model.IfLook = false;
                    model.IfSearch = false;
                    model.IfRefresh = true;
                    model.IfHuiZong = false;
                    model.IfPutOut = false;
                    model.IfSet = false;
                    model.IfExit = true;
                    this.Master.btModel = model;
                }
                else
                {
                    Const.SorryForPower(this.Page);
                }
            }
            else
            {
                Const.GoLoginPath_List(this.Page);
            }
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
        PageUsuClass.PageChangControl(nPageIndex, "CompanyList", this.Page);
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
        PageUsuClass.SearchControl(strselect, strcloname, strsql, this.pageind, "CompanyList", this.Page);
    }

    public void ShowData(string str)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            if (((str == "") && (base.Request.QueryString["pk_corp"] != null)) && (base.Request.QueryString["pk_corp"].ToString() != ""))
            {
                string str2 = base.Request.QueryString["pk_corp"].ToString();
                str = " pk_corp='" + str2 + "' or FatherPK='" + str2 + "'";
            }
            if ((str != "") && (str != null))
            {
                str = " and " + str;
            }
            DataSet set = this.pagesize.pagesize("*", "DB_Company", " where 1=1 and pk_corp like '" + ((UserModel)this.Session["User"]).Company.pk_corp.Trim() + "%'  " + str, "pk_corp", " order by pk_corp ", this.Master.PageIndex, this.Master.PageSize, out this.count);
            this.Master.RecordCount = Convert.ToInt32(this.count);
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                DataView defaultView = set.Tables[0].DefaultView;
                if ((this.ViewState["SortOrder"] != null) && (this.ViewState["OrderDire"] != null))
                {
                    string str3 = ((string)this.ViewState["SortOrder"]) + " " + ((string)this.ViewState["OrderDire"]);
                    defaultView.Sort = str3;
                }
                this.gvResult.DataSource = defaultView;
                this.gvResult.DataBind();
            }
            else
            {
                DataTable table = new DataTable();
                table = set.Tables[0];
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                this.gvResult.DataSource = table.DefaultView;
                this.gvResult.DataBind();
            }
            this.gvResult.SelectedIndex = -1;
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "ShowData()";
            this.el.WriteExceptionLog(true);
            Const.OpenErrorPage("获取数据失败，请联系管理员！", this.Page);
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public MainTwoO Master
    {
        get
        {
            return (MainTwoO)base.Master;
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
