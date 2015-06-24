using ASP;
using ExceptionLog;
using ExtExtenders;
using SoMeTech.Company.Branch;
using SoMeTech.Company.Employee;
using SoMeTech.Company.Role;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using YYControls;

public class Branch_BranchList : MainPageClass, IRequiresSessionState
{
    public string count = "0";
    private DB_OPT dbo;
    protected DropDownList ddlbranch;
    private ExceptionLog.ExceptionLog el;
    private EmployeeModel em;
    protected SmartGridView gvResult;
    protected SmartGridView gvResult1;
    protected SmartGridView gvResult2;
    public int pageind = 1;
    private PageSizeBll pagesize = new PageSizeBll();
    protected Panel Panel1;
    protected Panel Panel2;
    private BranchModel rm;
    private RoleModel role;
    protected TabContainer TabContainer1;
    protected TabPanel TabPanel1;
    protected TabPanel TabPanel2;
    protected HtmlInputHidden txtindex;
    protected HtmlInputHidden txttitle;
    protected UpdatePanel UpdatePanel1;
    protected UpdatePanel UpdatePanel2;
    protected UpdatePanel UpdatePanel3;

    private void BindDrop(DB_OPT dbo)
    {
        BranchModel[] modelArray = new BranchDal().GetModels("", false, false, false, false, dbo);
        this.ddlbranch.DataSource = modelArray;
        this.ddlbranch.DataTextField = "Name";
        this.ddlbranch.DataValueField = "BranchPK";
        this.ddlbranch.DataBind();
    }

