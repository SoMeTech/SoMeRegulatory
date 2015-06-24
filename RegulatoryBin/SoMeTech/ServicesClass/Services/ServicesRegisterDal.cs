namespace SoMeTech.ServicesClass.Services
{
       using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class ServicesRegisterDal : ServicesRegisterModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into gov_tc_db_ServicesRegister(");
            builder.Append("ServiceTypePK,Name,Path,ClassName,ContParameters,IfTwoCont,Method,IfTwoMet,Parameters,Discription,GetServiceType,StartSign,InTime,OutTime,FatherPK,IsHasBaby,Grade,PKPath,MaxNum)");
            builder.Append(" values (");
            builder.Append(":ServiceTypePK,:Name,:Path,:ClassName,:ContParameters,:IfTwoCont,:Method,:IfTwoMet,:Parameters,:Discription,:GetServiceType,:StartSign,:InTime,:OutTime,:FatherPK,:IsHasBaby,:Grade,:PKPath,:MaxNum)");
            OracleParameter[] parameters = new OracleParameter[] { 
                new OracleParameter(":ServiceTypePK", OracleType.Char, 40), new OracleParameter(":Name", OracleType.VarChar, 40), new OracleParameter(":Path", OracleType.VarChar, 0xff), new OracleParameter(":ClassName", OracleType.VarChar, 40), new OracleParameter(":ContParameters", OracleType.VarChar, 0xff), new OracleParameter(":IfTwoCont", OracleType.Char, 1), new OracleParameter(":Method", OracleType.VarChar, 40), new OracleParameter(":IfTwoMet", OracleType.Char, 1), new OracleParameter(":Parameters", OracleType.VarChar, 0xff), new OracleParameter(":Discription", OracleType.VarChar, 0xff), new OracleParameter(":GetServiceType", OracleType.VarChar, 1), new OracleParameter(":StartSign", OracleType.VarChar, 1), new OracleParameter(":InTime", OracleType.DateTime, 40), new OracleParameter(":OutTime", OracleType.DateTime, 40), new OracleParameter(":FatherPK", OracleType.VarChar, 40), new OracleParameter(":IsHasBaby", OracleType.Char, 1), 
                new OracleParameter(":Grade", OracleType.Int32, 4), new OracleParameter(":PKPath", OracleType.Clob), new OracleParameter(":MaxNum", OracleType.Int32, 4)
             };
            parameters[0].Value = base.ServiceTypePK;
            parameters[1].Value = base.Name;
            parameters[2].Value = base.Path;
            parameters[3].Value = base.ClassName;
            parameters[4].Value = base.ContParameters;
            parameters[5].Value = base.IfTwoCont;
            parameters[6].Value = base.Method;
            parameters[7].Value = base.IfTwoMet;
            parameters[8].Value = base.Parameters;
            parameters[9].Value = base.Discription;
            parameters[10].Value = base.GetServiceType;
            parameters[11].Value = base.StartSign;
            parameters[12].Value = base.InTime;
            parameters[13].Value = base.OutTime;
            parameters[14].Value = base.FatherPK;
            parameters[15].Value = base.IsHasBaby;
            parameters[0x10].Value = base.Grade;
            parameters[0x11].Value = base.PKPath;
            parameters[0x12].Value = base.MaxNum;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }

        public override int Delete(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from gov_tc_db_ServicesRegister ");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char, 40) };
            parameters[0].Value = base.PK;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }

        public override int Exists(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(PK) from gov_tc_db_ServicesRegister");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.VarChar) };
            parameters[0].Value = base.PK;
            return dbo.BackIsSelect(builder.ToString(), parameters, "");
        }

        public override ServicesRegisterModel[] GetChilds(string parentpk, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (parentpk != "")
            {
                builder.Append(" where FatherPK='" + parentpk + "'");
            }
            builder.Append(" order by PK");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            ServicesRegisterModel[] modelArray = new ServicesRegisterModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new ServicesRegisterModel();
                modelArray[i] = this.GetModel(set.Tables[0].Rows[i], false, false, dbo);
            }
            return modelArray;
        }

        public override ServicesRegisterModel[] GetEgality(bool bj_child, bool bj_tache, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
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
                builder.Append(" where Grade=(select Grade from gov_tc_db_ServicesRegister where PK='" + base.PK + "')");
            }
            builder.Append(" order by PK");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            ServicesRegisterModel[] modelArray = new ServicesRegisterModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new ServicesRegisterModel();
                modelArray[i] = this.GetModel(set.Tables[0].Rows[i], bj_child, bj_tache, dbo);
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

        public override ServicesRegisterModel GetModel(bool bj_child, bool bj_tache, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char, 40) };
            parameters[0].Value = base.PK;
            DataSet set = dbo.BackDataSet(builder.ToString(), parameters, "");
            if (set.Tables[0].Rows.Count > 0)
            {
                new ServicesRegisterModel();
                return this.GetModel(set.Tables[0].Rows[0], bj_child, bj_tache, dbo);
            }
            return null;
        }

        private ServicesRegisterModel GetModel(DataRow dr, bool bj_child, bool bj_tache, DB_OPT dbo)
        {
            ServicesRegisterModel model = new ServicesRegisterDal {
                PK = dr["PK"].ToString().Trim(),
                ServiceTypePK = dr["ServiceTypePK"].ToString().Trim(),
                Name = dr["Name"].ToString().Trim(),
                Path = dr["Path"].ToString().Trim(),
                ClassName = dr["ClassName"].ToString().Trim(),
                ContParameters = dr["ContParameters"].ToString().Trim(),
                IfTwoCont = dr["IfTwoCont"].ToString().Trim(),
                Method = dr["Method"].ToString().Trim(),
                IfTwoMet = dr["IfTwoMet"].ToString().Trim(),
                Parameters = dr["Parameters"].ToString().Trim(),
                Discription = dr["Discription"].ToString().Trim(),
                GetServiceType = dr["GetServiceType"].ToString().Trim(),
                StartSign = dr["StartSign"].ToString().Trim(),
                InTime = DateTime.Parse(dr["InTime"].ToString()),
                OutTime = DateTime.Parse(dr["OutTime"].ToString()),
                FatherPK = dr["FatherPK"].ToString().Trim(),
                IsHasBaby = dr["IsHasBaby"].ToString().Trim(),
                PKPath = dr["PKPath"].ToString().Trim(),
                MaxNum = int.Parse(dr["MaxNum"].ToString().Trim()),
                Grade = int.Parse(dr["Grade"].ToString().Trim())
            };
            bool flag1 = dr["IsHasBaby"].ToString() == "1";
            return model;
        }

        public override ServicesRegisterModel[] GetModel(string strWhere, bool bj_child, bool bj_tache, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strWhere != "")
            {
                builder.Append(" where " + strWhere);
            }
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            ServicesRegisterModel[] modelArray = null;
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            modelArray = new ServicesRegisterModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new ServicesRegisterModel();
                modelArray[i] = this.GetModel(set.Tables[0].Rows[i], bj_child, bj_tache, dbo);
            }
            return modelArray;
        }

        public override ServicesRegisterModel[] GetParents(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (base.PKPath != "")
            {
                string[] strArray = base.PKPath.Split(new char[] { '|' });
                string str = "";
                for (int j = 0; j < strArray.Length; j++)
                {
                    str = str + "'" + strArray[j] + "',";
                }
                builder.Append(" where PK in (" + str.Substring(0, str.Length - 1) + ")");
            }
            else
            {
                if (!(base.PK != ""))
                {
                    throw new Exception("条件不足.");
                }
                string strSql = "select PKPath from gov_tc_db_ServicesRegister where PK='" + base.PK + "'";
                DataSet set = dbo.BackDataSet(strSql, null);
                if (!(set.Tables[0].Rows[0][0].ToString() != ""))
                {
                    throw new Exception("没有上级.");
                }
                string[] strArray2 = set.Tables[0].Rows[0][0].ToString().Split(new char[] { '|' });
                string str3 = "";
                for (int k = 0; k < strArray2.Length; k++)
                {
                    str3 = str3 + "'" + strArray2[k] + "',";
                }
                builder.Append(" where PK in (" + str3.Substring(0, str3.Length - 1) + ")");
            }
            builder.Append(" order by PK");
            DataSet set2 = dbo.BackDataSet(builder.ToString(), null);
            if (set2.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            ServicesRegisterModel[] modelArray = new ServicesRegisterModel[set2.Tables[0].Rows.Count];
            for (int i = 0; i < set2.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new ServicesRegisterModel();
                modelArray[i] = this.GetModel(set2.Tables[0].Rows[i], false, false, dbo);
            }
            return modelArray;
        }

        public static string GetServicesRegisterColsName()
        {
            return "PK,SERVICETYPEPK,NAME,PATH,CLASSNAME,CONTPARAMETERS,IFTWOCONT,METHOD,IFTWOMET,PARAMETERS,DISCRIPTION,GETSERVICETYPE,MAXNUM,STARTSIGN,INTIME,OUTTIME,FATHERPK,PKPATH,GRADE,ISHASBABY";
        }

        private string GetSql()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,SERVICETYPEPK,NAME,PATH,CLASSNAME,CONTPARAMETERS,IFTWOCONT,METHOD,IFTWOMET,PARAMETERS,DISCRIPTION,GETSERVICETYPE,MAXNUM,STARTSIGN,INTIME,OUTTIME,FATHERPK,PKPATH,GRADE,ISHASBABY");
            builder.Append(" FROM gov_tc_db_ServicesRegister ");
            return builder.ToString();
        }

        public override int Update(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update gov_tc_db_ServicesRegister set ");
            builder.Append("ServiceTypePK=:ServiceTypePK,");
            builder.Append("Name=:Name,");
            builder.Append("Path=:Path,");
            builder.Append("ClassName=:ClassName,");
            builder.Append("ContParameters=:ContParameters,");
            builder.Append("IfTwoCont=:IfTwoCont,");
            builder.Append("Method=:Method,");
            builder.Append("IfTwoMet=:IfTwoMet,");
            builder.Append("Parameters=:Parameters,");
            builder.Append("Discription=:Discription,");
            builder.Append("GetServiceType=:GetServiceType,");
            builder.Append("StartSign=:StartSign,");
            builder.Append("InTime=:InTime,");
            builder.Append("OutTime=:OutTime,");
            builder.Append("FatherPK=:FatherPK,");
            builder.Append("IsHasBaby=:IsHasBaby,");
            builder.Append("Grade=:Grade,");
            builder.Append("PKPath=:PKPath,");
            builder.Append("MaxNum=:MaxNum");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { 
                new OracleParameter(":ServiceTypePK", OracleType.Char, 40), new OracleParameter(":Name", OracleType.VarChar, 40), new OracleParameter(":Path", OracleType.VarChar, 0xff), new OracleParameter(":ClassName", OracleType.VarChar, 40), new OracleParameter(":ContParameters", OracleType.VarChar, 0xff), new OracleParameter(":IfTwoCont", OracleType.Char, 1), new OracleParameter(":Method", OracleType.VarChar, 40), new OracleParameter(":IfTwoMet", OracleType.Char, 1), new OracleParameter(":Parameters", OracleType.VarChar, 0xff), new OracleParameter(":Discription", OracleType.VarChar, 0xff), new OracleParameter(":GetServiceType", OracleType.VarChar, 1), new OracleParameter(":StartSign", OracleType.VarChar, 1), new OracleParameter(":InTime", OracleType.DateTime, 40), new OracleParameter(":OutTime", OracleType.DateTime, 40), new OracleParameter(":FatherPK", OracleType.VarChar, 40), new OracleParameter(":IsHasBaby", OracleType.Char, 1), 
                new OracleParameter(":Grade", OracleType.Int32, 4), new OracleParameter(":PKPath", OracleType.Clob), new OracleParameter(":MaxNum", OracleType.Int32, 4), new OracleParameter(":PK", OracleType.Char, 40)
             };
            parameters[0].Value = base.ServiceTypePK;
            parameters[1].Value = base.Name;
            parameters[2].Value = base.Path;
            parameters[3].Value = base.ClassName;
            parameters[4].Value = base.ContParameters;
            parameters[5].Value = base.IfTwoCont;
            parameters[6].Value = base.Method;
            parameters[7].Value = base.IfTwoMet;
            parameters[8].Value = base.Parameters;
            parameters[9].Value = base.Discription;
            parameters[10].Value = base.GetServiceType;
            parameters[11].Value = base.StartSign;
            parameters[12].Value = base.InTime;
            parameters[13].Value = base.OutTime;
            parameters[14].Value = base.FatherPK;
            parameters[15].Value = base.IsHasBaby;
            parameters[0x10].Value = base.Grade;
            parameters[0x11].Value = base.PKPath;
            parameters[0x12].Value = base.MaxNum;
            parameters[0x13].Value = base.PK;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }

        public override int UpdateHasBaby(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update gov_tc_db_ServicesRegister set ");
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

        public override int UpdatePKPathAndGrade(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update gov_tc_db_ServicesRegister set ");
            builder.Append("PKPath='" + base.PKPath + "', ");
            builder.Append("Grade=" + base.Grade);
            builder.Append(" where PK='" + base.PK + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

