<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChatRoom2.aspx.cs" Inherits="BDDoctors.ChatRoom2" EnableEventValidation="false" ValidateRequest="false" %>
<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>
<%@ Register src="Controls/CtrlForChatRoom.ascx" tagname="CtrlForChatRoom" tagprefix="uc2" %>
<%@ Reference Control="~/Controls/CtrlForChatRoom.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>FewDew|World</title>
    <link href="CSS/Global.css" rel="stylesheet" type="text/css" />
       <script type="text/javascript" src="Js/jquery-1.3.2.min.js" ></script>
           <script type="text/javascript" src="JS/JqueryTimer.js"></script>
       <script type="text/javascript" src="JS/ChatRoom.js"></script>
    
    <script type="text/javascript">
    var tempBackLeft=0;
    var GlobalSleepTime=0;
    var footStepSpeed=200;
    var MyAvatar;
    var MyAvatarImgContainer;
    var MyAvatarX;
    var MyAvatarY;
    var CursorX;
    var CursorY;
    var SourcePointX;
    var SourcePointY;
    var T;
    var OutX;
    var OutY;
    var reached=1;
      var spanHeight=0;
 function handleEvent(oEvent) {

 if(reached==0)
 {
 return true;
 }

 if(document.getElementById("txtMyDetails").value.length==0)
 {
 alert("Select an avatar by clicking on the item in the avatar list. After selecting avatar you can walk over this location");
 return;
 }
        
        CursorX=oEvent.clientX;
        CursorY=oEvent.clientY;
        MyAvatar = document.getElementById("MyAvatar");
        MyAvatarImgContainer=document.getElementById("MyAvatarImgContainer");
        CursorX=CursorX-32;
        CursorY=CursorY-122;
        self.clearTimeout(T);
        
        GlobalSleepTime=0;
        moveMyAvatar();
 reached=0;
    }    
 //   window.onload = init;



</script>
<script type="text/javascript">
function RestartAvatar()
{
reached=1;
}

