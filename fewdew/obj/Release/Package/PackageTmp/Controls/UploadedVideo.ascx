<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadedVideo.ascx.cs" Inherits="BDDoctors.Controls.UploadedVideo" %>
<%@ Register assembly="ASPNetFlashVideo.NET2.AJAX" namespace="ASPNetFlashVideo" tagprefix="ASPNetFlashVideo" %>

<%--<asp:LinkButton runat="server" ID="lbtnUploadNewVideo" 
                                       Text="Upload Video" 
    onclick="lbtnUploadNewVideo_Click" CssClass="link-button-upload-video" ></asp:LinkButton>--%>
                                       

  
            <div runat="server" id="divUploadVideo"  visible=false style="width:400px"   >
                 
                 <asp:Label runat="server" ID="lblValidationMessageForVideo"></asp:Label>   
                 <ul>                                       
                    <li><asp:Label runat="server" ID="lblUploadMessage"></asp:Label></li>
                    <li><span style="width:120px; display:inline-block">Video Title</span> <asp:TextBox runat="server" ID="txtVideoTitle"></asp:TextBox></li>
                    <li><span style="width:120px; display:inline-block">Browse file</span><asp:FileUpload ID="FileUploadVideo" runat="server"   style="width:150px"   /></li>
                    <li><asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                            onclick="btnCancel_Click" /><asp:Button ID="btnUpload" runat="server" 
                            Text="Upload"  onclick="btnUpload_Click" /></li>
                 </ul>           
              </div>
 
                   
                             
                                              

        <asp:GridView ID="GridViewVideo" runat="server" AutoGenerateColumns="false" 
                CssClass="YourGridView" onrowdatabound="GridViewVideo_RowDataBound" 
                onrowediting="GridViewVideo_RowEditing">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a ID="hlinkAlbum" runat="server">
                        <asp:TextBox  runat="server" ID="txtHiddenParentId" Visible="false"></asp:TextBox>
                        <ul class="album">
                            <li>
                                <asp:ImageButton runat="server" Width="120"  ID="imgbtnVideoImage" CommandName="edit" />
                            </li>
                            <li>
                                <asp:Label ID="lblTitleValue" runat="server" CssClass="album"></asp:Label>
                            </li>
                        </ul>
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
               No Video is uploaded yet
            </EmptyDataTemplate>
        </asp:GridView>
        


     <p>&nbsp </p> 
 
            <asp:TextBox ID="txtNodeParent" runat="server" Visible=false></asp:TextBox>          
          <ASPNetFlashVideo:FlashVideo ID="FlashVideo1" runat="server" AutoPlay="true" AllowFullScreen=true Alignment="Center" Visible="false"  BufferTime="10"  
                                                >
            </ASPNetFlashVideo:FlashVideo>
            <asp:Label runat="server" ID="lblVideoTitle" CssClass="video-title"></asp:Label>
   
  
    <asp:GridView ID="GridReadMessage" runat="server"  BorderWidth="0"
    AutoGenerateColumns="false"  CssClass="CommentView"  
    ShowFooter="true"  ShowHeader="true" rowstyle-borderstyle="none"                              
    onrowupdating="GridReadMessage_RowUpdating"  >
    <RowStyle CssClass="CommentView" />
        <Columns>
            <asp:TemplateField>
            <ItemStyle  />
                <ItemTemplate>
                        <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>><img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "User_id")%>_thumb.jpg" /></a>
                </ItemTemplate>   
                                               
            </asp:TemplateField>
             
            <asp:TemplateField>
                <ItemStyle Width=150  />
                <ItemTemplate>
                  <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>>   <%# DataBinder.Eval(Container.DataItem, "User_Name")%></a>
                    <div><%# DataBinder.Eval(Container.DataItem, "Action_date")%></div>
                </ItemTemplate>                               
            </asp:TemplateField> 

            <asp:TemplateField>
              
                <ItemTemplate>
                 <ItemStyle Width=200 />
                      
                      <div><asp:LinkButton runat="server" Enabled="false" ID="lbtnMessage" Text=<%# DataBinder.Eval(Container.DataItem, "Node_value")%>></asp:LinkButton> </div>
                </ItemTemplate> 
                <FooterTemplate>
                Reply
                <div>
                <asp:TextBox runat="server" ID="txtEnterMessage" CssClass="message-box" TextMode="MultiLine"   >
                </asp:TextBox>
                </div>
                
                <asp:Button runat="server" ID="btnPostMessage" Text="Send"   CommandName="update" />
                </FooterTemplate>                               
            </asp:TemplateField> 

        </Columns>
        <EmptyDataTemplate>
         No Comment posted yet
        </EmptyDataTemplate>

    </asp:GridView> 

   
      
 


                          
                          