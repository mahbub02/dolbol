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
    public partial class BlogList : System.Web.UI.UserControl
    {
        private bool m_BindInfo = false;
        public Boolean BindInfo 
        {
            set { m_BindInfo = value; BindBlogList(); }
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
        protected void Page_Load(object sender, EventArgs e)
        {
            //BindBlogList();
            //     if (Page.IsPostBack == false)
            //{
                //UIhelper.PopulateCheckList(ChklistCategory, 28, null);


                // test
                //if (m_BindInfo == true)
                //{
                //    System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListNodes = DAL.DataAccess.Node.GetListNodesOnly("Blog", PageOwner());
                //    GridEmail.DataSource = ListNodes;
                //    GridEmail.DataBind();
                //    updatePanelBlogList.Update();
        
                //}
                
           // } 

        }
        private void BindBlogList()
        {
            if (m_BindInfo == true)
            {
                

            }
        }
        protected void GridEmail_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (e.Row.RowState)
                {

                    case DataControlRowState.Normal:
                    case DataControlRowState.Alternate:
                        HyperLink hlinkUserImage = (HyperLink)e.Row.FindControl("hlinkUserImage");
                        Label lblTitleValue = (Label)e.Row.FindControl("lblTitleValue");
                        Label lblDescriptionValue = (Label)e.Row.FindControl("lblDescriptionValue");
                        Label lblCategoryValue = (Label)e.Row.FindControl("lblCategoryValue");

                        Label lblUserName = (Label)e.Row.FindControl("lblUserName");
                        Label lblDateTime = (Label)e.Row.FindControl("lblDateTime");
                        HtmlImage imgUser = (HtmlImage)e.Row.FindControl("imgUser");
                        HtmlImage BlogImage = (HtmlImage)e.Row.FindControl("BlogImage");
                        
                        HyperLink hlinkReadMore = (HyperLink)e.Row.FindControl("hlinkReadMore");

                        System.Collections.Generic.List<DAL.DataObject.Node> NodeList = (System.Collections.Generic.List<DAL.DataObject.Node>)e.Row.DataItem;

                        BDDoctors.Controls.Comment CommentControl = (BDDoctors.Controls.Comment)e.Row.FindControl("Comment1");
                        CommentControl.NodeList = NodeList;

                        foreach (DAL.DataObject.Node nd in NodeList)
                        {
                            switch (nd.Attribute_id)
                            {
                                case 33:
                                    hlinkUserImage.NavigateUrl = ResolveClientUrl("/Profile.aspx?user=" + nd.User_id.ToString());
                                    // hlinkUserImage.Text = nd.User_Name.ToString();
                                    imgUser.Src = ResolveClientUrl("/images/profile/" + nd.User_id.Value.ToString() + "_mini.jpg");
                                    lblTitleValue.Text = nd.Node_value.ToString();
                                    hlinkReadMore.NavigateUrl = ResolveClientUrl("/ShowBlog.aspx?node_id=" + nd.Id.ToString());
                                    //hlinkDescription.NavigateUrl = ResolveClientUrl("/ShowBlog.aspx?node_id=" + nd.Id.ToString());
                                    lblUserName.Text = nd.User_Name.ToString() + " has posted this ";
                                    lblDateTime.Text = " On " + nd.Action_date.Value.ToShortDateString() + " at " + nd.Action_date.Value.ToShortTimeString();
                                    break;
                                case 34:
                                    lblDescriptionValue.Text = nd.Node_value.ToString();
                                    break;
                                case 35:
                                    lblCategoryValue.Text = nd.Node_value.ToString();
                                    break;
                                case 37:
                                    if (nd.Node_value != null)
                                    {
                                        BlogImage.Src = ResolveClientUrl("/images/Node/" + nd.Node_value.ToString() + "_thumb.jpg.jpg");
                                        BlogImage.Visible = true;
                                    
                                    }
                                    break;
                                    
                            }
                        }



                        break;
                }


            }
        }
    }
}