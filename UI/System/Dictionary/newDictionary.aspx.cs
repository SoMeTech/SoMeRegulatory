using ASP;
using ExceptionLog;
using SoMeTech.DataAccess;
using SoMeTech.User;
using SoMeTech.UsualBookTable;
using SoMeTech.YZXWPageClass;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Dictionary_newDictionary : Page, IRequiresSessionState
{
    private DB_OPT dbo;
    protected HtmlGenericControl divbh;
    private ExceptionLog.ExceptionLog el;
    protected HtmlInputHidden FatherPk;
    protected HtmlInputHidden flog;
    protected HtmlInputHidden tableName;
    protected TextBox txtBH;
    protected TextBox txtDiscription;
    protected TextBox txtFatherPk;
    protected TextBox txtname;
    private UsualBookTableModel ubtm;
    private UsualBookTableModel um;
    protected UpdatePanel UpdatePanel1;

    public void addupdate()
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            if ((this.txtname.Text.Trim() == "") || (this.txtBH.Text.Trim() == ""))
            {
                Const.ShowMessage("带*的数据必须填写！", this.Page);
            }
            else
            {
                this.ubtm = new UsualBookTableDal();
                this.um = new UsualBookTableModel();
                this.ubtm.FatherPK = this.FatherPk.Value.Trim();
                this.ubtm.TableName = base.Request.QueryString["tn"].ToString().Trim();
                if (this.ubtm.FatherPK != "")
                {
                    this.ubtm.PK = this.ubtm.FatherPK.Trim();
                    this.um = this.ubtm.GetModel(false, this.dbo);
                    if (this.um.IsHasBaby == "0")
                    {
                        this.ubtm.TableName = base.Request.QueryString["tn"].ToString();
                        this.ubtm.UpdateHasBaby(this.dbo);
                    }
                    this.ubtm.PKPath = this.ubtm.PKPath + this.ubtm.PK + "|";
                    this.ubtm.Grade = this.um.Grade;
                }
                this.ubtm.BH = this.txtBH.Text.Trim();
                this.ubtm.TableName = base.Request.QueryString["tn"].ToString().Trim();
                this.ubtm.Name = this.txtname.Text.Trim();
                this.ubtm.Discription = this.txtDiscription.Text.Trim();
                this.ubtm.FatherPK = this.FatherPk.Value.Trim();
                this.ubtm.IsHasBaby = "0";
                this.ubtm.Grade++;
                int count = 0;
                if ((base.Request["PK"] != null) && (base.Request["PK"].ToString() != ""))
                {
                    this.ubtm.PK = base.Request["PK"].ToString().Trim();
                    Const.UpdateSuccess(this.ubtm.Update(this.dbo), this.Page);
                }
                else
                {
                    this.ubtm.BH = this.txtBH.Text.Trim();
                    if (this.ubtm.Exists(this.dbo) > 0)
                    {
                        Const.ShowMessage("该编号已经存在！", this.Page);
                    }
                    else
                    {
                        count = this.ubtm.Add(this.dbo);
                        if (base.Request["reload"] != null)
                        {
                            Const.AddSuccess(count, base.Request["reload"].ToString(), this.Page);
                        }
                        else
                        {
                            Const.AddSuccess(count, "", this.Page);
                        }
                    }
                }
            }
        }
        catch (Exception exception)
        {
            this.el = new ExceptionLog.ExceptionLog();
            this.el.ErrClassName = base.GetType().ToString();
            this.el.ErrMessage = exception.Message.ToString();
            this.el.ErrMethod = "addupdate()";
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
        switch (ibtid)
        {
            case "ibtcontrol_ibtsave":
                this.addupdate();
                break;

            case "ibtcontrol_ibtdelete":
            case "ibtcontrol_ibtlook":
            case "ibtcontrol_ibtsearch":
            case "ibtcontrol_ibtrefresh":
            case "ibtcontrol_ibthuizong":
            case "ibtcontrol_ibtputout":
            case "ibtcontrol_ibtset":
            case "ibtcontrol_ibtexit":
                break;

            default:
                return;
        }
    }

    public void getTitleAdd()
    {
        switch (base.Request.QueryString["tn"])
        {
            case "GOV_TC_DB_FWType":
                this.Master.strTitle = "新增房屋类别档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增房屋类别档案";
                return;

            case "GOV_TC_DB_JZXMXZ":
                this.Master.strTitle = "新增建设项目性质档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增建设项目性质档案";
                return;

            case "GOV_TC_DB_HOUSETYPE":
                this.Master.strTitle = "新增房屋用途档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增房屋用途档案";
                return;

            case "GOV_TC_DB_HOUSEBUILDTYPE":
                this.Master.strTitle = "新增房屋建设性质档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增房屋建设性质档案";
                return;

            case "GOV_TC_DB_HOUSEPOWERTYPE":
                this.Master.strTitle = "新增房屋产权类型档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增房屋产权类型档案";
                return;

            case "GOV_TC_DB_HOUSENUMTYPE":
                this.Master.strTitle = "新增房屋数量类型档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增房屋数量类型档案";
                return;

            case "GOV_TC_DB_TDType":
                this.Master.strTitle = "新增土地性质档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增土地性质档案";
                return;

            case "GOV_TC_DB_FKFS":
                this.Master.strTitle = "新增收付款方式档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增收付款方式档案";
                return;

            case "GOV_TC_DB_OperationPassType":
                this.Master.strTitle = "新增多人审批方式档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增多人审批方式档案";
                return;

            case "GOV_TC_DB_TaxFeeKind":
                this.Master.strTitle = "新增税费项目性质档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增税费项目性质档案";
                return;

            case "GOV_TC_DB_JZType":
                this.Master.strTitle = "新增房屋结构档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增房屋结构档案";
                return;

            case "GOV_TC_DB_ISHESHICHAJIA":
                this.Master.strTitle = "新增能否核实档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增能否核实档案";
                return;

            case "GOV_TC_DB_SOILUSE":
                this.Master.strTitle = "新增土地用途档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 新增土地用途档案";
                return;
        }
    }

    public void getTitleUpdate()
    {
        switch (base.Request.QueryString["tn"])
        {
            case "GOV_TC_DB_FWType":
                this.Master.strTitle = "修改房屋类别档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改房屋类别档案";
                return;

            case "GOV_TC_DB_JZXMXZ":
                this.Master.strTitle = "修改建设项目性质档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改建设项目性质档案";
                return;

            case "GOV_TC_DB_HOUSETYPE":
                this.Master.strTitle = "修改房屋用途档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改房屋用途档案";
                return;

            case "GOV_TC_DB_HOUSEBUILDTYPE":
                this.Master.strTitle = "修改房屋建设性质档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改房屋建设性质档案";
                return;

            case "GOV_TC_DB_HOUSEPOWERTYPE":
                this.Master.strTitle = "修改房屋产权类型档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改房屋产权类型档案";
                return;

            case "GOV_TC_DB_HOUSENUMTYPE":
                this.Master.strTitle = "修改房屋数量类型档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改房屋数量类型档案";
                return;

            case "GOV_TC_DB_TDType":
                this.Master.strTitle = "修改土地性质档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改土地性质档案";
                return;

            case "GOV_TC_DB_FKFS":
                this.Master.strTitle = "修改收付款方式档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改收付款方式档案";
                return;

            case "GOV_TC_DB_OperationPassType":
                this.Master.strTitle = "修改多人审批方式档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改多人审批方式档案";
                return;

            case "GOV_TC_DB_TaxFeeKind":
                this.Master.strTitle = "修改税费项目性质档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改税费项目性质档案";
                return;

            case "GOV_TC_DB_JZType":
                this.Master.strTitle = "修改房屋结构档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改房屋结构档案";
                return;

            case "GOV_TC_DB_ISHESHICHAJIA":
                this.Master.strTitle = "修改能否核实档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改能否核实档案";
                return;

            case "GOV_TC_DB_SOILUSE":
                this.Master.strTitle = "修改土地用途档案";
                this.Master.LBTitle = "乡镇财政资金监管信息系统 - 修改土地用途档案";
                return;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
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
            IfExit = true
        };
        this.Master.btModel = model;
        this.Master.ButtonsPushDown = new ButtonsHandler(this.Buttons);
        if (!base.IsPostBack)
        {
            if (this.Session["user"] == null)
            {
                Const.GoLoginPath_OpenWindow(this.Page);
            }
            else
            {
                if ((base.Request["PK"] != null) && (base.Request["PK"].ToString() != ""))
                {
                    model.IfSave = true;
                    this.getTitleUpdate();
                    this.txtBH.ReadOnly = true;
                    this.flog.Value = "Update";
                    try
                    {
                        this.dbo = new DB_OPT();
                        this.dbo.Open();
                        this.ubtm = new UsualBookTableDal();
                        this.ubtm.TableName = base.Request["tn"].ToString();
                        this.ubtm.PK = base.Request["PK"].ToString();
                        this.ubtm = this.ubtm.GetModel(true, this.dbo);
                        this.txtBH.Text = this.ubtm.BH;
                        this.txtname.Text = this.ubtm.Name.ToString();
                        this.txtDiscription.Text = this.ubtm.Discription.ToString();
                        this.FatherPk.Value = this.ubtm.FatherPK.Trim();
                        if (this.ubtm.FatherPK.ToString() != "")
                        {
                            DataSet set = new DataSet();
                            string strSql = "select * from " + base.Request["tn"].ToString() + " where pk='" + this.ubtm.FatherPK.Trim() + "'";
                            set = this.dbo.BackDataSet(strSql, null);
                            if ((set != null) && (set.Tables[0].Rows.Count > 0))
                            {
                                this.txtFatherPk.Text = set.Tables[0].Rows[0]["Name"].ToString();
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        this.el = new ExceptionLog.ExceptionLog();
                        this.el.ErrClassName = base.GetType().ToString();
                        this.el.ErrMessage = exception.Message.ToString();
                        this.el.ErrMethod = "addupdate()";
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
                else
                {
                    model.IfSave = true;
                    this.getTitleAdd();
                    this.flog.Value = "add";
                }
                if (base.Request["tn"] != null)
                {
                    this.tableName.Value = base.Request["tn"].ToString();
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
