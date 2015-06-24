using ASP;
using SoMeTech.DataAccess;
using SoMeTech.User;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public class Welcome : Page, IRequiresSessionState
{
    protected HtmlForm form1;
    protected HtmlHead Head1;
    protected HtmlInputHidden userid;

    private void GetMess()
    {
    }

    private void IsPower()
    {
        DB_OPT dbo = new DB_OPT();
        try
        {
            UserModel model = new UserDal
            {
                UserName = ((UserModel)HttpContext.Current.Session["User"]).UserName
            };
            model.GetModel(dbo);
            string[] strArray = model.CompanyPower.Split(new char[] { '|' });
            for (int i = 0; i < strArray.Length; i++)
            {
                strArray[i].Trim();
            }
        }
        catch (Exception)
        {
        }
        finally
        {
            dbo.Close();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack && (this.Session["User"] != null))
        {
            this.userid.Value = ((UserModel)this.Session["User"]).UserName;
            this.GetMess();
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
