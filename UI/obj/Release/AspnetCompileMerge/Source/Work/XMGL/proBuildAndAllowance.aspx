
<%@ page language="C#" autoeventwireup="true" CodeBehind="proBuildAndAllowance.aspx.cs" inherits="Work_projectGL_proBuildAndAllowance" enableEventValidation="false" stylesheettheme="Default" %>
<%@ Register Src="~/WebControls/reprotButtonl.ascx" TagName="reprotButtonl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
table{
border-collapse:collapse;
border: 1px solid #000000;
}
tr
{
	height:38px;
	}
td{
border-collapse:collapse;
border: 1px solid #000000;
font-size:16px;
height:38px;
width:110px;
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
    function newSaveWord() {

        document.getElementById("Button1").click();

    }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding-top:20px; text-align:center;">
    <div class="buttonNoPrint"><uc1:reprotbuttonl ID="reprotButtonl1" runat="server" /></div> <br />
    <div style=" display:none;"><asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" /></div>
    <div id="printDiv" runat="server">
     <div style=" text-align:center; font-size:22px; font-weight:bold"><asp:Label ID="lblxname" runat="server" style="text-decoration: underline;"></asp:Label>(市区)<asp:Label  ID="lblxz" runat="server" style="text-decoration: underline;"></asp:Label>乡（镇）<asp:Label id="tilte_name" Font-Size="22px"  Text="项目类" runat="server"></asp:Label>财政资金监管台帐</div>
     
     <div style=" padding-top:40px; margin:0 auto">
     
<table width="800" id="table1" align="center" cellpadding="0"  cellspacing="0" style="border-collapse:collapse;border: 1px solid #000000;">
  <tr style="height:38px;">
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">项目名称</td>
        <td  colspan="2" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">
            <asp:Label id="project_name" runat="server"></asp:Label>
                        </td>
        
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">项目或资金类别</td>
        <td  colspan="2" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="project_type" runat="server"></asp:Label></td>
        
  </tr>
  <tr style="height:38px;">
        <td colspan="2" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">批次</td>
        
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">第一批</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">第二批</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">第三批</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">第四批</td>
  </tr>
  <tr style="height:38px;">
        <td rowspan="4" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">指标信息</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">收文时间</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="UP_DATE1" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="UP_DATE2" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="UP_DATE3" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="UP_DATE4" runat="server"></asp:Label></td>
  </tr>
  <tr style="height:38px;">
        
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">发文机关</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="UP_COMPANY1" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="UP_COMPANY2" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="UP_COMPANY3" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="UP_COMPANY4" runat="server"></asp:Label></td>
  </tr>
  <tr style="height:38px;">
        
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">指标文号</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="ZBWH1" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="ZBWH2" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="ZBWH3" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="ZBWH4" runat="server"></asp:Label></td>
  </tr>
  <tr style="height:38px;">
        
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">资金额度</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="ZJED1" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="ZJED2" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="ZJED3" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="ZJED4" runat="server"></asp:Label></td>
  </tr>

  <tr style="height:38px;">
        <td rowspan="3" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">收款信息</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">收款时间</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
  </tr>
  <tr style="height:38px;">
        
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">收款金额</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
  </tr>
  <tr style="height:38px;">
        
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">收款凭证号</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
  </tr>

  <tr style="height:38px;">
        <td rowspan="3" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">拨款信息</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">拨款时间</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
  </tr>
  <tr style="height:38px;">
       
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">拨款金额</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
  </tr>
  <tr style="height:38px;">
        
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">拨款凭证号</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
  </tr>
  <tr style="height:38px;">
        
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">公开公示</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">时间</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="GKDate1" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="GKDate2" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="GKDate3" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="GKDate4" runat="server"></asp:Label></td>
  </tr>
  <tr style="height:38px;">
        <td rowspan="5" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">付款信息</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">付款时间</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="GS_DATE1" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="GS_DATE2" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="GS_DATE3" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"> <asp:Label id="GS_DATE4" runat="server"></asp:Label></td>
  </tr>
  <tr style="height:38px;">
        
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">付款金额</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="FK_money1" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="FK_money2" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="FK_money3" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="FK_money4" runat="server"></asp:Label></td>
  </tr>
  <tr style="height:38px;">
        
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">付款凭证号</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="PZ_no1" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="PZ_no2" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="PZ_no3" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="PZ_no4" runat="server"></asp:Label></td>
  </tr>
  <tr style="height:38px;">
        
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">单位会计签名</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
  </tr>
  <tr style="height:38px;">
        
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">财政所长签名</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
  </tr>
  <tr style="height:38px;">
        <td rowspan="2" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">检查信息</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">检查或验收单位</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="YS_company1" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="YS_company2" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="YS_company3" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="YS_company4" runat="server"></asp:Label></td>
  </tr>
  <tr style="height:38px;">
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">检查或验收时间</td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="YS_Date1" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="YS_Date2" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="YS_Date3" runat="server"></asp:Label></td>
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"><asp:Label id="YS_Date4" runat="server"></asp:Label></td>
  
  </tr>
   <tr style="height:38px;">
        <td style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;">备注：</td>
        <td colspan="5" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;height:38px;width:110px;"></td>
        
  
  </tr>
</table>
                <div style=" text-align:center; padding-top:10px; font-size:16px;">监管人签字财政所长签名：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    &nbsp;登记人签名：</div>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
