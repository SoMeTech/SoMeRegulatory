<%@ page language="C#" masterpagefile="~/Master/Report.master" autoeventwireup="true" inherits="Report_zbxxJSHZ" title="乡镇财政资金指标信息接收回执" enableEventValidation="false" stylesheettheme="Default" CodeBehind="zbxxJSHZ.aspx.cs" %>
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
       <input type="text"  id="txtcids" runat="server"  style="display:none"/>
       <input type="text"  id="txtxzs" runat="server"  style="display:none"/>
        &nbsp;&nbsp; 资金性质：
       <asp:DropDownList ID="ddlxz" runat="server">        
           <asp:ListItem Value="01">项目建设资金</asp:ListItem>
           <asp:ListItem Value="02">补助性资金</asp:ListItem>
       </asp:DropDownList>
       &nbsp;&nbsp;&nbsp;年度：
       <asp:TextBox ID="txtyear" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;归口部门：           
        <input ID="txtdepart" runat="server" readonly="readonly" onclick="javascript:openwindow('../Shared/DiagList/DepaSelect.aspx','',300,400);" />          
        &nbsp;&nbsp;&nbsp;乡镇：
        <input type="text" runat="server" id="txtxz" onclick="javascript:openwindow('../Shared/DiagList/XzSelect.aspx','',300,400);" />
        &nbsp;&nbsp;&nbsp; 指标文号：<input  id="txtwh" runat="server"/>
        &nbsp;&nbsp; 文件名称：<input id="txtname" runat="server" />
        &nbsp;
           <asp:Button ID="btnQuery" runat="server" Text="查询" onclick="btnQuery_Click" />
       </div><br />
        <uc1:reprotButtonl ID="reprotButtonl1" runat="server" />
    <div class="ReportName">
    乡镇财政资金指标信息接收回执
    </div>   
    <div style=" padding-left:10px; padding-right:10px;">
     <div>
    <table style=" width:97%;"><tr><td>乡镇名称（盖章）：</td><td>接收时间：<%=DateTime.Now.ToString("yyyy年MM月dd日") %></td></tr></table>
    </div>
        <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
        ContextMenuCssClass="RightMenu" Width="100%" AllowSorting="true" >
        <Columns>
            <asp:TemplateField>
            <HeaderTemplate>序号</HeaderTemplate>
            <ItemTemplate><%#Container.DataItemIndex+1%></ItemTemplate>
            </asp:TemplateField>
        <asp:BoundField HeaderText="文件名称" DataField="文件名称"/>
        <asp:BoundField HeaderText="来文机关" DataField="来文机关"/>
        <asp:BoundField HeaderText="文件字号" DataField="文件字号"/>
        <asp:TemplateField>
        <HeaderTemplate>
        <div>乡镇接收人</div>
        <div>签  字</div>
        </HeaderTemplate>
        <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%#Bind("乡镇接收人签字")%>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="监管要求" DataField="监管要求"/>
        </Columns>
        </yyc:SmartGridView>
    </div>
</asp:Content>