using ASP;
using SoMeTech.CommonDll;
using SoMeTech.DataAccess;
using SoMeTech.ServicesClass.Operation;
using SoMeTech.ServicesClass.Services;
using SoMeTech.User;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControls_PowerServices : UserControl
{
    private string powerstr = "";
    private string powerstrtext = "";
    protected TreeView TreeView1;

    public void AddTreeNode(TreeNode tn, DataRow dr)
    {
        TreeNode child = new TreeNode(dr["Name"].ToString(), dr["PK"].ToString())
        {
            SelectAction = TreeNodeSelectAction.None
        };
        tn.ChildNodes.Add(child);
    }

    public void AddTreeNode(TreeNode tn, DataRow dr, DataSet ds, DB_OPT dbo)
    {
        TreeNode child = new TreeNode(dr["Name"].ToString(), dr["PK"].ToString())
        {
            SelectAction = TreeNodeSelectAction.Expand,
            ShowCheckBox = false
        };
        tn.ChildNodes.Add(child);
        TreeNode node2 = new TreeNode("List", "")
        {
            SelectAction = TreeNodeSelectAction.Expand,
            ShowCheckBox = false
        };
        TreeNode node3 = new TreeNode("Detail", "")
        {
            SelectAction = TreeNodeSelectAction.Expand,
            ShowCheckBox = false
        };
        child.ChildNodes.Add(node2);
        child.ChildNodes.Add(node3);
        ServicesMessModel model = new ServicesMessDal();
        string strWhere = "";
        if (((UserModel)base.Session["User"]).UserName == "admin")
        {
            strWhere = "OperationPK='" + dr["PK"].ToString() + "' and ISSAVE=1 ";
        }
        else
        {
            strWhere = "OperationPK='" + dr["PK"].ToString() + "' and CompanyPK='" + ((UserModel)base.Session["User"]).pk_corp + "' and ISSAVE=1 ";
        }
        foreach (DataRow row in model.GetList(strWhere, dbo).Tables[0].Rows)
        {
            if (row["name"].ToString().IndexOf("list") >= 0)
            {
                this.AddTreeNode_SM(node2, row);
            }
            else
            {
                this.AddTreeNode_SM(node3, row);
            }
        }
    }

    public void AddTreeNode_SM(TreeNode tn, DataRow dr)
    {
        if (dr["PowerCode"].ToString() != "")
        {
            TreeNode child = new TreeNode(dr["Name"].ToString(), dr["PowerCode"].ToString())
            {
                SelectAction = TreeNodeSelectAction.None
            };
            tn.ChildNodes.Add(child);
        }
    }

    public void BindTV(DB_OPT dbo)
    {
        DataSet list = new BusinessMessDal().GetList("", dbo);
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
        foreach (TreeNode node in tn.ChildNodes)
        {
            if (node.Checked && (node.Value != ""))
            {
                this.powerstr = this.powerstr + node.Value + "|";
            }
            if ((node.ChildNodes != null) && (node.ChildNodes.Count > 0))
            {
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
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            this.AddTreeNode(tn, row, ds, dbo);
        }
        this.TreeView1.Nodes.Add(tn);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.TreeView1.Attributes.Add("onclick", "javascrpit:CheckEvent();");
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
