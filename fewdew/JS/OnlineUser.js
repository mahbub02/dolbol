var GenericOnLineUserList;
$(document).ready(function(){
     $('.onlineMinMax,#OnlineUserBoxHeader').click(function(){               
//                $('.onlineMinMax').toggle();   
                $("#OnlineUserDisplayBox").toggle();
            });
});

$(document).everyTime(5000, function(i) {
          RefreshUserAndGetOnlineUserList();
        }, 0);
        
        
function RefreshUserAndGetOnlineUserList(){

    $.ajax({
            
              type: "POST",
              url: "club.aspx/RefreshUserAndGetOnlineUserList",
              data:"{'MyId':'" + parseInt( $("#hiddenUserId").val())+ "'}",
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function(msg) {
                        GenericOnLineUserList=msg.d;
                        PopulateOnlineUserList();
                       
                       
              },
              error: AjaxFailed
            });

}        

function PopulateOnlineUserList()
{
    if(GenericOnLineUserList!=null)
    {
        
    
//        if($("#OnlineUserDisplayBox").length<1)
//        {
//            var OnlineUserDisplayBox=$('<div></div>');
//            $(OnlineUserDisplayBox).attr('id','OnlineUserDisplayBox');
//            
////             var OnlineUserBoxHeader=$('<div></div>');
////            $(OnlineUserBoxHeader).attr('id','OnlineUserBoxHeader');
////            $(OnlineUserBoxHeader).text('Online friends');
//            
//            
//            
//            
//            
//            var OnlineUserContainer=$('<div></div>');
//            $(OnlineUserContainer).attr('id','OnlineUserContainer');
//            
////             $(OnlineUserDisplayBox).append(OnlineUserBoxHeader);
//             $(OnlineUserDisplayBox).append(OnlineUserContainer);
//            
//            $("#right-sider-accordioncontainer").append(OnlineUserDisplayBox); 
//            
////            var onlineMinMax1=$('<img />');
////            $(onlineMinMax1).addClass('onlineMinMax');
////            $(onlineMinMax1).attr('src','Images/Site/maximize.gif');
////            $(onlineMinMax1).css('cursor','pointer');
////            $(OnlineUserBoxHeader).append(onlineMinMax1);
////            
////            var onlineMinMax2=$('<img />');
////            $(onlineMinMax2).addClass('onlineMinMax');
////            $(onlineMinMax2).css('display','none');
////            $(onlineMinMax2).css('cursor','pointer');
////            $(onlineMinMax2).attr('src','Images/Site/minimize.gif');
////            $(OnlineUserBoxHeader).append(onlineMinMax2);
//            
//            $('.onlineMinMax').click(function(){               
//                $('.onlineMinMax').toggle();   
//                $("#OnlineUserContainer").toggle();
//            });
//            
//           
//        }

   
        $("#onlineUserNumber").text(GenericOnLineUserList.length);
        if(GenericOnLineUserList.length==0)
        {
            $("#OnlineUserBoxHeader").html('no online user');
            $("#OnlineUserBoxHeader").fadeIn();
        }
        else{
         $("#OnlineUserBoxHeader").fadeOut();
        }
        
   
        for (var i in GenericOnLineUserList)
        {
            var objUser = GenericOnLineUserList[i];
            var onlineUser=$('<div></div>');
            
            if($('#onlineUser'+objUser.Id).length<1)
            {
                $(onlineUser).attr('id','onlineUser'+objUser.Id);
                $(onlineUser).addClass('onlineUser');
                                ///
                                    $(onlineUser).hover(
                                                    function(e)
                                                    {
                                                     
                                                        if($("#user-status-tootip").length<1)
                                                        {
                                                            var ToolTips=$("<div></div>");
                                                            $(ToolTips).attr('id','user-status-tootip');
                                                            $(ToolTips).css('position','absolute');
                                                            $("body").append($(ToolTips));    
                                                        }
                                                    
                                                    $("#user-status-tootip").stop();    
                                                    $("#user-status-tootip").html($(this).attr('statusMessage'));
                                                    $("#user-status-tootip").css('left',e.pageX+"px");
                                                    $("#user-status-tootip").css('top',e.pageY+9+"px");
                                                    $("#user-status-tootip").css('z-index','2002');
                                                    $("#user-status-tootip").css('background-color','black');
                                                    $("#user-status-tootip").css('padding','5px');
                                                    $("#user-status-tootip").css('color','white');
                                                    $("#user-status-tootip").css('display','inline');
                                                 }
                                                ,
                                        
                                            function(e){
                                              
                                                $("#user-status-tootip").css('display','none');
                                                
                                            }
                                        
                                        );
                                ///
                
                var onlineUserImage=$('<div></div>');
                $(onlineUserImage).css('background-image','url(images/profile/'+objUser.Id+'_micro.jpg)');
                $(onlineUserImage).addClass('onlineUserImage');
                
                
                 var onlineUserName=$('<div></div>');
                $(onlineUserName).addClass('onlineUserName');
                $(onlineUserName).html(objUser.DisplayName);
                $(onlineUserName).attr('id','onlineUserName'+objUser.Id);
                $(onlineUserName).attr('displayName',objUser.DisplayName);
                
                $(onlineUser).append($(onlineUserImage));
                $(onlineUser).append($(onlineUserName));
                
                //$(onlineUser).html(objUser.DisplayName);
                $(onlineUser).attr('displayName',objUser.DisplayName);
                $(onlineUser).attr('statusMessage',objUser.StatusMessage+objUser.DisplayName);
                
                $(onlineUserName).click(function(){
                    var ClickedUserId=$(this).attr('id').split('onlineUserName')[1];
                    
                    optimizationAtSpeechUpdate(ClickedUserId,$(this).html(),"") 
                    
                   // alert($(this).attr('displayName')+"when clicked");  
                                      
                    OpenSpeechWindowSinceAvatarIsClicked(ClickedUserId,$(this).attr('displayName'),"");
                    ArrangementForScrolling(); 
                });
                $("#OnlineUserContainer").append(onlineUser);
            }
            
            

            
            
        }
         CleanOnlineUserList();
    }    
}   

function CleanOnlineUserList(){
    if(GenericOnLineUserList!=null)
    {
        $(".onlineUser").each(function(){
            if( isThisUserIsTheGenericOnlineList( $(this).attr('id').split("onlineUser")[1])==false)
             {
               
                 $("#onlineUser"+$(this).attr('id').split("onlineUser")[1]).remove();
             }
        });
    }
}

function isThisUserIsTheGenericOnlineList(id )
    {
            for (var i in GenericOnLineUserList)
                 {
                     var onlineUser = GenericOnLineUserList[i];
                     if(onlineUser.Id==id){
                        return true;
                     }
                 } 
                 return false; 
    }
