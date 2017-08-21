var ServerTimeInSec=null;
$(document).ready(function(){
      
            $.ajax({
        
              type: "POST",
              url: "club.aspx/GetServerTime",
               data:"{}",
            //  data:"{'WallOwnerid':'" + UserId + "','WallOwnerName':'" + UserDisplayName + "','MaxId':'" + 0 + "','Message':'" + message + "'}",
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function(msg) {
                
               ServerTimeInSec= parseInt(msg.d.substr(6));
               
           
              },
                 error: AjaxFailed
             });
        
});


    function BindUserfeed(e)
    {
    
      
        $(".SecondLevelSlider").not("#FeedContainerWrapper").slideUp('fast');        
        
//        if($("#FeedContainer").html()==null||$("#FeedContainer").html()=="")
//        {
              $("#FeedContainer").html("");   
              var UserId=$("#option-container").attr('my_id'); 
              var UserDisplayName=$("#option-container").attr('DisplayName');
//              alert(UserId+" "+UserDisplayName);
              
              GetAndBindUserFeed(e,UserId,UserDisplayName);
              
              if(UserId==0)
                {
              $("#secondleveltitle").html('My Friends activities');
                }
                else if(UserId==-1)
                {
                     $("#secondleveltitle").html('Public activities');
                }
                else
                {
                    $("#secondleveltitle").html($("#option-container").attr('DisplayName')+"'s wall");
                }
              $("#FeedContainerWrapper").slideDown();
       // }    
        
   }
    
$(document).ready(function(){
    $("#FriendsFeed").click(function(e){
        $("#ShowOlderPostButton").attr('max-id','0');
         DisplayAvatarDetails(e,0,'My Friends');
        $(".topSlider").not("#avatar-details").slideUp();
        
    });

     $("#publicFeed").click(function(e){
         $("#ShowOlderPostButton").attr('max-id','0');
         DisplayAvatarDetails(e,-1,'Public');
        $(".topSlider").not("#avatar-details").slideUp();
        
    });
    
    $("#MyWall").click(function(e){
         $("#ShowOlderPostButton").attr('max-id','0');
        DisplayAvatarDetails(e,$("#hiddenUserId").val(),$("#hiddenUserDisplayName").val());
        $(".topSlider").not("#avatar-details").slideUp();
    });
  
   $("*").not('.FeedBox').hover(function(e){
        $(".deletepost").css('display','none');
   }); 
   
    $("img#imgOfflineMessage").click(function(e){
         $("#ShowOlderPostButton").attr('max-id','0');
         BindUserfeed(e);   
        
    });
 
   
   
    
    $("#btnStatusBox").click(function(e){
        if($("textarea#txtStatusBox").val()=="Write something..." ||$("textarea#txtStatusBox").val()==""){
        return;
        }
      
        
       var UserId=$("#option-container").attr('my_id'); 
       var UserDisplayName=$("#option-container").attr('DisplayName'); 
       var message=$("textarea#txtStatusBox").val();
       $("textarea#txtStatusBox").val("");
         
       ShowWait(e); 
        $.ajax({
        
          type: "POST",
          url: "club.aspx/PostStatusMessage",
          data:"{'WallOwnerid':'" + UserId + "','WallOwnerName':'" + UserDisplayName + "','MaxId':'" + 0 + "','Message':'" + message + "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
           var Feed=msg.d;
            HideWait();   
            
                var FeedBox=GetFeedBoxForThisFeed(Feed);
                $("#FeedContainer").prepend($(FeedBox));

                $(".SecondLevelSlider").not("#FeedContainerWrapper").slideUp('fast');            
                $("#FeedContainerWrapper").slideDown();   

             $('.timestamp').cuteTime();
          },
          error: AjaxFailed
        });
        
    
    });
});
function funcCheck(e){
   
   } 
