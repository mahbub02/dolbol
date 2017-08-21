﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IframeProfilePhotoChange.aspx.cs" Inherits="BDDoctors.IframeProfilePhotoChange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Change profile photo</title>
    <script type="text/javascript">
        window.onunload=function() {parent.RefreshAvatarDetailsImage();}
    </script>
</head>
<body style="width:300px; height:300px; margin:0 auto; text-align:center; " >
    <form id="form1" runat="server">
    <div style="margin:0 auto;">
     <% Random rnd = new Random();%>
        
        <div  style="display:inline-block;  width:200px; height:200px;  background-repeat:no-repeat; background-image:url(Images/profile/<%=BDDoctors.LoginHandler.LoggedInUser().Id.ToString()%>_profile.jpg?rnd=<%=rnd.Next(1,20000).ToString()%>)">
        </div>
        <div>
          
          
        <p style="font-size:10px;">To change you profile photo. You just need to upload new photo from your local source</p>
        <asp:Label runat="server" ID="lblPhotoInformation" ForeColor=Red></asp:Label>
        <br />
            <asp:FileUpload ID="FileProfileUpload" runat="server" style="background-color:white; " />
            <asp:Button runat="server" ID="btnUploadPhoto" Text="Upload" 
                    style="background-color:#859A16; border:1px solid black; color:White; font-weight:bold; cursor:pointer; height: 24px;" 
                    onclick="btnUploadPhoto_Click" />
        </div>
    </div>
    
    </form>
</body>
</html>
