namespace SoMeTech.Dictionary.SFProExecuteRemark
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class SFZSZXFJDal
    {
        public int Add(SFZSZXFJModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into GOV_TC_DB_SFZSZXFJ(");
            builder.Append("EXECUTESTANDARDPK,TERMNAME,TERMVALUE,EXEMIN,EXEMAX,DISCRIPTION");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append(model.EXECUTESTANDARDPK + ",");
            builder.Append(model.TERMNAME + ",");
            builder.Append(model.TERMVALUE + ",");
            builder.Append(model.EXEMIN + ",");
            builder.Append(model.EXEMAX + ",");
            builder.Append(model.DISCRIPTION ?? "");
            builder.Append(")");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Delete(string PK, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from GOV_TC_DB_SFZSZXFJ ");
            builder.Append(" where PK=" + PK);
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Exists(string PK, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from GOV_TC_DB_SFZSZXFJ where PK=" + PK);
            builder.Append(" where PK=:PK");
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

        public SFZSZXFJModel GetModel(DataRow dr)
        {
            SFZSZXFJModel model = new SFZSZXFJModel {
                PK = dr["PK"].ToString(),
                EXECUTESTANDARDPK = dr["EXECUTESTANDARDPK"].ToString(),
                TERMNAME = dr["TERMNAME"].ToString()
            };
            if (dr["TERMVALUE"].ToString() != "")
            {
                model.TERMVALUE = int.Parse(dr["TERMVALUE"].ToString());
            }
            if (dr["EXEMIN"].ToString() != "")
            {
                model.EXEMIN = int.Parse(dr["EXEMIN"].ToString());
            }
            if (dr["EXEMAX"].ToString() != "")
            {
                model.EXEMAX = int.Parse(dr["EXEMAX"].ToString());
            }
            model.DISCRIPTION = dr["DISCRIPTION"].ToString();
            return model;
        }

        public SFZSZXFJModel GetModel(string PK, DB_OPT dbo)
        {
            string strSql = this.GetSql() + " where PK=:PK";
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char) };
            parameters[0].Value = PK;
            DataSet set = dbo.BackDataSet(strSql, parameters, "");
            if (set.Tables[0].Rows.Count > 0)
            {
                new SFZSZXFJModel();
                return this.GetModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public SFZSZXFJModel[] GetModels(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strWhere != "")
            {
                builder.Append(" where " + strWhere);
            }
            OracleParameter[] parameters = null;
            DataSet set = dbo.BackDataSet(builder.ToString(), parameters, "");
            SFZSZXFJModel[] modelArray = null;
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            modelArray = new SFZSZXFJModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new SFZSZXFJModel();
                modelArray[i] = this.GetModel(set.Tables[0].Rows[i]);
            }
            return modelArray;
        }

        public string GetSql()
        {
            return "select PK,EXECUTESTANDARDPK,TERMNAME,TERMVALUE,EXEMIN,EXEMAX,DISCRIPTION FROM GOV_TC_DB_SFZSZXFJ ";
        }

        public int Update(SFZSZXFJModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update GOV_TC_DB_SFZSZXFJ set ");
            builder.Append("EXECUTESTANDARDPK=" + model.EXECUTESTANDARDPK + ",");
            builder.Append("TERMNAME=" + model.TERMNAME + ",");
            builder.Append("TERMVALUE=" + model.TERMVALUE + ",");
            builder.Append("EXEMIN=" + model.EXEMIN + ",");
            builder.Append("EXEMAX=" + model.EXEMAX + ",");
            builder.Append("DISCRIPTION=" + model.DISCRIPTION);
            builder.Append(" where PK=" + model.PK);
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

