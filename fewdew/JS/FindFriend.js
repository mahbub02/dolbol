$(document).ready(function(){

$("#btnSearchMoreUser").attr('MaxId','0');
$("#btnInvite").click(function(e){
SendInvitationEmail(e);
}); 
 
$("#findFriend").click(function(){

   // $("#FindFriendWrapper").css('display','inline-block');
    $("#FindFriendWrapper").toggle(); 
//    $("#FindFriendWrapper").css('top','25px');
    $("#FindFriendWrapper").css('left','600px');
    $("#FindFriendWrapper").css({position: "absolute",top:($(window).scrollTop()+25 )+"px"});
    
});
$("#FindFriendClose").click(function(){
    $("#FindFriendWrapper").toggle(); 
});

    $("#btnSearchMoreUser").click(function(){
       GetUserListAndBindUser(); 
    });
    
    $("#btnFriendSearch").click(function(){
    
        if($("#txtSearchFriend").val()=="")
        {
            $("#txtSearchFriend").css('border','1px solid red');
        }
        else
        {
            $("#btnSearchMoreUser").attr('MaxId','0');
            $("#txtSearchFriend").css('border','1px solid #859A16');           
            $("#searchedUserListContainer").html("");
            GetUserListAndBindUser();
        }
    });
});

function SendInvitationEmail(e)
{
ShowWait(e);
  $.ajax({
        
                  type: "POST",
                  url: "club.aspx/SendInvitationEmail",
                  data:"{'email':'" + $("#InvitationTo").html() + "','Message':'" + $("#txtInvitationMessage").val() + "'}",
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function(msg) {
                    HideWait();
                     if(msg.d=="Done")
                     {
                         $("#InvitationForm").fadeOut();
                        jqDialog.notify("Invitation email has been sent", 3);
                     }
                     else{
                         
                        jqDialog.notify("Invitation email sending failed", 3);
                     }                           
                  },
              error: AjaxFailed
                });  
}
function GetUserListAndBindUser()
{
    $.ajax({
        
                  type: "POST",
                  url: "club.aspx/SearchUser",
                  data:"{'token':'" + $("#txtSearchFriend").val() + "','MaxId':'" + $("#btnSearchMoreUser").attr('MaxId') + "'}",
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function(msg) {
                        var userList=msg.d;
                        $("#btnSearchMoreUser").fadeOut(); 
                         $("#InvitationForm").fadeOut();
                      
                        if($(userList).length==0)
                        {
                            $("#SearchMessage").html('No search result');
                            
                           if( validateEmail($("#txtSearchFriend").val())==true)
                           {
                             $("#InvitationForm").fadeIn();
                             $("#InvitationTo").html($("#txtSearchFriend").val());
                           }
                        }
                        else
                        {
                             $("#SearchMessage").html("");
                            if($(userList).length==10)
                            {
                               $("#btnSearchMoreUser").fadeIn(); 
                            }                            
                            
                            for (var j in userList)
                            {
                             
                              
                               var user = userList[j];                               
                               var MaxId= parseInt( $("#btnSearchMoreUser").attr('MaxId'));
                               if(MaxId<user.Id)
                               {
                                $("#btnSearchMoreUser").attr('MaxId',user.Id);
                               }
                              
                               var userbox= GetUserBoxForThisUser(user);
                               $("#searchedUserListContainer").append(userbox);
                            }
                        }
                           
                       
                        
                  },
              error: AjaxFailed
                });
}

function GetUserBoxForThisUser(user)
{
  var SearchedUserBlock= $("<div></div>");
  $(SearchedUserBlock).addClass('SearchedUserBlock');
  
  var SearchedUserPhoto= $("<div></div>");
  $(SearchedUserPhoto).addClass('SearchedUserPhoto');
  $(SearchedUserPhoto).css('background-image','url(images/profile/'+user.Id+'_thumb.jpg)');
  
  var SearchedUserName=  $("<div></div>");
  $(SearchedUserName).addClass('SearchedUserName');
   $(SearchedUserName).html(user.DisplayName);
   
  $(SearchedUserBlock).attr('displayName',user.DisplayName);
  $(SearchedUserBlock).attr('userid',user.Id);
  
  $(SearchedUserBlock).append($(SearchedUserPhoto));
  $(SearchedUserBlock).append($(SearchedUserName));
  
  $(SearchedUserBlock).click(function(e){
     DisplayAvatarDetails(e,$(this).attr('userid'),$(this).attr('displayName'));
  }); 
  
  return $(SearchedUserBlock);
}


function validateEmail(address) {
        var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
        if(reg.test(address) == false) {
            return false;
        }
        return true;
    }