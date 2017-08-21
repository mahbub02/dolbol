<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NotifPoll.ascx.cs" Inherits="BDDoctors.Controls.FeedRelated.NotifPoll" %>
<asp:DataList ID="GridHeader"  runat="server" 
         AutoGenerateColumns="false"   ShowHeader="false" RepeatDirection=Horizontal RepeatLayout=Flow
        >
        
            <ItemTemplate>
              <div style="width:100px; float:left; ">
                    
                <a target="_top" href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>>            
                <img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "User_id")%>_thumb.jpg" />
                </a>
              </div>
                <div style="width:400px; float:left; display:inline;  ">  
                <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>> 
                <%# DataBinder.Eval(Container.DataItem, "User_Name")%>
                </a>
                 Has published a 
                 <a href=photoalbum.aspx?PhotoAlbum=<%# DataBinder.Eval(Container.DataItem, "Id")%>>poll</a>                 
                 at  <%# DataBinder.Eval(Container.DataItem, "Action_Date")%>  
                 <br />
                 Question:   <%# DataBinder.Eval(Container.DataItem, "Node_Value")%>?
                </div>
            </ItemTemplate>                                
       
    </asp:DataList>
           <div runat="server" id="dvResult">
           </div> 
    
          <div style="display:inline-block">
          <asp:CheckBoxList runat="server" ID="chkanswer"  >
            
         </asp:CheckBoxList>
         <asp:RadioButtonList runat="server" ID="rdoanswer">
         
         </asp:RadioButtonList>
         <div runat="server" id="dvMessage"></div>
         <asp:Button runat="server" ID="btnCastMyVote" Text="Cast my vote please" 
                  onclick="btnCastMyVote_Click" />
         </div> 
<%--<asp:DataList Width="350" RepeatDirection=Horizontal RepeatLayout=Flow ID="DlAlbums" style=" float:left; width:400px"    runat="server"   
         AutoGenerateColumns="false"   
        >
        
            
            <ItemTemplate>
            <p><%# DataBinder.Eval(Container.DataItem, "node_value")%><img src="Images/Node/<%# DataBinder.Eval(Container.DataItem, "Id")%>_mini.jpg" style="z-index:3" onclick="ShowActualSize(this);" /> </p>
         
         
         
            </ItemTemplate>  
                                          
        
    </asp:DataList>--%>