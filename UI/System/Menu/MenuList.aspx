<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" CodeBehind="MenuList.aspx.cs" title="Untitled Page" enableeventvalidation="false" stylesheettheme="Default" inherits="Menu_MenuList" %>

<%@ MasterType VirtualPath="~/Master/One.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            if (w > 1200) {
                var grid = document.getElementById('<%=gvResult.ClientID %>');
            grid.style.width = w;
        }
        //母版页panel宽度重定义
        var panel = document.getElementById('<%=Master.PanelID %>');
        panel.style.width = w;
    }
    </script>

    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="ddlgl" runat="server" Visible="false">
            </asp:DropDownList>
            <input type="hidden" id="txtindex" runat="server" />
            <input type="hidden" id="txttitle" runat="server" />
            <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                ContextMenuCssClass="RightMenu" Width="100%" DataKeyNames="MemuPK" AllowSorting="true"
                 OnRowCommand="gvResult_RowCommand" BoundRowClickCommandName="Select"
                BoundRowDoubleClickCommandName="two" OnSorting="gvResult_Sorting">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <HeaderStyle Width="3%" />
                        <ItemTemplate>
                            <a name='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>' id='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'><%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="名称" SortExpression="MenuName">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("MenuName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" Width="12%" />
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("MenuName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="菜单类型" SortExpression="MenuType">
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtType" runat="server" Text='<%# Bind("MenuType") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" Width="8%" />
                        <ItemTemplate>
                            <asp:Label ID="LbType" runat="server" Text='<%# SetType(DataBinder.Eval(Container,"DataItem.MenuType").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="等级" SortExpression="Grade">
                        <HeaderStyle Width="4%" />
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Grade") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="上级名称" SortExpression="FatherPK">
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" Width="10%" />
                        <ItemTemplate>
                            <asp:Label ID="Label10" runat="server" Text='<%# GetFather(DataBinder.Eval(Container, "DataItem.FatherPK").ToString()) %>'></asp:Label>
                            <asp:Label Visible="false" ID="lbFatherPK" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.FatherPK").ToString() %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="子项" SortExpression="IsHasBaby">
                        <HeaderStyle Width="4%" />
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# SetIsHasBaby(DataBinder.Eval(Container,"DataItem.IsHasBaby").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="权限状态" SortExpression="IsCheckPower">
                        <HeaderStyle Width="8%" />
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# SetIsCheckPower(DataBinder.Eval(Container,"DataItem.IsCheckPower").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="显示" SortExpression="IsShow">
                        <HeaderStyle Width="6%" />
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# SetShow(DataBinder.Eval(Container,"DataItem.IsShow").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="排序" SortExpression="OrderBy">
                        <HeaderStyle Width="4%" />
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("OrderBy") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="权限编码" SortExpression="PowerCode">
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                            <asp:Label ID="LabelPowerCode" runat="server" Text='<%# Bind("PowerCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <%--<asp:TemplateField HeaderText="选择" ShowHeader="False" Visible="False">
                        <itemstyle cssclass="none" />
                        <HeaderStyle Width="4%" cssclass="none" />
                        <ItemTemplate>
                            <asp:LinkButton ID="SelectButton" runat="server" Display="None" CausesValidation="False" CommandName="Select"
                                Text="选择"></asp:LinkButton>
                        </ItemTemplate>
                        <footerstyle cssclass="none" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="修改" ShowHeader="False" Visible="False">
                        <HeaderStyle Width="4%" />
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update"
                                Text="修改"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="删除" ShowHeader="False" Visible="False">
                        <HeaderStyle Width="4%" />
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                                Text="删除" OnClientClick="return confirm('确认要删除吗？');"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    
                    <asp:ButtonField CommandName="two" Visible="False" />
                    <asp:ButtonField CommandName="Select" Visible="False" />
                </Columns>
                <FixRowColumn FixColumns="0,1" FixRows="" FixRowType="Header,Pager" />
                <%--<HeaderStyle CssClass="Freezing"/>--%>
            </yyc:SmartGridView>
            
            <%
                if (txtindex.Value != "")
                {
                    //lbname.Text = "锚点 " + txtindex.Value;
                    //ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "topage", "alert('锚点 " + txtindex.Value + "');window.location.hash = 'maodian_" + txtindex.Value + "';", true);
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "topage", "window.location.hash = 'maodian_" + txtindex.Value + "';", true);
                }
            %>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
