$(function(){
        positionFooter(); 
        
     
        $(window)
	        .scroll(positionFooter)
	        .resize(positionFooter)
    });

function positionFooter(){
	        $("#emo-list").css({position: "absolute",top:($(window).scrollTop()+$(window).height()-$("#emo-list").height()-40)+"px"});
	        $("#OnlineUserDisplayBox").css({position: "absolute",top:($(window).scrollTop()+$(window).height()-$("#OnlineUserDisplayBox").height()-40)+"px"});
	        $("#footer-inner").css({position: "absolute",top:($(window).scrollTop()+$(window).height()-$("#footer-inner").height())+"px"});
	        
        }
        
$(document).ready(function(){
    $("#sign-up").click(function(){
            if($.browser.msie)
            {
                jqDialog.notify("This site is not currently internet explorer compatible. Please try with Firefox,Google Chrome,Opera or Safari browser");
            return false;
            } 

        window.location = "Registration.aspx";
    });
    
 
  
//    $(".menu").hover(
//        function(){
//       $(this).animate({
//              opacity: 0.9
//            }, 500);
//    
//        },
//        function(){
//      
//             $(this).animate({
//             opacity: 0.6
//            }, 500);
//        }
//    );

        $("#menu-company").mouseenter(function(){
                var offset=  $(this).offset();   
                $(".menu-details").not("#company-details").fadeOut();
                $("#company-details").css('left', parseInt(offset.left)+"px");
                $("#company-details").css('top', parseInt( offset.top)+25+"px");
                    
                $("#company-details").slideToggle("slow");
            }
    );  
    $("#company-details").mouseleave(function(){
         $("#company-details").slideToggle("slow");
    });
         $("#menu-contact-us").mouseenter(function(){
                var offset=  $(this).offset();   
               
                $(".menu-details").not("#contact-us-details").fadeOut();
                $("#contact-us-details").css('left', parseInt(offset.left)+"px");
                $("#contact-us-details").css('top', parseInt( offset.top)+25+"px");       
                $("#contact-us-details").slideToggle("slow");
            });
         $("#contact-us-details").mouseleave(function(){
            $("#contact-us-details").slideToggle("slow");
         });   
            
        $("#right-block,#left-block").click(function(){
            $(".menu-details").slideUp();
        });    
        
});

$(document).ready(function(){
    ///
           $("#txtPassword,#txtEmail").keypress(function(e){
               if(e.keyCode == 13)
                {
                 $("#btnLogin").trigger('click');
                 return false;

                }
            });
       ///
       

    $("#btnLogin").click(function(e){
       
           if($.browser.msie)
            {
                jqDialog.notify("This site is not currently internet explorer compatible. Please try with Firefox,Google Chrome,Opera or Safari browser");
                return false;
            } 

       
       
       
        $("#Message").css('visibility','hidden');
        
        var email=$("#txtEmail").val();
        var password=$("#txtPassword").val();
        
        if(email==""){
              $("#txtEmail").addClass('required');
             
              return;      
        }
        else{
            $("#txtEmail").removeClass('required');
        }
        
        if(password==""){
              $("#txtPassword").addClass('required');
              return;      
        }
        else{
            $("#txtPassword").removeClass('required');
        }
        if(validate(email)==false)
        {
            $("#Message").css('visibility','visible');
            $("#Message").text('Invalid email');
            $("#txtEmail").addClass('required');
            return;
        }
        ShowWait(e);
        $.ajax({
        
          type: "POST",
          url: "Default.aspx/DoLogin",
          data:"{'email':'" +email + "','password':'" +password+ "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
                HideWait(e);
                if(msg.d=="YES"){
                     window.location = "club.aspx?room_id=200";
                }
                else{
                    $("#Message").text('Invalid credentials');
                    $("#Message").css('visibility','visible');
                }
                
            
                    
          },
          error: AjaxFailed
        });
        
    });

});


 function AjaxFailed(request,status,error) {
        alert("ajax failed");
        var exp = new RegExp('<title>(.*)<\/title>','i');
        if (exp.exec(request.responseText)) {
           alert( request.responseText );
        }
        else {
           alert( request.responseText );
        }
    }
    
    
    function validate(address) {
        var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
        if(reg.test(address) == false) {
            return false;
        }
        return true;
    }


function ShowWait(e)
{
//    $("input").attr('disabled','disabled');
    if($(".loading").length<1)
    {
        var loading= $("<img />");
        $(loading).attr('src',"Images/Site/update.gif");
        $(loading).addClass('loading');
        $(loading).css('display','none');
        $(loading).css('position','absolute');
        $(loading).css('z-index','1000000');
        $(loading).css('left',e.pageX+"px");
        $(loading).css('top',e.pageY+"px");
        $("body").append($(loading));        
    }
    $(".loading").fadeIn();
}
function HideWait()
{
    $(".loading").fadeOut();
    $("input").removeAttr('disabled');
}