﻿<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" title="无标题页" CodeBehind="DataTableList.aspx.cs" enableeventvalidation="false" stylesheettheme="Default" inherits="SystemSetup_Dictionary_DataDic_DataTableList" %>

<%@ MasterType VirtualPath="~/Master/One.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (!Page.IsPostBack) %>
    <%{ %>
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/Loading.css") %>" rel="stylesheet" type="text/css" />

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
        //菜单收缩
        function menuCollapse(w) {
            setWidth(w);
        }

        //菜单打开
        function menuExpand(w) {
            setWidth(w);
        }

        function setWidth(w) {
            //alert(w);

            //列表宽度重定义

            //        if(w>1200){
            //            var grid = document.getElementById('<%=gvResult.ClientID %>');
        //            grid.style.width=w;
        //        }
        //母版页panel宽度重定义

        var panel = document.getElementById('<%=Master.PanelID %>');
        panel.style.width = w;
    }
    </script>

    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <input type="hidden" id="txtindex" runat="server" />
        <input type="hidden" id="txttitle" runat="server" />
            <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                ContextMenuCssClass="RightMenu" Width="100%" DataKeyNames="PK" AllowSorting="true"
                 OnRowCommand="gvResult_RowCommand" BoundRowClickCommandName="Select"
                BoundRowDoubleClickCommandName="Two" OnSorting="gvResult_Sorting">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <HeaderStyle Width="30px" />
                        <ItemTemplate>
                            <a name='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>' id='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'><%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="labPk" runat="server" Text='<%#Eval("PK") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TableRemark" HeaderText="表中文名" ItemStyle-Width="240px" SortExpression="TableRemark" />
                    <asp:BoundField DataField="TableName" HeaderText="表英文名" SortExpression="TableName" />
                    <asp:BoundField DataField="Remark" HeaderText="说明" SortExpression="Remark" />
                    <asp:ButtonField CommandName="Two" Visible="False" />
                    <asp:ButtonField CommandName="Select" Visible="False" />
                </Columns>
                <FixRowColumn FixColumns="0,1,2" FixRows="" FixRowType="Header,Pager" />
            </yyc:SmartGridView>
    
            <%
                if (txtindex.Value != "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "topage", "window.location.hash = 'maodian_" + txtindex.Value + "';", true);
                }
            %>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
