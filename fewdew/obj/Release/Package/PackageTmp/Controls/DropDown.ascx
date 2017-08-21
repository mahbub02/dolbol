<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DropDown.ascx.cs" Inherits="BDDoctors.Controls.DropDown" %>
                   
                    <asp:Label runat="server" ID="lblAttribute" CssClass="AttributeLabel"  Text="City"></asp:Label>
                    <asp:Label runat="server" ID="lblValue" Visible="false"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddl" RepeatLayout="Flow">                     
                    </asp:DropDownList>