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
using System.Web.Services;
using System.IO;
namespace BDDoctors
{

    public partial class Home2 : System.Web.UI.Page
    {

        #region "web method"
        [WebMethod]
        public static string UploadSingleImage(string ParentNodeId)
        {
           
            try
            {
                StringWriter writer = new StringWriter();
                HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
                System.Web.UI.Page pg = new Page();
                pg.EnableEventValidation = false;
                String StatusPart = string.Empty;
                System.Collections.Generic.List<DAL.DataObject.Node> nodes = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();

                if (LoginHandler.IsLoggedIn == false)
                {
                    return "<h3>To upload photo  please do login</h3>";
                }

                ParentNodeId = ParentNodeId.Replace("<pre>", "");
                ParentNodeId = ParentNodeId.Replace("</pre>", "");


                    nodes = DAL.DataAccess.Node.GetNodesOnly( Convert.ToInt64( ParentNodeId));

                    BDDoctors.Controls.FeedRelated.NotifSingleImage NotifSingleImage = (BDDoctors.Controls.FeedRelated.NotifSingleImage)pg.LoadControl("~/Controls/FeedRelated/NotifSingleImage.ascx");
                    NotifSingleImage.NodeList = nodes;
                    NotifSingleImage.RenderControl(htmlWriter);

                    StatusPart = writer.ToString();

                    BDDoctors.Controls.Comment CommentControl = (BDDoctors.Controls.Comment)pg.LoadControl("Controls/Comment.ascx");
                    CommentControl.showAllComment = true;
                    //System.Collections.Generic.List<DAL.DataObject.Node> nodelist = DAL.DataAccess.Node.GetShortNodesByParentNodeId(Convert.ToInt64(parentid));
                    CommentControl.NodeList = nodes;
                    CommentControl.RenderControl(htmlWriter);

                    return writer.ToString();
               
            }
            catch (Exception e)
            {
                return "Invalid file type, only jpg,jpeg,bmp type files are supported";
            }
                    //return writer.ToString();

        }
        //[WebMethod]
        //// Get session state value.
        //public static string GetMyName(string key)
        //{

        //    StringWriter writer = new StringWriter();
        //    HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);


        //    System.Web.UI.Page pg = new Page();

        //    BDDoctors.Controls.Comment CommentControl = (BDDoctors.Controls.Comment)pg.LoadControl("Controls/Comment.ascx");

        //    System.Collections.Generic.List<DAL.DataObject.Node> nodelist = DAL.DataAccess.Node.GetNodesOnly("Blog", 53);
        //    CommentControl.NodeList = nodelist;
        //    CommentControl.RenderControl(htmlWriter);

        //    return writer.ToString();
        //}
        [WebMethod]
        public static string FetchFeed(int type)
        {
            try
            {
                if (LoginHandler.IsLoggedIn == false)
                {
                    return "<h3>To Get Feed please do login</h3>";
                }

                System.Web.UI.Page pg = new Page();

                pg.EnableEventValidation = false;

                BDDoctors.Controls.ContentBasedFeed ContentBasedFeed = (BDDoctors.Controls.ContentBasedFeed)pg.LoadControl("~/Controls/ContentBasedFeed.ascx");

          

                if (type == 0)
                {
                    ContentBasedFeed.NodesList = DAL.DataAccess.Node.GetFriendzContentBasedNotification(LoginHandler.LoggedInUser().Id.Value);
                   
                }
                else
                {
                    ContentBasedFeed.NodesList = DAL.DataAccess.Node.GetPublicContentBasedNotification();
                    
                }

                StringWriter writer = new StringWriter();
                HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);


               
                ContentBasedFeed.RenderControl(htmlWriter);

                return writer.ToString();
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }



