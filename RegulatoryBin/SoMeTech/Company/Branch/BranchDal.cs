namespace SoMeTech.Company.Branch
{
    using SoMeTech.Company;
    using SoMeTech.Company.Employee;
       using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class BranchDal : BranchModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into DB_Branch(");
            builder.Append("BH,Name,Power,DataPower,RowPower,ServicesPower,CompanyPower,IsUserPower,Discription,Manager,Phone,Fax,Email,Address,FatherPK,IsHasBaby,Grade,PKPath,pk_corp");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + base.BH + "',");
            builder.Append("'" + base.Name + "',");
            builder.Append("'" + base.Power + "',");
            builder.Append("'" + base.DataPower + "',");
            builder.Append("'" + base.RowPower + "',");
            builder.Append("'" + base.ServicesPower + "',");
            builder.Append("'" + base.CompanyPower + "',");
            builder.Append("'" + base.IsUserPower + "',");
            builder.Append("'" + base.Discription + "',");
            builder.Append("'" + base.Manager + "',");
            builder.Append("'" + base.Phone + "',");
            builder.Append("'" + base.Fax + "',");
            builder.Append("'" + base.Email + "',");
            builder.Append("'" + base.Address + "',");
            builder.Append("'" + base.FatherPK + "',");
            builder.Append("'" + base.IsHasBaby + "',");
            builder.Append(base.Grade + ",");
            builder.Append("'" + base.PKPath + "',");
            builder.Append("'" + base.pk_corp + "'");
            builder.Append(")");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int Delete(DB_OPT dbo)
        {
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter("brapk", OracleType.Char, 40) };
            parameters[0].Value = base.BranchPK;
            return dbo.BuildQueryCommand("PROC_DELETEBRANCH", parameters);
        }

        public override int Exists(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from DB_Branch where BranchPK='" + base.BranchPK + "'");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override int Exists(string bh, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from DB_Branch where BH='" + bh + "'");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override BranchModel[] GetChilds(string parentpk, bool bj_employee, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (parentpk != "")
            {
                builder.Append(" where FatherPK='" + parentpk + "'");
            }
            builder.Append(" order by pk_corp");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            BranchModel[] modelArray = new BranchModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new BranchModel();
                modelArray[i] = this.Getmm(set.Tables[0].Rows[i], true, false, false, bj_employee, dbo);
            }
            return modelArray;
        }

        public override BranchModel[] GetEgality(bool bj_child, bool bj_father, bool bj_company, bool bj_employee, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (base.Grade >= 0)
            {
                builder.Append(" where Grade='" + base.Grade + "'");
            }
            else
            {
                if (base.pk_corp == "")
                {
                    throw new Exception("条件不足.");
                }
                builder.Append(" where Grade=(select Grade from Company where pk_corp='" + base.pk_corp + "')");
            }
            builder.Append(" order by pk_corp");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            BranchModel[] modelArray = new BranchModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new BranchModel();
                modelArray[i] = this.Getmm(set.Tables[0].Rows[i], bj_child, bj_father, bj_company, bj_employee, dbo);
            }
            return modelArray;
        }

        public override DataSet GetList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by BH ");
            return dbo.BackDataSet(builder.ToString(), null);
        }

        private BranchModel Getmm(DataRow dr, bool bj_child, bool bj_father, bool bj_company, bool bj_employee, DB_OPT dbo)
        {
            BranchModel model = new BranchDal();
            if (bj_father)
            {
                model.BranchPK = dr["FatherPK"].ToString();
                model.FatherInfo = model.GetModel(false, false, false, true, dbo);
            }
            model.BranchPK = dr["BranchPK"].ToString().Trim();
            model.BH = dr["BH"].ToString();
            model.Name = dr["Name"].ToString();
            model.Power = dr["Power"].ToString();
            model.DataPower = dr["DataPower"].ToString();
            model.RowPower = dr["RowPower"].ToString();
            model.ServicesPower = dr["ServicesPower"].ToString();
            model.CompanyPower = dr["CompanyPower"].ToString();
            model.IsUserPower = dr["IsUserPower"].ToString();
            model.Discription = dr["Discription"].ToString();
            model.Manager = dr["Manager"].ToString();
            model.Phone = dr["Phone"].ToString();
            model.Fax = dr["Fax"].ToString();
            model.Email = dr["Email"].ToString();
            model.Address = dr["Address"].ToString();
            model.FatherPK = dr["FatherPK"].ToString().Trim();
            model.IsHasBaby = dr["IsHasBaby"].ToString();
            if (dr["Grade"].ToString() != "")
            {
                model.Grade = int.Parse(dr["Grade"].ToString());
            }
            model.PKPath = dr["PKPath"].ToString();
            model.pk_corp = dr["pk_corp"].ToString();
            if (bj_employee)
            {
                model.ManagerInfo = new EmployeeDal { EmployeePK = dr["Manager"].ToString() }.GetModel(true, false, false, false, true, dbo);
            }
            if (bj_company)
            {
                model.PK_Corp_Info = new CompanyDal { pk_corp = dr["pk_corp"].ToString() }.GetModel(false, false, false, dbo);
            }
            if ((dr["IsHasBaby"].ToString() == "1") && bj_child)
            {
                model.Childs = this.GetChilds(model.BranchPK, true, dbo);
            }
            model.IsJGBM = dr["IsJGBM"].ToString();
            return model;
        }

        public override BranchModel GetModel(DB_OPT dbo)
        {
            BranchModel model = null;
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            builder.Append(" where BranchPK='" + base.BranchPK + "'");
            builder.Append(" order by BH ");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                model = new BranchModel();
                model = this.Getmm(set.Tables[0].Rows[0], false, false, false, false, dbo);
            }
            return model;
        }

        public override BranchModel GetModel(bool bj_child, bool bj_father, bool bj_company, bool bj_employee, DB_OPT dbo)
        {
            BranchModel model = null;
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            builder.Append(" where BranchPK='" + base.BranchPK + "'");
            builder.Append(" order by BH ");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                model = new BranchModel();
                model = this.Getmm(set.Tables[0].Rows[0], bj_child, bj_father, bj_company, bj_employee, dbo);
            }
            return model;
        }

        public override BranchModel GetModel_BH(DB_OPT dbo)
        {
            BranchModel model = null;
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            builder.Append(" where BH='" + base.BH + "'");
            builder.Append(" order by BH ");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                model = new BranchModel();
                model = this.Getmm(set.Tables[0].Rows[0], false, false, false, false, dbo);
            }
            return model;
        }

        public override BranchModel GetModel_BH(bool bj_child, bool bj_father, bool bj_company, bool bj_employee, DB_OPT dbo)
        {
            BranchModel model = null;
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            builder.Append(" where BH='" + base.BH + "'");
            builder.Append(" order by BH ");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                model = new BranchModel();
                model = this.Getmm(set.Tables[0].Rows[0], bj_child, bj_father, bj_company, bj_employee, dbo);
            }
            return model;
        }

        public override BranchModel[] GetModels(string strWhere, bool bj_child, bool bj_father, bool bj_company, bool bj_employee, DB_OPT dbo)
        {
            BranchModel[] modelArray = null;
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by BH ");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                modelArray = new BranchModel[set.Tables[0].Rows.Count];
                for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                {
                    modelArray[i] = new BranchModel();
                    modelArray[i] = this.Getmm(set.Tables[0].Rows[i], bj_child, bj_father, bj_company, bj_employee, dbo);
                }
            }
            return modelArray;
        }

        public override BranchModel[] GetParents(bool bj_employee, DB_OPT dbo)
        {
            string[] strArray;
            string str;
            int num;
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if ((base.PKPath != null) && (base.PKPath != ""))
            {
                strArray = base.PKPath.Split(new char[] { '|' });
                str = "";
                for (num = 0; num < strArray.Length; num++)
                {
                    str = str + "'" + strArray[num] + "',";
                }
                str = str.Substring(0, str.Length - 1);
                builder.Append(" where BranchPK in (" + str + ")");
            }
            else
            {
                if (!(base.BranchPK != ""))
                {
                    throw new Exception("条件不足.");
                }
                string strSql = "select PKPath from Branch where BranchPK='" + base.BranchPK + "'";
                DataSet set = dbo.BackDataSet(strSql, null);
                if (!(set.Tables[0].Rows[0][0].ToString() != ""))
                {
                    throw new Exception("没有上级.");
                }
                strArray = set.Tables[0].Rows[0][0].ToString().Split(new char[] { '|' });
                str = "";
                for (num = 0; num < strArray.Length; num++)
                {
                    str = str + "'" + strArray[num] + "',";
                }
                builder.Append(" where BranchPK in (" + str.Substring(0, str.Length - 1) + ")");
            }
            builder.Append(" order by BH ");
            DataSet set2 = dbo.BackDataSet(builder.ToString(), null);
            if (set2.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            BranchModel[] modelArray = new BranchModel[set2.Tables[0].Rows.Count];
            for (num = 0; num < set2.Tables[0].Rows.Count; num++)
            {
                modelArray[num] = new BranchModel();
                modelArray[num] = this.Getmm(set2.Tables[0].Rows[num], false, true, false, bj_employee, dbo);
            }
            return modelArray;
        }

        private string GetSql()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ");
            builder.Append(" BranchPK,BH,Name,Power,DataPower,RowPower,ServicesPower,CompanyPower,IsUserPower,Discription,Manager,Phone,Fax,Email,Address,FatherPK,IsHasBaby,Grade,PKPath,pk_corp,ISJGBM ");
            builder.Append(" from DB_Branch ");
            return builder.ToString();
        }

        public override DataSet GetViewList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetViewSql());
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by BH ");
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public string GetViewSql()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ");
            builder.Append(" BRANCHPK,BH,NAME,POWER,DATAPOWER,ROWPOWER,SERVICESPOWER,COMPANYPOWER,ISUSERPOWER,DISCRIPTION,MANAGER,PHONE,FAX,EMAIL,ADDRESS,FATHERPK,ISHASBABY,GRADE,PKPATH,PK_CORP,COMPANYNAME,EMPLOYEENAME ");
            builder.Append(" from GOV_TC_VIEW_BRANCH ");
            return builder.ToString();
        }

        public override int Update(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_Branch set ");
            builder.Append("BH='" + base.BH + "',");
            builder.Append("Name='" + base.Name + "',");
            builder.Append("Power='" + base.Power + "',");
            builder.Append("DataPower='" + base.DataPower + "',");
            builder.Append("RowPower='" + base.RowPower + "',");
            builder.Append("ServicesPower='" + base.ServicesPower + "',");
            builder.Append("CompanyPower='" + base.CompanyPower + "',");
            builder.Append("IsUserPower='" + base.IsUserPower + "',");
            builder.Append("Discription='" + base.Discription + "',");
            builder.Append("Manager='" + base.Manager + "',");
            builder.Append("Phone='" + base.Phone + "',");
            builder.Append("Fax='" + base.Fax + "',");
            builder.Append("Email='" + base.Email + "',");
            builder.Append("Address='" + base.Address + "',");
            builder.Append("FatherPK='" + base.FatherPK + "',");
            builder.Append("IsHasBaby='" + base.IsHasBaby + "',");
            builder.Append("Grade=" + base.Grade + ",");
            builder.Append("PKPath='" + base.PKPath + "',");
            builder.Append("pk_corp='" + base.pk_corp + "'");
            builder.Append(" where BranchPK='" + base.BranchPK + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int UpdateHasBaby(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_Branch set ");
            if (base.IsHasBaby != "")
            {
                builder.Append("IsHasBaby='" + base.IsHasBaby + "'");
            }
            else
            {
                builder.Append("IsHasBaby='1'");
            }
            builder.Append(" where BranchPK='" + base.BranchPK + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int UpdatePKPathAndGrade(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_Branch set ");
            builder.Append("PKPath='" + base.PKPath + "', ");
            builder.Append("Grade=" + base.Grade);
            builder.Append(" where BranchPK='" + base.BranchPK + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

