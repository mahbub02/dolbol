<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NotifTreatPanel.ascx.cs" Inherits="BDDoctors.Controls.NotifTreatPanel" %>
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
         AutoGenerateColumns="false" RepeatLayout=Flow RepeatDirection=Horizontal  Width="500"   ShowHeader="false"
        >
      
            
            <ItemTemplate>

                <div style="width:500px; float:left; ">  
                <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>> 
                <%# DataBinder.Eval(Container.DataItem, "User_Name")%>
                </a>
                  had an 
                 <a href=MediPanelDetails.aspx?Panel_id=<%# DataBinder.Eval(Container.DataItem, "Id")%>> appoinment </a> with the doctors in <a href="../TreatmentPanel.aspx"> prescription point</a>
                 <abbr class="timeago header" title=<%# ((DateTime)DataBinder.Eval(Container.DataItem, "action_date")).ToString("yyyy-MM-ddTHH:mm:ss", null) %> ></abbr>
                </div>
            </ItemTemplate>                                
        
    </asp:DataList>


<ul  style="width:400px;margin-left:60px">
<li  >  <asp:Label runat="server" Font-Size="18px" ID="lblDescriptionValue"></asp:Label></li>
   
<li>
   <asp:DataList Width="350" RepeatDirection=Horizontal RepeatLayout=Flow ID="DlAlbums" style=" float:left; width:400px"    runat="server"   
         AutoGenerateColumns="false"   
        >
        
            
            <ItemTemplate>
                <%--<a href=photoalbum.aspx?PhotoAlbum=<%# DataBinder.Eval(Container.DataItem, "Parent_Node_Id")%>>    --%>        
                    <%--<img src="Images/Node/<%# DataBinder.Eval(Container.DataItem, "Id")%>_mini.jpg" onclick="ShowActualSize(this);" />--%>
                    <a href="../Images/Node/<%# DataBinder.Eval(Container.DataItem, "id")%>_display.jpg" rel="example1" >      <img src="../../Images/Node/<%# DataBinder.Eval(Container.DataItem, "id")%>_mini.jpg" alt=""  /></a>
                    
               <%-- </a>--%>
            </ItemTemplate>                                
        
    </asp:DataList></li>    
   
</ul>

</div>