using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;
using SoMeTech.CommonDll;
using SoMeTech.YZXWPageClass;
public partial class readinfo : System.Web.UI.Page
{
    protected Label Label1;
    protected Label Label2;
    protected Label Label3;
    protected HiddenField hidf;
    protected Label Label5;
    protected TextBox TextBox1;
    protected Label lbsn;
    protected ImageButton IBTN_date;
    string[] strArray2 = new string[8];
    protected HtmlTextArea content_1;
    protected Calendar Calendar;
    protected FileUpload FileUpload1;
    protected DropDownList DPlist_year;
    protected DropDownList DPlist_month;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FileUpload1.Attributes.Add("onpropertychange", "test2();");
            int k = Convert.ToInt32(DateTime.Now.Year) + 30;

            for (int i = Convert.ToInt32(DateTime.Now.Year); i <= k; i++)
            {
                DPlist_year.Items.Add(i.ToString());
            }

            for (int i = 1; i <= 12; i++)
            {
                DPlist_month.Items.Add(i.ToString());
            }
        }
        else
        {
            int year, month, day;
            year = Convert.ToInt32(DPlist_year.SelectedItem.ToString());
            month = Convert.ToInt32(DPlist_month.SelectedItem.ToString());
            day = DateTime.Now.Day;
            DateTime querydate = new DateTime(year, month, day);
            Calendar.VisibleDate = querydate;
        }
    }
    protected void btndiffs_Click(object sender, EventArgs e)
    {
        string fileName = FileUpload1.PostedFile.FileName;
        if (fileName == null)
        {
            PageShowText.ShowMessage("请选择 客户信息 文件！", this.Page);
        }
        else
        {
            hidf.Value = fileName;
            string str;
            StreamReader reader = new StreamReader(fileName, Encoding.Default);
            while ((str = reader.ReadLine()) != null)
            {
                string[] strArray = str.Split(new char[] { '&' });
                SymmetricMethod method = new SymmetricMethod();
                if (strArray.Length == 3)
                {
                    Label1.Text = "CPU:" + method.Decrypto(strArray[0].ToString());
                    Label2.Text = "磁盘：" + method.Decrypto(strArray[1].ToString());
                    Label3.Text = "mac地址：" + method.Decrypto(strArray[2].ToString());
                }

            }
        }
    }
    protected void Create_code_Click(object sender, EventArgs e)
    {
        string fileName = hidf.Value.ToString();
        if (fileName.Length > 0)
        {
            if (TextBox1.Text.Length > 0)
            {
                if (Label5.Text.Length > 0)
                {
                    string str;
                    StreamReader reader = new StreamReader(fileName, Encoding.Default);
                    while ((str = reader.ReadLine()) != null)
                    {
                        string[] strArray = str.Split(new char[] { '&' });
                        SymmetricMethod method = new SymmetricMethod();

                        if (strArray.Length == 3)
                        {
                            string str1 = method.Decrypto(strArray[0].ToString());
                            string str2 = method.Decrypto(strArray[1].ToString());
                            string str3 = method.Decrypto(strArray[2].ToString());
                            strArray2[0] = "湖南恒宝科技有限公司(SoMe Tech.,Ltd)";
                            strArray2[1] = "hwhtj";
                            strArray2[2] = TextBox1.Text.Trim();
                            strArray2[3] = Convert.ToDateTime(this.Label5.Text.ToString()).ToString("G");
                            strArray2[4] = str1;
                            strArray2[5] = str2;
                            strArray2[6] = str3;
                            strArray2[7] = "";
                        }
                    }
                    //以上是取得信息，下面开始进行加密
                    string[] strArray3 = new string[8];
                    for (int i = 0; i < strArray2.Length; i++)
                    {
                        strArray3[i] = SMLicense.HRET(strArray2[i].ToString());
                    }
                    //字符串数组转字符串
                    content_1.Value = string.Join("&", strArray3) + "&";
                }
                else
                {
                    Const.ShowMessage("请选择到期日期", this.Page);
                }
            }
            else
            {
                Const.ShowMessage("请输入客户行政区域编码", this.Page);
            }
        }
        else
        {
            Const.ShowMessage("请选择 客户信息.txt 文件", this.Page);
        }

    }
    protected void Calendar_SelectionChanged(object sender, EventArgs e)
    {
        Label5.Text = Calendar.SelectedDate.ToString("G");
        Calendar.Visible = false;
    }

    protected void IBTN_date_Click(object sender, ImageClickEventArgs e)
    {
        Calendar.Visible = true;
    }
}
