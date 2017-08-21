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
    public partial class ForgottenPasswordEmailBody : System.Web.UI.UserControl
    {
        protected DAL.DataObject.User m_User;

        public DAL.DataObject.User User
        {
            get
            {
                return m_User;
            }
            set
            {
                m_User = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}