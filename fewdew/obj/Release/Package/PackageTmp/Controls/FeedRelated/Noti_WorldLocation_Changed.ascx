<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Noti_WorldLocation_Changed.ascx.cs" Inherits="BDDoctors.Controls.FeedRelated.Noti_WorldLocation_Changed" %>
 <asp:DataList ID="GridHeader"  runat="server" 
         AutoGenerateColumns="false" RepeatDirection=Horizontal RepeatLayout=Flow  style="float:left"  ShowHeader="false"
        >
       
            <ItemTemplate>
               <div style="width:60px; float:left; ">
                <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>>            
                <img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "User_id")%>_thumb.jpg" class="thumb" />
                </a>
                
                 </div>     
                 
                  <div style="width:400px; float:left; ">
                 <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>> 
                <%# DataBinder.Eval(Container.DataItem, "User_Name")%>
                </a> has changed his <a href="../../World.aspx"> surroundings</a>
                 at  <span style="color:#CCC">  <%# DataBinder.Eval(Container.DataItem, "Action_Date")%></span>
                 <br />
                <a href="../../ChatRoom.aspx?room_id=<%# DataBinder.Eval(Container.DataItem, "User_Id")%>">
                <img src="../../Images/AvatarChat/Background/<%# DataBinder.Eval(Container.DataItem, "User_Id")%>_thumb.jpg" class="thumb"
                </a>
                <%-- <%# DataBinder.Eval(Container.DataItem, "Node_Value")%>--%>
                 </div>
     
            </ItemTemplate>                                
        
       
    </asp:DataList>