<%@ page language="C#" masterpagefile="~/Master/Report.master" autoeventwireup="true" inherits="Report_zjjgGSCT" title="资金监管股室传递信息台帐" enableEventValidation="false" stylesheettheme="Default"  CodeBehind="zjjgGSCT.aspx.cs"%>
<%@ MasterType VirtualPath="~/Master/Report.master" %>

<%@ Register Src="~/WebControls/reprotButtonl.ascx" TagName="reprotButtonl" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <uc1:reprotButtonl ID="reprotButtonl1" runat="server" />
    <div class="ReportName">
    资金监管股室传递信息台帐
    </div>
    <div>
    单位名称：<%=Bianzdw %>
    </div>
        <div>
        <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
        ContextMenuCssClass="RightMenu" Width="100%" AllowSorting="true" >
       <Columns>
            <asp:TemplateField>
            <HeaderTemplate>序号</HeaderTemplate>
            <ItemTemplate><%#Container.DataItemIndex+1%></ItemTemplate>
            </asp:TemplateField>
               <asp:BoundField HeaderText="告知科局" DataField="PD_QUOTA_ZGKJ"/>
               <asp:BoundField HeaderText="传出信息股室" DataField="PD_QUOTA_QCBM"/>
               <asp:BoundField HeaderText="上级指标文号" DataField="PD_QUOTA_ZBWH"/>         
               <asp:BoundField HeaderText="上级发文日期" DataField="PD_QUOTA_FWDATA"/>
               <asp:BoundField HeaderText="文件标题" DataField="PD_QUOTA_NAME"/>
               <asp:BoundField HeaderText="核拨额度" DataField="PD_QUOTA_MONEY_TOTAL"/>
               <asp:BoundField HeaderText="下达额度" DataField="PD_QUOTA_ZBXDZH"/>
               <asp:BoundField HeaderText="资金类别" DataField="PD_QUOTA_ZJXZ"/>
               <asp:BoundField HeaderText="资金下达方式" DataField="PD_QUOTA_ZJLY"/>
               <asp:BoundField HeaderText="告知日期" DataField="PD_QUOTA_ZBWH"/>
               <asp:BoundField HeaderText="传出股室经办人" DataField="PD_QUOTA_PASS_MAN"/>
               <asp:BoundField HeaderText="接收单位经办人" DataField="PD_QUOTA_ACCEPT_MAN"/> 
        </Columns>
        </yyc:SmartGridView>
    </div>
</asp:Content>