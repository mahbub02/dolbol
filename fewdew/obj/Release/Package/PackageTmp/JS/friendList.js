
$(document).ready(function(){

    $("#imgFriendList").click(function(e){
        var ClickedUserId=$(this).parent("#option-container").attr('my_id');
        $(".SecondLevelSlider").not("#imgFriendList").slideUp('fast');
        
        BindTheFriendList(ClickedUserId,e);
    });
});

function BindTheFriendList(userid,e)
{
         if($("#FriendListContainer").length<1)
                {
                    var avatardetails = $("div#avatar-details");
                    var offset = avatardetails.offset();
                    var top=0;
                    top=offset.top+ parseInt($("div#avatar-details").css('height').split('px')[0]); 
                    
                  
                    var FriendListContainer=$('<div></div>');
                    $(FriendListContainer).attr('id','FriendListContainer'); 
                    $(FriendListContainer).addClass('SecondLevelSlider');
                    $(FriendListContainer).css('left',"0px");
                    $(FriendListContainer).css('top',top+"px");
                                        
                    $("body").append(FriendListContainer);
                    //$(FriendListContainer).slideDown();
                    
                }


if($("#FriendListContainer").css('display')!='none')
{
$("#FriendListContainer").slideUp();
return;
}
$("#FriendListContainer").html('');

$("#secondleveltitle").html($("#option-container").attr('DisplayName')+'\'s Friend List');

$("#FriendListContainer").slideDown();
ShowWait(e);   
        
              $.ajax({
                    
                      type: "POST",
                      url: "club.aspx/GetFriendList",
                      data:"{'userid':'" + userid+ "'}",
                      contentType: "application/json; charset=utf-8",
                      dataType: "json",
                      success: function(msg) {
                      HideWait();
                          var FriendList=msg.d; 
                           $("#NoFriendMessage").remove();  
                            if(FriendList.length==0)
                            {
                                var NoFriendMessage=$("<div></div>");
                                  $(NoFriendMessage).attr('id','NoFriendMessage');
                                  $(NoFriendMessage).html('Friend list is empty ');
                                  $("#FriendListContainer").append($(NoFriendMessage));
                            }
                           
                            
                             for (var i in FriendList)
                               {
                                var Friend = FriendList[i];
                                //alert(Friend.UserId);
                                 
                                  var FriendBox=$("<div></div>");
                                  $(FriendBox).addClass('FriendBox');
                                  
                                  var FriendImage=$("<div></div>");
                                  $(FriendImage).addClass('FriendImage');
                                  $(FriendImage).css('background-image','url(images/profile/'+Friend.UserId+'_mini.jpg)');
                                    
                                  var FriendName=$("<div></div>");
                                  $(FriendName).addClass('FriendName');
                                  $(FriendName).html(Friend.DisplayName);
                                  $(FriendName).attr('id','FriendName'+Friend.UserId);
                                  $(FriendName).click(function(e){
                                    var userid= $(this).attr('id').split('FriendName')[1];
                                    var displayName=$(this).html();
                                    DisplayAvatarDetails(e,userid,displayName);
                                  });
                                  
                                  $(FriendBox).append($(FriendImage));
                                  $(FriendBox).append($(FriendName));
                                  
                                  $("#FriendListContainer").append($(FriendBox));
   
                                    
                               } 
                              
                      },
                      error: AjaxFailed
                    }); 
}
