namespace SoMeTech.ServicesClass.Operation
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class BusinessMessDal : BusinessMessModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into GOV_TC_DB_OPRATETACHE(");
            builder.Append("Name,OprateOrder,Remark,TacheType)");
            builder.Append(" values (");
            builder.Append(":Name,:OprateOrder,:Remark,:TacheType)");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":Name", OracleType.VarChar, 60), new OracleParameter(":OprateOrder", OracleType.Number), new OracleParameter(":Remark", OracleType.VarChar, 0xff), new OracleParameter(":TacheType", OracleType.VarChar, 2) };
            parameters[0].Value = base.Name;
            parameters[1].Value = base.OprateOrder;
            parameters[2].Value = base.Remark;
            parameters[3].Value = base.TacheType;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }

        public override int Delete(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from GOV_TC_DB_OprateTache ");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char) };
            parameters[0].Value = base.PK;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }

        public override int Exists(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(PK) from GOV_TC_DB_OprateTache");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char) };
            parameters[0].Value = base.PK;
            return dbo.BackIsSelect(builder.ToString(), parameters, "");
        }

        public override DataSet GetList(string strWhere, DB_OPT dbo)
        {
            string selectSql = this.GetSelectSql();
            if (strWhere.Trim() != "")
            {
                selectSql = selectSql + " where " + strWhere;
            }
            return dbo.BackDataSet(selectSql, null);
        }

        public override BusinessMessModel GetModel(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSelectSql());
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char) };
            parameters[0].Value = base.PK;
            DataSet set = dbo.BackDataSet(builder.ToString(), parameters, "");
            if (set.Tables[0].Rows.Count > 0)
            {
                new BusinessMessModel();
                return this.GetModel(false, false, set.Tables[0].Rows[0], dbo);
            }
            return null;
        }

        public override BusinessMessModel[] GetModel(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSelectSql());
            if (strWhere != "")
            {
                builder.Append(" where " + strWhere);
            }
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            BusinessMessModel[] modelArray = null;
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            modelArray = new BusinessMessModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new BusinessMessModel();
                modelArray[i] = this.GetModel(false, false, set.Tables[0].Rows[i], dbo);
            }
            return modelArray;
        }

        private BusinessMessModel GetModel(bool bj_child, bool bj_father, DataRow dr, DB_OPT dbo)
        {
            BusinessMessModel model = new BusinessMessModel {
                Name = dr["Name"].ToString()
            };
            if (dr["OprateOrder"].ToString() != "")
            {
                model.OprateOrder = int.Parse(dr["OprateOrder"].ToString());
            }
            model.PK = dr["PK"].ToString();
            model.Remark = dr["Remark"].ToString();
            model.TacheType = dr["TacheType"].ToString();
            return model;
        }

        private string GetSelectSql()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,Name,OprateOrder,Remark,TacheType ");
            builder.Append(" FROM GOV_TC_DB_OprateTache ");
            return builder.ToString();
        }

        public static int IsFlowOK(string pk, DB_OPT dbo)
        {
            string strSql = "select Count(PK) from GOV_TC_DB_Operation where rtrim(OperationPK)='" + pk.Trim() + "'";
            return dbo.BackIsSelect(strSql, null);
        }

        public override int Update(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update GOV_TC_DB_OprateTache set ");
            builder.Append("Name=:Name,");
            builder.Append("OprateOrder=:OprateOrder,");
            builder.Append("TacheType=:TacheType,");
            builder.Append("Remark=:Remark");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char, 40), new OracleParameter(":Name", OracleType.VarChar, 60), new OracleParameter(":OprateOrder", OracleType.Number), new OracleParameter(":TacheType", OracleType.VarChar, 2), new OracleParameter(":Remark", OracleType.VarChar, 0xff) };
            parameters[0].Value = base.PK;
            parameters[1].Value = base.Name;
            parameters[2].Value = base.OprateOrder;
            parameters[3].Value = base.TacheType;
            parameters[4].Value = base.Remark;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }
    }
}

