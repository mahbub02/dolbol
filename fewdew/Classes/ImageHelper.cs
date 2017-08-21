using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace BDDoctors
{
    public class ImageHelper
    {
        public static Boolean  ResizeAndSave(string StrDirectory,string fileName,string fileType)
        {
            try
            {

                if (SaveInDiffrentShape(StrDirectory, fileName, fileType, 25) &&
                    SaveInDiffrentShape(StrDirectory, fileName, fileType, 40) &&
                   SaveInDiffrentShape(StrDirectory, fileName, fileType, 80) &&
                   SaveInDiffrentShape(StrDirectory, fileName, fileType, 200) &&
                   SaveInDiffrentShape(StrDirectory, fileName, fileType, 400) &&
                   SaveInDiffrentShape(StrDirectory, fileName, fileType, 601))
                {

                    return true;
                }
                else { return false; }
            }
            catch (Exception) { return false; }
            
        }
        private static Boolean SaveInDiffrentShape(string StrDirectory, string fileName,string fileType,Int32 imageWidth)
        {
            try
            {

                System.Drawing.Image oImg = System.Drawing.Image.FromFile(StrDirectory + @"\" + fileName);
                Int32 img_Width = oImg.Width;
                Int32 img_height = (Int32)(oImg.Height * imageWidth / oImg.Width);


                System.Drawing.Image oThumbNail = new Bitmap(imageWidth, img_height, oImg.PixelFormat);

                Graphics oGraphic = Graphics.FromImage(oThumbNail);

                oGraphic.CompositingQuality = CompositingQuality.HighQuality;

                oGraphic.SmoothingMode = SmoothingMode.HighQuality;

                oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

                Rectangle oRectangle = new Rectangle(0, 0, imageWidth, img_height);

                oGraphic.DrawImage(oImg, oRectangle);

                switch (imageWidth)
                {
                    case 25:
                        fileName = fileName + "_micro.jpg";
                        break;
                    case 40:
                        fileName = fileName + "_mini.jpg";        
                      break;
                    case 80:
                      fileName = fileName + "_thumb.jpg";
                      break;
                    case 200:
                      fileName = fileName + "_profile.jpg";
                      break;
                    case 400:
                      fileName = fileName + "_display.jpg";
                      break;
                    case 601:
                      fileName = fileName + "_world.jpg";
                      break;
                }
                fileType = fileType.ToLower();
                if (fileType.Contains("gif"))
                {
                    oThumbNail.Save(StrDirectory + @"\" + fileName, ImageFormat.Gif);
                }
                
                if (fileType.Contains("jpg") || fileType.Contains("jpeg"))
                {
                    oThumbNail.Save(StrDirectory + @"\" + fileName, ImageFormat.Jpeg);
                }

                if (fileType.Contains("bmp"))
                {
                    oThumbNail.Save(StrDirectory + @"\" + fileName, ImageFormat.Bmp);
                }




                oImg.Dispose();
                return true;

            }
            catch (Exception) { return false; }
        }
        //private static Boolean ResizeAndSaveInProfileShape(string StrDirectory, string fileName)
        //{
        //    try
        //    {

        //        System.Drawing.Image oImg = System.Drawing.Image.FromFile(StrDirectory + @"\" + fileName);
        //        Int32 img_Width = oImg.Width;
        //        Int32 img_height = (Int32)(oImg.Height * 100 / oImg.Width);


        //        System.Drawing.Image oThumbNail = new Bitmap(100, img_height, oImg.PixelFormat);

        //        Graphics oGraphic = Graphics.FromImage(oThumbNail);

        //        oGraphic.CompositingQuality = CompositingQuality.HighQuality;

        //        oGraphic.SmoothingMode = SmoothingMode.HighQuality;

        //        oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

        //        Rectangle oRectangle = new Rectangle(0, 0, 100, img_height);

        //        oGraphic.DrawImage(oImg, oRectangle);
        //        fileName = fileName.ToLower();
        //        fileName = fileName.Replace(".", "_profile.");
        //        if (fileName.IndexOf(".gif") > 0)
        //        {
        //            oThumbNail.Save(StrDirectory + @"\" + fileName, ImageFormat.Gif);

        //        }
        //        if (fileName.IndexOf(".jpg") > 0)
        //        {
        //            oThumbNail.Save(StrDirectory + @"\" + fileName, ImageFormat.Jpeg);
        //        }
        //        if (fileName.IndexOf(".bmp") > 0)
        //        {
        //            oThumbNail.Save(StrDirectory + @"\" + fileName, ImageFormat.Bmp);
        //        }



        //        oImg.Dispose();
        //        return true;

        //    }
        //    catch (Exception) { return false; }
        //}

        //private static Boolean ResizeAndSaveInMiniShape(string StrDirectory, string fileName)
        //{
        //    try
        //    {

        //        System.Drawing.Image oImg = System.Drawing.Image.FromFile(StrDirectory + @"\" + fileName);
        //        Int32 img_Width = oImg.Width;
        //        Int32 img_height = (Int32)(oImg.Height * 20 / oImg.Width);


        //        System.Drawing.Image oThumbNail = new Bitmap(20, img_height, oImg.PixelFormat);

        //        Graphics oGraphic = Graphics.FromImage(oThumbNail);

        //        oGraphic.CompositingQuality = CompositingQuality.HighQuality;

        //        oGraphic.SmoothingMode = SmoothingMode.HighQuality;

        //        oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

        //        Rectangle oRectangle = new Rectangle(0, 0, 20, img_height);

        //        oGraphic.DrawImage(oImg, oRectangle);
        //        fileName = fileName.ToLower();
        //        fileName = fileName.Replace(".", "_mini.");
        //        if (fileName.IndexOf(".gif") > 0)
        //        {
        //            oThumbNail.Save(StrDirectory + @"\" + fileName, ImageFormat.Gif);

        //        }
        //        if (fileName.IndexOf(".jpg") > 0)
        //        {
        //            oThumbNail.Save(StrDirectory + @"\" + fileName, ImageFormat.Jpeg);
        //        }
        //        if (fileName.IndexOf(".bmp") > 0)
        //        {
        //            oThumbNail.Save(StrDirectory + @"\" + fileName, ImageFormat.Bmp);
        //        }



        //        oImg.Dispose();
        //        return true;

        //    }
        //    catch (Exception) { return false; }
        //}
    }
}
