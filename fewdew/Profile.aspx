<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="BDDoctors.Profile" %>
<%@ Register src="Controls/EducationalInformation.ascx" tagname="EducationalInformation" tagprefix="uc1" %>
<%@ Register src="Controls/Workstation.ascx" tagname="Workstation" tagprefix="uc2" %>
<%@ Register src="Controls/BasicInfo.ascx" tagname="BasicInfo" tagprefix="uc3" %>
<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc4" %>
<%@ Register src="Controls/ProfilePhoto.ascx" tagname="ProfilePhoto" tagprefix="uc6" %>
<%@ Register src="Controls/PracticingZone.ascx" tagname="PracticingZone" tagprefix="uc5" %>
<%@ Register src="Controls/FriendList.ascx" tagname="FriendList" tagprefix="uc7" %>
<%@ Register src="Controls/ComposeEmail.ascx" tagname="ComposeEmail" tagprefix="uc8" %>
<%@ Register src="Controls/BlogList.ascx" tagname="BlogList" tagprefix="uc9" %>
<%@ Register src="Controls/UploadedPhoto.ascx" tagname="UploadedPhoto" tagprefix="uc10" %>
<%@ Register src="Controls/UploadedVideo.ascx" tagname="UploadedVideo" tagprefix="uc11" %>
<%@ Register src="Controls/CreatePersona.ascx" tagname="CreatePersona" tagprefix="uc12" %>
<%@ Register src="Controls/FeedRelated/NotifPoll.ascx" tagname="NotifPoll" tagprefix="uc22" %>
<%@ Reference Control="~/Controls/FeedRelated/NotifPoll.ascx" %>
<%@ Register src="Controls/FeedRelated/Status.ascx" tagname="Status" tagprefix="uc2" %>
<%@ Reference Control="~/Controls/FeedRelated/Status.ascx"  %>
<%@ Register src="Controls/Comment.ascx" tagname="Comment" tagprefix="uc3" %>
<%@ Reference Control="~/Controls/Comment.ascx" %>
<%@ Reference Control="~/Controls/FeedRelated/Notif_UploadedImage.ascx" %>
<%@ Register src="Controls/FeedRelated/Notif_UploadedImage.ascx" tagname="Notif_UploadedImage" tagprefix="uc4" %>
<%@ Register src="Controls/Notif_UploadedVideo.ascx" tagname="Notif_UploadedVideo" tagprefix="uc5" %>
<%@ Reference Control="~/Controls/Notif_UploadedVideo.ascx" %>

<%@ Register src="Controls/FeedRelated/Notif_UserStatus.ascx" tagname="Notif_UserStatus" tagprefix="uc7" %>
<%@ Reference Control="~/Controls/FeedRelated/Notif_UserStatus.ascx" %>
<%@ Register src="Controls/Notif_Blog.ascx" tagname="Notif_Blog" tagprefix="uc8" %>
<%@ Reference Control="~/Controls/Notif_Blog.ascx" %>
<%@ Register src="Controls/NotifTreatPanel.ascx" tagname="NotifTreatPanel" tagprefix="uc9" %>
<%@ Register src="Controls/ClickedOnAddConnectionButton.ascx" tagname="ClickedOnAddConnectionButton" tagprefix="uc13" %>
<%@ Register src="Controls/FeedRelated/Noti_WorldLocation_Changed.ascx" tagname="Noti_WorldLocation_Changed" tagprefix="uc23" %>
<%@ Reference Control="~/Controls/FeedRelated/Noti_WorldLocation_Changed.ascx" %>
<%@ Register src="Controls/FeedRelated/NotifSingleImage.ascx" tagname="NotifSingleImage" tagprefix="uc24" %>
<%@ Reference Control="~/Controls/FeedRelated/NotifSingleImage.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>FewDew|Profile</title>
        
  <script type="text/javascript" src="JS/jquery-1.3.2.min.js"></script> 
    <link href="CSS/Profile_Page.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Global.css" rel="stylesheet" type="text/css" />
    <link href="CSS/EduInfo.css" rel="stylesheet" type="text/css" />
           <script type="text/javascript" src="JS/phonetic_int.js"></script>
