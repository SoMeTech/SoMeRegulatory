<%@ control language="C#" autoeventwireup="true" inherits="tablepage_reprotButtonl" CodeBehind="reprotButtonl.ascx.cs"%>
  <style type="text/css">
           @media print
        {
        	
            .buttonNoPrint
            {
                display: none;         
            }
        }
    </style>
    <!--打印时隐藏滚动条-->
    <script type="text/javascript">
        function divhidden() {
            try {
                document.getElementById("div1").style.overflow = 'hidden';
            } catch (e) { }
        }
        function divshow() {
            try {
                document.getElementById("div1").style.overflow = 'auto';
            } catch (e) { }
        }
    </script>
  <script src="../jss/Main.js" type="text/javascript"></script>
 <object id="WebBrowser" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2" height="0"
            width="0">
        </object> <%--onfocus="divhidden()"--%>
        <input type="button" value="打印" onclick="divhidden(); document.all.WebBrowser.ExecWB(6, 1); divshow();" style="height:30px" class="buttonNoPrint" />
        <input type="button" value="直接打印" onclick="divhidden(); document.all.WebBrowser.ExecWB(6, 6); divshow();" style="height:30px" class="buttonNoPrint" />
        <input type="button" value="页面设置" onclick="divhidden(); document.all.WebBrowser.ExecWB(8, 1); divshow();" style="height:30px" class="buttonNoPrint" />
        <input type="button" value="打印预览" onclick="divhidden(); document.all.WebBrowser.ExecWB(7, 1); divshow();" style="height:30px" class="buttonNoPrint" />
        <input type="button" value="导出" runat="server" id="Daochu" class="buttonNoPrint" style="height:30px" />
