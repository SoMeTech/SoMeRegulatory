<%@ page language="C#" autoeventwireup="true" CodeBehind="ShowLog.aspx.cs" inherits="Work_PublicAspx_ShowLog" enableEventValidation="false" stylesheettheme="Default" %>
<%@ Register Src="~/WebControls/Buttons1.ascx" TagName="Buttons1" TagPrefix="uc1" %>
<html>
<head runat="server">
<script type="text/javascript" src="../../Ext/ext-all.js"></script>
<script type="text/javascript" src="../../Ext/adapter/ext/ext-base.js"></script>
<script type="text/javascript" src="../../Ext/resources/css/ext-all.css"></script>
    <style type="text/css">
        .tKeepAll{width:100%;border:1px solid #999;}
        .tKeepAll th{
	        word-break: keep-all;
	        white-space:nowrap;
	        border-right-width: 1px;
	        border-bottom-width: 1px;
	        border-right-style: solid;
	        border-bottom-style: solid;
	        border-right-color: #CCCCCC;
	        border-bottom-color: #CCCCCC;
        }
        .tKeepAll td{
	        word-break: keep-all;
	        white-space:nowrap;
	        border-right-width: 1px;
	        border-bottom-width: 1px;
	        border-right-style: solid;
	        border-bottom-style: solid;
	        border-right-color: #CCCCCC;
	        border-bottom-color: #CCCCCC;
        }
    </style>
    <script type="text/javascript">

        function PageSubmit(val) {
            if (val == 'ibtcontrol_ibtexit') {
                val = "";
                try {
                    window.parent.IsCloseTab();
                } catch (e) { window.close(); }
            }

        }
    </script>
</head><body >
<div id='divMain' style="position:absolute;height:600px;width:100%;overflow:auto;background:#EEEEEE;" >
<form runat="server" id="form1" onsubmit="return false;">
<uc1:Buttons1 ID="Buttons1_1" runat="server" />
            <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                ContextMenuCssClass="RightMenu" DataKeyNames="AUTOID" AllowSorting="true" CssClass="tKeepAll"
               >
                <Columns>
                <asp:BoundField DataField="AUTOID" HeaderText="AUTOID" SortExpression="AUTOID" ItemStyle-HorizontalAlign="Center" Visible="false" />
                <asp:BoundField DataField="PD_PROJECT_TYPE" HeaderText="项目类别" SortExpression="PD_PROJECT_TYPE"
                    ItemStyle-HorizontalAlign="Center"  Visible="false"/>
                <asp:BoundField DataField="PD_PROJECT_CODE" HeaderText="项目编码" SortExpression="PD_PROJECT_CODE"
                    ItemStyle-HorizontalAlign="Center"  Visible="false"/>
                <asp:BoundField DataField="MAN" HeaderText="操作人" SortExpression="MAN" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="COMPANY" HeaderText="单位" SortExpression="COMPANY" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="BM" HeaderText="部门" SortExpression="BM" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="EXE_DTIME" HeaderText="执行时间" SortExpression="EXE_DTIME"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="EXE_CZ" HeaderText="执行操作" SortExpression="EXE_CZ" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="EXE_JG" HeaderText="执行结果" SortExpression="EXE_JG" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="EXE_TXT" HeaderText="备注" SortExpression="EXE_TXT" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="FREE1" HeaderText="自定义字段1" SortExpression="FREE1" ItemStyle-HorizontalAlign="Center"  Visible="false"/>
                <asp:BoundField DataField="FREE2" HeaderText="自定义字段2" SortExpression="FREE2" ItemStyle-HorizontalAlign="Center"  Visible="false"/>
                <asp:BoundField DataField="FREE3" HeaderText="自定义字段3" SortExpression="FREE3" ItemStyle-HorizontalAlign="Center"  Visible="false"/>

                </Columns>
            </yyc:SmartGridView></form>
<div id="divHet"></div>
</div>
<script type="text/javascript">
    function GetHeight() {
        var gvResult = document.getElementById('<%=gvResult.ClientID %>');

    //document.getElementById('divHet').style.height=document.body.offsetHeight-gvResult.offsetHeight;
    document.getElementById('divMain').style.height = document.body.offsetHeight - 5;
}
setTimeout(GetHeight, 0);
</script>
</body>
</html>