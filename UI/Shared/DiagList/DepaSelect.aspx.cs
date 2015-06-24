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

public class Shared_DiagList_DepaSelect : Page, IRequiresSessionState
{
    protected HtmlForm form1;
    protected HtmlHead Head1;
    protected Label lblcont;

    private void bindData()
    {
        string sQLString = "";
        if (((UserModel)this.Session["user"]).Branch.Name.Trim() == "乡财局")
        {
            sQLString = "select bh,name from db_branch where pk_corp='03'";
        }
        else
        {
            sQLString = "select bh,name from db_branch where bh='" + ((UserModel)this.Session["user"]).Branch.BH + "' and pk_corp='03'";
        }
        DataSet set = DbHelperOra.Query(sQLString);
        string str2 = "<table align='center' width='100%' cellpadding='6px'><tr><td style='width:20px'>序号</td><td style='width:20px'>选择</td><td style='width:100px'>部门名称</td></tr>";
        if ((set.Tables.Count > 0) && (set.Tables[0].Rows.Count > 0))
        {
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                string str3 = str2 + "<tr><td>" + ((i + 1)).ToString() + "</td><td>";
                str2 = (str3 + "<input type='checkbox' value='" + set.Tables[0].Rows[i][0].ToString() + "' name='" + set.Tables[0].Rows[i][1].ToString() + "' />") + "</td><td>" + set.Tables[0].Rows[i][1].ToString() + "</td></tr>";
            }
        }
        this.lblcont.Text = str2 + "</table>";
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
