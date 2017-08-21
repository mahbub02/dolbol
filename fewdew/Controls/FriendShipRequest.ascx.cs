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

namespace BDDoctors.Controls
{
    public partial class FriendShipRequest : System.Web.UI.UserControl
    {
        private Int64 RequesterId
        {
            get { return Convert.ToInt64( ViewState["Requested"]); }
            set { ViewState["Requested"] = value; }
        }
        private DAL.DataObject.Friend m_Friend;
        public DAL.DataObject.Friend Friend
        {
            get { return m_Friend; }
            set { m_Friend = value;
            RequesterId = m_Friend.UserId.Value;
            }
        }
      

        protected void lbtnAccept_Click(object sender, EventArgs e)
        {
            DAL.DataObject.FriendShip frndshp = new BDDoctors.DAL.DataObject.FriendShip();
            frndshp.User1 = LoginHandler.LoggedInUser().Id;
            frndshp.User2 = RequesterId;
            frndshp.Status = 1;
            if (DAL.DataAccess.FriendShip.SaveFriendShip(frndshp))
            {
                dvrequestDetails.InnerHtml = "has become your friend";
               
            }
        }

        protected void lbtnReject_Click(object sender, EventArgs e)
        {
           
            DAL.DataAccess.FriendShip.DeleteFriendShip(RequesterId, LoginHandler.LoggedInUser().Id.Value);
            dvrequestDetails.InnerHtml = " His Friendship request in rejected";
        }
    }
}