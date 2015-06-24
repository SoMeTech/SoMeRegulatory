using AjaxPro;
using ASP;
using ExceptionLog;
using SoMeTech.Company;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.QxConst;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SoMeTech.CommonDll;
public class Login_page : Page, IRequiresSessionState
{
    private UserBll Bill = new UserBll();
    protected ImageButton btnTrue;
    protected CheckBox cbxPW;
    protected HtmlInputHidden CompanyPk;
    protected DropDownList dplND;
    private ExceptionLog.ExceptionLog el;
    protected HtmlForm form1;
    protected HtmlHead Head1;
    protected ImageButton ImageButton11;
    protected HtmlGenericControl msg;
    protected RequiredFieldValidator RequiredFieldValidator1;
    protected RequiredFieldValidator RequiredFieldValidator2;
    protected RequiredFieldValidator RequiredFieldValidator3;
    protected ScriptManager ScriptManager1;
    protected TextBox txtCompany;
    protected TextBox txtPW;
    protected TextBox txtServer;
    protected TextBox txtUser;
    protected UpdatePanel UpdatePanel1;

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        this.txtUser.Text = "";
        this.txtPW.Text = "";
    }

    protected void btnTrue_Click(object sender, EventArgs e)
    {
        try
        {
            string struser = this.txtUser.Text.Trim();
            string str2 = this.txtPW.Text.Trim();
            QxRoom.QxConst.QxConst.Encrypt(this.txtPW.Text.Trim(), "powerich");
            UserModel model = this.Bill.Login(struser);
            if (((model.UserName == struser) && (model.Password != null)) && (QxRoom.QxConst.QxConst.Decrypt(model.Password, "powerich") == str2))
            {
                this.Session["User"] = model;
                this.Session["companyname"] = this.txtCompany.Text.Trim();
                this.Session["pk_corp"] = this.CompanyPk.Value.Trim();
                HttpCookie cookie = new HttpCookie("UserCookie");
                cookie["UserName"] = base.Server.UrlEncode(this.txtUser.Text.Trim());
                cookie["CompanyPK"] = base.Server.UrlEncode(this.CompanyPk.Value.Trim());
                cookie["CompanyName"] = base.Server.UrlEncode(this.txtCompany.Text.Trim());
                TimeSpan span = new TimeSpan(1, 0, 0, 0);
                cookie.Expires = DateTime.Now.Add(span);
                base.Response.Cookies.Add(cookie);
                string errorInfo;
                bool result = CheckSN.UseSMlicense(cookie["CompanyPK"].ToString(), out errorInfo);
                if (result)
                {
                    if (this.cbxPW.Checked)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "js", "OpenPage('ChangePW.aspx?user=" + base.Server.UrlEncode(this.txtUser.Text) + "&pwd=" + base.Server.UrlEncode(this.txtPW.Text) + "','280','130')", true);
                    }
                    else
                    {
                        HttpCookie cookie2 = new HttpCookie("YearND")
                        {
                            Value = this.dplND.SelectedItem.ToString()
                        };
                        HttpContext.Current.Response.Cookies.Add(cookie2);
                        PageShowText.OpenPage("Default.aspx", 0x3e8, 650, this.Page);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "close", "window.close();", true);

                    }
                }
                else
                {
                    Const.ShowMessage(errorInfo, this.Page);
                }
            }
            else
            {
                this.msg.Style.Add("display", "block");
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "btnTrue_Click()";
            this.el.WriteExceptionLog(true);
            Const.OpenErrorPage("操作失败，请联系管理员！", this.Page);
        }
    }

    [AjaxMethod]
    public string GetCompanyCodeAndName(string username)
    {
        string userCompany = UserBll.GetUserCompany(username);
        if (userCompany == "false")
        {
            Const.OpenErrorPage("获取公司信息失败，请联系管理员！", this.Page);
        }
        return userCompany;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            int num = Convert.ToInt32(DateTime.Now.Year);
            for (int i = 0x7da; i <= (num + 1); i++)
            {
                this.dplND.Items.Add(i.ToString());
            }
            this.dplND.SelectedValue = num.ToString();
            if (((base.Request.QueryString["from"] != null) && base.Request.QueryString["from"].Equals("uf")) && ((base.Request.QueryString["UserName"] != null) && (base.Request.QueryString["Pwd"] != null)))
            {
                try
                {
                    string struser = base.Request.RawUrl.Split(new char[] { '&' })[1].Replace("UserName=", "");
                    string datastr = base.Server.UrlEncode(base.Request.QueryString["Pwd"]);
                    if (struser.Trim().Equals("系统管理员"))
                    {
                        struser = "admin";
                        datastr = "1";
                    }
                    QxRoom.QxConst.QxConst.Encrypt(datastr, "powerich");
                    UserModel model = this.Bill.Login(struser);
                    QxRoom.QxConst.QxConst.Decrypt(model.Password, "powerich");
                    if (((model.UserName == struser) && (model.Password != null)) && (QxRoom.QxConst.QxConst.Decrypt(model.Password, "powerich") == datastr))
                    {
                        this.Session["User"] = model;
                        CompanyModel company = model.Company;
                        this.txtUser.Text = struser;
                        this.txtPW.Text = datastr;
                        this.txtCompany.Text = company.Name;
                        this.CompanyPk.Value = company.pk_corp;
                        this.btnTrue_Click(sender, e);
                        return;
                    }
                    this.Page.Response.Redirect("Login.aspx", false);
                }
                catch (Exception exception)
                {
                    this.el = new ExceptionLog.ExceptionLog();
                    this.el.ErrClassName = base.GetType().ToString();
                    this.el.ErrMessage = exception.Message.ToString();
                    this.el.ErrMethod = "btnTrue_Click()";
                    this.el.WriteExceptionLog(true);
                    Const.OpenErrorPage("操作失败，请联系管理员！", this.Page);
                }
            }
            if (((this.Session["User"] != null) || (this.Session["companyname"] != null)) || (this.Session["pk_corp"] != null))
            {
                this.Session.Abandon();
            }
            if (base.Request.Cookies["UserCookie"] != null)
            {
                this.txtUser.Text = base.Server.UrlDecode(base.Request.Cookies["UserCookie"].Values["UserName"].Trim());
                this.txtCompany.Text = base.Server.UrlDecode(base.Request.Cookies["UserCookie"].Values["CompanyName"].Trim());
                this.CompanyPk.Value = base.Server.UrlDecode(base.Request.Cookies["UserCookie"].Values["CompanyPK"].Trim());
                string str3 = base.Request.Cookies["UserCookie"].Values["pwd"];
                if (str3 != null)
                {
                    str3 = QxRoom.QxConst.QxConst.Decrypt(base.Server.UrlDecode(str3.Trim()), "powerich");
                    this.txtPW.Attributes.Add("value", str3);
                    this.txtPW.Text = str3;
                }
            }
        }
        this.txtCompany.Attributes.Add("style", "display:none;");
    }

    protected void txtPW_TextChanged(object sender, EventArgs e)
    {
    }

    protected void txtUser_TextChanged(object sender, EventArgs e)
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
