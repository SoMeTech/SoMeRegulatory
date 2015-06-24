using ASP;
using SoMeTech.CommonDll;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControls_PowerMenu : UserControl
{
    private string powerstr = "";
    private string powerstrtext = "";
    protected TreeView TreeView1;

    public void AddTreeNode(TreeNode tn, DataRow dr, DataSet ds)
    {
        TreeNode child = new TreeNode(dr["MenuName"].ToString(), dr["PowerCode"].ToString());
        if ((dr["IsHasBaby"].ToString() == "1") || (dr["PageUrl"].ToString() == ""))
        {
            child.SelectAction = TreeNodeSelectAction.Expand;
        }
        else
        {
            child.SelectAction = TreeNodeSelectAction.None;
        }
        tn.ChildNodes.Add(child);
        if (dr["IsHasBaby"].ToString() == "1")
        {
            foreach (DataRow row in ds.Tables[0].Select("Grade='" + Convert.ToString((int)(int.Parse(dr["Grade"].ToString()) + 1)) + "' and IsCheckPower='1' and FatherPK='" + dr["MemuPK"].ToString() + "'"))
            {
                this.AddTreeNode(child, row, ds);
            }
        }
    }

    public void BindTV(DB_OPT dbo)
    {
        DataSet list = new MenuDal().GetList("", dbo);
        this.GetTreeView(list);
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

    public void GetTreeView(DataSet ds)
    {
        TreeNode tn = new TreeNode();
        tn = PublicDal.getConfigurationList();
        foreach (DataRow row in ds.Tables[0].Select("Grade='0' and IsCheckPower='1'"))
        {
            this.AddTreeNode(tn, row, ds);
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
