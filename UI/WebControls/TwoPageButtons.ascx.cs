using ASP;
using QxRoom.Common;
using System;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class WebControls_TwoPageButtons : UserControl
{
    private TwoPageButtonsModel _bm = new TwoPageButtonsModel("");
    protected HtmlGenericControl divbutton;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.ShowButtons();
        }
    }

    private void ShowButtons()
    {
        string str = "";
        int num = 0;
        if (this._bm.IfAddTwo)
        {
            num += 50;
            string str2 = Public.RelativelyPath(this._bm.IbtAddUrlTwo);
            str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtaddtwo\" id=\"ibtcontrol_ibtaddtwo\" src=\"" + str2 + "\" style=\"border-width:0px;\" onclick=\"javascript:PageSubmit('ibtcontrol_ibtaddtwo');\"/></td>";
        }
        if (this._bm.IfUpdateTwo)
        {
            num += 50;
            string str3 = Public.RelativelyPath(this._bm.IbtUpdateUrlTwo);
            str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtupdatetwo\" id=\"ibtcontrol_ibtupdatetwo\" src=\"" + str3 + "\" style=\"border-width:0px;\" onclick=\"javascript:PageSubmit('ibtcontrol_ibtupdatetwo');\"/></td>";
        }
        if (this._bm.IfDeleteTwo)
        {
            num += 50;
            string str4 = Public.RelativelyPath(this._bm.IbtDeleteUrlTwo);
            str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtdeletetwo\" id=\"ibtcontrol_ibtdeletetwo\" src=\"" + str4 + "\" style=\"border-width:0px;\" onclick=\"javascript:PageSubmit('ibtcontrol_ibtdeletetwo');\"/></td>";
        }
        str = str.Insert(0, "<table width=\"" + num.ToString() + "px\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tr>") + "</tr><tr></tr></table>";
        this.divbutton.InnerHtml = str;
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public TwoPageButtonsModel BM
    {
        get
        {
            return this._bm;
        }
        set
        {
            this._bm = value;
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
