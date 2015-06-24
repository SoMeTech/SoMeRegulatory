(function($) {
    $.fn.focus = function(options) {
      var settings = $.extend({}, $.fn.focus.defaults, options);
	  return this.each(function() {
  		  var focus = $(this);
	      var imgUrls = new Array();
	      var titles = new Array();
	      var temp = 0;
	      focus.find('img').each(function(){
	      	imgUrls[temp] = $(this).attr('src');
	      	titles[temp] = $(this).attr('title');
			temp++;
	      });
  		  
  		  var vars = {
  		    paused:false,
  		  	isRunning:false,
			imgUrls:imgUrls,
			currentIndex:0,
			titles:titles,
			animates:['blindH','blindV','expandRB','sliceRB','sliderB','sliderR'],
			currentAni:'random'	
		  };
		  //Download by http://www.codefans.net
		  if(settings.animateStyle==='random'){
		     var random = Math.floor((vars.animates.length)*Math.random());
		     vars.currentAni = vars.animates[random];
	      }else{
	  		 vars.currentAni = settings.animateStyle;
	      }
  		  var nivoControl = $('<div class="nivo-controlNav"></div>');
		  focus.append(nivoControl);
		  
		  for(var i = 0; i < imgUrls.length; i++){
		  	nivoControl.append('<a class="nivo-control" rel="'+ i +'" href="javascript:void(0)">'+ (i + 1) +'</a>');
		  }
		  
  		  $('.nivo-controlNav a', focus).live('click', function(event){
		        event.stopPropagation();
  		  		if(vars.isRunning) return false;
  		  		if($(this).hasClass('active')) return false;
  		  		clearInterval(timer);
  		  		timer = '';
  		  		var prevIndex = vars.currentIndex;
  		  		var nowIndex = Number($(this).attr('rel'));
  		  		vars.currentIndex = nowIndex-1;
  		  		$('.nivo-controlNav a', focus).each(function(){
					$(this).removeClass('active');
				});
  		  		$('.nivo-controlNav a:eq('+ nowIndex +')', focus).addClass('active');
  		  		$('.nivo-box', focus).each(function(){
	  				$(this).remove();
	  			});
				slice(focus,settings,imgUrls[nowIndex]);
				runEffect(focus,settings);
  	 	  });
  	 	  
		  $('.nivo-controlNav a:eq('+ vars.currentIndex +')', focus).addClass('active');
		  
		  var offset = focus.offset();
		  $('<div class="nivo-caption"><a href="javascript:void(0)" onclick="adjustImg(this)"></a></div>')
		  .css({ display:'none', opacity:0.8,"top":(offset.top+focus.height()+5)+"px"}).insertAfter(focus);
		 
		 if(vars.titles[vars.currentIndex] != ''){
			$('.nivo-caption a').html(vars.titles[vars.currentIndex]);
			$('.nivo-caption').offset({left:focus.offset().left+$('.nivo-caption').width()/2});
			$('.nivo-caption').fadeIn(800);
		 }
  		  
		  focus.data('globalVars',vars);
	      var index = 1;
		  slice(focus,settings,imgUrls[index]);
		  focus.bind('animateFinished',function(){
		  		vars.isRunning = false;
		 		var count = 0;
		 		var rep = 1;
		 		vars.currentIndex = vars.currentIndex+1;
				if(vars.currentIndex === vars.imgUrls.length){
					vars.currentIndex = 0;
				}
				
				if(vars.currentIndex === vars.imgUrls.length-1){
					rep = 0;
				}else{
					rep = vars.currentIndex+1;
				}
				
				
		 		$('.nivo-box', focus).each(function(){
	  				$(this).remove();
	  			});
		  		focus.find('img').each(function(){
		  			$(this).hide();
					if(count === vars.currentIndex){
						$(this).show();
					}
					count++;
		  		});
		  	    if(settings.animateStyle==='random'){
				    var random = Math.floor((vars.animates.length)*Math.random());
				    vars.currentAni = vars.animates[random];
			    }else{
			  		vars.currentAni = settings.animateStyle;
			    }
				slice(focus,settings,imgUrls[rep]);
				$('.nivo-controlNav a', focus).each(function(){
					$(this).removeClass('active');
				});
				$('.nivo-controlNav a:eq('+ vars.currentIndex +')', focus).addClass('active');
				
			   if(vars.titles[vars.currentIndex] != ''){
					$('.nivo-caption a').html(vars.titles[vars.currentIndex]);					
					$('.nivo-caption').fadeIn(800);
			   }
			   if(timer==''){
			   		timer = setInterval(function(){ runEffect(focus,settings); }, settings.pausedTime);
			   }
		  });
		  
		  	var timer = setInterval(function(){ runEffect(focus,settings); }, settings.pausedTime);
		  	
		  	focus.hover(function(){
	  			vars.paused = true;
				clearInterval(timer);
				timer = '';
  			},function(){
	  			vars.paused = false;
				if(timer == ''){
					timer = setInterval(function(){ runEffect(focus,settings); }, 3000);
				}
  		    });
	 });
    };


	function runEffect(focus,settings){
	  var pieces = $('.nivo-box', focus);
	  var i=0;
	  var time = 0;
	  var vars = focus.data('globalVars');
	  vars.isRunning = true;
	  pieces.each(function(){
	  	  var aniTime = settings.animateTime;
	  	  if(settings.isAys){
	  	  	aniTime = settings.animateTime/(settings.cols*settings.rows);
	  	  }
	  	  var piece = $(this);
	  	  var orgWidth = piece.width();
	  	  var orgHeight = piece.height();
	  	  if(vars.currentAni == 'blindV'){
		  	  piece.width(orgWidth);
		  	  piece.height(0);
	  	  }
		  if(vars.currentAni == 'blindH'){
			  piece.width(0);
		  	  piece.height(orgHeight);
		  }
		  if(vars.currentAni == 'expandRB'){
		 	  piece.width(0);
		  	  piece.height(0);
		  }
		  if(vars.currentAni == 'sliceRB'){
			  piece.width(0);
		  	  piece.height(0);
		  }
		  
		  if(vars.currentAni == 'sliderB'){
			  piece.width(orgWidth);
		  	  piece.height(0);
		  }
		  
		  if(vars.currentAni == 'sliderR'){
			  piece.width(0);
		  	  piece.height(orgHeight);
		  }
		  
	  	  piece.css({opacity:'1.0',display:'block'});
			if(i==pieces.length-1){
				setTimeout(function(){
					piece.animate({ width:orgWidth,height:orgHeight,opacity:'1.0' }, aniTime, '', function(){focus.trigger('animateFinished');});
				}, (time+100));
			}else{
				setTimeout(function(){
					piece.animate({ width:orgWidth,height:orgHeight,opacity:'1.0' }, aniTime, '');
				}, (time+100));
			}
		//time = time+20;
		i++;
	  });
	}

    function slice(focus,settings,imgUrl){
	  	$('.nivo-box', focus).each(function(){
	  		$(this).remove();
	  	});
	  var vars = focus.data('globalVars');
	  var rows = settings.rows;
	  var cols = settings.cols;
	  if(vars.currentAni == 'blindV'){
      	cols = 1;
	  }
	  
	  if(vars.currentAni == 'blindH'){
	  	rows = 1;
	  }
	  
	  if(vars.currentAni == 'expandRB'){
	  	rows = 1;
	  	cols = 1;
	  }
	  
	  if(vars.currentAni == 'sliceRB'){
		rows = settings.rows;
		cols = settings.cols;
	  }
	  
	  if(vars.currentAni == 'sliderB'){
	  	rows = 1;
	  	cols = 1;
	  }
	  
	  if(vars.currentAni == 'sliderR'){
	  	rows = 1;
	  	cols = 1;
	  }
	  
      var piecesWidth = Math.floor(focus.width()/cols);
      var piecesHeight = Math.floor(focus.height()/rows);
      //if(setti)
      for(var row=0;row<rows;row++){
		for(var col=0;col<cols;col++){
			if(col === cols-1){
                focus.append(
               	$('<div class="nivo-box" name="'+ col +'" rel="'+ row +'"><img src="'+imgUrl+'" style="position:absolute; width:'+focus.width()+'px; height:'+focus.height()+'px;display:block;left:-'+(piecesWidth*col)+'px;top:-'+(piecesHeight*row)+'px"/></div>').css({ 
                        left:(piecesWidth*col)+'px', 
                        top:(piecesHeight*row)+'px',
                        width:(focus.width()-(piecesWidth*col))+'px',
                        height:piecesHeight+'px',
                        opacity:'0.0',
                        display:'none'
                    })
                );
            } else {
               focus.append(
               $('<div class="nivo-box" name="'+ col +'" rel="'+ row +'"><img src="'+imgUrl+'" style="position:absolute; width:'+focus.width()+'px; height:'+focus.height()+'px;display:block;left:-'+(piecesWidth*col)+'px;top:-'+(piecesHeight*row)+'px"/></div>').css({ 
                        left:(piecesWidth*col)+'px', 
                        top:(piecesHeight*row)+'px',
                        width:piecesWidth+'px',
                        height:piecesHeight+'px',
                        opacity:'0.0',
                        display:'none'
                    })
                );
          }
		}
	  }
    }
    
    $.fn.focus.defaults = {
      rows:1,
      cols:5,
      animateStyle:'random',
      animateTime:1000,
      isAsy:false,
      isBlank:true,
      pausedTime:3000
    };
})(jQuery);