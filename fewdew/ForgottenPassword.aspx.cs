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
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.IO;

namespace BDDoctors.Controls
{
    public partial class ForgottenPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (txtEmail.Text.Trim().Length > 0)
            {
                Regex reg = new Regex(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
                if (reg.IsMatch(txtEmail.Text) == false)
                {
                    lblCredentialValidator.Text = "Enter valid email address";
                    return;

                }
                else
                {
                    lblCredentialValidator.Text = "";
                }
            }
            else 
            {
                lblCredentialValidator.Text = "Enter your account's email"; return;
            }

              DAL.DataObject.User usr=DAL.DataAccess.User.GetUser(txtEmail.Text.Trim());
              if (usr != null)
              {
                  try
                  {
                      SendEmail(usr);
                  }
                  catch { }
                  finally { UlForgottenPassword.Visible = false; lblCredentialValidator.Text = "Email with password has been sent, Please check your email to find your password"; }
              }
              else { lblCredentialValidator.Text = "Wrong email address"; }



        }

        private void SendEmail(DAL.DataObject.User usr)
        {
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.To.Add(new MailAddress(DAL.Common.ToString(usr.Email)));
            mail.From = new MailAddress("mahbub@surroundapps.com");
            mail.Subject = "Welcome to games.jagajag.com";
            mail.Body = GetEmailBody(usr);
            SmtpClient sc = new SmtpClient();
            sc.Credentials = new System.Net.NetworkCredential("mahbub+surroundapps.com", "mahbub1");
            sc.Host = "mail.surroundapps.com";
            // this.UpdateProgress1.Visible = true;
            sc.Send(mail);
            //this.UpdateProgress1.Visible = false;

        }
        private string GetEmailBody(DAL.DataObject.User usr)
        {
            StringWriter writer = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
            Page pg = new Page();
            ForgottenPasswordEmailBody ctrl = (ForgottenPasswordEmailBody)pg.LoadControl("~/Conrols/ActivationEmailBody.ascx");
            ctrl.User = usr;
            ctrl.RenderControl(htmlWriter);
            ctrl.Dispose();
            pg.Dispose();
            return writer.ToString();

        }

    }
}
