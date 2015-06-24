namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class MYFILETEST
    {
        private int? _商品编号;
        private string _商品名称;
        private string _商品小图地址;

        public int? 商品编号
        {
            get
            {
                return this._商品编号;
            }
            set
            {
                this._商品编号 = value;
            }
        }

        public string 商品名称
        {
            get
            {
                return this._商品名称;
            }
            set
            {
                this._商品名称 = value;
            }
        }

        public string 商品小图地址
        {
            get
            {
                return this._商品小图地址;
            }
            set
            {
                this._商品小图地址 = value;
            }
        }
    }
}

