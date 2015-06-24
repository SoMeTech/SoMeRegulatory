namespace SoMeTech.Dictionary.SFProExecuteStandard
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class SFProExecuteStandardDal
    {
        public int Add(SFProExecuteStandardModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into GOV_TC_DB_SFProExecuteStandard(");
            builder.Append("SFProjectPK,CountStandardPK,BuildingProPK,ExecuteStandard,Remark");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + model.SFProjectPK + "',");
            builder.Append("'" + model.CountStandardPK + "',");
            builder.Append("'" + model.BuildingProPK + "',");
            builder.Append(model.ExecuteStandard + ",");
            builder.Append("'" + model.Remark + "'");
            builder.Append(")");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Delete(string PK, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete GOV_TC_DB_SFProExecuteStandard ");
            builder.Append(" where PK='" + PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Exists(string PK, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(PK) from GOV_TC_DB_SFProExecuteStandard");
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

        public SFProExecuteStandardModel GetModel(DataRow dr)
        {
            SFProExecuteStandardModel model = new SFProExecuteStandardModel {
                PK = dr["PK"].ToString(),
                BuildingProPK = dr["BuildingProPK"].ToString(),
                CountStandardPK = dr["CountStandardPK"].ToString(),
                SFProjectPK = dr["SFProjectPK"].ToString()
            };
            if (dr["ExecuteStandard"].ToString() != "")
            {
                model.ExecuteStandard = decimal.Parse(dr["ExecuteStandard"].ToString());
            }
            model.Remark = dr["Remark"].ToString();
            return model;
        }

        public SFProExecuteStandardModel GetModel(string PK, DB_OPT dbo)
        {
            string strSql = this.GetSql() + " where PK=:PK";
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char) };
            parameters[0].Value = PK;
            DataSet set = dbo.BackDataSet(strSql, parameters, "");
            if (set.Tables[0].Rows.Count > 0)
            {
                new SFProExecuteStandardModel();
                return this.GetModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public SFProExecuteStandardModel[] GetModels(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strWhere != "")
            {
                builder.Append(" where " + strWhere);
            }
            OracleParameter[] parameters = null;
            DataSet set = dbo.BackDataSet(builder.ToString(), parameters, "");
            SFProExecuteStandardModel[] modelArray = null;
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            modelArray = new SFProExecuteStandardModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new SFProExecuteStandardModel();
                modelArray[i] = this.GetModel(set.Tables[0].Rows[i]);
            }
            return modelArray;
        }

        public string GetSql()
        {
            return "select PK,SFProjectPK,CountStandardPK,BuildingProPK,ExecuteStandard,Remark FROM GOV_TC_DB_SFProExecuteStandard";
        }

        public DataSet GetViewList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetViewSql());
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public DataSet GetViewList(string Columns, string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Columns);
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public static string GetViewSFPROEXECUTEColumns()
        {
            return " PK,SFPROJECTNAME,COUNTTYPENAME,COMPANYPK,BRANCHPK,JZXMNAME,SFPROJECTPK,COUNTSTANDARDPK,BUILDINGPROPK,EXECUTESTANDARD,REMARK,ISCANGETBEFOR ";
        }

        public string GetViewSql()
        {
            return "select PK,SFPROJECTNAME,COUNTTYPENAME,COMPANYPK,BRANCHPK,JZXMNAME,SFPROJECTPK,COUNTSTANDARDPK,BUILDINGPROPK,EXECUTESTANDARD,REMARK,ISCANGETBEFOR from GOV_TC_VIEW_SFPROEXECUTE";
        }

        public static string GetViewTAXFEECOLLECTIONColumns()
        {
            return " SFPROJECTPK,COUNTSTANDARDPK,EXECUTEPK,SFCODE,ZNJBZ,SFNAME,COUNTTYPENAME,COUNTTYPEPK,STANDARDMIN,STANDARDMAX,POLICYGIST,COUNTREMARK,COUNTSTANDARD,EXECUTESTANDARD,BUILDINGPROPK,EXECUTEREMARK,TAXFEEKINDPK,ISMUST,PAYORDER,SFREMARK,ISCANGETBEFOR,ISCANSETBACK,ISCANBZBACK,ISZNJ,ISYJJE,COMPANYPK,COMPANY,BRANCHPK,BRANCH,TACHEPK,TACHE,PAPERSPK,PAPERS,COLLECTOBJECTPK,COLLECTOBJECT,COLLECTOBJECTTABLE,COLLECTOBJECTCOLUMNS,METERINGPK,METERINGNAME,METERINGTABLE,METERINGCOLUMN,METERINGREMARK,METERINGUNITPK,TABLEPK,COLUMNNAME,COLUMNREMARK,UNITBH,UNITNAME ";
        }

        public int Update(SFProExecuteStandardModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update GOV_TC_DB_SFProExecuteStandard set ");
            builder.Append("SFProjectPK='" + model.SFProjectPK + "',");
            builder.Append("CountStandardPK='" + model.CountStandardPK + "',");
            builder.Append("BuildingProPK='" + model.BuildingProPK + "',");
            builder.Append("ExecuteStandard=" + model.ExecuteStandard + ",");
            builder.Append("Remark='" + model.Remark + "'");
            builder.Append(" where PK='" + model.PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

