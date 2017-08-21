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
using ASPNetFlashVideo;

namespace BDDoctors.Controls
{
    public partial class UploadedVideo : System.Web.UI.UserControl
    {
        private bool m_BindInfo = false;
        public Boolean BindInfo
        {
            set { m_BindInfo = value; BindVideoList(); }
            get { return m_BindInfo; }
        }
        private bool m_I_the_Owner = false;
        private Boolean AmIThePageOwner()
        {
            if (LoginHandler.IsLoggedIn && PageOwner() == LoginHandler.LoggedInUser().Id)
            {
                m_I_the_Owner = true;
                return true;
            }
            else
            {
                m_I_the_Owner = false;
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
        private void BindVideoList()
        {
            if (m_BindInfo == true)
            {
                //System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListNodes = DAL.DataAccess.Node.GetListNodesOnly("Uploaded Video", PageOwner());
                //GridViewVideo.DataSource = ListNodes;
                //GridViewVideo.DataBind();
                

            }
        }
        private bool ReturnVideo(string fileName)
        {
            
            string html = string.Empty;
            //rename if file already exists

            int j = 0;
            string AppPath;
            string inputPath;
            string outputPath;
            string imgpath;
            AppPath = Request.PhysicalApplicationPath;
            //Get the application path
            inputPath = AppPath + "Video";
            //Path of the original file
            outputPath = AppPath + "Video";
            //Path of the converted file
            imgpath = AppPath + "Video";
            //Path of the preview file
            string filepath = Server.MapPath("~/Video/" + fileName);

            try
            {
                this.FileUploadVideo.SaveAs(filepath);
            }
            catch
            {
                return false;
            }
            
            string outPutFile;
            outPutFile = "~/Video/" + fileName;
            int i = this.FileUploadVideo.PostedFile.ContentLength;
            System.IO.FileInfo a = new System.IO.FileInfo(Server.MapPath(outPutFile));
            while (a.Exists == false)
            {

            }
            long b = a.Length;
            while (i != b)
            {

            }

            string cmd = " -i \"" + inputPath + "\\" + fileName + "\" -ar 22050 \"" + outputPath + "\\" + fileName.Remove(fileName.IndexOf(".")) + ".flv" + "\"";
            ConvertNow(cmd);
            string imgargs = " -i \"" + outputPath + "\\" + fileName.Remove(fileName.IndexOf(".")) + ".flv" + "\" -f image2 -ss 1 -vframes 1 -s 280x200 -an \"" + imgpath + "\\" + fileName.Remove(fileName.IndexOf(".")) + ".jpg" + "\"";
            ConvertNow(imgargs);
            //string cmd = " -i \"" + inputPath + "\\" + fileName + "\" -ar 22050 \"" + outputPath + "\\" + fileName + "_Converted" + "\"";
            //ConvertNow(cmd);
            //string imgargs = " -i \"" + outputPath + "\\" + fileName + "_thumb.jpg" + "\" -f image2 -ss 1 -vframes 1 -s 280x200 -an \"" + imgpath + "\\" + fileName + "_thumb.jpg" + "\"";
            //ConvertNow(imgargs);

            
            return true;
        }
        private void ConvertNow(string cmd)
        {
            string exepath;
            string AppPath = Request.PhysicalApplicationPath;
            //Get the application path
            exepath = AppPath + "ffmpeg.exe";
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = exepath;
            //Path of exe that will be executed, only for "filebuffer" it will be "flvtool2.exe"
            proc.StartInfo.Arguments = cmd;
            //The command which will be executed
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardOutput = false;
            proc.Start();

            while (proc.HasExited == false)
            {

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            divUploadVideo.Visible = AmIThePageOwner();
        }

        //protected void lbtnUploadNewVideo_Click(object sender, EventArgs e)
        //{
        //    divUploadVideo.Visible = !divUploadVideo.Visible;
        //}

        
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            divUploadVideo.Visible = !divUploadVideo.Visible;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (txtVideoTitle.Text.Length == 0)
            {
                lblUploadMessage.Text = "Please enter video title";
                return;
            }
            else { lblUploadMessage.Text = ""; }

            
            if (FileUploadVideo.PostedFile.ContentType.Contains("video") == false || FileUploadVideo.PostedFile.ContentLength > 20000000)
            {
                lblUploadMessage.Text = "Please upload video only(max size:20 MB)";
                return;
            }

            if (FileUploadVideo.HasFile == true )
                {
                    DAL.DataObject.Node ndVideo;
                    string fileName;
                    fileName = LoginHandler.LoggedInUser().Id.ToString() + "_" + DateTime.Now.Millisecond + "_" + FileUploadVideo.PostedFile.FileName;
                          
                    ndVideo = new BDDoctors.DAL.DataObject.Node();
                    try
                    {
                        if (ReturnVideo(fileName))
                        {
                             
                            ndVideo.User_id = LoginHandler.LoggedInUser().Id;
                            ndVideo.User_Name = LoginHandler.LoggedInUser().DisplayName;
                            ndVideo.Node_value = fileName;
                            ndVideo.Attribute_id = 41;
                            DAL.DataAccess.Node.SaveNode(ndVideo);




                            DAL.DataObject.Node ndTitle = new BDDoctors.DAL.DataObject.Node();
                            ndTitle.User_id = LoginHandler.LoggedInUser().Id;
                            ndTitle.User_Name = LoginHandler.LoggedInUser().DisplayName;
                            ndTitle.Node_value = txtVideoTitle.Text;
                            ndTitle.Attribute_id = 42;
                            ndTitle.Parent_Node_Id = ndVideo.Id;
                            DAL.DataAccess.Node.SaveNode(ndTitle);
                            BindInfo = true;
                            BindVideoList();
                            divUploadVideo.Visible = !divUploadVideo.Visible;
                         
                        }
                        
                    }
                    catch
                    {
                        DAL.DataAccess.Node.DeleteNodes(ndVideo.Id.Value);
                    }







                    
                    //lblSuccessMessage.Text = "Album created successfully";
                    //BindInfo = true;
                    //BindAlbumList();
                    
                }
        }

        protected void GridViewVideo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (e.Row.RowState)
                {

                    case DataControlRowState.Normal:
                    case DataControlRowState.Alternate:
                        System.Collections.Generic.List<DAL.DataObject.Node> NodeList = (System.Collections.Generic.List<DAL.DataObject.Node>)e.Row.DataItem;
                        //ASPNetFlashVideo.FlashVideo FlashVideo1 = (FlashVideo)e.Row.FindControl("FlashVideo1");
                        ImageButton imgbtnVideoImage = (ImageButton)e.Row.FindControl("imgbtnVideoImage");
                        Label lblTitleValue = (Label)e.Row.FindControl("lblTitleValue");
                        TextBox txtHiddenParentId = (TextBox)e.Row.FindControl("txtHiddenParentId");
                        
                        foreach (DAL.DataObject.Node nd in NodeList)
                        {
                            switch (nd.Attribute_id)
                            {
                                case 41:
                                    //FlashVideo1.VideoURL = "~/Video/" + nd.Node_value.Remove(nd.Node_value.LastIndexOf("."))+".flv";
                                    imgbtnVideoImage.ImageUrl = "~/Video/" + nd.Node_value.Remove(nd.Node_value.LastIndexOf(".")) + ".jpg";
                                    txtHiddenParentId.Text = nd.Parent_Node_Id.ToString();
                                    break;
                                case 42:
                                    lblTitleValue.Text = nd.Node_value.ToString();
                                    break;

                            }
                        }
                        break;
                }
            }
        }

