namespace SMZJ.DAL
{
    using SoMeTech.CommonDll;
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_PROJECT_PUBLICEXCEL_Dal
    {
        public bool Add(PD_PROJECT_PUBLICEXCEL_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_PROJECT_PUBLICEXCEL(");
            builder.Append("AUTO_ID,COMPANYID,BRANCHID,NAME,TABLENAME,PD_PROJECT_SERVERPK)");
            builder.Append(" values (");
            builder.Append(":AUTO_ID,:COMPANYID,:BRANCHID,:NAME,:TABLENAME,:PD_PROJECT_SERVERPK)");
            builder.Append(" RETURNING AUTO_ID INTO :R_Auto_No ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_ID", OracleType.Number, 10), new OracleParameter(":COMPANYID", OracleType.VarChar, 50), new OracleParameter(":BRANCHID", OracleType.VarChar, 50), new OracleParameter(":NAME", OracleType.VarChar, 50), new OracleParameter(":TABLENAME", OracleType.VarChar, 0xfa0), new OracleParameter(":PD_PROJECT_SERVERPK", OracleType.VarChar, 50), new OracleParameter(":R_Auto_No", OracleType.Number, 20) };
            cmdParms[0].Value = model.AUTO_ID;
            cmdParms[1].Value = model.COMPANYID;
            cmdParms[2].Value = model.BRANCHID;
            cmdParms[3].Value = model.NAME;
            cmdParms[4].Value = model.TABLENAME;
            cmdParms[5].Value = model.PD_PROJECT_SERVERPK;
            cmdParms[6].Direction = ParameterDirection.Output;
            int num = DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
            model.AUTO_ID = decimal.Parse(cmdParms[6].Value.ToString());
            return (num > 0);
        }

        public PD_PROJECT_PUBLICEXCEL_Model DataRowToModel(DataRow row)
        {
            PD_PROJECT_PUBLICEXCEL_Model model = new PD_PROJECT_PUBLICEXCEL_Model();
            if (row != null)
            {
                if ((row["AUTO_ID"] != null) && (row["AUTO_ID"].ToString() != ""))
                {
                    model.AUTO_ID = decimal.Parse(row["AUTO_ID"].ToString());
                }
                if (row["COMPANYID"] != null)
                {
                    model.COMPANYID = row["COMPANYID"].ToString();
                }
                if (row["BRANCHID"] != null)
                {
                    model.BRANCHID = row["BRANCHID"].ToString();
                }
                if (row["NAME"] != null)
                {
                    model.NAME = row["NAME"].ToString();
                }
                if (row["TABLENAME"] != null)
                {
                    model.TABLENAME = row["TABLENAME"].ToString();
                }
                if (row["PD_PROJECT_SERVERPK"] != null)
                {
                    model.PD_PROJECT_SERVERPK = row["PD_PROJECT_SERVERPK"].ToString();
                }
            }
            return model;
        }

        public bool Delete(decimal AUTO_ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_PUBLICEXCEL ");
            builder.Append(" where AUTO_ID=:AUTO_ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_ID", OracleType.Number, 10) };
            cmdParms[0].Value = AUTO_ID;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string AUTO_IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_PUBLICEXCEL ");
            builder.Append(" where AUTO_ID in (" + AUTO_IDlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(decimal AUTO_ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_PROJECT_PUBLICEXCEL");
            builder.Append(" where AUTO_ID=:AUTO_ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_ID", OracleType.Number, 10) };
            cmdParms[0].Value = AUTO_ID;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        internal DataSet GetAllUserTable()
        {
            string dataBaseName = PublicDal.GetDataBaseName();
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from all_tab_comments t ");
            builder.Append("where t.owner='" + dataBaseName + "' and table_type='TABLE' and COMMENTS is not null");
            return DbHelperOra.Query(builder.ToString().ToUpper());
        }

        internal DataSet GetBranch(string Company)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select BH,NAME from db_branch ");
            builder.Append("where trim(pk_corp) like :Company||'%' ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":Company", OracleType.VarChar, 100) };
            cmdParms[0].Value = Company.Trim();
            return DbHelperOra.Query(builder.ToString(), cmdParms);
        }

        internal DataSet GetDataSet(string tablename, string columnNames)
        {
            if ((tablename.Trim().Length == 0) || (columnNames.Trim().Length == 0))
            {
                return null;
            }
            string dataBaseName = PublicDal.GetDataBaseName();
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from LB_VIEW_SELECTCOLUMNTEXTNAME t ");
            builder.Append("where t.owner='" + dataBaseName + "' and table_name='");
            builder.Append(tablename);
            builder.Append("' and column_name in (");
            builder.Append(columnNames);
            builder.Append(")");
            return DbHelperOra.Query(builder.ToString().ToUpper());
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_ID,COMPANYID,BRANCHID,NAME,TABLENAME,PD_PROJECT_SERVERPK ");
            builder.Append(" FROM PD_PROJECT_PUBLICEXCEL ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT * FROM ( ");
            builder.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append("order by T." + orderby);
            }
            else
            {
                builder.Append("order by T.AUTO_ID desc");
            }
            builder.Append(")AS Row, T.*  from PD_PROJECT_PUBLICEXCEL T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(builder.ToString());
        }

        public PD_PROJECT_PUBLICEXCEL_Model GetModel(decimal AUTO_ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_ID,COMPANYID,BRANCHID,NAME,TABLENAME,PD_PROJECT_SERVERPK from PD_PROJECT_PUBLICEXCEL ");
            builder.Append(" where AUTO_ID=:AUTO_ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_ID", OracleType.Number, 10) };
            cmdParms[0].Value = AUTO_ID;
            new PD_PROJECT_PUBLICEXCEL_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM PD_PROJECT_PUBLICEXCEL ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            object single = DbHelperOra.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        internal DataSet GetTableColumns(string table_name)
        {
            string dataBaseName = PublicDal.GetDataBaseName();
            StringBuilder builder = new StringBuilder();
            builder.Append("select t.*,0 checked from all_col_comments t ");
            builder.Append("where owner='" + dataBaseName + "' and table_name=:table_name and COMMENTS is not null");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":table_name", OracleType.VarChar, 100) };
            cmdParms[0].Value = table_name;
            return DbHelperOra.Query(builder.ToString().ToUpper(), cmdParms);
        }

        public bool Update(PD_PROJECT_PUBLICEXCEL_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_PROJECT_PUBLICEXCEL set ");
            builder.Append("COMPANYID=:COMPANYID,");
            builder.Append("BRANCHID=:BRANCHID,");
            builder.Append("NAME=:NAME,");
            builder.Append("TABLENAME=:TABLENAME,");
            builder.Append("PD_PROJECT_SERVERPK=:PD_PROJECT_SERVERPK");
            builder.Append(" where AUTO_ID=:AUTO_ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":COMPANYID", OracleType.VarChar, 50), new OracleParameter(":BRANCHID", OracleType.VarChar, 50), new OracleParameter(":NAME", OracleType.VarChar, 50), new OracleParameter(":TABLENAME", OracleType.VarChar, 0xfa0), new OracleParameter(":PD_PROJECT_SERVERPK", OracleType.VarChar, 50), new OracleParameter(":AUTO_ID", OracleType.Number, 10) };
            cmdParms[0].Value = model.COMPANYID;
            cmdParms[1].Value = model.BRANCHID;
            cmdParms[2].Value = model.NAME;
            cmdParms[3].Value = model.TABLENAME;
            cmdParms[4].Value = model.PD_PROJECT_SERVERPK;
            cmdParms[5].Value = model.AUTO_ID;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

