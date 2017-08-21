//-----------------------------
$(document).ready(function(){
    Onready();
});
function Onready(){
    jQuery('abbr.timeago').timeago();
    CommentSectionAnimation();
    BindPostCommentEvents();
    BindDeleteCommentEvents();
    EnableSingleImageUploadButton();
    CreateTab();
    StartPagination();
   //ActivateFeedMenu();
    BindParentDeleteEvents();
}
function ActivateFeedMenu()
{

$(".the_menu li").click( function(){
        
//       if( $(".the_menu li").index(this)==1){       
            ShowFeed($(".the_menu li").index(this));
//       }
//       else if( $(".the_menu li").index(this)==0){       
//            ShowContactFeed($(".the_menu li").index(this));
//       }
    });
}

function ShowFeed( type){

   $.ajax({
        
          type: "POST",
          url: "home2.aspx/FetchFeed",
          data:"{'type':'" + type + "'}",
            //My Comment joto gula params add korte chao toto gula 'no':'" + vua + "'  add koro "{ r }", er vetore
            //data: "{no:" + "13" + ","+"height:"+"100" +"}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
          alert(msg.d);
           $("#AllFeed").html(msg.d);
          //container.innerHTML=msg.d;
          //Onready();
          },
          error: AjaxFailed
        });
}

function CreateTab()
{
    $('.tabs a').click(function(){
		switch_tabs($(this));
	});
 
	switch_tabs($('.defaulttab'));

}

function switch_tabs(obj)
{
	$('.tab-content').hide();
	$('.tabs a').removeClass("selected");
	var id = obj.attr("rel");
 
	$('#'+id).fadeIn();
	obj.addClass("selected");
}



function EnableSingleImageUploadButton(){
	var button = $('#singleImageUploadButton'), interval;
		var data1="Mahbub";
		new AjaxUpload(button, {
			action: 'FileHandler.ashx', 
			name: 'myfile',
			 data: {
        example_key1 : data1,
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
				ServerUploadSingleImageAndReturnhtml(response);		
				window.clearInterval(interval);
				this.enable();
			}
		});
}

//-----------------------------
var title;
var span;
function BindParentDeleteEvents(){

    $(".delete-parent").bind("click",function(){
        title=$(this).attr("title");
        span=$(this).parents("span")[0];
        jqDialog.confirm("Do you really want to delete the post?",
			function() { ServerParentDeleteAndBind(title,span); },		// callback function for 'YES' button
			function() {  }		// callback function for 'NO' button
		);

        
    });
}

function ServerParentDeleteAndBind(parentId,container)
{


//return;
    $.ajax({
      type: "POST",
      url: "home2.aspx/DeleteContent",
      data:"{'parentId':'" + parentId + "'}",

        //My Comment joto gula params add korte chao toto gula 'no':'" + vua + "'  add koro "{ r }", er vetore
// data: "{no:" + "13" + ","+"height:"+"100" +"}",
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function(msg) {
        // Replace the div's content with the page method's return.
      container.innerHTML=msg.d;
      //container.innerHTML=msg.d;
      Onready();
      //// animation working
      
      
      
      },
      error: AjaxFailed
    });
    
}


//----------------------------------------------------------------------------------------

function BindPostCommentEvents (){
  $(".btnPostMessage").bind("click",function(e){
     ShowBusySign(e);
      
        
      var comment=$(this).prevAll(".txtEnterMessage").val();
      var container=$(this).parents(".CommentContainer")[0];
      var parentid=$(this).parents(".CommentContainer").children(".parent-id-container").val();
      ServerPostCommentAndBind(comment,parentid,container);
  });
}


function BindDeleteCommentEvents(){
    $(".delete-comment").bind("click",function(e){
           
            var CommentId;
            var container;
            CommentId=$(this).attr("id");
            container=$(this).parents(".CommentContainer")[0];
            
                jqDialog.confirm("Do you really want to delete the comment?",
			        function() { ServerDeleteCommentAndBind(CommentId,container); },		// callback function for 'YES' button
			        function() {  }		// callback function for 'NO' button
		        );

                
        
    });
}

function CommentSectionAnimation (){
  $(".seeComment").bind("click",function(){
  $(this).fadeOut("slow");
      $(this).nextAll(".dvCommentTable").fadeIn("slow");
    });
}
var PrevComment;
function ServerPostCommentAndBind(comment,parentid,container)
    {
    if(comment==PrevComment)    {
        return;
    }
    else{PrevComment=comment;}
    
        $.ajax({
        
          type: "POST",
          url: "home2.aspx/PostComment",
          data:"{'comment':'" + comment + "','parentid':'" + parentid + "'}",
            //My Comment joto gula params add korte chao toto gula 'no':'" + vua + "'  add koro "{ r }", er vetore
            //data: "{no:" + "13" + ","+"height:"+"100" +"}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
          container.innerHTML=msg.d;
          HideBusySign();
          Onready();
          },
          error: AjaxFailed
        });
    }

