<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Email.aspx.cs" Inherits="BDDoctors.Email" %>
<%@ Import Namespace="BDDoctors" %>
<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>


<%@ Register src="Controls/FeedRelated/Status.ascx" tagname="Status" tagprefix="uc2" %>

<%@ Reference Control="~/Controls/FeedRelated/Status.ascx"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>Habib:HOME</title>
<link href="CSS/Global.css" rel="stylesheet" type="text/css" />
<link href="CSS/Email.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="dvMain" >
        <uc1:LoggedInUserMenu ID="LoggedInUserMenu2" runat="server" />
     
          <div class="top" style="border:1px solid black">
          
           </div>
                    
           <div class="body" style="border:1px solid black">
                    <div class="left" style="border:1px solid black">
                        <asp:UpdatePanel ID="UpdatePanelEmailMenu" runat="server" UpdateMode="Always">
                       <ContentTemplate>
                        <ul>
                            <li><asp:LinkButton runat="server" ID="lbtnInbox" Text="Inbox" 
                                    onclick="lbtnInbox_Click"></asp:LinkButton></li>
                            <li><asp:LinkButton runat="server" ID="lbtnSentItem" Text="Sent Item" 
                                    onclick="lbtnSentItem_Click"></asp:LinkButton></li>
                            <li><asp:LinkButton runat="server" ID="lbtnComposeNew" Text="Compose New"></asp:LinkButton></li>
                        </ul>
                        </ContentTemplate>
                         </asp:UpdatePanel>
                        

                    </div>
                    <div class="middle" >
                            <h2 class="heading" > INBOX</h2>
                           
                           <asp:UpdatePanel ID="UpdatePanelGridEmail" runat="server" UpdateMode="Always">
                            <ContentTemplate>  
                                <asp:GridView ID="GridEmail" runat="server" CssClass="YourGridView" 
                              AutoGenerateColumns="false"   ShowHeader="false" ShowFooter=false 
                                onrowdeleting="GridEmail_RowDeleting" onrowediting="GridEmail_RowEditing" >
                              
                            <Columns>
                            
                                <asp:TemplateField>
                                  <ItemStyle  />
                                    <ItemTemplate>
                                            <a href=Profile2.aspx?user=<%# DataBinder.Eval(Container.DataItem, "Sender_Id")%>><img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "Sender_Id")%>_mini" /></a>
                                    </ItemTemplate>                                
                                </asp:TemplateField>
                                 
                                <asp:TemplateField>
                                    <ItemStyle Width=150  />
                                    <ItemTemplate>
                                        <div><%# DataBinder.Eval(Container.DataItem, "reciever_name")%></div>
                                        <div><%# DataBinder.Eval(Container.DataItem, "ActionDate")%></div>
                                    </ItemTemplate>                                
                                </asp:TemplateField> 
                                
                                <asp:TemplateField>
                                    <ItemStyle Width=200  />
                                    <ItemTemplate>
                                          <div><asp:LinkButton runat="server" ID="lbtnSubject" Text=<%# DataBinder.Eval(Container.DataItem, "Subject")%> CommandName="edit"></asp:LinkButton> </div>
                                          <div><asp:LinkButton runat="server" ID="lbtnMessage" Text=<%# DataBinder.Eval(Container.DataItem, "message")%> CommandName="edit"></asp:LinkButton> </div>
                                    </ItemTemplate>                                
                                </asp:TemplateField> 
                                
                                <asp:TemplateField>
                                    <ItemStyle Width=200 />
                                    <ItemTemplate>
                                    <div style="text-align:right">
                                    <asp:LinkButton runat="server" ID="lbtnDelete" Text="X" CommandName="Delete"></asp:LinkButton>
                                    </div>
                                    <asp:TextBox runat="server" Visible="false" ID="txtParentId" Text=<%# DataBinder.Eval(Container.DataItem, "parent_id")%> ></asp:TextBox>
                                    </ItemTemplate>                                
                                </asp:TemplateField>
                                
                                    
                            </Columns>
                            <EmptyDataTemplate>
                                 No email
                            </EmptyDataTemplate>
    
                            </asp:GridView>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                           <asp:UpdatePanel ID="UpdatePanelReadMessage" runat="server" UpdateMode="Always">
                            <ContentTemplate>  
                             <asp:GridView ID="GridReadMessage" runat="server"  BorderWidth="0"
                              AutoGenerateColumns="false"  CssClass="YourGridView"   ShowHeader="false" ShowFooter="true"  rowstyle-borderstyle="none"
                                                              
                                onrowupdating="GridReadMessage_RowUpdating">
                               <RowStyle CssClass="YourGridView" />
                            <Columns>
                            
                                <asp:TemplateField>
                                
                                    <ItemTemplate >
                                    
                                            <a href=Profile2.aspx?user=<%# DataBinder.Eval(Container.DataItem, "Sender_Id")%>><img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "Sender_Id")%>_mini" /></a>
                                    </ItemTemplate>
                                                                   
                                </asp:TemplateField>
                                 
                                <asp:TemplateField>
                                    <ItemStyle Width=120  />
                                    <ItemTemplate>
                                        <div><%# DataBinder.Eval(Container.DataItem, "reciever_name")%></div>
                                        <div><%# DataBinder.Eval(Container.DataItem, "ActionDate")%></div>
                                    </ItemTemplate>                                
                                </asp:TemplateField> 
                                
                                <asp:TemplateField>
                                    <ItemStyle Width=400 BorderWidth=0 BackColor=AliceBlue />
                                    <ItemTemplate>
                                          <div><asp:LinkButton runat="server" ID="lbtnSubject" Text=<%# DataBinder.Eval(Container.DataItem, "Subject")%>></asp:LinkButton> </div>
                                          <div><asp:LinkButton runat="server" ID="lbtnMessage" Text=<%# DataBinder.Eval(Container.DataItem, "message")%>></asp:LinkButton> </div>
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
                                 No email
                            </EmptyDataTemplate>
    
                            </asp:GridView> 
                            </ContentTemplate>
                            </asp:UpdatePanel>  
                           
                            
                             
                              
                            
                            
                             
                              
                           
                            
                             
                              
                    </div>
                    <div class="right" style="border:1px solid black">
                    <h2 class="heading" > Connections</h2>                      
                        
                        <div style="height:300px;>
                        
                        </div>
                        
                        <div style="float:left" style="border:1px solid black">
                         <h2 class="heading" > Practice zone</h2>
                           
                        </div>   
                    </div>
            </div>    
        
           
            
           
    </div>
    </form>
</body>
</html>
