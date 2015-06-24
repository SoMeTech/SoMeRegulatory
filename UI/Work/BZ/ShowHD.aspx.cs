using ASP;
using SoMeTech.CommonDll;
using SoMeTech.YZXWPageClass;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using YYControls;
using SMZJ.BLL;
using SMZJ.Model;

public partial class Work_projectBZ_ShowHD : Page, IRequiresSessionState
{
    protected WebControls_Buttons1 Buttons1_1;
    protected HtmlForm form1;
    protected SmartGridView gvResult;
    protected HtmlInputHidden ibtid;
    protected HtmlInputHidden jgjlText_H;

    public void Buttons(string ibtid)
    {
        string str;
        if (((str = ibtid) != null) && (str == "ibtcontrol_ibtsave"))
        {
            if (this.jgjlText_H.Value != "")
            {
                this.SaveBDData(base.Request["code"]);
            }
            else
            {
                PageShowText.ShowMessage("没有监管记录可以保存!", this.Page);
            }
        }
    }

    public void ListPageLoad(Page page, out ButtonsModel main_bm, string PD_PROJECT_CODE)
    {
        PublicDal.ShowMxButton(this.Page, out main_bm, "TB_PROJECT", "PD_PROJECT_CODE", PD_PROJECT_CODE, "PD_PROJECT_SERVERPK");
        main_bm.IfSave = true;
        main_bm.IfPutOut = true;
        main_bm.IbtPutOutText = "导出Excel";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ButtonsModel model = null;
        this.ListPageLoad(this.Page, out model, base.Request["code"]);
        this.Buttons1_1.BM = model;
        ButtonsHandler handler = new ButtonsHandler(this.Buttons);
        handler(this.ibtid.Value);
        this.ibtid.Value = "";
        if (!this.Page.IsPostBack)
        {
            DataSet set = new PD_PROJECT_INSPECTION_Bll().HeDuiData(base.Request["code"]);
            if ((set != null) && (set.Tables[0].Columns.Count > 0))
            {
                this.gvResult.DataKeyNames = new string[] { set.Tables[0].Columns[0].ColumnName };
                for (int i = 0; i < set.Tables[0].Columns.Count; i++)
                {
                    BoundField field = new BoundField
                    {
                        DataField = set.Tables[0].Columns[i].ColumnName,
                        HeaderText = set.Tables[0].Columns[i].ColumnName,
                        SortExpression = set.Tables[0].Columns[i].ColumnName
                    };
                    field.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.gvResult.Columns.Add(field);
                }
                this.gvResult.DataSource = set;
                if (set.Tables[0].Rows.Count == 0)
                {
                    set.Tables[0].Columns[0].DataType = typeof(string);
                    set.Tables[0].Rows.Add(set.Tables[0].NewRow());
                    set.Tables[0].Rows[0][0] = "无数据";
                    this.gvResult.DataSource = set;
                    this.gvResult.DataBind();
                    this.gvResult.Rows[0].Cells[0].ColumnSpan = set.Tables[0].Columns.Count;
                    int num2 = 1;
                    while (num2 < this.gvResult.Rows[0].Cells.Count)
                    {
                        this.gvResult.Rows[0].Cells.Remove(this.gvResult.Rows[0].Cells[num2]);
                    }
                }
                else
                {
                    set.Tables[0].DefaultView.RowFilter = "是否完全符合<>'是'";
                    DataView defaultView = set.Tables[0].DefaultView;
                    string str = "";
                    for (int j = 0; j < defaultView.Count; j++)
                    {
                        for (int k = 0; k < set.Tables[0].Columns.Count; k++)
                        {
                            object obj2 = str;
                            str = string.Concat(new object[] { obj2, "【", set.Tables[0].Columns[k].ColumnName, ":", defaultView[j][set.Tables[0].Columns[k].ToString()], "】" });
                            if (k < (set.Tables[0].Columns.Count - 1))
                            {
                                str = str + "、";
                            }
                        }
                        if (j < (defaultView.Count - 1))
                        {
                            str = str + "\r\n";
                        }
                    }
                    this.jgjlText_H.Value = str;
                    this.gvResult.DataBind();
                }
            }
        }
    }

    private void SaveBDData(string PD_PROJECT_CODE)
    {
        TB_PROJECT_BZ_Bll bll = new TB_PROJECT_BZ_Bll();
        TB_PROJECT_BZ_Model model = bll.GetModel(PD_PROJECT_CODE);
        model.PD_PROJECT_JGJL = this.jgjlText_H.Value;
        if (bll.Update(model))
        {
            PageShowText.ShowMessage("保存成功!", this.Page);
        }
        else
        {
            PageShowText.ShowMessage("保存失败!", this.Page);
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
