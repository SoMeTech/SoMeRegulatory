
using SoMeTech.User;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

    public partial class Default : Page, IRequiresSessionState
    {
        protected HtmlHead Head1;
        protected HtmlInputHidden hei;
        public string login_comname = "";
        public string login_compk = "";
        protected HtmlInputHidden stu;
        protected HtmlTitle title1;
        public string user_braname = "";
        public string user_brapk = "";
        public string user_comname = "";
        public string user_compk = "";
        public string user_name = "";
        public string user_rolname = "";
        public string user_rolpk = "";
        protected HtmlInputHidden wid1;
        protected HtmlInputHidden wid2;
        public string yearND = "";
        public string verion = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (((this.Session["user"] == null) || (this.Session["pk_corp"] == null)) || (this.Session["companyname"] == null))
                {
                    string script = "ShowMsg_Login('index.aspx')";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "login", script, true);
                }
                else
                {
                    this.yearND = HttpContext.Current.Request.Cookies["YearND"].Value.ToString();
                    this.login_compk = this.Session["pk_corp"].ToString();
                    this.user_compk = ((UserModel)this.Session["user"]).pk_corp;
                    if (((UserModel)this.Session["user"]).Branch != null)
                    {
                        this.user_brapk = ((UserModel)this.Session["user"]).Branch.BH;
                        this.Session["BranchBH"] = ((UserModel)this.Session["user"]).Branch.BH;
                    }
                    if (((UserModel)this.Session["user"]).Role != null)
                    {
                        this.user_rolpk = ((UserModel)this.Session["user"]).Role.BH;
                    }
                    this.login_comname = this.Session["companyname"].ToString();
                    if (((UserModel)this.Session["user"]).Company != null)
                    {
                        this.user_comname = ((UserModel)this.Session["user"]).Company.Name;
                    }

                    if (((UserModel)this.Session["user"]).Branch != null)
                    {
                        this.user_braname = ((UserModel)this.Session["user"]).Branch.Name;
                    }
                    if (((UserModel)this.Session["user"]).Role != null)
                    {
                        this.user_rolname = ((UserModel)this.Session["user"]).Role.Name;
                    }
                    if (((UserModel)this.Session["user"]).UserName != null)
                    {
                        this.user_name = ((UserModel)this.Session["user"]).UserName;
                    }
                    this.verion = HttpContext.Current.Request.Browser.Version.ToString();
                }
            }
        }

        /*protected global_asax ApplicationInstance
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
