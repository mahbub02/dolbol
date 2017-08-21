<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ForgottenPasswordEmailBody.ascx.cs" Inherits="BDDoctors.Controls.ForgottenPasswordEmailBody" %>
<div style="text-align:left; font-family:Verdana;font-size:11px">
Dear User,
<br />
You may have forgotten your <a href="http://www.fewdew.com/">www.fewdew.com</a> account password and requested to send your password. Please find your password below<br />
Email: <%=Convert.ToString(User.Email)%> <br />
password:<%=Convert.ToString(User.Password)%>
-> This is an automated system generated email.<br />

Admin,
www.fewdew.com

</div>