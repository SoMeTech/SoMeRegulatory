using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using SoMeTech.CommonDll;
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
        OpenFileDialog fileDialog = new OpenFileDialog();

        //判断用户是否正确的选择了文件 
        if (fileDialog.ShowDialog() == DialogResult.OK)
        {
            FileInfo fileInfo = new FileInfo(fileDialog.FileName);
            label4.Text = fileInfo.ToString();
            button1.Visible = false;


            string str;
            StreamReader reader = new StreamReader(fileInfo.ToString(), Encoding.Default);
            if ((str = reader.ReadLine()) != null)
            {
                string[] strArray = str.Split(new char[] { '&' });
                Class1 method = new Class1();
                if (strArray.Length == 3)
                {

                    label5.Text = "CPU:" + method.Decrypto(strArray[0].ToString());
                    label6.Text = "磁盘：" + method.Decrypto(strArray[1].ToString());
                    label7.Text = "mac地址：" + method.Decrypto(strArray[2].ToString());
                }

            }
        }
    }

    private void Create_code_Click(object sender, EventArgs e)
    {
        string[] strArray2 = new string[8];
        string fileName = label4.Text.ToString();
        if (fileName.Length > 0)
        {
            if (textBox1.Text.Length > 0)
            {
                if (dateTimePicker1.Value.ToString().Length > 0)
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
                            strArray2[2] = textBox1.Text.Trim();
                            strArray2[3] = Convert.ToDateTime(this.dateTimePicker1.Value.ToString()).ToString("G");
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
                    textBox2.Text = string.Join("&", strArray3) + "&";
                }
                else
                {
                    MessageBox.Show("请选择到期日期");
                }
            }
            else
            {
                MessageBox.Show("请输入客户行政区域编码");
            }
        }
        else
        {
            MessageBox.Show("请选择 客户信息.txt 文件");
        }
    }

   
}

