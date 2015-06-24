using ASP;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using YYControls;

public class User_DataPowerList : Page, IRequiresSessionState
{
    public string count = "";
    private DB_OPT dbo;
    private DataRowPowerModel drpm;
    protected HtmlForm form1;
    protected SmartGridView gvResult;
    protected HtmlInputText ifadd;
    public int pageind = 1;
    protected PageNavigator PageNavigator1;
    private PageSizeBll pagesize = new PageSizeBll();
    protected Panel Panel1;
    protected HtmlInputText pk;
    protected HtmlInputText tn;

    protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onMouseOver", "SetNewColor(this);");
            e.Row.Attributes.Add("onMouseOut", "SetOldColor(this);");
        }
    }

    protected void gvResult_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            string str = this.gvResult.DataKeys[e.RowIndex].Value.ToString();
            this.drpm = new DataRowPowerDal();
            this.drpm.PK = str;
            this.drpm.Delete(this.dbo);
            this.ShowData("");
        }
        catch (Exception)
        {
        }
        finally
        {
            this.dbo.Close();
        }
    }

    protected void gvResult_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string str = this.gvResult.DataKeys[e.RowIndex].Value.ToString();
        base.Response.Redirect("DataRowPower.aspx?PK=" + str + "&type=Update");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.PageNavigator1.OnPageChange += new PageChangeHandl(this.PageNavigator1_PageChange);
        if (!this.Page.IsPostBack)
        {
            string userName = ((UserModel)this.Session["User"]).UserName;
            string power = ((UserModel)this.Session["User"]).Power;
            if (PowerClass.IfHasPower(userName, power, PowerNum.DataRowPowerList))
            {
                this.ShowData("");
                this.PageNavigator1.RecordCount = this.drpm.GetList("", this.dbo).Tables[0].Rows.Count;
                this.PageNavigator1.PageSize = 10;
                this.PageNavigator1.PageIndex = this.pageind;
                if (!PowerClass.IfHasPower(userName, power, PowerNum.DataRowPowerUpdate))
                {
                    this.gvResult.Columns[8].Visible = false;
                }
                if (!PowerClass.IfHasPower(userName, power, PowerNum.DataRowPowerDelete))
                {
                    this.gvResult.Columns[9].Visible = false;
                }
            }
            else
            {
                Const.SorryForPower(this.Page);
            }
        }
    }

    protected void PageNavigator1_PageChange(object sender, int PageIndex)
    {
        this.PageNavigator1.PageSize = 10;
        this.pageind = PageIndex;
        this.PageNavigator1.PageIndex = PageIndex;
        this.ShowData("");
    }

    private void ShowData(string str)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            this.drpm = new DataRowPowerDal();
            DataSet set = this.pagesize.pagesize("*", "DataRowPower", str, "PK", " order by PowerCode ", this.pageind, 10, out this.count);
            if (set != null)
            {
                this.gvResult.DataSource = set.Tables[0].DefaultView;
                this.gvResult.DataBind();
            }
        }
        catch (Exception exception)
        {
            Const.OpenErrorPage("获取数据失败，请联系管理员！" + exception.Message, this.Page);
        }
        finally
        {
            this.dbo.Close();
        }
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
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
