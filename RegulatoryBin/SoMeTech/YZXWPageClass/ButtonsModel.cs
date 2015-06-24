namespace SoMeTech.YZXWPageClass
{
    using System;

    public sealed class ButtonsModel
    {
        private string ibtaddtext;
        private string ibtaddurl;
        private string ibtapplytext;
        private string ibtapplyurl;
        private string ibtaudittext;
        private string ibtauditurl;
        private string ibtdeletetext;
        private string ibtdeleteurl;
        private string ibtderatetext;
        private string ibtderateurl;
        private string ibtdisposetext;
        private string ibtdisposeurl;
        private string ibtdotext;
        private string ibtdourl;
        private string ibtexittext;
        private string ibtexiturl;
        private string ibthuizongtext;
        private string ibthuizongurl;
        private string ibtimpowertext;
        private string ibtimpowerurl;
        private string ibtlooktext;
        private string ibtlookurl;
        private string ibtmoneytext;
        private string ibtmoneyurl;
        private string ibtpapertext;
        private string ibtpaperurl;
        private string ibtprintnotetext;
        private string ibtprintnoteurl;
        private string ibtputouttext;
        private string ibtputouturl;
        private string ibtrefreshtext;
        private string ibtrefreshurl;
        private string ibtrollbacktext;
        private string ibtrollbackurl;
        private string ibtsavetext;
        private string ibtsaveurl;
        private string ibtsearchtext;
        private string ibtsearchurl;
        private string ibtsetbacktext;
        private string ibtsetbackurl;
        private string ibtsettext;
        private string ibtseturl;
        private string ibtupdatetext;
        private string ibtupdateurl;
        private bool ifadd;
        private bool ifapply;
        private bool ifaudit;
        private bool ifdelete;
        private bool ifderate;
        private bool ifdispose;
        private bool ifdo;
        private bool ifexit;
        private bool ifhuizong;
        private bool ifimpower;
        private bool iflook;
        private bool ifmoney;
        private bool ifpaper;
        private bool ifprintnote;
        private bool ifputout;
        private bool ifrefresh;
        private bool ifrollback;
        private bool ifsave;
        private bool ifsearch;
        private bool ifset;
        private bool ifsetback;
        private bool ifupdate;

        public ButtonsModel()
        {
            this.ibtderateurl = "images/new/process.png";
            this.ibtderatetext = "减免";
            this.ibtmoneyurl = "images/new/process.png";
            this.ibtmoneytext = "收款";
            this.ibtauditurl = "images/new/process.png";
            this.ibtaudittext = "审核";
            this.ibtapplyurl = "images/new/process.png";
            this.ibtapplytext = "审批";
            this.ibtdourl = "images/new/process.png";
            this.ibtdotext = "查看";
            this.ibtimpowerurl = "images/new/process.png";
            this.ibtimpowertext = "授权";
            this.ibtpaperurl = "images/new/process.png";
            this.ibtpapertext = "发证";
            this.ibtprintnoteurl = "images/new/shuchu.png";
            this.ibtprintnotetext = "打印票据";
            this.ibtaddurl = "images/new/add.png";
            this.ibtaddtext = "新增";
            this.ibtupdateurl = "images/new/xiugai.png";
            this.ibtupdatetext = "修改";
            this.ibtsaveurl = "images/new/baocun.png";
            this.ibtsavetext = "保存";
            this.ibtdeleteurl = "images/new/delete.png";
            this.ibtdeletetext = "删除";
            this.ibtlookurl = "images/new/chaxun.png";
            this.ibtlooktext = "查看";
            this.ibtsearchurl = "images/new/sousuo.png";
            this.ibtsearchtext = "搜索";
            this.ifrefresh = true;
            this.ibtrefreshurl = "images/new/refresh.png";
            this.ibtrefreshtext = "刷新";
            this.ibthuizongurl = "images/new/huizong.png";
            this.ibthuizongtext = "汇总";
            this.ibtputouturl = "images/new/shuchu.png";
            this.ibtputouttext = "打印";
            this.ibtseturl = "images/new/process.png";
            this.ibtsettext = "设置";
            this.ibtsetbackurl = "images/new/bohui.png";
            this.ibtsetbacktext = "弃审";
            this.ibtrollbackurl = "images/new/bohui.png";
            this.ibtrollbacktext = "退回";
            this.ibtdisposeurl = "images/new/zhuxiao.png";
            this.ibtdisposetext = "注销";
            this.ifexit = true;
            this.ibtexiturl = "images/new/tuichu.png";
            this.ibtexittext = "退出";
        }

        public ButtonsModel(string UserName)
        {
            this.ibtderateurl = "images/new/process.png";
            this.ibtderatetext = "减免";
            this.ibtmoneyurl = "images/new/process.png";
            this.ibtmoneytext = "收款";
            this.ibtauditurl = "images/new/process.png";
            this.ibtaudittext = "审核";
            this.ibtapplyurl = "images/new/process.png";
            this.ibtapplytext = "审批";
            this.ibtdourl = "images/new/process.png";
            this.ibtdotext = "查看";
            this.ibtimpowerurl = "images/new/process.png";
            this.ibtimpowertext = "授权";
            this.ibtpaperurl = "images/new/process.png";
            this.ibtpapertext = "发证";
            this.ibtprintnoteurl = "images/new/shuchu.png";
            this.ibtprintnotetext = "打印票据";
            this.ibtaddurl = "images/new/add.png";
            this.ibtaddtext = "新增";
            this.ibtupdateurl = "images/new/xiugai.png";
            this.ibtupdatetext = "修改";
            this.ibtsaveurl = "images/new/baocun.png";
            this.ibtsavetext = "保存";
            this.ibtdeleteurl = "images/new/delete.png";
            this.ibtdeletetext = "删除";
            this.ibtlookurl = "images/new/chaxun.png";
            this.ibtlooktext = "查看";
            this.ibtsearchurl = "images/new/sousuo.png";
            this.ibtsearchtext = "搜索";
            this.ifrefresh = true;
            this.ibtrefreshurl = "images/new/refresh.png";
            this.ibtrefreshtext = "刷新";
            this.ibthuizongurl = "images/new/huizong.png";
            this.ibthuizongtext = "汇总";
            this.ibtputouturl = "images/new/shuchu.png";
            this.ibtputouttext = "打印";
            this.ibtseturl = "images/new/process.png";
            this.ibtsettext = "设置";
            this.ibtsetbackurl = "images/new/bohui.png";
            this.ibtsetbacktext = "弃审";
            this.ibtrollbackurl = "images/new/bohui.png";
            this.ibtrollbacktext = "退回";
            this.ibtdisposeurl = "images/new/zhuxiao.png";
            this.ibtdisposetext = "注销";
            this.ifexit = true;
            this.ibtexiturl = "images/new/tuichu.png";
            this.ibtexittext = "退出";
            bool flag1 = UserName == "admin";
        }

        public ButtonsModel(string UserName, PageKind pk)
        {
            this.ibtderateurl = "images/new/process.png";
            this.ibtderatetext = "减免";
            this.ibtmoneyurl = "images/new/process.png";
            this.ibtmoneytext = "收款";
            this.ibtauditurl = "images/new/process.png";
            this.ibtaudittext = "审核";
            this.ibtapplyurl = "images/new/process.png";
            this.ibtapplytext = "审批";
            this.ibtdourl = "images/new/process.png";
            this.ibtdotext = "查看";
            this.ibtimpowerurl = "images/new/process.png";
            this.ibtimpowertext = "授权";
            this.ibtpaperurl = "images/new/process.png";
            this.ibtpapertext = "发证";
            this.ibtprintnoteurl = "images/new/shuchu.png";
            this.ibtprintnotetext = "打印票据";
            this.ibtaddurl = "images/new/add.png";
            this.ibtaddtext = "新增";
            this.ibtupdateurl = "images/new/xiugai.png";
            this.ibtupdatetext = "修改";
            this.ibtsaveurl = "images/new/baocun.png";
            this.ibtsavetext = "保存";
            this.ibtdeleteurl = "images/new/delete.png";
            this.ibtdeletetext = "删除";
            this.ibtlookurl = "images/new/chaxun.png";
            this.ibtlooktext = "查看";
            this.ibtsearchurl = "images/new/sousuo.png";
            this.ibtsearchtext = "搜索";
            this.ifrefresh = true;
            this.ibtrefreshurl = "images/new/refresh.png";
            this.ibtrefreshtext = "刷新";
            this.ibthuizongurl = "images/new/huizong.png";
            this.ibthuizongtext = "汇总";
            this.ibtputouturl = "images/new/shuchu.png";
            this.ibtputouttext = "打印";
            this.ibtseturl = "images/new/process.png";
            this.ibtsettext = "设置";
            this.ibtsetbackurl = "images/new/bohui.png";
            this.ibtsetbacktext = "弃审";
            this.ibtrollbackurl = "images/new/bohui.png";
            this.ibtrollbacktext = "退回";
            this.ibtdisposeurl = "images/new/zhuxiao.png";
            this.ibtdisposetext = "注销";
            this.ifexit = true;
            this.ibtexiturl = "images/new/tuichu.png";
            this.ibtexittext = "退出";
            switch (pk)
            {
                case PageKind.Add:
                    this.SetButtonState_Add(UserName);
                    return;

                case PageKind.Update:
                    this.SetButtonState_Update(UserName);
                    return;

                case PageKind.List:
                    this.SetButtonState_List(UserName);
                    return;
            }
        }

        public ButtonsModel(string UserName, PageType pt, PageKind pk)
        {
            this.ibtderateurl = "images/new/process.png";
            this.ibtderatetext = "减免";
            this.ibtmoneyurl = "images/new/process.png";
            this.ibtmoneytext = "收款";
            this.ibtauditurl = "images/new/process.png";
            this.ibtaudittext = "审核";
            this.ibtapplyurl = "images/new/process.png";
            this.ibtapplytext = "审批";
            this.ibtdourl = "images/new/process.png";
            this.ibtdotext = "查看";
            this.ibtimpowerurl = "images/new/process.png";
            this.ibtimpowertext = "授权";
            this.ibtpaperurl = "images/new/process.png";
            this.ibtpapertext = "发证";
            this.ibtprintnoteurl = "images/new/shuchu.png";
            this.ibtprintnotetext = "打印票据";
            this.ibtaddurl = "images/new/add.png";
            this.ibtaddtext = "新增";
            this.ibtupdateurl = "images/new/xiugai.png";
            this.ibtupdatetext = "修改";
            this.ibtsaveurl = "images/new/baocun.png";
            this.ibtsavetext = "保存";
            this.ibtdeleteurl = "images/new/delete.png";
            this.ibtdeletetext = "删除";
            this.ibtlookurl = "images/new/chaxun.png";
            this.ibtlooktext = "查看";
            this.ibtsearchurl = "images/new/sousuo.png";
            this.ibtsearchtext = "搜索";
            this.ifrefresh = true;
            this.ibtrefreshurl = "images/new/refresh.png";
            this.ibtrefreshtext = "刷新";
            this.ibthuizongurl = "images/new/huizong.png";
            this.ibthuizongtext = "汇总";
            this.ibtputouturl = "images/new/shuchu.png";
            this.ibtputouttext = "打印";
            this.ibtseturl = "images/new/process.png";
            this.ibtsettext = "设置";
            this.ibtsetbackurl = "images/new/bohui.png";
            this.ibtsetbacktext = "弃审";
            this.ibtrollbackurl = "images/new/bohui.png";
            this.ibtrollbacktext = "退回";
            this.ibtdisposeurl = "images/new/zhuxiao.png";
            this.ibtdisposetext = "注销";
            this.ifexit = true;
            this.ibtexiturl = "images/new/tuichu.png";
            this.ibtexittext = "退出";
            if (UserName == "admin")
            {
                this.ifadd = true;
                this.ifupdate = true;
                this.ifdelete = true;
                this.ifrefresh = true;
                this.ifexit = true;
            }
            else
            {
                this.SetButtonState_People(pt, pk);
            }
        }

        private void SetButtonState_Add(string UserName)
        {
            if (UserName == "admin")
            {
                this.ifadd = true;
            }
            this.ifupdate = false;
            this.ifexit = true;
        }

        private void SetButtonState_Admin(PageType pt, PageKind pk)
        {
        }

        private void SetButtonState_List(string UserName)
        {
            if (UserName == "admin")
            {
                this.ifadd = true;
                this.ifupdate = true;
                this.ifdelete = true;
                this.ifputout = true;
            }
            this.iflook = true;
        }

        private void SetButtonState_Main(PageKind pk)
        {
        }

        private void SetButtonState_Open(PageKind pk)
        {
            this.SetButtonState_Add("");
        }

        private void SetButtonState_People(PageType pt, PageKind pk)
        {
            this.SetButtonState_Open(pk);
        }

        private void SetButtonState_Update(string UserName)
        {
            if (UserName == "admin")
            {
                this.ifupdate = true;
            }
            this.ifadd = false;
            this.ifexit = true;
        }

        public string IbtAddText
        {
            get
            {
                return this.ibtaddtext;
            }
            set
            {
                this.ibtaddtext = value;
            }
        }

        public string IbtAddUrl
        {
            get
            {
                return this.ibtaddurl;
            }
            set
            {
                this.ibtaddurl = value;
            }
        }

        public string IbtApplyText
        {
            get
            {
                return this.ibtapplytext;
            }
            set
            {
                this.ibtapplytext = value;
            }
        }

        public string IbtApplyUrl
        {
            get
            {
                return this.ibtapplyurl;
            }
            set
            {
                this.ibtapplyurl = value;
            }
        }

        public string IbtAuditText
        {
            get
            {
                return this.ibtaudittext;
            }
            set
            {
                this.ibtaudittext = value;
            }
        }

        public string IbtAuditUrl
        {
            get
            {
                return this.ibtauditurl;
            }
            set
            {
                this.ibtauditurl = value;
            }
        }

        public string IbtDeleteText
        {
            get
            {
                return this.ibtdeletetext;
            }
            set
            {
                this.ibtdeletetext = value;
            }
        }

        public string IbtDeleteUrl
        {
            get
            {
                return this.ibtdeleteurl;
            }
            set
            {
                this.ibtdeleteurl = value;
            }
        }

        public string IbtDerateText
        {
            get
            {
                return this.ibtderatetext;
            }
            set
            {
                this.ibtderatetext = value;
            }
        }

        public string IbtDerateUrl
        {
            get
            {
                return this.ibtderateurl;
            }
            set
            {
                this.ibtderateurl = value;
            }
        }

        public string IbtDisposeText
        {
            get
            {
                return this.ibtdisposetext;
            }
            set
            {
                this.ibtdisposetext = value;
            }
        }

        public string IbtDisposeUrl
        {
            get
            {
                return this.ibtdisposeurl;
            }
            set
            {
                this.ibtdisposeurl = value;
            }
        }

        public string IbtDoText
        {
            get
            {
                return this.ibtdotext;
            }
            set
            {
                this.ibtdotext = value;
            }
        }

        public string IbtDoUrl
        {
            get
            {
                return this.ibtdourl;
            }
            set
            {
                this.ibtdourl = value;
            }
        }

        public string IbtExitText
        {
            get
            {
                return this.ibtexittext;
            }
            set
            {
                this.ibtexittext = value;
            }
        }

        public string IbtExitUrl
        {
            get
            {
                return this.ibtexiturl;
            }
            set
            {
                this.ibtexiturl = value;
            }
        }

        public string IbtHuiZongText
        {
            get
            {
                return this.ibthuizongtext;
            }
            set
            {
                this.ibthuizongtext = value;
            }
        }

        public string IbtHuiZongUrl
        {
            get
            {
                return this.ibthuizongurl;
            }
            set
            {
                this.ibthuizongurl = value;
            }
        }

        public string IbtImpowerText
        {
            get
            {
                return this.ibtimpowertext;
            }
            set
            {
                this.ibtimpowertext = value;
            }
        }

        public string IbtImpowerUrl
        {
            get
            {
                return this.ibtimpowerurl;
            }
            set
            {
                this.ibtimpowerurl = value;
            }
        }

        public string IbtLookText
        {
            get
            {
                return this.ibtlooktext;
            }
            set
            {
                this.ibtlooktext = value;
            }
        }

        public string IbtLookUrl
        {
            get
            {
                return this.ibtlookurl;
            }
            set
            {
                this.ibtlookurl = value;
            }
        }

        public string IbtMoneyText
        {
            get
            {
                return this.ibtmoneytext;
            }
            set
            {
                this.ibtmoneytext = value;
            }
        }

        public string IbtMoneyUrl
        {
            get
            {
                return this.ibtmoneyurl;
            }
            set
            {
                this.ibtmoneyurl = value;
            }
        }

        public string IbtPaperText
        {
            get
            {
                return this.ibtpapertext;
            }
            set
            {
                this.ibtpapertext = value;
            }
        }

        public string IbtPaperUrl
        {
            get
            {
                return this.ibtpaperurl;
            }
            set
            {
                this.ibtpaperurl = value;
            }
        }

        public string IbtPrintNoteText
        {
            get
            {
                return this.ibtprintnotetext;
            }
            set
            {
                this.ibtprintnotetext = value;
            }
        }

        public string IbtPrintNoteUrl
        {
            get
            {
                return this.ibtprintnoteurl;
            }
            set
            {
                this.ibtprintnoteurl = value;
            }
        }

        public string IbtPutOutText
        {
            get
            {
                return this.ibtputouttext;
            }
            set
            {
                this.ibtputouttext = value;
            }
        }

        public string IbtPutOutUrl
        {
            get
            {
                return this.ibtputouturl;
            }
            set
            {
                this.ibtputouturl = value;
            }
        }

        public string IbtRefreshText
        {
            get
            {
                return this.ibtrefreshtext;
            }
            set
            {
                this.ibtrefreshtext = value;
            }
        }

        public string IbtRefreshUrl
        {
            get
            {
                return this.ibtrefreshurl;
            }
            set
            {
                this.ibtrefreshurl = value;
            }
        }

        public string IbtRollBackText
        {
            get
            {
                return this.ibtrollbacktext;
            }
            set
            {
                this.ibtrollbacktext = value;
            }
        }

        public string IbtRollBackUrl
        {
            get
            {
                return this.ibtrollbackurl;
            }
            set
            {
                this.ibtrollbackurl = value;
            }
        }

        public string IbtSaveText
        {
            get
            {
                return this.ibtsavetext;
            }
            set
            {
                this.ibtsavetext = value;
            }
        }

        public string IbtSaveUrl
        {
            get
            {
                return this.ibtsaveurl;
            }
            set
            {
                this.ibtsaveurl = value;
            }
        }

        public string IbtSearchText
        {
            get
            {
                return this.ibtsearchtext;
            }
            set
            {
                this.ibtsearchtext = value;
            }
        }

        public string IbtSearchUrl
        {
            get
            {
                return this.ibtsearchurl;
            }
            set
            {
                this.ibtsearchurl = value;
            }
        }

        public string IbtSetBackText
        {
            get
            {
                return this.ibtsetbacktext;
            }
            set
            {
                this.ibtsetbacktext = value;
            }
        }

        public string IbtSetBackUrl
        {
            get
            {
                return this.ibtsetbackurl;
            }
            set
            {
                this.ibtsetbackurl = value;
            }
        }

        public string IbtSetText
        {
            get
            {
                return this.ibtsettext;
            }
            set
            {
                this.ibtsettext = value;
            }
        }

        public string IbtSetUrl
        {
            get
            {
                return this.ibtseturl;
            }
            set
            {
                this.ibtseturl = value;
            }
        }

        public string IbtUpdateText
        {
            get
            {
                return this.ibtupdatetext;
            }
            set
            {
                this.ibtupdatetext = value;
            }
        }

        public string IbtUpdateUrl
        {
            get
            {
                return this.ibtupdateurl;
            }
            set
            {
                this.ibtupdateurl = value;
            }
        }

        public bool IfAdd
        {
            get
            {
                return this.ifadd;
            }
            set
            {
                this.ifadd = value;
            }
        }

        public bool IfApply
        {
            get
            {
                return this.ifapply;
            }
            set
            {
                this.ifapply = value;
            }
        }

        public bool IfAudit
        {
            get
            {
                return this.ifaudit;
            }
            set
            {
                this.ifaudit = value;
            }
        }

        public bool IfDelete
        {
            get
            {
                return this.ifdelete;
            }
            set
            {
                this.ifdelete = value;
            }
        }

        public bool IfDerate
        {
            get
            {
                return this.ifderate;
            }
            set
            {
                this.ifderate = value;
            }
        }

        public bool IfDispose
        {
            get
            {
                return this.ifdispose;
            }
            set
            {
                this.ifdispose = value;
            }
        }

        public bool IfDo
        {
            get
            {
                return this.ifdo;
            }
            set
            {
                this.ifdo = value;
            }
        }

        public bool IfExit
        {
            get
            {
                return this.ifexit;
            }
            set
            {
                this.ifexit = value;
            }
        }

        public bool IfHuiZong
        {
            get
            {
                return this.ifhuizong;
            }
            set
            {
                this.ifhuizong = value;
            }
        }

        public bool IfImpower
        {
            get
            {
                return this.ifimpower;
            }
            set
            {
                this.ifimpower = value;
            }
        }

        public bool IfLook
        {
            get
            {
                return this.iflook;
            }
            set
            {
                this.iflook = value;
            }
        }

        public bool IfMoney
        {
            get
            {
                return this.ifmoney;
            }
            set
            {
                this.ifmoney = value;
            }
        }

        public bool IfPaper
        {
            get
            {
                return this.ifpaper;
            }
            set
            {
                this.ifpaper = value;
            }
        }

        public bool IfPrintNote
        {
            get
            {
                return this.ifprintnote;
            }
            set
            {
                this.ifprintnote = value;
            }
        }

        public bool IfPutOut
        {
            get
            {
                return this.ifputout;
            }
            set
            {
                this.ifputout = value;
            }
        }

        public bool IfRefresh
        {
            get
            {
                return this.ifrefresh;
            }
            set
            {
                this.ifrefresh = value;
            }
        }

        public bool IfRollBack
        {
            get
            {
                return this.ifrollback;
            }
            set
            {
                this.ifrollback = value;
            }
        }

        public bool IfSave
        {
            get
            {
                return this.ifsave;
            }
            set
            {
                this.ifsave = value;
            }
        }

        public bool IfSearch
        {
            get
            {
                return this.ifsearch;
            }
            set
            {
                this.ifsearch = value;
            }
        }

        public bool IfSet
        {
            get
            {
                return this.ifset;
            }
            set
            {
                this.ifset = value;
            }
        }

        public bool IfSetBack
        {
            get
            {
                return this.ifsetback;
            }
            set
            {
                this.ifsetback = value;
            }
        }

        public bool IfUpdate
        {
            get
            {
                return this.ifupdate;
            }
            set
            {
                this.ifupdate = value;
            }
        }
    }
}

