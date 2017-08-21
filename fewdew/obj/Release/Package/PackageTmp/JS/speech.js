var ConversationList;
var speechWindowWidth=230;
var speechWindowheight=300;
var GenericSpeechList; 
 
function ShowSpeechFooterContainer(){
        if($("#speechFooterContainer").length<1)
        {
            var speechFooterContainer=$('<div></div>');
            $(speechFooterContainer).attr('id','speechFooterContainer');
            
            var leftScroll=$('<div></div>');
            $(leftScroll).attr('id','leftScroll');
            $(leftScroll).text("");
            $(leftScroll).click(function(){
                SrollToLeft();
            });
            
             var rightScroll=$('<div></div>');
            $(rightScroll).attr('id','rightScroll');
            $(rightScroll).text("");
            $(rightScroll).click(function(){
                SrollToRight();
            }); 
          
            $("body").append(leftScroll);
            $("body").append(rightScroll);                               
            $("body").append(speechFooterContainer);           
        } 
        
            $("#speechFooterContainer").css('top',(($(window).scrollTop()+$(window).height())-25)+"px");
            $("#speechFooterContainer").css('left',($(window).width()-700-50)+"px");
            
            $("#leftScroll").css('top',$("#speechFooterContainer").css('top'));
            $("#leftScroll").css('left',($("#speechFooterContainer").css('left').split("px")[0]-$("#leftScroll").css('width').split("px")[0])+"px");
            $("#leftScroll").css('height',$("#speechFooterContainer").css('height'));
            
            $("#rightScroll").css('top',$("#speechFooterContainer").css('top'));
            $("#rightScroll").css('left',( parseInt( $("#speechFooterContainer").css('left').split("px")[0])+parseInt($("#speechFooterContainer").css('width').split("px")[0]))+"px");
            $("#rightScroll").css('height',$("#speechFooterContainer").css('height'));
        
}

function SrollToRight(){

    var indexOfFirstVisible= $(".speechFooter").index( $(".speechFooter:visible:first"))
    if($(".speechFooter")[indexOfFirstVisible-1]!=null)
        {
            var userid=$( $(".speechFooter")[indexOfFirstVisible-1]).attr('id').split("speechFooter")[1];
           // ArrangeTheSpeechFooter(userid); 
             ArrangeTheSpeechFooter(userid);
            OpendSpeechWindowForUser(userid);
            ManageLeftAndRightSlide();
        }
    }
  
    

function SrollToLeft(){
     
        var indexOfFirstVisible= $(".speechFooter").index( $(".speechFooter:visible:last"))
        var userid=$( $(".speechFooter")[indexOfFirstVisible+1]).attr('id').split("speechFooter")[1];
         ArrangeTheSpeechFooter(userid);
            OpendSpeechWindowForUser(userid);
            ManageLeftAndRightSlide();
    }
    
$(document).ready(function(){
 ShowSpeechFooterContainer();
 
    $(".avatarUser").click( function(){
            
            CreateOrOpenHisSpeechWindow($(this).attr("id"),$(this).attr("id"));
            var userid=$(this).attr("id");
           
            ArrangeTheSpeechFooter(userid);
            OpendSpeechWindowForUser(userid);
            ManageLeftAndRightSlide();
    });
  $(window).scroll(function () { 
       ArrangementForScrolling()
    }); 
    
    GetAllSpeechesForThisUser(GetLoggedInUserId());
          
     
});

