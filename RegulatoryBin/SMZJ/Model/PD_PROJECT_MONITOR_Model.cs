namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class PD_PROJECT_MONITOR_Model
    {
        private string _auto_no = "";
        private string _PD_ISGKGS = "";
        private string _pd_monitor_filename = "";
        private string _pd_monitor_filename_system = "";
        private DateTime? _pd_monitor_input_date = new DateTime();
        private int? _pd_monitor_input_month = 0;
        private decimal? _pd_monitor_proceed_wcl = 0;
        private decimal? _pd_monitor_total_money_pay = 0;
        private decimal? _pd_monitor_total_money_wcl = 0;
        private string _pd_project_code = "";
        private decimal? _pd_project_total_money = 0;
        private string _pd_zhiliang = "";

        public string AUTO_NO
        {
            get
            {
                return this._auto_no;
            }
            set
            {
                this._auto_no = value;
            }
        }

        public string PD_ISGKGS
        {
            get
            {
                return this._PD_ISGKGS;
            }
            set
            {
                this._PD_ISGKGS = value;
            }
        }

        public string PD_MONITOR_FILENAME
        {
            get
            {
                return this._pd_monitor_filename;
            }
            set
            {
                this._pd_monitor_filename = value;
            }
        }

        public string PD_MONITOR_FILENAME_SYSTEM
        {
            get
            {
                return this._pd_monitor_filename_system;
            }
            set
            {
                this._pd_monitor_filename_system = value;
            }
        }

        public DateTime? PD_MONITOR_INPUT_DATE
        {
            get
            {
                return this._pd_monitor_input_date;
            }
            set
            {
                this._pd_monitor_input_date = value;
            }
        }

        public int? PD_MONITOR_INPUT_MONTH
        {
            get
            {
                return this._pd_monitor_input_month;
            }
            set
            {
                this._pd_monitor_input_month = value;
            }
        }

        public decimal? PD_MONITOR_PROCEED_WCL
        {
            get
            {
                return this._pd_monitor_proceed_wcl;
            }
            set
            {
                this._pd_monitor_proceed_wcl = value;
            }
        }

        public decimal? PD_MONITOR_TOTAL_MONEY_PAY
        {
            get
            {
                return this._pd_monitor_total_money_pay;
            }
            set
            {
                this._pd_monitor_total_money_pay = value;
            }
        }

        public decimal? PD_MONITOR_TOTAL_MONEY_WCL
        {
            get
            {
                return this._pd_monitor_total_money_wcl;
            }
            set
            {
                this._pd_monitor_total_money_wcl = value;
            }
        }

        public string PD_PROJECT_CODE
        {
            get
            {
                return this._pd_project_code;
            }
            set
            {
                this._pd_project_code = value;
            }
        }

        public decimal? PD_PROJECT_TOTAL_MONEY
        {
            get
            {
                return this._pd_project_total_money;
            }
            set
            {
                this._pd_project_total_money = value;
            }
        }

        public string PD_ZHILIANG
        {
            get
            {
                return this._pd_zhiliang;
            }
            set
            {
                this._pd_zhiliang = value;
            }
        }
    }
}

