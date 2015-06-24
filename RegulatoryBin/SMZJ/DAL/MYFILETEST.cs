namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class MYFILETEST
    {
        public void Add(SMZJ.Model.MYFILETEST model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into MYFILETEST(");
            builder.Append("商品编号,商品名称,商品小图地址)");
            builder.Append(" values (");
            builder.Append(":商品编号,:商品名称,:商品小图地址)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":商品编号", OracleType.Number, 4), new OracleParameter(":商品名称", OracleType.VarChar, 0xff), new OracleParameter(":商品小图地址", OracleType.VarChar, 0xff) };
            cmdParms[0].Value = model.商品编号;
            cmdParms[1].Value = model.商品名称;
            cmdParms[2].Value = model.商品小图地址;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        public bool Delete(int 商品编号)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from MYFILETEST ");
            builder.Append(" where 商品编号=:商品编号 ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":商品编号", OracleType.Number, 4) };
            cmdParms[0].Value = 商品编号;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string 商品编号list)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from MYFILETEST ");
            builder.Append(" where 商品编号 in (" + 商品编号list + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int 商品编号)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from MYFILETEST");
            builder.Append(" where 商品编号=:商品编号 ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":商品编号", OracleType.Number, 4) };
            cmdParms[0].Value = 商品编号;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select 商品编号,商品名称,商品小图地址 ");
            builder.Append(" FROM MYFILETEST ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public SMZJ.Model.MYFILETEST GetModel(int 商品编号)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select 商品编号,商品名称,商品小图地址 from MYFILETEST ");
            builder.Append(" where 商品编号=:商品编号 ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":商品编号", OracleType.Number, 4) };
            cmdParms[0].Value = 商品编号;
            SMZJ.Model.MYFILETEST myfiletest = new SMZJ.Model.MYFILETEST();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["商品编号"].ToString() != "")
            {
                myfiletest.商品编号 = new int?(int.Parse(set.Tables[0].Rows[0]["商品编号"].ToString()));
            }
            myfiletest.商品名称 = set.Tables[0].Rows[0]["商品名称"].ToString();
            myfiletest.商品小图地址 = set.Tables[0].Rows[0]["商品小图地址"].ToString();
            return myfiletest;
        }

        public bool Update(SMZJ.Model.MYFILETEST model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update MYFILETEST set ");
            builder.Append("商品编号=:商品编号,");
            builder.Append("商品名称=:商品名称,");
            builder.Append("商品小图地址=:商品小图地址");
            builder.Append(" where 商品编号=:商品编号 ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":商品编号", OracleType.Number, 4), new OracleParameter(":商品名称", OracleType.VarChar, 0xff), new OracleParameter(":商品小图地址", OracleType.VarChar, 0xff) };
            cmdParms[0].Value = model.商品编号;
            cmdParms[1].Value = model.商品名称;
            cmdParms[2].Value = model.商品小图地址;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

