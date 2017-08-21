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
    public partial class Profile2 : System.Web.UI.Page
    {
        private Boolean AmIThePageOwner()
        {
            if (LoginHandler.IsLoggedIn && PageOwner() == LoginHandler.LoggedInUser().Id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private Int64 PageOwner()
        {
            Int64 user_id = 0;
            if (Request["user"] != null)
            {
                user_id = Convert.ToInt64(Request["user"]);
            }
            if (user_id == 0)
            {
                user_id = Convert.ToInt64(LoginHandler.LoggedInUser().Id);
            }
            return user_id;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (LoginHandler.IsLoggedIn == true)
                {
                    if (AmIThePageOwner() == false)
                    {
                        lbtnSendEmail.Visible = true;
                    }
                }
                BlogList1.BindInfo = false;
                UploadedVideo1.BindInfo = false;
                UploadedPhoto1.BindInfo = false;
               
                HideAllTabPanel();
                divUserInformation.Visible = true;
            }

         
          
            
        }

        protected void lbtnSendEmail_Click(object sender, EventArgs e)
        {
            divSendEmail.Visible = true;
            DAL.DataObject.User usr = DAL.DataAccess.User.GetUser(PageOwner());
            txtTo.Text = usr.DisplayName;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text.Trim().Length == 0)
            {
                lblValidationMessage.Text = "Enter Message";
                return;
            }
            else {
                lblValidationMessage.Text ="" ;
            }
            DAL.DataObject.Email eml = new BDDoctors.DAL.DataObject.Email();
            eml.Sender_Id = LoginHandler.LoggedInUser().Id.Value;
            eml.Reciever_Id = PageOwner();
            eml.Subject = txtSubject.Text;
            eml.Message = txtMessage.Text;
            DAL.DataAccess.Email.SaveEmail(eml);
            ulControl.Visible = false;
            lblValidationMessage.Text = "Email Successfully sent";
           // divSendEmail.Style.Add("height", "20px");
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            divSendEmail.Visible = false;
        }

        protected void imgBtnClose_Click(object sender, ImageClickEventArgs e)
        {
            divSendEmail.Visible = false;
        }

        protected void lbtnUserBlog_Click(object sender, EventArgs e)
        {
            HideAllTabPanel();            
            BlogList1.BindInfo = true;
            lbtnPostNewBlog.Visible = AmIThePageOwner();
            divUserBlogList.Visible = true;
        }

        protected void lbtnUserInformation_Click(object sender, EventArgs e)
        {
            HideAllTabPanel();
            divUserInformation.Visible = true;

        }
        protected void lbtnUploadedImage_Click(object sender, EventArgs e)
        {
            HideAllTabPanel();
            UploadedPhoto1.BindInfo = true;
            DivUploadedImage.Visible = true;
        }
        private void HideAllTabPanel()
        {
            divUserInformation.Visible = false;
            divUserBlogList.Visible = false;
            divUploadedVideo.Visible = false;
            DivUploadedImage.Visible = false;
            
        }

        protected void lbtnPostNewBlog_Click(object sender, EventArgs e)
        {
            UIhelper.PopulateCheckList(ChklistCategory, 28, null);
            lblValidationMessage.Text = "";
            divCreateNewBlog.Style.Add("height", "650px");
            txtDescription.Text = "";
            txtTitle.Text = "";
            foreach (ListItem li in ChklistCategory.Items)
            {
                li.Selected = false;
            }


            divCreateNewBlog.Visible = !divCreateNewBlog.Visible;
            txtTitle.Visible = true;
            txtDescription.Visible = true;
            ChklistCategory.Visible = true;
            btnCancel.Visible = true;
            btnSend.Visible = true;
            updatePanelCreateBlog.Update();
        }

        protected void lbtnClose_Click(object sender, EventArgs e)
        {
            divCreateNewBlog.Visible = !divCreateNewBlog.Visible;
            updatePanelCreateBlog.Update();
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            Boolean IsValidate = true;
            string message = "Please Enter";
            if (txtTitle.Text.Trim().Length < 1)
            {
                message += " (Title) ";
                IsValidate = false;
            }
            if (txtDescription.Text.Trim().Length < 1)
            {
                message += " (Description) ";
                IsValidate = false;
            }

            if (txtTitle.Text.Trim().Length < 1)
            {
                message += " (Title) ";
                IsValidate = false;
            }
            Boolean singleChecked = false;
            foreach (ListItem li in ChklistCategory.Items)
            {
                if (li.Selected == true)
                {
                    singleChecked = true;
                }
            }
            if (singleChecked == false)
            {
                message += " (Category) ";
                IsValidate = false;
            }
            if (IsValidate == false)
            {
                lblValidationMessageForBlog.Text = message;
                return;
            }
            else { lblValidationMessageForBlog.Text = ""; }

            if (FileUpoadBlogImage.HasFile)
            {
                if (FileUpoadBlogImage.PostedFile.ContentType.Contains("image") == false)
                {
                    IsValidate = false;
                    lblValidationMessageForBlog.Text = "UPLOAD IMAGE(jpg,jpeg,bmp,png,gif)";
                    return ;

                }
                
            }



            System.Collections.Generic.List<DAL.DataObject.Node> nodes = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();

            DAL.DataObject.Node nd;
            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 33;
            nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtTitle.Text);
            nodes.Add(nd);

            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 34;
            nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtDescription.Text);
            nodes.Add(nd);

            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 35;
            string Category = string.Empty;
            foreach (ListItem lItem in ChklistCategory.Items)
            {
                if (lItem.Selected == true)
                {
                    if (Category == string.Empty)
                    {
                        Category = Category + lItem.Value;
                    }
                    else
                    {
                        Category = Category + "," + lItem.Value;
                    }

                }
            }
            nd.Node_value = Category;
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nodes.Add(nd);


            Boolean imageValidate = true;
            if (FileUpoadBlogImage.HasFile)
            {
                if (FileUpoadBlogImage.PostedFile.ContentType.Contains("image") == false)
                {
                    imageValidate = false;
                    lblPhotoInformation.Text = "UPLOAD IMAGE(jpg,jpeg,bmp,png,gif)";

                }
            }


         Int64 parent_id=   DAL.DataAccess.Node.SaveNodes(nodes);







         if (FileUpoadBlogImage.HasFile)
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
             FileUpoadBlogImage.PostedFile.SaveAs(Server.MapPath("/images/Node/") + ndImage.Node_value);
             BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/Node/"), ndImage.Node_value, FileUpoadBlogImage.PostedFile.ContentType);
         }
                   



           
            lblSuccessfullyBlogPostMessage.Text = "Blog Successfully posted";
            divCreateNewBlog.Visible = !divCreateNewBlog.Visible;
            BlogList1.BindInfo = true;
            divUserBlogList.Visible = true;
            updatePanelCreateBlog.Update();

            
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            divCreateNewBlog.Visible = !divCreateNewBlog.Visible;
        }

        protected void lbtnUploadedVideo_Click(object sender, EventArgs e)
        {
            HideAllTabPanel();
            divUploadedVideo.Visible = true;
            UploadedVideo1.BindInfo=true;
            //DivUploadedImage.Visible = true;
        }

       

        

      
    }
}
