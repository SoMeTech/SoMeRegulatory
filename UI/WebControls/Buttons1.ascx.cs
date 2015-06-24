using ASP;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using System;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class WebControls_Buttons1 : UserControl
{
    private ButtonsModel _bm = new ButtonsModel("");
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
        if (this._bm != null)
        {
            if (this._bm.IfAdd)
            {
                num += 50;
                string str2 = Public.RelativelyPath(this._bm.IbtAddUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtadd\" id=\"ibtcontrol_ibtadd\" src=\"" + str2 + "\" style=\"border-width:0px;\" onclick=\"javascript:PageSubmit('ibtcontrol_ibtadd');\"/></td>";
            }
            if (this._bm.IfUpdate)
            {
                num += 50;
                string str3 = Public.RelativelyPath(this._bm.IbtUpdateUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtupdate\" id=\"ibtcontrol_ibtupdate\" src=\"" + str3 + "\" style=\"border-width:0px;\" onclick=\"javascript:PageSubmit('ibtcontrol_ibtupdate');\"/></td>";
            }
            if (this._bm.IfSave)
            {
                num += 50;
                string str4 = Public.RelativelyPath(this._bm.IbtSaveUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtsave\" id=\"ibtcontrol_ibtsave\" src=\"" + str4 + "\" style=\"border-width:0px;\" onclick=\"javascript:PageSubmit('ibtcontrol_ibtsave');\"/></td>";
            }
            if (this._bm.IfDelete)
            {
                num += 50;
                string str5 = Public.RelativelyPath(this._bm.IbtDeleteUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtdelete\" id=\"ibtcontrol_ibtdelete\" src=\"" + str5 + "\" style=\"border-width:0px;\" onclick=\"javascript:PageSubmit('ibtcontrol_ibtdelete');\"/></td>";
            }
            if (this._bm.IfLook)
            {
                num += 50;
                string str6 = Public.RelativelyPath(this._bm.IbtLookUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtlook\" id=\"ibtcontrol_ibtlook\" src=\"" + str6 + "\" style=\"border-width:0px;\" onclick=\"javascript:PageSubmit('ibtcontrol_ibtlook');\"/></td>";
            }
            if (this._bm.IfSearch)
            {
                num += 50;
                string str7 = Public.RelativelyPath(this._bm.IbtSearchUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtsearch\" id=\"ibtcontrol_ibtsearch\" src=\"" + str7 + "\" style=\"border-width:0px;\" onclick=\"javascript:PageSubmit('ibtcontrol_ibtsearch');\"/></td>";
            }
            if (this._bm.IfRefresh)
            {
                num += 50;
                string str8 = Public.RelativelyPath(this._bm.IbtRefreshUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtrefresh\" id=\"ibtcontrol_ibtrefresh\" src=\"" + str8 + "\" style=\"border-width:0px;\" onclick=\"javascript:PageSubmit('ibtcontrol_ibtrefresh');\"/></td>";
            }
            if (this._bm.IfHuiZong)
            {
                num += 50;
                string str9 = Public.RelativelyPath(this._bm.IbtHuiZongUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibthuizong\" id=\"ibtcontrol_ibthuizong\" src=\"" + str9 + "\" style=\"border-width:0px;\"/ onclick=\"javascript:PageSubmit('ibtcontrol_ibthuizong');\"></td>";
            }
            if (this._bm.IfDerate)
            {
                num += 50;
                string str10 = Public.RelativelyPath(this._bm.IbtDerateUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtderate\" id=\"ibtcontrol_ibtderate\" src=\"" + str10 + "\" style=\"border-width:0px;\"/ onclick=\"javascript:PageSubmit('ibtcontrol_ibtderate');\"></td>";
            }
            if (this._bm.IfMoney)
            {
                num += 50;
                string str11 = Public.RelativelyPath(this._bm.IbtMoneyUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtmoney\" id=\"ibtcontrol_ibtmoney\" src=\"" + str11 + "\" style=\"border-width:0px;\"/ onclick=\"javascript:PageSubmit('ibtcontrol_ibtmoney');\"></td>";
            }
            if (this._bm.IfAudit)
            {
                num += 50;
                string str12 = Public.RelativelyPath(this._bm.IbtAuditUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtaudit\" id=\"ibtcontrol_ibtaudit\" src=\"" + str12 + "\" style=\"border-width:0px;\"/ onclick=\"javascript:PageSubmit('ibtcontrol_ibtaudit');\"></td>";
            }
            if (this._bm.IfApply)
            {
                num += 50;
                string str13 = Public.RelativelyPath(this._bm.IbtApplyUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtapply\" id=\"ibtcontrol_ibtapply\" src=\"" + str13 + "\" style=\"border-width:0px;\"/ onclick=\"javascript:PageSubmit('ibtcontrol_ibtapply');\"></td>";
            }
            if (this._bm.IfDo)
            {
                num += 50;
                string str14 = Public.RelativelyPath(this._bm.IbtDoUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtdo\" id=\"ibtcontrol_ibtdo\" src=\"" + str14 + "\" style=\"border-width:0px;\"/ onclick=\"javascript:PageSubmit('ibtcontrol_ibtdo');\"></td>";
            }
            if (this._bm.IfImpower)
            {
                num += 50;
                string str15 = Public.RelativelyPath(this._bm.IbtImpowerUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtimpower\" id=\"ibtcontrol_ibtimpower\" src=\"" + str15 + "\" style=\"border-width:0px;\"/ onclick=\"javascript:PageSubmit('ibtcontrol_ibtimpower');\"></td>";
            }
            if (this._bm.IfPaper)
            {
                num += 50;
                string str16 = Public.RelativelyPath(this._bm.IbtPaperUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtpaper\" id=\"ibtcontrol_ibtpaper\" src=\"" + str16 + "\" style=\"border-width:0px;\"/ onclick=\"javascript:PageSubmit('ibtcontrol_ibtpaper');\"></td>";
            }
            if (this._bm.IfPutOut)
            {
                num += 50;
                string str17 = Public.RelativelyPath(this._bm.IbtPutOutUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtputout\" id=\"ibtcontrol_ibtputout\" src=\"" + str17 + "\" style=\"border-width:0px;\"/ onclick=\"javascript:PageSubmit('ibtcontrol_ibtputout');\"></td>";
            }
            if (this._bm.IfPrintNote)
            {
                num += 50;
                string str18 = Public.RelativelyPath(this._bm.IbtPrintNoteUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtputout\" id=\"ibtcontrol_ibtputout\" src=\"" + str18 + "\" style=\"border-width:0px;\"/ onclick=\"javascript:PageSubmit('ibtcontrol_ibtprintnote');\"></td>";
            }
            if (this._bm.IfSet)
            {
                num += 50;
                string str19 = Public.RelativelyPath(this._bm.IbtSetUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtset\" id=\"ibtcontrol_ibtset\" src=\"" + str19 + "\" style=\"border-width:0px;\"/ onclick=\"javascript:PageSubmit('ibtcontrol_ibtset');\"></td>";
            }
            if (this._bm.IfSetBack)
            {
                num += 50;
                string str20 = Public.RelativelyPath(this._bm.IbtSetBackUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtsetback\" id=\"ibtcontrol_ibtsetback\" src=\"" + str20 + "\" style=\"border-width:0px;\"/ onclick=\"javascript:PageSubmit('ibtcontrol_ibtsetback');\"></td>";
            }
            if (this._bm.IfRollBack)
            {
                num += 50;
                string str21 = Public.RelativelyPath(this._bm.IbtRollBackUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtrollback\" id=\"ibtcontrol_ibtrollback\" src=\"" + str21 + "\" style=\"border-width:0px;\"/ onclick=\"javascript:PageSubmit('ibtcontrol_ibtrollback');\"></td>";
            }
            if (this._bm.IfDispose)
            {
                num += 50;
                string str22 = Public.RelativelyPath(this._bm.IbtDisposeUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtdispose\" id=\"ibtcontrol_ibtdispose\" src=\"" + str22 + "\" style=\"border-width:0px;\"/ onclick=\"javascript:PageSubmit('ibtcontrol_ibtdispose');\"></td>";
            }
            if (this._bm.IfExit)
            {
                num += 50;
                string str23 = Public.RelativelyPath(this._bm.IbtExitUrl);
                str = str + "<td align=\"center\" style=\"width: 50px\"><input type=\"image\" name=\"ibtcontrol_ibtexit\" id=\"ibtcontrol_ibtexit\" src=\"" + str23 + "\" style=\"border-width:0px;\" onclick=\"javascript:PageSubmit('ibtcontrol_ibtexit');\"/></td>";
            }
            str = str.Insert(0, "<table width=\"" + num.ToString() + "px\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" ><tr>") + "</tr><tr>";
            if (this._bm.IfAdd)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtAddText + "</td>";
            }
            if (this._bm.IfUpdate)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtUpdateText + "</td>";
            }
            if (this._bm.IfSave)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtSaveText + "</td>";
            }
            if (this._bm.IfDelete)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtDeleteText + "</td>";
            }
            if (this._bm.IfLook)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtLookText + "</td>";
            }
            if (this._bm.IfSearch)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtSearchText + "</td>";
            }
            if (this._bm.IfRefresh)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtRefreshText + "</td>";
            }
            if (this._bm.IfHuiZong)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtHuiZongText + "</td>";
            }
            if (this._bm.IfDerate)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtDerateText + "</td>";
            }
            if (this._bm.IfMoney)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtMoneyText + "</td>";
            }
            if (this._bm.IfAudit)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtAuditText + "</td>";
            }
            if (this._bm.IfApply)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtApplyText + "</td>";
            }
            if (this._bm.IfDo)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtDoText + "</td>";
            }
            if (this._bm.IfImpower)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtImpowerText + "</td>";
            }
            if (this._bm.IfPaper)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtPaperText + "</td>";
            }
            if (this._bm.IfPutOut)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtPutOutText + "</td>";
            }
            if (this._bm.IfPrintNote)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtPrintNoteText + "</td>";
            }
            if (this._bm.IfSet)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtSetText + "</td>";
            }
            if (this._bm.IfSetBack)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtSetBackText + "</td>";
            }
            if (this._bm.IfRollBack)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtRollBackText + "</td>";
            }
            if (this._bm.IfDispose)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtDisposeText + "</td>";
            }
            if (this._bm.IfExit)
            {
                str = str + "<td align=\"center\" style=\"width: 50px\">" + this._bm.IbtExitText + "</td>";
            }
            str = str + "</tr></table>";
        }
        this.divbutton.InnerHtml = str;
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public ButtonsModel BM
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
