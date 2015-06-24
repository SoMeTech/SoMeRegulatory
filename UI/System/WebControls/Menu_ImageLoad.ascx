<%@ control language="C#" autoeventwireup="true" enableviewstate="true" inherits="Menu_ImageLoad" CodeBehind="Menu_ImageLoad.ascx.cs" %>
<script type="text/javascript">
    function img_change()
    {
        if (event.propertyName=="value")
        {
            if (document.forms.item(0).<%=Fu.ClientID %>.value!="")
	    {
	        document.forms.item(0).<%= Img.ClientID%>.src=document.forms.item(0).<%=Fu.ClientID %>.value;
	    }
    }
}

function setimgsize()
{
    if (document.forms.item(0).<%=Img.ClientID %>.width>150)
    {
        var imgwidth=document.forms.item(0).<%=Img.ClientID %>.width;
	    var imgheight=document.forms.item(0).<%=Img.ClientID %>.height;
	    document.forms.item(0).<%=Img.ClientID %>.width=150;
	    document.forms.item(0).<%=Img.ClientID %>.height=imgheight*(150/imgwidth);
	    if (document.forms.item(0).<%=Img.ClientID %>.height>150)
	    {
	        document.forms.item(0).<%=Img.ClientID %>.height=150;
		    document.forms.item(0).<%=Img.ClientID %>.width=imgwidth*(150/imgheight);
		}
    }
    if (document.forms.item(0).<%=Img.ClientID %>.height>150)
    {
        var imgwidth=document.forms.item(0).<%=Img.ClientID %>.width;
	    var imgheight=document.forms.item(0).<%=Img.ClientID %>.height;
	    document.forms.item(0).<%=Img.ClientID %>.height=150;
	    document.forms.item(0).<%=Img.ClientID %>.width=imgwidth*(150/imgheight);
	    if (document.forms.item(0).<%=Img.ClientID %>.width>150)
	    {
	        document.forms.item(0).<%=Img.ClientID %>.width=150;
		    document.forms.item(0).<%=Img.ClientID %>.height=imgheight*(150/imgwidth);
		}
    }
}

function img_sel()
{
    var re_val = window.showModalDialog('<%= QxRoom.Common.Public.RelativelyPath("System/webcontrols/Menu_imagesshow.aspx") %>?filepath=<%= ImagePath%>', window, 'dialogWidth:650px; dialogHeight:450px;resizable:0; help:0; scroll:yes; status:0');
    if (re_val!="")
    {
        document.forms.item(0).<%= Img.ClientID%>.src="<%= VirtualCatalog%>"+re_val;
        setimgsize();
        document.forms.item(0).<%= TxtImg.ClientID %>.value=re_val;
    }
}
</script>
<table>
    <tr>
        <td>
            <asp:FileUpload ID="Fu" runat="server" Width="434px"/>
            </td>
        <td rowspan="2">
            <asp:Image ID="Img" runat="server" /></td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="TxtImg" runat="server" ReadOnly="True" Width="300px"></asp:TextBox>
            <input id="Button1" type="button" value="从服务器上选择图片" 
                onclick="javascript:img_sel()" style="width: 135px"/></td>
    </tr>
    </table>
