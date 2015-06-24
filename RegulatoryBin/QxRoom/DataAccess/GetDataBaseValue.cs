namespace QxRoom.DataAccess
{
    using System;
    using System.Data;

    public class GetDataBaseValue
    {
        public static DataRow GetDataRow(DataSet _ds, int _indextable, int _indexrow)
        {
            return _ds.Tables[_indextable].Rows[_indexrow];
        }

        public static DataRow GetDataRow(DataSet _ds, string _tablename, int _indexrow)
        {
            return _ds.Tables[_tablename].Rows[_indexrow];
        }

        public static DataTable GetDataTable(DataSet _ds, int _index)
        {
            return _ds.Tables[_index];
        }

        public static DataTable GetDataTable(DataSet _ds, string _name)
        {
            return _ds.Tables[_name];
        }

        public static decimal GetDecimal(DataRow _dr, string _columnname)
        {
            object obj2 = GetObject(_dr, _columnname);
            if (obj2 != null)
            {
                return decimal.Parse(obj2.ToString());
            }
            return 0.0M;
        }

        public static decimal GetDecimal(DataRow _dr, string _columnname, decimal _returnnullvalue)
        {
            object obj2 = GetObject(_dr, _columnname);
            if (obj2 != null)
            {
                return decimal.Parse(obj2.ToString());
            }
            return _returnnullvalue;
        }

        public static int GetInt(DataRow _dr, string _columnname)
        {
            object obj2 = GetObject(_dr, _columnname);
            if (obj2 != null)
            {
                return int.Parse(obj2.ToString());
            }
            return 0;
        }

        public static int GetInt(DataRow _dr, string _columnname, int _returnnullvalue)
        {
            object obj2 = GetObject(_dr, _columnname);
            if (obj2 != null)
            {
                return int.Parse(obj2.ToString());
            }
            return _returnnullvalue;
        }

        public static object GetObject(DataRow _dr, string _columnname)
        {
            object obj2 = _dr[_columnname];
            if (!Convert.IsDBNull(obj2))
            {
                return obj2;
            }
            return null;
        }

        public static object GetObject(DataTable _dt, int _indexrow, string _columnname)
        {
            object obj2 = _dt.Rows[_indexrow][_columnname];
            if (!Convert.IsDBNull(obj2))
            {
                return obj2;
            }
            return null;
        }

        public static object GetObject(DataSet _ds, string _tablename, int _indexrow, string _columnname)
        {
            object obj2 = _ds.Tables[_tablename].Rows[_indexrow][_columnname];
            if (!Convert.IsDBNull(obj2))
            {
                return obj2;
            }
            return null;
        }

        public static string GetString(DataRow _dr, string _columnname)
        {
            object obj2 = GetObject(_dr, _columnname);
            if (obj2 != null)
            {
                return obj2.ToString();
            }
            return "";
        }

        public static string GetString(DataRow _dr, string _columnname, string _returnnullvalue)
        {
            object obj2 = GetObject(_dr, _columnname);
            if (obj2 != null)
            {
                return obj2.ToString();
            }
            return _returnnullvalue;
        }

        public static string GetString(DataTable _dt, int _indexrow, int _indexcolumn)
        {
            object obj2 = _dt.Rows[_indexrow][_indexcolumn];
            if (!Convert.IsDBNull(obj2))
            {
                return obj2.ToString();
            }
            return "";
        }

        public static string GetString(DataTable _dt, int _indexrow, string _columnname)
        {
            object obj2 = GetObject(_dt, _indexrow, _columnname);
            if (obj2 != null)
            {
                return obj2.ToString();
            }
            return "";
        }

        public static string GetString(DataSet _ds, int _indextable, int _indexrow, int _indexcolumn)
        {
            object obj2 = _ds.Tables[_indextable].Rows[_indexrow][_indexcolumn];
            if (!Convert.IsDBNull(obj2))
            {
                return obj2.ToString();
            }
            return "";
        }

        public static string GetString(DataSet _ds, string _tablename, int _indexrow, string _columnname)
        {
            object obj2 = GetObject(_ds, _tablename, _indexrow, _columnname);
            if (obj2 != null)
            {
                return obj2.ToString();
            }
            return "";
        }
    }
}

