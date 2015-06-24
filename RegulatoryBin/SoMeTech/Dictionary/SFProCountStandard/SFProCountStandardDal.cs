namespace SoMeTech.Dictionary.SFProCountStandard
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class SFProCountStandardDal
    {
        public int Add(SFProCountStandardModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();
            StringBuilder builder3 = new StringBuilder();
            if (model.PK != null)
            {
                builder2.Append("PK,");
                builder3.Append("'" + model.PK + "',");
            }
            if (model.SFPROJECTPK != null)
            {
                builder2.Append("SFPROJECTPK,");
                builder3.Append("'" + model.SFPROJECTPK + "',");
            }
            if (model.COUNTTYPENAME != null)
            {
                builder2.Append("COUNTTYPENAME,");
                builder3.Append("'" + model.COUNTTYPENAME + "',");
            }
            if (model.COUNTTYPEPK != null)
            {
                builder2.Append("COUNTTYPEPK,");
                builder3.Append("'" + model.COUNTTYPEPK + "',");
            }
            builder2.Append("STANDARDMIN,");
            builder3.Append(model.STANDARDMIN + ",");
            builder2.Append("STANDARDMAX,");
            builder3.Append(model.STANDARDMAX + ",");
            builder2.Append("COUNTSTANDARD,");
            builder3.Append(model.COUNTSTANDARD + ",");
            if (model.COMPANYPK != null)
            {
                builder2.Append("COMPANYPK,");
                builder3.Append("'" + model.COMPANYPK + "',");
            }
            if (model.BRANCHPK != null)
            {
                builder2.Append("BRANCHPK,");
                builder3.Append("'" + model.BRANCHPK + "',");
            }
            if (model.TACHEPK != null)
            {
                builder2.Append("TACHEPK,");
                builder3.Append("'" + model.TACHEPK + "',");
            }
            if (model.PAPERSPK != null)
            {
                builder2.Append("PAPERSPK,");
                builder3.Append("'" + model.PAPERSPK + "',");
            }
            if (model.POLICYGIST != null)
            {
                builder2.Append("POLICYGIST,");
                builder3.Append("'" + model.POLICYGIST + "',");
            }
            if (model.COLLECTOBJECTPK != null)
            {
                builder2.Append("COLLECTOBJECTPK,");
                builder3.Append("'" + model.COLLECTOBJECTPK + "',");
            }
            if (model.METERINGPK != null)
            {
                builder2.Append("METERINGPK,");
                builder3.Append("'" + model.METERINGPK + "',");
            }
            if (model.METERINGUNITPK != null)
            {
                builder2.Append("METERINGUNITPK,");
                builder3.Append("'" + model.METERINGUNITPK + "',");
            }
            if (model.REMARK != null)
            {
                builder2.Append("REMARK,");
                builder3.Append("'" + model.REMARK + "',");
            }
            if (model.MJ != null)
            {
                builder2.Append("MJ,");
                builder3.Append("'" + model.MJ + "',");
            }
            if (model.DJ != null)
            {
                builder2.Append("DJ,");
                builder3.Append("'" + model.DJ + "',");
            }
            if (model.JSJE != null)
            {
                builder2.Append("JSJE,");
                builder3.Append("'" + model.JSJE + "',");
            }
            builder.Append("insert into GOV_TC_DB_SFPROCOUNTSTANDARD(");
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
            builder.Append("delete from GOV_TC_DB_SFProCountStandard ");
            builder.Append(" where PK='" + PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Exists(string PK, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(PK) from GOV_TC_DB_SFProCountStandard");
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

        public SFProCountStandardModel GetModel(DataRow dr)
        {
            SFProCountStandardModel model = new SFProCountStandardModel {
                PK = dr["PK"].ToString(),
                SFPROJECTPK = dr["SFPROJECTPK"].ToString(),
                COUNTTYPENAME = dr["COUNTTYPENAME"].ToString(),
                COUNTTYPEPK = dr["COUNTTYPEPK"].ToString()
            };
            if (dr["STANDARDMIN"].ToString() != "")
            {
                model.STANDARDMIN = int.Parse(dr["STANDARDMIN"].ToString());
            }
            if (dr["STANDARDMAX"].ToString() != "")
            {
                model.STANDARDMAX = int.Parse(dr["STANDARDMAX"].ToString());
            }
            if (dr["COUNTSTANDARD"].ToString() != "")
            {
                model.COUNTSTANDARD = int.Parse(dr["COUNTSTANDARD"].ToString());
            }
            model.COMPANYPK = dr["COMPANYPK"].ToString();
            model.BRANCHPK = dr["BRANCHPK"].ToString();
            model.TACHEPK = dr["TACHEPK"].ToString();
            model.PAPERSPK = dr["PAPERSPK"].ToString();
            model.POLICYGIST = dr["POLICYGIST"].ToString();
            model.COLLECTOBJECTPK = dr["COLLECTOBJECTPK"].ToString();
            model.METERINGPK = dr["METERINGPK"].ToString();
            model.METERINGUNITPK = dr["METERINGUNITPK"].ToString();
            model.REMARK = dr["REMARK"].ToString();
            model.MJ = dr["MJ"].ToString();
            model.DJ = dr["DJ"].ToString();
            model.JSJE = dr["JSJE"].ToString();
            return model;
        }

        public SFProCountStandardModel GetModel(string PK, DB_OPT dbo)
        {
            string strSql = this.GetSql() + " where PK=:PK";
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char) };
            parameters[0].Value = PK;
            DataSet set = dbo.BackDataSet(strSql, parameters, "");
            if (set.Tables[0].Rows.Count > 0)
            {
                new SFProCountStandardModel();
                return this.GetModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public SFProCountStandardModel[] GetModels(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strWhere != "")
            {
                builder.Append(" where " + strWhere);
            }
            OracleParameter[] parameters = null;
            DataSet set = dbo.BackDataSet(builder.ToString(), parameters, "");
            SFProCountStandardModel[] modelArray = null;
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            modelArray = new SFProCountStandardModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new SFProCountStandardModel();
                modelArray[i] = this.GetModel(set.Tables[0].Rows[i]);
            }
            return modelArray;
        }

        public string GetSql()
        {
            return "select PK,SFPROJECTPK,COUNTTYPENAME,COUNTTYPEPK,STANDARDMIN,STANDARDMAX,COUNTSTANDARD,COMPANYPK,BRANCHPK,TACHEPK,PAPERSPK,POLICYGIST,COLLECTOBJECTPK,METERINGPK,METERINGUNITPK,REMARK,mj,dj,jsje FROM GOV_TC_DB_SFProCountStandard";
        }

        public static string GetViewSFCOUNTColumns()
        {
            return " PK,TACHEPK,TACHE,SFNAME,COUNTTYPENAME,SFPROJECTPK,COUNTPK,COUNTTYPEPK,STANDARDMIN,STANDARDMAX,POLICYGIST,COUNTREMARK,COUNTSTANDARD,MJ,DJ,JSJE,TAXFEEKINDPK,ISMUST,PAYORDER,SFREMARK,ISCANGETBEFOR,ISCANSETBACK,ISCANBZBACK,ZNJBZ,ISZNJ,COMPANYPK,COMPANY,BRANCHPK,BRANCH,PAPERSPK,PAPERS,COLLECTOBJECTPK,COLLECTOBJECT,COLLECTOBJECTTABLE,COLLECTOBJECTCOLUMNS,METERINGPK,METERINGNAME,METERINGTABLE,METERINGCOLUMN,METERINGREMARK,METERINGUNITPK,TABLEPK,COLUMNNAME,COLUMNREMARK,TACHETYPE,NAMEMJ,NAMEDJ,NAMEJSJE,COLMJ,COLDJ,COLJSJE ";
        }

        public static string GetViewSFPROCOUNTColumns()
        {
            return " PK,SFPROJECTPK,NAME,COUNTTYPENAME,COUNTSTANDARD,COMPANYPK,BRANCHPK,REMARK,ISCANGETBEFOR ";
        }

        public static string GetViewTAXFEESTANDARDColumns()
        {
            return " SFPROJECTPK,COUNTSTANDARDPK,EXECUTEPK,SFNAME,SFCODE,COUNTTYPENAME,COUNTTYPEPK,STANDARDMIN,STANDARDMAX,POLICYGIST,COUNTREMARK,COUNTSTANDARD,EXECUTESTANDARD,BUILDINGPROPK,EXECUTEREMARK,TAXFEEKINDPK,ISMUST,PAYORDER,SFREMARK,ISCANGETBEFOR,ISCANSETBACK,ISCANBZBACK,ISZNJ,ZNJBZ,COMPANYPK,BRANCHPK,TACHEPK,PAPERSPK,COLLECTOBJECTPK,METERINGPK,METERINGUNITPK ";
        }

        public int Update(SFProCountStandardModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update GOV_TC_DB_SFPROCOUNTSTANDARD set ");
            if (model.SFPROJECTPK != null)
            {
                builder.Append("SFPROJECTPK='" + model.SFPROJECTPK + "',");
            }
            if (model.COUNTTYPENAME != null)
            {
                builder.Append("COUNTTYPENAME='" + model.COUNTTYPENAME + "',");
            }
            if (model.COUNTTYPEPK != null)
            {
                builder.Append("COUNTTYPEPK='" + model.COUNTTYPEPK + "',");
            }
            builder.Append("STANDARDMIN=" + model.STANDARDMIN + ",");
            builder.Append("STANDARDMAX=" + model.STANDARDMAX + ",");
            builder.Append("COUNTSTANDARD=" + model.COUNTSTANDARD + ",");
            if (model.COMPANYPK != null)
            {
                builder.Append("COMPANYPK='" + model.COMPANYPK + "',");
            }
            if (model.BRANCHPK != null)
            {
                builder.Append("BRANCHPK='" + model.BRANCHPK + "',");
            }
            if (model.TACHEPK != null)
            {
                builder.Append("TACHEPK='" + model.TACHEPK + "',");
            }
            if (model.PAPERSPK != null)
            {
                builder.Append("PAPERSPK='" + model.PAPERSPK + "',");
            }
            if (model.POLICYGIST != null)
            {
                builder.Append("POLICYGIST='" + model.POLICYGIST + "',");
            }
            if (model.COLLECTOBJECTPK != null)
            {
                builder.Append("COLLECTOBJECTPK='" + model.COLLECTOBJECTPK + "',");
            }
            if (model.METERINGPK != null)
            {
                builder.Append("METERINGPK='" + model.METERINGPK + "',");
            }
            if (model.METERINGUNITPK != null)
            {
                builder.Append("METERINGUNITPK='" + model.METERINGUNITPK + "',");
            }
            if (model.REMARK != null)
            {
                builder.Append("REMARK='" + model.REMARK + "',");
            }
            if (model.MJ != null)
            {
                builder.Append("MJ='" + model.MJ + "',");
            }
            if (model.DJ != null)
            {
                builder.Append("DJ='" + model.DJ + "',");
            }
            if (model.JSJE != null)
            {
                builder.Append("JSJE='" + model.JSJE + "',");
            }
            int startIndex = builder.ToString().LastIndexOf(",");
            builder.Remove(startIndex, 1);
            builder.Append(" where PK='" + model.PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

