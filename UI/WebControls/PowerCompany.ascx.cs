using ASP;
using SoMeTech.CommonDll;
using SoMeTech.Company;
using SoMeTech.Company.Branch;
using SoMeTech.DataAccess;
using SoMeTech.User;
using System;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControls_PowerCompany : UserControl
{
    private string powerstr = "";
    private string powerstrtext = "";
    protected TreeView TreeView1;

    public void AddTreeNode(TreeNode tn, DataRow dr)
    {
        TreeNode child = new TreeNode(dr["Name"].ToString(), dr["pk_corp"].ToString())
        {
            SelectAction = TreeNodeSelectAction.None
        };
        tn.ChildNodes.Add(child);
    }

    public void AddTreeNode(TreeNode tn, DataRow dr, DataSet ds, DB_OPT dbo)
    {
        TreeNode child = new TreeNode(dr["Name"].ToString(), dr["pk_corp"].ToString())
        {
            SelectAction = TreeNodeSelectAction.Expand
        };
        tn.ChildNodes.Add(child);
        DataSet list = new BranchDal().GetList("pk_corp='" + dr["pk_corp"].ToString() + "'", dbo);
        if ((list != null) && (list.Tables[0].Rows.Count > 0))
        {
            TreeNode node2 = new TreeNode();
            node2 = new TreeNode("下属部门", "")
            {
                ShowCheckBox = false,
                SelectAction = TreeNodeSelectAction.Expand
            };
            child.ChildNodes.Add(node2);
            foreach (DataRow row in list.Tables[0].Rows)
            {
                this.AddTreeNode_BM(node2, row);
            }
        }
        if (dr["IsHasBaby"].ToString() == "1")
        {
            TreeNode node3 = new TreeNode();
            node3 = new TreeNode("下级单位", "")
            {
                ShowCheckBox = false,
                SelectAction = TreeNodeSelectAction.Expand
            };
            child.ChildNodes.Add(node3);
            foreach (DataRow row2 in ds.Tables[0].Select("Grade='" + Convert.ToString((int)(int.Parse(dr["Grade"].ToString()) + 1)) + "' and FatherPK='" + dr["pk_corp"].ToString() + "'"))
            {
                this.AddTreeNode(node3, row2, ds, dbo);
            }
        }
    }

    public void AddTreeNode_BM(TreeNode tn, DataRow dr)
    {
        TreeNode child = new TreeNode(dr["Name"].ToString(), dr["BH"].ToString())
        {
            SelectAction = TreeNodeSelectAction.None
        };
        tn.ChildNodes.Add(child);
    }

    public void BindTV(DB_OPT dbo)
    {
        StringBuilder builder = new StringBuilder();
        if (!((UserModel)base.Session["User"]).UserName.Equals("admin"))
        {
            builder.Append(" pk_corp like '");
            builder.Append(((UserModel)base.Session["User"]).Company.pk_corp);
            builder.Append("%'");
        }
        DataSet list = new CompanyDal().GetList(builder.ToString(), dbo);
        this.GetTreeView(list, dbo);
    }

    public string GetPower()
    {
        string powerStr = "";
        foreach (TreeNode node in this.TreeView1.Nodes)
        {
            powerStr = this.GetPowerStr(node);
        }
        if (powerStr.Length > 0)
        {
            powerStr = powerStr.Substring(0, powerStr.Length - 1);
        }
        this.powerstr = "";
        return powerStr;
    }

    private string GetPowerStr(TreeNode tn)
    {
        if ((tn.ChildNodes != null) && (tn.ChildNodes.Count > 0))
        {
            foreach (TreeNode node in tn.ChildNodes)
            {
                if (node.Checked && (node.Value != ""))
                {
                    this.powerstr = this.powerstr.Trim() + node.Value.Trim() + "|";
                }
                this.GetPowerStr(node);
            }
        }
        return this.powerstr;
    }

    private string GetPowerStrText(TreeNode tn)
    {
        if ((tn.ChildNodes != null) && (tn.ChildNodes.Count > 0))
        {
            foreach (TreeNode node in tn.ChildNodes)
            {
                if (node.Checked && (node.Text != ""))
                {
                    this.powerstrtext = this.powerstrtext + node.Text + "|";
                }
                this.GetPowerStrText(node);
            }
        }
        return this.powerstrtext;
    }

    public string GetPowerText()
    {
        string powerStrText = "";
        foreach (TreeNode node in this.TreeView1.Nodes)
        {
            powerStrText = this.GetPowerStrText(node);
        }
        if (powerStrText.Length > 0)
        {
            powerStrText = powerStrText.Substring(0, powerStrText.Length - 1);
        }
        this.powerstrtext = "";
        return powerStrText;
    }

    public void GetTreeView(DataSet ds, DB_OPT dbo)
    {
        TreeNode tn = new TreeNode();
        tn = PublicDal.getConfigurationList();
        foreach (DataRow row in ds.Tables[0].Select("Grade='0'"))
        {
            this.AddTreeNode(tn, row, ds, dbo);
        }
        this.TreeView1.Nodes.Add(tn);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.TreeView1.Attributes.Add("onclick", "javascrpit:CheckEvent();");
        bool isPostBack = this.Page.IsPostBack;
    }

    public void SetChecked(string powerstr1)
    {
        this.SetPowerTree(this.TreeView1.FindNode(PublicDal.getConfigurationList().Value.ToString()), powerstr1);
    }

    private void SetChildChecked(TreeNode p_Node)
    {
        foreach (TreeNode node in p_Node.ChildNodes)
        {
            node.Checked = p_Node.Checked;
            if (node.ChildNodes.Count > 0)
            {
                this.SetChildChecked(node);
            }
        }
    }

    private void SetParentChecked(TreeNode p_Node)
    {
        if (p_Node.Parent != null)
        {
            int num = 0;
            TreeNode parent = p_Node.Parent;
            foreach (TreeNode node2 in parent.ChildNodes)
            {
                if (node2.Checked)
                {
                    num++;
                }
            }
            if (num > 0)
            {
                parent.Checked = true;
            }
            else
            {
                parent.Checked = false;
            }
            if (parent.Parent != null)
            {
                this.SetParentChecked(parent);
            }
        }
    }

    private void SetPowerTree(TreeNode tn, string powerstr1)
    {
        foreach (TreeNode node in tn.ChildNodes)
        {
            node.Checked = PowerClass.IfHasPower("", powerstr1, node.Value);
            this.SetPowerTree(node, powerstr1);
        }
    }

    protected void TreeView1_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
    {
        this.SetChildChecked(e.Node);
        this.SetParentChecked(e.Node);
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
