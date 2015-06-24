namespace SoMeTech.User
{
    using SoMeTech.Company;
    using SoMeTech.Company.Branch;
    using SoMeTech.Company.Employee;
    using SoMeTech.Company.Role;
    using SoMeTech.Data;
    using SoMeTech.DataAccess;
    using QxRoom.Common;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.OracleClient;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Web.UI;

    public sealed class UserDal : UserModel
    {
        public override int Add(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into DB_Users(");
            builder.Append("BranchPK,RolePK,Power,DataPower,RowPower,ServicesPower,CompanyPower,EmployeePK,UserName,TrueName,Password,pk_corp");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + base.BranchPK + "',");
            builder.Append("'" + base.RolePK + "',");
            builder.Append(":Power,:DataPower,:RowPower,:ServicesPower,:CompanyPower,");
            builder.Append("'" + base.EmployeePK + "',");
            builder.Append("'" + base.UserName + "',");
            builder.Append("'" + base.TrueName + "',");
            builder.Append("'" + base.Password + "',");
            builder.Append("'" + base.pk_corp + "'");
            builder.Append(")");
            Hashtable ht = new Hashtable();
            ht.Add("Power", base.Power);
            ht.Add("DataPower", base.DataPower);
            ht.Add("RowPower", base.RowPower);
            ht.Add("ServicesPower", base.ServicesPower);
            ht.Add("CompanyPower", base.CompanyPower);
            return dbo.ExecutionIsSucess(builder.ToString(), ht);
        }

        public override void Delete(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from DB_Users ");
            builder.Append(" where UserPK='" + base.UserPK + "'");
            dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public override int ExistsByEmpPK(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(UserPK) from DB_Users where EmployeePK='" + base.EmployeePK + "'");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override int ExistsByUserName(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(UserName) from DB_Users where UserName='" + base.UserName + "'");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public override int ExistsByUserPK(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(UserPK) from DB_Users where UserPK='" + base.UserPK + "'");
            return dbo.BackIsSelect(builder.ToString(), null);
        }

        public static void GetCompanyPK(string username, ref string pk_corp, DB_OPT dbo)
        {
            string strSql = "select PK_CORP from DB_Users where UserName='" + username + "'";
            DataSet set = dbo.BackDataSet(strSql, null);
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                pk_corp = set.Tables[0].Rows[0]["pk_corp"].ToString();
            }
        }

        public override string GetLastStream(Page page, DB_OPT dbo)
        {
            string str = page.Request.Url.ToString();
            int startIndex = str.LastIndexOf("/") + 1;
            int num2 = str.LastIndexOf("?");
            string str2 = (num2 < 0) ? str.Substring(startIndex) : str.Substring(startIndex, num2 - startIndex);
            string strSql = "select distinct oper.serverpks from gov_tc_db_servicesmess ser left join gov_tc_db_sfproject sf on sf.PK=ser.taxfeecallectionpk left join gov_tc_db_taxfeekind tax on tax.pk=sf.TAXFEEKINDPK left join gov_tc_db_operation oper on oper.operationpk=ser.operationpk  where tax.pkpath=:path";
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter("path", OracleType.VarChar, 100) };
            parameters[0].Value = str2;
            DataSet set = dbo.Query(strSql, parameters);
            if ((set.Tables.Count <= 0) || (set.Tables[0].Rows.Count <= 0))
            {
                return null;
            }
            string str4 = set.Tables[0].Rows[0]["serverpks"].ToString();
            int num3 = str4.LastIndexOf('|');
            string str5 = null;
            if (num3 >= 0)
            {
                str5 = str4.Substring(num3).Replace("|", "");
            }
            return str5;
        }

        public override DataSet GetList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select UserPK,BranchPK,RolePK,EmployeePK,UserName,TrueName,Password,Power,DataPower,RowPower,ServicesPower,CompanyPower,Discription,IsUser,pk_corp ");
            builder.Append(" FROM DB_Users ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public override DataSet GetList(int PageSize, int PageIndex, string strWhere, DB_OPT dbo)
        {
            if (DB_OPT.DBT == DataBaseType.SqlServer)
            {
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@tblName", SqlDbType.NVarChar, 0xff), new SqlParameter("@fldName", SqlDbType.NVarChar, 0xff), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@PageIndex", SqlDbType.Int), new SqlParameter("@IsReCount", SqlDbType.Int), new SqlParameter("@OrderType", SqlDbType.Int), new SqlParameter("@strWhere", SqlDbType.NVarChar, 0x3e8) };
                parameterArray[0].Value = "Users";
                parameterArray[1].Value = "UserPK";
                parameterArray[2].Value = PageSize;
                parameterArray[3].Value = PageIndex;
                parameterArray[4].Value = 0;
                parameterArray[5].Value = 0;
                parameterArray[6].Value = strWhere;
                return dbo.SqlSelectProcPar("UP_GetRecordByPage", parameterArray);
            }
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":tblName", OracleType.VarChar, 0xff), new OracleParameter(":fldName", OracleType.VarChar, 0xff), new OracleParameter(":PageSize", OracleType.Int32), new OracleParameter(":PageIndex", OracleType.Int32), new OracleParameter(":IsReCount", OracleType.Int32), new OracleParameter(":OrderType", OracleType.Int32), new OracleParameter(":strWhere", OracleType.VarChar, 0x3e8) };
            parameters[0].Value = "Users";
            parameters[1].Value = "UserPK";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return dbo.SqlSelectProcPar("UP_GetRecordByPage", parameters);
        }

        public override DataSet GetListAll(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select USERPK,BRANCHPK,ROLEPK,EMPLOYEEPK,USERNAME,TRUENAME,PASSWORD,DISCRIPTION,ISUSER,PK_CORP,ENAME,SEX,BNAME,RNAME,CNAME,UPOWER,BPOWER,RPOWER,UDATAPOWER,BDATAPOWER,RDATAPOWER,UCOMPANYPOWER,UROWPOWER,BROWPOWER,RROWPOWER,USERVICESPOWER,BSERVICESPOWER,RSERVICESPOWER,BCOMPANYPOWER,RCOMPANYPOWER,BISUSERPOWER,RISUSERPOWER");
            builder.Append(" FROM gov_tc_view_Users ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public override void GetModel(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            if (base.UserName != "")
            {
                builder.Append("select USERPK,BRANCHPK,ROLEPK,EMPLOYEEPK,USERNAME,TRUENAME,PASSWORD,DISCRIPTION,ISUSER,PK_CORP,ENAME,SEX,BNAME,RNAME,CNAME,UPOWER,BPOWER,RPOWER,UDATAPOWER,BDATAPOWER,RDATAPOWER,UCOMPANYPOWER,UROWPOWER,BROWPOWER,RROWPOWER,USERVICESPOWER,BSERVICESPOWER,RSERVICESPOWER,BCOMPANYPOWER,RCOMPANYPOWER,BISUSERPOWER,RISUSERPOWER from gov_tc_view_Users where UserName='" + base.UserName + "'");
            }
            else if (base.UserPK != "")
            {
                builder.Append("select USERPK,BRANCHPK,ROLEPK,EMPLOYEEPK,USERNAME,TRUENAME,PASSWORD,DISCRIPTION,ISUSER,PK_CORP,ENAME,SEX,BNAME,RNAME,CNAME,UPOWER,BPOWER,RPOWER,UDATAPOWER,BDATAPOWER,RDATAPOWER,UCOMPANYPOWER,UROWPOWER,BROWPOWER,RROWPOWER,USERVICESPOWER,BSERVICESPOWER,RSERVICESPOWER,BCOMPANYPOWER,RCOMPANYPOWER,BISUSERPOWER,RISUSERPOWER from gov_tc_view_Users where UserPK='" + base.UserPK + "'");
            }
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                base.UserPK = set.Tables[0].Rows[0]["UserPK"].ToString();
                base.cName = set.Tables[0].Rows[0]["cName"].ToString();
                base.pk_corp = set.Tables[0].Rows[0]["pk_corp"].ToString();
                base.bName = set.Tables[0].Rows[0]["bName"].ToString();
                base.BranchPK = set.Tables[0].Rows[0]["BranchPK"].ToString();
                base.rName = set.Tables[0].Rows[0]["rName"].ToString();
                base.RolePK = set.Tables[0].Rows[0]["RolePK"].ToString();
                base.EmployeePK = set.Tables[0].Rows[0]["EmployeePK"].ToString();
                base.UserName = set.Tables[0].Rows[0]["UserName"].ToString();
                base.TrueName = set.Tables[0].Rows[0]["TrueName"].ToString();
                base.Password = set.Tables[0].Rows[0]["Password"].ToString();
                base.Power = set.Tables[0].Rows[0]["uPower"].ToString();
                base.DataPower = set.Tables[0].Rows[0]["uDataPower"].ToString();
                base.RowPower = set.Tables[0].Rows[0]["uRowPower"].ToString();
                base.ServicesPower = set.Tables[0].Rows[0]["uServicesPower"].ToString();
                base.CompanyPower = set.Tables[0].Rows[0]["uCompanyPower"].ToString();
                base.CompanyPower = base.CompanyPower + "|" + set.Tables[0].Rows[0]["bCompanyPower"].ToString();
                if (set.Tables[0].Rows[0]["rIsUserPower"].ToString() == "1")
                {
                    base.Power = base.Power + "|" + set.Tables[0].Rows[0]["rPower"].ToString();
                    base.DataPower = base.DataPower + "|" + set.Tables[0].Rows[0]["rDataPower"].ToString();
                    base.RowPower = base.RowPower + "|" + set.Tables[0].Rows[0]["rRowPower"].ToString();
                    base.ServicesPower = base.ServicesPower + "|" + set.Tables[0].Rows[0]["rServicesPower"].ToString();
                }
                base.Power = Public.DelRelTxt(base.Power, '|');
                base.DataPower = Public.DelRelTxt(base.DataPower, '|');
                base.RowPower = Public.DelRelTxt(base.RowPower, '|');
                base.ServicesPower = Public.DelRelTxt(base.ServicesPower, '|');
                base.CompanyPower = Public.DelRelTxt(base.CompanyPower, '|');
                base.Discription = set.Tables[0].Rows[0]["Discription"].ToString();
                base.IsUser = set.Tables[0].Rows[0]["IsUser"].ToString();
                base.Company = new CompanyDal { pk_corp = set.Tables[0].Rows[0]["pk_corp"].ToString() }.GetModel(false, false, false, dbo);
                base.Branch = new BranchDal { BranchPK = set.Tables[0].Rows[0]["BranchPK"].ToString() }.GetModel(false, false, false, false, dbo);
                base.Role = new RoleDal { RolePK = set.Tables[0].Rows[0]["RolePK"].ToString() }.GetModel(false, false, dbo);
                base.Employee = new EmployeeDal { EmployeePK = set.Tables[0].Rows[0]["EmployeePK"].ToString() }.GetModel(false, false, false, false, false, dbo);
            }
        }

        public override void GetModelOnly(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            if (base.UserName != "")
            {
                builder.Append("select USERPK,BRANCHPK,ROLEPK,EMPLOYEEPK,USERNAME,TRUENAME,PASSWORD,DISCRIPTION,ISUSER,PK_CORP,ENAME,SEX,BNAME,RNAME,CNAME,UPOWER,BPOWER,RPOWER,UDATAPOWER,BDATAPOWER,RDATAPOWER,UCOMPANYPOWER,UROWPOWER,BROWPOWER,RROWPOWER,USERVICESPOWER,BSERVICESPOWER,RSERVICESPOWER,BCOMPANYPOWER,RCOMPANYPOWER,BISUSERPOWER,RISUSERPOWER from gov_tc_view_Users where UserName='" + base.UserName + "'");
            }
            if (base.UserPK != "")
            {
                builder.Append("select USERPK,BRANCHPK,ROLEPK,EMPLOYEEPK,USERNAME,TRUENAME,PASSWORD,DISCRIPTION,ISUSER,PK_CORP,ENAME,SEX,BNAME,RNAME,CNAME,UPOWER,BPOWER,RPOWER,UDATAPOWER,BDATAPOWER,RDATAPOWER,UCOMPANYPOWER,UROWPOWER,BROWPOWER,RROWPOWER,USERVICESPOWER,BSERVICESPOWER,RSERVICESPOWER,BCOMPANYPOWER,RCOMPANYPOWER,BISUSERPOWER,RISUSERPOWER from gov_tc_view_Users where UserPK='" + base.UserPK + "'");
            }
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                base.UserPK = set.Tables[0].Rows[0]["UserPK"].ToString();
                base.cName = set.Tables[0].Rows[0]["cName"].ToString();
                base.pk_corp = set.Tables[0].Rows[0]["pk_corp"].ToString();
                base.bName = set.Tables[0].Rows[0]["bName"].ToString();
                base.BranchPK = set.Tables[0].Rows[0]["BranchPK"].ToString();
                base.rName = set.Tables[0].Rows[0]["rName"].ToString();
                base.RolePK = set.Tables[0].Rows[0]["RolePK"].ToString();
                base.EmployeePK = set.Tables[0].Rows[0]["EmployeePK"].ToString();
                base.UserName = set.Tables[0].Rows[0]["UserName"].ToString();
                base.TrueName = set.Tables[0].Rows[0]["TrueName"].ToString();
                base.Password = set.Tables[0].Rows[0]["Password"].ToString();
                base.Power = set.Tables[0].Rows[0]["uPower"].ToString();
                base.DataPower = set.Tables[0].Rows[0]["uDataPower"].ToString();
                base.RowPower = set.Tables[0].Rows[0]["uRowPower"].ToString();
                base.ServicesPower = set.Tables[0].Rows[0]["uServicesPower"].ToString();
                base.CompanyPower = set.Tables[0].Rows[0]["uCompanyPower"].ToString();
                base.Power = Public.DelRelTxt(base.Power, '|');
                base.DataPower = Public.DelRelTxt(base.DataPower, '|');
                base.RowPower = Public.DelRelTxt(base.RowPower, '|');
                base.ServicesPower = Public.DelRelTxt(base.ServicesPower, '|');
                base.CompanyPower = Public.DelRelTxt(base.CompanyPower, '|');
                base.Discription = set.Tables[0].Rows[0]["Discription"].ToString();
                base.IsUser = set.Tables[0].Rows[0]["IsUser"].ToString();
                base.Company = new CompanyDal { pk_corp = set.Tables[0].Rows[0]["pk_corp"].ToString() }.GetModel(false, false, false, dbo);
                base.Branch = new BranchDal { BranchPK = set.Tables[0].Rows[0]["BranchPK"].ToString() }.GetModel(false, false, false, false, dbo);
                base.Role = new RoleDal { RolePK = set.Tables[0].Rows[0]["RolePK"].ToString() }.GetModel(false, false, dbo);
                base.Employee = new EmployeeDal { EmployeePK = set.Tables[0].Rows[0]["EmployeePK"].ToString() }.GetModel(false, false, false, false, false, dbo);
            }
        }

        public override void GetServiceCode(string objID, string path, string userID, out int IsShow, out string showtxt, DB_OPT dbo)
        {
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter("objID", OracleType.VarChar, 100), new OracleParameter("path", OracleType.VarChar, 100), new OracleParameter("userID", OracleType.VarChar, 100), new OracleParameter("OutpowerCode", OracleType.Int32, 4), new OracleParameter("showtxt", OracleType.VarChar, 100) };
            parameters[0].Value = objID;
            parameters[1].Value = path;
            parameters[2].Value = userID;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            dbo.SqlProcPar("pd_tc_Proc_IsShowButtonList", parameters);
            IsShow = int.Parse(parameters[3].Value.ToString());
            showtxt = parameters[4].Value.ToString();
        }

        public override void GetServiceStream(string path, string userID, string MainServerPK, out string ShowButtonID, out string ButtonShowTxt, out string BoHui_ZhuiHui, out string IsSava_objID, DB_OPT dbo)
        {
            ButtonShowTxt = "";
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter("path", OracleType.VarChar, 100), new OracleParameter("userID", OracleType.VarChar, 100), new OracleParameter("MainServerPK", OracleType.VarChar, 100), new OracleParameter("ShowButtonID", OracleType.VarChar, 100), new OracleParameter("BoHui_ZhuiHui", OracleType.VarChar, 100), new OracleParameter("XserverPK", OracleType.VarChar, 0xff), new OracleParameter("IsSava_objID", OracleType.VarChar, 0xff) };
            parameters[0].Value = path;
            parameters[1].Value = userID;
            parameters[2].Value = MainServerPK;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            parameters[5].Direction = ParameterDirection.Output;
            parameters[6].Direction = ParameterDirection.Output;
            dbo.SqlProcPar("pd_tc_Proc_StreamIsShowButton", parameters);
            ShowButtonID = parameters[3].Value.ToString();
            BoHui_ZhuiHui = parameters[4].Value.ToString();
            ButtonShowTxt = parameters[5].Value.ToString();
            IsSava_objID = parameters[6].Value.ToString();
        }

        public override void GetUpDownStream(string path, string serverPK, int operation, out string NewServerPK, DB_OPT dbo)
        {
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter("path", OracleType.VarChar, 100), new OracleParameter("serverPK", OracleType.VarChar, 100), new OracleParameter("ad_Index", OracleType.Int32, 4), new OracleParameter("NewServerPK", OracleType.VarChar, 100), new OracleParameter("BH_Show", OracleType.Int32, 4) };
            parameters[0].Value = path;
            parameters[1].Value = serverPK;
            parameters[2].Value = operation;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            dbo.SqlProcPar("GetserviceStream", parameters);
            NewServerPK = parameters[3].Value.ToString();
        }

        public override void Login(DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from gov_tc_view_Users where UserName='" + base.UserName + "'");
            DataSet set = dbo.BackDataSet(builder.ToString(), null);
            if (set.Tables[0].Rows.Count > 0)
            {
                base.UserPK = set.Tables[0].Rows[0]["UserPK"].ToString();
                base.UserName = set.Tables[0].Rows[0]["UserName"].ToString();
                base.TrueName = set.Tables[0].Rows[0]["TrueName"].ToString();
                base.cName = set.Tables[0].Rows[0]["cName"].ToString();
                base.pk_corp = set.Tables[0].Rows[0]["pk_corp"].ToString();
                base.bName = set.Tables[0].Rows[0]["bName"].ToString();
                base.BranchPK = set.Tables[0].Rows[0]["BranchPK"].ToString();
                base.rName = set.Tables[0].Rows[0]["rName"].ToString();
                base.RolePK = set.Tables[0].Rows[0]["RolePK"].ToString();
                base.EmployeePK = set.Tables[0].Rows[0]["EmployeePK"].ToString();
                base.UserName = set.Tables[0].Rows[0]["UserName"].ToString();
                base.Password = set.Tables[0].Rows[0]["Password"].ToString();
                base.Power = set.Tables[0].Rows[0]["uPower"].ToString();
                base.DataPower = set.Tables[0].Rows[0]["uDataPower"].ToString();
                base.RowPower = set.Tables[0].Rows[0]["uRowPower"].ToString();
                base.ServicesPower = set.Tables[0].Rows[0]["uServicesPower"].ToString();
                base.CompanyPower = set.Tables[0].Rows[0]["uCompanyPower"].ToString();
                base.CompanyPower = base.CompanyPower + "|" + set.Tables[0].Rows[0]["bCompanyPower"].ToString();
                if (set.Tables[0].Rows[0]["rIsUserPower"].ToString() == "1")
                {
                    base.Power = base.Power + "|" + set.Tables[0].Rows[0]["rPower"].ToString();
                    base.DataPower = base.DataPower + "|" + set.Tables[0].Rows[0]["rDataPower"].ToString();
                    base.RowPower = base.RowPower + "|" + set.Tables[0].Rows[0]["rRowPower"].ToString();
                    base.ServicesPower = base.ServicesPower + "|" + set.Tables[0].Rows[0]["rServicesPower"].ToString();
                }
                base.Power = Public.DelRelTxt(base.Power, '|');
                base.DataPower = Public.DelRelTxt(base.DataPower, '|');
                base.RowPower = Public.DelRelTxt(base.RowPower, '|');
                base.ServicesPower = Public.DelRelTxt(base.ServicesPower, '|');
                base.CompanyPower = Public.DelRelTxt(base.CompanyPower, '|');
                base.Discription = set.Tables[0].Rows[0]["Discription"].ToString();
                base.IsUser = set.Tables[0].Rows[0]["IsUser"].ToString();
                base.Company = new CompanyDal { pk_corp = set.Tables[0].Rows[0]["pk_corp"].ToString() }.GetModel(false, false, false, dbo);
                base.Branch = new BranchDal { BranchPK = set.Tables[0].Rows[0]["BranchPK"].ToString() }.GetModel(false, false, false, false, dbo);
                base.Role = new RoleDal { RolePK = set.Tables[0].Rows[0]["RolePK"].ToString() }.GetModel(false, false, dbo);
                base.Employee = new EmployeeDal { EmployeePK = set.Tables[0].Rows[0]["EmployeePK"].ToString() }.GetModel(false, false, false, false, false, dbo);
            }
        }

        public override void SetServiceStream(string path, string BILL_CODE, string userID, string userCompany, string userDepart, string userDate, string serverPK, int operation, out string NewServerPK, DB_OPT dbo)
        {
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter("path", OracleType.VarChar, 100), new OracleParameter("BILL_CODE", OracleType.VarChar, 100), new OracleParameter("userID", OracleType.VarChar, 100), new OracleParameter("userCompany", OracleType.VarChar, 100), new OracleParameter("userDepart", OracleType.VarChar, 100), new OracleParameter("userDate", OracleType.DateTime), new OracleParameter("serverPK", OracleType.VarChar, 0xff), new OracleParameter("operation", OracleType.Int32, 4), new OracleParameter("NewServerPK", OracleType.VarChar, 100), new OracleParameter("XserverPK", OracleType.VarChar, 100) };
            parameters[0].Value = path;
            parameters[1].Value = BILL_CODE;
            parameters[2].Value = userID;
            parameters[3].Value = userCompany;
            parameters[4].Value = userDepart;
            parameters[5].Value = userDate;
            parameters[6].Value = serverPK;
            parameters[7].Value = operation;
            parameters[8].Direction = ParameterDirection.Output;
            parameters[9].Direction = ParameterDirection.Output;
            dbo.SqlProcPar("gov_tc_proc_serviceStream", parameters);
            NewServerPK = parameters[8].Value.ToString();
        }

        public override int Update(UserUpdatePowerType uupt, UserUpdateIndex uui, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_Users set ");
            Hashtable ht = null;
            switch (uupt)
            {
                case UserUpdatePowerType.BranchAndRole:
                    builder.Append("BranchPK='" + base.BranchPK + "',");
                    builder.Append("RolePK='" + base.RolePK + "',");
                    break;

                case UserUpdatePowerType.DataRowPower:
                    builder.Append("Power=:Power,");
                    builder.Append("DataPower=:DataPower,");
                    builder.Append("RowPower=:RowPower,");
                    builder.Append("ServicesPower=:ServicesPower,");
                    builder.Append("CompanyPower=:CompanyPower,");
                    ht = new Hashtable();
                    ht.Add("Power", base.Power);
                    ht.Add("DataPower", base.DataPower);
                    ht.Add("RowPower", base.RowPower);
                    ht.Add("ServicesPower", base.ServicesPower);
                    ht.Add("CompanyPower", base.CompanyPower);
                    break;

                case UserUpdatePowerType.All:
                    builder.Append("BranchPK='" + base.BranchPK + "',");
                    builder.Append("RolePK='" + base.RolePK + "',");
                    builder.Append("Power=:Power,");
                    builder.Append("DataPower=:DataPower,");
                    builder.Append("RowPower=:RowPower,");
                    builder.Append("ServicesPower=:ServicesPower,");
                    builder.Append("CompanyPower=:CompanyPower,");
                    ht = new Hashtable();
                    ht.Add("Power", base.Power);
                    ht.Add("DataPower", base.DataPower);
                    ht.Add("RowPower", base.RowPower);
                    ht.Add("ServicesPower", base.ServicesPower);
                    ht.Add("CompanyPower", base.CompanyPower);
                    break;
            }
            builder.Append("UserName='" + base.UserName + "',");
            builder.Append("TrueName='" + base.TrueName + "',");
            builder.Append("pk_corp='" + base.pk_corp + "',");
            if (base.Password != "")
            {
                builder.Append("Password='" + base.Password + "'");
            }
            switch (uui)
            {
                case UserUpdateIndex.AllowEmployeePK:
                    builder.Append(" where EmployeePK='" + base.EmployeePK + "'");
                    break;

                case UserUpdateIndex.AllowUserPK:
                    builder.Append(" where UserPK='" + base.UserPK + "'");
                    break;
            }
            return dbo.ExecutionIsSucess(builder.ToString(), ht);
        }

        public override int UpdatePwd(string strpwd, DB_OPT dbo)
        {
            string strSql = "update DB_Users set Password='" + strpwd.Trim() + "' where UserName='" + base.UserName.Trim() + "' and Password='" + base.Password.Trim() + "'";
            return dbo.ExecutionIsSucess(strSql, null);
        }

        public override string WelcomePower(string url, string username, ref string name)
        {
            DataSet set = DbHelperOra.Query("select menuname,powercode from db_menu t where pageurl='" + url + "'");
            if (set.Tables[0].Rows.Count > 0)
            {
                name = set.Tables[0].Rows[0]["menuname"].ToString();
                DataSet set2 = DbHelperOra.Query(string.Concat(new object[] { "select instr(uPower||'|'||rPower,'|'||'", set.Tables[0].Rows[0]["powercode"], "'||'|')indexNum from gov_tc_view_Users where username='", username, "'" }));
                if ((set2.Tables[0].Rows.Count > 0) && (int.Parse(set2.Tables[0].Rows[0]["indexNum"].ToString()) > 0))
                {
                    return "true";
                }
            }
            return "false";
        }
    }
}