function GetAndBindUserFeed(e,UserId,UserDisplayName)
{
  
//    if($("#FeedContainerWrapper").css('display')=='block'){
//     $("#FeedContainerWrapper").slideUp();
//      return;
//    }
    
     ShowWait(e);  
    $.ajax({
        
          type: "POST",
          url: "club.aspx/GetUserFeed",
          data:"{'WallOwnerid':'" + UserId + "','MaxId':'" + 0 + "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
           HideWait();
            var FeedList=msg.d; 
            CheckAndCreateFeedContainerAndItsWrapper();            
            BindFeeds(FeedList);
            $("#NoFeedMessage").remove();  
            
            if(FeedList.length<10){
               $("#ShowOlderPostButton").fadeOut(); 
            }
            else{
             $("#ShowOlderPostButton").fadeIn(); 
            }
            
            if(FeedList.length==0)
            {
                
              var NoFeedMessage=$("<div></div>");
              $(NoFeedMessage).attr('id','NoFeedMessage');
              $(NoFeedMessage).html('There is no feed');
              $("#FeedContainer").append($(NoFeedMessage));
               
            }
            
            $("#FeedContainerWrapper").slideDown();
             $('.timestamp').cuteTime();
          },
          error: AjaxFailed
        });
}
function ShowTheOlderPostOfThisUser(ShowOlderPostButton,e)
{

    var UserId=$("#option-container").attr('my_id'); 
    var UserDisplayName=$("#option-container").attr('DisplayName'); 
     ShowWait(e);  
        $.ajax({
        
          type: "POST",
          url: "club.aspx/ShowTheOlderPostOfThisUser",
          data:"{'WallOwnerid':'" + UserId + "','MaxId':'" + $(ShowOlderPostButton).attr('max-id') + "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
           HideWait();
            var FeedList=msg.d;
            BindFeeds(FeedList);
            if(FeedList.length<10)
            {
               $("#ShowOlderPostButton").fadeOut(); 
            }
             $('.timestamp').cuteTime();
          },
          error: AjaxFailed
        });
         
}
function CheckAndCreateFeedContainerAndItsWrapper()
{
    if($("#FeedContainerWrapper").length<1)
                {
               
                    var avatardetails = $("div#avatar-details");
                    var offset = avatardetails.offset();
                    var top=0;
                    top=offset.top+ parseInt($("div#avatar-details").css('height').split('px')[0]); 
                    
                    //alert(top);
                    var FeedContainerWrapper=$('<div></div>');
                    $(FeedContainerWrapper).attr('id','FeedContainerWrapper'); 
                    $(FeedContainerWrapper).addClass('SecondLevelSlider'); 
                    $(FeedContainerWrapper).css('left',"0px");
                    $(FeedContainerWrapper).css('top',top+"px");
                    
                    
                    var FeedContainer=$('<div></div>');
                    $(FeedContainer).attr('id','FeedContainer'); 
                   // $(FeedContainer).addClass('SecondLevelSlider');                                                       
                    
                    
                    var ShowOlderPostButton=$('<div></div>');
                    $(ShowOlderPostButton).attr('id','ShowOlderPostButton'); 
                    $(ShowOlderPostButton).html("show older post");
                    $(ShowOlderPostButton).attr('max-id','0');
                    $(ShowOlderPostButton).click(function(e){
                        ShowTheOlderPostOfThisUser(this,e);
                    });
                    
                    
                    $(FeedContainerWrapper).append($(FeedContainer));
                    $(FeedContainerWrapper).append( $(ShowOlderPostButton));
                    
                                        
                    $("body").append(FeedContainerWrapper);
                    
                }
            
}
function ReturnATimeStamp(Action_Date)
{
    var futdate = new Date();
    var ClientTime = futdate.getTime();
    var ActionTime=parseInt(Action_Date.substr(6));
    var abbr=$("<div></div>")
    $(abbr).addClass('timestamp'); 
        // multime -(server-ami);        
       if(ServerTimeInSec!=null)
       {
            var resultTime=ActionTime-(ServerTimeInSec-ClientTime); 
            var ago= new Date(resultTime);
            $(abbr).attr('cutetime',ago.toISOString());                                
            $(abbr).text(ago.toISOString()); 
           
       } 
        return $(abbr);                                    
            
}

