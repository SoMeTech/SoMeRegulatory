<%@ control language="C#" autoeventwireup="true" inherits="WebControls_Buttons1" CodeBehind="Buttons1.ascx.cs" %>

<script language="JavaScript">
    function document.onkeydown(){
        if(event.keyCode==81 && event.ctrlKey)
        {
            document.getElementById("ibtcontrol_ibtadd").click();//新增(ctrl+q)
        }
        if(event.keyCode==69 && event.ctrlKey)
        {
            document.getElementById("ibtcontrol_ibtupdate").click();//修改(ctrl+e)
        }
        if(event.keyCode==83 && event.ctrlKey)
        {
            document.getElementById("ibtcontrol_ibtsave").click();//保存(ctrl+s)
        }
        if(event.keyCode==68 && event.ctrlKey)
        {
            document.getElementById("ibtcontrol_ibtdelete").click();//删除(ctrl+d)
        }
        if(event.keyCode==71 && event.ctrlKey)
        {
            document.getElementById("ibtcontrol_ibtrefresh").click();//数据刷新(ctrl+g)
        }
        if(event.keyCode==27)
        {
            document.getElementById("ibtcontrol_ibtexit").click();//退出(esc)
        }
    }
</script>
 
<!--[if lt IE 7]>
<script type="text/javascript" src="../jquery.easyui/ie_png.js"></script>
<script type="text/javascript">
	 ie_png.fix('.png, div img, #contacts-form input, #contacts-form textarea');
</script>
<![endif]-->
<input type="reset" style="display: none" id="canel" />
<div runat="server" align="left" id="divbutton" style="background-image: url(~/images/new/backBar2.png); background-position:top; background-repeat:no-repeat; padding-bottom:5px;">
</div>
