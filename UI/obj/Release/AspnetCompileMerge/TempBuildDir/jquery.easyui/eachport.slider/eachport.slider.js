
/**
* Name: SYNV Slider Box v.1.0
* Date: Dec 2011
* Autor: Javy Song (http://www.eachport.com)
* Version: 1.0
**/

(function($) {
    $.fn.slider = function(options) {
        var defaults = {
            speed: 4000,
            width: 230,
            height: 230,
            showPage: true,
            showSlice: true
        }

        var opts = $.extend(defaults, options);
        var slider_current_index = 0;
        var slider_total_page = 0;
        var show_timer = 1;
        var hide_timer = 1;
        var scrool_timer = 1;
        var slider_pics = null;
        var hide = 100;
        var hideFF = 1.0;
        var scrool_way = "right";

        /*
        * @desc: get show images
        */
        slider_pics = $('#slider_container').children('.slider_item');

        slider_total_page = slider_pics.length;

        return this.each(function() {

            var S = $(this);
            S.width(opts.width);
            S.height(opts.height);

            if (!opts.showSlice) {
                $('#btnPre').hide();
                $('#btnNext').hide();
            }
            if (!opts.showPage) {
                $('#slider_page_container').hide();
            }

            var top = opts.height / 2 - 32;

            $('#btnPre').hover(function() {
                if (!(($.browser.msie) && ($.browser.version == "6.0"))) {
                    $(this).css('top', top - 1);
                }
            },
            function() {
                $(this).css('top', top);
            }).css('top', top);

            $('#btnNext').hover(function() {
                if (!(($.browser.msie) && ($.browser.version == "6.0"))) {
                    $(this).css('top', top - 1);
                }
            },
            function() {
                $(this).css('top', top);
            }).css('top', top);

            /*
            * @desc: generate slider pagination htmls
            */
            var slider_page_container = $('#slider_page_container');
            slider_page_container.css('top', opts.height - 26);
            slider_page_container.html('');
            for (var index = 0; index < slider_total_page; index++) {
                if (index == 0) {
                    slider_page_container.append('<li class="slider_page_item slider_page_selected"></li>');
                }
                else {
                    slider_page_container.append('<li class="slider_page_item"></li>');
                }
            }
            changeImage();

            scrool_timer = window.setInterval(function() { scrollNext(); }, opts.speed);

            /*
            * @desc: get previous image
            */
            $('#btnPre').click(function() {
                scrool_way = "left";
                clearInterval(hide_timer);
                clearInterval(show_timer);
                clearInterval(scrool_timer);
                scrollNext();
                scrool_timer = setInterval(function() { scrollNext(); }, opts.speed);
            });

            /*
            * @desc: get next image
            */
            $('#btnNext').click(function() {
                scrool_way = "right";
                clearInterval(hide_timer);
                clearInterval(show_timer);
                clearInterval(scrool_timer);
                scrollNext();
                scrool_timer = setInterval(function() { scrollNext(); }, opts.speed);
            });

            /*
            * @desc: pagination hover change image
            */
            $('#slider_page_container li').hover(function() {

                slider_current_index = $('#slider_page_container li').index($(this));
                if (scrool_way == "left") { slider_current_index++; }
                else {
                    slider_current_index--;
                }
                clearInterval(hide_timer);
                clearInterval(show_timer);
                clearInterval(scrool_timer);
                scrollNext();
                scrool_timer = setInterval(function() { scrollNext(); }, opts.speed);
            }, function() { });
        });

        /*
        * @desc: hide slider container image
        */
        function hideEffects() {
            hide = hide - 5;
            hideFF = hideFF - 0.05;
            $('#slider_container').css("filter", "alpha(opacity=" + hide + ")");
            $('#slider_container').css("opacity", hideFF + ""); //Firefox compatible
            if (hide <= 70 || hideFF <= 0.7) {
                window.clearInterval(hide_timer);
                hide = 70;
                hideFF = 0.7;
                changeImage();
            }
        }

        /*
        * @desc: show image effects
        */
        function showEffects() {
            hide = hide + 5;
            hideFF = hideFF + 0.05;
            $('#slider_container').css("filter", "alpha(opacity=" + hide + ")");
            $('#slider_container').css("opacity", hideFF + ""); //Firefox compatible
            if (hide >= 100 || hideFF >= 1.0) {
                window.clearInterval(show_timer);
                hide = 100;
                hideFF = 1.0;
            }
        }

        /*
        * @desc: change image to display
        */
        function changeImage() {
            if (!(($.browser.msie) && ($.browser.version == "6.0"))) {
                var img_src = slider_pics.eq(slider_current_index).attr('src');
                $('#slider_container').css('background', "url(" + img_src + ") no-repeat");
                show_timer = window.setInterval(function() { showEffects(); },100);
            }
            else {
                slider_pics.hide();
                slider_pics.eq(slider_current_index).show();
            }
            $('#slider_page_container li').removeClass('slider_page_selected');
            $('#slider_page_container li').eq(slider_current_index).addClass('slider_page_selected');
        }

        /*
        * @desc: scrool next images
        */
        function scrollNext() {
            if (scrool_way == "left") {
                slider_current_index--;
                if (slider_current_index < 0) {
                    slider_current_index = slider_total_page - 1;
                }
            }
            else {
                slider_current_index++;
                if (slider_current_index >= slider_total_page) {
                    slider_current_index = 0;
                }
            }
            if (!(($.browser.msie) && ($.browser.version == "6.0"))) {
                window.clearInterval(hide_timer);
                hide_timer = window.setInterval(function() { hideEffects(); }, 100);
            }
            else {
                changeImage();
            }
        }
    }
})(jQuery);