function GetFeedBoxForThisFeed(feed)
{
         
        CheckAndCreateFeedContainerAndItsWrapper();
             
                for (var j in feed)
                        {
                           var node = feed[j];
                           
                             if(parseInt($("#ShowOlderPostButton").attr('max-id'))==0|| parseInt($("#ShowOlderPostButton").attr('max-id'))>node.Id)
                                {
                                    $("#ShowOlderPostButton").attr('max-id',node.Id);
                                    //$("#ShowOlderPostButton").html(node.Id);
                                }
                                
                                
                           if(node.Id==node.Parent_Node_Id)
                           {
                                
                             
                                
                                var FeedBox=$('<div></div>');
                                $(FeedBox).attr('id','FeedBox'+node.Parent_Node_Id); 
                                $(FeedBox).attr('PostedBy','PostedBy'+node.User_id); 
                                $(FeedBox).addClass('FeedBox');
                                $(FeedBox).hover(function(){
                                        ShowDeleteButton(this);                                 
                                    }
                                );
                                
                                var feedLeftBlock=$('<div></div>');
                                $(feedLeftBlock).attr('id','feedLeftBlock'+node.Id); 
                                $(feedLeftBlock).addClass('feedLeftBlock');
                                
                                var userImage=$("<div></div>");
                                $(userImage).addClass('feeduserImage');
                                $(userImage).css('background-image','url(images/profile/'+node.User_id+'_mini.jpg)');
                                  
                                
                                $(feedLeftBlock).append(userImage);
                                
                                
                                var feedRightBlock=$('<div></div>');
                                $(feedRightBlock).attr('id','feedRightBlock'+node.Id); 
                                $(feedRightBlock).addClass('feedRightBlock');
                                
                                
                                var feedFeed=$('<div></div>');
                                $(feedFeed).attr('id','feedFeed'+node.Id); 
                                $(feedFeed).addClass('feedFeed');
                                
                                var feedControllerBox=$('<div></div>');
                                $(feedControllerBox).attr('id','feedControllerBox'+node.Id); 
                                $(feedControllerBox).addClass('feedControllerBox');
                                
                                var commentLink=$('<div></div>');
                                $(commentLink).attr('id','commentLink'+node.Id); 
                                $(commentLink).addClass('commentLink');
                                $(commentLink).html("Comment");
                                $(commentLink).click(function(){
                                    $("#FeedPostCommentContainer"+$(this).attr('id').split("commentLink")[1]).slideToggle('slow');
                                });
                                
                               
                                
//                                
//                                var abbr=$("<div></div>")
//                                $(abbr).addClass('timestamp');                               
//                                var ago= new Date(parseInt(node.Action_date.substr(6)));
//                                $(abbr).attr('cutetime',ago.toISOString());                                
//                                $(abbr).text(ago.toISOString()); 
                              
                                $(feedControllerBox).append( ReturnATimeStamp(node.Action_date));
                                $(feedControllerBox).append($(commentLink));
                                
                                var feedCommentContainer=$('<div></div>');
                                $(feedCommentContainer).attr('id','feedCommentContainer'+node.Id); 
                                $(feedCommentContainer).addClass('feedCommentContainer');
                               // $(feedCommentContainer).html('feedCommentContainer');
                                
                                var feedCommentList=$('<div></div>');
                                $(feedCommentList).attr('id','feedCommentList'+node.Parent_Node_Id); 
                                $(feedCommentList).addClass('feedCommentList');
                               // $(feedCommentList).html('feedCommentList');
                                
                                
                                var FeedPostCommentContainer=$('<div></div>');
                                $(FeedPostCommentContainer).addClass('FeedPostCommentContainer');
                                $(FeedPostCommentContainer).attr('id','FeedPostCommentContainer'+node.Id);
                                
                                var FeedPostCommentButton=$('<input type=\"button\" value=\"Share\"/>');
                                $(FeedPostCommentButton).addClass('FeedPostCommentButton');
//                                $(FeedPostCommentButton).addClass('small-button');
                                
                                $(FeedPostCommentButton).attr('id','FeedPostCommentButton'+node.Id);
                                $(FeedPostCommentButton).click(function(e){
                                    PostFeedComment(this,e);
                                });
                                
                               
                                var FeedCommentInputBox=$('<textarea></textarea>');
                                $(FeedCommentInputBox).addClass('FeedCommentInputBox');
                                $(FeedCommentInputBox).attr('id','FeedCommentInputBox'+node.Id);
                                $(FeedCommentInputBox).attr('placeholder',"write comment..");
                                $(FeedCommentInputBox).val($(FeedCommentInputBox).attr('placeholder'));
                                $(FeedCommentInputBox).css("color","#818661");
                              
                                
                                $(FeedCommentInputBox).click(function(e){
                                    AddPlaceHolder(this,e);
                                });
                               
                                $(FeedPostCommentContainer).append(FeedCommentInputBox);
                                $(FeedPostCommentContainer).append(FeedPostCommentButton);
                               
                                $(feedCommentContainer).append($(feedCommentList));
                                $(feedCommentContainer).append($(FeedPostCommentContainer));
                               
                                
                                $(feedRightBlock).append(feedFeed);
                                $(feedRightBlock).append(feedControllerBox);
                                $(feedRightBlock).append(feedCommentContainer);
                                
                                
                                
                                $(FeedBox).append($(feedLeftBlock));
                                $(FeedBox).append($(feedRightBlock));
                                
                                
                               ShowCommentsForFeed(feed,feedCommentList); 
                               
                                  
                                if(node.Attribute_id==1)
                                {
                                  ShowFeedForStatus(feed,$(feedFeed)); 
                                    
                                }
                                else if(node.Attribute_id==10)
                                {
                                     ShowFeedForWallPhoto(feed,$(feedFeed));
                                }
                             
                                return  $(FeedBox);
                           }
                           
                            
                        }
                      
                     
  
}
function BindFeeds(FeedList)
{
       // $("#secondleveltitle").html($("#option-container").attr('DisplayName')+"'s wall");
             
            for (var i in FeedList)
               {
                var feed = FeedList[i];
                var FeedBox=GetFeedBoxForThisFeed(feed);
                $("#FeedContainer").append($(FeedBox));
                    
               }  
               
                 
            MakeAllTextAreaBanglaCompatible();  
            
   $(".WallPhotoLink").colorbox({}, function(){});      

}
function DeleteThisPost(NodeId,e)
{
   
   
   ShowWait(e);
    $.ajax({
        
          type: "POST",
          url: "club.aspx/DeleteNode",
          data:"{'NodeId':'" + NodeId + "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
           HideWait();
           var id=parseInt(msg.d);
           $("#FeedBox"+id).fadeOut('slow'); 
           $("#FeedBox"+id).remove();
          },
          error: AjaxFailed
        });  
}

