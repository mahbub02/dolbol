<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="club.aspx.cs" Inherits="BDDoctors.club" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link rel="shortcut icon" href="Images/Site/fewdew.png" type="image/x-icon" />
<title>dolbol</title>
        
<script type="text/javascript" src="Js/jquery-1.3.2.min.js" ></script>
<script type="text/javascript" src="JS/JqueryTimer.js"></script>
<script type="text/javascript" src="JS/jquery.emoticon.js"></script>
<script type="text/javascript" src="JS/emoticons.js"></script>
<script type="text/javascript" src="JS/FeedRelated.js" ></script>
<script type="text/javascript" src="JS/jquery.cuteTime.min.js" ></script>
<script type="text/javascript" src="JS/jquery.colorbox-min.js" ></script>

<link href="CSS/Layout.css" rel="stylesheet" type="text/css" />
<link href="CSS/Club.css" rel="stylesheet" type="text/css" />
<link href="colorbox.css" rel="stylesheet" type="text/css" />


<script type="text/javascript" src="JS/phonetic_int.js"></script>
<script type="text/javascript">
_uacct = "UA-1154128-1";
//urchinTracker();
</script>

<script type="text/javascript">
</script>
<% if (BDDoctors.LoginHandler.LoggedInUser().Id.Value == 1) %>
<%{ %>

<script type="text/javascript" src="JS/JqueryDraw.js" ></script>
<script type="text/javascript" src="JS/ClubAdmin.js"></script>

<%} %>

<script type="text/javascript" src="JS/JqueryDraw.js" ></script>
<script type="text/javascript" src="JS/Club.js" ></script>
<script type="text/javascript" src="JS/speech.js"></script>
<script type="text/javascript" src="JS/OnlineUser.js"></script> 
<script type="text/javascript" src="JS/Request.js"></script>
<script type="text/javascript" src="JS/friendlist.js"></script>
<script type="text/javascript" src="JS/FindFriend.js"></script>
<script type="text/javascript" src="JS/jqdialog.min.js" ></script>
<script type="text/javascript" src="JS/ProfilePhotoChange.js" ></script>
<script type="text/javascript" src="JS/PostWallPhoto.js" ></script>
<link href="CSS/jqdialog.css" rel="stylesheet" type="text/css" />	




