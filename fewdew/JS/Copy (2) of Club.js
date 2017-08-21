var userText;
 
 var GenericChatterList;   

$(document).ready(function(){
    DuringReady();    
});


        $(document).everyTime(3000, function(i) {
                  GetRoomChatterListAndUpdateBackGroundPosition();
                }, 0);
 
  
        $(document).everyTime(200, function(i) {
          BindRoomChatter();
        }, 0);

  
        
$(document).everyTime(3000, function(i) {
  CleanUserList();
}, 0);


$(function(){
        positionFooter(); 
        function positionFooter(){
	        $("#emo-list").css({position: "absolute",top:($(window).scrollTop()+$(window).height()-$("#emo-list").height()-40)+"px"});
	        $("#OnlineUserDisplayBox").css({position: "absolute",top:($(window).scrollTop()+$(window).height()-$("#OnlineUserDisplayBox").height()-40)+"px"});
	        $("#footer-inner").css({position: "absolute",top:($(window).scrollTop()+$(window).height()-$("#footer-inner").height())+"px"});
	        $("#ChatHistoryBoxContainer").css({position: "absolute",top:($(window).scrollTop()+$(window).height()-$("#ChatHistoryBoxContainer").height()-40)+"px"});
	        $("#header-area").css({position: "absolute",top:($(window).scrollTop())+"px"});
	        $("#avatar-details").css({position: "absolute",top:($(window).scrollTop()+25 )+"px"});
	        $("#FindFriendWrapper").css({position: "absolute",top:($(window).scrollTop()+25 )+"px"});
	        $("#RequestContainer").css({position: "absolute",top:($(window).scrollTop()+25 )+"px"});
	        $("#region-container").css({position: "absolute",top:($(window).scrollTop()+$(window).height()-$("#region-container").height()-40)+"px"});
	        
	        
	                var avatardetails = $("div#avatar-details");
                    var offset = avatardetails.offset();
                    var top=0;
                    top=offset.top+ parseInt($("div#avatar-details").css('height').split('px')[0],10); 
	                $("#FeedContainerWrapper,#FriendListContainer,#RequestContainer").css('left',"0px");
                    $("#FeedContainerWrapper,#FriendListContainer,#RequestContainer").css('top',top+"px"); 
                    
                    
	        
	        
        }
     
        $(window).scroll(function(){
            positionFooter();
        });
	    $(window).resize(function(){
            positionFooter();
        });    
	      
});

$(document).ready(function(){
    $("#txtChatTextBox").keypress(function(e){
        if(e.keyCode == 13)
        {
            SubmitMyText($(this).val());
            $(this).val("");
        }
    }).keydown(function(){
       if($(this).val().length>50)
       {
       $(this).val( $(this).val().toString().substr(0,50));
       } 
    });
});
    
function GetRoomId(){
    return $("#hiddenRoomId").val();
}


function ShowHideAvatar(){
    $(".ShowHideAvatarList").click( function(e){
        $(".ShowHideAvatarList").toggle();
        $("#sample-container").css('left',e.pageX+'px');
        $("#sample-container").css('top',(e.pageY-170)+'px');
        $("#sample-container").toggle('fast');
    });
}

function OptimizationForSubmitText(mytext)
{
   
   
   for (var i in GenericChatterList)
   {
   var Chatter = GenericChatterList[i];
     if( $("#hiddenUserId").val()==Chatter.Id)
     {
        GenericChatterList[i].Message=mytext;
       
       BindChatHistory(GenericChatterList[i]);
     }
   }
    $("#chatbox"+$("#hiddenUserId").val()).fadeIn('slow');
   
   // $("#chatterName"+$("#hiddenUserId").val()).css('top','0px');
   $("#chatbox"+$("#hiddenUserId").val()).css('display','inline-block');
  // $("#chatbox"+$("#hiddenUserId").val()).children(".OnlyText").text(mytext);  
    
}
function SubmitMyText(mytext)
{
    OptimizationForSubmitText(mytext);
   if($(":checkbox").attr('value')=="b")
   {
     mytext="<span >"+mytext+"</span>";
   }
    $.ajax({
        
          type: "POST",
          url: "club.aspx/PostMyText",
          data:"{'roomId':'" +GetRoomId() + "','mytext':'" +mytext+ "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
                    
          },
          error: AjaxFailed
        });
}
        
function CleanUserList()
{
    if(GenericChatterList!=null)
    {
        $(".avatar").each(function(){
            if( IsThisIdExistInGenericList( $(this).attr('id'))==false)
             {
                $(this).remove();
             }
        });
    }
               
}

function IsThisIdExistInGenericList(id )
    {
            for (var i in GenericChatterList)
                 {
                     var Chatter = GenericChatterList[i];
                     if(Chatter.Id==id){
                        return true;
                     }
                 } 
                 return false; 
    }

