<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Notif_Blog.ascx.cs" Inherits="BDDoctors.Controls.Notif_Blog" %>
 <div style=" vertical-align:top;" class="notif-Panel" >
  <asp:DataList ID="datalistUserPhotoName" runat="server"  
         AutoGenerateColumns="false" RepeatLayout=Flow RepeatDirection=Horizontal  Width="60"   ShowHeader="false"
        >
      
            
            <ItemTemplate>
              <div style="float:left; ">
                <a target="_top" href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>>            
                <img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "User_id")%>_thumb.jpg" class="thumb" />
                </a>
                
              </div>
              
            </ItemTemplate>                                
        
    </asp:DataList>
    

 <asp:DataList ID="GridHeader"  runat="server" 
         AutoGenerateColumns="false" RepeatLayout=Flow  RepeatDirection=Horizontal Width="500"    ShowHeader="false"
        >
            <ItemTemplate>
             
                <div style="width:500px; float:left;display:inline;">
               
                <a style="" href=showblog.aspx?Node_id=<%# DataBinder.Eval(Container.DataItem, "Id")%>>  <span style="font-weight:bold; "><%# DataBinder.Eval(Container.DataItem, "Node_Value")%></span></a>
                
                <abbr class="timeago header" title=<%# ((DateTime)DataBinder.Eval(Container.DataItem, "action_date")).ToString("yyyy-MM-ddTHH:mm:ss", null) %> ></abbr>
               
                <p style="width:100%">Posted by <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>> 
                <%# DataBinder.Eval(Container.DataItem, "User_Name")%>
                </a>
                </p>
                
                 
                </div>
            </ItemTemplate>                                
        
    </asp:DataList>





<ul  style="width:400px; margin-left:60px">
   
   
    
    <li><asp:Label runat="server"  ID="lblDescriptionValue"></asp:Label> </li>
     
     <li style="width:100%">
     
     <asp:DataList Width="350" RepeatDirection=Horizontal RepeatLayout=Flow ID="DlAlbums" style=" float:left; width:400px"    runat="server"   
         AutoGenerateColumns="false"   
        >
        
            
            <ItemTemplate>
                <%--<a href=photoalbum.aspx?PhotoAlbum=<%# DataBinder.Eval(Container.DataItem, "Parent_Node_Id")%>>    --%>        
                  <%--  <img src="Images/Node/<%# DataBinder.Eval(Container.DataItem, "Id")%>_mini.jpg" onclick="ShowActualSize(this);" />--%>
                    
                     <a href="Images/Node/<%# DataBinder.Eval(Container.DataItem, "Id")%>_display.jpg" rel="example1" >     <img src="Images/Node/<%# DataBinder.Eval(Container.DataItem, "Id")%>_mini.jpg"  /></a>
                     
                    
               <%-- </a>--%>
            </ItemTemplate>                                
        
    </asp:DataList>
    </li>
    
</ul>

</div>