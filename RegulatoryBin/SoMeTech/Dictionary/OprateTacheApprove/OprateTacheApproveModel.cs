namespace SoMeTech.Dictionary.OprateTacheApprove
{
    using System;

    public sealed class OprateTacheApproveModel
    {
        private string _approvename;
        private int _approveorder;
        private string _companypk;
        private string _opratetachepk;
        private string _pk;
        private string _remark;

        public string ApproveName
        {
            get
            {
                return this._approvename;
            }
            set
            {
                this._approvename = value;
            }
        }

        public int ApproveOrder
        {
            get
            {
                return this._approveorder;
            }
            set
            {
                this._approveorder = value;
            }
        }

        public string CompanyPK
        {
            get
            {
                return this._companypk;
            }
            set
            {
                this._companypk = value;
            }
        }

        public string OprateTachePK
        {
            get
            {
                return this._opratetachepk;
            }
            set
            {
                this._opratetachepk = value;
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
    }
}

