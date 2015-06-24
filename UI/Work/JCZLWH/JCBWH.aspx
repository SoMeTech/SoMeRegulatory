<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" CodeBehind="JCBWH.aspx.cs" inherits="Work_JCZLWH_JCBWH" title="专项预算指标列表" enableEventValidation="false" stylesheettheme="Default" %>

<%@ MasterType VirtualPath="~/Master/One.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .numberLeft
        {
            text-align: right;
        }
        input[type="CheckBox"]
        {
            height: 20px;
            width: 20px;
            margin: 0;
            padding: 0;
        }
        .newTable 
        {
        	background:#EFEFEF;
            border-color:#EFEFEF;
        	}
        .newTable  td
        {
         background-color:#EFEFEF;
        	}
         .newTable input[type="submit"]
         {
          margin:0 atuo;
         	}
       
        
    </style>
    <%if (!Page.IsPostBack) %>
    <%{ %>
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/Loading.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/dowait.js") %>" type="text/javascript"></script>

    <div id="loading">
        <div class="loading-indicator">
            <img src="<%=QxRoom.Common.Public.RelativelyPath("images/extanim32.gif") %>" alt=""
                width="355" height="127" style="margin-right: 8px;" align="absmiddle" />
            正在获取数据,请稍候.....
        </div>
    </div>
    <div id="loading-mask">
    </div>
    <%} %>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jquery-1.4.2.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function gvResultClientClick() {
            document.getElementById("ibtcontrol_ibtdo").click();
        }

        function getTable(rowIndex) {
            var tablb = document.getElementById("<%=tabLB.ClientID %>");
         var tbName = tablb.options[tablb.selectedIndex].innerText;
         //alert(tbName);
         var tab = document.getElementById("tb");
         var rows = tab.rows.length;
         //alert(rows);
         var strs = "";
         for (var i = 0; i < rows - 1; i++) {
             var cols = tab.rows[i].childNodes;
             if (strs == "") {
                 strs = strs + cols[0].innerText + "|" + cols[1].childNodes[0].value;
             }
             else {
                 strs = strs + "|" + cols[0].innerText + "|" + cols[1].childNodes[0].value;
             }
         }
         //alert(strs);
         //document.getElementById("strs").value=strs;
         //alert(rowIndex);
         //var gdview=document.getElementById("<%=gvResult.ClientID %>");
         var gvResult = document.getElementById("<%=gvResult.ClientID %>");
         var reStrs = "";
         for (var j = 0; j < gvResult.rows[rowIndex].cells.length; j++) {
             if (reStrs == "") {
                 var reStrs = reStrs + gvResult.rows[rowIndex].cells[j].innerText;
             }
             else {
                 var reStrs = reStrs + "|" + gvResult.rows[rowIndex].cells[j].innerText;
             }

         }
         $.ajax({
             type: "Post",
             url: "JCBWH.aspx/GetData",
             datatype: "json",
             data: "{'data':'" + strs + "','redata':'" + reStrs + "','tabName':'" + tbName + "'}",
             contentType: "application/json; charset=utf-8",
             success: function (data) {
                 alert("编辑成功！");
             },
             error: function (err) {
                 alert("数据输入有误，添加失败!");
             }
         });
     }
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <input type="hidden" id="txtindex" runat="server" />
            <input type="hidden" id="txttitle" runat="server" />
            <div style="height: 38px; background-color: #F4F4F4; margin-bottom: 2px; margin-top: 1px;">
                <table>
                    <tr style="line-height: 34px;">
                        <td style="font-size: 12px; font-weight: bolder;">
                            选择基础表：
                        </td>
                        <td>
                            <asp:DropDownList ID="tabLB" runat="server" Width="600px" OnSelectedIndexChanged="selectChg"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
