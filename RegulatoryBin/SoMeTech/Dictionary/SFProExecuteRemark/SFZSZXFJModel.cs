namespace SoMeTech.Dictionary.SFProExecuteRemark
{
    using System;

    public sealed class SFZSZXFJModel
    {
        private string _discription;
        private string _executestandardpk;
        private int _exemax;
        private int _exemin;
        private string _pk;
        private string _termname;
        private int _termvalue;

        public string DISCRIPTION
        {
            get
            {
                return this._discription;
            }
            set
            {
                this._discription = value;
            }
        }

        public string EXECUTESTANDARDPK
        {
            get
            {
                return this._executestandardpk;
            }
            set
            {
                this._executestandardpk = value;
            }
        }

        public int EXEMAX
        {
            get
            {
                return this._exemax;
            }
            set
            {
                this._exemax = value;
            }
        }

        public int EXEMIN
        {
            get
            {
                return this._exemin;
            }
            set
            {
                this._exemin = value;
            }
        }

        public string PK
        {
            get
            {
                return this._pk;
            }
            set
            {
                this._pk = value;
            }
        }

        public string TERMNAME
        {
            get
            {
                return this._termname;
            }
            set
            {
                this._termname = value;
            }
        }

        public int TERMVALUE
        {
            get
            {
                return this._termvalue;
            }
            set
            {
                this._termvalue = value;
            }
        }
    }
}

