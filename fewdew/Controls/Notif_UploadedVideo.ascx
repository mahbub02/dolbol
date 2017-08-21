<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Notif_UploadedVideo.ascx.cs" Inherits="BDDoctors.Controls.Notif_UploadedVideo" %>
<%@ Register assembly="ASPNetFlashVideo.NET2.AJAX" namespace="ASPNetFlashVideo" tagprefix="ASPNetFlashVideo" %>
      
        
      <asp:GridView ID="GridHeader"  runat="server"  
         AutoGenerateColumns="false"   ShowHeader="false" ShowFooter=false
        >
        <Columns>                            
        <asp:TemplateField>
            
            <ItemTemplate>
              <div style="width:100px; float:left; ">       
                <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>>            
                <img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "User_id")%>_thumb.jpg" />
                </a>
                </div>
                <div style="width:400px; float:left; display:inline;  "> 
                    <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>> 
                    <%# DataBinder.Eval(Container.DataItem, "User_Name")%>
                    </a>
                     Has uploaded a <b>video<%--<img src="../Images/Site/video.gif" class="icon" />--%></b>
                    <%# DataBinder.Eval(Container.DataItem, "Node_Value")%>
                     at  <%# DataBinder.Eval(Container.DataItem, "Action_Date")%> 
                 </div> 
     
            </ItemTemplate>                                
        </asp:TemplateField>
        </Columns>
       
    </asp:GridView>
       
            
<asp:GridView ID="GridViewVideo"  runat="server" ShowFooter=false ShowHeader=false  CssClass="GridViewVideo" style="position:relative;left:100px;top:-50px;"
         AutoGenerateColumns="false" BorderColor=Green  onrowdatabound="GridViewVideo_RowDataBound" onrowupdating="GridViewVideo_RowUpdating"   
        >
        <Columns>                            
        <asp:TemplateField>
            
            <ItemTemplate>
                <%--<a href=photoalbum.aspx?PhotoAlbum=<%# DataBinder.Eval(Container.DataItem, "Parent_Node_Id")%>>            
                    <img src="Images/Node/<%# DataBinder.Eval(Container.DataItem, "Id")%>_mini.jpg" />
                </a>--%>
                <ul>
                <li>
                <aspnetflashvideo:flashvideo ID="FlashVideo1" runat="server"  Width="300" Height="300"
    AllowFullScreen=true Alignment="Center" Visible=false Enabled="true" AutoPlay="true" ShowControlPanel="true"   WindowMode="Window" BufferTime="10"   
                                                >
            </aspnetflashvideo:flashvideo></li>
                    <%--<asp:ImageButton runat="server" ImageUrl="~/Video/3_281_09072009.jpg" ID="imgThumbVideo" Width="50" Height="60" CommandName="update" style="float:left" />--%>
                
                <li><asp:LinkButton runat="server" ID="lbtnPlayVideo" CommandName="update" style="position:absolute;" CommandArgument=<%# DataBinder.Eval(Container.DataItem, "Id")%>  ><img src="video/<%# DataBinder.Eval(Container.DataItem, "Id")%>.jpg" style="width:60px" />  </asp:LinkButton></li> 
                </ul>
                
            </ItemTemplate>                                
        </asp:TemplateField>
        </Columns>
        
    </asp:GridView>


