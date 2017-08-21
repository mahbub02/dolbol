<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivateAccount.aspx.cs" Inherits="BDDoctors.ActivateAccount" %>
<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>dolbol|Activate Account</title>
    <link href="CSS/Global.css" rel="stylesheet" type="text/css" />
</head>
<body style="display:none">
    <form id="form1" runat="server">
     <div class="dvMain" >
    <div runat="server" id="DvForNotLoggedInUser" class="horizon-menu">
            <ul runat="server" id="ul1"  >
                <li>  <asp:HyperLink runat="server" ID="hlinkSignIn" NavigateUrl="~/Default.aspx" Text="SIGNIN"></asp:HyperLink></li>
                 <li> <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl="~/Signup.aspx" Text="SIGNUP"></asp:HyperLink></li>        
            </ul>
      </div>
      
     <div style="width:30%;  float:left">
        <img src="Images/Site/BlackDrop.jpg"  />
           <span style="font-size:30px; font-weight:bold; color:#007996; position:relative;left:230px; top:-200px">dolbol</span>
        <span style="font-size:13px; font-weight:bold; color:black; position:relative;left:30px; top:-150px ">Today's bindings , future society</span>
     </div> 
     
    <div style="margin:20%">
        <ul>
                <li><asp:Label runat="server" ID="lblInformation" Text="" CssClass="AttributeLabel" ></asp:Label></li>
                <li><asp:Label runat="server" ID="lblEmailAttribute" Text="Email" CssClass="AttributeLabel" ></asp:Label><asp:TextBox runat="server" ID="txtEmail"></asp:TextBox><asp:Label runat="server" ID="lblEmailValidator"></asp:Label></li>
                <li><asp:Label runat="server" ID="lblKey" Text="Key" CssClass="AttributeLabel" ></asp:Label><asp:TextBox runat="server" ID="txtKey" ></asp:TextBox><asp:Label runat="server" ID="lblKeyValidator" ></asp:Label></li>
                <li > <asp:Label runat="server" ID="Label1" Text="" CssClass="AttributeLabel" ></asp:Label>  <asp:Button runat="server" Text="Activate" 
            ID="btnSubmit" onclick="btnSubmit_Click" /></li>
        </ul> 
    </div>
    </div>
    </form>
</body>
</html>
