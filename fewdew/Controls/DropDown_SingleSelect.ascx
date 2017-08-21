<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DropDown_SingleSelect.ascx.cs" Inherits="BDDoctors.Controls.DropDown_SingleSelect" %>

<div>
<asp:Label ID="lblPropertyName" CssClass="lblPropertyName" runat="server" Text="Label"></asp:Label>
<asp:Label ID="lblPropertyValue" CssClass="lblPropertyValue" runat="server" ></asp:Label>
<asp:DropDownList ID="DropDownList1" runat="server" Visible="false"  
        AutoPostBack="true" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
       >
</asp:DropDownList>
<asp:Label ID="lblValidator" runat="server"></asp:Label>    
</div>
