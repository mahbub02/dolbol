using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.IO;
using System.Net.Mail;


namespace BDDoctors
{
    public partial class club : System.Web.UI.Page
    {
        [WebMethod]
        public static string SelectAvatar(string ImageSrc, Int32 roomId)
        {
            if (LoginHandler.IsLoggedIn == false)
            {
                throw new ArgumentException("You are not currenty loggedin");

            }

            System.Collections.Generic.IEnumerable<DAL.DataObject.RoomChatter> RoomChatters = from DAL.DataObject.RoomChatter chtr in DAL.DataAccess.RoomChatter.m_RoomUsers
                                                                                              where chtr.CurrentRoom.Value == roomId && chtr.Id.Value == LoginHandler.LoggedInUser().Id.Value
                                                                                              select chtr;
            if (RoomChatters.ToList<DAL.DataObject.RoomChatter>().Count == 1)
            {
                foreach (DAL.DataObject.RoomChatter roomChtr in RoomChatters.ToList<DAL.DataObject.RoomChatter>())
                {
                    roomChtr.Avatar = "url(" + ImageSrc.Replace("/sample", "") + ")";
                    roomChtr.RefreshTime = DateTime.Now;
                }
            }
            else {
                DAL.DataObject.RoomChatter rtr = new BDDoctors.DAL.DataObject.RoomChatter();
                rtr.Id = LoginHandler.LoggedInUser().Id.Value;
                rtr.DisplayName = LoginHandler.LoggedInUser().DisplayName;
                rtr.Avatar = "url(" + ImageSrc.Replace("/sample", "") + ")";             
                rtr.CurrentRoom = Convert.ToInt64(roomId);
                rtr.BackGroundPosition = "64px 0px";
                rtr.Left="350px";
                rtr.Top ="400px";

                rtr.RefreshTime = DateTime.Now;
                DAL.DataAccess.RoomChatter.JoinAtRoom(rtr);
                //return rtr.Avatar;
            }
            return null;

           
        }
        [WebMethod]
        public static System.Collections.Generic.List<object> GetRoomChatterListAndUpdateBackGroundPosition(Int32 roomId, string backPos)
        {
           
            System.Collections.Generic.IEnumerable<DAL.DataObject.RoomChatter> RoomChatters = from DAL.DataObject.RoomChatter chtr in DAL.DataAccess.RoomChatter.m_RoomUsers
                                                                                              where chtr.CurrentRoom.Value == roomId && chtr.Id.Value == LoginHandler.LoggedInUser().Id.Value
                                                                                              select chtr;
            if (RoomChatters.ToList<DAL.DataObject.RoomChatter>().Count == 1)
            {
                foreach (DAL.DataObject.RoomChatter roomChtr in RoomChatters.ToList<DAL.DataObject.RoomChatter>())
                {
                    if (backPos != "undefined")
                    {
                        roomChtr.BackGroundPosition = backPos;


                    }
                    else {
                        roomChtr.BackGroundPosition = "64px 0px";
                    }
                    roomChtr.RefreshTime = DateTime.Now;
                   

                }
            }
            else {
                System.Collections.Generic.IEnumerable<DAL.DataObject.RoomChatter> RoomChatterInAnyRoom = from DAL.DataObject.RoomChatter chtr in DAL.DataAccess.RoomChatter.m_RoomUsers
                                                                                                  where  chtr.Id.Value == LoginHandler.LoggedInUser().Id.Value
                                                                                                  select chtr;

                
                Random random = new Random();
                DAL.DataObject.RoomChatter rtr = new BDDoctors.DAL.DataObject.RoomChatter();
                rtr.Id = LoginHandler.LoggedInUser().Id.Value;
                rtr.DisplayName = LoginHandler.LoggedInUser().DisplayName;
                rtr.Avatar = "url(" + LoginHandler.LoggedInUser().AvatarName + ")";
                //if (RoomChatterInAnyRoom.ToList<DAL.DataObject.RoomChatter>().Count > 0)
                //{
                //    rtr.Avatar = RoomChatterInAnyRoom.ToList<DAL.DataObject.RoomChatter>()[0].Avatar;
                //}
                //else {
                //    rtr.Avatar = "url(Images/AvatarChat/Avatar/a2.png)";
                //}
                
                rtr.CurrentRoom = Convert.ToInt64(roomId);
                rtr.BackGroundPosition = "64px 0px";
                rtr.Left = "350px"; //random.Next(100, 400) + "px";
                rtr.Top = "550px"; //random.Next(100, 400) + "px";
                rtr.RefreshTime = DateTime.Now;
                DAL.DataAccess.RoomChatter.JoinAtRoom(rtr);
            
            }
            System.Collections.Generic.List<object> Objects = new System.Collections.Generic.List<object>();

            System.Collections.Generic.List<DAL.DataObject.RoomChatter> RoomChatterList = DAL.DataAccess.RoomChatter.GetRoomChatters(Convert.ToInt64(roomId));
            Objects.Add(RoomChatterList);
            Objects.Add(GetAllUnDeliveredSpeechesForThisUser( Convert.ToInt32( LoginHandler.LoggedInUser().Id.Value)));

            return Objects;
        }
        [WebMethod]
        public static System.Collections.Generic.List<DAL.DataObject.RoomChatter> UpdateMyAvatar(Int32 roomId, string backPos, string top, string left, string userText)
        {
            System.Collections.Generic.IEnumerable<DAL.DataObject.RoomChatter> RoomChatters = from DAL.DataObject.RoomChatter chtr in DAL.DataAccess.RoomChatter.m_RoomUsers
                                                                                              where chtr.CurrentRoom.Value == roomId && chtr.Id.Value == LoginHandler.LoggedInUser().Id.Value
                                                                                              select chtr;

            if (RoomChatters.ToList<DAL.DataObject.RoomChatter>().Count == 1)
            {
                foreach (DAL.DataObject.RoomChatter roomChtr in RoomChatters.ToList<DAL.DataObject.RoomChatter>())
                {
                    roomChtr.BackGroundPosition = backPos;
                    roomChtr.Top = top+"px";
                    roomChtr.Left = left+"px";
                    roomChtr.RefreshTime = DateTime.Now;
                    if (userText.Length > 0)
                    {
                        roomChtr.Message = userText;
                        roomChtr.SentTime = DateTime.Now;
                    }
                }
            }

            System.Collections.Generic.List<DAL.DataObject.RoomChatter> RoomChatterList = DAL.DataAccess.RoomChatter.GetRoomChatters(Convert.ToInt64(roomId));
            return RoomChatterList;
            
        }
         [WebMethod]
        public static System.Collections.Generic.List<DAL.DataObject.RoomChatter> PostMyText(Int32 roomId, string mytext)
        {
            System.Collections.Generic.IEnumerable<DAL.DataObject.RoomChatter> RoomChatters = from DAL.DataObject.RoomChatter chtr in DAL.DataAccess.RoomChatter.m_RoomUsers
                                                                                              where chtr.CurrentRoom.Value == roomId && chtr.Id.Value == LoginHandler.LoggedInUser().Id.Value
                                                                                              select chtr;

            if (RoomChatters.ToList<DAL.DataObject.RoomChatter>().Count == 1)
            {
                foreach (DAL.DataObject.RoomChatter roomChtr in RoomChatters.ToList<DAL.DataObject.RoomChatter>())
                {
                   
                        roomChtr.Message = mytext;
                        roomChtr.SentTime = DateTime.Now;
                   
                }
            }

            System.Collections.Generic.List<DAL.DataObject.RoomChatter> RoomChatterList = DAL.DataAccess.RoomChatter.GetRoomChatters(Convert.ToInt64(roomId));
            return RoomChatterList;
            
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            hiddenRoomId.Value = Request["room_id"];
         
            hiddenUserId.Value = LoginHandler.LoggedInUser().Id.ToString();
            hiddenUserDisplayName.Value = LoginHandler.LoggedInUser().DisplayName;
            Int32 roomId =Convert.ToInt32( Request["room_id"]);

            System.Collections.Generic.IEnumerable<DAL.DataObject.RoomChatter> RoomChatters = from DAL.DataObject.RoomChatter chtr in DAL.DataAccess.RoomChatter.m_RoomUsers
                                                                                              where chtr.CurrentRoom.Value == roomId && chtr.Id.Value == LoginHandler.LoggedInUser().Id.Value
                                                                                              select chtr;
            if (RoomChatters.ToList<DAL.DataObject.RoomChatter>().Count == 1)
            {
                foreach (DAL.DataObject.RoomChatter roomChtr in RoomChatters.ToList<DAL.DataObject.RoomChatter>())
                {
                   // roomChtr.Avatar = "url(Images/AvatarChat/Avatar/a2.png)";
                    
                    roomChtr.Left = "450px"; //random.Next(100, 400) + "px";
                    roomChtr.Top = "350px"; //random.Next(100, 400) + "px";
                    roomChtr.RefreshTime = DateTime.Now;
                }
            }
            else
            {
                DAL.DataObject.RoomChatter rtr = new BDDoctors.DAL.DataObject.RoomChatter();
                rtr.Id = LoginHandler.LoggedInUser().Id.Value;
                rtr.DisplayName = LoginHandler.LoggedInUser().DisplayName;
                rtr.Avatar = "url(" + LoginHandler.LoggedInUser().AvatarName + ")";
                // rtr.Avatar = "url(Images/AvatarChat/Avatar/a2.png)";
                rtr.CurrentRoom = Convert.ToInt64(roomId);
                rtr.BackGroundPosition = "64px 0px";
                rtr.Left = "450px"; //random.Next(100, 400) + "px";
                rtr.Top = "350px"; //random.Next(100, 400) + "px";
                rtr.RefreshTime = DateTime.Now;
                DAL.DataAccess.RoomChatter.JoinAtRoom(rtr);
                //return rtr.Avatar;
            }

        }
        [WebMethod]
        public static System.Collections.Generic.List<string> GetFolderNames(string folderName)
        {
            try
            {
                string[] folderPaths = System.IO.Directory.GetDirectories( (System.Web.HttpContext.Current.Server.MapPath("~\\Images\\" + folderName + "\\")));
               System.Collections.Generic.List<string> folderNames=new System.Collections.Generic.List<string>();

                for(int i=0;i<folderPaths.Length-1;i++)
                {
                    folderNames.Add(
                        folderPaths[i].Split(Path.AltDirectorySeparatorChar,
                              Path.DirectorySeparatorChar)[folderPaths[i].Split(Path.AltDirectorySeparatorChar,
                              Path.DirectorySeparatorChar).Length-1]                   
                        );
                }
                return folderNames;
            
            }
            catch(Exception ex) {

                return null; ;
            }
            return null;
         
        }
        [WebMethod]
        public static System.Collections.Generic.List<string> GetFileNames(string folderName)
        {
            try
            {
                string[] folderPaths = System.IO.Directory.GetFiles((System.Web.HttpContext.Current.Server.MapPath("~\\Images\\Emos\\" + folderName + "\\")));
                System.Collections.Generic.List<string> FileNames = new System.Collections.Generic.List<string>();
                
                
                for (int i = 0; i < folderPaths.Length - 1; i++)
                {
                  FileNames.Add(System.IO.Path.GetFileName(folderPaths[i]));

                    //folderNames.Add(
                    //    folderPaths[i].Split(Path.AltDirectorySeparatorChar,
                    //          Path.DirectorySeparatorChar)[folderPaths[i].Split(Path.AltDirectorySeparatorChar,
                    //          Path.DirectorySeparatorChar).Length - 1]
                    //    );
                }
                return FileNames;

            }
            catch (Exception ex)
            {

                return null; ;
            }
            return null;

        }
        [WebMethod]
        public static string SaveClubPlace(string Xs, string Ys,Int32 room_id,Int32 linkTo) 
        {
            DAL.DataObject.ClubPlace objClubPlace = new BDDoctors.DAL.DataObject.ClubPlace();
            objClubPlace.clubId = room_id;
            objClubPlace.LinkTo = linkTo;
            objClubPlace.Xs=DAL.DataAccess.ClubLocation.ConvertToList( Xs);
            objClubPlace.Ys = DAL.DataAccess.ClubLocation.ConvertToList( Ys);
            DAL.DataAccess.ClubLocation.SaveClubPlace(objClubPlace);

            //System.Collections.Generic.List<string> strs = DAL.DataAccess.ClubLocation.ConvertToList(Xs);
            //string str = DAL.DataAccess.ClubLocation.ConvertToString(strs);
            return null;
        }
        [WebMethod]
        public static System.Collections.Generic.List<DAL.DataObject.ClubPlace> GetClubLocations(Int32 roomId) 
        {
            System.Collections.Generic.List<DAL.DataObject.ClubPlace> PlaceList = DAL.DataAccess.ClubLocation.GetClubPlacesByClubId(roomId);

            return PlaceList;
        }


