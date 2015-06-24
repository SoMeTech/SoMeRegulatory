<%@ page language="C#" autoeventwireup="true" CodeBehind="Default0.aspx.cs" enableeventvalidation="false" stylesheettheme="Default" inherits="Default0" %>

<%@ Register Assembly="ExtExtenders" Namespace="ExtExtenders" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    
    <script src="js/dhtabstrip.js" type="text/javascript"></script>
    <script type="text/javascript">
        function addTabPanel(val, var1) {
            var tabs = $find("tabs");
            var tabPanel = tabs.TabPanel;

            tabPanel.add(
                {
                    title: val,
                    iconCls: "tabs",
                    //height : "600px",
                    html: '<iframe src="' + var1 + '" width="100%" height="100%" border="0" scrolling="yes"></iframe>',
                    closable: true
                }).show();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <div>
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <table cellspacing="0" cellpadding="0" border="0" align="center" width="100%" height="100%">
                <tr>
                    <td width="100%" height="100%" valign="top">
                        <cc1:TabContainer ID="tabs" runat="server" Width="100%" Height="630px" ActiveTabIndex="0" enableTabScroll="True">
                        
                            <cc1:TabPanel ID="tp1" runat="server" Width="100%" closable="False" TabIndex="0" HeaderText="欢迎使用">
                                <ContentTemplate>
                                    <iframe src="../welcome.aspx" width="100%" Height="100%" border="0" scrolling="yes"></iframe>
                                </ContentTemplate>
                            </cc1:TabPanel>
                            
                        </cc1:TabContainer>
                    </td>
                </tr>
               <%-- <tr>
                    <td>
                        <input type="text" ID="txt1" runat="server" />
                        <input type="text" ID="txt2" runat="server" />
                        <input type="button" id="btadd" name="btadd" value="js add" onclick="javascript:addTabPanel(txt1.value, txt2.value);" />
                        
                        <asp:Button ID="button1" runat="server" Text="add" OnClick="button1_Click" />
                    </td>
                </tr>--%>
            </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
