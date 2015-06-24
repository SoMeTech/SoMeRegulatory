namespace SoMeTech.UsualBookTable
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Text;

    [Serializable]
    public sealed class UsualBookTableDal : UsualBookTableModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into " + base.TableName + "(");
            builder.Append("BH,Name,Discription,FatherPK,IsHasBaby,Grade,PKPath");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + base.BH + "',");
            builder.Append("'" + base.Name + "',");
            builder.Append("'" + base.Discription + "',");
            builder.Append("'" + base.FatherPK + "',");
            builder.Append("'" + base.IsHasBaby + "',");
            builder.Append(base.Grade + ",");
            builder.Append("'" + base.PKPath + "'");
            builder.Append(")");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int Delete(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from " + base.TableName + " ");
            builder.Append(" where PK = '" + base.PK + "' or PKPath like '%" + base.PK + "%'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int Exists(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            if (base.BH != "")
            {
                builder.Append("select count(PK) from " + base.TableName + " where BH='" + base.BH + "'");
            }
            else
            {
                builder.Append("select count(PK) from " + base.TableName + " where PK='" + base.PK + "'");
            }
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override int Exists(string BH, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from " + base.TableName + " where BH='" + BH + "'");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override UsualBookTableModel[] GetChilds(string parentpk, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ");
            builder.Append(" * ");
            builder.Append(" from " + base.TableName + " ");
            if (parentpk != "")
            {
                builder.Append(" where FatherPK='" + parentpk + "'");
            }
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            UsualBookTableModel[] modelArray = new UsualBookTableModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new UsualBookTableModel();
                modelArray[i] = this.Getmm(set.Tables[0].Rows[i], true, dbo);
            }
            return modelArray;
        }

        public override UsualBookTableModel[] GetEgality(bool bj, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ");
            builder.Append(" * ");
            builder.Append(" from " + base.TableName + " ");
            if (base.Grade >= 0)
            {
                builder.Append(" where Grade='" + base.Grade + "'");
            }
            else
            {
                if (base.PK == "")
                {
                    throw new Exception("条件不足.");
                }
                builder.Append(" where Grade=(select Grade from " + base.TableName + " where PK='" + base.PK + "')");
            }
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            UsualBookTableModel[] modelArray = new UsualBookTableModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new UsualBookTableModel();
                modelArray[i] = this.Getmm(set.Tables[0].Rows[i], bj, dbo);
            }
            return modelArray;
        }

        public override DataSet GetList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * ");
            builder.Append(" FROM " + base.TableName + " ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by Grade");
            return dbo.BackDataSet(builder.ToString(), null);
        }

        private UsualBookTableModel Getmm(DataRow dr, bool bj, DB_OPT dbo)
        {
            UsualBookTableModel model = new UsualBookTableModel {
                PK = dr["PK"].ToString(),
                Name = dr["Name"].ToString(),
                Discription = dr["Discription"].ToString(),
                FatherPK = dr["FatherPK"].ToString(),
                IsHasBaby = dr["IsHasBaby"].ToString(),
                BH = dr["BH"].ToString()
            };
            if (dr["Grade"].ToString() != "")
            {
                model.Grade = int.Parse(dr["Grade"].ToString());
            }
            model.PKPath = dr["PKPath"].ToString();
            if ((dr["IsHasBaby"].ToString() == "1") && bj)
            {
                model.ubtm = this.GetChilds(model.PK, dbo);
            }
            return model;
        }

        public override UsualBookTableModel GetModel(bool bj, DB_OPT dbo)
        {
            new UsualBookTableModel();
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ");
            builder.Append(" * ");
            builder.Append(" from " + base.TableName + " ");
            builder.Append(" where PK='" + base.PK + "'");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.Getmm(set.Tables[0].Rows[0], bj, dbo);
            }
            return null;
        }

        public override UsualBookTableModel[] GetModels(string strwhere, bool bj, DB_OPT dbo)
        {
            UsualBookTableModel[] modelArray = null;
            StringBuilder builder = new StringBuilder();
            builder.Append("select ");
            builder.Append(" * ");
            builder.Append(" from " + base.TableName + " ");
            if (strwhere.Trim() != "")
            {
                builder.Append(" where " + strwhere);
            }
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                modelArray = new UsualBookTableModel[set.Tables[0].Rows.Count];
                for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                {
                    modelArray[i] = new UsualBookTableModel();
                    modelArray[i] = this.Getmm(set.Tables[0].Rows[i], bj, dbo);
                }
            }
            return modelArray;
        }

        public override UsualBookTableModel[] GetParents(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ");
            builder.Append(" * ");
            builder.Append(" from " + base.TableName + " ");
            if (base.PKPath != "")
            {
                string[] strArray = base.PKPath.Split(new char[] { '|' });
                string str = "";
                for (int j = 0; j < strArray.Length; j++)
                {
                    if (strArray[j] != "")
                    {
                        str = str + "'" + strArray[j] + "',";
                    }
                }
                builder.Append(" where PK in (" + str.Substring(0, str.Length - 1) + ")");
            }
            else
            {
                if (!(base.PK != ""))
                {
                    return null;
                }
                string strSql = "select PKPath from " + base.TableName + " where PK='" + base.PK + "'";
                DataSet set = dbo.BackDataSet(strSql, null);
                if (set.Tables[0].Rows[0][0].ToString() != "")
                {
                    string[] strArray2 = set.Tables[0].Rows[0][0].ToString().Split(new char[] { '|' });
                    string str3 = "";
                    for (int k = 0; k < strArray2.Length; k++)
                    {
                        if (strArray2[k] != "")
                        {
                            str3 = str3 + "'" + strArray2[k] + "',";
                        }
                    }
                    builder.Append(" where PK in (" + str3.Substring(0, str3.Length - 1) + ")");
                }
                else
                {
                    builder.Append(" where PK='" + base.PK + "'");
                }
            }
            DataSet set2 = dbo.BackDataSet(builder.ToString(), null);
            if (set2.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            UsualBookTableModel[] modelArray = new UsualBookTableModel[set2.Tables[0].Rows.Count];
            for (int i = 0; i < set2.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new UsualBookTableModel();
                modelArray[i] = this.Getmm(set2.Tables[0].Rows[i], false, dbo);
            }
            return modelArray;
        }

        public override int Update(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update " + base.TableName + " set ");
            builder.Append("BH='" + base.BH + "',");
            builder.Append("Name='" + base.Name + "',");
            builder.Append("Discription='" + base.Discription + "',");
            builder.Append("FatherPK='" + base.FatherPK + "',");
            builder.Append("IsHasBaby='" + base.IsHasBaby + "',");
            builder.Append("Grade=" + base.Grade + ",");
            builder.Append("PKPath='" + base.PKPath + "'");
            builder.Append(" where PK='" + base.PK + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int UpdateHasBaby(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update " + base.TableName + " set ");
            if (base.IsHasBaby != "")
            {
                builder.Append("IsHasBaby='" + base.IsHasBaby + "'");
            }
            else
            {
                builder.Append("IsHasBaby='1'");
            }
            builder.Append(" where PK='" + base.PK + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

