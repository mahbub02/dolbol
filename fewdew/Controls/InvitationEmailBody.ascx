<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InvitationEmailBody.ascx.cs" Inherits="BDDoctors.Controls.InvitationEmailBody" %>
<div style="text-align:left; font-family:Tahoma;font-size:11px; background-color:#F3F7D6; font-size:12px; color:#4B540F">
 
    <b>DolBol</b>
<br />
Check out my DolBol profile
<br />
<div style="width:500px; display:inline-block">
I set up a an account at DolBol.com which is a 3d  virtual world and where my avatar can walk into the virtual world,teleport to other world, chat with others, post message into my and others wall, make friendship. I want to get you as a friend so you can see it. First, you need to join DolBol! Once you join, you can also create your own profile.
</div>
<br />
<br />
<br />





<%=this.Message%>

<br />
<br />
<br />

Thanks,
<br />

<%=BDDoctors.LoginHandler.LoggedInUser().DisplayName%><br />
<%=BDDoctors.LoginHandler.LoggedInUser().Email%>

<br />
To sign up for DolBol, follow the link below:
<br />

<a href="www.DolBol.com/Registration.aspx?invitedby=<%=BDDoctors.LoginHandler.LoggedInUser().Id.ToString() %>" >Sign up at DolBol </a>

 

   
</div>

