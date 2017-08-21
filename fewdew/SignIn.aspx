<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="BDDoctors.SignIn" %>

<%@ Register src="Controls/Signup.ascx" tagname="Signup" tagprefix="uc1" %>
<%@ Register src="Controls/SignIn.ascx" tagname="SignIn" tagprefix="uc2" %>

<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HABIB:SIGNIN</title>
     <link href="CSS/Global.css" type="text/css" rel=Stylesheet />

    <link href="CSS/Signin_page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="dvMain" >
     <uc3:LoggedInUserMenu ID="LoggedInUserMenu2" runat="server" />
          <div class="top">
          
           </div>
                    
           <div class="body">
                <div class="signin-left">
                <img src="Images/Site/cartoon.gif" alt="" />
                        <h2>Habib</h2><h7>I am professional</h7>
                </div>
                  <div class="signin-right">
                        <div class="singing-signin" >
                            <uc2:SignIn  ID="SignIn1" runat="server" />
                        </div>
                         <div class="signing-signup">
                            <uc1:Signup ID="Signup1" runat="server" />
                         </div>   
                  </div>
           </div>    
            <div class="signin-footer" >sfsfs</div>
           
            
           
    </div>
           
       
    </form>
</body>
</html>
