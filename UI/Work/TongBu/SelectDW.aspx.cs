using ASP;
using System;
using System.IO;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Work_TongBu_SelectDW : Page, IRequiresSessionState
{
    protected HtmlForm form1;
    protected TreeView Treeview1;

    protected void LoadChildNode(TreeNode node)
    {
        DirectoryInfo info = new DirectoryInfo(node.Value);
        foreach (DirectoryInfo info2 in info.GetDirectories())
        {
            TreeNode child = new TreeNode(info2.Name)
            {
                Value = info2.FullName
            };
            try
            {
                if ((info2.GetDirectories().Length > 0) || (info2.GetFiles().Length > 0))
                {
                    child.SelectAction = TreeNodeSelectAction.SelectExpand;
                    child.PopulateOnDemand = true;
                    child.NavigateUrl = "#";
                }
            }
            catch
            {
                child.ImageUrl = "WebResource.axd?a=s&r=TreeView_XP_Explorer_ParentNode.gif&t=632242003305625000";
            }
            node.ChildNodes.Add(child);
        }
        foreach (FileInfo info3 in info.GetFiles())
        {
            TreeNode node3 = new TreeNode(info3.Name);
            node.ChildNodes.Add(node3);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Treeview1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (base.IsCallback && (e.Node.ChildNodes.Count == 0))
        {
            this.LoadChildNode(e.Node);
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
