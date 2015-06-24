<%@ page language="C#" masterpagefile="~/Master/MainMX.master" autoeventwireup="true" inherits="Work_DataPrint_companyToDataAdd"  CodeBehind="companyToDataAdd.aspx.cs"title="" enableEventValidation="false" stylesheettheme="Default" %>

<%@ MasterType VirtualPath="~/Master/MainMX.master" %>
<%@ Register Assembly="ExtExtenders" Namespace="ExtExtenders" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jquery-1.4.2.min.js") %>" type="text/javascript"></script>
        
        <script type="text/javascript">

            function findwindow(val, obj) {
                var webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val + "&xz=01";
                //alert(webFileUrl);
                //var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
                var _xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                _xmlhttp.open("POST", webFileUrl, false);
                _xmlhttp.send("");

                var arr = window.showModalDialog("../../Shared/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
                //alert(arr);
                if (arr != null && arr != "false") {
                    if (arr.indexOf("~") > 0) {
                        ss = arr.split("~");
                        obj.value = ss[1];
                        $("input[uid='txtCOMPANYBH']").get(0).value = ss[0];
                    }
                }
            }
        </script>
    <div>
        <table cellSpacing="0" cellPadding="0" width="100%" border="0">
	        <tr style="display:none;">
	        <td height="35" width="30%" align="right">
		        PK
	        ：</td>
	        <td height="35" width="*" align="left">
		        <asp:label id="lblPK" runat="server"></asp:label>
	        </td></tr>
	        <tr>
	        <td height="35" width="30%" align="right">
		        帐套
	        ：</td>
	        <td height="35" width="*" align="left">
	            <asp:DropDownList  id="dllDATANAME" runat="server" Width="200px">
	            </asp:DropDownList>
	        </td></tr>
	        <tr>
	        <td height="35" width="30%" align="right">
		        单位编码
	        ：</td>
	        <td height="35" width="*" align="left">
	            <input  id="lblCOMPANYBH" runat="server" style="width:200px" onClick="javascript: findwindow('company', this);" readonly="readonly" />
	            <input  id="txtCOMPANYBH" uid="txtCOMPANYBH" runat="server" style="display:none;"/>
	        </td></tr>
        </table>


    </div>
    
    
</asp:Content>