<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllFriends.aspx.cs" Inherits="BDDoctors.AllFriends" %>

<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SEE ALL FRIENDS</title>
    <link href="CSS/Global.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    div.friend a{ float:left; vertical-align:top}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
    <div class="dvMain" >
    <div class="top">   
        <uc1:LoggedInUserMenu ID="LoggedInUserMenu1" runat="server" />
    </div>
     <div class="body">
        <div class="left">
        </div>
        <div class="middle">
        
                <asp:GridView ID="GridAllFriend" runat="server" CssClass="YourGridView" 
                                                          AutoGenerateColumns="false"  
                    Width="90%"  ShowHeader="false" AllowPaging=true 
                    PagerSettings-Mode="NumericFirstLast" PageSize=20    ShowFooter=false    PagerStyle-CssClass="PageStyle"  
                    PagerSettings-Position="TopAndBottom" PagerStyle-HorizontalAlign=Left    
                    PagerStyle-Font-Bold=true 
                    onpageindexchanging="GridAllFriend_PageIndexChanging"    >
                                                          
                                                        <Columns>
                                                        
                                                            <asp:TemplateField>
                                                            
                                                              <ItemStyle    />
                                                                <ItemTemplate>
                                                                         <div class="friend">
                                                                             <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "UserId")%>><img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "Userid")%>_thumb.jpg" /></a>
                                                                             <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "UserId")%>>   <%# DataBinder.Eval(Container.DataItem, "DisplayName")%></a>
                                                                           
                                                                           </div>
                                                                </ItemTemplate>
                                                              </asp:TemplateField>
                                                        </Columns>
            </asp:GridView>
        </div>
        <div class="right">
        </div>
     </div>
    </div>
    </form>
</body>
</html>
