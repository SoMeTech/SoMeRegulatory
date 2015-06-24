<%@ page language="C#" masterpagefile="~/Master/TwoO.master" autoeventwireup="true" CodeBehind="CompanyList.aspx.cs" title="Untitled Page" enableeventvalidation="false" stylesheettheme="Default" inherits="Company_CompanyList" %>

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
            RefreshPage();
        }

        //菜单打开
        function menuExpand(w) {
            setWidth(w);
            RefreshPage();
        }

        function setWidth(w) {
            //alert(w);

            //列表宽度重定义
            if (w > 3200) {
                var grid = document.getElementById('<%=gvResult.ClientID %>');
                grid.style.width = w;
            }
            //母版页panel宽度重定义
            var panel = document.getElementById('<%=Master.PanelID %>');
            panel.style.width = w;

            //本页副列表宽度重定义
            //window.location.reload();
            if (w > 1200) {
                var gv1 = document.getElementById('<%=gvResult_child_employee.ClientID %>');
                gv1.style.width = w;
                var gv2 = document.getElementById('<%=gvResult_child_bank.ClientID %>');
                gv2.style.width = w;
            }
            var pl1 = document.getElementById('<%=Panel1.ClientID %>');
            pl1.style.width = w;
            var pl2 = document.getElementById('<%=Panel2.ClientID %>');
            pl2.style.width = w;

            var tp1 = document.getElementById('<%=TabPanel1.ClientID %>');
            tp1.style.width = w;
            var tp2 = document.getElementById('<%=TabPanel2.ClientID %>');
            tp2.style.width = w;

            var tabs1 = document.getElementById('<%=TabContainer1.ClientID %>');
            //tabs1.style.clientwidth=w;
            tabs1.style.width = w;
        }
    </script>

    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <input type="hidden" id="txtindex" runat="server" />
            <input type="hidden" id="txttitle" runat="server" />
            <yyc:SmartGridView ID="gvResult" runat="server" Width="3500px" OnSorting="gvResult_Sorting"
                TimeSpan="1000" BoundRowDoubleClickCommandName="two" BoundRowClickCommandName="Select"
                OnRowCommand="gvResult_RowCommand" RowStyle-Height="20px" HeaderStyle-Height="20px"
                AllowSorting="true" DataKeyNames="pk_corp" MouseOverCssClass="OverRow" AutoGenerateColumns="False"
                ContextMenuCssClass="RightMenu" RowStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <HeaderStyle Width="40px" />
                        <ItemTemplate>
                            <a name='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'
                                id='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'>
                                <%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="pk_corp" HeaderText="单位编号" SortExpression="pk_corp" />
                    <asp:BoundField DataField="Name" HeaderText="单位名称" SortExpression="Name" ItemStyle-Width="350px" />
                    <asp:BoundField DataField="ShortName" HeaderText="简称" SortExpression="ShortName" />
                    <asp:BoundField DataField="Country" HeaderText="所属国家" SortExpression="Country" />
                    <asp:BoundField DataField="Province" HeaderText="省份" SortExpression="Province" />
                    <asp:BoundField DataField="Area" HeaderText="地区" SortExpression="Area" />
                    <asp:BoundField DataField="Address" HeaderText="详细地址" SortExpression="Address" ItemStyle-Width="500px" />
                    <asp:BoundField DataField="PostalCode" HeaderText="邮政编码" SortExpression="PostalCode" />
                    <asp:BoundField DataField="Url" HeaderText="网址" SortExpression="Url" />
                    <asp:BoundField DataField="Email1" HeaderText="电子邮箱1" SortExpression="Email1" />
                    <asp:BoundField DataField="Email2" HeaderText="电子邮箱2" SortExpression="Email2" />
                    <asp:BoundField DataField="Email3" HeaderText="电子邮箱3" SortExpression="Email3" />
                    <asp:BoundField DataField="Phone1" HeaderText="联系电话1" SortExpression="Phone1" />
                    <asp:BoundField DataField="Phone2" HeaderText="联系电话2" SortExpression="Phone2" />
                    <asp:BoundField DataField="Phone3" HeaderText="联系电话3" SortExpression="Phone3" />
                    <asp:BoundField DataField="Fax1" HeaderText="传真1" SortExpression="Fax1" />
                    <asp:BoundField DataField="Fax2" HeaderText="传真2" SortExpression="Fax2" />
                    <asp:BoundField DataField="Fax3" HeaderText="传真3" SortExpression="Fax3" />
                    <asp:BoundField DataField="linkman1" HeaderText="联系人1" SortExpression="linkman1" />
                    <asp:BoundField DataField="linkman2" HeaderText="联系人2" SortExpression="linkman2" />
                    <asp:BoundField DataField="Holder" HeaderText="法人代表" SortExpression="Holder" />
                    <asp:TemplateField HeaderText="注册资金" SortExpression="RegMoney">
                        <ItemTemplate>
                            <asp:Label ID="lbRegMoney" runat="server" Text='<%# Common.Money_CutString(DataBinder.Eval(Container, "DataItem.RegMoney")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="FPDWM" HeaderText="发票单位名" SortExpression="FPDWM" />
                    <asp:BoundField DataField="InvoiceType" HeaderText="发票类型" SortExpression="InvoiceType" />
                    <asp:BoundField DataField="DutyNum" HeaderText="单位税号" SortExpression="DutyNum" />
                    <asp:ButtonField CommandName="two" Visible="False" />
                    <asp:ButtonField CommandName="Select" Visible="False" />
                </Columns>
                <FixRowColumn FixColumns="0,1" FixRows="" FixRowType="Header,Pager" />
            </yyc:SmartGridView>
            <asp:Button ID="btsx" runat="server" Text="1234" Visible="false" OnClick="btsx_Click">
            </asp:Button>
            <input type="hidden" id="txttj" name="txttj" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <%
        if (txtindex.Value != "")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "topage", "window.location.hash = 'maodian_" + txtindex.Value + "';", true);
        }
    %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <cc1:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="2"
        Height="290px">
        <cc1:TabPanel ID="TabPanel1" runat="server" closable="False" HeaderText="单位部门">
            <ContentTemplate>
                <asp:Panel ID="Panel1" runat="server" Height="260px" ScrollBars="Auto" Width="100%"
                    BackColor="white">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                        <ContentTemplate>
                            <input type="hidden" id="txtindex1" runat="server" />
                            <asp:DropDownList ID="ddlbranch" runat="server" Visible="false">
                            </asp:DropDownList>
                            <yyc:SmartGridView ID="gvResult_child_employee" runat="server" AutoGenerateColumns="False"
                                MouseOverCssClass="OverRow" ContextMenuCssClass="RightMenu" Width="100%" DataKeyNames="BranchPK"
                                HeaderStyle-Height="20px" TimeSpan="1000">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderStyle Width="4%" />
                                        <ItemTemplate>
                                            <img src="../../../images/chazhao.png" onclick="javascript:window.open('../Branch/BranchAdd.aspx','_blank','toolbar=no,status=no,resizable=no,width=700,height=500,scrollbars=no,left=150,top=150');"
                                                alt="新增部门信息" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="序号">
                                        <HeaderStyle Width="40px" />
                                        <ItemTemplate>
                                            <%# this.gvResult_child_employee.PageIndex * this.gvResult_child_employee.PageSize + this.gvResult_child_employee.Rows.Count + 1%>
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
                                </Columns>
                                <FixRowColumn FixColumns="0,1" FixRows="" FixRowType="Header,Pager" />
                            </yyc:SmartGridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel2" runat="server" closable="False" HeaderText="单位职员">
            <ContentTemplate>
                <asp:Panel ID="Panel2" runat="server" Height="260px" ScrollBars="Auto" Width="100%"
                    BackColor="white">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel4" UpdateMode="Conditional">
                        <ContentTemplate>
                            <yyc:SmartGridView ID="gv_Employee" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                                ContextMenuCssClass="RightMenu" Width="100%" DataKeyNames="EmployeePK" OnRowDataBound="gv_Employee_RowDataBound">
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
                                            <a name='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'
                                                id='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'>
                                                <%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%></a>
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
                                            <asp:Label ID="labsex" runat="server" Text='<%#Common.Str_GetSex(DataBinder.Eval(Container, "DataItem.Sex").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Age" HeaderText="年龄" SortExpression="Age" HeaderStyle-Width="30px"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="WorkAge" HeaderText="工龄" SortExpression="WorkAge" HeaderStyle-Width="30px"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
                                    <asp:TemplateField HeaderText="所属单位" SortExpression="cName" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="labCompany" runat="server" Text='<%#Eval("cName") %>'></asp:Label>
                                            <asp:Label ID="labgspk" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.pk_corp").ToString() %>'
                                                Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="所属部门" SortExpression="bName" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="labBranch" runat="server" Text='<%#Eval("bName") %>'></asp:Label>
                                            <asp:Label ID="labbmpk" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.BranchPK").ToString() %>'
                                                Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="职员职位" SortExpression="rName" ItemStyle-HorizontalAlign="Left"
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
                                </Columns>
                                <FixRowColumn FixColumns="0,1,2,3" FixRows="" FixRowType="Header,Pager" />
                            </yyc:SmartGridView>
                            <%
                                if (txtindex.Value != "")
                                {
                                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "topage", "window.location.hash = 'maodian_" + txtindex.Value + "';", true);
                                }
                            %>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel3" runat="server" closable="False" HeaderText="账套信息">
            <ContentTemplate>
                <asp:Panel ID="Panel3" runat="server" Height="260px" ScrollBars="Auto" Width="100%"
                    BackColor="white">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                        <ContentTemplate>
                            <yyc:SmartGridView ID="gvResult_child_bank" runat="server" AutoGenerateColumns="False"
                                MouseOverCssClass="OverRow" ContextMenuCssClass="RightMenu" Width="100%" DataKeyNames="BankPK"
                                HeaderStyle-Height="20px" TimeSpan="1000">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderStyle Width="4%" />
                                        <ItemTemplate>
                                            <img src="../../../images/chazhao.png" onclick="javascript:window.open('newBankInfo.aspx','_blank','toolbar=no,status=no,resizable=no,width=800,height=400,scrollbars=no,left=250,top=150');"
                                                alt="新增帐户信息" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="序号">
                                        <HeaderStyle Width="40px" />
                                        <ItemTemplate>
                                            <%# this.gvResult_child_bank.PageIndex * this.gvResult_child_bank.PageSize + this.gvResult_child_bank.Rows.Count + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="BankName" HeaderText="开户行" SortExpression="BankName" />
                                    <asp:BoundField DataField="BankNum" HeaderText="开户行账号" SortExpression="BankNum" />
                                    <asp:BoundField DataField="BankNumMan" HeaderText="账户所有人" SortExpression="BankNumMan" />
                                    <asp:BoundField DataField="Discription" HeaderText="备注" SortExpression="Discription" />
                                </Columns>
                                <FixRowColumn FixColumns="0,1" FixRows="" FixRowType="Header,Pager" />
                            </yyc:SmartGridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
    <%--<script type="text/javascript">
        function dolistchange(val)
        {
            //Company_CompanyList.ShowData(val);
            //txttj.value = val;
            //<%=txttj.ClientID %>.value = val;
            //alert(<%=txttj.ClientID %>.value);
            //<%=btsx.ClientID %>.OnClick();
        }
    </script>--%>
</asp:Content>