</script>
    <script type="text/javascript">
        
          function StyleTopBottom()
        {
                      var tempBackLeft=0;
            for(var i=0;i<4;i++)
            {
               GlobalSleepTime=GlobalSleepTime+footStepSpeed;               
              T= setTimeout("sleepForStyle(0)",GlobalSleepTime);
            }
 
        }
        
        function StyleBottomTop()
        {
                      var tempBackLeft=0;
            for(var i=0;i<4;i++)
            {
               GlobalSleepTime=GlobalSleepTime+footStepSpeed;               
               T=setTimeout("sleepForStyle(320)",GlobalSleepTime);
            }
 
        }
        function StyleLeftRight()
        {
                      var tempBackLeft=0;
            for(var i=0;i<4;i++)
            {
               GlobalSleepTime=GlobalSleepTime+footStepSpeed;               
               T=setTimeout("sleepForStyle(384)",GlobalSleepTime);
            }
 
        }
         function StyleRightLeft()
        {
           var tempBackLeft=0;
            for(var i=0;i<4;i++)
            {
               GlobalSleepTime=GlobalSleepTime+footStepSpeed;               
               T=setTimeout("sleepForStyle(448)",GlobalSleepTime);
            }
        }
        function StyleDiagonalRightTop()
        {
           var tempBackLeft=0;
            for(var i=0;i<4;i++)
            {
               GlobalSleepTime=GlobalSleepTime+footStepSpeed;               
               T=setTimeout("sleepForStyle(64)",GlobalSleepTime);
            }
        }
         function StyleDiagonalLeftTop()
        {
           var tempBackLeft=0;
            for(var i=0;i<4;i++)
            {
               GlobalSleepTime=GlobalSleepTime+footStepSpeed;               
               T=setTimeout("sleepForStyle(128)",GlobalSleepTime);
            }
        }
         function StyleDiagonalLeftBottom()
        {
           var tempBackLeft=0;
            for(var i=0;i<4;i++)
            {
               GlobalSleepTime=GlobalSleepTime+footStepSpeed;               
               T=setTimeout("sleepForStyle(256)",GlobalSleepTime);
            }
        }
        
         function StyleDiagonalRightBottom()
        {
            var tempBackLeft=0;
            for(var i=0;i<4;i++)
            {
               GlobalSleepTime=GlobalSleepTime+footStepSpeed;               
               T=setTimeout("sleepForStyle(192)",GlobalSleepTime);
               
            }
         }
          
          
          
          
          function  SelectStyle()
         {
            MyAvatar = document.getElementById("MyAvatar"); 
            MyAvatarX=  MyAvatar.style.left.split("px",1);
            MyAvatarY=  MyAvatar.style.top.split("px",1); 
         
             OutX=CursorX-MyAvatarX;
             OutY=CursorY-MyAvatarY;
             
            if( Math.abs(OutX)<2 || Math.abs(OutY)<2)
                {
                return false;
                }
           
            
            
          
//            
//            if( OutX>0 && Math.abs( OutY)<20)
//            {
//             StyleLeftRight();
//            }
//             else if(OutX<0 && Math.abs( OutY)<20)
//            {
//            StyleRightLeft(); 
//            }
//            else if(Math.abs( OutX)<20 && OutY>0)
//            {
//            StyleTopBottom();
//            }
//             
//             else if(Math.abs( OutX)<20&& OutY<0)
//            {
//            StyleBottomTop();
//            }
//            
            
            if( OutX>0 &&  OutY==0)
            {
             StyleLeftRight();
            }
             else if(OutX<0 && OutY==0)
            {
            StyleRightLeft(); 
            }
            else if( OutX==0 && OutY>0)
            {
            StyleTopBottom();
            }
             
             else if( OutX==0&& OutY<0)
            {
            StyleBottomTop();
            }
            
            
            
            else if(OutX>0 && OutY<0)
            {
                StyleDiagonalRightTop(); //diagonal cente to top right
            }
            
             else if(OutX<0 && OutY<0)
            {
       
            StyleDiagonalLeftTop(); // center to left top
            }
            
          
            
            else if(OutX<0 && OutY>0)
            {
            StyleDiagonalLeftBottom(); //center to left bottom 
            }

           
            else if(OutX>0 && OutY>0)
            {
            StyleDiagonalRightBottom (); // center to right bottom
            }
        
          return true;
        }
     </script>
     <script type="text/javascript">  
        
       function sleepForStyle(step)
            {
               
                
                
            var PreviousX=MyAvatarX;
               MyAvatar = document.getElementById("MyAvatar"); 
          MyAvatarX=  MyAvatar.style.left.split("px",1);
           MyAvatarY=  MyAvatar.style.top.split("px",1); 
         
             OutX=CursorX-MyAvatarX;
             if(Math.abs(OutX)<=10)
                {
                 reached=1;
                }
             if(Math.abs(OutX)<=3)
             {
             
             
               if(T)
               {
               clearTimeout(T);
               }
               
                return;
             }
            if(OutX>0)
            {
            
                MyAvatarX=parseInt( MyAvatarX)+3;
            }
            else
            {
                MyAvatarX=parseInt( MyAvatarX)-3;
            }
            
            MyAvatarY=((parseInt(MyAvatarX)-parseInt(PreviousX))*(parseInt(MyAvatarY)-parseInt(CursorY)))/(parseInt(PreviousX)-parseInt(CursorX))+parseInt(MyAvatarY);
            //alert(PreviousX+" "+MyAvatarX+" "+MyAvatarY );
            MyAvatarImgContainer.style.backgroundPosition=tempBackLeft+"px "+step+"px";
           
            MyAvatar.style.left=MyAvatarX+"px";
            MyAvatar.style.top=MyAvatarY+"px";
           
            
            
            
           // alert(tempBackLeft);
 
            document.getElementById("txtMyDetails").value=Math.floor( tempBackLeft)+"px "+Math.floor(step)+"px"+"/"+Math.floor(MyAvatarX)+"px "+Math.floor(MyAvatarY)+"px"; 
           
            tempBackLeft=tempBackLeft+64; 
             if(tempBackLeft==320)
             {
             tempBackLeft=64;
             } 
            //GlobalSleepTime=GlobalSleepTime+footStepSpeed; 
//    text.value=val;
            
            }
            
       
        function moveMyAvatar()
        {
  
             MyAvatarX=  MyAvatar.style.left.split("px",1);
             MyAvatarY=  MyAvatar.style.top.split("px",1);
           
             for(var i=0 ;i< Math.abs(CursorX-MyAvatarX)/12;i++)
             {
                
                 if(SelectStyle()==false)
                 {
//                    alert("false");
                    break;
                 }
             }
             self.clearTimeout(T);
             
//             while(SelectStyle()==true)
//             {
//              
//             SelectStyle();
//             }
        
        }
      

