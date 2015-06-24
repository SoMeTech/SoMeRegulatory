using ASP;
using SoMeTech.User;
using System;
using System.Reflection;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Work_DataPrint_Excel_GetSystemParame : Page, IRequiresSessionState
{
    protected HtmlForm form1;
    protected HtmlInputHidden NowData;
    protected TreeView tree1;

    public void GetSystemParam(string family)
    {
        Type t = new UserModel().GetType();
        TreeNode child = new TreeNode("系统参数", "")
        {
            SelectAction = TreeNodeSelectAction.None
        };
        this.tree1.Nodes.Add(child);
        if (family != null)
        {
            string[] familyList = family.Split(new char[] { '.' });
            this.GetSystemParam_DG(familyList, t, 0, child);
        }
        else
        {
            this.GetSystemParam_DG(null, t, 0, child);
        }
    }

    private void GetSystemParam_DG(string[] familyList, Type t, int p, TreeNode FatherTN)
    {
        foreach (PropertyInfo info in t.GetProperties())
        {
            TreeNode child = new TreeNode();
            if (info.PropertyType.BaseType != typeof(Array))
            {
                child.SelectAction = TreeNodeSelectAction.Expand;
                child.Text = info.Name;
                child.ToolTip = FatherTN.ToolTip + "." + info.Name;
                FatherTN.ChildNodes.Add(child);
            }
            if (familyList != null)
            {
                string str;
                if (p >= familyList.Length)
                {
                    return;
                }
                if ((info.PropertyType.IsClass && (info.PropertyType.BaseType != typeof(Array))) && (((str = info.PropertyType.FullName) == null) || (str != "System.String")))
                {
                    this.GetSystemParam_DG(familyList, info.PropertyType, p + 1, child);
                }
            }
            else
            {
                string str2;
                if ((((p <= 1) && info.PropertyType.IsClass) && (info.PropertyType.BaseType != typeof(Array))) && (((str2 = info.PropertyType.FullName) == null) || (str2 != "System.String")))
                {
                    this.GetSystemParam_DG(familyList, info.PropertyType, p + 1, child);
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsCallback)
        {
            this.tree1.Attributes.Add("onclick", "javascrpit:CheckEvent();");
            this.GetSystemParam(null);
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
