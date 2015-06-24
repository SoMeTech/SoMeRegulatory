<%@ page language="C#" autoeventwireup="true" masterpagefile="~/Master/Report.master" title="项目抽查巡查台账" inherits="Report_projCCXCTZ" enableEventValidation="false" stylesheettheme="Default"  CodeBehind="projCCXCTZ.aspx.cs"%>
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


    
       function findwindow(val,obj)
       {       var  year=document.getElementById("<%=ddlyear.ClientID %>").value; 
               var webFileUrl = "../PublicMode/DiagList/GetSession.aspx?tn="+val+"&year="+year;              
               var _xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
               _xmlhttp.open("POST", webFileUrl, false);
               _xmlhttp.send("");
    　　		
               var arr = window.showModalDialog("../PublicMode/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
		     
		       if (arr != null&&arr != "false")
		       {
                    if (arr.indexOf("~")>0)
                    {
	                    ss=arr.split("~");
	                    document.getElementById("<%=hcode.ClientID %>").value=ss[0];
	                    document.getElementById("<%=txtproname.ClientID %>").value=ss[1];                       
                       
                    }
		       }
	 }	
    </script>    
     <div class="buttonNoPrint">  
    <input type="hidden" id="hcode"  runat="server"/>
      <input type="hidden" id="upk"  runat="server"/>     
     <input type="text"  id="txtxzs" runat="server"  style="display:none"/>
     &nbsp;&nbsp;
     年度：<asp:DropDownList ID="ddlyear" runat="server">
       </asp:DropDownList>   
       &nbsp;&nbsp;   
      单位：<input  runat="server"  id="txtxz" onclick="javascript:openwindow('../PublicMode/DiagList/XzSelect.aspx','',300,400);" />
     &nbsp;&nbsp;
       项目名称：<asp:TextBox ID="txtproname" runat="server"></asp:TextBox>
   &nbsp;项目过程：
      <asp:DropDownList ID="ddlproc" runat="server" Width="100px">          
           <asp:ListItem Value="事前">事前</asp:ListItem>       
           <asp:ListItem Value="事中">事中</asp:ListItem>     
           <asp:ListItem Value="事后">事后</asp:ListItem>  
       </asp:DropDownList>  
  &nbsp;<asp:Button ID="btnquery" runat="server" Text="查 询" onclick="btnquery_Click" />   
   </div>
     <br />
        <uc1:reprotButtonl ID="reprotButtonl1" runat="server" />
    <div class="ReportName">
    项目抽查巡查台账
    </div>  
        <div style=" padding-left:10px;">
        <div>
        单位名称：
    </div>
     <div style="height:700px; overflow-y:scroll;">
        <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
        ContextMenuCssClass="RightMenu" Width="98%" AllowSorting="true" >
       <Columns>
            <asp:TemplateField>
            <HeaderTemplate>序号</HeaderTemplate>
            <ItemTemplate><%#Container.DataItemIndex+1%></ItemTemplate>
            </asp:TemplateField>
               <asp:BoundField HeaderText="项目编码" DataField="PD_PROJECT_CODE"/>
               <asp:BoundField HeaderText="项目名称" DataField="pd_project_name"/>
               <asp:BoundField HeaderText="项目过程" DataField="PD_INSPECTION_PROCESS"/>         
               <asp:BoundField HeaderText="监管时间" DataField="PD_INSPECTION_DATE"/>
               <asp:BoundField HeaderText="监管人员" DataField="PD_INSPECTION_MANS"/>
               <asp:BoundField HeaderText="监管地点" DataField="PD_INSPECTION_ADDR"/>
               <asp:BoundField HeaderText="项目进度完成比例" DataField="PD_MONITOR_PROCEED_WCL"/>
               <asp:BoundField HeaderText="项目总投资额" DataField="PD_PROJECT_TOTAL_MONEY"/>
               <asp:BoundField HeaderText="累计拨付总金额" DataField="PD_MONITOR_TOTAL_MONEY_PAY"/>
               <asp:BoundField HeaderText="总投资完成比例" DataField="PD_MONITOR_TOTAL_MONEY_WCL"/>
               <asp:BoundField HeaderText="监管内容" DataField="PD_INSPECTION_CONTENT"/>
               <asp:BoundField HeaderText="监管意见" DataField="PD_INSPECTION_SUGGEST"/> 
               <asp:BoundField HeaderText="监管结论" DataField="PD_INSPECTION_CONCLUSION"/> 
               <asp:BoundField HeaderText="监管资料" DataField="PD_INSPECTION_FILENAME"/>
        </Columns>
        </yyc:SmartGridView>
   </div>
    </div>
</asp:Content>
