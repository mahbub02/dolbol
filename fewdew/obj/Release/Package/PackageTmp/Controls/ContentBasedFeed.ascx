
<%@ Register src="~/Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>
<%@ Register src="~/Controls/FeedRelated/Status.ascx" tagname="Status" tagprefix="uc2" %>
<%@ Reference Control="~/Controls/FeedRelated/Status.ascx"  %>
<%@ Register src="~/Controls/Comment.ascx" tagname="Comment" tagprefix="uc3" %>
<%@ Reference Control="~/Controls/Comment.ascx" %>
<%@ Reference Control="~/Controls/FeedRelated/Notif_UploadedImage.ascx" %>
<%@ Register src="~/Controls/FeedRelated/Notif_UploadedImage.ascx" tagname="Notif_UploadedImage" tagprefix="uc4" %>
<%@ Register src="~/Controls/Notif_UploadedVideo.ascx" tagname="Notif_UploadedVideo" tagprefix="uc5" %>
<%@ Reference Control="~/Controls/Notif_UploadedVideo.ascx" %>

<%@ Register src="~/Controls/FeedRelated/Notif_UserStatus.ascx" tagname="Notif_UserStatus" tagprefix="uc7" %>
<%@ Reference Control="~/Controls/FeedRelated/Notif_UserStatus.ascx" %>
<%@ Register src="~/Controls/Notif_Blog.ascx" tagname="Notif_Blog" tagprefix="uc8" %> 
<%@ Reference Control="~/Controls/Notif_Blog.ascx" %>
<%@ Register src="~/Controls/NotifTreatPanel.ascx" tagname="NotifTreatPanel" tagprefix="uc9" %>
<%@ Register src="~/Controls/FeedRelated/NotifPoll.ascx" tagname="NotifPoll" tagprefix="uc10" %>
<%@ Reference Control="~/Controls/FeedRelated/NotifPoll.ascx" %>
<%@ Register src="~/Controls/FeedRelated/Noti_WorldLocation_Changed.ascx" tagname="Noti_WorldLocation_Changed" tagprefix="uc11" %>
<%@ Reference Control="~/Controls/FeedRelated/Noti_WorldLocation_Changed.ascx" %>
<%@ Register src="~/Controls/FeedRelated/NotifSingleImage.ascx" tagname="NotifSingleImage" tagprefix="uc12" %>
<%@ Reference Control="~/Controls/FeedRelated/NotifSingleImage.ascx" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentBasedFeed.ascx.cs" Inherits="BDDoctors.Controls.ContentBasedFeed" %>
                                                            <asp:DataList ID="GridContentBasedNotification" runat="server"  RepeatLayout=Flow EnableViewState=false
                                                            AutoGenerateColumns="false"  ShowHeader=false ShowFooter=false
                                                           
                                                             Width=600 onitemdatabound="GridContentBasedNotification_ItemDataBound" >
                                                             <ItemTemplate>
                                                                       
                                                                       
                                                                             
                                                                             <div style="float:left; width:100%; margin-bottom:20px; border-bottom:1px solid #E5F7FC" >
                                                                                    <uc4:Notif_UploadedImage ID="Notif_UploadedImage1" runat="server" Visible="false"  />
                                                                                    <uc5:Notif_UploadedVideo ID="Notif_UploadedVideo1" runat="server" Visible="false" />
                                                                                    <uc7:Notif_UserStatus ID="Notif_UserStatus1" runat="server" Visible="false" />
                                                                                    <uc8:Notif_Blog ID="Notif_Blog1" runat="server" Visible="false" />
                                                                                    <uc9:NotifTreatPanel ID="NotifTreatPanel1" runat="server" Visible="false" />
                                                                                    <uc10:NotifPoll ID="NotifPoll1" runat="server" visible="false" />
                                                                                    <uc11:Noti_WorldLocation_Changed ID="Noti_WorldLocation_Changed1"  Visible="false"  runat="server" />
                                                                                    <uc12:NotifSingleImage ID="NotifSingleImage1" runat="server" />
                                                                                 <div style="float:left; width:100%; ">
                                                                                        
                                                                                     <uc3:Comment ID="Comment1" runat="server"   />
                                                                                 </div> 
                                                                              </div> 
                                                                              
                                                                              
                                                              </ItemTemplate>
                                                              </asp:DataList>