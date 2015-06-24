using ExceptionLog;
using SoMeTech.DataAccess;
using SoMeTech.OperationLog;
using SoMeTech.User;
using System;
using System.Web;
using System.Web.UI;

public sealed class OperationLogBll : MainPageClass
{
    public static void deleteOp(string pk, Page page)
    {
        DB_OPT db = null;
        try
        {
            OperationLogModel model = new OperationLogDal();
            db = new DB_OPT();
            db.Open();
            model.pk = pk;
            model.Delete(db);
        }
        catch (Exception exception)
        {
            new ExceptionLog.ExceptionLog { ErrClassName = "OperationLogBll", ErrMessage = exception.Message.ToString(), ErrMethod = "deleteOp()" }.WriteExceptionLog(true);
            Const.OpenErrorPage("操作失败，请联系管理员！", page);
        }
        finally
        {
            if (db != null)
            {
                db.Close();
            }
        }
    }

    public static int insertOp(string opType, string Business, string Content, string ifPass, Page page)
    {
        int num = 0;
        DB_OPT dbo = null;
        try
        {
            OperationLogModel model = new OperationLogDal();
            dbo = new DB_OPT();
            dbo.Open();
            string userName = "";
            if (((UserModel) HttpContext.Current.Session["user"]).TrueName == "")
            {
                userName = ((UserModel) HttpContext.Current.Session["user"]).UserName;
            }
            else
            {
                userName = ((UserModel) HttpContext.Current.Session["user"]).TrueName;
            }
            model.UserName = userName;
            model.opType = opType;
            model.Business = Business;
            model.Content = Content;
            model.ifPass = ifPass;
            num = model.Add(dbo);
        }
        catch (Exception exception)
        {
            new ExceptionLog.ExceptionLog { ErrClassName = "OperationLogBll", ErrMessage = exception.Message.ToString(), ErrMethod = "insertOp()" }.WriteExceptionLog(true);
            Const.OpenErrorPage("操作失败，请联系管理员！", page);
        }
        finally
        {
            if (dbo != null)
            {
                dbo.Close();
            }
        }
        return num;
    }
}

