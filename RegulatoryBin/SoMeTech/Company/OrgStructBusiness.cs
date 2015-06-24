namespace SoMeTech.Company
{
    using System;

    public sealed class OrgStructBusiness
    {
        public static string GetCompanyAndBranchSql(string companypower)
        {
            return ("select rtrim(BH) as OrgBH,name as orgname from (SELECT pk_corp AS BH,name FROM DB_Company UNION all SELECT BH,name FROM DB_Branch ) a where patindex('%|'||rtrim(BH)||'|%','|" + companypower + "|')>0");
        }
    }
}

