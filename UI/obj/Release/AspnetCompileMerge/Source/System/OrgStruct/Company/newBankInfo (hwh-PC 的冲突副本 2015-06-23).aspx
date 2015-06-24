<%@ page language="C#" masterpagefile="~/Master/MainAddUpdate.master" autoeventwireup="true" CodeBehind="newBankInfo.aspx.cs" title="Untitled Page" enableeventvalidation="false" stylesheettheme="Default" inherits="Company_newBankInfo" %>

<%@ MasterType VirtualPath="~/Master/MainAddUpdate.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if (!Page.IsPostBack) %>
    <%{ %>
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/Loading.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/dowaitUpdate.js") %>" type="text/javascript"></script>

    <div id="loading">
        <div class="loading-indicator">
            <img src="<%=QxRoom.Common.Public.RelativelyPath("images/extanim32.gif") %>" alt=""
                width="355" height="127" style="margin-right: 8px;" align="absmiddle" />
            Loading.....
        </div>
    </div>
    <div id="loading-mask">
    </div>
    <%} %>

    <script type="text/javascript">
        function findwindow(val, num) {
            var webFileUrl = "../../../PublicMode/DiagList/GetSession.aspx?tn=" + val;
            //alert(webFileUrl);
            var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
            _xmlhttp.open("POST", webFileUrl, false);
            _xmlhttp.send("");

            var arr = window.showModalDialog("../../../PublicMode/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
            if (arr != null) {
                if (arr != "false")
                    helpMess(arr, num);
            }
        }

        function helpMess(val, num) {
            if (val.indexOf("~") > 0) {
                ss = val.split("~");
                if (num == "1") {
                    document.all["ctl00_ContentPlaceHolder1_CompanyPk"].value = ss[0];
                    document.all["ctl00_ContentPlaceHolder1_txtCompany"].value = ss[1];
                }
            }
            else {
                document.all["ctl00_ContentPlaceHolder1_txtMess"].value = "";
                document.form1.txtId.value = "";
            }
        }
    </script>

    <table width="100%">
        <tr height="30px">
            <td style="text-align: right">
                单位名称<font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtCompany" runat="server" Width="200px" onclick="javascript:findwindow('company','1');"
                    ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                <img src="../../../images/8.png" onclick="javascript:findwindow('company','1');"
                    alt="查找档案信息" />
                <input id="CompanyPk" type="hidden" runat="server" />
            </td>
            <td style="text-align: right">
                银行名称<font color="red">*</font>
            </td>
            <td style="width: 100px">
                <asp:TextBox ID="txtBankName" runat="server" Width="200px">
                </asp:TextBox>
            </td>
        </tr>
        <tr height="30px">
            <td style="text-align: right">
                账号所属人
            </td>
            <td>
                <asp:TextBox ID="txtBankNumMan" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td style="text-align: right">
                银行账号<font color="red">*</font>
            </td>
            <td style="width: 100px">
                <asp:TextBox ID="txtBankNum" runat="server" Width="200px">
                </asp:TextBox>
            </td>
        </tr>
        <tr height="30px">
            <td style="height: 60px; text-align: right;">
                简要说明
            </td>
            <td colspan="3" style="height: 60px">
                <asp:TextBox ID="txtDiscription" runat="server" Width="600px"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
