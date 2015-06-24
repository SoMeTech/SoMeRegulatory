using SoMeTech.YZXWPageClass;
using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using YYControls;
using SoMeTech.DataAccess;
using QxRoom.Common.ControlDo;
using System.Web;
using SoMeTech.User;
using System.Web.UI.HtmlControls;
using SoMeTech.CommonDll;
public partial class Work_JCZLWH_gnfl : Page, IRequiresSessionState
{
    protected SmartGridView gvResult;
    private ExceptionLog.ExceptionLog el;
    private DB_OPT dbo;
    public string count = "0";
    public int pageind = 1;
    protected HtmlInputHidden txtindex;
    protected HtmlInputHidden txttitle;
    private PageSizeBll pagesize = new PageSizeBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session["user"] != null)
        {
            if (base.Request["strTitle"] != null)
            {
                this.txttitle.Value = base.Server.UrlDecode(base.Request["strTitle"].ToString().Trim());
            }
            this.Master.strTitle = this.txttitle.Value;
            this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
            this.Master.PageNavigatorChange = new PageNavigatorHandler(this.PageChangControl);
            this.Master.gvGridView = this.gvResult;
            if (!this.Page.IsPostBack)
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
                
                try
                {
                    ButtonsModel model = null;
                    PublicDal.ShowListButton(this.Page, out model, "");
                    model.IbtDoText = "查看";
                    model.IfPrintNote = true;
                    model.IbtPrintNoteText = "打印";
                    this.Master.btModel = model;
                    this.ShowData("");
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
        }
        else
        {
            Const.GoLoginPath_List(this.Page);
        }
    }
    public void Buttons(string ibtid)
    {
        int selectedIndex = this.gvResult.SelectedIndex;
        switch (ibtid)
        {        
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
    protected void PageChangControl(object sender, int nPageIndex)
    {
        PageUsuClass.PageChangControl(nPageIndex, "gl_fzxzl ", this.Page);
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
    public void ShowData(string str)
    {
        try
        {
            string year = HttpContext.Current.Request.Cookies["YearND"].Value.ToString();
            this.dbo = new DB_OPT();
            this.dbo.Open();
        
                str = " where lbdm=4 and substr(fzdm,1,1)='2' and gsdm='" + year + "'";
         
                
            DataSet set = this.pagesize.pagesize(GetColsName(), "gl_fzxzl ", str, "fzdm", " order by fzdm ", this.Master.PageIndex, this.Master.PageSize, out this.count);
            this.Master.RecordCount = Convert.ToInt32(this.count);
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                DataTable table = set.Tables[0];
                DataColumn dc = new DataColumn();
                dc.ColumnName = "LEVEL";
                dc.Expression = "(len(trim(fzdm))-1)/2";
                table.Columns.Add(dc);
                DataColumn dc2 = new DataColumn();
                dc2.ColumnName = "PID";
                dc2.Expression = "iif(len(trim(fzdm))=3,'0',substring(fzdm,1,len(trim(fzdm))-2))";
                table.Columns.Add(dc2);
                DataColumn dc3 = new DataColumn();
                dc3.ColumnName = "FZDMM";
                dc3.Expression = "FZDM+'-'+FZMC";
                table.Columns.Add(dc3);
                this.gvResult.DataSource = table;
                this.gvResult.DataBind();
              
            }
            else
            {
                DataTable table3 = new DataTable();


                this.gvResult.DataSource = table3.DefaultView;
                this.gvResult.DataBind();
            }
            //PublicDal.setGridKeepAll(this.gvResult);
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

    public static string GetColsName()
    {
        //return "fzdm,(length(trim(fzdm))-1)/2 LEVEL,(case when length(trim(fzdm))>3 then substr(fzdm,1,length(trim(fzdm))-2) else '0' end ) PID,FZDM||-||fzmc FZMC";
        return "fzdm,fzmc";
    }
    public MainOne Master
    {
        get
        {
            return (MainOne)base.Master;
        }
    }
    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        
    }
}
