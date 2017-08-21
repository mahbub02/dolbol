using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace BDDoctors
{
    public class ChatAndOnlineUser
    {
        #region "Online User"
        private static System.Collections.Generic.List<DAL.DataObject.User> m_OnlineUser = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.User>();
        public static void Dispose()
        {
            m_Conversation.Clear();
           //m_OnlineUser.Clear();
        }
        public static System.Collections.Generic.List<DAL.DataObject.User> GetOnlineUser()
        {
            System.Collections.Generic.IEnumerable<DAL.DataObject.User> UserList = from DAL.DataObject.User onUser in m_OnlineUser
                                                                                           where  onUser.LastRefreshTime>DateTime.Now.AddMinutes(-1) && onUser.Id.Value!=LoginHandler.LoggedInUser().Id.Value
                                                                                           select onUser;

            return UserList.ToList<DAL.DataObject.User>();
           
        }
        public static void RefreshUser(Int64 UserId)
        {

            System.Collections.Generic.IEnumerable<DAL.DataObject.User> Users = from DAL.DataObject.User usr in m_OnlineUser
                                                                                where usr.Id.Value == UserId
                                                                                select usr;

            if (Users.ToList<DAL.DataObject.User>().Count == 1)
            {
                foreach (DAL.DataObject.User usr in Users.ToList<DAL.DataObject.User>())
                {
                    usr.LastRefreshTime = DateTime.Now;
                }
            }
            //else 
            //{
            //    AddUserAtOnlineUserList(LoginHandler.LoggedInUser());
            //}


        }
        public static void AddUserAtOnlineUserList(DAL.DataObject.User user)
        {
            if (GetOnlineUser().Exists(IsMatched)==false)
            {
                user.LastRefreshTime = DateTime.Now;
                m_OnlineUser.Add(user);
            }
            
        }

        public static void RemoveTheLoggedInUserFromOnlineUserList()
        {
            if (LoginHandler.IsLoggedIn == true && GetOnlineUser().Exists(IsMatched) == true)
            { 
            m_OnlineUser.RemoveAll(IsMatched);
            }
        }
        private static bool IsMatched(DAL.DataObject.User usr)
        {
            if (usr.Id.Value == LoginHandler.LoggedInUser().Id.Value)
            {
                return true;
            }
            else { return false; }
        }
        public static bool isOnline(Int64 userId)
        {
            System.Collections.Generic.IEnumerable<DAL.DataObject.User> OnlineUserList = from DAL.DataObject.User Usr in GetOnlineUser()
                                                                                where Usr.Id.Value ==userId
                                                                                  select Usr;
            
            if(OnlineUserList.ToList<DAL.DataObject.User>().Count>0)
            {
                return true;
            }
            else{
            return false;
            }

        }
        #endregion 

        #region "Conversation"
        private static System.Collections.Generic.List<DAL.DataObject.Conversation> m_Conversation = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Conversation>();
        public static System.Collections.Generic.List<DAL.DataObject.Conversation> GetConversations
        {
            get { return m_Conversation; }
            set { }
        }
        public static void AddConversationToTheConversationList(DAL.DataObject.Conversation conv)
        {
            DAL.DataObject.Conversation maxConv = m_Conversation.Max();
            if (maxConv == null)
            {
                conv.Id = 1;
            }
            else
            {
                conv.Id = maxConv.Id.Value + 1;
                
            }
            m_Conversation.Add(conv);
        }
        public static void RemoveConversationFromConversationList()
        {
            if (LoginHandler.IsLoggedIn == true)
            {
                m_Conversation.RemoveAll(IsExpired);
            }
        }
        private static bool IsExpired(DAL.DataObject.Conversation conv)
        {
            if (conv.Action_date<DateTime.Now.AddMinutes(1) && conv.IsDelivered==true)
            {
                return true;
            }
            else { return false; }
        }
        public static System.Collections.Generic.List<DAL.DataObject.Conversation> GetMyConversationWithThisUser(Int64 UserId)
        {
            System.Collections.Generic. IEnumerable<DAL.DataObject.Conversation> ConvList = from DAL.DataObject.Conversation cnv in m_Conversation
                                                                                            where ((cnv.Sender_id.Value == LoginHandler.LoggedInUser().Id.Value && cnv.Reciever_id != null && cnv.Reciever_id.Value == UserId) || (cnv.Reciever_id != null&& cnv.Reciever_id.Value == LoginHandler.LoggedInUser().Id.Value && cnv.Sender_id.Value == UserId)) && cnv.Message.Length > 0
                                                                                   select cnv;
           
         return  ConvList.ToList<DAL.DataObject.Conversation>();
          
        }
        public static System.Collections.Generic.List<Int64> GetUserInMyCurrentChatList()
        {
            System.Collections.Generic.IEnumerable<Int64> DistinctRecieverIds = (from DAL.DataObject.Conversation cnv in m_Conversation
                                                                     where cnv.Sender_id.Value == LoginHandler.LoggedInUser().Id.Value && cnv.Room_id==null
                                                                     select cnv.Reciever_id.Value).Distinct();
            System.Collections.Generic.IEnumerable<Int64> DistinctSenderIds = (from DAL.DataObject.Conversation cnv in m_Conversation
                                                                                 where cnv.Reciever_id!=null && cnv.Reciever_id.Value == LoginHandler.LoggedInUser().Id.Value && cnv.Room_id==null && cnv.Message.Length>0
                                                                                 select cnv.Sender_id.Value).Distinct();



            return DistinctRecieverIds.Union(DistinctSenderIds).ToList<Int64>();
        }

        public static System.Collections.Generic.List<DAL.DataObject.Conversation> GetConversationAtThisRoom(Int64 roomId, Int64 afterThatId)
        {
            System.Collections.Generic.IEnumerable<DAL.DataObject.Conversation> ConvList = from DAL.DataObject.Conversation cnv in m_Conversation
                                                                                           where (cnv.Room_id !=null && cnv.Room_id.Value ==roomId && cnv.Message.Length>0 && cnv.Id>afterThatId)
                                                                                           select  cnv;

            return ConvList.ToList<DAL.DataObject.Conversation>();

        }
        public static Int64 GetMaxRoomConversationId(Int64 room)
        {
            System.Collections.Generic.IEnumerable<Nullable<Int64>> Ids = from DAL.DataObject.Conversation cnv in m_Conversation
                                                                                 where (cnv.Room_id==room)
                                                                                 select cnv.Id;
            Nullable<Int64> MaxId = 0;
            if (Ids != null)
            {
                MaxId= Ids.Max();
            }
            if (MaxId == null)
            {
                return 0;
            }
           
            return MaxId.Value;
        }

        #endregion
    }
}