        [WebMethod]
        public static string PostComment(string comment, int parentid)
        {
            try
            { 
            if (LoginHandler.IsLoggedIn == false)
            {
                return "<h3>To post comment please do login</h3>";
            }


            DAL.DataObject.Node nd = new DAL.DataObject.Node();

            nd.Parent_Node_Id = parentid;
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(comment);
            nd.Attribute_id = 36;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            DAL.DataAccess.Node.SaveCommentOrImageOrVideo(nd);



            StringWriter writer = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);


            System.Web.UI.Page pg = new Page();

            pg.EnableEventValidation = false; 
            BDDoctors.Controls.Comment CommentControl = (BDDoctors.Controls.Comment)pg.LoadControl("Controls/Comment.ascx");
            CommentControl.showAllComment = true;
            System.Collections.Generic.List<DAL.DataObject.Node> nodelist = DAL.DataAccess.Node.GetShortNodesByParentNodeId(Convert.ToInt64(parentid));
            CommentControl.NodeList = nodelist;
            CommentControl.RenderControl(htmlWriter);

            return writer.ToString();
            }
            catch( Exception e)
            {
                return e.Message.ToString();
            }
        }
        
         [WebMethod]
        public static string DeleteContent(string parentId)
        {
            try
            {
                if (LoginHandler.IsLoggedIn == false)
                {
                    return "<h3>To delete post please do login</h3>";
                }

                if (DAL.DataAccess.Node.DeleteNodes(Convert.ToInt64(parentId)))
                {
                    return "<span style='color:red'>Deleted</span>";
                }
                
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }

            return "Operation failed";
         
        }


