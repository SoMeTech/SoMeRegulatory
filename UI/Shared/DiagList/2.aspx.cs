using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public class Shared_2 : Page, IRequiresSessionState
{
    protected HtmlForm form1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (base.Request.QueryString["tn"] != null)
        {
            UsualBookTable table = new UsualBookTable();
            string str = base.Request.QueryString["tn"];
            if (str != null)
            {
                if (!(str == "SubjectKind"))
                {
                    if (str == "LinkMan")
                    {
                        table.PageTitle = "联系人参照";
                        table.TableName = "LinkMan";
                        table.Columns = "LMPK as PK,Name as 联系人名称,1,0,0,''";
                    }
                }
                else
                {
                    table.PageTitle = "项目类别参照";
                    table.TableName = "SubjectKind";
                    table.Columns = "PK as PK,Name as 项目类别,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                    table.StrWhere = "Grade=1";
                }
            }
            this.Session["UsualBookTable"] = table;
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
