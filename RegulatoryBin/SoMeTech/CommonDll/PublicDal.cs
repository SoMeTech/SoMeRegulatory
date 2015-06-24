namespace SoMeTech.CommonDll
{
    using SoMeTech.CommonDll.Configuration;
    using SoMeTech.Data;
    using SoMeTech.DataAccess;
    using SoMeTech.json.usJSON;
    using SoMeTech.User;
    using SoMeTech.YZXWPageClass;
    using QxRoom.Common;
    using QxRoom.QxXml;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.OracleClient;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Script.Serialization;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Xml;
    using YYControls;
    using SMZJ.BLL;
    using SMZJ.Model;

    public sealed class PublicDal
    {
        public static ConfigurationDal cfd;
        public static DB_OPT dbo;

        public static void BindDropDownList(DropDownList dropDownList1, string tableName, string textField, string valueField, string strWhere)
        {
            DataSet pDBaseValues = GetPDBaseValues(tableName, strWhere);
            if ((pDBaseValues != null) && (pDBaseValues.Tables.Count > 0))
            {
                dropDownList1.DataSource = pDBaseValues.Tables[0];
                dropDownList1.DataTextField = textField;
                dropDownList1.DataValueField = valueField;
                dropDownList1.DataBind();
            }
        }

        public static int CalDateTime(DateTime t1, DateTime t2, bool pd)
        {
            if (pd && (t1 < t2))
            {
                DateTime time = t1;
                t1 = t2;
                t2 = time;
            }
            int num = t1.Year - t2.Year;
            int num2 = t1.Month - t2.Month;
            return (((num * 12) + num2) + 1);
        }

        public static void ChangeNum(string tacheNo, string num1)
        {
            XmlDocument document = new XmlDocument();
            string serverPath = Public.GetServerPath();
            document.Load(serverPath + @"\\bin\\TacheNo.xml");
            foreach (XmlNode node in document.SelectNodes("/TacheNo/TacheNoMess"))
            {
                if (node.Attributes[0].Value == tacheNo)
                {
                    node.InnerText = num1;
                    break;
                }
            }
            document.Save(serverPath + @"\\bin\\TacheNo.xml");
        }

        public static string CreateJSON(DataSet ds)
        {
            new JSONObject();
            JSONArray jsonArray = new JSONArray();
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                JSONObject item = new JSONObject();
                item.Add("CId", "'" + ds.Tables[0].Columns[i].ColumnName + "'");
                item.Add("CName", "'" + ds.Tables[0].Columns[i].ColumnName + "'");
                item.Add("sortable", "'true'");
                item.Add("renderer", "'null'");
                jsonArray.Add(item);
            }
            return JSONConvert.SerializeArray(jsonArray);
        }

        public static string CreateNum(out string num1, DB_OPT dbo)
        {
            cfd = new ConfigurationDal();
            DataSet list = new DataSet();
            list = cfd.GetList("", dbo);
            string str = "";
            string str2 = DateTime.Now.Month.ToString();
            string num = "";
            num1 = "";
            if ((list != null) && (list.Tables[0].Rows.Count > 0))
            {
                str = list.Tables[0].Rows[0]["STARTYEAR"].ToString();
                num1 = (int.Parse(list.Tables[0].Rows[0]["STARTNUM"].ToString()) + 1).ToString();
                num = (int.Parse(list.Tables[0].Rows[0]["STARTNUM"].ToString()) + 1).ToString();
            }
            if (DateTime.Now.Year.ToString() != str)
            {
                num = "0";
                cfd.Update(DateTime.Now.Year.ToString(), num, dbo);
                num = "1";
            }
            if (num.Length < 4)
            {
                num = Public.AddZero(num, 4);
            }
            if (str2.Length < 2)
            {
                str2 = Public.AddZero(str2, 2);
            }
            return (DateTime.Now.Year.ToString() + str2 + num);
        }

        public static string CreateNum(string tacheNo, out string num1, DB_OPT dbo)
        {
            cfd = new ConfigurationDal();
            DataSet list = new DataSet();
            list = cfd.GetList("", dbo);
            string str = "";
            string str2 = DateTime.Now.Month.ToString();
            string num = "";
            num1 = "";
            if ((list != null) && (list.Tables[0].Rows.Count > 0))
            {
                str = list.Tables[0].Rows[0]["STARTYEAR"].ToString();
                switch (tacheNo)
                {
                    case "01":
                        num = (int.Parse(list.Tables[0].Rows[0]["SOILGETNUM"].ToString()) + 1).ToString();
                        break;

                    case "02":
                        num = (int.Parse(list.Tables[0].Rows[0]["SOILOUTNUM"].ToString()) + 1).ToString();
                        break;

                    case "03":
                        num = (int.Parse(list.Tables[0].Rows[0]["SOILZHUANNUM"].ToString()) + 1).ToString();
                        break;

                    case "04":
                        num = (int.Parse(list.Tables[0].Rows[0]["PLANNUM"].ToString()) + 1).ToString();
                        break;

                    case "05":
                        num = (int.Parse(list.Tables[0].Rows[0]["BUILDINGNUM"].ToString()) + 1).ToString();
                        break;

                    case "06":
                        num = (int.Parse(list.Tables[0].Rows[0]["FINISHNUM"].ToString()) + 1).ToString();
                        break;

                    case "07":
                        num = (int.Parse(list.Tables[0].Rows[0]["HOUSENEWNUM"].ToString()) + 1).ToString();
                        break;

                    case "08":
                        num = (int.Parse(list.Tables[0].Rows[0]["HOUSESENNUM"].ToString()) + 1).ToString();
                        break;

                    case "09":
                        num = (int.Parse(list.Tables[0].Rows[0]["TQNUM"].ToString()) + 1).ToString();
                        break;
                }
                num1 = num;
            }
            if (DateTime.Now.Year.ToString() != str)
            {
                num = "0";
                cfd.Update(tacheNo, DateTime.Now.Year.ToString(), num, dbo);
                num = "1";
            }
            if (num.Length < 4)
            {
                num = Public.AddZero(num, 4);
            }
            if (str2.Length < 2)
            {
                str2 = Public.AddZero(str2, 2);
            }
            return (DateTime.Now.Year.ToString() + str2 + tacheNo + num);
        }

        public static string CreateNumXML(string tacheNo, out string num1, DB_OPT dbo)
        {
            QxXmlDocument document = new QxXmlDocument();
            string serverPath = Public.GetServerPath();
            document.Filepath = serverPath + @"\\bin\\TacheNo.xml";
            document.OpenXml();
            string innerText = document.GetNode("/TacheNo/Year", 0).InnerText;
            string str = DateTime.Now.Month.ToString();
            string str4 = "";
            num1 = "";
            int depth = document.GetDepth("/TacheNo/TacheNoMess");
            if (depth > 0)
            {
                for (int i = 0; i < depth; i++)
                {
                    if (document.SearchAttribute("/TacheNo/TacheNoMess", i, null, "NoNum") == tacheNo)
                    {
                        num1 = (int.Parse(document.GetNode("/TacheNo/TacheNoMess", i).InnerText) + 1).ToString();
                        str4 = (int.Parse(document.GetNode("/TacheNo/TacheNoMess", i).InnerText) + 1).ToString();
                        break;
                    }
                }
            }
            document.Dispose();
            if (DateTime.Now.Year.ToString() != innerText)
            {
                str4 = "0";
                XmlDocument document2 = new XmlDocument();
                document2.Load(serverPath + @"\\bin\\TacheNo.xml");
                document2.SelectSingleNode("/TacheNo/Year").InnerText = DateTime.Now.Year.ToString();
                foreach (XmlNode node in document2.SelectNodes("/TacheNo/TacheNoMess"))
                {
                    node.InnerText = str4;
                }
                document2.Save(serverPath + @"\\bin\\TacheNo.xml");
                str4 = "1";
            }
            if (str4.Length < 4)
            {
                str4 = Public.AddZero(str4, 4);
            }
            if (str.Length < 2)
            {
                str = Public.AddZero(str, 2);
            }
            return (DateTime.Now.Year.ToString() + str + tacheNo + str4);
        }

        public static string createProjectCode(string year, string departCode)
        {
            string text1 = year + departCode;
            string str2 = "";
            object single = DbHelperOra.GetSingle((str2 + "select Max(PD_Project_Code) from TB_Project where trim(PD_Year)='" + year.Trim().Trim(new char[] { '\t' }) + "'  and trim(PD_GK_DEPART_ID)='" + departCode.Trim() + "'").ToString());
            if (single != null)
            {
                return Convert.ToString((long) (long.Parse(single.ToString()) + 1L));
            }
            return (year.Trim() + departCode.Trim() + "001");
        }

        public static string DataToJSON(DataSet ds)
        {
            JSONObject jsonObject = new JSONObject();
            JSONArray array = new JSONArray();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                JSONObject item = new JSONObject();
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    item.Add(ds.Tables[0].Columns[j].ColumnName, "'" + ds.Tables[0].Rows[i][j] + "'");
                }
                array.Add(item);
            }
            jsonObject.Add("data", array);
            return JSONConvert.SerializeObject(jsonObject);
        }

        public static string DataToJSON2(DataSet ds)
        {
            new JSONObject();
            JSONArray jsonArray = new JSONArray();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                JSONObject item = new JSONObject();
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    item.Add(ds.Tables[0].Columns[j].ColumnName, "'" + ds.Tables[0].Rows[i][j] + "'");
                }
                jsonArray.Add(item);
            }
            return JSONConvert.SerializeArray(jsonArray);
        }

        public static object GetBranchName(string Branch)
        {
            string sQLString = "select name from db_branch where trim(BH)=:BH";
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":BH", OracleType.VarChar, 100) };
            cmdParms[0].Value = Branch.Trim();
            return DbHelperOra.GetSingle(sQLString, cmdParms);
        }

        public static string GetCompanyWhere()
        {
            string str = HttpContext.Current.Session["pk_corp"].ToString();
            string str2 = "";
            if ((str != null) && (str.Trim() != ""))
            {
                DB_OPT dbo = new DB_OPT();
                try
                {
                    try
                    {
                        dbo.Open();
                        UserModel model = new UserDal {
                            UserName = ((UserModel) HttpContext.Current.Session["User"]).UserName
                        };
                        model.GetModel(dbo);
                        string[] strArray = model.CompanyPower.Split(new char[] { '|' });
                        string str3 = "";
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            str3 = str3 + strArray[i].Trim();
                            if (i < (strArray.Length - 1))
                            {
                                str3 = str3 + "','";
                            }
                        }
                        if (str3 != "")
                        {
                            str3 = "'" + str3 + "'";
                            return (" and (trim(PD_PROJECT_INPUT_COMPANY) like '" + str.Trim() + "%' and trim(PD_PROJECT_INPUT_COMPANY) in (" + str3 + "))");
                        }
                        return " and 1=0";
                    }
                    catch (Exception)
                    {
                        str2 = " and 1=0 ";
                    }
                    return str2;
                }
                finally
                {
                    if (dbo != null)
                    {
                        dbo.Close();
                    }
                }
            }
            return " and 1=0 ";
        }

        public static string GetCompanyWhereZB()
        {
            UserModel model = (UserModel) HttpContext.Current.Session["User"];
            string str = model.Company.pk_corp;
            string str2 = "";
            if ((str != null) && (str.Trim() != ""))
            {
                DB_OPT dbo = new DB_OPT();
                try
                {
                    try
                    {
                        dbo.Open();
                        UserModel model2 = new UserDal {
                            UserName = model.UserName
                        };
                        model2.GetModel(dbo);
                        string[] strArray = model2.CompanyPower.Split(new char[] { '|' });
                        string str3 = "";
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            str3 = str3 + strArray[i].Trim();
                            if (i < (strArray.Length - 1))
                            {
                                str3 = str3 + "','";
                            }
                        }
                        if (str3 != "")
                        {
                            str3 = "'" + str3 + "'";
                            return (" and ((trim(PD_QUOTA_INPUT_DEPART)='" + model.Branch.BH.Trim() + "' and trim(PD_QUOTA_INPUT_COMPANY)='" + str.Trim() + "') or trim(PD_QUOTA_DEPART) in (" + str3 + ") or (pd_quota_isup=1 and IF_SHOW=1 and company_code='" + str.Trim() + "'))");
                        }
                        return (" and ((trim(PD_QUOTA_INPUT_DEPART)='" + model.Branch.BH.Trim() + "' and trim(PD_QUOTA_INPUT_COMPANY)='" + str.Trim() + "') or (pd_quota_isup=1 and IF_SHOW=1 and company_code='" + str.Trim() + "'))");
                    }
                    catch (Exception)
                    {
                        str2 = " and 1=0 ";
                    }
                    return str2;
                }
                finally
                {
                    if (dbo != null)
                    {
                        dbo.Close();
                    }
                }
            }
            return " and 1=0 ";
        }

        public static TreeNode getConfigurationList()
        {
            dbo = new DB_OPT();
            cfd = new ConfigurationDal();
            DataSet list = new DataSet();
            list = cfd.GetList("", dbo);
            string text = "";
            string str2 = "";
            if ((list != null) && (list.Tables[0].Rows.Count > 0))
            {
                text = list.Tables[0].Rows[0]["MenuNodeName"].ToString();
                str2 = list.Tables[0].Rows[0]["MenuNodeValue"].ToString();
                HttpContext.Current.Response.Cookies["NodeName"].Value = text;
            }
            return new TreeNode(text, str2) { SelectAction = TreeNodeSelectAction.Expand };
        }

        public static string GetDataBaseName()
        {
            string str = ConfigurationManager.AppSettings["DataConn"];
            string str2 = null;
            int startIndex = -1;
            startIndex = str.IndexOf("User ID");
            if (startIndex != -1)
            {
                int num2 = str.LastIndexOf(";", startIndex);
                int index = str.IndexOf(";", startIndex);
                if (num2 == -1)
                {
                    num2 = 0;
                }
                if (index == -1)
                {
                    index = str.Length;
                }
                num2 = str.IndexOf("=", num2) + 1;
                return str.Substring(num2, index - num2);
            }
            if ((str2 == null) && ((startIndex = str.IndexOf("uid")) != -1))
            {
                int num4 = str.LastIndexOf(";", startIndex);
                int length = str.IndexOf(";", startIndex);
                if (num4 == -1)
                {
                    num4 = 0;
                }
                if (length == -1)
                {
                    length = str.Length;
                }
                num4 = str.IndexOf("=", num4) + 1;
                return str.Substring(num4, length - num4);
            }
            return "zjjg";
        }

        public static DataSet GetJGBM(string pk_corp)
        {
            string sQLString = "select * from db_branch where ISJGBM=1 and  trim(pk_corp)=:pk_corp";
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":pk_corp", OracleType.VarChar, 100) };
            cmdParms[0].Value = pk_corp;
            return DbHelperOra.Query(sQLString, cmdParms);
        }

        public static OracleDataReader GetPDBaseReaderValues(string tableName, string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * ");
            builder.Append(" FROM ");
            builder.Append(tableName);
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.ExecuteReader(builder.ToString());
        }

        public static DataSet GetPDBaseValues(string tableName, string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * ");
            builder.Append(" FROM ");
            builder.Append(tableName);
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public static DataSet GetPDBaseValues(string tableName, string selectCol, string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select " + selectCol);
            builder.Append(" FROM ");
            builder.Append(tableName);
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public static void GetSelectTJ(SmartGridView gvResult, ref DataSet DataSetClo, ref DataSet DataSetTable, ArrayList NotDisplayColumn)
        {
            DataSetClo = new DataSet();
            DataSetTable = new DataSet();
            DataSetClo.Tables.Add();
            DataSetTable.Tables.Add();
            foreach (DataControlField field in gvResult.Columns)
            {
                TemplateField field3;
                string name = field.GetType().Name;
                if (name != null)
                {
                    if (!(name == "BoundField"))
                    {
                        if (name == "TemplateField")
                        {
                            goto Label_0164;
                        }
                    }
                    else
                    {
                        BoundField field2 = (BoundField) field;
                        if (((field2.Visible && (field2.HeaderText != "序号")) && ((NotDisplayColumn == null) || !GetSelectTJ_pd(gvResult, field, NotDisplayColumn, field2.DataField))) && (DataSetClo.Tables[0].Columns.IndexOf(field2.DataField) == -1))
                        {
                            if (DataSetClo.Tables[0].Columns.IndexOf(field2.DataField) == -1)
                            {
                                DataSetClo.Tables[0].Columns.Add(field2.DataField);
                            }
                            if (DataSetTable.Tables[0].Columns.IndexOf(field2.HeaderText) == -1)
                            {
                                DataSetTable.Tables[0].Columns.Add(field2.HeaderText);
                            }
                        }
                    }
                }
                continue;
            Label_0164:
                field3 = (TemplateField) field;
                if (((field3.Visible && (field3.HeaderText != "序号")) && (field3.SortExpression != "")) && ((NotDisplayColumn == null) || !GetSelectTJ_pd(gvResult, field, NotDisplayColumn, field3.SortExpression)))
                {
                    if (DataSetClo.Tables[0].Columns.IndexOf(field3.SortExpression) == -1)
                    {
                        DataSetClo.Tables[0].Columns.Add(field3.SortExpression);
                    }
                    if (DataSetTable.Tables[0].Columns.IndexOf(field3.HeaderText) == -1)
                    {
                        DataSetTable.Tables[0].Columns.Add(field3.HeaderText);
                    }
                }
            }
        }

        private static bool GetSelectTJ_pd(SmartGridView gvResult, DataControlField column, ArrayList NotDisplayColumn, string BindDataName)
        {
            foreach (object obj2 in NotDisplayColumn)
            {
                if (BindDataName == obj2.ToString())
                {
                    column.Visible = false;
                    return true;
                }
            }
            return false;
        }

        public static object GetSystemParam(string family)
        {
            UserModel userModel = (UserModel) HttpContext.Current.Session["User"];
            Type t = userModel.GetType();
            return GetSystemParam_DG(family.Split(new char[] { '.' }), t, userModel, 0);
        }

        private static object GetSystemParam_DG(string[] familyList, Type t, object userModel, int p)
        {
            foreach (PropertyInfo info in t.GetProperties())
            {
                object obj2 = info.GetValue(userModel, null);
                if (info.Name == familyList[p])
                {
                    if (p < (familyList.Length - 1))
                    {
                        return GetSystemParam_DG(familyList, obj2.GetType(), obj2, p + 1);
                    }
                    return obj2;
                }
            }
            return null;
        }

        public static DataSet getTZJGC()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select id,moneyname,isgetquota from PD_BASE_TZJGC");
            return DbHelperOra.Query(builder.ToString());
        }

        public static void GetUpDownStream(Page page, string serverPK, int operation, out string NewServerPK)
        {
            string str = page.Request.Url.ToString();
            int startIndex = str.LastIndexOf("/") + 1;
            int num2 = str.LastIndexOf("?");
            string path = (num2 < 0) ? str.Substring(startIndex) : str.Substring(startIndex, num2 - startIndex);
            UserModel model = new UserDal();
            DB_OPT dbo = new DB_OPT();
            model.GetUpDownStream(path, serverPK, operation, out NewServerPK, dbo);
        }

        public static string GetUpLoadFileName()
        {
            string str = "D://ZJJGFile/";
            return (str + DateTime.Now.Ticks);
        }

        public static string getURL(Page page)
        {
            string str = page.Request.Url.ToString();
            int startIndex = str.LastIndexOf("/") + 1;
            int num2 = str.LastIndexOf("?");
            if (num2 >= 0)
            {
                return str.Substring(startIndex, num2 - startIndex);
            }
            return str.Substring(startIndex);
        }

        public static bool IsDelete(Page page, string Tb_Name, string Id_Name, string Id_Value, string column_SERVERPK_Name)
        {
            if (((UserModel) page.Session["User"]).UserName.ToLower() != "admin")
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("select " + column_SERVERPK_Name + " from " + Tb_Name + " a");
                builder.Append(" where trim(a." + Id_Name + ")=:Id_Value ");
                OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":Id_Value", OracleType.VarChar, 50) };
                cmdParms[0].Value = Id_Value.Trim();
                DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
                if (set.Tables[0].Rows.Count > 0)
                {
                    string serverPK = set.Tables[0].Rows[0][0].ToString();
                    if (serverPK != null)
                    {
                        string newServerPK = "";
                        GetUpDownStream(page, serverPK, -1, out newServerPK);
                        return (serverPK == newServerPK);
                    }
                }
            }
            return true;
        }

        public static bool IsEnglishStr(string str)
        {
            new Regex("^[^\0-\x00ff]");
            Regex regex = new Regex("^[a-zA-Z]");
            return regex.IsMatch(str);
        }

        public static bool IsJGBM(string Branch)
        {
            string strSql = "select count(*) from db_branch where ISJGBM=1 and trim(BH)=:BH";
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":BH", OracleType.VarChar, 100) };
            cmdParms[0].Value = Branch;
            return DbHelperOra.Exists(strSql, cmdParms);
        }

        public static bool IsYwgs(string depart)
        {
            string strSql = "select count(*) from db_branch  t\r\n                            left join db_company c on c.pk_corp=t.pk_corp\r\n                            where c.ishasbaby=1  and t.isjgbm=0\r\n                            and trim(t.bh)=:bh";
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":bh", OracleType.VarChar, 100) };
            cmdParms[0].Value = depart;
            return DbHelperOra.Exists(strSql, cmdParms);
        }

        public static DataSet JsonToDataSet(string Json)
        {
            try
            {
                DataSet set = new DataSet();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Dictionary<string, object> dictionary = (Dictionary<string, object>) serializer.DeserializeObject(Json);
                foreach (KeyValuePair<string, object> pair in dictionary)
                {
                    DataTable table = new DataTable(pair.Key);
                    object[] objArray = (object[]) pair.Value;
                    foreach (object obj3 in objArray)
                    {
                        Dictionary<string, object> dictionary2 = (Dictionary<string, object>) obj3;
                        DataRow row = table.NewRow();
                        foreach (KeyValuePair<string, object> pair2 in dictionary2)
                        {
                            if (!table.Columns.Contains(pair2.Key))
                            {
                                table.Columns.Add(pair2.Key.ToString());
                                row[pair2.Key] = pair2.Value;
                            }
                            else
                            {
                                row[pair2.Key] = pair2.Value;
                            }
                        }
                        table.Rows.Add(row);
                    }
                    set.Tables.Add(table);
                }
                return set;
            }
            catch
            {
                return null;
            }
        }

        public static void NewTotalMoneyRow(DataSet ds)
        {
            try
            {
                if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    foreach (DataColumn column in ds.Tables[0].Columns)
                    {
                        if (((column.DataType == typeof(int)) || (column.DataType == typeof(float))) || ((column.DataType == typeof(double)) || (column.DataType == typeof(decimal))))
                        {
                            ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][column.ColumnName] = ds.Tables[0].Compute("Sum([" + column.ColumnName + "])", "");
                        }
                    }
                    if (ds.Tables[0].Columns[0].DataType == typeof(string))
                    {
                        ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][0] = "合计：";
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static string PD_Coding_Level(string type, string Coding)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from DB_BASE_SSXX where ssxx_type=:type order by SSXX_CODE   ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":type", OracleType.VarChar, 10) };
            cmdParms[0].Value = type.Trim();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                int num = 0;
                foreach (DataRow row in set.Tables[0].Rows)
                {
                    if (PageValidate.IsInt(row["SSXX_CODINGLEN"].ToString()))
                    {
                        num += int.Parse(row["SSXX_CODINGLEN"].ToString());
                        if (num == Coding.Length)
                        {
                            return row["SSXX_CODE"].ToString();
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;
        }

        public static string SetCreateServiceStream(Page pages)
        {
            UserModel model = new UserDal();
            DB_OPT dbo = new DB_OPT();
            string newServerPK = "";
            new TB_PROJECT_Bll();
            string str2 = pages.Request.Url.ToString();
            int startIndex = str2.LastIndexOf("/") + 1;
            int num2 = str2.LastIndexOf("?");
            string path = (num2 < 0) ? str2.Substring(startIndex) : str2.Substring(startIndex, num2 - startIndex);
            UserModel model2 = (UserModel) pages.Session["User"];
            string userName = model2.UserName;
            string userCompany = pages.Session["pk_corp"].ToString();
            string bH = model2.Branch.BH;
            string userDate = DateTime.Now.ToString("yyyy-MM-dd");
            model.SetServiceStream(path, "", userName, userCompany, bH, userDate, "", 0, out newServerPK, dbo);
            return newServerPK;
        }

        public static string SetCreateServiceStream(Page pages, string Url)
        {
            UserModel model = new UserDal();
            DB_OPT dbo = new DB_OPT();
            string newServerPK = "";
            UserModel model2 = (UserModel) pages.Session["User"];
            string userName = model2.UserName;
            string userCompany = pages.Session["pk_corp"].ToString();
            string bH = model2.Branch.BH;
            string userDate = DateTime.Now.ToString("yyyy-MM-dd");
            model.SetServiceStream(Url, "", userName, userCompany, bH, userDate, "", 0, out newServerPK, dbo);
            return newServerPK;
        }

        /// <summary>
        /// gridview强制不换行
        /// </summary>
        /// <param name="objView"></param>
        public static void setGridKeepAll(SmartGridView objView)
        {
            objView.HeaderRow.Style.Add("word-break", "keep-all");
            foreach (GridViewRow row in objView.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    cell.Wrap = false;
                    cell.Style.Add("word-break", "keep-all");
                }
            }
        }

        public static void setGViewColumns(DataSet ds, SmartGridView gvResult)
        {
            if (gvResult.Columns.Count == 0)
            {
                BoundField field = null;
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    field = new BoundField {
                        DataField = ds.Tables[0].Columns[i].ColumnName,
                        HeaderText = ds.Tables[0].Columns[i].ColumnName,
                        SortExpression = ds.Tables[0].Columns[i].ColumnName
                    };
                    field.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    if (IsEnglishStr(ds.Tables[0].Columns[i].ColumnName))
                    {
                        field.Visible = false;
                    }
                    gvResult.Columns.Add(field);
                }
                ButtonField field2 = new ButtonField {
                    CommandName = "two",
                    Visible = false
                };
                gvResult.Columns.Add(field2);
                field2 = new ButtonField {
                    CommandName = "Select",
                    Visible = false
                };
                gvResult.Columns.Add(field2);
            }
            if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count == 0))
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            }
        }

        public static string SetServiceStream(Page pages, int operation, string tableName, string IdName, string IdValue, string Mess, string PD_NOW_SERVERPK_NAME)
        {
            UserModel model = new UserDal();
            DB_OPT dbo = new DB_OPT();
            string newServerPK = "";
            TB_PROJECT_Bll bll = new TB_PROJECT_Bll();
            string str3 = pages.Request.Url.ToString();
            int startIndex = str3.LastIndexOf("/") + 1;
            int num2 = str3.LastIndexOf("?");
            string path = (num2 < 0) ? str3.Substring(startIndex) : str3.Substring(startIndex, num2 - startIndex);
            UserModel model2 = (UserModel) pages.Session["User"];
            string userName = model2.UserName;
            string userCompany = pages.Session["pk_corp"].ToString();
            string bH = model2.Branch.BH;
            string userDate = DateTime.Now.ToString("yyyy-MM-dd");
            string serverPK = bll.GetServerPK(tableName, IdName, IdValue, PD_NOW_SERVERPK_NAME);
            model.SetServiceStream(path, IdValue, userName, userCompany, bH, userDate, serverPK, operation, out newServerPK, dbo);
            if (bll.UpdateServerPK(tableName, IdName, IdValue, newServerPK, PD_NOW_SERVERPK_NAME))
            {
                if (Mess != null)
                {
                    PageShowText.Refurbish(Mess + "成功", pages);
                }
                return newServerPK;
            }
            if (Mess != null)
            {
                PageShowText.Refurbish(Mess + "失败", pages);
            }
            return newServerPK;
        }

        public static int SetZbState(string PD_QUOTA_CODE)
        {
            string str = "";
            return DbHelperOra.ExecuteSql(str + "update TB_QUOTA set PD_QUOTA_IFPASS=1  where PD_QUOTA_CODE='" + PD_QUOTA_CODE + "'");
        }

        public static string ShowBZ_MxButton_IsUP(Page page, out ButtonsModel main_bm, string serverPK, bool isQianShou)
        {
            if (HttpContext.Current.Session["User"] == null)
            {
                PageShowText.GoLoginPath_List(page);
                main_bm = null;
                return null;
            }
            string userName = ((UserModel) HttpContext.Current.Session["User"]).UserName;
            main_bm = new ButtonsModel(userName);
            string str2 = page.Request.Url.ToString();
            int startIndex = str2.LastIndexOf("/") + 1;
            int num2 = str2.LastIndexOf("?");
            string path = (num2 < 0) ? str2.Substring(startIndex) : str2.Substring(startIndex, num2 - startIndex);
            UserModel model = new UserDal();
            DB_OPT dbo = new DB_OPT();
            string showButtonID = "";
            string buttonShowTxt = "";
            string str6 = "";
            string str7 = "";
            model.GetServiceStream(path, userName, serverPK, out showButtonID, out buttonShowTxt, out str6, out str7, dbo);
            if (str7.Trim() != null)
            {
                string[] strArray = str7.Split(new char[] { '_' });
                if ((strArray.Length == 2) && (int.Parse(strArray[0]) == 1))
                {
                    main_bm.IfSave = true;
                }
            }
            if (!isQianShou)
            {
                string str8 = showButtonID.Trim();
                if (str8 != null)
                {
                    if (!(str8 == "ibtcontrol_ibtaudit"))
                    {
                        if (str8 == "ibtcontrol_ibtapply")
                        {
                            main_bm.IfApply = true;
                            if (buttonShowTxt != "")
                            {
                                main_bm.IbtApplyText = buttonShowTxt;
                            }
                            else
                            {
                                buttonShowTxt = main_bm.IbtApplyText;
                            }
                        }
                    }
                    else
                    {
                        main_bm.IfAudit = true;
                        if (buttonShowTxt != "")
                        {
                            main_bm.IbtAuditText = buttonShowTxt;
                        }
                        else
                        {
                            buttonShowTxt = main_bm.IbtAuditText;
                        }
                    }
                }
                if (str6 != null)
                {
                    string[] strArray2 = str6.Split(new char[] { '_' });
                    if (strArray2.Length != 2)
                    {
                        return buttonShowTxt;
                    }
                    if (int.Parse(strArray2[0]) == 1)
                    {
                        main_bm.IfSetBack = true;
                    }
                    if (int.Parse(strArray2[1]) == 1)
                    {
                        main_bm.IfRollBack = true;
                    }
                }
            }
            return buttonShowTxt;
        }

        public static void ShowListButton(Page page, out ButtonsModel model, string PD_PROJECT_CODE)
        {
            if (HttpContext.Current.Session["User"] == null)
            {
                PageShowText.GoLoginPath_List(page);
                model = null;
            }
            else
            {
                string userName = ((UserModel) HttpContext.Current.Session["User"]).UserName;
                model = new ButtonsModel(userName);
                string str2 = page.Request.Url.ToString();
                int startIndex = str2.LastIndexOf("/") + 1;
                int num2 = str2.LastIndexOf("?");
                string path = (num2 < 0) ? str2.Substring(startIndex) : str2.Substring(startIndex, num2 - startIndex);
                UserModel model2 = new UserDal();
                DB_OPT dbo = new DB_OPT();
                int isShow = 0;
                string showtxt = "";
                model2.GetServiceCode("ibtcontrol_ibtadd", path, userName, out isShow, out showtxt, dbo);
                if (isShow == 1)
                {
                    model.IfAdd = true;
                    if (showtxt != "")
                    {
                        model.IbtAddText = showtxt;
                    }
                }
                model2.GetServiceCode("ibtcontrol_ibtdo", path, userName, out isShow, out showtxt, dbo);
                if (isShow == 1)
                {
                    model.IfDo = true;
                    if (showtxt != "")
                    {
                        model.IbtDoText = showtxt;
                    }
                }
                model2.GetServiceCode("ibtcontrol_ibtdelete", path, userName, out isShow, out showtxt, dbo);
                if (isShow == 1)
                {
                    model.IfDelete = true;
                    if (showtxt != "")
                    {
                        model.IbtDeleteText = showtxt;
                    }
                }
            }
        }

        public static string ShowMxButton(Page page, out ButtonsModel main_bm, string tableName, string IdName, string IdValue, string PD_NOW_SERVERPK_NAME)
        {
            if (HttpContext.Current.Session["User"] == null)
            {
                PageShowText.GoLoginPath_List(page);
                main_bm = null;
                return null;
            }
            string userName = ((UserModel) HttpContext.Current.Session["User"]).UserName;
            main_bm = new ButtonsModel(userName);
            string mainServerPK = "";
            if ((IdValue != null) && (IdValue.Trim() != ""))
            {
                mainServerPK = new TB_PROJECT_Bll().GetServerPK(tableName, IdName, IdValue, PD_NOW_SERVERPK_NAME);
            }
            else
            {
                main_bm.IfSave = true;
                return "新建";
            }
            string str3 = page.Request.Url.ToString();
            int startIndex = str3.LastIndexOf("/") + 1;
            int num2 = str3.LastIndexOf("?");
            string path = (num2 < 0) ? str3.Substring(startIndex) : str3.Substring(startIndex, num2 - startIndex);
            UserModel model = new UserDal();
            DB_OPT dbo = new DB_OPT();
            string showButtonID = "";
            string buttonShowTxt = "";
            string str7 = "";
            string str8 = "";
            model.GetServiceStream(path, userName, mainServerPK, out showButtonID, out buttonShowTxt, out str7, out str8, dbo);
            string str9 = showButtonID.Trim();
            if (str9 != null)
            {
                if (!(str9 == "ibtcontrol_ibtaudit"))
                {
                    if (str9 == "ibtcontrol_ibtapply")
                    {
                        main_bm.IfApply = true;
                        if (buttonShowTxt != "")
                        {
                            main_bm.IbtApplyText = buttonShowTxt;
                        }
                    }
                }
                else
                {
                    main_bm.IfAudit = true;
                    if (buttonShowTxt != "")
                    {
                        main_bm.IbtAuditText = buttonShowTxt;
                    }
                }
            }
            if (str8.Trim() != null)
            {
                string[] strArray = str8.Split(new char[] { '_' });
                if ((strArray.Length == 2) && (int.Parse(strArray[0]) == 1))
                {
                    main_bm.IfSave = true;
                }
            }
            if (str7 != null)
            {
                string[] strArray2 = str7.Split(new char[] { '_' });
                if (strArray2.Length != 2)
                {
                    return buttonShowTxt;
                }
                if (int.Parse(strArray2[0]) == 1)
                {
                    main_bm.IfSetBack = true;
                }
                if (int.Parse(strArray2[1]) == 1)
                {
                    main_bm.IfRollBack = true;
                }
            }
            return buttonShowTxt;
        }

        public static void UpdateLog(string TYPE, string CODE, string EXE_CZ, string EXE_JG, string EXE_TXT, string FREE1, string FREE2, string FREE3, Page page)
        {
            if (HttpContext.Current.Session["User"] == null)
            {
                PageShowText.GoLoginPath_List(page);
            }
            else
            {
                PD_PROJECT_LOG_Bll bll = new PD_PROJECT_LOG_Bll();
                UserModel model = (UserModel) page.Session["User"];
                PD_PROJECT_LOG_Model model2 = new PD_PROJECT_LOG_Model {
                    AUTOID = DateTime.Now.ToString("yyyyMMddhhmmssffffff"),
                    BM = model.Branch.BH,
                    COMPANY = page.Session["pk_corp"].ToString(),
                    PD_PROJECT_CODE = CODE,
                    PD_PROJECT_TYPE = TYPE,
                    MAN = model.UserName,
                    EXE_CZ = EXE_CZ,
                    EXE_DTIME = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                    EXE_JG = EXE_JG,
                    EXE_TXT = EXE_TXT,
                    FREE1 = FREE1,
                    FREE2 = FREE2,
                    FREE3 = FREE3
                };
                bll.Add(model2);
            }
        }

        public static class PageValidate
        {
            public static bool IsDateTime(object text)
            {
                DateTime time;
                if (text == null)
                {
                    return false;
                }
                return DateTime.TryParse(text.ToString(), out time);
            }

            public static bool IsDecimal(object text)
            {
                decimal num;
                if (text == null)
                {
                    return false;
                }
                return decimal.TryParse(text.ToString(), out num);
            }

            public static bool IsInt(object text)
            {
                int num;
                if (text == null)
                {
                    return false;
                }
                return int.TryParse(text.ToString(), out num);
            }

            public static bool IsNumber(object text)
            {
                long num;
                if (text == null)
                {
                    return false;
                }
                return long.TryParse(text.ToString(), out num);
            }
        }
    }
}

