using ASP;
using SoMeTech.Data;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SMZJ.BLL;
using SMZJ.Model;
public class Work_FaGui_messbackoperinput : Page, IRequiresSessionState
{
    private MESS_BACK_Bll B_mesback = new MESS_BACK_Bll();
    protected Label backobj;
    protected Button Button1;
    protected Label company;
    protected Label createdate;
    protected HtmlForm form1;
    protected Label gzjy;
    protected Label knwt;
    protected HtmlGenericControl printDiv;
    protected Label project_name;
    protected tablepage_reprotButtonl reprotButtonl1;
    protected Label xzfyj;
    protected Label year;

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.ExpertControl(this.printDiv, DocumentType.Word, "乡镇财政资金信息反馈情况表");
    }

    public void ExpertControl(Control source, DocumentType type, string filename)
    {
        if (type == DocumentType.Excel)
        {
            base.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename, Encoding.UTF8) + ".xls");
            base.Response.ContentType = "application/ms-excel";
        }
        else if (type == DocumentType.Word)
        {
            base.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename, Encoding.UTF8) + ".doc");
            base.Response.ContentType = "application/ms-word";
        }
        base.Response.Charset = "UTF-8";
        base.Response.ContentEncoding = Encoding.UTF8;
        source.Page.EnableViewState = false;
        StringWriter writer = new StringWriter();
        HtmlTextWriter writer2 = new HtmlTextWriter(writer);
        source.RenderControl(writer2);
        base.Response.Write(writer.ToString());
        base.Response.End();
    }

    private string getFkName(string fkcode)
    {
        if (!string.IsNullOrEmpty(fkcode))
        {
            DataSet set = DbHelperOra.Query("select name from V_company_branch where bh='" + fkcode + "'");
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                return set.Tables[0].Rows[0]["name"].ToString();
            }
        }
        return "";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsCallback)
        {
            this.reprotButtonl1.DaochuBt.Attributes.Add("onclick", "newSaveWord()");
        }
        if (!base.IsPostBack && (base.Request["UpdatePK"] != null))
        {
            this.ShowInfo(base.Request["UpdatePK"].ToString());
        }
    }

    private void ShowInfo(string backid)
    {
        MESS_BACK_Model model = new MESS_BACK_Model();
        model = this.B_mesback.GetModel(backid);
        this.year.Text = DateTime.Now.Year.ToString();
        this.company.Text = model.MES_COMPANY_NAME;
        this.createdate.Text = !model.MES_DATE.HasValue ? "" : Convert.ToDateTime(model.MES_DATE).ToString("yyyy年MM月dd日");
        this.project_name.Text = model.PD_PROJECT_NAME;
        this.backobj.Text = this.getFkName(model.PD_QUOTA_DEPART);
        this.knwt.Text = model.MES_KUNAN;
        this.gzjy.Text = model.MES_JIANYI;
        this.xzfyj.Text = model.MES_XZYJ;
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }

    public enum DocumentType
    {
        Word,
        Excel
    }
}
