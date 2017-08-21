<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile2.aspx.cs" Inherits="BDDoctors.Profile2" %>
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
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Habib:Profile</title>
    <link href="CSS/Profile_Page.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Global.css" rel="stylesheet" type="text/css" />
    <link href="CSS/EduInfo.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="dvMain" >
     <uc4:LoggedInUserMenu ID="LoggedInUserMenu1" runat="server" />
          <div class="top">
           
              <uc12:CreatePersona ID="CreatePersona1" runat="server" />
          
           </div>
                    
           <div class="body">
                    <div class="left">
                   
                    
                    
                         <div class="profile-image">
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                             <ContentTemplate>                             
                                 <ul>
                             <li><asp:LinkButton runat="server" ID="lbtnSendEmail" Text="Send Email" 
                                  Visible="false"    onclick="lbtnSendEmail_Click"></asp:LinkButton></li>
                             <li>
                             
                                <div runat="server" id="divSendEmail" class="transparent" visible="false">
                                    
                                        <asp:ImageButton runat="server" ID="imgBtnClose" CssClass="imgClose" 
                                                ImageUrl="~/Images/Site/close_button.gif" onclick="imgBtnClose_Click" />
                                        <asp:Label runat="server" ID="lblValidationMessage"   ></asp:Label>
                                            <ul runat="server" id="ulControl">
                                                 <li><asp:Label runat="server" ID="lblEmailAttribute" Text="To" CssClass="AttributeLabel2" ></asp:Label><asp:TextBox runat="server" ID="txtTo" Enabled=false></asp:TextBox></li>
                                                 <li><asp:Label runat="server" ID="Label4" Text="Subject" CssClass="AttributeLabel2" ></asp:Label><asp:TextBox runat="server" ID="txtSubject"  ></asp:TextBox></li>
                                                 <li><asp:Label runat="server" ID="Label1" Text="Message" CssClass="AttributeLabel2" ></asp:Label><asp:TextBox runat="server" ID="txtMessage" TextMode="MultiLine" CssClass="message-box"></asp:TextBox></li>
                                                 <li><asp:Label runat="server" ID="Label3" Text="" CssClass="AttributeLabel2" ></asp:Label>
                                                 <asp:Button runat="Server" ID="btnSend" Text="Send" onclick="btnSend_Click"  />
                                                 <asp:Button runat="server" ID="btnCancel" Text="Cancel" onclick="btnCancel_Click" /></li>   
                     
                                            </ul> 
                                   
                                </div>
                                
                                <div id="post-new-blog">
                                      <asp:UpdatePanel ID="updatePanelCreateBlog" runat="server" UpdateMode="Conditional">
                                               <ContentTemplate>
                                                    <div runat="server" id="divCreateNewBlog" class="blog-transparent" visible=false  >
                                                      
                                                        
                                                            <asp:LinkButton runat="server" ID="lbtnClose" Text="X" CssClass="imgClose" onclick="lbtnClose_Click" 
                                                                    />
                                                            <asp:Label runat="server" ID="lblValidationMessageForBlog"   ></asp:Label>
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server"  UpdateMode="Always">
                                                                     <Triggers>
                                                                        <asp:PostBackTrigger ControlID="btnPost" /> 
                                                                    </Triggers>
                                                                  <ContentTemplate>
                                                                <ul runat="server" id="ul1">                                                 
                                                                     <li><asp:Label runat="server" ID="Label5" Text="Title" CssClass="AttributeLabel2" ></asp:Label><asp:TextBox runat="server" ID="txtTitle"  TextMode="MultiLine" Width="700"  Height="30"  ></asp:TextBox></li>
                                                                     <li><asp:Label runat="server" ID="Label6" Text="Description" CssClass="AttributeLabel2" ></asp:Label>
                                                                         
                                                                         <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" CssClass="message-box" Width="700" Height="200"></asp:TextBox></li>
                                                                     <li><asp:Label runat="server" ID="Label7" Text="Category" CssClass="AttributeLabel2" ></asp:Label><div class="category"><asp:CheckBoxList runat="server" ID="ChklistCategory"  RepeatDirection="Vertical" ></asp:CheckBoxList></div> </li>
                                                                    
                                                                     <li><asp:FileUpload ID="FileUpoadBlogImage" runat="server"   />Browse file to post photo with this blog post</li> 
                                                                     <li><asp:Label runat="server" ID="lblPhotoInformation" Text="" CssClass="AttributeLabel2" ></asp:Label>
                                                                     <asp:Button runat="Server" ID="btnPost" Text="Post" onclick="btnPost_Click"    />
                                                                     <asp:Button runat="server" ID="btnClose" Text="Cancel" onclick="btnClose_Click" 
                                                                               /></li> 
                                                                     
                                                                </ul> 
                                                                </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                             
                                                       
                                                    </div>
                                                 </ContentTemplate>
                                        </asp:UpdatePanel>                                          
                                </div>
                                
                             </li>
                             <li><uc6:ProfilePhoto ID="ProfilePhoto1" runat="server" /></li>
                            
                         </ul>
                          </ContentTemplate>
                             </asp:UpdatePanel>
                        </div>
                        
                        <div class="user-right-menu" >
                            <ul>
                                <li><asp:LinkButton runat="server" ID="lbtnUserInformation" Text="INFORMATION" onclick="lbtnUserInformation_Click" 
                                        ></asp:LinkButton></li>                            
                                <li><asp:LinkButton runat="server" ID="lbtnUserBlog" Text="BLOG" 
                                        onclick="lbtnUserBlog_Click"></asp:LinkButton></li>
                                <li> <asp:LinkButton runat="server" ID="lbtnUploadedVideo" Text="UPLOADED VIDEO" 
                                        onclick="lbtnUploadedVideo_Click"></asp:LinkButton></li>
                                 <li><asp:LinkButton runat="server" ID="lbtnUploadedImage" Text="UPLOADED IMAGE" 
                                         onclick="lbtnUploadedImage_Click"></asp:LinkButton></li>
                            </ul>
                            
                        </div>
                        

                    </div>
                    
                    <div class="middle">                    
                          <asp:UpdatePanel runat="server" ID="updatePanelMiddle" UpdateMode="Always">
                         <ContentTemplate>
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
                        <div runat="server" id="divUserBlogList"> 
                         <asp:Label runat="server" ID="lblSuccessfullyBlogPostMessage"   ></asp:Label>
                            <asp:LinkButton runat="server" ID="lbtnPostNewBlog" CssClass="post-new" 
                                Text="Post New Blog" onclick="lbtnPostNewBlog_Click"></asp:LinkButton> 
                            <h2 class="heading" > Blog List</h2>                                                  
                            <uc9:BlogList ID="BlogList1"  runat="server"    />
                            
                        </div>
                        <div runat="server" id="divUploadedVideo"> 
                            <uc11:UploadedVideo ID="UploadedVideo1" runat="server" />
                        </div>
                        <div runat="server" id="DivUploadedImage">
                             <uc10:UploadedPhoto ID="UploadedPhoto1" runat="server" BindInfo="false" />
                        </div>
                        
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
                    <div class="right">
                    <h2 class="heading" > Connections</h2>                      
                        
                        <div style="height:300px;>
                         <uc7:FriendList ID="FriendList1" runat="server" />
                        </div>
                        
                        <div style="float:left">
                         
                        </div>   
                    </div>
            </div>    
        
           
            
           
    </div>
    </form>
</body>
</html>
