namespace SoMeTech.ServicesClass.Services
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class ServicesTypeDal : ServicesTypeModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into gov_tc_db_ServicesType(");
            builder.Append("BH,Name)");
            builder.Append(" values (");
            builder.Append(":BH,:Name)");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":BH", OracleType.VarChar, 40), new OracleParameter(":Name", OracleType.VarChar, 40) };
            parameters[0].Value = base.BH;
            parameters[1].Value = base.Name;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }

        public override int Delete(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from gov_tc_db_ServicesType ");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.VarChar) };
            parameters[0].Value = base.PK;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }

        public override int Exists(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(PK) from gov_tc_db_ServicesType");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.VarChar) };
            parameters[0].Value = base.PK;
            return dbo.BackIsSelect(builder.ToString(), parameters, "");
        }

        public override DataSet GetList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,BH,Name ");
            builder.Append(" FROM gov_tc_db_ServicesType ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public override ServicesTypeModel GetModel(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,BH,Name from gov_tc_db_ServicesType ");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.VarChar) };
            parameters[0].Value = base.PK;
            DataSet set = dbo.BackDataSet(builder.ToString(), parameters, "");
            if (set.Tables[0].Rows.Count > 0)
            {
                new ServicesTypeModel();
                return this.GetModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        private ServicesTypeModel GetModel(DataRow dr)
        {
            return new ServicesTypeModel { PK = dr["PK"].ToString(), BH = dr["BH"].ToString(), Name = dr["Name"].ToString() };
        }

        public override ServicesTypeModel[] GetModel(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,BH,Name from gov_tc_db_ServicesType ");
            if (strWhere != "")
            {
                builder.Append(" where " + strWhere);
            }
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            ServicesTypeModel[] modelArray = null;
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            modelArray = new ServicesTypeModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new ServicesTypeModel();
                modelArray[i] = this.GetModel(set.Tables[0].Rows[i]);
            }
            return modelArray;
        }

        public override int Update(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update gov_tc_db_ServicesType set ");
            builder.Append("BH=:BH,");
            builder.Append("Name=:Name");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char, 40), new OracleParameter(":BH", OracleType.VarChar, 40), new OracleParameter(":Name", OracleType.VarChar, 40) };
            parameters[0].Value = base.PK;
            parameters[1].Value = base.BH;
            parameters[2].Value = base.Name;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }
    }
}

