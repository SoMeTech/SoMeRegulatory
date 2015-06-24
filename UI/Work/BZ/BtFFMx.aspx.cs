using ASP;
using SoMeTech.CommonDll;
using SoMeTech.User;
using SoMeTech.YZXWPageClass;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMZJ.BLL;
using SMZJ.Model;

public class Work_BZ_projBtFFMx : Page, IRequiresSessionState
{
    protected DropDownList ddlPD_BZFFLIST_COUNTRY;
    protected Label lblAUTO_NO;
    protected TextBox txtPD_BZFFLIST_ACCOUNTNO;
    protected TextBox txtPD_BZFFLIST_COMPANY;
    protected TextBox txtPD_BZFFLIST_DATE;
    protected TextBox txtPD_BZFFLIST_FFMONEY;
    protected TextBox txtPD_BZFFLIST_FFNUM;
    protected TextBox txtPD_BZFFLIST_FFSTAND;
    protected TextBox txtPD_BZFFLIST_IDNO;
    protected TextBox txtPD_BZFFLIST_PEASANT_ADDR;
    protected TextBox txtPD_BZFFLIST_PEASANT_CODE;
    protected TextBox txtPD_BZFFLIST_PEASANT_NAME;

    private void BindDDList()
    {
        PublicDal.BindDropDownList(this.ddlPD_BZFFLIST_COUNTRY, "v_company_branch", "NAME", "BH", " comp_ishasbaby=0 ");
    }

    public void Buttons(string ibtid)
    {
        switch (ibtid)
        {
            case "ibtcontrol_ibtdelete":
                this.DelData(base.Request["UpdatePK"].Trim());
                return;

            case "ibtcontrol_ibtsave":
                if ((base.Request["UpdatePK"] == null) || !(base.Request["UpdatePK"].Trim() != ""))
                {
                    this.CreateData();
                    return;
                }
                this.UpdataData(base.Request["UpdatePK"].Trim());
                return;

            case "ibtcontrol_ibtrefresh":
            case "ibtcontrol_ibtaudit":
            case "ibtcontrol_ibtsetback":
            case "ibtcontrol_ibtrollback":
                return;
        }
    }

    private void CreateData()
    {
        PD_PROJECT_BZFFLIST_Bll bll = new PD_PROJECT_BZFFLIST_Bll();
        PD_PROJECT_BZFFLIST_Model model = new PD_PROJECT_BZFFLIST_Model();
        model = this.GetModel(null);
        if (model != null)
        {
            bll.Add(model);
        }
        else
        {
            return;
        }
        PageShowText.Refurbish("添加成功", this.Page);
    }

    private void DelData(string AUTO_NO)
    {
        new PD_PROJECT_BZFFLIST_Bll().Delete(AUTO_NO);
        PageShowText.Refurbish("删除成功", this.Page);
    }

