<%@ page language="C#" autoeventwireup="true" inherits="Report_JGTable2" enableEventValidation="false" stylesheettheme="Default" CodeBehind="bzxJGTable2.aspx.cs" %>
<%@ Register Src="~/WebControls/reprotButtonl.ascx" TagName="reprotButtonl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>监管记录打印管理</title>   
<style type="text/css">
table{
border-collapse:collapse;
border: 1px solid #000000;
}
td{
border-collapse:collapse;
border: 1px solid #000000;
font-size:16px;
word-break:break-all;
}
.*
{
	font-size:16px;
}
   @media print
        {        	
            .buttonNoPrint
            {
                display: none;         
            }
        }
        
        
</style>

<script type="text/javascript">

</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding-top:20px; text-align:center;">
     <div class="buttonNoPrint"><uc1:reprotButtonl ID="reprotButtonl1" runat="server" />
         <div style=" display:none;"><asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" /></div>
        </div> <br />
        <div id="printDiv" runat="server">
        
      <div style=" text-align:center; font-size:24px; font-weight:bold"><asp:Label ID="lblxname" runat="server" style="text-decoration: underline;"></asp:Label>(市区)<asp:Label  ID="lblxz" runat="server" style="text-decoration: underline;"></asp:Label>
      乡(镇)补助性资金监管记录表</div>
      <div style=" padding-top:70px; margin:0 auto">
        <table width="700" align="center" cellpadding="0" cellspacing="0" style="border-collapse:collapse;border: 1px solid #000000;">
          <tr>
            <td height="36" colspan="3" align="right" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">监管资金名称</td>
            <td width="486" colspan="9" align="center" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;"><asp:Label ID="监管资金名称" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td height="36" colspan="3" align="right" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">监管依据(资金监管办法)</td>
            <td colspan="9" align="center" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;"><asp:Label ID="监管依据" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td height="36" colspan="3" align="right" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">补贴范围</td>
            <td colspan="9" align="center" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;"><asp:Label ID="补贴范围" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td height="36" colspan="3" align="right" style="width:175px;border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">指标文号</td>
            <td colspan="3" align="center" style="width:175px;border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;"><asp:Label ID="指标文号" runat="server"></asp:Label></td>
            <td colspan="3" align="right" style="width:175px;border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">指标额度</td>
            <td colspan="3" align="center" style="width:175px;border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;"><asp:Label ID="指标额度" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td height="36" colspan="3" align="right" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">补助对象</td>
            <td colspan="3" align="center" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">
              <asp:Label ID="补助对象" runat="server"></asp:Label>
            </td>
            <td colspan="3" align="right" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">补贴标准</td>
            <td colspan="3" align="center" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">
              <asp:Label ID="补贴标准" runat="server"></asp:Label>
            </td>
          </tr>
          <tr>
            <td height="36" colspan="3" align="right" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">补助数量</td>
            <td colspan="3" align="center" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">
              <asp:Label ID="补助人数" runat="server" ></asp:Label>
            </td>
            <td colspan="3" align="right" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">事前公示/事后公示</td>
            <td colspan="3" align="center" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">
              <asp:Label ID="公示" runat="server"></asp:Label>
            </td>
          </tr>
          <tr>
            <td height="36" colspan="3" align="right" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">公示主体</td>
            <td colspan="3" align="center" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">
              <asp:Label ID="公示主体" runat="server"></asp:Label>
            </td>
            <td colspan="3" align="right" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">是否公示(是/否)</td>
            <td colspan="3" align="center" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">
              <asp:Label ID="是否公示" runat="server"></asp:Label>
            </td>
          </tr>
          <tr>
            <td rowspan="2" align="center" valign="middle"  style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">监管记录</td>
            <td height="170" colspan="11" align="center" valign="middle" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">
              <asp:Label ID="监管记录" runat="server"></asp:Label>            </td>
          </tr>
          <tr>
            <td height="36" colspan="11" align="center" valign="middle" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">监管人签名：
              <asp:Label ID="监管人签名" runat="server"></asp:Label>
            </td>
          </tr>
          <tr>
            <td rowspan="2" align="center" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">监管结论</td>
            <td height="170" colspan="11" align="center" valign="middle" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">
              <asp:Label ID="监管结论" runat="server"></asp:Label>            </td>
          </tr>
          <tr>
            <td height="35" colspan="11" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">　</td>
          </tr>
          <tr>
            <td rowspan="2" align="center" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">财政所意见</td>
            <td height="170" colspan="11" align="center" valign="middle" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">
              <asp:Label ID="财政所意见" runat="server"></asp:Label>            </td>
          </tr>
          <tr>
            <td height="35" colspan="11" align="center" valign="middle" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">财政所长签名：
            <asp:Label ID="财政所长签名" runat="server" ></asp:Label></td>
          </tr>
        </table>
      </div>
      </div>
    </div>
    </form>
</body>
</html>
