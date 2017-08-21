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
    public partial class test3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Captcha1.ValidateCaptcha(txtCaptcha.Text.Trim());

            if (Captcha1.UserValidated)
            {

                lblMessage.ForeColor = System.Drawing.Color.Green;

                lblMessage.Text = "Valid";

            }

            else
            {

                lblMessage.ForeColor = System.Drawing.Color.Red;

                lblMessage.Text = "InValid";

            } 

        }

    }
}
