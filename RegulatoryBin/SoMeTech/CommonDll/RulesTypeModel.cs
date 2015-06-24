namespace SoMeTech.CommonDll
{
    using System;

    public class RulesTypeModel
    {
        private int _typeId;
        private string type;

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public int TypeId
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

