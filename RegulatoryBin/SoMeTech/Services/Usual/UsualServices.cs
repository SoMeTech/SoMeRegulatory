namespace SoMeTech.Services.Usual
{
    using SoMeTech.DataAccess;
    using System;

    public sealed class UsualServices
    {
        public int Audit(string mainTableName, string mainPK, string tableName, string PK, string executeMan, string computerIP, int step, string riticize, DB_OPT dbo)
        {
            string strSql = "update " + tableName + " set Sign='1', ExecuteMan='" + executeMan + "', ComputerIP='" + computerIP + "', ExecuteDate='" + DateTime.Now.ToShortDateString() + "', Riticize='" + riticize + "' where PK='" + PK + "'";
            dbo.ExecutionIsSucess(strSql, null);
            string[] strArray = new string[] { "update ", mainTableName, " set Step='", (step + 1).ToString(), "' where PK='", mainPK, "'" };
            strSql = string.Concat(strArray);
            return dbo.ExecutionIsSucess(strSql, null);
        }

        public int Derate(string mainTableName, string mainPK, string tableName, string PK, string executeMan, string computerIP, int step, string riticize, decimal money1, decimal money2, decimal money3, DB_OPT dbo)
        {
            string strSql = "update " + tableName + " set Sign='1', ExecuteMan='" + executeMan + "', ComputerIP='" + computerIP + "', ExecuteDate='" + DateTime.Now.ToShortDateString() + "', Riticize='" + riticize + "', Money1=" + money1.ToString() + ", Money2=" + money2.ToString() + ", Money3=" + money3.ToString() + " where PK='" + PK + "'";
            dbo.ExecutionIsSucess(strSql, null);
            string[] strArray = new string[] { "update ", mainTableName, " set Step='", (step + 1).ToString(), "' where PK='", mainPK, "'" };
            strSql = string.Concat(strArray);
            return dbo.ExecutionIsSucess(strSql, null);
        }

        public int DerateApply(string mainTableName, string mainPK, string tableName, string PK, string executeMan, string computerIP, int step, string riticize, decimal money1, decimal money2, decimal money3, DB_OPT dbo)
        {
            string strSql = "update " + tableName + " set Sign='1', ExecuteMan='" + executeMan + "', ComputerIP='" + computerIP + "', ExecuteDate='" + DateTime.Now.ToShortDateString() + "', Riticize='" + riticize + "', Money1=" + money1.ToString() + ", Money2=" + money2.ToString() + ", Money3=" + money3.ToString() + " where PK='" + PK + "'";
            dbo.ExecutionIsSucess(strSql, null);
            string[] strArray = new string[] { "update ", mainTableName, " set Step='", (step + 1).ToString(), "' where PK='", mainPK, "'" };
            strSql = string.Concat(strArray);
            return dbo.ExecutionIsSucess(strSql, null);
        }

        public int TaxFee(string mainTableName, string mainPK, string tableName, string PK, string executeMan, string computerIP, int step, string riticize, decimal money1, decimal money2, decimal money3, DB_OPT dbo)
        {
            string strSql = "update " + tableName + " set Sign='1', ExecuteMan='" + executeMan + "', ComputerIP='" + computerIP + "', ExecuteDate='" + DateTime.Now.ToShortDateString() + "', Riticize='" + riticize + "', Money1=" + money1.ToString() + ", Money2=" + money2.ToString() + ", Money3=" + money3.ToString() + " where PK='" + PK + "'";
            dbo.ExecutionIsSucess(strSql, null);
            string[] strArray = new string[] { "update ", mainTableName, " set Step='", (step + 1).ToString(), "' where PK='", mainPK, "'" };
            strSql = string.Concat(strArray);
            return dbo.ExecutionIsSucess(strSql, null);
        }
    }
}

