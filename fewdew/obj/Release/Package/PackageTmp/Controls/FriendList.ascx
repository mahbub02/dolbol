<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FriendList.ascx.cs" Inherits="BDDoctors.Controls.FriendList" %>

           
            <div style="width:200px" >
            <h4>Contact list</h4>
               <asp:DataList runat="server" ID="dlFriendList" Width="200"  
                      RepeatLayout="Flow" ShowHeader=false
                   RepeatDirection="Horizontal">
                   <HeaderTemplate>
                <span style="color:#4FA3B9">    Has no contact yet</span>
                   </HeaderTemplate>
               <ItemTemplate>
               
                 <div class="friend">
                    <ul >
               
                        <li><a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "UserId")%>><img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "Userid")%>_thumb.jpg" /></a></li>
                        <li><a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "UserId")%>>   <%# DataBinder.Eval(Container.DataItem, "DisplayName")%></a></li>
                    </ul>
                   </div>
               
               </ItemTemplate>
               </asp:DataList>
               <asp:LinkButton runat="server" id="lbtnSeeAll" Text="See All" Visible=false></asp:LinkButton>
            </div>
