using ASP;
using ExceptionLog;
using SoMeTech.Company.Employee;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Employee_EmployeeAdd : Page, IRequiresSessionState
{
    private DB_OPT dbo;
    protected HtmlGenericControl divbh;
    private ExceptionLog.ExceptionLog el;
    protected RadioButtonList rblsex1;
    protected TextBox txtaddress;
    protected TextBox txtage;
    protected TextBox txtarea;
    protected TextBox txtbh;
    protected HtmlInputText txtBirthDay;
    protected TextBox txtBranch;
    protected TextBox txtcity;
    protected TextBox txtCompany;
    protected TextBox txtemail;
    protected TextBox txthousetel;
    protected TextBox txticq;
    protected TextBox txtmobile1;
    protected TextBox txtmobile2;
    protected TextBox txtmsn;
    protected TextBox txtmz;
    protected TextBox txtName;
    protected TextBox txtnational;
    protected TextBox txtofficetel;
    protected TextBox txtother;
    protected TextBox txtpostcode;
    protected TextBox txtprovince;
    protected TextBox txtqq;
    protected TextBox txtRole;
    protected HtmlInputHidden txtssbmpk;
    protected HtmlInputHidden txtssgspk;
    protected HtmlInputHidden txtssjspk;
    protected TextBox txtworkage;

    private void AddEmployee()
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            if (((this.txtbh.Text.Trim() == "") || (this.txtName.Text.Trim() == "")) || ((this.txtssbmpk.Value.Trim() == "") || (this.txtssjspk.Value.Trim() == "")))
            {
                Const.ShowMessage("带*的数据必须填写！", this.Page);
            }
            else
            {
                EmployeeModel model = new EmployeeDal();
                if (model.Exists(this.txtbh.Text.Trim(), this.dbo) > 0)
                {
                    Const.ShowMessage("员工编号已经存在！", this.Page);
                }
                else
                {
                    model.BH = this.txtbh.Text.Trim();
                    model.Name = this.txtName.Text.Trim();
                    model.Sex = this.rblsex1.SelectedItem.Value;
                    if (this.txtage.Text.Trim() != "")
                    {
                        model.Age = int.Parse(this.txtage.Text.Trim());
                    }
                    if (this.txtworkage.Text.Trim() != "")
                    {
                        model.WorkAge = int.Parse(this.txtworkage.Text.Trim());
                    }
                    model.MZ = this.txtmz.Text.Trim();
                    model.Nationals = this.txtnational.Text.Trim();
                    model.Province = this.txtprovince.Text.Trim();
                    model.Area = this.txtarea.Text.Trim();
                    model.City = this.txtcity.Text.Trim();
                    model.PostalCode = this.txtpostcode.Text.Trim();
                    model.Address = this.txtaddress.Text.Trim();
                    model.Phone = this.txthousetel.Text.Trim();
                    model.OfficePhone = this.txtofficetel.Text.Trim();
                    model.Mobile1 = this.txtmobile1.Text.Trim();
                    model.Mobile2 = this.txtmobile2.Text.Trim();
                    model.QQNum = this.txtqq.Text.Trim();
                    model.ICQNum = this.txticq.Text.Trim();
                    model.MSNNum = this.txtmsn.Text.Trim();
                    model.Email = this.txtemail.Text.Trim();
                    if (this.txtBirthDay.Value.Trim() != "")
                    {
                        model.BirthDay = DateTime.Parse(this.txtBirthDay.Value.Trim());
                    }
                    model.OtherLink = this.txtother.Text.Trim();
                    model.BranchPK = this.txtssbmpk.Value.Trim();
                    model.RolePK = this.txtssjspk.Value.Trim();
                    model.pk_corp = this.txtssgspk.Value.Trim();
                    int count = model.Add(this.dbo);
                    if (base.Request["reload"] != null)
                    {
                        Const.AddSuccess(count, base.Request["reload"].ToString(), this.Page);
                    }
                    else
                    {
                        Const.AddSuccess(count, "", this.Page);
                    }
                    OperationLogBll.insertOp("新增", "职员列表", "在 " + this.txtCompany.Text.Trim() + " 单位 " + this.txtBranch.Text.Trim() + " 部门下新增编号为：" + this.txtbh.Text.Trim() + " 名称为：" + this.txtName.Text.Trim() + " 角色为：" + this.txtRole.Text.Trim() + " 的职员", "Y", this.Page);
                }
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "AddEmployee()";
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
                this.AddEmployee();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.LBTitle = "新增员工";
        this.Master.TitlePic = "~/images/页标题/新增员工副本.jpg";
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (!base.IsPostBack)
        {
            if (this.Session["user"] == null)
            {
                Const.GoLoginPath_OpenWindow(this.Page);
            }
            else
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
                ButtonsModel model = new ButtonsModel(userName);
                if (PowerClass.IfHasPower(userName, power, PowerNum.EmployeeAdd))
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
