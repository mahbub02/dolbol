<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Request.aspx.cs" Inherits="BDDoctors.Request" %>

<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>FewDew:Contact Request</title>
    <link href="CSS/Global.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Request.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode=Release>
        </asp:ScriptManager>
    <div class="dvMain">     
        <uc1:LoggedInUserMenu ID="LoggedInUserMenu1" runat="server" />
            <div class="top">
          
           </div>
                    
           <div class="body">
           <div class="left" >
           </div>
           <div class="middle" > 
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server"  UpdateMode="Conditional">
                     <ContentTemplate>
                     <h4 ><asp:Label runat="server" ID="lblRequestMessage"></asp:Label></h4>
                       <asp:DataList runat="server" ID="dlRequestList" 
                             onitemcommand="dlRequestList_ItemCommand" 
                             onitemdatabound="dlRequestList_ItemDataBound">
                       <ItemTemplate>
                       <div class="request" >
                            <asp:TextBox runat="server" ID="txtUserId" Visible="false"></asp:TextBox>
                             <div class="requester-image">
                                <asp:HyperLink runat="server" ID="hlinkImage" ><img runat="server"  Width=80  ID="imgFriendPic" /></asp:HyperLink> 
                             </div>
                             <div class="request-details">
                                 <asp:HyperLink runat="server" Target="_blank" ID="lbtnUserName"></asp:HyperLink>
                                has requested you to be his/her connection. What would you like to do
                               <asp:LinkButton runat="server" ID="lbtnReject" Text="Reject" CommandName="reject" ></asp:LinkButton>/<asp:LinkButton runat="server" ID="lbtnAccept" Text="Accept" CommandName="accept" ></asp:LinkButton>
                             </div>
                         </div>
                       </ItemTemplate>
                       </asp:DataList>
                     </ContentTemplate>
                    </asp:UpdatePanel>     
           </div>
            <div class="right" >
            </div>
            
           </div>
           
    </div>  
    </form>
</body>
</html>
