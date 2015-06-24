using ASP;
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

public class Report_jsxGTable2 : Page, IRequiresSessionState
{
    protected Button Button1;
    protected HtmlForm form1;
    protected HtmlHead Head1;
    protected Label lblxname;
    protected Label lblxz;
    protected HtmlGenericControl printDiv;
    protected tablepage_reprotButtonl reprotButtonl1;
    protected Label ���������;
    protected Label ��������ǩ��;
    protected Label ���������;
    protected Label ��ʾ;
    protected Label ��ʾ����;
    protected Label ��ܼ�¼;
    protected Label ��ܽ���;
    protected Label �����ǩ��;
    protected Label �������;
    protected Label ����ʽ�����;
    protected Label �Ƿ�ʾ;
    protected Label ��Ŀ����ص㼰����;
    protected Label ��Ŀʵʩ��λ;
    protected Label ��Ŀ���ܲ���;
    protected Label ָ����;
    protected Label ָ���ĺ�;

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.ExpertControl(this.printDiv, DocumentType.Word, "��Ŀ�����ʽ��ܼ�¼��");
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsCallback)
        {
            this.reprotButtonl1.DaochuBt.Attributes.Add("onclick", "newSaveWord()");
        }
        if ((this.Session["printID"] != null) && (this.Session["printID"].ToString() != ""))
        {
            this.ShowInfo(base.Request["UpdatePK"].ToString(), this.Session["printID"].ToString());
            this.Session["printID"] = null;
        }
        else
        {
            this.ShowInfo(base.Request["UpdatePK"].ToString());
        }
    }

    private void ShowInfo(string pd_project_code)
    {
        DataSet list = new ReportPublicBll().GetList("��Ŀ����='" + pd_project_code + "'", "view_tb_project_jgljb_xm2");
        if ((list.Tables.Count > 0) && (list.Tables[0].Rows.Count > 0))
        {
            this.lblxname.Text = list.Tables[0].Rows[0]["����"].ToString();
            this.lblxz.Text = list.Tables[0].Rows[0]["�ʽ�ʹ�õ�λ"].ToString();
            this.����ʽ�����.Text = list.Tables[0].Rows[0]["����ʽ�����"].ToString();
            this.�������.Text = list.Tables[0].Rows[0]["�������"].ToString();
            this.��Ŀ����ص㼰����.Text = list.Tables[0].Rows[0]["��Ŀ����ص㼰����"].ToString();
            this.ָ���ĺ�.Text = list.Tables[0].Rows[0]["ָ���ĺ�"].ToString();
            this.ָ����.Text = list.Tables[0].Rows[0]["ָ����"].ToString();
            this.��Ŀ���ܲ���.Text = list.Tables[0].Rows[0]["��Ŀ���ܲ���"].ToString();
            this.��Ŀʵʩ��λ.Text = list.Tables[0].Rows[0]["��Ŀʵʩ��λ"].ToString();
            this.���������.Text = list.Tables[0].Rows[0]["���������"].ToString();
            this.��ʾ.Text = list.Tables[0].Rows[0]["��ʾ"].ToString();
            this.��ʾ����.Text = list.Tables[0].Rows[0]["��ʾ����"].ToString();
            this.�Ƿ�ʾ.Text = list.Tables[0].Rows[0]["�Ƿ�ʾ"].ToString();
            this.��ܼ�¼.Text = list.Tables[0].Rows[0]["��ܼ�¼"].ToString();
            this.�����ǩ��.Text = list.Tables[0].Rows[0]["�����ǩ��"].ToString();
            this.��ܽ���.Text = list.Tables[0].Rows[0]["��ܽ���"].ToString();
            this.���������.Text = list.Tables[0].Rows[0]["���������"].ToString();
            this.��������ǩ��.Text = list.Tables[0].Rows[0]["��������ǩ��"].ToString();
        }
    }

    private void ShowInfo(string pd_project_code, string pd_project_auto_no)
    {
        DataSet list = new ReportPublicBll().GetList("��Ŀ����='" + pd_project_code + "' and  auto_no='" + pd_project_auto_no + "' ", "view_tb_project_jgljb_xm3");
        if ((list.Tables.Count > 0) && (list.Tables[0].Rows.Count > 0))
        {
            this.lblxname.Text = list.Tables[0].Rows[0]["����"].ToString();
            this.lblxz.Text = list.Tables[0].Rows[0]["�ʽ�ʹ�õ�λ"].ToString();
            this.����ʽ�����.Text = list.Tables[0].Rows[0]["����ʽ�����"].ToString();
            this.�������.Text = list.Tables[0].Rows[0]["�������"].ToString();
            this.��Ŀ����ص㼰����.Text = list.Tables[0].Rows[0]["��Ŀ����ص㼰����"].ToString();
            this.ָ���ĺ�.Text = list.Tables[0].Rows[0]["ָ���ĺ�"].ToString();
            this.ָ����.Text = list.Tables[0].Rows[0]["ָ����"].ToString();
            this.��Ŀ���ܲ���.Text = list.Tables[0].Rows[0]["��Ŀ���ܲ���"].ToString();
            this.��Ŀʵʩ��λ.Text = list.Tables[0].Rows[0]["��Ŀʵʩ��λ"].ToString();
            this.���������.Text = list.Tables[0].Rows[0]["���������"].ToString();
            this.��ʾ.Text = list.Tables[0].Rows[0]["��ʾ"].ToString();
            this.��ʾ����.Text = list.Tables[0].Rows[0]["��ʾ����"].ToString();
            this.�Ƿ�ʾ.Text = list.Tables[0].Rows[0]["�Ƿ�ʾ"].ToString();
            this.��ܼ�¼.Text = list.Tables[0].Rows[0]["��ܼ�¼"].ToString();
            this.�����ǩ��.Text = list.Tables[0].Rows[0]["�����ǩ��"].ToString();
            this.��ܽ���.Text = list.Tables[0].Rows[0]["��ܽ���"].ToString();
            this.���������.Text = list.Tables[0].Rows[0]["���������"].ToString();
            this.��������ǩ��.Text = list.Tables[0].Rows[0]["��������ǩ��"].ToString();
        }
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