        [WebMethod]
        public static System.Collections.Generic.List<DAL.DataObject.Speech> GetAllSpeechesForThisUser(Int32 UserId)
        {
           return BDDoctors.Speech.GetAllSpeechesForThisUser(UserId);
        }
        [WebMethod]
        public static System.Collections.Generic.List<DAL.DataObject.Speech> GetAllUnDeliveredSpeechesForThisUser(Int32 UserId)
        {
            return BDDoctors.Speech.GetAllUnDeliveredSpeechesForThisUser(UserId);
        }
        [WebMethod]
        public static System.Collections.Generic.List<DAL.DataObject.Speech> UpdateSpeech(Int32 UserId,string displayName, string Message)
        {
            return BDDoctors.Speech.UpdateSpeech( UserId,displayName,  Message);
        }
        [WebMethod]
        public static System.Collections.Generic.List<DAL.DataObject.Speech> DeleteSpeechWithThisUser(Int32 MyId, Int32 UserId)
        {
            return BDDoctors.Speech.DeleteSpeechWithThisUser(MyId, UserId);
        }

         [WebMethod]
        public static System.Collections.Generic.List<DAL.DataObject.OnlineUser> RefreshUserAndGetOnlineUserList(Int32 MyId)
        {
            OnlineUser.RefreshUser(MyId);
            return OnlineUser.GetOnlineUser();
        }

