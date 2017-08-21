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

namespace BDDoctors.Controls
{
    public partial class SignIn : System.Web.UI.UserControl
    {
        protected string TypedPassword
        {
            get
            {
                if (ViewState["TypedPassword"] != null)
                {
                    return Convert.ToString(ViewState["TypedPassword"]);
                }
                return null;
            }
            set
            {
                ViewState["TypedPassword"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ResetPasswordFields();

        }

        private void ResetPasswordFields()
        {
            if (txtPassword.Text.Length != 0)
            {
                TypedPassword = txtPassword.Text;
                txtPassword.Text = TypedPassword;
            }
            else
            {
                txtPassword.Attributes.Add("Value", TypedPassword);
            }

      
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Boolean Validate = true;
            if (txtEmail.Text.Length == 0)
            {
                lblEmailValidator.Text = "*";
                Validate = false;  
            }
            else
            {
                lblEmailValidator.Text = "";
            }

            Regex reg = new Regex(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
            if (reg.IsMatch(txtEmail.Text) == false)
            {
                lblEmailValidator.Text = "Enter a Valid Email";
                Validate = false;

            }
            else
            {
                lblEmailValidator.Text = "";
            }

            if (txtPassword.Text.Length == 0)
            {
                lblPasswordValidator.Text = "*";
                Validate = false;
            }
            else
            {
                lblPasswordValidator.Text = "";
            }
            if (Validate == false)
            {
                return;
            }

            if (Validate==true && BDDoctors.LoginHandler.DoLogin(txtEmail.Text, txtPassword.Text))
            {
                Response.Redirect(ResolveClientUrl("~\\Profile.aspx"));
            }
            else { lblCredentialValidator.Text = "Invalid Credentials"; }
        }
    }
}