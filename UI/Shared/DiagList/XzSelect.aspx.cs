using ASP;
using SoMeTech.Data;
using SoMeTech.User;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Shared_DiagList_XzSelect : Page, IRequiresSessionState
{
    protected HtmlForm form1;
    protected Label lblcont;

    private void bindData()
    {
        DataSet set = DbHelperOra.Query("select pk_corp,name from db_company where fatherpk='" + ((UserModel)this.Session["user"]).Company.pk_corp + "'");
        string str = "";
        if (set.Tables.Count > 0)
        {
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                if ((i % 5) == 0)
                {
                    str = str + "</br></br>";
                }
                string str2 = str;
                str = str2 + "<input type='checkbox' value='" + set.Tables[0].Rows[i][0].ToString() + "' name='" + set.Tables[0].Rows[i][1].ToString() + "' />" + set.Tables[0].Rows[i][1].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            this.lblcont.Text = str;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.bindData();
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
