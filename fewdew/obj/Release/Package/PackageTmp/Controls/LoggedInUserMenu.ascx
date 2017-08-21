<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoggedInUserMenu.ascx.cs" Inherits="BDDoctors.Controls.LoggedInUserMenu" %>
<div class="horizon-menu" runat="server" id="DvForLoggedInUser" visible=false >
<ul >
<li style="color:White"><asp:Label runat="server" ID="lbluserName"></asp:Label></li>
<li><a href="../Home2.aspx" class="home" >  <img src="../Images/Site/home.gif" /><span > Home</span></a></li>
<li><a href="../profile.aspx" class="profile"><img src="../Images/Site/profile.gif" /><span >Profile</span></a>  </li>
<li><a  href="../Email.aspx" class="email" ><img src="../Images/Site/Email.gif" /><span runat="server" id="spnEmail" >Email</span></a></li>
<li><a href="../blog.aspx" class="blog"><img src="../Images/Site/Blog.gif" /><span >Blog</span></a></li>
<li><a href="../world.aspx" class="world"><img src="../Images/Site/world.gif" /><span >World</span></a>  </li>
<li><a href="../TreatmentPanel.aspx" class="p-point" ><img src="../Images/Site/p-point.gif" /><span >P-Point</span></a>  </li>
<li><a href="../Request.aspx" class="request" ><img src="../Images/Site/Friendship.gif" /><span runat="server" id="spnRequest" >Request</span></a>  </li>
<li><a href="../finduser.aspx" class="findcontact" ><img src="../Images/Site/findContact.gif" /><span >Find Contact</span></a>  </li>
<li><a href="../club.aspx?room_id=1" class="findcontact" ><img src="../Images/Site/calloutsf2.gif" /><span >Chat Club</span></a>  </li>

<li><asp:LinkButton runat="server" style="float:right"  ID="lbtnSignOut" Text="Signout" 
        onclick="lbtnSignOut_Click"><span style="width:40px; height:40px; display:inline-block"></span>  <span >Signout</span></asp:LinkButton></li>

</ul>

</div>
 <div runat="server" id="DvForNotLoggedInUser" class="horizon-menu">
    <ul runat="server" id="ul1"  >
        <li><a href="../blog.aspx" class="blog"><img src="../Images/Site/Blog.gif" /><span >Blog</span></a></li>
        <li><a href="../TreatmentPanel.aspx" class="p-point" ><img src="../Images/Site/p-point.gif" /><span >P-Point</span></a> </li>
        <li><a href="../Default.aspx" class="p-point" ><img src="../Images/Site/p-point.giff" /><span >Signin</span></a> </li>
        <li><a href="../signup.aspx" class="p-point" ><img src="../Images/Site/p-point.gigff" /><span >Signup</span></a> </li>
        
  <%--    <li>  <asp:HyperLink runat="server" ID="hlinkSignIn" NavigateUrl="~/Default.aspx" Text="Signin"></asp:HyperLink></li>
       <li> <asp:HyperLink runat="server"  ID="HyperLink1" NavigateUrl="~/Signup.aspx" Text="SIGNUP"></asp:HyperLink></li>--%>
        
    </ul>
</div>