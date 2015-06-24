using ExceptionLog;
using SoMeTech.CommonDll.Configuration;
using SoMeTech.Company;
using SoMeTech.DataAccess;
using SoMeTech.User;
using QxRoom.QxConst;
using System;
using System.Data;
using System.Web;
using System.Web.UI;

public sealed class UserBll
{
    public int adduserinfo(string strdept, string strposition, string stremployee, string strname, string strtruename, string strpwd, string strpk_crop, DB_OPT opt)
    {
        UserModel model = new UserDal {
            BranchPK = strdept,
            RolePK = strposition,
            EmployeePK = stremployee,
            UserName = strname,
            TrueName = strtruename,
            Password = strpwd,
            pk_corp = strpk_crop
        };
        return model.Add(opt);
    }

    public int ChangePwd(string struser, string strpwd, string strOpwd)
    {
        int num;
        UserModel model = new UserDal();
        DB_OPT dbo = new DB_OPT();
        try
        {
            dbo.Open();
            model.UserName = struser;
            model.Password = QxRoom.QxConst.QxConst.Encrypt(strOpwd, "powerich");
            num = model.UpdatePwd(strpwd, dbo);
        }
        catch (Exception exception)
        {
            throw exception;
        }
        finally
        {
            dbo.Close();
        }
        return num;
    }

    public string deleteuserinfo(string strUser, Page page)
    {
        string str2;
        string str = "";
        UserModel model = new UserDal();
        DB_OPT dbo = new DB_OPT();
        try
        {
            dbo.Open();
            model.UserPK = strUser;
            model.GetModel(dbo);
            if (model.UserName == "admin")
            {
                return "admin";
            }
            model.Delete(dbo);
            OperationLogBll.insertOp("删除", "用户列表", "删除 " + model.cName + " 单位， " + model.bName + "部门下用户名为：" + model.UserName + " 真实姓名为：" + model.TrueName + " 的用户", "Y", page);
            str2 = str;
        }
        catch (Exception exception)
        {
            throw exception;
        }
        finally
        {
            dbo.Close();
        }
        return str2;
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

    public static string GetUserCompany(string username)
    {
        string str = "false";
        DB_OPT dbo = null;
        try
        {
            dbo = new DB_OPT();
            dbo.Open();
            string str2 = "";
            UserDal.GetCompanyPK(username.Trim(), ref str2, dbo);
            if (str2 != "")
            {
                string ccode = "";
                string cname = "";
                CompanyDal.GetCompanyName(str2, ref ccode, ref cname, dbo);
                str = ccode + "," + cname;
            }
        }
        catch (Exception exception)
        {
            new ExceptionLog.ExceptionLog { ErrClassName = "UserBll", ErrMessage = exception.Message.ToString(), ErrMethod = "GetUserCompany()" }.WriteExceptionLog(true);
        }
        finally
        {
            if (dbo != null)
            {
                dbo.Close();
            }
        }
        return str;
    }

    public int IfHadData(string emppk, DB_OPT dbo)
    {
        UserModel model = new UserDal {
            EmployeePK = emppk
        };
        return model.ExistsByEmpPK(dbo);
    }

    public int IsHaveData(string emppk)
    {
        int num;
        UserModel model = new UserDal();
        DB_OPT dbo = new DB_OPT();
        try
        {
            dbo.Open();
            model.EmployeePK = emppk;
            num = model.ExistsByEmpPK(dbo);
        }
        catch (Exception exception)
        {
            throw exception;
        }
        finally
        {
            dbo.Close();
        }
        return num;
    }

    public UserModel Login(string struser)
    {
        UserModel model;
        UserModel model2 = new UserDal();
        DB_OPT dbo = new DB_OPT();
        try
        {
            dbo.Open();
            model2.UserName = struser;
            model2.Login(dbo);
            ConfigurationModel model3 = new ConfigurationDal().GetModel(dbo);
            if (model3 != null)
            {
                HttpContext.Current.Response.Cookies["ischangelist"].Value = model3.ISCHANGELIST;
                HttpContext.Current.Session["common"] = model3;
                if (model3.ErrMessPath != "")
                {
                    ExceptionLog.ExceptionLog log = new ExceptionLog.ExceptionLog {
                        LogFilePath = model3.ErrMessPath
                    };
                }
            }
            model = model2;
        }
        catch (Exception exception)
        {
            throw exception;
        }
        finally
        {
            dbo.Close();
        }
        return model;
    }

    public static bool TryCon(string strCon)
    {
        bool flag = false;
        DB_OPT db_opt = null;
        try
        {
            db_opt = new DB_OPT();
            db_opt.OpenTest(strCon);
            flag = true;
        }
        catch (Exception exception)
        {
            new ExceptionLog.ExceptionLog { ErrClassName = "EIP_User.Login", ErrMessage = exception.Message.ToString(), ErrMethod = "TryCon()" }.WriteExceptionLog(true);
        }
        finally
        {
            if (db_opt != null)
            {
                db_opt.Close();
            }
        }
        return flag;
    }

    public int Updateuserinfo(string strUser, string power, string strname, string pk_corp)
    {
        int num;
        UserModel model = new UserDal();
        DB_OPT dbo = new DB_OPT();
        try
        {
            dbo.Open();
            model.EmployeePK = strUser;
            model.UserName = strname;
            model.Power = power;
            model.pk_corp = pk_corp;
            num = model.Update(UserUpdatePowerType.BranchAndRole, UserUpdateIndex.AllowEmployeePK, dbo);
        }
        catch (Exception exception)
        {
            throw exception;
        }
        finally
        {
            dbo.Close();
        }
        return num;
    }

    public int Updateuserinfo(string strUser, string bmpk, string rolepk, string strname, string pk_corp, DB_OPT opt)
    {
        int num;
        UserModel model = new UserDal();
        try
        {
            model.EmployeePK = strUser;
            model.UserName = strname;
            model.BranchPK = bmpk;
            model.RolePK = rolepk;
            model.pk_corp = pk_corp;
            num = model.Update(UserUpdatePowerType.BranchAndRole, UserUpdateIndex.AllowEmployeePK, opt);
        }
        catch (Exception exception)
        {
            throw exception;
        }
        return num;
    }

    public DataSet userinfo(string strwhere)
    {
        DataSet listAll;
        UserModel model = new UserDal();
        DB_OPT dbo = new DB_OPT();
        try
        {
            dbo.Open();
            listAll = model.GetListAll(strwhere, dbo);
        }
        catch (Exception exception)
        {
            throw exception;
        }
        finally
        {
            dbo.Close();
        }
        return listAll;
    }

    public DataSet UserName(string struser)
    {
        DataSet list;
        UserModel model = new UserDal();
        DB_OPT dbo = new DB_OPT();
        try
        {
            dbo.Open();
            model.UserPK = struser;
            list = model.GetList(" UserPK='" + model.UserPK + "'", dbo);
        }
        catch (Exception exception)
        {
            throw exception;
        }
        finally
        {
            dbo.Close();
        }
        return list;
    }
}

