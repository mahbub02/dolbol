<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="World.aspx.cs" Inherits="BDDoctors.World" %>
<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>FewDew|World</title>
    <link href="CSS/Global.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    
    div.main-div{ width:100px}
    div.room{float:left; cursor:crosshair;  background-repeat:no-repeat;}/* max-width:600px;min-width:600px; min-height:600px}*//*width:600px; height:500px; background-image:url(Images/AvatarChat/Background/bg1.gif);*/
     div#room:hover{ cursor:crosshair; }
   img { background-color:Transparent; border:none; padding:none;}
    .avatarItem{ background-color:Transparent}
    .user_name{ position:relative;top:-40px; font-weight:normal}
    div#room a{ color:#9AD8E8;}
    
   table#datalistRoomChater img{ vertical-align:top; margin:2px; padding:3px; border:1px solid #CCC; background-color:Transparent;}
    </style>
    <script type="text/javascript">
    var tempBackLeft=0;
    var GlobalSleepTime=0;
    var footStepSpeed=50;
    var MyAvatar;
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
 function handleEvent(oEvent) {
 if(reached==0)
 {

 return true;
 }

// if(document.getElementById("txtMyDetails").value.length==0)
// {
// alert("Select(Click) an avatar to make your avatar alive ");
// return;
// }

var imgbtnContainer=document.getElementById("MyAvatar");
imgbtnContainer.style.display="block";

       reached=0; 
        CursorX=oEvent.clientX;
        CursorY=oEvent.clientY-40;
        MyAvatar = document.getElementById("MyAvatar");
//        CursorX=CursorX-32;
//        CursorY=CursorY-32;
        self.clearTimeout(T);
        
        GlobalSleepTime=0;
        
        moveMyAvatar();
 
    }    
 //   window.onload = init;



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
           
            
            
          
          
            
//            if( OutX>0 &&  OutY==0)
//            {
//             StyleLeftRight();
//            }
//             else if(OutX<0 && OutY==0)
//            {
//            StyleRightLeft(); 
//            }
//            else if( OutX==0 && OutY>0)
//            {
//            StyleTopBottom();
//            }
//             
//             else if( OutX==0&& OutY<0)
//            {
//            StyleBottomTop();
//            }
            
            
            
             if(OutX>0 && OutY<0)
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
             if(Math.abs(OutX)<=13)
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
//            MyAvatar.style.backgroundPosition=tempBackLeft+"px "+step+"px";
           
            MyAvatar.style.left=MyAvatarX+"px";
            MyAvatar.style.top=MyAvatarY+"px";
           
            
            
            
           // alert(tempBackLeft);
 
            document.getElementById("txtMyDetails").value="left:"+Math.floor(MyAvatarX)+"px "+";top:"+Math.floor(MyAvatarY)+"px"; 
           
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
    function TurnAvatarVisible()
        {
         var avatar = document.getElementById("MyAvatar");
         avatar.style.display="block";
         return true;
        }
        function turnAvatarInvisible()
        {
         var avatar = document.getElementById("MyAvatar");
         avatar.style.display="none";
        }
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
        
        function ShowUserRoomThumb(imgCntrl)
      {
          if(imgCntrl.src.search("_mini.jpg")<0)
          {
          imgCntrl.alt=imgCntrl.src;
          imgCntrl.src=imgCntrl.alt+"_mini.jpg";
          
//          imgCntrl.style.position="absolute";
          
          }
          else if(imgCntrl.src.search("_mini.jpg")>0)
          {
           imgCntrl.src=imgCntrl.alt;
//           imgCntrl.style.position="relative";
          }
     }
    
    </script>
    <script type="text/javascript" src="JS/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="JS/main.js" ></script>
    
    <style type="text/css">


#screenshot{
	position:absolute;
	border:1px solid #ccc;
	background:#333;
	padding:5px;
	display:none;
	color:#fff;
	}

/*  */
</style>

</head>
<%--style="background-image:url(Images/Site/night.png); background-repeat:repeat"--%>
<body style="background-color:#283227"  >
    <form id="form1" runat="server" >

     <uc1:LoggedInUserMenu ID="LoggedInUserMenu1" runat="server" />
     <div class="main-div" runat="server" id=maindiv style="width:1000px">
    
                <input type=text  style="display:none" id="txtMyDetails"  runat="server"  />
            
         
            
                <div  id="room" runat="server" onclick=handleEvent(event) style="width:800px; padding:5px; float:left; height:605px;background-image:url(Images/AvatarChat/Island.jpg); background-repeat:no-repeat; " >
                 
                <div id="MyAvatar" style="display:none; position:absolute; top:50px; left:300px;" > 
                            <asp:ImageButton runat="server" ID="imgbtnSetHome" 
                                 ImageUrl="~/Images/AvatarChat/SetHome.gif" Width="50" Height="50" 
                                 style="background-color:Transparent" onclick="imgbtnSetHome_Click" /> 
                           <span style="color:#9AD8E8"> Click at this home to occupy the location you are currently in</span>
                </div>
                 
                    
                    
                    
                    <asp:DataList runat="server" ID="dlUsers" RepeatDirection=Horizontal 
                        RepeatLayout=Flow >
                    <ItemTemplate>
                    <span style="color:#CCC">
                        <a style="position:absolute;<%#DataBinder.Eval(Container.DataItem, "location")%>" class="screenshot" rel="Images/AvatarChat/Background/<%#DataBinder.Eval(Container.DataItem, "user_id")%>_thumb.jpg"  href=chatroom.aspx?room_id=<%#  DataBinder.Eval(Container.DataItem, "user_id")%>><img  onmouseover="ShowRoomThumb(this);"   style="width:10px"   src="Images/AvatarChat/flag.gif" />
                        <%#DataBinder.Eval(Container.DataItem, "user_name")%></a>
                    </span>
                    

                    </ItemTemplate>
                    </asp:DataList>
                </div>
                
                 
                         
                
                  <div style="float:left;  width:180px; ">
                   

                       
                               <asp:DataList ID="datalistRoomChater" Width=150 runat="server" style="float:left" RepeatDirection=Vertical>
                               <ItemTemplate>
                                                  <p>  <a href="chatroom.aspx?room_id=<%#  DataBinder.Eval(Container.DataItem, "RoomId")%>">   <img src="Images/AvatarChat/Background/<%#DataBinder.Eval(Container.DataItem, "RoomId")%>_thumb.jpg" /></a></p>
                                                   <p style="border-bottom:1px solid #9AD8E8"> <%# DataBinder.Eval(Container.DataItem, "CurrentMember")%>  online</p>
                                                        
                                                        
                             <%--<img alt="" src="Images/AvatarChat/Background/3_thumb.jpg" />
                               <p><a href=chatroom.aspx?room_id=<%#  DataBinder.Eval(Container.DataItem, "RoomId")%> <img alt="" src="Images/AvatarChat/Background/<%#DataBinder.Eval(Container.DataItem, "RoomId")%>_thumb.jpg"  /></a></p>
                               <p style="border-bottom:1px solid #9AD8E8"> <%# DataBinder.Eval(Container.DataItem, "CurrentMember")%>  online</p>
                           --%>
                                
                               </ItemTemplate>
                                </asp:DataList>
                       
                   </div>
               
                    
               
               
         
        
        
    </div>
    </form>
</body>
</html>