    public void Buttons(string ibtid)
    {
        int selectedIndex = this.gvResult.SelectedIndex;
        switch (ibtid)
        {
            case "ibtcontrol_ibtadd":
                PageShowText.OpenPage("BranchAdd.aspx?strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()) + "&reload=MainAddUpdate", 800, 500, this.Page);
                return;

            case "ibtcontrol_ibtupdate":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    PageShowText.OpenPage("BranchUpdate.aspx?PK=" + this.gvResult.DataKeys[selectedIndex].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 800, 500, this.Page);
                    return;
                }
                PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
                return;

            case "ibtcontrol_ibtdelete":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    this.DataDelete(this.gvResult.DataKeys[selectedIndex].Value.ToString(), ((Label)this.gvResult.Rows[selectedIndex].FindControl("lbBH")).Text, ((Label)this.gvResult.Rows[selectedIndex].FindControl("lbName")).Text, ((Label)this.gvResult.Rows[selectedIndex].FindControl("lbPK_Corp_Info")).Text);
                    return;
                }
                PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
                return;

            case "ibtcontrol_ibtlook":
            case "ibtcontrol_ibtsearch":
            case "ibtcontrol_ibthuizong":
            case "ibtcontrol_ibtputout":
            case "ibtcontrol_ibtset":
            case "ibtcontrol_ibtexit":
                break;

            case "ibtcontrol_ibtrefresh":
                if (this.Master.PageIndex > 1)
                {
                    this.pageind = this.Master.PageIndex;
                }
                this.ShowData(this.Master.StrSelect);
                break;

            default:
                return;
        }
    }

    private void ChildDataBind(string strPK)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            this.em = new EmployeeDal();
            DataSet list = new DataSet();
            list = this.em.GetList(" BranchPK='" + strPK + "'", this.dbo);
            if ((list != null) && (list.Tables[0].Rows.Count > 0))
            {
                this.gvResult1.DataSource = list;
                this.gvResult1.DataBind();
            }
            else
            {
                DataTable table = new DataTable();
                table = list.Tables[0];
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                this.gvResult1.DataSource = table.DefaultView;
                this.gvResult1.DataBind();
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

    private void ChildDataBindRole(string strPK)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            this.role = new RoleDal();
            DataSet list = new DataSet();
            list = this.role.GetList(" BranchPK='" + strPK + "'", this.dbo);
            if ((list != null) && (list.Tables[0].Rows.Count > 0))
            {
                this.gvResult2.DataSource = list;
                this.gvResult2.DataBind();
            }
            else
            {
                DataTable table = new DataTable();
                table = list.Tables[0];
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                this.gvResult2.DataSource = table.DefaultView;
                this.gvResult2.DataBind();
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "ChildDataBindRole()";
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

    protected void DataDelete(string strPK, string bh, string name, string company)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            this.rm = new BranchDal();
            this.rm.BranchPK = strPK;
            this.rm.Delete(this.dbo);
            OperationLogBll.insertOp("删除", "部门列表", "删除 " + company + " 单位下编号为：" + bh + " 名称为：" + name + " 的部门", "Y", this.Page);
            if (this.Master.PageIndex > 1)
            {
                this.pageind = this.Master.PageIndex;
            }
            this.ShowData(this.Master.StrSelect);
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

    protected void DataUpdate(string strPK)
    {
        ScriptManager.RegisterClientScriptBlock(this.Master.MainUpdatePanel, this.Master.MainUpdatePanel.GetType(), "open", "window.open('BranchUpdate.aspx?PK=" + strPK + "','','toolbar=no,status=no,resizable=no,width=800px,height=600px,scrollbars=no,location=no');", true);
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

    public string GetSex(string str)
    {
        if (str.Trim() == "0")
        {
            str = "男";
        }
        if (str.Trim() == "1")
        {
            str = "女";
        }
        return str;
    }

    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (this.Session["user"] == null)
        {
            Const.GoLoginPath_List(this.Page);
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
                    if (!(commandName == "Two"))
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
                    this.ChildDataBindRole(strPK);
                    this.UpdatePanel2.Update();
                    this.UpdatePanel3.Update();
                    return;
                }
                if (PowerClass.IfHasPower(userName, power, PowerNum.BranchUpdate))
                {
                    num = int.Parse(e.CommandArgument.ToString());
                    PageShowText.OpenPage("BranchUpdate.aspx?PK=" + this.gvResult.DataKeys[num].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 800, 500, this.Page);
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

    protected void gvResult1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string str;
        int num = 0;
        if (((str = e.CommandName) != null) && (str != "Select"))
        {
            if (!(str == "two"))
            {
                if (str == "Sort")
                {
                }
            }
            else
            {
                num = int.Parse(e.CommandArgument.ToString());
                PageShowText.OpenPage("BranchUpdate.aspx?PK=" + this.gvResult1.DataKeys[num].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 800, 500, this.Page);
            }
        }
    }

    protected void gvResult1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i <= this.gvResult1.Rows.Count; i++)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#8C9FF0'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
        }
    }

    protected void gvResult1_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        if ((this.ViewState["SortOrder1"] != null) && (this.ViewState["OrderDire1"] != null))
        {
            if (this.ViewState["SortOrder1"].ToString() == sortExpression)
            {
                if (this.ViewState["OrderDire1"].ToString() == "Desc")
                {
                    this.ViewState["OrderDire1"] = "ASC";
                }
                else
                {
                    this.ViewState["OrderDire1"] = "Desc";
                }
            }
            else
            {
                this.ViewState["SortOrder1"] = e.SortExpression;
                this.ViewState["OrderDire1"] = "ASC";
            }
        }
        else
        {
            this.ViewState["SortOrder1"] = e.SortExpression;
            this.ViewState["OrderDire1"] = "ASC";
        }
        if (this.gvResult.SelectedIndex >= 0)
        {
            this.ChildDataBind(this.gvResult.DataKeys[this.gvResult.SelectedIndex].Value.ToString());
        }
        else
        {
            this.ChildDataBind("");
        }
    }

    protected void gvResult2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int num = 0;
        string str = "";
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
                int activeTabIndex = this.TabContainer1.ActiveTabIndex;
                this.TabContainer1.ActiveTab.ID.ToString();
                return;
            }
            num = int.Parse(e.CommandArgument.ToString());
            str = this.gvResult2.DataKeys[num].Value.ToString();
            ScriptManager.RegisterClientScriptBlock(this.Master.MainUpdatePanel, this.Master.MainUpdatePanel.GetType(), "open", "window.open('../Role/RoleUpdate.aspx?PK=" + str + "&strTitle=" + base.Server.UrlEncode("角色信息").ToString() + "','','toolbar=no,status=no,resizable=no,width=800px,height=500px,scrollbars=no,location=no,left=200,top=100');", true);
        }
    }

    protected void gvResult2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i <= this.gvResult2.Rows.Count; i++)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#8C9FF0'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
        }
    }

    protected void gvResult2_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        if ((this.ViewState["SortOrder2"] != null) && (this.ViewState["OrderDire2"] != null))
        {
            if (this.ViewState["SortOrder2"].ToString() == sortExpression)
            {
                if (this.ViewState["OrderDire2"].ToString() == "Desc")
                {
                    this.ViewState["OrderDire2"] = "ASC";
                }
                else
                {
                    this.ViewState["OrderDire2"] = "Desc";
                }
            }
            else
            {
                this.ViewState["SortOrder2"] = e.SortExpression;
                this.ViewState["OrderDire2"] = "ASC";
            }
        }
        else
        {
            this.ViewState["SortOrder2"] = e.SortExpression;
            this.ViewState["OrderDire2"] = "ASC";
        }
        if (this.gvResult.SelectedIndex >= 0)
        {
            this.ChildDataBindRole(this.gvResult.DataKeys[this.gvResult.SelectedIndex].Value.ToString());
        }
        else
        {
            this.ChildDataBindRole("");
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
        ((ScriptManager)this.Master.FindControl("ScriptManager1")).RegisterAsyncPostBackControl(this.gvResult);
        if (!this.Page.IsPostBack)
        {
            if (this.Session["User"] != null)
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                ButtonsModel model = new ButtonsModel(userName);
                if (PowerClass.IfHasPower(userName, power, PowerNum.BranchList))
                {
                    try
                    {
                        try
                        {
                            string[] names = new string[] { "Name", "BH" };
                            DataSet searchControlDataSet = Common.GetSearchControlDataSet(names);
                            this.Master.DataSetClo = searchControlDataSet;
                            names[0] = "部门名称";
                            names[1] = "部门编号";
                            DataSet set2 = Common.GetSearchControlDataSet(names);
                            this.Master.DataSetTable = set2;
                            this.dbo = new DB_OPT();
                            this.dbo.Open();
                            this.BindDrop(this.dbo);
                            this.ChildDataBind("");
                            this.ChildDataBindRole("");
                            if (PowerClass.IfHasPower(userName, power, PowerNum.BranchAdd))
                            {
                                model.IfAdd = true;
                            }
                            if (PowerClass.IfHasPower(userName, power, PowerNum.BranchUpdate))
                            {
                                model.IfUpdate = true;
                            }
                            if (PowerClass.IfHasPower(userName, power, PowerNum.BranchDelete))
                            {
                                model.IfDelete = true;
                            }
                            model.IfLook = false;
                            model.IfSearch = false;
                            model.IfRefresh = true;
                            model.IfHuiZong = false;
                            model.IfPutOut = false;
                            model.IfSet = false;
                            model.IfExit = true;
                            this.Master.btModel = model;
                        }
                        catch (Exception exception)
                        {
                            this.el = new ExceptionLog.ExceptionLog();
                            this.el.ErrClassName = base.GetType().ToString();
                            this.el.ErrMessage = exception.Message.ToString();
                            this.el.ErrMethod = "Page_Load()";
                            this.el.WriteExceptionLog(true);
                            Const.OpenErrorPage("获取数据失败，请联系系统管理员！", this.Page);
                        }
                        return;
                    }
                    finally
                    {
                        if (this.dbo != null)
                        {
                            this.dbo.Close();
                        }
                    }
                }
                Const.SorryForPower(this.Page);
            }
            else
            {
                Const.GoLoginPath_List(this.Page);
            }
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
        PageUsuClass.PageChangControl(nPageIndex, "BranchList", this.Page);
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
        PageUsuClass.SearchControl(strselect, strcloname, strsql, this.pageind, "BranchList", this.Page);
    }

    public string SetIsUser(string strIsUser)
    {
        if (strIsUser == "1")
        {
            return "启用";
        }
        if (strIsUser == "")
        {
            return "";
        }
        return "不启用";
    }

    public void ShowData(string str)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
            if (((UserModel)this.Session["User"]).UserName.Trim() != "admin")
            {
                if (str != "")
                {
                    str = " where " + str + " and pk_corp='" + this.Session["pk_corp"].ToString() + "' and patindex('%|'||rtrim(BH)||'|%','|" + companyPower + "|')>0 ";
                }
                else
                {
                    str = " where pk_corp='" + this.Session["pk_corp"].ToString() + "' and patindex('%|'||rtrim(BH)||'|%','|" + companyPower + "|')>0 ";
                }
            }
            else if (str != "")
            {
                str = " where " + str;
            }
            DataSet set = this.pagesize.pagesize("*", "GOV_TC_VIEW_BRANCH", str, "BranchPK", " order by BH ", this.Master.PageIndex, this.Master.PageSize, out this.count);
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
                DataRow row = set.Tables[0].NewRow();
                set.Tables[0].Rows.Add(row);
                this.gvResult.DataSource = set.Tables[0].DefaultView;
                this.gvResult.DataBind();
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "ShowData()";
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