         [WebMethod]
         public static System.Collections.Generic.List<DAL.DataObject.Speech> SendInstanceFriendRequestToThisUser(Int32 UserId, string UserDisplayName)
         {
             return BDDoctors.Speech.SendInstanceFriendRequestToThisUser(UserId, UserDisplayName);
         }
         [WebMethod]
         public static System.Collections.Generic.List<DAL.DataObject.Speech> ConfirmedAsFriend(Int32 userid)
         {
             return BDDoctors.Speech.ConfirmedAsFriend(userid);
         }
         [WebMethod]
         public static string FriendShipRequestRejected(Int32 userid)
         {
             return Convert.ToString( DAL.DataAccess.FriendShip.DeleteFriendShip(userid, LoginHandler.LoggedInUser().Id.Value ));
         }


         protected void lbtnsignout_Click(object sender, EventArgs e)
        {
             BDDoctors.LoginHandler.DoLogOut();
         }

         [WebMethod]
         public static  string NumberOfPendingRequest(Int32 userid)
         {
             return Convert.ToString( DAL.DataAccess.FriendShip.NumberOfFriendRequest(userid));
         }
         [WebMethod]
         public static System.Collections.Generic.List<DAL.DataObject.Friend> GetFriendAwaitingForMyResponse(Int32 userid)
         {
             return DAL.DataAccess.FriendShip.GetFriendAwaitingForMyResponse(userid);
         }
         [WebMethod]
         public static System.Collections.Generic.List<DAL.DataObject.Friend> GetFriendList(Int32 userid)
         {
             return DAL.DataAccess.FriendShip.GetFriendList(userid);
         }

