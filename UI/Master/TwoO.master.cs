using ASP;
using ExceptionLog;
using SoMeTech.CommonDll.Configuration;
using SoMeTech.DataAccess;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class MainTwoO : MasterPage
{
    public string _strTitle = "";
    private ButtonsHandler bh;
    protected HtmlGenericControl Body1;
    protected WebControls_Buttons1 Buttons1_1;
    private ConfigurationDal cfd;
    protected ContentPlaceHolder ContentPlaceHolder1;
    protected ContentPlaceHolder ContentPlaceHolder2;
    private int controlspush;
    private DB_OPT dbo;
    private DropMainData drop;
    protected DropDownList dropSelectMian;
    private ExceptionLog.ExceptionLog el;
    protected HtmlForm form1;
    protected HtmlHead Head1;
    protected HtmlInputHidden ibtid;
    protected HtmlTitle lbtitle;
    protected PageNavigator PageNavigator1;
    protected Panel Panel1;
    private PageNavigatorHandler pnh;
    protected ScriptManager ScriptManager1;
    private SearchHandler sh;
    protected HtmlTableCell td1;
    protected HtmlTableCell td2;
    private string tdbackimgurl = "";
    protected HtmlImage titlePic;
    protected UpdatePanel UpdatePanel1;
    protected UpdatePanel UpdatePanel2;
    protected WebOrderControl WebOrderControl1;

    public void getPageSize()
    {
        try
        {
            this.dbo = new DB_OPT();
            this.cfd = new ConfigurationDal();
            this.dbo.Open();
            DataSet list = this.cfd.GetList("", this.dbo);
            if ((list != null) && (list.Tables[0].Rows.Count > 0))
            {
                this.PageNavigator1.PageSize = int.Parse(list.Tables[0].Rows[0]["PageSizeTwo"].ToString());
                this.PageSize = int.Parse(list.Tables[0].Rows[0]["PageSizeTwo"].ToString());
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "getPageSize()";
            this.el.WriteExceptionLog(true);
            Const.OpenErrorPage(" 获取数据失败，请联系管理员！", this.Page);
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.ControlsPush = 1;
        this.PageNavigator1.OnPageChange += new PageChangeHandl(this.PageNavigatorChange.Invoke);
        this.WebOrderControl1.OnPageChange += new PageChangeHandler(this.SearchHasGone.Invoke);
        if (((TextBox)this.WebOrderControl1.FindControl("TextBox1")).TabIndex == 1)
        {
            Common.TieButton(this.Page, (TextBox)this.WebOrderControl1.FindControl("TextBox1"), (Button)this.WebOrderControl1.FindControl("btnlike"));
        }
        if (((TextBox)this.PageNavigator1.FindControl("txtNewPageIndex")).TabIndex == 2)
        {
            Common.TieButton(this.Page, (TextBox)this.PageNavigator1.FindControl("txtNewPageIndex"), (ImageButton)this.PageNavigator1.FindControl("BtnGoto"));
        }
        if (!this.Page.IsPostBack)
        {
            this.PageIndex = 1;
            string str = Public.RelativelyPath("images/new/backBar2.png");
            this.td1.Style.Add(HtmlTextWriterStyle.BackgroundImage, str);
            this.td2.Style.Add(HtmlTextWriterStyle.BackgroundImage, str);
            this.getPageSize();
        }
        if (this.ButtonsPushDown != null)
        {
            this.ButtonsPushDown(this.ibtid.Value);
            this.ibtid.Value = "";
        }
        if (this.PageNavigatorChange != null)
        {
            this.PageNavigatorChange(sender, this.PageIndex);
        }
        if (this.SearchHasGone != null)
        {
            this.SearchHasGone(sender, this.StrSelect, this.StrCloname, this.StrSql, this.DataSetTable, this.DataSetClo);
        }
        if (this.DropMainDataChange != null)
        {
            this.DropMainDataChange();
        }
        this.ControlsPush = 2;
        string s = "1000";
        if (base.Request.Cookies["wid1"] != null)
        {
            s = base.Request.Cookies["wid1"].Value;
        }
        string str3 = "0";
        if (base.Request.Cookies["wid2"] != null)
        {
            str3 = base.Request.Cookies["wid2"].Value;
        }
        string str4 = "0";
        if (base.Request.Cookies["stu"] != null)
        {
            str4 = base.Request.Cookies["stu"].Value;
        }
        string str5 = "760";
        if (base.Request.Cookies["hei"] != null)
        {
            str5 = base.Request.Cookies["hei"].Value;
        }
        if (str4 == "0")
        {
            this.Panel1.Width = Unit.Parse(int.Parse(s).ToString());
        }
        else
        {
            this.Panel1.Width = Unit.Parse(int.Parse(str3).ToString());
        }
        int num = 250;
        if (int.Parse(str5) > 0)
        {
            num = int.Parse(str5) - 300;
        }
        this.Panel1.Height = Unit.Parse(num.ToString());
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public ButtonsModel btModel
    {
        get
        {
            return this.Buttons1_1.BM;
        }
        set
        {
            this.Buttons1_1.BM = value;
        }
    }

    public ButtonsHandler ButtonsPushDown
    {
        get
        {
            return this.bh;
        }
        set
        {
            this.bh = value;
        }
    }

    public int ControlsPush
    {
        get
        {
            return this.controlspush;
        }
        set
        {
            this.controlspush = value;
        }
    }

    public DataSet DataSetClo
    {
        get
        {
            return this.WebOrderControl1.DataSetClo;
        }
        set
        {
            this.WebOrderControl1.DataSetClo = value;
        }
    }

    public DataSet DataSetTable
    {
        get
        {
            return this.WebOrderControl1.DataSetTable;
        }
        set
        {
            this.WebOrderControl1.DataSetTable = value;
        }
    }

    public DropDownList drop1
    {
        get
        {
            return this.dropSelectMian;
        }
    }

    public DropMainData DropMainDataChange
    {
        get
        {
            return this.drop;
        }
        set
        {
            this.drop = value;
        }
    }

    public string FormID
    {
        get
        {
            return this.form1.ClientID;
        }
    }

    public string LBTitle
    {
        get
        {
            return this.lbtitle.Text;
        }
        set
        {
            this.lbtitle.Text = (value == null) ? "" : value;
        }
    }

    public UpdatePanel MainUpdatePanel
    {
        get
        {
            return this.UpdatePanel1;
        }
        set
        {
            this.UpdatePanel1 = value;
        }
    }

    public int PageCount
    {
        get
        {
            return this.PageNavigator1.PageCount;
        }
    }

    public int PageIndex
    {
        get
        {
            return this.PageNavigator1.PageIndex;
        }
        set
        {
            this.PageNavigator1.PageIndex = value;
        }
    }

    public PageNavigatorHandler PageNavigatorChange
    {
        get
        {
            return this.pnh;
        }
        set
        {
            this.pnh = value;
        }
    }

    public int PageSize
    {
        get
        {
            return this.PageNavigator1.PageSize;
        }
        set
        {
            this.PageNavigator1.PageSize = value;
        }
    }

    public Unit Panel_H
    {
        get
        {
            return this.Panel1.Height;
        }
    }

    public Unit Panel_W
    {
        get
        {
            return this.Panel1.Width;
        }
    }

    public string PanelID
    {
        get
        {
            return this.Panel1.ClientID;
        }
    }

    public Panel PanelObj
    {
        get
        {
            return this.Panel1;
        }
    }

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }

    public int RecordCount
    {
        get
        {
            return this.PageNavigator1.RecordCount;
        }
        set
        {
            this.PageNavigator1.RecordCount = value;
        }
    }

    public SearchHandler SearchHasGone
    {
        get
        {
            return this.sh;
        }
        set
        {
            this.sh = value;
        }
    }

    public string SelectText
    {
        get
        {
            return this.WebOrderControl1.SelectText;
        }
        set
        {
            this.WebOrderControl1.SelectText = value;
        }
    }

    public string SelectValue
    {
        get
        {
            return this.WebOrderControl1.SelectValue;
        }
        set
        {
            this.WebOrderControl1.SelectValue = value;
        }
    }

    public string SetTD1BackImg
    {
        set
        {
            this.td1.Style.Add(HtmlTextWriterStyle.BackgroundImage, value);
        }
    }

    public string SetTD2BackImg
    {
        set
        {
            this.td2.Style.Add(HtmlTextWriterStyle.BackgroundImage, value);
        }
    }

    public ScriptManager SM
    {
        get
        {
            return this.ScriptManager1;
        }
    }

    public string StrClomun
    {
        get
        {
            return this.WebOrderControl1.StrClomun;
        }
        set
        {
            this.WebOrderControl1.StrClomun = value;
        }
    }

    public string StrCloname
    {
        get
        {
            return this.WebOrderControl1.StrCloname;
        }
        set
        {
            this.WebOrderControl1.StrCloname = value;
        }
    }

    public string StrSelect
    {
        get
        {
            return this.WebOrderControl1.StrSelect;
        }
        set
        {
            this.WebOrderControl1.StrSelect = value;
        }
    }

    public string StrSql
    {
        get
        {
            return this.WebOrderControl1.StrSql;
        }
        set
        {
            this.WebOrderControl1.StrSql = value;
        }
    }

    public string strTitle
    {
        get
        {
            return this._strTitle;
        }
        set
        {
            this._strTitle = (value == null) ? "" : value;
        }
    }

    public string TableName
    {
        get
        {
            return this.WebOrderControl1.TableName;
        }
        set
        {
            this.WebOrderControl1.TableName = value;
        }
    }

    public string TDBackImage
    {
        get
        {
            return this.tdbackimgurl;
        }
        set
        {
            string str = value;
            this.td1.Style.Add(HtmlTextWriterStyle.BackgroundImage, str);
            this.td2.Style.Add(HtmlTextWriterStyle.BackgroundImage, str);
        }
    }

    public string TextValue
    {
        get
        {
            return this.WebOrderControl1.TextValue;
        }
        set
        {
            this.WebOrderControl1.TextValue = value;
        }
    }

    public string TitlePic
    {
        get
        {
            return this.titlePic.Src;
        }
        set
        {
            this.titlePic.Src = (value == null) ? "" : value;
        }
    }

    public string TitleTxt
    {
        get
        {
            return this.strTitle;
        }
        set
        {
            this.strTitle = value;
        }
    }

    public UpdatePanel UP1
    {
        get
        {
            return this.UpdatePanel1;
        }
    }

    public UpdatePanel UP2
    {
        get
        {
            return this.UpdatePanel2;
        }
    }
}
