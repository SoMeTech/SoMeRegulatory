using SoMeTech.Company;
using SoMeTech.Company.Branch;
using SoMeTech.Company.Employee;
using SoMeTech.Company.Role;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.ServicesClass.Operation;
using SoMeTech.ServicesClass.Services;
using SoMeTech.User;
using SoMeTech.UsualBookTable;
using System;
using System.Data;
using System.Reflection;

public sealed class ifExist
{
    private BranchModel bm;
    private CompanyModel cm;
    private DB_OPT dbo;
    private EmployeeModel em;
    private MenuModel mmd;
    private RoleModel rm;
    private ServicesModel sm;
    private ServicesTypeModel stm;
    private UsualBookTableModel um;
    private UserModel user;

    public bool checkBranch(string strWhere)
    {
        this.bm = new BranchDal();
        this.dbo = new DB_OPT();
        return (this.bm.GetList(strWhere, this.dbo).Tables[0].Rows.Count > 0);
    }

    public bool checkCompany(string strWhere)
    {
        this.cm = new CompanyDal();
        this.dbo = new DB_OPT();
        return (this.cm.GetList(strWhere, this.dbo).Tables[0].Rows.Count > 0);
    }

    public bool checkEmployee(string strWhere)
    {
        this.em = new EmployeeDal();
        this.dbo = new DB_OPT();
        return (this.em.GetList(strWhere, this.dbo).Tables[0].Rows.Count > 0);
    }

    public bool checkIsRepeat(string sql)
    {
        this.dbo = new DB_OPT();
        DataSet set = new DataSet();
        set = this.dbo.BackDataSet(sql, null);
        return ((set != null) && (set.Tables[0].Rows.Count > 0));
    }

    public bool checkIsRepeat(string text, string sql)
    {
        bool flag = false;
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            DataSet set = new DataSet();
            set = this.dbo.BackDataSet(sql, null);
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                {
                    if (text == set.Tables[0].Rows[0][0].ToString())
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }
        catch (Exception)
        {
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
        return flag;
    }

    public bool checkIsRepeat(string dllPath, string className, string strMethod, object[] methodObjs)
    {
        Type type = Assembly.LoadFrom(dllPath).GetType(className);
        object obj2 = Activator.CreateInstance(type);
        type.GetMethod(strMethod).Invoke(obj2, methodObjs);
        return false;
    }

    

    public bool checkMenu(string strWhere)
    {
        this.mmd = new MenuDal();
        this.dbo = new DB_OPT();
        return (this.mmd.GetList(strWhere, this.dbo).Tables[0].Rows.Count > 0);
    }

    public bool checkRole(string strWhere)
    {
        this.rm = new RoleDal();
        this.dbo = new DB_OPT();
        return (this.rm.GetList(strWhere, this.dbo).Tables[0].Rows.Count > 0);
    }

    public bool checkService(string strWhere)
    {
        this.sm = new ServicesDal();
        this.dbo = new DB_OPT();
        return (this.sm.GetList(strWhere, this.dbo).Tables[0].Rows.Count > 0);
    }

    public bool checkServiceMess(string strWhere)
    {
        ServicesMessModel model = new ServicesMessDal();
        this.dbo = new DB_OPT();
        return (model.GetList(strWhere, this.dbo).Tables[0].Rows.Count > 0);
    }

    public bool checkServiceRegister(string strWhere)
    {
        ServicesRegisterModel model = new ServicesRegisterDal();
        this.dbo = new DB_OPT();
        return (model.GetList(strWhere, this.dbo).Tables[0].Rows.Count > 0);
    }

    public bool checkServiceType(string strWhere)
    {
        this.stm = new ServicesTypeDal();
        this.dbo = new DB_OPT();
        return (this.stm.GetList(strWhere, this.dbo).Tables[0].Rows.Count > 0);
    }

   

   

    public bool checkUser(string strWhere)
    {
        this.user = new UserDal();
        this.dbo = new DB_OPT();
        return (this.user.GetList(strWhere, this.dbo).Tables[0].Rows.Count > 0);
    }

    public bool checkUsualBookTable(string strWhere, string tableName)
    {
        this.um = new UsualBookTableDal();
        this.dbo = new DB_OPT();
        this.um.TableName = tableName;
        return (this.um.GetList(strWhere, this.dbo).Tables[0].Rows.Count > 0);
    }


}

