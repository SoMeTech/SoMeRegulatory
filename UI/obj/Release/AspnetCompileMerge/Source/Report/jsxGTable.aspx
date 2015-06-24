<%@ page language="C#" autoeventwireup="true" inherits="Report_jsxGTable" enableEventValidation="false" stylesheettheme="Default" CodeBehind="jsxGTable.aspx.cs" %>
<%@ Register Src="~/WebControls/reprotButtonl.ascx" TagName="reprotButtonl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
<style type="text/css">
table{
border-collapse:collapse;
border: 1px solid #000000;
}
td{
border-collapse:collapse;
border: 1px solid #000000;
font-size:16px;
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
<body >
    <form id="form1" runat="server">
    <div style="padding-top:20px; text-align:center;">
    <div class="buttonNoPrint"><uc1:reprotButtonl ID="reprotButtonl1" runat="server" /></div> <br />
     <div style=" text-align:center; font-size:22px; font-weight:bold"><asp:Label ID="lblxname" runat="server" style="text-decoration: underline;"></asp:Label>(市区)<asp:Label  ID="lblxz" runat="server" style="text-decoration: underline;"></asp:Label>乡（镇）项目建设资金监管记录表</div>
     <div style=" padding-top:40px; margin:0 auto">
     
<table width="650" id="table1" align="center" cellpadding="0"  cellspacing="0">
  <tr height="36">
    <td  height="36" colspan="2" align="right">建账单位名称：</td>
    <td  colspan="3"><asp:Label id="建账单位名称" runat="server"></asp:Label></td>
    <td  colspan="2" align="right">建账日期：</td>
    <td colspan="3"><asp:Label id="建账日期" runat="server"></asp:Label></td>
    <td  align="right">经办人：</td>
    <td><asp:Label id="经办人" runat="server"></asp:Label></td>
  </tr>
  <tr height="36">
    <td height="36" colspan="3" align="right">指标文号：</td>
    <td colspan="9"style="width:550px;"><asp:Label id="指标文号" runat="server"></asp:Label></td>
  </tr>
  <tr height="36">
    <td height="36" colspan="3" align="right">监管资金名称：</td>
    <td colspan="9"><asp:Label id="监管资金名称" runat="server"></asp:Label></td>
  </tr>
  <tr height="36">
    <td height="36" colspan="3" align="right">资金用途：</td>
    <td colspan="9"><asp:Label id="资金用途" runat="server"></asp:Label></td>
  </tr>
  <tr height="36">
    <td height="36" colspan="3" align="right">项目建设地点及内容：</td>
    <td colspan="9"><asp:Label id="项目建设地点及内容" runat="server"></asp:Label></td>
  </tr>
  <tr height="36">
    <td height="36" colspan="3" align="right">监管依据(资金监管办法)：</td>
    <td colspan="9"><asp:Label id="监管依据" runat="server"></asp:Label></td>
  </tr>
  <tr height="36">
    <td height="36" colspan="3" align="right">资金类别：</td>
    <td colspan="3" ><asp:Label id="资金类别" runat="server"></asp:Label></td>
    <td colspan="3" align="right">指标额度：</td>
    <td colspan="3"><asp:Label id="指标额度" runat="server"></asp:Label></td>
  </tr>
  <tr height="36">
    <td height="36" colspan="3" align="right">政策要求：</td>
    <td colspan="3"><asp:Label id="政策要求" runat="server"></asp:Label></td>
    <td colspan="3" align="right">资金使用单位：</td>
    <td colspan="3"><asp:Label id="资金使用单位" runat="server"></asp:Label></td>
  </tr>
  <tr height="36">
    <td height="36" colspan="3" align="right">计划开工日期：</td>
    <td colspan="3"><asp:Label id="计划开工日期" runat="server"></asp:Label></td>
    <td colspan="3" align="right">计划完工日期：</td>
    <td colspan="3"><asp:Label id="计划完工日期" runat="server"></asp:Label></td>
  </tr>
  <tr height="36">
    <td height="36" colspan="3" align="right">项目责任人：</td>
    <td colspan="3"><asp:Label id="项目责任人" runat="server"></asp:Label></td>
    <td colspan="3" align="right">项目负责人：</td>
    <td colspan="3"><asp:Label id="项目负责人" runat="server"></asp:Label></td>
  </tr>
  <tr height="36">
    <td height="36" colspan="3" align="right">项目预算金额：</td>
    <td colspan="3"><asp:Label id="项目预算金额" runat="server"></asp:Label></td>
    <td colspan="3" align="right">项目决算金额：</td>
    <td colspan="3"><asp:Label id="项目决算金额" runat="server"></asp:Label></td>
  </tr>
  <tr height="36">
    <td height="108" colspan="3" rowspan="3" align="right">项目投资概况：</td>
    <td colspan="3" rowspan="3"><asp:Label id="项目投资概况" runat="server"></asp:Label></td>
    <td  height="36" colspan="3" align="right">上级财政资金：</td>
    <td colspan="3"><asp:Label id="上级财政资金" runat="server"></asp:Label></td>
  </tr>
  <tr height="36">
    <td height="36" colspan="3" align="right">本级自筹资金：</td>
    <td colspan="3"><asp:Label id="本级自筹资金" runat="server"></asp:Label></td>
  </tr>
  <tr height="36">
    <td height="36" colspan="3" align="right">其他来源资金：</td>
    <td colspan="3"><asp:Label id="其他来源资金" runat="server"></asp:Label></td>
  </tr>
  <tr height="36">
    <td height="36" colspan="3" align="right">资金拨付情况：</td>
    <td colspan="3"><asp:Label id="资金拨付情况" runat="server"></asp:Label></td>
    <td colspan="3" align="right">项目完工日期：</td>
    <td colspan="3"><asp:Label id="项目完工日期" runat="server"></asp:Label></td>
  </tr>
  <%--<tr height="36">
    <td height="36" colspan="3" align="right">记账时间</td>
    <td colspan="3"><asp:Label id="记账时间" runat="server"></asp:Label></td>
    <td colspan="3" align="right">凭证号</td>
    <td colspan="3"><asp:Label id="凭证号" runat="server"></asp:Label></td>
  </tr>--%>
  <tr height="36">
    <td height="36" colspan="3" align="right">公示情况：</td>
    <td colspan="3"><asp:Label id="公示情况" runat="server"></asp:Label></td>
    <td colspan="3" align="right">抽查巡查次数：</td>
    <td colspan="3"><asp:Label id="抽查巡查次数" runat="server"></asp:Label></td>
  </tr>
  <tr height="36">
    <td height="120" colspan="3" align="right">项目概况：</td>
    <td colspan="9"><asp:Label id="项目概况" runat="server"></asp:Label></td>
  </tr>
  <tr height="36">
    <td height="120" colspan="3" align="right">财政所意见：</td>
    <td colspan="9"><asp:Label id="财政所意见" runat="server"></asp:Label></td>
  </tr>
</table>
          <div style=" text-align:center; padding-top:10px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 监管人签字：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 监管日期：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 年&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    月&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 日&nbsp;                       </div>
    </div>
    </div>
    </form>
</body>
</html>