function OptimizationAtUpdateMyAvatar(e)
{
   for (var i in GenericChatterList)
   {
   var Chatter = GenericChatterList[i];
     if( $("#hiddenUserId").val()==Chatter.Id)
     {
        GenericChatterList[i].Top=e.pageY+"px";
        GenericChatterList[i].Left=e.pageX+"px";
       
     }
   }  
}
function DuringReady(){
   // BindSampleAvatar();
    ShowHideEmos();
    //ShowHideAvatar();
    $("#club-chatter").click( function(e){
       
        if(IsThisPointIsInsideTheClubAreas(e.pageX,e.pageY)==-1||IsThisPointIsInsideTheClubAreas(e.pageX,e.pageY)>0)
        {
           OptimizationAtUpdateMyAvatar(e);
            UpdateMyAvatar(e);
        }
        
//        if($(this).attr("id")!="avatarMenu")
//        {
//           $("#avatarMenu").fadeOut("slow");
//        }
    });
//    $("#club-chatter").hover(function(){
//         $("#avatarMenu").fadeOut("slow");
//    });
}



//function BindSampleAvatar(){
//    $(".sample-avatar").hover(function(){
//        $(".sample-avatar").css('border','3px solid #FCFCCC');
//        $(this).css('border','3px solid #CCC');
//         SelectAvatar($(this).attr('src'),RoomId());
//    }).click(function(){
//        SelectAvatar(this);
//    });
//}

function UpdateMyAvatar(e){
$("#"+$("#hiddenUserId").val()).removeClass("direction_enable");
//alert($("#hiddenUserId").val());
//alert( $("#"+$("#hiddenUserId").val()).css('background-position'));
   $.ajax({
        
          type: "POST",
          url: "club.aspx/UpdateMyAvatar",
          data:"{'roomId':'" + GetRoomId() + "','backPos':'" + $("#"+$("#hiddenUserId").val()).css('background-position') + "','top':'" + parseInt(e.pageY-32,10) + "','left':'" + parseInt( e.pageX-32,10) + "','userText':'" + userText + "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
                    GenericChatterList=msg.d; 
          },
          error: AjaxFailed
        }); 
}
function StopMeHere(){
$("#"+$("#hiddenUserId").val()).addClass("direction_enable");
//alert($("#hiddenUserId").val());
//alert( $("#"+$("#hiddenUserId").val()).css('background-position'));
   $.ajax({
        
          type: "POST",
          url: "club.aspx/UpdateMyAvatar",
          data:"{'roomId':'" + GetRoomId() + "','backPos':'" + $("#"+$("#hiddenUserId").val()).css('background-position') + "','top':'" + parseInt($("#"+$("#hiddenUserId").val()).css('top'),10) + "','left':'" + parseInt($("#"+$("#hiddenUserId").val()).css('left'),10) + "','userText':'" + userText + "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
                    GenericChatterList=msg.d; 
          },
          error: AjaxFailed
        }); 
}



function GetRoomChatterListAndUpdateBackGroundPosition(){
 $.ajax({
        
          type: "POST",
          url: "club.aspx/GetRoomChatterListAndUpdateBackGroundPosition",
          data:"{'roomId':'" + GetRoomId() + "','backPos':'" + $("#"+$("#hiddenUserId").val()).css('background-position') + "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
                   var temp= msg.d; 
                    GenericChatterList=temp[0];
                    GenericSpeechList=temp[1];
                     BindSpeechWindows();
                     
                    
          },
          error: AjaxFailed
        });
   
}
$(document).ready(function(){
    $("#club-chatter").mousemove(function(e){
      if( $("#"+$("#hiddenUserId").val()).hasClass("direction_enable")==true)
        {
        SetMyFaceDirection(e);
        }
    });
});
function SetMyFaceDirection(e){
    
  

      var OutX=parseInt(e.pageX -$("#"+$("#hiddenUserId").val()).css('left').toString().split("px")[0],10);
      var OutY=parseInt(e.pageY -$("#"+$("#hiddenUserId").val()).css('top').toString().split("px")[0],10);
      var bTop=0;
      $("#tester").text("(Outx:"+OutX+")  ("+ "OutY:"+OutY+")" );
    
        if((OutX>0 && OutY==0)||(OutX>0 && Math.abs(OutY)<16)){
           bTop=384; //left to right
        }
       else if((OutX<0 && OutY==0)||(OutX<0 && Math.abs(OutY)<16)){
           bTop=448; //right to left
        }
       else if((OutX==0 && OutY>0)||(Math.abs(OutX)<16 && OutY>0)){
           bTop=512; // Top to Bottom
        }
        else if((OutX==0 && OutY<0)||(Math.abs(OutX)<16 && OutY<0)){
           bTop=320; // Bottom to top
        }
    
       else if(OutX>0 && OutY<0){
           bTop=64;   //center to right top             
        }
        else if(OutX<0 && OutY<0){
           bTop=128; // center to left top
        }
        else if(OutX>0 && OutY>0){
         bTop=192; // center to right bottom
        }
        else if(OutX<0 && OutY>0){
           bTop=256; //center to left bottom 
        }
        
        var backgroundLeft= parseInt($("#"+$("#hiddenUserId").val()).css('background-position').toString().split(" ")[0].toString().split('px')[0],10);
     
        $("#"+$("#hiddenUserId").val()).css('background-position', backgroundLeft +"px "+bTop+"px" );
        
        
        
}
  

