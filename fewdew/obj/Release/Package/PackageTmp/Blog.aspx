<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="BDDoctors.Blog" %>
<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>
<%@ Register src="Controls/FeedRelated/Status.ascx" tagname="Status" tagprefix="uc2" %>
<%@ Reference Control="~/Controls/FeedRelated/Status.ascx"  %>
<%@ Register src="Controls/Comment.ascx" tagname="Comment" tagprefix="uc3" %>
<%@ Reference Control="~/Controls/Comment.ascx" %>
<%@ Reference Control="~/Controls/FeedRelated/Notif_UploadedImage.ascx" %>
<%@ Register src="Controls/FeedRelated/Notif_UploadedImage.ascx" tagname="Notif_UploadedImage" tagprefix="uc4" %>
<%@ Register src="Controls/Notif_UploadedVideo.ascx" tagname="Notif_UploadedVideo" tagprefix="uc5" %>
<%@ Reference Control="~/Controls/Notif_UploadedVideo.ascx" %>
<%@ Register src="Controls/ChatPoint.ascx" tagname="ChatPoint" tagprefix="uc6" %>
<%@ Reference Control="~/Controls/ChatPoint.ascx" %>
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

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Blog </title>
 <script type="text/javascript" src="JS/jquery-1.3.2.min.js"></script> 
 <script type="text/javascript" src="JS/jquery.timeago.js" ></script>
 <script type="text/javascript" src="JS/Profile.js" ></script>
 <script type="text/javascript" src="JS/jquery.colorbox-min.js"  ></script>
 <link href="CSS/Global.css" rel="stylesheet" type="text/css" />
 <link href="CSS/Profile_Page.css" rel="stylesheet" type="text/css" />
 <script type="text/javascript" src="JS/phonetic_int.js"></script>
    <script type="text/javascript">
     var IsFavClicked=0;
   
    
     function MakeBanglaEditor()
    {
   var Inputs= document.getElementsByTagName("input");
     
      for(var i=0;i<Inputs.length;i++)
     {
//     	if(Inputs[i].className=="bangla")
//	    {	
		makePhoneticEditor(Inputs[i]);
	
//		}
     }
  
    var textAreas= document.getElementsByTagName("textarea");
     
      for(var i=0;i<textAreas.length;i++)
     {
//     	if(textAreas[i].className=="bangla")
//	    {	
		makePhoneticEditor(textAreas[i]);
	
//		}
     }
    }
     
    </script>
    <script type="text/javascript">
  
            function resizeit(e)
            {
               this.style.height="60px";
            }
            function resizeitToSmall(e)
            {
                if(this.value=="")
                {
                 this.style.height="20px";
                }
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
    
 
<link type="text/css" media="screen" rel="stylesheet" href="colorbox.css" />
<script type="text/javascript" src="JS/jqdialog.min.js" ></script>
<link href="CSS/jqdialog.css" rel="stylesheet" type="text/css" />
    <style runat="server" id="serverStyle" type="text/css">
    
            </style>
</head>
<body onmousemove="TextAreaChange();" >

<form id="form1" runat="server">
      
    <div class="dvMain" >
          <uc1:LoggedInUserMenu ID="LoggedInUserMenu2" runat="server" />
 
         
            <div class="body" >
                     <div class="profile-left" >
                    Blog Category
                           <asp:DropDownList runat="server" ID="ddlCategory"  AutoPostBack=true
                            onselectedindexchanged="ddlCategory_SelectedIndexChanged">
                        <asp:ListItem Text="Fun" ></asp:ListItem>
                        <asp:ListItem Text="Serious"> </asp:ListItem>
                        </asp:DropDownList> 
                        <span style="color:#329993">Latest few of the selected category is being displayed</span>
                       
                        
                     </div>
                     
                          <div class="profile-right">  
                          <a href="BlogSection/CreateBlog.aspx" style=" float:right ">Create blog </a>
                                                         <div id="AllFeed" style="width:600px; display:inline-block;>
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
                    
             </div> 
     </div> 
</form>
</body>
</html>
