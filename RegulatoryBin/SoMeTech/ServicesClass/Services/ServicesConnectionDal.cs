namespace SoMeTech.ServicesClass.Services
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class ServicesConnectionDal : ServicesConnectionModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into gov_tc_db_ServicesConnection(");
            builder.Append("OperationPK,ServicePK,Name,ServiceStep,CompanyPK,BranchPK,ConnectionTypePK,FatherPK,ConnectionPath,Grade,IsHasBaby,TopLevelConnectionPK,IfTax,IfFee,IfLast,Memo)");
            builder.Append(" values (");
            builder.Append(":OperationPK,:ServicePK,:Name,:ServiceStep,:CompanyPK,:BranchPK,:ConnectionTypePK,:FatherPK,:ConnectionPath,:Grade,:IsHasBaby,:TopLevelConnectionPK,:IfTax,:IfFee,:IfLast,:Memo)");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":OperationPK", OracleType.VarChar, 40), new OracleParameter(":ServicePK", OracleType.VarChar, 40), new OracleParameter(":Name", OracleType.VarChar, 100), new OracleParameter(":ServiceStep", OracleType.Int32, 4), new OracleParameter(":CompanyPK", OracleType.VarChar, 40), new OracleParameter(":BranchPK", OracleType.VarChar, 40), new OracleParameter(":ConnectionTypePK", OracleType.VarChar, 40), new OracleParameter(":FatherPK", OracleType.VarChar, 40), new OracleParameter(":ConnectionPath", OracleType.VarChar, 0xff), new OracleParameter(":Grade", OracleType.Int32, 4), new OracleParameter(":IsHasBaby", OracleType.Char, 1), new OracleParameter(":TopLevelConnectionPK", OracleType.VarChar, 40), new OracleParameter(":IfTax", OracleType.Char, 1), new OracleParameter(":IfFee", OracleType.Char, 1), new OracleParameter(":IfLast", OracleType.Char, 1), new OracleParameter(":Memo", OracleType.VarChar, 0xff) };
            parameters[0].Value = base.OperationPK;
            parameters[1].Value = base.ServicePK;
            parameters[2].Value = base.Name;
            parameters[3].Value = base.ServiceStep;
            parameters[4].Value = base.CompanyPK;
            parameters[5].Value = base.BranchPK;
            parameters[6].Value = base.ConnectionTypePK;
            parameters[7].Value = base.FatherPK;
            parameters[8].Value = base.ConnectionPath;
            parameters[9].Value = base.Grade;
            parameters[10].Value = base.IsHasBaby;
            parameters[11].Value = base.TopLevelConnectionPK;
            parameters[12].Value = base.IfTax;
            parameters[13].Value = base.IfFee;
            parameters[14].Value = base.IfLast;
            parameters[15].Value = base.Memo;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }

        public override int Delete(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from gov_tc_db_ServicesConnection ");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.VarChar) };
            parameters[0].Value = base.PK;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }

        public override int Exists(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(PK) from gov_tc_db_ServicesConnection");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.VarChar) };
            parameters[0].Value = base.PK;
            return dbo.BackIsSelect(builder.ToString(), parameters, "");
        }

        public override DataSet GetList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,OperationPK,ServicePK,Name,ServiceStep,CompanyPK,BranchPK,ConnectionTypePK,FatherPK,ConnectionPath,Grade,IsHasBaby,TopLevelConnectionPK,IfTax,IfFee,IfLast,Memo ");
            builder.Append(" FROM gov_tc_db_ServicesConnection ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public override ServicesConnectionModel GetModel(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,OperationPK,ServicePK,Name,ServiceStep,CompanyPK,BranchPK,ConnectionTypePK,FatherPK,ConnectionPath,Grade,IsHasBaby,TopLevelConnectionPK,IfTax,IfFee,IfLast,Memo from gov_tc_db_ServicesConnection ");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.VarChar) };
            parameters[0].Value = base.PK;
            DataSet set = dbo.BackDataSet(builder.ToString(), parameters, "");
            if (set.Tables[0].Rows.Count > 0)
            {
                new ServicesConnectionModel();
                return this.GetModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        private ServicesConnectionModel GetModel(DataRow dr)
        {
            ServicesConnectionModel model = new ServicesConnectionModel {
                PK = dr["PK"].ToString(),
                OperationPK = dr["OperationPK"].ToString(),
                ServicePK = dr["ServicePK"].ToString(),
                Name = dr["Name"].ToString()
            };
            if (dr["ServiceStep"].ToString() != "")
            {
                model.ServiceStep = int.Parse(dr["ServiceStep"].ToString());
            }
            model.CompanyPK = dr["CompanyPK"].ToString();
            model.BranchPK = dr["BranchPK"].ToString();
            model.ConnectionTypePK = dr["ConnectionTypePK"].ToString();
            model.FatherPK = dr["FatherPK"].ToString();
            model.ConnectionPath = dr["ConnectionPath"].ToString();
            if (dr["Grade"].ToString() != "")
            {
                model.Grade = int.Parse(dr["Grade"].ToString());
            }
            model.IsHasBaby = dr["IsHasBaby"].ToString();
            model.TopLevelConnectionPK = dr["TopLevelConnectionPK"].ToString();
            model.IfTax = dr["IfTax"].ToString();
            model.IfFee = dr["IfFee"].ToString();
            model.IfLast = dr["IfLast"].ToString();
            model.Memo = dr["Memo"].ToString();
            return model;
        }

        public override ServicesConnectionModel[] GetModel(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,OperationPK,ServicePK,Name,ServiceStep,CompanyPK,BranchPK,ConnectionTypePK,FatherPK,ConnectionPath,Grade,IsHasBaby,TopLevelConnectionPK,IfTax,IfFee,IfLast,Memo from gov_tc_db_ServicesConnection ");
            if (strWhere != "")
            {
                builder.Append(" where " + strWhere);
            }
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            ServicesConnectionModel[] modelArray = null;
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            modelArray = new ServicesConnectionModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new ServicesConnectionModel();
                modelArray[i] = this.GetModel(set.Tables[0].Rows[i]);
            }
            return modelArray;
        }

        public override int Update(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update gov_tc_db_ServicesConnection set ");
            builder.Append("OperationPK=:OperationPK,");
            builder.Append("ServicePK=:ServicePK,");
            builder.Append("Name=:Name,");
            builder.Append("ServiceStep=:ServiceStep,");
            builder.Append("CompanyPK=:CompanyPK,");
            builder.Append("BranchPK=:BranchPK,");
            builder.Append("ConnectionTypePK=:ConnectionTypePK,");
            builder.Append("FatherPK=:FatherPK,");
            builder.Append("ConnectionPath=:ConnectionPath,");
            builder.Append("Grade=:Grade,");
            builder.Append("IsHasBaby=:IsHasBaby,");
            builder.Append("TopLevelConnectionPK=:TopLevelConnectionPK,");
            builder.Append("IfTax=:IfTax,");
            builder.Append("IfFee=:IfFee,");
            builder.Append("IfLast=:IfLast,");
            builder.Append("Memo=:Memo");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { 
                new OracleParameter(":PK", OracleType.Char, 40), new OracleParameter(":OperationPK", OracleType.VarChar, 40), new OracleParameter(":ServicePK", OracleType.VarChar, 40), new OracleParameter(":Name", OracleType.VarChar, 100), new OracleParameter(":ServiceStep", OracleType.Int32, 4), new OracleParameter(":CompanyPK", OracleType.VarChar, 40), new OracleParameter(":BranchPK", OracleType.VarChar, 40), new OracleParameter(":ConnectionTypePK", OracleType.VarChar, 40), new OracleParameter(":FatherPK", OracleType.VarChar, 40), new OracleParameter(":ConnectionPath", OracleType.VarChar, 0xff), new OracleParameter(":Grade", OracleType.Int32, 4), new OracleParameter(":IsHasBaby", OracleType.Char, 1), new OracleParameter(":TopLevelConnectionPK", OracleType.VarChar, 40), new OracleParameter(":IfTax", OracleType.Char, 1), new OracleParameter(":IfFee", OracleType.Char, 1), new OracleParameter(":IfLast", OracleType.Char, 1), 
                new OracleParameter(":Memo", OracleType.VarChar, 0xff)
             };
            parameters[0].Value = base.PK;
            parameters[1].Value = base.OperationPK;
            parameters[2].Value = base.ServicePK;
            parameters[3].Value = base.Name;
            parameters[4].Value = base.ServiceStep;
            parameters[5].Value = base.CompanyPK;
            parameters[6].Value = base.BranchPK;
            parameters[7].Value = base.ConnectionTypePK;
            parameters[8].Value = base.FatherPK;
            parameters[9].Value = base.ConnectionPath;
            parameters[10].Value = base.Grade;
            parameters[11].Value = base.IsHasBaby;
            parameters[12].Value = base.TopLevelConnectionPK;
            parameters[13].Value = base.IfTax;
            parameters[14].Value = base.IfFee;
            parameters[15].Value = base.IfLast;
            parameters[0x10].Value = base.Memo;
            return dbo.ExecutionIsSucess(builder.ToString(), parameters, "");
        }
    }
}

