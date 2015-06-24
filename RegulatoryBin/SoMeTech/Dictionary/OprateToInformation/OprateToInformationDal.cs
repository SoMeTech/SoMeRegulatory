namespace SoMeTech.Dictionary.OprateToInformation
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class OprateToInformationDal
    {
        public int Add(OprateToInformationModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into GOV_TC_DB_OPRATETOINFORMATION(");
            builder.Append("COMPANYPK,OPRATETACHEPK,BUILDINGPROPK,PAPERSPK,NAME,IFMUST,REMARK");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + model.COMPANYPK + "',");
            builder.Append("'" + model.OPRATETACHEPK + "',");
            builder.Append("'" + model.BUILDINGPROPK + "',");
            builder.Append("'" + model.PAPERSPK + "',");
            builder.Append("'" + model.NAME + "',");
            builder.Append("'" + model.IFMUST + "',");
            builder.Append("'" + model.REMARK + "'");
            builder.Append(")");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Delete(string PK, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete GOV_TC_DB_OprateToInformation ");
            builder.Append(" where PK='" + PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Exists(string PK, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(PK) from GOV_TC_DB_OprateToInformation");
            builder.Append(" where PK= :PK");
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

        public OprateToInformationModel GetModel(DataRow dr)
        {
            return new OprateToInformationModel { PK = dr["PK"].ToString(), NAME = dr["NAME"].ToString(), PAPERSPK = dr["PAPERSPK"].ToString(), REMARK = dr["REMARK"].ToString(), IFMUST = dr["IFMUST"].ToString(), OPRATETACHEPK = dr["OPRATETACHEPK"].ToString(), BUILDINGPROPK = dr["BUILDINGPROPK"].ToString(), COMPANYPK = dr["COMPANYPK"].ToString() };
        }

        public OprateToInformationModel GetModel(string PK, DB_OPT dbo)
        {
            string strSql = this.GetSql() + " where PK=:PK";
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char) };
            parameters[0].Value = PK;
            DataSet set = dbo.BackDataSet(strSql, parameters, "");
            if (set.Tables[0].Rows.Count > 0)
            {
                new OprateToInformationModel();
                return this.GetModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public OprateToInformationModel[] GetModels(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strWhere != "")
            {
                builder.Append(" where " + strWhere);
            }
            OracleParameter[] parameters = null;
            DataSet set = dbo.BackDataSet(builder.ToString(), parameters, "");
            OprateToInformationModel[] modelArray = null;
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            modelArray = new OprateToInformationModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new OprateToInformationModel();
                modelArray[i] = this.GetModel(set.Tables[0].Rows[i]);
            }
            return modelArray;
        }

        public string GetSql()
        {
            return "select PK,COMPANYPK,OPRATETACHEPK,BUILDINGPROPK,PAPERSPK,NAME,IFMUST,REMARK FROM GOV_TC_DB_OprateToInformation";
        }

        public DataSet GetViewList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,PAPERSPK,OPRATETACHEPK,BUILDINGPROPK,NAME,COMPANYPK,REMARK,PAPERSNAME,COMPANYNAME,OPRATETACHENAME,BUILDINGPRONAME,IFMUST,IsMUST from GOV_TC_VIEW_OPRATETOINFO");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public int Update(OprateToInformationModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update GOV_TC_DB_OPRATETOINFORMATION set ");
            builder.Append("COMPANYPK='" + model.COMPANYPK + "',");
            builder.Append("OPRATETACHEPK='" + model.OPRATETACHEPK + "',");
            builder.Append("BUILDINGPROPK='" + model.BUILDINGPROPK + "',");
            builder.Append("PAPERSPK='" + model.PAPERSPK + "',");
            builder.Append("NAME='" + model.NAME + "',");
            builder.Append("IFMUST='" + model.IFMUST + "',");
            builder.Append("REMARK='" + model.REMARK + "'");
            builder.Append(" where PK='" + model.PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

