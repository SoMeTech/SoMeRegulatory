using ASP;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SMZJ.BLL;

public class Report_jsxGTable : Page, IRequiresSessionState
{
    protected HtmlForm form1;
    protected HtmlHead Head1;
    protected Label lblxname;
    protected Label lblxz;
    protected tablepage_reprotButtonl reprotButtonl1;
    protected Label �����Գ��ʽ�;
    protected Label ���������;
    protected Label ���Ѳ�����;
    protected Label ��ʾ���;
    protected Label �ƻ���������;
    protected Label �ƻ��깤����;
    protected Label �������;
    protected Label ����ʽ�����;
    protected Label ���˵�λ����;
    protected Label ��������;
    protected Label ������;
    protected Label ������Դ�ʽ�;
    protected Label �ϼ������ʽ�;
    protected Label ��Ŀ������;
    protected Label ��Ŀ�ſ�;
    protected Label ��Ŀ����ص㼰����;
    protected Label ��Ŀ������;
    protected Label ��ĿͶ�ʸſ�;
    protected Label ��Ŀ�깤����;
    protected Label ��ĿԤ����;
    protected Label ��Ŀ������;
    protected Label ����Ҫ��;
    protected Label ָ����;
    protected Label ָ���ĺ�;
    protected Label �ʽ𲦸����;
    protected Label �ʽ����;
    protected Label �ʽ�ʹ�õ�λ;
    protected Label �ʽ���;;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsCallback)
        {
            this.reprotButtonl1.DaochuBt.Attributes.Add("onclick", "tbSaveExcel('��Ŀ�����ʽ��ܼ�¼��','table1',window)");
        }
        this.ShowInfo(base.Request["code"], base.Request["pd_found_xz"]);
    }

    private void ShowInfo(string code, string pd_found_xz)
    {
        DataSet list = new ReportPublicBll().GetList("��Ŀ����='" + base.Request["UpdatePK"].ToString() + "'", "view_tb_project_jgljb_xm");
        if ((list.Tables.Count > 0) && (list.Tables[0].Rows.Count > 0))
        {
            this.lblxname.Text = list.Tables[0].Rows[0]["����"].ToString();
            this.lblxz.Text = list.Tables[0].Rows[0]["�ʽ�ʹ�õ�λ"].ToString();
            this.���˵�λ����.Text = list.Tables[0].Rows[0]["���˵�λ����"].ToString();
            this.��������.Text = list.Tables[0].Rows[0]["��������"].ToString();
            this.������.Text = list.Tables[0].Rows[0]["������"].ToString();
            this.ָ���ĺ�.Text = list.Tables[0].Rows[0]["ָ���ĺ�"].ToString();
            this.����ʽ�����.Text = list.Tables[0].Rows[0]["����ʽ�����"].ToString();
            this.�ʽ���;.Text = list.Tables[0].Rows[0]["�ʽ���;"].ToString();
            this.��Ŀ����ص㼰����.Text = list.Tables[0].Rows[0]["��Ŀ����ص㼰����"].ToString();
            this.�������.Text = list.Tables[0].Rows[0]["�������"].ToString();
            this.�ʽ����.Text = list.Tables[0].Rows[0]["�ʽ����"].ToString();
            this.ָ����.Text = list.Tables[0].Rows[0]["ָ����"].ToString();
            this.����Ҫ��.Text = list.Tables[0].Rows[0]["����Ҫ��"].ToString();
            this.�ʽ�ʹ�õ�λ.Text = list.Tables[0].Rows[0]["�ʽ�ʹ�õ�λ"].ToString();
            this.�ƻ���������.Text = list.Tables[0].Rows[0]["�ƻ���������"].ToString();
            this.�ƻ��깤����.Text = list.Tables[0].Rows[0]["�ƻ��깤����"].ToString();
            this.��Ŀ������.Text = list.Tables[0].Rows[0]["��Ŀ������"].ToString();
            this.��Ŀ������.Text = list.Tables[0].Rows[0]["��Ŀ������"].ToString();
            this.��ĿԤ����.Text = list.Tables[0].Rows[0]["��ĿԤ����"].ToString();
            this.��Ŀ������.Text = list.Tables[0].Rows[0]["��Ŀ������"].ToString();
            this.��ĿͶ�ʸſ�.Text = list.Tables[0].Rows[0]["��ĿͶ�ʸſ�"].ToString();
            this.�ϼ������ʽ�.Text = list.Tables[0].Rows[0]["�ϼ������ʽ�"].ToString();
            this.�����Գ��ʽ�.Text = list.Tables[0].Rows[0]["�����Գ��ʽ�"].ToString();
            this.������Դ�ʽ�.Text = list.Tables[0].Rows[0]["������Դ�ʽ�"].ToString();
            this.�ʽ𲦸����.Text = list.Tables[0].Rows[0]["�ʽ𲦸����"].ToString();
            this.��Ŀ�깤����.Text = list.Tables[0].Rows[0]["��Ŀ�깤����"].ToString();
            this.��ʾ���.Text = list.Tables[0].Rows[0]["��ʾ���"].ToString();
            this.���Ѳ�����.Text = list.Tables[0].Rows[0]["���Ѳ�����"].ToString();
            this.��Ŀ�ſ�.Text = list.Tables[0].Rows[0]["��Ŀ�ſ�"].ToString();
            this.���������.Text = list.Tables[0].Rows[0]["���������"].ToString();
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
}
