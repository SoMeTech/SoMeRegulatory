<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" CodeBehind="RoleList.aspx.cs" title="Untitled Page" enableeventvalidation="false" stylesheettheme="Default" inherits="Role_RoleList" %>

<%@ MasterType VirtualPath="~/Master/One.master" %>
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
            //        if(w>1000){
            //            var grid = document.getElementById('<%=gvResult.ClientID %>');
        //            grid.style.width=w;
        //        }
        //母版页panel宽度重定义
        var panel = document.getElementById('<%=Master.PanelID %>');
        panel.style.width = w;
    }
    </script>
    
    
    <asp:DropDownList ID="ddlcompany" runat="server" Visible="false"></asp:DropDownList>
    <asp:DropDownList ID="ddlbranch" runat="server" Visible="false"></asp:DropDownList>
    <input type="hidden" id="txtindex" runat="server" />
    <input type="hidden" id="txttitle" runat="server" />
    <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
        ContextMenuCssClass="RightMenu" Width="100%" DataKeyNames="RolePK" AllowSorting="true"
        OnSorting="gvResult_Sorting" OnRowCommand="gvResult_RowCommand" BoundRowClickCommandName="Select"
        BoundRowDoubleClickCommandName="Two" >
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <HeaderStyle Width="30px" />
                <ItemTemplate>
                    <a name='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>' id='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'><%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%></a>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="编号" SortExpression="BH">
                <ItemTemplate>
                    <asp:Label ID="LbType" runat="server" Text='<%# Bind("BH") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
                <HeaderStyle HorizontalAlign="Left" Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="名称" SortExpression="Name">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
                <HeaderStyle HorizontalAlign="Left" Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="所属单位" SortExpression="pk_corp">
                <ItemTemplate>
                    <asp:Label ID="Lbpk_corp" runat="server" Text='<%# Getpk_corp(DataBinder.Eval(Container,"DataItem.pk_corp").ToString()) %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
                <HeaderStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="所属部门" SortExpression="BranchPK">
                <ItemTemplate>
                    <asp:Label ID="LbBranchPK" runat="server" Text='<%# GetBranch(DataBinder.Eval(Container,"DataItem.BranchPK").ToString()) %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
                <HeaderStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否启用" SortExpression="IsUserPower">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# SetIsUser(DataBinder.Eval(Container,"DataItem.IsUserPower").ToString()) %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="8%" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="修改" ShowHeader="False" Visible="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update"
                        Text="修改"></asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle Width="4%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除" ShowHeader="False" Visible="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="删除" OnClientClick="return confirm('确认要删除吗？');"></asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle Width="4%" />
            </asp:TemplateField>
            <asp:ButtonField CommandName="two" Visible="False" />
            <asp:ButtonField CommandName="Select" Visible="False" />
        </Columns>
        <FixRowColumn FixColumns="0,1,2" FixRows="" FixRowType="Header,Pager" />
    </yyc:SmartGridView>
    
    <%
        if (txtindex.Value != "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "topage", "window.location.hash = 'maodian_" + txtindex.Value + "';", true);
        }
    %>
    
</asp:Content>
