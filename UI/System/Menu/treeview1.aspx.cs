using ASP;
using ExceptionLog;
using SoMeTech.CommonDll;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Menu_treeview1 : Page, IRequiresSessionState
{
    private DB_OPT dbo;
    private ExceptionLog.ExceptionLog el;
    protected HtmlForm form1;
    protected HtmlHead Head1;
    protected HtmlTableCell menuheight;
    protected Panel panel1;
    protected TreeView TreeView1;

    public void AddTreeNode(TreeNode tn, DataRow dr, DataSet ds)
    {
        TreeNode child = new TreeNode(dr["MenuName"].ToString(), dr["PowerCode"].ToString(), "~/" + dr["ImgUrl"].ToString(), "", dr["opentype"].ToString());
        if (dr["VisitPoint"].ToString().Trim() == "1")
        {
            child.Expanded = true;
        }
        if ((dr["IsHasBaby"].ToString() == "1") || (dr["PageUrl"].ToString() == ""))
        {
            child.SelectAction = TreeNodeSelectAction.Expand;
        }
        else
        {
            child.Value = dr["opentype"].ToString();
            if (dr["PageUrl"].ToString().Trim() != "")
            {
                child.ToolTip = dr["opentype"].ToString() + "|" + dr["PageUrl"].ToString();
            }
            child.SelectAction = TreeNodeSelectAction.Expand;
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
        if (this.Session["User"] != null)
        {
            string power = ((UserModel)this.Session["User"]).Power;
            if (power != "")
            {
                string strWhere = "";
                if (((UserModel)this.Session["User"]).UserName != "admin")
                {
                    strWhere = "patindex('%|'||rtrim(PowerCode)||'|%','|" + power + "|')>0 or ISCHECKPOWER='0'";
                }
                DataSet list = model.GetList(strWhere, dbo);
                this.GetTreeView(list);
            }
        }
    }

    public void GetTreeView(DataSet ds)
    {
        TreeNode tn = new TreeNode();
        tn = PublicDal.getConfigurationList();
        foreach (DataRow row in ds.Tables[0].Select("Grade='0' and IsShow='1'"))
        {
            if ((((UserModel)this.Session["User"]).UserName != "admin") || (row["MenuName"].ToString() != "功能列表"))
            {
                this.AddTreeNode(tn, row, ds);
            }
        }
        this.TreeView1.Nodes.Add(tn);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.TreeView1.Attributes.Add("onclick", "javascrpit:CheckEvent();");
        if (!this.Page.IsPostBack)
        {
            try
            {
                this.dbo = new DB_OPT();
                this.dbo.Open();
                this.BindTV(this.dbo);
            }
            catch (Exception exception)
            {
                this.el = new ExceptionLog.ExceptionLog();
                this.el.ErrClassName = base.GetType().ToString();
                this.el.ErrMessage = exception.Message.ToString();
                this.el.ErrMethod = "Page_Load()";
                this.el.WriteExceptionLog(true);
                PageShowText.OpenErrorPage("获取数据失败，请联系管理员！", this.Page);
            }
            finally
            {
                if (this.dbo != null)
                {
                    this.dbo.Close();
                }
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
