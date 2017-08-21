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
    public partial class MediPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                UIhelper.PopulateCheckList(chkAreYouAlreadySuffering, 95, null);
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            Boolean IsValidate = true;
            string message = "Please Enter";
            if (txtName.Text.Trim().Length < 1)
            {
                message += " (Patient Name) ";
                IsValidate = false;
            }
            if (txtAge.Text.Trim().Length < 1)
            {
                message += " (Age) ";
                IsValidate = false;
            }
            if (txtWeight.Text.Trim().Length < 1)
            {
                message += " (Weight) ";
                IsValidate = false;
            }
            if (txtOccupation.Text.Trim().Length < 1)
            {
                message += " (Occupation) ";
                IsValidate = false;
            }

            if (txtDescription.Text.Trim().Length < 1)
            {
                message += " (Description) ";
                IsValidate = false;
            }

            if (txtHowLongSuffering.Text.Trim().Length < 1)
            {
                message += " (How long You are suffering) ";
                IsValidate = false;
            }

            //Boolean singleChecked = false;
            //foreach (ListItem li in ChklistCategory.Items)
            //{
            //    if (li.Selected == true)
            //    {
            //        singleChecked = true;
            //    }
            //}
            //if (singleChecked == false)
            //{
            //    message += " (Category) ";
            //    IsValidate = false;
            //}
            if (IsValidate == false)
            {
                lblValidationMessageForBlog.Text = message;
                return;
            }
            else { lblValidationMessageForBlog.Text = ""; }

            if (fileUploadPhoto.HasFile)
            {
                if (fileUploadPhoto.PostedFile.ContentType.Contains("image") == false)
                {
                    IsValidate = false;
                    lblValidationMessageForBlog.Text = "UPLOAD IMAGE(jpg,jpeg,bmp,png,gif)";
                    return;

                }

            }



            System.Collections.Generic.List<DAL.DataObject.Node> nodes = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();

            DAL.DataObject.Node nd;
            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 53;
            nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtName.Text);
            nodes.Add(nd);

            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 43;
            nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtAge.Text);
            nodes.Add(nd);

            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 44;
            nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtOccupation.Text);
            nodes.Add(nd);

            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 45;
            nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtWeight.Text);
            nodes.Add(nd);

            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 46;
            nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtDescription.Text);
            nodes.Add(nd);

            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 47;
            nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtHowLongSuffering.Text);
            nodes.Add(nd);

            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 48;
            string Diseases = string.Empty;
            foreach (ListItem lItem in chkAreYouAlreadySuffering.Items)
            {
                if (lItem.Selected == true)
                {
                    if (Diseases == string.Empty)
                    {
                        Diseases = Diseases + lItem.Value;
                    }
                    else
                    {
                        Diseases = Diseases + "," + lItem.Value;
                    }

                }
            }
            nd.Node_value = Diseases;
            nodes.Add(nd);



            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 49;
            nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtHistoryOfAnyOperation.Text);
            nodes.Add(nd);

            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 50;
            nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtHaveYouTakenAnyDrugForThisComplaint.Text);
            nodes.Add(nd);


            


            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 51;
            nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtTakingAnyMedicineForLong.Text);
            nodes.Add(nd);

            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 52;
            nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtHaveYouAlreadyDoneAnyInves.Text);
            nodes.Add(nd);

            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 59;
            nd.Node_value = "NO";
            nodes.Add(nd);

            Int64 parent_id = DAL.DataAccess.Node.SaveNodes(nodes);


            if (fileUploadPhoto.HasFile)
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
                fileUploadPhoto.PostedFile.SaveAs(Server.MapPath("/images/Node/") + ndImage.Node_value);
                BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/Node/"), ndImage.Node_value, fileUploadPhoto.PostedFile.ContentType);
            }


            Response.Redirect(ResolveClientUrl("~\\MediPanelDetails.aspx?Panel_id=")+parent_id.ToString());


            //lblSuccessfullyBlogPostMessage.Text = "Blog Successfully posted";
            //divCreateNewBlog.Visible = !divCreateNewBlog.Visible;
            //BlogList1.BindInfo = true;
            //divUserBlogList.Visible = true;
            //updatePanelCreateBlog.Update();
        }
    }
}
