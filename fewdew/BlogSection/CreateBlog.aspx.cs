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
    public partial class CreateBlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                UIhelper.PopulateDropDown(ddlCategory, 28, null);
                ////UIhelper.PopulateCheckList(ChklistCategory, 28, null);
            }
        }
        protected void btnCreateBlog_Click(object sender, EventArgs e)
       {
            Boolean IsValidate = true;
            string message = "Please Enter";
            if (txtBlogTitle.Text.Trim().Length < 1)
            {
                message += " (Title) ";
                IsValidate = false;
            }
            if (id_description.Value.Trim().Length <3)
            {
                message += " (Description) ";
                IsValidate = false;
            }

           
            Boolean singleChecked = false;
            //foreach (ListItem li in ChklistCategory.Items)
            //{
            //    if (li.Selected == true)
            //    {
            //        singleChecked = true;
            //    }
            //}
            if (ddlCategory.SelectedValue == "-1")
            {
                message += " ( Select Category) ";
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




            System.Collections.Generic.List<DAL.DataObject.Node> nodes = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();

            DAL.DataObject.Node nd;
            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 33;
            nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtBlogTitle.Text);
            nodes.Add(nd);

            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 34;
            nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(id_description.Value);
            nodes.Add(nd);

            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 35;
            string Category = string.Empty;
            //foreach (ListItem lItem in ChklistCategory.Items)
            //{
            //    if (lItem.Selected == true)
            //    {
            //        if (Category == string.Empty)
            //        {
            //            Category = Category + lItem.Value;
            //        }
            //        else
            //        {
            //            Category = Category + "," + lItem.Value;
            //        }

            //    }
            //}
            nd.Node_value = ddlCategory.SelectedValue;
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nodes.Add(nd);


           


            Int64 parent_id = DAL.DataAccess.Node.SaveNodes(nodes);
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
                catch {
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



            lblValidateMessage.Text = "Blog Successfully posted";
            Response.Redirect(ResolveClientUrl("~\\showblog.aspx") + "?" + "node_id=" + parent_id.ToString());
           

        }

        

        
        
    }
}
