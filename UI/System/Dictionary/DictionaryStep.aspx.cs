using ASP;
using ExceptionLog;
using SoMeTech.DataAccess;
using SoMeTech.User;
using SoMeTech.UsualBookTable;
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

public class DictionaryStep : Page, IRequiresSessionState
{
    public string count = "0";
    private DB_OPT dbo;
    private ExceptionLog.ExceptionLog el;
    protected SmartGridView gvResult;
    protected HtmlInputText ifadd;
    public int pageind = 1;
    private PageSizeBll pagesize = new PageSizeBll();
    protected HtmlInputText tn;
    protected HtmlInputHidden txtindex;
    protected HtmlInputHidden txttitle;
    private UsualBookTableModel ubtm;

    public void Buttons(string ibtid)
    {
        try
        {
            switch (ibtid)
            {
                case "ibtcontrol_ibtadd":
                    PageShowText.OpenPage("newDictionary.aspx?strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()) + "&tn=" + base.Request.QueryString["tn"].ToString() + "&reload=MainAddUpdate", 800, 500, this.Page);
                    return;

                case "ibtcontrol_ibtupdate":
                    {
                        if ((this.gvResult.SelectedIndex < 0) || (this.gvResult.Rows.Count < this.gvResult.SelectedIndex))
                        {
                            break;
                        }
                        string text = ((TextBox)this.gvResult.Rows[this.gvResult.SelectedIndex].FindControl("txtPK")).Text;
                        PageShowText.OpenPage("newDictionary.aspx?strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()) + "&PK=" + text + "&tn=" + base.Request.QueryString["tn"].ToString(), 800, 500, this.Page);
                        return;
                    }
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
                case "ibtcontrol_ibtset":
                case "ibtcontrol_ibtexit":
                    return;

                case "ibtcontrol_ibtrefresh":
                    this.ShowData(this.Master.StrSelect);
                    return;

                default:
                    return;
            }
            PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "Buttons()";
            this.el.WriteExceptionLog(true);
            Const.OpenErrorPage("Request[tn]对象为空！", this.Page);
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
                    this.ubtm = new UsualBookTableDal();
                    this.dbo.Open();
                    this.ubtm.TableName = base.Request.QueryString["tn"].ToString();
                    this.ubtm.PK = ((TextBox)this.gvResult.Rows[this.gvResult.SelectedIndex].Cells[0].FindControl("txtPK")).Text;
                    this.ubtm.Delete(this.dbo);
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
        PageShowText.ShowMessage_List("请先选择一行再删除！", this.Page);
    }

    public void getTitle()
    {
        if (base.Request.QueryString["tn"] != null)
        {
            switch (base.Request.QueryString["tn"].ToString())
            {
                case "GOV_TC_DB_FWType":
                    this.Master.TitlePic = "~/images/页标题/房屋类别列表.jpg";
                    return;

                case "GOV_TC_DB_JZType":
                    this.Master.TitlePic = "~/images/页标题/建筑类别列表.jpg";
                    return;

                case "GOV_TC_DB_JJXZ":
                    this.Master.TitlePic = "~/images/页标题/经济性质列表.jpg";
                    return;

                case "GOV_TC_DB_JZXMXZ":
                    this.Master.TitlePic = "~/images/页标题/建筑项目性质.jpg";
                    return;

                case "GOV_TC_DB_TDType":
                    this.Master.TitlePic = "~/images/页标题/土地类别列表.jpg";
                    return;

                case "GOV_TC_DB_YDXZ":
                    this.Master.TitlePic = "~/images/页标题/用地性质列表.jpg";
                    return;

                case "GOV_TC_DB_FKFS":
                    this.Master.TitlePic = "~/images/页标题/收付款方式.jpg";
                    return;

                case "GOV_TC_DB_OperationPassType":
                    this.Master.TitlePic = "~/images/页标题/多人审批通过方式.jpg";
                    break;

                default:
                    return;
            }
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
            string str;
            int num = 0;
            string str2 = "";
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
            if ((((((str = e.CommandName) != null) && (str != "Select")) && ((str == "Two") && (base.Request["List"] != null))) && (((base.Request["Add"] != null) && (base.Request["Update"] != null)) && ((base.Request["Delete"] != null) && (base.Request["Print"] != null)))) && PowerClass.IfHasPower(userName, power, base.Request["Update"].ToString()))
            {
                num = int.Parse(e.CommandArgument.ToString());
                str2 = this.gvResult.DataKeys[num].Value.ToString();
                PageShowText.OpenPage("newDictionary.aspx?tn=" + base.Request.QueryString["tn"] + "&PK=" + str2 + "&Add=" + base.Request.QueryString["Add"] + "&Update=" + base.Request.QueryString["Update"] + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 800, 500, this.Page);
            }
        }
    }

    protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataListDo.SetGridViewRowDataBound(sender, e);
    }

    protected void gvResult_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataListDo.SetGridViewSorting(sender, e);
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
                if (userName == "admin")
                {
                    model.IfAdd = true;
                    model.IfUpdate = true;
                    model.IfDelete = true;
                    model.IfLook = false;
                    model.IfSearch = false;
                    model.IfRefresh = true;
                    model.IfHuiZong = false;
                    model.IfPutOut = false;
                    model.IfSet = false;
                    model.IfExit = true;
                }
                else if ((((base.Request["List"] != null) && (base.Request["Add"] != null)) && ((base.Request["Update"] != null) && (base.Request["Delete"] != null))) && (base.Request["Print"] != null))
                {
                    if (PowerClass.IfHasPower(userName, power, base.Request["List"].ToString()))
                    {
                        if (PowerClass.IfHasPower(userName, power, base.Request["Add"].ToString()))
                        {
                            model.IfAdd = true;
                        }
                        if (PowerClass.IfHasPower(userName, power, base.Request["Update"].ToString()))
                        {
                            model.IfUpdate = true;
                        }
                        if (PowerClass.IfHasPower(userName, power, base.Request["Delete"].ToString()))
                        {
                            model.IfDelete = true;
                        }
                    }
                    else
                    {
                        Const.SorryForPower_List(this.Page);
                    }
                }
                this.Master.btModel = model;
                this.ubtm = new UsualBookTableDal();
                if (base.Request.QueryString["tn"].ToString() != "")
                {
                    this.ubtm.TableName = base.Request.QueryString["tn"].ToString();
                }
                string[] names = new string[] { "Name", "BH" };
                DataSet searchControlDataSet = Common.GetSearchControlDataSet(names);
                this.Master.DataSetClo = searchControlDataSet;
                names[0] = "名称";
                names[1] = "编号";
                DataSet set2 = Common.GetSearchControlDataSet(names);
                this.Master.DataSetTable = set2;
            }
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
        this.ubtm = new UsualBookTableDal();
        if (base.Request.QueryString["tn"].ToString() != "")
        {
            this.ubtm.TableName = base.Request.QueryString["tn"].ToString();
        }
        PageUsuClass.PageChangControl(nPageIndex, this.ubtm.TableName + "DictionaryStep", this.Page);
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
        this.ubtm = new UsualBookTableDal();
        if (base.Request.QueryString["tn"].ToString() != "")
        {
            this.ubtm.TableName = base.Request.QueryString["tn"].ToString();
        }
        PageUsuClass.SearchControl(strselect, strcloname, strsql, this.pageind, this.ubtm.TableName + "DictionaryStep", this.Page);
    }

