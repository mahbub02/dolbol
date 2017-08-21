<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComposeEmail.ascx.cs" Inherits="BDDoctors.Controls.ComposeEmail" %>
<div class="email-compose" runat="server">

    <asp:Label runat="server" ID="lblErrorMessage" Text="Subject" ></asp:Label>
    <ul runat="server" id="ulCompose">
    <li></li>
    <li><asp:Label runat="server" ID="lblEmailAttribute" Text="To" CssClass="AttributeLabel" ></asp:Label><asp:TextBox runat="server" ID="txtTo"></asp:TextBox></li>
    <li><asp:Label runat="server" ID="Label4" Text="Subject" CssClass="AttributeLabel" ></asp:Label><asp:TextBox runat="server" ID="txtSubject"  ></asp:TextBox></li>
    <li><asp:Label runat="server" ID="Label1" Text="Message" CssClass="AttributeLabel" ></asp:Label><asp:TextBox runat="server" ID="txtMessage" TextMode="MultiLine" CssClass="message-box"></asp:TextBox></li>
     <li><asp:Label runat="server" ID="Label3" Text="" CssClass="AttributeLabel" ></asp:Label>
         <asp:Button runat="Server" ID="btnSend" Text="Send" onclick="btnSend_Click" />
         <asp:Button runat="server" ID="btnCancel" Text="Cancel" 
             onclick="btnCancel_Click" /></li>   
    </ul>

</div>