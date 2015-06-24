using ASP;
using ExceptionLog;
using SoMeTech.CommonDll.Configuration;
using SoMeTech.DataAccess;
using System;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class MainReport : MasterPage
{
    public string _strTitle = "";
    private ButtonsHandler bh;
    protected Button Button1;
    protected ContentPlaceHolder ContentPlaceHolder1;
    private int controlspush;
    protected HtmlForm form1;
    protected HtmlHead Head1;
    protected HtmlTitle lbtitle;
    protected Panel Panel1;
    private PageChangeHandlerReport pnh;
    protected ScriptManager ScriptManager1;
    private SearchHandler sh;
    private string tdbackimgurl = "";
    protected UpdatePanel UpdatePanel1;
    protected ReportOrderControl WebOrderControl1;

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
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

    public TableRow ContRow
    {
        get
        {
            return this.WebOrderControl1.ContRow;
        }
        set
        {
            this.WebOrderControl1.ContRow = value;
        }
    }

    public Table ContTable
    {
        get
        {
            return this.WebOrderControl1.ContTable;
        }
        set
        {
            this.WebOrderControl1.ContTable = value;
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

    public PageChangeHandlerReport PageChangeReportChange
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

    public string PanelID
    {
        get
        {
            return this.Panel1.ClientID;
        }
    }

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
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

    public string TDBackImage
    {
        get
        {
            return this.tdbackimgurl;
        }
        set
        {
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
}
