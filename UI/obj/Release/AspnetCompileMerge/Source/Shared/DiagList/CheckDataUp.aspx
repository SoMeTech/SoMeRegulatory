<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" stylesheettheme="Default" CodeBehind="CheckDataUp.aspx.cs" inherits="Shared_CheckDataUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/Admin_Style.css" type="text/css" rel="stylesheet">
	<script type="text/javascript">
	    String.prototype.trim= function()
	    {
	        // 用正则表达式将前后空格
	        // 用空字符串替代。
	        return this.replace(/(^\s*)|(\s*$)/g, "");
	    }

	    function document.onkeydown() {
	        if (event.keyCode == 13) {
	            document.getElementById("bty").click(); //回车
	        }
	    }

	    window.name = "help_up";
	    function subMess() {
	        parent.frames["main"].location = "CheckData.aspx?txtMC=" + form1.txtMC.value.trim()+document.getElementById("MSSQL").value;
	    }
    
	    //        if (form1.txtID.value.trim() == "" && form1.txtMC.value.trim() == "") {
	    //            alert("请输入查询数据！");
	    //            form1.txtID.focus();
	    //            return false;
	    //        }
	    //        else {
	    //            if (form1.txtID.value.trim() != "" && form1.txtMC.value.trim() != "") {
	    //                alert("CheckData.aspx?txtID=" + form1.txtID.value.trim() + "&txtMC=" + form1.txtMC.value.trim());
	    //                parent.frames["main"].location = "CheckData.aspx?txtID=" + form1.txtID.value.trim() + "&txtMC=" + form1.txtMC.value.trim();
	    //            }
	    //            else if (form1.txtID.value.trim() != "") {
	    //                alert("CheckData.aspx?txtID=" + form1.txtID.value.trim());
	    //                parent.frames["main"].location = "CheckData.aspx?txtID=" + form1.txtID.value.trim();
	    //            }
	    //            else if (form1.txtMC.value.trim() != "") {
	    //                alert("CheckData.aspx?txtMC=" + form1.txtMC.value.trim());
	    //                parent.frames["main"].location = "CheckData.aspx?txtMC=" + form1.txtMC.value.trim();
	    //            }
	    //        }
	    //    }
	</script>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <input type="hidden" id="MSSQL" value="<%=MSSQLStr %>" />
    <div style="margin-top:10px;">
        <table style="width:330px;  ">
			<!--<tr>
				<td style="WIDTH: 100px; HEIGHT: 33px">
					<asp:Label ID="lbID" runat="server"></asp:Label></td>
				<td style="WIDTH: 92px; HEIGHT: 33px"><input type="text" id="txtID" name="txtID" runat="server"></td>
				<td style="WIDTH: 53px; HEIGHT: 33px">
				</td>
			</tr>-->
			
			<tr >
				<td style="WIDTH: 80px; _HEIGHT: 21px" align="right">
					<asp:Label ID="lbMC" runat="server"></asp:Label></td>
				<td style="WIDTH: 152px; HEIGHT: 3px;_HEIGHT: 21px">
					<input type="text"  style="width:150px;" id="txtMC" name="txtMC" runat="server" onpropertychange="subMess();"></td>
				<td style="WIDTH: 53px; HEIGHT: 3px;_HEIGHT: 21px">
					<!-- onkeyup="GetMC(this.value)"
					<input id="Submit1" style="HEIGHT: 24px" type="submit" value="查 询">-->
					<input type="button" id="bty" onclick="subMess();" value = "查询" />
			    </td>
			</tr>
		</table>
    </div>
    <div style="clear:both;"></div>
    
    </form>
</body>
</html>
