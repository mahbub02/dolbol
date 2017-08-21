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
    public partial class InvitationEmailBody : System.Web.UI.UserControl
    {
        protected string m_Email;
        protected string m_Message;

        public string Email
        {
            get
            {
                return m_Email;
            }
            set
            {
                m_Email = value;
            }
        }
        public string Message
        {
            get
            {
                return m_Message;
            }
            set
            {
                m_Message = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}