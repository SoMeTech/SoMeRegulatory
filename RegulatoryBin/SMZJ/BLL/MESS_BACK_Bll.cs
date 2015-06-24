namespace SMZJ.BLL
{
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;
    public class MESS_BACK_Bll
    {
        private readonly MESS_BACK_Dal dal = new MESS_BACK_Dal();

        public void Add(MESS_BACK_Model model)
        {
            this.dal.Add(model);
        }

        public bool Delete(string MES_ID)
        {
            return this.dal.Delete(MES_ID);
        }

        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public MESS_BACK_Model GetModel(string MES_ID)
        {
            return this.dal.GetModel(MES_ID);
        }

        public bool Update(MESS_BACK_Model model)
        {
            return this.dal.Update(model);
        }
    }
}