<%--                <yyc:SmartGridView ID="gvResult" runat="server" MouseOverCssClass="OverRow" ContextMenuCssClass="RightMenu"
                    BoundRowClickCommandName="Select" CssClass="tKeepAll" BoundRowDoubleClickCommandName="Two"
                    ondblclick="gvResultClientClick()">
                    <Columns>
                        <asp:ButtonField CommandName="two" Visible="False" />
                        <asp:ButtonField CommandName="Select" Visible="False" />
                    </Columns>
                </yyc:SmartGridView>--%>
            </div>
            <div style="z-index: 88889999; width:0; height: auto;
                position: relative; top: 20px; left: 30%" runat="server" id="divEdit">
                
            </div>
             <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                ContextMenuCssClass="RightMenu" DataKeyNames="TABNAME" AllowSorting="true" 
                OnSorting="gvResult_Sorting" OnRowCommand="gvResult_RowCommand" 
                CssClass="tKeepAll" BoundRowDoubleClickCommandName="Two"  ondblclick="gvResultClientClick()">
                <Columns>
                    <asp:TemplateField HeaderText="序号" InsertVisible="False"> 
              <ItemStyle HorizontalAlign="Center" BackColor="#7386AE" Font-Size="13px" Font-Bold="true" /> 
              <HeaderStyle HorizontalAlign="Center" Width="5%"  Font-Bold="true" Font-Size="Larger" BackColor="#7386AE" /> 
             <ItemTemplate> 
              <%#Container.DataItemIndex+1%> 
            </ItemTemplate> 
             </asp:TemplateField>
             <asp:TemplateField HeaderText="是否修改">
                            <ItemTemplate>
                                             <asp:CheckBox ID="RowSelectorEdit" runat="server" GroupName="SuppliersGroup"/>
                          
                           </ItemTemplate>
                           <HeaderStyle HorizontalAlign="center" Width="6%" BackColor="#7386AE"/>
                           <ItemStyle HorizontalAlign="center" />
             </asp:TemplateField> 
            <asp:BoundField HeaderText="物理表名" DataField="TABNAME" HeaderStyle-BackColor="#7386AE" ItemStyle-HorizontalAlign="left"/>
             <asp:BoundField HeaderText="数据表表名称" DataField="NAMEZW" HeaderStyle-BackColor="#7386AE" ItemStyle-HorizontalAlign="center"/>
             <asp:TemplateField HeaderText="数据表名称">
                            <ItemTemplate>
                                             <asp:TextBox ID="RowSelectorZW" runat="server" GroupName="SuppliersGroup" Width="220px"/>
                          
                           </ItemTemplate>
                           <HeaderStyle HorizontalAlign="center" Width="30%" BackColor="#7386AE"/>
                           <ItemStyle HorizontalAlign="center" />
             </asp:TemplateField> 
             <asp:BoundField HeaderText="ISJCB" DataField="ISJCB" HeaderStyle-BackColor="#7386AE" ItemStyle-HorizontalAlign="left"  />
                  <asp:TemplateField HeaderText="是否基础表">
                            <ItemTemplate>
                                             <asp:CheckBox ID="RowSelector" runat="server" GroupName="SuppliersGroup" />
                          
                           </ItemTemplate>
                           <HeaderStyle HorizontalAlign="center" Width="15%" BackColor="#7386AE"/>
                           <ItemStyle HorizontalAlign="center" />
             </asp:TemplateField> 
             <asp:BoundField HeaderText="ISYWB" DataField="ISYWB" HeaderStyle-BackColor="#7386AE" ItemStyle-HorizontalAlign="left" />
              <asp:TemplateField HeaderText="是否业务表">
                            <ItemTemplate>
                                             <asp:CheckBox ID="RowSelector2" runat="server" GroupName="SuppliersGroup"/>
                          
                           </ItemTemplate>
                           <HeaderStyle HorizontalAlign="center" Width="15%" BackColor="#7386AE"/>
                           <ItemStyle HorizontalAlign="center" />
             </asp:TemplateField> 
                    <asp:ButtonField CommandName="two" Visible="False" />
                    <asp:ButtonField CommandName="Select" Visible="False" />
                </Columns>
            </yyc:SmartGridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

