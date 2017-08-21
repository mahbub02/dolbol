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
    public partial class Signup : System.Web.UI.UserControl
    {
        protected string TypedPassword
        {
            get{
                if (ViewState["TypedPassword"] != null){
                    return Convert.ToString(ViewState["TypedPassword"]);
                }
                return null;
            }
            set{
                ViewState["TypedPassword"] = value;
            }
        }
        protected string ReTypedPassword{
            get{
               if (ViewState["ReTypedPassword"] != null){
                    return Convert.ToString(ViewState["ReTypedPassword"]);
                }
                return null;
               }
            set{
                ViewState["ReTypedPassword"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ResetPasswordFields();
        }

        private void ResetPasswordFields(){
            if (txtPassword.Text.Length != 0){
                TypedPassword = txtPassword.Text;
                txtPassword.Text = TypedPassword;
            }
            else{
                txtPassword.Attributes.Add("Value", TypedPassword);
            }

            if (txtRePassword.Text.Length != 0){
                ReTypedPassword = txtRePassword.Text;
                txtRePassword.Text = ReTypedPassword;
            }
            else{
                txtRePassword.Attributes.Add("Value", ReTypedPassword);
            } 
        }
        private Boolean ValidateCaptchat()
        {

            Captcha1.ValidateCaptcha(txtCaptcha.Text.Trim());

            if (Captcha1.UserValidated)
            {
                lblCaptchaValidator.Text = "";
                return true;

            }

            else
            {
                lblCaptchaValidator.Text = "The characters you entered didn't match the word verification. Please try again";
                return false;

            }
            return false;
        }
        private void ValidateAndSaveAndSendEmail()
        {

            if (EmailValidate() & PasswordValidate() & DisplayNameValidate() & ValidateCaptchat())
            {// & BMDCnumberValidator()
                DAL.DataObject.User usr = new BDDoctors.DAL.DataObject.User();
                DAL.DataObject.User fetchedUser = DAL.DataAccess.User.GetUser(txtEmail.Text);
                if (fetchedUser != null)
                {
                    usr.Id = fetchedUser.Id;
                }
                else { usr.Id = null; }
                usr.Email = txtEmail.Text;
                usr.Password = txtPassword.Text;
                usr.DisplayName = txtDisplayName.Text;
                //usr.BMDCnumber = txtBMDCRegNo.Text;
                usr.Status = 0;
                usr.ActivationKey = Convert.ToString(DateTime.Now.Millisecond.ToString().GetHashCode());

                dvMessageBoard.Visible = true;
                dvSigupControlHolder.Visible = false;

                if (DAL.DataAccess.User.SaveUser(usr))
                {
                    try
                    {
                        SendEmail(usr);
                        dvMessageBoard.Visible = true;
                        dvSigupControlHolder.Visible=false;
                        lblmessageBoard.Text="Email with activation code is sent to "+usr.Email.ToString()+" Check your mail please<br/>. Check the spam folder if you didn't get the activation mail in your inbox.";
           
                    }
                    catch(Exception e)
                    {
                        dvMessageBoard.Visible = true;
                        usr.Status = 0;
                        DAL.DataAccess.User.SaveUser(usr);
                        Response.Write("Operation Failed, Try Again");
                        dvMessageBoard.Visible = true;
                        dvSigupControlHolder.Visible=false;
                        lblmessageBoard.Text = "Email with activation code Sending failed, Please try again with different email address";
                    }
                }
                else {
                     dvMessageBoard.Visible = true;
                        dvSigupControlHolder.Visible=false;
                    lblmessageBoard.Text="Operation Failed, Try Again";
                   
                }

            }
            
        }

        //private Boolean BMDCnumberValidator()
        //{
        //    if (txtBMDCRegNo.Text.Length == 0)
        //    {
        //        lblBMDCRegNoValidator.Text = "Enter BMDC Reg: NO:";
        //        return false;
        //    }
        //    else
        //    {
        //        lblBMDCRegNoValidator.Text = "";
        //    }
        //    return true;
        //}

        private Boolean DisplayNameValidate()
        {
            if (txtDisplayName.Text.Length == 0)
            {
                lblDisplayValidator.Text = "Enter Display Name";
                return false;
            }
            else
            {
                lblDisplayValidator.Text = "";
            }
            if (txtDisplayName.Text.Length < 3)
            {
                lblDisplayValidator.Text = "Minimum 3 character";
                return false;
            }
            else
            {
                lblDisplayValidator.Text = "";
            }
            return true;
        }

        private Boolean PasswordValidate()
        {
            if (txtPassword.Text.Length == 0){
                lblPasswordValidator.Text = "Enter password";
                return false;
            }
            else {
                lblPasswordValidator.Text = "";
            }
            if (txtPassword.Text.Length <6 ){
                lblPasswordValidator.Text = "Minimum 6 character";
                return false;
            }
            else{
                lblPasswordValidator.Text = "";
            }
            if (txtRePassword.Text.Length == 0){
                lblRepasswordValidator.Text = "Re enter password";
                return false;
            }
            else{
                lblRepasswordValidator.Text = "";
            }
            if (txtPassword.Text != txtRePassword.Text){
                lblRepasswordValidator.Text = "Password mismatch";
                return false;
            }
            return true;

        }

        private Boolean EmailValidate(){
            Regex reg = new Regex(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
            if (reg.IsMatch(txtEmail.Text) == false){
                    lblEmailValidator.Text = "Enter valid email address";
                    return false;
                }
            else {
                lblEmailValidator.Text = ""; 
            }

           DAL.DataObject.User usr=BDDoctors.DAL.DataAccess.User.GetUser(txtEmail.Text);
           if (usr != null && usr.Status == 1)
           {
               lblEmailValidator.Text = "It is already taken by someone";
               return false;
           }
           else {
               lblEmailValidator.Text = "";
           }

           return true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            txtRePassword.Attributes.Add("Value", ReTypedPassword);
            txtPassword.Attributes.Add("Value", TypedPassword);
            ValidateAndSaveAndSendEmail();
        }
        private void SendEmail(DAL.DataObject.User usr)
        {
           // MailMessage mail = new MailMessage();
           // mail.IsBodyHtml = true;
           // mail.To.Add(new MailAddress(DAL.Common.ToString(usr.Email)));
           // mail.From = new MailAddress("mahbub@surroundapps.com");
           // mail.Subject = "Welcome to fewdew";
           // mail.Body = GetEmailBody(usr);
           // SmtpClient sc = new SmtpClient();
           // sc.Credentials = new System.Net.NetworkCredential("mahbub+surroundapps.com", "mahbub1");
           // sc.Host = "mail.surroundapps.com";
           //// this.UpdateProgress1.Visible = true;
           // sc.Send(mail);
           // //this.UpdateProgress1.Visible = false;

            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.To.Add(new MailAddress(DAL.Common.ToString(usr.Email)));
            mail.From = new MailAddress("admin@dolbol.com");
            mail.Subject = "Welcome to dolbol";
            mail.Body = GetEmailBody(usr);
            SmtpClient sc = new SmtpClient();
            sc.Credentials = new System.Net.NetworkCredential("admin@dolbol.com", "correct");
            sc.Host = "ivy.arvixe.com";
            // this.UpdateProgress1.Visible = true;
            sc.Send(mail);
            //this.UpdateProgress1.Visible = false;

        }
        private string GetEmailBody(DAL.DataObject.User usr)
        {
            StringWriter writer = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
            Page pg = new Page();
            ActivationEmailBody1.Visible=true;

            //ActivationEmailBody ctrl = (ActivationEmailBody)pg.LoadControl("~/Controls/ActivationEmailBody.ascx");
            ActivationEmailBody1.User = usr;
            ActivationEmailBody1.RenderControl(htmlWriter);
            //ctrl.Dispose();
           // pg.Dispose();
            return writer.ToString();

        }
    }
}