        protected void GridViewVideo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow gr = GridViewVideo.Rows[e.NewEditIndex];
            ImageButton imgbtnVideoImage = (ImageButton)gr.FindControl("imgbtnVideoImage");
            FlashVideo1.VideoURL = imgbtnVideoImage.ImageUrl.Replace("jpg", "flv");
            Label lbl = (Label)gr.FindControl("lblTitleValue");
            TextBox txtHiddenParentId = (TextBox)gr.FindControl("txtHiddenParentId");
            txtNodeParent.Text = txtHiddenParentId.Text;
            BindComments(Convert.ToInt64(txtNodeParent.Text));
            GridReadMessage.Attributes.Add("parentid", txtNodeParent.Text);
            lblVideoTitle.Text = lbl.Text;


            //divImageDisplay.Visible = true;
            //imgBtnDisplayImage.Visible = true;
        }
        private void BindComments(Int64 ParentId)
        {
            System.Collections.Generic.List<DAL.DataObject.Node> AllNodes = DAL.DataAccess.Node.GetNodesOnly( ParentId);

            System.Collections.Generic.List<DAL.DataObject.Node> NodesButComment = DAL.DataAccess.Node.FilterNodeButCommentsAndImageAndVideo(AllNodes);
            System.Collections.Generic.List<DAL.DataObject.Node> comments = DAL.DataAccess.Node.FilterNodeComments(AllNodes);

            GridReadMessage.DataSource = comments;
            GridReadMessage.DataBind();
        }

        protected void GridReadMessage_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
            TextBox txtEnterMessage = (TextBox)GridReadMessage.FooterRow.FindControl("txtEnterMessage");
            if (txtEnterMessage.Text.Length > 0)
            {
                DAL.DataObject.Node nd = new DAL.DataObject.Node();
                nd.Parent_Node_Id = Convert.ToInt64(GridReadMessage.Attributes["parentid"]);
                nd.User_id = LoginHandler.LoggedInUser().Id.Value;
                nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtEnterMessage.Text);
                nd.Attribute_id = 36;
                nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
                DAL.DataAccess.Node.SaveCommentOrImageOrVideo(nd);
                BindComments(nd.Parent_Node_Id.Value);
               
            }
        }

    }
}