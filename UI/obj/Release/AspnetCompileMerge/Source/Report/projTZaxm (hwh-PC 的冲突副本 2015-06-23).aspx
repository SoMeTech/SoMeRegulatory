<%@ page language="C#" masterpagefile="~/Master/Report.master" autoeventwireup="true" inherits="Report_projTZaxm" title="项目建设资金监管台账（按项目）" enableEventValidation="false" stylesheettheme="Default" CodeBehind="projTZaxm.aspx.cs"%>
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
      <div>  
      <input type="hidden" id="upk"  runat="server"/>
        <input type="text"  id="txtxzs" runat="server"  style="display:none"/>
     &nbsp;资金性质：
      <asp:DropDownList ID="ddlxz" runat="server">        
           <asp:ListItem Value="01">项目建设资金</asp:ListItem>
       </asp:DropDownList>
     &nbsp;&nbsp;&nbsp;
     年度： <asp:TextBox ID="txtyear" runat="server"></asp:TextBox>
       &nbsp;&nbsp;   
       所属单位：<input type="text" runat="server" id="txtxz" onclick="javascript:openwindow('../PublicMode/DiagList/XzSelect.aspx','',300,400);" />
     &nbsp;项目类别：<asp:DropDownList ID="ddllb" runat="server">
          </asp:DropDownList>
          &nbsp;&nbsp; 
       &nbsp;&nbsp;
       项目名称：<asp:TextBox ID="txtproname" runat="server" ></asp:TextBox>
&nbsp;<asp:Button ID="btnquery" runat="server" Text="查 询" OnClick="btnquery_Click" />
   
   </div> 
      <br />  <uc1:reprotButtonl ID="reprotButtonl1" runat="server" />
   <input type="hidden" runat="server" id="hcorp" />
    <div class="ReportName">
    项目建设资金监管台账（按项目）
    </div>
    <table style="width:100%;"><tr><td>登记责任人：</td><td></td>
    <td style="text-align:left; width:200px">所长审核签字：</td>
    </tr><tr><td></td>
    
    <td ></td><td></td>
    </tr></table>
    
            <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
        ContextMenuCssClass="RightMenu" Width="100%" AllowSorting="true" >
        <Columns>
            <asp:TemplateField>
            <HeaderTemplate>序号</HeaderTemplate>
            <ItemTemplate><%#Container.DataItemIndex+1%></ItemTemplate>
            </asp:TemplateField>
        <asp:BoundField HeaderText="合同类型" DataField="合同类型"/>
        <asp:BoundField HeaderText="合同编号" DataField="合同编号"/>
        <asp:BoundField HeaderText="合同签约单位" DataField="合同签约单位"/>
        <asp:BoundField HeaderText="合同金额" DataField="合同金额"/>
        <asp:BoundField HeaderText="拨付时间" DataField="拨付时间"/>
        <asp:BoundField HeaderText="拨付类型" DataField="拨付类型"/>
        <asp:BoundField HeaderText="支出功能分类" DataField="支出功能分类"/>
        <asp:BoundField HeaderText="拨付方式" DataField="拨付方式"/>
        <asp:BoundField HeaderText="凭证号" DataField="凭证号"/>
        <asp:BoundField HeaderText="本次拨付金额" DataField="本次拨付金额"/>
        <asp:BoundField HeaderText="累计拨付金额" DataField="累计拨付金额"/>
        <asp:BoundField HeaderText="拨付资金比例" DataField="拨付资金比例"/>
        </Columns>
        </yyc:SmartGridView>
</asp:Content>