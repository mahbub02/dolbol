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
    public partial class ComposeEmail : System.Web.UI.UserControl
    {
        private Boolean AmIThePageOwner()
        {
            if (LoginHandler.IsLoggedIn && PageOwner() == LoginHandler.LoggedInUser().Id)
            {
                return true;
            }
            else
            {
                return false;
            }
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
                user_id = Convert.ToInt64(LoginHandler.LoggedInUser().Id);
            }
            return user_id;
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
           
            DAL.DataObject.User usr = DAL.DataAccess.User.GetUser(PageOwner());
            txtTo.Text = usr.DisplayName;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if(txtMessage.Text.Trim().Length==0)
            {
                lblErrorMessage.Text="Enter Message";
            }
            DAL.DataObject.Email eml=new BDDoctors.DAL.DataObject.Email();
            eml.Sender_Id=LoginHandler.LoggedInUser().Id.Value;
            eml.Reciever_Id=PageOwner();
            eml.Subject=txtSubject.Text;
            eml.Message=txtMessage.Text;
            DAL.DataAccess.Email.SaveEmail(eml);
            ulCompose.Visible = false;
            lblErrorMessage.Text = "Email Successfully sent";
        }
    }
}