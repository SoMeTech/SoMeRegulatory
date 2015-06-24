<%@ page language="C#" autoeventwireup="true" smartnavigation="true" enableeventvalidation="false" stylesheettheme="Default" inherits="Menu_treeview" CodeBehind="treeview.aspx.cs"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
     <script src="tree/jquery-1.8.2.min.js"></script>
    <!--手风琴组件start-->
    <link href="tree/learunui-accordionTree.css" rel="stylesheet" />
    <!--手风琴组件end-->
    <!--树形组件start-->
    <link href="tree/tree.css" rel="stylesheet" />
    <script src="tree/tree.js"></script>
    <!--树形组件end-->
    <script type="text/javascript">
        //屏蔽右键
        function document.oncontextmenu() 
        { 
            return false; 
        } 
        /**初始化**/
        $(document).ready(function () {
            GetAccordionMenu();
            InitializeImpact();
        });
        //初始化界面UI效果
        function InitializeImpact() {
            //设置自应高度
            resizeU();
            $(window).resize(resizeU);
            function resizeU() {
                var divkuangH = $(window).height();
                $(".navigation").height(divkuangH - 0);
            }
            //手风琴效果
            var Accordion = function (el, multiple) {
                this.el = el || {};
                this.multiple = multiple || false;
                var links = this.el.find('.link');
                links.on('click', { el: this.el, multiple: this.multiple }, this.dropdown)
            }
            Accordion.prototype.dropdown = function (e) {
                //计算高度
                var accordionheight = ($("#accordion").children("ul li").length * 36);
                var navigationheight = $(".navigation").height()
                $('#accordion li').children('.submenu').height(navigationheight - accordionheight - 1);
                $(this).next().slideToggle();
                $(this).parent().toggleClass('open');
                if (!e.data.multiple) {
                    $(this).parent().parent().find('.submenu').not($(this).next()).slideUp().parent().removeClass('open');
                };
                GetTreeMenu($(this).next().attr('id'));
            }
            var accordion = new Accordion($('#accordion'), false);
            $(".submenu a").click(function () {
                $('.submenu a').removeClass('action');
                $(this).addClass('action');
            })
            $("#accordion li:first").find('div').trigger("click");//默认第一个展开
        }
        /*导航菜单begin====================*/
        //手风琴
        function GetAccordionMenu() {
            var html = "";
            $.ajax({
                type: 'post',
                dataType: "text",
                url: "treeview.aspx?action=LoadAccordionMenu",
                cache: false,
                async: false,
                success: function (data) {
                    $("#accordion").append(data);
                }
            });
        }
        //树形菜单
        function GetTreeMenu(ModuleId) {
            var itemtree = {
                onnodeclick: function (item) {
                    //alert(item.title)
                    //alert(item.text)
                    window.parent.addTabPanel(encodeURIComponent(item.text), item.text, item.title, item.value);

                },
                url: "treeview.aspx?action=LoadTreeMenu&ModuleId=" + ModuleId
            };
            $("#" + ModuleId).treeview(itemtree);
        }
        /*导航菜单end====================*/
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navigation">
            <ul id="accordion" class="accordion">
            </ul>
        </div>
    </form>
</body>
</html>