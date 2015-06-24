using System;
using System.Configuration;

public class DBConfigFactory
{
    protected static char[] configurationSeparator = new char[] { ',' };

    public static string ConfigPath
    {
        get
        {
            string str;
            try
            {
                str = ConfigurationManager.AppSettings["ConfigPath"].ToString();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return str;
        }
    }

    public static string GetBLLAssembly
    {
        get
        {
            string str;
            try
            {
                str = ConfigurationManager.AppSettings["BLLAssembly"].ToString();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return str;
        }
    }

    public static string GetCacheDatabaseName
    {
        get
        {
            string str;
            try
            {
                str = ConfigurationManager.AppSettings["CacheDatabaseName"].ToString();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return str;
        }
    }

    public static string GetCacheDependencyAssembly
    {
        get
        {
            string str;
            try
            {
                str = ConfigurationManager.AppSettings["CacheDependencyAssembly"].ToString();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return str;
        }
    }

    public static string[] GetCategoryTableDependency
    {
        get
        {
            string[] strArray;
            try
            {
                strArray = ConfigurationManager.AppSettings["CategoryTableDependency"].Split(configurationSeparator);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return strArray;
        }
    }

    public static string GetDALAssembly
    {
        get
        {
            string str;
            try
            {
                str = ConfigurationManager.AppSettings["DALAssembly"].ToString();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return str;
        }
    }

    public static string GetDBConnectionString
    {
        get
        {
            string connectionString;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringA"].ConnectionString;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return connectionString;
        }
    }
}

