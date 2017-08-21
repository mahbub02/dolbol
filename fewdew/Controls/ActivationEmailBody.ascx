<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActivationEmailBody.ascx.cs" Inherits="BDDoctors.Controls.ActivationEmailBody" %>
<div style="text-align:left; font-family:Tahoma;font-size:11px; background-color:#F3F7D6; font-size:12px; color:#4B540F">
    Dear User,
<div style="margin-left:30px">
<br />
    You have created a free account at www.DolBol.gamecookstudio.com, and now you need to activate your account.
<br />
To activate your account at&nbsp; www.DolBol.gamecookstudio.com,please follow the URL: <br />    
 
 <a href="http://www.DolBol.gamecookstudio.com/ActivateAccount.aspx?Email=<%=Convert.ToString(User.Email)%>&key=<%=Convert.ToString(User.ActivationKey)%>"  >Click here to activate your account</a> 
            <br />
       <%-- If the above link doesn&#39;t work then please visit this URL:www.DolBol.com/ActivateAccount.aspx  
        <br />
        and enter the following 
        email address&nbsp; and Activation Code:<br />
       <b> Email: <%=Convert.ToString(User.Email)%></b> <br />
       <b>Activation Code: <%=Convert.ToString(User.ActivationKey)%></b><br />
         Password:<%=Convert.ToString(User.Password)%>--%>
         
  <br />
  <pre>
    <p style="font-weight:bold">
        What is DolBol?
    </p>
   DolBol is a virtual world and it runs directly in the web browser with nothing to install. DolBol is a milestone in the virtual 3d community for its faster loading capability. Newcomer can select avatar for free and ready to explore the worlds, meet other members, making friendship and chat with comfy features of thousand of emoticons, share his thought in wall, share photo and a lots.Members see the world and others avatar in an isometric perspective and click interface. DolBol goes far beyond other browser based worlds for its server based real time rendering that normally 3d world offer. A beta version is now online. “The really interesting stuff is still in development”, says CEO M.H.Rahman.
    
  </pre>
  </div>
  With Regards,<br />
  DolBol support team
       
</div>

