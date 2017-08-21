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
    public partial class UploadedPhoto : System.Web.UI.UserControl
    {
        private bool m_BindInfo = false;
        public Boolean BindInfo
        {
            set { m_BindInfo = value; BindAlbumList(); }
            get { return m_BindInfo; }
        }

        private bool m_I_the_Owner = false;
        private Boolean AmIThePageOwner()
        {
            if (LoginHandler.IsLoggedIn && PageOwner() == LoginHandler.LoggedInUser().Id)
            {
                m_I_the_Owner = true;
               
            }
            else
            {
                m_I_the_Owner = false;
            }
            return m_I_the_Owner;
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
                lbtnCreateNewPhotoAlbum.Visible = AmIThePageOwner();
            }
            
        }
        private void BindAlbumList()
        {
            if (m_BindInfo == true)
            {
                

            }
        }

        protected void GridViewAlbumbs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (e.Row.RowState)
                {

                    case DataControlRowState.Normal:
                    case DataControlRowState.Alternate:
                       Label lblTitleValue = (Label)e.Row.FindControl("lblTitleValue");
                       HtmlAnchor hlinkAlbum = (HtmlAnchor)e.Row.FindControl("hlinkAlbum");
                       HtmlImage ImgAlbum = (HtmlImage)e.Row.FindControl("ImgAlbum");
                        System.Collections.Generic.List<DAL.DataObject.Node> NodeList = (System.Collections.Generic.List<DAL.DataObject.Node>)e.Row.DataItem;

                        foreach (DAL.DataObject.Node nd in NodeList)
                        {
                           
                            switch (nd.Attribute_id)
                            {
                               case 39:
                                    lblTitleValue.Text = nd.Node_value.ToString();
                                    hlinkAlbum.HRef = "~/PhotoAlbum.aspx?PhotoAlbum=" + nd.Id.ToString();
                                    break;   
                                case 40:
                                    if (nd.Node_value != null)
                                    {
                                        ImgAlbum.Src = "~/Images/Node/" + nd.Id.ToString()+"_thumb.jpg";
                                    }
                                    break;
                            }
                        }
                        break;
                }


            }
        }

        protected void lbtnCreateNewPhotoAlbum_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            divCreateNewAlbum.Visible = !divCreateNewAlbum.Visible;
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Length > 0)
            {
                DAL.DataObject.Node ndAlbum = new BDDoctors.DAL.DataObject.Node();
               
                ndAlbum.User_id = LoginHandler.LoggedInUser().Id;
                ndAlbum.User_Name = LoginHandler.LoggedInUser().DisplayName;
                ndAlbum.Node_value = txtTitle.Text;
                ndAlbum.Attribute_id = 39;
                DAL.DataAccess.Node.SaveNode(ndAlbum);
             //   ndAlbum.Node_value = ndAlbum.Id.ToString();
              //  ndAlbum.Parent_Node_Id = ndAlbum.Id;
              //  DAL.DataAccess.Node.SaveNode(ndAlbum);
                divCreateNewAlbum.Visible = !divCreateNewAlbum.Visible;
                lblSuccessMessage.Text = "Album created successfully";
                BindInfo = true;
                BindAlbumList();
              //  updatePanelBlogList.Update();

            }
            else 
            {
                lblValidationMessageForAlbum.Text = "Enter an album name";
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            divCreateNewAlbum.Visible = !divCreateNewAlbum.Visible;
        }

        protected void lbtnClose_Click(object sender, EventArgs e)
        {
            divCreateNewAlbum.Visible = !divCreateNewAlbum.Visible;
        }
    }
}