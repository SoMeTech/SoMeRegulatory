using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class User_DataPower : Page, IRequiresSessionState
{
    protected Button btDo;
    protected Button btSearch;
    protected DropDownList ddltablename;
    protected DropDownList DropDownList1;
    protected DropDownList DropDownList2;
    protected DropDownList DropDownList3;
    protected HtmlForm form1;
    protected GridView gvResult;
    protected HtmlInputText ifadd;
    protected manager_PageControl pcPage;
    protected HtmlInputText pk;
    protected TextBox TextBox1;
    protected HtmlInputText tn;
    protected TextBox txtDiscription;

    protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void gvResult_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

    protected void gvResult_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
    }

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

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }
}
