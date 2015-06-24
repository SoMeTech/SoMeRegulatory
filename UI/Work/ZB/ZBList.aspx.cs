using ASP;
using QxRoom.Common;
using SoMeTech.CommonDll;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Collections;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using YYControls;
using SMZJ.BLL;

public partial class Work_ZB_ZBList : Page, IRequiresSessionState
{
    DataTable dt1;
    DataTable dt2;
    private ExceptionLog.ExceptionLog el;
    private UserBll bll = new UserBll();
    public string count = "0";
    private DB_OPT dbo;
    private PageSizeBll pagesize = new PageSizeBll();
    private decimal PD_QUOTA_MONEY_TOTAL;
    private decimal PD_QUOTA_ZBXDZH;
    private decimal PD_UP_MONEY;
    public int pageind = 1;
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
                    string currSelectedTabId = this.hidCurrentTab.Value;

                    if (!string.IsNullOrEmpty(this.hidCurrentTab.Value))
                    {
                        int tabId;
                        if (int.TryParse(currSelectedTabId, out tabId))
                        {
                            this.tabs.ActiveTabIndex = Convert.ToInt32(currSelectedTabId);
                        }
                        if (1 == tabId)
                        {
                            this.gvResult.DataSource = null;
                            this.gvResult.DataBind();
                            this.tabs.ActiveTab = this.tbSource2;
                            this.gvResult.DataSource = dt1;
                            this.gvResult.DataBind();
                            this.gvResult.Attributes.Add("style", "word-break:keep-all;word-wrap:normal");
                        }
                        else
                        {
                            this.gvResult.DataSource = null;
                            this.tabs.ActiveTab = this.tbSource1;
                            this.gvResult.DataSource = dt2;
                            this.gvResult.DataBind();
                            this.gvResult.Attributes.Add("style", "word-break:keep-all;word-wrap:normal");
                        }

                    }

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
    protected void hidCurrentTab_ValueChanged(object sender, EventArgs e)
    {

        this.ShowData("");
        string currSelectedTabId = this.hidCurrentTab.Value;

        if (!string.IsNullOrEmpty(this.hidCurrentTab.Value))
        {
            int tabId;
            if (int.TryParse(currSelectedTabId, out tabId))
            {
                this.tabs.ActiveTabIndex = Convert.ToInt32(currSelectedTabId);
            }
            if (1 == tabId)
            {
                this.gvResult.DataSource = null;
                this.gvResult.DataBind();
                this.tabs.ActiveTab = this.tbSource2;
                this.gvResult.DataSource = dt1;
                this.gvResult.DataBind();
                this.gvResult.Attributes.Add("style", "word-break:keep-all;word-wrap:normal");
            }
            else
            {
                this.gvResult.DataSource = null;
                this.tabs.ActiveTab = this.tbSource1;
                this.gvResult.DataSource = dt2;
                this.gvResult.DataBind();
                this.gvResult.Attributes.Add("style", "word-break:keep-all;word-wrap:normal");
            }

        }
    }
    public void ShowData(string str)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            string companyWhereZB = PublicDal.GetCompanyWhereZB();
            if (str != "")
            {
                str = " where " + str + " and  PD_UP_MONEY is not null " + companyWhereZB;
            }
            else
            {
                str = "where PD_UP_MONEY is not null " + companyWhereZB;
            }
            DataSet set = this.pagesize.pagesize(this.getCloumns(), "view_tb_quota_list", str, "pd_quota_code", " order by pd_quota_fwdata desc,pd_quota_depart,pd_quota_zjxz,pd_quota_zbwh ", this.Master.PageIndex, this.Master.PageSize, out this.count);
            this.Master.RecordCount = Convert.ToInt32(this.count);
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                DataView defaultView = set.Tables[0].DefaultView;
                if ((this.ViewState["SortOrder"] != null) && (this.ViewState["OrderDire"] != null))
                {
                    string str3 = ((string)this.ViewState["SortOrder"]) + " " + ((string)this.ViewState["OrderDire"]);
                    defaultView.Sort = str3;
                }
                if (((UserModel)this.Session["User"]).Company.IsHasBaby == "0")
                {
                    DataTable table = set.Tables[0];
                    table.Columns.Add("pd_quota_zbxdzh");
                    table.Columns.Add("pd_quota_ifxzhz_name");
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(table.Rows[i]["PD_UP_MONEY"].ToString()))
                        {
                            this.PD_UP_MONEY += decimal.Parse(table.Rows[i]["PD_UP_MONEY"].ToString());
                        }
                    }
                    if (table.Select("PD_QUOTA_ZJXZ='项目资金'").Length > 0)
                    {
                        dt1 = table.Select("PD_QUOTA_ZJXZ='项目资金'").CopyToDataTable();
                        DataRow row1 = dt1.NewRow();
                        row1["pd_quota_fwdata"] = "合计";
                        row1["PD_UP_MONEY"] = this.PD_UP_MONEY;
                        dt1.Rows.Add(row1);
                    }

                    if (table.Select("PD_QUOTA_ZJXZ='补助性资金'").Length > 0)
                    {
                        dt2 = table.Select("PD_QUOTA_ZJXZ='补助性资金'").CopyToDataTable();
                        DataRow row2 = dt2.NewRow();
                        row2["pd_quota_fwdata"] = "合计";
                        row2["PD_UP_MONEY"] = this.PD_UP_MONEY;
                        dt2.Rows.Add(row2);

                    }
                }
                else
                {
                    DataTable table2 = set.Tables[0];
                    for (int j = 0; j < table2.Rows.Count; j++)
                    {
                        if (PublicDal.PageValidate.IsDecimal(table2.Rows[j]["PD_QUOTA_ZBXDZH"]))
                        {
                            this.PD_QUOTA_ZBXDZH += decimal.Parse(table2.Rows[j]["PD_QUOTA_ZBXDZH"].ToString());
                        }
                        if (PublicDal.PageValidate.IsDecimal(table2.Rows[j]["PD_QUOTA_MONEY_TOTAL"]))
                        {
                            this.PD_QUOTA_MONEY_TOTAL += decimal.Parse(table2.Rows[j]["PD_QUOTA_MONEY_TOTAL"].ToString());
                        }
                    }
                    if (table2.Select("PD_QUOTA_ZJXZ='项目资金'").Length > 0)
                    {
                        dt1 = table2.Select("PD_QUOTA_ZJXZ='项目资金'").CopyToDataTable();
                        DataRow row1 = dt1.NewRow();
                        row1["pd_quota_fwdata"] = "合计";
                        row1["PD_QUOTA_ZBXDZH"] = this.PD_QUOTA_ZBXDZH;
                        row1["PD_QUOTA_MONEY_TOTAL"] = this.PD_QUOTA_MONEY_TOTAL;
                        dt1.Rows.Add(row1);

                    }
                    if (table2.Select("PD_QUOTA_ZJXZ='补助性资金'").Length > 0)
                    {
                        dt2 = table2.Select("PD_QUOTA_ZJXZ='补助性资金'").CopyToDataTable();
                        DataRow row2 = dt2.NewRow();
                        row2["pd_quota_fwdata"] = "合计";
                        row2["PD_QUOTA_ZBXDZH"] = this.PD_QUOTA_ZBXDZH;
                        row2["PD_QUOTA_MONEY_TOTAL"] = this.PD_QUOTA_MONEY_TOTAL;
                        dt2.Rows.Add(row2);
                    }
                }
            }
            else
            {
                DataTable table3 = new DataTable();
                table3 = set.Tables[0];
                if (table3.Select("PD_QUOTA_ZJXZ='项目资金'").Length > 0) 
                {
                    dt1 = table3.Select("PD_QUOTA_ZJXZ='项目资金'").CopyToDataTable();
                    DataRow row1 = dt1.NewRow();
                    dt1.Rows.Add(row1);
                }

                if (table3.Select("PD_QUOTA_ZJXZ='补助性资金'").Length > 0) 
                {

                    dt2 = table3.Select("PD_QUOTA_ZJXZ='补助性资金'").CopyToDataTable();
                    DataRow row2 = dt2.NewRow();
                    dt2.Rows.Add(row2);
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
    public void Buttons(string ibtid)
    {
        int selectedIndex = this.gvResult.SelectedIndex;
        switch (ibtid)
        {
            case "ibtcontrol_ibtadd":
                PageShowText.OpenPage("ZBOper.aspx", null, null, this.Page);
                return;

            case "ibtcontrol_ibtdo":
                if ((selectedIndex < 0) || (this.gvResult.Rows.Count < selectedIndex))
                {
                    PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
                    return;
                }
                if ((this.gvResult.DataKeys[selectedIndex].Value.ToString() != null) && (this.gvResult.DataKeys[selectedIndex].Value.ToString().Trim() != ""))
                {
                    PageShowText.OpenPage("ZBOper.aspx?look=looklist&UpdatePK=" + this.gvResult.DataKeys[selectedIndex].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), null, null, this.Page);
                }
                return;

            case "ibtcontrol_ibtdelete":
                if ((selectedIndex < 0) || (this.gvResult.Rows.Count < selectedIndex))
                {
                    PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
                    return;
                }
                this.DataDelete(this.gvResult.DataKeys[selectedIndex].Value.ToString(), "", "", "", "");
                return;

            case "ibtcontrol_ibtprintnote":
                PageShowText.OpenPage("ZPRINT.aspx?pk=" + base.Server.UrlEncode(this.gvResult.DataKeys[selectedIndex].Value.ToString()), null, null, this.Page);
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

    public string GetBranch(string str)
    {
        return "";
    }

    private string getCloumns()
    {
        string str = "distinct pd_quota_code, pd_quota_zbwh,PD_QUOTA_PICI, pd_quota_name, pd_quota_fwdata, pd_quota_lwjg,pd_quota_lwjg_name,pd_quota_zjxz,pd_quota_zjxz_name, pd_quota_target, pd_quota_standard, pd_quota_basis, pd_quota_basis_jg, pd_quota_zbxdzh, pd_quota_gllx, pd_quota_jjlx, pd_quota_zjly, pd_quota_zjly_name, pd_quota_zgkj, pd_quota_zgkj_name, pd_quota_ifpass, pd_quota_ifpass_name, pd_quota_ifllyqs, pd_quota_ifllyqs_name, pd_quota_isup, pd_quota_isup_name, pd_quota_ifxzqs, pd_quota_ifxzqs_name, pd_quota_ifup, pd_quota_ifup_name, pd_year, pd_quota_input_date, pd_quota_input_man, pd_quota_input_company, pd_quota_input_company_name, pd_quota_input_depart, pd_quota_input_depart_name, pd_quota_pass_date, pd_quota_pass_man, pd_quota_pass_company, pd_quota_pass_company_name, pd_quota_pass_depart, pd_quota_pass_depart_name, pd_quota_accept_date, pd_quota_accept_man, pd_quota_accept_company, pd_quota_accept_company_name, pd_quota_accept_depart, pd_quota_accept_depart_name, pd_quota_up_date, pd_quota_up_man, pd_quota_up_company, pd_quota_up_company_name, pd_quota_up_depart, pd_quota_up_depart_name, pd_quota_depart, pd_quota_depart_name, pd_quota_lx, pd_quota_jgyq, pd_quota_zbyt, pd_quota_company, pd_quota_xmzgbm, pd_quota_zgbm, pd_quota_file, pd_quota_serverpk,pd_quota_ifxzhz_name,pd_quota_ifsbxm_name";
        string bH = ((UserModel)this.Session["User"]).Branch.BH;
        string text = PublicDal.PD_Coding_Level("2", bH);
        if (PublicDal.PageValidate.IsInt(text) && (int.Parse(text) != 14))
        {
            return (str + ",pd_quota_money_total");
        }
        foreach (DataControlField field in this.gvResult.Columns)
        {
            BoundField field2;
            if (field.GetType().Name.Equals("BoundField"))
            {
                field2 = (BoundField)field;
                string dataField = field2.DataField;
                if (dataField != null)
                {
                    if (!(dataField == "pd_quota_zbxdzh"))
                    {
                        if (dataField == "pd_quota_ifxzqs_name")
                        {
                            goto Label_00E0;
                        }
                        if (!(dataField == "pd_quota_ifxzhz_name"))
                        {
                            continue;
                        }
                        goto Label_00FA;
                    }
                    field2.SortExpression = field2.DataField = "PD_UP_MONEY";
                }
            }
            continue;
        Label_00E0:
            field2.SortExpression = field2.DataField = "ISRECEIVE";
            continue;
        Label_00FA:
            field2.SortExpression = field2.DataField = "ISHUIZHI";
        }
        str = str + ",ISRECEIVE,ISHUIZHI,PD_UP_MONEY,'****' pd_quota_money_total";
        ArrayList list = new ArrayList();
        list.Add("pd_quota_money_total");
        list.Add("pd_quota_ifpass_name");
        list.Add("pd_quota_ifllyqs_name");
        list.Add("pd_quota_isup_name");
        this.Master.NotDisplayColumn = list;
        return str;
    }

    public string Getpk_corp(string str)
    {
        return "";
    }

    private string GetSelectCheckBox()
    {
        string str = "";
        for (int i = 0; i < this.gvResult.Rows.Count; i++)
        {
            if (((CheckBox)this.gvResult.Rows[i].FindControl("checkBox")).Checked)
            {
                str = str + this.gvResult.Rows[i].Cells[1].Text + ",";
            }
        }
        return str.Remove(str.Length - 1);
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
    protected void PageChangControl(object sender, int nPageIndex)
    {
        PageUsuClass.PageChangControl(nPageIndex, "view_tb_quota_list", this.Page);
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
        PageUsuClass.SearchControl(strselect, strcloname, strsql, this.pageind, "view_tb_quota_list", this.Page);
    }

    public string SetIsUser(string strIsUser)
    {
        if (strIsUser == "1")
        {
            return "启用";
        }
        return "不启用";
    }
}
