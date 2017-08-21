$(function(){
        positionFooter(); 
        function positionFooter(){
	        $("#emo-list").css({position: "absolute",top:($(window).scrollTop()+$(window).height()-$("#emo-list").height()-40)+"px"});
	        $("#OnlineUserDisplayBox").css({position: "absolute",top:($(window).scrollTop()+$(window).height()-$("#OnlineUserDisplayBox").height()-40)+"px"});
	        $("#footer-inner").css({position: "absolute",top:($(window).scrollTop()+$(window).height()-$("#footer-inner").height())+"px"});
	      //  $("#numberOfOnlineUser").css({position: "absolute",top:($(window).scrollTop()+$(window).height()-$("#numberOfOnlineUser").height())+"px"});
	        
	        
	        
	        
        }
     
        $(window)
	        .scroll(positionFooter)
	        .resize(positionFooter)
    });

$(document).ready(function(){
$("#menu-signin").click(function(){
        window.location = "Default.aspx";
    });
    
$("#what-is-fewdew").click(function(){
     
        window.location = "default.aspx";
    });
    


        $("#menu-company").hover(function(){
                var offset=  $(this).offset();   
                $(".menu-details").not("#company-details").fadeOut();
                $("#company-details").css('left', parseInt(offset.left)+"px");
                $("#company-details").css('top', parseInt( offset.top)+25+"px");       
                $("#company-details").slideToggle("slow");
            }
    );  
         $("#menu-contact-us").hover(function(){
                var offset=  $(this).offset();   
                $(".menu-details").not("#contact-us-details").fadeOut();
                $("#contact-us-details").css('left', parseInt(offset.left)+"px");
                $("#contact-us-details").css('top', parseInt( offset.top)+25+"px");       
                $("#contact-us-details").slideToggle("slow");
            });
        $("#right-block,#left-block").click(function(){
            $(".menu-details").slideUp();
        });    
        
});






$(document).ready(function(){

    $('#txtPassword').pstrength();
    
    $('#txtBirthday').datepicker({
            showOn: 'button',
			buttonImage: 'images/site/calendar.gif',
			buttonImageOnly: true,
			changeMonth: true,
			yearRange: "-100:+0",
			changeYear: true,			
			minDate: new Date(1900, 1 - 1, 26), 
			maxDate: new Date(),
			onSelect: function(dateText, inst) {
			   
			     var datDate1= Date.parse(dateText);
                 var datDate2= Date.parse(new Date());

                
			  }

		});
});

$(document).ready(function(){
    
    $("#sex").change(function(){
        $(".avatar-collection").toggle();
    });
 
    $("img.avatar").hover(
    function(){
     
           $(this).css('border','1px solid #4B6300');
//            $(this).css('background-color','#4B6300');
        },
    function(){
           $(this).css('border','1px solid #B0C62A');
//            $(this).css('background-color','transparent');
       
       }   
    ).click(function(){        
        $("img.avatar").removeClass('avatarSelected');
        $(this).addClass('avatarSelected');
        $("#avatar-selection-message").css('color','black');
    });;
   
    
});

function validateEmail(address) {
        var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
        if(reg.test(address) == false) {
            return false;
        }
        return true;
    }
    
