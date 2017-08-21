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
using System.Drawing.Imaging;

namespace BDDoctors.Controls
{
    public partial class CreatePersona : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                BindPersonaList();
            }
        }

       
        private void BindPersonaList()
        {
            System.Collections.Generic.List<DAL.DataObject.User> PersonaList = DAL.DataAccess.User.GetAllPersona(LoginHandler.LoggedInUser().Email, LoginHandler.LoggedInUser().Password);
            GridViewPersona.DataSource = PersonaList;
            GridViewPersona.DataBind();
        }

        //protected void GridViewPersona_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    //LoginHandler.DoLogOut();
        //    Int64 invokedUserId = Convert.ToInt64(GridViewPersona.DataKeys[e.NewEditIndex].Value);
        //    DAL.DataObject.User SelectedUser = DAL.DataAccess.User.GetUser(invokedUserId);
        //    LoginHandler.DoLoginWithPersona(SelectedUser);
           
        //    Response.Redirect(ResolveClientUrl("~\\Profile.aspx"));
        //}
        private void SaveACopyOfDefaultImageAsProfilePicture(DAL.DataObject.User usr)
        {
            string sourceFile = System.IO.Path.Combine(Server.MapPath("/images/profile/"), "default");
            string destFile = System.IO.Path.Combine(Server.MapPath("/images/profile/"), usr.Id.Value.ToString());
            System.IO.File.Copy(sourceFile, destFile, true);
            BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/profile/"), usr.Id.Value.ToString(), ImageFormat.Jpeg.ToString());


            sourceFile = System.IO.Path.Combine(Server.MapPath("/images/AvatarChat/Background/"), "default");
            destFile = System.IO.Path.Combine(Server.MapPath("/images/AvatarChat/Background/"), usr.Id.Value.ToString());
            System.IO.File.Copy(sourceFile, destFile, true);
            BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/images/AvatarChat/Background/"), usr.Id.Value.ToString(), ImageFormat.Jpeg.ToString());


        }

        protected void lbtnCreatePersona_Click(object sender, EventArgs e)
        {
            divCreatePersona.Visible = true;

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            System.Collections.Generic.List<DAL.DataObject.User> PersonaList = DAL.DataAccess.User.GetAllPersona(LoginHandler.LoggedInUser().Email, LoginHandler.LoggedInUser().Password);
            if (PersonaList.Count >= 10)
            {
                lblValidationMessage.Text = "Maximum 10 persona are allowed";
                return; 
            }

            if (txtPersonaName.Text.Trim().Length == 0)
            {
                lblValidationMessage.Text = "Enter the display name for this persona";
            }
            else
            {
                lblValidationMessage.Text = "";
                DAL.DataObject.User usr = LoginHandler.LoggedInUser();
                usr.DisplayName = txtPersonaName.Text;
                usr.Id = null;
                DAL.DataAccess.User.SaveUser(usr);
                SaveACopyOfDefaultImageAsProfilePicture(usr);
                BindPersonaList();
                divCreatePersona.Visible = false;
                txtPersonaName.Text = "";
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtPersonaName.Text = "";
            divCreatePersona.Visible = false;
        }

        protected void lbtnClose_Click(object sender, EventArgs e)
        {
            txtPersonaName.Text = "";
            divCreatePersona.Visible = false;
        }

        protected void GridViewPersona_EditCommand(object source, DataListCommandEventArgs e)
        {

           // LoginHandler.DoLogOut();

            Int64 invokedUserId = Convert.ToInt64(GridViewPersona.DataKeys[e.Item.ItemIndex]);
            DAL.DataObject.User SelectedUser = DAL.DataAccess.User.GetUser(invokedUserId);
            LoginHandler.DoLoginWithPersona(SelectedUser);

            Response.Redirect(ResolveClientUrl("~\\Profile.aspx"));
        }
       
    }
}