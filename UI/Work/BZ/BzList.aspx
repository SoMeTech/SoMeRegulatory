<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" CodeBehind="BzList.aspx.cs" inherits="Work_BZ_projBzList" title="无标题页" enableEventValidation="false" stylesheettheme="Default" %>

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
         function gvResultClientClick() {
             document.getElementById("ibtcontrol_ibtdo").click();
         }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <input type="hidden" id="txtindex" runat="server" />
            <input type="hidden" id="txttitle" runat="server" />
            <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                ContextMenuCssClass="RightMenu" Width="300%" DataKeyNames="PD_PROJECT_CODE" AllowSorting="true"
                OnSorting="gvResult_Sorting" OnRowCommand="gvResult_RowCommand" BoundRowClickCommandName="Select"
                CssClass="tKeepAll" BoundRowDoubleClickCommandName="Two"   ondblclick="gvResultClientClick()">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <HeaderStyle Width="30px" />
                        <ItemTemplate>
                            <a name='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'
                                id='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'>
                                <%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PD_QUOTA_ZBWH" HeaderText="指标文号" SortExpression="PD_QUOTA_ZBWH"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_CODE" HeaderText="项目编码" SortExpression="PD_PROJECT_CODE"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" Visible="false" />
                    <asp:BoundField DataField="PD_PROJECT_NAME" HeaderText="项目名称" SortExpression="PD_PROJECT_NAME"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" />
                    <asp:BoundField DataField="PD_YEAR" HeaderText="项目年度" SortExpression="PD_YEAR" ItemStyle-HorizontalAlign="Center"
                        HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="pd_project_typeName" HeaderText="项目类别" SortExpression="pd_project_typeName"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" />
                    <asp:BoundField DataField="PD_GK_DEPARTNAME" HeaderText="归口部门编码" SortExpression="PD_GK_DEPART_ID"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_FOUND_XZNAME" HeaderText="资金性质" SortExpression="PD_FOUND_XZ"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_IFGS" HeaderText="是否公示" SortExpression="PD_PROJECT_IFGS"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_IFGS_BEFORE" HeaderText="是否事前公示" SortExpression="PD_PROJECT_IFGS_BEFORE"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_OPEN_BODY" HeaderText="公示主体" SortExpression="PD_PROJECT_OPEN_BODY"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="pd_project_statusName" HeaderText="项目建设状态" SortExpression="pd_project_statusName"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_FILENO_JG" HeaderText="监管依据" SortExpression="PD_PROJECT_FILENO_JG"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="pd_project_input_companyName" HeaderText="项目申报单位" SortExpression="pd_project_input_companyName"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_INPUT_MAN" HeaderText="项目申报经办人" SortExpression="PD_PROJECT_INPUT_MAN"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" />
                    <asp:BoundField DataField="PD_PROJECT_INPUT_DATE" HeaderText="项目申报日期" SortExpression="PD_PROJECT_INPUT_DATE"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" />
                    <asp:BoundField DataField="PD_PROJECT_BZYJ" HeaderText="补助依据" SortExpression="PD_PROJECT_BZYJ"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_BZFW" HeaderText="补助范围" SortExpression="PD_PROJECT_BZFW"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_BZDX" HeaderText="补助对象" SortExpression="PD_PROJECT_BZDX"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_BZNUM" HeaderText="补助数量" SortExpression="PD_PROJECT_BZNUM"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_BZSTAND_NUM" HeaderText="补助标准" SortExpression="PD_PROJECT_BZSTAND_NUM"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_BZMONEY" HeaderText="补助金额" SortExpression="PD_PROJECT_BZMONEY"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_BZFF_DATE" HeaderText="要求发放时间" SortExpression="PD_PROJECT_BZFF_DATE"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_SJFF_DATE" HeaderText="实际发放时间" SortExpression="PD_PROJECT_SJFF_DATE"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_IFFF" HeaderText="是否一卡通发放" SortExpression="PD_PROJECT_IFFF"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_JGYQ" HeaderText="监管要求" SortExpression="PD_PROJECT_JGYQ"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_JGJL" HeaderText="监管记录" SortExpression="PD_PROJECT_JGJL"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_JG_RESULT" HeaderText="监管结论" SortExpression="PD_PROJECT_JG_RESULT"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:ButtonField CommandName="two" Visible="False" />
                    <asp:ButtonField CommandName="Select" Visible="False" />
                </Columns>
            </yyc:SmartGridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
