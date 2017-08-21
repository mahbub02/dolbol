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

namespace BDDoctors.Pages
{
    public partial class FriendshipRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Collections.Generic.List<DAL.DataObject.Friend> frndlist = DAL.DataAccess.FriendShip.GetFriendAwaitingForMyResponse(LoginHandler.LoggedInUser().Id.Value);
             foreach (DAL.DataObject.Friend frnd in frndlist)
             {
                 BDDoctors.Controls.FriendShipRequest cntrl = (BDDoctors.Controls.FriendShipRequest)this.LoadControl("~/Controls/FriendShipRequest.ascx");
                 cntrl.Friend = frnd;
                 dvRequestContainer.Controls.Add(cntrl);
             }

        }
    }
}