<META HTTP-EQUIV="PRAGMA" CONTENT="NO-CACHE">
    <script type="text/javascript">
        _uacct = "UA-1154128-1";
        urchinTracker();
</script>

    <script type="text/javascript">
     var IsFavClicked=0;
     $(document).ready( function(){

            $("textarea").each(function(){
               $(this).attr('id','banlgaenable'+$('textarea').index(this));
            });
            
            $("textarea,input").each(function(){
                makePhoneticEditor(this);
                
            }).focus( function(){
                $(this).css('height','50px');
            });
        });
  
    </script>
    <script type="text/javascript">
    
     function handleEvent(oEvent) 
            {
             var dv = document.getElementById("click-add");
             dv.style.left=oEvent.clientX+"px";
             dv.style.top=oEvent.clientY+"px";
              return true;
            }  
            
            
       
        
        


        
         function ShowActualSize(imgCntrl)
            {
                  if(imgCntrl.src.search("_mini.jpg")>0)
                  {
                  imgCntrl.src=imgCntrl.src.replace("_mini.jpg","")+"_display.jpg";
                  }
                  else if(imgCntrl.src.search("_display.jpg")>0)
                  {
                   imgCntrl.src=imgCntrl.src.replace("_display.jpg","")+"_mini.jpg";
                  }
            }

          
    </script>
    


 <script type="text/javascript" src="JS/jquery.timeago.js" ></script>
 <script type="text/javascript" src="JS/Profile.js" ></script>
 <script type="text/javascript" src="JS/jquery.colorbox-min.js"  ></script>
 <link type="text/css" media="screen" rel="stylesheet" href="colorbox.css" />


     <script type="text/javascript">
			$(document).ready(function(){
				//Examples of how to assign the ColorBox event to elements
				$("a[rel='example1']").colorbox();
				$("a[rel='example2']").colorbox({transition:"fade"});
				$("a[rel='example3']").colorbox({transition:"none", width:"75%", height:"75%"});
				$("a[rel='example4']").colorbox({slideshow:true});
				$(".single").colorbox({}, function(){
					alert('Howdy, this is an example callback.');
				});
				$(".colorbox").colorbox();
				$(".youtube").colorbox({iframe:true, width:650, height:550});
				$(".iframe").colorbox({width:"80%", height:"80%", iframe:true});
				$(".addFriend").colorbox({width:"50%", height:"50%", iframe:true});
				
				$(".inline").colorbox({width:"50%", inline:true, href:"#inline_example1"});
				
				//Example of preserving a JavaScript event for inline calls.
				$("#click").click(function(){ 
					$('#click').css({"background-color":"#f00", "color":"#fff", "cursor":"inherit"}).text("Open this window again and this message will still be here.");
					return false;
				});
			});
		</script>
		 <style runat="server" id="serverStyle" type="text/css">
    
         </style>
<script type="text/javascript" src="JS/jqdialog.min.js" ></script>
<link href="CSS/jqdialog.css" rel="stylesheet" type="text/css" />	

</head>

