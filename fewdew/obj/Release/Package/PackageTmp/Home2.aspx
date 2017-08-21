<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home2.aspx.cs" EnableEventValidation="false"   ValidateRequest="false" Inherits="BDDoctors.Home2" %>
<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>
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
<%@ Register src="Controls/FeedRelated/NotifPoll.ascx" tagname="NotifPoll" tagprefix="uc10" %>
<%@ Reference Control="~/Controls/FeedRelated/NotifPoll.ascx" %>
<%@ Register src="Controls/FeedRelated/Noti_WorldLocation_Changed.ascx" tagname="Noti_WorldLocation_Changed" tagprefix="uc11" %>
<%@ Reference Control="~/Controls/FeedRelated/Noti_WorldLocation_Changed.ascx" %>
<%@ Register src="Controls/FeedRelated/NotifSingleImage.ascx" tagname="NotifSingleImage" tagprefix="uc12" %>
<%@ Reference Control="~/Controls/FeedRelated/NotifSingleImage.ascx" %>
<%@ Register src="Controls/ContentBasedFeed.ascx" tagname="ContentBasedFeed" tagprefix="uc6" %>
<%@ Reference Control="~/Controls/ContentBasedFeed.ascx"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>FewDew|My Yard</title>
<script type="text/javascript" src="JS/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="JS/jquery.timeago.js" ></script>
<script type="text/javascript"  src="JS/mytab.js"></script>
<script type="text/javascript" src="JS/home.js" ></script>
<script type="text/javascript" src="JS/ajaxupload.js"> </script>
   
<link href="CSS/Global.css" rel="stylesheet" type="text/css" />
<link href="CSS/Home.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="JS/phonetic_int.js"></script>
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
 

       
       <link href="CSS/mytab.css" rel="stylesheet" type="text/css" />        
      
          <style runat="server" id="serverStyle" type="text/css">
    
            </style>
<style type="text/css">
##page_navigation{ float:left;}    
#page_navigation a{
	padding:3px;
	border:1px solid #CCC;
	margin:2px;
	color:black;
	text-decoration:none
}
.active_page{
	background:#9AD8E8;
	color:white !important;
}
</style>
  
    <style type="text/css">
       		
        div.button {height: 29px;width: 133px;background: url(../images/site/button.png) 0 0;font-size: 14px; color: #C7D92C; text-align: center; padding-top: 15px;}		
        div.button.hover {background: url(../images/site/button.png) 0 56px;color: #95A226;	}		
        #button2.hover, #button4.hover { text-decoration:underline; }
    		
    </style>
     <script type="text/javascript" src="JS/jquery.colorbox-min.js" ></script>
     <link href="colorbox.css" rel="stylesheet" type="text/css" />
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
				$(".iframe").colorbox({width:"400px", height:"220px", iframe:true});
				$(".inline").colorbox({width:"50%", inline:true, href:"#inline_example1"});
				
				//Example of preserving a JavaScript event for inline calls.
				$("#click").click(function(){ 
					$('#click').css({"background-color":"#f00", "color":"#fff", "cursor":"inherit"}).text("Open this window again and this message will still be here.");
					return false;
				});
			});
</script>
    
    <script type="text/javascript" src="JS/jqdialog.min.js" ></script>
     <link href="CSS/jqdialog.css" rel="stylesheet" type="text/css" />	
        
