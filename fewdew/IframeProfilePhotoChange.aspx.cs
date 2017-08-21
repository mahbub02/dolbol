using System;
using System.Collections;
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
using System.Drawing.Imaging;

namespace BDDoctors
{
    public partial class IframeProfilePhotoChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
      
        protected void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            if (FileProfileUpload.HasFile)
            {
                string strFileName;
                strFileName = FileProfileUpload.FileName;
                String fileType = FileProfileUpload.PostedFile.ContentType;

                if (fileType != null && fileType.Contains("image"))
                {
                    lblPhotoInformation.Text = "";
                    strFileName = LoginHandler.LoggedInUser().Id.ToString();

                    FileProfileUpload.PostedFile.SaveAs(Server.MapPath("/images/profile/") + strFileName);
                    BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/profile/"), LoginHandler.LoggedInUser().Id.Value.ToString(), ImageFormat.Jpeg.ToString());              
                   


                }
                else
                {
                    lblPhotoInformation.Text = "Only image files of jpg,jpeg,bmp,png,gif format are supported";
                }


            }


        }
    }
}
