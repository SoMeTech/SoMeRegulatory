<%@ page language="C#" autoeventwireup="true" CodeBehind="DepaSelect.aspx.cs" inherits="Shared_DiagList_DepaSelect" enableEventValidation="false" stylesheettheme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="../../jss/jquery-1.4.2.min.js" type="text/javascript"></script>
    <title>归口部门选择</title>
<script>
    $(document).ready(function () {
        $("input[type='checkbox']").click(function () {

            var cname = "";
            var cids = "";
            $("input[type='checkbox']").each(function () {
                if ($(this).attr("checked")) {
                    cname += $(this).attr("name") + ",";
                    cids += $(this).val() + ",";
                }


            });
            window.opener.document.getElementById("ctl00_ContentPlaceHolder1_txtcids").value = cids.toString().substring(0, cids.length - 1);
            window.opener.document.getElementById("ctl00_ContentPlaceHolder1_txtdepart").value = cname.toString().substring(0, cname.length - 1);
        });

    });
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin:0 auto; padding-left:30px"> 
        <asp:Label ID="lblcont" runat="server" ></asp:Label>
    </div>
    </form>
</body>
</html>

