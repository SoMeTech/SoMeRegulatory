namespace SoMeTech.ServicesClass.Services
{
    using SoMeTech.Company;
    using SoMeTech.Company.Branch;
       using SoMeTech.DataAccess;
    using SoMeTech.ServicesClass.Operation;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class ServicesMessDal : ServicesMessModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into gov_tc_db_ServicesMess(");
            builder.Append("BH,ServiceTypePK,ServiceRegisterPK,OperationPK,CompanyPK,BranchPK,PowerCode,Name,Discription,TaxFeeCallectionPK,IsShow,IsBLService,BLPKs,BLPassType,InPK,InPKJZJZ)");
            builder.Append(" values (");
            builder.Append(":BH,:ServiceTypePK,:ServiceRegisterPK,:OperationPK,:CompanyPK,:BranchPK,:PowerCode,:Name,:Discription,:TaxFeeCallectionPK,:IsShow,:IsBLService,:BLPKs,:BLPassType,:InPK,:InPKJZJZ)");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":BH", OracleType.VarChar, 40), new OracleParameter(":ServiceTypePK", OracleType.VarChar, 40), new OracleParameter(":ServiceRegisterPK", OracleType.Char, 40), new OracleParameter(":OperationPK", OracleType.Char, 40), new OracleParameter(":CompanyPK", OracleType.VarChar, 40), new OracleParameter(":BranchPK", OracleType.VarChar, 40), new OracleParameter(":PowerCode", OracleType.VarChar, 10), new OracleParameter(":Name", OracleType.VarChar, 40), new OracleParameter(":Discription", OracleType.VarChar, 0xff), new OracleParameter(":TaxFeeCallectionPK", OracleType.VarChar, 40), new OracleParameter(":IsShow", OracleType.Char, 1), new OracleParameter(":IsBLService", OracleType.Char, 1), new OracleParameter(":BLPKs", OracleType.VarChar, 0x834), new OracleParameter(":BLPassType", OracleType.VarChar, 40), new OracleParameter(":InPK", OracleType.VarChar, 40), new OracleParameter(":InPKJZJZ", OracleType.VarChar, 40) };
            parameters[0].Value = base.BH;
            parameters[1].Value = base.ServiceTypePK;
            parameters[2].Value = base.ServiceRegisterPK;
            parameters[3].Value = base.OperationPK;
            parameters[4].Value = base.CompanyPK;
            parameters[5].Value = base.BranchPK;
            parameters[6].Value = base.PowerCode;
            parameters[7].Value = base.Name;
            parameters[8].Value = base.Discription;
            parameters[9].Value = base.TaxFeeCallectionPK;
            parameters[10].Value = base.IsShow;
            parameters[11].Value = base.IsBLService;
            parameters[12].Value = base.BLPKs;
            parameters[13].Value = base.BLPassType;
            parameters[14].Value = base.InPK;
            parameters[15].Value = base.InPKJZJZ;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }

        public override int AddManyApply(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into gov_tc_db_ServicesMess(");
            builder.Append("BH,ServiceTypePK,OperationPK,Name,Discription,IsShow,IsBLService,BLPKs,BLPassType)");
            builder.Append(" values (");
            builder.Append(":BH,:ServiceTypePK,:OperationPK,:Name,:Discription,:IsShow,:IsBLService,:BLPKs,:BLPassType)");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":BH", OracleType.VarChar, 40), new OracleParameter(":ServiceTypePK", OracleType.VarChar, 40), new OracleParameter(":OperationPK", OracleType.Char, 40), new OracleParameter(":Name", OracleType.VarChar, 40), new OracleParameter(":Discription", OracleType.VarChar, 0xff), new OracleParameter(":IsShow", OracleType.Char, 1), new OracleParameter(":IsBLService", OracleType.Char, 1), new OracleParameter(":BLPKs", OracleType.VarChar, 0x834), new OracleParameter(":BLPassType", OracleType.VarChar, 40) };
            parameters[0].Value = base.BH;
            parameters[1].Value = base.ServiceTypePK;
            parameters[2].Value = base.OperationPK;
            parameters[3].Value = base.Name;
            parameters[4].Value = base.Discription;
            parameters[5].Value = base.IsShow;
            parameters[6].Value = base.IsBLService;
            parameters[7].Value = base.BLPKs;
            parameters[8].Value = base.BLPassType;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }

        public override int Delete(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from gov_tc_db_ServicesMess ");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char) };
            parameters[0].Value = base.PK;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }

        public override int Exists(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(PK) from gov_tc_db_ServicesMess");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.VarChar) };
            parameters[0].Value = base.PK;
            return dbo.BackIsSelect(builder.ToString(), parameters, "");
        }

        public override DataSet Exists(string Clo, string ColValue, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select " + Clo + " from gov_tc_db_ServicesMess");
            builder.Append(" where " + Clo + "=:ColValue");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":ColValue", OracleType.VarChar) };
            parameters[0].Value = ColValue;
            return dbo.BackDataSet(builder.ToString(), parameters, "");
        }

        public override DataSet GetList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by BH");
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public override ServicesMessModel GetModel(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char) };
            parameters[0].Value = base.PK;
            DataSet set = dbo.BackDataSet(builder.ToString(), parameters, "");
            if (set.Tables[0].Rows.Count > 0)
            {
                new ServicesMessModel();
                return this.GetModel(set.Tables[0].Rows[0], dbo);
            }
            return null;
        }

        public ServicesMessModel GetModel(DataRow dr, DB_OPT dbo)
        {
            ServicesMessModel model = new ServicesMessModel {
                PK = dr["PK"].ToString().Trim(),
                BH = dr["BH"].ToString().Trim(),
                ServiceTypePK = dr["ServiceTypePK"].ToString().Trim(),
                ServiceRegisterPK = dr["ServiceRegisterPK"].ToString().Trim()
            };
            if (model.ServiceRegisterPK.Trim() != "")
            {
                model.ServiceRegisterInfo = new ServicesRegisterDal { PK = model.ServiceRegisterPK.Trim() }.GetModel(false, false, dbo);
            }
            model.OperationPK = dr["OperationPK"].ToString().Trim();
            if (model.OperationPK.Trim() != "")
            {
                model.OperationInfo = new BusinessMessDal { PK = model.OperationPK.Trim() }.GetModel(dbo);
            }
            model.InPK = dr["InPK"].ToString().Trim();
            model.InPKJZJZ = dr["InPKJZJZ"].ToString().Trim();
            if (model.InPKJZJZ.Trim() != "")
            {
                model.InInfoJZJZ = new ServicesMessDal { PK = model.InPKJZJZ.Trim() }.GetModel(dbo);
            }
            model.CompanyPK = dr["CompanyPK"].ToString().Trim();
            if (model.CompanyPK.Trim() != "")
            {
                model.CompanyInfo = new CompanyDal { pk_corp = model.CompanyPK.Trim() }.GetModel(false, false, false, dbo);
            }
            model.BranchPK = dr["BranchPK"].ToString().Trim();
            if (model.BranchPK.Trim() != "")
            {
                model.BranchInfo = new BranchDal { BH = model.BranchPK.Trim() }.GetModel_BH(dbo);
            }
            model.TaxFeeCallectionPK = dr["TaxFeeCallectionPK"].ToString().Trim();
            if (model.TaxFeeCallectionPK.Trim() != "")
            {
                string strSql = "select Name FROM GOV_TC_DB_SFProject where PK='" + model.TaxFeeCallectionPK.Trim() + "'";
                model.TaxFeeCallectionName = dbo.SelectString(strSql, null);
            }
            model.PowerCode = dr["PowerCode"].ToString();
            model.Name = dr["Name"].ToString();
            model.Discription = dr["Discription"].ToString();
            model.IsShow = dr["IsShow"].ToString();
            model.IsBLService = dr["IsBLService"].ToString();
            model.BLPKs = dr["BLPKs"].ToString();
            model.BLPassType = dr["BLPassType"].ToString();
            return model;
        }

        public override ServicesMessModel[] GetModel(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strWhere != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by BH ");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            ServicesMessModel[] modelArray = null;
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            modelArray = new ServicesMessModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new ServicesMessModel();
                modelArray[i] = this.GetModel(set.Tables[0].Rows[i], dbo);
            }
            return modelArray;
        }

        public ServicesMessModel GetModelOnly(string pk, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char) };
            parameters[0].Value = pk;
            DataSet set = dbo.BackDataSet(builder.ToString(), parameters, "");
            if (set.Tables[0].Rows.Count > 0)
            {
                ServicesMessDal dal = new ServicesMessDal();
                return dal.GetModel(set.Tables[0].Rows[0], dbo);
            }
            return null;
        }

        public static ArrayList GetServices(string strs, DB_OPT dbo)
        {
            ArrayList arr = new ArrayList();
            string[] strArray = strs.Split(new char[] { '|' });
            ServicesMessModel sm = null;
            for (int i = 0; i < strArray.Length; i++)
            {
                sm = new ServicesMessDal {
                    PK = strArray[i]
                };
                sm = sm.GetModel(dbo);
                string bLPassType = sm.BLPassType;
                string[,] strArray2 = null;
                string isBLService = sm.IsBLService;
                if (isBLService != null)
                {
                    if (!(isBLService == "0"))
                    {
                        if (!(isBLService == "1"))
                        {
                            continue;
                        }
                        goto Label_00B1;
                    }
                    strArray2 = new string[,] { { (i + 1).ToString(), strArray[i] } };
                    arr.Add(strArray2);
                }
                continue;
            Label_00B1:;
                string[] strArray3 = sm.BLPKs.Split(new char[] { '~' });
                for (int j = 0; j < strArray3.Length; j++)
                {
                    string[] strArray4 = strArray3[j].Split(new char[] { '^' });
                    for (int k = 0; k < strArray4.Length; k++)
                    {
                        GetServices(ref arr, strArray, i, strArray4, k, j, strArray3.Length, strArray2, sm, bLPassType, bLPassType, dbo);
                    }
                }
            }
            return arr;
        }

        public static void GetServices(ref ArrayList arr, string[] strs1, int i, string[] strs3, int t, int j, int zxcount, string[,] sers, ServicesMessModel sm, string bltype, string zxbltype, DB_OPT dbo)
        {
            sm = new ServicesMessDal();
            sm.PK = strs3[t];
            sm = sm.GetModel(dbo);
            string isBLService = sm.IsBLService;
            if (isBLService != null)
            {
                if (!(isBLService == "0"))
                {
                    if (!(isBLService == "1"))
                    {
                        return;
                    }
                }
                else
                {
                    sers = new string[1, 2];
                    sers[0, 0] = (i + 1).ToString();
                    if (zxcount > 1)
                    {
                        string[] strArray = new string[] { bltype, ",", strs3[t], ",", (t + 1).ToString(), ",", (j + 1).ToString(), ",", zxbltype };
                        sers[0, 1] = string.Concat(strArray);
                    }
                    else
                    {
                        string[] strArray2 = new string[] { bltype, ",", strs3[t], ",", (t + 1).ToString(), ",," };
                        sers[0, 1] = string.Concat(strArray2);
                    }
                    arr.Add(sers);
                    return;
                }
                string[] strArray3 = sm.BLPKs.Split(new char[] { '~' });
                for (int k = 0; k < strArray3.Length; k++)
                {
                    string[] strArray4 = strArray3[k].Split(new char[] { '^' });
                    for (int m = 0; m < strArray4.Length; m++)
                    {
                        GetServices(ref arr, strs1, i, strArray4, m, j, zxcount, sers, sm, sm.BLPassType, zxbltype, dbo);
                    }
                }
            }
        }

        public static string GetServicesMessColsName()
        {
            return " PK,BH,SERVICETYPEPK,SERVICEREGISTERPK,OPERATIONPK,INPK,INPKJZJZ,COMPANYPK,BRANCHPK,POWERCODE,NAME,DISCRIPTION,ISSHOW,ISBLSERVICE,BLPKS,BLPASSTYPE,TAXFEECALLECTIONPK ";
        }

        private string GetSql()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,BH,SERVICETYPEPK,SERVICEREGISTERPK,OPERATIONPK,INPK,INPKJZJZ,COMPANYPK,BRANCHPK,POWERCODE,NAME,DISCRIPTION,ISSHOW,ISBLSERVICE,BLPKS,BLPASSTYPE,TAXFEECALLECTIONPK,NAME MeNAME ");
            builder.Append(" FROM gov_tc_db_ServicesMess ");
            return builder.ToString();
        }

        public static string GetViewServicesColsName()
        {
            return "PK,BH,ServiceTypePK,ServiceRegisterPK,OperationPK,INPK,INPKJZJZ,CompanyPK,BranchPK,PowerCode,Name,Discription,TaxFeeCallectionPK,IsShow,IsBLService,BLPKs,BLPassType,Path,ClassName,ContParameters,IfTwoCont,Method,IfTwoMet,Parameters,GetServiceType,StartSign,InTime,OutTime,FatherPK,PKPath,Grade,IsHasBaby,ServicesTypeName,COMPANYNAME";
        }

        public override int Update(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update gov_tc_db_ServicesMess set ");
            builder.Append("BH=:BH,");
            builder.Append("ServiceTypePK=:ServiceTypePK,");
            builder.Append("ServiceRegisterPK=:ServiceRegisterPK,");
            builder.Append("OperationPK=:OperationPK,");
            builder.Append("CompanyPK=:CompanyPK,");
            builder.Append("BranchPK=:BranchPK,");
            builder.Append("PowerCode=:PowerCode,");
            builder.Append("Name=:Name,");
            builder.Append("Discription=:Discription,");
            builder.Append("TaxFeeCallectionPK=:TaxFeeCallectionPK,");
            builder.Append("IsShow=:IsShow,");
            builder.Append("IsBLService=:IsBLService,");
            builder.Append("BLPKs=:BLPKs,");
            builder.Append("BLPassType=:BLPassType,");
            builder.Append("InPK=:InPK,");
            builder.Append("InPKJZJZ=:InPKJZJZ");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { 
                new OracleParameter(":BH", OracleType.VarChar, 40), new OracleParameter(":ServiceTypePK", OracleType.VarChar, 40), new OracleParameter(":ServiceRegisterPK", OracleType.Char, 40), new OracleParameter(":OperationPK", OracleType.Char, 40), new OracleParameter(":CompanyPK", OracleType.VarChar, 40), new OracleParameter(":BranchPK", OracleType.VarChar, 40), new OracleParameter(":PowerCode", OracleType.VarChar, 10), new OracleParameter(":Name", OracleType.VarChar, 40), new OracleParameter(":Discription", OracleType.VarChar, 0xff), new OracleParameter(":TaxFeeCallectionPK", OracleType.VarChar, 40), new OracleParameter(":IsShow", OracleType.Char, 1), new OracleParameter(":IsBLService", OracleType.Char, 1), new OracleParameter(":BLPKs", OracleType.VarChar, 0x834), new OracleParameter(":BLPassType", OracleType.VarChar, 40), new OracleParameter(":InPK", OracleType.VarChar, 40), new OracleParameter(":InPKJZJZ", OracleType.VarChar, 40), 
                new OracleParameter(":PK", OracleType.Char, 40)
             };
            parameters[0].Value = base.BH;
            parameters[1].Value = base.ServiceTypePK;
            parameters[2].Value = base.ServiceRegisterPK;
            parameters[3].Value = base.OperationPK;
            parameters[4].Value = base.CompanyPK;
            parameters[5].Value = base.BranchPK;
            parameters[6].Value = base.PowerCode;
            parameters[7].Value = base.Name;
            parameters[8].Value = base.Discription;
            parameters[9].Value = base.TaxFeeCallectionPK;
            parameters[10].Value = base.IsShow;
            parameters[11].Value = base.IsBLService;
            parameters[12].Value = base.BLPKs;
            parameters[13].Value = base.BLPassType;
            parameters[14].Value = base.InPK;
            parameters[15].Value = base.InPKJZJZ;
            parameters[0x10].Value = base.PK;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }

        public override int UpdateManyApply(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update gov_tc_db_ServicesMess set ");
            builder.Append("BH=:BH,ServiceTypePK=:ServiceTypePK,OperationPK=:OperationPK,Name=:Name,Discription=:Discription,IsShow=:IsShow,IsBLService=:IsBLService,BLPKs=:BLPKs,BLPassType=:BLPassType where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":BH", OracleType.VarChar, 40), new OracleParameter(":ServiceTypePK", OracleType.VarChar, 40), new OracleParameter(":OperationPK", OracleType.Char, 40), new OracleParameter(":Name", OracleType.VarChar, 40), new OracleParameter(":Discription", OracleType.VarChar, 0xff), new OracleParameter(":IsShow", OracleType.Char, 1), new OracleParameter(":IsBLService", OracleType.Char, 1), new OracleParameter(":BLPKs", OracleType.VarChar, 0x834), new OracleParameter(":BLPassType", OracleType.VarChar, 40), new OracleParameter(":PK", OracleType.Char, 40) };
            parameters[0].Value = base.BH;
            parameters[1].Value = base.ServiceTypePK;
            parameters[2].Value = base.OperationPK;
            parameters[3].Value = base.Name;
            parameters[4].Value = base.Discription;
            parameters[5].Value = base.IsShow;
            parameters[6].Value = base.IsBLService;
            parameters[7].Value = base.BLPKs;
            parameters[8].Value = base.BLPassType;
            parameters[9].Value = base.PK;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }
    }
}