function DisplayAvatarDetails(e,userid,displayName){
   $("div#avatar-details").fadeIn('fast');     
     if(userid==parseInt($("#hiddenUserId").val(),10))
     {
        $("#profilePhoto").fadeIn();
        $("#profilePhoto").attr('href','IframeProfilePhotoChange.aspx?userid='+userid);
     }
     else{
        $("#profilePhoto").fadeOut();
     }
     
    if( $("div#option-container").attr('my_id')!=userid){
        $("div.topSlider").not("div#avatar-details").slideUp();
        $(".SecondLevelSlider").slideUp();   
        $("div#avatar-details").slideDown();
        $("div#option-container").attr('my_id', userid);
        $("div#option-container").attr('DisplayName',displayName);
        $("span#avatar-user-name").html(displayName); 
        $("div#avatar-details-image").attr('PrevBackImage','url(images/profile/'+userid+'_thumb.jpg)');
       
        $("div#avatar-details-image").css('background-image','url(images/profile/'+userid+'_thumb.jpg?random='+Math.random()+')');
        $("#secondleveltitle").html("");
        $("#FriendListContainer").slideUp();
        $("#FeedContainer").html("");
        $("#ShowOlderPostButton").fadeIn(); 
    }
    
   if(userid==0)
   {
    BindUserfeed(e);   
    $('#option-container').css('visibility','hidden'); 
   }
   else if(userid==-1)
   {
    BindUserfeed(e);   
    $('#option-container').css('visibility','hidden'); 
   }
   else{
    $('#option-container').css('visibility','visible');
   }  
    /// Code to create a text box where one can put message to others wall
   
    

}