         [WebMethod]
         public static System.Collections.Generic.List<DAL.DataObject.Node> PostStatusMessage(Int64 WallOwnerid, string WallOwnerName, Int64 MaxId,string Message)
         {
             
             System.Collections.Generic.List<DAL.DataObject.Node> nodes = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();
             DAL.DataObject.Node nd;
             nd = new BDDoctors.DAL.DataObject.Node();
             nd.User_id = LoginHandler.LoggedInUser().Id.Value;
             nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
             if (WallOwnerid == 0 || WallOwnerid == -1)
             {
                 nd.Wall_Owner_id = LoginHandler.LoggedInUser().Id.Value; 
                 nd.Wall_Owner_Name = LoginHandler.LoggedInUser().DisplayName;
             }
             else
             {
                 nd.Wall_Owner_id = WallOwnerid;
                 nd.Wall_Owner_Name = WallOwnerName;

             }
             nd.Attribute_id = 1;
             nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(Message);
             nd.Action_date = DateTime.Now;
             nodes.Add(nd);
             Int64 parent_id = DAL.DataAccess.Node.SaveNodes(nodes);
             nd.Parent_Node_Id = parent_id;

             return nodes;
             
             
         }

         [WebMethod]
         public static System.Collections.Generic.List<DAL.DataObject.Node> PublishPhotoToThisWall(Int64 WallOwnerid, string WallOwnerName, Int64 MaxId, string fileName, string title, string description)
         {

             System.Collections.Generic.List<DAL.DataObject.Node> nodes = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();
             
             DAL.DataObject.Node nd;

             nd = new BDDoctors.DAL.DataObject.Node();
             nd.User_id = LoginHandler.LoggedInUser().Id.Value;
             nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
             if (WallOwnerid == 0 || WallOwnerid == -1)
             {
                 nd.Wall_Owner_id = LoginHandler.LoggedInUser().Id.Value;
                 nd.Wall_Owner_Name = LoginHandler.LoggedInUser().DisplayName;
             }
             else
             {
                 nd.Wall_Owner_id = WallOwnerid;
                 nd.Wall_Owner_Name = WallOwnerName;

             }
             nd.Attribute_id = 10;
             nd.Node_value = fileName;
             nd.Action_date = DateTime.Now;
             nodes.Add(nd);

             ///////////

             nd = new BDDoctors.DAL.DataObject.Node();
             nd.User_id = LoginHandler.LoggedInUser().Id.Value;
             nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
             if (WallOwnerid == 0 || WallOwnerid == -1)
             {
                 nd.Wall_Owner_id = LoginHandler.LoggedInUser().Id.Value;
                 nd.Wall_Owner_Name = LoginHandler.LoggedInUser().DisplayName;
             }
             else
             {
                 nd.Wall_Owner_id = WallOwnerid;
                 nd.Wall_Owner_Name = WallOwnerName;

             }
             nd.Attribute_id = 11;
             nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(title);
             nd.Action_date = DateTime.Now;
             nodes.Add(nd);

             /////////

             nd = new BDDoctors.DAL.DataObject.Node();
             nd.User_id = LoginHandler.LoggedInUser().Id.Value;
             nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
             if (WallOwnerid == 0 || WallOwnerid == -1)
             {
                 nd.Wall_Owner_id = LoginHandler.LoggedInUser().Id.Value;
                 nd.Wall_Owner_Name = LoginHandler.LoggedInUser().DisplayName;
             }
             else
             {
                 nd.Wall_Owner_id = WallOwnerid;
                 nd.Wall_Owner_Name = WallOwnerName;

             }
             nd.Attribute_id = 12;
             nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(description);
             nd.Action_date = DateTime.Now;
             nodes.Add(nd);








             Int64 parent_id = DAL.DataAccess.Node.SaveNodes(nodes);
             //nd.Parent_Node_Id = parent_id;

             return nodes;


         }
        [WebMethod]
         public static System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> GetUserFeed(Int64 WallOwnerid, Int64 MaxId)
         {

             if (WallOwnerid == 0)
             {
                 return DAL.DataAccess.Node.GetClubFriendsFeed(LoginHandler.LoggedInUser().Id.Value, null);
             }
             else if (WallOwnerid == -1)
             {
                 return DAL.DataAccess.Node.GetClubPublicFeed(null);
             }
             else
             {
                 return DAL.DataAccess.Node.GetClubUserFeed(WallOwnerid, null);
             }
            
             
             
         }
        //[WebMethod]
        //public static System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> GetUserFriendsFeed(Int64 WallOwnerid, Int64 MaxId)
        //{

