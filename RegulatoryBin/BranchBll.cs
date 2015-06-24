using SoMeTech.Company.Branch;
using SoMeTech.DataAccess;
using System;

public sealed class BranchBll
{
    private DB_OPT dbo;

    public static void ChangeChildPkPath(string branchpk, string pkpath, int grade, DB_OPT dbo)
    {
        BranchModel model = new BranchDal();
        BranchModel[] modelArray = model.GetChilds(branchpk, false, dbo);
        if (modelArray != null)
        {
            for (int i = 0; i < modelArray.Length; i++)
            {
                model.BranchPK = modelArray[i].BranchPK;
                model.Grade = grade;
                model.PKPath = pkpath;
                if (modelArray[i].IsHasBaby == "1")
                {
                    ChangeChildPkPath(modelArray[i].BranchPK, pkpath + model.BranchPK + "|", grade + 1, dbo);
                }
            }
        }
        else
        {
            model.BranchPK = branchpk;
            model.IsHasBaby = "0";
            model.UpdateHasBaby(dbo);
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
            BranchModel[] parents = new BranchDal { PKPath = pkpath }.GetParents(false, this.dbo);
            for (int i = 0; i < parents.Length; i++)
            {
                str2 = parents[i].BranchPK + "~" + str2;
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
}

