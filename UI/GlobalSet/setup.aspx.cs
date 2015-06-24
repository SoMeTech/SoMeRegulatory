using ASP;
using ExceptionLog;
using SoMeTech.CommonDll.Configuration;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.QxConst;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SMZJ.BLL;

public class setup : MainPageClass, IRequiresSessionState
{
    private ConfigurationDal cfd;
    protected CompareValidator CompareValidator1;
    protected RadioButtonList db_quota_fileIsShow;
    private DB_OPT dbo;
    private ExceptionLog.ExceptionLog el;
    protected TextBox FileErrMessPath;
    private ConfigurationModel model;
    protected RadioButtonList rbtifOpenExceptionLog;
    protected RadioButtonList rbtifOpenOpLog;
    protected TextBox txtAginPD;
    protected TextBox txtMenuNodeName;
    protected TextBox txtMenuNodeValue;
    protected TextBox txtPageSizeOne;
    protected TextBox txtPageSizeTwo;
    protected TextBox txtPassWord;
    protected TextBox txtServiceIP;
    protected TextBox txtServiceName;
    protected HtmlInputHidden txttitle;
    protected TextBox txtUserName;

    private void AddConfing()
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            if (((this.txtUserName.Text.Trim() == "") || (this.txtServiceName.Text.Trim() == "")) || ((this.txtPassWord.Text.Trim() == "") || (this.txtAginPD.Text.Trim() == "")))
            {
                Const.ShowMessage("带*的数据必须填写！", this.Page);
            }
            else
            {
                this.cfd = new ConfigurationDal();
                this.model = new ConfigurationModel();
                this.model.SERVICEIP = this.txtServiceIP.Text.Trim();
                this.model.IFOPENEXCEPTIONLOG = this.rbtifOpenExceptionLog.SelectedItem.Value;
                this.model.IFOPENOPLOG = this.rbtifOpenOpLog.SelectedItem.Value;
                this.model.MENUNODENAME = this.txtMenuNodeName.Text.Trim();
                this.model.MENUNODEVALUE = this.txtMenuNodeValue.Text.Trim();
                if (this.txtPageSizeOne.Text.Trim() != "")
                {
                    this.model.PAGESIZEONE = new int?(int.Parse(this.txtPageSizeOne.Text.Trim()));
                }
                if (this.txtPageSizeTwo.Text.Trim() != "")
                {
                    this.model.PAGESIZETWO = new int?(int.Parse(this.txtPageSizeTwo.Text.Trim()));
                }
                if (this.txtPassWord.Text.Trim() != "")
                {
                    this.model.PASSWORD = QxRoom.QxConst.QxConst.Encrypt(this.txtPassWord.Text.Trim(), "powerich");
                }
                this.model.SERVICENAME = this.txtServiceName.Text.Trim();
                this.model.USERNAME = this.txtUserName.Text.Trim();
                this.model.ErrMessPath = this.FileErrMessPath.Text;
                new TB_QUOTA_Bll().SaveSetting("ZBOper.aspx", "tr_wjzl", this.db_quota_fileIsShow.SelectedItem.Value);
                DataSet list = new DataSet();
                list = this.cfd.GetList("", this.dbo);
                if ((list.Tables[0].Rows.Count > 0) && (list != null))
                {
                    this.cfd.Update(this.model, this.dbo);
                    if (this.cfd.Update(this.model, this.dbo) > 0)
                    {
                        PageShowText.ShowMessage("信息保存成功！", this.Page);
                    }
                }
                else if (this.cfd.Add(this.model, this.dbo) > 0)
                {
                    PageShowText.ShowMessage("信息保存成功！", this.Page);
                }
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "AddConfing()";
            this.el.WriteExceptionLog(true);
            PageShowText.OpenErrorPage(" 操作失败，请联系管理员！", this.Page);
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
    }

    public void Buttons(string ibtid)
    {
        string str = ibtid;
        if (str != null)
        {
            if (!(str == "ibtcontrol_ibtsave"))
            {
                if ((!(str == "ibtcontrol_ibtrefresh") && !(str == "ibtcontrol_ibtset")) && (str == "ibtcontrol_ibtexit"))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Master.MainUpdatePanel, this.Master.MainUpdatePanel.GetType(), "close1", "window.close();", true);
                }
            }
            else
            {
                this.AddConfing();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.LBTitle = "乡镇财政资金监管信息系统 - 系统配置";
        if (base.Request["strTitle"] != null)
        {
            this.txttitle.Value = base.Server.UrlDecode(base.Request["strTitle"].ToString().Trim());
        }
        this.Master.strTitle = this.txttitle.Value;
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (!this.Page.IsPostBack)
        {
            if (this.Session["User"] == null)
            {
                Const.GoLoginPath_Open(this.Page);
            }
            else
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
                ButtonsModel model = new ButtonsModel(userName);
                if (PowerClass.IfHasPower(userName, power, PowerNum.SystemSet))
                {
                    model.IfSave = true;
                    model.IfAdd = false;
                    model.IfUpdate = false;
                    model.IfDelete = false;
                    model.IfLook = false;
                    model.IfSearch = false;
                    model.IfRefresh = true;
                    model.IfHuiZong = false;
                    model.IfPutOut = false;
                    model.IfSet = false;
                    model.IfExit = true;
                    this.Master.btModel = model;
                    try
                    {
                        try
                        {
                            this.dbo = new DB_OPT();
                            this.dbo.Open();
                            this.cfd = new ConfigurationDal();
                            ConfigurationModel model2 = this.cfd.GetModel(this.dbo);
                            if (model2 != null)
                            {
                                this.txtMenuNodeName.Text = model2.MENUNODENAME.ToString();
                                this.txtMenuNodeValue.Text = model2.MENUNODEVALUE.ToString();
                                this.txtPageSizeOne.Text = model2.PAGESIZEONE.ToString();
                                this.txtPageSizeTwo.Text = model2.PAGESIZETWO.ToString();
                                this.txtServiceName.Text = model2.SERVICENAME.ToString();
                                this.txtUserName.Text = model2.USERNAME.ToString();
                                this.txtServiceIP.Text = model2.SERVICEIP.ToString();
                                this.FileErrMessPath.Text = model2.ErrMessPath.ToString();
                                this.rbtifOpenExceptionLog.SelectedValue = model2.IFOPENEXCEPTIONLOG.ToString();
                                this.rbtifOpenOpLog.SelectedValue = model2.IFOPENOPLOG.ToString();
                                TB_QUOTA_Bll bll = new TB_QUOTA_Bll();
                                this.db_quota_fileIsShow.SelectedValue = bll.tFileIsShow("ZBOper.aspx", "tr_wjzl").ToString();
                            }
                        }
                        catch (Exception exception)
                        {
                            this.el = new ExceptionLog.ExceptionLog();
                            this.el.ErrClassName = base.GetType().ToString();
                            this.el.ErrMessage = exception.Message.ToString();
                            this.el.ErrMethod = "Page_Load()";
                            this.el.WriteExceptionLog(true);
                            Const.OpenErrorPage(" 获取数据失败，请联系管理员！", this.Page);
                        }
                        return;
                    }
                    finally
                    {
                        if (this.dbo != null)
                        {
                            this.dbo.Close();
                        }
                    }
                }
                Const.SorryForPower(this.Page);
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
