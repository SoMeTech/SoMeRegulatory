namespace SoMeTech.ServicesClass.Operation
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class OperationDal : OperationModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into gov_tc_db_Operation(");
            builder.Append("OperationPK,ServerPKs)");
            builder.Append(" values (");
            builder.Append(":OperationPK,:ServerPKs)");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":OperationPK", OracleType.VarChar, 40), new OracleParameter(":ServerPKs", OracleType.VarChar, 0xff) };
            parameters[0].Value = base.OperationPK;
            parameters[1].Value = base.ServerPKs;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }

        public override int Delete(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from gov_tc_db_Operation ");
            builder.Append(" where OperationPK=:OperationPK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":OperationPK", OracleType.VarChar) };
            parameters[0].Value = base.OperationPK;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }

        public override int Exists(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(PK) from gov_tc_db_Operation");
            builder.Append(" where OperationPK=:OperationPK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":OperationPK", OracleType.VarChar) };
            parameters[0].Value = base.OperationPK;
            return dbo.BackIsSelect(builder.ToString(), parameters, "");
        }

        public override DataSet GetList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,OPERATIONPK,SERVERPKS ");
            builder.Append(" FROM gov_tc_db_Operation ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public override OperationModel GetModel(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,OPERATIONPK,SERVERPKS from gov_tc_db_Operation ");
            builder.Append(" where OperationPK=:OperationPK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":OperationPK", OracleType.Char) };
            parameters[0].Value = base.OperationPK;
            DataSet set = dbo.BackDataSet(builder.ToString(), parameters, "");
            if (set.Tables[0].Rows.Count > 0)
            {
                new OperationModel();
                return this.GetModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        private OperationModel GetModel(DataRow dr)
        {
            return new OperationModel { PK = dr["PK"].ToString().Trim(), OperationPK = dr["OperationPK"].ToString().Trim(), ServerPKs = dr["ServerPKs"].ToString() };
        }

        public override OperationModel[] GetModel(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,OPERATIONPK,SERVERPKS from gov_tc_db_Operation ");
            if (strWhere != "")
            {
                builder.Append(" where " + strWhere);
            }
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            OperationModel[] modelArray = null;
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            modelArray = new OperationModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new OperationModel();
                modelArray[i] = this.GetModel(set.Tables[0].Rows[i]);
            }
            return modelArray;
        }

        public override int Update(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update gov_tc_db_Operation set ");
            builder.Append("ServerPKs=:ServerPKs");
            builder.Append(" where OperationPK=:OperationPK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":OperationPK", OracleType.VarChar, 40), new OracleParameter(":ServerPKs", OracleType.VarChar, 0xfa0) };
            parameters[0].Value = base.OperationPK;
            parameters[1].Value = base.ServerPKs;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }
    }
}

