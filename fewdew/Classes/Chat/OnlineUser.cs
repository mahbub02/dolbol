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
    public class OnlineUser
    {
        #region "Online User"
        private static System.Collections.Generic.List<DAL.DataObject.OnlineUser> m_OnlineUser = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.OnlineUser>();
        public static void OnlineUserDispose()
        {
            m_OnlineUser.Clear();
           //m_OnlineUser.Clear();
        }
        public static System.Collections.Generic.List<DAL.DataObject.OnlineUser> GetOnlineUser()
        {
            System.Collections.Generic.IEnumerable<DAL.DataObject.OnlineUser> UserList = from DAL.DataObject.OnlineUser onUser in m_OnlineUser
                                                                                           where  onUser.LastRefreshTime>DateTime.Now.AddMinutes(-1) && onUser.Id.Value!=LoginHandler.LoggedInUser().Id.Value
                                                                                           select onUser;

            return UserList.ToList<DAL.DataObject.OnlineUser>();
           
        }
        public static void RefreshUser(Int64 UserId)
        {

            System.Collections.Generic.IEnumerable<DAL.DataObject.OnlineUser> Users = from DAL.DataObject.OnlineUser usr in m_OnlineUser
                                                                                where usr.Id.Value == UserId
                                                                                select usr;

            if (Users.ToList<DAL.DataObject.OnlineUser>().Count == 1)
            {
                foreach (DAL.DataObject.OnlineUser usr in Users.ToList<DAL.DataObject.OnlineUser>())
                {
                    usr.LastRefreshTime = DateTime.Now;
                }
            }
            else if (Users.ToList<DAL.DataObject.OnlineUser>().Count < 1)
            {
                DAL.DataObject.OnlineUser onlineUser = new BDDoctors.DAL.DataObject.OnlineUser();
                onlineUser.Id = LoginHandler.LoggedInUser().Id.Value;
                onlineUser.DisplayName = LoginHandler.LoggedInUser().DisplayName;
                onlineUser.LastRefreshTime = DateTime.Now;
                AddUserAtOnlineUserList(onlineUser);
            }
            else {
                RemoveTheLoggedInUserFromOnlineUserList();
            }
            


        }
        public static void AddUserAtOnlineUserList(DAL.DataObject.OnlineUser user)
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
        private static bool IsMatched(DAL.DataObject.OnlineUser usr)
        {
            if (usr.Id.Value == LoginHandler.LoggedInUser().Id.Value)
            {
                return true;
            }
            else { return false; }
        }
        public static bool isOnline(Int64 userId)
        {
            System.Collections.Generic.IEnumerable<DAL.DataObject.OnlineUser> OnlineUserList = from DAL.DataObject.OnlineUser Usr in GetOnlineUser()
                                                                                where Usr.Id.Value ==userId
                                                                                  select Usr;
            
            if(OnlineUserList.ToList<DAL.DataObject.OnlineUser>().Count>0)
            {
                return true;
            }
            else{
            return false;
            }

        }
        #endregion 

        
    }
}
