<%@ page language="C#" masterpagefile="~/Master/Report.master" autoeventwireup="true" inherits="Report_projDJTZ" title="项目登记台帐" enableEventValidation="false" stylesheettheme="Default" CodeBehind="projDJTZ.aspx.cs" %>
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
      <input type="hidden" id="upk"  runat="server"/>     
     &nbsp;资金性质：
      <asp:DropDownList ID="ddlxz" runat="server">        
           <asp:ListItem Value="01">项目建设资金</asp:ListItem>
       </asp:DropDownList>
     &nbsp;&nbsp;&nbsp;
     年度：<asp:TextBox ID="txtyear" runat="server"></asp:TextBox>
       &nbsp;&nbsp;   
       所属单位：<input id="txtxz" runat="server"  onclick="javascript:openwindow('../PublicMode/DiagList/XzSelect.aspx','',300,400);" />
     &nbsp;项目类别：<asp:DropDownList ID="ddllb" runat="server">
          </asp:DropDownList>
          &nbsp;&nbsp; 
       &nbsp;&nbsp;
       项目名称：<asp:TextBox ID="txtproname" runat="server" ></asp:TextBox>
&nbsp;<asp:Button ID="btnquery" runat="server" Text="查 询" OnClick="btnquery_Click" />
   
   </div>
      <br /><uc1:reprotButtonl ID="reprotButtonl1" runat="server" />
    <div class="ReportName">
        项目登记台账
    </div>
    <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
        ContextMenuCssClass="RightMenu" Width="100%" AllowSorting="true">
        <Columns>
            <asp:TemplateField>
            <HeaderTemplate>序号</HeaderTemplate>
            <ItemTemplate><%#Container.DataItemIndex+1%></ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="项目名称" DataField="项目名称" />
            <asp:BoundField HeaderText="乡镇" DataField="乡镇代码" />
            <asp:BoundField HeaderText="资金性质名称" DataField="资金性质" />
            <asp:BoundField HeaderText="项目类别" DataField="项目类别编码" />
            <asp:BoundField HeaderText="指标文件" DataField="指标文号" />
            <asp:BoundField HeaderText="补助标准" DataField="补助标准" />
            <asp:BoundField HeaderText="资金金额" DataField="资金金额" />
            <asp:BoundField HeaderText="归口部门" DataField="归口部门" />
            <asp:BoundField HeaderText="立项依据/补助依据" DataField="立项依据" />
            <asp:BoundField HeaderText="监管依据" DataField="监管依据" />
            <asp:BoundField HeaderText="监管人" DataField="监管人" />
        </Columns>
    </yyc:SmartGridView>
</asp:Content>