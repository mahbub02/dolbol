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
using BDDoctors.DAL.DataObject;
using BDDoctors.DAL.DataAccess;
using System.Web.Services;
//using System.math;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing;


namespace BDDoctors
{
    public partial class worldHomeManage : System.Web.UI.Page
    {
        [WebMethod()]
        public static string CreateJagWorldLink(string name, string description, int ParentId, int accessType)
        {
              DAL.DataObject.JagPlace ParentJagPlace =  DAL.DataAccess.jagPlace.GetJagPlaceById( ParentId);

            Random random = new Random();
            DAL.DataObject.JagPlace objPlace = new DAL.DataObject.JagPlace();
            objPlace.Parent_Id = ParentId;
            objPlace.Name = name;
            objPlace.Description = description;
            objPlace.OwnerName = LoginHandler.LoggedInUser().DisplayName;
            objPlace.OwnerId = LoginHandler.LoggedInUser().Id.Value;
            objPlace.Top = random.Next(100, 400);
            objPlace.Left = random.Next(100, 600);
            objPlace.width = 760;
            objPlace.Height = 400;
            objPlace.Level = ParentJagPlace.Level + 1;
            //DAL.DataObject.JagPlaceLevel.WorldHome
            objPlace.zindex = 1;
            objPlace.AccessType = accessType;
            DAL.DataAccess.jagPlace.SaveJagPlace(objPlace);
            System.Web.UI.Page pg = new Page();
            StringWriter writer = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);

            BDDoctors.Controls.LinkGenerator LinkGenerator = (BDDoctors.Controls.LinkGenerator)pg.LoadControl("~/Controls/LinkGenerator.ascx");
            LinkGenerator.JagPlace = objPlace;
            LinkGenerator.RenderControl(htmlWriter);
            return writer.ToString();
        }

        [WebMethod()]
        public static string SaveLinkLocation(int place_id, int top, int left)
        {
            DAL.DataObject.JagPlace objPlace = DAL.DataAccess.jagPlace.GetJagPlaceById(place_id);
            objPlace.Left = (int)left;
            objPlace.Top = (int)top;
            DAL.DataAccess.jagPlace.SaveJagPlace(objPlace);
            return "Done";
        }
        [WebMethod()]
        public static string ResizeBackGroundImage(int width, int height, int place_id)
        {

            //System.Web.HttpContext.Current.Server.MapPath("~\worlds\PlaceBackground\Original\")

            SaveInDiffrentShape(System.Web.HttpContext.Current.Server.MapPath("~\\PlaceBackground\\Original\\"), System.Web.HttpContext.Current.Server.MapPath("~\\PlaceBackground\\Resized\\"), place_id + ".jpg", null, (int)width, place_id + ".jpg");


            DAL.DataObject.JagPlace objPlace = DAL.DataAccess.jagPlace.GetJagPlaceById(place_id);
            objPlace.width = width;
            objPlace.Height = height;
            DAL.DataAccess.jagPlace.SaveJagPlace(objPlace);

            return "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            hiddenParentidContainer.Value = Request["place_id"];
        }
    

