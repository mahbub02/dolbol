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
using BDDoctors.DAL;
namespace BDDoctors
{
    public partial class CreatePoll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            System.Collections.Generic.List<DAL.DataObject.Node> nodes = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();
            DAL.DataObject.Node nd;
         

            TextBox Answer;
            FileUpload Fileupload;
            dvMessage.InnerHtml = string.Empty;
            if (txtQuestion.Text.Trim().Length == 0)
            {
                dvMessage.InnerHtml = "<p>Enter Question and answer</p>";
                return;
            }

            if (FileUploadQuestion.PostedFile.ContentLength > 0)
            {
                if (FileUploadQuestion.PostedFile.ContentType.Contains("jpg") || FileUploadQuestion.PostedFile.ContentType.Contains("jpeg") || FileUploadQuestion.PostedFile.ContentType.Contains("bmp") || FileUploadQuestion.PostedFile.ContentType.Contains("gif"))
                {

                }
                else { 
                    dvMessage.InnerHtml = dvMessage.InnerHtml + "<p>Associate image with question  have to be jpg,jpeg,bmp,gif </p> ";
                    return;
                }
            }

            Int64 Answercount = 0;
            for (int i = 1; i <= 10; i++)
            {
                Answer = (TextBox)dvCreatePoll.FindControl("txtAnswer" + i.ToString());
                Fileupload = (FileUpload)dvCreatePoll.FindControl("FileUpload" + i.ToString());
                Fileupload.EnableViewState = true;
                
                if (Answer.Text.Trim().Length > 0 || Fileupload.PostedFile.ContentLength>0)
                {
                    if (Fileupload.PostedFile.ContentLength>0)
                    {
                        if (Fileupload.PostedFile.ContentType.Contains("jpg") || Fileupload.PostedFile.ContentType.Contains("jpeg") || Fileupload.PostedFile.ContentType.Contains("bmp") || Fileupload.PostedFile.ContentType.Contains("gif"))
                        {

                        }
                        else
                        {
                            dvMessage.InnerHtml = dvMessage.InnerHtml + "<p>Associate image with answer (" + i.ToString() + " ) have to be jpg,jpeg,bmp,gif </p> ";
                           
                        }
                        if (Answer.Text.Trim().Length == 0)
                        {
                            dvMessage.InnerHtml = dvMessage.InnerHtml + "<p>Question with the photo number (" + i.ToString() + " ) is not given </p> ";
                        }
                       
                    }
                    if (Answer.Text.Trim().Length > 0)
                    {
                        Answercount = Answercount + 1;
                    }
                }
                
            }
            if (dvMessage.InnerHtml.Trim().Length > 0)
            {
                return;
            }
            if (Answercount < 2)
            {
                dvMessage.InnerHtml = dvMessage.InnerHtml + "<p>There should be atleast two questions</p>";
                return;
            }

