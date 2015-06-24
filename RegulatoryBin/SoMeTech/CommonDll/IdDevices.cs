namespace SoMeTech.CommonDll
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Linq;

    public class IdDevices
    {
        private DB_OPT dbo;
        private IdRulesDal ir;

        public bool CompareDate(string strDate)
        {
            return (strDate == this.GetCurrentDate());
        }

        public bool CompareMonth(string strDate)
        {
            return (strDate.Substring(0, 6) == this.GetCurrentDate().Substring(0, 6));
        }

        public bool CompareYear(string strDate)
        {
            return (strDate.Substring(0, 4) == this.GetCurrentDate().Substring(0, 4));
        }

        public string GetCurrentDate()
        {
            string str = "";
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            str = year.ToString();
            if (month < 10)
            {
                str = str + "0" + month;
            }
            else
            {
                str = str + month;
            }
            if (day < 10)
            {
                return (str + "0" + day);
            }
            return (str + day);
        }

        public string GetRulesId(int id)
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            this.ir = new IdRulesDal();
            string strWhere = " id= " + id + " order by Paragraphs ";
            DataSet list = this.ir.GetList(strWhere, this.dbo);
            return this.rulesProcess(list, id);
        }

        public string rulesProcess(DataSet ds, int rulesid)
        {
            string str;
            string str2 = "";
            try
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return "";
                }
                if (ds.Tables[0].Select(" IsRestore=1 ").Count<DataRow>() == 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string str3;
                        string str4 = ds.Tables[0].Rows[i]["type"].ToString();
                        if (str4 != null)
                        {
                            if (!(str4 == "固定字符"))
                            {
                                if (str4 == "日期")
                                {
                                    goto Label_0111;
                                }
                                if (str4 == "数字")
                                {
                                    goto Label_0144;
                                }
                                if (!(str4 == "用户输入文本"))
                                {
                                    continue;
                                }
                                goto Label_0296;
                            }
                            str2 = str2 + ds.Tables[0].Rows[i]["CurrentValue"] + ds.Tables[0].Rows[i]["EndSign"];
                        }
                        continue;
                    Label_0111:
                        str2 = str2 + this.GetCurrentDate() + ds.Tables[0].Rows[i]["EndSign"];
                        continue;
                    Label_0144:
                        str3 = ds.Tables[0].Select(" IsRestore=0 and Type='数字' ")[0]["CurrentValue"].ToString();
                        int num2 = Convert.ToInt32(ds.Tables[0].Select(" IsRestore=0 and Type='数字' ")[0]["maxValue"]);
                        if (Convert.ToInt32(str3) > num2)
                        {
                            return "-1";
                        }
                        for (int j = str3.Length; j < num2.ToString().Length; j++)
                        {
                            str3 = "0" + str3;
                        }
                        str2 = str2 + ds.Tables[0].Rows[i]["CurrentValue"] + ds.Tables[0].Rows[i]["EndSign"];
                        int typeid = Convert.ToInt32(ds.Tables[0].Select(" Type='数字' ")[0]["typeid"]);
                        int num5 = Convert.ToInt32(ds.Tables[0].Select(" IsRestore=0 and Type='数字' ")[0]["step"]);
                        int currentvalue = Convert.ToInt32(str3) + num5;
                        this.ir.UpdateNum(currentvalue, rulesid, typeid, this.dbo);
                        continue;
                    Label_0296:
                        str2 = str2 + "&" + ds.Tables[0].Rows[i]["EndSign"];
                    }
                }
                else
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        string str5;
                        string str6 = ds.Tables[0].Rows[k]["type"].ToString();
                        if (str6 != null)
                        {
                            if (!(str6 == "固定字符"))
                            {
                                if (str6 == "日期")
                                {
                                    goto Label_03B3;
                                }
                                if (str6 == "数字")
                                {
                                    goto Label_03E7;
                                }
                                if (!(str6 == "用户输入文本"))
                                {
                                    continue;
                                }
                                goto Label_0742;
                            }
                            str2 = str2 + ds.Tables[0].Rows[k]["CurrentValue"] + ds.Tables[0].Rows[k]["EndSign"];
                        }
                        continue;
                    Label_03B3:
                        str2 = str2 + this.GetCurrentDate() + ds.Tables[0].Rows[k]["EndSign"];
                        continue;
                    Label_03E7:
                        str5 = ds.Tables[0].Select(" Type='日期' ")[0]["CurrentValue"].ToString();
                        string str7 = ds.Tables[0].Select(" IsRestore=1 and Type='数字' ")[0]["RestoreCycle"].ToString();
                        if ((((str7 == "日") && this.CompareDate(str5)) || ((str7 == "月") && this.CompareMonth(str5))) || ((str7 == "年") && this.CompareYear(str5)))
                        {
                            string str8 = ds.Tables[0].Select(" IsRestore=1 and Type='数字' ")[0]["CurrentValue"].ToString();
                            int num8 = Convert.ToInt32(ds.Tables[0].Select(" IsRestore=1 and Type='数字' ")[0]["maxValue"]);
                            if (Convert.ToInt32(str8) > num8)
                            {
                                return "-1";
                            }
                            for (int m = str8.Length; m < num8.ToString().Length; m++)
                            {
                                str8 = "0" + str8;
                            }
                            str2 = str2 + str8 + ds.Tables[0].Rows[k]["EndSign"];
                            int num10 = Convert.ToInt32(ds.Tables[0].Select(" IsRestore=1 and Type='数字' ")[0]["step"]);
                            int num11 = Convert.ToInt32(str8) + num10;
                            int num12 = Convert.ToInt32(ds.Tables[0].Select(" Type='数字' ")[0]["typeid"]);
                            this.ir.UpdateNum(num11, rulesid, num12, this.dbo);
                        }
                        else
                        {
                            string str9 = ds.Tables[0].Select(" IsRestore=1 and Type='数字' ")[0]["InitialValue"].ToString();
                            int num13 = Convert.ToInt32(ds.Tables[0].Select(" IsRestore=1 and Type='数字' ")[0]["maxValue"]);
                            if (Convert.ToInt32(str9) > num13)
                            {
                                return "-1";
                            }
                            for (int n = str9.Length; n < num13.ToString().Length; n++)
                            {
                                str9 = "0" + str9;
                            }
                            str2 = str2 + str9 + ds.Tables[0].Rows[k]["EndSign"];
                            int num15 = Convert.ToInt32(ds.Tables[0].Select(" Type='日期' ")[0]["typeid"]);
                            this.ir.UpdateDate(this.GetCurrentDate(), rulesid, num15, this.dbo);
                            num15 = Convert.ToInt32(ds.Tables[0].Select(" Type='数字' ")[0]["typeid"]);
                            int num16 = Convert.ToInt32(ds.Tables[0].Select(" IsRestore=1 and Type='数字' ")[0]["step"]);
                            int num17 = Convert.ToInt32(str9) + num16;
                            this.ir.UpdateNum(num17, rulesid, num15, this.dbo);
                        }
                        continue;
                    Label_0742:
                        str2 = str2 + "&" + ds.Tables[0].Rows[k]["EndSign"];
                    }
                }
                str = str2;
            }
            finally
            {
                this.dbo.Close();
            }
            return str;
        }
    }
}

