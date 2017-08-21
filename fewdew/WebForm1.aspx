<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BDDoctors.WebForm1" %>

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
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>FewDew|My Yard</title>
<link href="CSS/Global.css" rel="stylesheet" type="text/css" />
<link href="CSS/Home.css" rel="stylesheet" type="text/css" />
 <script type="text/javascript" src="JS/phonetic_int.js"></script>
    <script type="text/javascript">
        _uacct = "UA-1154128-1";
        urchinTracker();
</script>
  <script type="text/javascript"  src="JS/mytab.js"></script>
  <script type="text/javascript" src="JS/jquery-1.3.2.min.js"></script> 


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
 function ShowActualSize(imgCntrl)
      {
          if(imgCntrl.src.search("_mini.jpg")>0)
          {
          imgCntrl.src=imgCntrl.src.replace("_mini.jpg","")+"_display.jpg";
//          imgCntrl.style.position="absolute";
          
          }
          else if(imgCntrl.src.search("_display.jpg")>0)
          {
           imgCntrl.src=imgCntrl.src.replace("_display.jpg","")+"_mini.jpg";
//           imgCntrl.style.position="relative";
          }
     }
     
      function ShowActualSizeOfProfile(imgCntrl)
      {
          if(imgCntrl.src.search("_profile.jpg")>0)
          {
          imgCntrl.src=imgCntrl.src.replace("_profile.jpg","")+"_display.jpg";
//          imgCntrl.style.position="absolute";
          
          }
          else if(imgCntrl.src.search("_display.jpg")>0)
          {
           imgCntrl.src=imgCntrl.src.replace("_display.jpg","")+"_profile.jpg";
//           imgCntrl.style.position="relative";
          }
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
                 if(txtBox.value.length==300)
                     {
                      alert("Maximum text length 300");
       
                     } 
        }
        
        
        function TextAreaChange()
        {
       // ScrollDivLeftAndBottom();
          var areas =document.getElementsByTagName("textarea");
          for(var i=0;i<areas.length;i++)
          {
             
           areas[i].onclick=resizeit;
           areas[i].onmouseout=resizeitToSmall;
          }
        }
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
    
    
//    function ScrollDivLeftAndBottom()
//        {

////          var divs= document.getElementsByTagName("div");
////             for(var i=0;i<divs.length;i++)
////             {
////              divs[i].scrollTop=divs[i].scrollHeight;
////              divs[i].scrollRight=divs[i].scrollWidth;
////             }
//              

//        }
        
//         function ScrollDivLeftAndBottom()
//        {

//            var textAreas= document.getElementsByTagName("div");
//     
//              for(var i=0;i<textAreas.length;i++)
//             {
//             textAreas[i].scrollTop=textAreas[i].scrollHeight;
//              textAreas[i].scrollLeft=textAreas[i].scrollWidth;
//       
//             }
//           
//         
//        }
    
    
</script>
        <link href="CSS/mytab.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" src="JS/home.js" ></script> 
    <script type="text/javascript">
   
function GetCurrentTime()
{
    $.ajax({
    
      type: "POST",
      url: "webform1.aspx/GetDate",
       data: "{comment:" + "13" + ","+"height:"+"100" +"}",
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function(msg) {
        // Replace the div's content with the page method's return.
        alert(msg.d);
      },
      error: AjaxFailed
    });
    
}
  
function AjaxFailed(result) {
            alert(result.status + ' ' + result.statusText);
         }      </script>

