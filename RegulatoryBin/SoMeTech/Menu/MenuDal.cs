namespace SoMeTech.Menu
{
       using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Text;

    public sealed class MenuDal : MenuModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into DB_Menu(");
            builder.Append("MenuBH,MenuName,PageUrl,ImgUrl,FatherPK,IsHasBaby,Grade,PKPath,IsShow,PowerCode,InsertPC,UpdatePC,DeletePC,PrintPC,OpenType,IsCheckPower,VisitPoint,MenuType,OrderBy,Discription,pk_corp");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + base.MenuBH + "',");
            builder.Append("'" + base.MenuName + "',");
            builder.Append("'" + base.PageUrl + "',");
            builder.Append("'" + base.ImgUrl + "',");
            builder.Append("'" + base.FatherPK + "',");
            builder.Append("'" + base.IsHasBaby + "',");
            builder.Append(base.Grade + ",");
            builder.Append("'" + base.PKPath + "',");
            builder.Append("'" + base.IsShow + "',");
            builder.Append("'" + base.PowerCode + "',");
            builder.Append("'" + base.InsertPC + "',");
            builder.Append("'" + base.UpdatePC + "',");
            builder.Append("'" + base.DeletePC + "',");
            builder.Append("'" + base.PrintPC + "',");
            builder.Append("'" + base.OpenType + "',");
            builder.Append("'" + base.IsCheckPower + "',");
            builder.Append(base.VisitPoint + ",");
            builder.Append("'" + base.MenuType + "',");
            builder.Append(base.OrderBy + ",");
            builder.Append("'" + base.Discription + "',");
            builder.Append("'" + base.pk_corp + "'");
            builder.Append(")");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public static void ChangeChildPkPath(string menupk, string pkpath, int grade, DB_OPT dbo)
        {
            MenuModel model = new MenuDal();
            MenuModel[] childs = model.GetChilds(menupk, dbo);
            if (childs != null)
            {
                for (int i = 0; i < childs.Length; i++)
                {
                    model.MemuPK = childs[i].MemuPK;
                    model.Grade = grade;
                    model.PKPath = pkpath;
                    model.UpdatePKPathAndGrade(dbo);
                    if (childs[i].IsHasBaby == "1")
                    {
                        ChangeChildPkPath(childs[i].MemuPK, pkpath + model.MemuPK + "|", grade + 1, dbo);
                    }
                }
            }
            else
            {
                model.MemuPK = menupk;
                model.IsHasBaby = "0";
                model.UpdateHasBaby(dbo);
            }
        }

        public override int Delete(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from DB_Menu ");
            builder.Append(" where MemuPK='" + base.MemuPK + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int Exists(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from DB_Menu where MemuPK='" + base.MemuPK + "'");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override int Exists(string PowerCode, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from DB_Menu where PowerCode='" + PowerCode + "'");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override MenuModel[] GetChilds(string parentpk, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ");
            builder.Append(" MemuPK,MenuBH,MenuName,PageUrl,ImgUrl,FatherPK,IsHasBaby,Grade,PKPath,IsShow,PowerCode,InsertPC,UpdatePC,DeletePC,PrintPC,OpenType,IsCheckPower,VisitPoint,MenuType,OrderBy,Discription,pk_corp ");
            builder.Append(" from DB_Menu ");
            if (parentpk != "")
            {
                builder.Append(" where FatherPK='" + parentpk + "'");
            }
            builder.Append(" order by PowerCode");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            MenuModel[] modelArray = new MenuModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new MenuModel();
                modelArray[i] = this.Getmm(set.Tables[0].Rows[i], true, dbo);
            }
            return modelArray;
        }

        public override MenuModel[] GetEgality(bool bj, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ");
            builder.Append(" MemuPK,MenuBH,MenuName,PageUrl,ImgUrl,FatherPK,IsHasBaby,Grade,PKPath,IsShow,PowerCode,InsertPC,UpdatePC,DeletePC,PrintPC,OpenType,IsCheckPower,VisitPoint,MenuType,OrderBy,Discription,pk_corp ");
            builder.Append(" from DB_Menu ");
            if (base.Grade >= 0)
            {
                builder.Append(" where Grade='" + base.Grade + "'");
            }
            else
            {
                if (base.MemuPK == "")
                {
                    throw new Exception("条件不足.");
                }
                builder.Append(" where Grade=(select Grade from Menu where MemuPK='" + base.MemuPK + "')");
            }
            builder.Append(" order by PowerCode");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            MenuModel[] modelArray = new MenuModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new MenuModel();
                modelArray[i] = this.Getmm(set.Tables[0].Rows[i], bj, dbo);
            }
            return modelArray;
        }

        public override DataSet GetList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select MemuPK,MenuBH,MenuName,PageUrl,ImgUrl,FatherPK,IsHasBaby,Grade,PKPath,IsShow,PowerCode,InsertPC,UpdatePC,DeletePC,PrintPC,OpenType,IsCheckPower,VisitPoint,MenuType,OrderBy,Discription,pk_corp ");
            builder.Append(" FROM DB_Menu ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by OrderBy,PowerCode");
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public static string GetMenuColsName()
        {
            return "MemuPK,MenuBH,MenuName,PageUrl,ImgUrl,FatherPK,IsHasBaby,Grade,PKPath,IsShow,PowerCode,InsertPC,UpdatePC,DeletePC,PrintPC,OpenType,IsCheckPower,VisitPoint,MenuType,OrderBy,Discription,pk_corp";
        }

        private MenuModel Getmm(DataRow dr, bool bj, DB_OPT dbo)
        {
            MenuModel model = new MenuModel {
                MemuPK = dr["MemuPK"].ToString(),
                MenuBH = dr["MenuBH"].ToString(),
                MenuName = dr["MenuName"].ToString(),
                PageUrl = dr["PageUrl"].ToString(),
                ImgUrl = dr["ImgUrl"].ToString(),
                FatherPK = dr["FatherPK"].ToString(),
                IsHasBaby = dr["IsHasBaby"].ToString()
            };
            if (dr["Grade"].ToString() != "")
            {
                model.Grade = int.Parse(dr["Grade"].ToString());
            }
            model.PKPath = dr["PKPath"].ToString();
            model.IsShow = dr["IsShow"].ToString();
            model.PowerCode = dr["PowerCode"].ToString();
            model.InsertPC = dr["InsertPC"].ToString();
            model.UpdatePC = dr["UpdatePC"].ToString();
            model.DeletePC = dr["DeletePC"].ToString();
            model.PrintPC = dr["PrintPC"].ToString();
            model.OpenType = dr["OpenType"].ToString();
            model.IsCheckPower = dr["IsCheckPower"].ToString();
            if (dr["VisitPoint"].ToString() != "")
            {
                model.VisitPoint = int.Parse(dr["VisitPoint"].ToString());
            }
            model.MenuType = dr["MenuType"].ToString();
            if (dr["OrderBy"].ToString() != "")
            {
                model.OrderBy = int.Parse(dr["OrderBy"].ToString());
            }
            model.Discription = dr["Discription"].ToString();
            model.pk_corp = dr["pk_corp"].ToString();
            if ((dr["IsHasBaby"].ToString() == "1") && bj)
            {
                model.Childs = this.GetChilds(model.MemuPK, dbo);
            }
            return model;
        }

        public override MenuModel GetModel(bool bj, DB_OPT dbo)
        {
            new MenuModel();
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ");
            builder.Append(" MemuPK,MenuBH,MenuName,PageUrl,ImgUrl,FatherPK,IsHasBaby,Grade,PKPath,IsShow,PowerCode,InsertPC,UpdatePC,DeletePC,PrintPC,OpenType,IsCheckPower,VisitPoint,MenuType,OrderBy,Discription,pk_corp ");
            builder.Append(" from DB_Menu ");
            builder.Append(" where MemuPK='" + base.MemuPK + "'");
            builder.Append(" order by PowerCode");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.Getmm(set.Tables[0].Rows[0], bj, dbo);
            }
            return null;
        }

        public override MenuModel[] GetModels(string strwhere, bool bj, DB_OPT dbo)
        {
            MenuModel[] modelArray = null;
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ");
            builder.Append(" MemuPK,MenuBH,MenuName,PageUrl,ImgUrl,FatherPK,IsHasBaby,Grade,PKPath,IsShow,PowerCode,InsertPC,UpdatePC,DeletePC,PrintPC,OpenType,IsCheckPower,VisitPoint,MenuType,OrderBy,Discription,pk_corp ");
            builder.Append(" from DB_Menu ");
            if (strwhere != "")
            {
                builder.Append(" where " + strwhere);
            }
            builder.Append(" order by PowerCode");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                modelArray = new MenuModel[set.Tables[0].Rows.Count];
                for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                {
                    modelArray[i] = new MenuModel();
                    modelArray[i] = this.Getmm(set.Tables[0].Rows[i], bj, dbo);
                }
            }
            return modelArray;
        }

        public override MenuModel[] GetParents(DB_OPT dbo)
        {
            string[] strArray;
            string str;
            int num;
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ");
            builder.Append(" MemuPK,MenuBH,MenuName,PageUrl,ImgUrl,FatherPK,IsHasBaby,Grade,PKPath,IsShow,PowerCode,InsertPC,UpdatePC,DeletePC,PrintPC,OpenType,IsCheckPower,VisitPoint,MenuType,OrderBy,Discription,pk_corp ");
            builder.Append(" from DB_Menu ");
            if (base.PKPath != "")
            {
                strArray = base.PKPath.Split(new char[] { '|' });
                str = "";
                for (num = 0; num < strArray.Length; num++)
                {
                    if (strArray[num] != "")
                    {
                        str = str + "'" + strArray[num] + "',";
                    }
                }
                str = str.Substring(0, str.Length - 1);
                builder.Append(" where MemuPK in (" + str + ")");
            }
            else
            {
                if (!(base.MemuPK != ""))
                {
                    throw new Exception("条件不足.");
                }
                string strSql = "select PKPath from DB_Menu where MemuPK='" + base.MemuPK + "'";
                DataSet set = dbo.BackDataSet(strSql, null);
                if (!(set.Tables[0].Rows[0][0].ToString() != ""))
                {
                    throw new Exception("没有上级.");
                }
                strArray = set.Tables[0].Rows[0][0].ToString().Split(new char[] { '|' });
                str = "";
                for (num = 0; num < strArray.Length; num++)
                {
                    if (strArray[num] != "")
                    {
                        str = str + "'" + strArray[num] + "',";
                    }
                }
                builder.Append(" where MemuPK in (" + str.Substring(0, str.Length - 1) + ")");
            }
            builder.Append(" order by PowerCode");
            DataSet set2 = dbo.BackDataSet(builder.ToString(), null);
            if (set2.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            MenuModel[] modelArray = new MenuModel[set2.Tables[0].Rows.Count];
            for (num = 0; num < set2.Tables[0].Rows.Count; num++)
            {
                modelArray[num] = new MenuModel();
                modelArray[num] = this.Getmm(set2.Tables[0].Rows[num], false, dbo);
            }
            return modelArray;
        }

        public override int Update(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_Menu set ");
            builder.Append("MenuBH='" + base.MenuBH + "',");
            builder.Append("MenuName='" + base.MenuName + "',");
            builder.Append("PageUrl='" + base.PageUrl + "',");
            builder.Append("ImgUrl='" + base.ImgUrl + "',");
            builder.Append("FatherPK='" + base.FatherPK + "',");
            builder.Append("IsHasBaby='" + base.IsHasBaby + "',");
            builder.Append("Grade=" + base.Grade + ",");
            builder.Append("PKPath='" + base.PKPath + "',");
            builder.Append("IsShow='" + base.IsShow + "',");
            builder.Append("PowerCode='" + base.PowerCode + "',");
            builder.Append("InsertPC='" + base.InsertPC + "',");
            builder.Append("UpdatePC='" + base.UpdatePC + "',");
            builder.Append("DeletePC='" + base.DeletePC + "',");
            builder.Append("PrintPC='" + base.PrintPC + "',");
            builder.Append("OpenType='" + base.OpenType + "',");
            builder.Append("IsCheckPower='" + base.IsCheckPower + "',");
            builder.Append("VisitPoint=" + base.VisitPoint + ",");
            builder.Append("MenuType='" + base.MenuType + "',");
            builder.Append("OrderBy=" + base.OrderBy + ",");
            builder.Append("Discription='" + base.Discription + "',");
            builder.Append("pk_corp='" + base.pk_corp + "'");
            builder.Append(" where MemuPK='" + base.MemuPK + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int UpdateHasBaby(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_Menu set ");
            if (base.IsHasBaby != "")
            {
                builder.Append("IsHasBaby='" + base.IsHasBaby + "'");
            }
            else
            {
                builder.Append("IsHasBaby='1'");
            }
            builder.Append(" where MemuPK='" + base.MemuPK + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int UpdatePKPathAndGrade(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_Menu set ");
            builder.Append("PKPath='" + base.PKPath + "', ");
            builder.Append("Grade=" + base.Grade);
            builder.Append(" where MemuPK='" + base.MemuPK + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

