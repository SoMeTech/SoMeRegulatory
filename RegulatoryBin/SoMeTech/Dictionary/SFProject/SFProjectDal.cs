namespace SoMeTech.Dictionary.SFProject
{
    using SoMeTech.DataAccess;
    using SoMeTech.ServicesClass.Operation;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class SFProjectDal
    {
        public int Add(SFProjectModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();
            StringBuilder builder3 = new StringBuilder();
            if (model.PK != null)
            {
                builder2.Append("PK,");
                builder3.Append("'" + model.PK + "',");
            }
            if (model.BH != null)
            {
                builder2.Append("BH,");
                builder3.Append("'" + model.BH + "',");
            }
            if (model.SFCODE != null)
            {
                builder2.Append("SFCODE,");
                builder3.Append("'" + model.SFCODE + "',");
            }
            if (model.NAME != null)
            {
                builder2.Append("NAME,");
                builder3.Append("'" + model.NAME + "',");
            }
            if (model.TAXFEEKINDPK != null)
            {
                builder2.Append("TAXFEEKINDPK,");
                builder3.Append("'" + model.TAXFEEKINDPK + "',");
            }
            if (model.ISMUST != null)
            {
                builder2.Append("ISMUST,");
                builder3.Append("'" + model.ISMUST + "',");
            }
            if (model.PAYORDER.HasValue)
            {
                builder2.Append("PAYORDER,");
                builder3.Append(model.PAYORDER + ",");
            }
            if (model.REMARK != null)
            {
                builder2.Append("REMARK,");
                builder3.Append("'" + model.REMARK + "',");
            }
            if (model.ISCANGETBEFOR != null)
            {
                builder2.Append("ISCANGETBEFOR,");
                builder3.Append("'" + model.ISCANGETBEFOR + "',");
            }
            if (model.ISCANSETBACK != null)
            {
                builder2.Append("ISCANSETBACK,");
                builder3.Append("'" + model.ISCANSETBACK + "',");
            }
            if (model.ISCANBZBACK != null)
            {
                builder2.Append("ISCANBZBACK,");
                builder3.Append("'" + model.ISCANBZBACK + "',");
            }
            if (model.ISYJJE != null)
            {
                builder2.Append("ISYJJE,");
                builder3.Append("'" + model.ISYJJE + "',");
            }
            if (model.ISZNJ != null)
            {
                builder2.Append("ISZNJ,");
                builder3.Append("'" + model.ISZNJ + "',");
            }
            if (model.ZNJBZ.HasValue)
            {
                builder2.Append("ZNJBZ,");
                builder3.Append(model.ZNJBZ + ",");
            }
            if (model.UNITTYPEPK != null)
            {
                builder2.Append("UNITTYPEPK,");
                builder3.Append("'" + model.UNITTYPEPK + "',");
            }
            builder.Append("insert into GOV_TC_DB_SFPROJECT(");
            builder.Append(builder2.ToString().Remove(builder2.Length - 1));
            builder.Append(")");
            builder.Append(" values (");
            builder.Append(builder3.ToString().Remove(builder3.Length - 1));
            builder.Append(")");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Delete(string PK, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from GOV_TC_DB_SFProject ");
            builder.Append(" where PK='" + PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Delete_Proc(string PK, DB_OPT dbo)
        {
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter("sfpk", OracleType.Char, 40) };
            parameters[0].Value = PK;
            return dbo.BuildQueryCommand("PROC_DELETESFPRO", parameters);
        }

        public int Exists(string PK, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(PK) from GOV_TC_DB_SFProject");
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

        public SFProjectModel GetModel(DataRow dr)
        {
            SFProjectModel model = new SFProjectModel {
                PK = dr["PK"].ToString(),
                BH = dr["BH"].ToString(),
                SFCODE = dr["SFCODE"].ToString(),
                NAME = dr["NAME"].ToString(),
                TAXFEEKINDPK = dr["TAXFEEKINDPK"].ToString(),
                ISMUST = dr["ISMUST"].ToString()
            };
            if (dr["PAYORDER"].ToString() != "")
            {
                model.PAYORDER = new int?(int.Parse(dr["PAYORDER"].ToString()));
            }
            if (dr["ZNJBZ"].ToString() != "")
            {
                model.ZNJBZ = new decimal?(int.Parse(dr["ZNJBZ"].ToString()));
            }
            model.REMARK = dr["REMARK"].ToString();
            model.ISCANGETBEFOR = dr["ISCANGETBEFOR"].ToString();
            model.ISYJJE = dr["ISYJJE"].ToString();
            model.ISCANSETBACK = dr["ISCANSETBACK"].ToString();
            model.ISCANBZBACK = dr["ISCANBZBACK"].ToString();
            model.ISZNJ = dr["ISZNJ"].ToString();
            model.UNITTYPEPK = dr["UNITTYPEPK"].ToString();
            return model;
        }

        public SFProjectModel GetModel(string PK, DB_OPT dbo)
        {
            string strSql = this.GetSql() + " where PK=:PK";
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char) };
            parameters[0].Value = PK;
            DataSet set = dbo.BackDataSet(strSql, parameters, "");
            if (set.Tables[0].Rows.Count > 0)
            {
                new SFProjectModel();
                return this.GetModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public SFProjectModel[] GetModels(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strWhere != "")
            {
                builder.Append(" where " + strWhere);
            }
            OracleParameter[] parameters = null;
            DataSet set = dbo.BackDataSet(builder.ToString(), parameters, "");
            SFProjectModel[] modelArray = null;
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            modelArray = new SFProjectModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new SFProjectModel();
                modelArray[i] = this.GetModel(set.Tables[0].Rows[i]);
            }
            return modelArray;
        }

        public string GetSql()
        {
            return "select PK,BH,NAME,TAXFEEKINDPK,ISMUST,PAYORDER,REMARK,ISCANGETBEFOR,SFCODE,ZNJBZ,ISCANSETBACK,ISCANBZBACK,ISZNJ,UNITTYPEPK,ISYJJE FROM GOV_TC_DB_SFProject";
        }

        public static SFProjectModel[] GetTacheSFMessByTachePK(string TachePK, DB_OPT dbo)
        {
            string strSql = "select distinct SFPROJECTPK,NAME from GOV_TC_VIEW_SFPROCOUNTSTANDARD where TACHEPK='" + TachePK + "'";
            DataSet set = dbo.BackDataSet(strSql, null);
            SFProjectModel[] modelArray = null;
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                modelArray = new SFProjectModel[set.Tables[0].Rows.Count];
                for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                {
                    modelArray[i] = new SFProjectModel();
                    modelArray[i].PK = set.Tables[0].Rows[0]["SFPROJECTPK"].ToString();
                    modelArray[i].NAME = set.Tables[0].Rows[0]["NAME"].ToString();
                }
            }
            return modelArray;
        }

       

        public static string GetViewSFPROJECTColumns()
        {
            return " PK,BH,NAME,TAXFEEKINDPK,SFKIND,UNITTYPENAME,ISMUST,PAYORDER,REMARK,ISCANGETBEFOR,ISCANSETBACK,ISCANBZBACK,SFCODE,ZNJBZ,ISZNJ,UNITTYPEPK,ISYJJE,UNITBH,UNITNAME ";
        }

        public static string GetViewTAXFEECOLLECTIONColumns()
        {
            return " SFPROJECTPK,COUNTSTANDARDPK,EXECUTEPK,SFCODE,ZNJBZ,SFNAME,COUNTTYPENAME,COUNTTYPEPK,STANDARDMIN,STANDARDMAX,POLICYGIST,COUNTREMARK,COUNTSTANDARD,EXECUTESTANDARD,BUILDINGPROPK,EXECUTEREMARK,TAXFEEKINDPK,ISMUST,PAYORDER,SFREMARK,ISCANGETBEFOR,ISCANSETBACK,ISCANBZBACK,ISZNJ,ISYJJE,COMPANYPK,COMPANY,BRANCHPK,BRANCH,TACHEPK,TACHE,PAPERSPK,PAPERS,COLLECTOBJECTPK,COLLECTOBJECT,COLLECTOBJECTTABLE,COLLECTOBJECTCOLUMNS,METERINGPK,METERINGNAME,METERINGTABLE,METERINGCOLUMN,METERINGREMARK,METERINGUNITPK,TABLEPK,COLUMNNAME,COLUMNREMARK,UNITBH,UNITNAME ";
        }

        public int Update(SFProjectModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update GOV_TC_DB_SFPROJECT set ");
            if (model.BH != null)
            {
                builder.Append("BH='" + model.BH + "',");
            }
            if (model.SFCODE != null)
            {
                builder.Append("SFCODE='" + model.SFCODE + "',");
            }
            if (model.NAME != null)
            {
                builder.Append("NAME='" + model.NAME + "',");
            }
            if (model.TAXFEEKINDPK != null)
            {
                builder.Append("TAXFEEKINDPK='" + model.TAXFEEKINDPK + "',");
            }
            if (model.ISMUST != null)
            {
                builder.Append("ISMUST='" + model.ISMUST + "',");
            }
            if (model.PAYORDER.HasValue)
            {
                builder.Append("PAYORDER=" + model.PAYORDER + ",");
            }
            if (model.REMARK != null)
            {
                builder.Append("REMARK='" + model.REMARK + "',");
            }
            if (model.ISCANGETBEFOR != null)
            {
                builder.Append("ISCANGETBEFOR='" + model.ISCANGETBEFOR + "',");
            }
            if (model.ISCANSETBACK != null)
            {
                builder.Append("ISCANSETBACK='" + model.ISCANSETBACK + "',");
            }
            if (model.ISCANBZBACK != null)
            {
                builder.Append("ISCANBZBACK='" + model.ISCANBZBACK + "',");
            }
            if (model.ISYJJE != null)
            {
                builder.Append("ISYJJE='" + model.ISYJJE + "',");
            }
            if (model.ISZNJ != null)
            {
                builder.Append("ISZNJ='" + model.ISZNJ + "',");
            }
            if (model.ZNJBZ.HasValue)
            {
                builder.Append("ZNJBZ=" + model.ZNJBZ + ",");
            }
            if (model.UNITTYPEPK != null)
            {
                builder.Append("UNITTYPEPK='" + model.UNITTYPEPK + "',");
            }
            int startIndex = builder.ToString().LastIndexOf(",");
            builder.Remove(startIndex, 1);
            builder.Append(" where PK='" + model.PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

