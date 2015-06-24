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

public class Work_PublicReportWH_PublicReportWHList : Page, IRequiresSessionState
{
    public string count = "0";
    private DB_OPT dbo;
    private ExceptionLog.ExceptionLog el;
    protected SmartGridView gvResult;
    public int pageind = 1;
    private PageSizeBll pagesize = new PageSizeBll();
    protected HtmlInputHidden txtindex;
    protected HtmlInputHidden txttitle;
    protected UpdatePanel UpdatePanel1;

    public void Buttons(string ibtid)
    {
        int selectedIndex = this.gvResult.SelectedIndex;
        switch (ibtid)
        {
            case "ibtcontrol_ibtadd":
                PageShowText.OpenPage("PublicReportWHMx.aspx", 0x556, 0x300, this.Page);
                break;

            case "ibtcontrol_ibtupdate":
                break;

            case "ibtcontrol_ibtdelete":
                {
                    string text = this.gvResult.DataKeys[selectedIndex].Value.ToString();
                    if (PublicDal.PageValidate.IsNumber(text))
                    {
                        this.DataDelete(text);
                    }
                    return;
                }
            case "ibtcontrol_ibtdo":
                if ((selectedIndex < 0) || (this.gvResult.Rows.Count < selectedIndex))
                {
                    PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
                    return;
                }
                PageShowText.OpenPage("PublicReportWHMx.aspx?UpdatePK=" + this.gvResult.DataKeys[selectedIndex].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 0x556, 0x300, this.Page);
                return;

            case "ibtcontrol_ibtlook":
            case "ibtcontrol_ibtsearch":
            case "ibtcontrol_ibtputout":
            case "ibtcontrol_ibtset":
            case "ibtcontrol_ibtexit":
                return;

            case "ibtcontrol_ibthuizong":
                PageShowText.Run_javascript("window.parent.tbSaveExcel('" + this.Master.strTitle + "','" + this.gvResult.ClientID + "',window);", this.Page);
                return;

            case "ibtcontrol_ibtrefresh":
                if (this.Master.PageIndex > 1)
                {
                    this.pageind = this.Master.PageIndex;
                }
                this.ShowData(this.Master.StrSelect);
                return;

            default:
                return;
        }
    }

    private void DataDelete(string strPK)
    {
        try
        {
            new PD_PROJECT_CONTRACT_Bll().Delete(strPK);
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
    }

    private string getColumns()
    {
        return " auto_no, pd_project_code,PD_PROJECT_NAME, pd_contract_type, pd_contract_no, pd_contract_date, pd_contract_company, pd_contract_moeny, pd_contract_moeny_change, pd_contract_ask_limit, pd_contract_ask_proceed, pd_contract_ask_payment, pd_contract_note, pd_contract_filename, pd_contract_filename_system, pd_contract_name ";
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
                    PageShowText.OpenPage("PublicReportWHMx.aspx?UpdatePK=" + this.gvResult.DataKeys[num].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 0x556, 0x300, this.Page);
                }
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
        PageUsuClass.PageChangControl(nPageIndex, "tb_project", this.Page);
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
        PageUsuClass.SearchControl(strselect, strcloname, strsql, this.pageind, "tb_project", this.Page);
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
                str = " where " + str + " and  pd_found_xz='01' " + companyWhere;
            }
            else
            {
                str = "where  pd_found_xz='01' " + companyWhere;
            }
            DataSet set = this.pagesize.pagesize(this.getColumns(), "view_contract_list", str, "pd_project_code", " order by pd_project_code,auto_no desc ", this.Master.PageIndex, this.Master.PageSize, out this.count);
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
