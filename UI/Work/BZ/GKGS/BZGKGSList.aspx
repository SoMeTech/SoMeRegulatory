<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" CodeBehind="BZGKGSList.aspx.cs" inherits="Work_BZ_GKGS_BZGKGSList" title="项目建设资金公开公示" enableEventValidation="false" stylesheettheme="Default" %>

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
             document.getElementById("ibtcontrol_ibtlook").click();
         }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <input type="hidden" id="txtindex" runat="server" />
            <input type="hidden" id="txttitle" runat="server" />
            <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                ContextMenuCssClass="RightMenu" Width="300%" DataKeyNames="PD_PROJECT_CODE" AllowSorting="true"
                OnSorting="gvResult_Sorting" OnRowCommand="gvResult_RowCommand" BoundRowClickCommandName="Select"
                CssClass="tKeepAll" BoundRowDoubleClickCommandName="Two" ondblclick="gvResultClientClick()">
                <Columns>
                    <asp:BoundField DataField="PD_PROJECT_CODE" HeaderText="项目编码" Visible="false" SortExpression="PD_PROJECT_CODE"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                                            <asp:TemplateField HeaderText="序号">
                        <HeaderStyle Width="30px" />
                        <ItemTemplate>
                            <a name='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'
                                id='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'>
                                <%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PD_PROJECT_NAME" HeaderText="项目名称" SortExpression="PD_PROJECT_NAME"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" />
                    <asp:BoundField DataField="PD_YEAR" HeaderText="项目年度" SortExpression="PD_YEAR" ItemStyle-HorizontalAlign="Center"
                        HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_TYPENAME" HeaderText="项目类别" SortExpression="PD_PROJECT_TYPE"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" />
                    <asp:BoundField DataField="ISGKGS" HeaderText="是否已公开公示" SortExpression="ISGKGS"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" />
                    <asp:BoundField DataField="PD_GK_DEPARTNAME" HeaderText="归口部门" SortExpression="PD_GK_DEPART"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_FOUND_XZNAME" HeaderText="资金性质" SortExpression="PD_FOUND_XZ"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                 
                    <asp:BoundField DataField="PD_PROJECT_IFXZGL" HeaderText="是否乡镇直接管理" SortExpression="PD_PROJECT_IFXZGL"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_IFGS" HeaderText="是否公示" SortExpression="PD_PROJECT_IFGS"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_IFGS_BEFORE" HeaderText="是否事前公示" SortExpression="PD_PROJECT_IFGS_BEFORE"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_OPEN_BODY" HeaderText="公示主体" SortExpression="PD_PROJECT_OPEN_BODY"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_FZR" HeaderText="项目负责人" SortExpression="PD_PROJECT_FZR"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_CWFZR" HeaderText="财务负责人" SortExpression="PD_PROJECT_CWFZR"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_SYHS" HeaderText="受益户数" SortExpression="PD_PROJECT_SYHS"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_SYRS" HeaderText="收益人数" SortExpression="PD_PROJECT_SYRS"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_STATUSNAME" HeaderText="项目建设状态" SortExpression="PD_PROJECT_STATUS"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" />
                    <asp:BoundField DataField="PD_PROJECT_BEGIN_DATE" HeaderText="开工日期" SortExpression="PD_PROJECT_BEGIN_DATE"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" />
                    <asp:BoundField DataField="PD_PROJECT_END_DATE" HeaderText="完工日期" SortExpression="PD_PROJECT_END_DATE"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_YEARS" HeaderText="项目建设时限" SortExpression="PD_PROJECT_YEARS"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_FILENO_LX" HeaderText="立项依据" Visible=false SortExpression="PD_PROJECT_FILENO_LX"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_FILENO_JG" HeaderText="监管依据" SortExpression="PD_PROJECT_FILENO_JG"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_INPUT_COMPANYNAME" HeaderText="项目申报单位" SortExpression="PD_PROJECT_INPUT_COMPANY"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_INPUT_MANNAME" HeaderText="项目申报经办人" SortExpression="PD_PROJECT_INPUT_MAN"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_PROJECT_INPUT_DATE" HeaderText="项目申报日期" SortExpression="PD_PROJECT_INPUT_DATE"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                           <asp:BoundField DataField="PD_PROJECT_GNFL" HeaderText="功能分类"  Visible=false SortExpression="PD_PROJECT_GNFL"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:TemplateField HeaderText="项目建设内容" SortExpression="PD_PROJECT_CONTENT" Visible=false HeaderStyle-Width="400px">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("PD_PROJECT_CONTENT").ToString().Length>30?Eval("PD_PROJECT_CONTENT").ToString().Substring(0,30)+"...":Eval("PD_PROJECT_CONTENT")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="项目用途" Visible=false SortExpression="PD_PROJECT_XMYT" HeaderStyle-Width="400px">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("PD_PROJECT_XMYT").ToString().Length>30?Eval("PD_PROJECT_XMYT").ToString().Substring(0,30)+"...":Eval("PD_PROJECT_XMYT")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField CommandName="two" Visible="False" />
                    <asp:ButtonField CommandName="Select" Visible="False" />
                </Columns>
            </yyc:SmartGridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
