using ASP;
using SoMeTech.CommonDll;
using SoMeTech.DataAccess;
using QxRoom.QxExcel;
using SMZJ.BLL;
using SMZJ.Model;
using System;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using YYControls;

public class Report_PublicReport : Page, IRequiresSessionState
{
    protected SmartGridView gvResult;
    protected HtmlInputHidden ibtid;
    protected HtmlInputHidden ISSHOW;
    protected HtmlInputHidden reportParameter;
    protected HtmlInputHidden reportParameterSchema;
    protected tablepage_reprotButtonlTwo reprotButtonl1;
    protected HtmlInputHidden selectXMl;
    protected HtmlInputHidden SpanRow;
    protected HtmlGenericControl tbHead;
    protected HtmlGenericControl window1;

    private void Button(string p)
    {
        string str = p;
        if (str != null)
        {
            if (!(str == "ShowData"))
            {
                if (!(str == "DownExcel"))
                {
                    return;
                }
            }
            else
            {
                this.sShowData(base.Request["id"]);
                return;
            }
            DataSet source = this.sShowData(base.Request["id"]);
            if (source != null)
            {
                DataSet list = new HideColumn_Bll().GetList("reportParamPK=" + base.Request["id"]);
                for (int i = 0; i < source.Tables[0].Columns.Count; i++)
                {
                    if (((list != null) && (list.Tables.Count > 0)) && (list.Tables[0].Rows.Count > 0))
                    {
                        foreach (DataRow row in list.Tables[0].Rows)
                        {
                            if (row["ColumnName"].ToString().ToLower().Trim() == source.Tables[0].Columns[i].ColumnName.ToLower().Trim())
                            {
                                source.Tables[0].Columns.Remove(source.Tables[0].Columns[i].ColumnName);
                                i--;
                            }
                        }
                    }
                }
                base.Response.Clear();
                base.Response.ContentEncoding = Encoding.UTF8;
                base.Response.AppendHeader("Content-Disposition", "attachment;filename=" + base.Server.UrlEncode(this.tbHead.InnerText) + ".xls");
                base.Response.ContentType = "application/vnd.ms-excel";
                base.Response.BufferOutput = true;
                new DataSetToExcel().ExportToExcel(source, base.Response.OutputStream);
                base.Response.End();
            }
        }
    }

    private void ChuShiHua()
    {
    }

    private DataSet getDataSet(string _where, string t_orderby, OracleParameter[] spa_cs, string reportID)
    {
        OracleParameter[] parameterArray;
        DB_OPT db_opt = new DB_OPT();
        DataSet set = null;
        reportParam_Model model = new reportParam_Bll().GetModel(int.Parse(reportID));
        if (model == null)
        {
            return set;
        }
        whereList_Bll bll2 = new whereList_Bll();
        DataView defaultView = bll2.GetList("reportParamPK=" + reportID).Tables[0].DefaultView;
        defaultView.RowFilter = "IsProcParam=1";
        string tabelName = model.tabelName;
        switch (int.Parse(model.tbtype))
        {
            case 0:
            case 1:
                return db_opt.BackDataSet("select * from " + tabelName + " " + _where + t_orderby, null);

            case 2:
                {
                    int num = 3;
                    parameterArray = spa_cs;
                    if (defaultView.Count <= 0)
                    {
                        parameterArray = new OracleParameter[] { new OracleParameter("wherestr", OracleType.VarChar), new OracleParameter("orderby", OracleType.VarChar), new OracleParameter("p_cursor", OracleType.Cursor) };
                        parameterArray[0].Value = " " + _where + " ";
                        parameterArray[0].Direction = ParameterDirection.Input;
                        parameterArray[1].Value = " " + t_orderby + " ";
                        parameterArray[1].Direction = ParameterDirection.Input;
                        parameterArray[2].Direction = ParameterDirection.Output;
                        goto Label_0238;
                    }
                    if (spa_cs == null)
                    {
                        parameterArray = new OracleParameter[num + defaultView.Count];
                        for (int i = 0; i < defaultView.Count; i++)
                        {
                            parameterArray[i] = new OracleParameter(defaultView[i]["columnName"].ToString(), OracleType.VarChar);
                            parameterArray[i].Value = "";
                            parameterArray[i].Direction = ParameterDirection.Input;
                        }
                    }
                    break;
                }
            default:
                return db_opt.BackDataSet("select * from " + tabelName + " " + _where + t_orderby, null);
        }
        parameterArray[parameterArray.Length - 3] = new OracleParameter("wherestr", OracleType.VarChar);
        parameterArray[parameterArray.Length - 3].Value = " " + _where + " ";
        parameterArray[parameterArray.Length - 3].Direction = ParameterDirection.Input;
        parameterArray[parameterArray.Length - 2] = new OracleParameter("orderby", OracleType.VarChar);
        parameterArray[parameterArray.Length - 2].Value = " " + t_orderby + " ";
        parameterArray[parameterArray.Length - 2].Direction = ParameterDirection.Input;
        parameterArray[parameterArray.Length - 1] = new OracleParameter("p_cursor", OracleType.Cursor);
        parameterArray[parameterArray.Length - 1].Direction = ParameterDirection.Output;
    Label_0238:
        return db_opt.SqlSelectProcPar(tabelName, parameterArray);
    }

