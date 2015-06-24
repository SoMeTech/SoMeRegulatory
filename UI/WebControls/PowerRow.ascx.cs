using ASP;
using SoMeTech.CommonDll;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using QxRoom.Common;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControls_PowerRow : UserControl
{
    private string powerstr = "";
    private string powerstrtext = "";
    protected TreeView TreeView1;

    public void AddTreeNode(TreeNode tn, DataRow dr, DataSet ds, LoadData[] lds)
    {
        TreeNode child = new TreeNode(GetChineseName(dr["TableName"].ToString(), lds), dr["PowerCode"].ToString());
        tn.ChildNodes.Add(child);
        tn.SelectAction = TreeNodeSelectAction.Expand;
        DataRow[] rowArray = ds.Tables[0].Select("TableName='" + dr["TableName"].ToString() + "'");
        if (rowArray.Length > 0)
        {
            foreach (DataRow row in rowArray)
            {
                TreeNode node2 = new TreeNode(row["Name"].ToString(), row["PowerCode"].ToString());
                child.ChildNodes.Add(node2);
                child.SelectAction = TreeNodeSelectAction.Expand;
                node2.SelectAction = TreeNodeSelectAction.None;
            }
        }
    }

    public void BindTV(DB_OPT dbo)
    {
        DataSet list = new DataRowPowerItemDal().GetList("", dbo);
        this.GetTreeView(list);
    }

    public static string GetChineseName(string tablename, LoadData[] lds)
    {
        foreach (LoadData data in lds)
        {
            if (data.TableName == tablename)
            {
                return data.TextName;
            }
        }
        return "";
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
        int num = 0;
        DataTable table = new DataTable();
        table.Columns.Add(new DataColumn("PK"));
        table.Columns.Add(new DataColumn("Name"));
        table.Columns.Add(new DataColumn("PowerCode"));
        table.Columns.Add(new DataColumn("TableName"));
        table.Columns.Add(new DataColumn("QXList"));
        table.Columns.Add(new DataColumn("strWhere"));
        table.Columns.Add(new DataColumn("ShowTJ"));
        table.Columns.Add(new DataColumn("Discription"));
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            foreach (DataRow row2 in table.Rows)
            {
                if (row["TableName"].ToString() == row2["TableName"].ToString())
                {
                    num++;
                    break;
                }
            }
            if (num == 0)
            {
                DataRow row3 = table.NewRow();
                row3["PK"] = row["PK"].ToString();
                row3["Name"] = row["Name"].ToString();
                row3["PowerCode"] = row["PowerCode"].ToString();
                row3["TableName"] = row["TableName"].ToString();
                row3["QXList"] = row["QXList"].ToString();
                row3["strWhere"] = row["strWhere"].ToString();
                row3["ShowTJ"] = row["ShowTJ"].ToString();
                row3["Discription"] = row["Discription"].ToString();
                table.Rows.Add(row3);
                num = 0;
            }
        }
        LoadData[] lds = LoadData.LoadXml(Public.GetServerPath() + @"\\bin\\DataMessage.xml");
        foreach (DataRow row4 in table.Rows)
        {
            this.AddTreeNode(tn, row4, ds, lds);
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
