﻿<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" CodeBehind="jjfl.aspx.cs" inherits="Work_JCZLWH_jjfl" enableEventValidation="false" stylesheettheme="Default" %>
<%@ MasterType VirtualPath="~/Master/One.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .numberLeft
        {
            text-align: right;
        }
    </style>
    <%if (!Page.IsPostBack) %>
    <%{ %>
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/Loading.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/dowait.js") %>" type="text/javascript"></script>

    <div id="loading">
        <div class="loading-indicator">
            <img src="<%=QxRoom.Common.Public.RelativelyPath("images/extanim32.gif") %>" alt=""
                width="355" height="127" style="margin-right: 8px;" align="absmiddle" />
            正在获取数据,请稍候.....
        </div>
    </div>
    <div id="loading-mask">
    </div>
    <%} %>
     <script type="text/javascript">
         function gvResultClientClick() {
             document.getElementById("ibtcontrol_ibtdo").click();
         }
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <input type="hidden" id="txtindex" runat="server" />
            <input type="hidden" id="txttitle" runat="server" />
            <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                ContextMenuCssClass="RightMenu" DataKeyNames="FZDM" AllowSorting="true"
                OnSorting="gvResult_Sorting" OnRowCommand="gvResult_RowCommand" BoundRowClickCommandName="Select"
                CssClass="tKeepAll" BoundRowDoubleClickCommandName="Two"  ondblclick="gvResultClientClick()">
                <Columns>
                    <asp:BoundField DataField="序号" HeaderText="序号" SortExpression="序号" Visible="true"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%" />
                    <asp:BoundField DataField="FZDM" HeaderText="代码" SortExpression="FZDM"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%" />
                    <asp:BoundField DataField="LEVEL" HeaderText="层级" SortExpression="LEVEL"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%" />
                    <asp:BoundField DataField="PID" HeaderText="上级代码" SortExpression="PID"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%" />
                    <asp:BoundField DataField="FZDMM" HeaderText="名称" SortExpression="FZDMM"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%" />
                </Columns>
            </yyc:SmartGridView>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>