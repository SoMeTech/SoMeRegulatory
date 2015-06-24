using ASP;
using ExceptionLog;
using SoMeTech.CommonDll;
using SoMeTech.Data;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SMZJ.BLL;

public class Work_JCZLWH_NDJZ : Page, IRequiresSessionState
{
    private UserBll bll = new UserBll();
    protected Button Button1;
    protected Button Button2;
    public string count = "0";
    private ExceptionLog.ExceptionLog el;
    protected System.Web.UI.WebControls.GridView GridView;
    protected System.Web.UI.WebControls.GridView gvResult;
    public int pageind = 1;
    private PageSizeBll pagesize = new PageSizeBll();
    protected Panel Panel_Left;
    protected Panel Panel_right;
    protected TextBox TextBox1;
    protected HtmlInputHidden txtindex;
    protected HtmlInputHidden txttitle;
    protected DropDownList year1;
    protected DropDownList year2;

    private void BindList(DB_OPT dbo)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = "";
        this.TextBox1.Text = "";
        foreach (GridViewRow row in this.gvResult.Rows)
        {
            CheckBox box = (CheckBox)row.Cells[1].FindControl("RowSelector");
            if (box.Checked)
            {
                if (str == "")
                {
                    str = str + row.Cells[2].Text.ToString() + "&" + row.Cells[3].Text.ToString();
                }
                else
                {
                    str = str + "|" + row.Cells[2].Text.ToString() + "&" + row.Cells[3].Text.ToString();
                }
            }
        }
        if (str == "")
        {
            PageShowText.ShowMessage_List("请选择需要结转的表再操作！", this.Page);
        }
        else
        {
            PageShowText.ShowMessage("请慎重进行这样的操作！程序将" + this.year1.SelectedValue.ToString() + "年的基础数据复制到" + this.year2.SelectedValue.ToString() + "年度中，并保持完全一致", this.Page);
            ScriptManager.RegisterClientScriptBlock((Page)this, base.GetType(), "", " <script language='javascript' >if(Confirm('确认码?')) document.getElementById('Hf').value='1'; else document.getElementById('Hf').value='0'; </script>", false);
            string[] strArray = str.Split(new char[] { '|' });
            int num = 1;
            foreach (string str2 in strArray)
            {
                string[] strArray2 = str2.Split(new char[] { '&' });
                this.TextBox1.Visible = true;
                this.Button2.Visible = true;
                this.TextBox1.Text = this.TextBox1.Text.ToString() + num.ToString() + ". " + strArray2[0] + "正在结转......\n";
                this.DoJieZhuan(strArray2[0], strArray2[1], this.year1.SelectedValue.ToString(), this.year2.SelectedValue.ToString());
                this.TextBox1.Text = this.TextBox1.Text.ToString() + strArray2[0] + "结转成功!\n";
                num++;
            }
            PageShowText.ShowMessage("结转成功！", this.Page);
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.TextBox1.Visible = false;
        this.Button2.Visible = false;
    }

