namespace SoMeTech.Dictionary.OprateTacheApprove
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class OprateTacheApproveDal
    {
        public int Add(OprateTacheApproveModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into GOV_TC_DB_OprateTacheApprove(");
            builder.Append("OprateTachePK,CompanyPK,ApproveOrder,ApproveName,Remark");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + model.OprateTachePK + "',");
            builder.Append("'" + model.CompanyPK + "',");
            builder.Append(model.ApproveOrder + ",");
            builder.Append("'" + model.ApproveName + "',");
            builder.Append("'" + model.Remark + "'");
            builder.Append(")");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Delete(string PK, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete GOV_TC_DB_OprateTacheApprove ");
            builder.Append(" where PK='" + PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Exists(string PK, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(PK) from GOV_TC_DB_OprateTacheApprove");
            builder.Append(" where PK= @PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char) };
            parameters[0].Value = PK;
            return dbo.BackIsSelect(builder.ToString(), parameters, "");
        }

        public DataSet GetList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public OprateTacheApproveModel GetModel(DataRow dr)
        {
            OprateTacheApproveModel model = new OprateTacheApproveModel {
                PK = dr["PK"].ToString(),
                ApproveName = dr["ApproveName"].ToString(),
                CompanyPK = dr["CompanyPK"].ToString()
            };
            if (dr["ApproveOrder"].ToString() != "")
            {
                model.ApproveOrder = int.Parse(dr["ApproveOrder"].ToString());
            }
            model.Remark = dr["Remark"].ToString();
            model.OprateTachePK = dr["OprateTachePK"].ToString();
            return model;
        }

        public OprateTacheApproveModel GetModel(string PK, DB_OPT dbo)
        {
            string strSql = this.GetSql() + " where PK=:PK";
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char) };
            parameters[0].Value = PK;
            DataSet set = dbo.BackDataSet(strSql, parameters, "");
            if (set.Tables[0].Rows.Count > 0)
            {
                new OprateTacheApproveModel();
                return this.GetModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public OprateTacheApproveModel[] GetModels(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strWhere != "")
            {
                builder.Append(" where " + strWhere);
            }
            OracleParameter[] parameters = null;
            DataSet set = dbo.BackDataSet(builder.ToString(), parameters, "");
            OprateTacheApproveModel[] modelArray = null;
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            modelArray = new OprateTacheApproveModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new OprateTacheApproveModel();
                modelArray[i] = this.GetModel(set.Tables[0].Rows[i]);
            }
            return modelArray;
        }

        public string GetSql()
        {
            return "select PK,OprateTachePK,CompanyPK,ApproveOrder,ApproveName,Remark FROM GOV_TC_DB_OprateTacheApprove";
        }

        public DataSet GetViewList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,NAME,OPRATETACHEPK,COMPANYPK,TAKEPAPERSORDER,REMARK,COMPANYNAME,YWNAME FROM GOV_TC_VIEW_PAPERSINFO");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public int Update(OprateTacheApproveModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update GOV_TC_DB_OprateTacheApprove set ");
            builder.Append("OprateTachePK='" + model.OprateTachePK + "',");
            builder.Append("CompanyPK='" + model.CompanyPK + "',");
            builder.Append("ApproveOrder=" + model.ApproveOrder + ",");
            builder.Append("ApproveName='" + model.ApproveName + "',");
            builder.Append("Remark='" + model.Remark + "'");
            builder.Append(" where PK='" + model.PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

