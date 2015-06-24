using ASP;
using SoMeTech.Data;
using System;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Backup : Page, IRequiresSessionState
{
    protected Button btnBackup;
    protected Button btnRestore;
    protected DropDownList ddlBktype1;
    protected DropDownList ddlBktype2;
    protected HtmlForm form1;
    protected FileUpload fupbk;
    protected FileUpload fupRe;
    protected TextBox tbxDbname;
    protected TextBox TextBox1;
    protected TextBox TextBox2;
    protected TextBox txtPwd;

    protected void btnBackup_Click(object sender, EventArgs e)
    {
        this.btnBkOracle(sender, e);
    }

    protected void btnBkOracle(object sender, EventArgs e)
    {
        string str = @"d:\zjjgDB" + DateTime.Now.ToString() + ".dmp";
        string text1 = "zjjgDB" + DateTime.Now.ToString() + ".log";
        string str2 = "orcl";
        string str3 = "system";
        string str4 = "123456";
        string str5 = "exp " + str3 + "/" + str4 + "@" + str2 + " file=" + str;
        Process process = new Process
        {
            StartInfo = { FileName = "cmd.exe", UseShellExecute = false, RedirectStandardInput = true, RedirectStandardOutput = true, RedirectStandardError = true, CreateNoWindow = true }
        };
        try
        {
            process.Start();
            process.StandardInput.WriteLine(str5);
            process.StandardInput.WriteLine("exit");
            base.Response.Write("<script>alert(' 提示：数据库备份成功！');</script>");
            process.Close();
        }
        catch (Exception exception)
        {
            base.Response.Write("<script>alert('提示：数据库备份失败！" + exception.Message + "');</script>");
        }
    }

    protected void btnRestore_Click(object sender, EventArgs e)
    {
        OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":dbname", "zjjg_20130314_db"), new OracleParameter(":bkpath", this.fupRe.FileName.ToString()) };
        DbHelperOra.RunProcedure("p_backupdb", parameters);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
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