    private PD_PROJECT_BZFFLIST_Model GetModel(PD_PROJECT_BZFFLIST_Model model)
    {
        if (model == null)
        {
            model = new PD_PROJECT_BZFFLIST_Model();
        }
        string str = "";
        if (!PageValidate.IsDateTime(this.txtPD_BZFFLIST_DATE.Text))
        {
            str = str + @"补贴发放时间格式错误！\n";
        }
        if (this.txtPD_BZFFLIST_COMPANY.Text.Trim().Length == 0)
        {
            str = str + @"补贴发放单位不能为空！\n";
        }
        if (this.ddlPD_BZFFLIST_COUNTRY.SelectedValue.Trim().Length == 0)
        {
            str = str + @"所属乡镇不能为空！\n";
        }
        if (this.txtPD_BZFFLIST_PEASANT_CODE.Text.Trim().Length == 0)
        {
            str = str + @"农户代码不能为空！\n";
        }
        if (this.txtPD_BZFFLIST_PEASANT_NAME.Text.Trim().Length == 0)
        {
            str = str + @"农户姓名不能为空！\n";
        }
        if (this.txtPD_BZFFLIST_IDNO.Text.Trim().Length == 0)
        {
            str = str + @"身份证号码不能为空！\n";
        }
        if (!PageValidate.IsNumber(this.txtPD_BZFFLIST_FFNUM.Text))
        {
            str = str + @"补贴数量格式错误！\n";
        }
        if (!PageValidate.IsNumber(this.txtPD_BZFFLIST_FFSTAND.Text))
        {
            str = str + @"补贴标准格式错误！\n";
        }
        if (!PageValidate.IsNumber(this.txtPD_BZFFLIST_FFMONEY.Text))
        {
            str = str + @"补贴金额格式错误！\n";
        }
        if (this.txtPD_BZFFLIST_ACCOUNTNO.Text.Trim().Length == 0)
        {
            str = str + @"发放账号不能为空！\n";
        }
        if (this.txtPD_BZFFLIST_PEASANT_ADDR.Text.Trim().Length == 0)
        {
            str = str + @"农户家庭住址不能为空！\n";
        }
        if (str != "")
        {
            PageShowText.ShowMessage(str, this.Page);
            return null;
        }
        string text = this.lblAUTO_NO.Text;
        DateTime time = DateTime.Parse(this.txtPD_BZFFLIST_DATE.Text);
        string str3 = this.txtPD_BZFFLIST_COMPANY.Text;
        string selectedValue = this.ddlPD_BZFFLIST_COUNTRY.SelectedValue;
        string str5 = this.txtPD_BZFFLIST_PEASANT_CODE.Text;
        string str6 = this.txtPD_BZFFLIST_PEASANT_NAME.Text;
        string str7 = this.txtPD_BZFFLIST_IDNO.Text;
        int num = int.Parse(this.txtPD_BZFFLIST_FFNUM.Text);
        int num2 = int.Parse(this.txtPD_BZFFLIST_FFSTAND.Text);
        int num3 = int.Parse(this.txtPD_BZFFLIST_FFMONEY.Text);
        string str8 = this.txtPD_BZFFLIST_ACCOUNTNO.Text;
        string str9 = this.txtPD_BZFFLIST_PEASANT_ADDR.Text;
        model.AUTO_NO = text;
        model.PD_BZFFLIST_DATE = new DateTime?(time);
        model.PD_BZFFLIST_COMPANY = str3;
        model.PD_BZFFLIST_COUNTRY = selectedValue;
        model.PD_BZFFLIST_PEASANT_CODE = str5;
        model.PD_BZFFLIST_PEASANT_NAME = str6;
        model.PD_BZFFLIST_IDNO = str7;
        model.PD_BZFFLIST_FFNUM = new decimal?(num);
        model.PD_BZFFLIST_FFSTAND = new decimal?(num2);
        model.PD_BZFFLIST_FFMONEY = new decimal?(num3);
        model.PD_BZFFLIST_ACCOUNTNO = str8;
        model.PD_BZFFLIST_PEASANT_ADDR = str9;
        return model;
    }

    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }

    protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void gvResult_Sorting(object sender, GridViewSortEventArgs e)
    {
    }

    public void ListPageLoad(Page page, out ButtonsModel main_bm)
    {
        string userName = ((UserModel)HttpContext.Current.Session["User"]).UserName;
        main_bm = new ButtonsModel(userName);
        main_bm.IfSave = true;
        main_bm.IfExit = true;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session["User"] == null)
        {
            Const.GoLoginPath_OpenWindow(this.Page);
        }
        else
        {
            if (base.Request["strTitle"] != null)
            {
                this.Master.strTitle = base.Request["strTitle"];
            }
            this.Master.strTitle = base.Request["strTitle"];
            this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
            this.Master.SearchHasGone = new SearchHandler(this.SearchControl);
            ButtonsModel model = null;
            this.ListPageLoad(this.Page, out model);
            this.Master.btModel = model;
            this.BindDDList();
            if ((!base.IsPostBack && (base.Request["UpdatePK"] != null)) && (base.Request["UpdatePK"].Trim() != ""))
            {
                this.ShowInfo(base.Request["UpdatePK"].Trim());
            }
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
    }

    private void ShowInfo(string AUTO_NO)
    {
        PD_PROJECT_BZFFLIST_Model model = new PD_PROJECT_BZFFLIST_Bll().GetModel(AUTO_NO);
        this.lblAUTO_NO.Text = model.AUTO_NO;
        this.txtPD_BZFFLIST_DATE.Text = model.PD_BZFFLIST_DATE.ToString();
        this.txtPD_BZFFLIST_COMPANY.Text = model.PD_BZFFLIST_COMPANY;
        this.ddlPD_BZFFLIST_COUNTRY.SelectedValue = model.PD_BZFFLIST_COUNTRY;
        this.txtPD_BZFFLIST_PEASANT_CODE.Text = model.PD_BZFFLIST_PEASANT_CODE;
        this.txtPD_BZFFLIST_PEASANT_NAME.Text = model.PD_BZFFLIST_PEASANT_NAME;
        this.txtPD_BZFFLIST_IDNO.Text = model.PD_BZFFLIST_IDNO;
        this.txtPD_BZFFLIST_FFNUM.Text = model.PD_BZFFLIST_FFNUM.ToString();
        this.txtPD_BZFFLIST_FFSTAND.Text = model.PD_BZFFLIST_FFSTAND.ToString();
        this.txtPD_BZFFLIST_FFMONEY.Text = model.PD_BZFFLIST_FFMONEY.ToString();
        this.txtPD_BZFFLIST_ACCOUNTNO.Text = model.PD_BZFFLIST_ACCOUNTNO;
        this.txtPD_BZFFLIST_PEASANT_ADDR.Text = model.PD_BZFFLIST_PEASANT_ADDR;
    }

    private void UpdataData(string AUTO_NO)
    {
        PD_PROJECT_BZFFLIST_Bll bll = new PD_PROJECT_BZFFLIST_Bll();
        PD_PROJECT_BZFFLIST_Model model = this.GetModel(bll.GetModel(AUTO_NO));
        bll.Update(model);
        PageShowText.Refurbish("修改成功", this.Page);
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public MainMX Master
    {
        get
        {
            return (MainMX)base.Master;
        }
    }

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }

    private static class PageValidate
    {
        public static bool IsDateTime(string text)
        {
            DateTime time;
            return DateTime.TryParse(text, out time);
        }

        public static bool IsNumber(string text)
        {
            int num;
            return int.TryParse(text, out num);
        }
    }
}
