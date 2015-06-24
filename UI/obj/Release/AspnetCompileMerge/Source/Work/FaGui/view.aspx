<%@ page language="C#" autoeventwireup="true" inherits="view" CodeBehind="view.aspx.cs" enableEventValidation="false" stylesheettheme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>政策法规查询</title>
     <link href="css/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<div style="text-align:center">
<table width="90%" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td align="left" valign="top">
          <table width="100%"  border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td width="2%">&nbsp;</td>
              <td width="98%"><table width="80%" >
                <tr align="center">
                  <td height="40"><font size="4"><strong>
                    <p></p>
                    </strong></font>
                      <p>&nbsp;</p>
                      <p><font size="4"><strong><%=title %></strong></font> <br>
                          <br>
                    </p></td>
                </tr>
                <tr align="center">
                  <td>文章类别：<%=type %> 更新时间：<%=scTime %></td>
                </tr>
                <tr>
                  <td  align="left"><div align="left">
                      <p>&nbsp; </p>
                      <p>
                        <%=content %>
                      </p>
                  </div></td>
                </tr>
                <tr>
                  <td>
                  <table width="100%" border="0" cellpadding="0" cellspacing="5" style="BORDER-top: #6687ba 1px solid;BORDER-bottom: #6687ba 1px solid;">
                      <tr>
                        <td><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton></td>
                            
                        <td><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">LinkButton</asp:LinkButton></td>
                          </tr>   
                  </table></td>
                </tr>
              </table></td>
              <td width="2%">&nbsp;</td>
            </tr>
          </table>
    </div>
    </form>
</body>
</html>
