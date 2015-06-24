<%@ page language="C#" autoeventwireup="true" inherits="Work_FaGui_messbackoperinput" CodeBehind="messbackoperinput.aspx.cs"  enableEventValidation="false" stylesheettheme="Default" %>
<%@ Register Src="~/WebControls/reprotButtonl.ascx" TagName="reprotButtonl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    
    <script type="text/javascript">
        function newSaveWord() {

            document.getElementById("Button1").click();

        }
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
   <div style="padding-top:20px; text-align:center;">
    <div class="buttonNoPrint"><uc1:reprotButtonl ID="reprotButtonl1" runat="server" /></div> <br />
    <div style=" display:none"><asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" /></div>
    <div id="printDiv" runat="server">
     <div style=" text-align:center; font-size:22px; font-weight:bold"><asp:Label ID="year" runat="server" style="text-decoration: underline;"></asp:Label>年度乡镇财政资金信息反馈情况表</div>
     <div style=" padding-top:40px; margin:0 auto">
     
<table width="700" align="center" cellpadding="0" cellspacing="0" style="border-collapse:collapse;border: 1px solid #000000;">
  <tr height="36">
    <td  height="36" colspan="3" width="25%" align="right" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">填报单位名称：</td>
    <td  colspan="3" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;"><asp:Label id="company" runat="server"></asp:Label></td>
    <td  colspan="2" align="right" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">填报日期：</td>
    <td colspan="3" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;"><asp:Label id="createdate" runat="server"></asp:Label></td>
    
  </tr>
  <tr height="36">
    <td  height="36" colspan="3" align="right" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">项目名称：</td>
    <td  colspan="3" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;"><asp:Label id="project_name" runat="server"></asp:Label></td>
    <td  colspan="2" align="right" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">反馈对象：</td>
    <td colspan="3" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;"><asp:Label id="backobj" runat="server"></asp:Label></td>
    
  </tr>

  <tr>
    <td rowspan="2" colspan="3" align="center" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">存在的问题及困难</td>
    <td height="170" colspan="8" align="center" valign="middle" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">
      <asp:Label id="knwt" runat="server"></asp:Label>            </td>
  </tr>

  <tr>
    <td height="35" colspan="8" align="center" valign="middle" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">财政所长签名：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        年&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 月&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        日</td>
  </tr>
  
  <tr>
    <td rowspan="2" colspan="3" align="center" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">工作建议</td>
    <td height="170" colspan="8" align="center" valign="middle" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">
      <asp:Label id="gzjy" runat="server"></asp:Label>            </td>
  </tr>

  <tr>
    <td height="35" colspan="8" align="center" valign="middle" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">财政所长签名：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        年&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 月&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        日</td>
  </tr>
  
   <tr>
    <td rowspan="2" colspan="3" align="center" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">乡镇政府意见</td>
    <td height="170" colspan="8" align="center" valign="middle" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">
      <asp:Label id="xzfyj" runat="server"></asp:Label>            </td>
  </tr>

  <tr>
    <td height="35" colspan="8" align="center" valign="middle" style="border-collapse:collapse;border: 1px solid #000000;font-size:16px;word-break:break-all;">乡镇长签名：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        年&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 月&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        日</td>
  </tr>
  
  
</table>
          
    </div>
    <div style=" text-align:center; padding-top:10px; font-size:16px;">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 填报日期：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 年&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    月&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 日&nbsp;                       </div>
     </div>
    </div>
    </form>
</body>
</html>
