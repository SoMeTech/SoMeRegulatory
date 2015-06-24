namespace SoMeTech.OperationLog
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Text;

    public class OperationLogDal : OperationLogModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into DB_OPERATIONLOG(");
            builder.Append("UserName,opType,Business,Content,ifPass");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + base.UserName + "',");
            builder.Append("'" + base.opType + "',");
            builder.Append("'" + base.Business + "',");
            builder.Append("'" + base.Content + "',");
            builder.Append("'" + base.ifPass + "'");
            builder.Append(")");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int Delete(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete DB_OPERATIONLOG ");
            builder.Append(" where pk='" + base.pk + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int Exists(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from DB_OPERATIONLOG");
            builder.Append(" where pk='" + base.pk + "' ");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override DataSet GetList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select pk,UserName,opType,Business,Content,ifPass,opTime ");
            builder.Append(" FROM DB_OPERATIONLOG ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        private OperationLogModel Getmm(DataRow dr, DB_OPT dbo)
        {
            OperationLogModel model = new OperationLogModel {
                pk = dr["pk"].ToString(),
                UserName = dr["UserName"].ToString(),
                opType = dr["opType"].ToString(),
                Business = dr["Business"].ToString(),
                Content = dr["Content"].ToString(),
                ifPass = dr["ifPass"].ToString()
            };
            if (dr["opTime"].ToString() != "")
            {
                model.opTime = DateTime.Parse(dr["opTime"].ToString());
            }
            return model;
        }

        public override OperationLogModel GetModel(DB_OPT dbo)
        {
            new OperationLogModel();
            StringBuilder builder = new StringBuilder();
            builder.Append("select pk,UserName,opType,Business,Content,ifPass,opTime ");
            builder.Append(" FROM DB_OPERATIONLOG ");
            if (base.pk.Trim() != "")
            {
                builder.Append(" where pk='" + base.pk + "'");
            }
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.Getmm(set.Tables[0].Rows[0], dbo);
            }
            return null;
        }

        public override int Update(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_OPERATIONLOG set ");
            builder.Append("UserName='" + base.UserName + "',");
            builder.Append("opType='" + base.opType + "',");
            builder.Append("Business='" + base.Business + "',");
            builder.Append("Content='" + base.Content + "',");
            builder.Append("ifPass='" + base.ifPass + "',");
            builder.Append("opTime='" + base.opTime + "'");
            builder.Append(" where pk='" + base.pk + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

