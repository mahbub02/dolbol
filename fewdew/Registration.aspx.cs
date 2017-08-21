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
using System.Web.Services;
using System.Net.Mail;
using System.IO;
namespace BDDoctors
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request["invitedby"]) == true)
            {
                invitedBy.Value = "0";
            }
            else {
                invitedBy.Value = Convert.ToString(Request["invitedby"]);
            }

            
        }
        [WebMethod]
        public static string IsThisDisplayNameAvailable(string displayName)
        {
            if (DAL.DataAccess.User.GetUserByDisplayName(displayName) == null)
            {
                return "YES";
            }
            else {
                return "NO";
            }
           
        }
        [WebMethod]
        public static string IsThisEmailAddressAvailable(string EmailAddress)
        {
            if (DAL.DataAccess.User.GetUser(EmailAddress) == null)
            {
                return "YES";
            }
            else
            {
                return "NO";
            }

        }
        [WebMethod]
        public static string CreateAccountAndSendActivationEmail(string displayName, string email, string password, string sex, string birthdate, string avatar,Int64 invitedBy)
        {
            DAL.DataObject.User usr = new BDDoctors.DAL.DataObject.User();
            usr.DisplayName = displayName;
            usr.Email = email;
            usr.Password = password;
            usr.Status = 0;
            usr.BirthDay = Convert.ToDateTime(birthdate);
            if (sex == "female")
            {
                usr.Sex = false;

            }
            else {
                usr.Sex = true;
            }
            avatar = avatar.ToLower();

           
             if (avatar.Contains("female"))
            {
                usr.AvatarName = avatar.Replace("sample/female/", "");
            }
             else if (avatar.Contains("male"))
            {
                usr.AvatarName = avatar.Replace("sample/male/", "");
            }

            
           

            usr.ActivationKey = Convert.ToString(DateTime.Now.Millisecond.ToString().GetHashCode());
            if (DAL.DataAccess.User.SaveUser(usr))
            {
                try
                {
                    SendEmail(usr);
                    if (invitedBy > 0)
                    {
                        DAL.DataObject.User Requester = new BDDoctors.DAL.DataObject.User();
                        Requester = DAL.DataAccess.User.GetUser(invitedBy);

                        DAL.DataObject.FriendShip frnship = new DAL.DataObject.FriendShip();
                        frnship.User1 = Requester.Id;
                        frnship.User2 = usr.Id;
                        frnship.Status = 0;
                        frnship.ActionDate = DateTime.Now;
                        DAL.DataAccess.FriendShip.SaveFriendShip(frnship);
                    }

                    return "YES";
                }
                catch (Exception e)
                {
                   
                    usr.Status = 0;
                    DAL.DataAccess.User.SaveUser(usr);
                    return "NO";
                 }
            }
            return "";
        }
        private static void SendEmail(DAL.DataObject.User usr)
        {


            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.To.Add(new MailAddress(DAL.Common.ToString(usr.Email)));
            mail.From = new MailAddress("_@gamecookstudio.com");
            mail.Subject = "Welcome to DolBol";
            mail.Body = GetEmailBody(usr);
            SmtpClient sc = new SmtpClient();
            sc.Credentials = new System.Net.NetworkCredential("__@gamecookstudio.com", "");
            sc.Host = "ivy.arvixe.com";
            sc.Send(mail);

        }
        private static string  GetEmailBody(DAL.DataObject.User usr)
        {
            StringWriter writer = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
            Page pg = new Page();
            //ActivationEmailBody1.Visible = true;

            BDDoctors.Controls.ActivationEmailBody ctrl = (BDDoctors.Controls.ActivationEmailBody)pg.LoadControl("~/Controls/ActivationEmailBody.ascx");
            ctrl.User = usr;
            ctrl.RenderControl(htmlWriter);
            //ctrl.Dispose();
            // pg.Dispose();
            return writer.ToString();

        }

    }
}
