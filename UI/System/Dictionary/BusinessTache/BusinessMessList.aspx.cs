﻿using ASP;
using ExceptionLog;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.ServicesClass.Operation;
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

public class SystemSetup_Dictionary_BusinessMessList : Page, IRequiresSessionState
{
    private BusinessMessModel bmm;
    public string count = "0";
    private DB_OPT dbo;
    private ExceptionLog.ExceptionLog el;
    protected SmartGridView gvResult;
    public int pageind = 1;
    private PageSizeBll pagesize = new PageSizeBll();
    protected ScriptManagerProxy ScriptManagerProxy1;
    protected HtmlInputHidden txtindex;
    protected HtmlInputHidden txttitle;
    protected UpdatePanel UpdatePanel1;

    public void Buttons(string ibtid)
    {
        int selectedIndex = this.gvResult.SelectedIndex;
        string str = "";
        switch (ibtid)
        {
            case "ibtcontrol_ibtadd":
                PageShowText.OpenPage("NewBusinessMess.aspx?strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()) + "&reload=MainAddUpdate", 800, 500, this.Page);
                return;

            case "ibtcontrol_ibtupdate":
                if ((this.gvResult.SelectedIndex >= 0) && (this.gvResult.Rows.Count >= this.gvResult.SelectedIndex))
                {
                    PageShowText.OpenPage("NewBusinessMess.aspx?PK=" + ((Label)this.gvResult.Rows[this.gvResult.SelectedIndex].FindControl("labPk")).Text.Trim() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 800, 500, this.Page);
                    return;
                }
                Const.ShowMessage("请选择一行数据再操作！", this.Page);
                return;

            case "ibtcontrol_ibtdelete":
                this.delete();
                if (this.Master.PageIndex > 1)
                {
                    this.pageind = this.Master.PageIndex;
                }
                this.ShowData(this.Master.StrSelect);
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
                if (selectedIndex >= 0)
                {
                    str = this.gvResult.DataKeys[selectedIndex].Value.ToString();
                    string s = this.gvResult.Rows[selectedIndex].Cells[2].Text.Trim();
                    try
                    {
                        try
                        {
                            this.dbo = new DB_OPT();
                            this.dbo.Open();
                            OperationModel model = new OperationDal
                            {
                                OperationPK = str
                            };
                            model = model.GetModel(this.dbo);
                            string str3 = "";
                            if (model != null)
                            {
                                str3 = Public.RelativelyPath("GlobalSet/Services/OperationFlowUpdate.aspx");
                            }
                            else
                            {
                                str3 = Public.RelativelyPath("GlobalSet/Services/OperationFlowAdd.aspx");
                            }
                            PageShowText.OpenPage(str3 + "?PK=" + str + "&TopPK=&name=" + base.Server.UrlEncode(s), 800, 500, this.Page);
                        }
                        catch (Exception exception)
                        {
                            this.el = new ExceptionLog.ExceptionLog();
                            this.el.ErrClassName = base.GetType().ToString();
                            this.el.ErrMessage = exception.Message.ToString();
                            this.el.ErrMethod = "ibtcontrol_ibtset()";
                            this.el.WriteExceptionLog(true);
                            Const.OpenErrorPage("操作失败，请联系系统管理员！", this.Page);
                        }
                        break;
                    }
                    finally
                    {
                        if (this.dbo != null)
                        {
                            this.dbo.Close();
                        }
                    }
                }
                Const.ShowMessage("请选择一行数据再操作！", this.Page);
                break;

            default:
                return;
        }
    }

    public void delete()
    {
        if ((this.gvResult.SelectedIndex >= 0) && (this.gvResult.Rows.Count >= this.gvResult.SelectedIndex))
        {
            try
            {
                try
                {
                    this.dbo = new DB_OPT();
                    this.bmm = new BusinessMessDal();
                    this.bmm.PK = ((Label)this.gvResult.Rows[this.gvResult.SelectedIndex].FindControl("labPk")).Text;
                    this.dbo.Open();
                    this.bmm.Delete(this.dbo);
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
        Const.ShowMessage("请选择一行数据再操作！", this.Page);
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
                else if (PowerClass.IfHasPower(userName, power, PowerNum.SFType))
                {
                    num = int.Parse(e.CommandArgument.ToString());
                    PageShowText.OpenPage("NewBusinessMess.aspx?PK=" + this.gvResult.DataKeys[num].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 800, 500, this.Page);
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
                ButtonsModel model = new ButtonsModel(userName);
                if (PowerClass.IfHasPower(userName, power, PowerNum.BusinessMessList))
                {
                    if (PowerClass.IfHasPower(userName, power, PowerNum.BusinessMessAdd))
                    {
                        model.IfAdd = true;
                    }
                    if (PowerClass.IfHasPower(userName, power, PowerNum.BusinessMessUpdate))
                    {
                        model.IfUpdate = true;
                    }
                    if (PowerClass.IfHasPower(userName, power, PowerNum.BusinessMessDelete))
                    {
                        model.IfDelete = true;
                    }
                    model.IfLook = false;
                    model.IfSearch = false;
                    model.IfRefresh = true;
                    model.IfHuiZong = false;
                    model.IfSet = true;
                    model.IfExit = true;
                    this.Master.btModel = model;
                    string[] names = new string[] { "Name", "OprateOrder" };
                    DataSet searchControlDataSet = Common.GetSearchControlDataSet(names);
                    this.Master.DataSetClo = searchControlDataSet;
                    names[0] = "业务环节名称";
                    names[1] = "办理顺序";
                    DataSet set2 = Common.GetSearchControlDataSet(names);
                    this.Master.DataSetTable = set2;
                }
                else
                {
                    Const.SorryForPower_List(this.Page);
                }
            }
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
        PageUsuClass.PageChangControl(nPageIndex, "BusinessMessList", this.Page);
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
        PageUsuClass.SearchControl(strselect, strcloname, strsql, this.pageind, "BusinessMessList", this.Page);
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
            DataSet set = this.pagesize.pagesize(" * ", "GOV_TC_DB_OPRATETACHE", str, "PK", "", this.Master.PageIndex, this.Master.PageSize, out this.count);
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