function ArrangementForScrolling(){

        ShowSpeechFooterContainer();
       //$("#speechFooterContainer,.speechFooter:visible,.speechWindow:visible").fadeOut();
        var topStart=parseInt($("#speechFooterContainer").css('top').split("px")[0]);
        $(".speechFooter:visible").css('top',topStart+"px");
       $(".speechWindow:visible").each(function(){
            $(this).css('top', parseInt(topStart-parseInt( $(this).css('height').split("px")[0]))+"px");
       });
}
    
    
function CreateOrOpenHisSpeechWindow(userid,displayName){   
   if( $("#speechFooter"+userid).length  <1)
   {
   
   
            var speechFooter=$('<div></div>');
            $(speechFooter).attr('id',"speechFooter"+userid);
            $(speechFooter).addClass('speechFooter');
           
            
            var footerClose=$('<span></span>');
            $(footerClose).attr('id','footerClose'+userid);
            $(footerClose).html("x");
            $(footerClose).addClass('footerClose');
            $(footerClose).click(function(){
                OptimizationForRemoveWindow($(this));
                RemoveThisWindow($(this));
                 

            });
            
            var footerUserName=$('<span></span>');
            $(footerUserName).attr('id','footerUserName'+userid);
            $(footerUserName).html(displayName);
            $(footerUserName).addClass('footerUserName');
            
            $(speechFooter).append(footerUserName);
            $(speechFooter).append(footerClose);
            
            $(speechFooter).click(function(){
                    $(".speechWindow").not($("#speechWindow"+userid)).fadeOut();
                    $("#speechWindow"+userid).css('left',$("#speechFooter"+userid).css('left')); 
                    $("#speechWindow"+userid).css('top', parseInt( parseInt($("#speechFooterContainer").css('top').split("px")[0])-parseInt($("#speechWindow"+userid).css("height").split("px")[0]))+"px" );  
                    $("#speechWindow"+userid).toggle();
                    $(this).removeClass('blink');
                    ArrangementForScrolling();
                
            });
            $("body").append(speechFooter); 
    
    
            var speechWindow=$('<div></div>');
                $(speechWindow).addClass('speechWindow');
                $(speechWindow).attr('id',"speechWindow"+userid);
                $(speechWindow).attr('displayName',"speechWindow"+displayName);
                    
            var speechWindowheader=$('<div></div>');
                $(speechWindowheader).addClass('speechWindowheader');
                $(speechWindowheader).html(displayName);
            var speechWindowSpeehList=$('<div></div>');
                $(speechWindowSpeehList).addClass('speechWindowSpeehList');
                $(speechWindowSpeehList).attr('id',"speechWindowSpeehList"+userid);
                
            var speechWindowEntryBox=$('<div></div>');
                $(speechWindowEntryBox).addClass('speechWindowEntryBox');

            var speechWindowTextBox=$('<textarea></textarea>');
                $(speechWindowTextBox).addClass('speechWindowTextBox');
               
             $(speechWindowTextBox).keypress(function(e){
                                        if(e.keyCode == 13)
                                        {
                                           // alert($(this).parent().parent(".speechWindow").attr('id').split('speechWindow')[1]);
                                           
                                            updateSpeech( $(this).parent().parent(".speechWindow").attr('id').split('speechWindow')[1],$(this).parent().parent(".speechWindow").attr('displayName').split('speechWindow')[1] , $(this).val());
                                            $(this).val("");
                                        }
                                    });  
                
            $(speechWindow).append(speechWindowheader);
            $(speechWindow).append(speechWindowSpeehList);     
            $(speechWindowEntryBox).append(speechWindowTextBox);  
            $(speechWindow).append(speechWindowEntryBox);
            $("body").append(speechWindow); 
   } 
  
 
}

function OpendSpeechWindowForUser(userid){
    $('.speechWindow').fadeOut();     
    $("#speechWindow"+userid).css('left',$("#speechFooter"+userid).css('left')); 
    $("#speechWindow"+userid).css('top', parseInt( parseInt($("#speechFooterContainer").css('top').split("px")[0])-parseInt($("#speechWindow"+userid).css("height").split("px")[0]))+"px" );  
    $("#speechWindow"+userid).fadeIn();
}

