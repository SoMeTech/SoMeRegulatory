<%@ control language="C#" autoeventwireup="true" inherits="manager_PageControl" CodeBehind="PageControl.ascx.cs" %>
<div>
    <asp:Label ID="lblPageCount" CssClass="menutext" runat="server"></asp:Label>&nbsp;
    <asp:Label ID="lblCurrentIndex" CssClass="menutext" runat="server"></asp:Label>&nbsp;
    <asp:LinkButton ID="btnFirst" CssClass="menutext" OnClick="PagerButtonClick"  CommandArgument="0">首页</asp:LinkButton>&nbsp; 
    <asp:LinkButton ID="btnPrev" CssClass="menutext" OnClick="PagerButtonClick"   CommandArgument="prev">前一页</asp:LinkButton>&nbsp;
    <asp:LinkButton ID="btnNext" CssClass="menutext" OnClick="PagerButtonClick"   CommandArgument="next">下一页</asp:LinkButton>&nbsp;
    <asp:LinkButton ID="btnLast" CssClass="menutext" OnClick="PagerButtonClick"   CommandArgument="last">末页</asp:LinkButton>
</div>

