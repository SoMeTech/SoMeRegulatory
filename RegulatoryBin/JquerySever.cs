using SoMeTech.CommonDll;
using SoMeTech.Data;
using System;
using System.Web;
using System.Web.Services;

[WebServiceBinding(ConformsTo=WsiProfiles.BasicProfile1_1), WebService(Namespace="http://tempuri.org/")]
public class JquerySever : WebService
{
    [WebMethod]
    public void GetData()
    {
        string sQLString = "select  Minpd_quota_code as PK,PD_QUOTA_ZBWH as 指标文号,PD_QUOTA_MONEY_TOTAL||'~'||sumPD_QUOTA_ZBXDZH||'~'||pd_quota_pici,'','' from v_quota_JieYuZB where  PD_QUOTA_MONEY_TOTAL-sumPD_QUOTA_ZBXDZH>0 and trim(pd_quota_input_depart)='030003'";
        JSONHelper.Write(DbHelperOra.Query(sQLString).Tables[0]);
    }

    [WebMethod]
    public void getdatainfo()
    {
        HttpRequest request = HttpContext.Current.Request;
        StateInfo o = new StateInfo();
        for (int i = 0; i < 0x5f5e100; i++)
        {
            o.State = i;
        }
        JSONHelper.Write(JSONHelper.Convert2Json(o));
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
}

