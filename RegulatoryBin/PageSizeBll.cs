using SoMeTech.DataAccess;
using System;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;

public sealed class PageSizeBll : MainPageClass
{
    private DB_OPT db = new DB_OPT();

    public void GridViewSort(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        if ((this.ViewState["SortOrder"] != null) && (this.ViewState["OrderDire"] != null))
        {
            if (this.ViewState["SortOrder"].ToString() == sortExpression)
            {
                if (this.ViewState["OrderDire"].ToString() == "Desc")
                {
                    this.ViewState["OrderDire"] = "ASC";
                }
                else
                {
                    this.ViewState["OrderDire"] = "Desc";
                }
            }
            else
            {
                this.ViewState["SortOrder"] = e.SortExpression;
                this.ViewState["OrderDire"] = "ASC";
            }
        }
        else
        {
            this.ViewState["SortOrder"] = e.SortExpression;
            this.ViewState["OrderDire"] = "ASC";
        }
    }

    public DataSet pagesize(string strlist, string strtablename, string strwhere, string strorderid, string strorder, int strno, int pagesize, out string ii)
    {
        if (DB_OPT.DBT == DataBaseType.SqlServer)
        {
            SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("TableList", SqlDbType.NVarChar), new SqlParameter("TableName", SqlDbType.NVarChar), new SqlParameter("SelectWhere", SqlDbType.NVarChar), new SqlParameter("SelectOrderId", SqlDbType.NVarChar), new SqlParameter("SelectOrder", SqlDbType.NVarChar), new SqlParameter("intPageNo", SqlDbType.Int), new SqlParameter("intPageSize", SqlDbType.Int), new SqlParameter("RecordCount", SqlDbType.Int) };
            parameterArray[0].Value = strlist;
            parameterArray[0].Direction = ParameterDirection.Input;
            parameterArray[1].Value = strtablename;
            parameterArray[1].Direction = ParameterDirection.Input;
            parameterArray[2].Value = strwhere;
            parameterArray[2].Direction = ParameterDirection.Input;
            parameterArray[3].Value = strorderid;
            parameterArray[3].Direction = ParameterDirection.Input;
            parameterArray[4].Value = strorder;
            parameterArray[4].Direction = ParameterDirection.Input;
            parameterArray[5].Value = strno.ToString();
            parameterArray[5].Direction = ParameterDirection.Input;
            parameterArray[6].Value = pagesize.ToString();
            parameterArray[6].Direction = ParameterDirection.Input;
            parameterArray[7].Direction = ParameterDirection.Output;
            DataSet set = this.db.SqlSelectProcPar("GETDATASET.GetList", parameterArray);
            ii = parameterArray[7].Value.ToString();
            return set;
        }
        OracleParameter[] parameters = new OracleParameter[] { new OracleParameter("TableList", OracleType.VarChar), new OracleParameter("TableName", OracleType.VarChar), new OracleParameter("SelectWhere", OracleType.VarChar), new OracleParameter("SelectOrderId", OracleType.VarChar), new OracleParameter("SelectOrder", OracleType.VarChar), new OracleParameter("intPageNo", OracleType.Number), new OracleParameter("intPageSize", OracleType.Number), new OracleParameter("RecordCount", OracleType.Number), new OracleParameter("p_cursor", OracleType.Cursor) };
        parameters[0].Value = strlist;
        parameters[0].Direction = ParameterDirection.Input;
        parameters[1].Value = strtablename;
        parameters[1].Direction = ParameterDirection.Input;
        parameters[2].Value = strwhere;
        parameters[2].Direction = ParameterDirection.Input;
        parameters[3].Value = strorderid;
        parameters[3].Direction = ParameterDirection.Input;
        parameters[4].Value = strorder;
        parameters[4].Direction = ParameterDirection.Input;
        parameters[5].Value = strno.ToString();
        parameters[5].Direction = ParameterDirection.Input;
        parameters[6].Value = pagesize.ToString();
        parameters[6].Direction = ParameterDirection.Input;
        parameters[7].Direction = ParameterDirection.Output;
        parameters[8].Direction = ParameterDirection.Output;
        DataSet set2 = this.db.SqlSelectProcPar("GETDATASET.GetList", parameters);
        ii = parameters[7].Value.ToString();
        return set2;
    }

    public DataSet pagesize(string strlist, string strtablename, string strwhere, string strorderid, string strorder, int strno, int pagesize, DB_OPT dbo, out string ii)
    {
        if (DB_OPT.DBT == DataBaseType.SqlServer)
        {
            SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("TableList", SqlDbType.NVarChar), new SqlParameter("TableName", SqlDbType.NVarChar), new SqlParameter("SelectWhere", SqlDbType.NVarChar), new SqlParameter("SelectOrderId", SqlDbType.NVarChar), new SqlParameter("SelectOrder", SqlDbType.NVarChar), new SqlParameter("intPageNo", SqlDbType.Int), new SqlParameter("intPageSize", SqlDbType.Int), new SqlParameter("RecordCount", SqlDbType.Int) };
            parameterArray[0].Value = strlist;
            parameterArray[0].Direction = ParameterDirection.Input;
            parameterArray[1].Value = strtablename;
            parameterArray[1].Direction = ParameterDirection.Input;
            parameterArray[2].Value = strwhere;
            parameterArray[2].Direction = ParameterDirection.Input;
            parameterArray[3].Value = strorderid;
            parameterArray[3].Direction = ParameterDirection.Input;
            parameterArray[4].Value = strorder;
            parameterArray[4].Direction = ParameterDirection.Input;
            parameterArray[5].Value = strno.ToString();
            parameterArray[5].Direction = ParameterDirection.Input;
            parameterArray[6].Value = pagesize.ToString();
            parameterArray[6].Direction = ParameterDirection.Input;
            parameterArray[7].Direction = ParameterDirection.Output;
            DataSet set = this.db.SqlSelectProcPar("GETDATASET.GetList", parameterArray);
            ii = parameterArray[7].Value.ToString();
            return set;
        }
        OracleParameter[] parameters = new OracleParameter[] { new OracleParameter("TableList", OracleType.VarChar), new OracleParameter("TableName", OracleType.VarChar), new OracleParameter("SelectWhere", OracleType.VarChar), new OracleParameter("SelectOrderId", OracleType.VarChar), new OracleParameter("SelectOrder", OracleType.VarChar), new OracleParameter("intPageNo", OracleType.Number), new OracleParameter("intPageSize", OracleType.Number), new OracleParameter("RecordCount", OracleType.Number), new OracleParameter("p_cursor", OracleType.Cursor) };
        parameters[0].Value = strlist;
        parameters[0].Direction = ParameterDirection.Input;
        parameters[1].Value = strtablename;
        parameters[1].Direction = ParameterDirection.Input;
        parameters[2].Value = strwhere;
        parameters[2].Direction = ParameterDirection.Input;
        parameters[3].Value = strorderid;
        parameters[3].Direction = ParameterDirection.Input;
        parameters[4].Value = strorder;
        parameters[4].Direction = ParameterDirection.Input;
        parameters[5].Value = strno.ToString();
        parameters[5].Direction = ParameterDirection.Input;
        parameters[6].Value = pagesize.ToString();
        parameters[6].Direction = ParameterDirection.Input;
        parameters[7].Direction = ParameterDirection.Output;
        parameters[8].Direction = ParameterDirection.Output;
        DataSet set2 = this.db.SqlSelectProcPar("GETDATASET.GetList", parameters);
        ii = parameters[7].Value.ToString();
        return set2;
    }

    public DataSet pagesize_num(string strlist, string strtablename, string strwhere, string strorderid, string strorder, int strno, int pagesize, DB_OPT dbo, out string ii)
    {
        if (DB_OPT.DBT == DataBaseType.SqlServer)
        {
            SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("TableList", SqlDbType.NVarChar), new SqlParameter("TableName", SqlDbType.NVarChar), new SqlParameter("SelectWhere", SqlDbType.NVarChar), new SqlParameter("SelectOrderId", SqlDbType.NVarChar), new SqlParameter("SelectOrder", SqlDbType.NVarChar), new SqlParameter("intPageNo", SqlDbType.Int), new SqlParameter("intPageSize", SqlDbType.Int), new SqlParameter("RecordCount", SqlDbType.Int) };
            parameterArray[0].Value = strlist;
            parameterArray[0].Direction = ParameterDirection.Input;
            parameterArray[1].Value = strtablename;
            parameterArray[1].Direction = ParameterDirection.Input;
            parameterArray[2].Value = strwhere;
            parameterArray[2].Direction = ParameterDirection.Input;
            parameterArray[3].Value = strorderid;
            parameterArray[3].Direction = ParameterDirection.Input;
            parameterArray[4].Value = strorder;
            parameterArray[4].Direction = ParameterDirection.Input;
            parameterArray[5].Value = strno.ToString();
            parameterArray[5].Direction = ParameterDirection.Input;
            parameterArray[6].Value = pagesize.ToString();
            parameterArray[6].Direction = ParameterDirection.Input;
            parameterArray[7].Direction = ParameterDirection.Output;
            DataSet set = this.db.SqlSelectProcPar("GETDATASETBYNUM.GetListByNum", parameterArray);
            ii = parameterArray[7].Value.ToString();
            return set;
        }
        OracleParameter[] parameters = new OracleParameter[] { new OracleParameter("TableList", OracleType.VarChar), new OracleParameter("TableName", OracleType.VarChar), new OracleParameter("SelectWhere", OracleType.VarChar), new OracleParameter("SelectOrderId", OracleType.VarChar), new OracleParameter("SelectOrder", OracleType.VarChar), new OracleParameter("intPageNo", OracleType.Number), new OracleParameter("intPageSize", OracleType.Number), new OracleParameter("RecordCount", OracleType.Number), new OracleParameter("p_cursor", OracleType.Cursor) };
        parameters[0].Value = strlist;
        parameters[0].Direction = ParameterDirection.Input;
        parameters[1].Value = strtablename;
        parameters[1].Direction = ParameterDirection.Input;
        parameters[2].Value = strwhere;
        parameters[2].Direction = ParameterDirection.Input;
        parameters[3].Value = strorderid;
        parameters[3].Direction = ParameterDirection.Input;
        parameters[4].Value = strorder;
        parameters[4].Direction = ParameterDirection.Input;
        parameters[5].Value = strno.ToString();
        parameters[5].Direction = ParameterDirection.Input;
        parameters[6].Value = pagesize.ToString();
        parameters[6].Direction = ParameterDirection.Input;
        parameters[7].Direction = ParameterDirection.Output;
        parameters[8].Direction = ParameterDirection.Output;
        DataSet set2 = this.db.SqlSelectProcPar("GETDATASETBYNUM.GetListByNum", parameters);
        ii = parameters[7].Value.ToString();
        return set2;
    }
}

