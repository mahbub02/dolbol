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

namespace BDDoctors.Controls.FeedRelated
{
    public partial class NotifPoll : System.Web.UI.UserControl
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
                                                                                         where nd.Attribute_id != null && nd.Attribute_id.Value == 55
                                                                                         select nd;


            GridHeader.Attributes.Add("ParentNodeId", DAL.DataAccess.Node.GetParentIdFromNodeList(ListNodes).Value.ToString());


            GridHeader.DataSource = ParentNodeList;
            GridHeader.DataBind();



            System.Collections.Generic.IEnumerable<DAL.DataObject.Node> AnswerList = from DAL.DataObject.Node nd in ListNodes
                                                                                    where nd.Attribute_id != null && nd.Node_value != null && nd.Attribute_id.Value == 56
                                                                                    select nd;


            System.Collections.Generic.IEnumerable<DAL.DataObject.Node> SingleOrMultiple = from DAL.DataObject.Node nd in ListNodes
                                                                                     where nd.Attribute_id != null && nd.Node_value != null && nd.Attribute_id.Value == 58
                                                                                     select nd ;



            Int64 totalVotes=0;
            dvResult.Controls.Clear();
            foreach (DAL.DataObject.Node ndAnswer in AnswerList)
            {
                string[] voteAndAnswer = ndAnswer.Node_value.Split('-');
                if (voteAndAnswer.Length == 1)
                {
                    totalVotes = totalVotes + 0;
                    Label lbl=new Label();
                    lbl.Text = "0";
                    dvResult.Controls.Add(lbl);
                }
                else 
                {
                    totalVotes = totalVotes + Convert.ToInt64(voteAndAnswer[0]);
                    Label lbl = new Label();
                    lbl.Text = voteAndAnswer[0];
                    dvResult.Controls.Add(lbl);
                }
            }

            foreach (DAL.DataObject.Node nd in SingleOrMultiple)
            {
                if (nd.Node_value == "1")
                {
                    chkanswer.Visible = true;
                    rdoanswer.Visible = false;
                    chkanswer.Items.Clear();
                    rdoanswer.Items.Clear();

                    foreach (DAL.DataObject.Node ndAnswer in AnswerList)
                    {
                        ListItem li = new ListItem();
                        li.Value = ndAnswer.Id.Value.ToString();
                        string[] voteAndAnswer = ndAnswer.Node_value.Split('-');
                        if (voteAndAnswer.Length == 1)
                        {
                            li.Text = ndAnswer.Node_value;
                            li.Attributes.Add("CastedVoteSoFar","0");
                            
                        }
                        else 
                        {
                            li.Text = voteAndAnswer[1];
                            li.Attributes.Add("CastedVoteSoFar",voteAndAnswer[0]);
                        }
                        chkanswer.Items.Add(li);
                        
                    }
                   
                    break;
                }
                else if (nd.Node_value =="0")
                {
                    chkanswer.Visible = false;
                    rdoanswer.Visible = true;
                    foreach (DAL.DataObject.Node ndAnswer in AnswerList)
                    {
                        ListItem li = new ListItem();
                        string[] voteAndAnswer = ndAnswer.Node_value.Split('-');
                        if (voteAndAnswer.Length == 1)
                        {
                            li.Text = ndAnswer.Node_value;
                            li.Value = ndAnswer.Id.Value.ToString();
                            li.Attributes.Add("CastedVoteSoFar", "0");

                            // li.Attributes.Add("" = "0";
                        }
                        else
                        {
                            li.Text = voteAndAnswer[1];
                            li.Value = ndAnswer.Id.Value.ToString();
                            li.Attributes.Add("CastedVoteSoFar", voteAndAnswer[0]);
                        }
                        rdoanswer.Items.Add(li);

                    }

                  

                    break;
                }
            }



         

        }



        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void ReBindHeaderAndAlbumGrid()
        { 
           BindHeaderAndAlbumGrid(  DAL.DataAccess.Node.GetNodesOnly(Convert.ToInt64(GridHeader.Attributes["ParentNodeId"])));
        }
        protected void btnCastMyVote_Click(object sender, EventArgs e)
        {
            System.Collections.Generic.List<DAL.DataObject.NodeInfo> NodeInfos = DAL.DataAccess.NodeInfo.GetNodeInfos(LoginHandler.LoggedInUser().Id.Value, Convert.ToInt64( GridHeader.Attributes["ParentNodeId"]));
            if (NodeInfos.Count > 0)
            {
                dvMessage.InnerHtml = "<p>Your have already casted your vote </p>";
                ReBindHeaderAndAlbumGrid();

                return;
            }
            if (chkanswer.Visible == true)
            {
                foreach (ListItem li in chkanswer.Items)
                {
                    
                    if (li.Selected == true)
                    {
                       
                            string str = li.Attributes["CastedVoteSoFar"];
                            Int64 casted = Convert.ToInt64(li.Attributes["CastedVoteSoFar"]);
                            DAL.DataObject.Node nd = DAL.DataAccess.Node.GetShortNodeByID(Convert.ToInt64(li.Value));
                            string[] voteAndAnswer = nd.Node_value.Split('-');
                            if (voteAndAnswer.Length == 1)
                            {
                                nd.Node_value = "1"+ "-" + li.Text;
                            }
                            else {
                                nd.Node_value = Convert.ToString(Convert.ToInt64(voteAndAnswer[0]) + 1) + "-" + li.Text;
                            }
                            
                            DAL.DataAccess.Node.SaveMultipleNodeWithSameAttribute(nd);
                    }
                }
                DAL.DataObject.NodeInfo ndInfo = new BDDoctors.DAL.DataObject.NodeInfo();
                ndInfo.NodeId = Convert.ToInt64(GridHeader.Attributes["ParentNodeId"]);
                ndInfo.User_id = LoginHandler.LoggedInUser().Id.Value;
                ndInfo.Info = "Vote Casted";
                DAL.DataAccess.NodeInfo.SaveNodeInfo(ndInfo);
                dvMessage.InnerHtml = "<p>Your vote is casted</p>";
                ReBindHeaderAndAlbumGrid();

                
            }
        }
    }
}