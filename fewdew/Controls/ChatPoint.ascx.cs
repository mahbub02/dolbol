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
    public partial class ChatPoint : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lblChatUserName.Text = DAL.DataAccess.User.GetUser( Convert.ToInt64( base.ID)).DisplayName;
            }
            ////if (Page.IsPostBack==false)
            ////{
                
            //    imgbtnUserOnChat.ImageUrl=ResolveClientUrl("/Images/profile/"+this.ID.ToString()+"_mini.jpg");
            //    imgbtnUserOnChat.PostBackUrl= ResolveClientUrl("/Profile.aspx?user=" + this.ID.ToString() );
            //    lbtnUserOnChat.Text=DAL.DataAccess.User.GetUser( Convert.ToInt64( this.ID)).DisplayName;
            ////}
            BindConversation();
        }
        public void BindConversation()
        {
          System.Collections.Generic.List<DAL.DataObject.Conversation> convList = ChatAndOnlineUser.GetMyConversationWithThisUser(Convert.ToInt64(this.ID));
         DAL.DataObject.Conversation conv= convList.Max();
         if (conv != null)
         {
             if (this.Attributes["lastMsgId"] == null || Convert.ToInt64(this.Attributes["lastMsgId"]) < conv.Id)
             {
                 imgChatBlinker.Visible = true;
                 
             }
            
         }

          GridConversation.DataSource = convList;
          GridConversation.DataBind();
        }

        protected void GridConversation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            TextBox txtEnterMessage = (TextBox)GridConversation.FooterRow.FindControl("txtEnterMessage");

            if (txtEnterMessage.Text.Trim().Length > 0)            {

                if (ChatAndOnlineUser.isOnline(Convert.ToInt64(this.ID)) == false)
                {
                    lblOffLineMessage.Text = "The user is no longer online";
                }
                DAL.DataObject.User recieverUser = DAL.DataAccess.User.GetUser(Convert.ToInt64(this.ID));
                DAL.DataObject.Conversation cnv = new BDDoctors.DAL.DataObject.Conversation();
                cnv.Sender_id = LoginHandler.LoggedInUser().Id.Value;
                cnv.Reciever_id = recieverUser.Id;
                cnv.Sender_Name = LoginHandler.LoggedInUser().DisplayName;
                cnv.Reciever_name = recieverUser.DisplayName;
                cnv.Action_date = DateTime.Now;
                cnv.Message = DAL.Common.GetTextWithBr(txtEnterMessage.Text);
                ChatAndOnlineUser.AddConversationToTheConversationList(cnv);
                BindConversation();

            }
           
            
        }

        protected void btnPostMessage_Click(object sender, EventArgs e)
        {
            if (txtEnterMessage.Text.Trim().Length > 0)
            {

                if (ChatAndOnlineUser.isOnline(Convert.ToInt64(this.ID)) == false)
                {
                    lblOffLineMessage.Text = "The user is no longer online";
                }
                DAL.DataObject.User recieverUser = DAL.DataAccess.User.GetUser(Convert.ToInt64(this.ID));
                DAL.DataObject.Conversation cnv = new BDDoctors.DAL.DataObject.Conversation();
                cnv.Sender_id = LoginHandler.LoggedInUser().Id.Value;
                cnv.Reciever_id = recieverUser.Id;
                cnv.Sender_Name = LoginHandler.LoggedInUser().DisplayName;
                cnv.Reciever_name = recieverUser.DisplayName;
                cnv.Action_date = DateTime.Now;
                cnv.Message = DAL.Common.GetTextWithBr(txtEnterMessage.Text);
                ChatAndOnlineUser.AddConversationToTheConversationList(cnv);

                this.Attributes.Add("lastMsgId", cnv.Id.ToString());
                imgChatBlinker.Visible = false;
              
                txtEnterMessage.Text = "";
                BindConversation();

               

            }
        }

        protected void lbtnMinimize_Click(object sender, EventArgs e)
        {
            //dvFooter.Visible = !dvFooter.Visible;
            //dvMessage.Visible = !dvMessage.Visible;
            dvChatPointMessage.Visible = !dvChatPointMessage.Visible;
            //imgMinimized.Visible = !imgMinimized.Visible;
            //imgMinimized.ImageUrl = ResolveClientUrl("/Images/profile/" + this.ID.ToString() + "_mini.jpg");
            

            
        }

        //protected void imgMinimized_Click(object sender, ImageClickEventArgs e)
        //{
            
        //    //dvFooter.Visible = !dvFooter.Visible;
        //    //dvMessage.Visible = !dvMessage.Visible;
        //    dvChatPointMessage.Visible = !dvChatPointMessage.Visible;
        //    imgMinimized.Visible = !imgMinimized.Visible;
        //    imgMinimized.ImageUrl = ResolveClientUrl("/Images/profile/" + this.ID.ToString() + "_mini.jpg");
        //}

        protected void lbtnMinimized_Click(object sender, EventArgs e)
        {
            dvChatPointMessage.Visible = !dvChatPointMessage.Visible;


            System.Collections.Generic.List<DAL.DataObject.Conversation> convList = ChatAndOnlineUser.GetMyConversationWithThisUser(Convert.ToInt64(this.ID));
            DAL.DataObject.Conversation conv = convList.Max();
            if (conv != null)
            {
                this.Attributes.Add("lastMsgId", conv.Id.ToString());
                imgChatBlinker.Visible = false;
            }
            //imgMinimized.Visible = !imgMinimized.Visible;
            //imgMinimized.ImageUrl = ResolveClientUrl("/Images/profile/" + this.ID.ToString() + "_mini.jpg");

        }
    }
}