    private bool ReturnBackgroundImage(string fileName, [System.Runtime.InteropServices.OptionalAttribute, System.Runtime.InteropServices.DefaultParameterValueAttribute("")]  // ERROR: Optional parameters aren't supported in C#
string OutputFileName)
    {
        try {
            FuploadBackground.PostedFile.SaveAs(Server.MapPath("~\\PlaceBackground\\Original\\") + fileName);
            if (SaveInDiffrentShape(Server.MapPath("~\\PlaceBackground\\Original\\"), Server.MapPath("~\\PlaceBackground\\Resized\\"), fileName, FuploadBackground.PostedFile.ContentType, 760, OutputFileName) == true && SaveInDiffrentShape(Server.MapPath("~\\PlaceBackground\\Original\\"), Server.MapPath("~\\PlaceBackground\\thumbs\\"), fileName, FuploadBackground.PostedFile.ContentType, 120, OutputFileName) == true) {
                return true;
            }
        }
        catch (Exception ex) {
            return false;
        }
        return true;
    }
    private static string ReturnMimeType(string Filename)
    {
        string mime = "application/octetstream";
        string ext = System.IO.Path.GetExtension(Filename).ToLower();
        Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
        if (rk != null && rk.GetValue("Content Type") != null) {
            mime = rk.GetValue("Content Type").ToString();
        }
        return mime;
    }
    private static Boolean SaveInDiffrentShape(string StrSourceDirectory, string strDestinationDirectory, string fileName, string fileType, Int32 imageWidth, [System.Runtime.InteropServices.OptionalAttribute, System.Runtime.InteropServices.DefaultParameterValueAttribute("")]  // ERROR: Optional parameters aren't supported in C#
string outputFileName)
    {
        if (fileType == null) {
            fileType = ReturnMimeType((StrSourceDirectory + "\\") + fileName);
        }
        
        
        try {
            FileInfo fi = new FileInfo("myImage.gif");
            
            
            System.Drawing.Image oImg = System.Drawing.Image.FromFile((StrSourceDirectory + "\\") + fileName);
            
            Int32 img_Width = oImg.Width;
            Int32 img_height = default(Int32);
            if (img_Width > imageWidth) {
                img_height = (Int32)(oImg.Height * imageWidth / oImg.Width);
            }
            else {
                imageWidth = img_Width;
                img_height = oImg.Height;
            }
            
            
            
            System.Drawing.Image oThumbNail = new Bitmap(imageWidth, img_height, oImg.PixelFormat);
            
            Graphics oGraphic = Graphics.FromImage(oThumbNail);
            
            oGraphic.CompositingQuality = CompositingQuality.HighQuality;
            
            oGraphic.SmoothingMode = SmoothingMode.HighQuality;
            
            oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            
            Rectangle oRectangle = new Rectangle(0, 0, imageWidth, img_height);
            
            oGraphic.DrawImage(oImg, oRectangle);
            
            //Select Case imageWidth
            //    Case 40
            //        fileName = fileName & "_mini"
            //        Exit Select
            //    Case 80
            //        fileName = fileName & "_thumb"
            //        Exit Select
            //    Case 120
            //        fileName = fileName & "_profile"
            //        Exit Select
            //End Select
            fileType = fileType.ToLower();
            if (!string.IsNullOrEmpty(outputFileName)) {
                fileName = outputFileName;
            }
            if (fileType.Contains("gif")) {
                oThumbNail.Save((strDestinationDirectory + "\\") + fileName, ImageFormat.Gif);
            }
            
            if (fileType.Contains("jpg") || fileType.Contains("jpeg")) {
                oThumbNail.Save((strDestinationDirectory + "\\") + fileName, ImageFormat.Jpeg);
            }
            
            if (fileType.Contains("bmp")) {
                oThumbNail.Save((strDestinationDirectory + "\\") + fileName, ImageFormat.Bmp);
            }
            
            
            
            oImg.Dispose();
            
            return true;
        }
        catch (Exception generatedExceptionName) {
            return false;
        }
    }

    protected void btnUploadBackground_Click(object sender, EventArgs e)
    {
        string FileName = Request["place_id"] + System.IO.Path.GetExtension(FuploadBackground.PostedFile.FileName);

        if (FuploadBackground.PostedFile.ContentType.Contains("image") & !FuploadBackground.PostedFile.ContentType.Contains("gif"))
        {
            if (ReturnBackgroundImage(FileName, Request["place_id"] + ".jpg") == true)
            {
                lblbackGroundUploadMessage.ForeColor = Color.Green;
                lblbackGroundUploadMessage.Text = "Profile photo updated";
            }
            else
            {
                lblbackGroundUploadMessage.ForeColor = Color.Red;
                lblbackGroundUploadMessage.Text = "photo uploading failed";
                return;
            }
        }
        else
        {
            lblbackGroundUploadMessage.ForeColor = Color.Red;
            lblbackGroundUploadMessage.Text = "Supported image formats are-jpg,jpeg & bmp. Photo upload failed.";
            return;
        }
        lblbackGroundUploadMessage.ForeColor = Color.Green;
        lblbackGroundUploadMessage.Text = "Photo successfully uploaded";
    }

   
    }
}
