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
    public partial class ShowBlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (LoginHandler.IsLoggedIn == true)
                {
                    serverStyle.InnerHtml = "div.delete-comment-of" + LoginHandler.LoggedInUser().Id.ToString() + " span.delete-comment{display:inline}";
                }
               System.Collections.Generic.List<DAL.DataObject.Node> AllNodes=  DAL.DataAccess.Node.GetNodesOnly(Convert.ToInt64(Request["node_id"]));
               BindHeaderAndAlbumGrid(AllNodes);
            }
        }

        public void BindHeaderAndAlbumGrid(System.Collections.Generic.List<DAL.DataObject.Node> ListNodes)
        {
            System.Collections.Generic.IEnumerable<DAL.DataObject.Node> ParentNodeList = from DAL.DataObject.Node nd in ListNodes
                                                                                         where nd.Attribute_id != null && nd.Attribute_id.Value == 33
                                                                                         select nd;

            Comment1.NodeList = ListNodes;


            GridHeader.DataSource = ParentNodeList;
            GridHeader.DataBind();

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

                        dvdescription.InnerHtml = nd.Node_value.ToString();
                        if (LoginHandler.IsLoggedIn == true)
                        {
                            if (nd.User_id.Value == LoginHandler.LoggedInUser().Id.Value)
                            {
                                lbtnEdit.Visible = true;
                                lbtnDelete.Visible = true;
                            }
                        }
                        GridHeader.Attributes.Add("ParentNodeId", nd.Parent_Node_Id.ToString());
                        break;
                    case 35:
                        lblCategoryValue.Text = nd.Node_value.ToString();
                        break;
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

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveClientUrl("~\\blogsection\\editblog.aspx") + "?" + "node_id=" + Convert.ToString(Request["node_id"]));
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            
            if (DAL.DataAccess.Node.DeleteNodes(Convert.ToInt64(Request["node_id"])))
            {
                dvBody.InnerHtml = "<span>Blog Successfully deleted</span>";
            }
        }
    

        
    }
}
