namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class HideColumn_Model
    {
        private string _columnname;
        private decimal _id;
        private decimal? _reportparampk = 0;

        public string ColumnName
        {
            get
            {
                return this._columnname;
            }
            set
            {
                this._columnname = value;
            }
        }

        public decimal id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public decimal? reportParamPK
        {
            get
            {
                return this._reportparampk;
            }
            set
            {
                this._reportparampk = value;
            }
        }
    }
}

