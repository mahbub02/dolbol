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
    public partial class Comment : System.Web.UI.UserControl
    {
        private System.Collections.Generic.List<DAL.DataObject.Node> m_NodeList;
        private Boolean m_showAllComment = false;
        public System.Collections.Generic.List<DAL.DataObject.Node> NodeList
        {
            set { m_NodeList = value; BindCommentList(m_NodeList); }
            get { return m_NodeList; }
        }
        public Boolean showAllComment
        {
            get { return m_showAllComment; }
            set { m_showAllComment = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void BindCommentList(System.Collections.Generic.List<DAL.DataObject.Node> NodeList)
        {
            System.Collections.Generic.List<DAL.DataObject.Node> CommentList = DAL.DataAccess.Node.FilterNodeComments(NodeList);
            Int64 Parent_node_id = DAL.DataAccess.Node.GetParentIdFromNodeList(NodeList).Value;
            seeAll.Name = Parent_node_id.ToString();
            hiddenParentContainer.Value = Parent_node_id.ToString();
            //if (CommentList.Count > 6)
            //{
            //    if (showAllComment == false)
            //    {

            if (CommentList.Count > 0)
            {
                seeAll.InnerText = "View all " + CommentList.Count.ToString() + " comments";
            }
            else { seeAll.InnerText ="comment"; }
                   
                    //CommentList = CommentList.GetRange(1, 5);
                    

            //    }
            //}
            
            GridComment.DataSource = CommentList;
            GridComment.DataBind();
           
           
           
           
           GridComment.Attributes.Add("ParentNodeId", Parent_node_id.ToString());

        }

        //protected void GridComment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    TextBox txtEnterMessage = (TextBox)GridComment.FooterRow.FindControl("txtEnterMessage");
        //    if (txtEnterMessage.Text.Length > 0 && txtEnterMessage.Text.Length <300)
        //    {
        //        DAL.DataObject.Node nd = new DAL.DataObject.Node();
        //        nd.Parent_Node_Id = Convert.ToInt64(GridComment.Attributes["ParentNodeId"]);
        //        nd.User_id = LoginHandler.LoggedInUser().Id.Value;
        //        nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(txtEnterMessage.Text);
        //        nd.Attribute_id = 36;
        //        nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
        //        DAL.DataAccess.Node.SaveCommentOrImageOrVideo(nd);
        //        BindCommentList( DAL.DataAccess.Node.GetShortNodesByParentNodeId(nd.Parent_Node_Id.Value));
        //        UpdatePanel2.Update();
        //    }
        //}

        //protected void GridComment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
           
           
        //}

        //protected void GridComment_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    if (DAL.DataAccess.Node.DeleteNodes(Convert.ToInt64(GridComment.DataKeys[e.NewEditIndex].Value)))
        //    {
        //        BindCommentList(DAL.DataAccess.Node.GetShortNodesByParentNodeId(Convert.ToInt64(GridComment.Attributes["ParentNodeId"])));
        //        UpdatePanel2.Update();
        //    }
        //}

        //protected void GridComment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridComment.PageIndex = e.NewPageIndex;
        //    BindCommentList(DAL.DataAccess.Node.GetShortNodesByParentNodeId(Convert.ToInt64(GridComment.Attributes["ParentNodeId"])));
        //    UpdatePanel2.Update();
        //}
    }
}