<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" CodeBehind="OperationLogList.aspx.cs" enableeventvalidation="false" stylesheettheme="Default" inherits="Operation_OperationLogList" %>

<%@ MasterType VirtualPath="~/Master/One.master" %>
<%@ Register Assembly="YYControls" Namespace="YYControls" TagPrefix="yyc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if (!Page.IsPostBack) %>
    <%{ %>
    
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/Loading.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/dowait.js") %>" type="text/javascript"></script>
    
    <div id="loading">
        <div class="loading-indicator">
            <img src="<%=QxRoom.Common.Public.RelativelyPath("images/extanim32.gif") %>" alt="" width="355" height="127" style="margin-right:8px;" align="absmiddle"/>
                正在获取数据,请稍候.....
        </div>
    </div>
    <div id="loading-mask"></div>
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
            if (w > 1500) {
                var grid = document.getElementById('<%=gvOpList.ClientID %>');
            grid.style.width = w;
        }
        //母版页panel宽度重定义
        var panel = document.getElementById('<%=Master.PanelID %>');
        panel.style.width = w;
    }
    </script>
    <input type="hidden" id="txtindex" runat="server" />
    <input type="hidden" id="txttitle" runat="server" />
    <yyc:SmartGridView ID="gvOpList" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
        ContextMenuCssClass="RightMenu" Width="100%" OnRowDataBound="gvOpList_RowDataBound"
        OnRowCommand="gvOpList_RowCommand" BoundRowClickCommandName="Select" BoundRowDoubleClickCommandName="Two"
        DataKeyNames="PK" AllowSorting="True" OnSorting="gvOpList_Sorting">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <HeaderStyle Width="40px" />
                <ItemTemplate>
                    <a name='maodian_<%# this.gvOpList.PageIndex * this.gvOpList.PageSize + this.gvOpList.Rows.Count + 1%>' id='maodian_<%# this.gvOpList.PageIndex * this.gvOpList.PageSize + this.gvOpList.Rows.Count + 1%>'><%# this.gvOpList.PageIndex * this.gvOpList.PageSize + this.gvOpList.Rows.Count + 1%></a>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField Visible="False">
                <ItemTemplate>
                    <asp:Label ID="labopPk" runat="server" Text='<%#Eval("PK") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="UserName" HeaderText="操作用户" SortExpression="UserName" HeaderStyle-Width="10%"/>
            <asp:BoundField DataField="opType" HeaderText="操作性质" SortExpression="opType"  HeaderStyle-Width="5%"/>
            <asp:BoundField DataField="Business" HeaderText="操作业务" SortExpression="Business" HeaderStyle-Width="20%"/>
            
            <asp:TemplateField HeaderText="操作内容" SortExpression="Content" HeaderStyle-Width="40%">
                <ItemTemplate>
                    <asp:Label ID="lbContent" runat="server" Text='<%# QxRoom.Common.CharCheck.CutStr_New(DataBinder.Eval(Container,"DataItem.Content").ToString(), 60) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                    
            <asp:BoundField DataField="ifPass" HeaderText="是否成功" SortExpression="ifPass" Visible="false" />
            <asp:BoundField DataField="opTime" HeaderText="操作时间" SortExpression="opTime" />
            <asp:ButtonField CommandName="Two" Visible="False" />
            <asp:ButtonField CommandName="Select" Visible="False" />
        </Columns>
        <FixRowColumn FixColumns="0,1" FixRows="" FixRowType="Header,Pager" />
    </yyc:SmartGridView>
    
    <%
        if (txtindex.Value != "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "topage", "window.location.hash = 'maodian_" + txtindex.Value + "';", true);
        }
    %>
    
</asp:Content>
