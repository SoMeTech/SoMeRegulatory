using ASP;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using System;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class MainAddUpdate : MasterPage
{
    public string _strTitle = "";
    private ButtonsHandler bh;
    protected WebControls_Buttons1 Buttons1_1;
    protected ContentPlaceHolder ContentPlaceHolder1;
    protected HtmlForm form1;
    protected HtmlHead Head1;
    public int hei;
    protected HtmlInputHidden ibtid;
    protected HtmlTitle lbtitle;
    protected Panel Panel1;
    protected ScriptManager ScriptManager1;
    protected HtmlTableCell td1;
    protected HtmlTableCell td2;
    private string tdbackimgurl = "";
    protected HtmlImage titlePic;
    protected UpdatePanel UpdatePanel1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (((UserModel)base.Session["User"]).UserName.ToLower() == "admin")
        {
            this.btModel.IfSave = true;
        }
        if (!this.Page.IsPostBack)
        {
            string str = Public.RelativelyPath("images/new/backBar2.png");
            this.td1.Style.Add(HtmlTextWriterStyle.BackgroundImage, str);
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
        if (base.Request["strTitle"] != null)
        {
            if (base.Request["PK"] != null)
            {
                if (base.Request["look"] != null)
                {
                    this._strTitle = "查看" + base.Server.UrlDecode(base.Request["strTitle"].ToString());
                    this.LBTitle = "乡镇财政资金监管信息系统 - 查看" + base.Server.UrlDecode(base.Request["strTitle"].ToString());
                }
                else
                {
                    this._strTitle = "修改" + base.Server.UrlDecode(base.Request["strTitle"].ToString());
                    this.LBTitle = "乡镇财政资金监管信息系统 - 修改" + base.Server.UrlDecode(base.Request["strTitle"].ToString());
                }
            }
            else if (base.Request["mainPK"] == null)
            {
                this._strTitle = "新增" + base.Server.UrlDecode(base.Request["strTitle"].ToString());
                this.LBTitle = "乡镇财政资金监管信息系统 - 新增" + base.Server.UrlDecode(base.Request["strTitle"].ToString());
            }
            else
            {
                this._strTitle = base.Server.UrlDecode(base.Request["strTitle"].ToString());
                this.LBTitle = "乡镇财政资金监管信息系统 - " + base.Server.UrlDecode(base.Request["strTitle"].ToString());
            }
        }
        string s = "633";
        if (base.Request.Cookies["hei"] != null)
        {
            s = base.Request.Cookies["hei"].Value;
        }
        this.hei = int.Parse(s) + 100;
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
}
