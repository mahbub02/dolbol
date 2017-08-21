<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClickedOnAddConnectionButton.ascx.cs" Inherits="BDDoctors.Controls.ClickedOnAddConnectionButton" %>
<%@ Import  Namespace=BDDoctors %>
<%@ Import  Namespace=BDDoctors.Controls %>

<div  class="blackblock" style="width:300px; vertical-align:top;  float:left;">

    <div style="float:left;">
        <ul >
        <li><a href=Profile.aspx?user=<%=User2Id%>><img src="Images/profile/<%=User2Id%>_thumb.jpg" /></a></li>
        <li><a href=Profile.aspx?user=<%=User2Id%>>   <%=User2Name%></a></li>
        </ul>
    </div>
    <div style="">
     Do you want to request this person to be your contact?a
     <asp:Button runat="server"  ID="btnAddAsConnection" Text="Yes" onclick="btnAddAsConnection_Click" />
    <asp:Button runat="server" ID="btnCancel" Text="No" onclick="btnCancel_Click" />
    </div>
</div>