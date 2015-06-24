<%@ control language="C#" autoeventwireup="true" inherits="WebControls_TextboxButtonControl" CodeBehind="TextboxButtonControl.ascx.cs"%>

<script>
    function tb_mouseover(obj) {
        obj.style.backgroundColor = '#fff09e';
    }
    function tb_mouseout(obj) {
        obj.style.backgroundColor = '#fff';
    }

</script>

<script>
<!--
    function resizeImage(ImgD, w, h) {
        //图片按比例缩放
        var flag = false;
        function tempfunction() {
            var image = new Image();
            var iwidth = w; //定义允许图片宽度，当宽度大于这个值时等比例缩小
            var iheight = h; //定义允许图片高度，当宽度大于这个值时等比例缩小
            image.src = ImgD.src;
            if (image.width > 0 && image.height > 0) {
                flag = false;
                if (image.width / image.height >= iwidth / iheight) {
                    if (image.width > iwidth) {
                        ImgD.width = iwidth;
                        ImgD.height = (image.height * iwidth) / image.width;
                    } else {
                        ImgD.width = image.width;
                        ImgD.height = image.height;
                    }

                }
                else {
                    if (image.height > iheight) {
                        ImgD.height = iheight;
                        ImgD.width = (image.width * iheight) / image.height;
                    } else {
                        ImgD.width = image.width;
                        ImgD.height = image.height;
                    }
                }
            }
            ImgD.style.top = (h - ImgD.height) / 2 + "px";
            ImgD.style.left = (w - ImgD.width) / 2 + "px";
        }
        tempfunction();
    }
    //-->
</script>

<style type="text/css">
    ul li
    {
        margin: 0;
        padding: 0;
    }
    ul
    {
        list-style: none;
    }
    ul li
    {
    }
    ul li a
    {
        width: 100px;
        height: 100px;
        border: 1px solid #ccc;
        display: block;
        position: relative;
    }
    ul li img
    {
        border: 0;
        position: absolute;
    }
</style>
<table style="border: 1px solid #555; height: 18px; word-break: keep-all;"
    border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="height: 14px;">
            <input name="TextBox1" type="text" id="TextBox1" style="height: 14px; width: 132px;
                border: 1px solid #fff;" />
        </td>
        <td onmouseover="tb_mouseover(this)" onmouseout="tb_mouseout(this)" style="background-color: #fff;">
            &nbsp;<img name="ImageButton1" id="ImageButton1" src="./Image/Cal.png" style="cursor: hand;" />&nbsp;
        </td>
    </tr>
</table>