function RequiredValidation(){
   //  alert($("#sex").val());
    $(".required").each(function(){
        if( $(this).val()=="")
        {
            $(this).addClass('NotYetGiven');
        }
        else{
            $(this).removeClass('NotYetGiven');
        }
    });
      var validate=true;
       if( $(".NotYetGiven").length>0)
        {
            validate=false;
        }
     if( $("#txtPassword").val().length<6)
     {  
         $("#txtPassword").addClass('NotYetGiven');          
         validate=false;
     } 
     
     if($("#txtEmail").val()!="")
     {
        if (validateEmail($("#txtEmail").val())==false)
        {
        
         $("#email-message").text('Invalid email'); 
          validate=false;  
        }
        else{
           
            $("#email-message").text(""); 
        }        
              
     }
     else
     {
         $("#email-message").text("");
        validate=false;               
     }
     
    if ($("img.avatarSelected").length<1)
    {
        $("#avatar-selection-message").css('color','red');
        validate=false;
    } 
    else{ $("#avatar-selection-message").css('color','black');
    }
    
     
    return validate;
      
        

}
$(document).ready(function(){ 
    $("#TryAgain").click(function(){
        $("#SignupMessagebox").fadeOut();
        $("#Signupbox").fadeIn('slow');
        
    });

   $("#txtPassword").keypress(function(){
       if( $("#txtPassword").val().length<6)
         {  
         $("#txtPassword").addClass('NotYetGiven'); 
        } 
        else{
            $("#txtPassword").removeClass('NotYetGiven'); 
        }
   });

     

    
    $("#btnLogin").click(function(e){
        if( RequiredValidation()==true)
        {
            ShowWait(e);
                $.ajax({
        
                  type: "POST",
                  url: "Registration.aspx/IsThisDisplayNameAvailable",
                  data:"{'displayName':'" +$("#txtDisplayName").val() + "'}",
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function(msg) {
                    HideWait();
                    if(msg.d=="YES")
                    {
                        $("#availability-message").html('Available');
                        $("#availability-message").css('color','black');
                        IsThisEmailAddressAvailable(e);
                    }
                    else if(msg.d=="NO")
                    {
                         $("#availability-message").html('Not available');
                         $("#availability-message").css('color','Red');  
                    }
                            
                  },
                  error: AjaxFailed
                });
        }       
       
    });
    
    $("#check-availability").click(function(e){
         if( $("#txtDisplayName").val()=="")
        {
           $("#txtDisplayName").addClass('NotYetGiven');
           return;
        }
        else{
           $("#txtDisplayName").removeClass('NotYetGiven');
        }
        
   
            ShowWait(e);
                $.ajax({
        
                  type: "POST",
                  url: "Registration.aspx/IsThisDisplayNameAvailable",
                  data:"{'displayName':'" +$("#txtDisplayName").val() + "'}",
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function(msg) {
                    HideWait();
                    if(msg.d=="YES")
                    {
                        $("#availability-message").html('Available');
                        $("#availability-message").css('color','black');
                    }
                    else if(msg.d=="NO")
                    {
                         $("#availability-message").html('Not available');
                         $("#availability-message").css('color','Red');  
                    }
                            
                  },
                  error: AjaxFailed
                }); 
    });
    
    
});

function IsThisEmailAddressAvailable(e)
{
        ShowWait(e);
                $.ajax({
        
                  type: "POST",
                  url: "Registration.aspx/IsThisEmailAddressAvailable",
                  data:"{'EmailAddress':'" +$("#txtEmail").val() + "'}",
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function(msg) {
                    
                    if(msg.d=="YES")
                    {
                        $("#email-message").html('Available');
                        $("#email-message").css('color','black');
                        CreateAccountAndSendActivationEmail();
                    }
                    else if(msg.d=="NO")
                    {
                         $("#email-message").html('Not available');
                         $("#email-message").css('color','Red');  
                        HideWait();    
                    }
                            
                  },
                  error: AjaxFailed
                });     
}

function CreateAccountAndSendActivationEmail(){
    var myAvatar;
     $("#Signupbox").fadeOut();
     $("#SignupMessagebox").fadeIn();
    
    myAvatar=$("img.avatarSelected").attr('src');
        $.ajax({
        
                  type: "POST",
                  url: "Registration.aspx/CreateAccountAndSendActivationEmail",
                  data:"{'displayName':'" +$("#txtDisplayName").val() + "','email':'" +$("#txtEmail").val() + "','password':'" +$("#txtPassword").val() + "','sex':'" +$("#sex").val()+ "','birthdate':'" +$("#txtBirthday").val()+ "','avatar':'" + myAvatar + "','invitedBy':'" + $("#invitedBy").val() + "'}",
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function(msg) {
                    HideWait();
                           
                    if(msg.d=="YES")
                        {
                            $("#SignupSeccessMessage").fadeIn();
                            $("#SignupFailedMessage").fadeOut();
                        }
                        else
                        {
                            $("#SignupSeccessMessage").fadeOut();
                            $("#SignupFailedMessage").fadeIn();                      
                        }
                   
                            
                  },
                  error: AjaxFailed
                }); 
    
}

function ShowWait(e)
{
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
}

function AjaxFailed(request,status,error) {
        var exp = new RegExp('<title>(.*)<\/title>','i');
        if (exp.exec(request.responseText)) {
           alert( request.responseText );
        }
        else {
           alert( request.responseText );
        }
    }