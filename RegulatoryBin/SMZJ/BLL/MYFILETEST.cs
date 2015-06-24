namespace SMZJ.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class MYFILETEST
    {
        private readonly SMZJ.DAL.MYFILETEST dal = new SMZJ.DAL.MYFILETEST();

        public void Add(SMZJ.Model.MYFILETEST model)
        {
            this.dal.Add(model);
        }

        public List<SMZJ.Model.MYFILETEST> DataTableToList(DataTable dt)
        {
            List<SMZJ.Model.MYFILETEST> list = new List<SMZJ.Model.MYFILETEST>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    SMZJ.Model.MYFILETEST item = new SMZJ.Model.MYFILETEST();
                    if (dt.Rows[i]["商品编号"].ToString() != "")
                    {
                        item.商品编号 = new int?(int.Parse(dt.Rows[i]["商品编号"].ToString()));
                    }
                    item.商品名称 = dt.Rows[i]["商品名称"].ToString();
                    item.商品小图地址 = dt.Rows[i]["商品小图地址"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public bool Delete(int 商品编号)
        {
            return this.dal.Delete(商品编号);
        }

        public bool DeleteList(string 商品编号list)
        {
            return this.dal.DeleteList(商品编号list);
        }

        public bool Exists(int 商品编号)
        {
            return this.dal.Exists(商品编号);
        }

        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public SMZJ.Model.MYFILETEST GetModel(int 商品编号)
        {
            return this.dal.GetModel(商品编号);
        }

        public List<SMZJ.Model.MYFILETEST> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public bool Update(SMZJ.Model.MYFILETEST model)
        {
            return this.dal.Update(model);
        }
    }
}