function ShowConfirmBoxForPostDelete(PostdeleteButton,e)
{
  var id=$(PostdeleteButton).attr('id').split('PostdeleteButton')[1];
 
jqDialog.confirm("Do you really want to delete this post?",
			function() { DeleteThisPost(id,e); },		// callback function for 'YES' button
			function() {  }		// callback function for 'NO' button
		);
		
}
function ShowDeleteButton(FeedBox)
{
 
  
           
       
    var offset = $(FeedBox).offset();
   
    if($(".deletepost").length<1)
    {
        var PostdeleteButton=$("<div></div>"); 
        $(PostdeleteButton).addClass('deletepost');
        $(PostdeleteButton).click(function(e){
            ShowConfirmBoxForPostDelete(this,e);
        });
        $(PostdeleteButton).html('delete'); 
        $(PostdeleteButton).css('display','none');
        $("body").append($(PostdeleteButton));
              
    }
        
        $(".deletepost").attr('id','PostdeleteButton'+$(FeedBox).attr('id').split('FeedBox')[1]);
        $(".deletepost").css('left',parseInt(offset.left+380)+"px");
        $(".deletepost").css('top',offset.top+"px");
        
        
          
       
           if($("#option-container").attr('my_id')==$("#hiddenUserId").val())
           {
              $(".deletepost").css('display','inline'); 
           }
           else{
                if( $(FeedBox).attr('PostedBy').split('PostedBy')[1]==$("#hiddenUserId").val())
                {
                   $(".deletepost").css('display','inline');  
                }
                else{
                 $(".deletepost").css('display','none'); 
                } 
            
           } 
      
   
}

