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
    public partial class MediPanelEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                UIhelper.PopulateCheckList(chkAreYouAlreadySuffering, 95, null);
                BindTreatmentPanel();
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
            foreach(DAL.DataObject.Node SNode  in nodes)
            {
                SNode.Parent_Node_Id = Convert.ToInt64(Request["Panel_id"]);
            }

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


            Response.Redirect(ResolveClientUrl("~\\MediPanelDetails.aspx?Panel_id=") + parent_id.ToString());



        }

        private void BindTreatmentPanel()
        {

            if (Page.IsPostBack == false)
            {
                System.Collections.Generic.List<DAL.DataObject.Node> AllNodes = DAL.DataAccess.Node.GetNodesOnly( Convert.ToInt64(Request["Panel_id"]));
                System.Collections.Generic.List<DAL.DataObject.Node> NodesButComment = DAL.DataAccess.Node.FilterNodeButComments(AllNodes);
                System.Collections.Generic.List<DAL.DataObject.Node> comments = DAL.DataAccess.Node.FilterNodeComments(AllNodes);
                //Comment1.NodeList = AllNodes;

                System.Collections.Generic.IEnumerable<DAL.DataObject.Node> PhotoList = from DAL.DataObject.Node nd in AllNodes
                                                                                        where nd.Attribute_id != null && nd.Node_value != null && nd.Attribute_id.Value == 37
                                                                                        select nd;
                //DlAlbums.DataSource = PhotoList;
                //DlAlbums.DataBind();



                foreach (DAL.DataObject.Node nd in NodesButComment)
                {
                    switch (nd.Attribute_id)
                    {
                        case 53:

                            txtName.Text = nd.Node_value.ToString();
                            
                            break;
                        case 43:
                           txtAge.Text = nd.Node_value.ToString();
                            break;
                        case 44:
                           txtOccupation.Text = nd.Node_value.ToString();
                            break;
                        case 45:
                            txtWeight.Text = nd.Node_value.ToString();
                            break;
                        case 46:
                            txtDescription.Text = nd.Node_value.ToString();
                            break;
                        case 47:
                            txtHowLongSuffering.Text = nd.Node_value.ToString();
                            break;
                        case 48:
                            UIhelper.PopulateCheckList(chkAreYouAlreadySuffering, 95, nd.Node_value);

                          //  chkAreYouAlreadySuffering .Text = nd.Node_value.ToString();
                            break;
                        case 49:
                            txtHistoryOfAnyOperation.Text = nd.Node_value.ToString();
                            break;
                        case 50:
                          txtHaveYouTakenAnyDrugForThisComplaint.Text = nd.Node_value.ToString();
                            break;
                        case 51:
                            txtTakingAnyMedicineForLong.Text = nd.Node_value.ToString();
                            break;
                        case 52:
                         txtHaveYouAlreadyDoneAnyInves.Text = nd.Node_value.ToString();
                            break;
                        case 59:

                            //if (LoginHandler.IsLoggedIn == true)
                            //{
                            //    if (LoginHandler.LoggedInUser().Id.Value <= 2)
                            //    {
                            //        btnResoved.Visible = true;
                            //    }
                            //}
                            //if (nd.User_id != null)
                            //{
                            //    btnResoved.Text = nd.Node_value.ToString();

                            //    if (nd.Node_value == "NO")
                            //    {
                            //        lblIsResolved.Text = "This panel is open";
                            //        if (LoginHandler.IsLoggedIn == true)
                            //        {

                            //            if (nd.User_id.Value == LoginHandler.LoggedInUser().Id.Value || LoginHandler.LoggedInUser().Id.Value < 3)
                            //            {
                            //                IsCommentVisble = true;
                            //            }
                            //        }
                            //    }
                            //    else { lblIsResolved.Text = "This panel is closed"; }


                            //}


                            break;




                    }
                }

            }
        }
    }
}
