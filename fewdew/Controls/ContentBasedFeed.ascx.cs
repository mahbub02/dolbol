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
    public partial class ContentBasedFeed : System.Web.UI.UserControl
    {
        public System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> NodesList
        {
            get {
                return null;
             
            }
            set {

                GridContentBasedNotification.DataSource = value;
                GridContentBasedNotification.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

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
                    //LinkButton lbtnFavourite = (LinkButton)e.Item.FindControl("lbtnFavourite");
                    //lbtnFavourite.Attributes.Add("parent_id", parentNode.Id.Value.ToString() + "," + parentNode.feature_Name.ToString());

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