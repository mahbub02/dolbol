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
    public partial class Blog : System.Web.UI.Page
    {
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                serverStyle.InnerHtml = "div.delete-comment-of" + LoginHandler.LoggedInUser().Id.ToString() + " span.delete-comment{display:inline}"; 

                BindPublicContentBasedNotification();
                PopulateDropDown(ddlCategory, 28, null);
            }
        }
        public static void PopulateDropDown(DropDownList dl, Int64 source_id, String SelectedText)
        {
            System.Collections.Generic.List<String> itemList = DAL.DataAccess.Node.GetSourceTextList(source_id);
            dl.Items.Clear();
            ListItem FirstItem = new ListItem("Recent blogs", "-1");
            dl.Items.Add(FirstItem);
            foreach (string str in itemList)
            {
                ListItem li = new ListItem(str, str);
                if (SelectedText == li.Value)
                {
                    li.Selected = true;
                }

                dl.Items.Add(li);
            }
        }
        private void BindPublicContentBasedNotification()
        {
            GridContentBasedNotification.DataSource = DAL.DataAccess.Node.GetBlogList();
            GridContentBasedNotification.DataBind();
        }
       
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue != "-1")
            {
                GridContentBasedNotification.DataSource = DAL.DataAccess.Node.GetBlogListByCategory(ddlCategory.SelectedValue);
                GridContentBasedNotification.DataBind();
            }
            else { BindPublicContentBasedNotification(); }
        }


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
     
        

        
    }
}