function RefreshAvatarDetailsImage()
{
     
        $("div#avatar-details-image").css('background-image','url(images/profile/'+$("div#option-container").attr('my_id')+'_thumb.jpg?random='+Math.random()+')');
      
}

 function BindRoomChatter() {
         if(GenericChatterList!=null)
         {
          
//              $("#tester").html(GenericChatterList.length);
                for (var i in GenericChatterList)
                 {
                     var Chatter = GenericChatterList[i];
                    if($("#"+Chatter.Id).length<1) 
                    {
                     
                         var avat=$('<div></div>');
                        
                        $(avat).attr('id',Chatter.Id);
                        $(avat).attr('DisplayName',Chatter.DisplayName);
                        $(avat).addClass('avatar');
                         
                        $(avat).css('background-position',Chatter.BackGroundPosition);
                        $(avat).css('background-image',Chatter.Avatar);
                          
                        if(IsThisPointIsInsideTheClubAreas(parseInt(Chatter.Left,10),parseInt(Chatter.Top,10))!=-1)
                        {
                        
                           $(avat).css('left',"450px");
                           $(avat).css('top',"350px"); 
                        }
                        else{
                            $(avat).css('left',Chatter.Left);
                            $(avat).css('top',Chatter.Top);
                        
                        }
                        $(avat).css('z-index',Chatter.Top.split('px')[0]);
                        
//                         for(var x=100; x<600;x++)
//                         {
//                            for(var y=100;y<600;y++)
//                            {
//                                IsThisPointIsInsideTheClubAreas(x,y);
//                            }
//                         }
                          
//                        var x=100;
//                        var y=100;
//                            for(var x=300;x<500;x=x+50){
//                              for(var y=250;y<500;y=y+50){
//                                if(IsThisPointIsInsideTheClubAreas(x,y)==-1){

//                                    break;
//                                }                                
//                              } 
//                              if(IsThisPointIsInsideTheClubAreas(x,y)==-1){
//   
//                                    break;
//                                    
//                                }
//                            }
//                            
//                        $(avat).css('left',x+"px");
//                        $(avat).css('top',y+"px");  

 
//                           $(avat).css('left',"450px");
//                           $(avat).css('top',"400px"); 
                        
//                         if( $("#hiddenUserId").val()==Chatter.Id)
//                         {
//                           
////                           $(avat).css('left',"350px");
////                           $(avat).css('top',"550px"); 
//                         }
//                         else{
//                             $(avat).hover(function(e){
////                                  alert( (parseInt( $(this).css("left").split("px")[0])+64)+"px");

//                                   $("div#avatarMenu").fadeIn("slow");
//                                   $("div#avatarMenu").css('left',(parseInt( $(this).css("left").split("px")[0])+40)+"px");
//                                   $("div#avatarMenu").css('top',(parseInt( $(this).css("top").split("px")[0])+54)+"px");
//                                   $("div#avatarMenu").attr('my_id', $(this).attr('id')); 
//                                   $("div#avatarMenu").attr('DisplayName', $(this).attr('DisplayName')); 
//                               });
                               $(avat).click(function(e){
                                    var userid=$(this).attr('id');
                                    var displayName=$(this).attr('DisplayName');
                                    
                                     DisplayAvatarDetails(e,userid,displayName);
                                     e.stopPropagation();
                               });
                                 
//                              }
                        
//                        $(avat).css('background-color',"blue");
                         
                        $(avat).css('width','64px');
                        $(avat).css('height','64px');
                        $(avat).css('position','absolute'); 
                        
                        var ChatText=$('<div></div>');
                        $(ChatText).addClass('chatbox');
                        $(ChatText).attr('id',"chatbox"+Chatter.Id);
                                var OnlyText=$('<div></div>');
                                $(OnlyText).addClass('OnlyText');
                                $(ChatText).append(OnlyText);
                         
                        //$(avat).append(ChatText);
                        var ChatterName=$('<div></div>');
                        $(ChatterName).text(Chatter.DisplayName);
                        $(ChatterName).addClass('chatterName');
                        $(ChatterName).attr('id',"chatterName"+Chatter.Id);                        
                        $(avat).append(ChatterName);
                        
                        $("#club-chatter").append($(avat));
                        $("#club-chatter").append($(ChatText));
                       
                        
                        
                        
                    }
                    else
                    {
                   
                      MoveAvatar(Chatter);  
                    }
                                    
                   
                    
                    if(Chatter.Message=="undefined"){
                       // $("#chatbox"+Chatter.Id).css('display','none');
                        //$("#chatterName"+Chatter.Id).css('top','48px');
                    }
                    else{
                    // $("#chatbox"+Chatter.Id).children(".OnlyText").html(Chatter.Message);
//                        if($("#chatbox"+Chatter.Id).children(".OnlyText").html().toUpperCase()!=Chatter.Message.toUpperCase())
//                        {
//                          //alert($("#chatbox"+Chatter.Id).children(".OnlyText").html().toUpperCase()+" "+Chatter.Message.toUpperCase()); 
//                            $("#chatbox"+Chatter.Id).fadeIn('slow');
//                            $("#chatbox"+Chatter.Id).children(".OnlyText").html(Chatter.Message);
//                            $("#chatterName"+Chatter.Id).css('top','0px');
//                            BindChatHistory(Chatter);
//                            //alert($("#chatbox"+Chatter.Id).html() + "--"+Chatter.Message );
//                        }
                       //  $("#chatbox"+Chatter.Id).html(Chatter.Message);
                        
                    }
                        // $("#tester3").text('ChatBoxHtml:'+$("#chatbox"+Chatter.Id).html());

                      
                }
        }
   } 
   function MoveAvatar(Chatter){
   
    $("#"+Chatter.Id).css('background-image',Chatter.Avatar);

      var OutX=parseInt(parseInt(Chatter.Left.toString().split("px")[0],10)-parseInt($("#"+Chatter.Id).css('left').toString().split("px")[0],10));
      var OutY=parseInt(parseInt(Chatter.Top.toString().split("px")[0],10)-parseInt($("#"+Chatter.Id).css('top').toString().split("px")[0],10));
      var bTop=0;
      $("#tester").text("(Outx:"+OutX+")  ("+ "OutY:"+OutY+")" );
    
        if((OutX>0 && OutY==0)||(OutX>0 && Math.abs(OutY)<16)){
           bTop=384; //left to right
        }
       else if((OutX<0 && OutY==0)||(OutX<0 && Math.abs(OutY)<16)){
           bTop=448; //right to left
        }
       else if((OutX==0 && OutY>0)||(Math.abs(OutX)<16 && OutY>0)){
           bTop=512; // Top to Bottom
        }
        else if((OutX==0 && OutY<0)||(Math.abs(OutX)<16 && OutY<0)){
           bTop=320; // Bottom to top
        }
    
       else if(OutX>0 && OutY<0){
           bTop=64;   //center to right top             
        }
        else if(OutX<0 && OutY<0){
           bTop=128; // center to left top
        }
        else if(OutX>0 && OutY>0){
         bTop=192; // center to right bottom
        }
        else if(OutX<0 && OutY>0){
           bTop=256; //center to left bottom 
        }
  
            
        
      
            var x1=parseInt( $("#"+Chatter.Id).css('left').toString().split("px")[0],10);
            $("#"+$("#hiddenUserId").val()).removeClass("direction_enable");// new
//          
              var x;
              var StepDis=3;
               if(Math.abs(OutX)<=4 && Math.abs(OutY)<=4)
                {
                   if( $("#hiddenUserId").val()==Chatter.Id)
                   {
                     $("#"+$("#hiddenUserId").val()).addClass("direction_enable");
                   //  $("#"+$("#hiddenUserId").val()).css('background-position','0px 0px');
                    
                   }
                   else{
                          $("#"+Chatter.Id).css("background-position",Chatter.BackGroundPosition); 
                   }

                   
                    return;
                }
              
              //  $("#"+$("#hiddenUserId").val()).removeClass("direction_enable");// new
                 
              var y1=parseInt( $("#"+Chatter.Id).css('top').toString().split("px")[0],10);
              var x2=parseInt(Chatter.Left.toString().split("px")[0],10);
              var y2=parseInt(Chatter.Top.toString().split("px")[0],10);
               var m=1;
               m=Math.abs(x2-x1)/Math.abs(y2-y1);
               if(m>1){
                 m=1;
               }
              if(OutX>0)
                 {
                    x=x1+3*m;
                 }
             else
                 {
                     x=x1-3*m;
                 }
              
//              $("#tester2").text("  X:-"+x+"  x1-:"+x1+"  y1-"+y1+"  x2-"+x2+"  Y2-"+y2);   
                 
var y=parseInt( (x-x1)*(y2-y1)/(x2-x1)+ y1,10);
if(  IsThisPointIsInsideTheClubAreas(x+32,y+44)>-1)
  {  
    if(  IsThisPointIsInsideTheClubAreas(x+32,y+44)==0)
    {
         if( $("#hiddenUserId").val()==Chatter.Id)
            {
              StopMeHere();
//              $("#"+Chatter.Id).fadeOut('slow');
              //alert("stop here");  
            }
        return;
    }
    else{
           if( $("#hiddenUserId").val()==Chatter.Id)
            {
              $("#hiddenRoomId").val(IsThisPointIsInsideTheClubAreas(x+32,y+44));
              $("#club-chatter").css('background-image','url(Images/Club/'+IsThisPointIsInsideTheClubAreas(x+32,y+32)+'.jpg)');
              $("#club-chatter").html("");
              GenericChatterList=null;
              BindClubLocation();
              return;
            }
    } 
  }  
//alert(y);
if(isNaN(y)==false)
{
     $("#"+Chatter.Id).css('left',x+"px");
     $("#"+Chatter.Id).css('top',y+"px");
     $("#"+Chatter.Id).css('z-index',y);
     
     $("#chatbox"+Chatter.Id).css('left',x+"px");
     $("#chatbox"+Chatter.Id).css('top',parseInt( y-64,10)+"px");
     
    var bLeft= parseInt($("#"+Chatter.Id).css('background-position').toString().split(" ")[0].toString().split('px')[0],10);
     if(bLeft==256){
        bLeft=64;
     }
     else{
        bLeft=bLeft+64;
     }
     
     $("#"+Chatter.Id).css('background-position', bLeft+"px"+" "+bTop+"px" );
    
 
}
 $("#tester2").text("  (X:"+x+")  (x1:"+x1+")  (y1:"+y1+")  (x2:"+x2+")  (Y2:"+y2+") (y:"+y+") (bTop:"+bTop+")(m:"+m+")"); 

    
             

            

   }   
