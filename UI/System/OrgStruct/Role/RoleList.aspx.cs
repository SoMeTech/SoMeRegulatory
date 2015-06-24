using ASP;
using ExceptionLog;
using SoMeTech.Company;
using SoMeTech.Company.Branch;
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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using YYControls;

public class Role_RoleList : MainPageClass, IRequiresSessionState
{
    public string count = "0";
    private DB_OPT dbo;
    protected DropDownList ddlbranch;
    protected DropDownList ddlcompany;
    private ExceptionLog.ExceptionLog el;
    protected SmartGridView gvResult;
    public int pageind = 1;
    private PageSizeBll pagesize = new PageSizeBll();
    private RoleModel rm;
    protected HtmlInputHidden txtindex;
    protected HtmlInputHidden txttitle;

    private void BindList(DB_OPT dbo)
    {
        CompanyModel[] modelArray = new CompanyDal().GetModels("", false, false, false, dbo);
        this.ddlcompany.DataSource = modelArray;
        this.ddlcompany.DataTextField = "Name";
        this.ddlcompany.DataValueField = "pk_corp";
        this.ddlcompany.DataBind();
        BranchModel[] modelArray2 = new BranchDal().GetModels("", false, false, false, false, dbo);
        this.ddlbranch.DataSource = modelArray2;
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
                PageShowText.OpenPage("RoleAdd.aspx?strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()) + "&reload=MainAddUpdate", 800, 500, this.Page);
                return;

            case "ibtcontrol_ibtupdate":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    PageShowText.OpenPage("RoleUpdate.aspx?PK=" + this.gvResult.DataKeys[selectedIndex].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 800, 500, this.Page);
                    return;
                }
                PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
                return;

            case "ibtcontrol_ibtdelete":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    this.DataDelete(this.gvResult.DataKeys[selectedIndex].Value.ToString(), ((Label)this.gvResult.Rows[selectedIndex].FindControl("LbType")).Text, ((Label)this.gvResult.Rows[selectedIndex].FindControl("Label1")).Text, ((Label)this.gvResult.Rows[selectedIndex].FindControl("Lbpk_corp")).Text, ((Label)this.gvResult.Rows[selectedIndex].FindControl("LbBranchPK")).Text);
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

    private void DataDelete(string strPK, string bh, string name, string company, string branch)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            this.rm = new RoleDal();
            this.rm.RolePK = strPK;
            this.rm.Delete(this.dbo);
            OperationLogBll.insertOp("删除", "角色列表", "删除 " + company + " 单位， " + branch + "部门下编号为：" + bh + " 名称为：" + name + " 的角色", "Y", this.Page);
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

    public string GetBranch(string str)
    {
        if ((str.Trim() != "") && (str.Trim() != "0"))
        {
            try
            {
                this.ddlbranch.SelectedValue = str.Trim();
                return this.ddlbranch.SelectedItem.Text;
            }
            catch (Exception)
            {
                return "";
            }
        }
        return "";
    }

    public string Getpk_corp(string str)
    {
        if ((str.Trim() != "") && (str.Trim() != "0"))
        {
            try
            {
                this.ddlcompany.SelectedValue = str;
                return this.ddlcompany.SelectedItem.Text;
            }
            catch (Exception)
            {
                return "";
            }
        }
        return "";
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
                    this.gvResult.DataKeys[num].Value.ToString();
                    return;
                }
                if (PowerClass.IfHasPower(userName, power, PowerNum.RoleUpdate))
                {
                    num = int.Parse(e.CommandArgument.ToString());
                    PageShowText.OpenPage("RoleUpdate.aspx?PK=" + this.gvResult.DataKeys[num].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 800, 500, this.Page);
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
        if (!this.Page.IsPostBack)
        {
            if (this.Session["user"] != null)
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
                ButtonsModel model = new ButtonsModel(userName);
                if (PowerClass.IfHasPower(userName, power, PowerNum.RoleList))
                {
                    try
                    {
                        try
                        {
                            string[] names = new string[] { "Name", "BH" };
                            DataSet searchControlDataSet = Common.GetSearchControlDataSet(names);
                            this.Master.DataSetClo = searchControlDataSet;
                            names[0] = "角色名称";
                            names[1] = "角色编号";
                            DataSet set2 = Common.GetSearchControlDataSet(names);
                            this.Master.DataSetTable = set2;
                            this.dbo = new DB_OPT();
                            this.dbo.Open();
                            this.BindList(this.dbo);
                            if (PowerClass.IfHasPower(userName, power, PowerNum.RoleAdd))
                            {
                                model.IfAdd = true;
                            }
                            if (PowerClass.IfHasPower(userName, power, PowerNum.RoleUpdate))
                            {
                                model.IfUpdate = true;
                            }
                            if (PowerClass.IfHasPower(userName, power, PowerNum.RoleDelete))
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
                            this.el.ErrMethod = "bind()";
                            this.el.WriteExceptionLog(true);
                            Const.OpenErrorPage("获取数据失败，请联系管理员！", this.Page);
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
        PageUsuClass.PageChangControl(nPageIndex, "RoleList", this.Page);
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
        PageUsuClass.SearchControl(strselect, strcloname, strsql, this.pageind, "RoleList", this.Page);
    }

    public string SetIsUser(string strIsUser)
    {
        if (strIsUser == "1")
        {
            return "启用";
        }
        return "不启用";
    }

    public void ShowData(string str)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            if (str != "")
            {
                str = " where " + str + " ";
            }
            DataSet set = this.pagesize.pagesize("*", "DB_Role", str, "RolePK", " order by BH ", this.Master.PageIndex, this.Master.PageSize, out this.count);
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
                this.rm = new RoleDal();
                DataTable table = new DataTable();
                table = this.rm.GetList("RolePK=''", this.dbo).Tables[0];
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                this.gvResult.DataSource = table.DefaultView;
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