<body   >
    
    <form id="form1" runat="server">
       
        <input runat="server" id="hiddenInputAmITheOwner"   style="display:none" />
        
        
       <uc4:LoggedInUserMenu ID="LoggedInUserMenu1" runat="server" />  
    <div class="dvMain" >
    
          <div class="top">           
           <span style="font-size:14px; font-weight:bold; color:#393D3D; margin-top:5px;"><asp:Label runat="server" ID="lblPageUserName"></asp:Label></span>
                
           </div>
         
                  
           <div class="body">
                    <div class="profile-left" >
                                 
                                 
                    
                    
                         <div class="profile-image">
                                     <div runat="server" id="dvPersona" >
                                        <uc12:CreatePersona ID="CreatePersona1" runat="server" />
                                    </div>                    
                                 <ul>
                                  <%--  <li><asp:LinkButton runat="server" ID="lbtnSendEmail" Text="Send Email" 
                                  Visible="false"   style="float:right"  onclick="lbtnSendEmail_Click"></asp:LinkButton></li>
                                    <li>--%>
                                    <a  runat="server" class='iframe' id="anchorSendEmail" href=SendEmail.aspx >Send email</a>
                             <%--<p><a class='iframe' href="http://google.com">Outside webpage (IFrame)</a></p>--%>

                                <%--<div runat="server" id="divSendEmail" style="position:absolute;top:200px; left:100px; width:500px" class="blackblock" visible="false">
                                    
                                        <asp:ImageButton runat="server" ID="imgBtnClose"  style="float:right; margin:3px" 
                                                ImageUrl="~/Images/Site/close_button.gif" onclick="imgBtnClose_Click" />
                                        <asp:Label runat="server" ID="lblValidationMessage"   ></asp:Label>
                                            <ul runat="server" id="ulControl">
                                                 <li><asp:Label runat="server" ID="lblEmailAttribute" Text="To" CssClass="AttributeLabel2" ></asp:Label><asp:TextBox runat="server" ID="txtTo" Enabled=false></asp:TextBox></li>
                                                 <li><asp:Label runat="server" ID="Label4" Text="Subject" CssClass="AttributeLabel2" ></asp:Label><asp:TextBox runat="server" ID="txtSubject" MaxLength="150"  ></asp:TextBox></li>
                                                 <li><asp:Label runat="server" ID="Label1" Text="Message" CssClass="AttributeLabel2" ></asp:Label><asp:TextBox runat="server" ID="txtMessage" TextMode="MultiLine" CssClass="message-box"></asp:TextBox></li>
                                                 <li><asp:Label runat="server" ID="Label3" Text="" CssClass="AttributeLabel2" ></asp:Label>
                                                 <asp:Button runat="Server" ID="btnSend" Text="Send" onclick="btnSend_Click"  />
                                                 <asp:Button runat="server" ID="btnCancel" Text="Cancel" onclick="btnCancel_Click" />
                                                     
                                                 </li>   
                     
                                            </ul> 
                                   
                                </div>--%>
                                
                             
                                
                             
                             <li>
                                 
                                 <uc6:ProfilePhoto ID="ProfilePhoto1" runat="server" /></li>
                                <%-- <li> <asp:LinkButton style="float:right" runat="server" ID="lbtnAddAsConnection"  Text="Request to be contact" Visible="false" onclick="lbtnAddAsConnection_Click"  ></asp:LinkButton></li>--%>
                            
                                 
                                <%--<div id="click-add"  style="position:absolute; top:150px; float:left; z-index:3">
                                        <uc13:ClickedOnAddConnectionButton ID="ClickedOnAddConnectionButton1"  
                                        runat="server" Visible=false />
                                </div>--%>
                                
                            <li>
                              <a runat="server" id="anchorAddFriend" class='addFriend' visible=false >Add As contact</a>  
                            </li>
                         </ul>
                         
                        </div>
                        
                        <div class="user-right-menu;" style="display:none" >
                        
                        
                        
                        <asp:label runat="server" ID="lbtnWhoseworld" style="font-size:15px; position:relative;top:50px;left:80px;font-weight:bold; color:#80C23B"></asp:label>
                
                            <ul>
                                <li>                               
                                <asp:LinkButton runat="server" ID="lbtnWorld" ><img src="Images/Site/world.gif" /> </asp:LinkButton></li>        

                                <li><asp:LinkButton runat="server" ID="lbtnUserInformation" Text="Information" onclick="lbtnUserInformation_Click" 
                                     OnClientClick="IsFavClicked=0;"   ></asp:LinkButton></li>                            
                                <li><asp:LinkButton runat="server" ID="lbtnUserBlog" Text="Blog" 
                                     OnClientClick="IsFavClicked=0;"   onclick="lbtnUserBlog_Click"></asp:LinkButton></li>
                                <li> <asp:LinkButton runat="server" ID="lbtnUploadedVideo" Text="Uploaded Video" 
                                     OnClientClick="IsFavClicked=0;"   onclick="lbtnUploadedVideo_Click"></asp:LinkButton></li>
                                 <li><asp:LinkButton runat="server" ID="lbtnUploadedImage" Text="Photo albums" 
                                     OnClientClick="IsFavClicked=0;"    onclick="lbtnUploadedImage_Click"></asp:LinkButton></li>
                                <li><asp:LinkButton runat="server" ID="lbtnMyTreatpanel" Text="Prescription Point" onclick="lbtnMyTreatpanel_Click" 
                                         OnClientClick="IsFavClicked=0;" ></asp:LinkButton></li>
                                <li><asp:LinkButton runat="server" ID="lbtnMyPersona" Text="Persona" onclick="lbtnMyPersona_Click" 
                                        OnClientClick="IsFavClicked=0;" ></asp:LinkButton></li>
                                <li><asp:LinkButton runat="server" ID="lbtnMyPreviousStatus" Text="Previous status" onclick="lbtnMyPreviousStatus_Click" 
                                        OnClientClick="IsFavClicked=0;"  ></asp:LinkButton></li> 
                                 <li><asp:LinkButton runat="server" ID="lbtnMyFavouriteList" Text="User favourites" onclick="lbtnMyFavouriteList_Click" 
                                        OnClientClick="IsFavClicked=1; "  ></asp:LinkButton></li> 
                                        <input runat="server" id="hiddenInputIsFavClicked"   style="display:none" />
                                                       
                            </ul>
                          
                       
                        
                        </div>
                        
                        <uc7:FriendList ID="FriendList1" runat="server" />
                    </div>
                    
                    <div class="profile-right">                    
                          
                         <span class="menu_class" runat="server" id="SpanMenu">Information<img src="Images/Site/dropsign.gif" style="width:10px" /></span>

                                                        <ul style="display:none;" class="the_menu">
                                                       <li><asp:LinkButton runat="server"   ID="lbtnInfo" Text="Information" onclick="lbtnInfo_Click" 
                                                                    ></asp:LinkButton></li>                            
                                                            <li><asp:LinkButton runat="server"  ID="lbtnWall" Text="Executed" onclick="lbtnWall_Click"  
                                                                    ></asp:LinkButton></li>

                                                        </ul>
                         
                         
                         
                         
                        <div runat="server" id="divUserInformation">
                            <h2 class="heading" > Basic Information</h2>
                            <uc3:BasicInfo ID="BasicInfo1" runat="server" />
                            <h2 class="heading" > Work Station</h2>
                            <uc2:Workstation ID="Workstation1" runat="server" />
                            <%--<uc5:PracticingZone ID="PracticingZone1" runat="server" />--%>
                            <h2 class="heading" > Education Information</h2>
                             <uc1:EducationalInformation ID="EducationalInformation1" runat="server" />
                             <h2 class="heading" > Practice zone</h2>
                           <uc5:PracticingZone ID="PracticingZone1" runat="server" /> 
                        </div>
                        <div runat="server" id="divUserBlogList" style="background-color:#393D3D; margin-top:20px; height:80px"> 
                        <%-- <asp:Label runat="server" ID="lblSuccessfullyBlogPostMessage"   ></asp:Label>
                            <asp:LinkButton runat="server" ID="lbtnPostNewBlog" style="float:right" ForeColor=white
                                Text="Post New Blog" onclick="lbtnPostNewBlog_Click"></asp:LinkButton>--%>
                        </div>
                        
                          <div runat="server" id="divTreatMentPanel" visible=false style="background-color:#393D3D; margin-top:20px; height:80px"> 
                         <asp:HyperLink runat="server" style="float:right" ForeColor=white ID="hlinkNewPanel" Text="Seek new prescription" NavigateUrl="~/MediPanel.aspx"></asp:HyperLink>
                               
                         </div>
                        <div runat="server" id="DivUploadedImage" style="background-color:#393D3D; margin-top:20px; height:80px">
                            <%-- <uc10:UploadedPhoto ID="UploadedPhoto1" runat="server" BindInfo="false" />--%>
                                    <div runat="server" id="divCreateNewAlbum" style="float:left"  >
                                            <ul>
                                              <li> <asp:Label runat="server" ID="lblValidationMessageForAlbum"  ForeColor=Red  ></asp:Label></li> 
                                              <li><span style="width:120px; font-weight:bold;  color:White; text-align:right; display:inline-block">Album Name</span><asp:TextBox runat="server" ID="txtalbumTitle"  Width="200"    ></asp:TextBox>
                                                  <asp:Button runat="Server" ID="btnCreatAlbum" Text="Create Album" 
                                                      onclick="btnCreatAlbum_Click"  /></li> 
                                             </ul>   
                                                          
                                       </div>
                            
                        </div>
                        
                        <div runat="server" id="divUploadedVideo" style="background-color:#393D3D; margin-top:20px; height:80px"> 
                           
                            <asp:Label runat="server" ID="lblValidationMessageForVideo"></asp:Label>   
                                 <ul>                                       
                                    <li><asp:Label runat="server" ID="lblUploadMessage"></asp:Label></li>
                                    <li><span style="width:120px; font-weight:bold; font-size:13px; color:White; text-align:right; display:inline-block">Video Title</span> <asp:TextBox runat="server" ID="txtVideoTitle"></asp:TextBox></li>
                                    <li><span style="width:123px; font-weight:bold; font-size:13px; color:White; text-align:right; display:inline-block">Browse file</span><asp:FileUpload ID="FileUploadVideo" runat="server"  /><asp:Button ID="btnUpload" runat="server" 
                                            Text="Upload" onclick="btnUpload_Click"   /></li>
                                    
                                 </ul>        
                            
                        </div>
                     
                     
                         
                         
                         
                         
                         
                         
                                                <div id="AllFeed" style="width:600px; display:inline-block;>
                                                            <asp:DataList ID="GridContentBasedNotification" runat="server"  RepeatLayout=Flow EnableViewState=false
                                                            AutoGenerateColumns="false"  ShowHeader=false ShowFooter=false
                                                           
                                                             Width=600 onitemdatabound="GridContentBasedNotification_ItemDataBound" >
                                                             <ItemTemplate>
                                                                       
                                                                       
                                                                              <asp:Panel runat="server" ID="pnlDelete" Visible="false" CssClass="delete-parent"     >Delete</asp:Panel>
                                                                              
                                                                             <div style="float:left; width:100%; margin-bottom:20px; border-bottom:1px solid #E5F7FC" >
                                                                                    <uc4:Notif_UploadedImage ID="Notif_UploadedImage1" runat="server" Visible="false"  />
                                                                                    <uc5:Notif_UploadedVideo ID="Notif_UploadedVideo1" runat="server" Visible="false" />
                                                                                    <uc7:Notif_UserStatus ID="Notif_UserStatus1" runat="server" Visible="false" />
                                                                                    <uc8:Notif_Blog ID="Notif_Blog1" runat="server" Visible="false" />
                                                                                    <uc9:NotifTreatPanel ID="NotifTreatPanel1" runat="server" Visible="false" />
                                                                                    <uc22:NotifPoll ID="NotifPoll1" runat="server" visible="false" />
                                                                                    <uc23:Noti_WorldLocation_Changed ID="Noti_WorldLocation_Changed1"  Visible="false"  runat="server" />
                                                                                    <uc24:NotifSingleImage ID="NotifSingleImage1" runat="server" />
                                                                                 <div style="float:left; width:100%; ">
                                                                                        
                                                                                     <uc3:Comment ID="Comment1" runat="server"   />
                                                                                 </div> 
                                                                              </div> 
                                                                              
                                                                              
                                                              </ItemTemplate>
                                                              </asp:DataList>           
                                                                        
                                                </div> 

                         
                         
                         
                         
                         
                         
                         
                        
                   
                    </div>
                    
            </div>    
        
           
            
           
    </div>
    </form>
</body>
</html>
