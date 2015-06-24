namespace SoMeTech.Menu
{
    using SoMeTech.DataAccess;
    using System;
    using System.Collections;
    using System.Data;
    using System.Text;

    public sealed class DataRowPowerDal : DataRowPowerModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into DataRowPower(");
            builder.Append("Name,PowerCode,TJType,TableName,ColumnName,strWhere,Discription");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + base.Name + "',");
            builder.Append("'" + base.PowerCode + "',");
            builder.Append("'" + base.TJType + "',");
            builder.Append("'" + base.TableName + "',");
            builder.Append("'" + base.ColumnName + "',@strWhere,");
            builder.Append("'" + base.Discription + "'");
            builder.Append(")");
            Hashtable ht = new Hashtable();
            ht.Add("strWhere", base.strWhere);
            return dbo.ExecutionIsSucess(builder.ToString(), ht);
        }

        public override int Delete(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete DataRowPower ");
            builder.Append(" where PK='" + base.PK + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int Exists(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from DataRowPower where PK='" + base.PK + "'");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override DataSet GetList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,Name,PowerCode,TJType,TableName,ColumnName,strWhere,Discription ");
            builder.Append(" FROM DataRowPower ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public override void GetModel(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ");
            builder.Append(" PK,Name,PowerCode,TJType,TableName,ColumnName,strWhere,Discription ");
            builder.Append(" from DataRowPower ");
            builder.Append(" where PK='" + base.PK + "'");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                base.Name = set.Tables[0].Rows[0]["Name"].ToString();
                base.PowerCode = set.Tables[0].Rows[0]["PowerCode"].ToString();
                base.TJType = set.Tables[0].Rows[0]["TJType"].ToString();
                base.TableName = set.Tables[0].Rows[0]["TableName"].ToString();
                base.ColumnName = set.Tables[0].Rows[0]["ColumnName"].ToString();
                base.strWhere = set.Tables[0].Rows[0]["strWhere"].ToString();
                base.Discription = set.Tables[0].Rows[0]["Discription"].ToString();
                base.CodeAndWhere = set.Tables[0].Rows[0]["PowerCode"].ToString() + "|" + set.Tables[0].Rows[0]["strWhere"].ToString();
            }
        }

        public override DataRowPowerModel[] GetModels(DB_OPT dbo)
        {
            DataRowPowerModel[] modelArray = null;
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ");
            builder.Append(" PK,Name,PowerCode,TJType,TableName,ColumnName,strWhere,Discription ");
            builder.Append(" from DataRowPower ");
            builder.Append(" where TableName='" + base.TableName + "'");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                modelArray = new DataRowPowerModel[set.Tables[0].Rows.Count];
                for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                {
                    modelArray[i] = new DataRowPowerModel();
                    modelArray[i].Name = set.Tables[0].Rows[i]["Name"].ToString();
                    modelArray[i].PowerCode = set.Tables[0].Rows[i]["PowerCode"].ToString();
                    modelArray[i].TJType = set.Tables[0].Rows[i]["TJType"].ToString();
                    modelArray[i].TableName = set.Tables[0].Rows[i]["TableName"].ToString();
                    modelArray[i].ColumnName = set.Tables[0].Rows[i]["ColumnName"].ToString();
                    modelArray[i].strWhere = set.Tables[0].Rows[i]["strWhere"].ToString();
                    modelArray[i].Discription = set.Tables[0].Rows[i]["Discription"].ToString();
                    modelArray[i].CodeAndWhere = set.Tables[0].Rows[i]["PowerCode"].ToString() + "|" + set.Tables[0].Rows[i]["strWhere"].ToString();
                }
            }
            return modelArray;
        }

        public override int Update(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DataRowPower set ");
            builder.Append("Name='" + base.Name + "',");
            builder.Append("PowerCode='" + base.PowerCode + "',");
            builder.Append("TJType='" + base.TJType + "',");
            builder.Append("TableName='" + base.TableName + "',");
            builder.Append("ColumnName='" + base.ColumnName + "',");
            builder.Append("strWhere=@strWhere,");
            builder.Append("Discription='" + base.Discription + "'");
            builder.Append(" where PK='" + base.PK + "'");
            Hashtable ht = new Hashtable();
            ht.Add("strWhere", base.strWhere);
            return dbo.ExecutionIsSucess(builder.ToString(), ht);
        }
    }
}

