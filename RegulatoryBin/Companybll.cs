using SoMeTech.Company;
using SoMeTech.DataAccess;
using System;
using System.Collections;
using System.Data;

public sealed class Companybll : MainPageClass
{
    private DB_OPT dbo = new DB_OPT();

    public DataSet Bankinfo(string BankPK)
    {
        if ((BankPK == "") && (BankPK == null))
        {
            return this.dbo.BackDataSet("select db_Bank.*,db_company.[Name] from db_Bank,db_company where db_Bank.pk_corp=db_company.pk_corp", null);
        }
        return this.dbo.BackDataSet("select db_Bank.*,db_company.[Name] from db_Bank,db_company where db_Bank.BankPK='" + BankPK + "' and db_Bank.pk_corp=db_company.pk_corp", null);
    }

    public static void ChangeChildPkPath(string pk_corp, string pkpath, int grade, DB_OPT dbo)
    {
        CompanyModel model = new CompanyDal();
        CompanyModel[] modelArray = model.GetChilds(pk_corp, false, dbo);
        if (modelArray != null)
        {
            for (int i = 0; i < modelArray.Length; i++)
            {
                model.pk_corp = modelArray[i].pk_corp;
                model.Grade = grade;
                model.PKPath = pkpath;
                model.UpdatePKPathAndGrade(dbo);
                if (modelArray[i].IsHasBaby == "1")
                {
                    ChangeChildPkPath(modelArray[i].pk_corp, pkpath + model.pk_corp + "|", grade + 1, dbo);
                }
            }
        }
        else
        {
            model.pk_corp = pk_corp;
            model.IsHasBaby = "0";
            model.UpdateHasBaby(dbo);
        }
    }

    public DataSet companyinfo(string pk_corp)
    {
        DataSet set;
        try
        {
            this.dbo.Open();
            if ((pk_corp == "") || (pk_corp == null))
            {
                return this.dbo.BackDataSet("select * from gov_tc_view_company", null);
            }
            set = this.dbo.BackDataSet("select * from gov_tc_view_company where pk_corp='" + pk_corp + "'", null);
        }
        catch (Exception exception)
        {
            throw exception;
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
        return set;
    }

    public void deleteCompany(string pk_corp)
    {
        try
        {
            this.dbo.Open();
            this.dbo.ExecutionIsSucess("delete from company where pk_corp='" + pk_corp + "'", null);
        }
        catch (Exception exception)
        {
            throw exception;
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
    }

    public string GetStrParent(string pkpath)
    {
        string str;
        try
        {
            string str2 = "";
            this.dbo = new DB_OPT();
            this.dbo.Open();
            CompanyModel[] parents = new CompanyDal { PKPath = pkpath }.GetParents(false, this.dbo);
            for (int i = 0; i < parents.Length; i++)
            {
                str2 = parents[i].pk_corp + "~" + str2;
            }
            str = str2.Substring(0, str2.Length - 1);
        }
        catch (Exception)
        {
            str = "";
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
        return str;
    }

    public int insertBankinfo(string pk_corp, string BankName, string BankNum, string BankNumMan, string Discription)
    {
        return this.dbo.ExecutionIsSucess("insert into Bank(pk_corp,BankName,BankNum,BankNumMan,Discription) values('" + pk_corp + "','" + BankName + "','" + BankNum + "','" + BankNumMan + "','" + Discription + "')", null);
    }

    public int insertCompany(string pk_corp, string Name, string ShortName, string KeyChar, string Country, string Province, string Area, string Address, string PostalCode, string Url, string Email1, string Email2, string Email3, string Phone1, string Phone2, string Phone3, string Fax1, string Fax2, string Fax3, string linkman1, string linkman2, string Holder, string RegMoney, string BankPK, string FPDWM, string InvoiceType, string DutyNum, string Discription)
    {
        int num;
        Hashtable ht = new Hashtable();
        ht.Add("@Email1", Email1);
        ht.Add("@Email2", Email2);
        ht.Add("@Email3", Email3);
        try
        {
            this.dbo.Open();
            num = this.dbo.ExecutionIsSucess("insert into company(pk_corp,[Name],ShortName,KeyChar,Country,Province,Area,Address,PostalCode,Url,Email1,Email2,Email3,Phone1,Phone2,Phone3,Fax1,Fax2,Fax3,linkman1,linkman2,Holder,RegMoney,BankPK,FPDWM,InvoiceType,DutyNum,Discription) values('" + pk_corp + "','" + Name + "','" + ShortName + "','" + KeyChar + "','" + Country + "','" + Province + "','" + Area + "','" + Address + "','" + PostalCode + "','" + Url + "',@Email1,@Email2,@Email3,'" + Phone1 + "','" + Phone2 + "','" + Phone3 + "','" + Fax1 + "','" + Fax2 + "','" + Fax3 + "','" + linkman1 + "','" + linkman2 + "','" + Holder + "'," + RegMoney + ",'" + BankPK + "','" + FPDWM + "','" + InvoiceType + "','" + DutyNum + "','" + Discription + "')", ht);
        }
        catch (Exception exception)
        {
            throw exception;
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
        return num;
    }

    public DataSet maxPk_corp()
    {
        DataSet set;
        try
        {
            this.dbo.Open();
            set = this.dbo.BackDataSet("select max(pk_corp) from company", null);
        }
        catch (Exception exception)
        {
            throw exception;
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
        return set;
    }

    public int updateBankinfo(string BankPK, string pk_corp, string BankName, string BankNum, string BankNumMan, string Discription)
    {
        return this.dbo.ExecutionIsSucess("update Bank set pk_corp='" + pk_corp + "',BankName='" + BankName + "',BankNum='" + BankNum + "',BankNumMan='" + BankNumMan + "',Discription='" + Discription + "' where BankPK='" + BankPK + "'", null);
    }

    public int updateCompany(string pk_corp, string Name, string ShortName, string KeyChar, string Country, string Province, string Area, string Address, string PostalCode, string Url, string Email1, string Email2, string Email3, string Phone1, string Phone2, string Phone3, string Fax1, string Fax2, string Fax3, string linkman1, string linkman2, string Holder, string RegMoney, string BankPK, string FPDWM, string InvoiceType, string DutyNum, string Discription)
    {
        int num;
        Hashtable ht = new Hashtable();
        ht.Add("@Email1", Email1);
        ht.Add("@Email2", Email2);
        ht.Add("@Email3", Email3);
        try
        {
            this.dbo.Open();
            num = this.dbo.ExecutionIsSucess("update company set [Name]='" + Name + "',ShortName='" + ShortName + "',KeyChar='" + KeyChar + "',Country='" + Country + "',Province='" + Province + "',Area='" + Area + "',Address='" + Address + "',PostalCode='" + PostalCode + "',Url='" + Url + "',Email1=@Email1,Email2=@Email2,Email3=@Email3,Phone1='" + Phone1 + "',Phone2='" + Phone2 + "',Phone3='" + Phone3 + "',Fax1='" + Fax1 + "',Fax2='" + Fax2 + "',Fax3='" + Fax3 + "',linkman1='" + linkman1 + "',linkman2='" + linkman2 + "',Holder='" + Holder + "',RegMoney=" + RegMoney + ",BankPK='" + BankPK + "',FPDWM='" + FPDWM + "',InvoiceType='" + InvoiceType + "',DutyNum='" + DutyNum + "',Discription='" + Discription + "' where pk_corp='" + pk_corp + "'", ht);
        }
        catch (Exception exception)
        {
            throw exception;
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
        return num;
    }
}

