<%@ Page Language="C#" masterpagefile="~/Master/Report.master" EnableEventValidation = "false" AutoEventWireup="true" CodeBehind="pro.aspx.cs" Inherits="pro" %>

<%@ MasterType VirtualPath="~/Master/Report.master" %>
<%@ Register Src="~/WebControls/reprotButtonlTwo.ascx" TagName="reprotButtonlTwo" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
           @media print
        {        	
            .buttonNoPrint
            {
                display: none;         
            }
        }
       
    </style>
     <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/PublicJS.js") %>" type="text/javascript"></script>
    <script src="../jss/PulbicReport.js"></script>
    <div>
          <input type="text"  id="txtxzs" runat="server"  style="display:none"/>
      <input type="hidden" id="upk"  runat="server"/>    
         <input type="hidden" id="ibtid" name="ibtid" uid='ibtid' runat="server" /> 
<table uid='tbHead' style="width: 100%; border: 0px solid #FFFFFF;" border="0" cellpadding="0"
        cellspacing="0">
        <tr>
            <td height="50" align="center" valign="middle" style="border: 0px solid #FFFFFF;"
                colspan="1">
                <label id="tbHead" runat="server" style="width: 100%; font-size: 24px;" />
            </td>
        </tr>
        <tr>
            <td style="padding:0 0 0 37px">
                <uc1:reprotButtonlTwo ID="reprotButtonl1" runat="server" />
            </td>
        </tr>
    </table>

    </div>
<div class="ReportName">
    <div class="auto-style1">
    <span style="align-content:center" class="auto-style2"><strong>乡镇涉农专项资金使用情况表（项目类资金）</strong></span>

        
    
            </div>
     
        
    
            <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
        ContextMenuCssClass="RightMenu" Width="100%" AllowSorting="True" EnableModelValidation="True" IfUserMouseOverCssClass="False" RowDoubleClickDoed="False" TimeSpan="0" >
        <Columns>
            <asp:TemplateField>
            <HeaderTemplate>序号</HeaderTemplate>
            <ItemTemplate><%#Container.DataItemIndex+1%></ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="project_type_code" HeaderText="项目代码" Visible="true"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" />
            <asp:BoundField HeaderText="项目类别" DataField="project_type_name" Visible="true"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" />
            <asp:BoundField DataField="pd_project_money_total" HeaderText="金额" Visible="true"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" />
            <asp:BoundField DataField="PD_PROJECT_SYRS" HeaderText="受益人数" Visible="true"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" />
            <asp:BoundField DataField="PD_PROJECT_CONTENT" HeaderText="建设内容" Visible="true"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" />
        </Columns>
        </yyc:SmartGridView>
</div>
</asp:Content>