    public void Buttons(string ibtid)
    {
        int selectedIndex = this.gvResult.SelectedIndex;
        switch (ibtid)
        {
            case "ibtcontrol_ibtadd":
                PageShowText.OpenPage("BXKMx.aspx?strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), null, null, this.Page);
                return;

            case "ibtcontrol_ibtdo":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    if ((this.gvResult.DataKeys[selectedIndex].Value.ToString() != null) && (this.gvResult.DataKeys[selectedIndex].Value.ToString().Trim() != ""))
                    {
                        PageShowText.OpenPage("BXKMx.aspx?UpdatePK=" + this.gvResult.DataKeys[selectedIndex].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), null, null, this.Page);
                    }
                    return;
                }
                PageShowText.ShowMessage_List("请选择一行数据再操作！", this.Page);
                return;

            case "ibtcontrol_ibtdelete":
                if ((selectedIndex >= 0) && (this.gvResult.Rows.Count >= selectedIndex))
                {
                    this.DeleteObject(this.gvResult.DataKeys[selectedIndex].Value.ToString());
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

    private void DeleteObject(string p)
    {
        if (PublicDal.IsDelete(this.Page, "TB_PROJECT", "PD_PROJECT_CODE", p, "PD_PROJECT_SERVERPK"))
        {
            TB_PROJECT_Bll bll = new TB_PROJECT_Bll();
            if (bll.ProjectIsBX(p))
            {
                PageShowText.ShowMessage("项目状态为已选，无法删除，请先删除项目情况登记中的项目！", this.Page);
            }
            else
            {
                bll.Delete(p);
                if (this.Master.PageIndex > 1)
                {
                    this.pageind = this.Master.PageIndex;
                }
                this.ShowData(this.Master.StrSelect);
                PageShowText.ShowMessage("删除成功！", this.Page);
            }
        }
        else
        {
            PageShowText.ShowMessage("单据已进入业务流程，需删除请追回单据后再进行删除。", this.Page);
        }
    }

    private void DoJieZhuan(string name, string ziDuan, string yuanND, string mbND)
    {
        try
        {
            ArrayList sQLStringList = new ArrayList();
            sQLStringList.Add("PURGE RECYCLEBIN");
            sQLStringList.Add("create table Test_Jcb_TempOne  as select * from " + name + " where " + ziDuan + "='" + yuanND + "'");
            sQLStringList.Add("UPDATE  Test_Jcb_TempOne  set  " + ziDuan + "='" + mbND + "' where " + ziDuan + "='" + yuanND + "'");
            sQLStringList.Add("insert into " + name + "  select * from Test_Jcb_TempOne");
            sQLStringList.Add("create table Test_Jcb_TempTwo  as select distinct * from " + name);
            sQLStringList.Add("DROP table Test_Jcb_TempOne");
            sQLStringList.Add("DROP table " + name);
            sQLStringList.Add("RENAME Test_Jcb_TempTwo to " + name);
            sQLStringList.Add("PURGE RECYCLEBIN");
            DbHelperOra.ExecuteSqlTran(sQLStringList);
        }
        catch (Exception exception)
        {
            PageShowText.ShowMessage("结转失败" + exception, this.Page);
        }
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
                    PageShowText.OpenPage("BXKMx.aspx?UpdatePK=" + this.gvResult.DataKeys[num].Value.ToString() + "&strTitle=" + base.Server.UrlEncode(this.txttitle.Value.Trim()), 0x556, 0x300, this.Page);
                }
            }
        }
    }

    protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
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
        this.Master.StrSelect = "";
        if (!this.Page.IsPostBack)
        {
            int num = Convert.ToInt32(HttpContext.Current.Request.Cookies["YearND"].Value.ToString());
            int num2 = num - 1;
            this.year1.Items.Add(num2.ToString());
            this.year1.Items.Add(num.ToString());
            int num3 = num + 1;
            this.year1.Items.Add(num3.ToString());
            this.year1.SelectedValue = num.ToString();
            this.year1.Enabled = false;
            this.year2.Items.Add(num.ToString());
            int num4 = num + 1;
            this.year2.Items.Add(num4.ToString());
            int num5 = num + 2;
            this.year2.Items.Add(num5.ToString());
            this.year2.SelectedValue = (num + 1).ToString();
            this.year2.Enabled = false;
            this.TextBox1.Visible = false;
            this.Button2.Visible = false;
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
        string sQLString = "select *  from user_TAB_COLUMNS where Table_name in (select Table_name from User_Tab_Comments where   table_type='TABLE' and Table_name in (select TABNAME from DB_BZD) )  and COLUMN_NAME in ('PD_YEAR','GSDM')";
        DataTable table = DbHelperOra.Query(sQLString).Tables[0];
        this.gvResult.DataSource = table;
        this.gvResult.DataBind();
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
