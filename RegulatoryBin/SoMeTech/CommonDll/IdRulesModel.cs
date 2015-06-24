namespace SoMeTech.CommonDll
{
    using System;

    public class IdRulesModel
    {
        private string _currentValue;
        private string _endSign;
        private int _id;
        private int _initialValue;
        private int _isRestore;
        private int _paragraphs;
        private int _restoreCycle;
        private int _step;
        private RulesTypeModel _typeId;

        public string CurrentValue
        {
            get
            {
                return this._currentValue;
            }
            set
            {
                this._currentValue = value;
            }
        }

        public string EndSign
        {
            get
            {
                return this._endSign;
            }
            set
            {
                this._endSign = value;
            }
        }

        public int Id
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

        public int InitialValue
        {
            get
            {
                return this._initialValue;
            }
            set
            {
                this._initialValue = value;
            }
        }

        public int IsRestore
        {
            get
            {
                return this._isRestore;
            }
            set
            {
                this._isRestore = value;
            }
        }

        public int Paragraphs
        {
            get
            {
                return this._paragraphs;
            }
            set
            {
                this._paragraphs = value;
            }
        }

        public int RestoreCycle
        {
            get
            {
                return this._restoreCycle;
            }
            set
            {
                this._restoreCycle = value;
            }
        }

        public int Step
        {
            get
            {
                return this._step;
            }
            set
            {
                this._step = value;
            }
        }

        public RulesTypeModel TypeId
        {
            get
            {
                return this._typeId;
            }
            set
            {
                this._typeId = value;
            }
        }
    }
}