    public void ShowData(string str)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.ubtm = new UsualBookTableDal();
            this.dbo.Open();
            if ((base.Request.QueryString["tn"] != null) && (base.Request.QueryString["tn"] != ""))
            {
                this.ubtm.TableName = base.Request.QueryString["tn"].ToString();
                if ((str != "") && (str != null))
                {
                    str = " where " + str + " ";
                }
                DataSet set = this.pagesize.pagesize("*", this.ubtm.TableName, str, "PK", "", this.Master.PageIndex, this.Master.PageSize, out this.count);
                this.Master.RecordCount = Convert.ToInt32(this.count);
                if ((set != null) && (set.Tables[0].Rows.Count > 0))
                {
                    set.Tables[0].Columns.Add(new DataColumn("FatherName", Type.GetType("System.String")));
                    DataSet list = new DataSet();
                    list = this.ubtm.GetList("", this.dbo);
                    foreach (DataRow row in set.Tables[0].Rows)
                    {
                        if ((row["FatherPK"].ToString().Trim() == "0") || (row["FatherPK"].ToString() == ""))
                        {
                            row["FatherName"] = "无";
                        }
                        else
                        {
                            DataRow[] rowArray = list.Tables[0].Select("PK='" + row["FatherPK"].ToString().Trim() + "'");
                            if ((rowArray != null) && (rowArray.Length > 0))
                            {
                                row["FatherName"] = rowArray[0]["Name"];
                            }
                        }
                    }
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
                    set.Tables[0].Columns.Add(new DataColumn("FatherName", Type.GetType("System.String")));
                    foreach (DataRow row2 in set.Tables[0].Rows)
                    {
                        row2["FatherName"] = "无";
                    }
                    DataRow row3 = table.NewRow();
                    table.Rows.Add(row3);
                    this.gvResult.DataSource = table.DefaultView;
                    this.gvResult.DataBind();
                }
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
