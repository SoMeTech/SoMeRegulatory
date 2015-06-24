    <%@ page language="C#" masterpagefile="~/Master/Report.master" autoeventwireup="true" inherits="Report_projTZ" title="财政资金项目台帐" enableEventValidation="false" stylesheettheme="Default" CodeBehind="projTZ.aspx.cs" %>
<%@ MasterType VirtualPath="~/Master/Report.master" %>

<%@ Register Src="~/WebControls/reprotButtonl.ascx" TagName="reprotButtonl" TagPrefix="uc1" %>
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
     <script type="text/javascript">    
   function openwindow(url,name,iWidth,iHeight)
{
var url; //转向网页的地址;
var name; //网页名称，可为空;
var iWidth; //弹出窗口的宽度;
var iHeight; //弹出窗口的高度;
var iTop = (window.screen.availHeight-30-iHeight)/2; //获得窗口的垂直位置;
var iLeft = (window.screen.availWidth-10-iWidth)/2; //获得窗口的水平位置;
window.open(url,name,'height='+iHeight+',,innerHeight='+iHeight+',width='+iWidth+',innerWidth='+iWidth+',top='+iTop+',left='+iLeft+',toolbar=no,menubar=no,scrollbars=auto,resizeable=no,location=no,status=no');
} 
      
    </script>
  
   <div class="buttonNoPrint">     
     <input type="text"  id="txtxzs" runat="server"  style="display:none"/>
    <input type="text"  id="txtcids" runat="server"  style="display:none"/>
    <input type="hidden" id="hcode"  runat="server"/>
      <input type="hidden" id="upk"  runat="server"/>     
     &nbsp;资金性质：
      <asp:DropDownList ID="ddlxz" runat="server">          
           <asp:ListItem Value="01">项目建设资金</asp:ListItem>       
       </asp:DropDownList>
     &nbsp;&nbsp;&nbsp;
     年度：
      <asp:TextBox ID="txtyear" runat="server"></asp:TextBox>
       &nbsp;&nbsp;   
      单位：<input id="txtxz" runat="server"  onclick="javascript:openwindow('../PublicMode/DiagList/XzSelect.aspx','',300,400);" />
     &nbsp;&nbsp;
       项目名称：<asp:TextBox ID="txtproname" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnquery" runat="server" Text="查 询" onclick="btnquery_Click" />   
   </div>   
    <div id="div1" style="position: absolute; z-index: 2; overflow: auto; ">
      <br />
        <uc1:reprotButtonl ID="reprotButtonl1" runat="server" />  
    <div style=" padding-left:10px; padding-right:10px;">
      <div class="ReportName">
    财政资金项目台帐
    </div>
    <table style="width:100%;"><tr>
    <td style="text-align:right;">单位：元</td>
    </tr></table>
            <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
        ContextMenuCssClass="RightMenu" Width="98%" AllowSorting="true" >
        <Columns>
        <asp:TemplateField>
        <HeaderTemplate>序号</HeaderTemplate>
        <ItemTemplate><%#Container.DataItemIndex+1%></ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="项目名称" DataField="项目名称"/>
        <asp:BoundField HeaderText="项目地址" DataField="项目地址"/>
        <asp:BoundField HeaderText="总投资" DataField="总投资"/>
        <asp:BoundField HeaderText="财政投入-小计" DataField="财政投入_小计"/>
        <asp:BoundField HeaderText="财政投入-上级财政资金" DataField="财政投入_上级财政资金"/>
        <asp:BoundField HeaderText="财政投入-本级财政资金" DataField="财政投入_本级财政资金"/>
        <asp:BoundField HeaderText="财政所监管责任人" DataField="财政所监管责任人"/>
        <asp:BoundField HeaderText="施工单位或责任人" DataField="施工单位或责任人"/>
        <asp:BoundField HeaderText="使用单位及责任人" DataField="使用单位及责任人"/>
        <asp:BoundField HeaderText="开工日期" DataField="开工日期"/>
        <asp:BoundField HeaderText="竣工日期" DataField="竣工日期"/>
        <asp:BoundField HeaderText="验收日期" DataField="验收日期"/>
        <asp:BoundField HeaderText="验收责任人" DataField="验收责任人"/>
        </Columns>
        </yyc:SmartGridView>
    </div>
    </div>
</asp:Content>