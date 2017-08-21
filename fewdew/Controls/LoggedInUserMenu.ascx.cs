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
    public partial class LoggedInUserMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Page.IsPostBack == false)
            {
                if (LoginHandler.IsLoggedIn == true)
                {
                    DAL.DataObject.User usr = LoginHandler.LoggedInUser();
                    lbluserName.Text = "Welcome!  " + usr.DisplayName;
                    DAL.DataAccess.FriendShip.NumberOfFriendRequest(usr.Id.Value);
                    Int64 Count = 0;
                    Count = DAL.DataAccess.FriendShip.NumberOfFriendRequest(usr.Id.Value);
                    if (Count > 0)
                    {
                        spnRequest.InnerText = spnRequest.InnerText + "(" + Count.ToString() + ")";
                    }
                    Count = 0;
                    Count = DAL.DataAccess.Email.NumberOfUnreadMessageAtInbox(usr.Id.Value);
                    if (Count > 0)
                    {
                        spnEmail.InnerText = spnEmail.InnerText + "(" + Count.ToString() + ")";
                    }
                    DvForLoggedInUser.Visible = true;
                    DvForNotLoggedInUser.Visible = false;
                }
                else 
                {
                    lbtnSignOut.Visible = false;
                    lbluserName.Visible = false;
                    //hlinkHome.Visible = false;
                    //hlinkRequest.Visible = false;
                    //hlinkProfile.Visible = false;
                    //hlinkEmail.Visible = false;
                    //hlinkBlog.Visible = false;
                    //hlinkChatRoom.Visible = false;
                    //hlinkTreatmentPanel.Visible = false;
                }
            }
            

        }

       

        protected void lbtnSignOut_Click(object sender, EventArgs e)
        {
            BDDoctors.LoginHandler.DoLogOut();
            
        }

        
    }
}