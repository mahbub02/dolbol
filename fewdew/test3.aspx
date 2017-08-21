<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test3.aspx.cs" Inherits="BDDoctors.test3" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <cc1:CaptchaControl ID="Captcha1" runat="server"

 CaptchaBackgroundNoise="Low" CaptchaLength="5"

 CaptchaHeight="60" CaptchaWidth="200"

 CaptchaLineNoise="None" CaptchaMinTimeout="5"

 CaptchaMaxTimeout="240" FontColor = "#529E00" />
    </div>
    
    <asp:button ID="Button1" runat="server" text="Button" onclick="Button1_Click" /><asp:Label
        ID="lblMessage" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="txtCaptcha" runat="server"></asp:TextBox>
    </form>
</body>
</html>
