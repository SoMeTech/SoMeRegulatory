namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_PROJECT_CONTRACT_BAK_Dal
    {
        public bool Add(PD_PROJECT_CONTRACT_BAK_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_PROJECT_CONTRACT_BAK(");
            builder.Append("ID,PD_PROJECT_CODE,PD_CONTRACT_TYPE,PD_CONTRACT_NO,PD_CONTRACT_DATE,PD_CONTRACT_COMPANY,PD_CONTRACT_MOENY,PD_CONTRACT_MOENY_CHANGE,PD_CONTRACT_ASK_LIMIT,PD_CONTRACT_ASK_PROCEED,PD_CONTRACT_ASK_PAYMENT,PD_CONTRACT_NOTE,PD_CONTRACT_FILENAME,PD_CONTRACT_FILENAME_SYSTEM,PD_CONTRACT_NAME,PD_DB_LOOP,PD_YEAR,PD_NOW_SERVERPK)");
            builder.Append(" values (");
            builder.Append(":ID,:PD_PROJECT_CODE,:PD_CONTRACT_TYPE,:PD_CONTRACT_NO,:PD_CONTRACT_DATE,:PD_CONTRACT_COMPANY,:PD_CONTRACT_MOENY,:PD_CONTRACT_MOENY_CHANGE,:PD_CONTRACT_ASK_LIMIT,:PD_CONTRACT_ASK_PROCEED,:PD_CONTRACT_ASK_PAYMENT,:PD_CONTRACT_NOTE,:PD_CONTRACT_FILENAME,:PD_CONTRACT_FILENAME_SYSTEM,:PD_CONTRACT_NAME,:PD_DB_LOOP,:PD_YEAR,:PD_NOW_SERVERPK)");
            OracleParameter[] cmdParms = new OracleParameter[] { 
                new OracleParameter(":ID", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 0x24), new OracleParameter(":PD_CONTRACT_TYPE", OracleType.VarChar, 30), new OracleParameter(":PD_CONTRACT_NO", OracleType.VarChar, 30), new OracleParameter(":PD_CONTRACT_DATE", OracleType.DateTime), new OracleParameter(":PD_CONTRACT_COMPANY", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_MOENY", OracleType.Number, 0x12), new OracleParameter(":PD_CONTRACT_MOENY_CHANGE", OracleType.Number, 0x12), new OracleParameter(":PD_CONTRACT_ASK_LIMIT", OracleType.VarChar, 500), new OracleParameter(":PD_CONTRACT_ASK_PROCEED", OracleType.VarChar, 500), new OracleParameter(":PD_CONTRACT_ASK_PAYMENT", OracleType.VarChar, 500), new OracleParameter(":PD_CONTRACT_NOTE", OracleType.VarChar, 500), new OracleParameter(":PD_CONTRACT_FILENAME", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_FILENAME_SYSTEM", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_NAME", OracleType.VarChar, 100), new OracleParameter(":PD_DB_LOOP", OracleType.Char, 1), 
                new OracleParameter(":PD_YEAR", OracleType.Number, 4), new OracleParameter(":PD_NOW_SERVERPK", OracleType.VarChar, 50)
             };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.PD_PROJECT_CODE;
            cmdParms[2].Value = model.PD_CONTRACT_TYPE;
            cmdParms[3].Value = model.PD_CONTRACT_NO;
            cmdParms[4].Value = model.PD_CONTRACT_DATE;
            cmdParms[5].Value = model.PD_CONTRACT_COMPANY;
            cmdParms[6].Value = model.PD_CONTRACT_MOENY;
            cmdParms[7].Value = model.PD_CONTRACT_MOENY_CHANGE;
            cmdParms[8].Value = model.PD_CONTRACT_ASK_LIMIT;
            cmdParms[9].Value = model.PD_CONTRACT_ASK_PROCEED;
            cmdParms[10].Value = model.PD_CONTRACT_ASK_PAYMENT;
            cmdParms[11].Value = model.PD_CONTRACT_NOTE;
            cmdParms[12].Value = model.PD_CONTRACT_FILENAME;
            cmdParms[13].Value = model.PD_CONTRACT_FILENAME_SYSTEM;
            cmdParms[14].Value = model.PD_CONTRACT_NAME;
            cmdParms[15].Value = model.PD_DB_LOOP;
            cmdParms[0x10].Value = model.PD_YEAR;
            cmdParms[0x11].Value = model.PD_NOW_SERVERPK;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public PD_PROJECT_CONTRACT_BAK_Model DataRowToModel(DataRow row)
        {
            PD_PROJECT_CONTRACT_BAK_Model model = new PD_PROJECT_CONTRACT_BAK_Model();
            if (row != null)
            {
                if ((row["ID"] != null) && (row["ID"].ToString() != ""))
                {
                    model.ID = decimal.Parse(row["ID"].ToString());
                }
                if (row["PD_PROJECT_CODE"] != null)
                {
                    model.PD_PROJECT_CODE = row["PD_PROJECT_CODE"].ToString();
                }
                if (row["PD_CONTRACT_TYPE"] != null)
                {
                    model.PD_CONTRACT_TYPE = row["PD_CONTRACT_TYPE"].ToString();
                }
                if (row["PD_CONTRACT_NO"] != null)
                {
                    model.PD_CONTRACT_NO = row["PD_CONTRACT_NO"].ToString();
                }
                if ((row["PD_CONTRACT_DATE"] != null) && (row["PD_CONTRACT_DATE"].ToString() != ""))
                {
                    model.PD_CONTRACT_DATE = new DateTime?(DateTime.Parse(row["PD_CONTRACT_DATE"].ToString()));
                }
                if (row["PD_CONTRACT_COMPANY"] != null)
                {
                    model.PD_CONTRACT_COMPANY = row["PD_CONTRACT_COMPANY"].ToString();
                }
                if ((row["PD_CONTRACT_MOENY"] != null) && (row["PD_CONTRACT_MOENY"].ToString() != ""))
                {
                    model.PD_CONTRACT_MOENY = new decimal?(decimal.Parse(row["PD_CONTRACT_MOENY"].ToString()));
                }
                if ((row["PD_CONTRACT_MOENY_CHANGE"] != null) && (row["PD_CONTRACT_MOENY_CHANGE"].ToString() != ""))
                {
                    model.PD_CONTRACT_MOENY_CHANGE = new decimal?(decimal.Parse(row["PD_CONTRACT_MOENY_CHANGE"].ToString()));
                }
                if (row["PD_CONTRACT_ASK_LIMIT"] != null)
                {
                    model.PD_CONTRACT_ASK_LIMIT = row["PD_CONTRACT_ASK_LIMIT"].ToString();
                }
                if (row["PD_CONTRACT_ASK_PROCEED"] != null)
                {
                    model.PD_CONTRACT_ASK_PROCEED = row["PD_CONTRACT_ASK_PROCEED"].ToString();
                }
                if (row["PD_CONTRACT_ASK_PAYMENT"] != null)
                {
                    model.PD_CONTRACT_ASK_PAYMENT = row["PD_CONTRACT_ASK_PAYMENT"].ToString();
                }
                if (row["PD_CONTRACT_NOTE"] != null)
                {
                    model.PD_CONTRACT_NOTE = row["PD_CONTRACT_NOTE"].ToString();
                }
                if (row["PD_CONTRACT_FILENAME"] != null)
                {
                    model.PD_CONTRACT_FILENAME = row["PD_CONTRACT_FILENAME"].ToString();
                }
                if (row["PD_CONTRACT_FILENAME_SYSTEM"] != null)
                {
                    model.PD_CONTRACT_FILENAME_SYSTEM = row["PD_CONTRACT_FILENAME_SYSTEM"].ToString();
                }
                if (row["PD_CONTRACT_NAME"] != null)
                {
                    model.PD_CONTRACT_NAME = row["PD_CONTRACT_NAME"].ToString();
                }
                if (row["PD_DB_LOOP"] != null)
                {
                    model.PD_DB_LOOP = int.Parse(row["PD_DB_LOOP"].ToString());
                }
                if ((row["PD_YEAR"] != null) && (row["PD_YEAR"].ToString() != ""))
                {
                    model.PD_YEAR = new int?(int.Parse(row["PD_YEAR"].ToString()));
                }
                if (row["PD_NOW_SERVERPK"] != null)
                {
                    model.PD_NOW_SERVERPK = row["PD_NOW_SERVERPK"].ToString();
                }
            }
            return model;
        }

        public bool Delete(decimal ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_CONTRACT_BAK ");
            builder.Append(" where ID=:ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":ID", OracleType.Number, 20) };
            cmdParms[0].Value = ID;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_CONTRACT_BAK ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(decimal ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_PROJECT_CONTRACT_BAK");
            builder.Append(" where ID=:ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":ID", OracleType.Number, 20) };
            cmdParms[0].Value = ID;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PD_PROJECT_CODE,PD_CONTRACT_TYPE,PD_CONTRACT_NO,PD_CONTRACT_DATE,PD_CONTRACT_COMPANY,PD_CONTRACT_MOENY,PD_CONTRACT_MOENY_CHANGE,PD_CONTRACT_ASK_LIMIT,PD_CONTRACT_ASK_PROCEED,PD_CONTRACT_ASK_PAYMENT,PD_CONTRACT_NOTE,PD_CONTRACT_FILENAME,PD_CONTRACT_FILENAME_SYSTEM,PD_CONTRACT_NAME,PD_DB_LOOP,PD_YEAR,PD_NOW_SERVERPK ");
            builder.Append(" FROM PD_PROJECT_CONTRACT_BAK ");
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
                builder.Append("order by T.ID desc");
            }
            builder.Append(")AS Row, T.*  from PD_PROJECT_CONTRACT_BAK T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(builder.ToString());
        }

        internal decimal? GetMaxID(string PD_CONTRACT_NO)
        {
            string sQLString = "select max(id)id from PD_PROJECT_CONTRACT_BAK where PD_CONTRACT_NO=:PD_CONTRACT_NO";
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_CONTRACT_NO", OracleType.VarChar, 30) };
            cmdParms[0].Value = PD_CONTRACT_NO;
            object single = DbHelperOra.GetSingle(sQLString, cmdParms);
            if (single != null)
            {
                return new decimal?(decimal.Parse(single.ToString()));
            }
            return null;
        }

        public PD_PROJECT_CONTRACT_BAK_Model GetModel(decimal ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PD_PROJECT_CODE,PD_CONTRACT_TYPE,PD_CONTRACT_NO,PD_CONTRACT_DATE,PD_CONTRACT_COMPANY,PD_CONTRACT_MOENY,PD_CONTRACT_MOENY_CHANGE,PD_CONTRACT_ASK_LIMIT,PD_CONTRACT_ASK_PROCEED,PD_CONTRACT_ASK_PAYMENT,PD_CONTRACT_NOTE,PD_CONTRACT_FILENAME,PD_CONTRACT_FILENAME_SYSTEM,PD_CONTRACT_NAME,PD_DB_LOOP,PD_YEAR,PD_NOW_SERVERPK from PD_PROJECT_CONTRACT_BAK ");
            builder.Append(" where ID=:ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":ID", OracleType.Number, 20) };
            cmdParms[0].Value = ID;
            new PD_PROJECT_CONTRACT_BAK_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public bool GetPd_Contract_Moeny_Total(string PD_PROJECT_CODE, string PD_CONTRACT_MOENY, string Contract_Code)
        {
            string sQLString = "select nvl((sum(b.PD_PROJECT_MONEY_TOTAL) -(sum(a.PD_CONTRACT_MOENY)+ :PD_CONTRACT_MOENY)),0)  from PD_PROJECT_CONTRACT a,TB_PROJECT b   where a.PD_Project_Code= b.PD_Project_Code and a.PD_Project_Code = :PD_PROJECT_CODE and a.Auto_NO != :Contract_Code ";
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30), new OracleParameter(":PD_CONTRACT_MOENY", OracleType.Double, 10), new OracleParameter(":Contract_Code", OracleType.Int32, 4) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            cmdParms[1].Value = Convert.ToDecimal(PD_CONTRACT_MOENY);
            if (!Contract_Code.Equals("null"))
            {
                cmdParms[2].Value = Convert.ToInt32(Contract_Code);
            }
            else
            {
                cmdParms[2].Value = 0;
            }
            object single = DbHelperOra.GetSingle(sQLString, cmdParms);
            return ((single != null) && (decimal.Parse(single.ToString()) >= 0M));
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM PD_PROJECT_CONTRACT_BAK ");
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

        public bool Update(PD_PROJECT_CONTRACT_BAK_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_PROJECT_CONTRACT_BAK set ");
            builder.Append("ID=:ID,");
            builder.Append("PD_PROJECT_CODE=:PD_PROJECT_CODE,");
            builder.Append("PD_CONTRACT_TYPE=:PD_CONTRACT_TYPE,");
            builder.Append("PD_CONTRACT_NO=:PD_CONTRACT_NO,");
            builder.Append("PD_CONTRACT_DATE=:PD_CONTRACT_DATE,");
            builder.Append("PD_CONTRACT_COMPANY=:PD_CONTRACT_COMPANY,");
            builder.Append("PD_CONTRACT_MOENY=:PD_CONTRACT_MOENY,");
            builder.Append("PD_CONTRACT_MOENY_CHANGE=:PD_CONTRACT_MOENY_CHANGE,");
            builder.Append("PD_CONTRACT_ASK_LIMIT=:PD_CONTRACT_ASK_LIMIT,");
            builder.Append("PD_CONTRACT_ASK_PROCEED=:PD_CONTRACT_ASK_PROCEED,");
            builder.Append("PD_CONTRACT_ASK_PAYMENT=:PD_CONTRACT_ASK_PAYMENT,");
            builder.Append("PD_CONTRACT_NOTE=:PD_CONTRACT_NOTE,");
            builder.Append("PD_CONTRACT_FILENAME=:PD_CONTRACT_FILENAME,");
            builder.Append("PD_CONTRACT_FILENAME_SYSTEM=:PD_CONTRACT_FILENAME_SYSTEM,");
            builder.Append("PD_CONTRACT_NAME=:PD_CONTRACT_NAME,");
            builder.Append("PD_DB_LOOP=:PD_DB_LOOP,");
            builder.Append("PD_YEAR=:PD_YEAR,");
            builder.Append("PD_NOW_SERVERPK=:PD_NOW_SERVERPK");
            builder.Append(" where ID=:ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { 
                new OracleParameter(":ID", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 0x24), new OracleParameter(":PD_CONTRACT_TYPE", OracleType.VarChar, 30), new OracleParameter(":PD_CONTRACT_NO", OracleType.VarChar, 30), new OracleParameter(":PD_CONTRACT_DATE", OracleType.DateTime), new OracleParameter(":PD_CONTRACT_COMPANY", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_MOENY", OracleType.Number, 0x12), new OracleParameter(":PD_CONTRACT_MOENY_CHANGE", OracleType.Number, 0x12), new OracleParameter(":PD_CONTRACT_ASK_LIMIT", OracleType.VarChar, 500), new OracleParameter(":PD_CONTRACT_ASK_PROCEED", OracleType.VarChar, 500), new OracleParameter(":PD_CONTRACT_ASK_PAYMENT", OracleType.VarChar, 500), new OracleParameter(":PD_CONTRACT_NOTE", OracleType.VarChar, 500), new OracleParameter(":PD_CONTRACT_FILENAME", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_FILENAME_SYSTEM", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_NAME", OracleType.VarChar, 100), new OracleParameter(":PD_DB_LOOP", OracleType.Char, 1), 
                new OracleParameter(":PD_YEAR", OracleType.Number, 4), new OracleParameter(":PD_NOW_SERVERPK", OracleType.VarChar, 50)
             };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.PD_PROJECT_CODE;
            cmdParms[2].Value = model.PD_CONTRACT_TYPE;
            cmdParms[3].Value = model.PD_CONTRACT_NO;
            cmdParms[4].Value = model.PD_CONTRACT_DATE;
            cmdParms[5].Value = model.PD_CONTRACT_COMPANY;
            cmdParms[6].Value = model.PD_CONTRACT_MOENY;
            cmdParms[7].Value = model.PD_CONTRACT_MOENY_CHANGE;
            cmdParms[8].Value = model.PD_CONTRACT_ASK_LIMIT;
            cmdParms[9].Value = model.PD_CONTRACT_ASK_PROCEED;
            cmdParms[10].Value = model.PD_CONTRACT_ASK_PAYMENT;
            cmdParms[11].Value = model.PD_CONTRACT_NOTE;
            cmdParms[12].Value = model.PD_CONTRACT_FILENAME;
            cmdParms[13].Value = model.PD_CONTRACT_FILENAME_SYSTEM;
            cmdParms[14].Value = model.PD_CONTRACT_NAME;
            cmdParms[15].Value = model.PD_DB_LOOP;
            cmdParms[0x10].Value = model.PD_YEAR;
            cmdParms[0x11].Value = model.PD_NOW_SERVERPK;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

