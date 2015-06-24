using ASP;
using SoMeTech.CommonDll;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using YYControls;
using SMZJ.BLL;
public class Work_FaGui_messback : Page, IRequiresSessionState
{
    private MESS_BACK_Bll B_mesback = new MESS_BACK_Bll();
    private UserBll bll = new UserBll();
    public string count = "0";
    private DB_OPT dbo;
    private ExceptionLog.ExceptionLog el;
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
                PageShowText.OpenPage("messbackoper.aspx?strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()) + "&reload=MainAddUpdate", null, null, this.Page);
                return;

            case "ibtcontrol_ibtupdate":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    PageShowText.OpenPage("messbackoper.aspx?PK=" + this.gvResult.DataKeys[selectedIndex].Value.ToString() + "&reload=MainAddUpdate&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), null, null, this.Page);
                    return;
                }
                PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
                return;

            case "ibtcontrol_ibtdelete":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    this.DataDelete(this.gvResult.DataKeys[selectedIndex].Value.ToString());
                    return;
                }
                PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
                return;

            case "ibtcontrol_ibtlook":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    PageShowText.OpenPage("messbackoper.aspx?PK=" + this.gvResult.DataKeys[selectedIndex].Value.ToString() + "&reload=MainAddUpdate&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), null, null, this.Page);
                    return;
                }
                PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
                return;

            case "ibtcontrol_ibtdo":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    PageShowText.OpenPage("messbackoper.aspx?PK=" + this.gvResult.DataKeys[selectedIndex].Value.ToString() + "&reload=MainAddUpdate&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), null, null, this.Page);
                    return;
                }
                PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
                return;

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

    private void DataDelete(string UserPK)
    {
        if (PublicDal.IsDelete(this.Page, "mess_back", "MES_ID", UserPK, "PD_NOW_SERVERPK"))
        {
            if (this.B_mesback.Delete(UserPK))
            {
                if (this.Master.PageIndex > 1)
                {
                    this.pageind = this.Master.PageIndex;
                }
                this.ShowData(this.Master.StrSelect);
                PageShowText.ShowMessage("删除成功!", this.Page);
            }
            else
            {
                PageShowText.ShowMessage("删除失败,没有找到数据.", this.Page);
            }
        }
        else
        {
            PageShowText.ShowMessage("单据已进入业务流程，需删除请追回单据后再进行删除。", this.Page);
        }
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
                if (PowerClass.IfHasPower(userName, power, PowerNum.UserUpdate))
                {
                    num = int.Parse(e.CommandArgument.ToString());
                    PageShowText.OpenPage("UserUpdate.aspx?PK=" + this.gvResult.DataKeys[num].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 800, 500, this.Page);
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
        this.txttitle.Value = "信息反馈列表";
        this.Master.strTitle = this.txttitle.Value;
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        this.Master.SearchHasGone = new SearchHandler(this.SearchControl);
        this.Master.PageNavigatorChange = new PageNavigatorHandler(this.PageChangControl);
        this.Master.gvGridView = this.gvResult;
        if (!base.IsPostBack)
        {
            if (this.Session["user"] != null)
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
                ButtonsModel model = null;
                string[] names = new string[] { "PD_PROJECT_SUBJECTS" };
                DataSet searchControlDataSet = Common.GetSearchControlDataSet(names);
                this.Master.DataSetClo = searchControlDataSet;
                names[0] = "标题";
                DataSet set2 = Common.GetSearchControlDataSet(names);
                this.Master.DataSetTable = set2;
                PublicDal.ShowListButton(this.Page, out model, "");
                this.Master.btModel = model;
                model.IbtDoText = "查看";
            }
            else
            {
                Const.GoLoginPath_List(this.Page);
            }
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
        PageUsuClass.PageChangControl(nPageIndex, "v_mess_back", this.Page);
    }

    private void PageRefresh()
    {
        this.ShowData(this.Master.StrSelect);
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
        PageUsuClass.SearchControl(strselect, strcloname, strsql, this.pageind, "v_mess_back", this.Page);
    }

    public void ShowData(string str)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            UserModel model = (UserModel)HttpContext.Current.Session["User"];
            string lastStream = model.GetLastStream(this.Page, this.dbo);
            model.UserName = model.UserName;
            model.GetModel(this.dbo);
            string[] strArray = model.CompanyPower.Split(new char[] { '|' });
            string strwhere = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].Trim().Length != 0)
                {
                    strwhere = strwhere + strArray[i].Trim();
                    if (i < (strArray.Length - 1))
                    {
                        strwhere = strwhere + "','";
                    }
                }
            }
            if (strwhere != "")
            {
                strwhere = "'" + strwhere + "'";
                strwhere = " where ((mes_company in (" + strwhere + ") and pd_now_serverpk='" + lastStream + "') or trim(mes_company)='" + model.Company.pk_corp.Trim() + "' or PD_QUOTA_DEPART='" + model.Branch.BH + "')";
            }
            else
            {
                strwhere = " where (trim(mes_company)='" + model.Company.pk_corp.Trim() + "' or PD_QUOTA_DEPART='" + model.Branch.BH + "')";
            }
            if (!string.IsNullOrEmpty(str))
            {
                strwhere = strwhere + " and " + str;
            }
            DataSet set = this.pagesize.pagesize("*", "v_mess_back", strwhere, "MES_ID", " order by MES_ID desc", this.Master.PageIndex, this.Master.PageSize, out this.count);
            this.Master.RecordCount = Convert.ToInt32(this.count);
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                DataView defaultView = set.Tables[0].DefaultView;
                if ((this.ViewState["SortOrder"] != null) && (this.ViewState["OrderDire"] != null))
                {
                    string str4 = ((string)this.ViewState["SortOrder"]) + " " + ((string)this.ViewState["OrderDire"]);
                    defaultView.Sort = str4;
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
