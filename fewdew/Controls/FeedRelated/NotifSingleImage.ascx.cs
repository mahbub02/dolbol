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
    public partial class NotifSingleImage : System.Web.UI.UserControl
    {

        private System.Collections.Generic.List<DAL.DataObject.Node> m_NodeList;

        public System.Collections.Generic.List<DAL.DataObject.Node> NodeList
        {
            set { m_NodeList = value; BindHeaderGrid(m_NodeList); }
            get { return m_NodeList; }
        }
        public void BindHeaderGrid(System.Collections.Generic.List<DAL.DataObject.Node> ListNodes)
        {
            System.Collections.Generic.IEnumerable<DAL.DataObject.Node> ParentNodeList = from DAL.DataObject.Node nd in ListNodes
                                                                                         where nd.Attribute_id != null && nd.Attribute_id.Value == 63
                                                                                         select nd;

            GridHeader.DataSource = ParentNodeList;
            GridHeader.DataBind();



        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}