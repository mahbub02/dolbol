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
    public partial class Email : System.Web.UI.Page
    {
        public void BindEmailWithInboxItem()
        {
            lblHeaderText.Text = "Inbox Message(s)";
            lbtnInbox.CssClass = "Selected";
            lbtnSentItem.CssClass = "Deselected";
            lblDeletedMail.CssClass = "Deselected";

            setInboxEmailNumber();
            GridEmail.Visible = true;
            GridReadMessage.Visible = false;
            System.Collections.Generic.List<DAL.DataObject.Email> EmailList = DAL.DataAccess.Email.GetInBoxEmail(LoginHandler.LoggedInUser().Id.Value);
            GridEmail.Attributes.Add("currentlist", "inbox");
            GridEmail.DataSource = EmailList;
            GridEmail.DataBind();
            hiddenDeletePressed.Value = "";
        }

        public void BindEmailWithSentItem()
        {
            GridEmail.Visible = true;
            GridReadMessage.Visible = false;

            System.Collections.Generic.List<DAL.DataObject.Email> EmailList = DAL.DataAccess.Email.GetSentEmail(LoginHandler.LoggedInUser().Id.Value);
            GridEmail.Attributes.Add("currentlist","sent") ;
            GridEmail.DataSource = EmailList;
            GridEmail.DataBind();
            hiddenDeletePressed.Value = "";
        }

        public void BindEmailWithDeletedItem()
        {
            GridEmail.Visible = true;
            GridReadMessage.Visible = false;
            System.Collections.Generic.List<DAL.DataObject.Email> EmailList = DAL.DataAccess.Email.GetEmailFromFolder(LoginHandler.LoggedInUser().Id.Value,"deleted");
            GridEmail.Attributes.Add("currentlist","deleted") ;
            GridEmail.DataSource = EmailList;
            GridEmail.DataBind();
            hiddenDeletePressed.Value = "YES";
        }
        private void setInboxEmailNumber()
        {
            Int64 count = DAL.DataAccess.Email.NumberOfUnreadMessageAtInbox(LoginHandler.LoggedInUser().Id.Value);
            if (count > 0)
            {
                lbtnInbox.Text = "Inbox" + "(" + count + ")";

            }
            else { lbtnInbox.Text = "Inbox"; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                BindEmailWithInboxItem();
                setInboxEmailNumber();
               // UpdatePanelComposeMail.Visible = false;
                
            }

        }
       
        protected void GridEmail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gr = GridEmail.Rows[e.RowIndex];
            TextBox txtparentEmailId = (TextBox)gr.FindControl("txtParentId");
            DAL.DataAccess.Email.MoveEmail(LoginHandler.LoggedInUser().Id.Value, Convert.ToInt64( txtparentEmailId.Text), "deleted");
           switch (GridEmail.Attributes["currentlist"])
           {
               case "deleted":
                   BindEmailWithDeletedItem();
                   break;
               case "inbox":
                   BindEmailWithInboxItem();
                   break;
               case "sent":
                   BindEmailWithSentItem();
                   break;
           }
              
           
        }

        protected void GridEmail_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
            GridViewRow gr = GridEmail.Rows[e.NewEditIndex];
            TextBox txtparentEmailId = (TextBox)gr.FindControl("txtParentId");
           

            BindReadMessageGrid(Convert.ToInt64(txtparentEmailId.Text));
            if (GridEmail.Attributes["currentlist"] == "inbox")
            {
                DAL.DataAccess.Email.ChangeEmailStatus(Convert.ToInt64(txtparentEmailId.Text), 1);
            }
            setInboxEmailNumber();
           
        }

        private void BindReadMessageGrid( Int64 Parent_Email_id)
        {
            GridEmail.Visible = false;
            GridReadMessage.Visible = true;
            GridReadMessage.Attributes.Add("parentid", Parent_Email_id.ToString());

            System.Collections.Generic.List<DAL.DataObject.Email> EmailList = DAL.DataAccess.Email.GetEmailListByParentEmailID( Parent_Email_id);
            if (EmailList[0].Sender_Id.Value == LoginHandler.LoggedInUser().Id.Value){
                GridReadMessage.Attributes.Add("recieverid",EmailList[0].Reciever_Id.Value.ToString());
                 GridReadMessage.Attributes.Add("2ndperson",EmailList[0].Reciever_Name.ToString());

            }
            else { GridReadMessage.Attributes.Add("recieverid", EmailList[0].Sender_Id.Value.ToString());
                 GridReadMessage.Attributes.Add("2ndperson",EmailList[0].Sender_Name.ToString());
           
            }
            GridReadMessage.DataSource = EmailList;
            GridReadMessage.DataBind();
            lblHeaderText.Text="Message between you and "+Convert.ToString(GridReadMessage.Attributes["2ndperson"]);
            setInboxEmailNumber();
        }

       

        protected void GridReadMessage_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
    
           TextBox txtEnterMessage = (TextBox)GridReadMessage.FooterRow.FindControl("txtEnterMessage");
           if (txtEnterMessage.Text.Length > 0)
           {
               DAL.DataObject.Email eml = new DAL.DataObject.Email();
               eml.Parent_Id = Convert.ToInt64(GridReadMessage.Attributes["parentid"]);
               eml.Reciever_Id = Convert.ToInt64(GridReadMessage.Attributes["recieverid"]);
               eml.Sender_Id = LoginHandler.LoggedInUser().Id.Value;
               eml.Subject = "Re:";
               eml.Message = BDDoctors.DAL.Common.GetTextWithBr(txtEnterMessage.Text);
               DAL.DataAccess.Email.SaveEmail(eml);
               BindReadMessageGrid(eml.Parent_Id.Value);
           }
        }

        protected void lbtnInbox_Click(object sender, EventArgs e)
        {
            BindEmailWithInboxItem();
            lblHeaderText.Text = "Inbox Message(s)";
            lbtnInbox.CssClass = "Selected";
            lbtnSentItem.CssClass = "Deselected";
            lblDeletedMail.CssClass = "Deselected";
        }

        protected void lbtnSentItem_Click(object sender, EventArgs e)
        {
            BindEmailWithSentItem();
            lblHeaderText.Text = "Sent Message(s)";
            lbtnSentItem.CssClass = "Selected";
            lbtnInbox.CssClass = "Deselected";
            lblDeletedMail.CssClass = "Deselected";
        }

        protected void lblDeletedMail_Click(object sender, EventArgs e)
        {
            BindEmailWithDeletedItem();
            lblHeaderText.Text = "Deleted Message(s)";
            lblDeletedMail.CssClass = "Selected";
            lbtnInbox.CssClass = "Deselected";
            lbtnSentItem.CssClass = "Deselected";
           
        }

        protected void GridEmail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridEmail.PageIndex = e.NewPageIndex;
            switch (GridEmail.Attributes["currentlist"])
            {
                case "deleted":
                    BindEmailWithDeletedItem();
                    break;
                case "inbox":
                    BindEmailWithInboxItem();
                    break;
                case "sent":
                    BindEmailWithSentItem();
                    break;
            }
        }

       

        
        

       
        

       

       


       
    }
}
