
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Notif_UploadedImage.ascx.cs" Inherits="BDDoctors.Controls.FeedRelated.Notif_UploadedImage" %>
        
    <%-- <asp:LinkButton  runat="server" ID="lbtnDelete" 
         CssClass="comment-delete" Text="Delete" 
              onclick="lbtnDelete_Click" 
         ></asp:LinkButton>--%>
        
        <asp:DataList ID="GridHeader"  runat="server" 
         AutoGenerateColumns="false"   ShowHeader="false" RepeatDirection=Horizontal RepeatLayout=Flow
        >
        
            <ItemTemplate>
              <div style="width:60px; float:left; ">
                    
               <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>>            
                <img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "User_id")%>_thumb.jpg" class="thumb" />
                </a>
              </div>
                <div style="width:500px; float:left; display:inline;  ">  
                <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>> 
                <%# DataBinder.Eval(Container.DataItem, "User_Name")%>
                </a>
                 Has created album
                 <a href=photoalbum.aspx?PhotoAlbum=<%# DataBinder.Eval(Container.DataItem, "Id")%>><%# DataBinder.Eval(Container.DataItem, "Node_Value")%></a>
                <abbr class="timeago header" title=<%# ((DateTime)DataBinder.Eval(Container.DataItem, "action_date")).ToString("yyyy-MM-ddTHH:mm:ss", null) %> ></abbr>
                </div>
            </ItemTemplate>                                
       
    </asp:DataList>
       
            
<asp:DataList Width="350" RepeatDirection=Horizontal RepeatLayout=Flow ID="DlAlbums" style=" float:left; width:400px"    runat="server"   
         AutoGenerateColumns="false"   
        >
        
            
            <ItemTemplate>
                <%--<a href=photoalbum.aspx?PhotoAlbum=<%# DataBinder.Eval(Container.DataItem, "Parent_Node_Id")%>>    --%>        
               

               <a href="Images/Node/<%# DataBinder.Eval(Container.DataItem, "Id")%>_display.jpg" rel="example1" >     <img src="Images/Node/<%# DataBinder.Eval(Container.DataItem, "Id")%>_mini.jpg"  /></a>
               <%-- </a>--%>
            </ItemTemplate>                                
        
    </asp:DataList>
    