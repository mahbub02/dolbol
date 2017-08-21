 $(document).ready(function(){
        Onready();
        $(document).everyTime(3000, function(i) {
              SetMyPositionAndBindUser();
            }, 0);
    });
        
function Onready(){
    $(".avatarSample").click( function(){
        AvatarSelection($(this).attr('src'),RoomId());
    });
     $("#dvToRaiseCoverCallout").click( function(e){
     
        if($("#dvMyAvtarTxtandButtonContainer").css('visibility')=='hidden')
        {
           
            handleEvent(e);
        }
     });
     
    $("#dvMyAvtarTxtandButtonContainer,#dvMyAvtarTxtandButtonContainer > *").css('visibility','hidden');
    
     $("#talklink").click(function(){
        if($("#dvMyAvtarTxtandButtonContainer").css('visibility')=='hidden')
        {
            $("#dvMyAvtarTxtandButtonContainer,#dvMyAvtarTxtandButtonContainer > *").css('visibility','visible');
        }
        else{$("#dvMyAvtarTxtandButtonContainer,#dvMyAvtarTxtandButtonContainer > *").css('visibility','hidden');
           
        }
        
    });
}

function RoomId()
{
   return $("#hiddenRoomIdContainer").val();
}

function AvatarSelection(SampleImgSrc,roomId)
    {

         $.ajax({
        
          type: "POST",
          url: "ChatRoom2.aspx/SelectAvatar",
          data:"{'SampleImgSrc':'" + SampleImgSrc + "','roomId':'" + roomId + "'}",
            //My Comment joto gula params add korte chao toto gula 'no':'" + vua + "'  add koro "{ r }", er vetore
//            data: "{no:" + "13" + ","+"height:"+"100" +"}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
            $("#MyAvatarImgContainer").css('background-image',msg.d);
             $("#txtMyDetails").val("64px 192px/260px 208px");
             $("#MyAvatar").css("display","block");
            alert(msg.d);

          },
          error: AjaxFailed
        });
    }
     function AjaxFailed(request,status,error) {
//        var exp = new RegExp('<title>(.*)<\/title>','i');
//        if (exp.exec(request.responseText)) {
//           alert( RegExp.lastParen );
//        }
//        else {
//           alert( status );
//        }
    }

     
   function SetMyPositionAndBindUser()
    {
        if($("#txtMyDetails").val()=="")
        {
            return;
        }
         $.ajax({
        
          type: "POST",
          url: "ChatRoom2.aspx/SetMyPositionAndBindUser",
          data:"{'MyDetails':'" + $("#txtMyDetails").val() + "','roomId':'" + RoomId() + "','txtHiddenUserText':'" + $("#txtHiddenUserText").val() + "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
          $("#room").html(msg.d);
          $("#txtHiddenUserText").val("");
          },
          error: AjaxFailed
        });
    }         
 