function SelectAvatar(imgCntrl)
    {
    //$("#"+$("#hiddenUserId").val()).addClass("direction_enable");
    var imageSrc;
    imageSrc=$(imgCntrl).attr('src');

         $.ajax({
        
          type: "POST",
          url: "club.aspx/SelectAvatar",
          data:"{'ImageSrc':'" + imageSrc + "','roomId':'" + GetRoomId() + "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
          },
          error: AjaxFailed
        });
    }
     function AjaxFailed(request,status,error) {
        var exp = new RegExp('<title>(.*)<\/title>','i');
        if (exp.exec(request.responseText))
         {
         //alert( request.responseText );
        }
        else {
          //alert( request.responseText );
        }
    }
$(document).ready(function(){
    $(".ShowHideChatHistory").click( function(e){
           
            $("#ChatHistoryBoxContainer").css('left',(e.pageX-200)+'px');
            $("#ChatHistoryBoxContainer").css('position','absolute');
            $("#ChatHistoryBoxContainer").css('top',(e.pageY-250)+'px');
            $("#ChatHistoryBoxContainer").toggle();
            });
});

function ShowHideEmos(){
    $(".ShowHideEmo").click( function(e){
           
            $("#emo-list").css('left',(e.pageX-280)+'px');
            $("#emo-list").css('top',(e.pageY-375)+'px');
            $("#emo-list").toggle();
               if( $("#static-emo").html().length<120)
               {
                   for(var i=1;i<=22;i++)
                    {
                             var emo=$('<img/>');
                            $(emo).attr('src','Images/staticemos/'+i+'.gif');
                            $(emo).addClass('emo-item');
                            $("#static-emo").append($(emo));
                    }
               }
                
                 BindClickEventOnEmoItem();   
                
                 $(".emo-item").hover( function(){
                 $(".emo-item").css('border','1px solid transparent');
                 $(this).css('border','1px solid black');
                            });
                
                   
                
                            
    });
}

$(document).ready(function(){
    $("#ShowMoreEmo").click(function(e){
                    ShowWait(e);
                    var folderName='Emos';
                            $.ajax({
                              type: "POST",
                              url: "club.aspx/GetFolderNames",
                              data:"{'folderName':'" +folderName + "'}",
                              contentType: "application/json; charset=utf-8",
                              dataType: "json",
                              success: function(msg) {
                              HideWait();
                                 if(msg.d!=null)
                                         {
                                                for (var i in msg.d)
                                                 {
                                                    
                                                     var emoitem = msg.d[i];
                                                     var folderP=$('<div></div>');
                                                     $(folderP).addClass('avatarfolder');
                                                     $(folderP).text(emoitem);
                                                     $("#dynamic-emo-folder").append($(folderP));
                                                 }
                                                  $("#dynamic-emo-folder").fadeIn('slow');
                                                 
                                                 $(".avatarfolder").mouseover(function(){
                                                   $(".avatarfolder").css('background-color','white');
                                                   $(this).css('background-color','#ADD1E1'); 
                                                    
                                                 }).click(function(e){
                                                      ShowWait(e);
                                                         var folderName=$(this).html();
                                                          $.ajax({
                                                                
                                                                  type: "POST",
                                                                  url: "club.aspx/GetFileNames",
                                                                   data:"{'folderName':'" +$(this).html() + "'}",
                                                                  contentType: "application/json; charset=utf-8",
                                                                  dataType: "json",
                                                                  success: function(msg) {
                                                                  HideWait();
                                                                     if(msg.d!=null)
                                                                        {
                                                                        $("#dynamic-emo").fadeIn('slow');
                                                                         $("#dynamic-emo").html("");
                                                                           for (var i in msg.d)
                                                                            {
                                                                              var emo=$('<img/>');
                                                                                $(emo).attr('src','Images/Emos/'+folderName+'/'+msg.d[i]);
                                                                                $(emo).addClass('emo-item');
                                                                                $("#dynamic-emo").append($(emo));
                                                                            }
                                                                            BindClickEventOnEmoItem();
                                                                         }   
                                                                  
                                                                  },
                                                                  error: AjaxFailed
                                                                });
                                                        
                                                 });
                                         }            
                              //''
                                        
                              },
                              error: AjaxFailed
                         });
                });
});

