using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Menu_imagesshow : Page, IRequiresSessionState
{
    protected HtmlForm form1;
    protected Menu_FileShow fs1;
    protected Table TbFiles;

    protected void Page_Load(object sender, EventArgs e)
    {
        base.Response.Expires = -1;
        this.fs1.DefaultDir = base.Server.MapPath("~");
        this.fs1.ControlPage = "imagesshow.aspx";
        this.fs1.RemoveDir = "";
        this.fs1.ShowFiles = "jpg,JPG,gif,GIF";
        this.fs1.WindowName = "file";
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
