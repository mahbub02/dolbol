<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FriendShipRequest.ascx.cs" Inherits="BDDoctors.Controls.FriendShipRequest" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <div style="float:left">
        <a style="float:left" href="../../Profile.aspx?user=<%=Friend.UserId %>"><img  id="ImageUser" src="../../Images/profile/<%=Friend.UserId%>_thumb.jpg"  /></a>
        
            <a style="float:left" href="../../Profile.aspx?user=<%=Friend.UserId %>"> <%=Friend.DisplayName%> </a> 
        <div runat="server" id="dvrequestDetails" >
        Has requested to be his friend.What would you like to do?
            <br />
            <asp:LinkButton runat="server" ID="lbtnAccept" Text="Accept" 
                    onclick="lbtnAccept_Click"></asp:LinkButton>
            <asp:LinkButton runat="server" ID="lbtnReject" Text="Reject" 
                onclick="lbtnReject_Click"></asp:LinkButton>
        </div> 
    
     </div>
</ContentTemplate>
</asp:UpdatePanel>

