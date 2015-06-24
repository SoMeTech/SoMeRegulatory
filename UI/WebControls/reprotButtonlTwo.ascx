<%@ control language="C#" autoeventwireup="true" inherits="tablepage_reprotButtonlTwo" CodeBehind="reprotButtonlTwo.ascx.cs" %>
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
                CallDivHidden()
            } catch (e) { }
        }
        function divshow() {
            try {
                CallDivShow();
            } catch (e) { }
        }


        function pagesetup_null() {
            var hkey_root, hkey_path, hkey_key
            hkey_root = "HKEY_CURRENT_USER"
            hkey_path = "\\Software\\Microsoft\\Internet Explorer\\PageSetup\\"
            //设置网页打印的页眉页脚为空
            try {
                var RegWsh = new ActiveXObject("WScript.Shell")
                hkey_key = "header"
                RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "")
                hkey_key = "footer"
                RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "")

                hkey_key = "margin_top";//注册表中的0.75对应于网页的19.05
                RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "0.75");
                hkey_key = "margin_bottom";//注册表中的0.75对应于网页的19.05
                RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "0.75");
                hkey_key = "margin_left";//注册表中的0.75对应于网页的19.05
                RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "0.75");
                hkey_key = "margin_right";//注册表中的0.75对应于网页的19.05
                RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "0.75");
            } catch (e) { alert(e); }
        }
        pagesetup_null();
    </script>
 <object id="WebBrowser" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2" height="0"
            width="0">
        </object> <%--onfocus="divhidden()"--%>
        <input type="button" value="打印" onclick="divhidden(); document.all.WebBrowser.ExecWB(6, 1); divshow();" style="height:30px" class="buttonNoPrint" />
        <input type="button" value="直接打印" onclick="divhidden(); document.all.WebBrowser.ExecWB(6, 6); divshow();" style="height:30px" class="buttonNoPrint" />
        <input type="button" value="页面设置" onclick="divhidden(); document.all.WebBrowser.ExecWB(8, 1); divshow();" style="height:30px" class="buttonNoPrint" />
        <input type="button" value="打印预览" onclick="divhidden(); document.all.WebBrowser.ExecWB(7, 1); divshow();" style="height:30px" class="buttonNoPrint" />
        <input type="button" value="导出Excel" runat="server" id="Daochu" class="buttonNoPrint" style="height:30px" />