//    function showValue(val)
//    {
//    var text = document.getElementById("txtMyDetails"); 
//    text.value=val;
//    }
    function ShowAlert()
        {
        alert("show alert");

        }
//    function TurnAvatarVisible()
//        {
//         var avatar = document.getElementById("MyAvatar");
//         avatar.style.display="block";
//         return true;
//        }
//        function turnAvatarInvisible()
//        {
//         var avatar = document.getElementById("MyAvatar");
//         avatar.style.display="none";
//        }
        function CheckBr(txtBox,lineLength)
        {
          var text=  txtBox.value;
            if(text.charAt(text.length-1)!='\n' && text.length>lineLength)
                {               
                    if( text.lastIndexOf('\n')<text.length-lineLength)
                    {
                        txtBox.value= text+'\n';
                    }
                }    
        }
        function ScrollDivLeftAndBottom()
        {

          var div= document.getElementById("dvConversation");
          div.scrollTop=div.scrollHeight;
          div.scrollLeft=div.scrollWidth;
          
//         for (var i=0;i<divs.length;i++)
//         {
//         divs[i].scrollTop=divs[i].scrollHeight;
//         divs[i].scrollLeft=divs[i].scrollWidth;
//         }
        
        }
        
    </script>
    
    <script type="text/javascript">
    function CheckPostBack()
{
var prm = Sys.WebForms.PageRequestManager.getInstance();
       prm.add_initializeRequest(InitializeRequest);
       prm.add_endRequest(EndRequest);
}
function InitializeRequest(sender, args)
           {
           ScrollDivLeftAndBottom();

           }
       
       function EndRequest(sender, args)
           {
            var hiddentxt=document.getElementById('txtHiddenUserText');
            hiddentxt.value="";
             ScrollDivLeftAndBottom();

           }

    </script>
    
     <style type="text/css">
    
    div.main-div{ width:1000px ; }
    div.room{float:left; cursor:crosshair; }/* max-width:600px;min-width:600px; min-height:600px}*//*width:600px; height:500px; background-image:url(Images/AvatarChat/Background/bg1.gif);*/
    #dvToRaiseCoverCallout{cursor:crosshair;}
    div.chat-point{color:white; width:380px;  }
    div.chat-point a {color:#2F9A8F}
    div.chat-point span {color:#283227;}
    .avatarItem{ background-color:Transparent; border-left:1px solid #2F9A8F}
    .avatarItem:hover{ background-color:#283227}
    .user_name{ vertical-align:bottom; position:relative;top:54px;  font-weight:normal}
    .exit-button{ }
    .exit-button:hover{  cursor:pointer}
    #txtMyChtBox{ background-color:#72cee4; border:1px solid #CCC; font-size:12px; margin-left:8px; margin-right:8px; margin-top:5px }
    .hide{ display:none;  }
    .jackel{ display:inline}
    div.dvOther{ vertical-align:bottom;}

    </style>
    <link href="CSS/fixpng.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
//        function toogleHeightWidth()
//        {
//        
//           var dvMyAvtarTxtandButtonContainer=document.getElementById('dvMyAvtarTxtandButtonContainer');
//           var txtMyChtBox=document.getElementById('txtMyChtBox');
//           var btnChatPost=document.getElementById('btnChatPost');
//           
//          if(dvMyAvtarTxtandButtonContainer.style.visibility=="" || dvMyAvtarTxtandButtonContainer.style.visibility=="visible")
//             {
//             dvMyAvtarTxtandButtonContainer.style.visibility="hidden";
//             }
//             else if(dvMyAvtarTxtandButtonContainer.style.visibility=="hidden")
//             {
//             dvMyAvtarTxtandButtonContainer.style.visibility="visible";
//             }
//           
//               
//          
//           
//        }
        
        
        function PutUserInputInHiddenBox(cntrlName)
        {
        
                var cntrl=document.getElementById(cntrlName);
                
                var hiddentxt=document.getElementById('txtHiddenUserText');
                if(cntrl.value!="")
                {
                   var d=new Date();  
                   hiddentxt.value=hiddentxt.value+  cntrl.value+ '\n';
                   cntrl.value="";
                   var spnFlytext=document.getElementById("spnFlytext");
                   spnFlytext.innerHTML=hiddentxt.value;
                   flyMe(spnFlytext);
                   
                }
//                toogleHeightWidth();
        }
      
        function flyMe(cntrl)
        {
            spanHeight=0;
                for(var j=1;j<200;j++)
                {
                setTimeout("vua()",j*40);// cntrl.style.top=MyAvatarY+j+"px",j*100);
                 
                 
              
////                        cntrl.style.left=MyAvatarX+"px";
////                     cntrl.style.top=MyAvatarY+"px";
                }
                
        }
        function vua()
        {
        spanHeight=spanHeight+4;
             MyAvatar = document.getElementById("MyAvatar"); 
            MyAvatarX=  MyAvatar.style.left.split("px",1);
            MyAvatarY=  MyAvatar.style.top.split("px",1); 
          var spnFlytext=document.getElementById("spnFlytext");
         var sum=MyAvatarY-spanHeight;
        
          spnFlytext.style.top=sum+"px";
         
          spnFlytext.style.left=MyAvatarX+"px";
          
        }
        
        
    </script>
    
    
</head>
<body style="text-align:left; margin:0 0;  background-color:#283227; background-repeat:repeat"  onload="CheckPostBack();">
    <form id="form1" runat="server" >
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode=Release>
    </asp:ScriptManager>
     
     <uc1:LoggedInUserMenu ID="LoggedInUserMenu1" runat="server" />
     
     <div class="main-div" style=" float:left;" runat="server" id=maindiv>
               <input type=hidden id="hiddenRoomIdContainer" runat="server" />     
             
     
                <img runat="server" id="imgFood" onclick="RestartAvatar();" src="Images/Site/food.gif"  title="Give food to restart your movement" style="float:left; position:absolute;z-index:3; " alt="If avatar is not walking that click here" />
                <span id="spnFlytext" style="position:absolute;color:#76d0e5; font-size:20px; z-index:40"></span>
                     <div runat="server" id="MyAvatar" style="width:150px; display:none; background-color:Transparent; top:200px;left:200px;position:absolute; z-index:5">
                             <div id="dvToRaiseCoverCallout">
                             <div id="dvMyAvtarTxtandButtonContainer" style="z-index:5; width:150px; height:90px;   background-image:url(Images/Site/callout.gif); background-repeat:no-repeat">
                                <asp:TextBox runat="server" ID="txtMyChtBox" TextMode="MultiLine" style="height:50%; width:90%"></asp:TextBox>   
                                <input type="hidden" runat="server" id="txtHiddenUserText" value="" />
                                 <input type=button id="btnChatPost" runat="server" onclick="PutUserInputInHiddenBox('txtMyChtBox');"  value="Send" style="width:30%; height:15%; float:right; margin-right:5px; background-color:Transparent" />
                             
                            </div>
                            </div>
                            <div runat="server" id="MyAvatarImgContainer" style="background-image:url(Images/AvatarChat/avatar/a1.png);  position:absolute;z-index:5; width:64px; height:64px;">
                              <a href="#"  id="talklink" style="">Talk</a>  
                            </div>
                    
                     </div>    

              
       
           <asp:UpdatePanel ID="UpdatePanelMyDetails" runat="server" UpdateMode=Conditional>
           <ContentTemplate> 
                <input type=text  style="display:block" id="txtMyDetails"  runat="server"  />
            </ContentTemplate>
            </asp:UpdatePanel> 
         
         
          <asp:UpdateProgress runat="server" ID="uProgressMenu"  AssociatedUpdatePanelID="UpdatePanel1">
                 <ProgressTemplate>
                 <img src="Images/Site/updateprogress2.gif" alt="Wait" style="position:absolute;z-index:3;top:250px; left:550px"  />
                 </ProgressTemplate> 
         </asp:UpdateProgress> 
         
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>    
            <asp:Timer ID="Timer1" runat="server" Interval="5000" Enabled=false ontick="Timer1_Tick">
            </asp:Timer>
                <asp:LinkButton runat="server" ID="hlinkChangeRoom" Text="Change your world" Visible=false ></asp:LinkButton>
                
                   <div style="border:1px solid #CCC; padding:8px; float:left; background-color:White">
                   
                             <div style="position:absolute; z-index:4;  background-color:green;  float:left; color:#283227 ">
                             <asp:Button runat="server" id="btnRemoveMyAvatar"     OnClientClick="turnAvatarInvisible();" Text="EXITEXITEXITEXITEXITEXITEXITEXITEXITEXIT"  onclick="btnRemoveMyAvatar_Click" Visible=false style="display:inline; font-size:20px; background-color:white; color:black;background-image:url(Images/site/roomexit2.gif);  width:64px; height:30px;  float:left"
                           />
                            </div>  
                     <div class="room" id="room" runat="server"  onclick=handleEvent(event) style="float:left" >
                       
                    </div>
                   </div>
                  <div>
                       <div style="background-color:Yellow; float:left; width:380px; overflow:auto; height:55px; float:left" >
                        <% for (int i = 1; i <= 7; i++) %>
                        <%{ %>
                              <img src="Images/AvatarChat/Avatar/sample/a<%=i.ToString()%>.png" class="avatarSample" />
                        <%} %>
                        
                        <asp:DataList runat="server" ID="dlAvatarList"  Visible=false
                               Width=380 RepeatLayout="Flow" Height=55 RepeatDirection=Horizontal style="float:left;  background-color:white; " 
                                oneditcommand="dlAvatarList_EditCommand"   > 
                            
                            <ItemTemplate >
                                <asp:ImageButton CssClass="avatarItem" Width=50 OnClientClick="TurnAvatarVisible();" ImageUrl=<%#"~/Images/AvatarChat/Avatar/sample/"+ DataBinder.Eval(Container.DataItem, "AvatarFileName")%> runat="server" ID="imgUser"  Height="50" CommandName="edit" />
                             </ItemTemplate>
                    
                        </asp:DataList>
                       </div>
                   </div> 
                   <div style="width:350px;color:White; height:50px; display:inline-block">
                   <p>To select an avatar you just have to click on them</p>
                   </div>
                   <div class="chat-point"  style="float:left; background-color:white  ">
                   
                        
                            <div runat="server" id="dvConversation"  style="height:200px; text-align:left; width:350px;  overflow:auto; float:left;  color:White;font-size:12px">
                                   
                            </div>
                    </div>     
                    
                   
               
                
          </ContentTemplate>
        </asp:UpdatePanel>
        
        <div style="float:left;  width:380px; background-color:White  ">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <Triggers>
        <asp:PostBackTrigger ControlID="btnRoomBackUpload"  />
        </Triggers>
                <ContentTemplate>
                   <ul>
                    <li> <textarea ID="txtChat" runat="server"       style="float:left;background-image:url(Images/site/ButtonBig.gif); color:White; width:310px; height:50px"></textarea><asp:Button ID="btnTextPost" runat="server" Text="SEND" Height="53px"  
                    Width="40" style="float:left;margin-left:15px;background-image:url(Images/site/ButtonSmall.gif);color:White" onclick="btnTextPost_Click"  />
                    
                    </li> 
                    
                            </ul> 
                </ContentTemplate>
       </asp:UpdatePanel>   
        </div>
        
        <ul>
            <li><div runat="server" id="dvUploadPicture" visible=false>
                    
                        <asp:Label runat="server" ID="lbtnUploadMessage" ForeColor=Black Text="Change your world background just by uploading a picture.Please be aware of the perspective"></asp:Label> 
                        
                         <asp:FileUpload runat="server" ID="fileuploadRoomBack" />
                         
                        <asp:Button runat="server" ID="btnRoomBackUpload" Text="Upload" 
                            onclick="btnRoomBackUpload_Click" style="background-image:url(Images/site/ButtonSmall.gif);" />
                            
                            </div> 
                      </li>
            
        
        </ul>
    </div>
    </form>
</body>
</html>
