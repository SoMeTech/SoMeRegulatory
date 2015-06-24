<%@ page language="C#" masterpagefile="~/Master/Report.master" autoeventwireup="true" inherits="Report_zjffQD" title="财政补助性资金发放清册" enableEventValidation="false" stylesheettheme="Default" CodeBehind="zjffQD.aspx.cs" %>
<%@ MasterType VirtualPath="~/Master/Report.master" %>
<%@ Register Src="~/WebControls/reprotButtonl.ascx" TagName="reprotButtonl" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <br />
        <uc1:reprotButtonl ID="reprotButtonl1" runat="server" />
    <div class="ReportName">
    财政补助性资金发放清册
    </div>
    <table style="width:100%;"><tr><td style="text-align:right; width:60px;">编制单位:</td>
    <td style="text-align:left;"><%=Bianzdw %></td>
    <td><%=DateTime.Now.ToString("yyyy年MM月dd日") %></td>
    <td></td>
    <td></td>
    <td style="text-align:right;">单位：元、亩</td>
    </tr></table>
    <div>
            <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
        ContextMenuCssClass="RightMenu" Width="100%" AllowSorting="true" >
        <Columns>
        <asp:BoundField HeaderText="农 户 代 码" DataField="农户代码"/>
        <asp:BoundField HeaderText="农户姓名" DataField="农户姓名"/>
        <asp:BoundField HeaderText="身 份 证 号 码" DataField="身份证号码"/>
        <asp:BoundField HeaderText="补贴数量" DataField="补贴数量"/>
        <asp:BoundField HeaderText="补贴标准" DataField="补贴标准"/>
        <asp:BoundField HeaderText="补贴金额" DataField="补贴金额"/>
        <asp:BoundField HeaderText="发 放 账 号" DataField="发放账号"/>
        <asp:BoundField HeaderText="家 庭 地 址" DataField="家庭地址"/>        
        </Columns>
        </yyc:SmartGridView>
<script type="text/javascript">

       function findwindow(val,obj)
       {
               var webFileUrl = "/PublicMode/DiagList/GetSession.aspx?tn="+val;
               //alert(webFileUrl);
               //var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
               var _xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
               _xmlhttp.open("POST", webFileUrl, false);
               _xmlhttp.send("");
    　　		
               var arr = window.showModalDialog("/PublicMode/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
		       //alert(arr);
		       if (arr != null&&arr != "false")
		       {
                    if (arr.indexOf("~")>0)
                    {
	                    ss=arr.split("~");
	                    obj.value=ss[0];
                    }
		       }
	 }
</script>
</asp:Content>