function ArrangeTheSpeechFooter(userid){

    var LeftTemp=parseInt($("#speechFooterContainer").css('left').split("px")[0]);
    var topStart=parseInt($("#speechFooterContainer").css('top').split("px")[0]);
        if($("#speechFooter"+userid).css('display')=="none")
        {
             
            if($(".speechFooter").length>3)
            {
                
              $(".speechFooter").css('display','none');
              var TopIndex;
              var BottomIndex;  
                  if( $(".speechFooter").index($("#speechFooter"+userid))>2)
                   {
                    TopIndex=$(".speechFooter").index($("#speechFooter"+userid))+1;
                    BottomIndex=TopIndex-3;
                   }
                  else if( $(".speechFooter").index($("#speechFooter"+userid))<=2)
                   {
                    TopIndex=3//$(".speechFooter").index($("#speechFooter"+userid))+1;
                    BottomIndex=0;
                   }
                   
                    $(".speechFooter").slice(BottomIndex,TopIndex).each(function(){
                        $(this).css('top',topStart+"px");
                        $(this).css('left',LeftTemp+"px");
                        $(this).css('display',"inline");
                        LeftTemp=LeftTemp+ parseInt($(this).css('width').split("px")[0]);
                    });
            }
            else
            {
               $(".speechFooter").each(function(){
                        $(this).css('top',topStart+"px");
                        $(this).css('left',LeftTemp+"px");
                        $(this).css('display',"inline");
                        LeftTemp=LeftTemp+ parseInt($(this).css('width').split("px")[0]);
                    }); 
            }
       }
         
         
         
      
         
             // IsOutSideTheLeftEnd(userid);   
                     

}

function ManageLeftAndRightSlide()
{
        $("#rightScroll").html('<span>'+ $(".speechFooter").index( $(".speechFooter:visible:first"))+'</span>');
         if($(".speechFooter").index( $(".speechFooter:visible:first"))>0)
         {
            $("#rightScroll").fadeIn();
         }else
         {
         $("#rightScroll").fadeOut();
         }
         
         $("#leftScroll").html('<span>'+parseInt($(".speechFooter").length-$(".speechFooter").index( $(".speechFooter:visible:last"))-1)+'</span>');             
         if(($(".speechFooter").length-$(".speechFooter").index( $(".speechFooter:visible:last"))-1)>0)
         {
          $("#leftScroll").fadeIn();
         }
         else
         {
         $("#leftScroll").fadeOut();
         }
}


//function WhereIsThisWindow(id)
//{
//      if(  $(".speechFooter").length>3 && $("#speechFooter"+id).css('display')=='none')
//        {
//            if($(".speechFooter").index( $(".speechFooter:visible:first"))>$(".speechFooter").index( $("#speechFooter"+id)) )
//            {
//                return -1;
//            }
//            else{
//               return +1; 
//            }
//            
//        }
//        else{
//            return 0;
//        }
//}

function optimizationAtSpeechUpdate(ClickedUserId,ClickedUserDisplayName,justformali)
{
  

    var user2id=null;
    var user2displayName=null;
    var isAlreadyExist=false;
    for (var i in GenericSpeechList)
       {
        
       var speech = GenericSpeechList[i];
         if( $("#hiddenUserId").val()==speech.User2Id)
         {
             isAlreadyExist=true;           
         }
       }
    
    if(isAlreadyExist==false)
    {
         speech=new Speech("",ClickedUserId,"",ClickedUserDisplayName,"","","","");
        
     
        
          
      
        var length=GenericSpeechList.length;
        
        GenericSpeechList[length]=speech;
    }
    BindSpeechWindows();                        
    ArrangeTheSpeechFooter(ClickedUserId);
    OpendSpeechWindowForUser(ClickedUserId);
    ManageLeftAndRightSlide();
    
         
}
function Speech(User1Id,User2Id,User1DisplayName,User2DisplayName,Message,WindowStatus,IsDelivered,LastModifiedDate)
{
this.User1Id=User1Id;
this.User2Id=User2Id;
this.User1DisplayName=User1DisplayName;
this.User2DisplayName=User2DisplayName;

this.Message=Message;
this.WindowStatus=WindowStatus;
this.IsDelivered=IsDelivered;
this.LastModifiedDate=LastModifiedDate;
}


