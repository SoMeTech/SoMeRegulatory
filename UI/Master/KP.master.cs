using ASP;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using System;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class KP_Master : MasterPage
{
    public string _strTitle = "";
    private ButtonsHandler bh;
    protected HtmlGenericControl Body1;
    protected WebControls_Buttons1 Buttons1_1;
    protected ContentPlaceHolder ContentPlaceHolder1;
    protected HtmlForm form1;
    public int hei;
    protected HtmlInputHidden ibtid;
    protected HtmlTitle lbtitle;
    protected Panel Panel1;
    protected ScriptManager ScriptManager1;
    protected HtmlTableCell td2;
    private string tdbackimgurl = "";
    protected HtmlImage titlePic;
    protected HtmlInputHidden txtBusinessDate;
    protected UpdatePanel UpdatePanel1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            string str = Public.RelativelyPath("images/new/backBar2.png");
            this.td2.Style.Add(HtmlTextWriterStyle.BackgroundImage, str);
        }
        if (this.ButtonsPushDown != null)
        {
            this.ButtonsPushDown(this.ibtid.Value);
            this.ibtid.Value = "";
            if (this.Page.IsPostBack)
            {
                PageShowText.CloseDiv(this.Page);
            }
        }
        string s = "760";
        if (base.Request.Cookies["hei"] != null)
        {
            s = base.Request.Cookies["hei"].Value;
        }
        this.hei = int.Parse(s) + 0x2d;
        this.Panel1.Height = Unit.Parse(this.hei.ToString());
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

    public int PanelHeight
    {
        get
        {
            return this.hei;
        }
        set
        {
            this.hei = value;
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

    public string SetTD1BackImg
    {
        set
        {
        }
    }

    public string SetTD2BackImg
    {
        set
        {
            this.td2.Style.Add(HtmlTextWriterStyle.BackgroundImage, value);
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
            string str = value;
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
}
