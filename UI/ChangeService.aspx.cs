
using ExceptionLog;
using SoMeTech.YZXWPageClass;
using QxRoom.QxConst;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;


    public partial class ChangeService : Page, IRequiresSessionState
    {
        protected ImageButton btnTrue;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected ImageButton ibtTestCon;
        protected RequiredFieldValidator RequiredFieldValidator1;
        protected RequiredFieldValidator RequiredFieldValidator2;
        protected RequiredFieldValidator RequiredFieldValidator4;
        protected TextBox txtPW;
        protected TextBox txtService;
        protected TextBox txtUser;

        protected void btnTrue_Click(object sender, ImageClickEventArgs e)
        {
            this.UpdateService();
        }
        
        protected void ibtTestCon_Click(object sender, ImageClickEventArgs e)
        {

            if (UserBll.TryCon("Data Source=" + this.txtService.Text.Trim() + ";User ID=" + this.txtUser.Text.Trim() + ";Password=" + this.txtPW.Text.Trim() + ";"))
            {
                string str = this.txtPW.Text.Trim();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "close", "alert('测试连接成功！');", true);
                this.Session["spwd"] = str;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "close", "alert('测试连接失败！');", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                PageUsuClass.ReadSqlIp(this.txtService, this.Page);
                if (this.Session["spwd"] != null)
                {
                    this.txtPW.Text = this.Session["spwd"].ToString();
                }
            }
        }

        public void UpdateService()
        {
            try
            {
                int num = 0;
                string filename = base.Server.MapPath("Web.config");
                XmlDocument document = new XmlDocument();
                document.Load(filename);
                foreach (XmlElement element in document.DocumentElement.ChildNodes)
                {
                    if (element.Name == "appSettings")
                    {
                        XmlNodeList childNodes = element.ChildNodes;
                        if (childNodes.Count > 0)
                        {
                            foreach (XmlElement element2 in childNodes)
                            {
                                if (element2.Attributes["key"].Value.ToLower() == "dataconn")
                                {
                                    element2.Attributes["value"].Value = "Data Source=" + this.txtService.Text.Trim() + ";User ID=" + this.txtUser.Text.Trim() + ";Password=";
                                    document.Save(filename);
                                    num++;
                                }
                                if (element2.Attributes["key"].Value.ToLower() == "pwd")
                                {
                                    element2.Attributes["value"].Value = QxRoom.QxConst.QxConst.Encrypt(this.txtPW.Text.Trim(), "powerich");
                                    document.Save(filename);
                                    num++;
                                }
                                if (num == 2)
                                {
                                    Const.ShowMessageAndClose("保存服务器配置成功！", this.Page);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                new ExceptionLog.ExceptionLog { ErrClassName = base.GetType().ToString(), ErrMessage = exception.Message.ToString(), ErrMethod = "UpdateService()" }.WriteExceptionLog(true);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "close", "alert('保存服务器配置失败！');", true);
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