function PostFeedComment(FeedPostCommentButton,e)
{
    var ParentId=$(FeedPostCommentButton).attr('id').split('FeedPostCommentButton')[1];
    var WallOwnerId=$("#option-container").attr('my_id'); 
    var WallOwnerDisplayName=$("#option-container").attr('DisplayName'); 

 
 if( $("#FeedCommentInputBox"+ParentId).val()!="" && $("#FeedCommentInputBox"+ParentId).val()!=$("#FeedCommentInputBox"+ParentId).attr('placeholder') )
 {
    ShowWait(e);  
    $.ajax({
        
          type: "POST",
          url: "club.aspx/PostFeedComment",
          data:"{'ParentId':'" + ParentId + "','comment':'" + $("#FeedCommentInputBox"+ParentId).val()+ "','WallOwnerId':'" + WallOwnerId + "','WallOwnerDisplayName':'" + WallOwnerDisplayName + "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
           HideWait();
           var node=msg.d;
        
           ShowCommentForANode(node,$("#feedCommentList"+node.Parent_Node_Id));
           $("#FeedCommentInputBox"+node.Parent_Node_Id).val("");
           
            $('.timestamp').cuteTime(); 
          },
          error: AjaxFailed
        });  
    }
 
 

}

function AddPlaceHolder(textarea,e)
{
   if($(textarea).val()==$(textarea).attr('placeholder'))
      {
        $(textarea).val("");
        $(textarea).css("color","black");
        
      } 
      $(textarea).css('height','40px'); 
      e.stopPropagation();  
      
}

function ShowFeedForWallPhoto(feed,feedfeed)
{
     var feedUserStatus=$('<div></div>');
   for (var j in feed)
    {
            var node = feed[j];
            if(node.Id==node.Parent_Node_Id)
            {
                var feedUserName=$('<div></div>');
                $(feedUserName).attr('id','feedUserName'+node.User_id); 
                $(feedUserName).attr('displayName',''+node.User_Name); 
                $(feedUserName).addClass('feedUserName');
                $(feedUserName).html(node.User_Name);
                
                $(feedUserName).click(function(e){
                  var userid=$(this).attr('id').split('feedUserName')[1];
                  var displayName=$(this).attr('displayName');  
//                    if( $("div#option-container").attr('my_id')!=userid)
//                        {  
                                            
                            DisplayAvatarDetails(e,userid,displayName);
//                        }
                });
                
                var feedWallOwnerNameUserName=$('<div></div>');
                $(feedWallOwnerNameUserName).attr('id','feedWallOwnerNameUserName'+node.Wall_Owner_id); 
                $(feedWallOwnerNameUserName).addClass('feedWallOwnerNameUserName');
                $(feedWallOwnerNameUserName).html("-> "+node.Wall_Owner_Name);
                $(feedWallOwnerNameUserName).attr('displayName',''+node.Wall_Owner_Name); 
                
                $(feedWallOwnerNameUserName).click(function(e){
                  var userid=$(this).attr('id').split('feedWallOwnerNameUserName')[1];
                  var displayName=$(this).attr('displayName');  
//                    if( $("div#option-container").attr('my_id')!=userid)
//                        {  
                                            
                            DisplayAvatarDetails(e,userid,displayName);
//                        }
                });
                
               
                $(feedUserStatus).attr('id','feedUserStatus'+node.User_id); 
                $(feedUserStatus).addClass('feedUserStatus');
               
                var WallPhotoLink=$("<a></a>");
                $(WallPhotoLink).addClass('WallPhotoLink');
                $(WallPhotoLink).attr('href','Images/Node/'+node.Node_value+'_display.jpg');
                
                var UploadedPhoto=$("<img />");
                $(UploadedPhoto).attr('src','Images/Node/'+node.Node_value+'_thumb.jpg');
                $(UploadedPhoto).addClass('uploaded-photo');
                
                $(WallPhotoLink).append($(UploadedPhoto));
                
                $(feedUserStatus).append($(WallPhotoLink));
               
               
                $(feedfeed).append($(feedUserName));
                if(node.User_id!=node.Wall_Owner_id)
                {
                $(feedfeed).append($(feedWallOwnerNameUserName));
                } 
                $(feedfeed).append($(feedUserStatus));
            }
            else if(node.Attribute_id==11)
            {
                var photoTitle=$("<div></div>");
                $(photoTitle).html(node.Node_value);
                $(photoTitle).addClass('photo-title');
                $(feedUserStatus).append($(photoTitle));
            }
            else if(node.Attribute_id==12)
            {
                var photoDescription=$("<div></div>");
                $(photoDescription).html(node.Node_value);
                $(photoDescription).addClass('photo-description');
                $(feedUserStatus).append($(photoDescription));
            }
            
        } 
}

