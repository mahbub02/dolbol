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
    public partial class Notif_Blog : System.Web.UI.UserControl
    {
        private System.Collections.Generic.List<DAL.DataObject.Node> m_NodeList;

        public System.Collections.Generic.List<DAL.DataObject.Node> NodeList
        {
            set { m_NodeList = value; BindHeaderAndAlbumGrid(m_NodeList); }
            get { return m_NodeList; }
        }
        public void BindHeaderAndAlbumGrid(System.Collections.Generic.List<DAL.DataObject.Node> ListNodes)
        {
            System.Collections.Generic.IEnumerable<DAL.DataObject.Node> ParentNodeList = from DAL.DataObject.Node nd in ListNodes
                                                                                         where nd.Attribute_id != null && nd.Attribute_id.Value == 33
                                                                                         select nd;
            

            GridHeader.DataSource = ParentNodeList;
            GridHeader.DataBind();
            datalistUserPhotoName.DataSource = GridHeader.DataSource;
            datalistUserPhotoName.DataBind();

            System.Collections.Generic.IEnumerable<DAL.DataObject.Node> PhotoList = from DAL.DataObject.Node nd in ListNodes
                                                                                    where nd.Attribute_id != null && nd.Node_value != null && nd.Attribute_id.Value == 37
                                                                                    select nd;
            DlAlbums.DataSource = PhotoList;
            DlAlbums.DataBind();
            
            foreach (DAL.DataObject.Node nd in ListNodes)
            {
                switch (nd.Attribute_id)
                {
                     case 34:
                        if (nd.Node_value.Length > 300)
                        {
                            nd.Node_value = nd.Node_value.Substring(0, 300) + ".........";
                        }
                        lblDescriptionValue.Text = nd.Node_value.ToString();
                        GridHeader.Attributes.Add("ParentNodeId",nd.Parent_Node_Id.ToString() );
                        break;
                    //case 35:
                    //    lblCategoryValue.Text = nd.Node_value.ToString();
                    //    break;
                    //case 37:
                    //    if (nd.Node_value != null)
                    //    {
                    //        BlogImage.Src = ResolveClientUrl("/images/node/" + nd.Node_value.ToString() + "_mini.jpg");


                    //        BlogImage.Src = ResolveClientUrl("/images/Node/" + nd.Node_value.ToString() + "_mini.jpg");
                    //        BlogImage.Visible = true;

                    //    }
                    //    break;

                }
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void lbtnDelete_Click(object sender, EventArgs e)
        //{
        //    if (DAL.DataAccess.Node.DeleteNodes(Convert.ToInt64(GridHeader.Attributes["ParentNodeId"])))
        //    {
        //        this.Visible = false;
        //    }
        //}
    }
}