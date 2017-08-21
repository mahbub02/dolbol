<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Feed.ascx.cs" Inherits="BDDoctors.Controls.Feed" %>

<asp:Label runat="server" ID="lblSetStatusAttribute" CssClass="lblStatus" Text="Enter Your Status"></asp:Label>
<asp:TextBox runat="server" ID="txtStatus" CssClass="txtStatus"  ></asp:TextBox>
<asp:Button runat="server" ID="btnPost" Text="Post"  
    CssClass="btnStatusPost" onclick="btnPost_Click"  />
