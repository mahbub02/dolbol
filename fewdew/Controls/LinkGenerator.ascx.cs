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
using BDDoctors.DAL.DataObject;
using BDDoctors.DAL.DataAccess;
using BDDoctors.DAL;
namespace BDDoctors.Controls
{
    public partial class LinkGenerator : System.Web.UI.UserControl
    {
        protected DAL.DataObject.JagPlace m_JagPlace;
        public DAL.DataObject.JagPlace JagPlace
        {
            get { return m_JagPlace; }
            set { m_JagPlace = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

    }
}