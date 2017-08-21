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
    public partial class Notif_UploadedImage : System.Web.UI.UserControl
    {
        private System.Collections.Generic.List<DAL.DataObject.Node> m_NodeList;
        
        public System.Collections.Generic.List<DAL.DataObject.Node> NodeList
        {
            set { m_NodeList = value; BindHeaderAndAlbumGrid(m_NodeList); }
            get { return m_NodeList; }
        }

        public void BindHeaderAndAlbumGrid(System.Collections.Generic.List<DAL.DataObject.Node> ListNodes)
        {
            System.Collections.Generic.IEnumerable< DAL.DataObject.Node> ParentNodeList = from DAL.DataObject.Node nd in ListNodes
                                                                                   where nd.Attribute_id != null && nd.Attribute_id.Value == 39
                                                                                   select nd;


            GridHeader.Attributes.Add("ParentNodeId", DAL.DataAccess.Node.GetParentIdFromNodeList(ListNodes).Value.ToString());


            GridHeader.DataSource = ParentNodeList;
            GridHeader.DataBind();
           
            System.Collections.Generic.IEnumerable<DAL.DataObject.Node> PhotoList = from DAL.DataObject.Node nd in ListNodes
                                                                                    where nd.Attribute_id != null && nd.Node_value!=null && nd.Attribute_id.Value == 40
                                                                                    select nd;
            DlAlbums.DataSource = PhotoList;
            DlAlbums.DataBind();
          
        }

       

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //protected void lbtnDelete_Click(object sender, EventArgs e)
        //{
        //  //  if (DAL.DataAccess.Node.DeleteNodes(Convert.ToInt64(GridHeader.Attributes["ParentNodeId"])))
        //   // {
        //        this.Visible = false;
        //       // UpdatePanel2.Update();
        //   // }
        //}
    }
}