        //    return DAL.DataAccess.Node.GetClubFriendsFeed(WallOwnerid, null);


        //}
        [WebMethod]
        public static DAL.DataObject.Node PostFeedComment(Int64 ParentId, string comment, Int64 WallOwnerId, string WallOwnerDisplayName)
        {
            try
            {
              //  DAL.DataObject.User WallOwner = DAL.DataAccess.User.GetUser(WallOwnerId);
                DAL.DataObject.Node nd;
                nd = new BDDoctors.DAL.DataObject.Node();
                nd.Parent_Node_Id = ParentId;
                nd.User_id = LoginHandler.LoggedInUser().Id.Value;
                nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
                nd.Wall_Owner_id = WallOwnerId;
                nd.Wall_Owner_Name = WallOwnerDisplayName;
                nd.Attribute_id = 1000;
                nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(comment);
                nd.Action_date = DateTime.Now;
                DAL.DataAccess.Node.SaveNode(nd);
                return nd;
            }
            catch(Exception e)
            {

                return null;
            }

          

        }
        [WebMethod]
        public static Int64 DeleteNode(Int64 NodeId)
        {
            try
            {
                DAL.DataAccess.Node.DeleteNodes(NodeId);
                return NodeId;
            }
            catch (Exception e)
            {

                return 0;
            }



        }
        [WebMethod]
        public static System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ShowTheOlderPostOfThisUser(Int64 WallOwnerid, Int64 MaxId)
        {

           // return DAL.DataAccess.Node.GetClubUserFeed(WallOwnerid, MaxId);
            if (WallOwnerid == 0)
            {
                return DAL.DataAccess.Node.GetClubFriendsFeed(LoginHandler.LoggedInUser().Id.Value, MaxId);
            }
            else if (WallOwnerid == -1)
            {
                return DAL.DataAccess.Node.GetClubPublicFeed(MaxId);
            }
            else
            {
                return DAL.DataAccess.Node.GetClubUserFeed(WallOwnerid, MaxId);
            }
            


        }

       
        [WebMethod]
        public static System.Collections.Generic.List<DAL.DataObject.User> SearchUser(string token, Int64 MaxId)
        {

            return DAL.DataAccess.User.SearchUser(token,MaxId);

        }
        [WebMethod]
        public static string SendInvitationEmail(string email, string Message)
        {

            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            //mail.To.Add(new MailAddress(DAL.Common.ToString(usr.Email)));
            mail.To.Add(new MailAddress(email));
            mail.From = new MailAddress("notification@dolbol.com");
            mail.Subject = "Someone has invite you to join dolbol";
            mail.Body = GetEmailBody(email,Message);
            
            SmtpClient sc = new SmtpClient();
            sc.Credentials = new System.Net.NetworkCredential("notification@dolbol.com", "correct");
            sc.Host = "ivy.arvixe.com";
            // this.UpdateProgress1.Visible = true;
            sc.Send(mail);
            //this.UpdateProgress1.Visible = false;
            return "Done";

        }
        private static string GetEmailBody(string  email,string message)
        {
            StringWriter writer = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
            Page pg = new Page();
            //ActivationEmailBody1.Visible = true;

            BDDoctors.Controls.InvitationEmailBody ctrl = (BDDoctors.Controls.InvitationEmailBody)pg.LoadControl("~/Controls/InvitationEmailBody.ascx");
            ctrl.Email = email;
            ctrl.Message = message;
            ctrl.RenderControl(htmlWriter);
            //ctrl.Dispose();
            // pg.Dispose();
            return writer.ToString();

        }
        [WebMethod]
        public static DateTime GetServerTime()
        {
            return DateTime.Now;
        }
        
        


        
        
    }
}

