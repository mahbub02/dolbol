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
    public partial class Notif_UploadedVideo : System.Web.UI.UserControl
    {
        private System.Collections.Generic.List<DAL.DataObject.Node> m_NodeList;

        public System.Collections.Generic.List<DAL.DataObject.Node> NodeList
        {
            set { m_NodeList = value; BindHeaderAndAlbumGrid(m_NodeList); }
            get { return m_NodeList; }
        }

        public void BindHeaderAndAlbumGrid(System.Collections.Generic.List<DAL.DataObject.Node> ListNodes)
        {
            System.Collections.Generic.IEnumerable<DAL.DataObject.Node> ParentNodeList = from DAL.DataObject.Node nd in ListNodes
                                                                                         where nd.Attribute_id != null && nd.Attribute_id.Value == 42
                                                                                         select nd;

            GridHeader.DataSource = ParentNodeList;
            GridHeader.DataBind();

            System.Collections.Generic.IEnumerable<DAL.DataObject.Node> VideoList = from DAL.DataObject.Node nd in ListNodes
                                                                                    where nd.Attribute_id != null && nd.Node_value != null && nd.Attribute_id.Value == 41
                                                                                    select nd;
          
            GridViewVideo.DataSource = VideoList;
            GridViewVideo.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewVideo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (e.Row.RowState)
                {

                    case DataControlRowState.Normal:
                    case DataControlRowState.Alternate:
                        DAL.DataObject.Node node = (DAL.DataObject.Node)e.Row.DataItem;
                        ASPNetFlashVideo.FlashVideo FlashVideo1 = (FlashVideo)e.Row.FindControl("FlashVideo1");
                       // ImageButton imgThumbVideo = (ImageButton)(e.Row.FindControl("imgThumbVideo"));
                      //  imgThumbVideo.ImageUrl = "~/Video/" + node.Node_value.Remove(node.Node_value.LastIndexOf(".")) + ".jpg";
                       // Server.MapPath("/Video/profile/
                        FlashVideo1.VideoURL = Server.MapPath("/Video/" + node.Id + ".flv");
                       // FlashVideo1.VideoURL = Server.MapPath("/Video/" + node.Node_value.Remove(node.Node_value.LastIndexOf(".")) + ".flv");
                        //FlashVideo1.StartUpImageURL = "~/Video/" + node.Node_value.Remove(node.Node_value.LastIndexOf(".")) + ".jpg";
                       // FlashVideo1.VideoURL="~/Video/" + node.Node_value.ToString();
                        break;
                }
            }
        }

        protected void GridViewVideo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow gr = GridViewVideo.Rows[e.RowIndex];
          
            ASPNetFlashVideo.FlashVideo FlashVideo1 = (FlashVideo)gr.FindControl("FlashVideo1");
            LinkButton lbtnPlayVideo = (LinkButton)(gr.FindControl("lbtnPlayVideo"));
            FlashVideo1.VideoURL = Server.MapPath("/Video/" + lbtnPlayVideo.CommandArgument + ".flv");
            //lbtnPlayVideo.Visible = false;
            //FlashVideo1.VideoURL = lbtnPlayVideo.CommandArgument+".flv";// .ImageUrl.Replace("jpg", "flv");
           // imgThumbVideo.Visible = false;
            FlashVideo1.Visible = true;
            //UpdatePanel2.Update();
           
        }
    }
}