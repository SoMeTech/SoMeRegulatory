namespace SoMeTech.Company.Role
{
    using SoMeTech.Company;
    using SoMeTech.Company.Branch;
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class RoleDal : RoleModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into DB_Role(");
            builder.Append("BH,Name,Power,DataPower,RowPower,ServicesPower,CompanyPower,Discription,IsUserPower,FatherPK,IsHasBaby,Grade,PKPath,BranchPK,pk_corp");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + base.BH + "',");
            builder.Append("'" + base.Name + "',");
            builder.Append("'" + base.Power + "',");
            builder.Append("'" + base.DataPower + "',");
            builder.Append("'" + base.RowPower + "',");
            builder.Append("'" + base.ServicesPower + "',");
            builder.Append("'" + base.CompanyPower + "',");
            builder.Append("'" + base.Discription + "',");
            builder.Append("'" + base.IsUserPower + "',");
            builder.Append("'" + base.FatherPK + "',");
            builder.Append("'" + base.IsHasBaby + "',");
            builder.Append(base.Grade + ",");
            builder.Append("'" + base.PKPath + "',");
            builder.Append("'" + base.BranchPK + "',");
            builder.Append("'" + base.pk_corp + "'");
            builder.Append(")");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int Delete(DB_OPT dbo)
        {
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter("rolepk", OracleType.Char, 40) };
            parameters[0].Value = base.RolePK;
            return dbo.BuildQueryCommand("PROC_DELETEROLE", parameters);
        }

        public override int Exists(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from DB_Role where RolePK='" + base.RolePK + "'");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override int Exists(string bh, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from DB_Role where BH='" + bh + "'");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override DataSet GetList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSqlString());
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        private RoleModel Getmm(DataRow dr, bool bj_child, bool bj_father, DB_OPT dbo)
        {
            RoleModel model = new RoleDal();
            if (bj_father)
            {
                model.RolePK = dr["FatherPK"].ToString();
                model.FatherInfo = model.GetModel(false, false, dbo);
            }
            model.RolePK = dr["RolePK"].ToString().Trim();
            model.BH = dr["BH"].ToString();
            model.Name = dr["Name"].ToString();
            model.Power = dr["Power"].ToString();
            model.DataPower = dr["DataPower"].ToString();
            model.RowPower = dr["RowPower"].ToString();
            model.ServicesPower = dr["ServicesPower"].ToString();
            model.CompanyPower = dr["CompanyPower"].ToString();
            model.Discription = dr["Discription"].ToString();
            model.IsUserPower = dr["IsUserPower"].ToString();
            model.FatherPK = dr["FatherPK"].ToString().Trim();
            model.IsHasBaby = dr["IsHasBaby"].ToString();
            if (dr["Grade"].ToString() != "")
            {
                model.Grade = int.Parse(dr["Grade"].ToString());
            }
            model.PKPath = dr["PKPath"].ToString();
            model.BranchPK = dr["BranchPK"].ToString();
            model.Branch = new BranchDal { BranchPK = dr["BranchPK"].ToString() }.GetModel(false, false, false, false, dbo);
            model.pk_corp = dr["pk_corp"].ToString();
            model.Company = new CompanyDal { pk_corp = dr["pk_corp"].ToString() }.GetModel(dbo);
            if ((dr["IsHasBaby"].ToString() == "1") && bj_child)
            {
                model.Childs = this.GetChilds(model.RolePK, dbo);
            }
            return model;
        }

        public override RoleModel GetModel(bool bj_child, bool bj_father, DB_OPT dbo)
        {
            RoleModel model = null;
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSqlString());
            builder.Append(" where RolePK='" + base.RolePK + "'");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                model = new RoleModel();
                model = this.Getmm(set.Tables[0].Rows[0], bj_child, bj_father, dbo);
            }
            return model;
        }

        public override RoleModel[] GetModels(string strWhere, bool bj_child, bool bj_father, DB_OPT dbo)
        {
            RoleModel[] modelArray = null;
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSqlString());
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                modelArray = new RoleModel[set.Tables[0].Rows.Count];
                for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                {
                    modelArray[i] = new RoleModel();
                    modelArray[i] = this.Getmm(set.Tables[0].Rows[i], true, true, dbo);
                }
            }
            return modelArray;
        }

        private string GetSqlString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select RolePK,BH,Name,Power,DataPower,RowPower,ServicesPower,CompanyPower,Discription,IsUserPower,FatherPK,IsHasBaby,Grade,PKPath,pk_corp,BranchPK ");
            builder.Append(" FROM DB_Role ");
            return builder.ToString();
        }

        public override int Update(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_Role set ");
            builder.Append("BH='" + base.BH + "',");
            builder.Append("Name='" + base.Name + "',");
            builder.Append("Power='" + base.Power + "',");
            builder.Append("DataPower='" + base.DataPower + "',");
            builder.Append("RowPower='" + base.RowPower + "',");
            builder.Append("ServicesPower='" + base.ServicesPower + "',");
            builder.Append("CompanyPower='" + base.CompanyPower + "',");
            builder.Append("Discription='" + base.Discription + "',");
            builder.Append("IsUserPower='" + base.IsUserPower + "',");
            builder.Append("FatherPK='" + base.FatherPK + "',");
            builder.Append("IsHasBaby='" + base.IsHasBaby + "',");
            builder.Append("Grade=" + base.Grade + ",");
            builder.Append("PKPath='" + base.PKPath + "',");
            builder.Append("BranchPK='" + base.BranchPK + "',");
            builder.Append("pk_corp='" + base.pk_corp + "'");
            builder.Append(" where RolePK='" + base.RolePK + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

