<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Status.ascx.cs" Inherits="BDDoctors.Controls.FeedRelated.Status" %>


    <div style="float:left">
 <a style="float:left" href="../../Profile.aspx?user=<%=Node.User_id %>"><img  id="ImageUser" src="../../Images/profile/<%=Node.User_id%>_thumb.jpg"  /></a>
    <%=Node.User_id %>
    </div>
    <%=Node.Node_value %>



