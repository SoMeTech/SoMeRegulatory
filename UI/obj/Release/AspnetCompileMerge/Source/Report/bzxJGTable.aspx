<%@ page language="C#" autoeventwireup="true" inherits="Report_JGTable" enableEventValidation="false" stylesheettheme="Default" CodeBehind="bzxJGTable.aspx.cs" %>
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
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding-top:20px; text-align:center;">
     <div class="buttonNoPrint"><uc1:reprotButtonl ID="reprotButtonl1" runat="server" /></div> <br />
      <div style=" text-align:center; font-size:24px; font-weight:bold"><asp:Label ID="lblxname" runat="server" style="text-decoration: underline;"></asp:Label>(市区)<asp:Label  ID="lblxz" runat="server" style="text-decoration: underline;"></asp:Label>
      乡(镇)补助性资金监管记录表</div>
       <div style=" padding-top:70px; margin:0 auto">
           <table id="table1" width="650" align="center"  cellspacing="0" cellpadding="0">
  <tr height="46">
    <td  height="46" colspan="2" align="right" >建账单位名称：</td>
    <td colspan="3"><asp:Label id="建账单位名称" runat="server"></asp:Label></td>
    <td colspan="2" align="right">建账日期：</td>
    <td colspan="3"><asp:Label id="建账日期" runat="server"></asp:Label></td>
    <td align="right">经办人：</td>
    <td><asp:Label id="经办人" runat="server"></asp:Label></td>
  </tr>
  <tr height="46">
    <td height="46" colspan="3" align="right" style="width:100px;">指标文号：</td>
    <td colspan="9" style="width:550px;"><asp:Label id="指标文号" runat="server"></asp:Label></td>
  </tr>
  <tr height="46">
    <td height="46" colspan="3" align="right">监管资金名称：</td>
    <td colspan="9"><asp:Label id="监管资金名称" runat="server"></asp:Label></td>
  </tr>
  <tr height="46">
    <td height="46" colspan="3" align="right">资金用途：</td>
    <td colspan="9"><asp:Label id="资金用途" runat="server"></asp:Label></td>
  </tr>
  <tr height="46">
    <td height="46" colspan="3" align="right">补贴范围：</td>
    <td colspan="9"><asp:Label id="补贴范围" runat="server"></asp:Label></td>
  </tr>
  <tr height="46">
    <td height="46" colspan="3" align="right">监管依据(资金监管办法)：</td>
    <td colspan="9"><asp:Label id="监管依据" runat="server"></asp:Label></td>
  </tr>
  <tr height="46">
    <td height="46" colspan="3" align="right">资金类别：</td>
    <td colspan="3" ><asp:Label id="资金类别" runat="server"></asp:Label></td>
    <td colspan="3" align="right">指标额度：</td>
    <td colspan="3" ><asp:Label id="指标额度" runat="server"></asp:Label></td>
  </tr>
  <tr height="46">
    <td height="46" colspan="3" align="right">政策要求：</td>
    <td colspan="9"><asp:Label id="政策要求" runat="server"></asp:Label></td>
  </tr>
  <tr height="46">
    <td height="46" colspan="3" align="right">补助人数：</td>
    <td colspan="3"><asp:Label id="补助人数" runat="server"></asp:Label></td>
    <td colspan="3" align="right">公示情况：</td>
    <td colspan="3"><asp:Label id="公示情况" runat="server"></asp:Label></td>
  </tr>
  <tr height="46">
    <td height="46" colspan="3" align="right">公示主体：</td>
    <td colspan="3"><asp:Label id="公示主体" runat="server"></asp:Label></td>
    <td colspan="3" align="right">抽查巡查次数：</td>
    <td colspan="3"><asp:Label id="抽查巡查次数" runat="server"></asp:Label></td>
  </tr>
  <tr height="46">
    <td height="180" colspan="3" align="right">监管概况：</td>
    <td colspan="9" style="width:550px"><asp:Label id="监管概况" runat="server"></asp:Label></td>
  </tr>
  <tr height="46">
    <td  height="180" colspan="3" align="right">财政所意见：</td>
    <td colspan="9" ><asp:Label id="财政所意见" runat="server"></asp:Label></td>
  </tr>
</table>
        <div style=" text-align:center; padding-top:10px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 监管人签字：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 监管日期：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 年&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    月&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 日&nbsp;                       </div>
         </div>
    </div>
    </form>
</body>
</html>
