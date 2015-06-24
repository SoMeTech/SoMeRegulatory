namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class news
    {
        private string _contents;
        private string _newid;
        private string _subjects;
        private DateTime? _sysdate;
        private int? _type;

        public string contents
        {
            get
            {
                return this._contents;
            }
            set
            {
                this._contents = value;
            }
        }

        public string newid
        {
            get
            {
                return this._newid;
            }
            set
            {
                this._newid = value;
            }
        }

        public string subjects
        {
            get
            {
                return this._subjects;
            }
            set
            {
                this._subjects = value;
            }
        }

        public DateTime? sysdate_
        {
            get
            {
                return this._sysdate;
            }
            set
            {
                this._sysdate = value;
            }
        }

        public int? type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
    }
}

