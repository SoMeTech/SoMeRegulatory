<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" CodeBehind="NDJZ.aspx.cs" Inherits="Work_JCZLWH_NDJZ" title="无标题页" enableEventValidation="false" stylesheettheme="Default" %>

<%@ MasterType VirtualPath="~/Master/One.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (!Page.IsPostBack) %>
    <%{ %>
    
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/Loading.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/dowait.js") %>" type="text/javascript"></script>
    
    <div id="loading">
        <div class="loading-indicator">
            <img src="<%=QxRoom.Common.Public.RelativelyPath("images/extanim32.gif") %>" alt="" width="355" height="127" style="margin-right:8px;" align="absmiddle"/>
                正在获取数据,请稍候.....
        </div>
    </div>
    <div id="loading-mask"></div>
    <%} %>
    <script type="text/javascript">
        function gvResultClientClick() {
            document.getElementById("ibtcontrol_ibtdo").click();
        }
        function IfCheck() {
            var checknum = 0;
            var checkobj = document.getElementsByTagName("CheckBox");
            alert(checkobj);

        }
    </script>
      <asp:GridView ID="GridView" runat="server"  Width="100%" CellPadding="4" >

            </asp:GridView>
   
        <table>
        <tr>
        <td style="width:300px">
            <input type="hidden" id="txtindex" runat="server" />
            <input type="hidden" id="txttitle" runat="server" /> 
            <div style="border: thin solid #8db2e3; margin-top: 15px; margin-left: 10px; margin-right: 5px;">
            <p style="margin-top: -8px; margin-left: 15px; background-color: White; width: 120px; font-size:12px; font-weight:bolder">
                数据表选择：</p>
            <asp:Panel ID="Panel_Left" runat="server" Height="470px" ScrollBars="auto" Width="725px">  
            <asp:GridView ID="gvResult" runat="server"  CellPadding="4" AutoGenerateColumns="false" Width="700px" >
            <Columns>
            <asp:TemplateField HeaderText="序号" InsertVisible="False"> 
              <ItemStyle HorizontalAlign="Center" BackColor="#7386AE" Font-Size="13px" Font-Bold="true" /> 
              <HeaderStyle HorizontalAlign="Center" Width="9%" BackColor="#7386AE" Font-Bold="true" Font-Size="Larger" /> 
             <ItemTemplate> 
              <%#Container.DataItemIndex+1%> 
            </ItemTemplate> 
            </asp:TemplateField>

               <asp:TemplateField HeaderText="选择">
                            <ItemTemplate>
                                             <asp:CheckBox ID="RowSelector" runat="server" GroupName="SuppliersGroup"/>
                          
                           </ItemTemplate>
                           <HeaderStyle HorizontalAlign="center" Width="8%" BackColor="#7386AE"/>
                           <ItemStyle HorizontalAlign="center" />
             </asp:TemplateField> 
            <asp:BoundField HeaderText="数据表表名称" DataField="TABLE_NAME" HeaderStyle-BackColor="#7386AE" ItemStyle-HorizontalAlign="left"/>
            <asp:BoundField HeaderText="年度字段" DataField="COLUMN_NAME" HeaderStyle-BackColor="#7386AE" ItemStyle-HorizontalAlign="left" />
            </Columns>
            <RowStyle Font-Size="55px" />
            <HeaderStyle Font-Size="13px" Height="25px" />
            </asp:GridView>
            </asp:Panel>
            </div>
            </td>
            <td style="width:200px">
            <div style="border: thin solid #8db2e3; margin-top: 15px; margin-left: 10px; margin-right: 5px;">
            <p style="margin-top: -8px; margin-left: 15px; background-color: White; width: 120px; font-size:12px; font-weight:bolder">
                年度选择：</p>
             <asp:Panel ID="Panel_right" runat="server" Height="470px" ScrollBars="auto" Width="340px">
             <table style="margin-left:50px; margin-top:50px; line-height:30px">
             <tr>
             <td style=" font-size:12px; font-weight:bolder">源年度</td>
             </tr>
             <tr>
             <td>
                 <asp:DropDownList ID="year1" runat="server" Width="170px" Height="24px"></asp:DropDownList>
             </td>
             </tr>
             <tr>
             <td style="font-size:12px; font-weight:bolder">目标年度：</td>
             </tr>
             <tr>
             <td>
                 <asp:DropDownList ID="year2" runat="server" Width="170px" Height="24px"></asp:DropDownList>
             </td>
             </tr>
             <tr >
             <td style="height:60px;">
                 <asp:Button ID="Button1" runat="server" Text="结 转" Width="80px" Font-Size=13px 
                     Font-Bold=true Enabled="True" onclick="Button1_Click" /></td>
             </tr>
             <tr>
             <td>
                 <asp:TextBox ID="TextBox1" runat="server" Rows="0" TextMode="MultiLine"  style="margin-top:27px;" Height="150px" Width="220px" BorderStyle="None" ForeColor="Red" Font-Size="16px"></asp:TextBox>
             </td>
             </tr>
               <tr>
             <td style="">
                 <asp:Button ID="Button2" runat="server" Text="确 定" Width="80px" Font-Size=13px 
                     Font-Bold="true" Font-Italic="False" onclick="Button2_Click" /></td>
             </tr>
             </table>
             </asp:Panel>
            </div>
            </td>
            </tr>
          </table>
        
</asp:Content>

