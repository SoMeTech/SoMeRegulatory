using ASP;
using ExceptionLog;
using SoMeTech.CommonDll;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Menu_treeview : Page, IRequiresSessionState
{
    private DB_OPT dbo;
    private ExceptionLog.ExceptionLog el;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAction();
        }
    }
    public void LoadAction()
    {
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        Response.Expires = 0;
        Response.CacheControl = "no-cache";
        Response.AddHeader("Pragma", "No-Cache");

        string active = HttpContext.Current.Request["action"];                                          //提交类型
        string ModuleId = HttpContext.Current.Request["ModuleId"];
        MenuModel model = new MenuDal();
        string strWhere = "";
        switch (active)
        {
            case "LoadAccordionMenu":   //加载手风琴菜单
                StringBuilder sb_html = new StringBuilder();
                try
                {
                    if (this.Session["User"] != null)
                    {
                        string power = ((UserModel)this.Session["User"]).Power;
                        if (power != "")
                        {
                            if (((UserModel)this.Session["User"]).UserName != "admin")
                            {
                                strWhere = "patindex('%|'||rtrim(PowerCode)||'|%','|" + power + "|')>0 or ISCHECKPOWER='0'";
                            }
                        }
                    }
                    this.dbo = new DB_OPT();
                    this.dbo.Open();
                    DataTable dt = model.GetList(strWhere, dbo).Tables[0];
                    DataRow[] rows = dt.Select("Grade='0' and IsShow='1'");
                    foreach (DataRow dr in rows)
                    {
    
                        sb_html.Append("<li title=" + dr["MENUNAME"] + ">");
                        sb_html.Append("<div class=\"link\">");
                        sb_html.Append("<img src=" + dr["IMGURL"] + ">&nbsp;&nbsp;<span>" + dr["MENUNAME"] + "</span><i class=\"chevron-down\"></i>");
                        sb_html.Append("</div>");
                        sb_html.Append("<div id=\"" + dr["MEMUPK"].ToString().Trim() + "\" class=\"submenu bottomline\"></div>");
                        sb_html.Append("</li>");
                    }
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
                Response.Write(sb_html.ToString());
                Response.End();
                break;
            case "LoadTreeMenu":        //加载子树菜单
                if (this.Session["User"] != null)
                {
                    string power = ((UserModel)this.Session["User"]).Power;
                    if (power != "")
                    {
                        if (((UserModel)this.Session["User"]).UserName != "admin")
                        {
                            strWhere = "patindex('%|'||rtrim(PowerCode)||'|%','|" + power + "|')>0 or ISCHECKPOWER='0'";
                        }
                    }
                }
                this.dbo = new DB_OPT();
                this.dbo.Open();
                DataTable submenu_dt = model.GetList(strWhere, dbo).Tables[0];
                DataRow[] submenu_rows = submenu_dt.Select("IsShow='1'");
                List<TreeJsonEntity> TreeList = new List<TreeJsonEntity>();
                foreach (DataRow dr in submenu_rows)
                {
                    TreeJsonEntity tree = new TreeJsonEntity();
                    bool hasChildren = false;
                    DataRow[] childnode = submenu_dt.Select("FatherPK='" + dr["MEMUPK"].ToString() + "'");
                    if (childnode.Length > 0)
                    {
                        hasChildren = true;
                    }
                    tree.id = dr["MEMUPK"].ToString().Trim();
                    tree.text = dr["MENUNAME"].ToString();
                    tree.value = dr["MEMUPK"].ToString().Trim();
                    tree.title = dr["PAGEURL"].ToString().Trim();
                    tree.img = dr["IMGURL"].ToString().Trim();
                    tree.isexpand = false;
                    tree.complete = true;
                    tree.hasChildren = hasChildren;
                    tree.parentId = dr["FATHERPK"].ToString();
                    TreeList.Add(tree);
                }
                string str = TreeList.TreeToJson(ModuleId).Trim();
                Response.Write(TreeList.TreeToJson(ModuleId).Trim());
                Response.End();
                break;
            default:
                break;
        }
    }
}
