namespace SoMeTech.Company
{
    using SoMeTech.Company.Branch;
       using SoMeTech.DataAccess;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class CompanyDal : CompanyModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into DB_Company(");
            builder.Append("pk_corp,BH,Name,ShortName,KeyChar,Country,Province,Area,Address,PostalCode,Url,Email1,Email2,Email3,Phone1,Phone2,Phone3,Fax1,Fax2,Fax3,linkman1,linkman2,Holder,RegMoney,BankPK,FPDWM,InvoiceType,DutyNum,Discription,FatherPK,IsHasBaby,Grade,PKPath,ZXBJ");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + base.pk_corp + "',");
            builder.Append("'" + base.BH + "',");
            builder.Append("'" + base.Name + "',");
            builder.Append("'" + base.ShortName + "',");
            builder.Append("'" + base.KeyChar + "',");
            builder.Append("'" + base.Country + "',");
            builder.Append("'" + base.Province + "',");
            builder.Append("'" + base.Area + "',");
            builder.Append("'" + base.Address + "',");
            builder.Append("'" + base.PostalCode + "',");
            builder.Append("'" + base.Url + "',");
            builder.Append(":Email1,:Email2,:Email3,");
            builder.Append("'" + base.Phone1 + "',");
            builder.Append("'" + base.Phone2 + "',");
            builder.Append("'" + base.Phone3 + "',");
            builder.Append("'" + base.Fax1 + "',");
            builder.Append("'" + base.Fax2 + "',");
            builder.Append("'" + base.Fax3 + "',");
            builder.Append("'" + base.linkman1 + "',");
            builder.Append("'" + base.linkman2 + "',");
            builder.Append("'" + base.Holder + "',");
            builder.Append(base.RegMoney + ",");
            builder.Append("'" + base.BankPK + "',");
            builder.Append("'" + base.FPDWM + "',");
            builder.Append("'" + base.InvoiceType + "',");
            builder.Append("'" + base.DutyNum + "',");
            builder.Append("'" + base.Discription + "',");
            builder.Append("'" + base.FatherPK + "',");
            builder.Append("'" + base.IsHasBaby + "',");
            builder.Append(base.Grade + ",");
            builder.Append("'" + base.PKPath + "',");
            builder.Append("'" + base.ZXBJ + "'");
            builder.Append(")");
            Hashtable ht = new Hashtable();
            ht.Add(":Email1", base.Email1);
            ht.Add(":Email2", base.Email2);
            ht.Add(":Email3", base.Email3);
            return dbo.ExecutionIsSucess(builder.ToString(), ht);
        }

        public override int Delete(DB_OPT dbo)
        {
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter("compk", OracleType.Char, 4) };
            parameters[0].Value = base.pk_corp;
            return dbo.BuildQueryCommand("PROC_DELETECOMPANY", parameters);
        }

        public override int Exists(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(pk_corp) from DB_Company where pk_corp='" + base.pk_corp + "'");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override int Exists(string bh, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from DB_Company where BH='" + bh + "'");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override CompanyModel[] GetChilds(string parentpk, bool bj_branch, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (parentpk != "")
            {
                builder.Append(" where FatherPK='" + parentpk + "' and FatherPK!=PK_CORP");
            }
            builder.Append(" order by pk_corp");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            CompanyModel[] modelArray = new CompanyModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new CompanyModel();
                modelArray[i] = this.Getcm(set.Tables[0].Rows[i], true, false, bj_branch, dbo);
            }
            return modelArray;
        }

        private CompanyModel Getcm(DataRow dr, bool bj_child, bool bj_father, bool bj_branch, DB_OPT dbo)
        {
            CompanyModel model = new CompanyDal();
            if (bj_father)
            {
                model.pk_corp = dr["FatherPK"].ToString();
                model.FatherInfo = model.GetModel(false, false, true, dbo);
            }
            model.pk_corp = dr["pk_corp"].ToString();
            model.Name = dr["Name"].ToString();
            model.ShortName = dr["ShortName"].ToString();
            model.KeyChar = dr["KeyChar"].ToString();
            model.Country = dr["Country"].ToString();
            model.Province = dr["Province"].ToString();
            model.Area = dr["Area"].ToString();
            model.Address = dr["Address"].ToString();
            model.PostalCode = dr["PostalCode"].ToString();
            model.Url = dr["Url"].ToString();
            model.Email1 = dr["Email1"].ToString();
            model.Email2 = dr["Email2"].ToString();
            model.Email3 = dr["Email3"].ToString();
            model.Phone1 = dr["Phone1"].ToString();
            model.Phone2 = dr["Phone2"].ToString();
            model.Phone3 = dr["Phone3"].ToString();
            model.Fax1 = dr["Fax1"].ToString();
            model.Fax2 = dr["Fax2"].ToString();
            model.Fax3 = dr["Fax3"].ToString();
            model.linkman1 = dr["linkman1"].ToString();
            model.linkman2 = dr["linkman2"].ToString();
            model.Holder = dr["Holder"].ToString();
            if (dr["RegMoney"].ToString() != "")
            {
                model.RegMoney = decimal.Parse(dr["RegMoney"].ToString());
            }
            model.BankPK = dr["BankPK"].ToString().Trim();
            model.FPDWM = dr["FPDWM"].ToString();
            model.InvoiceType = dr["InvoiceType"].ToString();
            model.DutyNum = dr["DutyNum"].ToString();
            model.Discription = dr["Discription"].ToString();
            model.FatherPK = dr["FatherPK"].ToString().Trim();
            model.IsHasBaby = dr["IsHasBaby"].ToString();
            if (dr["Grade"].ToString() != "")
            {
                model.Grade = int.Parse(dr["Grade"].ToString());
            }
            model.PKPath = dr["PKPath"].ToString();
            model.ZXBJ = dr["ZXBJ"].ToString();
            if (bj_father)
            {
                model.Childs_Branch = new BranchDal().GetModels("pk_corp='" + dr["pk_corp"].ToString() + "'", false, false, false, true, dbo);
            }
            if ((dr["IsHasBaby"].ToString() == "1") && !bj_child)
            {
                model.Childs_Company = this.GetChilds(model.pk_corp, true, dbo);
            }
            return model;
        }

        public static void GetCompanyName(string pk_corp, ref string ccode, ref string cname, DB_OPT dbo)
        {
            string strSql = "select Name from DB_Company where pk_corp='" + pk_corp + "'";
            DataSet set = dbo.BackDataSet(strSql, null);
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                ccode = pk_corp;
                cname = set.Tables[0].Rows[0]["Name"].ToString();
            }
        }

        public override CompanyModel[] GetEgality(bool bj_child, bool bj_father, bool bj_branch, DB_OPT dbo)
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
                builder.Append(" where Grade=(select Grade from DB_Company where pk_corp='" + base.pk_corp + "')");
            }
            builder.Append(" order by pk_corp");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            CompanyModel[] modelArray = new CompanyModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new CompanyModel();
                modelArray[i] = this.Getcm(set.Tables[0].Rows[i], bj_child, bj_father, bj_branch, dbo);
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
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public override CompanyModel GetModel(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            builder.Append(" where pk_corp='" + base.pk_corp + "'");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            base.BH = set.Tables[0].Rows[0]["BH"].ToString();
            base.Name = set.Tables[0].Rows[0]["Name"].ToString();
            base.ShortName = set.Tables[0].Rows[0]["ShortName"].ToString();
            base.KeyChar = set.Tables[0].Rows[0]["KeyChar"].ToString();
            base.Country = set.Tables[0].Rows[0]["Country"].ToString();
            base.Province = set.Tables[0].Rows[0]["Province"].ToString();
            base.Area = set.Tables[0].Rows[0]["Area"].ToString();
            base.Address = set.Tables[0].Rows[0]["Address"].ToString();
            base.PostalCode = set.Tables[0].Rows[0]["PostalCode"].ToString();
            base.Url = set.Tables[0].Rows[0]["Url"].ToString();
            base.Email1 = set.Tables[0].Rows[0]["Email1"].ToString();
            base.Email2 = set.Tables[0].Rows[0]["Email2"].ToString();
            base.Email3 = set.Tables[0].Rows[0]["Email3"].ToString();
            base.Phone1 = set.Tables[0].Rows[0]["Phone1"].ToString();
            base.Phone2 = set.Tables[0].Rows[0]["Phone2"].ToString();
            base.Phone3 = set.Tables[0].Rows[0]["Phone3"].ToString();
            base.Fax1 = set.Tables[0].Rows[0]["Fax1"].ToString();
            base.Fax2 = set.Tables[0].Rows[0]["Fax2"].ToString();
            base.Fax3 = set.Tables[0].Rows[0]["Fax3"].ToString();
            base.linkman1 = set.Tables[0].Rows[0]["linkman1"].ToString();
            base.linkman2 = set.Tables[0].Rows[0]["linkman2"].ToString();
            base.Holder = set.Tables[0].Rows[0]["Holder"].ToString();
            if (set.Tables[0].Rows[0]["RegMoney"].ToString() != "")
            {
                base.RegMoney = decimal.Parse(set.Tables[0].Rows[0]["RegMoney"].ToString());
            }
            base.BankPK = set.Tables[0].Rows[0]["BankPK"].ToString();
            base.FPDWM = set.Tables[0].Rows[0]["FPDWM"].ToString();
            base.InvoiceType = set.Tables[0].Rows[0]["InvoiceType"].ToString();
            base.DutyNum = set.Tables[0].Rows[0]["DutyNum"].ToString();
            base.Discription = set.Tables[0].Rows[0]["Discription"].ToString();
            base.FatherPK = set.Tables[0].Rows[0]["FatherPK"].ToString();
            base.IsHasBaby = set.Tables[0].Rows[0]["IsHasBaby"].ToString();
            if (set.Tables[0].Rows[0]["Grade"].ToString() != "")
            {
                base.Grade = int.Parse(set.Tables[0].Rows[0]["Grade"].ToString());
            }
            base.PKPath = set.Tables[0].Rows[0]["PKPath"].ToString();
            base.ZXBJ = set.Tables[0].Rows[0]["ZXBJ"].ToString();
            return this;
        }

        public override CompanyModel GetModel(bool bj_child, bool bj_father, bool bj_branch, DB_OPT dbo)
        {
            new CompanyModel();
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            builder.Append(" where pk_corp='" + base.pk_corp + "'");
            builder.Append(" order by pk_corp");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.Getcm(set.Tables[0].Rows[0], bj_child, bj_father, bj_branch, dbo);
            }
            return null;
        }

        public override CompanyModel[] GetModels(string strwhere, bool bj_child, bool bj_father, bool bj_branch, DB_OPT dbo)
        {
            CompanyModel[] modelArray = null;
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strwhere.Trim() != "")
            {
                builder.Append(" where " + strwhere);
            }
            builder.Append(" order by pk_corp");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                modelArray = new CompanyModel[set.Tables[0].Rows.Count];
                for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                {
                    modelArray[i] = new CompanyModel();
                    modelArray[i] = this.Getcm(set.Tables[0].Rows[i], bj_child, bj_father, bj_branch, dbo);
                }
            }
            return modelArray;
        }

        public override CompanyModel[] GetParents(bool bj_branch, DB_OPT dbo)
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
                str = str.Substring(0, str.Length - 1);
                builder.Append(" where pk_corp in (" + str + ")");
            }
            else
            {
                if (!(base.pk_corp != ""))
                {
                    throw new Exception("条件不足.");
                }
                string strSql = "select PKPath from DB_Company where pk_corp='" + base.pk_corp + "'";
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
                builder.Append(" where pk_corp in (" + str.Substring(0, str.Length - 1) + ")");
            }
            builder.Append(" order by pk_corp");
            DataSet set2 = dbo.BackDataSet(builder.ToString(), null);
            if (set2.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            CompanyModel[] modelArray = new CompanyModel[set2.Tables[0].Rows.Count];
            for (num = 0; num < set2.Tables[0].Rows.Count; num++)
            {
                modelArray[num] = new CompanyModel();
                modelArray[num] = this.Getcm(set2.Tables[0].Rows[num], false, true, bj_branch, dbo);
            }
            return modelArray;
        }

        private string GetSql()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ");
            builder.Append(" pk_corp,BH,Name,ShortName,KeyChar,Country,Province,Area,Address,PostalCode,Url,Email1,Email2,Email3,Phone1,Phone2,Phone3,Fax1,Fax2,Fax3,linkman1,linkman2,Holder,RegMoney,BankPK,FPDWM,InvoiceType,DutyNum,Discription,FatherPK,IsHasBaby,Grade,PKPath,ZXBJ ");
            builder.Append(" from DB_Company ");
            return builder.ToString();
        }

        public override int Update(string oldpk, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_Company set ");
            builder.Append("pk_corp='" + base.pk_corp + "',");
            builder.Append("BH='" + base.BH + "',");
            builder.Append("Name='" + base.Name + "',");
            builder.Append("ShortName='" + base.ShortName + "',");
            builder.Append("KeyChar='" + base.KeyChar + "',");
            builder.Append("Country='" + base.Country + "',");
            builder.Append("Province='" + base.Province + "',");
            builder.Append("Area='" + base.Area + "',");
            builder.Append("Address='" + base.Address + "',");
            builder.Append("PostalCode='" + base.PostalCode + "',");
            builder.Append("Url='" + base.Url + "',");
            builder.Append("Email1=:Email1,");
            builder.Append("Email2=:Email2,");
            builder.Append("Email3=:Email3,");
            builder.Append("Phone1='" + base.Phone1 + "',");
            builder.Append("Phone2='" + base.Phone2 + "',");
            builder.Append("Phone3='" + base.Phone3 + "',");
            builder.Append("Fax1='" + base.Fax1 + "',");
            builder.Append("Fax2='" + base.Fax2 + "',");
            builder.Append("Fax3='" + base.Fax3 + "',");
            builder.Append("linkman1='" + base.linkman1 + "',");
            builder.Append("linkman2='" + base.linkman2 + "',");
            builder.Append("Holder='" + base.Holder + "',");
            builder.Append("RegMoney=" + base.RegMoney + ",");
            builder.Append("BankPK='" + base.BankPK + "',");
            builder.Append("FPDWM='" + base.FPDWM + "',");
            builder.Append("InvoiceType='" + base.InvoiceType + "',");
            builder.Append("DutyNum='" + base.DutyNum + "',");
            builder.Append("Discription='" + base.Discription + "',");
            builder.Append("FatherPK='" + base.FatherPK + "',");
            builder.Append("IsHasBaby='" + base.IsHasBaby + "',");
            builder.Append("Grade=" + base.Grade + ",");
            builder.Append("PKPath='" + base.PKPath + "',");
            builder.Append("ZXBJ='" + base.ZXBJ + "'");
            builder.Append(" where pk_corp='" + oldpk + "'");
            Hashtable ht = new Hashtable();
            ht.Add(":Email1", base.Email1);
            ht.Add(":Email2", base.Email2);
            ht.Add(":Email3", base.Email3);
            return dbo.ExecutionIsSucess(builder.ToString(), ht);
        }

        public override int UpdateHasBaby(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_Company set ");
            if (base.IsHasBaby != "")
            {
                builder.Append("IsHasBaby='" + base.IsHasBaby + "'");
            }
            else
            {
                builder.Append("IsHasBaby='1'");
            }
            builder.Append(" where pk_corp='" + base.pk_corp + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int UpdatePKPathAndGrade(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_Company set ");
            builder.Append("PKPath='" + base.PKPath + "', ");
            builder.Append("Grade=" + base.Grade);
            builder.Append(" where pk_corp='" + base.pk_corp + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int UpdateZXBJ(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_Company set ");
            builder.Append("ZXBJ='" + base.ZXBJ + "'");
            builder.Append(" where pk_corp='" + base.pk_corp + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

