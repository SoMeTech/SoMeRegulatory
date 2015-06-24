using ASP;
using ExceptionLog;
using SoMeTech.CommonDll;
using SoMeTech.DataAccess;
using SoMeTech.User;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public class Shared_DiagList_GetSession : Page, IRequiresSessionState
{
    private DB_OPT dbo;
    private ExceptionLog.ExceptionLog el;
    protected HtmlForm form1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (base.Request.QueryString["tn"] != null)
        {
            UsualBookTable table = new UsualBookTable();
            string str = base.Request.QueryString["tn"];
            try
            {
                string companyPower;
                string str6;
                this.dbo = new DB_OPT();
                this.dbo.Open();
                switch (str)
                {
                    case "ContractName":
                        {
                            table.PageTitle = "合同信息参照";
                            table.TableName = "PD_Project_Contract";
                            table.Columns = "PD_Contract_No as PK,PD_CONTRACT_NAME as 合同名称,'','','',''";
                            UserModel model = new UserDal
                            {
                                UserName = base.Request.QueryString["UsersPK"]
                            };
                            model.GetModel(this.dbo);
                            companyPower = model.CompanyPower;
                            goto Label_3001;
                        }
                    case "SubjectKind":
                        table.PageTitle = "项目类别参照";
                        table.TableName = "SubjectKind";
                        table.Columns = "PK as PK,Name as 项目类别,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        table.Grade = 1;
                        goto Label_30B8;

                    case "Custom":
                        table.PageTitle = "客户参照";
                        table.TableName = "Custom";
                        table.Columns = "CusPK as PK,CustomName as 客户名称,City as 城市,Address as 地址,0,'',0,''";
                        goto Label_30B8;

                    case "Linkman":
                        if ((base.Request.QueryString["cuspk"] != null) && (base.Request.QueryString["cuspk"] != ""))
                        {
                            table.StrWhere = "CusPK='" + base.Request.QueryString["cuspk"].ToString() + "'";
                        }
                        table.PageTitle = "联系人参照";
                        table.TableName = "Linkman";
                        table.Columns = "LMPK as PK,Name as 联系人名称,Sex as 性别,Age as 年龄,OfficePhone as 办公电话,0,'',0,''";
                        goto Label_30B8;

                    case "Employee":
                        table.PageTitle = "员工参照";
                        table.TableName = "DB_Employee";
                        table.Columns = " EmployeePK as PK,Name as 员工名称,Grade as 等级,FatherPK,IsHasBaby,PKPath ";
                        if ((base.Request.QueryString["pk_corp"] != null) && (base.Request.QueryString["pk_corp"] != ""))
                        {
                            table.StrWhere = " pk_corp='" + base.Request.QueryString["pk_corp"].ToString() + "'";
                        }
                        table.Grade = 0;
                        goto Label_30B8;

                    case "ContratKind":
                        table.PageTitle = "合同类别参照";
                        table.TableName = "ContratKind";
                        table.Columns = "PK as PK,Name as 合同类别,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        table.Grade = 1;
                        goto Label_30B8;

                    case "ContractsMessage":
                        table.PageTitle = "合同信息参照";
                        table.TableName = "pd_project_contract";
                        table.Columns = "pd_contract_no as PK,pd_contract_name as 合同名称,pd_contract_company||','||pd_contract_moeny,0,'',0,''";
                        table.StrWhere = " pd_project_code='" + base.Request.QueryString["project_code"].ToString() + "' and PD_CONTRACT_TYPE='" + base.Request["CONTRACTTYPE"].Trim() + "'";
                        goto Label_30B8;

                    case "Subject":
                        if ((base.Request.QueryString["cuspk"] != null) && (base.Request.QueryString["cuspk"] != ""))
                        {
                            table.StrWhere = "ContratPK='" + base.Request.QueryString["cuspk"].ToString() + "'";
                        }
                        table.PageTitle = "合同主信息参照";
                        table.TableName = "Subject";
                        table.Columns = "SubPK as PK,ReduceName as 项目名称,0,'',0,''";
                        goto Label_30B8;

                    case "Product":
                        table.PageTitle = "物品信息参照";
                        table.TableName = "Product";
                        table.Columns = "ProPK as PK,ProductName as 物品名称,0,'',0,''";
                        goto Label_30B8;

                    case "ContratPayItem":
                        table.PageTitle = "佣金支付条款参照";
                        table.TableName = "ContratPayItem";
                        table.Columns = "ItemPK as PK,Content as 合同名称,0,'',0,''";
                        goto Label_30B8;

                    case "Branch":
                        table.PageTitle = "部门参照";
                        table.TableName = "DB_Branch";
                        table.Columns = "BranchPK as PK,Name as 部门名称,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        if ((base.Request.QueryString["pk_corp"] != null) && (base.Request.QueryString["pk_corp"] != ""))
                        {
                            table.StrWhere = "pk_corp='" + base.Request.QueryString["pk_corp"].ToString() + "'";
                        }
                        table.Grade = 0;
                        goto Label_30B8;

                    case "Menu":
                        table.PageTitle = "菜单信息参照";
                        table.TableName = "DB_Menu";
                        table.Columns = "MemuPK as PK,MenuName as 菜单名称,Grade as 等级, FatherPK, IsHasBaby,''";
                        table.Grade = 0;
                        goto Label_30B8;

                    case "Branch_BH":
                        table.PageTitle = "部门参照";
                        table.TableName = "DB_Branch";
                        table.Columns = "BH as PK,Name as 部门名称,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        if ((base.Request.QueryString["pk_corp"] != null) && (base.Request.QueryString["pk_corp"] != ""))
                        {
                            table.StrWhere = "pk_corp='" + base.Request.QueryString["pk_corp"].ToString() + "'";
                        }
                        table.Grade = 0;
                        goto Label_30B8;

                    case "Role":
                        table.PageTitle = "角色参照";
                        table.TableName = "DB_Role";
                        table.Columns = "RolePK as PK,Name as 角色名称,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        table.Grade = 0;
                        table.StrWhere = table.StrWhere + " 1=1 ";
                        if ((base.Request.QueryString["pk_corp"] != null) && (base.Request.QueryString["pk_corp"] != ""))
                        {
                            table.StrWhere = table.StrWhere + " and pk_corp='" + base.Request.QueryString["pk_corp"].ToString() + "'";
                        }
                        if ((base.Request.QueryString["branchpk"] != null) && (base.Request.QueryString["branchpk"] != ""))
                        {
                            table.StrWhere = table.StrWhere + " and BranchPK='" + base.Request.QueryString["branchpk"].ToString() + "'";
                        }
                        goto Label_30B8;

                    case "CustomKind":
                        table.PageTitle = "客户类别参照";
                        table.TableName = "CustomKind";
                        table.Columns = "PK as PK,Name as 客户类别,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        table.Grade = 1;
                        goto Label_30B8;

                    case "PayType":
                        table.PageTitle = "付款方式参照";
                        table.TableName = "PayType";
                        table.Columns = "PK as PK,Name as 付款方式,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        table.Grade = 1;
                        goto Label_30B8;

                    case "ContratPickUp":
                        table.PageTitle = "合同提成参照";
                        table.TableName = "ContratPickUp";
                        table.Columns = "PUPK as PK,Content as 提成内容,0,'',0,''";
                        goto Label_30B8;

                    case "HeTongBH":
                        table.PageTitle = "合同编号参照";
                        table.TableName = "PD_PROJECT_CONTRACT";
                        table.StrWhere = "trim(PD_PROJECT_CODE)='" + base.Request["PD_PROJECT_CODE"].Trim() + "'";
                        table.Columns = "PD_CONTRACT_NO as PK,PD_CONTRACT_NO||' '||PD_CONTRACT_NAME 合同编号与名称,PD_CONTRACT_MOENY_CHANGE||'~'||PD_CONTRACT_NAME,'',0,''";
                        goto Label_30B8;

                    case "XiangZhen":
                        {
                            table.PageTitle = "单位信息参照";
                            table.TableName = "DB_Company";
                            table.Columns = "pk_corp as PK,Name as 单位名称,0,'',0,''";
                            table.StrWhere = " ZXBJ!=1 ";
                            if ((base.Request.QueryString["UsersPk"] == null) || !(base.Server.UrlDecode(base.Request.QueryString["UsersPK"]).Trim() != ""))
                            {
                                goto Label_30B8;
                            }
                            companyPower = "";
                            if (HttpContext.Current.Session["User"] != null)
                            {
                                goto Label_2FDD;
                            }
                            UserModel model2 = new UserDal
                            {
                                UserName = base.Request.QueryString["UsersPK"]
                            };
                            model2.GetModel(this.dbo);
                            companyPower = model2.CompanyPower;
                            goto Label_3001;
                        }
                    case "Users":
                        {
                            table.PageTitle = "单位信息参照";
                            table.TableName = "DB_Company";
                            table.Columns = "pk_corp as PK,Name as 单位名称,0,'',0,''";
                            if ((base.Request.QueryString["UsersPk"] == null) || !(base.Server.UrlDecode(base.Request.QueryString["UsersPK"]).Trim() != ""))
                            {
                                goto Label_30B8;
                            }
                            companyPower = "";
                            if (HttpContext.Current.Session["User"] != null)
                            {
                                goto Label_2FDD;
                            }
                            UserModel model3 = new UserDal
                            {
                                UserName = base.Request.QueryString["UsersPK"]
                            };
                            model3.GetModel(this.dbo);
                            companyPower = model3.CompanyPower;
                            goto Label_3001;
                        }
                    case "company":
                        table.PageTitle = "单位信息参照";
                        table.TableName = "DB_company";
                        table.Columns = "pk_corp as PK,Name as 单位名称,0,'',0,''";
                        goto Label_30B8;

                    case "Company":
                        table.PageTitle = "单位信息参照";
                        table.TableName = "DB_Company";
                        table.Columns = "pk_corp as PK,Name as 单位名称,Grade as 等级, FatherPK, IsHasBaby,''";
                        table.Grade = 0;
                        goto Label_30B8;

                    case "proj_pfwh":
                        {
                            string str3 = base.Request["proj"];
                            table.PageTitle = "上级指标文号参照";
                            table.TableName = "tb_quota";
                            if ((base.Request["loop"] != null) && (base.Request["loop"] == "1"))
                            {
                                table.StrWhere = " pd_project_code='" + str3 + "'";
                            }
                            table.Columns = " pd_quota_code as PK,pd_quota_code||' '||pd_quota_name as pfwh,'','',''";
                            goto Label_30B8;
                        }
                    case "proj_bzwh":
                        table.PageTitle = "上级指标文号参照";
                        table.TableName = "open_pd_quota";
                        table.StrWhere = " 1=1 ";
                        if (base.Request.Params["xz"] != null)
                        {
                            table.StrWhere = table.StrWhere + " and PD_QUOTA_ZJXZ='" + base.Request.Params["xz"].Trim() + "'";
                        }
                        table.Columns = " pd_quota_zbwh as PK,ShowText as 指标文号,pd_up_money,'',''";
                        goto Label_30B8;

                    case "ProjectBXK":
                        {
                            UserModel model4 = (UserModel)this.Session["User"];
                            table.PageTitle = "项目备选库";
                            table.TableName = "v_selectProjectCS";
                            table.StrWhere = " 1=1 ";
                            if (base.Request.Params["xz"] != null)
                            {
                                table.StrWhere = table.StrWhere + " and trim(PD_FOUND_XZ)='" + base.Request["xz"].Trim() + "'";
                            }
                            table.StrWhere = table.StrWhere + " and trim(pk_corp)='" + model4.Company.pk_corp.Trim() + "'";
                            table.StrWhere = table.StrWhere + " and trim(bh)='" + model4.Branch.BH.Trim() + "'";
                            table.StrWhere = table.StrWhere + " and pd_project_isbxk=1";
                            table.Columns = " pd_project_code as PK,pd_project_name as 项目名称,'','','' ";
                            goto Label_30B8;
                        }
                    case "open_pd_quotaAddMoney":
                        {
                            UserModel model5 = (UserModel)this.Session["User"];
                            table.PageTitle = "上级指标文号参照";
                            table.TableName = "open_pd_quotaAddMoney";
                            table.StrWhere = " if_show=1 ";
                            if (base.Request.Params["xz"] != null)
                            {
                                table.StrWhere = table.StrWhere + " and PD_QUOTA_ZJXZ='" + base.Request.Params["xz"].Trim() + "'";
                            }
                            if (base.Request["company_code"] != null)
                            {
                                table.StrWhere = table.StrWhere + " and trim(company_code)='" + model5.Company.pk_corp.Trim() + "'";
                            }
                            table.Columns = " pd_quota_code as PK,ShowText as 指标文号,pd_up_money||'~'||PD_QUOTA_DEPART||'~'||PD_QUOTA_DEPART_NAME||'~'||PD_QUOTA_BASIS_JG||'~'||PD_QUOTA_ZJLY||'~'||PD_QUOTA_ZGKJ,'',''";
                            goto Label_30B8;
                        }
                    case "pd_DuoZhiBiao":
                        break;

                    case "ZhiBiaoJYK":
                        table.PageTitle = "上级指标文号参照";
                        table.TableName = "v_quota_JieYuZB";
                        table.StrWhere = " PD_QUOTA_MONEY_TOTAL-sumPD_QUOTA_ZBXDZH>0 and trim(pd_quota_input_depart)='" + base.Request.Params["branch"].Trim() + "'";
                        table.Columns = " Minpd_quota_code as PK,PD_QUOTA_ZBWH as 指标文号,PD_QUOTA_MONEY_TOTAL||'~'||sumPD_QUOTA_ZBXDZH||'~'||pd_quota_pici,'',''";
                        goto Label_30B8;

                    case "proj_bianma":
                        table.PageTitle = "项目参照";
                        table.TableName = "V_PROJECTADDQUOTA";
                        table.Columns = "pd_project_code as PK,pd_project_name||'-'||村名 as 项目名称,pd_project_gnfl||','||pd_project_jjfl||','||PD_PROJECT_MONEY_TOTAL||','||PD_QUOTA_JJLX||','||PD_QUOTA_GLLX,0,'',0,''";
                        table.StrWhere = " 1=1 ";
                        if (base.Request.Params["year"] != null)
                        {
                            string strWhere = table.StrWhere;
                            table.StrWhere = strWhere + " and pd_year=" + base.Request["year"].Trim() + " and pd_project_input_company=" + ((UserModel)this.Session["user"]).Company.pk_corp;
                        }
                        if (base.Request.Params["pd_found_xz"] != null)
                        {
                            table.StrWhere = table.StrWhere + " and pd_found_xz='" + base.Request["pd_found_xz"].Trim() + "'";
                        }
                        table.StrWhere = table.StrWhere + " and nvl(PD_PROJECT_ISBXK,0)=0 ";
                        goto Label_30B8;

                    case "proj_bianma3":
                        {
                            UserModel model7 = (UserModel)this.Session["User"];
                            string str4 = "1=0";
                            if (model7 != null)
                            {
                                str4 = base.Request.QueryString["tn"];
                            }
                            str4 = ("trim(pd_project_input_company)='" + model7.Company.pk_corp.Trim() + "'") + " and PD_FOUND_XZ='" + base.Request["PD_FOUND_XZ"] + "' and nvl(PD_PROJECT_ISBXK,0)=0 ";
                            table.PageTitle = "项目参照";
                            table.TableName = "v_tb_project_PD_FOUND_OUT";
                            table.StrWhere = str4;
                            table.Columns = "pd_project_code as PK,pd_project_name as 项目名称,PD_PROJECT_MONEY_TOTAL||','||PD_PROJECT_MONEY_CZ_TOTAL,0,'',0,''";
                            goto Label_30B8;
                        }
                    case "proj_bianma2":
                        {
                            UserModel model8 = (UserModel)this.Session["User"];
                            string str5 = "1=0";
                            if (model8 != null)
                            {
                                str5 = "trim(pd_project_input_company)='" + model8.Company.pk_corp.Trim() + "'";
                            }
                            string str9 = str5;
                            str5 = str9 + " and pd_year=" + base.Request["pd_year"] + " and PD_FOUND_XZ='" + base.Request["ProjectType"] + "' and nvl(PD_PROJECT_ISBXK,0)=0 ";
                            table.PageTitle = "项目参照";
                            table.TableName = "v_tb_project_PD_FOUND_OUT";
                            table.StrWhere = str5;
                            table.Columns = "pd_project_code as PK,pd_project_name||'-'||村名 as 项目名称,PD_PROJECT_MONEY_TOTAL||','||PD_PROJECT_MONEY_CZ_TOTAL,0,'',0,''";
                            goto Label_30B8;
                        }
                    case "proj_bianma1":
                        table.PageTitle = "项目参照";
                        table.TableName = "tb_project";
                        str6 = "";
                        table.Columns = "pd_project_code as PK,pd_project_name as 项目名称,pd_project_gnfl||','||pd_project_jjfl,0,'',0,''";
                        if (!(((UserModel)this.Session["user"]).Company.IsHasBaby == "1"))
                        {
                            goto Label_1813;
                        }
                        str6 = " pd_year=" + base.Request.Params["year"].Trim() + " and pd_project_input_company in(select pk_corp from db_company where fatherpk='" + ((UserModel)this.Session["user"]).Company.pk_corp + "')";
                        goto Label_1880;

                    case "PublicReport":
                        table.PageTitle = "参照";
                        table.TableName = base.Request["tb"];
                        table.Columns = base.Request["column"] + ",'','','',''";
                        table.StrWhere = base.Request["where"].Replace('"', '\'');
                        goto Label_30B8;

                    case "GoodsKind":
                        table.PageTitle = "物品类别参照";
                        table.TableName = "GoodsKind";
                        table.Columns = "PK as PK,Name as 物品类别,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        table.Grade = 1;
                        goto Label_30B8;

                    case "GOV_TC_DB_YWLB":
                        table.PageTitle = "业务类别参照";
                        table.TableName = "GOV_TC_DB_YWLB";
                        table.Columns = "PK as PK,Name as 业务类别,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        table.Grade = 1;
                        table.ShowSelect = 1;
                        if (base.Request.QueryString["YWBH"] != null)
                        {
                            table.StrWhere = "PKPath like '%" + base.Request.QueryString["YWBH"].ToString() + "%' and StartSign='1'";
                        }
                        goto Label_30B8;

                    case "gov_tc_db_ywlb":
                        table.PageTitle = "业务类别参照";
                        table.TableName = "GOV_TC_DB_YWLB";
                        table.Columns = "PK as PK,Name as 业务类别,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        table.Grade = 1;
                        goto Label_30B8;


                    case "GOV_TC_DB_ServicesRegister":
                        table.PageTitle = "系统注册服务参照";
                        table.TableName = "GOV_TC_DB_ServicesRegister";
                        table.Columns = "PK as PK,Name as 注册服务名称,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        table.StrWhere = "StartSign='1'";
                        table.Grade = 0;
                        if (base.Request.QueryString["showselect"] != null)
                        {
                            table.ShowSelect = int.Parse(base.Request.QueryString["showselect"].ToString());
                        }
                        goto Label_30B8;

                    case "GOV_TC_DB_ServicesMess_nbgl":
                        table.PageTitle = "系统已配置的服务参照";
                        table.TableName = "GOV_TC_DB_ServicesMess";
                        table.Columns = "PK as PK,Name as 配置服务名称,0,'',0,''";
                        if (base.Request.QueryString["pk_corp"] != null)
                        {
                            table.StrWhere = table.StrWhere + "CompanyPK='" + base.Request.QueryString["pk_corp"].ToString() + "'";
                            table.StrWhere = table.StrWhere + " and patindex('%|'||rtrim(ServiceTypePK)||'|%','|6|12|13|')>0";
                        }
                        goto Label_30B8;

                    case "GOV_TC_DB_ServicesMess_jzjznbgl":
                        table.PageTitle = "系统已配置的服务参照";
                        table.TableName = "GOV_TC_DB_ServicesMess";
                        table.Columns = "PK as PK,Name as 配置服务名称,0,'',0,''";
                        if (base.Request.QueryString["pk_corp"] != null)
                        {
                            table.StrWhere = table.StrWhere + "CompanyPK='" + base.Request.QueryString["pk_corp"].ToString() + "'";
                            table.StrWhere = table.StrWhere + " and patindex('%|'||rtrim(ServiceTypePK)||'|%','|18|19|13|')>0";
                        }
                        goto Label_30B8;

                    case "GOV_TC_DB_ServicesMess":
                        table.PageTitle = "系统已配置的服务参照";
                        table.TableName = "GOV_TC_DB_ServicesMess";
                        table.Columns = "PK as PK,Name as 配置服务名称,0,'',0,''";
                        if (base.Request.QueryString["pk_corp"] != null)
                        {
                            table.StrWhere = table.StrWhere + "CompanyPK='" + base.Request.QueryString["pk_corp"].ToString() + "'";
                            if (base.Request.QueryString["servicetype"] != null)
                            {
                                table.StrWhere = table.StrWhere + " and ServiceTypePK='" + base.Request.QueryString["servicetype"].ToString() + "'";
                            }
                        }
                        goto Label_30B8;



                    case "GOV_TC_DB_UNITTYPE":
                        table.PageTitle = "计算单位类型";
                        table.TableName = "GOV_TC_DB_UNITTYPE";
                        table.Columns = "PK as PK,Name as 计算单位类型,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        table.Grade = 1;
                        goto Label_30B8;

                    case "GOV_TC_DB_FKFS":
                        table.PageTitle = "付款方式参照";
                        table.TableName = "GOV_TC_DB_FKFS";
                        table.Columns = "PK as PK,Name as 单位类别,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        table.Grade = 1;
                        goto Label_30B8;


                  

                    case "GOV_TC_DB_TaxFeeKind_PK":
                        table.PageTitle = "模块权限参照";
                        table.TableName = "GOV_TC_DB_TaxFeeKind";
                        table.Columns = "PK as PK,Name as 税费类别,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        table.Grade = 0;
                        goto Label_30B8;

                    case "GOV_TC_DB_TaxFeeKind":
                        table.PageTitle = "税费类别参照";
                        table.TableName = "GOV_TC_DB_TaxFeeKind";
                        table.Columns = "BH as 编号,Name as 税费类别,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        goto Label_30B8;

                    case "gov_tc_db_ServicesType":
                        table.PageTitle = "服务类型参照";
                        table.TableName = "gov_tc_db_ServicesType";
                        table.Columns = "BH as PK,Name as 服务类型,0,'',0,''";
                        goto Label_30B8;

                    case "GOV_TC_DB_PapersInfo":
                        table.PageTitle = "证件档案参照";
                        table.TableName = "GOV_TC_DB_PapersInfo";
                        table.Columns = "PK as PK,Name as 证件名称,0,'',0,''";
                        goto Label_30B8;

                    case "GOV_TC_DB_Metering":
                        table.PageTitle = "计量计价类别参照";
                        table.TableName = "GOV_TC_DB_Metering";
                        table.Columns = "PK as PK,Name as 计量计价名称,0,'',0,''";
                        if ((base.Request["PARALLELISMTABLE"] != null) && (base.Request["PARALLELISMTABLE"].ToString() != ""))
                        {
                            table.StrWhere = "PARALLELISMTABLE='" + base.Request["PARALLELISMTABLE"].ToString() + "'";
                            if ((base.Request["FSTABLE"] != null) && (base.Request["FSTABLE"].ToString() != ""))
                            {
                                table.StrWhere = "PARALLELISMTABLE='" + base.Request["PARALLELISMTABLE"].ToString() + "' or PARALLELISMTABLE='" + base.Request["FSTABLE"].ToString() + "'";
                            }
                        }
                        goto Label_30B8;

                    case "GOV_TC_DB_CollectObject":
                        table.PageTitle = "征收对象参照";
                        table.TableName = "GOV_TC_DB_CollectObject";
                        table.Columns = "PK as PK,Name as 征收对象名称,0,'',0,''";
                        if ((base.Request["PARALLELISMTABLE"] != null) && (base.Request["PARALLELISMTABLE"].ToString() != ""))
                        {
                            table.StrWhere = "PARALLELISMTABLE='" + base.Request["PARALLELISMTABLE"].ToString() + "'";
                            if ((base.Request["FSTABLE"] != null) && (base.Request["FSTABLE"].ToString() != ""))
                            {
                                table.StrWhere = "PARALLELISMTABLE='" + base.Request["PARALLELISMTABLE"].ToString() + "' or PARALLELISMTABLE='" + base.Request["FSTABLE"].ToString() + "'";
                            }
                        }
                        goto Label_30B8;

                   

                    case "GOV_TC_DB_OprateTache":
                        table.PageTitle = "业务环节参照";
                        table.TableName = "GOV_TC_DB_OprateTache";
                        table.Columns = "PK as PK,Name as 环节名称,0,'',0,''";
                        goto Label_30B8;

                    case "GOV_TC_DB_OprateTacheBH":
                        table.PageTitle = "业务环节参照";
                        table.TableName = "GOV_TC_DB_OprateTache";
                        table.Columns = "OPRATEORDER as PK,Name as 环节名称,0,'',0,''";
                        goto Label_30B8;

                    case "GOV_TC_DB_OprateTache_Added":
                        table.PageTitle = "业务环节参照";
                        table.TableName = "GOV_TC_VIEW_SFPROCOUNTSTANDARD";
                        table.Columns = "distinct TACHEPK as PK,TACHE as 环节名称,0,'',0,''";
                        table.StrWhere = "COMPANYPK='" + this.Session["pk_corp"].ToString() + "' and TACHETYPE='11'";
                        goto Label_30B8;

                    

                    case "DB_DataTable":
                        table.PageTitle = "数据字典——表参照";
                        table.TableName = "DB_DataTable";
                        table.Columns = "PK || '|' || TABLENAME as PK,TableRemark as 表名称,0,'',0,''";
                        goto Label_30B8;

                    case "DB_DataColumn":
                        table.PageTitle = "数据字典——列参照";
                        table.TableName = "DB_DataColumn";
                        table.Columns = "PK || '|' || COLUMNNAME as PK,COLUMNREMARK as 列名称,0,'',0,''";
                        if ((base.Request["PARALLELISMTABLE"] == null) || !(base.Request["PARALLELISMTABLE"].ToString() != ""))
                        {
                            goto Label_305B;
                        }
                        table.StrWhere = "TABLEPK='" + base.Request["PARALLELISMTABLE"].ToString() + "'";
                        if ((base.Request["TABLEPK"] != null) && (base.Request["TABLEPK"].ToString() != ""))
                        {
                            table.StrWhere = "TABLEPK='" + base.Request["PARALLELISMTABLE"].ToString() + "' or TABLEPK " + base.Request["TABLEPK"].ToString();
                        }
                        goto Label_30B8;

                    case "GOV_TC_DB_HouseCompany":
                        table.PageTitle = "建设单位档案参照";
                        table.TableName = "GOV_TC_DB_HouseCompany";
                        table.Columns = "PK || '|' || LegalMan || '|' || LinkType || '|' || RegisterAddress as PK,Name as 单位名称,0,'',0,''";
                        table.StrWhere = "ISPASS='0'";
                        goto Label_30B8;

                    case "GOV_TC_DB_BuildingCompany":
                        table.PageTitle = "施工单位档案参照";
                        table.TableName = "GOV_TC_DB_BuildingCompany";
                        table.Columns = "PK || '|' || LegalMan || '|' || LinkType || '|' || RegisterAddress as PK,Name as 单位名称,0,'',0,''";
                        table.StrWhere = "ISPASS='0'";
                        goto Label_30B8;

                    case "GOV_TC_VIEW_SOILMESS":
                        table.PageTitle = "土地档案参照";
                        table.TableName = "GOV_TC_DB_SOILDOCUMENT";
                        table.Columns = "PK||'|'||SOILSUBNUM||'|'||SOILAREA||'|'||SOILPLACE||'|'||SOILNUM as PK,SOILSUBNUM as 土地成交确认书号, Grade as 等级, FatherPK, IsHasBaby,''";
                        table.StrWhere = "ISPASS='0'";
                        table.Grade = 0;
                        goto Label_30B8;

                    case "GOV_TC_DB_BuildProjectDocument":
                        table.PageTitle = "建设项目档案参照";
                        table.TableName = "GOV_TC_VIEW_BUILDPROJECTDOC";
                        table.StrWhere = "ISPASS='0'";
                        table.Columns = "PK||'|'||ProjectName||'|'||HouseUnitHolder||'|'||HouseUnitHolderPhone||'|'||BuildAddress||'|'||SOILDOCPK||'|'||SOILSUBNUM||'|'||SOILNUM as PK,ProjectName as 项目信息, Grade as 等级, FatherPK, IsHasBaby,''";
                        if ((base.Request["type"] != null) && (base.Request["type"].ToString() != ""))
                        {
                            table.StrWhere = "ISPASS='0' and (type='" + base.Request["type"].ToString() + "' or type is null)";
                        }
                        table.Grade = 0;
                        goto Label_30B8;

                    case "GOV_TC_DB_BuildProjectDocument_jzs":
                        table.PageTitle = "建设项目档案参照";
                        table.TableName = "GOV_TC_DB_BuildProjectDocument";
                        table.Columns = "PK || '|' || BuildUnitHolder || '|' || BuildUnitHolderPhone || '|' || BuildAddress as PK,ProjectName as 建设项目名称, Grade as 等级, FatherPK, IsHasBaby, ''";
                        table.StrWhere = "ISPASS='0'";
                        table.Grade = 0;
                        goto Label_30B8;

                    case "GOV_TC_DB_ISHESHICHAJIA":
                        table.PageTitle = "能否核实差价性质档案参照";
                        table.TableName = "GOV_TC_DB_ISHESHICHAJIA";
                        table.Columns = "PK as PK,Name as 核实性质,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        table.Grade = 1;
                        goto Label_30B8;

                    case "GOV_TC_DB_JZXZ":
                        table.PageTitle = "建筑结构档案参照";
                        table.TableName = "GOV_TC_DB_JZXZ";
                        table.Columns = "PK as PK,Name as 建筑用途,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        table.Grade = 1;
                        goto Label_30B8;

                    case "GOV_TC_DB_PROJECTKIND":
                        table.PageTitle = "项目性质档案参照";
                        table.TableName = "GOV_TC_DB_PROJECTKIND";
                        table.Columns = "PK as PK,Name as 项目性质,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        table.Grade = 1;
                        goto Label_30B8;

                    case "GOV_TC_PAPER_BUILDSOILUSEPLAN":
                        table.PageTitle = "建设用地规划许可证参照";
                        table.TableName = "GOV_TC_PAPER_BUILDSOILUSEPLAN";
                        table.Columns = "PK as PK,BH as 证件编号,0,'',0,''";
                        if ((base.Request.QueryString["ProjectPK"] != null) && (base.Request.QueryString["ProjectPK"] != ""))
                        {
                            table.StrWhere = table.StrWhere + " PROJECTPK='" + base.Request.QueryString["ProjectPK"].ToString().Trim() + "'";
                        }
                        goto Label_30B8;

                    case "GOV_TC_PAPER_BUILDPROCOPY":
                        table.PageTitle = "建设工程规划许可证副本参照";
                        table.TableName = "GOV_TC_PAPER_BUILDPROCOPY";
                        table.Columns = "PK as PK,BH as 证件编号,0,'',0,''";
                        if ((base.Request.QueryString["ProjectPK"] != null) && (base.Request.QueryString["ProjectPK"] != ""))
                        {
                            table.StrWhere = table.StrWhere + " PROJECTPK='" + base.Request.QueryString["ProjectPK"].ToString().Trim() + "'";
                        }
                        goto Label_30B8;

                    case "GOV_TC_PAPER_BUILDPROJECTPLAN":
                        table.PageTitle = "建设工程规划许可证正本参照";
                        table.TableName = "GOV_TC_PAPER_BUILDPROJECTPLAN";
                        table.Columns = "PK as PK,BH as 证件编号,0,'',0,''";
                        if ((base.Request.QueryString["ProjectPK"] != null) && (base.Request.QueryString["ProjectPK"] != ""))
                        {
                            table.StrWhere = table.StrWhere + " PROJECTPK='" + base.Request.QueryString["ProjectPK"].ToString().Trim() + "'";
                        }
                        goto Label_30B8;

                    case "GOV_TC_PAPER_BUILDPROCST":
                        table.PageTitle = "建筑工程施工许可证参照";
                        table.TableName = "GOV_TC_PAPER_BUILDPROCST";
                        table.Columns = "PK as PK,BH as 证件编号,0,'',0,''";
                        if ((base.Request.QueryString["ProjectPK"] != null) && (base.Request.QueryString["ProjectPK"] != ""))
                        {
                            table.StrWhere = table.StrWhere + " PROJECTPK='" + base.Request.QueryString["ProjectPK"].ToString().Trim() + "'";
                        }
                        goto Label_30B8;

                    case "GOV_TC_DB_STREET":
                        table.PageTitle = "路段档案";
                        table.TableName = "GOV_TC_DB_STREET";
                        table.Columns = "PK as PK,Name as 路段名称,Grade as 等级,FatherPK,IsHasBaby,PKPath";
                        table.Grade = 1;
                        goto Label_30B8;

                    case "GOV_TC_DB_LDJG_HOUSE":
                        table.PageTitle = "路段价格限制-房产";
                        table.TableName = "GOV_TC_DB_LDJG_HOUSE";
                        table.Columns = "PK || '|' || ZFMINVALUE || '|' || FZFMINVALUE as PK,TYPE||'-'||TNAME||'-'||QYFW as 路段名称,0,'',0,''";
                        goto Label_30B8;

                    case "GOV_TC_DB_LDJG_SOIL":
                        table.PageTitle = "路段价格限制-土地";
                        table.TableName = "GOV_TC_DB_LDJG_SOIL";
                        table.Columns = "PK || '|' || ZFMINVALUE || '|' || FZFMINVALUE as PK,TYPE||'-'||TNAME||'-'||QYFW as 路段名称,0,'',0,''";
                        goto Label_30B8;

                    case "FG":
                        table.PageTitle = "政策法规信息参照";
                        table.TableName = "PD_PROJECT_REGULATE";
                        table.Columns = "PD_PROJECT_CODE as PK,PD_PROJECT_SUBJECTS as 标题,0,'',0,''";
                        goto Label_30B8;

                    case "GLLX":
                        table.PageTitle = "支出功能信息参照";
                        table.TableName = "GL_Fzxzl";
                        table.Columns = "fzdm as PK,trim(fzdm)||'-'||fzmc as 标题,0,'',0,''";
                        table.StrWhere = " lbdm='4' and SFMX='1' and substr(fzdm,1,1)='2'and trim(gsdm)='" + base.Request["ye"].ToString() + "' order by fzdm";
                        goto Label_30B8;

                    case "JJLX":
                        table.PageTitle = "支出经济信息参照";
                        table.TableName = "GL_Fzxzl";
                        table.Columns = "fzdm as PK,trim(fzdm)||'-'||fzmc as 标题,0,'',0,''";
                        table.StrWhere = " lbdm='5'and length(trim(fzdm))=3 and trim(gsdm)='" + base.Request["ye"].ToString() + "' order by fzdm";
                        goto Label_30B8;

                    case "PROJECT":
                        table.PageTitle = "项目信息参照";
                        table.TableName = "tb_project";
                        table.Columns = "pd_project_code as PK,pd_project_name as 项目名称,0,'',0,''";
                        goto Label_30B8;

                    case "INSPECTION_BTFFID":
                        table.PageTitle = "补贴发放信息参照";
                        table.TableName = "PD_PROJECT_BZFFLIST";
                        table.Columns = "AUTO_NO as PK,PD_BZFFLIST_PEASANT_NAME||PD_BZFFLIST_IDNO as 项目名称,0,'',0,''";
                        goto Label_30B8;

                    case "mssql_kjkm":
                        table.PageTitle = "会计科目";
                        table.TableName = "GL_Kmxx";
                        table.Columns = "kmdm as PK,kmmc as 项目名称,0,'',0,''";
                        table.StrWhere = " gsdm='' ";
                        goto Label_30B8;

                    case "mssql_fzhs":
                        table.PageTitle = "辅助核算项目";
                        table.TableName = "GL_Xmzl";
                        table.Columns = "xmdm as PK,xmmc as 项目名称,0,'',0,''";
                        table.StrWhere = " gsdm='' ";
                        goto Label_30B8;

                    case "pd_base_kaopingtype":
                        table.PageTitle = "工作考评大类";
                        table.TableName = "pd_base_kaopingtype";
                        table.Columns = "auto_id as PK, khtypename as 考核大类 ,0,'',0,''";
                        goto Label_30B8;

                    default:
                        goto Label_30B8;
                }
                UserModel model6 = (UserModel)this.Session["User"];
                table.PageTitle = "上级指标文号参照";
                table.TableName = "open_pd_quotaAddMoney";
                table.StrWhere = " if_show=1 ";
                if (base.Request.Params["xz"] != null)
                {
                    table.StrWhere = table.StrWhere + " and PD_QUOTA_ZJXZ='" + base.Request.Params["xz"].Trim() + "'";
                }
                if ((base.Request.Params["TZJGC"] != null) && PublicDal.PageValidate.IsInt(base.Request.Params["TZJGC"]))
                {
                    switch (int.Parse(base.Request.Params["TZJGC"]))
                    {
                        case 1:
                            table.StrWhere = table.StrWhere + " and PD_QUOTA_LWJG<=2 ";
                            break;

                        case 2:
                            table.StrWhere = table.StrWhere + " and PD_QUOTA_LWJG=3 ";
                            break;
                    }
                }
                if (base.Request["company_code"] != null)
                {
                    table.StrWhere = table.StrWhere + " and trim(company_code)='" + model6.Company.pk_corp.Trim() + "'";
                }
                table.Columns = " pd_quota_code as PK,ShowText as 指标文号,pd_up_money||'~'||PD_QUOTA_DEPART||'~'||PD_QUOTA_DEPART_NAME||'~'||PD_QUOTA_BASIS_JG||'~'||PD_QUOTA_ZJLY_NAME||'~'||PD_QUOTA_ZGKJ_NAME,'',''";
                goto Label_30B8;
            Label_1813: ;
                str6 = " pd_year=" + base.Request.Params["year"].Trim() + " and pd_project_input_company='" + ((UserModel)this.Session["user"]).Company.pk_corp + "'";
            Label_1880:
                if ((base.Request.Params["xz"] != null) && (base.Request.Params["xz"].Trim() != "0"))
                {
                    str6 = str6 + " and pd_found_xz='" + base.Request.Params["xz"].Trim() + "'";
                }
                table.StrWhere = str6;
                goto Label_30B8;
            Label_2FDD:
                companyPower = PowerClass.GetPowerString(((UserModel)HttpContext.Current.Session["User"]).CompanyPower);
            Label_3001:
                table.PageTitle = "单位信息参照";
                table.TableName = "DB_Company";
                table.Columns = "pk_corp as PK,Name as 单位名称,'',0,''";
                if (base.Request.QueryString["UsersPK"] != "admin")
                {
                    table.StrWhere = "pk_corp in (" + companyPower + ")";
                }
                goto Label_30B8;
            Label_305B:
                if ((base.Request["TABLEPK"] != null) && (base.Request["TABLEPK"].ToString() != ""))
                {
                    table.StrWhere = "TABLEPK ='" + base.Request["TABLEPK"].ToString() + "'";
                }
            Label_30B8:
                this.Session["UsualBookTable"] = table;
            }
            catch (Exception exception)
            {
                this.el = new ExceptionLog.ExceptionLog();
                this.el.ErrClassName = base.GetType().ToString();
                this.el.ErrMessage = exception.Message.ToString();
                this.el.ErrMethod = "Page_Load()";
                this.el.WriteExceptionLog(true);
                Const.OpenErrorPage("获取数据失败，请联系系统管理员！", this.Page);
            }
            finally
            {
                if (this.dbo != null)
                {
                    this.dbo.Close();
                }
            }
        }
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }
}
