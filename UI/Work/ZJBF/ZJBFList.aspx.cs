using ASP;
using ExceptionLog;
using SoMeTech.CommonDll;
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
using SMZJ.BLL;

public partial class Work_ZJBF_ZJBFList : Page, IRequiresSessionState
{
    private UserBll bll = new UserBll();
    public string count = "0";
    private DB_OPT dbo;
    private ExceptionLog.ExceptionLog el;
    protected SmartGridView gvResult;
    public int pageind = 1;
    private PageSizeBll pagesize = new PageSizeBll();
    protected HtmlInputHidden txtindex;
    protected HtmlInputHidden txttitle;
    protected UpdatePanel UpdatePanel1;

    private void BindList()
    {
        DataSet list = new PD_FOUND_OUT_Bll().GetList("");
        if ((list != null) && (list.Tables.Count > 0))
        {
            this.gvResult.DataSource = list.Tables[0];
            this.gvResult.DataBind();
        }
    }

    public void Buttons(string ibtid)
    {
        int selectedIndex = this.gvResult.SelectedIndex;
        switch (ibtid)
        {
            case "ibtcontrol_ibtadd":
                PageShowText.OpenPage("ZJBFOper.aspx?strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), null, null, this.Page);
                return;

            case "ibtcontrol_ibtdo":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    PageShowText.OpenPage("ZJBFOper.aspx?UpdatePK=" + this.gvResult.DataKeys[selectedIndex].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), null, null, this.Page);
                    return;
                }
                PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
                return;

            case "ibtcontrol_ibtdelete":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    this.DataDelete(this.gvResult.DataKeys[selectedIndex].Value.ToString(), "", "", "", "");
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
            if (PublicDal.IsDelete(this.Page, "PD_FOUND_OUT", "AUTO_NO", strPK, "PD_NOW_SERVERPK"))
            {
                new PD_FOUND_OUT_Bll().Delete(Convert.ToInt32(strPK));
                if (this.Master.PageIndex > 1)
                {
                    this.pageind = this.Master.PageIndex;
                }
                this.ShowData(this.Master.StrSelect);
            }
            else
            {
                PageShowText.ShowMessage("单据已进入业务流程，需删除请追回单据后再进行删除。", this.Page);
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
    }

    public DataTable dbDataTableAddXuHao(DataTable dt, string colXuHao)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i][colXuHao] = i + 1;
        }
        return dt;
    }

    public string GetBranch(string str)
    {
        return "";
    }

    public string Getpk_corp(string str)
    {
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
                    PageShowText.OpenPage("ZJBFOper.aspx?UpdatePK=" + this.gvResult.DataKeys[num].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 0x556, 0x300, this.Page);
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
        this.Master.gvGridView = this.gvResult;
        if (!this.Page.IsPostBack)
        {
            if (this.Session["user"] != null)
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
                try
                {
                    this.BindList();
                    ButtonsModel model = null;
                    PublicDal.ShowListButton(this.Page, out model, "");
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
            }
            else
            {
                Const.GoLoginPath_List(this.Page);
            }
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
        PageUsuClass.PageChangControl(nPageIndex, "PD_FOUND_OUT", this.Page);
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
        PageUsuClass.SearchControl(strselect, strcloname, strsql, this.pageind, "PD_FOUND_OUT", this.Page);
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
            string companyWhere = PublicDal.GetCompanyWhere();
            if (str != "")
            {
                str = " where " + str + companyWhere;
            }
            else
            {
                str = " where 1=1" + companyWhere;
            }
            DataSet ds = this.pagesize.pagesize("*", "v_pd_found_out_list", str, "auto_no", "", this.Master.PageIndex, this.Master.PageSize, out this.count);
            this.Master.RecordCount = Convert.ToInt32(this.count);
            if (this.gvResult.Columns.Count == 0)
            {
                PublicDal.setGViewColumns(ds, this.gvResult);
                DataSet dataSetClo = null;
                DataSet dataSetTable = null;
                PublicDal.GetSelectTJ(this.gvResult, ref dataSetClo, ref dataSetTable, null);
                this.Master.DataSetClo = dataSetClo;
                this.Master.DataSetTable = dataSetTable;
            }
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                PublicDal.NewTotalMoneyRow(ds);
                DataView defaultView = ds.Tables[0].DefaultView;
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
                table = ds.Tables[0];
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
