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
    public partial class IframeUploadWallPhoto : System.Web.UI.Page
    {
        protected string m_fileName;
        public string FileName
        { 
            get
            {
                return m_fileName;
            }
            set
            {
                m_fileName = value;
            }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            FileName = "0";
        }

        protected void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            if (FileWallPhotoUpload.HasFile)
            {
                string strFileName;
                strFileName = FileWallPhotoUpload.FileName;
                String fileType = FileWallPhotoUpload.PostedFile.ContentType;

                if (fileType != null && fileType.Contains("image"))
                {
                    try
                    {
                        lblPhotoInformation.Text = "";
                        strFileName = LoginHandler.LoggedInUser().Id.ToString() + "_" + DateTime.Now.Millisecond.ToString().GetHashCode().ToString().Replace("-",""); ;
                        FileWallPhotoUpload.PostedFile.SaveAs(Server.MapPath("/images/Node/") + strFileName);
                        BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/Node/"), strFileName, ImageFormat.Jpeg.ToString());
                        FileName = strFileName;
                    }
                    catch
                    {
                        lblPhotoInformation.Text = "Photo uploading failed";
                        FileName = "0";
                    }
                    
    
                }
                else
                {
                    lblPhotoInformation.Text = "Only image files of jpg,jpeg,bmp,png,gif format are supported";
                    FileName = "0";
                }

            }
        }
    }
}
