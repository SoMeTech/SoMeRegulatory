namespace SoMeTech.Menu
{
    using SoMeTech.DataAccess;
    using System;
    using System.Collections;
    using System.Data;
    using System.Text;

    public sealed class DataRowPowerItemDal : DataRowPowerItemModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into db_DataRowPowerItem(");
            builder.Append("Name,PowerCode,TableName,ColumnName,QXList,strWhere,ShowTJ,Discription");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + base.Name + "',");
            builder.Append("'" + base.PowerCode + "',");
            builder.Append("'" + base.TableName + "',");
            builder.Append("'" + base.ColumnName + "',");
            builder.Append("@QXList,@strWhere,");
            builder.Append("'" + base.ShowTJ + "',");
            builder.Append("'" + base.Discription + "'");
            builder.Append(")");
            Hashtable ht = new Hashtable();
            ht.Add("QXList", base.QXList);
            ht.Add("strWhere", base.strWhere);
            return dbo.ExecutionIsSucess(builder.ToString(), ht);
        }

        public override int Delete(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete db_DataRowPowerItem ");
            builder.Append(" where PK='" + base.PK + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int Exists(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from db_DataRowPowerItem where PK='" + base.PK + "'");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override DataSet GetList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,Name,PowerCode,TableName,ColumnName,QXList,strWhere,ShowTJ,Discription ");
            builder.Append(" FROM db_DataRowPowerItem ");
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
            builder.Append(" PK,Name,PowerCode,TableName,ColumnName,QXList,strWhere,ShowTJ,Discription ");
            builder.Append(" from db_DataRowPowerItem ");
            builder.Append(" where PK='" + base.PK + "'");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                base.Name = set.Tables[0].Rows[0]["Name"].ToString();
                base.PowerCode = set.Tables[0].Rows[0]["PowerCode"].ToString();
                base.TableName = set.Tables[0].Rows[0]["TableName"].ToString();
                base.ColumnName = set.Tables[0].Rows[0]["ColumnName"].ToString();
                base.QXList = set.Tables[0].Rows[0]["QXList"].ToString();
                base.strWhere = set.Tables[0].Rows[0]["strWhere"].ToString();
                base.ShowTJ = set.Tables[0].Rows[0]["ShowTJ"].ToString();
                base.Discription = set.Tables[0].Rows[0]["Discription"].ToString();
            }
        }

        public override DataRowPowerItemModel[] GetModels(DB_OPT dbo)
        {
            DataRowPowerItemModel[] modelArray = null;
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ");
            builder.Append(" PK,Name,PowerCode,TableName,ColumnName,QXList,strWhere,ShowTJ,Discription ");
            builder.Append(" from db_DataRowPowerItem ");
            builder.Append(" where TableName='" + base.TableName + "'");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                modelArray = new DataRowPowerItemModel[set.Tables[0].Rows.Count];
                for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                {
                    modelArray[i] = new DataRowPowerItemModel();
                    modelArray[i].Name = set.Tables[0].Rows[i]["Name"].ToString();
                    modelArray[i].PowerCode = set.Tables[0].Rows[i]["PowerCode"].ToString();
                    modelArray[i].TableName = set.Tables[0].Rows[i]["TableName"].ToString();
                    modelArray[i].ColumnName = set.Tables[0].Rows[i]["ColumnName"].ToString();
                    modelArray[i].ColumnName = set.Tables[0].Rows[i]["QXList"].ToString();
                    modelArray[i].strWhere = set.Tables[0].Rows[i]["strWhere"].ToString();
                    modelArray[i].ShowTJ = set.Tables[0].Rows[i]["ShowTJ"].ToString();
                    modelArray[i].Discription = set.Tables[0].Rows[i]["Discription"].ToString();
                }
            }
            return modelArray;
        }

        public override int Update(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update db_DataRowPowerItem set ");
            builder.Append("Name='" + base.Name + "',");
            builder.Append("PowerCode='" + base.PowerCode + "',");
            builder.Append("TableName='" + base.TableName + "',");
            builder.Append("ColumnName='" + base.ColumnName + "',");
            builder.Append("QXList=@QXList,");
            builder.Append("strWhere=@strWhere,");
            builder.Append("ShowTJ='" + base.ShowTJ + "',");
            builder.Append("Discription='" + base.Discription + "'");
            builder.Append(" where PK='" + base.PK + "'");
            Hashtable ht = new Hashtable();
            ht.Add("QXList", base.QXList);
            ht.Add("strWhere", base.strWhere);
            return dbo.ExecutionIsSucess(builder.ToString(), ht);
        }
    }
}

