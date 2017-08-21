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
    public partial class PhotoAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
               
                BindHeaderAndContent();

                

            }
        }
        private void BindHeaderAndContent()
        {
            System.Collections.Generic.List<DAL.DataObject.Node> ListNodes = DAL.DataAccess.Node.GetNodesOnly( Convert.ToInt64(Request["PhotoAlbum"]));




          

            System.Collections.Generic.List<DAL.DataObject.Node> comments = DAL.DataAccess.Node.FilterNodeComments(ListNodes);
            Comment1.NodeList = ListNodes;

            System.Collections.Generic.IEnumerable<DAL.DataObject.Node> PhotoList = from DAL.DataObject.Node nd in ListNodes
                                                                                    where nd.Attribute_id != null && nd.Node_value != null && nd.Attribute_id.Value == 40
                                                                                    select nd;
            System.Collections.Generic.List<DAL.DataObject.Node> ParentNodeList = DAL.DataAccess.Node.GetParentNode(ListNodes);
            //from DAL.DataObject.Node nd in ListNodes
            //                                                                             where nd.Attribute_id != null && nd.Attribute_id.Value == 39
            //                                                                             select nd;
            if (ParentNodeList[0].User_id.Value == LoginHandler.LoggedInUser().Id.Value)
            {
                 uploadBlock.Visible = true;
                 btnDelete.Visible = true;
            }
            GridHeader.DataSource = ParentNodeList;
            GridHeader.DataBind();

            DlAlbums.DataSource = PhotoList;
            DlAlbums.DataBind();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUploadImage.HasFile)
            {
                if (FileUploadImage.PostedFile.ContentType.Contains("jpg") || FileUploadImage.PostedFile.ContentType.Contains("jpeg") || FileUploadImage.PostedFile.ContentType.Contains("bmp") || FileUploadImage.PostedFile.ContentType.Contains("gif"))
                {
                    DAL.DataObject.Node ndImage = new BDDoctors.DAL.DataObject.Node();
                    ndImage.Parent_Node_Id = Convert.ToInt64(Request["PhotoAlbum"]);
                    ndImage.User_id = LoginHandler.LoggedInUser().Id;
                    ndImage.User_Name = LoginHandler.LoggedInUser().DisplayName;
                    ndImage.Node_value = "Nothing";
                    ndImage.Attribute_id = 40;
                    DAL.DataAccess.Node.SaveMultipleNodeWithSameAttribute(ndImage);
                    ndImage.Node_value = ndImage.Id.ToString();
                    DAL.DataAccess.Node.SaveNode(ndImage);


                    //strFileName = ndImage.Node_value;
                    FileUploadImage.PostedFile.SaveAs(Server.MapPath("/images/Node/") + ndImage.Id.ToString());
                    if (BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/Node/"), ndImage.Id.ToString(), FileUploadImage.PostedFile.ContentType))
                    {
                        BindHeaderAndContent();
                        lblUploadMessage.Text = "Photo successfully uploaded";
                    }
                    else { DAL.DataAccess.Node.DeleteNodes(ndImage.Id.Value); lblUploadMessage.Text = "jpg,jpeg,bmp,gif are supported"; }
                    


                }
                else
                {
                    lblUploadMessage.Text = "jpg,jpeg,bmp,gif are supported";

                }


            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
          Int32 a=  txtHidden.Value.LastIndexOf("/");
          Int32 b= txtHidden.Value.LastIndexOf("_thumb.jpg");
          txtHidden.Value = txtHidden.Value.Substring(a+1, Convert.ToInt32(b - (a+1)));
          DAL.DataAccess.Node.DeleteNodes(Convert.ToInt32(txtHidden.Value));
          BindHeaderAndContent();
         
        }
    }
}
