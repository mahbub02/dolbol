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
using System.Drawing.Imaging;

namespace BDDoctors
{
    public partial class ActivateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Request["Email"]!=null&&Request["Key"]!=null&& Convert.ToString(Request["Email"]).Length > 0 && Convert.ToString(Request["Key"]).Length > 0)
            {
                DAL.DataObject.User usr = DAL.DataAccess.User.GetUser(Convert.ToString(Request["Email"]));
                if (usr != null)
                {
                    if (usr.Status == 1)
                    {
                       // LoginHandler.DoLogin(usr.Email, usr.Password);
                        //Response.Redirect(ResolveClientUrl("~\\Home.aspx"));
                        Response.Write("This account was already activated. Check your email to get password");
                        return;
                    }
                    if(usr.ActivationKey==Convert.ToString(Request["Key"])){
                        usr.Status = 1;
                        if (DAL.DataAccess.User.SaveUser(usr))
                        {
                            SaveACopyOfDefaultImageAsProfilePicture(usr);
                            Response.Write("Your account is activated");
                            LoginHandler.DoLogin(usr.Email, usr.Password);
                            Response.Redirect(ResolveClientUrl("~\\club.aspx?room_id=200"));
                            return;
                        }
                    }
                }

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Length == 0)
            {
                lblEmailValidator.Text = "*";
                return;
            }
            else
            {
                lblEmailValidator.Text = "";
            }
            if (txtKey.Text.Length == 0)
            {
                lblKeyValidator.Text = "*";
                return;
            }
            else
            {
                lblKeyValidator.Text = "";
            }

            DAL.DataObject.User usr = DAL.DataAccess.User.GetUser(txtEmail.Text);
            if (usr != null)
            {
                lblInformation.Text = "";
                if (usr.Status == 1)
                {
                    LoginHandler.DoLogin(usr.Email, usr.Password);
                    Response.Redirect(ResolveClientUrl("~\\Home.aspx"));
                    return;
                }
                else if (usr.ActivationKey ==txtKey.Text)
                {
                    usr.Status = 1;
                    if (DAL.DataAccess.User.SaveUser(usr))
                    {
                        SaveACopyOfDefaultImageAsProfilePicture(usr);
                        Response.Write("Your account is activated");
                        LoginHandler.DoLogin(usr.Email, usr.Password);
                        Response.Redirect(ResolveClientUrl("~\\Home.aspx"));
                        return;
                    }
                }
                else if (usr.ActivationKey != txtKey.Text)
                {
                    lblInformation.Text = "Wrong activation Key";
                }
            }
            else {
                lblInformation.Text = "There is no user with this email";

            }

        }

        private void SaveACopyOfDefaultImageAsProfilePicture(DAL.DataObject.User usr)
        {
            string sourceFile = System.IO.Path.Combine(Server.MapPath("/images/profile/"), "default");
            string destFile = System.IO.Path.Combine(Server.MapPath("/images/profile/"), usr.Id.Value.ToString());
          
            System.IO.File.Copy(sourceFile, destFile, true);
            BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/profile/"), usr.Id.Value.ToString(), ImageFormat.Jpeg.ToString());

            // sourceFile = System.IO.Path.Combine(Server.MapPath("/images/AvatarChat/Background/"), "default");
            // destFile = System.IO.Path.Combine(Server.MapPath("/images/AvatarChat/Background/"), usr.Id.Value.ToString());
            //System.IO.File.Copy(sourceFile, destFile, true);
            //BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/AvatarChat/Background/"), usr.Id.Value.ToString(), ImageFormat.Jpeg.ToString());

        }
    }
}
