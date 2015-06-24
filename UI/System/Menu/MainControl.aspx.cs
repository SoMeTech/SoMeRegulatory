using ASP;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Menu_MainControl : Page, IRequiresSessionState
{
    private DB_OPT dbo;
    protected HtmlForm form1;
    protected Label lbBanBen;
    protected TreeView TreeView1;

    public void AddTreeNode(TreeNode tn, DataRow dr, DataSet ds)
    {
        TreeNode child = new TreeNode(dr["MenuName"].ToString(), dr["PowerCode"].ToString(), "~/" + dr["ImgUrl"].ToString(), "~/" + dr["PageUrl"].ToString(), dr["OpenType"].ToString());
        if ((dr["IsHasBaby"].ToString() == "1") || (dr["PageUrl"].ToString() == ""))
        {
            child.SelectAction = TreeNodeSelectAction.None;
        }
        tn.ChildNodes.Add(child);
        if (dr["IsHasBaby"].ToString() == "1")
        {
            foreach (DataRow row in ds.Tables[0].Select("Grade='" + Convert.ToString((int)(int.Parse(dr["Grade"].ToString()) + 1)) + "' and IsShow='1' and FatherPK='" + dr["MemuPK"].ToString() + "'"))
            {
                this.AddTreeNode(child, row, ds);
            }
        }
    }

    private void BindTV(DB_OPT dbo)
    {
        MenuModel model = new MenuDal();
        string str = ((UserModel)this.Session["User"]).Power.Replace('|', ',');
        string strWhere = "";
        if (((UserModel)this.Session["User"]).UserName != "admin")
        {
            strWhere = " PowerCode in (" + str + ")";
        }
        DataSet list = model.GetList(strWhere, dbo);
        this.GetTreeView(list);
    }

    public void GetTreeView(DataSet ds)
    {
        TreeNode tn = new TreeNode("瘦马科技")
        {
            SelectAction = TreeNodeSelectAction.None
        };
        foreach (DataRow row in ds.Tables[0].Select("Grade='0' and IsShow='1'"))
        {
            this.AddTreeNode(tn, row, ds);
        }
        this.TreeView1.Nodes.Add(tn);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            try
            {
                this.dbo = new DB_OPT();
                this.dbo.Open();
                this.BindTV(this.dbo);
            }
            catch (Exception)
            {
            }
            finally
            {
                this.dbo.Close();
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

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }
}
