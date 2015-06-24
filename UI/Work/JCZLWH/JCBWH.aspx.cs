using ASP;
using SoMeTech.CommonDll;
using SoMeTech.Data;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using System;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using YYControls;
using SMZJ.BLL;

public class Work_JCZLWH_JCBWH : Page, IRequiresSessionState
{
    private UserBll bll = new UserBll();
    public string count = "0";
    protected HtmlGenericControl divEdit;
    private ExceptionLog.ExceptionLog el;
    protected SmartGridView gvResult;
    public int pageind = 1;
    private PageSizeBll pagesize = new PageSizeBll();
    private string strTabName;
    protected DropDownList tabLB;
    protected HtmlInputHidden txtindex;
    protected HtmlInputHidden txttitle;
    protected UpdatePanel UpdatePanel1;

    public void Buttons(string ibtid)
    {
        int selectedIndex = this.gvResult.SelectedIndex;
        switch (ibtid)
        {
            case "ibtcontrol_ibtadd":
                PageShowText.OpenPage("ZBOper.aspx", null, null, this.Page);
                return;

            case "ibtcontrol_ibtdo":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    this.doEidt(this.gvResult.SelectedIndex);
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

            case "ibtcontrol_ibtprintnote":
                PageShowText.OpenPage("ZPRINT.aspx?pk=" + base.Server.UrlEncode(this.gvResult.DataKeys[selectedIndex].Value.ToString()), null, null, this.Page);
                return;

            case "ibtcontrol_ibtsave":
                this.doSave();
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

    private void DataDelete(string strPK, string bh, string name, string company, string branch)
    {
        try
        {
            if (PublicDal.IsDelete(this.Page, "TB_QUOTA", "PD_QUOTA_CODE", strPK, "PD_QUOTA_SERVERPK"))
            {
                TB_QUOTA_Bll bll = new TB_QUOTA_Bll();
                TB_QUOTA_DETAIL tb_quota_detail = new TB_QUOTA_DETAIL();
                if (bll.Delete(strPK))
                {
                    tb_quota_detail.DeleteProject(strPK);
                    PageShowText.ShowMessage("删除成功!", this.Page);
                }
                else
                {
                    PageShowText.ShowMessage("删除失败!", this.Page);
                }
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

    private void doEidt(int i)
    {
        int count = this.gvResult.Rows[i].Cells.Count;
        HtmlTable child = new HtmlTable();
        for (int j = 2; j < count; j++)
        {
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell cell = new HtmlTableCell();
            Label label = new Label
            {
                Text = this.gvResult.HeaderRow.Cells[j].Text
            };
            cell.Attributes.Add("background-color", "#fff");
            cell.Controls.Add(label);
            HtmlTableCell cell2 = new HtmlTableCell();
            TextBox box = new TextBox();
            if (this.gvResult.Rows[i].Cells[j].Text.ToString() == "&nbsp;")
            {
                box.Text = "";
            }
            else
            {
                box.Text = this.gvResult.Rows[i].Cells[j].Text;
            }
            box.ID = j.ToString();
            box.Style.Add("width", "150px");
            this.divEdit.Controls.Add(box);
            cell2.Controls.Add(box);
            row.Cells.Add(cell);
            row.Cells.Add(cell2);
            child.Rows.Add(row);
        }
        HtmlTableRow row2 = new HtmlTableRow();
        HtmlTableCell cell3 = new HtmlTableCell();
        cell3.Attributes.Add("colspan", "2");
        Button button = new Button();
        int num3 = i + 1;
        button.Attributes.Add("onclick", "getTable(" + num3.ToString() + ")");
        button.Text = "保存";
        cell3.Controls.Add(button);
        row2.Cells.Add(cell3);
        child.Rows.Add(row2);
        child.Attributes.Add("id", "tb");
        child.Attributes.Add("border", "1px");
        child.Attributes.Add("class", "newTable");
        this.divEdit.Controls.Add(child);
    }

    private void doSave()
    {
        //this.Page.RegisterStartupScript("ggg", " <script>getTable(); </script>");
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", " <script>getTable(); </script>");
        for (int i = 0; i < 2; i++)
        {
        }
    }

    public string GetBranch(string str)
    {
        return "";
    }

    [WebMethod]
    public static string GetData(string data, string redata, string tabName)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        string[] strArray = data.Split(new char[] { '|' });
        string[] strArray2 = redata.Split(new char[] { '|' });
        StringBuilder builder = new StringBuilder();
        int num = 0;
        for (int i = 0; i < strArray.Length; i++)
        {
            if ((i % 2) != 1)
            {
                if (builder.ToString() == "")
                {
                    if ((strArray2[i - num] == " ") || (strArray2[i - num] == ""))
                    {
                        num++;
                    }
                    else
                    {
                        builder.Append("where " + strArray[i] + " = '" + strArray2[i - num] + "' ");
                        num++;
                    }
                }
                else if ((strArray2[i - num] == " ") || (strArray2[i - num] == ""))
                {
                    num++;
                }
                else
                {
                    builder.Append(" and " + strArray[i] + " = '" + strArray2[i - num] + "'");
                    num++;
                }
            }
        }
        StringBuilder builder2 = new StringBuilder();
        for (int j = 0; j < strArray.Length; j++)
        {
            if ((j % 2) != 1)
            {
                if (builder2.ToString() == "")
                {
                    builder2.Append("set " + strArray[j] + " = ");
                }
                else
                {
                    builder2.Append(" , " + strArray[j] + " = ");
                }
            }
            else
            {
                builder2.Append(" '" + strArray[j] + "' ");
            }
        }
        string sQLString = "update " + tabName + " " + builder2.ToString() + builder.ToString();
        DbHelperOra.ExecuteSql(sQLString);
        return serializer.Serialize(sQLString);
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
                    PageShowText.OpenPage("ZBOper.aspx?UpdatePK=" + this.gvResult.DataKeys[num].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 0x556, 0x300, this.Page);
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
        if (this.Session["user"] != null)
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
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
                try
                {
                    ButtonsModel model = null;
                    PublicDal.ShowListButton(this.Page, out model, "");
                    model.IbtDoText = "修改";
                    model.IfPrintNote = false;
                    model.IfSave = true;
                    model.IfAdd = true;
                    model.IfDo = true;
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
        }
        else
        {
            Const.GoLoginPath_List(this.Page);
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
        PageUsuClass.PageChangControl(nPageIndex, "view_tb_quota_list", this.Page);
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
        PageUsuClass.SearchControl(strselect, strcloname, strsql, this.pageind, "view_tb_quota_list", this.Page);
    }

    protected void selectChg(object sender, EventArgs e)
    {
        this.strTabName = this.tabLB.SelectedValue.ToString();
        DataSet set = DbHelperOra.Query("select * from " + this.strTabName);
        this.gvResult.DataSource = set.Tables[0];
        this.gvResult.DataBind();
    }

    public void ShowData(string str)
    {
        string sQLString = "select TABNAME,NAMEZW from DB_BZD";
        DataSet set = DbHelperOra.Query(sQLString);
        this.tabLB.DataSource = set.Tables[0];
        this.tabLB.DataValueField = set.Tables[0].Columns[0].ColumnName;
        this.tabLB.DataTextField = set.Tables[0].Columns[1].ColumnName;
        this.tabLB.DataBind();
        this.tabLB.SelectedValue = "DB_BZD";
        this.strTabName = this.tabLB.SelectedValue.ToString();
        DataSet set2 = DbHelperOra.Query("select * from " + this.strTabName);
        this.gvResult.DataSource = set2.Tables[0];
        this.gvResult.DataBind();
    }

    public string ShowData2()
    {
        string sQLString = "select TABNAME,NAMEZW from DB_BZD where ISJCB='1'";
        DataSet set = DbHelperOra.Query(sQLString);
        this.tabLB.DataSource = set.Tables[0];
        this.tabLB.DataValueField = set.Tables[0].Columns[0].ColumnName;
        this.tabLB.DataTextField = set.Tables[0].Columns[1].ColumnName;
        this.tabLB.DataBind();
        this.tabLB.SelectedValue = "test";
        this.strTabName = this.tabLB.SelectedValue.ToString();
        DataSet set2 = DbHelperOra.Query("select * from " + this.strTabName);
        this.gvResult.DataSource = set2.Tables[0];
        this.gvResult.DataBind();
        return "编辑成功";
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
