<%@ page language="C#" autoeventwireup="true" inherits="Report_proGKGS" masterpagefile="~/Master/Report.master" title="公开公示栏" enableEventValidation="false" stylesheettheme="Default" CodeBehind="proGKGS.aspx.cs" %>

<%@ Register Src="~/WebControls/reprotButtonl.ascx" TagName="reprotButtonl" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
               var xz=document.getElementById("<%=ddlxz.ClientID %>").value;  
               var webFileUrl = "../PublicMode/DiagList/GetSession.aspx?tn="+val+"&year="+year+"&xz="+xz;              
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
   <div>     
   <input type="text"  id="txtcids" runat="server"  style="display:none"/>
    <input type="hidden" id="hcode"  runat="server"/>
     &nbsp;资金性质：
      <asp:DropDownList ID="ddlxz" runat="server">
           <asp:ListItem Value="0">==请选择==</asp:ListItem>
           <asp:ListItem Value="01">项目建设资金</asp:ListItem>
           <asp:ListItem Value="02">补助性资金</asp:ListItem>
       </asp:DropDownList>
     &nbsp;&nbsp;&nbsp;
     年度：<asp:DropDownList ID="ddlyear" runat="server">
       </asp:DropDownList>   
       &nbsp;&nbsp;   
       所属乡镇：<input id="txtxz" runat="server"  onclick="javascript:openwindow('../PublicMode/DiagList/XzSelect.aspx','',500,400);" />
     &nbsp;&nbsp;&nbsp; 项目过程：<asp:DropDownList ID="ddlprocess" runat="server">
           <asp:ListItem Value="0">==请选择==</asp:ListItem>
           <asp:ListItem Value="1">事前</asp:ListItem>
           <asp:ListItem Value="2">事中</asp:ListItem>
           <asp:ListItem Value="3">事后</asp:ListItem>
       </asp:DropDownList>
       &nbsp;&nbsp;
       项目名称：<asp:TextBox ID="txtproname" runat="server" ReadOnly="true" onclick="javascript:findwindow('proj_bianma1',this);"></asp:TextBox>
&nbsp;<asp:Button ID="btnquery" runat="server" Text="查 询" onclick="btnquery_Click" />
   
   </div>
    <div id="div1" style="position: absolute; z-index: 2; overflow: auto; ">
      <br /><uc1:reprotButtonl ID="reprotButtonl1" runat="server" />
    <div class="ReportName">
     项目过程公开公示栏
    </div>
    <table style="width:100%;">
    <tr>
    <td style="text-align:right;">单位：元</td>
    </tr>
    </table>
    <div>
    
            <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
        ContextMenuCssClass="RightMenu" Width="100%" AllowSorting="true" >
        <Columns>
        <asp:TemplateField>
        <HeaderTemplate>序号</HeaderTemplate>
        <ItemTemplate><%#Container.DataItemIndex+1%></ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="资金来源" DataField="资金来源"/>
        <asp:BoundField HeaderText="项目建设地点" DataField="项目建设地点"/>
        <asp:BoundField HeaderText="资金额度" DataField="资金额度"/>
        <asp:BoundField HeaderText="受益人数" DataField="受益人数"/>
        <asp:BoundField HeaderText="计划开工日期" DataField="计划开工日期"/>
        <asp:BoundField HeaderText="计划完工日期" DataField="计划完工日期"/>
        <asp:BoundField HeaderText="承建单位" DataField="承建单位"/>
        <asp:BoundField HeaderText="合同金额" DataField="合同金额"/>
        <asp:BoundField HeaderText="开工日期" DataField="开工日期"/>
        <asp:BoundField HeaderText="完工日期" DataField="完工日期"/>
        <asp:BoundField HeaderText="竣工日期" DataField="竣工日期"/>
        <asp:BoundField HeaderText="验收日期" DataField="验收日期"/>      
        </Columns>
        </yyc:SmartGridView>
    </div>
    </div>
</asp:Content>
