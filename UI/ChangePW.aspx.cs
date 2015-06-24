using SoMeTech.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

    public partial class ChangePW : System.Web.UI.Page
    {
        protected TextBox txtNewPD;
        private UserBll Bill = new UserBll();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTrue_Click(object sender, EventArgs e)
        {
            string struser = base.Server.UrlDecode(base.Request["user"].ToString()).ToString();
            string strpwd = QxRoom.QxConst.QxConst.Encrypt(this.txtNewPD.Text.Trim(), "powerich");
            string strOpwd = base.Server.UrlDecode(base.Request["pwd"].ToString()).ToString();
            if (this.Bill.ChangePwd(struser, strpwd, strOpwd) > 0)
            {
                UserModel model = this.Bill.Login(struser);
                if (((model.UserName == struser) && (model.Password != null)) && (model.Password == strpwd))
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "js", " <script>window.opener.location = 'Default2.aspx';window.opener=null;window.close();</script>");
                    OperationLogBll.insertOp("修改", "用户信息", "修改了用户：" + base.Request["user"].ToString() + "的密码", "Y", this.Page);
                }
            }
            else
            {
                Const.ShowMessage("密码修改失败！", this.Page);
            }
        }



 

    }
