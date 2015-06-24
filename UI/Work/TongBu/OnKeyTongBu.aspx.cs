using ASP;
using SoMeTech.Company;
using SoMeTech.Company.Branch;
using SoMeTech.Data;
using SoMeTech.DataAccess;
using SoMeTech.User;
using QxRoom.QxConst;
using System;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Work_TongBu_OnKeyTongBu : Page, IRequiresSessionState
{
    protected Button btnok;
    protected Button btnTB;
    private DataView dv;
    protected HtmlForm form1;
    protected Label lblTitle;
    public static StringBuilder strSelectDW = new StringBuilder();
    protected TreeView TreeView1;

    [WebMethod]
    public static string btn_tb()
    {
        string str = "";
        StringBuilder builder = new StringBuilder();
        builder.Append("select distinct gsdm as PK_CORP,gsmc as Name,case len(gsdm) when 2 then 1 else 0 end as ISHASBABY,case len(gsdm) when 2 then 0 else 1 end as  Grade,substring(gsdm,1,2) as FatherPK,substring(gsdm,1,2)+'|' as PKPath,'0' as ZXBJ from PubGszl where kjnd=(select max(kjnd) from PubGszl)");
        builder.Append(" and gsdm in ");
        builder.Append(strSelectDW);
        builder.Append(" ; ");
        builder.Append("select gsdm as PK_CORP,kjnd,bmdm as BH,bmmc as Name from PUBBMXX where kjnd=(select max(kjnd) from PUBBMXX );");
        builder.Append(" and gsdm in ");
        builder.Append(strSelectDW);
        builder.Append(" ; ");
        builder.Append("select gsdm,kjnd,zydm,zyxm,bmdm from PUBZYXX  where kjnd=(select max(kjnd) from PUBZYXX );");
        builder.Append(" and gsdm in ");
        builder.Append(strSelectDW);
        builder.Append(" ; ");
        builder.Append("select ID,name as UserName,password,gsdm as PK_CORP from gl_CZY;");
        builder.Append(" and gsdm in ");
        builder.Append(strSelectDW);
        builder.Append(" ; ");
        DataSet set = DbHelperSQL.Query(builder.ToString());
        DB_OPT dbo = new DB_OPT();
        dbo.Open();
        if ((set == null) || (set.Tables.Count != 4))
        {
            return str;
        }
        DataTable table = set.Tables[0];
        for (int i = 0; i < table.Rows.Count; i++)
        {
            DataRow row = table.Rows[i];
            CompanyModel model = new CompanyDal
            {
                pk_corp = row["PK_CORP"].ToString(),
                Name = row["Name"].ToString(),
                IsHasBaby = row["ISHASBABY"].ToString(),
                Grade = Convert.ToInt32(row["Grade"].ToString()),
                FatherPK = row["FatherPK"].ToString(),
                PKPath = row["PKPath"].ToString(),
                ZXBJ = row["ZXBJ"].ToString()
            };
            builder = new StringBuilder();
            builder.Append("select * from DB_Company where pk_corp='");
            builder.Append(model.pk_corp);
            builder.Append("'");
            if (DbHelperOra.Exists(builder.ToString()))
            {
                builder = new StringBuilder();
                builder.Append("update Db_Company set IsHasBaby='");
                builder.Append(model.IsHasBaby);
                builder.Append("',Grade=");
                builder.Append(model.Grade);
                builder.Append(",FatherPK='");
                builder.Append(model.FatherPK);
                builder.Append("',PKPath='");
                builder.Append(model.PKPath);
                builder.Append("',ZXBJ='");
                builder.Append(model.ZXBJ);
                builder.Append("' where PK_CORP='");
                builder.Append(model.pk_corp);
                builder.Append("' ");
                DbHelperOra.ExecuteSql(builder.ToString());
            }
            else
            {
                builder = new StringBuilder();
                builder.Append("insert into Db_Company(pk_corp,Name,Ishasbaby,Grade,FatherPK,PKPath,ZXBJ) values('");
                builder.Append(model.pk_corp);
                builder.Append("','");
                builder.Append(model.Name);
                builder.Append("','");
                builder.Append(model.IsHasBaby);
                builder.Append("',");
                builder.Append(model.Grade);
                builder.Append(",'");
                builder.Append(model.FatherPK);
                builder.Append("','");
                builder.Append(model.PKPath);
                builder.Append("','");
                builder.Append(model.ZXBJ);
                builder.Append("')");
                DbHelperOra.ExecuteSql(builder.ToString());
                builder = new StringBuilder();
                builder.Append("insert into db_branch(BranchPK,BH,Name,ISHasbaby,grade,PK_CORP,ISJGBM) values (sys_Guid(),'D");
                builder.Append(model.pk_corp);
                builder.Append("01','");
                builder.Append(model.Name);
                builder.Append("默认部门',0,0,'");
                builder.Append(model.pk_corp);
                builder.Append("',0)");
                DbHelperOra.ExecuteSql(builder.ToString());
                builder = new StringBuilder();
                builder.Append("insert into db_role(RolePK,BH,Name,Power,ServicesPower,ISUserPower,Grade,BranchPK,PK_CORP )");
                builder.Append("select sys_guid(),'R");
                builder.Append(model.pk_corp);
                builder.Append("01','");
                builder.Append(model.Name);
                builder.Append("默认角色',");
                builder.Append("Power,ServicesPower,ISUserPower,Grade,(select BranchPK from Db_Branch where BH='D");
                builder.Append(model.pk_corp);
                builder.Append("01' and Rownum=1),'");
                builder.Append(model.pk_corp);
                builder.Append("' from db_role t where BH='R000000' ");
                DbHelperOra.ExecuteSql(builder.ToString());
            }
        }
        table = set.Tables[1];
        for (int j = 0; j < table.Rows.Count; j++)
        {
            DataRow row2 = table.Rows[j];
            BranchModel model2 = new BranchDal
            {
                BH = row2["BH"].ToString(),
                Name = row2["Name"].ToString(),
                pk_corp = row2["PK_CORP"].ToString()
            };
            if (model2.Exists(model2.BH, dbo) > 0)
            {
                model2.Update(dbo);
            }
            else
            {
                model2.Add(dbo);
            }
        }
        table = set.Tables[3];
        for (int k = 0; k < table.Rows.Count; k++)
        {
            DataRow row3 = table.Rows[k];
            UserModel model3 = new UserDal
            {
                UserName = row3["UserName"].ToString().Trim(),
                TrueName = row3["UserName"].ToString(),
                Password = QxRoom.QxConst.QxConst.Encrypt(row3["password"].ToString(), "powerich")
            };
            if (string.IsNullOrEmpty(row3["PK_CORP"].ToString()))
            {
                model3.pk_corp = "01";
            }
            else
            {
                model3.pk_corp = row3["PK_CORP"].ToString();
            }
            if (model3.ExistsByUserName(dbo) > 0)
            {
                builder = new StringBuilder();
                builder.Append("update DB_Users set Password ='");
                builder.Append(model3.Password);
                builder.Append("' , PK_Corp='");
                builder.Append(model3.pk_corp);
                builder.Append("' , TrueName='");
                builder.Append(model3.UserName);
                builder.Append("' where UserName='");
                builder.Append(model3.UserName);
                builder.Append("'");
                DbHelperOra.ExecuteSql(builder.ToString());
            }
            else
            {
                builder = new StringBuilder();
                builder.Append("insert into Db_Users(UserName,TrueName,Password,pk_corp,BranchPK,RolePK) values('");
                builder.Append(model3.UserName);
                builder.Append("','");
                builder.Append(model3.UserName);
                builder.Append("','");
                builder.Append(model3.Password);
                builder.Append("','");
                builder.Append(model3.pk_corp);
                builder.Append("',(select BranchPK from Db_Branch where BH='D");
                builder.Append(model3.pk_corp);
                builder.Append("01' and Rownum=1),(SELECT rolepk FROM db_role  WHERE BH='R");
                builder.Append(model3.pk_corp);
                builder.Append("01' and Rownum=1))");
                DbHelperOra.ExecuteSql(builder.ToString());
                builder = new StringBuilder();
                builder.Append("update db_users a set (a.Power, a.servicespower)= (select b.Power, b.servicespower from Db_Role b where a.RolePK=b.RolePK) where length(a.pk_corp)<=4");
                DbHelperOra.ExecuteSql(builder.ToString());
            }
        }
        dbo.Close();
        StringBuilder builder2 = new StringBuilder();
        builder2.Append("已成功同步乡财县管系统的基础数据！ 本次共同步【单位数据】：");
        builder2.Append(set.Tables[0].Rows.Count);
        builder2.Append(" 条；【部门数据】：");
        builder2.Append(set.Tables[1].Rows.Count);
        builder2.Append(" 条；【人员数据】：");
        builder2.Append(set.Tables[3].Rows.Count);
        builder2.Append(" 条");
        return builder2.ToString();
    }

    public void btnok_onclick(object sender, EventArgs e)
    {
        strSelectDW.Append(" (");
        foreach (TreeNode node in this.TreeView1.Nodes)
        {
            if (node.Checked)
            {
                strSelectDW.Append(node.Value.ToString());
                strSelectDW.Append(",");
            }
        }
        strSelectDW.Remove(strSelectDW.Length - 1, 1);
        strSelectDW.Append(") ");
    }

    public void CreateTree(string parentID, TreeNode node, DataTable dt, TreeView treeView)
    {
        this.dv = new DataView(dt);
        this.dv.RowFilter = "[FatherPK]=" + parentID;
        foreach (DataRowView view in this.dv)
        {
            if (node == null)
            {
                TreeNode child = new TreeNode
                {
                    Text = view["Name"].ToString(),
                    Value = view["PK_CORP"].ToString()
                };
                this.TreeView1.Nodes.Add(child);
                this.CreateTree(view["PK_CORP"].ToString(), child, dt, treeView);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            DataSet set = DbHelperSQL.Query("select distinct gsdm as PK_CORP,gsmc as Name,case len(gsdm) when 2 then 0 else 1 end as  Grade,substring(gsdm,1,2) as [FatherPK] from PubGszl where kjnd=(select max(kjnd) from PubGszl) and gsdm like '01%'");
            new TreeNode("总预算账", "01", "");
            this.CreateTree("01", null, set.Tables[0], this.TreeView1);
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
