<%@ WebHandler Language="C#" Class="PublicExcel" %>

using System;
using System.Web;

public partial class PublicExcel : IHttpHandler, System.Web.SessionState.IReadOnlySessionState {
    public void ProcessRequest (HttpContext context) {
        HttpRequest Request = context.Request;
        HttpResponse Response = context.Response;
        HttpServerUtility Server = context.Server;


        Response.ContentType = "text/plain";
        string type = context.Request["type"];
        string id = context.Request["id"];
        string returnStr="";
        try
        {
            switch (type)
            {
                case "getXmlData":
                    if (SoMeTech.CommonDll.PublicDal.PageValidate.IsDecimal(id))
                    {
                        SMZJ.BLL.PD_PROJECT_PUBLICEXCEL_Bll bll = new SMZJ.BLL.PD_PROJECT_PUBLICEXCEL_Bll();
                        SMZJ.Model.PD_PROJECT_PUBLICEXCEL_Model model = bll.GetModel(decimal.Parse(id));
                        if (model == null)
                            break;

                        SMZJ.BLL.PD_PROJECT_PUBLICEXCEL_DETAIL_Bll detailBll = new SMZJ.BLL.PD_PROJECT_PUBLICEXCEL_DETAIL_Bll();
                        System.Data.DataSet detailDS = detailBll.GetList(" pid='" + id + "' and isdefaulttype='0' ");
                        //string xmlData = model.TABLENAME;
                        //if (xmlData.Trim().Length == 0)
                        //    break;

                        //System.Data.DataSet ds = new System.Data.DataSet();
                        //System.Xml.XmlTextReader xmlReader = new System.Xml.XmlTextReader(new System.IO.StringReader(xmlData));
                        //ds.ReadXml(xmlReader);

                        if (detailDS.Tables.Count > 0 && detailDS.Tables[0].Rows.Count > 0)
                        {
                            System.Collections.ArrayList lsColumn = new System.Collections.ArrayList();
                            foreach (System.Data.DataRow dr in detailDS.Tables[0].Rows)
                            {
                                if (lsColumn.IndexOf(dr["TABLE_ENAME"]) == -1)
                                    lsColumn.Add(dr["TABLE_ENAME"]);
                            }
                            returnStr = "";
                            System.Data.DataSet dsdataAll = new System.Data.DataSet();
                            int i = 1;
                            foreach (object obj in lsColumn)
                            {
                                detailDS.Tables[0].DefaultView.RowFilter = " TABLE_ENAME='" + obj.ToString() + "'";
                                System.Data.DataView dv = detailDS.Tables[0].DefaultView;
                                //int objRowCount = detailDS.Tables[0].DefaultView.ToTable("table2", true, "COLUMN_CNAME").Rows.Count;
                                //string RowsStr = "";
                                System.Data.DataTable _dt = new System.Data.DataTable(obj.ToString());
                                //object[] objRow = new object[objRowCount];
                                int j = 0;
                                foreach (System.Data.DataRowView drv in dv)
                                {
                                    if (_dt.Columns.IndexOf(drv["COLUMN_CNAME"].ToString()) == -1)
                                    {
                                        _dt.Columns.Add(drv["COLUMN_CNAME"].ToString());
                                        //objRow[j++] = "123";
                                    }
                                }
                                //_dt.Rows.Add(objRow);
                                dsdataAll.Tables.Add(_dt);
                                //returnStr += SoMeTech.CommonDll.PublicDal.DataToJSON(dsdata);
                            }
                            string URL = context.Request.Url.AbsoluteUri;
                            URL = URL.Replace(context.Request.Url.PathAndQuery, "");
                            string _GUID = Guid.NewGuid().ToString("N");
                            string _path = context.Server.MapPath("~/temp/excel/" + _GUID + "/");// + obj.ToString() + ".xls"
                            if (!System.IO.Directory.Exists(_path))
                            {
                                System.IO.Directory.CreateDirectory(_path);
                            }
                            //QxRoom.QxExcel.DataSetToExcel.ExportToExcel(_path + dsdataAll.Tables[0].TableName + ".xls", dsdataAll);

                            ExcelLibrary.DataSetHelper.CreateWorkbook(_path + dsdataAll.Tables[0].TableName + ".xls", dsdataAll);

                            if (System.IO.File.Exists(_path + dsdataAll.Tables[0].TableName + ".xls"))
                            {
                                System.IO.FileInfo fileInfo = null;
                                try
                                {
                                    fileInfo = new System.IO.FileInfo(_path + dsdataAll.Tables[0].TableName + ".xls");
                                    Response.Clear();
                                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                                    Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(dsdataAll.Tables[0].TableName + ".xls", System.Text.Encoding.UTF8));
                                    Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                                    Response.ContentType = "application/octet-stream";
                                    Response.WriteFile(fileInfo.FullName);
                                    Response.End();
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                                return;
                            }
                            
                            //Response.Clear();
                            //Response.ContentEncoding = System.Text.Encoding.UTF8;
                            //Response.AppendHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(dsdataAll.Tables[0].TableName) + ".xls");
                            //Response.ContentType = "application/vnd.ms-excel";
                            //Response.BufferOutput = true;

                            //System.IO.MemoryStream m = new System.IO.MemoryStream();
                            //QxRoom.QxExcel.DataSetToExcel dsToExcle = new QxRoom.QxExcel.DataSetToExcel();
                            //dsToExcle.ExportToExcel(dsdataAll, m);
                            //m.WriteTo(Response.OutputStream);

                            //Response.End();
                        }
                    }
                    break;
                case "savadata":
                    string sysName = context.Request["sysName"];
                    if (sysName != null)
                    {
                        sysName = context.Server.MapPath("/temp/" + sysName);
                        if (System.IO.File.Exists(sysName))
                        {
                            try
                            {
                                string strConn = "PRovider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sysName + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
                                System.Data.OleDb.OleDbConnection Oleconn = new System.Data.OleDb.OleDbConnection(strConn);
                                System.Data.DataSet excel_ds = new System.Data.DataSet();
                                string strExcel = "select * from [" + GetExcelFirstTableName(sysName, 0) + "]";
                                try
                                {
                                    Oleconn.Open();
                                    System.Data.OleDb.OleDbDataAdapter excelCommand = new System.Data.OleDb.OleDbDataAdapter(strExcel, Oleconn);
                                    excelCommand.Fill(excel_ds, "exdtSource");//得到dataset
                                }
                                catch (Exception)
                                {
                                    returnStr = "Excel数据文件读取失败！";
                                    break;
                                }
                                finally
                                {
                                    Oleconn.Close();
                                    Oleconn.Dispose();
                                }

                                if (SoMeTech.CommonDll.PublicDal.PageValidate.IsDecimal(id))
                                {
                                    SMZJ.BLL.PD_PROJECT_PUBLICEXCEL_Bll bll = new SMZJ.BLL.PD_PROJECT_PUBLICEXCEL_Bll();
                                    SMZJ.Model.PD_PROJECT_PUBLICEXCEL_Model model = bll.GetModel(decimal.Parse(id));
                                    //string xmlData = model.TABLENAME;
                                    //if (xmlData.Trim().Length == 0)
                                    //    break;
                                    //System.Data.DataSet ds_Xml = new System.Data.DataSet();
                                    //System.Xml.XmlTextReader xmlReader = new System.Xml.XmlTextReader(new System.IO.StringReader(xmlData));
                                    //ds_Xml.ReadXml(xmlReader);

                                    SMZJ.BLL.PD_PROJECT_PUBLICEXCEL_DETAIL_Bll detailBll = new SMZJ.BLL.PD_PROJECT_PUBLICEXCEL_DETAIL_Bll();
                                    System.Data.DataSet detailDS = detailBll.GetList(" pid='" + id + "'");

                                    if (detailDS.Tables.Count > 0 && detailDS.Tables[0].Rows.Count > 0)
                                    {
                                        System.Collections.ArrayList lsColumn = new System.Collections.ArrayList();
                                        //获取是否多表导入
                                        foreach (System.Data.DataRow dr in detailDS.Tables[0].Rows)
                                        {
                                            if (lsColumn.IndexOf(dr["TABLE_ENAME"]) == -1)
                                                lsColumn.Add(dr["TABLE_ENAME"]);
                                        }
                                        foreach (object objTableName in lsColumn)
                                        {
                                            
                                            System.Data.DataView dv = detailDS.Tables[0].DefaultView;
                                            
                                            dv.RowFilter = " TABLE_ENAME='" + objTableName.ToString() + "'";
                                            //获取导入数据列名匹配数据库列名
                                            string RowsStr = "";
                                            foreach (System.Data.DataRowView drv in dv)
                                            {
                                                RowsStr += "'" + drv["COLUMN_ENAME"] + "',";
                                            }
                                            System.Data.DataSet dsdata = bll.GetDataSet(objTableName.ToString(), RowsStr.Remove(RowsStr.Length - 1, 1));

                                            //foreach (System.Data.DataRow _dr in dsdata.Tables[0].Rows)
                                            //{
                                            //    int _intdex = excel_ds.Tables[0].Columns.IndexOf(_dr["COMMENTS"].ToString().Trim());
                                            //    if (_intdex != -1 && _dr["COLUMN_NAME"].ToString().Trim().Length != 0)
                                            //        excel_ds.Tables[0].Columns[_intdex].ColumnName = _dr["COLUMN_NAME"].ToString().Trim();
                                            //}
                                            int NoColumnNum = 0;
                                            foreach (System.Data.DataRowView drv in dv)
                                            {
                                                int _intdex = excel_ds.Tables[0].Columns.IndexOf(drv["COLUMN_CNAME"].ToString().Trim());
                                                if (_intdex != -1 && drv["COLUMN_ENAME"].ToString().Trim().Length != 0)
                                                    excel_ds.Tables[0].Columns[_intdex].ColumnName = drv["COLUMN_ENAME"].ToString().Trim();
                                                else
                                                {
                                                    if (_intdex == -1)
                                                        NoColumnNum++;
                                                    //returnStr = "Excel中不存在模板中设定的 " + drv["COLUMN_CNAME"].ToString().Trim() + " 列，请检查！";
                                                    else
                                                        returnStr = "Excel导入模板已损坏，请联系管理员！";
                                                    //return;
                                                }
                                            }
                                            if (NoColumnNum == dv.Count)
                                            {
                                                returnStr = "您的Excel数据不符合要求！请检查。";
                                                return;
                                            }


                                            //拼接SQL语句，创建SQL参数。
                                            string sql = " insert into " + objTableName.ToString() + "(";
                                            string sqlValue = ") values(";
                                            System.Collections.ArrayList list = new System.Collections.ArrayList();
                                            foreach (System.Data.DataRow dr_data in dsdata.Tables[0].Rows)
                                            {
                                                //COLUMN_NAME,COMMENTS,DATA_TYPE
                                                if (dr_data["COMMENTS"].ToString().Trim().Length != 0)
                                                {
                                                    sql += dr_data["COLUMN_NAME"] + ",";
                                                    sqlValue += ":" + dr_data["COLUMN_NAME"] + ",";
                                                    System.Data.OracleClient.OracleParameter param = new System.Data.OracleClient.OracleParameter(":" + dr_data["COLUMN_NAME"], getOralceType(dr_data["DATA_TYPE"].ToString()), int.Parse(dr_data["data_length"].ToString()));
                                                    list.Add(param);
                                                }
                                                //dr["COLUMN_NAME"]
                                            }
                                            SoMeTech.DataAccess.DB_OPT dbo = new SoMeTech.DataAccess.DB_OPT();
                                            dbo.Open();
                                            dbo.TranFar();
                                            
                                            //获取导入表的主键
                                            string PrimaryName = null, PrimaryType = null, PrimaryLength = null;
                                            getPrimary(objTableName.ToString(), dbo, ref PrimaryName, ref PrimaryType, ref PrimaryLength);
                                            
                                            if (dv.Table.Columns.IndexOf(PrimaryName) == -1)
                                            {
                                                sql += PrimaryName + ",";
                                                sqlValue += ":" + PrimaryName + ",";
                                                System.Data.OracleClient.OracleParameter param = new System.Data.OracleClient.OracleParameter(":" + PrimaryName, getOralceType(PrimaryType), int.Parse(PrimaryLength));
                                                list.Add(param);
                                            }
                                            
                                            
                                            sql = sql.Remove(sql.Length - 1, 1);
                                            sqlValue = sqlValue.Remove(sqlValue.Length - 1, 1);
                                            sql = sql + sqlValue + ")";

                                            //执行SQL导入
                                            int _DataIndex = 1;
                                            try
                                            {
                                                foreach (System.Data.DataRow dr_excel in excel_ds.Tables[0].Rows)
                                                {
                                                    System.Data.OracleClient.OracleParameter[] parmAll = new System.Data.OracleClient.OracleParameter[list.Count];
                                                    for (int i = 0; i < list.Count; i++)
                                                    {
                                                        System.Data.OracleClient.OracleParameter temp = (System.Data.OracleClient.OracleParameter)list[i];
                                                        System.Data.OracleClient.OracleParameter param = new System.Data.OracleClient.OracleParameter(temp.ParameterName, temp.OracleType, temp.Size);

                                                        dv.RowFilter = " TABLE_ENAME='" + objTableName.ToString() + "' and COLUMN_ENAME='" + param.ParameterName.Remove(0, 1) + "'";
                                                        
                                                        //主键必须设定自动增长(SEQ)
                                                        if (PrimaryName.Equals(param.ParameterName.Remove(0, 1), StringComparison.OrdinalIgnoreCase) || dv[0]["isPrimary"].ToString().Trim() == "1")
                                                            param.Value = 0;
                                                        else if (dv[0]["isPrimary"].ToString().Trim() == "0" || dv[0]["isPrimary"].ToString().Trim().Length == 0)
                                                        {
                                                            //判断默认值
                                                            switch (dv[0]["ISDEFAULTTYPE"].ToString().Trim())
                                                            {
                                                                case "1":
                                                                    param.Value = dv[0]["DEFAULTDATA"];
                                                                    break;
                                                                case "2":
                                                                    param.Value = SoMeTech.CommonDll.PublicDal.GetSystemParam(dv[0]["DEFAULTDATA"].ToString().Trim());
                                                                    break;
                                                                case "3":
                                                                    param.Value = getObjectData(dv[0]["DEFAULTDATA"].ToString().Trim());
                                                                    break;
                                                                case "4":
                                                                    param.Value = dv[0]["DEFAULTDATA"];
                                                                    break;
                                                            }
                                                        }
                                                        //获取默认值后，如果用户Excel中存在此列，就覆盖系统默认，取用户数据值
                                                        if (IsColumnName(excel_ds.Tables[0], param.ParameterName.Remove(0, 1)))
                                                        {
                                                            //判定过于复杂，暂不处理
                                                            //if (dv[0]["isPrimary"].ToString().Trim() == "2")
                                                            //{
                                                            //    bool b = detailBll.GetCountBool("select count(*) from " + objTableName.ToString() + " where " + param.ParameterName.Remove(0, 1) + " ='" + dr_excel[param.ParameterName.Remove(0, 1)] + "'");
                                                            //    if (b)
                                                            //        throw new Exception("数据第" + _DataIndex+"行 第"+"列数据不允许重复，包括与系统中的");
                                                            //}
                                                            param.Value = dr_excel[param.ParameterName.Remove(0, 1)];
                                                        }
                                                        parmAll[i] = param;
                                                    }
                                                    dbo.ExecuteSql(sql, parmAll);
                                                    _DataIndex++;
                                                }
                                                returnStr = "";
                                                dbo.Commit();
                                            }
                                            catch (Exception e)
                                            {
                                                returnStr = "Excel数据不匹配，发生在第 " + _DataIndex + " 行数据，请检查！";
                                                dbo.RollBack();
                                            }
                                            finally
                                            {
                                                System.IO.File.Delete(sysName);
                                                dbo.Close();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        System.IO.File.Delete(sysName);
                                        returnStr = "Excel导入模板已损坏，请联系管理员！";
                                        break;
                                    }
                                }
                                else
                                {
                                    System.IO.File.Delete(sysName);
                                    returnStr = "找不到对应的导入模板，请联系管理员！";
                                    break;
                                }
                            }
                            finally
                            {
                                System.IO.File.Delete(sysName);
                            }
                        }
                        else
                        {
                            returnStr = "导入失败，找不到Excel文件，请联系管理员！";
                            break;
                        }
                    }
                    else
                    {
                        returnStr = "导入失败，请联系管理员！";
                        break;
                    }
                    break;

                case "gettable":
                    {
                        SMZJ.BLL.PD_PROJECT_PUBLICEXCEL_Bll bll_gt = new SMZJ.BLL.PD_PROJECT_PUBLICEXCEL_Bll();
                        System.Data.DataSet ds = bll_gt.GetAllUserTable();
                        returnStr = SoMeTech.CommonDll.PublicDal.DataToJSON(ds);
                    }
                    break;
                case "selectColumns":
                    {
                        string tbName = context.Request["tbName"];
                        if (tbName != null)
                        {
                            string upTbName = context.Request["upTbName"];
                            SMZJ.BLL.PD_PROJECT_PUBLICEXCEL_Bll bll_tb = new SMZJ.BLL.PD_PROJECT_PUBLICEXCEL_Bll();
                            System.Data.DataSet ds_tb = bll_tb.GetTableColumns(tbName);

                            if (upTbName == tbName)
                            {
                                ds_tb.Tables[0].Columns.Add("UpT", typeof(int));
                                ds_tb.Tables[0].Columns.Add("UpV", typeof(string));
                                ds_tb.Tables[0].Columns.Add("UpP", typeof(string));

                                SMZJ.BLL.PD_PROJECT_PUBLICEXCEL_DETAIL_Bll detailBll = new SMZJ.BLL.PD_PROJECT_PUBLICEXCEL_DETAIL_Bll();
                                System.Data.DataSet ds = detailBll.GetList("table_ename='" + upTbName + "'");
                                foreach (System.Data.DataRow drAll in ds_tb.Tables[0].Rows)
                                {
                                    foreach (System.Data.DataRow drUp in ds.Tables[0].Rows)
                                    {
                                        if (drAll["column_name"].ToString() == drUp["column_ename"].ToString())
                                        {
                                            drAll["checked"] = 1;
                                            drAll["UpP"] = drUp["isprimary"];
                                            drAll["UpT"] = drUp["ISDEFAULTTYPE"];
                                            drAll["UpV"] = drUp["DEFAULTDATA"];
                                        }
                                    }
                                }
                            }
                            returnStr = SoMeTech.CommonDll.PublicDal.DataToJSON(ds_tb);
                        }
                    }
                    break;
                case "GetIDTable":
                    string auto_id = context.Request["auto_id"];
                    if (auto_id != null && SoMeTech.CommonDll.PublicDal.PageValidate.IsDecimal(auto_id))
                    {
                        SMZJ.BLL.PD_PROJECT_PUBLICEXCEL_Bll bll_gtid = new SMZJ.BLL.PD_PROJECT_PUBLICEXCEL_Bll();
                        SMZJ.Model.PD_PROJECT_PUBLICEXCEL_Model model = bll_gtid.GetModel(decimal.Parse(auto_id));
                        System.Data.DataSet dsBranch = bll_gtid.GetBranch(model.COMPANYID);

                        returnStr = model.TABLENAME + "|" + model.COMPANYID + "|" + model.BRANCHID + "|" + SoMeTech.CommonDll.PublicDal.DataToJSON(dsBranch) + "|" + model.NAME;
                    }
                    break;
                case "GetBranch":
                    string Company = context.Request["Company"];
                    if (Company != null && Company.Trim().Length != 0)
                    {
                        SMZJ.BLL.PD_PROJECT_PUBLICEXCEL_Bll bll_gtid = new SMZJ.BLL.PD_PROJECT_PUBLICEXCEL_Bll();
                        System.Data.DataSet dsBranch = bll_gtid.GetBranch(Company);

                        returnStr = SoMeTech.CommonDll.PublicDal.DataToJSON(dsBranch);
                    }
                    break;
            }
        }
        finally
        {
            context.Response.Write(returnStr);
        }
    }
    private object getObjectData(string ObjectData)
    {
        switch (ObjectData)
        {
            case "date":
                return DateTime.Now;
        }
        return null;
    }
    //private void SavaData(string sql,System.Data.OracleClient.OracleParameter[] paramAll,SoMeTech.DataAccess.DB_OPT dbo)
    //{
    //}
    private void ParamValueTypePD(System.Data.OracleClient.OracleParameter param)
    {
        switch (param.DbType)
        {
            
        }
    }
    private bool IsColumnName(System.Data.DataTable dt,string ColumnName) 
    {
        if (dt.Columns.IndexOf(ColumnName) == -1)
            return false;
        else
            return true;
    }
    private System.Data.OracleClient.OracleType getOralceType(string dataType)
    {
        switch (dataType)
        {
            case "VARCHAR2":
                return System.Data.OracleClient.OracleType.VarChar;
            case "NVARCHAR2":
                return System.Data.OracleClient.OracleType.NVarChar;
            case "CHAR":
                return System.Data.OracleClient.OracleType.Char;
            case "NUMBER":
                return System.Data.OracleClient.OracleType.Number;
            case "DATE":
                return System.Data.OracleClient.OracleType.DateTime;
            default:
                return System.Data.OracleClient.OracleType.NVarChar;
        }
    }
    private Type getType(string dataType)
    {
        switch (dataType)
        {
            case "VARCHAR2":
            case "NVARCHAR2":
                return typeof(string);
            case "CHAR":
                return typeof(int);
            case "NUMBER":
                return typeof(decimal);
            case "DATE":
                return typeof(DateTime);
            default:
                return typeof(string);
        }
    }

    public static string GetExcelFirstTableName(string excelFileName,int tableIndex)
    {
        string tableName = null;
        if (System.IO.File.Exists(excelFileName))
        {
            using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet." +
              "OLEDB.4.0;Extended Properties=\"Excel 8.0\";Data Source=" + excelFileName))
            {
                conn.Open();
                System.Data.DataTable dt = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                if (dt.Rows.Count >= tableIndex)
                    tableName = dt.Rows[tableIndex][2].ToString().Trim();
            }
        }
        return tableName;
    }
    private void getPrimary(string tbName, SoMeTech.DataAccess.DB_OPT dbo,ref string PrimaryName,ref string type,ref string length)
    {
        string uid = SoMeTech.CommonDll.PublicDal.GetDataBaseName();
        string sql = "select  t1.column_name,t3.data_type,t3.data_length   from   user_cons_columns t1 " +
        "inner join user_constraints t2 on t2.constraint_name=t1.constraint_name " +
        "inner join LB_VIEW_SELECTCOLUMNTEXTNAME t3 on t3.TABLE_NAME=t1.table_name and t3.OWNER=t2.owner and t3.COLUMN_NAME=t1.column_name " +
        "where t2.owner='" + uid.ToUpper() + "' and  t2.table_name   =   '" + tbName.ToUpper() + "'  and   t2.constraint_type   ='P' ";

        System.Data.DataSet ds = dbo.Query(sql, null);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
        {
            PrimaryName = ds.Tables[0].Rows[0]["column_name"].ToString();
            type = ds.Tables[0].Rows[0]["data_type"].ToString();
            length= ds.Tables[0].Rows[0]["data_length"].ToString();
        }
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}