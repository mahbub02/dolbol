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
namespace BDDoctors.Service
{
    public partial class PageMethodService : System.Web.UI.Page
    {
        [WebMethod]
        // Get session state value.
        public static  string GetMyName(string key)
        {

            StringWriter writer = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
            

            System.Web.UI.Page pg = new Page();
            
            BDDoctors.Controls.Comment CommentControl = (BDDoctors.Controls.Comment)pg.LoadControl("Controls/Comment.ascx");
           
            System.Collections.Generic.List<DAL.DataObject.Node> nodelist = DAL.DataAccess.Node.GetNodesOnly( 53);
            CommentControl.NodeList = nodelist;
            CommentControl.RenderControl(htmlWriter);

            return writer.ToString();
        }
        [WebMethod]
        public static string PostCommentAndReturnCommentHtml( string Comment,int parentId)
        {
            if (LoginHandler.IsLoggedIn == false)
            {
                return "<h3>To post comment please do login</h3>";
            }

            parentId = 53;
            DAL.DataObject.Node nd = new DAL.DataObject.Node();

            nd.Parent_Node_Id = parentId;
            nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(Comment);
            nd.Attribute_id = 36;
            nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            DAL.DataAccess.Node.SaveCommentOrImageOrVideo(nd);         
          


            StringWriter writer = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);


            System.Web.UI.Page pg = new Page();

            BDDoctors.Controls.Comment CommentControl = (BDDoctors.Controls.Comment)pg.LoadControl("Controls/Comment.ascx");
            CommentControl.showAllComment = true;
            System.Collections.Generic.List<DAL.DataObject.Node> nodelist = DAL.DataAccess.Node.GetShortNodesByParentNodeId(Convert.ToInt64(parentId));
            CommentControl.NodeList = nodelist;
            CommentControl.RenderControl(htmlWriter);

            return writer.ToString();
        }
        [WebMethod]
        public static  string ShowAllComment(Int64 parentId)
        {
            //parentId = (Int64)parentId;

            //DAL.DataObject.Node nd = new DAL.DataObject.Node();

            //nd.Parent_Node_Id = parentId;
            //nd.User_id = LoginHandler.LoggedInUser().Id.Value;
            //nd.Node_value = BDDoctors.DAL.Common.GetTextWithBr(Comment);
            //nd.Attribute_id = 36;
            //nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
            //DAL.DataAccess.Node.SaveCommentOrImageOrVideo(nd);



            StringWriter writer = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);


            System.Web.UI.Page pg = new Page();

            BDDoctors.Controls.Comment CommentControl = (BDDoctors.Controls.Comment)pg.LoadControl("Controls/Comment.ascx");
            CommentControl.showAllComment = true;
            System.Collections.Generic.List<DAL.DataObject.Node> nodelist = DAL.DataAccess.Node.GetShortNodesByParentNodeId(Convert.ToInt64(parentId));
            CommentControl.NodeList = nodelist;
            CommentControl.RenderControl(htmlWriter);

            return writer.ToString();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            System.Collections.Generic.List<DAL.DataObject.Node> nodelist = DAL.DataAccess.Node.GetShortNodesByParentNodeId(Convert.ToInt64(53));
            Comment1.NodeList = nodelist;

           // string str= ShowAllComment(53);

            //PostCommentAndReturnCommentHtml("hello", 53);
            //string str= GetMyName("");
           //Response.Write(str);
           
        }

    }
}
