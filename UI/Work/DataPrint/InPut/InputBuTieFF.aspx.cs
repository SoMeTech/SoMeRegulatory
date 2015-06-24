using ASP;
using ExceptionLog;
using SoMeTech.CommonDll;
using SoMeTech.DataAccess;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Data;
using System.IO;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Xml;
using YYControls;
using SMZJ.BLL;

public class Work_DataPrint_InPut_InputBuTieFF : Page, IRequiresSessionState
{
    private UserBll bll = new UserBll();
    public string count = "0";
    private ExceptionLog.ExceptionLog el;
    protected UserControls_FilePostCtr FilePostCtr1;
    protected SmartGridView gvResult;
    public int pageind = 1;
    private PageSizeBll pagesize = new PageSizeBll();
    protected HtmlInputHidden txtindex;
    protected HtmlInputHidden txttitle;
    protected UpdatePanel UpdatePanel1;
    protected HtmlTable zxzb_bt;

    public void Buttons(string ibtid)
    {
        string str;
        int selectedIndex = this.gvResult.SelectedIndex;
        if (((str = ibtid) != null) && (str == "ibtcontrol_ibtsave"))
        {
            this.ShowData_Input();
        }
    }

    private void JS_BindShow(string ShowText)
    {
        if (ShowText != null)
        {
            PageShowText.Run_javascript("bind();alert(\"" + ShowText + "\")", this.Page);
        }
        else
        {
            PageShowText.Run_javascript("bind();", this.Page);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (base.Request["strTitle"] != null)
        {
            this.txttitle.Value = base.Server.UrlDecode(base.Request["strTitle"].ToString().Trim());
        }
        this.Master.strTitle = this.txttitle.Value;
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        this.Master.SearchHasGone = new SearchHandler(this.SearchControl);
        this.Master.PageNavigatorChange = new PageNavigatorHandler(this.PageChangControl);
        if (!this.Page.IsPostBack)
        {
            if (this.Session["user"] != null)
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
                try
                {
                    string[] names = new string[] { "pd_project_name", "pd_project_code" };
                    DataSet searchControlDataSet = Common.GetSearchControlDataSet(names);
                    this.Master.DataSetClo = searchControlDataSet;
                    names[0] = "项目名称";
                    names[1] = "项目编码";
                    DataSet set2 = Common.GetSearchControlDataSet(names);
                    this.Master.DataSetTable = set2;
                    ButtonsModel model = null;
                    PublicDal.ShowListButton(this.Page, out model, "");
                    model.IfSave = true;
                    model.IbtSaveText = "导入";
                    this.Master.btModel = model;
                }
                catch (Exception exception)
                {
                    this.el = new ExceptionLog.ExceptionLog();
                    this.el.ErrClassName = base.GetType().ToString();
                    this.el.ErrMessage = exception.Message.ToString();
                    this.el.ErrMethod = "bind()";
                    this.el.WriteExceptionLog(true);
                    Const.OpenErrorPage("获取数据失败，请联系管理员！", this.Page);
                }
            }
            else
            {
                Const.GoLoginPath_List(this.Page);
            }
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
    }

    protected void ShowData_Input()
    {
        string showText = null;
        try
        {
            string s = base.Server.UrlDecode(this.FilePostCtr1.getFileName);
            string path = null;
            DataSet set = null;
            if ((s != null) && (s.Trim() != ""))
            {
                set = new DataSet();
                XmlTextReader reader = new XmlTextReader(new StringReader(s));
                set.ReadXml(reader);
                path = base.Server.MapPath("~/temp/" + set.Tables[0].Rows[0]["FileSysName"]);
            }
            else
            {
                showText = "请先选择需要导入的Excel文件";
            }
            if ((set != null) && File.Exists(path))
            {
                DataSet dataSet = ExcelToDataset.GetDataSet(path);
                showText = new TB_PROJECT_BZ_Bll().InputData(dataSet);
                if (showText != "")
                {
                    showText = "以下记录未导入成功：" + showText;
                }
                else
                {
                    showText = "导入成功!";
                }
                File.Delete(path);
            }
            else
            {
                showText = "请先选择需要导入的Excel文件";
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "bind()";
            this.el.WriteExceptionLog(true);
            showText = "导入出现异常：" + exception;
        }
        this.FilePostCtr1.getFileName = "";
        this.JS_BindShow(showText);
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public MainOne Master
    {
        get
        {
            return (MainOne)base.Master;
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