function BindClickEventOnEmoItem(){
    
     $(".emo-item").each(function(){
                            $(this).unbind('click');
                            $(this).click(function(){
                             
                               SubmitMyText("<img src=\""+$(this).attr('src')+"\">");  
                                 $("#emo-list").fadeOut('fast');
                        });
                            
                     });
    
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
   
 var ClubPlaceList;   
 $(document).ready(function(){
 
     BindClubLocation();
    
 }); 
function BindClubLocation()
{
 $.ajax({
        
          type: "POST",
          url: "club.aspx/GetClubLocations",
          data:"{'roomId':'" + GetRoomId() + "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
                    ClubPlaceList=msg.d;
                     drawPolyGons();
          },
          error: AjaxFailed
        });
}
   
 function drawPolyGons()
 {
    
 for (var i in ClubPlaceList)
                 {
                     var xList=new Array();
                     var yList=new Array();
                        for (var j in ClubPlaceList[i].Xs)
                        {
                            xList[$(xList).length]= parseInt( ClubPlaceList[i].Xs[j],10);
                            yList[$(yList).length]=parseInt( ClubPlaceList[i].Ys[j],10);
                            var folderP=$('<div></div>');
                            $(folderP).css('position','absolute');
                            $(folderP).css('left',ClubPlaceList[i].Xs[j]+"px");
                            $(folderP).css('top',ClubPlaceList[i].Ys[j]+"px");
                            
                           // $(folderP).text(ClubPlaceList[i].Xs[j]+"px" + ClubPlaceList[i].Ys[j]+"px");
                             $(folderP).text("");
                            
                            $("#club-chatter").append($(folderP));
                            
                           
                            
                        }
                         $("#club-chatter").drawPolygon(xList, yList, {color:'#00FF00', alpha: .1});
                    
                    
                 }
//                var xList=new Array(165,498,485,188);
//                var yList=new Array(62,66,251,241);
                
//                alert(""); 
 }
 
 function IsThisPointIsInsideTheClubAreas(x,y)
 {
    for (var i in ClubPlaceList)
                 {
                     var ClubPlace = ClubPlaceList[i];
                    
                    if( isInsideTheArea( ClubPlace,x,y)==true)
                    {
                        return ClubPlace.LinkTo;
                    }   
                 }
            return -1;        
 }
 
 function isInsideTheArea(clubarea,x,y)
 {
 var xList=clubarea.Xs;
 var yList=clubarea.Ys;

  var i;
        var j=$(xList).length-1 ;
        
        var  oddNodes=false;
        
          for (i=0; i<$(xList).length; i++)
          {
                if (parseInt(yList[i],10)<y && parseInt(yList[j],10)>=y ||  parseInt(yList[j],10)<y && parseInt(yList[i],10)>=y)
                 {
                  if (parseInt(xList[i],10)+(y-parseInt(yList[i],10))/(parseInt(yList[j],10)-parseInt(yList[i],10))*(parseInt(xList[j],10)-parseInt(xList[i],10))<x)
                   {
                    oddNodes=!oddNodes;
                   }
                 }     
              j=i;
          }
        
    return oddNodes;   
 } 
 
 function MakeAllTextAreaBanglaCompatible()
 {
    $('textarea').each(function(){
        makePhoneticEditor(this);
    });
    
 }
 
 $(document).ready(function(){
//         var Inputs= document.getElementsByTagName("textarea");
//      for(var i=0;i<Inputs.length;i++)
//     {
//	
//		makePhoneticEditor(Inputs[i]);

//     }
switched=true;
        MakeAllTextAreaBanglaCompatible();
        $(".language").click(function(){
           if( $(this).val()=="b")
           {
            switched=false;
           }
           else  if( $(this).val()=="e")
           {
            switched=true;
           }
           
            
        });

//    $("input[@name='language']").change(function(){alert("alert e");
////        if ($("input[@name='language']:checked").val() == 'e')
////           {
////            alert("alert e");
////           }
////        else($("input[@name='language']:checked").val() == 'b')
////            {
////            alert("alert b");
////            }
////        
//        // Code for handling 'c'
//    });

 });
 function BindChatHistory(Chatter){
 
    var bgcolorlist=new Array("#F7F7F7", "#FFFFFF", "#DDDD00","#00FFFF","#A52A2A","#D2691E","#008B8B","#B8860B","#8B0000","#CD5C5C","#F08080","#20B2AA","#66CDAA","#191970","#6B8E23","#CD853F","#2E8B57","#A0522D","#4682B4");

   var color=Chatter.Id%17;
   

  var ConversationBox=$('<div></div>');
  $(ConversationBox).addClass('conversationbox');
  var UserName=$('<div></div>');
  var Message=$('<div></div>');
  $(UserName).text(Chatter.DisplayName);
  $(UserName).addClass('sender-name');
  $(UserName).css('color', bgcolorlist[color]);
  //'#'+(parseInt( Chatter.Id)*0xFFFFFF<<0).toString(16);
  
  //$(userText).css("color",'#'+(parseInt( Chatter.Id)*0xFFFFFF<<0).toString(16));
//    alert(color);
  //alert('#'+(parseInt( Chatter.Id)*0xFFFFFF<<0).toString(16));
  $(Message).html(Chatter.Message);
  $(Message).addClass('sender-message');
  $(ConversationBox).append(UserName);
  $(ConversationBox).append(Message);
  $("#ChatHistory").append(ConversationBox);
  
var objDiv = document.getElementById("ChatHistory");
objDiv.scrollTop = objDiv.scrollHeight; 
 
 }
 
