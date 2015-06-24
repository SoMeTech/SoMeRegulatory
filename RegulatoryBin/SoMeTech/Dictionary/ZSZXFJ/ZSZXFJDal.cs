namespace SoMeTech.Dictionary.ZSZXFJ
{
    using SoMeTech.DataAccess;
    using SoMeTech.Dictionary.SFType;
    using SoMeTech.UsualBookTable;
    using System;
    using System.Data;
    using System.Text;

    public sealed class ZSZXFJDal : ZSZXFJModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into GOV_TC_DB_ZSZXFJ(");
            builder.Append("OperationPK,SFPK,ProjectType,TermName1,TermName2,ExecuteValue1,ExecuteValue2,ExecuteValue3,flog,Discription");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + base.OperationPK + "',");
            builder.Append("'" + base.SFPK + "',");
            builder.Append("'" + base.ProjectType + "',");
            builder.Append("'" + base.TermName1 + "',");
            builder.Append("'" + base.TermName2 + "',");
            builder.Append(base.ExecuteValue1 + ",");
            builder.Append(base.ExecuteValue2 + ",");
            builder.Append(base.ExecuteValue3 + ",");
            builder.Append(base.flog + ",");
            builder.Append("'" + base.Discription + "'");
            builder.Append(")");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int Delete(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from GOV_TC_DB_ZSZXFJ ");
            builder.Append(" where PK='" + base.pk + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int Exists(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from GOV_TC_DB_ZSZXFJ");
            builder.Append(" where pk='" + base.pk + "' ");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override DataSet GetList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,OPERATIONPK,SFPK,PROJECTTYPE,TERMNAME,TERMVALUE,EXECUTEVALUE1,EXECUTEVALUE2,DISCRIPTION,EXECUTEVALUE3,SFNAME,YWNAME,SFZSXMNAME");
            builder.Append(" FROM gov_tc_view_ZSZXFJ ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        private ZSZXFJModel Getmm(DataRow dr, DB_OPT dbo)
        {
            ZSZXFJModel model = new ZSZXFJModel {
                pk = dr["pk"].ToString(),
                Discription = dr["Discription"].ToString(),
                ExecuteValue1 = decimal.Parse(dr["ExecuteValue1"].ToString()),
                ExecuteValue2 = decimal.Parse(dr["ExecuteValue2"].ToString()),
                ExecuteValue3 = decimal.Parse(dr["ExecuteValue3"].ToString()),
                OperationPK = dr["OperationPK"].ToString()
            };
            if (model.OperationPK.Trim() != "")
            {
                string strSql = "select Name FROM GOV_TC_DB_OPRATETACHE where PK='" + model.OperationPK.Trim() + "'";
                model.OperationName = dbo.SelectString(strSql, null);
            }
            model.SFPK = dr["SFPK"].ToString();
            SFTypeModel model2 = new SFTypeDal {
                PK = dr["SFPK"].ToString().Trim()
            };
            model2 = model2.GetModel(dbo);
            model.Sfinfo = model2;
            model.ProjectType = dr["ProjectType"].ToString();
            UsualBookTableModel model3 = new UsualBookTableDal {
                PK = dr["ProjectType"].ToString().Trim()
            };
            model3 = model3.GetModel(false, dbo);
            model.ProjecttypeInfo = model3;
            model.TermName1 = dr["TermName1"].ToString();
            model.TermName2 = dr["TermName2"].ToString();
            model.flog = int.Parse(dr["flog"].ToString());
            return model;
        }

        public override ZSZXFJModel GetModel(DB_OPT dbo)
        {
            new ZSZXFJModel();
            StringBuilder builder = new StringBuilder();
            builder.Append("select ");
            builder.Append(" PK,OperationPK,SFPK,ProjectType,TermName1,TermName2,ExecuteValue1,ExecuteValue2,ExecuteValue3,flog,Discription ");
            builder.Append(" from GOV_TC_DB_ZSZXFJ ");
            builder.Append(" where PK='" + base.pk + "' ");
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
            builder.Append("update GOV_TC_DB_ZSZXFJ set ");
            builder.Append("OperationPK='" + base.OperationPK + "',");
            builder.Append("SFPK='" + base.SFPK + "',");
            builder.Append("ProjectType='" + base.ProjectType + "',");
            builder.Append("TermName1='" + base.TermName1 + "',");
            builder.Append("TermName2='" + base.TermName2 + "',");
            builder.Append("ExecuteValue1=" + base.ExecuteValue1 + ",");
            builder.Append("ExecuteValue2=" + base.ExecuteValue2 + ",");
            builder.Append("ExecuteValue3=" + base.ExecuteValue3 + ",");
            builder.Append("flog=" + base.flog + ",");
            builder.Append("Discription='" + base.Discription + "'");
            builder.Append(" where pk='" + base.pk + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

