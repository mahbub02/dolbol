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
using BDDoctors.DAL;
using BDDoctors;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BDDoctors.DAL.DataAccess
{
    public class RoomChatter
    {
        public static System.Collections.Generic.List<DAL.DataObject.RoomChatter> m_RoomUsers = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.RoomChatter>();
        public static void Dispose()
        {
            //m_Conversation.Clear();
            m_RoomUsers.Clear();
        }
        public static System.Collections.Generic.List<DAL.DataObject.RoomChatter> GetRoomChatters( Int64 roomId )
        {
            System.Collections.Generic.IEnumerable<DAL.DataObject.RoomChatter> RoomChatters = from DAL.DataObject.RoomChatter chtr in m_RoomUsers
                                                                                              where chtr.CurrentRoom == roomId && chtr.RefreshTime>DateTime.Now.AddSeconds(-25)
                                                                                           select chtr;

            return RoomChatters.ToList<DAL.DataObject.RoomChatter>();
        }

        public static void RemoveLoggedInUserFromThisRoom( Int64 RoomId)
        {
           //string room = LoginHandler.LoggedInUser().CurrentRoom;
            if (LoginHandler.IsLoggedIn == true && GetRoomChatters(RoomId).Exists(IsMatched) == true)
            {
                m_RoomUsers.RemoveAll(IsMatched);
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
        public static Boolean JoinAtRoom(DAL.DataObject.RoomChatter rchatter)
        {
            System.Collections.Generic.IEnumerable<DAL.DataObject.RoomChatter> RoomChatters = from DAL.DataObject.RoomChatter chtr in m_RoomUsers
                                                                                              where chtr.CurrentRoom == rchatter.CurrentRoom && chtr.Id.Value == rchatter.Id.Value
                                                                                              select chtr;

           
            if (RoomChatters.ToList<DAL.DataObject.RoomChatter>().Count == 0)
            {

                m_RoomUsers.Add(rchatter);
            }
            else {
                RoomChatters.ToList<DAL.DataObject.RoomChatter>()[0].Avatar = rchatter.Avatar;
            
            }
            return true;
        }

        public static void UpdateUserState(Int64 RoomId,string backPos,string top,string left,string userText)
        {
           
            System.Collections.Generic.IEnumerable<DAL.DataObject.RoomChatter> RoomChatters = from DAL.DataObject.RoomChatter chtr in m_RoomUsers
                                                                                              where chtr.CurrentRoom.Value == RoomId && chtr.Id.Value == LoginHandler.LoggedInUser().Id.Value
                                                                                              select chtr;

            if (RoomChatters.ToList<DAL.DataObject.RoomChatter>().Count == 1)
            {
                foreach (DAL.DataObject.RoomChatter roomChtr in RoomChatters.ToList<DAL.DataObject.RoomChatter>())
                {
                    roomChtr.BackGroundPosition = backPos;
                    roomChtr.Top = top;
                    roomChtr.Left = left;
                    roomChtr.RefreshTime = DateTime.Now;
                    if (userText.Length > 0)
                    {
                        roomChtr.Message = userText;
                        roomChtr.SentTime = DateTime.Now;
                    }
                }
            }

            
        }
        //public static void IsHeAlreadyInThisChatRoom(Int64 RoomId)
        //{

        //    System.Collections.Generic.IEnumerable<DAL.DataObject.RoomChatter> RoomChatters = from DAL.DataObject.RoomChatter chtr in m_RoomUsers
        //                                                                                      where chtr.Id.Value == LoginHandler.LoggedInUser().Id.Value && chtr.CurrentRoom == RoomId
        //                                                                                      select chtr;

        //    if (RoomChatters.ToList<DAL.DataObject.RoomChatter>().Count == 1)
        //    {
        //        foreach (DAL.DataObject.RoomChatter roomChtr in RoomChatters.ToList<DAL.DataObject.RoomChatter>())
        //        {
        //            roomChtr.BackGroundPosition = backPos;
        //            roomChtr.Top = top;
        //            roomChtr.Left = left;
        //        }
        //    }


        //}

       
    }
}
