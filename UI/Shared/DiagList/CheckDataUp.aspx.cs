using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Shared_CheckDataUp : Page, IRequiresSessionState
{
    protected HtmlForm form1;
    protected Label lbID;
    protected Label lbMC;
    public string MSSQLStr = "";
    protected HtmlInputText txtID;
    protected HtmlInputText txtMC;

    protected void Page_Load(object sender, EventArgs e)
    {
        UsualBookTable table = new UsualBookTable();
        table = (UsualBookTable)this.Session["UsualBookTable"];
        if (base.Request["MSSQL"] != null)
        {
            this.MSSQLStr = "&MSSQL=" + base.Request["MSSQL"];
        }
        if (!this.Page.IsPostBack && (table != null))
        {
            this.lbID.Text = table.Columns.Split(new char[] { char.Parse(",") })[0].Split(new char[] { char.Parse(" ") })[2].Trim() + "：";
            this.lbMC.Text = table.Columns.Split(new char[] { char.Parse(",") })[1].Split(new char[] { char.Parse(" ") })[2].Trim() + "：";
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
