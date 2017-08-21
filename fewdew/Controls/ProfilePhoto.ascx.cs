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
    public partial class ProfilePhoto : System.Web.UI.UserControl
    {
        
        private  Boolean AmIThePageOwner()
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
                btnPhotoUpload.Visible = AmIThePageOwner();
                FileProfileUpload.Visible = AmIThePageOwner();
                //if(LoginHandler.IsLoggedIn==true&& DAL.DataAccess.FriendShip.IsHeExistInTheList(PageOwner(), LoginHandler.GetLoggedInUserFriends())==false)
                //{

                //    lbtnAddAsConnection.Visible = !AmIThePageOwner(); 
                //}
                imgProfile.Src = "~/images/profile/" + PageOwner().ToString() + "_profile.jpg?state="+DateTime.Now.Millisecond;
            }
        }
        protected void btnPhotoUpload_Click(object sender, EventArgs e)
        {
           
            if (FileProfileUpload.HasFile)
            {
                string strFileName;
                strFileName = FileProfileUpload.FileName;
                String fileType = FileProfileUpload.PostedFile.ContentType;

                if (fileType!=null && fileType.Contains("image"))
                {
                    lblPhotoInformation.Text = "";
                    strFileName = LoginHandler.LoggedInUser().Id.ToString();

                    FileProfileUpload.PostedFile.SaveAs(Server.MapPath("/images/profile/") + strFileName);
                    BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/profile/"), strFileName, fileType);

                    imgProfile.Src = "~/images/profile/" + strFileName + "_profile.jpg?state=" + DateTime.Now.Millisecond;

                  string path ;
                  path="/profile.aspx";
                  HttpResponse.RemoveOutputCacheItem(path); 

                    
                }
                else
                {
                    lblPhotoInformation.Text = "UPLOAD IMAGE(jpg,jpeg,bmp,png,gif)";
                }


            }


        }

        //protected void lbtnAddAsConnection_Click(object sender, EventArgs e)
        //{
        //    if (PageOwner() != LoginHandler.LoggedInUser().Id.Value)
        //    {
        //        DAL.DataObject.FriendShip frndshp = new BDDoctors.DAL.DataObject.FriendShip();
        //        frndshp.User1 = LoginHandler.LoggedInUser().Id;
        //        frndshp.User2 = PageOwner();
        //        frndshp.Status = 0;
        //        DAL.DataAccess.FriendShip.SaveFriendShip(frndshp);
        //        DAL.DataObject.Friend frnd = new BDDoctors.DAL.DataObject.Friend();
        //        frnd.UserId = PageOwner();
        //        frnd.ActionDate = DateTime.Now;
        //        frnd.Status = 0;
        //        frnd.DisplayName = LoginHandler.LoggedInUser().DisplayName.ToString();
        //        LoginHandler.AddFriendToLoggedInUserFriendList(frnd);
        //        lbtnAddAsConnection.Visible = false;
        //    }
        //}

      
    }
}