</head>
<body onload="MakeBanglaEditor();" onmousemove="TextAreaChange();MakeBanglaEditor();" >
 <div id="Result" onclick="GetCurrentTime();">Click here for the time.</div>
  <form id="form1" runat="server">
                              <div class="dvMain" >
                                      
        <uc1:LoggedInUserMenu ID="LoggedInUserMenu2" runat="server" />
     
                                     <div id="Div1" onclick="GetCurrentTime();">Click here for the time.</div>
                    
                                     <div class="body" style="margin-bottom:100px">
                                            
                                             <div  style="float:left; display:none " class="user-right-menu" >
                                           
                                           
                                                        <ul >
                                                            <li><asp:LinkButton runat="server" Height="30"   ID="lbtnPublicNotification" Text="Public Feed" onclick="lbtnPublicNotification_Click"  
                                                                    ></asp:LinkButton></li>                            
                                                            <li><asp:LinkButton runat="server" Height="30"  ID="lbtnFriendNotification" Text="Contact's Feed" onclick="lbtnFriendNotification_Click" 
                                                                    ></asp:LinkButton></li>
                                                        </ul>
                                                
                                            </div>
                                            
                                           
                                                
                                                 <div class="home-left" >
                                                     
                                                     
                                                
                                                    
                                                               
                                                                
                                                                    <div class="yahoo-tab">
                                                                      <ul class="ulitem" >
                                                                        <li><a href=#  id="status" class="yaselected"   onclick="changeTab(this);" >Status</a></li>
                                                                        <li><a href=#  id="video"  class="yadeselected" onclick="changeTab(this);" >Video</a></li>
                                                                        <li><a href=#  id="image"  class="yadeselected" onclick="changeTab(this);" >Image</a></li>
                                                                        <li><a href=#  id="Album" class="yadeselected" onclick="changeTab(this);" >Album</a></li>
                                                                        <li><a href=#  id="blog"  class="yadeselected" onclick="changeTab(this);" >Blog</a></li>
                                                                        <li><a href=#  id="prescription"  class="yadeselected" onclick="changeTab(this);" >P-Point</a></li>
                                                                      </ul>
                                                                          <div id="tab-panel">
                                                                                <div id="divstatus" class="yaselected" style="height:45px">
                                                                                <asp:TextBox runat="server" ID="txtEnterStatus" style="margin:6px" Height=30 Width=300></asp:TextBox>
                                                                                    <asp:Button runat="server" ID="btnStatusPost" style="height:30px;margin:6px " 
                                                                                        Text="POST" onclick="btnStatusPost_Click" />
                                                                                </div>
                                                                                <div id="divvideo" class="yadeselected" style="height:100px; " >
                                                                                <ul>
                                                                                    <li><asp:Label runat="server" ID="lblUploadMessage" ForeColor=Red></asp:Label></li>
                                                                                    <li><span style="font-size:10px; width:100px; display:inline-block">Enter Video Title</span><asp:TextBox runat="server" MaxLength="30" ID="txtVideoTitle"></asp:TextBox> </li>
                                                                                    
                                                                                    <li><span style="font-size:10px; width:95px; display:inline-block"></span>  <asp:FileUpload runat="server" ID="FileUploadVideo" /> </li>
                                                                                    
                                                                                    <li><span style="font-size:10px;width:200px; margin-left:100px;  display:inline-block"> Select an video file on your computer</span> </li>
                                                                                    <li><span style="font-size:10px; width:95px; display:inline-block"></span>
                                                                                        <asp:Button runat="server" ID="btnUploadVideo" style="height:30px;margin:6px " 
                                                                                            Text="POST" onclick="btnUploadVideo_Click" /></li>
                                                                                </ul>
                                                                                        
                                                                                    
                                                                           
                                                                                </div>
                                                                                <div id="divimage" class="yadeselected" style="height:50px">
                                                                                    <ul>
                                                                                      <li><span style="font-size:10px"> Select an image file on your computer</span> </li>
                                                                                      <li><asp:FileUpload runat="server" ID="fileuploadImage" style="margin:5px" /> 
                                                                                          <asp:Button runat="server" ID="btnImageUpload" style="height:30px;margin:6px " 
                                                                                              Text="POST" onclick="btnImageUpload_Click" /></li>
                                                                                    </ul>
                                                                                    
                                                                                    
                                                                                </div>
                                                                                 <div id="divAlbum" class="yadeselected">
                                                                                   <span>Enter Album Name:</span>  <asp:TextBox runat="server" ID="txtAlbumName"  style="margin:6px" Height=20 Width=150></asp:TextBox><br />
                                                                                     <asp:Button runat="server" ID="btnPostAlbum" style="height:30px;margin:6px " 
                                                                                         Text="POST" onclick="btnPostAlbum_Click" />
                                                                                </div>
                                                                                <div id="divblog" class="yadeselected" style="height:50px" >
                                                                                    <a href="BlogSection/CreateBlog.aspx" style="float:right; font-size:13px; color:Black; font-weight:bold">Create blog </a>
                                                                                </div>
                                                                                <div id="divprescription" class="yadeselected" style="height:50px" >
                                                                                    <a href=MediPanel.aspx style="float:right; font-size:13px; color:Black; font-weight:bold">Seek Prescription</a>
                                                                                </div>
                                                                                
                                                                               
                                                                          </div>
                                                                      </div>
                                                                
                                                              
                                                    
                                                            <asp:GridView ID="GridContentBasedNotification" runat="server" 
                                                            AutoGenerateColumns="false"  ShowHeader=false ShowFooter=false
                                                            onrowdatabound="GridContentBasedNotification_RowDataBound" 
                                                           onrowediting="GridContentBasedNotification_RowEditing" 
                                                           onrowupdating="GridContentBasedNotification_RowUpdating" Width=500 >
                                                                    <Columns>                            
                                                                    <asp:TemplateField>
                                                                    <ItemStyle    />
                                                                        <ItemTemplate>
                                                                       
                                                                       
                                                                             <div style="float:left; width:100%;text-align:right">
                                                                              
                                                                               <asp:LinkButton runat="server" ID="lbtnDelete" CssClass="comment-delete" Text="Delete" CommandName=update ></asp:LinkButton>|
                                                                                <asp:LinkButton runat="server" ID="lbtnFavourite" CssClass="command"  Text="Add To My Favourite" CommandName="edit" ></asp:LinkButton>
                                                                             </div> 
                                                                             <div style="float:left; width:100%" >
                                                                                    <uc4:Notif_UploadedImage ID="Notif_UploadedImage1" runat="server" Visible="false"  />
                                                                                    <uc5:Notif_UploadedVideo ID="Notif_UploadedVideo1" runat="server" Visible="false" />
                                                                                    <uc7:Notif_UserStatus ID="Notif_UserStatus1" runat="server" Visible="false" />
                                                                                    <uc8:Notif_Blog ID="Notif_Blog1" runat="server" Visible="false" />
                                                                                    <uc9:NotifTreatPanel ID="NotifTreatPanel1" runat="server" Visible="false" />
                                                                                    <uc10:NotifPoll ID="NotifPoll1" runat="server" visible="false" />
                                                                                    <uc11:Noti_WorldLocation_Changed ID="Noti_WorldLocation_Changed1"  Visible="false"  runat="server" />
                                                                                    <uc12:NotifSingleImage ID="NotifSingleImage1" runat="server" />
                                                                                 <div style="float:left; width:100%">
                                                                                 
                                                                                  <uc3:Comment ID="Comment1" runat="server"   />
                                                                                 </div> 
                                                                              </div> 
                                                                              <div style="border-top:1px solid #CCC; float:left;  margin-bottom:30px;margin-top:10px; width:100%">
                                                                              
                                                                              </div>
                                                                              
                                                                         
                                                                            
                                                                        </ItemTemplate>                                
                                                                    </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                      There is no feed to show.
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            
                                                 </div>         
                                           
                                            
                                            
                                            <div style="float:left;" class="home-right">
                                         
                                                     <asp:GridView ID="GridPublicInfoNotification" runat="server" CssClass="YourGridView" 
                                                          AutoGenerateColumns="false"  Width="300"     
                                                            ShowHeader="false" AllowPaging=true PagerSettings-Mode=NumericFirstLast PageSize=10
                                                        ShowFooter=false onpageindexchanging="GridPublicInfoNotification_PageIndexChanging" 
                                                           PagerStyle-CssClass="PageStyle"  PagerSettings-Position=TopAndBottom 
                                                            PagerStyle-HorizontalAlign=Left  style="float:left"   PagerStyle-Font-Bold=true 
                                                              >
                                                           
                                                        <Columns>
                                                        
                                                            <asp:TemplateField>
                                                            
                                                              <ItemStyle    />
                                                                <ItemTemplate>
                                                                <div style="float:left;">
                                                                    <div style="float:left;width:40px;  ">
                                                                        <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>><img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "User_id")%>_mini.jpg" class="mini" /></a>
                                                                    </div>
                                                                    
                                                                    <div style="float:left;width:240px;margin-left:15px  ">
                                                                      <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>>   <%#DataBinder.Eval(Container.DataItem, "User_Name")%></a>
                                                                                 <%# DataBinder.Eval(Container.DataItem, "Attribute_Name")%>                                                                           
                                                                             <b> <%# DataBinder.Eval(Container.DataItem, "Node_value")%> </b>
                                                                    </div>
                                                                 </div>       
                                                                        
                                                                          
                                                                </ItemTemplate>                                
                                                            </asp:TemplateField>
                                                             
                                                            
                                                            
                                                                
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            
                                                        </EmptyDataTemplate>
                                
                                                        </asp:GridView>
                                                                             
                                            </div>
                                            
                                            
                          
                                           
       
                    
                                       </div> 
            
           
                             </div>
</form>                             
</body>
</html>

