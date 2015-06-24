using ASP;
using SoMeTech.CommonDll;
using SoMeTech.YZXWPageClass;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SMZJ.BLL;
using SMZJ.Model;

public class Work_DataPrint_companyToDataAdd : Page, IRequiresSessionState
{
    protected DropDownList dllDATANAME;
    protected HtmlInputText lblCOMPANYBH;
    protected Label lblPK;
    protected HtmlInputText txtCOMPANYBH;

    private void Bind()
    {
        DataSet sQLDataName = new GOV_TC_DB_COMPANYDATADZ_Bll().GetSQLDataName();
        if ((sQLDataName != null) && (sQLDataName.Tables.Count > 0))
        {
            this.dllDATANAME.DataSource = sQLDataName.Tables[0];
            this.dllDATANAME.DataTextField = "ztmc";
            this.dllDATANAME.DataValueField = "dbname";
            this.dllDATANAME.DataBind();
        }
    }

    public void Buttons(string ibtid)
    {
        string str;
        if (((str = ibtid) != null) && (str == "ibtcontrol_ibtsave"))
        {
            if (base.Request["UpdatePK"] != null)
            {
                if (PublicDal.PageValidate.IsNumber(base.Request["UpdatePK"]))
                {
                    if (this.UpdateData(long.Parse(base.Request["UpdatePK"])))
                    {
                        PageShowText.Refurbish("修改成功", this.Page);
                    }
                    else
                    {
                        PageShowText.Refurbish("修改失败", this.Page);
                    }
                }
            }
            else if (this.CreateData())
            {
                PageShowText.Refurbish("添加成功", this.Page);
            }
            else
            {
                PageShowText.Refurbish("添加失败", this.Page);
            }
        }
    }

    private bool CreateData()
    {
        GOV_TC_DB_COMPANYDATADZ_Bll bll = new GOV_TC_DB_COMPANYDATADZ_Bll();
        GOV_TC_DB_COMPANYDATADZ_Model model = null;
        this.GetModel(ref model);
        return bll.Add(model);
    }

    private void GetModel(ref GOV_TC_DB_COMPANYDATADZ_Model model)
    {
        if (model == null)
        {
            model = new GOV_TC_DB_COMPANYDATADZ_Model();
        }
        model.DATANAME = this.dllDATANAME.SelectedItem.Value;
        model.COMPANYBH = this.txtCOMPANYBH.Value;
        model.SHOWNAME = this.dllDATANAME.SelectedItem.Text;
    }

    public void ListPageLoad(Page page, out ButtonsModel main_bm, string PK)
    {
        PublicDal.ShowMxButton(this.Page, out main_bm, "GOV_TC_DB_COMPANYDATADZ", "PK", PK, "PD_NOW_SERVERPK");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (base.Request["strTitle"] != null)
        {
            this.Master.strTitle = base.Request["strTitle"];
        }
        this.Master.strTitle = base.Request["strTitle"];
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        this.Master.SearchHasGone = new SearchHandler(this.SearchControl);
        ButtonsModel model = null;
        this.ListPageLoad(this.Page, out model, null);
        this.Master.btModel = model;
        if (!base.IsPostBack)
        {
            this.Bind();
            if ((base.Request["UpdatePK"] != null) && (base.Request["UpdatePK"].Trim() != ""))
            {
                this.ShowInfo(long.Parse(base.Request["UpdatePK"].Trim()));
            }
        }
    }

    protected void PageChangControl(object sender, int nPageIndex)
    {
    }

    protected void SearchControl(object sender, string strselect, string strcloname, string strsql, DataSet dstable, DataSet dsclo)
    {
    }

    private void ShowInfo(long PK)
    {
        GOV_TC_DB_COMPANYDATADZ_Model model = new GOV_TC_DB_COMPANYDATADZ_Bll().GetModel(PK);
        this.dllDATANAME.SelectedValue = model.DATANAME;
        this.txtCOMPANYBH.Value = model.COMPANYBH;
        this.lblCOMPANYBH.Value = model.COMPANYNAME;
    }

    private bool UpdateData(long pk)
    {
        GOV_TC_DB_COMPANYDATADZ_Bll bll = new GOV_TC_DB_COMPANYDATADZ_Bll();
        GOV_TC_DB_COMPANYDATADZ_Model model = bll.GetModel(pk);
        this.GetModel(ref model);
        return bll.Update(model);
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
}
