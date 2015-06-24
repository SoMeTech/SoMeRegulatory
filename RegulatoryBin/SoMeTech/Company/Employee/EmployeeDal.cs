namespace SoMeTech.Company.Employee
{
    using SoMeTech.Company;
    using SoMeTech.Company.Branch;
    using SoMeTech.Company.Role;
    using SoMeTech.DataAccess;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class EmployeeDal : EmployeeModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into DB_Employee(");
            builder.Append("BranchPK,RolePK,BH,Name,CardNum,Sex,Age,WorkAge,BirthDay,MZ,Nationals,Province,Area,City,Address,PostalCode,OfficePhone,Phone,Mobile1,Mobile2,Mobile3,QQNum,ICQNum,MSNNum,Email,OtherLink,FatherPK,IsHasBaby,Grade,PKPath,pk_corp");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + base.BranchPK + "',");
            builder.Append("'" + base.RolePK + "',");
            builder.Append("'" + base.BH + "',");
            builder.Append("'" + base.Name + "',");
            builder.Append("'" + base.CardNum + "',");
            builder.Append("'" + base.Sex + "',");
            builder.Append(base.Age + ",");
            builder.Append(base.WorkAge + ",");
            builder.Append("to_date('" + base.BirthDay + "','yyyy-mm-dd hh24:mi:ss'),");
            builder.Append("'" + base.MZ + "',");
            builder.Append("'" + base.Nationals + "',");
            builder.Append("'" + base.Province + "',");
            builder.Append("'" + base.Area + "',");
            builder.Append("'" + base.City + "',");
            builder.Append("'" + base.Address + "',");
            builder.Append("'" + base.PostalCode + "',");
            builder.Append("'" + base.OfficePhone + "',");
            builder.Append("'" + base.Phone + "',");
            builder.Append("'" + base.Mobile1 + "',");
            builder.Append("'" + base.Mobile2 + "',");
            builder.Append("'" + base.Mobile3 + "',");
            builder.Append("'" + base.QQNum + "',");
            builder.Append("'" + base.ICQNum + "',");
            builder.Append("'" + base.MSNNum + "',");
            builder.Append(":Email,");
            builder.Append("'" + base.OtherLink + "',");
            builder.Append("'" + base.FatherPK + "',");
            builder.Append("'" + base.IsHasBaby + "',");
            builder.Append(base.Grade + ",");
            builder.Append("'" + base.PKPath + "',");
            builder.Append("'" + base.pk_corp + "'");
            builder.Append(")");
            Hashtable ht = new Hashtable();
            ht.Add(":Email", base.Email);
            return dbo.ExecutionIsSucess(builder.ToString(), ht);
        }

        public override int Delete(DB_OPT dbo)
        {
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter("emppk", OracleType.Char, 40) };
            parameters[0].Value = base.EmployeePK;
            return dbo.BuildQueryCommand("PROC_DELETEEMPLOYEE", parameters);
        }

        public override int Exists(string BH, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from DB_Employee where BH='" + BH + "'");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override int Exists(string col, string val, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(EmployeePK) from DB_Employee where " + col + "='" + val + "'");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override EmployeeModel[] GetChilds(string parentpk, bool bj_company, bool bj_branch, bool bj_role, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (parentpk != "")
            {
                builder.Append(" where FatherPK='" + parentpk + "'");
            }
            builder.Append(" order by EmployeePK");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            EmployeeModel[] modelArray = new EmployeeModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new EmployeeModel();
                modelArray[i] = this.Getem(set.Tables[0].Rows[i], true, false, bj_company, bj_branch, bj_role, dbo);
            }
            return modelArray;
        }

        public override EmployeeModel[] GetEgality(bool bj_child, bool bj_father, bool bj_company, bool bj_branch, bool bj_role, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (base.Grade >= 0)
            {
                builder.Append(" where Grade='" + base.Grade + "'");
            }
            else
            {
                if (base.EmployeePK == "")
                {
                    throw new Exception("条件不足.");
                }
                builder.Append(" where Grade=(select Grade from Employee where EmployeePK='" + base.EmployeePK + "')");
            }
            builder.Append(" order by EmployeePK");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            EmployeeModel[] modelArray = new EmployeeModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new EmployeeModel();
                modelArray[i] = this.Getem(set.Tables[0].Rows[i], bj_child, bj_father, bj_company, bj_branch, bj_role, dbo);
            }
            return modelArray;
        }

        private EmployeeModel Getem(DataRow dr, bool bj_child, bool bj_father, bool bj_company, bool bj_branch, bool bj_role, DB_OPT dbo)
        {
            EmployeeModel model = new EmployeeModel();
            if (bj_father)
            {
                model.BranchPK = dr["FatherPK"].ToString();
                model.FatherInfo = model.GetModel(false, false, false, false, true, dbo);
            }
            model.BranchPK = dr["BranchPK"].ToString().Trim();
            if (bj_branch)
            {
                BranchModel model2 = new BranchDal
                {
                    BranchPK = dr["BranchPK"].ToString()
                };
                model2 = model2.GetModel(false, false, false, false, dbo);
                model.Branch = model2;
            }
            model.RolePK = dr["RolePK"].ToString().Trim();
            if (bj_role)
            {
                RoleModel model3 = new RoleDal
                {
                    RolePK = dr["RolePK"].ToString()
                };
                model3 = model3.GetModel(false, false, dbo);
                model.Role = model3;
            }
            model.BH = dr["BH"].ToString();
            model.Name = dr["Name"].ToString();
            model.CardNum = dr["CardNum"].ToString();
            model.Sex = dr["Sex"].ToString();
            if (dr["Age"].ToString() != "")
            {
                model.Age = int.Parse(dr["Age"].ToString());
            }
            if (dr["WorkAge"].ToString() != "")
            {
                model.WorkAge = int.Parse(dr["WorkAge"].ToString());
            }
            if (dr["BirthDay"].ToString() != "")
            {
                model.BirthDay = DateTime.Parse(dr["BirthDay"].ToString());
            }
            model.MZ = dr["MZ"].ToString();
            model.Nationals = dr["Nationals"].ToString();
            model.Province = dr["Province"].ToString();
            model.Area = dr["Area"].ToString();
            model.City = dr["City"].ToString();
            model.Address = dr["Address"].ToString();
            model.PostalCode = dr["PostalCode"].ToString();
            model.OfficePhone = dr["OfficePhone"].ToString();
            model.Phone = dr["Phone"].ToString();
            model.Mobile1 = dr["Mobile1"].ToString();
            model.Mobile2 = dr["Mobile2"].ToString();
            model.Mobile3 = dr["Mobile3"].ToString();
            model.QQNum = dr["QQNum"].ToString();
            model.ICQNum = dr["ICQNum"].ToString();
            model.MSNNum = dr["MSNNum"].ToString();
            model.Email = dr["Email"].ToString();
            model.OtherLink = dr["OtherLink"].ToString();
            model.pk_corp = dr["pk_corp"].ToString();
            if (bj_company)
            {
                CompanyModel model4 = new CompanyDal
                {
                    pk_corp = dr["pk_corp"].ToString()
                };
                model4 = model4.GetModel(false, false, false, dbo);
                model.Company = model4;
            }
            model.FatherPK = dr["FatherPK"].ToString().Trim();
            model.IsHasBaby = dr["IsHasBaby"].ToString();
            if (dr["Grade"].ToString() != "")
            {
                model.Grade = int.Parse(dr["Grade"].ToString());
            }
            model.PKPath = dr["PKPath"].ToString();
            if ((dr["IsHasBaby"].ToString() == "1") && bj_child)
            {
                this.GetChilds(model.EmployeePK, false, false, false, dbo);
            }
            return model;
        }

        public override DataSet GetList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public override EmployeeModel GetModel(bool bj_child, bool bj_father, bool bj_company, bool bj_branch, bool bj_role, DB_OPT dbo)
        {
            new EmployeeModel();
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            builder.Append(" where EmployeePK='" + base.EmployeePK + "'");
            builder.Append(" order by EmployeePK");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.Getem(set.Tables[0].Rows[0], bj_child, bj_father, bj_company, bj_branch, bj_role, dbo);
            }
            return null;
        }

        public override EmployeeModel[] GetModels(string strwhere, bool bj_child, bool bj_father, bool bj_company, bool bj_branch, bool bj_role, DB_OPT dbo)
        {
            EmployeeModel[] modelArray = null;
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strwhere.Trim() != "")
            {
                builder.Append(" where " + strwhere);
            }
            builder.Append(" order by EmployeePK");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                modelArray = new EmployeeModel[set.Tables[0].Rows.Count];
                for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                {
                    modelArray[i] = new EmployeeModel();
                    modelArray[i] = this.Getem(set.Tables[0].Rows[i], bj_child, bj_father, bj_company, bj_branch, bj_role, dbo);
                }
            }
            return modelArray;
        }

        public override EmployeeModel[] GetParents(bool bj_company, bool bj_branch, bool bj_role, DB_OPT dbo)
        {
            string[] strArray;
            string str;
            int num;
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (base.PKPath != "")
            {
                strArray = base.PKPath.Split(new char[] { '|' });
                str = "";
                for (num = 0; num < strArray.Length; num++)
                {
                    str = str + "'" + strArray[num] + "',";
                }
                if (str.Length > 0)
                {
                    str = str.Substring(0, str.Length - 1);
                }
                builder.Append(" where EmployeePK in (" + str + ")");
            }
            else
            {
                if (!(base.EmployeePK != ""))
                {
                    throw new Exception("条件不足.");
                }
                string strSql = "select PKPath from Employee where EmployeePK='" + base.EmployeePK + "'";
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
                builder.Append(" where EmployeePK in (" + str.Substring(0, str.Length - 1) + ")");
            }
            builder.Append(" order by EmployeePK");
            DataSet set2 = dbo.BackDataSet(builder.ToString(), null);
            if (set2.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            EmployeeModel[] modelArray = new EmployeeModel[set2.Tables[0].Rows.Count];
            for (num = 0; num < set2.Tables[0].Rows.Count; num++)
            {
                modelArray[num] = new EmployeeModel();
                modelArray[num] = this.Getem(set2.Tables[0].Rows[num], false, true, bj_company, bj_branch, bj_role, dbo);
            }
            return modelArray;
        }

        private string GetSql()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select EMPLOYEEPK,BRANCHPK,ROLEPK,BH,NAME,CARDNUM,SEX,AGE,WORKAGE,BIRTHDAY,MZ,NATIONALS,PROVINCE,AREA,CITY,ADDRESS,POSTALCODE,OFFICEPHONE,PHONE,MOBILE1,MOBILE2,MOBILE3,QQNUM,ICQNUM,MSNNUM,OTHERLINK,EMAIL,PK_CORP,FATHERPK,ISHASBABY,GRADE,PKPATH,BNAME,RNAME,CNAME");
            builder.Append(" FROM gov_tc_view_Employee");
            return builder.ToString();
        }

        public override int Update(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_Employee set ");
            builder.Append("BranchPK='" + base.BranchPK + "',");
            builder.Append("RolePK='" + base.RolePK + "',");
            builder.Append("BH='" + base.BH + "',");
            builder.Append("Name='" + base.Name + "',");
            builder.Append("CardNum='" + base.CardNum + "',");
            builder.Append("Sex='" + base.Sex + "',");
            builder.Append("Age=" + base.Age + ",");
            builder.Append("WorkAge=" + base.WorkAge + ",");
            builder.Append("BirthDay=to_date('" + base.BirthDay + "','yyyy-mm-dd hh24:mi:ss'),");
            builder.Append("MZ='" + base.MZ + "',");
            builder.Append("Nationals='" + base.Nationals + "',");
            builder.Append("Province='" + base.Province + "',");
            builder.Append("Area='" + base.Area + "',");
            builder.Append("City='" + base.City + "',");
            builder.Append("Address='" + base.Address + "',");
            builder.Append("PostalCode='" + base.PostalCode + "',");
            builder.Append("OfficePhone='" + base.OfficePhone + "',");
            builder.Append("Phone='" + base.Phone + "',");
            builder.Append("Mobile1='" + base.Mobile1 + "',");
            builder.Append("Mobile2='" + base.Mobile2 + "',");
            builder.Append("Mobile3='" + base.Mobile3 + "',");
            builder.Append("QQNum='" + base.QQNum + "',");
            builder.Append("ICQNum='" + base.ICQNum + "',");
            builder.Append("MSNNum='" + base.MSNNum + "',");
            builder.Append("Email=:Email,");
            builder.Append("OtherLink='" + base.OtherLink + "',");
            builder.Append("FatherPK='" + base.FatherPK + "',");
            builder.Append("IsHasBaby='" + base.IsHasBaby + "',");
            builder.Append("Grade=" + base.Grade + ",");
            builder.Append("PKPath='" + base.PKPath + "',");
            builder.Append("pk_corp='" + base.pk_corp + "',");
            builder.Append("EmployeePK='" + base.EmployeePK + "'");
            builder.Append(" where EmployeePK='" + base.EmployeePK + "'");
            Hashtable ht = new Hashtable();
            ht.Add(":Email", base.Email);
            return dbo.ExecutionIsSucess(builder.ToString(), ht);
        }

        public override int UpdateHasBaby(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_Employee set ");
            if (base.IsHasBaby != "")
            {
                builder.Append("IsHasBaby='" + base.IsHasBaby + "'");
            }
            else
            {
                builder.Append("IsHasBaby='1'");
            }
            builder.Append(" where EmployeePK='" + base.EmployeePK + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int UpdatePKPathAndGrade(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_Employee set ");
            builder.Append("PKPath='" + base.PKPath + "', ");
            builder.Append("Grade=" + base.Grade);
            builder.Append(" where EmployeePK='" + base.EmployeePK + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

