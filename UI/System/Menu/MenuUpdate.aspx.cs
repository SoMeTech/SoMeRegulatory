using ASP;
using ExceptionLog;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Menu_MenuUpdate : MainPageClass, IRequiresSessionState
{
    private DB_OPT dbo;
    protected DropDownList drpdIsList;
    protected DropDownList drpdPodomZT;
    protected DropDownList drpdWindow;
    protected DropDownList DrpType;
    private ExceptionLog.ExceptionLog el;
    protected HtmlInputHidden FartherMenuPK;
    protected Menu_ImageLoad fl1;
    private MenuModel mm;
    protected TextBox txtFartherMenu;
    protected TextBox txtfwqxbm;
    protected HtmlInputHidden txtishasbaby;
    protected TextBox txtMenuMemo;
    protected TextBox txtMenuName;
    protected TextBox txtMenuPX;
    protected TextBox txtMenuUrl;
    protected DropDownList txtTally;
    protected UpdatePanel UpdatePanel1;

    private void BindDropDown(DB_OPT dbo)
    {
    }

    public void Buttons(string ibtid)
    {
        string str;
        if (((str = ibtid) != null) && (str != "ibtcontrol_ibtupdate"))
        {
            if (str == "ibtcontrol_ibtsave")
            {
                this.UpdateMenu();
            }
            else if (str != "ibtcontrol_ibtrefresh")
            {
                if (!(str == "ibtcontrol_ibtset"))
                {
                    bool flag1 = str == "ibtcontrol_ibtexit";
                }
            }
            else
            {
                this.dbo = new DB_OPT();
                this.dbo.Open();
                this.mm = new MenuDal();
                this.mm.MemuPK = base.Request.QueryString["MenuPK"].ToString();
                this.mm = this.mm.GetModel(false, this.dbo);
                this.GetStrParent(this.mm.PKPath);
                this.SetValue(this.mm);
            }
        }
    }

    private string GetStrParent(string pkpath)
    {
        string str;
        try
        {
            string str2 = "";
            this.dbo = new DB_OPT();
            this.dbo.Open();
            MenuModel[] parents = new MenuDal { PKPath = pkpath }.GetParents(this.dbo);
            for (int i = 0; i < parents.Length; i++)
            {
                str2 = parents[i].MemuPK + "~" + str2;
            }
            if (str2.Length > 0)
            {
                str2 = str2.Substring(0, str2.Length - 1);
            }
            str = str2;
        }
        catch (Exception)
        {
            str = "";
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
        return str;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.txtMenuPX.Attributes.Add("onkeypress", "javascript:return onlyNum();");
        this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改菜单";
        this.Master.TitlePic = "~/images/页标题/修改菜单副本.jpg";
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (!this.Page.IsPostBack && (this.Session["User"] != null))
        {
            if (base.Request.QueryString["PK"] != null)
            {
                try
                {
                    try
                    {
                        string userName = ((UserModel)this.Session["User"]).UserName;
                        string power = ((UserModel)this.Session["User"]).Power;
                        ButtonsModel model = new ButtonsModel(userName);
                        if (PowerClass.IfHasPower(userName, power, PowerNum.MenuUpdate))
                        {
                            model.IfAdd = false;
                            model.IfSave = true;
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
                            this.dbo = new DB_OPT();
                            this.dbo.Open();
                            this.mm = new MenuDal();
                            this.mm.MemuPK = base.Request.QueryString["PK"].ToString();
                            this.mm = this.mm.GetModel(false, this.dbo);
                            this.SetValue(this.mm);
                        }
                        else
                        {
                            Const.SorryForPower(this.Page);
                        }
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
                    goto Label_0237;
                }
                finally
                {
                    if (this.dbo != null)
                    {
                        this.dbo.Close();
                    }
                }
            }
            Const.GoLoginPath_Open(this.Page);
        }
    Label_0237:
        this.fl1.VirtualCatalog = "";
        this.fl1.ImagePath = "System/menu/images";
    }

    private void SetValue(MenuModel mm)
    {
        this.txtfwqxbm.Text = mm.PowerCode;
        this.txtMenuMemo.Text = mm.Discription;
        this.txtMenuName.Text = mm.MenuName;
        this.txtMenuUrl.Text = mm.PageUrl;
        this.txtTally.Text = mm.VisitPoint.ToString();
        this.txtMenuPX.Text = mm.OrderBy.ToString();
        this.drpdWindow.SelectedValue = mm.OpenType;
        this.drpdPodomZT.SelectedValue = mm.IsCheckPower;
        this.drpdIsList.SelectedValue = mm.IsShow;
        this.DrpType.SelectedValue = mm.MenuType;
        this.fl1.ImageUrl = mm.ImgUrl;
        this.txtishasbaby.Value = mm.IsHasBaby;
        this.FartherMenuPK.Value = mm.FatherPK.Trim();
        if (mm.FatherPK.Trim() != "")
        {
            MenuModel model = new MenuDal();
            this.txtFartherMenu.Text = model.GetList("MemuPK='" + mm.FatherPK + "'", this.dbo).Tables[0].Rows[0]["MenuName"].ToString();
        }
    }

    private void UpdateMenu()
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            this.dbo.TranFar();
            if (this.txtMenuName.Text.Trim() == "")
            {
                Const.ShowMessage("带*的数据必须填写！", this.Page);
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
                MenuModel model = new MenuDal();
                MenuModel model2 = new MenuDal();
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
                    if (this.txtishasbaby.Value == "1")
                    {
                        MenuDal.ChangeChildPkPath(base.Request.QueryString["PK"].ToString(), model2.PKPath + base.Request.QueryString["PK"].ToString() + "|", model.Grade + 2, this.dbo);
                    }
                    model2.Grade = model.Grade + 1;
                }
                else
                {
                    model2.Grade = 0;
                }
                model2.FatherPK = this.FartherMenuPK.Value.Trim();
                model2.IsHasBaby = this.txtishasbaby.Value;
                model2.MemuPK = base.Request.QueryString["PK"].ToString();
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
                model2.pk_corp = HttpContext.Current.Session["pk_corp"].ToString();
                model2.Update(this.dbo);
                this.dbo.Commit();
                Const.DoSuccessClose("", this.Page);
            }
        }
        catch (Exception exception)
        {
            this.dbo.RollBack();
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "UpdateMenu()";
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