        [WebMethod]
        public static string DeleteComment(string commentid)
        {
            try
            {
                if (LoginHandler.IsLoggedIn == false)
                {
                    return "<h3>To delete comment please do login</h3>";
                }


                DAL.DataObject.Node nd=DAL.DataAccess.Node.GetShortNodeByID(Convert.ToInt64(commentid));

                DAL.DataAccess.Node.DeleteNodes(Convert.ToInt64(commentid));



                StringWriter writer = new StringWriter();
                HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);


                System.Web.UI.Page pg = new Page();

                pg.EnableEventValidation = false;
                BDDoctors.Controls.Comment CommentControl = (BDDoctors.Controls.Comment)pg.LoadControl("Controls/Comment.ascx");
                CommentControl.showAllComment = true;
                System.Collections.Generic.List<DAL.DataObject.Node> nodelist = DAL.DataAccess.Node.GetShortNodesByParentNodeId(nd.Parent_Node_Id.Value);
                CommentControl.NodeList = nodelist;
                CommentControl.RenderControl(htmlWriter);

                return writer.ToString();
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }


         
        }

        [WebMethod]
        public static string PostStatusMessage(string comment)
        {
            try
            {
                StringWriter writer = new StringWriter();
                HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
                System.Web.UI.Page pg = new Page();
                pg.EnableEventValidation = false;
                String StatusPart = string.Empty;
                System.Collections.Generic.List<DAL.DataObject.Node> nodes = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();
                if (LoginHandler.IsLoggedIn == false)
                {
                    return "<h3>To post Status please do login</h3>";
                }
                if (comment.Length > 0)
                {
                   
                    DAL.DataObject.Node nd;
                    nd = new BDDoctors.DAL.DataObject.Node();
                    nd.User_id = LoginHandler.LoggedInUser().Id.Value;
                    nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
                    nd.Wall_Owner_id = LoginHandler.LoggedInUser().Id.Value;
                    nd.Wall_Owner_Name = LoginHandler.LoggedInUser().DisplayName;

                    nd.Attribute_id = 54;
                    nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(comment);
                    nodes.Add(nd);
                    Int64 parent_id = DAL.DataAccess.Node.SaveNodes(nodes);

                    nodes = DAL.DataAccess.Node.GetNodesOnly( parent_id);

                    BDDoctors.Controls.FeedRelated.Notif_UserStatus userStatusCtrl = (BDDoctors.Controls.FeedRelated.Notif_UserStatus)pg.LoadControl("~/Controls/FeedRelated/Notif_UserStatus.ascx");
                    userStatusCtrl.NodeList = nodes;
                    userStatusCtrl.RenderControl(htmlWriter);
                  
                    StatusPart = writer.ToString();
                   
                    BDDoctors.Controls.Comment CommentControl = (BDDoctors.Controls.Comment)pg.LoadControl("Controls/Comment.ascx");
                    CommentControl.showAllComment = true;
                   //System.Collections.Generic.List<DAL.DataObject.Node> nodelist = DAL.DataAccess.Node.GetShortNodesByParentNodeId(Convert.ToInt64(parentid));
                    CommentControl.NodeList = nodes;
                    CommentControl.RenderControl(htmlWriter);
                    
                    return  writer.ToString();


                    //return writer.ToString();

                }

                //DAL.DataObject.Node nd = new DAL.DataObject.Node();

                //nd.Parent_Node_Id = parentid;
                //nd.User_id = LoginHandler.LoggedInUser().Id.Value;
                //nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(comment);
                //nd.Attribute_id = 36;
                //nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
                //DAL.DataAccess.Node.SaveCommentOrImageOrVideo(nd);









                return "kichui nai";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        //[WebMethod]
        //public static string ShowAllComment(Int64 parentId)
        //{
        //    //parentId = (Int64)parentId;

        //    //DAL.DataObject.Node nd = new DAL.DataObject.Node();

        //    //nd.Parent_Node_Id = parentId;
        //    //nd.User_id = LoginHandler.LoggedInUser().Id.Value;
        //    //nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(Comment);
        //    //nd.Attribute_id = 36;
        //    //nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
        //    //DAL.DataAccess.Node.SaveCommentOrImageOrVideo(nd);



        //    StringWriter writer = new StringWriter();
        //    HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);


        //    System.Web.UI.Page pg = new Page();

        //    BDDoctors.Controls.Comment CommentControl = (BDDoctors.Controls.Comment)pg.LoadControl("Controls/Comment.ascx");
        //    CommentControl.showAllComment = true;
        //    System.Collections.Generic.List<DAL.DataObject.Node> nodelist = DAL.DataAccess.Node.GetShortNodesByParentNodeId(Convert.ToInt64(parentId));
        //    CommentControl.NodeList = nodelist;
        //    CommentControl.RenderControl(htmlWriter);

        //    return writer.ToString();
        //}



        #endregion


        private bool m_BindInfo = false;
        public Boolean BindInfo
        {
            set { m_BindInfo = value;  }
            get { return m_BindInfo; }
        }

        private bool m_I_the_Owner = false;

        private void AmIThePageOwner()
        {
            if (LoginHandler.IsLoggedIn && PageOwner() == LoginHandler.LoggedInUser().Id)
            {
                m_I_the_Owner = true;
            }
            else
            {
                m_I_the_Owner = false;
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

        private void BindPublicInfoNotification(){
            GridPublicInfoNotification.DataSource = DAL.DataAccess.Node.GetPublicBasicInfoChangeNotification(LoginHandler.LoggedInUser().Id.Value);
            GridPublicInfoNotification.DataBind();        
        }
        private void BindFriendsInfoNotification()
        {
            GridPublicInfoNotification.DataSource = DAL.DataAccess.Node.GetFriendsBasicInfoChangeNotification(LoginHandler.LoggedInUser().Id.Value);
            GridPublicInfoNotification.DataBind();
        }
        private void BindPublicContentBasedNotification()
        {
            GridContentBasedNotification.DataSource = DAL.DataAccess.Node.GetPublicContentBasedNotification();
            GridContentBasedNotification.DataBind();
        }
        private void BindFriendsContentBasedNotification()
        {
            GridContentBasedNotification.DataSource = DAL.DataAccess.Node.GetFriendzContentBasedNotification(LoginHandler.LoggedInUser().Id.Value);
            GridContentBasedNotification.DataBind();
        }

        //protected void GridPublicInfoNotification_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridPublicInfoNotification.PageIndex = e.NewPageIndex;
        //    if (Convert.ToString(ViewState["NotiType"]) == "public")
        //    {
        //        BindPublicInfoNotification();
        //    }
        //    else { BindFriendsInfoNotification(); }
            
        //}
        private void DeselectTabs()
        {
            lbtnPublicNotification.CssClass = "Deselected";
            lbtnFriendNotification.CssClass = "Deselected";
        }
        protected void lbtnPublicNotification_Click(object sender, EventArgs e)
        {
            //DeselectTabs();
            //lbtnPublicNotification.CssClass = "Selected";
            //ViewState["NotiType"] = "public";
            BindPublicInfoNotification();
            BindPublicContentBasedNotification();

        }
        protected void lbtnFriendNotification_Click(object sender, EventArgs e)
        {
            //DeselectTabs();
            //lbtnFriendNotification.CssClass = "Selected";
            //ViewState["NotiType"] = "friends";
            BindFriendsInfoNotification();
            BindFriendsContentBasedNotification();
        }
        protected void Page_Load(object sender, EventArgs e){
            //Response.AppendHeader("Refresh",Convert.ToString((Session.Timeout*60)+10)+";URL=Login.aspx");
            
            if (Page.IsPostBack == false)
            {
                serverStyle.InnerHtml = "div.delete-comment-of" + LoginHandler.LoggedInUser().Id.ToString() + " span.delete-comment{display:inline}"; 

                lbtnPublicNotification.CssClass = "Selected";
                lbtnFriendNotification.CssClass = "Deselected";
                ViewState["NotiType"] = "public";
                BindPublicInfoNotification();
                BindPublicContentBasedNotification();
            }
            else {
                //BindChatPoints();
            }

           //// test BindChatPoints();
            ///test BindOnlineUserList();
            //// test BDDoctors.ChatAndOnlineUser.RefreshUser(LoginHandler.LoggedInUser().Id.Value);
            
        }


        protected void GridContentBasedNotification_ItemDataBound(object sender, DataListItemEventArgs e)
     
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            { 
               
            
            System.Collections.Generic.List<DAL.DataObject.Node> NodeList;
        
                         NodeList= (System.Collections.Generic.List<DAL.DataObject.Node>)e.Item.DataItem;                       
                        BDDoctors.Controls.Comment CommentControl = (BDDoctors.Controls.Comment)e.Item.FindControl("Comment1");
                      
                         //nd= DAL.DataAccess.Node.GetParentNode(NodeList)[0];
                        DAL.DataObject.Node parentNode;
                         if (NodeList.Count > 0)
                        {
                            parentNode = DAL.DataAccess.Node.GetParentNode(NodeList)[0];
                            //HtmlInputHidden inputHiddenParent = (HtmlInputHidden)e.Item.FindControl("parentContainer");
                            //inputHiddenParent.Value = parentNode.ToString();
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
        protected void GridContentBasedNotification_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //LinkButton lbtnFavourite = (LinkButton)GridContentBasedNotification.Rows[e.RowIndex].FindControl("lbtnFavourite");
            //LinkButton lbtnDelete = (LinkButton)GridContentBasedNotification.Rows[e.RowIndex].FindControl("lbtnDelete");
            //UpdatePanel UpdatePanelItem = (UpdatePanel)GridContentBasedNotification.Rows[e.RowIndex].FindControl("UpdatePanelItem");
            //string ParentId = (string)lbtnFavourite.Attributes["parent_id"];
            // DAL.DataAccess.Node.SaveToFavList(Convert.ToInt64(ParentId), LoginHandler.LoggedInUser().Id.Value);

            //if (DAL.DataAccess.Node.DeleteNodes(Convert.ToInt64(ParentId)))
            //{
            //GridContentBasedNotification.Rows[e.RowIndex].Visible = false;

            //Label lbl = new Label();
            //lbl.Text = "Item Deleted permanently";
            //UpdatePanelItem.ContentTemplateContainer.Controls.Clear();
            //UpdatePanelItem.ContentTemplateContainer.Controls.Add(lbl);
            //UpdatePanelItem.Update();
            ////}
        }
        //protected void GridContentBasedNotification_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    UpdatePanel UpdatePanelItem = (UpdatePanel)GridContentBasedNotification.Rows[e.NewEditIndex].FindControl("UpdatePanelItem");
        //    LinkButton lbtnFavourite = (LinkButton)GridContentBasedNotification.Rows[e.NewEditIndex].FindControl("lbtnFavourite");
        //    string ParentIdAndFeatureName = (string)lbtnFavourite.Attributes["parent_id"];
        //    string[] items = ParentIdAndFeatureName.Split(',');
        //    if (DAL.DataAccess.Node.SaveToFavList(Convert.ToInt64(items[0]), LoginHandler.LoggedInUser().Id.Value, Convert.ToString(items[1])))
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



    

        //protected void btnStatusPost_Click(object sender, EventArgs e)
        //{
        //    if (txtEnterStatus.Text.Trim().Length > 0)
        //    {
        //        System.Collections.Generic.List<DAL.DataObject.Node> nodes = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();
        //        DAL.DataObject.Node nd;
        //        nd = new BDDoctors.DAL.DataObject.Node();
        //        nd.User_id = LoginHandler.LoggedInUser().Id.Value;
        //        nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
        //        nd.Attribute_id = 54;
        //        nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtEnterStatus.Text);
        //        nodes.Add(nd);
        //        Int64 parent_id = DAL.DataAccess.Node.SaveNodes(nodes);
        //        txtEnterStatus.Text = "";
        //        BindPublicContentBasedNotification();
        //    }
        //}

        //protected void btnImageUpload_Click(object sender, EventArgs e)
        //{
        //    if (fileuploadImage.HasFile == true && fileuploadImage.PostedFile.ContentType.Contains("image"))
        //    {   
        //        DAL.DataObject.Node nd=new BDDoctors.DAL.DataObject.Node();
        //        nd.Attribute_id=63;
        //        nd.User_id=LoginHandler.LoggedInUser().Id;
        //        nd.User_Name=LoginHandler.LoggedInUser().DisplayName;
        //        nd.Node_value="Nothing";
        //        System.Collections.Generic.List<DAL.DataObject.Node> Nodes=new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();
        //        Nodes.Add(nd);

        //        Int64 parentNodeId = DAL.DataAccess.Node.SaveNodes(Nodes);
        //        nd.Parent_Node_Id=nd.Id;
        //        DAL.DataAccess.Node.SaveNode(nd);

        //        fileuploadImage.PostedFile.SaveAs(Server.MapPath("/images/Node/") + parentNodeId.ToString());
        //        try
        //        {
        //            BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/Node/"), parentNodeId.ToString(), fileuploadImage.PostedFile.ContentType);
        //        }
        //        catch
        //        {
        //            DAL.DataAccess.Node.DeleteNodes(parentNodeId);

        //        }
        //        BindPublicContentBasedNotification();
        //    }
        //}

        //private bool ReturnVideo(string fileName)
        //{

        //    string html = string.Empty;
        //    //rename if file already exists

        //    int j = 0;
        //    string AppPath;
        //    string inputPath;
        //    string outputPath;
        //    string imgpath;
        //    AppPath = Request.PhysicalApplicationPath;
        //    //Get the application path
        //    inputPath = AppPath + "Video";
        //    //Path of the original file
        //    outputPath = AppPath + "Video";
        //    //Path of the converted file
        //    imgpath = AppPath + "Video";
        //    //Path of the preview file
        //    string filepath = Server.MapPath("~/Video/" + fileName);

        //    try
        //    {
        //        this.FileUploadVideo.SaveAs(filepath);
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //    string outPutFile;
        //    outPutFile = "~/Video/" + fileName;
        //    int i = this.FileUploadVideo.PostedFile.ContentLength;
        //    System.IO.FileInfo a = new System.IO.FileInfo(Server.MapPath(outPutFile));
        //    while (a.Exists == false)
        //    {

        //    }
        //    long b = a.Length;
        //    while (i != b)
        //    {

        //    }

        //    string cmd = " -i \"" + inputPath + "\\" + fileName + "\" -ar 22050 \"" + outputPath + "\\" + fileName + ".flv" + "\"";
        //    ConvertNow(cmd);
        //    string imgargs = " -i \"" + outputPath + "\\" + fileName + ".flv" + "\" -f image2 -ss 1 -vframes 1 -s 280x200 -an \"" + imgpath + "\\" + fileName + ".jpg" + "\"";
        //    ConvertNow(imgargs);
        //    //string cmd = " -i \"" + inputPath + "\\" + fileName + "\" -ar 22050 \"" + outputPath + "\\" + fileName + "_Converted" + "\"";
        //    //ConvertNow(cmd);
        //    //string imgargs = " -i \"" + outputPath + "\\" + fileName + "_thumb.jpg" + "\" -f image2 -ss 1 -vframes 1 -s 280x200 -an \"" + imgpath + "\\" + fileName + "_thumb.jpg" + "\"";
        //    //ConvertNow(imgargs);


        //    return true;
        //}
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

        protected void btnPostAlbum_Click(object sender, EventArgs e)
        {
            if (txtAlbumName.Text.Length > 0)
            {
                DAL.DataObject.Node ndAlbum = new BDDoctors.DAL.DataObject.Node();

                ndAlbum.User_id = LoginHandler.LoggedInUser().Id;
                ndAlbum.User_Name = LoginHandler.LoggedInUser().DisplayName;
                ndAlbum.Node_value = txtAlbumName.Text;
                ndAlbum.Attribute_id = 39;
                DAL.DataAccess.Node.SaveNode(ndAlbum);
                
                Response.Redirect(ResolveClientUrl("~\\photoalbum.aspx") + "?" + "PhotoAlbum=" + ndAlbum.Id.Value.ToString());
                
            }
        }

       

        //protected void btnUploadVideo_Click(object sender, EventArgs e)
        //{
        //    if (txtVideoTitle.Text.Length == 0)
        //    {
        //        lblUploadMessage.Text = "Please enter video title";
        //        return;
        //    }
        //    else { lblUploadMessage.Text = ""; }


        //    if ( FileUploadVideo.PostedFile.ContentLength > 400000000)
        //    {
        //        lblUploadMessage.Text = "Please upload video only(max size:400 MB)";
        //        return;
        //    }

        //    if (FileUploadVideo.HasFile == true)
        //    {
        //        DAL.DataObject.Node ndVideo;
        //        string fileName;
        //        fileName = LoginHandler.LoggedInUser().Id.ToString() + "_" + DateTime.Now.Millisecond.ToString();// + "_" + FileUploadVideo.PostedFile.FileName;
        //        ndVideo = new BDDoctors.DAL.DataObject.Node();
        //        try
        //        {
        //            if (ReturnVideo(fileName))
        //            {

        //                // Server.MapPath("~/Video/" + fileName)



        //                ndVideo.User_id = LoginHandler.LoggedInUser().Id;
        //                ndVideo.User_Name = LoginHandler.LoggedInUser().DisplayName;
        //                ndVideo.Node_value = fileName;
        //                ndVideo.Attribute_id = 41;
        //                DAL.DataAccess.Node.SaveNode(ndVideo);
        //                System.IO.File.Move(Server.MapPath("~/Video/" + fileName + ".flv"), Server.MapPath("~/Video/" + ndVideo.Id.ToString() + ".flv"));
        //                System.IO.File.Move(Server.MapPath("~/Video/" + fileName + ".jpg"), Server.MapPath("~/Video/" + ndVideo.Id.ToString() + ".jpg"));




        //                DAL.DataObject.Node ndTitle = new BDDoctors.DAL.DataObject.Node();
        //                ndTitle.User_id = LoginHandler.LoggedInUser().Id;
        //                ndTitle.User_Name = LoginHandler.LoggedInUser().DisplayName;
        //                ndTitle.Node_value = txtVideoTitle.Text;
        //                ndTitle.Attribute_id = 42;
        //                ndTitle.Parent_Node_Id = ndVideo.Id;
        //                DAL.DataAccess.Node.SaveNode(ndTitle);



        //            }

        //        }
        //        catch
        //        {
        //            DAL.DataAccess.Node.DeleteNodes(ndVideo.Id.Value);
        //            lblUploadMessage.Text = "This file may contains error or you may have tried to upload file but video type";
        //        }
        //        finally { BindPublicContentBasedNotification(); }








        //        //lblSuccessMessage.Text = "Album created successfully";
        //        //BindInfo = true;
        //        //BindAlbumList();

        //    }
        //}















    }
}
