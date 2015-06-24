using ASP;
using SoMeTech.DataAccess;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Shared_CheckData : Page, IRequiresSessionState
{
    private DB_OPT db;
    private DataSet ds;
    protected HtmlForm form1;
    protected LinkButton lbUp;
    protected TableRow Tablerow1;
    protected Table tbList;
    private UsualBookTable ubt = new UsualBookTable();

    private string GetCellText_AN(string strMethod, int i, int t, bool isgrade)
    {
        string str = "<a href=\"javascript:" + strMethod + "('" + this.ds.Tables[0].Rows[i][0].ToString().Trim() + "~" + this.ds.Tables[0].Rows[i][1].ToString().Trim();
        if (isgrade && (this.ds.Tables[0].Columns.Count > 2))
        {
            str = str + "~" + this.ds.Tables[0].Rows[i][2].ToString().Trim();
        }
        return (str + "')\" target=help>选 择</a></td>");
    }

    private string GetCellText_WB(string strMethod, int i, int t, bool isgrade)
    {
        string str = "<a href=\"javascript:" + strMethod + "('" + this.ds.Tables[0].Rows[i][0].ToString().Trim() + "~" + this.ds.Tables[0].Rows[i][1].ToString().Trim();
        if (isgrade && (this.ds.Tables[0].Columns.Count > 2))
        {
            str = str + "~" + this.ds.Tables[0].Rows[i][2].ToString().Trim();
        }
        return (str + "')\" target=help>" + this.ds.Tables[0].Rows[i][t].ToString().Trim() + "</a></td>");
    }

    private string GetCellText_XH(string strMethod, int i, int t, bool isgrade)
    {
        string str = "<a id=\"link_" + Convert.ToString((int)(i + 1)) + "\" href=\"javascript:" + strMethod + "('" + this.ds.Tables[0].Rows[i][0].ToString().Trim() + "~" + this.ds.Tables[0].Rows[i][1].ToString().Trim();
        if (isgrade && (this.ds.Tables[0].Columns.Count > 2))
        {
            str = str + "~" + this.ds.Tables[0].Rows[i][2].ToString().Trim();
        }
        return (str + "')\" target=help>" + Convert.ToString((int)(i + 1)) + "</a></td>");
    }

    public DataSet GetDataSet(string sql)
    {
        DataSet ds;
        DataBaseType dBT = DB_OPT.DBT;
        try
        {
            if (base.Request["MSSQL"] != null)
            {
                this.db = new DB_OPT("2", base.Request["MSSQL"], DataBaseType.SqlServer);
                DB_OPT.DBT = DataBaseType.SqlServer;
            }
            else
            {
                this.db = new DB_OPT();
            }
            this.ds = new DataSet();
            this.ds = this.db.BackDataSet(sql, null);
            ds = this.ds;
        }
        catch
        {
            ds = null;
        }
        finally
        {
            DB_OPT.DBT = dBT;
        }
        return ds;
    }

    private void GetNextStep(string mess)
    {
        this.ubt.TJ = mess;
        this.GetDataSet(this.ubt.selectNextStep());
        this.GetTable();
        this.ubt.TJ = mess.Substring(0, mess.Length - 1) + (int.Parse(mess.Substring(mess.Length - 1, 1)) + 1);
        this.ubt.strStep = this.ubt.strStep + mess + "^";
        this.Session["UsualBookTable"] = this.ubt;
    }

    public void GetReturnMC(string strID, string strMC)
    {
        this.ubt = (UsualBookTable)this.Session["UsualBookTable"];
        this.GetDataSet(this.ubt.selectMCas(strID, strMC));
        this.GetTable();
    }

    private void GetTable()
    {
        this.tbList.Rows.Clear();
        if (this.ds != null)
        {
            if (this.ds.Tables.Count > 0)
            {
                if (this.ds.Tables[0].Rows.Count > 0)
                {
                    int num = 3;
                    if ((this.ubt.ShowSelect > 0) && (int.Parse(this.ds.Tables[0].Rows[0][2].ToString()) < this.ubt.ShowSelect))
                    {
                        num = 2;
                    }
                    if (!this.ubt.IsGrade)
                    {
                        num = 2;
                    }
                    TableRow row = new TableRow
                    {
                        BackColor = Color.AliceBlue
                    };
                    for (int i = 0; i < num; i++)
                    {
                        TableCell cell = new TableCell();
                        switch (i)
                        {
                            case 0:
                                cell.Width = 40;
                                cell.Text = "序号";
                                goto Label_0186;

                            case 1:
                                if (num != 2)
                                {
                                    break;
                                }
                                cell.Width = 260;
                                goto Label_0128;

                            case 2:
                                cell.Width = 40;
                                cell.Text = "选 择";
                                goto Label_0186;

                            default:
                                goto Label_0186;
                        }
                        cell.Width = 220;
                    Label_0128: ;
                        cell.Text = this.ubt.Columns.Split(new char[] { ',' })[i].Split(new char[] { ' ' })[2].Trim();
                    Label_0186:
                        row.Cells.Add(cell);
                    }
                    this.tbList.Rows.Add(row);
                    for (int j = 0; j < this.ds.Tables[0].Rows.Count; j++)
                    {
                        TableRow htr = new TableRow
                        {
                            ID = "tr_" + j
                        };
                        htr.Attributes.Add("onmouseover", "javascript:trmove(tr_" + j + ")");
                        htr.Attributes.Add("onmouseout", string.Concat(new object[] { "javascript:trout(tr_", j, ",", j, ")" }));
                        for (int k = 0; k < num; k++)
                        {
                            this.WriteTableBody(htr, j, k);
                        }
                        this.tbList.Rows.Add(htr);
                    }
                    TableRow row3 = new TableRow
                    {
                        ID = "tr_wu"
                    };
                    TableCell cell2 = new TableCell
                    {
                        Text = "</td><td></td><td><a href=\"javascript:openHelp(' ~ ~0')\" target=help>    无    </a></td>"
                    };
                    row3.Cells.Add(cell2);
                    this.tbList.Rows.Add(row3);
                }
                else
                {
                    base.Response.Write("没有任何数据！");
                }
            }
            else
            {
                base.Response.Write("没有任何数据！！");
            }
        }
        else
        {
            base.Response.Write("没有任何数据！！！");
        }
    }

    private bool IfTheLastStep(string dm)
    {
        return (dm == "1");
    }

    protected void lbUp_Click(object sender, EventArgs e)
    {
        if (this.ubt != null)
        {
            this.ubt = (UsualBookTable)this.Session["UsualBookTable"];
            string strStep = this.ubt.strStep;
            this.ubt.TJ = this.ubt.TJ.Substring(0, this.ubt.TJ.Length - 1) + (int.Parse(this.ubt.TJ.Split(new char[] { '~' })[2]) - 2);
            string[] strArray = strStep.Split(new char[] { '^' });
            if (strArray.Length < 3)
            {
                if (strArray.Length == 2)
                {
                    this.ubt.Grade--;
                    this.GetDataSet(this.ubt.Select());
                    this.lbUp.Visible = false;
                    this.GetTable();
                    this.ubt.strStep = "";
                }
            }
            else
            {
                this.ubt.TJ = strArray[strArray.Length - 3];
                this.ubt.TJ = this.ubt.TJ.Substring(0, this.ubt.TJ.Length - 1) + (int.Parse(strArray[strArray.Length - 2].Split(new char[] { '~' })[2]) - 1);
                this.ubt.Grade = int.Parse(this.ubt.TJ.Split(new char[] { '~' })[2]);
                this.GetDataSet(this.ubt.selectNextStep());
                this.GetTable();
                this.ubt.TJ = strArray[strArray.Length - 2].Substring(0, strArray[strArray.Length - 2].Length - 1) + (int.Parse(strArray[strArray.Length - 2].Substring(strArray[strArray.Length - 2].Length - 1, 1)) + 1);
                this.ubt.strStep = "";
                for (int i = 0; i < (strArray.Length - 2); i++)
                {
                    this.ubt.strStep = this.ubt.strStep + strArray[i] + "^";
                }
                this.Session["UsualBookTable"] = this.ubt;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.ubt = (UsualBookTable)this.Session["UsualBookTable"];
        if (this.ubt != null)
        {
            if (!this.Page.IsPostBack)
            {
                if ((base.Request.QueryString["txtID"] != null) && (base.Request.QueryString["txtMC"] != null))
                {
                    this.GetReturnMC(base.Request.QueryString["txtID"].Trim(), base.Request.QueryString["txtMC"].Trim());
                }
                else if (base.Request.QueryString["txtID"] != null)
                {
                    this.GetReturnMC(base.Request.QueryString["txtID"].Trim(), "");
                }
                else if (base.Request.QueryString["txtMC"] != null)
                {
                    this.GetReturnMC("", base.Request.QueryString["txtMC"].Trim());
                }
                else
                {
                    this.GetDataSet(this.ubt.Select());
                    this.GetTable();
                }
                this.lbUp.Visible = false;
            }
            if (base.Request["type"] != null)
            {
                if (base.Request["type"] != "")
                {
                    this.GetNextStep(base.Request["type"].ToString());
                }
                this.lbUp.Visible = true;
            }
        }
        else
        {
            this.GetTable();
        }
    }

    private void WriteTableBody(TableRow htr, int i, int t)
    {
        TableCell cell = new TableCell();
        if (this.ubt.IsGrade)
        {
            if ((this.ds.Tables[0].Columns.Count > 4) && !this.IfTheLastStep(this.ds.Tables[0].Rows[i][4].ToString().Trim()))
            {
                if (t == 0)
                {
                    cell.Text = this.GetCellText_XH("openHelp", i, t, true);
                }
                if (t == 1)
                {
                    cell.Text = this.GetCellText_WB("openHelp", i, t, true);
                }
                if (t == 2)
                {
                    cell.Text = this.GetCellText_AN("openHelp", i, t, true);
                }
            }
            else
            {
                if (t == 0)
                {
                    cell.Text = this.GetCellText_XH("openMe", i, t, true);
                }
                if (t == 1)
                {
                    cell.Text = this.GetCellText_WB("openMe", i, t, true);
                }
                if (t == 2)
                {
                    cell.Text = this.GetCellText_AN("openHelp", i, t, true);
                }
            }
        }
        else
        {
            if (t == 0)
            {
                cell.Text = this.GetCellText_XH("openHelp", i, t, false);
            }
            if (t == 1)
            {
                cell.Text = this.GetCellText_WB("openHelp", i, t, false);
            }
            if (t == 2)
            {
                cell.Text = this.GetCellText_AN("openHelp", i, t, false);
            }
        }
        htr.Cells.Add(cell);
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