            dvMessage.InnerHtml = string.Empty;


            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 55;
            nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtQuestion.Text);
            DAL.DataAccess.Node.SaveNode(nd);
            if (FileUploadQuestion.PostedFile.ContentLength > 0)
            {
                if (FileUploadQuestion.PostedFile.ContentType.Contains("jpg") || FileUploadQuestion.PostedFile.ContentType.Contains("jpeg") || FileUploadQuestion.PostedFile.ContentType.Contains("bmp") || FileUploadQuestion.PostedFile.ContentType.Contains("gif"))
                {
                    FileUploadQuestion.PostedFile.SaveAs(Server.MapPath("/images/Node/") + nd.Id.ToString());
                    BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/Node/"), nd.Id.ToString(), FileUploadQuestion.PostedFile.ContentType);
                }

            }
            Int64 Parent_Node_id = nd.Id.Value;

            nd = new BDDoctors.DAL.DataObject.Node();
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            nd.Attribute_id = 58;
            nd.Parent_Node_Id = Parent_Node_id;
            nd.Node_value = rdoListSingleOrMulti.SelectedValue.ToString();
            DAL.DataAccess.Node.SaveNode(nd);

            for (int i = 1; i <= 10; i++)
            {
                Answer = (TextBox)dvCreatePoll.FindControl("txtAnswer" + i.ToString());
                Fileupload = (FileUpload)dvCreatePoll.FindControl("FileUpload" + i.ToString());
               

                if (Answer.Text.Trim().Length > 0 || Fileupload.PostedFile.ContentLength > 0)
                {
                   
                        if (Answer.Text.Trim().Length > 0)
                        {
                            nd = new BDDoctors.DAL.DataObject.Node();
                            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
                            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
                            nd.Attribute_id = 56;
                            nd.Parent_Node_Id = Parent_Node_id;
                            nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(Answer.Text);
                            DAL.DataAccess.Node.SaveMultipleNodeWithSameAttribute(nd);


                            if (Fileupload.PostedFile.ContentLength > 0)
                            {
                                if (Fileupload.PostedFile.ContentType.Contains("jpg") || Fileupload.PostedFile.ContentType.Contains("jpeg") || Fileupload.PostedFile.ContentType.Contains("bmp") || Fileupload.PostedFile.ContentType.Contains("gif"))
                                {
                                    Fileupload.PostedFile.SaveAs(Server.MapPath("/images/Node/") + nd.Id.ToString());
                                    BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/Node/"), nd.Id.ToString(), Fileupload.PostedFile.ContentType);
                                }


                            }
                        }
                    
                }

            }


            //for (int i = 1; i <= 10; i++)
            //{
            //    Fileupload = (FileUpload)dvCreatePoll.FindControl("FileUpload" + i.ToString());
            //    nd = new BDDoctors.DAL.DataObject.Node();
            //    nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            //    nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            //    nd.Attribute_id = 55;
            //    nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(Answer.Text);
            //    nodes.Add(nd);
            //}

            //for(int i=1;i<=10;i++)
            //{
            //Answer=(TextBox) dvCreatePoll.FindControl("txtAnswer"+i.ToString());           
            //nd = new BDDoctors.DAL.DataObject.Node();
            //nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            //nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            //nd.Attribute_id = 55;
            //nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(Answer.Text);
            //nodes.Add(nd);
            //}
            
            
                
            //    nd = new BDDoctors.DAL.DataObject.Node();
            //nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            //nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            //nd.Attribute_id = 34;
            //nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtAnswer1.Text);
            //nodes.Add(nd);

            //nd = new BDDoctors.DAL.DataObject.Node();
            //nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            //nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            //nd.Attribute_id = 35;
            //string Category = string.Empty;
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
            //nd.Node_value = Category;
            //nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            //nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            //nodes.Add(nd);


            //Boolean imageValidate = true;
            //if (FileUpoadBlogImage.HasFile)
            //{
            //    if (FileUpoadBlogImage.PostedFile.ContentType.Contains("image") == false)
            //    {
            //        imageValidate = false;
            //        lblPhotoInformation.Text = "UPLOAD IMAGE(jpg,jpeg,bmp,png,gif)";

            //    }
            //}


            //Int64 parent_id = DAL.DataAccess.Node.SaveNodes(nodes);
            //if (FileUpoadBlogImage.HasFile)
            //{

            //   DAL.DataObject.Node ndImage = new BDDoctors.DAL.DataObject.Node();
            //    ndImage.Parent_Node_Id = parent_id;
            //    ndImage.User_id = LoginHandler.LoggedInUser().Id;
            //    ndImage.User_Name = LoginHandler.LoggedInUser().DisplayName;
            //    ndImage.Node_value = "Nothing";
            //    ndImage.Attribute_id = 37;
            //    DAL.DataAccess.Node.SaveCommentOrImageOrVideo(ndImage);
            //    ndImage.Node_value = ndImage.Id.ToString();
            //    DAL.DataAccess.Node.SaveNode(ndImage);


            //    //strFileName = ndImage.Node_value;
            //    FileUpoadBlogImage.PostedFile.SaveAs(Server.MapPath("/images/Node/") + ndImage.Node_value);
            //    BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/Node/"), ndImage.Node_value, FileUpoadBlogImage.PostedFile.ContentType);
            //}
        }
    }
}
