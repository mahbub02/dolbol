$(document).ready(function(){
    $("#friendRequestLI").click(function(e){
        ShowTheRequestList(e);
    });
    
    showTheNumberOfPendingRequest();
           
            
      
});
function ShowTheRequestList(e)
{
       
            if($("#RequestContainer").length<1)
                {
//                    var clickedButton = $("div#friendRequest");
//                    var offset = clickedButton.offset();
                    
                   
                    
                    var RequestContainer=$('<div></div>');
                    $(RequestContainer).attr('id','RequestContainer'); 
                   //  $("#RequestContainer").css({position: "absolute",top:($(window).scrollTop()+25 )+"px"});
                     
                    $(RequestContainer).addClass('topSlider'); 
                                                                          
                    $(RequestContainer).css('left',"10px");
                    
                    $(RequestContainer).css('top',"25px");
                    $(RequestContainer).css('position',"absolute");
                    $(RequestContainer).css('display',"none");
                    $("body").append(RequestContainer);
                    
                }
     $("#RequestContainer").css({position: "absolute",top:($(window).scrollTop()+25 )+"px"});           
                
     $(".SecondLevelSlider").css('display','none');  
    $(".topSlider").not("#RequestContainer").slideUp();
      
    if($("#RequestContainer").css('display')!="none")
    {
        $("#RequestContainer").slideToggle("slow");    
        return;
    }         
    ShowWait(e);            
                                    
    $.ajax({
                    
                      type: "POST",
                      url: "club.aspx/GetFriendAwaitingForMyResponse",
                      data:"{'userid':'" + $("#hiddenUserId").val()+ "'}",
                      contentType: "application/json; charset=utf-8",
                      dataType: "json",
                      success: function(msg) {
                        var RequestList=msg.d;
                         HideWait();
                         $("#RequestContainer").html("");
                         
                         
                         if(RequestList.length==0)
                         {
                           $("#friendRequest").html("Request");
                            
                            $("#RequestContainer").html('There is no pending request');
                         }
                         else{
                            $("#friendRequest").html("Request("+RequestList.length+")");
                         }
                              for (var i in RequestList)
                               {
                                var Request = RequestList[i];
                                     

                                    var RequestBox=$("<div></div>");
                                    $(RequestBox).addClass('RequestBox');
                                    
                                    var RequestRequester=$("<div></div>");
                                    $(RequestRequester).addClass('RequestRequester');
                                    $(RequestRequester).html(Request.DisplayName);
                                    
                                    var RequesterDetails=$("<div></div>");
                                    $(RequesterDetails).addClass('RequesterDetails');
                                    $(RequesterDetails).html("has sent you friend request");
                                    
                                    var RequestController=$("<div></div>");
                                    $(RequestController).addClass('RequestController');
                                    $(RequestController).attr('id','RequestController'+Request.UserId);
                                    
                                    var RequestAccept=$("<div></div>");
                                    $(RequestAccept).addClass('RequestAccept');
                                    $(RequestAccept).html('Accept');
                                    $(RequestAccept).click(function(e){
                                        RequestAccepted(this,e);
                                    });
                                    
                                    var RequestReject=$("<div></div>");
                                    $(RequestReject).addClass('RequestReject');
                                    $(RequestReject).html('Reject');
                                    $(RequestReject).click(function(e){
                                        RequestRejected(this,e);
                                    });
                                    
                                    $(RequestBox).append($(RequestRequester)); 
                                    $(RequestBox).append(RequesterDetails);
                                    $(RequestBox).append($(RequestController));
                                     
                                    $(RequestController).append(RequestAccept);
                                    $(RequestController).append(RequestReject);
                                                                       
                                                                     
                                    
                                    $(RequestContainer).append(RequestBox);                                  
                                    
                                   
                                 
                                                                  
                               }  
                               $("#RequestContainer").slideToggle("slow");    
                      },
                      error: AjaxFailed
                    });
}

function RequestAccepted(thisbutton,e)
{
var userid= $(thisbutton).parent(".RequestController").attr('id').split("RequestController")[1];
 ShowWait(e);  

     $.ajax({
            
              type: "POST",
              url: "club.aspx/ConfirmedAsFriend",
              data:"{'userid':'" + userid+ "'}",
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function(msg) {
                        HideWait();
                        GenericSpeechList=msg.d;
                        BindSpeechWindows();
                        
                        ArrangeTheSpeechFooter(userid);
                        OpendSpeechWindowForUser(userid);
                        ManageLeftAndRightSlide();
                        
                        $(thisbutton).parent('.RequestController').parent(".RequestBox").children('.RequesterDetails').html('is now your friend');            
                        $(thisbutton).parent('.RequestController').remove();
                       
              },
              error: AjaxFailed
            });
  

}
function RequestRejected(thisbutton,e)
{
 var userid= $(thisbutton).parent(".RequestController").attr('id').split("RequestController")[1];
 

 ShowWait(e);  
     $.ajax({
            
              type: "POST",
              url: "club.aspx/FriendShipRequestRejected",
              data:"{'userid':'"+userid+"'}",
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function(msg) {
                        HideWait();
                        
                        $(thisbutton).parent('.RequestController').parent(".RequestBox").children('.RequesterDetails').html('is rejected');            
                        $(thisbutton).parent('.RequestController').remove();
                       
              },
              error: AjaxFailed
            });
              
}

function showTheNumberOfPendingRequest()
{
                $.ajax({
                    
                      type: "POST",
                      url: "club.aspx/NumberOfPendingRequest",
                      data:"{'userid':'" + $("#hiddenUserId").val()+ "'}",
                      contentType: "application/json; charset=utf-8",
                      dataType: "json",
                      success: function(msg) {
                               var count=parseInt(msg.d);
                               if(count>0)
                               {
                                $("#friendRequest").html("Request("+count+")");
                               }
                      },
                      error: AjaxFailed
                    });
}

