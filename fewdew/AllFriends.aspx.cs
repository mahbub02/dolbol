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

namespace BDDoctors
{
    public partial class AllFriends : System.Web.UI.Page
    {
        private System.Collections.Generic.List<DAL.DataObject.Friend> m_FriendList = null;

        protected System.Collections.Generic.List<DAL.DataObject.Friend> ListOfFriend
        {
            get
            {
                if (m_FriendList == null)
                {
                    m_FriendList = DAL.DataAccess.FriendShip.GetFriendList(PageOwner());

                }
                return m_FriendList;

            }
            set { m_FriendList = null; }
        }

        private Int64 PageOwner()
        {
            Int64 user_id = 0;
            if (Request["user"] != null)
            {
                user_id = Convert.ToInt64(Request["user"]);
            }
            if (user_id == 0)
            {
                if (LoginHandler.IsLoggedIn == true)
                {
                    user_id = Convert.ToInt64(LoginHandler.LoggedInUser().Id);
                }

            }
            return user_id;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack == false)
            {
                System.Collections.Generic.List<DAL.DataObject.Friend> frndList = DAL.DataAccess.FriendShip.GetFriendList(PageOwner());
               
                GridAllFriend.DataSource = frndList;
                GridAllFriend.DataBind();
            }

        }

        protected void GridAllFriend_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridAllFriend.PageIndex = e.NewPageIndex;
            System.Collections.Generic.List<DAL.DataObject.Friend> frndList = DAL.DataAccess.FriendShip.GetFriendList(PageOwner());

            GridAllFriend.DataSource = frndList;
            GridAllFriend.DataBind();
     
        }
    }
}
