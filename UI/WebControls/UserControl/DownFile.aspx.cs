using ASP;
using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class WebControls_UserControl_DownFile : Page, IRequiresSessionState
{
    protected HtmlForm form1;

    protected void Page_Load(object sender, EventArgs e)
    {
        string str = base.Server.UrlDecode(base.Request["str"]);
        string str2 = base.Server.UrlDecode(base.Request["all"]);
        string path = base.Request["DefaultDown"];
        string str4 = null;
        if (path != null)
        {
            str4 = base.Server.MapPath(path);
        }
        else
        {
            str4 = base.Server.MapPath(@"upfile\" + str);
        }
        if (this.Context.Request["DownModel"] != null)
        {
            str4 = base.Server.MapPath("~/") + @"ModelFile\Model_ButieFF.xls";
            str2 = "补贴发放导入模板.xls";
        }
        if (File.Exists(str4))
        {
            FileInfo info = null;
            try
            {
                info = new FileInfo(str4);
                base.Response.Clear();
                base.Response.ContentEncoding = Encoding.UTF8;
                base.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(str2, Encoding.UTF8));
                base.Response.AddHeader("Content-Length", info.Length.ToString());
                base.Response.ContentType = "application/octet-stream";
                base.Response.WriteFile(info.FullName);
                base.Response.End();
                base.Response.Flush();
                base.Response.Clear();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        else
        {
            base.Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
            base.Response.Write("alert('您所需要下载的附件不存在,无法下载。');");
            base.Response.Write("</script>");
            base.Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
            base.Response.Write("window.close();");
            base.Response.Write("</script>");
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
