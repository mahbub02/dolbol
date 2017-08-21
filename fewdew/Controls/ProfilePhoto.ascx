<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfilePhoto.ascx.cs" Inherits="BDDoctors.Controls.ProfilePhoto" %>


        <ul>
            <%--<li><asp:LinkButton runat="server" ID="lbtnAddAsConnection" 
                    Text="Create Connection" Visible="false" onclick="lbtnAddAsConnection_Click" ></asp:LinkButton>
                
            </li>--%>
                        
            <li><img runat="server" id="imgProfile"  class="profile-image" onerror="this.onerror=null; this.src='~/Images/profile/Default'" /></li>
            <li><asp:FileUpload ID="FileProfileUpload" runat="server" Height="20" Width="20" CssClass="fileUpload"   /></li>
            <li><asp:Button runat="server" ID="btnPhotoUpload" Text="Upload" 
                    onclick="btnPhotoUpload_Click" /></li>
            <li><asp:Label runat="server" ID="lblPhotoInformation" CssClass="message"></asp:Label></li>
        </ul>
