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
    public partial class MediPanelDetails : System.Web.UI.Page
    {
        protected Boolean M_CommentVisible = false;
        protected Boolean IsCommentVisble
        {
            get { return M_CommentVisible; }
            set { M_CommentVisible = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                serverStyle.InnerHtml = "div.delete-comment-of" + LoginHandler.LoggedInUser().Id.ToString() + " span.delete-comment{display:inline}"; 
                BindTreatmentPanel();
            }
        }
        private void BindTreatmentPanel()
        {
           
            if (Page.IsPostBack == false)
            {
                System.Collections.Generic.List<DAL.DataObject.Node> AllNodes = DAL.DataAccess.Node.GetNodesOnly( Convert.ToInt64(Request["Panel_id"]));
                System.Collections.Generic.List<DAL.DataObject.Node> NodesButComment = DAL.DataAccess.Node.FilterNodeButComments(AllNodes);
                System.Collections.Generic.List<DAL.DataObject.Node> comments = DAL.DataAccess.Node.FilterNodeComments(AllNodes);
                Comment1.NodeList = AllNodes;
               
                System.Collections.Generic.IEnumerable<DAL.DataObject.Node> PhotoList = from DAL.DataObject.Node nd in AllNodes
                                                                                        where nd.Attribute_id != null && nd.Node_value != null && nd.Attribute_id.Value == 37
                                                                                        select nd;
                DlAlbums.DataSource = PhotoList;
                DlAlbums.DataBind();
          


                foreach (DAL.DataObject.Node nd in NodesButComment)
                {
                    switch (nd.Attribute_id)
                    {
                        case 53:

                            lblName.Text = nd.Node_value.ToString();
                            hlinkUserImage.NavigateUrl = ResolveClientUrl("/Profile.aspx?user=" + nd.User_id.ToString());
                            imgUser.Src = ResolveClientUrl("/images/profile/" + nd.User_id.Value.ToString() + "_thumb.jpg");
                            lblUserName.Text = nd.User_Name.ToString() + " has posted this ";
                            lblDateTime.Text = " On " + nd.Action_date.Value.ToShortDateString() + " at " + nd.Action_date.Value.ToShortTimeString();
                            if (LoginHandler.IsLoggedIn == true)
                            {
                                if (LoginHandler.LoggedInUser().Id.Value == nd.User_id.Value)
                                {
                                    anchorEdit.HRef = "MediPanelEdit.aspx?panel_id=" + Convert.ToString(Request["Panel_id"]);
                                    anchorEdit.Visible = true;
                                }
                            }
                            break;
                        case 43:
                            lblAge.Text = nd.Node_value.ToString();
                            break;
                        case 44:
                            lblOccupation.Text = nd.Node_value.ToString();
                            break;
                        case 45:
                            lblWeight.Text = nd.Node_value.ToString();
                            break;
                        case 46:
                            lblDescription.Text = nd.Node_value.ToString();
                            break;
                        case 47:
                            lblHowLongSuffering.Text = nd.Node_value.ToString();
                            break;
                        case 48:
                            lblSufferingFrom.Text = nd.Node_value.ToString();
                            break;
                        case 49:
                            lblHistoryOfAnyOperation.Text = nd.Node_value.ToString();
                            break;
                        case 50:
                            lblHaveYouTakenAnyDrugForThisComplaint.Text = nd.Node_value.ToString();
                            break;
                        case 51:
                            lblTakingAnyMedicineForLong.Text = nd.Node_value.ToString();
                            break;
                        case 52:
                            lblHaveYouAlreadyDoneAnyInves.Text = nd.Node_value.ToString();
                            break;
                        case 59:

                            if (LoginHandler.IsLoggedIn == true)
                            {
                                if (LoginHandler.LoggedInUser().Id.Value <= 2)
                                {
                                    btnResoved.Visible = true;
                                }
                            }   
                            if (nd.User_id != null)
                            {
                                btnResoved.Text = nd.Node_value.ToString();

                                if (nd.Node_value == "NO")
                                {
                                    lblIsResolved.Text = "This panel is open";
                                    if (LoginHandler.IsLoggedIn == true)
                                    {

                                        if (nd.User_id.Value == LoginHandler.LoggedInUser().Id.Value || LoginHandler.LoggedInUser().Id.Value < 3)
                                        {
                                            IsCommentVisble = true;
                                        }
                                    }
                                }
                                else { lblIsResolved.Text = "This panel is closed"; }

                               
                            }
                            
                            
                            break;

                       
                       

                    }
                }

            }
        }

        protected void btnResoved_Click(object sender, EventArgs e)
        {
              DAL.DataObject.Node nd = DAL.DataAccess.Node.GetShortNodeByID(Convert.ToInt64(Request["Panel_id"]));
              if (btnResoved.Text == "NO")
              {
                  nd.Node_value ="YES";
              }
              else 
              {
                  nd.Node_value = "NO";
              }
            
              if (DAL.DataAccess.Node.UpdateNodes(nd.Parent_Node_Id.Value, 59, nd.Node_value)==true )
              {

                  btnResoved.Text = nd.Node_value;
                  Response.Redirect(ResolveClientUrl("~\\MedipanelDetails.aspx?Panel_id=") + Convert.ToInt64(Request["Panel_id"]));
              }
        }
    }
}