// 
//function showAvatarMenu(avatar,e)
//{
//   //$("div#avatarMenu").css('display','none');
//  if( $("div#avatarMenu").css('display')=='none')
//  {
//   $("div#avatarMenu").fadeIn("slow");
//   $("div#avatarMenu").css('left',$(avatar).css("left"));
//   $("div#avatarMenu").css('top',$(avatar).css("top"));
//  }
//   
//  
//}

$(document).ready(function(){
    $("div#closeAvatarDetails").click(function(){       
        $("div#avatar-details").slideUp();
        $("div.SecondLevelSlider").slideUp();
         $("#FeedContainer").html("");
         $("#secondleveltitle").html("");
    });
    
     $("#imgStartChat").click(function(){
       
       var ClickedUserId=$(this).parent("#option-container").attr('my_id');
       var ClickedUserDisplayName=$(this).parent("#option-container").attr('DisplayName');
       if($("#hiddenUserId").val()==ClickedUserId)
       {
        jqDialog.notify("You can't chat with yourself", 3);
        
        return;
       }
       
        optimizationAtSpeechUpdate(ClickedUserId,ClickedUserDisplayName,""); 
        
              
       OpenSpeechWindowSinceAvatarIsClicked(ClickedUserId,ClickedUserDisplayName,"");
       
        ArrangementForScrolling();  
    });
    
    $("#imgAddFriend").click(function(){
       var ClickedUserId=$(this).parent("#option-container").attr('my_id');
       var ClickedUserDisplayName=$(this).parent("#option-container").attr('DisplayName');
       if($("#hiddenUserId").val()==ClickedUserId)
       {
         jqDialog.notify("You can't add yourself as your friend", 3);
        return;
       }   
       OpenSpeechWindowSinceAvatarIsClicked(ClickedUserId,ClickedUserDisplayName,"");
       ArrangementForScrolling();
       SendInstanceFriendRequestToThisUser($(this).parent("#option-container").attr('my_id'),ClickedUserDisplayName);  
    });
    
});



$(document).ready(function(){
 $(".ChatLocation").fadeTo("slow", 0.60);
    $(".ChatLocation").hover(function () {
        $(this).fadeTo("slow", 0.99);
        
      }, 
      function () {
        $(this).fadeTo("slow", 0.60);
        $(this).fadeTo("slow", 0.60);
      }).click(function(){
           
         
         $("#hiddenRoomId").val($(this).attr('id'));
              $("#club-chatter").css('display','none'); 
              $("#club-chatter").css('background-image','url(Images/Club/'+$(this).attr('id')+'.jpg)');
              $("#club-chatter").fadeIn("Slow");
              $("#club-chatter").html("");
              GenericChatterList=null;
              BindClubLocation();
      });
});


$(document).ready(function(){
   $(".chatHistoryBox-minmax").click(function(){
        $('.chatHistoryBox-minmax').toggle();
        $("#ChatHistory").slideToggle("slow");        
       
   });
    $('.ClubLocation-minmax').click(function(){
             $('.ClubLocation-minmax').toggle();   
             $("#ChatLocations").slideToggle("slow");
        });
});

$(document).ready(function(){
    $("#ShowRegionList,#close-region-container").click(function(){
        $("#region-container").toggle();
    });
    
    $(".region").click(function(){
         $("#hiddenRoomId").val($(this).attr('location'));
              $("#club-chatter").css('display','none'); 
              $("#club-chatter").css('background-image','url(Images/Club/'+$(this).attr('location')+'.jpg)');
              $("#club-chatter").fadeIn("Slow");
              $("#club-chatter").html("");
              GenericChatterList=null;
              BindClubLocation();
              $("#region-container").toggle();
    });
    
});



