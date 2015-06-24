namespace SoMeTech.CommonDll.Configuration
{
       using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class ConfigurationDal
    {
        public int Add(ConfigurationModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();
            StringBuilder builder3 = new StringBuilder();
            if (model.PK != null)
            {
                builder2.Append("PK,");
                builder3.Append("'" + model.PK + "',");
            }
            if (model.SERVICENAME != null)
            {
                builder2.Append("SERVICENAME,");
                builder3.Append("'" + model.SERVICENAME + "',");
            }
            if (model.USERNAME != null)
            {
                builder2.Append("USERNAME,");
                builder3.Append("'" + model.USERNAME + "',");
            }
            if (model.PASSWORD != null)
            {
                builder2.Append("PASSWORD,");
                builder3.Append("'" + model.PASSWORD + "',");
            }
            if (model.MENUNODENAME != null)
            {
                builder2.Append("MENUNODENAME,");
                builder3.Append("'" + model.MENUNODENAME + "',");
            }
            if (model.MENUNODEVALUE != null)
            {
                builder2.Append("MENUNODEVALUE,");
                builder3.Append("'" + model.MENUNODEVALUE + "',");
            }
            if (model.IFOPENEXCEPTIONLOG != null)
            {
                builder2.Append("IFOPENEXCEPTIONLOG,");
                builder3.Append("'" + model.IFOPENEXCEPTIONLOG + "',");
            }
            if (model.IFOPENOPLOG != null)
            {
                builder2.Append("IFOPENOPLOG,");
                builder3.Append("'" + model.IFOPENOPLOG + "',");
            }
            if (model.PAGESIZETWO.HasValue)
            {
                builder2.Append("PAGESIZETWO,");
                builder3.Append(model.PAGESIZETWO + ",");
            }
            if (model.PAGESIZEONE.HasValue)
            {
                builder2.Append("PAGESIZEONE,");
                builder3.Append(model.PAGESIZEONE + ",");
            }
            if (model.ErrMessPath != null)
            {
                builder2.Append("ERRMESSPATH,");
                builder3.Append("'" + model.ErrMessPath + "',");
            }
            if (model.MASTERPAGETWO != null)
            {
                builder2.Append("MASTERPAGETWO,");
                builder3.Append("'" + model.MASTERPAGETWO + "',");
            }
            if (model.MASTERPAGEONE != null)
            {
                builder2.Append("MASTERPAGEONE,");
                builder3.Append("'" + model.MASTERPAGEONE + "',");
            }
            if (model.STARTYEAR != null)
            {
                builder2.Append("STARTYEAR,");
                builder3.Append("'" + model.STARTYEAR + "',");
            }
            if (model.STARTNUM != null)
            {
                builder2.Append("STARTNUM,");
                builder3.Append("'" + model.STARTNUM + "',");
            }
            if (model.SERVICEIP != null)
            {
                builder2.Append("SERVICEIP,");
                builder3.Append("'" + model.SERVICEIP + "',");
            }
            if (model.SOILGETNUM != null)
            {
                builder2.Append("SOILGETNUM,");
                builder3.Append("'" + model.SOILGETNUM + "',");
            }
            if (model.SOILOUTNUM != null)
            {
                builder2.Append("SOILOUTNUM,");
                builder3.Append("'" + model.SOILOUTNUM + "',");
            }
            if (model.SOILZHUANNUM != null)
            {
                builder2.Append("SOILZHUANNUM,");
                builder3.Append("'" + model.SOILZHUANNUM + "',");
            }
            if (model.PLANNUM != null)
            {
                builder2.Append("PLANNUM,");
                builder3.Append("'" + model.PLANNUM + "',");
            }
            if (model.BUILDINGNUM != null)
            {
                builder2.Append("BUILDINGNUM,");
                builder3.Append("'" + model.BUILDINGNUM + "',");
            }
            if (model.FINISHNUM != null)
            {
                builder2.Append("FINISHNUM,");
                builder3.Append("'" + model.FINISHNUM + "',");
            }
            if (model.HOUSENEWNUM != null)
            {
                builder2.Append("HOUSENEWNUM,");
                builder3.Append("'" + model.HOUSENEWNUM + "',");
            }
            if (model.HOUSESENNUM != null)
            {
                builder2.Append("HOUSESENNUM,");
                builder3.Append("'" + model.HOUSESENNUM + "',");
            }
            if (model.ISCHANGELIST != null)
            {
                builder2.Append("ISCHANGELIST,");
                builder3.Append("'" + model.ISCHANGELIST + "',");
            }
            if (model.ISPRINT != null)
            {
                builder2.Append("ISPRINT,");
                builder3.Append("'" + model.ISPRINT + "',");
            }
            if (model.GSZZSJS.HasValue)
            {
                builder2.Append("GSZZSJS,");
                builder3.Append(model.GSZZSJS.ToString() + ",");
            }
            if (model.TQNUM != null)
            {
                builder2.Append("TQNUM,");
                builder3.Append("'" + model.TQNUM + "',");
            }
            if (model.ISGATHERING != null)
            {
                builder2.Append("ISGATHERING,");
                builder3.Append("'" + model.ISGATHERING + "',");
            }
            if (model.ISAUTOTABLE != null)
            {
                builder2.Append("ISAUTOTABLE,");
                builder3.Append("'" + model.ISAUTOTABLE + "',");
            }
            builder.Append("insert into DB_CONFIGURATION(");
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
            builder.Append("delete DB_CONFIGURATION ");
            builder.Append(" where PK='" + PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Exists(string PK, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(PK) from DB_CONFIGURATION");
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

        public ConfigurationModel GetModel(DB_OPT dbo)
        {
            string sql = this.GetSql();
            DataSet set = dbo.BackDataSet(sql, null);
            if (set.Tables[0].Rows.Count > 0)
            {
                new ConfigurationModel();
                return this.GetModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public ConfigurationModel GetModel(DataRow dr)
        {
            ConfigurationModel model = new ConfigurationModel {
                PK = dr["PK"].ToString(),
                SERVICENAME = dr["SERVICENAME"].ToString(),
                USERNAME = dr["USERNAME"].ToString(),
                PASSWORD = dr["PASSWORD"].ToString(),
                MENUNODENAME = dr["MENUNODENAME"].ToString(),
                MENUNODEVALUE = dr["MENUNODEVALUE"].ToString(),
                IFOPENEXCEPTIONLOG = dr["IFOPENEXCEPTIONLOG"].ToString(),
                IFOPENOPLOG = dr["IFOPENOPLOG"].ToString()
            };
            if (dr["PAGESIZETWO"].ToString() != "")
            {
                model.PAGESIZETWO = new int?(int.Parse(dr["PAGESIZETWO"].ToString()));
            }
            if (dr["PAGESIZEONE"].ToString() != "")
            {
                model.PAGESIZEONE = new int?(int.Parse(dr["PAGESIZEONE"].ToString()));
            }
            model.ErrMessPath = dr["ERRMESSPATH"].ToString();
            model.MASTERPAGETWO = dr["MASTERPAGETWO"].ToString();
            model.MASTERPAGEONE = dr["MASTERPAGEONE"].ToString();
            model.STARTYEAR = dr["STARTYEAR"].ToString();
            model.STARTNUM = dr["STARTNUM"].ToString();
            model.SERVICEIP = dr["SERVICEIP"].ToString();
            model.SOILGETNUM = dr["SOILGETNUM"].ToString();
            model.SOILOUTNUM = dr["SOILOUTNUM"].ToString();
            model.SOILZHUANNUM = dr["SOILZHUANNUM"].ToString();
            model.PLANNUM = dr["PLANNUM"].ToString();
            model.BUILDINGNUM = dr["BUILDINGNUM"].ToString();
            model.FINISHNUM = dr["FINISHNUM"].ToString();
            model.HOUSENEWNUM = dr["HOUSENEWNUM"].ToString();
            model.HOUSESENNUM = dr["HOUSESENNUM"].ToString();
            model.ISCHANGELIST = dr["ISCHANGELIST"].ToString();
            model.ISPRINT = dr["ISPRINT"].ToString();
            if (dr["GSZZSJS"].ToString() != "")
            {
                model.GSZZSJS = new decimal?(decimal.Parse(dr["GSZZSJS"].ToString()));
            }
            model.TQNUM = dr["TQNUM"].ToString();
            model.ISGATHERING = dr["ISGATHERING"].ToString();
            model.ISAUTOTABLE = dr["ISAUTOTABLE"].ToString();
            return model;
        }

        public ConfigurationModel[] GetModels(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strWhere != "")
            {
                builder.Append(" where " + strWhere);
            }
            OracleParameter[] parameters = null;
            DataSet set = dbo.BackDataSet(builder.ToString(), parameters, "");
            ConfigurationModel[] modelArray = null;
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            modelArray = new ConfigurationModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new ConfigurationModel();
                modelArray[i] = this.GetModel(set.Tables[0].Rows[i]);
            }
            return modelArray;
        }

        public string GetSql()
        {
            return "select PK,SERVICENAME,USERNAME,PASSWORD,MENUNODENAME,MENUNODEVALUE,IFOPENEXCEPTIONLOG,IFOPENOPLOG,PAGESIZETWO,PAGESIZEONE,ERRMESSPATH,MASTERPAGETWO,MASTERPAGEONE,STARTYEAR,STARTNUM,SERVICEIP,SOILGETNUM,SOILOUTNUM,SOILZHUANNUM,PLANNUM,BUILDINGNUM,FINISHNUM,HOUSENEWNUM,HOUSESENNUM,ISCHANGELIST,ISPRINT,GSZZSJS,TQNUM,ISGATHERING,ISAUTOTABLE FROM DB_CONFIGURATION";
        }

        public int Update(ConfigurationModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_CONFIGURATION set ");
            if (model.SERVICENAME != null)
            {
                builder.Append("SERVICENAME='" + model.SERVICENAME + "',");
            }
            if (model.USERNAME != null)
            {
                builder.Append("USERNAME='" + model.USERNAME + "',");
            }
            if (model.PASSWORD != null)
            {
                builder.Append("PASSWORD='" + model.PASSWORD + "',");
            }
            if (model.MENUNODENAME != null)
            {
                builder.Append("MENUNODENAME='" + model.MENUNODENAME + "',");
            }
            if (model.MENUNODEVALUE != null)
            {
                builder.Append("MENUNODEVALUE='" + model.MENUNODEVALUE + "',");
            }
            if (model.IFOPENEXCEPTIONLOG != null)
            {
                builder.Append("IFOPENEXCEPTIONLOG='" + model.IFOPENEXCEPTIONLOG + "',");
            }
            if (model.IFOPENOPLOG != null)
            {
                builder.Append("IFOPENOPLOG='" + model.IFOPENOPLOG + "',");
            }
            if (model.PAGESIZETWO.HasValue)
            {
                builder.Append("PAGESIZETWO=" + model.PAGESIZETWO + ",");
            }
            if (model.PAGESIZEONE.HasValue)
            {
                builder.Append("PAGESIZEONE=" + model.PAGESIZEONE + ",");
            }
            if (model.ErrMessPath != null)
            {
                builder.Append("ERRMESSPATH='" + model.ErrMessPath + "',");
            }
            if (model.MASTERPAGETWO != null)
            {
                builder.Append("MASTERPAGETWO='" + model.MASTERPAGETWO + "',");
            }
            if (model.MASTERPAGEONE != null)
            {
                builder.Append("MASTERPAGEONE='" + model.MASTERPAGEONE + "',");
            }
            if (model.STARTYEAR != null)
            {
                builder.Append("STARTYEAR='" + model.STARTYEAR + "',");
            }
            if (model.STARTNUM != null)
            {
                builder.Append("STARTNUM='" + model.STARTNUM + "',");
            }
            if (model.SERVICEIP != null)
            {
                builder.Append("SERVICEIP='" + model.SERVICEIP + "',");
            }
            if (model.SOILGETNUM != null)
            {
                builder.Append("SOILGETNUM='" + model.SOILGETNUM + "',");
            }
            if (model.SOILOUTNUM != null)
            {
                builder.Append("SOILOUTNUM='" + model.SOILOUTNUM + "',");
            }
            if (model.SOILZHUANNUM != null)
            {
                builder.Append("SOILZHUANNUM='" + model.SOILZHUANNUM + "',");
            }
            if (model.PLANNUM != null)
            {
                builder.Append("PLANNUM='" + model.PLANNUM + "',");
            }
            if (model.BUILDINGNUM != null)
            {
                builder.Append("BUILDINGNUM='" + model.BUILDINGNUM + "',");
            }
            if (model.FINISHNUM != null)
            {
                builder.Append("FINISHNUM='" + model.FINISHNUM + "',");
            }
            if (model.HOUSENEWNUM != null)
            {
                builder.Append("HOUSENEWNUM='" + model.HOUSENEWNUM + "',");
            }
            if (model.HOUSESENNUM != null)
            {
                builder.Append("HOUSESENNUM='" + model.HOUSESENNUM + "',");
            }
            if (model.ISCHANGELIST != null)
            {
                builder.Append("ISCHANGELIST='" + model.ISCHANGELIST + "',");
            }
            if (model.ISPRINT != null)
            {
                builder.Append("ISPRINT='" + model.ISPRINT + "',");
            }
            if (model.GSZZSJS.HasValue)
            {
                builder.Append("GSZZSJS=" + model.GSZZSJS + ",");
            }
            if (model.TQNUM != null)
            {
                builder.Append("TQNUM='" + model.TQNUM + "',");
            }
            if (model.ISGATHERING != null)
            {
                builder.Append("ISGATHERING='" + model.ISGATHERING + "',");
            }
            if (model.ISAUTOTABLE != null)
            {
                builder.Append("ISAUTOTABLE='" + model.ISAUTOTABLE + "',");
            }
            int startIndex = builder.ToString().LastIndexOf(",");
            builder.Remove(startIndex, 1);
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Update(string year, string num, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_CONFIGURATION set ");
            builder.Append("STARTYEAR='" + year + "',");
            builder.Append("STARTNUM='" + num + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Update(string tacheNo, string year, string num, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_CONFIGURATION set ");
            builder.Append("STARTYEAR='" + year + "',");
            switch (tacheNo)
            {
                case "01":
                    builder.Append("SOILGETNUM='" + num + "'");
                    break;

                case "02":
                    builder.Append("SOILOUTNUM='" + num + "'");
                    break;

                case "03":
                    builder.Append("SOILZHUANNUM='" + num + "'");
                    break;

                case "04":
                    builder.Append("PLANNUM='" + num + "'");
                    break;

                case "05":
                    builder.Append("BUILDINGNUM='" + num + "'");
                    break;

                case "06":
                    builder.Append("FINISHNUM='" + num + "'");
                    break;

                case "07":
                    builder.Append("HOUSENEWNUM='" + num + "'");
                    break;

                case "08":
                    builder.Append("HOUSESENNUM='" + num + "'");
                    break;

                case "09":
                    builder.Append("TQNUM='" + num + "'");
                    break;
            }
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

