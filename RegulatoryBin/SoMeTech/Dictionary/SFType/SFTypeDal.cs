namespace SoMeTech.Dictionary.SFType
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Text;

    public sealed class SFTypeDal : SFTypeModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into GOV_TC_DB_SFType(");
            builder.Append("pk_corp,Name,Discription");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + base.pk_corp + "',");
            builder.Append("'" + base.Name + "',");
            builder.Append("'" + base.Discription + "'");
            builder.Append(")");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int Delete(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete GOV_TC_DB_SFType ");
            builder.Append(" where PK='" + base.PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int Exists(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from GOV_TC_DB_SFType");
            builder.Append(" where PK='" + base.PK + "' ");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override DataSet GetList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,Name,Discription,pk_corp ");
            builder.Append(" FROM gov_tc_view_SFType ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        private SFTypeModel Getmm(DataRow dr, DB_OPT dbo)
        {
            return new SFTypeModel { PK = dr["PK"].ToString(), Discription = dr["Discription"].ToString(), Name = dr["Name"].ToString(), pk_corp = dr["pk_corp"].ToString() };
        }

        public override SFTypeModel GetModel(DB_OPT dbo)
        {
            new SFTypeModel();
            StringBuilder builder = new StringBuilder();
            builder.Append("select ");
            builder.Append(" PK,Name,Discription,pk_corp ");
            builder.Append(" from GOV_TC_DB_SFType ");
            builder.Append(" where PK='" + base.PK + "' ");
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
            builder.Append("update GOV_TC_DB_SFType set ");
            builder.Append("pk_corp='" + base.pk_corp + "',");
            builder.Append("Name='" + base.Name + "',");
            builder.Append("Discription='" + base.Discription + "'");
            builder.Append(" where PK='" + base.PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

