using ASP;
using ExceptionLog;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
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

public class Menu_MenuList : MainPageClass, IRequiresSessionState
{
    public string count = "0";
    private DB_OPT dbo;
    protected DropDownList ddlgl;
    private ExceptionLog.ExceptionLog el;
    protected SmartGridView gvResult;
    private MenuModel mm;
    public int pageind = 1;
    protected ScriptManagerProxy ScriptManagerProxy1;
    protected HtmlInputHidden txtindex;
    protected HtmlInputHidden txttitle;
    protected UpdatePanel UpdatePanel1;

    private void BindDrop(DB_OPT dbo)
    {
        this.mm = new MenuDal();
        MenuModel[] modelArray = this.mm.GetModels("", false, dbo);
        this.ddlgl.DataSource = modelArray;
        this.ddlgl.DataTextField = "MenuName";
        this.ddlgl.DataValueField = "MemuPK";
        this.ddlgl.DataBind();
    }

    public void Buttons(string ibtid)
    {
        int selectedIndex = this.gvResult.SelectedIndex;
        switch (ibtid)
        {
            case "ibtcontrol_ibtadd":
                PageShowText.OpenPage("MenuAdd.aspx?strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 800, 500, this.Page);
                return;

            case "ibtcontrol_ibtupdate":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    PageShowText.OpenPage("MenuUpdate.aspx?PK=" + this.gvResult.DataKeys[selectedIndex].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 800, 500, this.Page);
                    return;
                }
                PageShowText.ShowMessage_List("请选择一行再操作！", this.Page);
                return;

            case "ibtcontrol_ibtdelete":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    this.DataDelete(this.gvResult.DataKeys[selectedIndex].Value.ToString());
                    if (this.Master.PageIndex > 1)
                    {
                        this.pageind = this.Master.PageIndex;
                    }
                    this.ShowData(this.Master.StrSelect);
                    return;
                }
                PageShowText.ShowMessage_List("请选择一行再操作！", this.Page);
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

    private void DataDelete(string strPK)
    {
        try
        {
            this.mm = new MenuDal();
            this.dbo = new DB_OPT();
            this.dbo.Open();
            this.mm = new MenuDal();
            this.mm.MemuPK = strPK;
            this.mm.Delete(this.dbo);
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "DataDelete()";
            this.el.WriteExceptionLog(true);
            PageShowText.OpenErrorPage("操作失败，请联系系统管理员！", this.Page);
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
    }

    private void DataUpdate(string strPK)
    {
        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "open", "window.open('MenuUpdate.aspx?MenuPK=" + strPK + "','','toolbar=no,status=no,resizable=no,width=800px,height=600px,scrollbars=no,location=no');", true);
    }

    public string GetFather(string pk)
    {
        return Common.GetDDLsText(this.ddlgl, pk);
    }

    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
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
                if (!(commandName == "two"))
                {
                    return;
                }
            }
            else
            {
                this.gvResult.DataKeys[num].Value.ToString();
                return;
            }
            if (PowerClass.IfHasPower(userName, power, PowerNum.MenuUpdate))
            {
                num = int.Parse(e.CommandArgument.ToString());
                PageShowText.OpenPage("MenuUpdate.aspx?PK=" + this.gvResult.DataKeys[num].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 800, 500, this.Page);
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
            if (this.Session["User"] != null)
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                ButtonsModel model = new ButtonsModel(userName);
                if (PowerClass.IfHasPower(userName, power, PowerNum.MenuList))
                {
                    try
                    {
                        try
                        {
                            this.dbo = new DB_OPT();
                            this.dbo.Open();
                            this.BindDrop(this.dbo);
                            string[] names = new string[] { "MenuName", "Grade", "PowerCode" };
                            DataSet searchControlDataSet = Common.GetSearchControlDataSet(names);
                            this.Master.DataSetClo = searchControlDataSet;
                            names[0] = "菜单名称";
                            names[1] = "菜单等级";
                            names[2] = "权限编码";
                            DataSet set2 = Common.GetSearchControlDataSet(names);
                            this.Master.DataSetTable = set2;
                            if (PowerClass.IfHasPower(userName, power, PowerNum.MenuAdd))
                            {
                                model.IfAdd = true;
                            }
                            if (PowerClass.IfHasPower(userName, power, PowerNum.MenuUpdate))
                            {
                                model.IfUpdate = true;
                            }
                            if (PowerClass.IfHasPower(userName, power, PowerNum.MenuDelete))
                            {
                                model.IfDelete = true;
                            }
                            model.IfLook = false;
                            model.IfSearch = false;
                            model.IfRefresh = true;
                            model.IfHuiZong = false;
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
                            PageShowText.OpenErrorPage("获取数据失败，请联系管理员！", this.Page);
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
                PageShowText.SorryForPower(this.Page);
            }
            else
            {
                PageShowText.GoLoginPath_List(this.Page);
            }
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
        PageUsuClass.PageChangControl(nPageIndex, "MenuList", this.Page);
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
        PageUsuClass.SearchControl(strselect, strcloname, strsql, this.pageind, "MenuList", this.Page);
    }

    public string SetIsCheckPower(string strpopedom)
    {
        if (strpopedom == "0")
        {
            return "无需验证";
        }
        return "需要验证";
    }

    public string SetIsHasBaby(string strchild)
    {
        if (strchild == "0")
        {
            return "无";
        }
        return "有";
    }

    public string SetShow(string strshow)
    {
        if (strshow == "0")
        {
            return "不显示";
        }
        return "显示";
    }

    public string SetType(string strtype)
    {
        if (strtype == "1")
        {
            return "后台菜单";
        }
        return "前台菜单";
    }

    public void ShowData(string str)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            this.mm = new MenuDal();
            if (str != "")
            {
                str = " where " + str + " ";
            }
            DataSet set = PageUsuClass.GetPageSizeData(MenuDal.GetMenuColsName(), "DB_Menu", str, "MemuPK", " order by PowerCode ", this.Master.PageIndex, this.Master.PageSize, out this.count);
            this.Master.RecordCount = Convert.ToInt32(this.count);
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                DataView defaultView = set.Tables[0].DefaultView;
                defaultView.Sort = DataListDo.GetViewSort();
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
            PageShowText.OpenErrorPage("获取数据失败，请联系系统管理员！", this.Page);
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
