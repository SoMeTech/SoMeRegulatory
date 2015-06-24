namespace SoMeTech.Company.Bank
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Text;

    public sealed class BankDal : BankModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into DB_Bank(");
            builder.Append("pk_corp,BankName,BankNum,BankNumMan,Discription");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + base.pk_corp + "',");
            builder.Append("'" + base.BankName + "',");
            builder.Append("'" + base.BankNum + "',");
            builder.Append("'" + base.BankNumMan + "',");
            builder.Append("'" + base.Discription + "'");
            builder.Append(")");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override void Delete(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from DB_Bank ");
            builder.Append(" where BankPK='" + base.BankPK + "'");
            dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int Exists(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from DB_Bank where BankPK='" + base.BankPK + "'");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override void GetModel(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ");
            builder.Append(" BankPK,pk_corp,BankName,BankNum,BankNumMan,Discription ");
            builder.Append(" from DB_Bank ");
            builder.Append(" where BankPK='" + base.BankPK + "'");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                base.pk_corp = set.Tables[0].Rows[0]["pk_corp"].ToString();
                base.BankName = set.Tables[0].Rows[0]["BankName"].ToString();
                base.BankNum = set.Tables[0].Rows[0]["BankNum"].ToString();
                base.BankNumMan = set.Tables[0].Rows[0]["BankNumMan"].ToString();
                base.Discription = set.Tables[0].Rows[0]["Discription"].ToString();
            }
        }

        public override DataSet GetViewList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select BANKPK,PK_CORP,BANKNAME,BANKNUM,BANKNUMMAN,DISCRIPTION,NAME ");
            builder.Append(" FROM gov_tc_view_Bank ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public override int Update(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_Bank set ");
            builder.Append("pk_corp='" + base.pk_corp + "',");
            builder.Append("BankName='" + base.BankName + "',");
            builder.Append("BankNum='" + base.BankNum + "',");
            builder.Append("BankNumMan='" + base.BankNumMan + "',");
            builder.Append("Discription='" + base.Discription + "'");
            builder.Append(" where BankPK='" + base.BankPK + "'");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