</head>
<body style="height:400px">
<form id="form1" runat="server">

     <div id="header-area">
                <ul>
                  <li id="signout"  style="margin-left:20px; margin-right:10px; background-image:none"><span ><asp:LinkButton runat="server" 
                            ID="lbtnsignout" style="font-weight:bold" Text="Sign out" 
                            onclick="lbtnsignout_Click"></asp:LinkButton></span> </li>
                    
                    
                   
                    <li id="friendRequestLI"  class="menu"><span id="friendRequest">Request</span></li>        
                   <li id="FeedMenuIcon"  class="menu" style=" margin-left:162px">
                      <span style="font-weight:bold">Feed</span>
                        
                    </li>
                     <li id="findFriend" class="menu"><span >Find Friend</span></li>
                </ul>
                <ul style="display:none;top:25px" id="FeedMenus">
                             <li id="MyWall" class="menu"><span >My Wall</span></li>
                            <li id="FriendsFeed" class="menu"><span >Friends Feed</span></li>
                            <li id="publicFeed" class="menu"><span >Public Feed</span></li>
                           
                        </ul>
     </div>

    <div id="content-area" style=" margin:0 0; ">
        <input type="hidden" runat="server" id="hiddenRoomId" />
        <input type="hidden" runat="server" id="hiddenUserId" />
        <input type="hidden" runat="server" id="hiddenUserDisplayName" />
        <img src="Images/site/busy.gif" id="loading" style="display:none; position:absolute; z-index:100" alt="wait" />
         <span id="tester" style="display:none"></span><span id="tester2" style="display:none"></span><span id="tester3" style="display:none"></span>
       
       <%-- <div  id="left-sider" >
           
        </div>--%>
         
        <div id="club-chatter" class="rounded" style=" background-repeat:no-repeat; background-image:url(Images/Club/<%=Request["room_id"]%>.jpg);">
         
        </div>
        <div id="right-sider">
            <div id="right-sider-accordioncontainer">
                <div id="ChatHistoryBoxContainer"  >
                    <div id="ChatHistoryBoxHeader">                                             
                         Club chat history
                    </div>
                    <div id="ChatHistory"   >
                        
                    </div>
                     
               </div> 
            
        
            </div>   
           <%--<div id="avatarMenu" >
                <span id="sendFriendRequst">Add as Friend</span>             
                <span id="initiate_chat" >Chat</span>
                <span>View Profile</span>
                
           </div>--%>
            
             <% if (BDDoctors.LoginHandler.LoggedInUser().Id.Value == 1) %>
                <%{ %>
                 <div id="MakeInsideCheckingEnable" style="width:100%;float:left; height:100px; background-color:gray; display:inline-block">
                    <span id="saveTheArea" style="border:1px solid #CCC; height:20px; width:100px; cursor:pointer">Save Area</span>
                    <input type="text" value="0" id="linkTo" />
                </div>
               <%} %>
       </div>
       
       <div  id="club-map">
        <div  id="hide-map">
         </div>       
          
           <div class="place-short-cut" id="shortcut1" >
            1
           </div>
           <div class="place-short-cut" id="shortcut2" >
           2
           </div>
           <div class="place-short-cut" id="shortcut3" >
           3
           </div>
             <div class="place-short-cut" id="shortcut4" >
           4
           </div>
         
           <div class="place-short-cut" id="shortcut6" >
           6
           </div>
             <div class="place-short-cut" id="shortcut7" >
           7
           </div>
            <div class="place-short-cut" id="shortcut8" >
           8
           </div>
            <div class="place-short-cut" id="shortcut9" >
           9
           </div>
            <div class="place-short-cut" id="shortcut10" >
           10
           </div>
            <div class="place-short-cut" id="shortcut11" >
           11
           </div>
           
       
            
       </div>
       
       <div id="avatar-details" class="topSlider">
       <div style="width:98%;">
            <a id='profilePhoto' href="IframeProfilePhotoChange.aspx"><img src="Images/Site/profileImageEdit.gif" /> </a>
            
            <div id="avatar-details-image" >
            </div>
            <div style="float:right; font-weight:bold; margin:4px;cursor:pointer;" id="closeAvatarDetails">
                X
            </div>     
             <div id="StatusBox">
                <span id="avatar-user-name">&nbsp</span>   
                <textarea id="txtStatusBox" ></textarea>
                    <div id="option-container">
                        <img src="Images/Site/chaticon.gif" class="options" id="imgStartChat" alt="Chat" />
                        <img src="Images/Site/add_friend_icon.gif" class="options" id="imgAddFriend" alt="Add him as friend" />
                        <img src="Images/Site/offlineMessage.gif" class="options" id="imgOfflineMessage" alt="Wall Post of this user" />
                        <img src="Images/Site/friendlist.gif" class="options" id="imgFriendList" alt="Friend List of this user" />
                        <a href="IframeUploadWallPhoto.aspx" id="ancPostWallPhoto"><img src="Images/Site/uploadImage.gif" class="options" id="imguploadImage" alt="Post photo to this wall" /></a> 
                        
                   </div> 

                <input type=button value="Share" id="btnStatusBox" class="small-button" />
             </div>
         </div>
         <div id="secondleveltitle"></div>    
                    
       
       
       </div>
       
        
    <%--   <div id="sample-container" style="width:240px; display:none; height:160px; position:absolute; background-color:Transparent">
          <% for (int i = 1; i <= 6; i++) %>
         <%{ %>
                 <img src="Images/AvatarChat/Avatar/sample/a<%=i.ToString()%>.png" class="sample-avatar"   />
         <%} %>
       </div>--%>
     <div id="emo-list" style="">
        <div id="static-emo" >
        <span id="ShowMoreEmo">More</span>
       
        </div>
        <div id="dynamic-emo-folder" >
            
        </div>
        <div id="dynamic-emo" >
     
        </div>
        
    </div>
    <div id="OnlineUserDisplayBox">
        <div id="OnlineUserBoxHeader"></div>
        <div id="OnlineUserContainer">
        </div>
    </div>
    
    <div id="FindFriendWrapper">
        <div id="FindFriendHeader">
           <span style="float:left; font-size:13px; color:White; font-weight:bold; margin-left:30px;">Search Friend</span>     <span style=" float:right" id="FindFriendClose">X</span>
        </div>
        <div id="FindFriendPanel">
            <ul>
                <li><span>Looking for a person? Try searching by email:</span></li>
                <li><input id="txtSearchFriend" type=text /><input  type=button id="btnFriendSearch" value="Search"  /> </li>
                <li><span id="SearchMessage"></span></li>
                <li>
                    <ul id="InvitationForm" >
                        <li>Invite someone to dolbol</li>
                        <li><span>To:</span><span id="InvitationTo"></span> </li>
                        <li><span>From:</span><span style="width:25px">You</span></li>
                        <li><span>Message:</span><textarea id="txtInvitationMessage"></textarea></li>
                        <li><span>&nbsp</span><input type=button id="btnInvite" value="Invite"  /> </li>
                        
                    </ul>
                </li>
            </ul>
          <div id="searchedUserListContainer">
          
          </div> 
          <div style="width:100%;">
            <span id="btnSearchMoreUser" style="display:none; float:right; cursor:pointer">More</span>
          </div> 
            
             
        </div>
        
    </div>
    
    <div id="region-container" style="display:none;">
        <div id="region-container-header">Region list <span id="close-region-container" style="float:right; font-weight:bold; font-size:14px; padding:3px; cursor:pointer">X</span></div>
        
        <span location="1" class="region">Dhaka University</span>
        <span location="2" class="region">BUET</span>
        <span location="3" class="region">CUET</span>
        <span location="4" class="region">Islami university</span>
        <span location="5" class="region">Jahangir nagar university</span>
        <span location="6" class="region">Rajshahi university</span>
        <span location="7" class="region">Sust</span>
           <div class="virtual-world" id="penguin-world" >
            <img src="Images/Club/penguinWorld.jpg" />
            Penguin world
           </div> 
           <div class="virtual-world" style="opacity:0.5;filter:alpha(opacity=5);">
            <img src="Images/Club/yahooworld.jpg" />
            Paradise 
          </div>
    </div>
             
    </div>
    <div id="footer">
        <div id="footer-inner">
          
            <div style="width:700px;">
         
                
                <div class="onlineMinMax altOnTop" style=""   alt="Online user list"    >
                    <span id="onlineUserNumber" style="position:relative;left:30px;top:-14px; background-color:Black; color:White; font-weight:bold"></span>
                </div>
                <ul style="float:left; display:inline; list-style:none;"  alt="Change keyboard layout" class="altOnTop" >
                   <li> <input type="radio"  name="language" value="b" class="language" />Bangla</li>
                   <li> <input type="radio" name="language" value="e" class="language" checked="checked" />English</li>
                </ul>
                <%--<img class="ShowHideMap" alt="select avatar" src="Images/Site/maps_human.gif"   />--%>
                <img id="ShowRegionList" alt="Map" class="altOnTop" src="Images/Site/maps_human.gif"   />
                 
                      
                <textarea type="text" id="txtChatTextBox" class="rounded" style="width:200px;padding-left:6px; padding-right:6px; border:1px solid #173500; height:20px; margin:2px; background-color:white; " ></textarea>
                <img src="Images/Site/red.gif" class="ShowHideEmo altOnTop" alt="Show emoticon list"   height="20px"/> 
                
                <img src="Images/Site/chathistory2.gif" class="ShowHideChatHistory altOnTop" alt="Show chat history"  height="20px"/> 
                
                <%--<img src="Images/Site/minimize.gif" class="ShowHideEmo" style="display:none"  height="20px"/> --%>
                      
             </div>
                   
        </div>
    </div>
   
</form>
</body>
</html>
