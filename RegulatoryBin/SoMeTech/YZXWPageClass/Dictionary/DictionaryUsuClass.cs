namespace SoMeTech.YZXWPageClass.Dictionary
{
    using SoMeTech.DataAccess;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.OracleClient;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public sealed class DictionaryUsuClass
    {
        

       
       

        private static object GetPara(string item, string head)
        {
            if (DB_OPT.DBT == DataBaseType.SqlServer)
            {
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("Item", SqlDbType.NVarChar), new SqlParameter("Head", SqlDbType.NVarChar), new SqlParameter("ERR", SqlDbType.NVarChar), new SqlParameter("YN", SqlDbType.Char) };
                parameterArray[0].Value = item;
                parameterArray[0].Direction = ParameterDirection.Input;
                parameterArray[1].Value = head;
                parameterArray[1].Direction = ParameterDirection.Input;
                parameterArray[2].Direction = ParameterDirection.Output;
                parameterArray[3].Direction = ParameterDirection.Output;
                return parameterArray;
            }
            OracleParameter[] parameterArray2 = new OracleParameter[] { new OracleParameter("Item", OracleType.VarChar), new OracleParameter("Head", OracleType.VarChar), new OracleParameter("ERR", OracleType.VarChar), new OracleParameter("YN", OracleType.Char) };
            parameterArray2[0].Value = item;
            parameterArray2[0].Direction = ParameterDirection.Input;
            parameterArray2[1].Value = head;
            parameterArray2[1].Direction = ParameterDirection.Input;
            parameterArray2[2].Direction = ParameterDirection.Output;
            parameterArray2[3].Direction = ParameterDirection.Output;
            return parameterArray2;
        }

        

       

    }
}

