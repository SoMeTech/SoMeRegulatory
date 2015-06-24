namespace SoMeTech.Dictionary.LDJGXZ
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class LDJGDal
    {
        public int Add(LDJGModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into " + model.TableName + "(");
            builder.Append("TYPE,QYFW,TPK,TBH,TNAME,ZFMINVALUE,ZFMAXVALUE,ZFDEFVALUE,FZFMINVALUE,FZFMAXVALUE,FZFDEFVALUE,LDPK,LDMC");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + model.Type + "',");
            builder.Append("'" + model.QYFW + "',");
            builder.Append("'" + model.TPK + "',");
            builder.Append("'" + model.TBH + "',");
            builder.Append("'" + model.TNAME + "',");
            builder.Append(model.ZFMinValue + ",");
            builder.Append(model.ZFMaxValue + ",");
            builder.Append(model.ZFDefValue + ",");
            builder.Append(model.FZFMinValue + ",");
            builder.Append(model.FZFMaxValue + ",");
            builder.Append(model.FZFDefValue + ",");
            builder.Append("'" + model.LDPK + "',");
            builder.Append("'" + model.LDMC + "'");
            builder.Append(")");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Delete(string PK, string tablename, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from " + tablename);
            builder.Append(" where PK='" + PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Exists(string PK, string tablename, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(PK) from " + tablename);
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char) };
            parameters[0].Value = PK;
            return dbo.BackIsSelect(builder.ToString(), parameters, "");
        }

        public DataSet GetList(string strWhere, string tablename, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql(tablename));
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public LDJGModel GetModel(DataRow dr)
        {
            LDJGModel model = new LDJGModel {
                PK = dr["PK"].ToString(),
                Type = dr["Type"].ToString(),
                QYFW = dr["QYFW"].ToString(),
                TPK = dr["TPK"].ToString(),
                TBH = dr["TBH"].ToString(),
                TNAME = dr["TNAME"].ToString(),
                LDPK = dr["LDPK"].ToString(),
                LDMC = dr["LDMC"].ToString()
            };
            if (dr["ZFMinValue"].ToString() != "")
            {
                model.ZFMinValue = new decimal?(decimal.Parse(dr["ZFMinValue"].ToString()));
            }
            if (dr["ZFMaxValue"].ToString() != "")
            {
                model.ZFMaxValue = new decimal?(decimal.Parse(dr["ZFMaxValue"].ToString()));
            }
            if (dr["ZFDefValue"].ToString() != "")
            {
                model.ZFDefValue = new decimal?(decimal.Parse(dr["ZFDefValue"].ToString()));
            }
            if (dr["FZFMinValue"].ToString() != "")
            {
                model.FZFMinValue = new decimal?(decimal.Parse(dr["FZFMinValue"].ToString()));
            }
            if (dr["FZFMaxValue"].ToString() != "")
            {
                model.FZFMaxValue = new decimal?(decimal.Parse(dr["FZFMaxValue"].ToString()));
            }
            if (dr["FZFDefValue"].ToString() != "")
            {
                model.FZFDefValue = new decimal?(decimal.Parse(dr["FZFDefValue"].ToString()));
            }
            return model;
        }

        public LDJGModel GetModel(string PK, string tablename, DB_OPT dbo)
        {
            string strSql = this.GetSql(tablename) + " where PK=:PK";
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char) };
            parameters[0].Value = PK;
            DataSet set = dbo.BackDataSet(strSql, parameters, "");
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.GetModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public LDJGModel[] GetModels(string strWhere, string tablename, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql(tablename));
            if (strWhere != "")
            {
                builder.Append(" where " + strWhere);
            }
            OracleParameter[] parameters = null;
            DataSet set = dbo.BackDataSet(builder.ToString(), parameters, "");
            LDJGModel[] modelArray = null;
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            modelArray = new LDJGModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = this.GetModel(set.Tables[0].Rows[i]);
            }
            return modelArray;
        }

        public string GetSql(string tablename)
        {
            return ("select PK,TYPE,QYFW,TPK,TBH,TNAME,ZFMINVALUE,ZFMAXVALUE,ZFDEFVALUE,FZFMINVALUE,FZFMAXVALUE,FZFDEFVALUE,LDPK,LDMC FROM " + tablename);
        }

        public static string GetTableColumns()
        {
            return " PK,TYPE,QYFW,TPK,TBH,TNAME,ZFMINVALUE,ZFMAXVALUE,ZFDEFVALUE,FZFMINVALUE,FZFMAXVALUE,FZFDEFVALUE,LDPK,LDMC ";
        }

        public int Update(LDJGModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update " + model.TableName + " set ");
            builder.Append("Type='" + model.Type + "',");
            builder.Append("QYFW='" + model.QYFW + "',");
            builder.Append("TPK='" + model.TPK + "',");
            builder.Append("TBH='" + model.TBH + "',");
            builder.Append("TNAME='" + model.TNAME + "',");
            builder.Append("ZFMinValue=" + model.ZFMinValue + ",");
            builder.Append("ZFMaxValue=" + model.ZFMaxValue + ",");
            builder.Append("ZFDefValue=" + model.ZFDefValue + ",");
            builder.Append("FZFMinValue=" + model.FZFMinValue + ",");
            builder.Append("FZFMaxValue=" + model.FZFMaxValue + ",");
            builder.Append("FZFDefValue=" + model.FZFDefValue + ",");
            builder.Append("LDMC='" + model.LDMC + "',");
            builder.Append("LDPK='" + model.LDPK + "'");
            builder.Append(" where PK='" + model.PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

