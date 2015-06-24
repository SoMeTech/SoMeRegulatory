using ASP;
using ExceptionLog;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Menu_MenuAdd : MainPageClass, IRequiresSessionState
{
    private DB_OPT dbo;
    protected HtmlGenericControl divbh;
    protected DropDownList drpdIsList;
    protected DropDownList drpdPodomZT;
    protected DropDownList drpdWindow;
    protected DropDownList DrpType;
    private ExceptionLog.ExceptionLog el;
    protected HtmlInputHidden FartherMenuPK;
    protected Menu_ImageLoad fl1;
    protected TextBox txtFartherMenu;
    protected TextBox txtfwqxbm;
    protected TextBox txtMenuMemo;
    protected TextBox txtMenuName;
    protected TextBox txtMenuPX;
    protected TextBox txtMenuUrl;
    protected DropDownList txtTally;
    protected UpdatePanel UpdatePanel1;

    private void AddMenu()
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            this.dbo.TranFar();
            if (this.txtMenuName.Text.Trim() == "")
            {
                Const.ShowMessage("请输入菜单名称！", this.Page);
            }
            else
            {
                MenuModel model = new MenuDal();
                MenuModel model2 = new MenuDal();
                if (model2.Exists(this.txtfwqxbm.Text.Trim(), this.dbo) > 0)
                {
                    Const.ShowMessage("菜单权限编码已经存在！", this.Page);
                }
                else
                {
                    string oldpath = "";
                    if (this.fl1.LoadFile.HasFile)
                    {
                        string menuUrl = ConfigMenu.MenuUrl;
                        oldpath = ConfigMenu.MenuUrl;
                        string str3 = Public.UpFile(base.Server.MapPath(Public.RelativelyPath(oldpath)), this.fl1.LoadFile.PostedFile);
                        if (menuUrl != "")
                        {
                            oldpath = menuUrl + "/" + str3;
                        }
                        else
                        {
                            oldpath = str3;
                        }
                    }
                    else
                    {
                        oldpath = this.fl1.ImageUrl;
                    }
                    model.FatherPK = this.FartherMenuPK.Value;
                    if (model.FatherPK != "")
                    {
                        model.MemuPK = model.FatherPK;
                        model = model.GetModel(false, this.dbo);
                        if (model.IsHasBaby == "0")
                        {
                            model2.MemuPK = model.MemuPK;
                            model2.UpdateHasBaby(this.dbo);
                        }
                        model2.PKPath = model.PKPath + model.MemuPK + "|";
                        model2.Grade = model.Grade + 1;
                    }
                    else
                    {
                        model2.Grade = 0;
                    }
                    model2.FatherPK = this.FartherMenuPK.Value.Trim();
                    model2.IsHasBaby = "0";
                    model2.PowerCode = this.txtfwqxbm.Text.Trim();
                    model2.Discription = this.txtMenuMemo.Text;
                    model2.MenuName = this.txtMenuName.Text;
                    model2.ImgUrl = oldpath;
                    model2.PageUrl = this.txtMenuUrl.Text;
                    model2.VisitPoint = int.Parse(this.txtTally.Text);
                    model2.OrderBy = int.Parse(this.txtMenuPX.Text);
                    model2.OpenType = this.drpdWindow.SelectedValue;
                    model2.IsCheckPower = this.drpdPodomZT.SelectedValue;
                    model2.IsShow = this.drpdIsList.SelectedValue;
                    model2.MenuType = this.DrpType.SelectedValue;
                    model2.pk_corp = this.Session["pk_corp"].ToString();
                    model2.Add(this.dbo);
                    this.dbo.Commit();
                    Const.DoSuccessOpen("", this.Page);
                }
            }
        }
        catch (Exception exception)
        {
            this.dbo.RollBack();
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "AddMenu()";
            this.el.WriteExceptionLog(true);
            Const.OpenErrorPage("操作失败，请联系管理员！", this.Page);
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
        string str;
        if (((str = ibtid) != null) && (str != "ibtcontrol_ibtadd"))
        {
            if (!(str == "ibtcontrol_ibtsave"))
            {
                if (((str == "ibtcontrol_ibtrefresh") || (str == "ibtcontrol_ibtset")) || (str != "ibtcontrol_ibtexit"))
                {
                }
            }
            else
            {
                this.AddMenu();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.txtMenuPX.Attributes.Add("onkeypress", "javascript:return onlyNum();");
        this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增菜单";
        this.Master.TitlePic = "~/images/页标题/新增菜单副本.jpg";
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (!this.Page.IsPostBack)
        {
            if (this.Session["User"] != null)
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                ButtonsModel model = new ButtonsModel(userName);
                if (PowerClass.IfHasPower(userName, power, PowerNum.MenuAdd))
                {
                    model.IfAdd = false;
                    model.IfUpdate = false;
                    model.IfSave = true;
                    model.IfDelete = false;
                    model.IfLook = false;
                    model.IfSearch = false;
                    model.IfRefresh = true;
                    model.IfHuiZong = false;
                    model.IfPutOut = false;
                    model.IfSet = false;
                    model.IfExit = true;
                    this.Master.btModel = model;
                }
                else
                {
                    Const.SorryForPower(this.Page);
                }
            }
            else
            {
                Const.GoLoginPath_Open(this.Page);
            }
        }
        this.fl1.VirtualCatalog = "";
        this.fl1.ImagePath = "System/menu/images";
    }

    private void SetMenuDefault()
    {
        this.txtMenuName.Text = "";
        this.txtMenuMemo.Text = "";
        this.txtfwqxbm.Text = "";
        this.txtMenuPX.Text = "0";
        this.txtMenuUrl.Text = "";
        this.txtTally.Text = "0";
        this.drpdIsList.SelectedIndex = 0;
        this.drpdPodomZT.SelectedIndex = 0;
        this.drpdWindow.SelectedIndex = 0;
        this.DrpType.SelectedIndex = 0;
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
