using ASP;
using ExceptionLog;
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

public class Operation_OperationLogList : Page, IRequiresSessionState
{
    public string count = "0";
    private DB_OPT dbo;
    private ExceptionLog.ExceptionLog el;
    protected SmartGridView gvOpList;
    public int pageind = 1;
    private PageSizeBll pagesize = new PageSizeBll();
    protected HtmlInputHidden txtindex;
    protected HtmlInputHidden txttitle;

    public void Buttons(string ibtid)
    {
        int selectedIndex = this.gvOpList.SelectedIndex;
        string str = ibtid;
        switch (str)
        {
            case null:
                break;

            case "ibtcontrol_ibtdelete":
                this.delete();
                return;

            default:
                if (str != "ibtcontrol_ibtlook")
                {
                    if (!(str == "ibtcontrol_ibtrefresh"))
                    {
                        bool flag1 = str == "ibtcontrol_ibtexit";
                        return;
                    }
                    this.ShowData(this.Master.StrSelect);
                    return;
                }
                if ((selectedIndex >= 0) && (selectedIndex <= this.gvOpList.Rows.Count))
                {
                    OpenServices.OpenPage("OperationLogLook.aspx?PK=" + this.gvOpList.DataKeys[selectedIndex].Value.ToString(), 800, 500, this.Page);
                    return;
                }
                Const.ShowMessage("请先选择一行再修改！", this.Page);
                break;
        }
    }

    public void delete()
    {
        try
        {
            if (this.gvOpList.SelectedIndex < 0)
            {
                Const.ShowMessage_List("请选择一行再删除！", this.Page);
            }
            else
            {
                OperationLogBll.deleteOp(((Label)this.gvOpList.Rows[this.gvOpList.SelectedIndex].Cells[0].FindControl("labopPk")).Text.Trim(), this.Page);
                this.ShowData(this.Master.StrSelect);
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "delete()";
            this.el.WriteExceptionLog(true);
            Const.OpenErrorPage("操作失败，请联系系统管理员！", this.Page);
        }
    }

    protected void gvOpList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string str;
        int num = 0;
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
        if ((((str = e.CommandName) != null) && !(str == "Select")) && !(str == "Two"))
        {
            bool flag1 = str == "Sort";
        }
    }

    protected void gvOpList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i <= this.gvOpList.Rows.Count; i++)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#8C9FF0'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
        }
    }

    protected void gvOpList_Sorting(object sender, GridViewSortEventArgs e)
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
                Const.GoLoginPath_Open(this.Page);
            }
            else
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                ButtonsModel model = new ButtonsModel(userName);
                if (PowerClass.IfHasPower(userName, power, PowerNum.OperationLogList))
                {
                    PowerClass.IfHasPower(userName, power, PowerNum.OperationLogPrint);
                    PowerClass.IfHasPower(userName, power, PowerNum.OperationLogDelete);
                    string[] names = new string[] { "UserName", "opTime" };
                    DataSet searchControlDataSet = Common.GetSearchControlDataSet(names);
                    this.Master.DataSetClo = searchControlDataSet;
                    names[0] = "操作人";
                    names[1] = "操作时间";
                    DataSet set2 = Common.GetSearchControlDataSet(names);
                    this.Master.DataSetTable = set2;
                    model.IfLook = true;
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
        PageUsuClass.PageChangControl(nPageIndex, "OperationLogList", this.Page);
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
        PageUsuClass.SearchControl(strselect, strcloname, strsql, this.pageind, "OperationLogList", this.Page);
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
            DataSet set = this.pagesize.pagesize("*", "DB_OPERATIONLOG", str, "PK", "", this.Master.PageIndex, this.Master.PageSize, out this.count);
            this.Master.RecordCount = Convert.ToInt32(this.count);
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                DataView defaultView = set.Tables[0].DefaultView;
                if ((this.ViewState["SortOrder"] != null) && (this.ViewState["OrderDire"] != null))
                {
                    string str2 = ((string)this.ViewState["SortOrder"]) + " " + ((string)this.ViewState["OrderDire"]);
                    defaultView.Sort = str2;
                }
                this.gvOpList.DataSource = defaultView;
                this.gvOpList.DataBind();
            }
            else
            {
                DataTable table = new DataTable();
                table = set.Tables[0];
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                this.gvOpList.DataSource = table.DefaultView;
                this.gvOpList.DataBind();
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
