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
using BDDoctors.DAL;


namespace BDDoctors
{
    public class LoginHandler
    {
        private const string LOGIN_SESSION_KEY = "LOGGED_IN_USER";
        private const string LOGGED_IN_USER_FRINEDS = "LOGGED_IN_USER_FRIEND";
        private static System.Web.HttpContext Context
        {
            get { return System.Web.HttpContext.Current; }
        }

        private static System.Web.SessionState.HttpSessionState Session
        {
            get
            {
                if ((Context != null))
                {
                    return Context.Session;
                }
                return null;
            }
        }

        private static System.Web.HttpResponse Response
        {
            get
            {
                if ((Context != null))
                {
                    return Context.Response;
                }
                return null;
            }
        }

        public static bool IsLoggedIn
        {
            get
            {
                DAL.DataObject.User usr = (DAL.DataObject.User)Session[LOGIN_SESSION_KEY];
                if (usr == null)
                {
                    return false;
                }
                else { return true; }
                //return (LoggedInUser() != null);
            }
        }

        public static bool DoLogin(string Email, string Password)
        {
            DAL.DataObject.User usr= BDDoctors.DAL.DataAccess.User.GetUser(Email);

            if (usr != null && string.Compare(usr.Password, Password) == 0&& usr.Status==1)
            {
                Session[LOGIN_SESSION_KEY] = usr;
                BDDoctors.ChatAndOnlineUser.AddUserAtOnlineUserList(LoginHandler.LoggedInUser());
                Session[LOGGED_IN_USER_FRINEDS]= DAL.DataAccess.FriendShip.GetFriendListUnionAwaitingForResponse(usr.Id.Value);
                return true;
            }
            else { return false;}
           
        }
        public static bool DoLoginWithPersona(DAL.DataObject.User persona)
        {

                //  BDDoctors.DAL.DataAccess.RoomChatter.RemoveLoggedInUserFromHisCurrentChatRoom();
                BDDoctors.ChatAndOnlineUser.RemoveTheLoggedInUserFromOnlineUserList();
                
                Session[LOGIN_SESSION_KEY] = persona;
                BDDoctors.ChatAndOnlineUser.AddUserAtOnlineUserList(LoginHandler.LoggedInUser());
                Session[LOGGED_IN_USER_FRINEDS] = DAL.DataAccess.FriendShip.GetFriendListUnionAwaitingForResponse(LoginHandler.LoggedInUser().Id.Value);
                
                return true;
           

        }



        public static void DoLogOut()
        {
            if (IsLoggedIn)
            {
               // UserFactory.RemoveUserFromUserList(LogInHandler.LoggedInUser());
                BDDoctors.ChatAndOnlineUser.RemoveTheLoggedInUserFromOnlineUserList();
                Session[LOGIN_SESSION_KEY] = null;
                Session[LOGGED_IN_USER_FRINEDS] = null;
               
            }
            Control cntrl = new Control();
            Response.Redirect(cntrl.ResolveClientUrl("~\\Default.aspx"));
            //Response.Redirect(ResolveClientUrl("~\\Login.aspx"));
           
        }

       
        public static System.Collections.Generic.List<DAL.DataObject.Friend> GetLoggedInUserFriends()
        {
            return (System.Collections.Generic.List<DAL.DataObject.Friend>)Session[LOGGED_IN_USER_FRINEDS];
        }
        public static void AddFriendToLoggedInUserFriendList( DAL.DataObject.Friend frnd )
        {
            System.Collections.Generic.List<DAL.DataObject.Friend> frndList = ((System.Collections.Generic.List<DAL.DataObject.Friend>)Session[LOGGED_IN_USER_FRINEDS]);
            frndList.Add(frnd);
            Session[LOGGED_IN_USER_FRINEDS] = frndList;
        }

        public static DAL.DataObject.User LoggedInUser()
        {
            try
            {
                DAL.DataObject.User usr= (DAL.DataObject.User)Session[LOGIN_SESSION_KEY];
                if (usr == null)
                {
                    Control cntrl = new Control(); 
                    Response.Redirect(cntrl.ResolveClientUrl("~\\Default.aspx"));
                    
                }
                return usr;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
