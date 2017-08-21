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

namespace BDDoctors.BlogSection
{
    public partial class EditBlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                serverStyle.InnerHtml = "div.delete-comment-of" + LoginHandler.LoggedInUser().Id.ToString() + " span.delete-comment{display:inline}"; 
                UIhelper.PopulateDropDown(ddlCategory, 28, null);
                System.Collections.Generic.List<DAL.DataObject.Node> AllNodes = DAL.DataAccess.Node.GetNodesOnly( Convert.ToInt64(Request["node_id"]));
                BindHeaderAndAlbumGrid(AllNodes);
                
            }
        }

        public void BindHeaderAndAlbumGrid(System.Collections.Generic.List<DAL.DataObject.Node> ListNodes)
        {
            //System.Collections.Generic.IEnumerable<DAL.DataObject.Node> ParentNodeList = from DAL.DataObject.Node nd in ListNodes
            //                                                                             where nd.Attribute_id != null && nd.Attribute_id.Value == 33
            //                                                                             select nd;

            Comment1.NodeList = ListNodes;


            //GridHeader.DataSource = ParentNodeList;
            //GridHeader.DataBind();

            System.Collections.Generic.IEnumerable<DAL.DataObject.Node> PhotoList = from DAL.DataObject.Node nd in ListNodes
                                                                                    where nd.Attribute_id != null && nd.Node_value != null && nd.Attribute_id.Value == 37
                                                                                    select nd;
            DlAlbums.DataSource = PhotoList;
            DlAlbums.DataBind();

            foreach (DAL.DataObject.Node nd in ListNodes)
            {
                switch (nd.Attribute_id)
                {
                    case 33:
                        txtBlogTitle.Text = nd.Node_value.ToString();
                        if (nd.User_id != LoginHandler.LoggedInUser().Id)
                        {
                            Response.Redirect(ResolveClientUrl("~\\showblog.aspx") + "?" + "node_id=" + nd.Id.ToString());

                        }
                        break;
                    case 34:

                        id_description.Value = nd.Node_value.ToString();                        
                        break;
                    case 35:
                        ddlCategory.SelectedValue = nd.Node_value.ToString();
                       
                        break;


                }
            }

        }
    

        protected void btnUpdateBlog_Click(object sender, EventArgs e)
        {
            Boolean IsValidate = true;
            string message = "Please Enter";
            if (txtBlogTitle.Text.Trim().Length < 20)
            {
                message += " (Title-mininum length 20 character) ";
                IsValidate = false;
            }
            if (id_description.Value.Trim().Length < 30)
            {
                message += " (Description-Minimum length 20 character) ";
                IsValidate = false;
            }


            Boolean singleChecked = false;
            
            if (ddlCategory.SelectedValue == "-1")
            {
                message += " (Category) ";
                IsValidate = false;
            }

            if (IsValidate == false)
            {
                lblValidateMessage.Text = message;
                return;
            }

            else { lblValidateMessage.Text = ""; }

            if (FileUpload2.HasFile)
            {
                if (FileUpload2.PostedFile.ContentType.Contains("image") == false)
                {
                    IsValidate = false;
                    lblfileupload2.Text = "jpg,jpeg,bmp,png,gif files are supported ";
                    return;

                }

            }
            if (FileUpload3.HasFile)
            {
                if (FileUpload3.PostedFile.ContentType.Contains("image") == false)
                {
                    IsValidate = false;
                    lblfileupload3.Text = "jpg,jpeg,bmp,png,gif files are supported ";
                    return;

                }

            }
            if (FileUpload4.HasFile)
            {
                if (FileUpload4.PostedFile.ContentType.Contains("image") == false)
                {
                    IsValidate = false;
                    lblfileupload4.Text = "jpg,jpeg,bmp,png,gif files are supported ";
                    return;

                }

            }
            if (FileUpload5.HasFile)
            {
                if (FileUpload5.PostedFile.ContentType.Contains("image") == false)
                {
                    IsValidate = false;
                    lblfileupload5.Text = "jpg,jpeg,bmp,png,gif files are supported ";
                    return;

                }

            }



            DAL.DataObject.Node nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Parent_Node_Id = Convert.ToInt64(Request["node_id"]);



            nd.Attribute_id = 33;
            nd.Node_value = txtBlogTitle.Text;
            DAL.DataAccess.Node.SaveNode(nd);
            nd.Id = null;

            nd.Attribute_id = 34;
            nd.Node_value = id_description.Value;
            DAL.DataAccess.Node.SaveNode(nd);
            nd.Id = null;

            nd.Attribute_id = 35;
            nd.Node_value = ddlCategory.SelectedValue.ToString();
            DAL.DataAccess.Node.SaveNode(nd);
            nd.Id = null;
            //DAL.DataAccess.Node.UpdateNodes(Convert.ToInt64(Request["node_id"]), 33, txtBlogTitle.Text.ToString());
            //DAL.DataAccess.Node.UpdateNodes(Convert.ToInt64(Request["node_id"]), 34, id_description.Value.ToString());
            //DAL.DataAccess.Node.UpdateNodes(Convert.ToInt64(Request["node_id"]), 35, ddlCategory.SelectedValue.ToString());

            Int64 parent_id = Convert.ToInt64(Request["node_id"]);
            if (FileUpload2.HasFile)
            {

                DAL.DataObject.Node ndImage = new BDDoctors.DAL.DataObject.Node();
                ndImage.Parent_Node_Id = parent_id;
                ndImage.User_id = LoginHandler.LoggedInUser().Id;
                ndImage.User_Name = LoginHandler.LoggedInUser().DisplayName;
                ndImage.Node_value = "Nothing";
                ndImage.Attribute_id = 37;
                DAL.DataAccess.Node.SaveCommentOrImageOrVideo(ndImage);
                ndImage.Node_value = ndImage.Id.ToString();
                DAL.DataAccess.Node.SaveNode(ndImage);


                //strFileName = ndImage.Node_value;
                FileUpload2.PostedFile.SaveAs(Server.MapPath("/images/Node/") + ndImage.Node_value);
                try
                {
                    BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/Node/"), ndImage.Node_value, FileUpload2.PostedFile.ContentType);
                }
                catch
                {
                    DAL.DataAccess.Node.DeleteNodes(ndImage.Id.Value);

                }
            }

            if (FileUpload3.HasFile)
            {

                DAL.DataObject.Node ndImage = new BDDoctors.DAL.DataObject.Node();
                ndImage.Parent_Node_Id = parent_id;
                ndImage.User_id = LoginHandler.LoggedInUser().Id;
                ndImage.User_Name = LoginHandler.LoggedInUser().DisplayName;
                ndImage.Node_value = "Nothing";
                ndImage.Attribute_id = 37;
                DAL.DataAccess.Node.SaveCommentOrImageOrVideo(ndImage);
                ndImage.Node_value = ndImage.Id.ToString();
                DAL.DataAccess.Node.SaveNode(ndImage);


                //strFileName = ndImage.Node_value;
                FileUpload3.PostedFile.SaveAs(Server.MapPath("/images/Node/") + ndImage.Node_value);
                try
                {
                    BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/Node/"), ndImage.Node_value, FileUpload3.PostedFile.ContentType);
                }
                catch
                {
                    DAL.DataAccess.Node.DeleteNodes(ndImage.Id.Value);

                }

            }
            if (FileUpload4.HasFile)
            {

                DAL.DataObject.Node ndImage = new BDDoctors.DAL.DataObject.Node();
                ndImage.Parent_Node_Id = parent_id;
                ndImage.User_id = LoginHandler.LoggedInUser().Id;
                ndImage.User_Name = LoginHandler.LoggedInUser().DisplayName;
                ndImage.Node_value = "Nothing";
                ndImage.Attribute_id = 37;
                DAL.DataAccess.Node.SaveCommentOrImageOrVideo(ndImage);
                ndImage.Node_value = ndImage.Id.ToString();
                DAL.DataAccess.Node.SaveNode(ndImage);


                //strFileName = ndImage.Node_value;
                FileUpload4.PostedFile.SaveAs(Server.MapPath("/images/Node/") + ndImage.Node_value);
                try
                {
                    BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/Node/"), ndImage.Node_value, FileUpload4.PostedFile.ContentType);
                }
                catch
                {
                    DAL.DataAccess.Node.DeleteNodes(ndImage.Id.Value);

                }
            }


            if (FileUpload5.HasFile)
            {

                DAL.DataObject.Node ndImage = new BDDoctors.DAL.DataObject.Node();
                ndImage.Parent_Node_Id = parent_id;
                ndImage.User_id = LoginHandler.LoggedInUser().Id;
                ndImage.User_Name = LoginHandler.LoggedInUser().DisplayName;
                ndImage.Node_value = "Nothing";
                ndImage.Attribute_id = 37;
                DAL.DataAccess.Node.SaveCommentOrImageOrVideo(ndImage);
                ndImage.Node_value = ndImage.Id.ToString();
                DAL.DataAccess.Node.SaveNode(ndImage);


                //strFileName = ndImage.Node_value;
                FileUpload5.PostedFile.SaveAs(Server.MapPath("/images/Node/") + ndImage.Node_value);
                try
                {
                    BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/Node/"), ndImage.Node_value, FileUpload5.PostedFile.ContentType);
                }
                catch
                {
                    DAL.DataAccess.Node.DeleteNodes(ndImage.Id.Value);

                }
            }


            Response.Redirect(ResolveClientUrl("~\\showblog.aspx") + "?" + "node_id=" + Convert.ToString(Request["node_id"]));
        }

        protected void DlAlbums_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            if (DAL.DataAccess.Node.DeleteNodes(Convert.ToInt64(DlAlbums.DataKeys[e.Item.ItemIndex])))
            {
                System.Collections.Generic.List<DAL.DataObject.Node> AllNodes = DAL.DataAccess.Node.GetNodesOnly(Convert.ToInt64(Request["node_id"]));
                BindHeaderAndAlbumGrid(AllNodes);  
            }
        }
    }
}
