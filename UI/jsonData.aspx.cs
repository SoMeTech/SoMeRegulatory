using ASP;
using SoMeTech.json.usJSON;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public class jsonData : Page, IRequiresSessionState
{
    protected HtmlForm form1;

    private void getJSONstr(DataSet ds)
    {
        string s = base.Request.Params["start"];
        string str2 = base.Request.Params["limit"];
        JSONObject jsonObject = new JSONObject();
        JSONArray array = new JSONArray();
        for (int i = int.Parse(s); (i < ds.Tables[0].Rows.Count) && (i < (int.Parse(s) + int.Parse(str2))); i++)
        {
            JSONObject item = new JSONObject();
            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
            {
                item.Add(ds.Tables[0].Columns[j].ColumnName, "'" + ds.Tables[0].Rows[i][j] + "'");
            }
            array.Add(item);
        }
        jsonObject.Add("totalProperty", ds.Tables[0].Rows.Count);
        jsonObject.Add("root", array);
        string str3 = JSONConvert.SerializeObject(jsonObject);
        base.Response.Write(str3);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string str;
        jsonData_Dal dal = new jsonData_Dal();
        if (((str = base.Request["tname"]) != null) && (str == "xmss"))
        {
            this.getJSONstr(dal.get_xmss_DataSet(base.Request["pk"]));
        }
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }
}
