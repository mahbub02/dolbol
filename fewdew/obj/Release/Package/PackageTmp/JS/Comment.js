$(document).ready(function(){
    Onready();
});
function Onready(){
    CommentSectionAnimation();
    BindPostCommentEvents();
    BindDeleteCommentEvents();
}
function BindPostCommentEvents (){
  $(".btnPostMessage").bind("click",function(){
      var comment=$(this).prevAll(".txtEnterMessage").val();
      var container=$(this).parents(".CommentContainer")[0];
      var parentid=$(this).parents(".CommentContainer").children(".parent-id-container").val();
      ServerPostCommentAndBind(comment,parentid,container);
  });
}
function BindDeleteCommentEvents(){
    $(".delete-comment").bind("click",function(){
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
          
          Onready();
          },
          error: AjaxFailed
        });
    }

    
    function ServerPostStatusMessage(txtStatus){
         var comment=$(txtStatus).prevAll("#textUserStatus").val();
         $(txtStatus).prevAll("#textUserStatus").val("");
         $.ajax({
          type: "POST",
          url: "home2.aspx/PostStatusMessage",
          data:"{'comment':'" + comment + "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
         
           $("#AllFeed").html(msg.d+ $("#AllFeed").html());
          
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