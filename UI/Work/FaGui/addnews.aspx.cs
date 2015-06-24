using ASP;
using SMZJ.BLL;
using ExceptionLog;
using FredCK.FCKeditorV2;
using SoMeTech.DataAccess;
using SoMeTech.Dictionary.DataDic.DataTable;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using SMZJ.Model;
using System;
using System.Data;
using System.IO;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

public class addnews : Page, IRequiresSessionState
{
    private BLL_news B_news = new BLL_news();
    private DB_OPT dbo;
    protected DropDownList DropDownList1;
    private ExceptionLog.ExceptionLog el;
    protected UserControls_FilePostCtr FilePostCtr1;
    private DataTableModel model;
    private DataTableDal sd;
    protected HtmlTable t1;
    protected FCKeditor txtPD_PROJECT_CONTENTS;
    protected TextBox txtPD_PROJECT_SUBJECTS;

    public void addupdate()
    {
        news news = new news
        {
            newid = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
            type = new int?(int.Parse(this.DropDownList1.SelectedValue)),
            subjects = this.txtPD_PROJECT_SUBJECTS.Text,
            contents = this.txtPD_PROJECT_CONTENTS.Value
        };
        if (news.contents.Length == 0)
        {
            news.contents = " ";
        }
        news.sysdate_ = new DateTime?(DateTime.Now);
        int count = 0;
        count = this.B_news.Add(news);
        if (count > 0)
        {
            PD_PROJECT_REGULATE_DETAIL_Bll bll = new PD_PROJECT_REGULATE_DETAIL_Bll();
            PD_PROJECT_REGULATE_DETAIL_Model model = new PD_PROJECT_REGULATE_DETAIL_Model
            {
                PD_PROJECT_CODE = news.newid
            };
            DataSet set = null;
            string s = base.Server.UrlDecode(this.FilePostCtr1.getFileName);
            if ((s != null) && (s.Trim() != ""))
            {
                set = new DataSet();
                XmlTextReader reader = new XmlTextReader(new StringReader(s));
                set.ReadXml(reader);
            }
            if (((set != null) && (set.Tables.Count > 0)) && ((set.Tables[0].Rows.Count > 0) && (set.Tables[0].Rows[0]["FileSysName"].ToString().Trim() != "")))
            {
                model.FILENAME = set.Tables[0].Rows[0]["FileName"].ToString();
                model.FILESYSNAME = set.Tables[0].Rows[0]["FileSysName"].ToString();
            }
            bll.Add(model);
        }
        if (base.Request["reload"] != null)
        {
            Const.AddSuccess(count, base.Request["reload"].ToString(), this.Page);
        }
        else
        {
            Const.AddSuccess(count, "", this.Page);
        }
    }

    public void Buttons(string ibtid)
    {
        try
        {
            switch (ibtid)
            {
                case "ibtcontrol_ibtadd":
                case "ibtcontrol_ibtupdate":
                case "ibtcontrol_ibtdelete":
                case "ibtcontrol_ibtlook":
                case "ibtcontrol_ibtsearch":
                case "ibtcontrol_ibtrefresh":
                case "ibtcontrol_ibthuizong":
                case "ibtcontrol_ibtputout":
                case "ibtcontrol_ibtset":
                    return;

                case "ibtcontrol_ibtsave":
                    this.addupdate();
                    return;
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "Buttons(ibtid=" + ibtid + ")";
            this.el.WriteExceptionLog(true);
            Const.OpenErrorPage("操作失败，请联系管理员！", this.Page);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session["user"] == null)
        {
            Const.GoLoginPath_OpenWindow(this.Page);
        }
        else
        {
            this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
            if (!base.IsPostBack)
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                ButtonsModel model = new ButtonsModel(userName)
                {
                    IfAdd = false,
                    IfUpdate = false,
                    IfDelete = false,
                    IfLook = false,
                    IfSearch = false,
                    IfRefresh = true,
                    IfHuiZong = false,
                    IfPutOut = false,
                    IfSet = false,
                    IfSave = true,
                    IfExit = true
                };
                if ((base.Request["PK"] != null) && (base.Request["PK"] != ""))
                {
                    try
                    {
                        this.dbo = new DB_OPT();
                        this.dbo.Open();
                        this.sd = new DataTableDal();
                        this.model = this.sd.GetModel(base.Request.QueryString["PK"].ToString(), this.dbo);
                    }
                    catch (Exception exception)
                    {
                        this.el = new ExceptionLog.ExceptionLog();
                        this.el.ErrClassName = base.GetType().ToString();
                        this.el.ErrMessage = exception.Message.ToString();
                        this.el.ErrMethod = "Page_Load()";
                        this.el.WriteExceptionLog(true);
                        Const.OpenErrorPage("获取数据失败，请联系管理员！", this.Page);
                    }
                    finally
                    {
                        if (this.dbo != null)
                        {
                            this.dbo.Close();
                        }
                    }
                }
                this.Master.btModel = model;
            }
        }
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public MainAddUpdate Master
    {
        get
        {
            return (MainAddUpdate)base.Master;
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
