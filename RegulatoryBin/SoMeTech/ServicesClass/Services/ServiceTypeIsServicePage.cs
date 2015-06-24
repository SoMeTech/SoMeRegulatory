namespace SoMeTech.ServicesClass.Services
{
    using System;

    public sealed class ServiceTypeIsServicePage
    {
        public static string GetPageName(ServicesTypeEnum ste)
        {
            string str = "";
            switch (ste)
            {
                case ServicesTypeEnum.Audit:
                    return "CastTaxFeeList.aspx";

                case ServicesTypeEnum.Apply:
                    return "ApprovalPage.aspx";

                case ServicesTypeEnum.Derate:
                    return "DeratePage.aspx";

                case ServicesTypeEnum.Check:
                case ServicesTypeEnum.Invoice:
                case ServicesTypeEnum.Issue:
                case ServicesTypeEnum.Print:
                case ServicesTypeEnum.Out:
                case ServicesTypeEnum.ManyApply:
                    return str;

                case ServicesTypeEnum.DerateApproval:
                    return "DerateApprovalPage.aspx";

                case ServicesTypeEnum.Gathering:
                    return "GatheringList.aspx";

                case ServicesTypeEnum.CastTaxFee:
                    return "CastTaxFeeList.aspx";

                case ServicesTypeEnum.CenterTaxFeeApply:
                    return "CenterApprovalPage.aspx";

                case ServicesTypeEnum.CenterPaperApply:
                    return "CenterApprovalPage.aspx";

                case ServicesTypeEnum.JZJZ:
                    return "JZJZPage.aspx";

                case ServicesTypeEnum.JZJZApply:
                    return "JZJZApprovalPage.aspx";
            }
            return str;
        }

        public static string GetServiceName(ServicesTypeEnum ste)
        {
            string str = "";
            switch (ste)
            {
                case ServicesTypeEnum.Audit:
                    return "审核";

                case ServicesTypeEnum.Apply:
                    return "审批";

                case ServicesTypeEnum.Derate:
                    return "减免";

                case ServicesTypeEnum.Check:
                case ServicesTypeEnum.Invoice:
                case ServicesTypeEnum.Issue:
                case ServicesTypeEnum.Print:
                case ServicesTypeEnum.Out:
                case ServicesTypeEnum.ManyApply:
                    return str;

                case ServicesTypeEnum.DerateApproval:
                    return "减免审批";

                case ServicesTypeEnum.Gathering:
                    return "核销";

                case ServicesTypeEnum.CastTaxFee:
                    return "计算";

                case ServicesTypeEnum.CenterTaxFeeApply:
                    return "中心税费审批";

                case ServicesTypeEnum.CenterPaperApply:
                    return "中心发证审批";

                case ServicesTypeEnum.JZJZ:
                    return "加征减征";

                case ServicesTypeEnum.JZJZApply:
                    return "加征减征审批";
            }
            return str;
        }
    }
}

