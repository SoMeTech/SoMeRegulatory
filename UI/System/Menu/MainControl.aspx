<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" CodeBehind="MainControl.aspx.cs" stylesheettheme="Default" inherits="Menu_MainControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../css/Admin_Style.css" rel="stylesheet" type="text/css" />
    <style type="text/css"> 
　　 a:link { text-decoration: none} 
　　 a:active { text-decoration:none} 
　　 a:hover { text-decoration:none;color: red} 
　　 a:visited { text-decoration: none} 
　　 </style>
</head>
<body style="background-color:#E7EDF6;">
    <form id="form1" runat="server">
    <div>
        <table cellspacing="0" cellpadding="0" border="0" bordercolor="#B1C6F1" width="100%" height="100%">
			<tr>
			    <td align="center" valign="middle" width="100%" height="27px" background="images/渐变图形01.jpg" style="border-bottom:#88a7d3 1px solid;">
                    <asp:Label ID="lbBanBen" runat="server" Font-Bold="True" Text="房地产税收"></asp:Label>
                </td>
			</tr>
			<tr>
				<td valign="top" align="left" width="100%" height="100%">
                    <asp:TreeView ID="TreeView1" runat="server"
                        ImageSet="Arrows" Target="mainFrame" ExpandDepth="1" ShowLines="True" Width="100%" BorderColor="beige">
                        
                        <ParentNodeStyle Font-Bold="False" ImageUrl="~/images/open2.gif" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <SelectedNodeStyle BackColor="#BFDBFF" Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                            ImageUrl="~/images/open2.gif" VerticalPadding="0px" />
                        <RootNodeStyle ImageUrl="~/images/tree_root.gif" />
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            ImageUrl="~/images/file.gif" NodeSpacing="0px" VerticalPadding="0px" Width="100%" />
                    </asp:TreeView>
                </td>
			</tr>
		</table>
    </div>
    </form>
</body>
</html>
