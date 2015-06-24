namespace SoMeTech.CommonDll
{
    using SoMeTech.Data;
    using System;
    using System.Data;

    public class GetSetXiangCunZu
    {
        public string getCun(string iId)
        {
            string str = "-请选择-,0|";
            DataSet set = new DataSet();
            foreach (DataRow row in DbHelperOra.Query("select * from PD_BASE_GROUP where father='" + iId + "'").Tables[0].Rows)
            {
                string str2 = str;
                str = str2 + row["GROUP_Name"].ToString() + "," + row["GROUP_Code"].ToString() + "|";
            }
            return str;
        }

        public string getXiang()
        {
            string str = "-请选择-,0|";
            DataSet set = new DataSet();
            set = DbHelperOra.Query("select * from db_company where ZXBJ=1");
            if (set != null)
            {
                foreach (DataRow row in set.Tables[0].Rows)
                {
                    string str2 = str;
                    str = str2 + row["Name"].ToString() + "," + row["PK_CORP"].ToString() + "|";
                }
            }
            return str;
        }

        public string getZu(string iId)
        {
            string str = "-请选择-,0|";
            DataSet set = new DataSet();
            set = DbHelperOra.Query("select * from PD_BASE_VILLAGE where father='" + iId + "'");
            if (set != null)
            {
                foreach (DataRow row in set.Tables[0].Rows)
                {
                    string str2 = str;
                    str = str2 + row["VILLAGE_Name"].ToString() + "," + row["VILLAGE_Code"].ToString() + "|";
                }
            }
            return str;
        }
    }
}