$(document).ready(function(){
//    $("#initiate_chat").click(function(){
//       var ClickedUserId=$(this).parent("#avatarMenu").attr('my_id');
//       var ClickedUserDisplayName=$(this).parent("#avatarMenu").attr('DisplayName');
//        
//      OpenSpeechWindowSinceAvatarIsClicked(ClickedUserId,ClickedUserDisplayName,"");
//      ArrangementForScrolling();  
//    });
//    
//    $("#sendFriendRequst").click(function(){
//       var ClickedUserId=$(this).parent("#avatarMenu").attr('my_id');
//       var ClickedUserDisplayName=$(this).parent("#avatarMenu").attr('DisplayName');
//          
//       OpenSpeechWindowSinceAvatarIsClicked(ClickedUserId,ClickedUserDisplayName,"");
//       ArrangementForScrolling();
//       SendInstanceFriendRequestToThisUser($(this).parent("#avatarMenu").attr('my_id'),ClickedUserDisplayName);  
//    });
  
});

function SendInstanceFriendRequestToThisUser(userid,UserDisplayName){

    
    $.ajax({
            
              type: "POST",
              url: "club.aspx/SendInstanceFriendRequestToThisUser",
              data:"{'UserId':'" + userid+ "','UserDisplayName':'" + UserDisplayName + "'}",
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function(msg) {
                        GenericSpeechList=msg.d;
                        BindSpeechWindows();
                        //ArrangeTheSpeechFooter(userid);
                        //alert(userid);
                      
                       
              },
              error: AjaxFailed
            });
            
}
function optimizationForUpdateSpeech(userid,displayName,message)
{
var SenderName=$("#hiddenUserDisplayName").val();
var str= "<div class=\"speech-box\">"+
                " <div class=\"speech-sender\">"+
                    SenderName+
                "</div>"+
                "<div class=\"action-time\">"
                  +" " + // +DateTime.Now.ToShortTimeString() +
                "</div>"+
                 "<div class=\"speech\">"
                    +  message +
                "</div>" +
                "<div class=\"speechProgress\">"
                    + ""  +
                "</div>" +
            "</div>";
           
            

 $("#speechWindowSpeehList"+userid).html($("#speechWindowSpeehList"+userid).html()+str);

}

function updateSpeech(userid,displayName,message){

//alert(displayName+"1");
optimizationForUpdateSpeech(userid,displayName,message);

if($.browser.msie && $.browser.version.substr(0,1)<7)
 {
    
}
else{
    message=$().emoticon(message);
}



    $.ajax({
            
              type: "POST",
              url: "club.aspx/UpdateSpeech",
              data:"{'UserId':'" + userid+ "','displayName':'" + displayName + "','Message':'" + message + "'}",
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function(msg) {
                        GenericSpeechList=msg.d;
                        BindSpeechWindows();
                        //ArrangeTheSpeechFooter(userid);
                        //alert(userid);
                      
                       
              },
              error: AjaxFailed
            });
            
}
function OpenSpeechWindowSinceAvatarIsClicked(userid,ClickedUserDisplayName,message)
{
  // alert(ClickedUserDisplayName+"2");
   if($.browser.msie && $.browser.version.substr(0,1)<7)
    {
    
    }
else{
    message=$().emoticon(message);
    }
    $.ajax({
            
              type: "POST",
              url: "club.aspx/UpdateSpeech",
              data:"{'UserId':'" + userid+ "','displayName':'" + ClickedUserDisplayName + "','Message':'" + message + "'}",
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function(msg) {
                        GenericSpeechList=msg.d;
                        BindSpeechWindows();                        
                        ArrangeTheSpeechFooter(userid);
                        OpendSpeechWindowForUser(userid);
                        ManageLeftAndRightSlide();
                        //alert(userid);
                      
                       
              },
              error: AjaxFailed
            });
}

