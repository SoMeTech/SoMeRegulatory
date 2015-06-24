using ASP;
using ExceptionLog;
using SoMeTech.CommonDll;
using SoMeTech.Company;
using SoMeTech.DataAccess;
using SoMeTech.User;
using System;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Company_treeview : Page, IRequiresSessionState
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
        TreeNode child = new TreeNode(dr["Name"].ToString(), dr["pk_corp"].ToString())
        {
            ToolTip = "CompanyList.aspx?pk_corp=" + dr["pk_corp"].ToString()
        };
        if (dr["IsHasBaby"].ToString() == "0")
        {
            child.SelectAction = TreeNodeSelectAction.Expand;
        }
        tn.ChildNodes.Add(child);
        if (dr["IsHasBaby"].ToString() == "1")
        {
            foreach (DataRow row in ds.Tables[0].Select("Grade='" + Convert.ToString((int)(int.Parse(dr["Grade"].ToString()) + 1)) + "' and zxbj='0' and FatherPK='" + dr["pk_corp"].ToString() + "'"))
            {
                this.AddTreeNode(child, row, ds);
            }
        }
    }

    private void BindTV(DB_OPT dbo)
    {
        DataSet list;
        CompanyModel model = new CompanyDal();
        string str = ((UserModel)this.Session["User"]).CompanyPower.Replace("|", "','");
        str = "'" + str + "'";
        if (!((UserModel)this.Session["User"]).UserName.Equals("admin"))
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" pk_corp in (");
            builder.Append(str);
            builder.Append(")");
            builder.Append(" and pk_corp like '");
            builder.Append(((UserModel)this.Session["User"]).Company.pk_corp.Trim());
            builder.Append("%' ");
            list = model.GetList(builder.ToString(), dbo);
        }
        else
        {
            list = model.GetList("1=1 ", dbo);
        }
        this.GetTreeView(list);
    }

    public void GetTreeView(DataSet ds)
    {
        TreeNode tn = new TreeNode();
        tn = PublicDal.getConfigurationList();
        foreach (DataRow row in ds.Tables[0].Select("Grade='0'"))
        {
            this.AddTreeNode(tn, row, ds);
        }
        this.TreeView1.Nodes.Add(tn);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.TreeView1.Attributes.Add("onclick", "javascrpit:CheckEvent();");
        string s = "760";
        if (base.Request.Cookies["hei"] != null)
        {
            s = base.Request.Cookies["hei"].Value;
        }
        int num = 300;
        if (int.Parse(s) > 0)
        {
            num = int.Parse(s) + 0x41;
        }
        this.TreeView1.Height = Unit.Parse(num.ToString());
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
                Const.OpenErrorPage("获取数据失败，请联系管理员！", this.Page);
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
