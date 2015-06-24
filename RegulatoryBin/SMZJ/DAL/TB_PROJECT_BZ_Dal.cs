namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class TB_PROJECT_BZ_Dal
    {
        public void Add(TB_PROJECT_BZ_Model model)
        {
            StringBuilder builder = new StringBuilder();
            model.PD_PROJECT_CODE = DateTime.Now.ToString("yyyyMMddhhmmssffffff");
            builder.Append("insert into TB_PROJECT(");
            builder.Append("PD_PROJECT_FILENO_ZB,PD_PROJECT_CODE,PD_PROJECT_NAME,PD_YEAR,PD_PROJECT_TYPE,PD_GK_DEPART,PD_FOUND_XZ,PD_PROJECT_IFGS,PD_PROJECT_IFGS_BEFORE,PD_PROJECT_OPEN_BODY,PD_PROJECT_STATUS,PD_PROJECT_FILENO_JG,PD_PROJECT_INPUT_COMPANY,PD_PROJECT_INPUT_MAN,PD_PROJECT_INPUT_DATE,PD_PROJECT_BZYJ,PD_PROJECT_BZFW,PD_PROJECT_BZDX,PD_PROJECT_BZNUM,PD_PROJECT_BZSTAND_NUM,PD_PROJECT_BZMONEY,PD_PROJECT_BZFF_DATE,PD_PROJECT_SJFF_DATE,PD_PROJECT_IFFF,PD_PROJECT_JGYQ,PD_PROJECT_JGJL,PD_PROJECT_JG_RESULT,PD_PROJECT_SERVERPK)");
            builder.Append(" values (");
            builder.Append(":PD_PROJECT_FILENO_ZB,:PD_PROJECT_CODE,:PD_PROJECT_NAME,:PD_YEAR,:PD_PROJECT_TYPE,:PD_GK_DEPART,:PD_FOUND_XZ,:PD_PROJECT_IFGS,:PD_PROJECT_IFGS_BEFORE,:PD_PROJECT_OPEN_BODY,:PD_PROJECT_STATUS,:PD_PROJECT_FILENO_JG,:PD_PROJECT_INPUT_COMPANY,:PD_PROJECT_INPUT_MAN,:PD_PROJECT_INPUT_DATE,:PD_PROJECT_BZYJ,:PD_PROJECT_BZFW,:PD_PROJECT_BZDX,:PD_PROJECT_BZNUM,:PD_PROJECT_BZSTAND_NUM,:PD_PROJECT_BZMONEY,:PD_PROJECT_BZFF_DATE,:PD_PROJECT_SJFF_DATE,:PD_PROJECT_IFFF,:PD_PROJECT_JGYQ,:PD_PROJECT_JGJL,:PD_PROJECT_JG_RESULT,:PD_PROJECT_SERVERPK)");
            builder.Append(" RETURNING PD_PROJECT_CODE INTO :R_Auto_No ");
            OracleParameter[] cmdParms = new OracleParameter[] { 
                new OracleParameter(":PD_PROJECT_FILENO_ZB", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 0x24), new OracleParameter(":PD_PROJECT_NAME", OracleType.VarChar, 100), new OracleParameter(":PD_YEAR", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_TYPE", OracleType.VarChar, 30), new OracleParameter(":PD_GK_DEPART", OracleType.VarChar, 100), new OracleParameter(":PD_FOUND_XZ", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_IFGS", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_IFGS_BEFORE", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_OPEN_BODY", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_STATUS", OracleType.VarChar, 20), new OracleParameter(":PD_PROJECT_FILENO_JG", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_INPUT_COMPANY", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_INPUT_MAN", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_INPUT_DATE", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_BZYJ", OracleType.VarChar, 100), 
                new OracleParameter(":PD_PROJECT_BZFW", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_BZDX", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_BZNUM", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_BZSTAND_NUM", OracleType.VarChar, 200), new OracleParameter(":PD_PROJECT_BZMONEY", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_BZFF_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_SJFF_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_IFFF", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_JGYQ", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_JGJL", OracleType.VarChar, 0xfa0), new OracleParameter(":PD_PROJECT_JG_RESULT", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_SERVERPK", OracleType.VarChar, 100), new OracleParameter(":R_Auto_No", OracleType.Number, 20)
             };
            cmdParms[0].Value = model.PD_PROJECT_FILENO_ZB;
            cmdParms[1].Value = model.PD_PROJECT_CODE;
            cmdParms[2].Value = model.PD_PROJECT_NAME;
            cmdParms[3].Value = model.PD_YEAR;
            cmdParms[4].Value = model.PD_PROJECT_TYPE;
            cmdParms[5].Value = model.PD_GK_DEPART;
            cmdParms[6].Value = model.PD_FOUND_XZ;
            cmdParms[7].Value = model.PD_PROJECT_IFGS;
            cmdParms[8].Value = model.PD_PROJECT_IFGS_BEFORE;
            cmdParms[9].Value = model.PD_PROJECT_OPEN_BODY;
            cmdParms[10].Value = model.PD_PROJECT_STATUS;
            cmdParms[11].Value = model.PD_PROJECT_FILENO_JG;
            cmdParms[12].Value = model.PD_PROJECT_INPUT_COMPANY;
            cmdParms[13].Value = model.PD_PROJECT_INPUT_MAN;
            cmdParms[14].Value = model.PD_PROJECT_INPUT_DATE;
            cmdParms[15].Value = model.PD_PROJECT_BZYJ;
            cmdParms[0x10].Value = model.PD_PROJECT_BZFW;
            cmdParms[0x11].Value = model.PD_PROJECT_BZDX;
            cmdParms[0x12].Value = model.PD_PROJECT_BZNUM;
            cmdParms[0x13].Value = model.PD_PROJECT_BZSTAND_NUM;
            cmdParms[20].Value = model.PD_PROJECT_BZMONEY;
            cmdParms[0x15].Value = model.PD_PROJECT_BZFF_DATE;
            cmdParms[0x16].Value = model.PD_PROJECT_SJFF_DATE;
            cmdParms[0x17].Value = model.PD_PROJECT_IFFF;
            cmdParms[0x18].Value = model.PD_PROJECT_JGYQ;
            cmdParms[0x19].Value = model.PD_PROJECT_JGJL;
            cmdParms[0x1a].Value = model.PD_PROJECT_JG_RESULT;
            cmdParms[0x1b].Value = model.PD_PROJECT_SERVERPK;
            cmdParms[0x1c].Direction = ParameterDirection.Output;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
            model.PD_PROJECT_CODE = cmdParms[0x1c].Value.ToString();
        }

        public bool Delete(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from TB_PROJECT ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string PD_PROJECT_CODElist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from TB_PROJECT ");
            builder.Append(" where PD_PROJECT_CODE in (" + PD_PROJECT_CODElist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from TB_PROJECT");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        private OracleType GetCloumnType(string ColumnName)
        {
            switch (ColumnName)
            {
                case "CHAR":
                    return OracleType.Char;

                case "VARCHAR2":
                    return OracleType.VarChar;

                case "DATE":
                    return OracleType.DateTime;

                case "NUMBER":
                    return OracleType.Number;
            }
            return OracleType.VarChar;
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PD_PROJECT_FILENO_ZB,PD_PROJECT_CODE,PD_PROJECT_NAME,PD_YEAR,PD_PROJECT_TYPE,PD_GK_DEPART,PD_FOUND_XZ,PD_PROJECT_IFGS,PD_PROJECT_IFGS_BEFORE,PD_PROJECT_OPEN_BODY,PD_PROJECT_STATUS,PD_PROJECT_FILENO_JG,PD_PROJECT_INPUT_COMPANY,PD_PROJECT_INPUT_MAN,PD_PROJECT_INPUT_DATE,PD_PROJECT_BZYJ,PD_PROJECT_BZFW,PD_PROJECT_BZDX,PD_PROJECT_BZNUM,PD_PROJECT_BZSTAND_NUM,PD_PROJECT_BZMONEY,PD_PROJECT_BZFF_DATE,PD_PROJECT_SJFF_DATE,PD_PROJECT_IFFF,PD_PROJECT_JGYQ,PD_PROJECT_JGJL,PD_PROJECT_JG_RESULT ");
            builder.Append(" FROM TB_PROJECT ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public TB_PROJECT_BZ_Model GetModel(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PD_PROJECT_FILENO_ZB,PD_PROJECT_CODE,PD_PROJECT_NAME,PD_YEAR,PD_PROJECT_TYPE,PD_GK_DEPART,PD_FOUND_XZ,PD_PROJECT_IFGS,PD_PROJECT_IFGS_BEFORE,PD_PROJECT_OPEN_BODY,PD_PROJECT_STATUS,PD_PROJECT_FILENO_JG,PD_PROJECT_INPUT_COMPANY,PD_PROJECT_INPUT_MAN,PD_PROJECT_INPUT_DATE,PD_PROJECT_BZYJ,PD_PROJECT_BZFW,PD_PROJECT_BZDX,PD_PROJECT_BZNUM,PD_PROJECT_BZSTAND_NUM,PD_PROJECT_BZMONEY,PD_PROJECT_BZFF_DATE,PD_PROJECT_SJFF_DATE,PD_PROJECT_IFFF,PD_PROJECT_JGYQ,PD_PROJECT_JGJL,PD_PROJECT_JG_RESULT");
            builder.Append(" from TB_PROJECT ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            TB_PROJECT_BZ_Model model = new TB_PROJECT_BZ_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            model.PD_PROJECT_FILENO_ZB = set.Tables[0].Rows[0]["PD_PROJECT_FILENO_ZB"].ToString();
            model.PD_PROJECT_CODE = set.Tables[0].Rows[0]["PD_PROJECT_CODE"].ToString();
            model.PD_PROJECT_NAME = set.Tables[0].Rows[0]["PD_PROJECT_NAME"].ToString();
            if (set.Tables[0].Rows[0]["PD_YEAR"].ToString() != "")
            {
                model.PD_YEAR = new int?(int.Parse(set.Tables[0].Rows[0]["PD_YEAR"].ToString()));
            }
            model.PD_PROJECT_TYPE = set.Tables[0].Rows[0]["PD_PROJECT_TYPE"].ToString();
            model.PD_GK_DEPART = set.Tables[0].Rows[0]["PD_GK_DEPART"].ToString();
            model.PD_FOUND_XZ = set.Tables[0].Rows[0]["PD_FOUND_XZ"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_IFGS"].ToString() != "")
            {
                model.PD_PROJECT_IFGS = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_IFGS"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_IFGS_BEFORE"].ToString() != "")
            {
                model.PD_PROJECT_IFGS_BEFORE = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_IFGS_BEFORE"].ToString()));
            }
            model.PD_PROJECT_OPEN_BODY = set.Tables[0].Rows[0]["PD_PROJECT_OPEN_BODY"].ToString();
            model.PD_PROJECT_STATUS = set.Tables[0].Rows[0]["PD_PROJECT_STATUS"].ToString();
            model.PD_PROJECT_FILENO_JG = set.Tables[0].Rows[0]["PD_PROJECT_FILENO_JG"].ToString();
            model.PD_PROJECT_INPUT_COMPANY = set.Tables[0].Rows[0]["PD_PROJECT_INPUT_COMPANY"].ToString();
            model.PD_PROJECT_INPUT_MAN = set.Tables[0].Rows[0]["PD_PROJECT_INPUT_MAN"].ToString();
            model.PD_PROJECT_INPUT_DATE = set.Tables[0].Rows[0]["PD_PROJECT_INPUT_DATE"].ToString();
            model.PD_PROJECT_BZYJ = set.Tables[0].Rows[0]["PD_PROJECT_BZYJ"].ToString();
            model.PD_PROJECT_BZFW = set.Tables[0].Rows[0]["PD_PROJECT_BZFW"].ToString();
            model.PD_PROJECT_BZDX = set.Tables[0].Rows[0]["PD_PROJECT_BZDX"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_BZNUM"].ToString() != "")
            {
                model.PD_PROJECT_BZNUM = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_BZNUM"].ToString()));
            }
            model.PD_PROJECT_BZSTAND_NUM = set.Tables[0].Rows[0]["PD_PROJECT_BZSTAND_NUM"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_BZMONEY"].ToString() != "")
            {
                model.PD_PROJECT_BZMONEY = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_BZMONEY"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_BZFF_DATE"].ToString() != "")
            {
                model.PD_PROJECT_BZFF_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_BZFF_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_SJFF_DATE"].ToString() != "")
            {
                model.PD_PROJECT_SJFF_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_SJFF_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_IFFF"].ToString() != "")
            {
                model.PD_PROJECT_IFFF = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_IFFF"].ToString()));
            }
            model.PD_PROJECT_JGYQ = set.Tables[0].Rows[0]["PD_PROJECT_JGYQ"].ToString();
            model.PD_PROJECT_JGJL = set.Tables[0].Rows[0]["PD_PROJECT_JGJL"].ToString();
            model.PD_PROJECT_JG_RESULT = set.Tables[0].Rows[0]["PD_PROJECT_JG_RESULT"].ToString();
            return model;
        }

        public TB_PROJECT_BZ_Model GetModelName(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select op.ShowText PD_PROJECT_FILENO_ZB,PD_PROJECT_FILENO_ZB PD_PROJECT_FILENO_ZB_CODE,PD_PROJECT_CODE,PD_PROJECT_NAME,PD_YEAR,PD_PROJECT_TYPE,PD_GK_DEPART,PD_FOUND_XZ,PD_PROJECT_IFGS,PD_PROJECT_IFGS_BEFORE,PD_PROJECT_OPEN_BODY,PD_PROJECT_STATUS,PD_PROJECT_FILENO_JG,PD_PROJECT_INPUT_COMPANY,PD_PROJECT_INPUT_MAN,PD_PROJECT_INPUT_DATE,PD_PROJECT_BZYJ,PD_PROJECT_BZFW,PD_PROJECT_BZDX,PD_PROJECT_BZNUM,PD_PROJECT_BZSTAND_NUM,PD_PROJECT_BZMONEY,PD_PROJECT_BZFF_DATE,PD_PROJECT_SJFF_DATE,PD_PROJECT_IFFF,PD_PROJECT_JGYQ,PD_PROJECT_JGJL,PD_PROJECT_JG_RESULT");
            builder.Append(" from TB_PROJECT t");
            builder.Append(" left join open_pd_quotaaddmoney op on trim(op.pd_quota_code)=trim(t.PD_PROJECT_FILENO_ZB) ");
            builder.Append(" where t.PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            TB_PROJECT_BZ_Model model = new TB_PROJECT_BZ_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            model.PD_PROJECT_FILENO_ZB = set.Tables[0].Rows[0]["PD_PROJECT_FILENO_ZB"].ToString();
            model.PD_PROJECT_FILENO_ZB_CODE = set.Tables[0].Rows[0]["PD_PROJECT_FILENO_ZB_CODE"].ToString();
            model.PD_PROJECT_CODE = set.Tables[0].Rows[0]["PD_PROJECT_CODE"].ToString();
            model.PD_PROJECT_NAME = set.Tables[0].Rows[0]["PD_PROJECT_NAME"].ToString();
            if (set.Tables[0].Rows[0]["PD_YEAR"].ToString() != "")
            {
                model.PD_YEAR = new int?(int.Parse(set.Tables[0].Rows[0]["PD_YEAR"].ToString()));
            }
            model.PD_PROJECT_TYPE = set.Tables[0].Rows[0]["PD_PROJECT_TYPE"].ToString();
            model.PD_GK_DEPART = set.Tables[0].Rows[0]["PD_GK_DEPART"].ToString();
            model.PD_FOUND_XZ = set.Tables[0].Rows[0]["PD_FOUND_XZ"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_IFGS"].ToString() != "")
            {
                model.PD_PROJECT_IFGS = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_IFGS"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_IFGS_BEFORE"].ToString() != "")
            {
                model.PD_PROJECT_IFGS_BEFORE = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_IFGS_BEFORE"].ToString()));
            }
            model.PD_PROJECT_OPEN_BODY = set.Tables[0].Rows[0]["PD_PROJECT_OPEN_BODY"].ToString();
            model.PD_PROJECT_STATUS = set.Tables[0].Rows[0]["PD_PROJECT_STATUS"].ToString();
            model.PD_PROJECT_FILENO_JG = set.Tables[0].Rows[0]["PD_PROJECT_FILENO_JG"].ToString();
            model.PD_PROJECT_INPUT_COMPANY = set.Tables[0].Rows[0]["PD_PROJECT_INPUT_COMPANY"].ToString();
            model.PD_PROJECT_INPUT_MAN = set.Tables[0].Rows[0]["PD_PROJECT_INPUT_MAN"].ToString();
            model.PD_PROJECT_INPUT_DATE = set.Tables[0].Rows[0]["PD_PROJECT_INPUT_DATE"].ToString();
            model.PD_PROJECT_BZYJ = set.Tables[0].Rows[0]["PD_PROJECT_BZYJ"].ToString();
            model.PD_PROJECT_BZFW = set.Tables[0].Rows[0]["PD_PROJECT_BZFW"].ToString();
            model.PD_PROJECT_BZDX = set.Tables[0].Rows[0]["PD_PROJECT_BZDX"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_BZNUM"].ToString() != "")
            {
                model.PD_PROJECT_BZNUM = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_BZNUM"].ToString()));
            }
            model.PD_PROJECT_BZSTAND_NUM = set.Tables[0].Rows[0]["PD_PROJECT_BZSTAND_NUM"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_BZMONEY"].ToString() != "")
            {
                model.PD_PROJECT_BZMONEY = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_BZMONEY"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_BZFF_DATE"].ToString() != "")
            {
                model.PD_PROJECT_BZFF_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_BZFF_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_SJFF_DATE"].ToString() != "")
            {
                model.PD_PROJECT_SJFF_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_SJFF_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_IFFF"].ToString() != "")
            {
                model.PD_PROJECT_IFFF = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_IFFF"].ToString()));
            }
            model.PD_PROJECT_JGYQ = set.Tables[0].Rows[0]["PD_PROJECT_JGYQ"].ToString();
            model.PD_PROJECT_JGJL = set.Tables[0].Rows[0]["PD_PROJECT_JGJL"].ToString();
            model.PD_PROJECT_JG_RESULT = set.Tables[0].Rows[0]["PD_PROJECT_JG_RESULT"].ToString();
            return model;
        }

        internal string InputData(DataSet ds)
        {
            string str = "";
            Hashtable hashtable = new Hashtable();
            hashtable.Add("序号", new Nodes("AUTO_NO", "CHAR", 0x24));
            hashtable.Add("发放日期", new Nodes("PD_BZFFLIST_DATE", "DATE", -1));
            hashtable.Add("补贴发放单位", new Nodes("PD_BZFFLIST_COMPANY", "VARCHAR2", 100));
            hashtable.Add("所属乡镇", new Nodes("PD_BZFFLIST_COUNTRY", "VARCHAR2", 100));
            hashtable.Add("用户代码", new Nodes("PD_BZFFLIST_PEASANT_CODE", "VARCHAR2", 100));
            hashtable.Add("对象姓名", new Nodes("PD_BZFFLIST_PEASANT_NAME", "VARCHAR2", 200));
            hashtable.Add("身份证号码", new Nodes("PD_BZFFLIST_IDNO", "VARCHAR2", 50));
            hashtable.Add("补贴数量", new Nodes("PD_BZFFLIST_FFNUM", "NUMBER", 20));
            hashtable.Add("补贴标准", new Nodes("PD_BZFFLIST_FFSTAND", "NUMBER", 20));
            hashtable.Add("补贴金额(元)", new Nodes("PD_BZFFLIST_FFMONEY", "NUMBER", 20));
            hashtable.Add("发放账号", new Nodes("PD_BZFFLIST_ACCOUNTNO", "VARCHAR2", 100));
            hashtable.Add("农户家庭住址", new Nodes("PD_BZFFLIST_PEASANT_ADDR", "VARCHAR2", 100));
            hashtable.Add("备注", new Nodes("PD_BZFFLIST_TEXT", "VARCHAR2", 0xff));
            string sQLString = "insert into PD_PROJECT_BZFFLIST(";
            string str3 = ") values(";
            OracleParameter[] cmdParms = new OracleParameter[ds.Tables[0].Columns.Count];
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                Nodes nodes = (Nodes) hashtable[ds.Tables[0].Columns[i].ColumnName.Trim()];
                if (nodes == null)
                {
                    return ("选择的Excel格式不正确,不存在列“" + ds.Tables[0].Columns[i].ColumnName.Trim() + "”,请重新选择");
                }
                string cloumnName = nodes.cloumnName;
                ds.Tables[0].Columns[i].ColumnName = cloumnName;
                sQLString = sQLString + cloumnName;
                str3 = str3 + ":" + cloumnName;
                if (i < (ds.Tables[0].Columns.Count - 1))
                {
                    sQLString = sQLString + ",";
                    str3 = str3 + ",";
                }
                if (nodes.TypeLength != -1)
                {
                    cmdParms[i] = new OracleParameter(":" + nodes.cloumnName, this.GetCloumnType(nodes.cloumnType), nodes.TypeLength);
                }
                else
                {
                    cmdParms[i] = new OracleParameter(":" + nodes.cloumnName, this.GetCloumnType(nodes.cloumnType));
                }
            }
            sQLString = sQLString + str3 + ")";
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    string str5;
                    if (((str5 = ds.Tables[0].Columns[j].ColumnName) != null) && (((str5 == "PD_BZFFLIST_IDNO") || (str5 == "PD_BZFFLIST_ACCOUNTNO")) || (str5 == "PD_BZFFLIST_PEASANT_CODE")))
                    {
                        cmdParms[j].Value = row[j].ToString().Remove(0, 1);
                    }
                    else
                    {
                        cmdParms[j].Value = row[j];
                    }
                }
                if (DbHelperOra.ExecuteSql(sQLString, cmdParms) <= 0)
                {
                    str = str + row[0] + ",";
                }
            }
            return str;
        }

        public bool Update(TB_PROJECT_BZ_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update TB_PROJECT set ");
            builder.Append("PD_PROJECT_FILENO_ZB=:PD_PROJECT_FILENO_ZB,");
            builder.Append("PD_PROJECT_NAME=:PD_PROJECT_NAME,");
            builder.Append("PD_YEAR=:PD_YEAR,");
            builder.Append("PD_PROJECT_TYPE=:PD_PROJECT_TYPE,");
            builder.Append("PD_GK_DEPART=:PD_GK_DEPART,");
            builder.Append("PD_FOUND_XZ=:PD_FOUND_XZ,");
            builder.Append("PD_PROJECT_IFGS=:PD_PROJECT_IFGS,");
            builder.Append("PD_PROJECT_IFGS_BEFORE=:PD_PROJECT_IFGS_BEFORE,");
            builder.Append("PD_PROJECT_OPEN_BODY=:PD_PROJECT_OPEN_BODY,");
            builder.Append("PD_PROJECT_STATUS=:PD_PROJECT_STATUS,");
            builder.Append("PD_PROJECT_FILENO_JG=:PD_PROJECT_FILENO_JG,");
            builder.Append("PD_PROJECT_INPUT_COMPANY=:PD_PROJECT_INPUT_COMPANY,");
            builder.Append("PD_PROJECT_INPUT_MAN=:PD_PROJECT_INPUT_MAN,");
            builder.Append("PD_PROJECT_INPUT_DATE=:PD_PROJECT_INPUT_DATE,");
            builder.Append("PD_PROJECT_BZYJ=:PD_PROJECT_BZYJ,");
            builder.Append("PD_PROJECT_BZFW=:PD_PROJECT_BZFW,");
            builder.Append("PD_PROJECT_BZDX=:PD_PROJECT_BZDX,");
            builder.Append("PD_PROJECT_BZNUM=:PD_PROJECT_BZNUM,");
            builder.Append("PD_PROJECT_BZSTAND_NUM=:PD_PROJECT_BZSTAND_NUM,");
            builder.Append("PD_PROJECT_BZMONEY=:PD_PROJECT_BZMONEY,");
            builder.Append("PD_PROJECT_BZFF_DATE=:PD_PROJECT_BZFF_DATE,");
            builder.Append("PD_PROJECT_SJFF_DATE=:PD_PROJECT_SJFF_DATE,");
            builder.Append("PD_PROJECT_IFFF=:PD_PROJECT_IFFF,");
            builder.Append("PD_PROJECT_JGYQ=:PD_PROJECT_JGYQ,");
            builder.Append("PD_PROJECT_JGJL=:PD_PROJECT_JGJL,");
            builder.Append("PD_PROJECT_JG_RESULT=:PD_PROJECT_JG_RESULT");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { 
                new OracleParameter(":PD_PROJECT_FILENO_ZB", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_NAME", OracleType.VarChar, 100), new OracleParameter(":PD_YEAR", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_TYPE", OracleType.VarChar, 30), new OracleParameter(":PD_GK_DEPART", OracleType.VarChar, 100), new OracleParameter(":PD_FOUND_XZ", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_IFGS", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_IFGS_BEFORE", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_OPEN_BODY", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_STATUS", OracleType.VarChar, 20), new OracleParameter(":PD_PROJECT_FILENO_JG", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_INPUT_COMPANY", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_INPUT_MAN", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_INPUT_DATE", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_BZYJ", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_BZFW", OracleType.VarChar, 100), 
                new OracleParameter(":PD_PROJECT_BZDX", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_BZNUM", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_BZSTAND_NUM", OracleType.VarChar, 200), new OracleParameter(":PD_PROJECT_BZMONEY", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_BZFF_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_SJFF_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_IFFF", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_JGYQ", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_JGJL", OracleType.VarChar, 0xfa0), new OracleParameter(":PD_PROJECT_JG_RESULT", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 0x24)
             };
            cmdParms[0].Value = model.PD_PROJECT_FILENO_ZB;
            cmdParms[1].Value = model.PD_PROJECT_NAME;
            cmdParms[2].Value = model.PD_YEAR;
            cmdParms[3].Value = model.PD_PROJECT_TYPE;
            cmdParms[4].Value = model.PD_GK_DEPART;
            cmdParms[5].Value = model.PD_FOUND_XZ;
            cmdParms[6].Value = model.PD_PROJECT_IFGS;
            cmdParms[7].Value = model.PD_PROJECT_IFGS_BEFORE;
            cmdParms[8].Value = model.PD_PROJECT_OPEN_BODY;
            cmdParms[9].Value = model.PD_PROJECT_STATUS;
            cmdParms[10].Value = model.PD_PROJECT_FILENO_JG;
            cmdParms[11].Value = model.PD_PROJECT_INPUT_COMPANY;
            cmdParms[12].Value = model.PD_PROJECT_INPUT_MAN;
            cmdParms[13].Value = model.PD_PROJECT_INPUT_DATE;
            cmdParms[14].Value = model.PD_PROJECT_BZYJ;
            cmdParms[15].Value = model.PD_PROJECT_BZFW;
            cmdParms[0x10].Value = model.PD_PROJECT_BZDX;
            cmdParms[0x11].Value = model.PD_PROJECT_BZNUM;
            cmdParms[0x12].Value = model.PD_PROJECT_BZSTAND_NUM;
            cmdParms[0x13].Value = model.PD_PROJECT_BZMONEY;
            cmdParms[20].Value = model.PD_PROJECT_BZFF_DATE;
            cmdParms[0x15].Value = model.PD_PROJECT_SJFF_DATE;
            cmdParms[0x16].Value = model.PD_PROJECT_IFFF;
            cmdParms[0x17].Value = model.PD_PROJECT_JGYQ;
            cmdParms[0x18].Value = model.PD_PROJECT_JGJL;
            cmdParms[0x19].Value = model.PD_PROJECT_JG_RESULT;
            cmdParms[0x1a].Value = model.PD_PROJECT_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public enum M_columnname
        {
            自动序号,
            补贴发放时间,
            补贴发放单位,
            所属乡镇,
            农户代码,
            农户姓名,
            身份证号码,
            补贴数量,
            补贴标准,
            补贴金额,
            发放账号,
            农户家庭住址
        }

        public class Nodes
        {
            public string cloumnName = "";
            public string cloumnType = "";
            public int TypeLength = -1;

            public Nodes(string cloumnname, string cloumntype, int typelength)
            {
                this.cloumnName = cloumnname;
                this.cloumnType = cloumntype;
                this.TypeLength = typelength;
            }
        }
    }
}

