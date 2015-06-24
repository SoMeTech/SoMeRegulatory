using ASP;
using SMZJ.BLL;
using SoMeTech.YZXWPageClass;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class view : Page, IRequiresSessionState
{
    private BLL_news B_news = new BLL_news();
    public string content = "";
    protected HtmlForm form1;
    protected LinkButton LinkButton1;
    protected LinkButton LinkButton2;
    public string scTime = "";
    public string title = "";
    public string type = "";

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string topID = this.B_news.GetTopID(base.Request.QueryString["id"].ToString());
        if (topID == "0")
        {
            PageShowText.ShowMessage("已经是第一篇了", this.Page);
        }
        else
        {
            base.Response.Redirect("view.aspx?id=" + topID);
        }
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string nextID = this.B_news.GetNextID(base.Request.QueryString["id"].ToString());
        if (nextID == "0")
        {
            PageShowText.ShowMessage("已经是第一篇了", this.Page);
        }
        else
        {
            base.Response.Redirect("view.aspx?id=" + nextID);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session["user"] == null)
        {
            Const.GoLoginPath_OpenWindow(this.Page);
        }
        else if (!base.IsPostBack && (base.Request.QueryString["id"] != null))
        {
            string nextID = this.B_news.GetNextID(base.Request.QueryString["id"].ToString());
            string topID = this.B_news.GetTopID(base.Request.QueryString["id"].ToString());
            if (topID != "0")
            {
                this.LinkButton1.Text = "上一篇：" + this.B_news.GetList(" newid='" + topID + "'").Tables[0].Rows[0]["subjects"].ToString();
            }
            else
            {
                this.LinkButton1.Text = "";
            }
            if (nextID != "0")
            {
                this.LinkButton2.Text = "下一篇：" + this.B_news.GetList(" newid='" + nextID + "'").Tables[0].Rows[0]["subjects"].ToString();
            }
            else
            {
                this.LinkButton2.Text = "";
            }
            DataSet list = this.B_news.GetList(" newid='" + base.Request.QueryString["id"] + "'");
            this.title = list.Tables[0].Rows[0]["subjects"].ToString();
            this.content = list.Tables[0].Rows[0]["contents"].ToString();
            if (list.Tables[0].Rows[0]["type"].ToString() == "0")
            {
                this.type = "法律法规";
            }
            else
            {
                this.type = "工作动态";
            }
            this.scTime = list.Tables[0].Rows[0]["sysdate_"].ToString();
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
