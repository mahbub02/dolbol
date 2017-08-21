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
    public partial class Profile2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OwnerSpecificCode();
            if (Page.IsPostBack == false)
            {
               DisplayProfileImagControls();
               
                DisplayProfileInViewMood();
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

        private Boolean AmIThePageOwner()
        {
            if (LoginHandler.IsLoggedIn && PageOwner() == LoginHandler.LoggedInUser().Id)
            {
                return true;
            }
            else { return false; }
        }

        private void DisplayProfileImagControls()
        {
            
            imgProfile.Src = ResolveClientUrl("/images/profile/" + PageOwner().ToString() + "_profile.jpg");

        }

        private void OwnerSpecificCode()
        {
            if (AmIThePageOwner())
            {
                FileProfileUpload.Visible = true;
                btnPhotoUpload.Visible = true;
                btnSave.Visible = true;
                lbtnAddAsFriend.Visible = false;
            }
            else {
                FileProfileUpload.Visible = false;
                btnPhotoUpload.Visible = false;
                btnSave.Visible = false;
                //DAL.DataAccess.FriendShip.IsHeExistInTheList(LoginHandler.LoggedInUser().Id.Value, LoginHandler.GetLoggedInUserFriends());
                if(DAL.DataAccess.FriendShip.IsHeExistInTheList(PageOwner(), LoginHandler.GetLoggedInUserFriends()))
                {
                lbtnAddAsFriend.Visible = false;
                }
               
            }
        }
        private void DisplayProfileInViewMood()
        {
           

            System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListNodes = DAL.DataAccess.Node.GetListNodesOrAttribute("profile", PageOwner());
            Boolean isProfileExist = false;
            foreach (System.Collections.Generic.List<DAL.DataObject.Node> nodes in ListNodes)
            {
                foreach (DAL.DataObject.Node nd in nodes)
                {
                    if (nd.Node_value != null && nd.Node_value.Length > 0)
                    {
                        isProfileExist = true;
                        switch (nd.Attribute_id)
                        {
                            case 1:
                                lblFullNameAttribute.Visible = true;
                                txtFullName.Visible = false;                               
                                lblFullNameValue.Visible = true;
                                lblFullNameValue.Text = nd.Node_value.ToString();
                                lblFullNameAttribute.Text = nd.Attribute_Name.ToString();
                                break;
                            case 2:
                                lblGenderAttribute.Visible = true;
                                rdoGender.Visible = false;
                                lblGenderValue.Visible = true;
                                lblGenderValue.Text = nd.Node_value.ToString();
                                lblGenderAttribute.Text = nd.Attribute_Name.ToString();
                                break;
                            case 3:
                                lblCityAttribute.Visible = true;
                                ddlCity.Visible = false;
                                lblCityValue.Visible = true;
                                lblCityValue.Text = nd.Node_value.ToString();
                                lblCityAttribute.Text = nd.Attribute_Name.ToString();
                                break;
                            case 4:
                                lblDegreeAttribute.Visible = true;
                                txtDegree.Visible = false;
                                lblDegressValue.Visible = true;
                                lblDegressValue.Text = nd.Node_value.ToString();
                                lblDegreeAttribute.Text = nd.Attribute_Name.ToString();
                                ImgBtnDegreeHelp.Visible = false;
                                dvChkListDegree.Visible = false;
                                break;
                            case 5:
                                lblAddressAttribute.Visible = true;
                                txtAddress.Visible = false;
                                lblAddressValue.Visible = true;
                                lblAddressValue.Text=nd.Node_value.ToString();
                                lblAddressAttribute.Text = nd.Attribute_Name.ToString();
                                break;
                        }
                    
                    }
                   
                }
            }
            if (LoginHandler.IsLoggedIn)// do checking 
            {
                if (isProfileExist)
                {
                    btnSave.Text = "Edit";
                }
                else { btnSave.Text = "Create"; }
            }
            else { btnSave.Visible = false; }
           

        }
        private void DisplayProfileInEditMood()
        {
            System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListNodes = DAL.DataAccess.Node.GetListNodesOrAttribute("profile", LoginHandler.LoggedInUser().Id.Value);
          
            foreach (System.Collections.Generic.List<DAL.DataObject.Node> nodes in ListNodes)
            {
                foreach (DAL.DataObject.Node nd in nodes)
                {
                   
                        switch (nd.Attribute_id)
                        {
                            case 1:
                                lblFullNameAttribute.Visible = true;
                                txtFullName.Visible = true;
                                lblFullNameValue.Visible = false;
                                txtFullName.Text = DAL.Common.GetString(nd.Node_value);
                                lblFullNameAttribute.Text = nd.Attribute_Name.ToString();
                                break;
                            case 2:
                                lblGenderAttribute.Visible = true;
                                rdoGender.Visible = true;
                                BDDoctors.UIhelper.PopulateRadioList(rdoGender, nd.Source_id.Value, nd.Node_value);
                                lblGenderValue.Visible = false;
                                lblGenderValue.Text = DAL.Common.GetString(nd.Node_value);
                                lblGenderAttribute.Text = nd.Attribute_Name.ToString();
                                break;
                            case 3:
                                lblCityAttribute.Visible = true;
                                ddlCity.Visible = true;
                                lblCityValue.Visible = false;
                                lblCityValue.Text = DAL.Common.GetString(nd.Node_value);
                                lblCityAttribute.Text = nd.Attribute_Name.ToString();
                                BDDoctors.UIhelper.PopulateDropDown(ddlCity, nd.Source_id.Value, nd.Node_value);
                                break;
                            case 4:
                                lblDegreeAttribute.Visible = true;
                                txtDegree.Visible = true;
                                lblDegressValue.Visible = false;
                                txtDegree.Text = DAL.Common.GetString(nd.Node_value);
                                lblDegreeAttribute.Text = nd.Attribute_Name.ToString();
                                BDDoctors.UIhelper.PopulateCheckList(ChklistDegree, nd.Source_id.Value, nd.Node_value);
                                ImgBtnDegreeHelp.Visible = true;
                                dvChkListDegree.Visible = false;
                                break;
                            case 5:
                                lblAddressAttribute.Visible = true;
                                txtAddress.Visible = true;
                                lblAddressValue.Visible = false;
                                txtAddress.Text = DAL.Common.GetString(nd.Node_value);
                                lblAddressAttribute.Text = nd.Attribute_Name.ToString();
                                break;
                        }

                   

                }
            }
            btnSave.Text = "Update";
        }

        private void SaveNodes()
        {
            System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListNodes = DAL.DataAccess.Node.GetListNodesOrAttribute("profile", LoginHandler.LoggedInUser().Id.Value);
            //Nullable<Int64>  parent_id = null;
            foreach (System.Collections.Generic.List<DAL.DataObject.Node> nodes in ListNodes)
            {
                foreach (DAL.DataObject.Node nd in nodes)
                {

                    switch (nd.Attribute_id)
                    {
                        case 1:
                            nd.Node_value = txtFullName.Text;
                            break;
                        case 2:
                            nd.Node_value = rdoGender.SelectedValue;                           
                            break;
                        case 3:
                            nd.Node_value = ddlCity.SelectedValue;
                            break;
                        case 4:
                            nd.Node_value = txtDegree.Text;
                              break;
                        case 5:
                            nd.Node_value = txtAddress.Text;                            
                            break;
                        case 6:
                            nd.Node_value = PageOwner().ToString();
                            break;
                    }
                    nd.User_id = LoginHandler.LoggedInUser().Id;
                    //if (nd.Parent_Node_Id != null)
                    //{
                    //    parent_id = nd.Parent_Node_Id;
                    //}
                   

                }
                DAL.DataAccess.Node.SaveNodes(nodes);
            }
            
           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Update")
            {
                SaveNodes();
                DisplayProfileInViewMood();
            }
            else {
                DisplayProfileInEditMood();
            }
        }

        protected void ImgBtnDegreeHelp_Click(object sender, ImageClickEventArgs e)
        {
            dvChkListDegree.Visible = true;
            foreach (ListItem li in ChklistDegree.Items)
            {
                if (li.Selected == true && txtDegree.Text.Contains(li.Value)==false)
                {
                    
                    txtDegree.Text = txtDegree.Text + "," + li.Value;
                    li.Selected = false;
                }
               
            }
            
        }

        protected void btnPhotoUpload_Click(object sender, EventArgs e)
        {

            if (FileProfileUpload.HasFile)
            {
                string strFileName;
                strFileName = FileProfileUpload.FileName;
                String fileType= FileProfileUpload.PostedFile.ContentType;

               if (fileType.Contains("image"))
               {
                   lblPhotoInformation.Text = "";
                   strFileName = LoginHandler.LoggedInUser().Id.ToString();

                   FileProfileUpload.PostedFile.SaveAs(Server.MapPath("/images/profile/") + strFileName);
                   BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/profile/"), strFileName, fileType);

                   imgProfile.Src = ResolveClientUrl("/images/profile/" + strFileName + "_profile.jpg");
                  

               }
               else {
                   lblPhotoInformation.Text = "UPLOAD IMAGE(jpg,jpeg,bmp,png,gif)";
               }
               
               
            }
              
        }

        protected void lbtnAddAsFriend_Click(object sender, EventArgs e)
        {

            if (PageOwner() != LoginHandler.LoggedInUser().Id.Value)
            {
                DAL.DataObject.FriendShip frndshp = new BDDoctors.DAL.DataObject.FriendShip();
                frndshp.User1 = LoginHandler.LoggedInUser().Id;
                frndshp.User2 = PageOwner();
                frndshp.Status = 0;
                DAL.DataAccess.FriendShip.SaveFriendShip(frndshp);
                DAL.DataObject.Friend frnd=new BDDoctors.DAL.DataObject.Friend();
                frnd.UserId=PageOwner();
                frnd.ActionDate=DateTime.Now;
                frnd.Status=0;
                frnd.DisplayName=LoginHandler.LoggedInUser().DisplayName.ToString();

                LoginHandler.AddFriendToLoggedInUserFriendList(frnd);
                lbtnAddAsFriend.Enabled = false;
            }
        }

    }
}