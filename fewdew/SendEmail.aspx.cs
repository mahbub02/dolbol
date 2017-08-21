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
    public partial class SendEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                txtTo.Text = DAL.DataAccess.User.GetUser(Convert.ToInt64(Request["user_id"])).DisplayName;
            }

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text.Trim().Length == 0)
            {
                lblValidationMessage.Text = "Enter Message";
                lblValidationMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                lblValidationMessage.Text = "";
            }
            DAL.DataObject.Email eml = new BDDoctors.DAL.DataObject.Email();
            eml.Sender_Id = LoginHandler.LoggedInUser().Id.Value;
            eml.Reciever_Id = Convert.ToInt64(Request["user_id"]);
            eml.Subject = txtSubject.Text;
            eml.Message = txtMessage.Text;
            DAL.DataAccess.Email.SaveEmail(eml);
            txtMessage.Text = "";
            txtSubject.Text = "";
            lblValidationMessage.Text = "Email Successfully sent";
            lblValidationMessage.ForeColor = System.Drawing.Color.Green;
            // divSendEmail.Style.Add("height", "20px");

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "";
            txtSubject.Text = "";
           
        }

    }
}
