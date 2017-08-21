<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NotifSingleImage.ascx.cs" Inherits="BDDoctors.Controls.FeedRelated.NotifSingleImage" %>
<asp:DataList ID="GridHeader"  runat="server" 
         AutoGenerateColumns="false" RepeatDirection=Horizontal RepeatLayout=Flow  style="float:left"  ShowHeader="false"
        >
       
            <ItemTemplate>
               <div style="width:60px; float:left; ">
                <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>>            
                <img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "User_id")%>_thumb.jpg" class="thumb" />
                </a>
                
                 </div>     
                 
                  <div style="width:500px; float:left; ">
                 <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>> 
                <%# DataBinder.Eval(Container.DataItem, "User_Name")%>
                </a> has uploaded an image  
                  <abbr class="timeago header" title=<%# ((DateTime)DataBinder.Eval(Container.DataItem, "action_date")).ToString("yyyy-MM-ddTHH:mm:ss", null) %> ></abbr>
                 <br />
                
           <a href="../../Images/Node/<%# DataBinder.Eval(Container.DataItem, "id")%>_display.jpg" rel="example1" >      <img src="../../Images/Node/<%# DataBinder.Eval(Container.DataItem, "id")%>_profile.jpg" alt=""  /></a>
                 
                <%-- <%# DataBinder.Eval(Container.DataItem, "Node_Value")%>--%>
                 </div>
     
            </ItemTemplate>                                
        
       
    </asp:DataList>