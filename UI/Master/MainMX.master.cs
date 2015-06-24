using ASP;
using ExtExtenders;
using SoMeTech.CommonDll;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using System;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class MainMX : MasterPage
{
    public string _strTitle = "";
    private ButtonsHandler bh;
    protected WebControls_Buttons1 Buttons1_1;
    protected ContentPlaceHolder ContentPlaceHolder1;
    protected ContentPlaceHolder ContentPlaceHolder2;
    private int controlspush;
    private DropMainData drop;
    protected HtmlForm form1;
    protected HtmlHead Head1;
    protected HtmlInputHidden ibtid;
    protected HtmlTitle lbtitle;
    protected Panel Panel1;
    protected ScriptManager ScriptManager1;
    private SearchHandler sh;
    private TabContainer tabContainer1;
    protected HtmlTableCell td1;
    protected HtmlTableCell td2;
    private string tdbackimgurl = "";
    protected HtmlImage titlePic;
    protected UpdatePanel UpdatePanel1;
    protected UpdatePanel UpdatePanel2;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (((UserModel)base.Session["User"]).UserName.ToLower() == "admin")
        {
            this.btModel.IfSave = true;
        }
        this.ControlsPush = 1;
        if (!this.Page.IsPostBack)
        {
            string str = Public.RelativelyPath("images/new/backBar3.png");
            this.td1.Style.Add(HtmlTextWriterStyle.BackgroundImage, str);
            this.td2.Style.Add(HtmlTextWriterStyle.BackgroundImage, str);
        }
        if (this.ButtonsPushDown != null)
        {
            this.ButtonsPushDown(this.ibtid.Value);
            this.ibtid.Value = "";
        }
        if (this.DropMainDataChange != null)
        {
            this.DropMainDataChange();
        }
        this.ControlsPush = 2;
        this.Page.Title = this.strTitle;
        if (this.TabContainer1 != null)
        {
            int num = 0x3f;
            int num2 = 280;
            this.Panel1.Height = Unit.Parse(num2.ToString());
            string text = base.Request.Cookies["allhei"].Value;
            if ((text != null) && PublicDal.PageValidate.IsInt(text))
            {
                this.TabContainer1.Height = ((int.Parse(text.ToString()) - num) - num2) - 70;
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

    public TabContainer TabContainer1
    {
        get
        {
            return this.tabContainer1;
        }
        set
        {
            this.tabContainer1 = value;
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
