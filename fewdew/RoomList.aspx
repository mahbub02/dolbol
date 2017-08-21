<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomList.aspx.cs" Inherits="BDDoctors.RoomList" %>

<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>World List</title>
    <link href="CSS/Global.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-image:url(Images/Site/night.png); background-repeat:repeat; height:800px">
    <form id="form1" runat="server">
    <uc1:LoggedInUserMenu ID="LoggedInUserMenu1" runat="server" />
    <div style="width:100%; text-align:center;"  >
    <a href="ChatRoom.aspx?room_id=1"><img width="400px" src="Images/AvatarChat/Background/circle/1.jpg" /> </a>
    <a href="ChatRoom.aspx?room_id=2"><img width="400px" src="Images/AvatarChat/Background/circle/2.jpg" /> </a>
    
    
    </div>
    <div style="width:100%; text-align:center; height:800px"  >
    <a href="ChatRoom.aspx?room_id=3"><img width="400px" src="Images/AvatarChat/Background/circle/3.jpg" /> </a>
    </div>
    
    </form>
</body>
</html>