    private string GetHTML(string columnsName, string DataType, DataRow _Where_dr, DataSet ds)
    {
        string str2 = "";
        string str3 = "";
        if (ds != null)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["ColumnsName"].ToString().Trim() == columnsName.Trim())
                {
                    if (row["datatype"].ToString().Trim() != "System.DateTime")
                    {
                        str2 = row["value"].ToString().Trim();
                        break;
                    }
                    if (row["datetime"].ToString().Trim() == "start")
                    {
                        str2 = row["value"].ToString().Trim();
                    }
                    else
                    {
                        str3 = row["value"].ToString().Trim();
                    }
                    if ((str2 != "") && (str3 != ""))
                    {
                        break;
                    }
                }
            }
        }
        string str4 = "";
        if (((_Where_dr != null) && PublicDal.PageValidate.IsInt(_Where_dr["IsGetData"].ToString())) && (int.Parse(_Where_dr["IsGetData"].ToString()) == 1))
        {
            string s = _Where_dr["ShowWhere"].ToString().Trim();
            if (s.Length != 0)
            {
                int startIndex = 0;
                while ((startIndex = s.IndexOf("@", startIndex)) >= 0)
                {
                    startIndex++;
                    bool flag = false;
                    int num2 = s.LastIndexOf("like", startIndex);
                    int num3 = s.LastIndexOf("=", startIndex);
                    if ((num2 != -1) && (num2 > num3))
                    {
                        flag = true;
                    }
                    int index = s.IndexOf(" ", startIndex);
                    if (index == -1)
                    {
                        index = s.Length;
                    }
                    string family = s.Substring(startIndex, index - startIndex);
                    object systemParam = PublicDal.GetSystemParam(family);
                    s = s.Remove(startIndex - 1, family.Length + 1);
                    if (systemParam != null)
                    {
                        if (flag)
                        {
                            s = s.Insert(startIndex - 1, "\"%" + systemParam.ToString() + "%\"");
                        }
                        else
                        {
                            s = s.Insert(startIndex - 1, "\"" + systemParam.ToString() + "\"");
                        }
                    }
                    else
                    {
                        s = s.Insert(startIndex - 1, "\"\"");
                    }
                }
            }
            str4 = " onclick=\"findwindow('PublicReport','" + base.Server.UrlEncode(_Where_dr["ShowTableName"].ToString()) + "','" + base.Server.UrlEncode(_Where_dr["ShowColumn"].ToString()) + "','" + base.Server.UrlEncode(s) + "',this)\" readonly='readonly' ";
        }
        switch (DataType)
        {
            case "System.Decimal":
                return ("<td style='text-align:right; width:50%;'><a style='cursor:hand;' onclick='setOrderby(this)'>" + columnsName + "</a>：</td><td><input uid='selectInput' name='" + columnsName + "' value='" + str2 + "' datatype='" + DataType + "'/></td>");

            case "System.String":
                return ("<td style='text-align:right; width:50%;'><a style='cursor:hand;' onclick='setOrderby(this)'>" + columnsName + "</a>：</td><td><input uid='selectInput' name='" + columnsName + "' value='" + str2 + "' datatype='" + DataType + "' " + str4 + "/></td>");

            case "System.DateTime":
                return ("<td style='text-align:right; width:50%;'><a style='cursor:hand;' onclick='setOrderby(this)'>" + columnsName + "</a>：</td><td><input id='" + Guid.NewGuid().ToString() + "' uid='selectInput' name='" + columnsName + "'  value='" + str2 + "' datatype='" + DataType + "' datetime='start'  readonly='readonly'/> 至 <input  id='" + Guid.NewGuid().ToString() + "' uid='selectInput' name='" + columnsName + "'  value='" + str3 + "' datatype='" + DataType + "' datetime='end'  readonly='readonly'/></td>");

            case "User.QuJian":
                return ("<td style='text-align:right; width:50%;'><a style='cursor:hand;' onclick='setOrderby(this)'>" + columnsName + "</a>：</td><td><input id='" + Guid.NewGuid().ToString() + "' uid='selectInput' name='" + columnsName + "'  value='" + str2 + "' datatype='" + DataType + "' datetime='start'  readonly='readonly'/> 至 <input  id='" + Guid.NewGuid().ToString() + "' uid='selectInput' name='" + columnsName + "'  value='" + str3 + "' datatype='" + DataType + "' datetime='end'  readonly='readonly'/></td>");

            case "User.Date":
                return ("<td style='text-align:right; width:50%;'><a style='cursor:hand;' onclick='setOrderby(this)'>" + columnsName + "</a>：</td><td><input id='" + Guid.NewGuid().ToString() + "' uid='selectInput' name='" + columnsName + "'  value='" + str2 + "' datatype='" + DataType + "' readonly='readonly'/></td>");
        }
        return ("<td style='text-align:right; width:50%;'><a style='cursor:hand;' onclick='setOrderby(this)'>" + columnsName + "</a>：</td><td><input uid='selectInput' name='" + columnsName + "'  value='" + str2 + "' datatype='" + DataType + "'/></td>");
    }

    private DataSet getReportParameter(string reportID)
    {
        if (reportID == null)
        {
            return null;
        }
        DataSet set = new DataSet();
        reportParam_Bll bll = new reportParam_Bll();
        whereList_Bll bll2 = new whereList_Bll();
        DataSet list = bll.GetList("id=" + reportID);
        if (list.Tables.Count > 0)
        {
            list.Tables[0].TableName = "reportParam";
            DataTable table = list.Tables[0];
            list.Tables.Remove(table);
            set.Tables.Add(table);
        }
        list = bll2.GetList("reportParamPK=" + reportID);
        if (list.Tables.Count > 0)
        {
            list.Tables[0].TableName = "whereList";
            DataTable table2 = list.Tables[0];
            list.Tables.Remove(table2);
            set.Tables.Add(table2);
        }
        return set;
    }

    private void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            this.getReportParameter(base.Request["id"]);
            string columndata = new reportParam_Bll().GetModel(int.Parse(base.Request["id"])).columndata;
            string newHeaderNames = File.ReadAllText(base.Server.MapPath(columndata), Encoding.Default);
            if ((newHeaderNames != null) && (newHeaderNames.Trim().Length != 0))
            {
                AndyGridViewTHeaderHepler hepler = new AndyGridViewTHeaderHepler();
                e.Row.BackColor = Color.Beige;
                hepler.SplitTableHeaderHTML(e.Row, newHeaderNames);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session["User"] == null)
        {
            Const.GoLoginPath_OpenWindow(this.Page);
        }
        else
        {
            DataSet set = this.getReportParameter(base.Request["id"]);
            if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
            {
                if (set.Tables["reportParam"].Rows[0]["columndata"].ToString().Trim().Length > 0)
                {
                    this.gvResult.RowDataBound += new GridViewRowEventHandler(this.gvResult_RowDataBound);
                }
                if (!base.IsPostBack)
                {
                    if (this.reportParameter.Value.Trim().Length == 0)
                    {
                        this.reportParameter.Value = base.Server.UrlEncode(set.GetXml());
                        this.reportParameterSchema.Value = base.Server.UrlEncode(set.GetXmlSchema());
                        set.GetXmlSchema();
                    }
                    this.ISSHOW.Value = set.Tables["reportParam"].Rows[0]["IsOpenShow"].ToString();
                    base.Title = this.tbHead.InnerText = set.Tables["reportParam"].Rows[0]["ShowReportName"].ToString();
                    this.SpanRow.Value = set.Tables["reportParam"].Rows[0]["ReportSpanRow"].ToString();
                    this.reprotButtonl1.DaochuBt.Attributes.Add("onclick", "SubmitDownExcel()");
                    if (set.Tables["reportParam"].Rows[0]["IsOpenShow"].ToString() == "1")
                    {
                        this.showData("", "", false, null, null, base.Request["id"]);
                    }
                    else
                    {
                        this.showSelect("", "", base.Request["id"]);
                    }
                }
                else
                {
                    this.Button(this.ibtid.Value);
                    this.ibtid.Value = "";
                }
                this.setGridStyle();
            }
        }
    }

    public static void ReportSpanRow(GridView xhTable, int SpanRow)
    {
        if (SpanRow >= 0)
        {
            string text = null;
            int num = 0;
            if (xhTable.Rows.Count > 0)
            {
                text = xhTable.Rows[0].Cells[SpanRow].Text;
            }
            xhTable.Rows[0].Cells[SpanRow].Style.Add(HtmlTextWriterStyle.BackgroundColor, "#EEE");
            for (int i = 1; i < xhTable.Rows.Count; i++)
            {
                xhTable.Rows[i].Cells[SpanRow].Style.Add(HtmlTextWriterStyle.BackgroundColor, "#EEE");
                if ((text != xhTable.Rows[i].Cells[SpanRow].Text) || (i == (xhTable.Rows.Count - 1)))
                {
                    if (i != (num + 1))
                    {
                        if (text != xhTable.Rows[i].Cells[SpanRow].Text)
                        {
                            xhTable.Rows[num].Cells[SpanRow].RowSpan = i - num;
                        }
                        else
                        {
                            xhTable.Rows[i].Cells.Remove(xhTable.Rows[i].Cells[SpanRow]);
                            xhTable.Rows[num].Cells[SpanRow].RowSpan = (i - num) + 1;
                        }
                    }
                    int num1 = xhTable.Rows.Count - 1;
                    num = i;
                    text = xhTable.Rows[i].Cells[SpanRow].Text;
                }
                else
                {
                    xhTable.Rows[i].Cells.Remove(xhTable.Rows[i].Cells[SpanRow]);
                }
            }
        }
    }

    private void setGridStyle()
    {
        for (int i = 0; i < this.gvResult.Rows.Count; i++)
        {
            for (int j = 0; j < this.gvResult.Columns.Count; j++)
            {
                if (this.gvResult.Rows[i].Cells[j].Text.Length > 20)
                {
                    this.gvResult.Rows[i].Cells[j].Style.Add(HtmlTextWriterStyle.Width, "80px");
                }
            }
        }
    }

    private void setGViewColumns(DataSet ds, string ReportID)
    {
        if (this.gvResult.Columns.Count == 0)
        {
            DataSet list = new HideColumn_Bll().GetList("reportParamPK=" + ReportID);
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                if (((list != null) && (list.Tables.Count > 0)) && (list.Tables[0].Rows.Count > 0))
                {
                    bool flag = false;
                    foreach (DataRow row in list.Tables[0].Rows)
                    {
                        if (row["ColumnName"].ToString().ToLower().Trim() == ds.Tables[0].Columns[i].ColumnName.ToLower().Trim())
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        continue;
                    }
                }
                BoundField field = new BoundField
                {
                    DataField = ds.Tables[0].Columns[i].ColumnName,
                    HeaderText = ds.Tables[0].Columns[i].ColumnName,
                    SortExpression = ds.Tables[0].Columns[i].ColumnName
                };
                field.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                this.gvResult.Columns.Add(field);
            }
        }
        if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count == 0))
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        }
    }

    private void setSelectWindow(DataSet ds, DataSet ds_where, string orderby, bool IsDesc, string reportID)
    {
        string str = "";
        DataSet list = new HideColumn_Bll().GetList("reportParamPK=" + reportID);
        DataSet set2 = new reportParam_Bll().GetList("id=" + reportID);
        if (((set2.Tables.Count > 0) && (set2.Tables[0].Rows.Count > 0)) && (set2.Tables[0].Rows[0]["IsColumnWhere"].ToString().Trim() == "1"))
        {
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                bool flag = false;
                foreach (DataRow row in list.Tables[0].Rows)
                {
                    if (row["ColumnName"].ToString().ToLower().Equals(ds.Tables[0].Columns[i].ColumnName.ToLower()))
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    string str2 = this.GetHTML(ds.Tables[0].Columns[i].ColumnName, ds.Tables[0].Columns[i].DataType.FullName, null, ds_where);
                    str = str + "<tr>" + str2 + "</tr>";
                }
            }
        }
        DataSet set3 = new whereList_Bll().GetList("reportParamPK=" + reportID);
        if (set3.Tables.Count > 0)
        {
            foreach (DataRow row2 in set3.Tables[0].Rows)
            {
                if (PublicDal.PageValidate.IsInt(row2["IsShow"]) && (int.Parse(row2["IsShow"].ToString()) == 1))
                {
                    string str3 = this.GetHTML(row2["columnName"].ToString(), row2["columnType"].ToString(), row2, ds_where);
                    str = str + "<tr>" + str3 + "</tr>";
                }
            }
        }
        str = str + "<tr><td style='text-align:right; width:150px;'>排序字段(单击以上列名)：</td><td><a uid='selectInput' id='nullType_px' datatype='nullType.px'>" + orderby.Replace("\"", "").Replace("desc", "") + "</a></td></tr><tr><td colspan=\"2\" align=\"right\"> 是否倒序：<input type=\"checkbox\" " + (IsDesc ? "checked='checked'" : "") + " id=\"c_desc\" uid=\"c_desc\" /></td></tr><tr><td align=\"right\"><input type=\"button\" name=\"bt2\" value=\"清空内容\" onclick='QingKong()'/></td><td><input type='button' onclick=\" document.getElementById('nullType_px').innerHTML=''\" value='清空排序' /></td></tr>";
        str = "<table align=\"center\">" + str + "</table><table id='' width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td colspan=\"2\" align=\"center\">&nbsp;</td></tr><tr><td align=\"right\"><input type=\"submit\" name=\"Submit\" value=\"确定\" onclick='SubmitFrom()' /></td><td align=\"center\" style='width:50px'></td><td align=\"left\"><input type=\"button\" name=\"bt3\"  onclick='extWindow.hide()' value=\"取消\" /></td></tr></table>";
        this.window1.InnerHtml = str;
    }

    private DataSet showData(string _where, string orderby, bool IsDesc, DataSet ds_where, OracleParameter[] spa, string reportID)
    {
        DataSet set = this.getDataSet(" where 1=0 ", "", spa, reportID);
        string str = PublicDal.GetSystemParam("Company.pk_corp").ToString().Trim();
        string str2 = "";
        if (_where.IndexOf("where") == -1)
        {
            _where = " where 1=1 ";
        }
        if (set.Tables[0].Columns.IndexOf("PowerDepart") >= 0)
        {
            string[] strArray = PublicDal.GetSystemParam("CompanyPower").ToString().Split(new char[] { '|' });
            for (int i = 0; i < strArray.Length; i++)
            {
                str2 = str2 + strArray[i].Trim() + "','";
            }
            if (str2 != "")
            {
                str2 = str2.Remove(str2.Length - 3);
                str2 = "'" + str2 + "'";
            }
        }
        if (set.Tables[0].Columns.IndexOf("LoginCompany") >= 0)
        {
            _where = _where + " and trim(LoginCompany) like '" + str + "%'";
        }
        if (set.Tables[0].Columns.IndexOf("PowerDepart") >= 0)
        {
            _where = _where + " and trim(PowerDepart) in (" + str2 + ")";
        }
        string str3 = orderby;
        if ((str3 != null) && (str3.Trim() != ""))
        {
            str3 = " order by" + str3;
        }
        else
        {
            str3 = "";
        }

        DataSet ds = this.getDataSet(_where, str3, spa, reportID);
        if (int.Parse(reportID) >= 25)
        {
            string xz = this.Session["pk_corp"].ToString();
            int nd = DateTime.Now.Year;
            DataTable dt = ds.Tables[0];
            DataTable dt1 = new DataTable();
            dt1 = dt.Clone();
            foreach (DataRow dr in dt.Select("乡镇代码='" + xz + "' and 年度=" + nd + ""))
            {
                dt1.ImportRow(dr);
            }
            ds.Clear();
            ds.Tables.Clear();
            ds.Tables.Add(dt1);
        }
        this.setGViewColumns(ds, reportID);
        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        foreach (DataColumn column in ds.Tables[0].Columns)
        {
            if (((column.DataType == typeof(int)) || (column.DataType == typeof(float))) || ((column.DataType == typeof(double)) || (column.DataType == typeof(decimal))))
            {
                ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][column.ColumnName] = ds.Tables[0].Compute("Sum([" + column.ColumnName + "])", "");
            }
        }
        
        this.gvResult.DataSource = ds;
        this.gvResult.DataBind();
        this.gvResult.Rows[this.gvResult.Rows.Count - 1].Cells[0].Text = "合计：";
        this.gvResult.Rows[this.gvResult.Rows.Count - 1].CssClass = "HeaderRow";
        if ((this.SpanRow.Value.Trim().Length != 0) && PublicDal.PageValidate.IsInt(this.SpanRow.Value))
        {
            ReportSpanRow(this.gvResult, int.Parse(this.SpanRow.Value));
        }
        this.setSelectWindow(ds, ds_where, orderby, IsDesc, reportID);
        return ds;
    }

    private void showSelect(string _where, string t_orderby, string reportID)
    {
        new reportParam_Bll();
        DataSet ds = this.getDataSet(" where 1=0 ", t_orderby, null, reportID);
        this.setGViewColumns(ds, reportID);
        ds.Tables[0].Rows.Clear();
        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        this.gvResult.DataSource = ds;
        this.gvResult.DataBind();
        this.setSelectWindow(ds, null, "", false, reportID);
    }

    private DataSet sShowData(string reportID)
    {
        DataSet set = null;
        DataSet set2 = null;
        if (this.reportParameter.Value != "")
        {
            set2 = new DataSet();
            XmlTextReader reader = new XmlTextReader(new StringReader(base.Server.UrlDecode(this.reportParameter.Value)));
            XmlTextReader reader2 = new XmlTextReader(new StringReader(base.Server.UrlDecode(this.reportParameterSchema.Value)));
            set2.ReadXmlSchema(reader2);
            set2.ReadXml(reader);
        }
        string s = this.selectXMl.Value.Trim();
        if ((s != null) && (s.Trim() != ""))
        {
            set = new DataSet();
            XmlTextReader reader3 = new XmlTextReader(new StringReader(s));
            set.ReadXml(reader3);
        }
        string str2 = " where 1=1 ";
        string orderby = "";
        bool isDesc = false;
        DataView defaultView = set2.Tables["whereList"].DefaultView;
        defaultView.RowFilter = "IsProcParam=1";
        OracleParameter[] spa = new OracleParameter[3 + defaultView.Count];
        for (int i = 0; i < set.Tables[0].Rows.Count; i++)
        {
            string str9;
            string str13;
            DataRow row = set.Tables[0].Rows[i];
            string str4 = row["ColumnsName"].ToString().Trim();
            bool flag2 = false;
            if ((row["value"].ToString().Trim() == "") || (str4.Trim().Length == 0))
            {
                flag2 = true;
            }
            if (defaultView.Count > 0)
            {
                for (int m = 0; m < defaultView.Count; m++)
                {
                    if (str4 == defaultView[m]["columnName"].ToString().Trim())
                    {
                        flag2 = true;
                        spa[m] = new OracleParameter(defaultView[m]["columnName"].ToString(), OracleType.VarChar);
                        spa[m].Value = row["value"].ToString().Trim();
                        spa[m].Direction = ParameterDirection.Input;
                    }
                }
            }
            if (!flag2 || (row["datatype"].ToString().Trim() == "nullType.px"))
            {
                string str7 = row["datatype"].ToString().Trim();
                if (str7 == null)
                {
                    goto Label_05F6;
                }
                if (!(str7 == "System.Decimal"))
                {
                    if (str7 == "System.String")
                    {
                        goto Label_0307;
                    }
                    if (str7 == "System.DateTime")
                    {
                        goto Label_0380;
                    }
                    if (str7 == "nullType.px")
                    {
                        goto Label_04DF;
                    }
                    goto Label_05F6;
                }
                string str8 = str2;
                str2 = str8 + " and \"" + str4.Replace("'", "") + "\" = " + row["value"].ToString().Trim().Replace("'", "");
            }
            continue;
        Label_0307:
            str9 = str2;
            str2 = str9 + " and \"" + str4.Replace("'", "") + "\" like '%" + row["value"].ToString().Trim().Replace("'", "") + "%'";
            continue;
        Label_0380:
            if (row["datetime"].ToString().Trim() == "start")
            {
                if (PublicDal.PageValidate.IsDateTime(row["value"].ToString().Trim()))
                {
                    string str10 = str2;
                    str2 = str10 + " and \"" + str4.Replace("'", "") + "\" >=to_date('" + DateTime.Parse(row["value"].ToString().Trim()).ToString("yyyy-MM-dd") + "','yyyy-MM-dd')";
                }
            }
            else if (PublicDal.PageValidate.IsDateTime(row["value"].ToString().Trim()))
            {
                string str11 = str2;
                str2 = str11 + " and \"" + str4.Replace("'", "") + "\" <=to_date('" + DateTime.Parse(row["value"].ToString().Trim()).ToString("yyyy-MM-dd") + "','yyyy-MM-dd')";
            }
            continue;
        Label_04DF:
            orderby = "";
            string str5 = row["datetime"].ToString().Trim();
            if (str5 != "desc")
            {
                str5 = "";
            }
            else
            {
                isDesc = true;
            }
            string[] strArray = row["value"].ToString().Trim().Replace("'", "").Replace("，", ",").Split(new char[] { ',' });
            for (int k = 0; k < strArray.Length; k++)
            {
                if (strArray[k].Trim().Length != 0)
                {
                    string str12 = orderby;
                    orderby = str12 + " \"" + strArray[k].Trim() + "\" " + str5 + ",";
                }
            }
            if (orderby.Trim().Length != 0)
            {
                orderby = orderby.Remove(orderby.Length - 1);
            }
            continue;
        Label_05F6:
            str13 = str2;
            str2 = str13 + " and \"" + str4.Replace("'", "") + "\" like '%" + row["value"].ToString().Trim().Replace("'", "") + "%'";
        }
        defaultView.RowFilter = "IsProcParam=2";
        for (int j = 0; j < defaultView.Count; j++)
        {
            string str6 = defaultView[j]["columnName"].ToString().Trim();
            if (str6.Length != 0)
            {
                string[] strArray2 = str6.Split(new char[] { '=' });
                if (strArray2.Length == 2)
                {
                    object systemParam = PublicDal.GetSystemParam(strArray2[1]);
                    if (systemParam != null)
                    {
                        if ((defaultView[j]["IsLike"].ToString().Trim().Length != 0) && (int.Parse(defaultView[j]["IsLike"].ToString().Trim()) == 0))
                        {
                            string str14 = str2;
                            str2 = str14 + " and \"" + strArray2[0] + "\" = '" + systemParam.ToString().Trim() + "'";
                        }
                        else
                        {
                            string str15 = str2;
                            str2 = str15 + " and \"" + strArray2[0] + "\" like '%" + systemParam.ToString().Trim() + "%'";
                        }
                    }
                }
            }
        }
        return this.showData(str2, orderby, isDesc, set, spa, reportID);
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public MainReport Master
    {
        get
        {
            return (MainReport)base.Master;
        }
    }

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }

    private enum tbType
    {
        表,
        视图,
        存储过程
    }
}
