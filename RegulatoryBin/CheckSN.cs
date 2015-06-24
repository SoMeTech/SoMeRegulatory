using SoMeTech.CommonDll;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;

public class CheckSN
{
    public static bool UseSMlicense(string CompanyPk, out string errorInfo)
    {
        try
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SM");
            CompanyPk = CompanyPk.Substring(0, 6);
            builder.Append(CompanyPk);
            SMLicense.HRET(builder.ToString());
            if (File.Exists(HttpContext.Current.Request.PhysicalApplicationPath.ToString() + "License.lic"))
            {
                string str;
                StreamReader reader = new StreamReader(HttpContext.Current.Request.PhysicalApplicationPath.ToString() + "License.lic", Encoding.Default);
                while ((str = reader.ReadLine()) != null)
                {
                    string[] strArray = str.Split(new char[] { '&' });
                    new SymmetricMethod();
                    if (strArray.Length == 9)
                    {
                        string etStr = strArray[2];
                        etStr = SMLicense.HEDET(etStr);
                        string str3 = strArray[3];
                        if (DateTime.Now > Convert.ToDateTime(SMLicense.HEDET(str3)))
                        {
                            errorInfo = "系统授权已到期，请联系服务商续期！";
                            return false;
                        }
                        if (etStr.Equals(CompanyPk))
                        {
                            errorInfo = "";
                            return true;
                        }
                    }
                    else
                    {
                        int length = strArray.Length;
                    }
                }
            }
            else
            {
                if(CompanyPk.ToString() == "431026")
                {
                    errorInfo = "试用版，请及时注册";
                    return true;
                }
            }
            errorInfo = "系统未注册，请尽快联系服务商注册！";
            return false;
        }
        catch (Exception)
        {
            errorInfo = "系统未注册，请尽快联系服务商注册！";
            return false;
        }
    }
}

