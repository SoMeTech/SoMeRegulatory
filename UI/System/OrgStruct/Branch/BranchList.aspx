<%@ page language="C#" masterpagefile="~/Master/TwoO.master" autoeventwireup="true" title="Untitled Page" CodeBehind="BranchList.aspx.cs" enableeventvalidation="false" stylesheettheme="Default" inherits="Branch_BranchList" %>

<%@ Register Assembly="ExtExtenders" Namespace="ExtExtenders" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Master/TwoO.master" %>
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
            if (w > 2000) {
                var grid = document.getElementById('<%=gvResult.ClientID %>');
            grid.style.width = w;
        }
        //母版页panel宽度重定义
        var panel = document.getElementById('<%=Master.PanelID %>');
        panel.style.width = w;

        //本页副列表宽度重定义
        //window.location.reload();
        if (w > 1500) {
            var gv1 = document.getElementById('<%=gvResult1.ClientID %>');
            gv1.style.width = w;
            var gv2 = document.getElementById('<%=gvResult1.ClientID %>');
            gv2.style.width = w;
        }
        var pl2 = document.getElementById('<%=Panel2.ClientID %>');
        pl2.style.width = w;

        var tabs1 = document.getElementById('<%=TabContainer1.ClientID %>');
        //tabs1.style.clientwidth=w;
        tabs1.style.width = w;
    }
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:DropDownList ID="ddlbranch" runat="server" Visible="false">
            </asp:DropDownList>
            <input type="hidden" id="txtindex" runat="server" />
            <input type="hidden" id="txttitle" runat="server" />
            <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                RowStyle-Height="20px" ContextMenuCssClass="RightMenu" Width="100%" DataKeyNames="BranchPK"
                AllowSorting="true" HeaderStyle-Height="20px" OnRowCommand="gvResult_RowCommand"
                BoundRowClickCommandName="Select" BoundRowDoubleClickCommandName="Two" TimeSpan="1000"
                OnSorting="gvResult_Sorting" >
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <HeaderStyle Width="30px" />
                        <ItemTemplate>
                            <a name='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'
                                id='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'>
                                <%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="编号" SortExpression="BH">
                        <ItemTemplate>
                            <asp:Label ID="lbBH" runat="server" Text='<%# Bind("BH") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" Width="60px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="名称" SortExpression="Name">
                        <ItemTemplate>
                            <asp:Label ID="lbName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="所属单位" SortExpression="COMPANYNAME">
                        <ItemTemplate>
                            <asp:Label ID="lbPK_Corp_Info" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.COMPANYNAME") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="上级部门" SortExpression="FatherPK">
                        <ItemTemplate>
                            <asp:Label ID="lbFatherPK" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FatherPK") %>'
                                Visible="false"></asp:Label>
                            <asp:Label ID="lbFatherInfo" runat="server" Text='<%# GetFather(DataBinder.Eval(Container, "DataItem.FatherPK").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="负责人" SortExpression="EMPLOYEENAME">
                        <ItemTemplate>
                            <asp:Label ID="lbManager" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EMPLOYEENAME") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" Width="100px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Phone" HeaderText="联系电话" SortExpression="Phone" />
                    <asp:BoundField DataField="Fax" HeaderText="传真" SortExpression="Fax" />
                    <asp:BoundField DataField="Email" HeaderText="电子邮箱" SortExpression="Email" />
                    <asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address" />
                    <asp:ButtonField CommandName="two" Visible="False" />
                    <asp:ButtonField CommandName="Select" Visible="False" />
                </Columns>
                <FixRowColumn FixColumns="0,1,2" FixRows="" FixRowType="Header,Pager" />
            </yyc:SmartGridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%
        if (txtindex.Value != "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "topage", "window.location.hash = 'maodian_" + txtindex.Value + "';", true);
        }
    %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <cc1:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="0"
        Height="290px">
        <cc1:TabPanel ID="TabPanel1" runat="server" closable="False" HeaderText="部门职员">
            <ContentTemplate>
                <asp:Panel ID="Panel2" runat="server" Height="260px" ScrollBars="Auto" Width="100%"
                    BackColor="white">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                        <ContentTemplate>
                            <yyc:SmartGridView ID="gvResult1" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                                ContextMenuCssClass="RightMenu" Width="100%" DataKeyNames="EmployeePK" AllowSorting="true"
                                HeaderStyle-Height="20px" OnRowCommand="gvResult1_RowCommand" BoundRowClickCommandName="Select"
                                BoundRowDoubleClickCommandName="Two" TimeSpan="1000" OnSorting="gvResult1_Sorting">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderStyle Width="4%" />
                                        <ItemTemplate>
                                            <img src="../../../images/chazhao.png" onclick="javascript:window.open('../../Employee/EmployeeAdd.aspx','_blank','toolbar=no,status=no,resizable=no,width=800,height=500,scrollbars=no,left=50,top=50');"
                                                alt="新增职员信息" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="序号">
                                        <HeaderStyle Width="40px" />
                                        <ItemTemplate>
                                            <%# this.gvResult1.PageIndex * this.gvResult1.PageSize + this.gvResult1.Rows.Count + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="职员编号" SortExpression="BH" HeaderStyle-Width="60px"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="labBH" runat="server" Text='<%#Eval("BH") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="职员姓名" SortExpression="Name" HeaderStyle-Width="80px"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="labName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                            <asp:Label ID="labemppk" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.EmployeePK").ToString() %>'
                                                Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="性别" SortExpression="Sex" HeaderStyle-Width="30px"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="labsex" runat="server" Text='<%#GetSex(DataBinder.Eval(Container, "DataItem.Sex").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Age" HeaderText="年龄" SortExpression="Age" HeaderStyle-Width="30px"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="WorkAge" HeaderText="工龄" SortExpression="WorkAge" HeaderStyle-Width="30px"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
                                    <asp:TemplateField HeaderText="所属职位" SortExpression="rName" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="labRole" runat="server" Text='<%#Eval("rName") %>'></asp:Label>
                                            <asp:Label ID="labjspk" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.RolePK").ToString() %>'
                                                Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="联系电话" SortExpression="Mobile1" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="labMobile1" runat="server" Text='<%#Eval("Mobile1") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="联系地址" SortExpression="Address" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="labAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="电子邮件" SortExpression="Email" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="labEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:ButtonField CommandName="two" Visible="False" />
                                    <asp:ButtonField CommandName="Select" Visible="False" />
                                </Columns>
                                <FixRowColumn FixColumns="0,1" FixRows="" FixRowType="Header,Pager" />
                            </yyc:SmartGridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel2" runat="server" closable="False" HeaderText="部门角色" TabIndex="1">
            <ContentTemplate>
                <asp:Panel ID="Panel1" runat="server" Height="260px" ScrollBars="Auto" Width="100%"
                    BackColor="white">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional">
                        <ContentTemplate>
                            <yyc:SmartGridView ID="gvResult2" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                                ContextMenuCssClass="RightMenu" Width="100%" DataKeyNames="RolePK" AllowSorting="true"
                                HeaderStyle-Height="20px" OnRowCommand="gvResult2_RowCommand" BoundRowClickCommandName="Select"
                                BoundRowDoubleClickCommandName="Two" TimeSpan="1000" OnSorting="gvResult2_Sorting">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderStyle Width="4%" />
                                        <ItemTemplate>
                                            <img src="../../../images/chazhao.png" onclick="javascript:window.open('../Role/RoleAdd.aspx','_blank','toolbar=no,status=no,resizable=no,width=800,height=500,scrollbars=no,left=50,top=50');"
                                                alt="新增角色信息" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="序号" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <%# this.gvResult2.PageIndex * this.gvResult2.PageSize + this.gvResult2.Rows.Count + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="角色编号" SortExpression="BH">
                                        <ItemTemplate>
                                            <asp:Label ID="LbType" runat="server" Text='<%# Bind("BH") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" Width="30%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="角色名称" SortExpression="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" Width="30%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="是否启用" SortExpression="IsUserPower">
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" runat="server" Text='<%# SetIsUser(DataBinder.Eval(Container,"DataItem.IsUserPower").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="8%" />
                                    </asp:TemplateField>
                                    <asp:ButtonField CommandName="two" Visible="False" />
                                    <asp:ButtonField CommandName="Select" Visible="False" />
                                </Columns>
                                <FixRowColumn FixColumns="0,1" FixRows="" FixRowType="Header,Pager" />
                            </yyc:SmartGridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
</asp:Content>
