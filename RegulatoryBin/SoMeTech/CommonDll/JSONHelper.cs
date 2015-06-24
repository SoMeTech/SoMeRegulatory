namespace SoMeTech.CommonDll
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Globalization;
    using System.Reflection;
    using System.Text;
    using System.Web;

    public sealed class JSONHelper
    {
        public static string Convert2Json(object o)
        {
            StringBuilder sb = new StringBuilder();
            WriteValue(sb, o);
            return sb.ToString();
        }

        public static object JsonToObject<T>(string jsonstr)
        {
            string[] strArray = jsonstr.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                strArray[i] = strArray[i].Replace("\"", "").Replace("'", "");
            }
            object obj2 = Activator.CreateInstance(typeof(T));
            PropertyInfo[] properties = obj2.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (properties != null)
            {
                foreach (PropertyInfo info in properties)
                {
                    for (int j = 0; j < strArray.Length; j++)
                    {
                        if (strArray[j].Split(new char[] { ':' })[0] == info.Name)
                        {
                            Type propertyType = info.PropertyType;
                            info.SetValue(obj2, Convert.ChangeType(strArray[j].Split(new char[] { ':' })[1], propertyType), null);
                        }
                    }
                }
            }
            return obj2;
        }

        public static void Write(DataSet dsSource)
        {
            DataTable table = dsSource.Tables[0];
            DataTable table2 = dsSource.Tables[1];
            StringBuilder sb = new StringBuilder();
            string str = table2.Rows[0]["TotalRow"].ToString();
            sb.Append("{\"total\":" + (string.IsNullOrEmpty(str) ? "1" : str) + ",\"rows\":[");
            foreach (DataRow row in table.Rows)
            {
                WriteDataRow(sb, row);
                sb.Append(",");
            }
            if (table.Rows.Count > 0)
            {
                sb.Length--;
            }
            sb.Append("]}");
            Write(sb.ToString());
        }

        public static void Write(DataTable dtSource)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (DataRow row in dtSource.Rows)
            {
                WriteDataRow(sb, row);
                sb.Append(",");
            }
            if (dtSource.Rows.Count > 0)
            {
                sb.Length--;
            }
            sb.Append("]");
            Write(sb.ToString());
        }

        public static void Write(string str)
        {
            HttpResponse response = HttpContext.Current.Response;
            response.HeaderEncoding = Encoding.UTF8;
            response.ContentType = "application/json";
            response.Write(str);
        }

        public static void Write(string jsonName, object obj)
        {
            Write(Convert2Json(obj), jsonName);
        }

        public static void Write(string str, string jsonName)
        {
            string s = "var " + jsonName + " = " + str;
            HttpResponse response = HttpContext.Current.Response;
            response.HeaderEncoding = Encoding.UTF8;
            response.ContentType = "application/json";
            response.Write(s);
        }

        public static void Write(DataTable dt_big, DataTable dt_details, string pk_field)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (DataRow row in dt_big.Rows)
            {
                sb.Append("{");
                foreach (DataColumn column in row.Table.Columns)
                {
                    sb.AppendFormat("\"{0}\":", column.ColumnName);
                    WriteValue(sb, row[column]);
                    sb.Append(",");
                }
                DataView defaultView = dt_details.DefaultView;
                defaultView.RowFilter = pk_field + "=" + row[pk_field];
                DataTable table = defaultView.ToTable();
                if (table.Rows.Count > 0)
                {
                    sb.Append("\"rows\":[");
                    foreach (DataRow row2 in table.Rows)
                    {
                        sb.Append("{");
                        foreach (DataColumn column2 in table.Columns)
                        {
                            sb.AppendFormat("\"{0}\":", column2.ColumnName);
                            WriteValue(sb, row2[column2]);
                            sb.Append(",");
                        }
                        sb.Length--;
                        sb.Append("}");
                        sb.Append(",");
                    }
                    sb.Length--;
                    sb.Append("]");
                }
                else
                {
                    sb.Length--;
                }
                sb.Append("}");
                sb.Append(",");
            }
            if (dt_big.Rows.Count > 0)
            {
                sb.Length--;
            }
            sb.Append("]");
            HttpResponse response = HttpContext.Current.Response;
            response.HeaderEncoding = Encoding.UTF8;
            response.ContentType = "application/json";
            response.Write(sb.ToString());
        }

        public static void WriteDataRow(StringBuilder sb, DataRow row)
        {
            sb.Append("{");
            foreach (DataColumn column in row.Table.Columns)
            {
                sb.AppendFormat("\"{0}\":", column.ColumnName);
                WriteValue(sb, row[column]);
                sb.Append(",");
            }
            if (row.Table.Columns.Count > 0)
            {
                sb.Length--;
            }
            sb.Append("}");
        }

        public static void WriteDataSet(StringBuilder sb, DataSet ds)
        {
            sb.Append("{\"Tables\":{");
            foreach (DataTable table in ds.Tables)
            {
                sb.AppendFormat("\"{0}\":", table.TableName);
                WriteDataTable(sb, table);
                sb.Append(",");
            }
            if (ds.Tables.Count > 0)
            {
                sb.Length--;
            }
            sb.Append("}}");
        }

        public static void WriteDataTable(StringBuilder sb, DataTable table)
        {
            sb.Append("{\"Rows\":[");
            foreach (DataRow row in table.Rows)
            {
                WriteDataRow(sb, row);
                sb.Append(",");
            }
            if (table.Rows.Count > 0)
            {
                sb.Length--;
            }
            sb.Append("]}");
        }

        public static void WriteDropList(DataTable dtSource)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append("{\"");
            sb.Append(dtSource.Rows[0].Table.Columns[0].ColumnName.ToString());
            sb.Append(" \":-1,\"");
            sb.Append(dtSource.Rows[0].Table.Columns[1].ColumnName.ToString());
            sb.Append("\":\"==请选择==\"},");
            foreach (DataRow row in dtSource.Rows)
            {
                WriteDataRow(sb, row);
                sb.Append(",");
            }
            if (dtSource.Rows.Count > 0)
            {
                sb.Length--;
            }
            sb.Append("]");
            Write(sb.ToString());
        }

        public static void WriteEnumerable(StringBuilder sb, IEnumerable e)
        {
            bool flag = false;
            sb.Append("[");
            foreach (object obj2 in e)
            {
                WriteValue(sb, obj2);
                sb.Append(",");
                flag = true;
            }
            if (flag)
            {
                sb.Length--;
            }
            sb.Append("]");
        }

        public static void WriteHashtable(StringBuilder sb, Hashtable e)
        {
            bool flag = false;
            sb.Append("{");
            foreach (string str in e.Keys)
            {
                sb.AppendFormat("\"{0}\":", str.ToLower());
                WriteValue(sb, e[str]);
                sb.Append(",");
                flag = true;
            }
            if (flag)
            {
                sb.Length--;
            }
            sb.Append("}");
        }

        public static void WriteObject(StringBuilder sb, object o)
        {
            MemberInfo[] members = o.GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance);
            sb.Append("{");
            bool flag = false;
            foreach (MemberInfo info in members)
            {
                bool flag2 = false;
                object val = null;
                if ((info.MemberType & MemberTypes.Field) == MemberTypes.Field)
                {
                    val = ((FieldInfo) info).GetValue(o);
                    flag2 = true;
                }
                else if ((info.MemberType & MemberTypes.Property) == MemberTypes.Property)
                {
                    PropertyInfo info3 = (PropertyInfo) info;
                    if (info3.CanRead && (info3.GetIndexParameters().Length == 0))
                    {
                        val = info3.GetValue(o, null);
                        flag2 = true;
                    }
                }
                if (flag2)
                {
                    sb.Append("\"");
                    sb.Append(info.Name);
                    sb.Append("\":");
                    WriteValue(sb, val);
                    sb.Append(",");
                    flag = true;
                }
            }
            if (flag)
            {
                sb.Length--;
            }
            sb.Append("}");
        }

        public static void WriteString(StringBuilder sb, string s)
        {
            sb.Append("\"");
            foreach (char ch in s)
            {
                switch (ch)
                {
                    case '\b':
                    {
                        sb.Append(@"\b");
                        continue;
                    }
                    case '\t':
                    {
                        sb.Append(@"\t");
                        continue;
                    }
                    case '\n':
                    {
                        sb.Append(@"\n");
                        continue;
                    }
                    case '\f':
                    {
                        sb.Append(@"\f");
                        continue;
                    }
                    case '\r':
                    {
                        sb.Append(@"\r");
                        continue;
                    }
                    case '"':
                    {
                        sb.Append("\\\"");
                        continue;
                    }
                    case '\\':
                    {
                        sb.Append(@"\\");
                        continue;
                    }
                }
                int num = ch;
                if ((num < 0x20) || (num > 0x7f))
                {
                    sb.AppendFormat(@"\u{0:X04}", num);
                }
                else
                {
                    sb.Append(ch);
                }
            }
            sb.Append("\"");
        }

        public static void WriteValue(StringBuilder sb, object val)
        {
            if ((val == null) || (val == DBNull.Value))
            {
                sb.Append("null");
            }
            else if ((val is string) || (val is Guid))
            {
                WriteString(sb, val.ToString());
            }
            else if (val is bool)
            {
                sb.Append(val.ToString().ToLower());
            }
            else if ((((val is double) || (val is float)) || ((val is long) || (val is int))) || (((val is short) || (val is byte)) || (val is decimal)))
            {
                sb.AppendFormat(CultureInfo.InvariantCulture.NumberFormat, "{0}", new object[] { val });
            }
            else if (val.GetType().IsEnum)
            {
                sb.Append((int) val);
            }
            else if (val is DateTime)
            {
                sb.Append("\"");
                sb.Append(Convert.ToDateTime(val).ToString("yyyy-MM-dd HH:mm"));
                sb.Append("\"");
            }
            else if (val is DataSet)
            {
                WriteDataSet(sb, val as DataSet);
            }
            else if (val is DataTable)
            {
                WriteDataTable(sb, val as DataTable);
            }
            else if (val is DataRow)
            {
                WriteDataRow(sb, val as DataRow);
            }
            else if (val is Hashtable)
            {
                WriteHashtable(sb, val as Hashtable);
            }
            else if (val is IEnumerable)
            {
                WriteEnumerable(sb, val as IEnumerable);
            }
            else
            {
                WriteObject(sb, val);
            }
        }
    }
}

