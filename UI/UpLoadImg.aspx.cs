using ASP;
using System;
using System.Collections.Specialized;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class UpLoadImg : Page, IRequiresSessionState
{
    protected Button Button1;
    protected Button Button2;
    protected HtmlForm form1;
    protected TextBox txt_file;
    protected HtmlGenericControl ulimg;
    protected HtmlInputFile uploadfile1;

    protected void Button1_Click(object sender, EventArgs e)
    {
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        NameValueCollection values = new NameValueCollection(base.Request.Form);
        base.Response.Write(values.GetValues("file1")[0].ToString());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
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
