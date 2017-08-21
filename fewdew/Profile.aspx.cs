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
    public partial class Profile : System.Web.UI.Page
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

            string cmd = " -i \"" + inputPath + "\\" + fileName + "\" -ar 22050 \"" + outputPath + "\\" + fileName + ".flv" + "\"";
            ConvertNow(cmd);
            string imgargs = " -i \"" + outputPath + "\\" + fileName + ".flv" + "\" -f image2 -ss 1 -vframes 1 -s 280x200 -an \"" + imgpath + "\\" + fileName + ".jpg" + "\"";
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

            if (Page.IsPostBack == false)
            {
                lbtnMyPersona.Visible = AmIThePageOwner();
                dvPersona.Visible = AmIThePageOwner();
                serverStyle.InnerHtml = "div.delete-comment-of" + LoginHandler.LoggedInUser().Id.ToString() + " span.delete-comment{display:inline}"; 

                if (LoginHandler.IsLoggedIn == true && DAL.DataAccess.FriendShip.IsHeExistInTheList(PageOwner(), LoginHandler.GetLoggedInUserFriends()) == false)
                {
                   //lbtnAddAsConnection.Visible = !AmIThePageOwner();
                    anchorAddFriend.Visible = !AmIThePageOwner();
                    anchorAddFriend.HRef = "SendFriendRequest.aspx?user_id=" + Request["user"];
                }

                if (LoginHandler.IsLoggedIn == true)
                {
                    DAL.DataObject.User usr = DAL.DataAccess.User.GetUser(PageOwner());

                    if (AmIThePageOwner() == false)
                    {
                        //lbtnSendEmail.Visible = true;
                        anchorSendEmail.Visible = true;
                        anchorSendEmail.HRef = "SendEmail.aspx?user_id=" + Request["user"];
                        lbtnWhoseworld.Text = usr.DisplayName + "'s world ";
                        lblPageUserName.Text = usr.DisplayName + "'s Profile";
                        lbtnWorld.PostBackUrl = ResolveClientUrl("/chatroom.aspx?room_id=" + usr.Id.ToString());
                        //lbtnWorld.Text = usr.DisplayName + "'s world"; 
                    }
                    else
                    {
                        anchorSendEmail.Visible = false;
                        lblPageUserName.Text = " My Profile";
                        lbtnWhoseworld.Text = "My world";
                        hiddenInputAmITheOwner.Value = "YES";
                        lbtnWorld.PostBackUrl = ResolveClientUrl("/chatroom.aspx?room_id=" + usr.Id.ToString());
                        //lbtnWorld.Text = "My World";
                    }
                }


                //  UploadedPhoto1.BindInfo = false;

                HideAllTabPanel();
                lbtnUserInformation.CssClass = "Selected";
                divUserInformation.Visible = true;
            }
            else 
            
            {
                //hiddenInputIsItFavouritelist.Value = "NO";
            }




        }


        protected void lbtnSendEmail_Click(object sender, EventArgs e)
        {
            //divSendEmail.Visible = true;
            DAL.DataObject.User usr = DAL.DataAccess.User.GetUser(PageOwner());
            //txtTo.Text = usr.DisplayName;
            //lblValidationMessage.Text = "";
            //txtSubject.Text = "";
            //txtMessage.Text = "";
            //ulControl.Visible = true;

            //DAL.DataObject.Email eml = new BDDoctors.DAL.DataObject.Email();
            //eml.Sender_Id = LoginHandler.LoggedInUser().Id.Value;
            //eml.Reciever_Id = PageOwner();
            //eml.Subject = txtSubject.Text;
            //eml.Message = txtMessage.Text;
            //DAL.DataAccess.Email.SaveEmail(eml);
            //ulControl.Visible = false;
            //lblValidationMessage.Text = "Email Successfully sent";
        }

        //protected void btnSend_Click(object sender, EventArgs e)
        //{
        //    if (txtMessage.Text.Trim().Length == 0)
        //    {
        //        lblValidationMessage.Text = "Enter Message";
        //        return;
        //    }
        //    else {
        //        lblValidationMessage.Text ="" ;
        //    }
        //    DAL.DataObject.Email eml = new BDDoctors.DAL.DataObject.Email();
        //    eml.Sender_Id = LoginHandler.LoggedInUser().Id.Value;
        //    eml.Reciever_Id = PageOwner();
        //    eml.Subject = txtSubject.Text;
        //    eml.Message = txtMessage.Text;
        //    DAL.DataAccess.Email.SaveEmail(eml);
        //    ulControl.Visible = false;
        //    lblValidationMessage.Text = "Email Successfully sent";
        //   // divSendEmail.Style.Add("height", "20px");
            
        //}

        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    divSendEmail.Visible = false;
        //}

        //protected void imgBtnClose_Click(object sender, ImageClickEventArgs e)
        //{
        //    divSendEmail.Visible = false;
        //}

       
      

        //protected void lbtnPostNewBlog_Click(object sender, EventArgs e)
        //{
        //    UIhelper.PopulateCheckList(ChklistCategory, 28, null);
        //    lblValidationMessage.Text = "";
        //    divCreateNewBlog.Style.Add("height", "650px");
        //    txtDescription.Text = "";
        //    txtTitle.Text = "";
        //    foreach (ListItem li in ChklistCategory.Items)
        //    {
        //        li.Selected = false;
        //    }


        //    divCreateNewBlog.Visible = !divCreateNewBlog.Visible;
        //    txtTitle.Visible = true;
        //    txtDescription.Visible = true;
        //    ChklistCategory.Visible = true;
        //    btnCancel.Visible = true;
        //    btnSend.Visible = true;
        //    updatePanelCreateBlog.Update();
        //}

        //protected void lbtnClose_Click(object sender, EventArgs e)
        //{
        //    divCreateNewBlog.Visible = !divCreateNewBlog.Visible;
        //    updatePanelCreateBlog.Update();
        //}

        //protected void btnPost_Click(object sender, EventArgs e)
        //{
        //    Boolean IsValidate = true;
        //    string message = "Please Enter";
        //    if (txtTitle.Text.Trim().Length < 1)
        //    {
        //        message += " (Title) ";
        //        IsValidate = false;
        //    }
        //    if (txtDescription.Text.Trim().Length < 1)
        //    {
        //        message += " (Description) ";
        //        IsValidate = false;
        //    }

        //    if (txtTitle.Text.Trim().Length < 1)
        //    {
        //        message += " (Title) ";
        //        IsValidate = false;
        //    }
        //    Boolean singleChecked = false;
        //    foreach (ListItem li in ChklistCategory.Items)
        //    {
        //        if (li.Selected == true)
        //        {
        //            singleChecked = true;
        //        }
        //    }
        //    if (singleChecked == false)
        //    {
        //        message += " (Category) ";
        //        IsValidate = false;
        //    }
        //    if (IsValidate == false)
        //    {
        //        lblValidationMessageForBlog.Text = message;
        //        return;
        //    }
        //    else { lblValidationMessageForBlog.Text = ""; }

        //    if (FileUpoadBlogImage.HasFile)
        //    {
        //        if (FileUpoadBlogImage.PostedFile.ContentType.Contains("image") == false)
        //        {
        //            IsValidate = false;
        //            lblValidationMessageForBlog.Text = "UPLOAD IMAGE(jpg,jpeg,bmp,png,gif)";
        //            return ;

        //        }
                
        //    }



        //    System.Collections.Generic.List<DAL.DataObject.Node> nodes = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();

        //    DAL.DataObject.Node nd;
        //    nd = new BDDoctors.DAL.DataObject.Node();
        //    nd.User_id = LoginHandler.LoggedInUser().Id.Value;
        //    nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
        //    nd.Attribute_id = 33;
        //    nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtTitle.Text);
        //    nodes.Add(nd);

        //    nd = new BDDoctors.DAL.DataObject.Node();
        //    nd.User_id = LoginHandler.LoggedInUser().Id.Value;
        //    nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
        //    nd.Attribute_id = 34;
        //    nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtDescription.Text);
        //    nodes.Add(nd);

        //    nd = new BDDoctors.DAL.DataObject.Node();
        //    nd.User_id = LoginHandler.LoggedInUser().Id.Value;
        //    nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
        //    nd.Attribute_id = 35;
        //    string Category = string.Empty;
        //    foreach (ListItem lItem in ChklistCategory.Items)
        //    {
        //        if (lItem.Selected == true)
        //        {
        //            if (Category == string.Empty)
        //            {
        //                Category = Category + lItem.Value;
        //            }
        //            else
        //            {
        //                Category = Category + "," + lItem.Value;
        //            }

        //        }
        //    }
        //    nd.Node_value = Category;
        //    nd.User_id = LoginHandler.LoggedInUser().Id.Value;
        //    nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
        //    nodes.Add(nd);


        //    Boolean imageValidate = true;
        //    if (FileUpoadBlogImage.HasFile)
        //    {
        //        if (FileUpoadBlogImage.PostedFile.ContentType.Contains("image") == false)
        //        {
        //            imageValidate = false;
        //            lblPhotoInformation.Text = "UPLOAD IMAGE(jpg,jpeg,bmp,png,gif)";

        //        }
        //    }


        // Int64 parent_id=   DAL.DataAccess.Node.SaveNodes(nodes);
        // if (FileUpoadBlogImage.HasFile)
        // {

        //     DAL.DataObject.Node ndImage = new BDDoctors.DAL.DataObject.Node();
        //     ndImage.Parent_Node_Id = parent_id;
        //     ndImage.User_id = LoginHandler.LoggedInUser().Id;
        //     ndImage.User_Name = LoginHandler.LoggedInUser().DisplayName;
        //     ndImage.Node_value = "Nothing";
        //     ndImage.Attribute_id = 37;
        //     DAL.DataAccess.Node.SaveCommentOrImageOrVideo(ndImage);
        //     ndImage.Node_value = ndImage.Id.ToString();
        //     DAL.DataAccess.Node.SaveNode(ndImage);


        //     //strFileName = ndImage.Node_value;
        //     FileUpoadBlogImage.PostedFile.SaveAs(Server.MapPath("/images/Node/") + ndImage.Node_value);
        //     BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/Node/"), ndImage.Node_value, FileUpoadBlogImage.PostedFile.ContentType);
        // }
                   



           
        //    lblSuccessfullyBlogPostMessage.Text = "Blog Successfully posted";
        //    divCreateNewBlog.Visible = !divCreateNewBlog.Visible;
          
        //    divUserBlogList.Visible = true;
        //    updatePanelCreateBlog.Update();
        //    BindUserBlogs();
            
        //}

        //protected void btnClose_Click(object sender, EventArgs e)
        //{
        //    divCreateNewBlog.Visible = !divCreateNewBlog.Visible;
        //}
     
        protected void lbtnStatusChangeInit_Click(object sender, EventArgs e)
        {
           
        }

      

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (txtVideoTitle.Text.Length == 0)
            {
                lblUploadMessage.Text = "Please enter video title";
                return;
            }
            else { lblUploadMessage.Text = ""; }


            if (FileUploadVideo.PostedFile.ContentType.Contains("video") == false || FileUploadVideo.PostedFile.ContentLength > 400000000)
            {
                lblUploadMessage.Text = "Please upload video only(max size:400 MB)";
                return;
            }

            if (FileUploadVideo.HasFile == true)
            {
                DAL.DataObject.Node ndVideo;
                string fileName;
                fileName = LoginHandler.LoggedInUser().Id.ToString() + "_" + DateTime.Now.Millisecond.ToString();// + "_" + FileUploadVideo.PostedFile.FileName;
                ndVideo = new BDDoctors.DAL.DataObject.Node();
                try
                {
                    if (ReturnVideo(fileName))
                    {

                       // Server.MapPath("~/Video/" + fileName)

                       

                        ndVideo.User_id = LoginHandler.LoggedInUser().Id;
                        ndVideo.User_Name = LoginHandler.LoggedInUser().DisplayName;
                        ndVideo.Node_value = fileName;
                        ndVideo.Attribute_id = 41;
                        DAL.DataAccess.Node.SaveNode(ndVideo);
                        System.IO.File.Move(Server.MapPath("~/Video/" + fileName+".flv"), Server.MapPath("~/Video/" + ndVideo.Id.ToString()+".flv"));
                        System.IO.File.Move(Server.MapPath("~/Video/" + fileName+".jpg"), Server.MapPath("~/Video/" + ndVideo.Id.ToString()+".jpg"));




                        DAL.DataObject.Node ndTitle = new BDDoctors.DAL.DataObject.Node();
                        ndTitle.User_id = LoginHandler.LoggedInUser().Id;
                        ndTitle.User_Name = LoginHandler.LoggedInUser().DisplayName;
                        ndTitle.Node_value = txtVideoTitle.Text;
                        ndTitle.Attribute_id = 42;
                        ndTitle.Parent_Node_Id = ndVideo.Id;
                        DAL.DataAccess.Node.SaveNode(ndTitle);
                       


                    }

                }
                catch
                {
                    DAL.DataAccess.Node.DeleteNodes(ndVideo.Id.Value);
                }
                finally { bindUsersUploadedVideo(); }








                //lblSuccessMessage.Text = "Album created successfully";
                //BindInfo = true;
                //BindAlbumList();

            }
        }

        protected void btnCreatAlbum_Click(object sender, EventArgs e)
        {
            if (txtalbumTitle.Text.Length > 0)
            {
                DAL.DataObject.Node ndAlbum = new BDDoctors.DAL.DataObject.Node();

                ndAlbum.User_id = LoginHandler.LoggedInUser().Id;
                ndAlbum.User_Name = LoginHandler.LoggedInUser().DisplayName;
                ndAlbum.Node_value = txtalbumTitle.Text;
                ndAlbum.Attribute_id = 39;
                DAL.DataAccess.Node.SaveNode(ndAlbum);
                //   ndAlbum.Node_value = ndAlbum.Id.ToString();
                //  ndAlbum.Parent_Node_Id = ndAlbum.Id;
                //  DAL.DataAccess.Node.SaveNode(ndAlbum);
                divCreateNewAlbum.Visible = !divCreateNewAlbum.Visible;
                Response.Redirect(ResolveClientUrl("~\\photoalbum.aspx") + "?" + "PhotoAlbum=" + ndAlbum.Id.Value.ToString());
                //  lblSuccessMessage.Text = "Album created successfully";
                //   BindInfo = true;
                // BindAlbumList();
                //  updatePanelBlogList.Update();

            }
            else
            {
                lblValidationMessageForAlbum.Text = "Enter an album name";
            }
        }


        #region "Binding methods"
        //protected void GridContentBasedNotification_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    System.Collections.Generic.List<DAL.DataObject.Node> NodeList;
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        switch (e.Row.RowState)
        //        {

        //            case DataControlRowState.Normal:
        //            case DataControlRowState.Alternate:
        //                NodeList = (System.Collections.Generic.List<DAL.DataObject.Node>)e.Row.DataItem;
        //                BDDoctors.Controls.Comment CommentControl = (BDDoctors.Controls.Comment)e.Row.FindControl("Comment1");

        //                //nd= DAL.DataAccess.Node.GetParentNode(NodeList)[0];
        //                DAL.DataObject.Node parentNode;
        //                if (NodeList.Count > 0)
        //                {
        //                    parentNode = DAL.DataAccess.Node.GetParentNode(NodeList)[0];
        //                    LinkButton lbtnFavourite = (LinkButton)e.Row.FindControl("lbtnFavourite");
        //                    lbtnFavourite.Attributes.Add("parent_id", parentNode.Id.Value.ToString()+","+parentNode.feature_Name.ToString());
        //                    switch (parentNode.Attribute_id.Value)
        //                    {
        //                        case 39:
        //                            BDDoctors.Controls.FeedRelated.Notif_UploadedImage Notif_UploadedImage1 = (BDDoctors.Controls.FeedRelated.Notif_UploadedImage)e.Row.FindControl("Notif_UploadedImage1");
        //                            Notif_UploadedImage1.NodeList = NodeList;
        //                            Notif_UploadedImage1.Visible = true;
        //                            CommentControl.NodeList = NodeList;
        //                            break;
        //                        case 41:
        //                            BDDoctors.Controls.Notif_UploadedVideo Notif_UploadedVideo1 = (BDDoctors.Controls.Notif_UploadedVideo)e.Row.FindControl("Notif_UploadedVideo1");

        //                            Notif_UploadedVideo1.NodeList = NodeList;
        //                            Notif_UploadedVideo1.Visible = true;
        //                            CommentControl.NodeList = NodeList;
        //                            break;
        //                        case 54:
        //                            BDDoctors.Controls.FeedRelated.Notif_UserStatus NotifUserStatus = (BDDoctors.Controls.FeedRelated.Notif_UserStatus)e.Row.FindControl("Notif_UserStatus1");

        //                            NotifUserStatus.NodeList = NodeList;
        //                            NotifUserStatus.Visible = true;
        //                            CommentControl.NodeList = NodeList;
        //                            break;
        //                        case 33:
        //                            BDDoctors.Controls.Notif_Blog Notif_Blog = (BDDoctors.Controls.Notif_Blog)e.Row.FindControl("Notif_Blog1");

        //                            Notif_Blog.NodeList = NodeList;
        //                            Notif_Blog.Visible = true;
        //                            CommentControl.NodeList = NodeList;
        //                            break;
        //                        case 43:
        //                            BDDoctors.Controls.NotifTreatPanel NotifTreatPanel = (BDDoctors.Controls.NotifTreatPanel)e.Row.FindControl("NotifTreatPanel1");

        //                            NotifTreatPanel.NodeList = NodeList;
        //                            NotifTreatPanel.Visible = true;
        //                            CommentControl.NodeList = NodeList;
        //                            break;
        //                        default:
        //                            CommentControl.Visible = false;
        //                            break;

        //                    }
        //                }
        //                //if (DAL.DataAccess.Node.GetParentNode(NodeList)[0].Attribute_id.Value == 39)
        //                //{
        //                //    BDDoctors.Controls.FeedRelated.Notif_UploadedImage Notif_UploadedImage1 = (BDDoctors.Controls.FeedRelated.Notif_UploadedImage)e.Row.FindControl("Notif_UploadedImage1");

        //                //    Notif_UploadedImage1.NodeList = NodeList;
        //                //    Notif_UploadedImage1.Visible = true;
        //                //}


        //                break;
        //        }



        //    }

        //}

        protected void GridContentBasedNotification_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {


                System.Collections.Generic.List<DAL.DataObject.Node> NodeList;

                NodeList = (System.Collections.Generic.List<DAL.DataObject.Node>)e.Item.DataItem;
                BDDoctors.Controls.Comment CommentControl = (BDDoctors.Controls.Comment)e.Item.FindControl("Comment1");

                //nd= DAL.DataAccess.Node.GetParentNode(NodeList)[0];
                DAL.DataObject.Node parentNode;
                if (NodeList.Count > 0)
                {
                    parentNode = DAL.DataAccess.Node.GetParentNode(NodeList)[0];

                    Panel pnlDelete = (Panel)(e.Item.FindControl("pnlDelete"));
                    if (parentNode.User_id.Value == LoginHandler.LoggedInUser().Id.Value)
                    {
                        pnlDelete.Visible = true;
                        pnlDelete.ToolTip = parentNode.Id.ToString();
                    }
                    switch (parentNode.Attribute_id.Value)
                    {
                        case 39:
                            BDDoctors.Controls.FeedRelated.Notif_UploadedImage Notif_UploadedImage1 = (BDDoctors.Controls.FeedRelated.Notif_UploadedImage)e.Item.FindControl("Notif_UploadedImage1");
                            Notif_UploadedImage1.NodeList = NodeList;
                            Notif_UploadedImage1.Visible = true;
                            CommentControl.NodeList = NodeList;
                            break;
                        case 41:
                            BDDoctors.Controls.Notif_UploadedVideo Notif_UploadedVideo1 = (BDDoctors.Controls.Notif_UploadedVideo)e.Item.FindControl("Notif_UploadedVideo1");

                            Notif_UploadedVideo1.NodeList = NodeList;
                            Notif_UploadedVideo1.Visible = true;
                            CommentControl.NodeList = NodeList;
                            break;
                        case 54:
                            BDDoctors.Controls.FeedRelated.Notif_UserStatus NotifUserStatus = (BDDoctors.Controls.FeedRelated.Notif_UserStatus)e.Item.FindControl("Notif_UserStatus1");

                            NotifUserStatus.NodeList = NodeList;
                            NotifUserStatus.Visible = true;
                            CommentControl.NodeList = NodeList;
                            break;
                        case 33:
                            BDDoctors.Controls.Notif_Blog Notif_Blog = (BDDoctors.Controls.Notif_Blog)e.Item.FindControl("Notif_Blog1");

                            Notif_Blog.NodeList = NodeList;
                            Notif_Blog.Visible = true;
                            CommentControl.NodeList = NodeList;
                            break;
                        case 43:
                            BDDoctors.Controls.NotifTreatPanel NotifTreatPanel = (BDDoctors.Controls.NotifTreatPanel)e.Item.FindControl("NotifTreatPanel1");

                            NotifTreatPanel.NodeList = NodeList;
                            NotifTreatPanel.Visible = true;
                            CommentControl.NodeList = NodeList;
                            break;
                        case 55:
                            BDDoctors.Controls.FeedRelated.NotifPoll NotifPoll = (BDDoctors.Controls.FeedRelated.NotifPoll)e.Item.FindControl("NotifPoll1");

                            NotifPoll.NodeList = NodeList;
                            NotifPoll.Visible = true;
                            CommentControl.NodeList = NodeList;
                            break;
                        case 62:
                            BDDoctors.Controls.FeedRelated.Noti_WorldLocation_Changed Noti_WorldLocation_Changed = (BDDoctors.Controls.FeedRelated.Noti_WorldLocation_Changed)e.Item.FindControl("Noti_WorldLocation_Changed1");

                            Noti_WorldLocation_Changed.NodeList = NodeList;
                            Noti_WorldLocation_Changed.Visible = true;
                            CommentControl.NodeList = NodeList;
                            break;
                        case 63:
                            BDDoctors.Controls.FeedRelated.NotifSingleImage NotifSingleImage = (BDDoctors.Controls.FeedRelated.NotifSingleImage)e.Item.FindControl("NotifSingleImage1");

                            NotifSingleImage.NodeList = NodeList;
                            NotifSingleImage.Visible = true;
                            CommentControl.NodeList = NodeList;
                            break;
                        default:
                            CommentControl.Visible = false;
                            break;

                    }
                }





            }

        }

        //protected void GridContentBasedNotification_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    LinkButton lbtnFavourite = (LinkButton)GridContentBasedNotification.Rows[e.RowIndex].FindControl("lbtnFavourite");
        //    LinkButton lbtnDelete = (LinkButton)GridContentBasedNotification.Rows[e.RowIndex].FindControl("lbtnDelete");
        //    UpdatePanel UpdatePanelItem = (UpdatePanel)GridContentBasedNotification.Rows[e.RowIndex].FindControl("UpdatePanelItem");
        //    string ParentId = (string)lbtnFavourite.Attributes["parent_id"];
        //    // DAL.DataAccess.Node.SaveToFavList(Convert.ToInt64(ParentId), LoginHandler.LoggedInUser().Id.Value);

        //    //if (DAL.DataAccess.Node.DeleteNodes(Convert.ToInt64(ParentId)))
        //    //{
        //    //GridContentBasedNotification.Rows[e.RowIndex].Visible = false;

        //    Label lbl = new Label();
        //    lbl.Text = "Item Deleted permanently";
        //    UpdatePanelItem.ContentTemplateContainer.Controls.Clear();
        //    UpdatePanelItem.ContentTemplateContainer.Controls.Add(lbl);
        //    UpdatePanelItem.Update();
        //    //}
        //}
       
        //protected void GridContentBasedNotification_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    UpdatePanel UpdatePanelItem = (UpdatePanel)GridContentBasedNotification.Rows[e.NewEditIndex].FindControl("UpdatePanelItem");
        //    LinkButton lbtnFavourite = (LinkButton)GridContentBasedNotification.Rows[e.NewEditIndex].FindControl("lbtnFavourite");
        //    string s = lbtnFavourite.CssClass;
        //    string ParentIdAndFeatureName = (string)lbtnFavourite.Attributes["parent_id"];
        //    string[] items = ParentIdAndFeatureName.Split(',');
        //    if (DAL.DataAccess.Node.SaveToFavList(Convert.ToInt64(items[0]),LoginHandler.LoggedInUser().Id.Value,Convert.ToString(items[1]) ))
        //    {
        //        lbtnFavourite.Text = "Added to your favourite list";
        //    }
        //    else
        //    {
        //        lbtnFavourite.Text = "Already in your favourite list";
        //    }
        //    lbtnFavourite.Enabled = false;
        //    UpdatePanelItem.Update();
        //}
        #endregion

       
        #region "Bind Command events"
        private void HideAllTabPanel()
        {
            divUserInformation.Visible = false;
            divUserBlogList.Visible = false;
            divUploadedVideo.Visible = false;
            DivUploadedImage.Visible = false;
          
            dvPersona.Visible = false;
            divTreatMentPanel.Visible = false;
            lbtnUserInformation.CssClass = "Deselected";
            lbtnUserBlog.CssClass = "Deselected";
            lbtnUploadedVideo.CssClass = "Deselected";
            lbtnUploadedImage.CssClass = "Deselected";
            lbtnMyTreatpanel.CssClass = "Deselected";
            lbtnMyPersona.CssClass = "Deselected";
            lbtnMyPreviousStatus.CssClass = "Deselected";
            lbtnMyFavouriteList.CssClass = "Deselected";


        }

        protected void lbtnUserInformation_Click(object sender, EventArgs e)
        {
            hiddenInputIsFavClicked.Value = "NO";
            HideAllTabPanel();
            GridContentBasedNotification.Visible = false;
            divUserInformation.Visible = true;
            lbtnUserInformation.CssClass = "Selected";
           
        }

        protected void lbtnUserBlog_Click(object sender, EventArgs e)
        {
            hiddenInputIsFavClicked.Value = "NO";
            HideAllTabPanel();
            GridContentBasedNotification.Visible = true;
          //  lbtnPostNewBlog.Visible = AmIThePageOwner();
          //  divUserBlogList.Visible = true;
          //  BindUserBlogs();


            lbtnUserBlog.CssClass = "Selected";
        }
        ////private void BindUserBlogs() 
        ////{
        ////    System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListNodes = DAL.DataAccess.Node.GetListNodesOnly("Blog", PageOwner());
        ////    GridContentBasedNotification.DataSource = ListNodes;
        ////    GridContentBasedNotification.DataBind();
        ////}

        protected void lbtnUploadedImage_Click(object sender, EventArgs e)
        {
            hiddenInputIsFavClicked.Value = "NO";
            HideAllTabPanel();
            GridContentBasedNotification.Visible = true;
            //UploadedPhoto1.BindInfo = true;
            DivUploadedImage.Visible = AmIThePageOwner();
            lbtnUploadedImage.CssClass = "Selected";

            BindUserImage();
           
        }
        private void BindUserImage()
        {
            //System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListNodes = DAL.DataAccess.Node.GetListNodesOnly("Photo Album", PageOwner());
            //GridContentBasedNotification.DataSource = ListNodes;
            //GridContentBasedNotification.DataBind();
        }


        protected void lbtnUploadedVideo_Click(object sender, EventArgs e)
        {
            hiddenInputIsFavClicked.Value = "NO";
            HideAllTabPanel();
            divUploadedVideo.Visible = AmIThePageOwner();
            GridContentBasedNotification.Visible = true;
            bindUsersUploadedVideo();
            lbtnUploadedVideo.CssClass = "Selected";

           
            //DivUploadedImage.Visible = true;
        }
        private void bindUsersUploadedVideo()
        {
            //System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListNodes = DAL.DataAccess.Node.GetListNodesOnly("Uploaded Video", PageOwner());
            //GridContentBasedNotification.DataSource = ListNodes;
            //GridContentBasedNotification.DataBind();

        }

        protected void lbtnMyTreatpanel_Click(object sender, EventArgs e)
        {
            hiddenInputIsFavClicked.Value = "NO";
            HideAllTabPanel();
            divTreatMentPanel.Visible = AmIThePageOwner();
            GridContentBasedNotification.Visible = true;
            lbtnMyTreatpanel.CssClass = "Selected";
            BindUsersTreamentPanel();
        }
        private void BindUsersTreamentPanel()
        {
            //GridContentBasedNotification.DataSource = DAL.DataAccess.Node.GetListNodesOnly("Treatment panel", PageOwner());
            //GridContentBasedNotification.DataBind();
        }

        protected void lbtnMyPersona_Click(object sender, EventArgs e)
        {
            hiddenInputIsFavClicked.Value = "NO";
            HideAllTabPanel();

            lbtnMyPersona.CssClass = "Selected";

            GridContentBasedNotification.Visible = false;

           
        }

        protected void lbtnMyPreviousStatus_Click(object sender, EventArgs e)
        {
            hiddenInputIsFavClicked.Value = "NO";
            HideAllTabPanel();
            GridContentBasedNotification.Visible = true;
           
            lbtnMyPreviousStatus.CssClass = "Selected";
            bindUserPreviousStatus();
        }
        private void bindUserPreviousStatus()
        {
            //GridContentBasedNotification.DataSource = DAL.DataAccess.Node.GetListNodesOnly("User Status", PageOwner());
            //GridContentBasedNotification.DataBind();
        }
        protected void lbtnMyFavouriteList_Click(object sender, EventArgs e)
        {
            hiddenInputIsFavClicked.Value = "YES";
            HideAllTabPanel();
            //hiddenInputIsItFavouritelist.Value = "YES";
            lbtnMyFavouriteList.CssClass = "Selected";
            BindUserFavouriteList();
        }
        private void BindUserFavouriteList()
        {
            GridContentBasedNotification.DataSource = DAL.DataAccess.Node.GetMyFavouriteFeeds(PageOwner());
            GridContentBasedNotification.DataBind();
        }

        #endregion

        //protected void lbtnAddAsConnection_Click(object sender, EventArgs e)
        //{
        //    ClickedOnAddConnectionButton1.Visible = true;
        //    ClickedOnAddConnectionButton1.User2Id = PageOwner();
        //    lbtnAddAsConnection.Visible = false;
        //}

        //protected void GridContentBasedNotification_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    UpdatePanel UpdatePanelItem = (UpdatePanel)GridContentBasedNotification.Rows[e.RowIndex].FindControl("UpdatePanelItem");
        //    LinkButton lbtnFavourite = (LinkButton)GridContentBasedNotification.Rows[e.RowIndex].FindControl("lbtnFavourite");
        //    LinkButton lbtnRemoveFromFavList = (LinkButton)GridContentBasedNotification.Rows[e.RowIndex].FindControl("lbtnRemoveFromFavList");

        //    string s = lbtnFavourite.CssClass;
        //    string ParentIdAndFeatureName = (string)lbtnFavourite.Attributes["parent_id"];
        //    string[] items = ParentIdAndFeatureName.Split(',');

        //    if (DAL.DataAccess.Node.RemoveFromFavList(Convert.ToInt64(items[0]), LoginHandler.LoggedInUser().Id.Value, Convert.ToString(items[1])))
        //    {
        //        lbtnRemoveFromFavList.Text = "Item removed from your favourite list";
        //    }

        //    lbtnRemoveFromFavList.Enabled = false;
        //    UpdatePanelItem.Update();
        //}

        private void BindUserWall()
        {
            GridContentBasedNotification.DataSource = DAL.DataAccess.Node.GetUserWallNodesList(PageOwner());
            GridContentBasedNotification.DataBind();

        }

        protected void lbtnWall_Click(object sender, EventArgs e)
        {
            divUserInformation.Visible = false;
            //divUserBlogList.Visible = false;
            //divUploadedVideo.Visible = false;
            //DivUploadedImage.Visible = false;

            BindUserWall();
            SpanMenu.InnerText = lbtnWall.Text;
        }

        protected void lbtnInfo_Click(object sender, EventArgs e)
        {
            divUserInformation.Visible = true;
            //divUserBlogList.Visible = true;
            //divUploadedVideo.Visible = true;
            //DivUploadedImage.Visible = true;

            SpanMenu.InnerText = lbtnInfo.Text;
        }


    }
}
