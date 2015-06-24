using ASP;
using ExceptionLog;
using SoMeTech.Company.Employee;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using QxRoom.Common;
using QxRoom.Common.ControlDo;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Employee_EmployeeUpdate : Page, IRequiresSessionState
{
    private DB_OPT dbo;
    private ExceptionLog.ExceptionLog el;
    protected Label labaddress;
    protected Label labage;
    protected Label labarea;
    protected Label labbh;
    protected Label labBirthDay;
    protected Label labBranch;
    protected Label labcity;
    protected Label labCompany;
    protected Label labemail;
    protected Label labhousetel;
    protected Label labicq;
    protected Label labmobile1;
    protected Label labmobile2;
    protected Label labmsn;
    protected Label labmz;
    protected Label labName;
    protected Label labnational;
    protected Label labofficetel;
    protected Label labother;
    protected Label labpostcode;
    protected Label labprovince;
    protected Label labqq;
    protected Label labRole;
    protected Label labssbmpk;
    protected Label labssgspk;
    protected Label labssjspk;
    protected Label labworkage;
    protected Label labxb;
    protected RadioButtonList rblsex1;
    protected TextBox txtaddress;
    protected TextBox txtaddress_bak;
    protected TextBox txtage;
    protected TextBox txtage_bak;
    protected TextBox txtarea;
    protected TextBox txtarea_bak;
    protected TextBox txtbh;
    protected TextBox txtbh_bak;
    protected HtmlInputText txtBirthDay;
    protected HtmlInputText txtBirthDay_bak;
    protected TextBox txtBranch;
    protected TextBox txtBranch_bak;
    protected TextBox txtcity;
    protected TextBox txtcity_bak;
    protected TextBox txtCompany;
    protected TextBox txtCompany_bak;
    protected TextBox txtemail;
    protected TextBox txtemail_bak;
    protected TextBox txthousetel;
    protected TextBox txthousetel_bak;
    protected TextBox txticq;
    protected TextBox txticq_bak;
    protected TextBox txtmobile1;
    protected TextBox txtmobile1_bak;
    protected TextBox txtmobile2;
    protected TextBox txtmobile2_bak;
    protected TextBox txtmsn;
    protected TextBox txtmsn_bak;
    protected TextBox txtmz;
    protected TextBox txtmz_bak;
    protected TextBox txtName;
    protected TextBox txtName_bak;
    protected TextBox txtnational;
    protected TextBox txtnational_bak;
    protected TextBox txtofficetel;
    protected TextBox txtofficetel_bak;
    protected TextBox txtother;
    protected TextBox txtother_bak;
    protected TextBox txtpostcode;
    protected TextBox txtpostcode_bak;
    protected TextBox txtprovince;
    protected TextBox txtprovince_bak;
    protected TextBox txtqq;
    protected TextBox txtqq_bak;
    protected TextBox txtRole;
    protected TextBox txtRole_bak;
    protected HtmlInputHidden txtssbmpk;
    protected HtmlInputHidden txtssbmpk_bak;
    protected HtmlInputHidden txtssgspk;
    protected HtmlInputHidden txtssgspk_bak;
    protected HtmlInputHidden txtssjspk;
    protected HtmlInputHidden txtssjspk_bak;
    protected TextBox txtworkage;
    protected TextBox txtworkage_bak;
    protected TextBox txtxbbak;

    private void BindData()
    {
        EmployeeModel model = new EmployeeDal
        {
            EmployeePK = base.Request.QueryString["PK"].ToString()
        };
        model = model.GetModel(false, false, true, true, true, this.dbo);
        this.txtbh.Text = model.BH;
        this.txtbh_bak.Text = model.BH;
        this.txtName.Text = model.Name;
        this.txtName_bak.Text = model.Name;
        if (Public.IsNumber(model.Sex))
        {
            this.rblsex1.SelectedIndex = int.Parse(model.Sex);
            this.txtxbbak.Text = model.Sex;
        }
        this.txtage.Text = model.Age.ToString();
        this.txtage_bak.Text = model.Age.ToString();
        this.txtworkage.Text = model.WorkAge.ToString();
        this.txtworkage_bak.Text = model.WorkAge.ToString();
        this.txtmz.Text = model.MZ;
        this.txtmz_bak.Text = model.MZ;
        this.txtnational.Text = model.Nationals;
        this.txtnational_bak.Text = model.Nationals;
        this.txtprovince.Text = model.Province;
        this.txtprovince_bak.Text = model.Province;
        this.txtarea.Text = model.Area;
        this.txtarea_bak.Text = model.Area;
        this.txtcity.Text = model.City;
        this.txtcity_bak.Text = model.City;
        this.txtpostcode.Text = model.PostalCode;
        this.txtpostcode_bak.Text = model.PostalCode;
        this.txtaddress.Text = model.Address;
        this.txtaddress_bak.Text = model.Address;
        this.txthousetel.Text = model.Phone;
        this.txthousetel_bak.Text = model.Phone;
        this.txtofficetel.Text = model.OfficePhone;
        this.txtofficetel_bak.Text = model.OfficePhone;
        this.txtmobile1.Text = model.Mobile1;
        this.txtmobile1_bak.Text = model.Mobile1;
        this.txtmobile2.Text = model.Mobile2;
        this.txtmobile2_bak.Text = model.Mobile2;
        this.txtqq.Text = model.QQNum;
        this.txtqq_bak.Text = model.QQNum;
        this.txticq.Text = model.ICQNum;
        this.txticq_bak.Text = model.ICQNum;
        this.txtmsn.Text = model.MSNNum;
        this.txtmsn_bak.Text = model.MSNNum;
        this.txtemail.Text = model.Email;
        this.txtemail_bak.Text = model.Email;
        this.txtother.Text = model.OtherLink;
        this.txtother_bak.Text = model.OtherLink;
        if (model.BirthDay.ToString() != "")
        {
            this.txtBirthDay.Value = model.BirthDay.ToShortDateString();
            this.txtBirthDay_bak.Value = model.BirthDay.ToShortDateString();
        }
        this.txtssgspk.Value = model.pk_corp;
        this.txtssgspk_bak.Value = model.pk_corp;
        if (model.Company != null)
        {
            this.txtCompany.Text = model.Company.Name;
            this.txtCompany_bak.Text = model.Company.Name;
        }
        this.txtssbmpk.Value = model.BranchPK;
        this.txtssbmpk_bak.Value = model.BranchPK;
        if (model.Branch != null)
        {
            this.txtBranch.Text = model.Branch.Name;
            this.txtBranch_bak.Text = model.Branch.Name;
        }
        this.txtssjspk.Value = model.RolePK;
        this.txtssjspk_bak.Value = model.RolePK;
        if (model.Role != null)
        {
            this.txtRole.Text = model.Role.Name;
            this.txtRole_bak.Text = model.Role.Name;
        }
    }

    public void Buttons(string ibtid)
    {
        string str;
        if (((str = ibtid) != null) && (str != "ibtcontrol_ibtupdate"))
        {
            if (!(str == "ibtcontrol_ibtsave"))
            {
                if (((str == "ibtcontrol_ibtrefresh") || (str == "ibtcontrol_ibtset")) || (str != "ibtcontrol_ibtexit"))
                {
                }
            }
            else
            {
                this.DataUpdate();
            }
        }
    }

    private void DataUpdate()
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
                string strEditMess = "";
                if (!PageDo.IsChanged(ref strEditMess, true, this.Page) && (this.txtxbbak.Text == this.rblsex1.SelectedIndex.ToString()))
                {
                    Const.ShowMessage("没有修改任何信息，请修改信息后再保存！", this.Page);
                }
                else
                {
                    if (this.txtxbbak.Text != this.rblsex1.SelectedIndex.ToString())
                    {
                        string str2 = strEditMess;
                        strEditMess = str2 + "性别从 " + this.txtxbbak.Text + " 修改为 " + this.rblsex1.SelectedIndex.ToString();
                    }
                    string strUser = base.Request.QueryString["PK"].ToString().Trim();
                    EmployeeModel model = new EmployeeDal
                    {
                        EmployeePK = strUser,
                        BH = this.txtbh.Text.Trim(),
                        Name = this.txtName.Text.Trim(),
                        Sex = this.rblsex1.SelectedItem.Value
                    };
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
                    if (model.Update(this.dbo) > 0)
                    {
                        UserModel model2 = new UserDal
                        {
                            EmployeePK = strUser
                        };
                        if (model2.ExistsByEmpPK(this.dbo) > 0)
                        {
                            UserBll bll = new UserBll();
                            if (bll.Updateuserinfo(strUser, this.txtssbmpk.Value, this.txtssjspk.Value.Trim(), this.txtName.Text, this.txtssgspk.Value.Trim(), this.dbo) <= 0)
                            {
                                Const.DoSuccessClose("修改员工信息成功，但联动修改用户信息失败，请手动修改用户信息！", this.Page);
                            }
                        }
                        Const.DoSuccessClose("修改员工信息成功！", this.Page);
                        strEditMess = "编号为：" + this.txtbh.Text.Trim() + " 名称为：" + this.txtName.Text.Trim() + " 的职员修改信息：" + strEditMess;
                        OperationLogBll.insertOp("修改", "职员列表", strEditMess, "Y", this.Page);
                    }
                    else
                    {
                        Const.ShowMessage("", this.Page);
                    }
                }
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "DataUpdate()";
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

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改员工信息";
        this.Master.TitlePic = "~/images/页标题/修改用户副本.jpg";
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (!base.IsPostBack)
        {
            if (this.Session["user"] == null)
            {
                Const.GoLoginPath_OpenDialog(this.Page);
            }
            else if (base.Request.QueryString["PK"] != null)
            {
                string userName = ((UserModel)this.Session["User"]).UserName;
                string power = ((UserModel)this.Session["User"]).Power;
                string companyPower = ((UserModel)this.Session["User"]).CompanyPower;
                ButtonsModel model = new ButtonsModel(userName);
                if (PowerClass.IfHasPower(userName, power, PowerNum.EmployeeUpdate))
                {
                    try
                    {
                        try
                        {
                            this.dbo = new DB_OPT();
                            this.dbo.Open();
                            this.BindData();
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
                        catch (Exception exception)
                        {
                            this.el = new ExceptionLog.ExceptionLog();
                            this.el.ErrClassName = base.GetType().ToString();
                            this.el.ErrMessage = exception.Message.ToString();
                            this.el.ErrMethod = "Page_Load()";
                            this.el.WriteExceptionLog(true);
                            Const.OpenErrorPage("获取数据失败，请联系管理员！", this.Page);
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