$(document).ready(function(){
    
    $(".ShowHideMap,div#hide-map,div#ChatLocations,#penguin-world").click(function(){
    $("div#club-map").css('background-image','url(../images/club/map.jpg)'); 
    $("div#club-map").toggle();
    $("#region-container").css('display','none');
  
        
    });

//    $("div#club-map").hover(
//        function(){    
//        $(this).stop();
//          $(this).animate( { opacity:"1.0" } , 1000 )
//        },
//            function(){
//                  $(this).stop();
//                 $(this).animate( { opacity:".6" } , 1000 )
//            } 
//    
//    );

   $("div.place-short-cut").hover(
    function(){
     $(this).stop();
       $(this).animate( { opacity:".5" } , 400 )
    },
    function(){
     $(this).stop();
       $(this).animate( { opacity:"0.0" } , 400 )
     
    }   
   ).click(function(){
   
              $("div#club-map").toggle();  
              $("#hiddenRoomId").val( $(this).attr('id').split('shortcut')[1]+'00');
              $("#club-chatter").css('background-image','url(Images/Club/'+$(this).attr('id').split('shortcut')[1]+'00.jpg)');
              $("#club-chatter").html("");
              GenericChatterList=null;
              BindClubLocation();
              
   }); 
    
});


function RejectFriend(userid)
{
    alert(userid);
}
function ConfirmFriend(userid)
{

   $.ajax({
            
              type: "POST",
              url: "club.aspx/ConfirmedAsFriend",
              data:"{'userid':'" + userid+ "'}",
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


$(document).ready(function(){
$("textarea#txtStatusBox").val("Write something...");
$("textarea#txtStatusBox").css("color","#818661");

   $("textarea#txtStatusBox").click(function(e){
      if($(this).val()=="Write something...")
      {
        $(this).val("");
        $("textarea#txtStatusBox").css("color","black");
        
      } 
      $(this).css('height','40px'); 
      e.stopPropagation();  
   });
   
   
   $("*").not("textarea#txtStatusBox").click(function(e){
      
       if($("textarea#txtStatusBox").val()=="")
      {
        $("textarea#txtStatusBox").val("Write something...");
        $("textarea#txtStatusBox").css("color","#818661");
        
        $("textarea#txtStatusBox").css('height','25px'); 
        
      } 
   });  

});

$(document).ready(function(){
$("textarea#txtChatTextBox").val("Write something...");
$("textarea#txtChatTextBox").css("color","#818661");
$("textarea#txtChatTextBox").css("background-color","white");
   $("textarea#txtChatTextBox").click(function(e){
      if($(this).val()=="Write something...")
      {
        $(this).val("");
        $("textarea#txtChatTextBox").css("color","black");
        
      } 
     
      e.stopPropagation();  
   });
   
   
   $("*").not("textarea#txtChatTextBox").click(function(e){
      
       if($("textarea#txtChatTextBox").val()=="")
      {
        $("textarea#txtChatTextBox").val("Write something...");
        $("textarea#txtChatTextBox").css("color","#818661");
       
        
       
        
      } 
   });  

});


$(document).ready(function(){
    $("#option-container img").each(function(){
        $(this).mouseenter(function(e){
                        if($("#controller-tooltips").length<1){
                            var ToolTips=$("<div></div>");
                            $(ToolTips).attr('id','controller-tooltips');
                            $(ToolTips).css('position','absolute');
                            $("body").append($(ToolTips));    
                        }
                    
                    $("#controller-tooltips").stop();    
                    $("#controller-tooltips").html($(this).attr('alt'));
                    $("#controller-tooltips").css('left',e.pageX+"px");
                    $("#controller-tooltips").css('top',e.pageY+9+"px");
                    $("#controller-tooltips").css('z-index','2002');
                    $("#controller-tooltips").css('background-color','black');
                    $("#controller-tooltips").css('padding','5px');
                    $("#controller-tooltips").css('color','white');
                    $("#controller-tooltips").css('display','inline');
                 }
        );
        
        $(this).mouseleave(function(){
                $("#controller-tooltips").css('display','none');                
        });
        
    });
});


$(document).ready(function(){
    $(".altOnTop").each(function(){
        $(this).mouseenter(
                    function(e)
                    {
                    
                     
                        if($("#altOnTop-tooltips").length<1)
                        {
                            var ToolTips=$("<div></div>");
                            $(ToolTips).attr('id','altOnTop-tooltips');
                            $(ToolTips).css('position','absolute');
                            $("body").append($(ToolTips));    
                        }
                   // alert( $("#altOnTop-tooltips:visible").length);
                       if( $("#altOnTop-tooltips:visible").length<1)
                       {
                        
                        $("#altOnTop-tooltips").html($(this).attr('alt'));
                        $("#altOnTop-tooltips").css('left',$(this).offset().left+"px");
                        $("#altOnTop-tooltips").css('top',$(this).offset().top-20+"px");
                        $("#altOnTop-tooltips").css('z-index','2002');
                        $("#altOnTop-tooltips").css('background-color','black');
                        $("#altOnTop-tooltips").css('padding','5px');
                        $("#altOnTop-tooltips").css('color','white');
                        $("#altOnTop-tooltips").show();
                       } 
                 }
               
        
        );
        
       $(this).mouseleave(function(){
            $("#altOnTop-tooltips").hide();
       });  
        
    });
});