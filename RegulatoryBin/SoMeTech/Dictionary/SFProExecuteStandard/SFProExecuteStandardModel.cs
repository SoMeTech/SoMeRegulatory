namespace SoMeTech.Dictionary.SFProExecuteStandard
{
    using System;

    public sealed class SFProExecuteStandardModel
    {
        private string _buildingpropk;
        private string _countstandardpk;
        private decimal _executestandard;
        private string _pk;
        private string _remark;
        private string _sfprojectpk;

        public string BuildingProPK
        {
            get
            {
                return this._buildingpropk;
            }
            set
            {
                this._buildingpropk = value;
            }
        }

        public string CountStandardPK
        {
            get
            {
                return this._countstandardpk;
            }
            set
            {
                this._countstandardpk = value;
            }
        }

        public decimal ExecuteStandard
        {
            get
            {
                return this._executestandard;
            }
            set
            {
                this._executestandard = value;
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

        public string Remark
        {
            get
            {
                return this._remark;
            }
            set
            {
                this._remark = value;
            }
        }

        public string SFProjectPK
        {
            get
            {
                return this._sfprojectpk;
            }
            set
            {
                this._sfprojectpk = value;
            }
        }
    }
}

