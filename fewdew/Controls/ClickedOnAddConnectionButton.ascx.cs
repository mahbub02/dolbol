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
using BDDoctors;


namespace BDDoctors.Controls
{
    public partial class ClickedOnAddConnectionButton : System.Web.UI.UserControl
    {
       
        public string User2Name
        {
            get {
                DAL.DataObject.User usr = DAL.DataAccess.User.GetUser(User2Id);
                return usr.DisplayName;
            }
        }
        public Int64 User2Id
        {
            get { return Convert.ToInt64(ViewState["User2Id"]); }
            set { ViewState["User2Id"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddAsConnection_Click(object sender, EventArgs e)
        {
          
                DAL.DataObject.FriendShip frndshp = new BDDoctors.DAL.DataObject.FriendShip();
                frndshp.User1 = LoginHandler.LoggedInUser().Id;
                frndshp.User2 = User2Id;
                frndshp.Status = 0;
                DAL.DataAccess.FriendShip.SaveFriendShip(frndshp);
                DAL.DataObject.Friend frnd = new BDDoctors.DAL.DataObject.Friend();
                frnd.UserId = User2Id;
                frnd.ActionDate = DateTime.Now;
                frnd.Status = 0;
                frnd.DisplayName = LoginHandler.LoggedInUser().DisplayName.ToString();
                LoginHandler.AddFriendToLoggedInUserFriendList(frnd);
                this.Visible = false;
           
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

    }
}