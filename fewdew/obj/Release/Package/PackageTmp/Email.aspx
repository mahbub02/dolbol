<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Email.aspx.cs" Inherits="BDDoctors.Email" %>
<%@ Import Namespace="BDDoctors" %>
<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>


<%@ Register src="Controls/FeedRelated/Status.ascx" tagname="Status" tagprefix="uc2" %>

<%@ Reference Control="~/Controls/FeedRelated/Status.ascx"  %>
<%@ Register src="Controls/FriendList.ascx" tagname="FriendList" tagprefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>Fewdew|Email</title>
<link href="CSS/Global.css" rel="stylesheet" type="text/css" />
<link href="CSS/Email.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript">
function HideTheCrossButtonWhenDeletedEmailPressed()
{

    var HiddenInput=document.getElementById("hiddenDeletePressed");
   
        if(HiddenInput.value=="YES")
            {
            
            var ancList=document.getElementsByTagName("a");
        
              for(var i=0;i<ancList.length;i++)
              {
                  if(ancList[i].className=="cross")
                  {
                     ancList[i].style.display="none";
                  }
              }
            }

}

 function CheckBr(txtBox,lineLength)
        {
       
          var text=  txtBox.value;
            if(text.charAt(text.length-1)!='\n' && text.length>lineLength)
                {               
                    if( text.lastIndexOf('\n')<text.length-lineLength)
                    {
                        txtBox.value= text+'\n';
                    }
                }   
                 if(txtBox.value.length==1000)
                     {
                      alert("Maximum text length 300");
       
                     } 
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode=Release>
        </asp:ScriptManager>
    <div class="dvMain" >
        <uc1:LoggedInUserMenu ID="LoggedInUserMenu2" runat="server" />
     
          <div class="top" style="border:1px solid black">
         
           </div>
                    
           <div class="body" onmousemove="HideTheCrossButtonWhenDeletedEmailPressed();" >
                    <div class="left" style="width:120px"  >
                                             <asp:UpdateProgress runat="server" ID="uProgressMenu"  AssociatedUpdatePanelID="UpdatePanelEmailMenu">
                                             <ProgressTemplate>
                                             <img src="Images/Site/updateprogress2.gif" alt="Wait" style="position:absolute;z-index:3;"  />
                                             </ProgressTemplate> 
                                             </asp:UpdateProgress>  
                        <asp:UpdatePanel ID="UpdatePanelEmailMenu" runat="server" UpdateMode="Always">
                           <ContentTemplate>
                            <input runat="server" id="hiddenDeletePressed" style="display:none"    />
                        <ul class="ulEmails" >
                            <li><asp:LinkButton runat="server" ID="lbtnInbox" Text="Inbox" CssClass="mail-box-clicked"
                                    onclick="lbtnInbox_Click"></asp:LinkButton></li>
                            <li><asp:LinkButton runat="server" ID="lbtnSentItem" Text="Sent Item" 
                                    onclick="lbtnSentItem_Click"></asp:LinkButton></li>
                            <li><asp:LinkButton runat="server" ID="lblDeletedMail" Text="Deleted Mail" OnClientClick="HideTheCrossButtonWhenDeletedEmailPressed();" onclick="lblDeletedMail_Click" 
                                  ></asp:LinkButton></li>
                        </ul>
                        </ContentTemplate>
                         </asp:UpdatePanel>
                    </div>
                    <div class="middle" style="width:630px"  >                          
                           
                           <asp:UpdatePanel ID="UpdatePanelGridEmail" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                          <h4><asp:Label runat="server" ID="lblHeaderText" Text=""></asp:Label>  </h4>
                                <asp:GridView ID="GridEmail" runat="server" AllowPaging=true Width=630
                              AutoGenerateColumns="false"   ShowHeader="false" ShowFooter=false  PagerSettings-Position=TopAndBottom 
                                PagerStyle-Font-Bold=true onrowdeleting="GridEmail_RowDeleting" PageSize="10" 
                                    PagerSettings-Mode=NumericFirstLast onrowediting="GridEmail_RowEditing" 
                                    onpageindexchanging="GridEmail_PageIndexChanging" >
                               
                            <Columns>
                            
                                <asp:TemplateField>
                                  <ItemStyle  />
                                    <ItemTemplate>
                                  <div class="B<%# DataBinder.Eval(Container.DataItem, "status")%>" style="margin-bottom:10px; border-bottom:1px solid #CCC" >
                                     <div style="width:100px">
                                            <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "Sender_Id")%>><img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "Sender_Id")%>_thumb.jpg" /></a>
                                    </div>
                                    <div style="width:150px">
                                         <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "sender_Id")%>>   <%# DataBinder.Eval(Container.DataItem, "sender_name")%></a>
                                        <div><%# DataBinder.Eval(Container.DataItem, "ActionDate")%></div>
                                    </div>
                                    
                                    <div style="width:300px">
                                                 <p style="border-bottom:1px solid #CCC"> Subject:<asp:LinkButton runat="server" ID="lbtnSubject" Text=<%# DataBinder.Eval(Container.DataItem, "Subject")%> CommandName="edit"></asp:LinkButton> </p> 
                                                 <p> <asp:LinkButton runat="server" ID="lbtnMessage" Text=<%# DataBinder.Eval(Container.DataItem, "message")%> CommandName="edit"></asp:LinkButton> </p> 
                                   
                                    </div> 
                                    
                                    <div style=" margin-left:90px; width:10px; float:right; ">
                                            
                                             <asp:LinkButton runat="server" CssClass="cross"  style="" ID="lbtnDelete" Text="X" CommandName="Delete"></asp:LinkButton>
                                           
                                            <asp:TextBox runat="server" Visible="false" ID="txtParentId" Text=<%# DataBinder.Eval(Container.DataItem, "parent_id")%> ></asp:TextBox>
                               
                                    </div>
                                  </div>           
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
                              AutoGenerateColumns="false"  CssClass="YourGridView"  
                                    ShowFooter="true"  ShowHeader="false" rowstyle-borderstyle="none"
                                                              
                                onrowupdating="GridReadMessage_RowUpdating" 
                                    >
                               <RowStyle CssClass="YourGridView" />
                            <Columns>
                            
                                <asp:TemplateField>
                                <ItemStyle  />
                                    <ItemTemplate>
                                            <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "Sender_Id")%>><img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "Sender_Id")%>_thumb.jpg" /></a>
                                    </ItemTemplate>   
                                                                   
                                </asp:TemplateField>
                                 
                                <asp:TemplateField>
                                    <ItemStyle Width=150  />
                                    <ItemTemplate>
                                      <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "sender_Id")%>>   <%# DataBinder.Eval(Container.DataItem, "sender_name")%></a>
                                        <div><%# DataBinder.Eval(Container.DataItem, "ActionDate")%></div>
                                    </ItemTemplate>                               
                                </asp:TemplateField> 
                                
                                <asp:TemplateField>
                                  
                                    <ItemTemplate>
                                     <ItemStyle width=200 />
                                          <p style="width:100%; border-bottom:1px solid #CCC"><asp:LinkButton runat="server" ID="lbtnSubject" Text=<%# DataBinder.Eval(Container.DataItem, "Subject")%>></asp:LinkButton></p>
                                          <p><asp:LinkButton runat="server" ID="lbtnMessage" Text=<%# DataBinder.Eval(Container.DataItem, "message")%>></asp:LinkButton> </p>
                                    </ItemTemplate> 
                                    <FooterTemplate>
                                    Reply
                                    <div>
                                    <asp:TextBox runat="server" ID="txtEnterMessage" CssClass="message-box" onkeypress="CheckBr(this,40);" TextMode="MultiLine"   >
                                    </asp:TextBox>
                                     <asp:Button runat="server" ID="btnPostMessage" Text="Send"   CommandName="update" />
                                    </div>
                                    
                                   
                                    </FooterTemplate>                               
                                </asp:TemplateField> 
                                
                                
                                
                                    
                            </Columns>
                            <EmptyDataTemplate>
                                 No email
                            </EmptyDataTemplate>
    
                            </asp:GridView> 
                            </ContentTemplate>
                            </asp:UpdatePanel> 
                                             <asp:UpdateProgress runat="server" ID="UpdateProgress1"  AssociatedUpdatePanelID="UpdatePanelReadMessage">
                                             <ProgressTemplate>
                                             <img src="Images/Site/updateprogress2.gif" alt="Wait" style="position:absolute;z-index:3;"  />
                                             </ProgressTemplate> 
                                             </asp:UpdateProgress>
                          
              
                    </div>
                    <div class="right">
                    <h2 class="heading"  > Connections</h2>                      
                        
                        <div style="height:300px;>
                         <uc3:FriendList ID="FriendList1" runat="server" />
                        </div>
                        
                        <div style="float:left">
                         
                        </div>   
                    </div>
            </div>    
        
           
            
           
    </div>
    </form>
</body>
</html>