function BindSpeechWindows(){
   
     if(GenericSpeechList!=null)
         {
         
                for (var i in GenericSpeechList)
                 {
                     var speech = GenericSpeechList[i];
                       CreateOrOpenHisSpeechWindow(speech.User2Id,speech.User2DisplayName);
                     
                       ArrangeTheSpeechFooter(speech.User2Id);
                       if ($(".speechFooter:visible").length<1)
                       {
                        OpendSpeechWindowForUser(speech.User2Id);
                       }
                       ManageLeftAndRightSlide();
                      
                     
                      if($("#speechWindowSpeehList"+speech.User2Id).html()!=speech.Message)
                      {
                         $("#speechWindowSpeehList"+speech.User2Id).html(speech.Message);
                          var objDiv = document.getElementById("speechWindowSpeehList"+speech.User2Id);
                          objDiv.scrollTop = objDiv.scrollHeight; 
                           
//                          alert($("#speechWindow"+speech.User2Id).css('display')); 
                          
                          if($("#speechWindow"+speech.User2Id).css('display')!='block')
                          {
                            $("#speechFooter"+speech.User2Id).addClass('blink');
                          }
                          else
                          {
                            $("#speechFooter"+speech.User2Id).removeClass('blink');
                          }
                      }
                      
                        
                      
                 }
          } 
                  
}

function GetAllUndeliveredSpeechForThisUser(userid){
 
 $.ajax({
            
              type: "POST",
              url: "club.aspx/GetAllUnDeliveredSpeechesForThisUser",
              data:"{'UserId':'" + userid+ "'}",
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function(msg) {
                        GenericSpeechList=msg.d;
                       
                       
              },
              error: AjaxFailed
            });
 
 }
 
 function GetAllSpeechesForThisUser(userid){
 
 $.ajax({
            
              type: "POST",
              url: "club.aspx/GetAllSpeechesForThisUser",
              data:"{'UserId':'" + userid+ "'}",
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function(msg) {
                        GenericSpeechList=msg.d;
                        BindSpeechWindows();
                        //alert(GenericSpeechList.length);
                       
                       
              },
              error: AjaxFailed
            });
 
 }
 
 
 
 $(document).everyTime(10000, function(i) {
         // GetAllUndeliveredSpeechForThisUser(GetLoggedInUserId());
          BindSpeechWindows();
        }, 0);
        
   
   function GetLoggedInUserId(){
      return $("#hiddenUserId").val();
   }     
 
function OptimizationForRemoveWindow(footerClose)
{
  var userid=$(footerClose).attr('id').split('footerClose')[1];
  var index=null;
  for (var i in GenericSpeechList)
       {
        
       var speech = GenericSpeechList[i];
         if( userid==speech.User2Id)
         {
             index=i;           
         }
       }
    if(index!=null)
    {
        GenericSpeechList[i]=null;
       
    }   
}


function RemoveThisWindow(footerClose)
{
 $("#speechFooter"+$(footerClose).attr('id').split('footerClose')[1]).remove();
 $("#speechWindow"+$(footerClose).attr('id').split('footerClose')[1]).remove();
 $(footerClose).remove();

 
 $.ajax({
            
              type: "POST",
              url: "club.aspx/DeleteSpeechWithThisUser",
              data:"{'MyId':'" + parseInt( $("#hiddenUserId").val())+ "','UserId':'" + $(footerClose).attr('id').split('footerClose')[1]+ "'}",
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function(msg) {
                        GenericSpeechList=msg.d;
                       
                       
              },
              error: AjaxFailed
            });
 
}

//$(document).everyTime(10000, function(i) {
//      
//          CleanSpeecherWindow();
//        }, 0);

//function CleanSpeecherWindow()
//{
//    if(GenericSpeechList!=null)
//    {
//        $(".speechWindow").each(function(){
//            if( isThisSpeechWindowExist( $(this).attr('id').split("speechWindow")[1])==false)
//             {
//               
//                 $("#speechFooter"+$(this).attr('id').split("speechWindow")[1]).remove();
//                 $("#speechWindow"+$(this).attr('id').split("speechWindow")[1]).remove();
//                 $("#footerClose"+$(this).attr('id').split("speechWindow")[1]).remove();
//                  
//             }
//        });
//    }
//               
//}

//function isThisSpeechWindowExist(id )
//    {
//            for (var i in GenericSpeechList)
//                 {
//                     var speech = GenericSpeechList[i];
//                     if(speech.User2Id==id){
//                        return true;
//                     }
//                 } 
//                 return false; 
//    }