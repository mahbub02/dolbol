<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SignIn.ascx.cs" Inherits="BDDoctors.Controls.SignIn" %>

            <ul>
            <li><asp:Label runat="server" ID="lblEmailAttribute" Text="Email" CssClass="AttributeLabel" style="font-size:13px;" ></asp:Label><asp:TextBox runat="server" ID="txtEmail" CssClass="single-text"></asp:TextBox><asp:Label runat="server" ID="lblEmailValidator"></asp:Label></li>
            <li><asp:Label runat="server" ID="Label1" Text="Password" CssClass="AttributeLabel" style="font-size:13px;" ></asp:Label><asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="single-text" ></asp:TextBox><asp:Label runat="server" ID="lblPasswordValidator" ></asp:Label></li>
            <li ><asp:Label runat="server" ID="Label2" Text="" CssClass="AttributeLabel" style="font-size:15px;" ></asp:Label><asp:Button runat="server" Text="Login" 
                    ID="btnSubmit" onclick="btnSubmit_Click" /> </li>
            <li><asp:Label runat="server" ID="Label5" Text="" CssClass="AttributeLabel" style="font-size:15px;" ></asp:Label><asp:Label runat="server" ID="lblCredentialValidator" ForeColor=Red></asp:Label></li>
            <li style="width:500px; display:block"><asp:Label runat="server" ID="Label3" Text="" CssClass="AttributeLabel" ></asp:Label>Do you have any Fewdew account? If not,<a style="color:Black" href=Signup.aspx>create your Account </a></li>
            <li><asp:Label runat="server" ID="Label4" Text="" CssClass="AttributeLabel" ></asp:Label><a style="color:Black" href=ForgottenPassword.aspx>Forgotten your account password? </a></li>
            </ul>
