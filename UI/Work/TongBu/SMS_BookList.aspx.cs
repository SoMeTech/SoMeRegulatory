using ASP;
using SoMeTech.Data;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Input_SMS_SMS_BookList : Page, IRequiresSessionState
{
    protected Button btnok;
    private DataView dv;
    protected HtmlForm form1;
    protected TreeView TreeView1;

    public void btnok_onclick(object sender, EventArgs e)
    {
    }

    public void CreateTree(string parentID, TreeNode node, DataTable dt, TreeView treeView)
    {
        this.dv = new DataView(dt);
        this.dv.RowFilter = "[FatherPK]=" + parentID;
        foreach (DataRowView view in this.dv)
        {
            if (node == null)
            {
                TreeNode child = new TreeNode
                {
                    Text = view["Name"].ToString(),
                    Value = view["PK_CORP"].ToString()
                };
                this.TreeView1.Nodes.Add(child);
                this.CreateTree(view["PK_CORP"].ToString(), child, dt, treeView);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            Convert.ToInt32(this.Session["userID"]);
            DataSet set = DbHelperSQL.Query("select distinct gsdm as PK_CORP,gsmc as Name,case len(gsdm) when 2 then 0 else 1 end as  Grade,substring(gsdm,1,2) as [FatherPK] from PubGszl where kjnd=(select max(kjnd) from PubGszl) and gsdm like '01%'");
            this.CreateTree("01", null, set.Tables[0], this.TreeView1);
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