function ShowBusySign(e)
{
      $('#busy').css('display','inline');
      $('#busy').css('left',e.pageX+'px');
      $('#busy').css('top',e.pageY+'px');
}
function HideBusySign()
{
      $('#busy').css('display','none');
}
//--------------------------------------------------------------------

function ServerPostStatusMessage(){
         
         var comment=$(".txtStatusTextBox").val();
         if(comment=="")
         {  
            return;
         }   
         $.ajax({
          type: "POST",
          url: "home2.aspx/PostStatusMessage",
          data:"{'comment':'" + comment + "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
         
           $("#AllFeed").html(msg.d+ $("#AllFeed").html());
          $(".txtStatusTextBox").val("");
          Onready();
          
          },
          error: AjaxFailed
        });
    }


 
  

 function ServerDeleteCommentAndBind(commentid,container)
{
    $.ajax({
      type: "POST",
      url: "home2.aspx/DeleteComment",
      data:"{'commentid':'" + commentid + "'}",

        //My Comment joto gula params add korte chao toto gula 'no':'" + vua + "'  add koro "{ r }", er vetore
// data: "{no:" + "13" + ","+"height:"+"100" +"}",
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function(msg) {
        // Replace the div's content with the page method's return.
      container.innerHTML=msg.d;
      Onready();
      //// animation working
      
      
      
      },
      error: AjaxFailed
    });
    
}




function AjaxFailed(result) {
    alert(result.status + ' ' + result.statusText);
 } 
 
 $(document).ready(function () {
    $('span.menu_class').click(function () { 
	$('ul.the_menu').slideToggle('medium');
	
    });
});



//////////////////

function ServerUploadSingleImageAndReturnhtml(ParentNodeId)
    {
//         var comment=$(txtStatus).prevAll("#textUserStatus").val();
  //       $(txtStatus).prevAll("#textUserStatus").val("");


         $.ajax({
    
          type: "POST",
          url: "home2.aspx/UploadSingleImage",
          data:"{'ParentNodeId':'" + ParentNodeId + "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
//    alert(msg.d);
          $("#GridContentBasedNotification").html( msg.d+ $("#GridContentBasedNotification").html());

         
          Onready();

          
          
          
          },
          error: AjaxFailed
        });
    }


function StartPagination()
{
//how much items per page to show
	var show_per_page = 5; 
	//getting the amount of elements inside content div
	var number_of_items = $('#GridPublicInfoNotification').children().size();
	
	//calculate the number of pages we are going to have
	var number_of_pages = Math.ceil(number_of_items/show_per_page);
	
	//set the value of our hidden input fields
	$('#current_page').val(0);
	$('#show_per_page').val(show_per_page);
	
	//now when we got all we need for the navigation let's make it '
	
	/* 
	what are we going to have in the navigation?
		- link to previous page
		- links to specific pages
		- link to next page
	*/
	var navigation_html = '<a class="previous_link" href="javascript:previous();">Prev</a>';
	var current_link = 0;
	while(number_of_pages > current_link){
		navigation_html += '<a class="page_link" href="javascript:go_to_page(' + current_link +')" longdesc="' + current_link +'">'+ (current_link + 1) +'</a>';
		current_link++;
	}
	navigation_html += '<a class="next_link" href="javascript:next();">Next</a>';
	
	$('#page_navigation').html(navigation_html);
	
	//add active_page class to the first page link
	$('#page_navigation .page_link:first').addClass('active_page');
	
	//hide all the elements inside content div
	$('#GridPublicInfoNotification').children().css('display', 'none');
	
	//and show the first n (show_per_page) elements
	$('#GridPublicInfoNotification').children().slice(0, show_per_page).css('display', 'block');

}

function previous(){
	
	new_page = parseInt($('#current_page').val()) - 1;
	//if there is an item before the current active link run the function
	if($('.active_page').prev('.page_link').length==true){
		go_to_page(new_page);
	}
	
}

function next(){
	new_page = parseInt($('#current_page').val()) + 1;
	//if there is an item after the current active link run the function
	if($('.active_page').next('.page_link').length==true){
		go_to_page(new_page);
	}
	
}
function go_to_page(page_num){
	//get the number of items shown per page
	var show_per_page = parseInt($('#show_per_page').val());
	
	//get the element number where to start the slice from
	start_from = page_num * show_per_page;
	
	//get the element number where to end the slice
	end_on = start_from + show_per_page;
	
	//hide all children elements of content div, get specific items and show them
	$('#GridPublicInfoNotification').children().css('display', 'none').slice(start_from, end_on).css('display', 'block');
	
	/*get the page link that has longdesc attribute of the current page and add active_page class to it
	and remove that class from previously active page link*/
	$('.page_link[longdesc=' + page_num +']').addClass('active_page').siblings('.active_page').removeClass('active_page');
	
	//update the current page input field
	$('#current_page').val(page_num);
}