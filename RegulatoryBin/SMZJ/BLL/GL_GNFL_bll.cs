

namespace SMZJ.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using SMZJ.DAL;
    public class GL_GNFL_bll
    {
        private readonly GL_GNFL_dal dal = new GL_GNFL_dal();
        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }
    }
}
