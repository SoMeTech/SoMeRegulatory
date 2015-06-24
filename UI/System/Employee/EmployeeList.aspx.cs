using ASP;
using ExceptionLog;
using SoMeTech.Company.Employee;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using QxRoom.QxConst;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using YYControls;

public class Employee_EmployeeList : Page, IRequiresSessionState
{
    private UserBll bll;
    public string count = "0";
    private DB_OPT dbo;
    private ExceptionLog.ExceptionLog el;
    private EmployeeModel em;
    protected SmartGridView gvResult;
    public int pageind = 1;
    private PageSizeBll pagesize = new PageSizeBll();
    protected HtmlInputHidden txtindex;
    protected HtmlInputHidden txttitle;

    public void Buttons(string ibtid)
    {
        int selectedIndex = this.gvResult.SelectedIndex;
        switch (ibtid)
        {
            case "ibtcontrol_ibtadd":
                PageShowText.OpenPage("EmployeeAdd.aspx?strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()) + "&reload=MainAddUpdate", 800, 500, this.Page);
                return;

            case "ibtcontrol_ibtupdate":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    PageShowText.OpenPage("EmployeeUpdate.aspx?PK=" + this.gvResult.DataKeys[selectedIndex].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 800, 500, this.Page);
                    return;
                }
                PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
                return;

            case "ibtcontrol_ibtdelete":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    this.DataDelete(this.gvResult.DataKeys[selectedIndex].Value.ToString(), ((Label)this.gvResult.Rows[selectedIndex].FindControl("labBH")).Text, ((Label)this.gvResult.Rows[selectedIndex].FindControl("labName")).Text, ((Label)this.gvResult.Rows[selectedIndex].FindControl("labCompany")).Text, ((Label)this.gvResult.Rows[selectedIndex].FindControl("labBranch")).Text, ((Label)this.gvResult.Rows[selectedIndex].FindControl("labRole")).Text);
                    if (this.Master.PageIndex > 1)
                    {
                        this.pageind = this.Master.PageIndex;
                    }
                    this.ShowData(this.Master.StrSelect);
                    return;
                }
                PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
                return;

            case "ibtcontrol_ibtimpower":
                this.ToBeUser(selectedIndex);
                return;

            case "ibtcontrol_ibtlook":
            case "ibtcontrol_ibtsearch":
            case "ibtcontrol_ibthuizong":
            case "ibtcontrol_ibtputout":
            case "ibtcontrol_ibtexit":
                break;

            case "ibtcontrol_ibtrefresh":
                if (this.Master.PageIndex > 1)
                {
                    this.pageind = this.Master.PageIndex;
                }
                this.ShowData(this.Master.StrSelect);
                return;

            case "ibtcontrol_ibtset":
                this.ToBeUser(selectedIndex);
                break;

            default:
                return;
        }
    }

    private void DataDelete(string strpk, string bh, string name, string company, string branch, string role)
    {
        try
        {
            this.em = new EmployeeDal();
            this.dbo = new DB_OPT();
            this.dbo.Open();
            this.em.EmployeePK = strpk.Trim();
            this.em.Delete(this.dbo);
            OperationLogBll.insertOp("删除", "职员列表", "删除 " + company + " 单位， " + branch + "部门下编号为：" + bh + " 真实姓名为：" + name + " 角色为：" + role + " 的职员", "Y", this.Page);
            this.ShowData(this.Master.StrSelect);
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "DataDelete()";
            this.el.WriteExceptionLog(true);
            Const.OpenErrorPage("操作失败，请联系管理员！", this.Page);
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
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
            string str;
            int num = 0;
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
            if (((str = e.CommandName) != null) && (str != "Select"))
            {
                if (!(str == "Two"))
                {
                    if (str == "Sort")
                    {
                    }
                }
                else if (PowerClass.IfHasPower(userName, power, PowerNum.EmployeeUpdate))
                {
                    num = int.Parse(e.CommandArgument.ToString());
                    PageShowText.OpenPage("EmployeeUpdate.aspx?PK=" + this.gvResult.DataKeys[num].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 800, 500, this.Page);
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
        if (base.Request["strTitle"] != null)
        {
            this.txttitle.Value = base.Server.UrlDecode(base.Request["strTitle"].ToString().Trim());
        }
        this.Master.strTitle = this.txttitle.Value;
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        this.Master.SearchHasGone = new SearchHandler(this.SearchControl);
        this.Master.PageNavigatorChange = new PageNavigatorHandler(this.PageChangControl);
        if (!base.IsPostBack)
        {
            if (this.Session["user"] == null)
            {
                Const.GoLoginPath_List(this.Page);
            }
            else
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
                ButtonsModel model = new ButtonsModel(userName);
                if (PowerClass.IfHasPower(userName, power, PowerNum.EmployeeList))
                {
                    string[] names = new string[] { "Name", "BH" };
                    DataSet searchControlDataSet = Common.GetSearchControlDataSet(names);
                    this.Master.DataSetClo = searchControlDataSet;
                    names[0] = "员工姓名";
                    names[1] = "员工编号";
                    DataSet set2 = Common.GetSearchControlDataSet(names);
                    this.Master.DataSetTable = set2;
                    model.IfAdd = PowerClass.IfHasPower(userName, power, PowerNum.EmployeeAdd);
                    model.IfUpdate = PowerClass.IfHasPower(userName, power, PowerNum.EmployeeUpdate);
                    model.IfDelete = PowerClass.IfHasPower(userName, power, PowerNum.EmployeeDelete);
                    model.IfImpower = PowerClass.IfHasPower(userName, power, PowerNum.UserAdd);
                    model.IfLook = false;
                    model.IfSearch = false;
                    model.IfRefresh = true;
                    model.IfPutOut = false;
                    model.IfHuiZong = false;
                    model.IfSet = false;
                    model.IfExit = true;
                    this.Master.btModel = model;
                }
                else
                {
                    Const.SorryForPower(this.Page);
                }
            }
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
        PageUsuClass.PageChangControl(nPageIndex, "EmployeeList", this.Page);
    }

    private void RefreshPage()
    {
        this.ShowData("");
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
        PageUsuClass.SearchControl(strselect, strcloname, strsql, this.pageind, "EmployeeList", this.Page);
    }

    public void ShowData(string str)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            if ((str != "") && (str != null))
            {
                str = " where " + str + " ";
            }
            DataSet set = this.pagesize.pagesize("*", "gov_tc_view_Employee", str, "EmployeePK", "", this.Master.PageIndex, this.Master.PageSize, out this.count);
            this.Master.RecordCount = Convert.ToInt32(this.count);
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                DataView defaultView = set.Tables[0].DefaultView;
                if ((this.ViewState["SortOrder"] != null) && (this.ViewState["OrderDire"] != null))
                {
                    string str2 = ((string)this.ViewState["SortOrder"]) + " " + ((string)this.ViewState["OrderDire"]);
                    defaultView.Sort = str2;
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

    private void ToBeUser(int index)
    {
        try
        {
            if ((index >= 0) && (this.gvResult.Rows.Count >= index))
            {
                this.dbo = new DB_OPT();
                this.bll = new UserBll();
                this.dbo.Open();
                string str = ((Label)this.gvResult.Rows[index].Cells[5].FindControl("labgspk")).Text.Trim();
                string strdept = ((Label)this.gvResult.Rows[index].Cells[6].FindControl("labbmpk")).Text.Trim();
                string strposition = ((Label)this.gvResult.Rows[index].Cells[7].FindControl("labjspk")).Text.Trim();
                string emppk = ((Label)this.gvResult.Rows[index].Cells[2].FindControl("labemppk")).Text.Trim();
                string strname = ((Label)this.gvResult.Rows[index].Cells[1].FindControl("labBH")).Text.Trim();
                string strtruename = ((Label)this.gvResult.Rows[index].Cells[2].FindControl("labName")).Text.Trim();
                string text = ((Label)this.gvResult.Rows[index].FindControl("labCompany")).Text;
                string str8 = ((Label)this.gvResult.Rows[index].FindControl("labBranch")).Text;
                string str9 = ((Label)this.gvResult.Rows[index].FindControl("labRole")).Text;
                string strpwd = QxRoom.QxConst.QxConst.Encrypt("123456", "powerich").Trim();
                if (this.bll.IfHadData(emppk, this.dbo) <= 0)
                {
                    if (this.bll.adduserinfo(strdept, strposition, emppk, strname, strtruename, strpwd, str, this.dbo) > 0)
                    {
                        PageShowText.ShowMessage_List("授权用户成功！", this.Page);
                        OperationLogBll.insertOp("授权", "职员列表", "授权给 " + text + " 单位， " + str8 + "部门下编号为：" + strname + " 真实姓名为：" + strtruename + " 角色为：" + str9 + " 的职员", "Y", this.Page);
                    }
                }
                else
                {
                    PageShowText.ShowMessage_List("该员工已经授权！", this.Page);
                }
            }
            else
            {
                PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "ToBeUser()";
            this.el.WriteExceptionLog(true);
            Const.OpenErrorPage("操作失败，请联系管理员！", this.Page);
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
