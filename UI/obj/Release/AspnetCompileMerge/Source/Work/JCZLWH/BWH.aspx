<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" CodeBehind="BWH.aspx.cs" inherits="Work_JCZLWH_BWH" title="专项预算指标列表" enableEventValidation="false" stylesheettheme="Default" %>

<%@ MasterType VirtualPath="~/Master/One.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .numberLeft
        {
            text-align: right;
        }
        input[type="CheckBox"]
        {
            height: 20px;
            width: 20px;
            margin:0;
            padding:0;
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
                ContextMenuCssClass="RightMenu" DataKeyNames="TABNAME" AllowSorting="true" 
                OnSorting="gvResult_Sorting" OnRowCommand="gvResult_RowCommand" 
                CssClass="tKeepAll" BoundRowDoubleClickCommandName="Two"  ondblclick="gvResultClientClick()">
                <Columns>
                    <asp:TemplateField HeaderText="序号" InsertVisible="False"> 
              <ItemStyle HorizontalAlign="Center" BackColor="#7386AE" Font-Size="13.5px" Font-Bold="true" /> 
              <HeaderStyle HorizontalAlign="Center" Width="5%"  Font-Bold="true" Font-Size="13.5px" BackColor="#7386AE" /> 
             <ItemTemplate> 
              <%#Container.DataItemIndex+1%> 
            </ItemTemplate> 
             </asp:TemplateField>
             <asp:TemplateField HeaderText="是否修改">
                            <ItemTemplate>
                                             <asp:CheckBox ID="RowSelectorEdit" runat="server" GroupName="SuppliersGroup"/>
                          
                           </ItemTemplate>
                           <HeaderStyle HorizontalAlign="center" Width="6%" BackColor="#7386AE"/>
                           <ItemStyle HorizontalAlign="center" />
             </asp:TemplateField> 
            <asp:BoundField HeaderText="物理表名(不可修改)" DataField="TABNAME" HeaderStyle-BackColor="#7386AE" ItemStyle-HorizontalAlign="left" HeaderStyle-Font-Size="13.5px"/>
             <asp:BoundField HeaderText="数据表表名称(可修改)" DataField="NAMEZW" HeaderStyle-BackColor="#7386AE" ItemStyle-HorizontalAlign="center" HeaderStyle-Font-Size="13.5px"/>
             <asp:TemplateField HeaderText="数据表名称(可修改)">
                            <ItemTemplate>
                                             <asp:TextBox ID="RowSelectorZW" runat="server" GroupName="SuppliersGroup" Width="220px" BorderStyle="None" BackColor="Transparent"/>
                          
                           </ItemTemplate>
                           <HeaderStyle HorizontalAlign="center" Width="30%" BackColor="#7386AE" Font-Size="13.5px"/>
                           <ItemStyle HorizontalAlign="center" />
             </asp:TemplateField> 
             <asp:BoundField HeaderText="ISJCB" DataField="ISJCB" HeaderStyle-BackColor="#7386AE" ItemStyle-HorizontalAlign="left"  />
                  <asp:TemplateField HeaderText="是否基础表(可修改)">
                            <ItemTemplate>
                                             <asp:CheckBox ID="RowSelector" runat="server" GroupName="SuppliersGroup" />
                          
                           </ItemTemplate>
                           <HeaderStyle HorizontalAlign="center" Width="15%" BackColor="#7386AE" Font-Size="13.5px"/>
                           <ItemStyle HorizontalAlign="center" />
             </asp:TemplateField> 
             <asp:BoundField HeaderText="ISYWB" DataField="ISYWB" HeaderStyle-BackColor="#7386AE" ItemStyle-HorizontalAlign="left" />
              <asp:TemplateField HeaderText="是否业务表(可修改)">
                            <ItemTemplate>
                                             <asp:CheckBox ID="RowSelector2" runat="server" GroupName="SuppliersGroup"/>
                          
                           </ItemTemplate>
                           <HeaderStyle HorizontalAlign="center" Width="15%" BackColor="#7386AE" Font-Size="13.5px"/>
                           <ItemStyle HorizontalAlign="center" />
             </asp:TemplateField> 
                    <asp:ButtonField CommandName="two" Visible="False" />
                    <asp:ButtonField CommandName="Select" Visible="False" />
                </Columns>
            </yyc:SmartGridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
