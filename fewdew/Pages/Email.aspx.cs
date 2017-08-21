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
            GridEmail.Visible = true;
            GridReadMessage.Visible = false;

            System.Collections.Generic.List<DAL.DataObject.Email> EmailList = DAL.DataAccess.Email.GetInBoxEmail(LoginHandler.LoggedInUser().Id.Value);
            GridEmail.DataSource = EmailList;
            GridEmail.DataBind();
        }
        public void BindEmailWithSentItem()
        {
            GridEmail.Visible = true;
            GridReadMessage.Visible = false;

            System.Collections.Generic.List<DAL.DataObject.Email> EmailList = DAL.DataAccess.Email.GetSentEmail(LoginHandler.LoggedInUser().Id.Value);
            GridEmail.DataSource = EmailList;
            GridEmail.DataBind();
        }
        private void setInboxEmailNumber()
        {
            Int64 count = DAL.DataAccess.Email.NumberOfUnreadMessageAtInbox(LoginHandler.LoggedInUser().Id.Value);
            if (count > 0)
            {
                lbtnInbox.Text = lbtnInbox.Text + "(" + count + ")";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                BindEmailWithInboxItem();
                setInboxEmailNumber();
                
            }

        }
       
        protected void GridEmail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gr = GridEmail.Rows[e.RowIndex];
            TextBox txtparentEmailId = (TextBox)gr.FindControl("txtParentId");
            DAL.DataAccess.Email.MoveEmail(LoginHandler.LoggedInUser().Id.Value, Convert.ToInt64( txtparentEmailId.Text), "deleted");
            BindEmailWithInboxItem();
        }

        protected void GridEmail_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
            GridViewRow gr = GridEmail.Rows[e.NewEditIndex];
            TextBox txtparentEmailId = (TextBox)gr.FindControl("txtParentId");
           
           
            BindReadMessageGrid(Convert.ToInt64(txtparentEmailId.Text));
           
            DAL.DataAccess.Email.ChangeEmailStatus(Convert.ToInt64(txtparentEmailId.Text), 1);
            setInboxEmailNumber();
           
        }

        private void BindReadMessageGrid( Int64 Parent_Email_id)
        {
            GridEmail.Visible = false;
            GridReadMessage.Visible = true;
            GridReadMessage.Attributes.Add("parentid", Parent_Email_id.ToString());

            System.Collections.Generic.List<DAL.DataObject.Email> EmailList = DAL.DataAccess.Email.GetEmailListByParentEmailID( Parent_Email_id);
            if (EmailList[0].Sender_Id.Value == LoginHandler.LoggedInUser().Id.Value)
            {
                GridReadMessage.Attributes.Add("recieverid",EmailList[0].Reciever_Id.Value.ToString());
            }
            else { GridReadMessage.Attributes.Add("recieverid", EmailList[0].Sender_Id.Value.ToString()); }
            GridReadMessage.DataSource = EmailList;
            GridReadMessage.DataBind();
        }

       

        protected void GridReadMessage_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
    
           TextBox txtEnterMessage = (TextBox)GridReadMessage.FooterRow.FindControl("txtEnterMessage");
           DAL.DataObject.Email eml = new DAL.DataObject.Email();
           eml.Parent_Id = Convert.ToInt64(GridReadMessage.Attributes["parentid"]);
           eml.Reciever_Id = Convert.ToInt64(GridReadMessage.Attributes["recieverid"]);
           eml.Sender_Id = LoginHandler.LoggedInUser().Id.Value;
           eml.Message =BDDoctors.DAL.Common.GetTextWithBr( txtEnterMessage.Text);
           DAL.DataAccess.Email.SaveEmail(eml);
           BindReadMessageGrid(eml.Parent_Id.Value);

        }

        protected void lbtnInbox_Click(object sender, EventArgs e)
        {
            BindEmailWithInboxItem();
            
        }

        protected void lbtnSentItem_Click(object sender, EventArgs e)
        {
            BindEmailWithSentItem();
        }

        

       
        

       

       


       
    }
}
