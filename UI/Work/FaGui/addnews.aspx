<%@ page language="C#" autoeventwireup="true" masterpagefile="~/Master/MainAddUpdate.master" inherits="addnews" CodeBehind="addnews.aspx.cs"  enableeventvalidation="false" validaterequest="false " stylesheettheme="Default" %>
<%@ MasterType VirtualPath="~/Master/MainAddUpdate.master" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="~/WebControls/UserControl/FilePostCtr.ascx" TagName="FilePostCtr" TagPrefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/fileup.css") %>"
        type="text/css" rel="stylesheet" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/fileup.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/resources/css/ext-all.css") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/adapter/ext/ext-base.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/ext-all.js") %>" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/XMGL/projSsMx.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/PublicJS.js") %>" type="text/javascript"></script>


    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jquery-1.4.2.min.js") %>"
        type="text/javascript"></script>

    <%if (!Page.IsPostBack) %>
    <%{ %>
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/Loading.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/dowaitUpdate.js") %>" type="text/javascript"></script>

    <div id="loading">
        <div class="loading-indicator">
            <img src="<%=QxRoom.Common.Public.RelativelyPath("images/extanim32.gif") %>" alt=""
                width="355" height="127" style="margin-right: 8px;" align="absmiddle" />
            Loading.....
        </div>
    </div>
    <div id="loading-mask">
    </div>
    <%} %>

    <script src="../../../Shared/jss/Check.js" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/Qx_nz.js") %>" type="text/javascript"
        charset="gb2312"></script>

    <div style="text-align: center;">
        <table width="90%" id="t1" runat="server">
            <tr>
            <td style="width:10%;"></td>
                <td>
                    <table style="text-align:left; width:100%;">
                        <tr style="height: 50px;">
                            <td style="text-align: right; width: 100px;">
                                标题：<font color="red">*</font>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtPD_PROJECT_SUBJECTS" runat="server" Style="border-color: #000000;
                                    width: 300px;  border-width: 1px;" Font-Bold="True"
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 50px;">
                            <td style="text-align: right; width: 100px;">
                                类别：<font color="red">*</font>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem Value="1">工作动态</asp:ListItem>
                                    <asp:ListItem Value="0">法律法规</asp:ListItem>
                                    <asp:ListItem Value="2">上级文件</asp:ListItem>
                                    <asp:ListItem Value="3">本级文件</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr height="50px">
                            <td style="text-align: right; width: 100px;">
                                文件上传：
                            </td>
                            <td style="text-align: left;">
                             <table>
                                <tr>
                                    <td>
                                        <div id='upfile10000' style='border: thin solid #899aa1; width: auto; height: 25px;' onmouseover="MouseOnRowIndex=10000">
                                            <div id='ShowDIV10000' class="filetxt">
                                            </div>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="fileUpArea" onmouseover="MouseOnRowIndex=10000" style="margin-bottom:-10px;">
                                            <input type="file" class="fileinput" name="filesupload" onchange="BindUpLoad(this,'zxzb_bt',0)"
                                                columnindex='0' rowindex='10000' onmouseover="MouseOnRowIndex=10000" /></div>
                                    </td>
                                </tr>
                            </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
            <td style="width:10%;"></td>
                <td>
                    <table  style="width:100%;">
                        <tr>
                            <td>
                                <fckeditorv2:fckeditor id="txtPD_PROJECT_CONTENTS" runat="server" DefaultLanguage="zh-cn" Width="100%" Height="350px"></fckeditorv2:fckeditor>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <uc1:FilePostCtr ID="FilePostCtr1" runat="server" />
    </div>
</asp:Content>