function ShowFeedForStatus(feed,feedfeed)
{
    
  for (var j in feed)
    {
            var node = feed[j];
            if(node.Id==node.Parent_Node_Id)
            {
                var feedUserName=$('<div></div>');
                $(feedUserName).attr('id','feedUserName'+node.User_id); 
                $(feedUserName).attr('displayName',''+node.User_Name); 
                $(feedUserName).addClass('feedUserName');
                $(feedUserName).html(node.User_Name);
                
                $(feedUserName).click(function(e){
                  var userid=$(this).attr('id').split('feedUserName')[1];
                  var displayName=$(this).attr('displayName');  
//                    if( $("div#option-container").attr('my_id')!=userid)
//                        {  
                                            
                            DisplayAvatarDetails(e,userid,displayName);
//                        }
                });
                
                var feedWallOwnerNameUserName=$('<div></div>');
                $(feedWallOwnerNameUserName).attr('id','feedWallOwnerNameUserName'+node.Wall_Owner_id); 
                $(feedWallOwnerNameUserName).addClass('feedWallOwnerNameUserName');
                $(feedWallOwnerNameUserName).html("-> "+node.Wall_Owner_Name);
                $(feedWallOwnerNameUserName).attr('displayName',''+node.Wall_Owner_Name); 
                
                $(feedWallOwnerNameUserName).click(function(e){
                  var userid=$(this).attr('id').split('feedWallOwnerNameUserName')[1];
                  var displayName=$(this).attr('displayName');  
//                    if( $("div#option-container").attr('my_id')!=userid)
//                        {  
                                            
                            DisplayAvatarDetails(e,userid,displayName);
//                        }
                });
                
                var feedUserStatus=$('<div></div>');
                $(feedUserStatus).attr('id','feedUserStatus'+node.User_id); 
                $(feedUserStatus).addClass('feedUserStatus');
                $(feedUserStatus).html(node.Node_value);
                
               //alert($("#feedFeed"+node.Id).html());
               
                $(feedfeed).append($(feedUserName));
                if(node.User_id!=node.Wall_Owner_id)
                {
                $(feedfeed).append($(feedWallOwnerNameUserName));
                } 
                $(feedfeed).append($(feedUserStatus));
            }
        } 
    }

function ShowCommentsForFeed(feed,feedCommentList)
{

  for (var j in feed)
    {
        var node = feed[j];
       
        ShowCommentForANode(node,feedCommentList);  
        
    }          
}
function ShowCommentForANode(node,feedCommentList)
{
    if(node.Id!=node.Parent_Node_Id && node.Attribute_id==1000)
    {
      
        
//      if( $("#feedCommentList"+node.Parent_Node_Id).length>0)
//      {
          
           
            var SingleCommentBox=$("<div></div>");
            $(SingleCommentBox).addClass('SingleCommentBox');
            $(SingleCommentBox).attr('id','SingleCommentBox'+node.Id); 
            
            var CommentBoxLeft=$("<div></div>");
            $(CommentBoxLeft).addClass('CommentBoxLeft');
            
            var CommenterPhoto=$("<div></div>");
            $(CommenterPhoto).addClass('CommenterPhoto');
            $(CommenterPhoto).css('background-image','url(images/profile/'+node.User_id+'_micro.jpg)');
        
            $(CommentBoxLeft).append($(CommenterPhoto));
            
            var CommentBoxRight=$("<div></div>");
            $(CommentBoxRight).addClass('CommentBoxRight');
            
                        
            var CommenterName=$('<div></div>');
            $(CommenterName).attr('id','CommenterName'+node.User_id); 
            $(CommenterName).addClass('CommenterName');
            $(CommenterName).html(node.User_Name);
            $(CommenterName).click(function(e){
                
                DisplayAvatarDetails(e,$(this).attr('id').split('CommenterName')[1],$(this).html());
            });
            
            var CommenterComment=$('<div></div>');
            $(CommenterComment).attr('id','CommenterComment'+node.User_id); 
            $(CommenterComment).addClass('CommenterComment');
            $(CommenterComment).html(node.Node_value);
           
            
            
            
            var CommentController=$('<div></div>');
            $(CommentController).attr('id','CommentController'+node.User_id); 
            $(CommentController).addClass('CommentController');
            
//            var abbr=$("<div></div>")
//            $(abbr).addClass('timestamp');                               
//            var ago= new Date(parseInt(node.Action_date.substr(6)));
//            $(abbr).attr('cutetime',ago.toISOString());                                
//            $(abbr).text(ago.toISOString());
            
//            var CommentDate=$('<div></div>');
//            $(CommentDate).attr('id','CommentDate'+node.User_id); 
//            $(CommentDate).addClass('CommentDate');
            
            
            var CommentDelete=$('<div></div>');
            $(CommentDelete).attr('id','CommentDelete'+node.Id); 
            $(CommentDelete).addClass('CommentDelete');
            $(CommentDelete).html('delete');
            $(CommentDelete).click(function(e){
               ShowConfirmBoxForCommentDelete(this,e,'Sure?');
            });
            $(CommentDelete).css('display','none');
           if($("#option-container").attr('my_id')==$("#hiddenUserId").val())
           {
               $(CommentDelete).css('display','inline'); 
           }
           else{
                if( node.User_id==$("#hiddenUserId").val())
                {
                    $(CommentDelete).css('display','inline');  
                } 
            
           } 
           
           $(CommentController).append( ReturnATimeStamp(node.Action_date));
           $(CommentController).append( $(CommentDelete));
            
            
           $(CommentBoxRight).append($(CommenterName));
           $(CommentBoxRight).append($(CommenterComment)); 
           $(CommentBoxRight).append($(CommentController));
            
           $(SingleCommentBox).append(CommentBoxLeft);
           $(SingleCommentBox).append(CommentBoxRight);
           $(feedCommentList).append($(SingleCommentBox));
//      }
    }

}

