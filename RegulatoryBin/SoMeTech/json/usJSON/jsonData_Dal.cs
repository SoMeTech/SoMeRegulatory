namespace SoMeTech.json.usJSON
{
    using System;
    using System.Data;
    using SMZJ.BLL;

    public class jsonData_Dal
    {
        public DataSet get_xmss_DataSet(string PD_PROJECT_CODE)
        {
            PD_PROJECT_ATTACH_SS_Bll bll = new PD_PROJECT_ATTACH_SS_Bll();
            return bll.GetList(" PD_PROJECT_CODE='" + PD_PROJECT_CODE + "'");
        }
    }
}

