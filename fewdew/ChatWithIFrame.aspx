<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChatWithIFrame.aspx.cs" Inherits="BDDoctors.ChatWithIFrame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="CSS/Global.css" rel="stylesheet" type="text/css" />
    <link href="CSS/ChatIframe.css" rel="stylesheet" type="text/css" />
</head>
<body style="height:90%;  overflow:hidden">
    <form id="form1" runat="server" >
    
    <iframe runat="server" id="iframeChat" class="iframe"  src=SignIn.aspx width="100%"  frameborder=1  height="650px"  scrolling="auto"   >
    
    </iframe>
    <div class="chat-holder" >
       <asp:GridView ID="GridViewOnlineUsers" runat="server" AutoGenerateColumns="false" ShowFooter="false" ShowHeader="false">
            <Columns>
                <asp:TemplateField>
                
                    <ItemTemplate>
                            <a href=Profile2.aspx?user=<%# DataBinder.Eval(Container.DataItem, "id")%>><img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "id")%>_mini" /></a>
                    </ItemTemplate>   
                                                   
                </asp:TemplateField>
                 
                <asp:TemplateField>
                    
                    <ItemTemplate>
                      <a href=Profile2.aspx?user=<%# DataBinder.Eval(Container.DataItem, "id")%>>   <%# DataBinder.Eval(Container.DataItem, "DisplayName")%></a>
                        <div style="color:#ADB0B0; font-size:x-small"><%--<%# DataBinder.Eval(Container.DataItem, "Action_date")%>--%></div>
                    </ItemTemplate>                               
                </asp:TemplateField> 
            </Columns>
            <EmptyDataTemplate>
            No user Online
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
