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

namespace BDDoctors.Controls.FeedRelated
{
    public partial class Status : System.Web.UI.UserControl
    {
        private DAL.DataObject.Node m_node;
        public DAL.DataObject.Node Node
        {
            get { return m_node; }
            set { m_node = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}