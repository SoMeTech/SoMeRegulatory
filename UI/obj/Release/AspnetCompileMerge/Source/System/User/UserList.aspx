<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" CodeBehind="UserList.aspx.cs" title="Untitled Page" enableeventvalidation="false" stylesheettheme="Default" inherits="User_UserList" %>

<%@ Register Src="../../WebControls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<%@ Register Src="../../WebControls/WebOrderControl.ascx" TagName="WebOrderControl" TagPrefix="uc2" %>
<%@ MasterType VirtualPath="~/Master/One.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
            if (w > 1000) {
                var grid = document.getElementById('<%=gvResult.ClientID %>');
            grid.style.width = w;
        }
        //母版页panel宽度重定义
        var panel = document.getElementById('<%=Master.PanelID %>');
        panel.style.width = w;
    }
    </script>
    <input type="hidden" id="txtindex" runat="server" />
    <input type="hidden" id="txttitle" runat="server" />
    <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
        ContextMenuCssClass="RightMenu" Width="100%" DataKeyNames="UserPK" AllowSorting="true"
        OnRowCommand="gvResult_RowCommand" BoundRowClickCommandName="Select" BoundRowDoubleClickCommandName="Two" 
        TimeSpan="1000" OnSorting="gvResult_Sorting" >
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <HeaderStyle Width="30px" />
                <ItemTemplate>
                    <a name='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>' id='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'><%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%></a>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="用户名" SortExpression="UserName" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="labUserName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="真实姓名" SortExpression="TrueName" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="labTrueName" runat="server" Text='<%#Eval("TrueName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="职员姓名" SortExpression="eName" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="labName" runat="server" Text='<%#Eval("eName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="职员性别" SortExpression="Sex" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="labsex" runat="server" Text='<%#GetSex(DataBinder.Eval(Container, "DataItem.Sex").ToString()) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="所属单位" SortExpression="cName" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="labCompanyPK" runat="server" Text='<%#Eval("cName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="所属部门" SortExpression="bName" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="labBranchPK" runat="server" Text='<%#Eval("bName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="职员职位" SortExpression="rName" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="labRolePK" runat="server" Text='<%#Eval("rName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:ButtonField CommandName="two" Visible="False" />
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

