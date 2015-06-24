<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" CodeBehind="ZBList1.aspx.cs" inherits="Work_ZB_ZBList1" title="专项预算指标列表" enableEventValidation="false" stylesheettheme="Default" %>

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
                ContextMenuCssClass="RightMenu" DataKeyNames="PD_QUOTA_CODE" AllowSorting="true"
                OnSorting="gvResult_Sorting" OnRowCommand="gvResult_RowCommand" BoundRowClickCommandName="Select"
                CssClass="tKeepAll" BoundRowDoubleClickCommandName="Two"  ondblclick="gvResultClientClick()">
                <Columns>
                    <asp:TemplateField Visible="false">
                        <HeaderTemplate>
                            选择</HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="checkBox" uid='checkBox' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PD_QUOTA_CODE" HeaderText="指标编号" SortExpression="PD_QUOTA_CODE"
                        Visible="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                <%-- <asp:TemplateField HeaderText="序号">
                        <HeaderStyle Width="30px" />
                        <ItemTemplate>
                            <a name='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'
                                id='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'>
                                <%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%></a>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="编号" InsertVisible="False"> 
              <ItemStyle HorizontalAlign="Center" BackColor="#DEDEDE" Font-Size="13px" Font-Bold="true" /> 
              <HeaderStyle HorizontalAlign="Center" Width="9%"  Font-Bold="true" Font-Size="Larger" /> 
             <ItemTemplate> 
              <%#Container.DataItemIndex+1%> 
            </ItemTemplate> 
             </asp:TemplateField>
                       <asp:BoundField DataField="序号" HeaderText="序号" SortExpression="序号" Visible="false"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="pd_quota_fwdata" HeaderText="发文日期" SortExpression="pd_quota_fwdata"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="pd_quota_zbwh" HeaderText="指标文号" SortExpression="pd_quota_zbwh"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />                        
                      <asp:BoundField DataField="PD_QUOTA_PICI" HeaderText="指标批次" SortExpression="PD_QUOTA_PICI"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />  
                    <asp:BoundField DataField="PD_QUOTA_NAME" HeaderText="文件名称" SortExpression="PD_QUOTA_NAME"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />                        
                    <asp:BoundField DataField="pd_quota_zbxdzh" HeaderText="指标下达总额" SortExpression="pd_quota_zbxdzh"
                        ItemStyle-CssClass="numberLeft" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="pd_quota_money_total" HeaderText="指标额度" SortExpression="pd_quota_money_total"
                        ItemStyle-CssClass="numberLeft" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                        
                    <asp:BoundField DataField="pd_quota_depart_name" HeaderText="归口部门" SortExpression="pd_quota_depart_name"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="pd_quota_zjly_name" HeaderText="资金来源" SortExpression="pd_quota_zjly"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="pd_quota_zgkj_name" HeaderText="主管科局" SortExpression="pd_quota_zgkj"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_QUOTA_ZJXZ" HeaderText="资金性质" SortExpression="PD_QUOTA_ZJXZ"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="pd_quota_ifpass_name" HeaderText="是否传出" SortExpression="pd_quota_ifpass_name"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_QUOTA_PASS_DATE" HeaderText="传出日期" SortExpression="PD_QUOTA_PASS_DATE"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="PD_QUOTA_PASS_MAN" HeaderText="传出经办人" SortExpression="PD_QUOTA_PASS_MAN"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="pd_quota_ifllyqs_name" HeaderText="是否已接收" SortExpression="pd_quota_ifllyqs_name"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="pd_quota_accept_date" HeaderText="接收日期" SortExpression="pd_quota_accept_date"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="pd_quota_accept_man" HeaderText="接收经办人" SortExpression="pd_quota_accept_man"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="pd_quota_isup_name" HeaderText="是否已下发" SortExpression="pd_quota_isup_name"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="pd_quota_up_date" HeaderText="下发日期" SortExpression="pd_quota_up_date"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="pd_quota_up_man" HeaderText="下发经办人" SortExpression="pd_quota_up_man"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="pd_quota_ifxzqs_name" HeaderText="乡镇是否签收" SortExpression="pd_quota_ifxzqs_name"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="pd_quota_ifxzhz_name" HeaderText="乡镇是否回执" SortExpression="pd_quota_ifxzhz_name"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="pd_quota_ifsbxm_name" HeaderText="是否已申报项目" SortExpression="pd_quota_ifsbxm_name"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    
                    <asp:ButtonField CommandName="two" Visible="False" />
                    <asp:ButtonField CommandName="Select" Visible="False" />
                    
                </Columns>
            </yyc:SmartGridView>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
