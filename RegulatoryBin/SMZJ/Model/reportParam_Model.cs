namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class reportParam_Model
    {
        private string _columndata;
        private decimal _id;
        private decimal? _iscolumnwhere;
        private decimal? _isopenshow;
        private string _name;
        private decimal? _reportspanrow;
        private string _showreportname;
        private string _tabelname;
        private string _tbtype;

        public string columndata
        {
            get
            {
                return this._columndata;
            }
            set
            {
                this._columndata = value;
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

        public decimal? IsColumnWhere
        {
            get
            {
                return this._iscolumnwhere;
            }
            set
            {
                this._iscolumnwhere = value;
            }
        }

        public decimal? IsOpenShow
        {
            get
            {
                return this._isopenshow;
            }
            set
            {
                this._isopenshow = value;
            }
        }

        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public decimal? ReportSpanRow
        {
            get
            {
                return this._reportspanrow;
            }
            set
            {
                this._reportspanrow = value;
            }
        }

        public string ShowReportName
        {
            get
            {
                return this._showreportname;
            }
            set
            {
                this._showreportname = value;
            }
        }

        public string tabelName
        {
            get
            {
                return this._tabelname;
            }
            set
            {
                this._tabelname = value;
            }
        }

        public string tbtype
        {
            get
            {
                return this._tbtype;
            }
            set
            {
                this._tbtype = value;
            }
        }
    }
}

