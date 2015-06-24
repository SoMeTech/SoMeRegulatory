<%@ page language="C#" autoeventwireup="true" CodeBehind="fileup.aspx.cs" inherits="Work_ZB_fileup" enableEventValidation="false" stylesheettheme="Default" %>

　　<%@ Register Assembly="ExtExtenders" Namespace="ExtExtenders" TagPrefix="cc1" %>
　　<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
　　<html xmlns="http://www.w3.org/1999/xhtml" >
　　<head id="Head1" runat="server">
　　<title>附件信息</title>
　　<link href ="http://www.hd1204.com/../Styles/AjaxTookitStyle.css" type="text/css" rel="stylesheet" />
　　</head>
　　<body>
　　<form id="form1" runat="server">
　　<div style="height: 1882px; width: 1200px">
　　<asp:ScriptManager ID="ScriptManager1" runat="server">
　　</asp:ScriptManager>
　　<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"
　　Height="1616px" >
　　<cc1:TabPanel runat="server" HeaderText="添加附件信息" ID="TabPanel1">
　　<HeaderTemplate>
　　添加附件信息
　　</HeaderTemplate>
　　<ContentTemplate>
　 <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="商品编号" 
            onrowupdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
            <asp:TemplateField HeaderText="商品编号">
            <ItemTemplate>
             <asp:TextBox ID="商品编号" runat="server" Text='<%#Bind("商品编号")%>'></asp:TextBox>
            </ItemTemplate>            
                </asp:TemplateField>        
                 <asp:TemplateField HeaderText="商品小图地址">
                    <ItemTemplate>
                         <asp:FileUpload ID="商品小图上传" runat="server" />
                        <asp:Image ID="商品小图" ImageUrl='<%#Bind("商品小图地址")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>                
            </Columns>
        </asp:GridView>
　　</ContentTemplate>
　　</cc1:TabPanel>
　　</cc1:TabContainer>
　　</div>
　　</form>
　　</body>
　　</html>