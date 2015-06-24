using AjaxPro;
using SoMeTech.CommonDll;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;



public class head : Page, IRequiresSessionState
{
    protected HtmlForm form1;
    protected HtmlHead Head1;
    protected Label labadmin;
    protected Label lblSN;
    protected Label lbluser;
    protected Label lblic;
    protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!base.IsPostBack)
            {
                Utility.RegisterTypeForAjax(typeof(head));
                if (this.Session["user"] == null)
                {
                    PageShowText.GoLoginPath_List(this.Page);
                    base.Response.End();
                }
                else if (((UserModel)this.Session["user"]).TrueName == "")
                {
                    this.labadmin.Text = ((UserModel)this.Session["user"]).UserName;
                }
                else
                {
                    this.labadmin.Text = ((UserModel)this.Session["user"]).TrueName;
                }
                this.lbluser.Text = ((UserModel)this.Session["user"]).TrueName;
                string str;
                if (((UserModel)this.Session["User"]).Company.pk_corp.Trim().Substring(0,6).ToString()=="431026")
                {
                    lblic.Text = "试用版(" + ((UserModel)this.Session["User"]).Company.pk_corp.Trim().Substring(0, 6).ToString()+")";
                }
                else
                {
                StreamReader reader = new StreamReader(HttpContext.Current.Request.PhysicalApplicationPath.ToString() + "License.lic", Encoding.Default);
                while ((str = reader.ReadLine()) != null)
                {
                    string[] strArray = str.Split(new char[] { '&' });
                    new SymmetricMethod();
                    if (strArray.Length == 9)
                    {
                        string etStr = strArray[2];
                        etStr = SMLicense.HEDET(etStr);
                        string str3 = strArray[3];
                        TimeSpan ts = Convert.ToDateTime(SMLicense.HEDET(str3)) - DateTime.Now;
                        if (ts.Days < 90) 
                        {
                            lblic.Text = "试用版，系统还可使用" + ts.Days.ToString() + "天";
                        }
                        else
                        {
                            lblic.Text = "";
                        }
                    }
                    
                }
            }
            }
        }

    [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
    public void SetSession(string pk, string name)
    {
        this.Session["companyname"] = name;
        this.Session["pk_corp"] = pk;
    }

    /*
            protected  global_asax ApplicationInstance
            {
                get
                {
                    return (global_asax)this.Context.ApplicationInstance;
                }
            }*/

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }
}

