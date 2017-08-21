<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChatPoint.ascx.cs" Inherits="BDDoctors.Controls.ChatPoint" %>

    <asp:Panel runat=server ID="dvChatPointMessage" Visible=true   class="chat-point-message guter">
    
             
                <div style="float:left;width:100%; height:30px;background-color:black;">
                    <a style="float:left; z-index:2;" href=Profile.aspx?user=<%=this.ID%>><img src="Images/profile/<%=this.ID%>_mini.jpg" style="width:20px" /></a>
                    
                    <asp:LinkButton runat="server" ID="lbtnMinimize" style="float:right" Text="-"  ForeColor=White Font-Size=X-Large
                        onclick="lbtnMinimize_Click" Width="70%"></asp:LinkButton>
                    

                </div>
                <div class="only-messages" runat="server" id="dvMessage">
                   <asp:GridView ID="GridConversation" runat="server"  CssClass="comment"
        AutoGenerateColumns="false" ShowHeader=false ShowFooter=false  Width="240"  
                       style="margin-left:0px" onrowupdating="GridConversation_RowUpdating" 
                     >
                <Columns>  
                                          
                                        <%--<asp:TemplateField>
                                         <ItemStyle Width="30" />
                                            <ItemTemplate>
                                                    <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "Sender_id")%>><img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "Sender_id")%>_mini.jpg" /></a>
                                            </ItemTemplate>   
                                                                           
                                        </asp:TemplateField>--%>
                                         
                                        <asp:TemplateField>
                                            <ItemStyle Width="60" />
                                            <ItemTemplate>
                                              <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "Sender_id")%>>   <%# DataBinder.Eval(Container.DataItem, "Sender_Name")%></a>
                                                <div style="color:#ADB0B0; font-size:8px"><%# DataBinder.Eval(Container.DataItem, "Action_date")%></div>
                                            </ItemTemplate>                               
                                        </asp:TemplateField> 
                                        
                                        <asp:TemplateField>
                                          
                                            <ItemTemplate>
                                            
                                                  
                                                  <div><asp:label runat="server" ID="lblMessage" Text=<%# DataBinder.Eval(Container.DataItem, "Message")%>></asp:label> </div>
                                            </ItemTemplate> 
                                                                   
                                        </asp:TemplateField> 
                </Columns>
                <EmptyDataTemplate>
                 
                </EmptyDataTemplate>
            </asp:GridView>
                </div>    
                 <div runat="server" id="dvFooter" style="float:left;width:100%;  height:40px;">
                             <asp:Label runat="server" ID="lblOffLineMessage" style="width:100%"></asp:Label>
                            <asp:TextBox runat="server" ID="txtEnterMessage"  TextMode="MultiLine" style="display:inline; width:75%; height:20px"   >    </asp:TextBox>
                            <asp:Button runat="server" ID="btnPostMessage" Text="Send"   CommandName="update" 
                                    onclick="btnPostMessage_Click"  style="display:inline; width:20%;height:40px;position:relative;" />
                                                        
                </div>
   </asp:Panel>
<%--   <asp:ImageButton ImageUrl="~/Images/profile/<%=base.ID%>_mini.jpg" Visible=false  
    runat="server" ID="imgMinimized" CssClass="imgMinimized" 
    onclick="imgMinimized_Click" /> --%>
    
  <asp:LinkButton runat="server" ID="lbtnMinimized" onclick="lbtnMinimized_Click" CssClass="imgMinimized" ><img id="imgChatBlinker" visible=false runat="server" style="z-index:2; position:absolute;top:-20px" src="../Images/Site/chatBlink.gif" /> <img src="../Images/profile/<%=base.ID%>_mini.jpg" style="height:20px"  /><asp:Label runat="server" ID="lblChatUserName"></asp:Label>  </asp:LinkButton>
  

   
