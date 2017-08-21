<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FriendshipRequest.aspx.cs" Inherits="BDDoctors.Pages.FriendshipRequest" %>

<%@ Register src="../Controls/FriendShipRequest.ascx" tagname="FriendShipRequest" tagprefix="uc1" %>
<%@ Reference Control="~/Controls/FriendShipRequest.ascx" %>
<%@ Register src="../Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../CSS/Global.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/Home.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode=Release>
    </asp:ScriptManager>
    
    <uc2:LoggedInUserMenu ID="LoggedInUserMenu1" runat="server" />
    
    <div runat="server" id="dvRequestContainer" style="float:left;">
    
    </div>
    </form>
</body>
</html>
