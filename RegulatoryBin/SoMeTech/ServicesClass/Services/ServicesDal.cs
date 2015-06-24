namespace SoMeTech.ServicesClass.Services
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class ServicesDal : ServicesModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into gov_tc_db_Services(");
            builder.Append("BH,ServiceTypePK,CompanyPK,BranchPK,PowerCode,Name,Path,ClassName,ContParameters,IfTwoCont,Method,IfTwoMet,Parameters,Discription,GetServiceType,TaxFeeCallectionPK,Table1,Table2,Table3,Table4,IsShow,IsBLService,BLPKs,BLPassType,OperationPK)");
            builder.Append(" values (");
            builder.Append(":BH,:ServiceTypePK,:CompanyPK,:BranchPK,:PowerCode,:Name,:Path,:ClassName,:ContParameters,:IfTwoCont,:Method,:IfTwoMet,:Parameters,:Discription,:GetServiceType,:TaxFeeCallectionPK,:Table1,:Table2,:Table3,:Table4,:IsShow,:IsBLService,:BLPKs,:BLPassType,:OperationPK)");
            OracleParameter[] parameters = new OracleParameter[] { 
                new OracleParameter(":BH", OracleType.VarChar, 40), new OracleParameter(":ServiceTypePK", OracleType.Char, 40), new OracleParameter(":CompanyPK", OracleType.VarChar, 40), new OracleParameter(":BranchPK", OracleType.VarChar, 40), new OracleParameter(":PowerCode", OracleType.VarChar, 10), new OracleParameter(":Name", OracleType.VarChar, 40), new OracleParameter(":Path", OracleType.VarChar, 0xff), new OracleParameter(":ClassName", OracleType.VarChar, 40), new OracleParameter(":ContParameters", OracleType.VarChar, 0xff), new OracleParameter(":IfTwoCont", OracleType.Char, 1), new OracleParameter(":Method", OracleType.VarChar, 40), new OracleParameter(":IfTwoMet", OracleType.Char, 1), new OracleParameter(":Parameters", OracleType.VarChar, 0xff), new OracleParameter(":Discription", OracleType.VarChar, 0xff), new OracleParameter(":GetServiceType", OracleType.VarChar, 1), new OracleParameter(":TaxFeeCallectionPK", OracleType.VarChar, 40), 
                new OracleParameter(":Table1", OracleType.VarChar, 30), new OracleParameter(":Table2", OracleType.VarChar, 30), new OracleParameter(":Table3", OracleType.VarChar, 30), new OracleParameter(":Table4", OracleType.VarChar, 30), new OracleParameter(":IsShow", OracleType.Char, 1), new OracleParameter(":IsBLService", OracleType.Char, 1), new OracleParameter(":BLPKs", OracleType.VarChar, 0xff), new OracleParameter(":BLPassType", OracleType.VarChar, 40), new OracleParameter(":OperationPK", OracleType.Char, 40)
             };
            parameters[0].Value = base.BH;
            parameters[1].Value = base.ServiceTypePK;
            parameters[2].Value = base.CompanyPK;
            parameters[3].Value = base.BranchPK;
            parameters[4].Value = base.PowerCode;
            parameters[5].Value = base.Name;
            parameters[6].Value = base.Path;
            parameters[7].Value = base.ClassName;
            parameters[8].Value = base.ContParameters;
            parameters[9].Value = base.IfTwoCont;
            parameters[10].Value = base.Method;
            parameters[11].Value = base.IfTwoMet;
            parameters[12].Value = base.Parameters;
            parameters[13].Value = base.Discription;
            parameters[14].Value = base.GetServiceType;
            parameters[15].Value = base.TaxFeeCallectionPK;
            parameters[0x10].Value = base.Table1;
            parameters[0x11].Value = base.Table2;
            parameters[0x12].Value = base.Table3;
            parameters[0x13].Value = base.Table4;
            parameters[20].Value = base.IsShow;
            parameters[0x15].Value = base.IsBLService;
            parameters[0x16].Value = base.BLPKs;
            parameters[0x17].Value = base.BLPassType;
            parameters[0x18].Value = base.OperationPK;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }

        public override int AddManyApply(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into gov_tc_db_Services(");
            builder.Append("BH,ServiceTypePK,Name,OperationPK,Discription,IsShow,IsBLService,BLPKs,BLPassType,Table1,Table2,Table3,Table4)");
            builder.Append(" values (");
            builder.Append(":BH,:ServiceTypePK,:Name,:OperationPK,:Discription,:IsShow,:IsBLService,:BLPKs,:BLPassType,:Table1,:Table2,:Table3,:Table4)");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":BH", OracleType.VarChar, 40), new OracleParameter(":ServiceTypePK", OracleType.Char, 40), new OracleParameter(":Name", OracleType.VarChar, 40), new OracleParameter(":OperationPK", OracleType.Char, 40), new OracleParameter(":Discription", OracleType.VarChar, 0xff), new OracleParameter(":IsShow", OracleType.Char, 1), new OracleParameter(":IsBLService", OracleType.Char, 1), new OracleParameter(":BLPKs", OracleType.VarChar, 0xff), new OracleParameter(":BLPassType", OracleType.VarChar, 40), new OracleParameter(":Table1", OracleType.VarChar, 30), new OracleParameter(":Table2", OracleType.VarChar, 30), new OracleParameter(":Table3", OracleType.VarChar, 30), new OracleParameter(":Table4", OracleType.VarChar, 30) };
            parameters[0].Value = base.BH;
            parameters[1].Value = base.ServiceTypePK;
            parameters[2].Value = base.Name;
            parameters[3].Value = base.OperationPK;
            parameters[4].Value = base.Discription;
            parameters[5].Value = base.IsShow;
            parameters[6].Value = base.IsBLService;
            parameters[7].Value = base.BLPKs;
            parameters[8].Value = base.BLPassType;
            parameters[9].Value = base.Table1;
            parameters[10].Value = base.Table2;
            parameters[11].Value = base.Table3;
            parameters[12].Value = base.Table4;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }

        public override int Delete(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from gov_tc_db_Services ");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.VarChar) };
            parameters[0].Value = base.PK;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }

        public override int Exists(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(PK) from gov_tc_db_Services");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.VarChar) };
            parameters[0].Value = base.PK;
            return dbo.BackIsSelect(builder.ToString(), parameters, "");
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

        public override ServicesModel GetModel(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.VarChar) };
            parameters[0].Value = base.PK;
            DataSet set = dbo.BackDataSet(builder.ToString(), parameters, "");
            if (set.Tables[0].Rows.Count > 0)
            {
                new ServicesModel();
                return this.GetModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        private ServicesModel GetModel(DataRow dr)
        {
            return new ServicesModel { 
                PK = dr["PK"].ToString().Trim(), BH = dr["BH"].ToString().Trim(), ServiceTypePK = dr["ServiceTypePK"].ToString().Trim(), CompanyPK = dr["CompanyPK"].ToString().Trim(), BranchPK = dr["BranchPK"].ToString().Trim(), PowerCode = dr["PowerCode"].ToString(), Name = dr["Name"].ToString(), Path = dr["Path"].ToString(), ClassName = dr["ClassName"].ToString(), ContParameters = dr["ContParameters"].ToString(), IfTwoCont = dr["IfTwoCont"].ToString(), Method = dr["Method"].ToString(), IfTwoMet = dr["IfTwoMet"].ToString(), Parameters = dr["Parameters"].ToString(), Discription = dr["Discription"].ToString(), GetServiceType = dr["GetServiceType"].ToString().Trim(), 
                TaxFeeCallectionPK = dr["TaxFeeCallectionPK"].ToString().Trim(), Table1 = dr["Table1"].ToString(), Table2 = dr["Table2"].ToString(), Table3 = dr["Table3"].ToString(), Table4 = dr["Table4"].ToString(), IsShow = dr["IsShow"].ToString(), IsBLService = dr["IsBLService"].ToString(), BLPKs = dr["BLPKs"].ToString(), BLPassType = dr["BLPassType"].ToString(), OperationPK = dr["OperationPK"].ToString().Trim()
             };
        }

        public override ServicesModel[] GetModel(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strWhere != "")
            {
                builder.Append(" where " + strWhere);
            }
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            ServicesModel[] modelArray = null;
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            modelArray = new ServicesModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new ServicesModel();
                modelArray[i] = this.GetModel(set.Tables[0].Rows[i]);
            }
            return modelArray;
        }

        private string GetSql()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,BH,ServiceTypePK,CompanyPK,BranchPK,PowerCode,Name,Path,ClassName,ContParameters,IfTwoCont,Method,IfTwoMet,Parameters,Discription,GetServiceType,TaxFeeCallectionPK,Table1,Table2,Table3,Table4,IsShow,IsBLService,BLPKs,BLPassType,OperationPK ");
            builder.Append(" FROM gov_tc_db_Services ");
            return builder.ToString();
        }

        public override int Update(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update gov_tc_db_Services set ");
            builder.Append("BH=:BH,");
            builder.Append("ServiceTypePK=:ServiceTypePK,");
            builder.Append("CompanyPK=:CompanyPK,");
            builder.Append("BranchPK=:BranchPK,");
            builder.Append("PowerCode=:PowerCode,");
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
            builder.Append("TaxFeeCallectionPK=:TaxFeeCallectionPK,");
            builder.Append("Table1=:Table1,");
            builder.Append("Table2=:Table2,");
            builder.Append("Table3=:Table3,");
            builder.Append("Table4=:Table4,");
            builder.Append("IsShow=:IsShow,");
            builder.Append("IsBLService=:IsBLService,");
            builder.Append("BLPKs=:BLPKs,");
            builder.Append("BLPassType=:BLPassType,");
            builder.Append("OperationPK=:OperationPK");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { 
                new OracleParameter(":PK", OracleType.Char, 40), new OracleParameter(":BH", OracleType.VarChar, 40), new OracleParameter(":ServiceTypePK", OracleType.Char, 40), new OracleParameter(":CompanyPK", OracleType.VarChar, 40), new OracleParameter(":BranchPK", OracleType.VarChar, 40), new OracleParameter(":PowerCode", OracleType.VarChar, 10), new OracleParameter(":Name", OracleType.VarChar, 40), new OracleParameter(":Path", OracleType.VarChar, 0xff), new OracleParameter(":ClassName", OracleType.VarChar, 40), new OracleParameter(":ContParameters", OracleType.VarChar, 0xff), new OracleParameter(":IfTwoCont", OracleType.Char, 1), new OracleParameter(":Method", OracleType.VarChar, 40), new OracleParameter(":IfTwoMet", OracleType.Char, 1), new OracleParameter(":Parameters", OracleType.VarChar, 0xff), new OracleParameter(":Discription", OracleType.VarChar, 0xff), new OracleParameter(":GetServiceType", OracleType.VarChar, 1), 
                new OracleParameter(":TaxFeeCallectionPK", OracleType.VarChar, 40), new OracleParameter(":Table1", OracleType.VarChar, 30), new OracleParameter(":Table2", OracleType.VarChar, 30), new OracleParameter(":Table3", OracleType.VarChar, 30), new OracleParameter(":Table4", OracleType.VarChar, 30), new OracleParameter(":IsShow", OracleType.Char, 1), new OracleParameter(":IsBLService", OracleType.Char, 1), new OracleParameter(":BLPKs", OracleType.VarChar, 0xff), new OracleParameter(":BLPassType", OracleType.VarChar, 40), new OracleParameter(":OperationPK", OracleType.Char, 40)
             };
            parameters[0].Value = base.PK;
            parameters[1].Value = base.BH;
            parameters[2].Value = base.ServiceTypePK;
            parameters[3].Value = base.CompanyPK;
            parameters[4].Value = base.BranchPK;
            parameters[5].Value = base.PowerCode;
            parameters[6].Value = base.Name;
            parameters[7].Value = base.Path;
            parameters[8].Value = base.ClassName;
            parameters[9].Value = base.ContParameters;
            parameters[10].Value = base.IfTwoCont;
            parameters[11].Value = base.Method;
            parameters[12].Value = base.IfTwoMet;
            parameters[13].Value = base.Parameters;
            parameters[14].Value = base.Discription;
            parameters[15].Value = base.GetServiceType;
            parameters[0x10].Value = base.TaxFeeCallectionPK;
            parameters[0x11].Value = base.Table1;
            parameters[0x12].Value = base.Table2;
            parameters[0x13].Value = base.Table3;
            parameters[20].Value = base.Table4;
            parameters[0x15].Value = base.IsShow;
            parameters[0x16].Value = base.IsBLService;
            parameters[0x17].Value = base.BLPKs;
            parameters[0x18].Value = base.BLPassType;
            parameters[0x19].Value = base.OperationPK;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }
    }
}

