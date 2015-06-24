<%@ control language="C#" autoeventwireup="true" inherits="UserControls_FilePostCtr" CodeBehind="FilePostCtr.ascx.cs" %>
<script type="text/javascript">
    function getfiledName() {
        var a = document.getElementById("<%=filedNamelist.ClientID %>");
    return a;
}
function OpenBar() {

}
</script>
         <input id="filedNamelist" name="filedNamelist" type="hidden" runat="server" value="" />