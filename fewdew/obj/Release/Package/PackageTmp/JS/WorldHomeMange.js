
$(document).ready( function(){
ONReady();
});
function ONReady(){
    EnableColorBox();
    ActivateDraggable();
    ActivateResizable();
    
     $("#btnCreateWorld").click( function(){
        CreateJagPlaceLink();
   }); 
   $(".upload-Background").click( function(){
    
        $("#dvUploadImage").toggle('slow');
   });
   
    $("#spanSaveChanges").click( function(e){
                if($("#hiddenParentidContainer").val()==$("#idContainer").val())
                {
                    ResizeTheBackGroundImage();
                    ShowWait(e);
                } 
                else{  
                ShowWait(e); 
		        SaveLinkLocation();
		        }
		    });
		    
    $(".pathlink").click( function(e){
                $('#history').css('top',e.pageY+"px");
                $('#history').css('left',300+"px");
                $('#history').toggle('slow');


            });
    $('#history').click( function(){
        $(this).toggle('slow');
    });  
     $('#menu').click( function(){
        $(this).toggle('slow');
    });        
 
   
}

function ResizeTheBackGroundImage()
{
//    alert("Image resized");
    
    var width =$("#"+$("#idContainer").val()).width();
    var height =$("#"+$("#idContainer").val()).height();
    
//    alert(width);
//    alert(height);
  
        $.ajax({
                type: "POST",
                url: "worldHomeManage.aspx/ResizeBackGroundImage",
                data:"{'width':'" + width + "','height':'" + height + "','place_id':'" + $("#idContainer").val() + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                HideWait();
               },
                error: AjaxFailed
                });

    
 
}

function EnableColorBox(){			
				$("a[rel='example1']").colorbox();
				$("a[rel='example2']").colorbox({transition:"fade"});
				$("a[rel='example3']").colorbox({transition:"none", width:"75%", height:"75%"});
				$("a[rel='example4']").colorbox({slideshow:true});
				$(".single").colorbox({}, function(){
					alert('Howdy, this is an example callback.');
				});
				$(".colorbox").colorbox();
				$(".youtube").colorbox({iframe:true, width:650, height:550});
				$(".iframe").colorbox({width:"50%", height:"50%", iframe:true});
				$(".create-world-link").colorbox({width:"50%", inline:true, href:"#create-world-form"});
				
				//Example of preserving a JavaScript event for inline calls.
				$("#click").click(function(){ 
					$('#click').css({"background-color":"#f00", "color":"#fff", "cursor":"inherit"}).text("Open this window again and this message will still be here.");
					return false;
				});
			}
			
//#description-context
//			
function ActivateDraggable() {
	       
		$(".draggable").draggable({
				containment: '#droppable',
				scroll: false
		 }).mouseup( function(){
		    var coord = $(this).position();
		    $("#idContainer").val($(this).attr('id'));
		   
//		    alert($(this).width());
            $("#menu").css('display','none');   
            $("#menu").fadeIn('slow');
		    $("#menu").css("top",coord.top+"px");
		    $("#menu").css("left",coord.left+$(this).width()+"px");
		    $("#spandescription").text($(this).children(".descriptin").val());
//		    alert($(this).children(".descriptin").val());
		    
//		    alert(coord.left+" "+ coord.top);
		 });
//		 .mouseover( function(){ 
//		 
//		              
//         //alert($(this).children(".descriptin").val());        		 
//         
//         $("#description-context").fadeIn('slow');
//         
////		 $("#description-context >.descriptin").value
////		 alert("hover");
//		 
//		 });
		 
		 $(".resizable").mouseup( function(){
		    var coord = $(this).position();
		    $("#idContainer").val($(this).attr('id'));
		    
//		    alert($(this).width());
            $("#menu").css('display','none');   
            $("#menu").fadeIn('slow');
		    $("#menu").css("top",coord.top+"px");
		    $("#menu").css("left",coord.left+$(this).width()+"px");
		    
		     $("#spandescription").text($(".parentdescriptin").val() );
		
//		    alert(coord.left+" "+ coord.top);
		 });
		 
		 
		$("#droppable").droppable({
			drop: function(event, ui) {
				$(this).addClass('ui-state-highlight').find('p').html('Dropped!');
			}
		});

	}
function SaveLinkLocation(){
    //alert("Save change clicked hoise");
    var coord =$("#"+$("#idContainer").val()).position();
//    alert(coord.left);
//    alert(coord.top);
//    alert($("#idContainer").val());
//    alert($("#idContainer").val());

     $.ajax({
                type: "POST",
                url: "worldHomeManage.aspx/SaveLinkLocation",
                data:"{'place_id':'" + $("#idContainer").val() + "','top':'" + coord.top + "','left':'" + coord.left + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                HideWait();
               },
                error: AjaxFailed
                });
 
}	
	
	
function ActivateResizable() {
		$(".resizable").resizable({
//			animate: true,
//			maxHeight: 150,
//			maxWidth: 150,
//			minHeight: 50,
//			minWidth: 10

		});
	}
	  
  
//       $(document).ready(function() {
//		$(".world-item").draggable({
//				containment: '#content-area',
//				scroll: false
//		 }).mousemove(function(){
//						var coord = $(this).position();
//						$("p:last",this).text( "left: " + coord.left + ", top: " + coord.top );
//		 }).mouseup(function(){
//				var coords=[];
//				var coord = $(this).position();
//				var item={ coordTop:  coord.left, coordLeft: coord.top  };
//			   	coords.push(item);
//				var order = {id:this.id, coords: coords };
//				$.post('updatecoords.php', 'data='+$.toJSON(order), function(response){
//						if(response == "success")
//							$("#respond").html('<div class="success">X and Y Coordinates Saved!</div>').hide().fadeIn(1000);
//							setTimeout(function(){ $('#respond').fadeOut(1000); }, 2000);
//						});
//				});
//		});




function CreateJagPlaceLink(ParentId)
    {
       
           if($("#txtWorldName").val()=="")
           {
            alert("Enter World Name");
            return;
           }
           if($("#txtWorldDescription").val()=="")
           {
            alert("Enter World Description");
            return;
           } 
          
   
     $.ajax({
                type: "POST",
                url: "worldHomeManage.aspx/CreateJagWorldLink",
                data:"{'name':'" + $("#txtWorldName").val() + "','description':'" + $("#txtWorldDescription").val() + "','ParentId':'" + $("#hiddenParentidContainer").val() + "','accessType':'" + $('input[name=accessType]:checked').val() + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                $("#droppable").html($("#droppable").html()+msg.d);
                ONReady();
                $.fn.colorbox.close()
//                alert(msg.d);
//                $(inputbutton).parents(".request-box").html("<b><a href=UserRoom.aspx?room_id="+$(inputbutton).attr('id')+">"+msg.d+"</a></b>&nbsp has become your friend now");
                },
                error: AjaxFailed
                });

    }
    
function AjaxFailed(result) {
    alert(result.status + ' ' + result.statusText);
    }
    
    function ShowWait(e)
    {
      
        $("#loading").css('left',e.pageX+"px");
        $("#loading").css('top',e.pageY+"px");
          $("#loading").fadeIn();
       
    }
    function HideWait()
    {
        $("#loading").fadeOut();
        $("#menu").fadeOut();
        
       
    }