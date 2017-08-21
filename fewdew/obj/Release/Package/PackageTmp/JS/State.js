 $(document).ready(function(){
        Onready();
    });
        
function Onready(){
    EnableStateUploadButton();
    MakeResizable();
    MakeDraggable();
    
}
     function EnableStateUploadButton(){
	        var button = $('#singleImageUploadButton'), interval;
		        var data1="Mahbub";
		        new AjaxUpload(button, {
			        action: 'StateUpoad.ashx', 
			        name: 'myfile',
			         data: {
                id : $("#hiddenStateId").val(),
               example_key2 : 'example_value2'
                            },
			        onSubmit : function(file, ext){		
				        button.text('Uploading');
				        this.disable();			
				        interval = window.setInterval(function(){
					        var text = button.text();
					        if (text.length < 13){
						        button.text(text + '.');					
					        } else {
						        button.text('Uploading');				
					        }
				        }, 200);
			        },
			        onComplete: function(file, response){
				        button.text('Upload');
//				        ServerUploadSingleImageAndReturnhtml(response);		
				        window.clearInterval(interval);
				        this.enable();
			        }
		        });
            }
            
 function MakeResizable() {
		$(".resizable").resizable({
			animate: true,
			maxHeight: 150,
			maxWidth: 150,
			minHeight: 50,
			minWidth: 10

		});
	}
	
function MakeDraggable() {
		$(".draggable").draggable({
				containment: '#droppable',
				scroll: false
		 }).mouseup( function(){
		    var coord = $(this).position();
		    $("#InfoContainer").val($(this).attr('id'));
//		    alert($(this).width());
             $("#menu").css("display","inline");
		    $("#menu").css("top",coord.top+"px");
		    $("#menu").css("left",coord.left+$(this).width()+"px");
//		    alert(coord.left+" "+ coord.top);
		 });
		$("#droppable").droppable({
			drop: function(event, ui) {
//				$(this).addClass('ui-state-highlight').find('p').html('Dropped!');
			}
		});

	}