</head>
<body onload="MakeBanglaEditor();GetCurrentTime();"  >
    <form id="form1" runat="server">
    <img src="Images/Site/busy.gif" id="busy" style="display:none; position:absolute;" />
       <input type='hidden' id='current_page' />
	<input type='hidden' id='show_per_page' />
          
        
                              
          
        
                              <div class="dvMain" >
                                      
        <uc1:LoggedInUserMenu ID="LoggedInUserMenu2" runat="server" />
     
                                     
                    
                                     <div class="body" style="margin-bottom:100px">
                                            
                                             <div  style="float:left; display:none" class="user-right-menu" >
                                           
                                           
                                                        <ul >
                                                            
                                                        </ul>
                                                
                                            </div>
                                            
                                           
                                                
                                                 <div class="home-left" >
                                               
                                                        <div id="wrapper">
                                                            <ul class="tabs">
                                                                <li><a href="#" class="defaulttab" rel="tabs1">Status</a></li>
                                                                <li><a class="" href="#" rel="tabs2">Image</a></li>
                                                                <li><a class="" href="#" rel="tabs3">Blog</a></li>
                                                                <li><a class="" href="#" rel="tabs4">Album</a></li>
                                                                <li><a class="selected" href="#" rel="tabs5">P-Point</a></li>
                                                            </ul>
                                                         
                                                            <div style="display:none;" class="tab-content" id="tabs1"> 
                                                                <textarea class="txtStatusTextBox" style="margin:6px; " ></textarea>
                                                                
                                                                 <input id="submitStatus" type=button value="POST" style="height:30px;margin:6px " onclick="ServerPostStatusMessage();" />  
                                                             </div>
                                                            <div style="display: none;" class="tab-content" id="tabs2">
                                                                 <div id="singleImageUploadButton" class="button">Upload</div>
                                                            </div>
                                                             <div style="display: none;" class="tab-content" id="tabs3"> <a href="BlogSection/CreateBlog.aspx" style=" ">Create blog </a></div>
                                                             <div style="display: none;" class="tab-content" id="tabs4">
                                                                                    <span style="float:left" >Album Name</span>
                                                                                   <asp:TextBox runat="server" ID="txtAlbumName"  style="Height:20px; Width:120px; float:left" ></asp:TextBox>
                                                                                   <asp:Button runat="server" ID="btnPostAlbum" style="float:left " 
                                                                                    Text="POST" onclick="btnPostAlbum_Click" />
                                                             </div>   
                                                            <div style="display: block;" class="tab-content" id="tabs5"><a href=MediPanel.aspx style="">Seek Prescription</a></div>
                                                        </div>
                                                        
                                                        <span class="menu_class">Feed Type<img src="Images/Site/dropsign.gif" style="width:10px" /> </span>

                                                        <ul style="display: none;" class="the_menu">
                                                       <li><asp:LinkButton runat="server"   ID="lbtnPublicNotification" Text="Public feed" onclick="lbtnPublicNotification_Click"  
                                                                    ></asp:LinkButton></li>                            
                                                            <li><asp:LinkButton runat="server"  ID="lbtnFriendNotification" Text="Contact feed" onclick="lbtnFriendNotification_Click" 
                                                                    ></asp:LinkButton></li>

                                                        </ul>
                                                      
                                                      
                                                      
                                                        
                                                                
                                                               
                                                                

      
                                                            <div id="AllFeed" style="width:600px; display:inline-block;">
                                                            <asp:DataList ID="GridContentBasedNotification" runat="server"  RepeatLayout=Flow EnableViewState=false
                                                            AutoGenerateColumns="false"  ShowHeader=false ShowFooter=false
                                                           
                                                             Width=600 onitemdatabound="GridContentBasedNotification_ItemDataBound" >
                                                             <ItemTemplate>
                                                                   <%  %>     
                                                                       
                                                                         
                                                                              
                                                                            <%--   <asp:LinkButton runat="server" ID="lbtnDelete"  Text="Delete"  ></asp:LinkButton>|
                                                                                <asp:LinkButton runat="server" Visible=false ID="lbtnFavourite"   Text="Add To My Favourite" CommandName="edit" ></asp:LinkButton>
                                                                            --%>     
                                                                            <asp:Panel runat="server" ID="pnlDelete" Visible="false" CssClass="delete-parent"     >Delete</asp:Panel>
                                                                              
                                                                             
                                                                             <div style="float:left; width:100%; margin-bottom:20px; border-bottom:1px solid #E5F7FC" >
                                                                                    <uc4:Notif_UploadedImage ID="Notif_UploadedImage1" runat="server" Visible="false"  />
                                                                                    <uc5:Notif_UploadedVideo ID="Notif_UploadedVideo1" runat="server" Visible="false" />
                                                                                    <uc7:Notif_UserStatus ID="Notif_UserStatus1" runat="server" Visible="false" />
                                                                                    <uc8:Notif_Blog ID="Notif_Blog1" runat="server" Visible="false" />
                                                                                    <uc9:NotifTreatPanel ID="NotifTreatPanel1" runat="server" Visible="false" />
                                                                                    <uc10:NotifPoll ID="NotifPoll1" runat="server" visible="false" />
                                                                                    <uc11:Noti_WorldLocation_Changed ID="Noti_WorldLocation_Changed1"  Visible="false"  runat="server" />
                                                                                    <uc12:NotifSingleImage ID="NotifSingleImage1" runat="server" />
                                                                                 <div style="float:left; width:100%; ">
                                                                                        
                                                                                     <uc3:Comment ID="Comment1" runat="server"   />
                                                                                 </div> 
                                                                              </div> 
                                                                              
                                                                              
                                                              </ItemTemplate>
                                                              </asp:DataList>           
                                                                        
                                                           </div> 
                                                 </div>         
                                           
                                            
                                            
                                            <div style="float:left;" class="home-right">
                                         <div id='page_navigation'></div>
                                         <p style="width:380px; height:30px; display:inline-block"></p>
                                                     <asp:DataList ID="GridPublicInfoNotification" runat="server" CssClass="YourGridView" 
                                                          AutoGenerateColumns="false"  Width="380"     
                                                            ShowHeader="false"  style="float:left"  RepeatLayout=Flow 
                                                              >
                                                           
                                                      
                                                                <ItemTemplate>
                                                                <div style="float:left;">
                                                                    <div style="float:left;width:40px;  ">
                                                                        <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>><img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "User_id")%>_mini.jpg" class="mini" /></a>
                                                                    </div>
                                                                    
                                                                    <div style="float:left;width:320px;margin-left:7px  ">
                                                                      <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>>   <%#DataBinder.Eval(Container.DataItem, "User_Name")%></a>
                                                                              <%--   <%# DataBinder.Eval(Container.DataItem, "Attribute_Name")%>                                                                           --%>
                                                                              <%# DataBinder.Eval(Container.DataItem, "Node_value")%> 
                                                                    </div>
                                                                 </div>       
                                                                        
                                                                          
                                                                </ItemTemplate>                                
                                                        </asp:DataList>
                                                        
                                                        
                                                                             
                                            </div>
                                            
                                            
                          
                                           
       
                    
                                       </div> 
            
           
                             </div>
    
    
        
        
    
    
    
    
    </form>
</body>
</html>