function ShowConfirmBoxForCommentDelete(deletebutton,e,message){

    var id=$(deletebutton).attr('id').split('CommentDelete')[1];
    
  
  jqDialog.confirm("Do you really want to delete the comment?",
			function() { DeleteThisComment(id,e);positionFooter(); },		// callback function for 'YES' button
			function() { positionFooter(); }		// callback function for 'NO' button
		);
}


function DeleteThisComment(NodeId,e)
{
   
   
   ShowWait(e);
    $.ajax({
        
          type: "POST",
          url: "club.aspx/DeleteNode",
          data:"{'NodeId':'" + NodeId + "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
           HideWait();
           var id=parseInt(msg.d);
       
           $("#SingleCommentBox"+id).remove();
          },
          error: AjaxFailed
        });  
}

$(document).ready(function(){

    $("textarea[placeholder]").each(function(){
             $(this).val($(this).attr('placeholder')); 
             $(this).css('height','20px');
    });
        
    $("*").click(function(){
        $("textarea[placeholder]").each(function(){
           if( $(this).val()=="")
           {
             $(this).val($(this).attr('placeholder')); 
             $(this).css('height','20px');
           }
        });
        
    });

});


$(document).ready(function(){
    $("#FeedMenuIcon").click(function(){
        $("#FeedMenus").toggle();
    });
});

function PublishThisPhotoIntoWall(fileName,title,description)
{
      
       var UserId=$("#option-container").attr('my_id'); 
       var UserDisplayName=$("#option-container").attr('DisplayName'); 
       var message=$("textarea#txtStatusBox").val();
       $.fn.colorbox.close();
      
//       alert(UserDisplayName); 
    
        
        $.ajax({
        
          type: "POST",
          url: "club.aspx/PublishPhotoToThisWall",
          data:"{'WallOwnerid':'" + UserId + "','WallOwnerName':'" + UserDisplayName + "','MaxId':'" + 0 + "','fileName':'" + fileName + "','title':'" + title + "','description':'" + description + "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
           var Feed=msg.d;
            HideWait();   
            
                var FeedBox=GetFeedBoxForThisFeed(Feed);
                $("#FeedContainer").prepend($(FeedBox));

                $(".SecondLevelSlider").not("#FeedContainerWrapper").slideUp('fast');            
                $("#FeedContainerWrapper").slideDown();   

             $('.timestamp').cuteTime();
             
             $(".WallPhotoLink").colorbox({}, function(){});

          },
          error: AjaxFailed
        });
        
}