<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendFriendRequest.aspx.cs" Inherits="BDDoctors.SendFriendRequest" %>
<%@ Import Namespace=BDDoctors %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title>SendFriendRequest</title>
    <style type="text/css">
    .button{border:1px solid #CCC;background-color:#9AD8E8;}
    .button:hover{ border-color:#007996;}

    
    img{ border:1px solid #9AD8E8; padding:3px}
    a{ color:#4FA3B9; font-weight:bold;text-decoration:none;}
  
div#friend-request div{ float:left}
div#user_details{ width:220px;   float:left}
div#request{ width:260px; float:left; color:#0086E2}
    </style>
</head>
<body >
    <form id="form1" runat="server">
                                    <div id="friend-request">
                                    <% System.Data.DataRow dr = GetFriendRequestRow();  %>
                                    <% BDDoctors.DAL.DataObject.User usr = BDDoctors.DAL.DataAccess.User.GetUser(Convert.ToInt64(Request["user_id"])); %>
                                 
                                    <div id="user_details">
                                        <a  target=_top href=Profile.aspx?user=<%=usr.Id.ToString()%>><img src="Images/profile/<%=usr.Id.ToString()%>_profile.jpg" /></a>
                                        <a target=_top href=Profile.aspx?user=<%=usr.Id.ToString()%>> <%=usr.DisplayName%></a>
                                    </div>
                                    <div id="request">
                                    <% if (dr == null) %>
                                        <%{ %>
                                            <span>Do you want to request <%=usr.DisplayName%> to be your contact?</span>
                                            <asp:Button runat="server"  CssClass="button" ID="btnAddAsConnection" Text="Yes" onclick="btnAddAsConnection_Click" />
                                        <%} %>
                                    <%else %>
                                        <%{ %>
                                            <% if (Convert.ToInt64(dr["user1"]) ==BDDoctors.LoginHandler.LoggedInUser().Id.Value) %>
                                                <%{ %>
                                                    <span>Your request has already been sent to  &nbsp <%=usr.DisplayName%>.  <%=usr.DisplayName%> &nbsp has to confirm you as friend </span>
                                                <%} %>
                                             <%else %>
                                                <%{ %>
                                                    <span>You are already requested to be <%=usr.DisplayName%>'s  contact. <a href=Request.aspx> Click here </a> to accept <%=usr.DisplayName%>'s request</span>
                                                <%} %>
                                        <%} %>
                                        </div>
                                    </div>
   
                                   
                                
   
    </form>
</body>
</html>
