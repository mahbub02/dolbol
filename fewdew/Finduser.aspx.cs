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
using BDDoctors.DAL;
using BDDoctors;
using System.Data.Sql;
using System.Data.SqlClient;
namespace BDDoctors
{
    public partial class Finduser : System.Web.UI.Page
    {
        private Boolean AmIThePageOwner()
        {
            if (LoginHandler.IsLoggedIn && PageOwner() == LoginHandler.LoggedInUser().Id)
            {
                return true;
            }
            else
            {
                return false;
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
            if (Page.IsPostBack==false)
            {
                UIhelper.PopulateDropDownClassYear(ddlYear, null);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            System.Collections.Generic.List<DAL.DataObject.User> userList = FindUser();
            GridAllFriend.DataSource = userList;
            GridAllFriend.DataBind();
        }

        public System.Collections.Generic.List<DAL.DataObject.User> FindUser()
        {
            System.Collections.Generic.List<DAL.DataObject.User> UserList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.User>();

            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.Text;
            string str;
            str = "SELECT * FROM USERS WHERE USERS.id IN" +
                "( SELECT DISTINCT user_id FROM NODE WHERE";


            Boolean FirstAlreadyTaken = false;
            if (txtContactEmail.Text.Trim().Length > 0)
            {
                
                if (FirstAlreadyTaken == false)
                {
                    str = str + "(NODE_Value like '%" + txtContactEmail.Text.Trim() + "%' AND Attribute_id=27)";
                    //SqlCmd.Parameters.AddWithValue("@27", txtContactEmail.Text);
                }
                else
                {
                    str = str + "OR (NODE_Value like '%" + txtContactEmail.Text.Trim() + "%' AND Attribute_id=27)";
                    //  SqlCmd.Parameters.AddWithValue("@27", txtContactEmail.Text);
                }
                FirstAlreadyTaken = true;
            }
            if (txtFullName.Text.Trim().Length > 0)
            {
               
                if (FirstAlreadyTaken == false)
                {
                    str = str + "(NODE_Value like '%" + txtFullName.Text.Trim() + "%' AND Attribute_id=20)";
                    // SqlCmd.Parameters.AddWithValue("@20", txtFullName.Text);
                }
                else
                {
                    str = str + " OR (NODE_Value like '%" + txtFullName.Text.Trim() + "%' AND Attribute_id=20)";
                    //SqlCmd.Parameters.AddWithValue("@20", txtFullName.Text);
                }
                FirstAlreadyTaken = true;
            }
            if (txtHomeTown.Text.Trim().Length > 0)
            {

                if (FirstAlreadyTaken == false)
                {
                    str = str + "(NODE_Value like '%" + txtHomeTown.Text.Trim() + "%' AND Attribute_id=25)";
                    // SqlCmd.Parameters.AddWithValue("@20", txtFullName.Text);
                }
                else
                {
                    str = str + " OR (NODE_Value like '%" + txtHomeTown.Text.Trim() + "%' AND Attribute_id=25)";
                    //SqlCmd.Parameters.AddWithValue("@20", txtFullName.Text);
                }
                FirstAlreadyTaken = true;
            }

            if (txtContactNumber.Text.Trim().Length > 0)
            {

                if (FirstAlreadyTaken == false)
                {
                    str = str + "(NODE_Value like '%" + txtContactNumber.Text.Trim() + "%' AND Attribute_id=26)";
                    // SqlCmd.Parameters.AddWithValue("@20", txtFullName.Text);
                }
                else
                {
                    str = str + " OR (NODE_Value like '%" + txtContactNumber.Text.Trim() + "%' AND Attribute_id=26)";
                    //SqlCmd.Parameters.AddWithValue("@20", txtFullName.Text);
                }
                FirstAlreadyTaken = true;
            }
            if (txtSpeciality.Text.Trim().Length > 0)
            {

                if (FirstAlreadyTaken == false)
                {
                    str = str + "(NODE_Value like '%" + txtSpeciality.Text.Trim() + "%' AND Attribute_id=28)";
                    // SqlCmd.Parameters.AddWithValue("@20", txtFullName.Text);
                }
                else
                {
                    str = str + " OR (NODE_Value like '%" + txtSpeciality.Text.Trim() + "%' AND Attribute_id=28)";
                    //SqlCmd.Parameters.AddWithValue("@20", txtFullName.Text);
                }
                FirstAlreadyTaken = true;
            }
            if (txtInstitueName.Text.Trim().Length > 0)
            {

                if (FirstAlreadyTaken == false)
                {
                    str = str + "(NODE_Value like '%" + txtInstitueName.Text.Trim() + "%' AND Attribute_id=9)";
                    // SqlCmd.Parameters.AddWithValue("@20", txtFullName.Text);
                }
                else
                {
                    str = str + " OR (NODE_Value like '%" + txtInstitueName.Text.Trim() + "%' AND Attribute_id=9)";
                    //SqlCmd.Parameters.AddWithValue("@20", txtFullName.Text);
                }
                FirstAlreadyTaken = true;
            }

            if (txtInstitueName.Text.Trim().Length > 0)
            {

                if (FirstAlreadyTaken == false)
                {
                    str = str + "(NODE_Value like '%" + txtInstitueName.Text.Trim() + "%' AND Attribute_id=9)";
                    // SqlCmd.Parameters.AddWithValue("@20", txtFullName.Text);
                }
                else
                {
                    str = str + " OR (NODE_Value like '%" + txtInstitueName.Text.Trim() + "%' AND Attribute_id=9)";
                    //SqlCmd.Parameters.AddWithValue("@20", txtFullName.Text);
                }
                FirstAlreadyTaken = true;
            }
            if (Convert.ToInt64( ddlYear.SelectedValue) > 0)
            {

                if (FirstAlreadyTaken == false)
                {
                    str = str + "(NODE_Value like '%" + ddlYear.SelectedValue + "%' AND Attribute_id=10)";
                    // SqlCmd.Parameters.AddWithValue("@20", txtFullName.Text);
                }
                else
                {
                    str = str + " OR (NODE_Value like '%" + ddlYear.SelectedValue + "%' AND Attribute_id=10)";
                    //SqlCmd.Parameters.AddWithValue("@20", txtFullName.Text);
                }
                FirstAlreadyTaken = true;
            }












            if (FirstAlreadyTaken == true)
            {

                SqlCmd.CommandText = str + ")";
                //SqlCmd.Parameters.AddWithValue("@Email", Email);
                //SqlCmd.Parameters.AddWithValue("@Password", Password);

                SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);

                if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
                {
                    SqlDa.Fill(dset);
                    BDDoctors.DAL.DBConn.Disconnect();
                    if (dset != null && dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dset.Tables[0].Rows)
                        {
                            UserList.Add(BDDoctors.DAL.DataAccess.User.CreateUserObject(dr));
                        }
                        
                    }

                }
                BDDoctors.DAL.DBConn.Disconnect();
               
            }
            return UserList;
        }

        protected void GridAllFriend_RowEditing(object sender, GridViewEditEventArgs e)
        {
          Int64 userId=  Convert.ToInt64(GridAllFriend.DataKeys[e.NewEditIndex].Value);
            ClickedOnAddConnectionButton1.Visible = true;
            ClickedOnAddConnectionButton1.User2Id = userId;

            HtmlAnchor anchAnch = (HtmlAnchor)GridAllFriend.Rows[e.NewEditIndex].FindControl("anchorAddFriend");
            

          //LinkButton lbtnAddAsFriend=(LinkButton)  GridAllFriend.Rows[e.NewEditIndex].FindControl("lbtnAddAsFriend");
          //lbtnAddAsFriend.Enabled = false;

            //if (DAL.DataAccess.Node.DeleteNodes()
            //{
            //    BindCommentList(DAL.DataAccess.Node.GetShortNodesByParentNodeId(Convert.ToInt64(GridComment.Attributes["ParentNodeId"])));
            //    UpdatePanel2.Update();
            //}
        }

        protected void GridAllFriend_RowDataBound(object sender, GridViewRowEventArgs e)
        {
             if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (e.Row.RowState)
                {
                     

                    case DataControlRowState.Normal:
                    case DataControlRowState.Alternate:
                     LinkButton lbtnaddasConnection=   (LinkButton)e.Row.FindControl("lbtnAddAsFriend");
                     HtmlAnchor anchAnch = (HtmlAnchor)e.Row.FindControl("anchorAddFriend");

                    DAL.DataObject.User usr = (DAL.DataObject.User)e.Row.DataItem;

                    if (DAL.DataAccess.FriendShip.IsHeExistInTheList(usr.Id.Value, LoginHandler.GetLoggedInUserFriends()) == false)
                    {
                        //lbtnaddasConnection.Text = "Already in your contact list";
                        if (LoginHandler.LoggedInUser().Id.Value != usr.Id)
                        {
                            anchAnch.HRef="sendFriendRequest.aspx?user_id=" + usr.Id.ToString();
                            anchAnch.Attributes.Add("class", "iframe");

                            //lbtnaddasConnection.Enabled = true;
                            //lbtnaddasConnection.CssClass = "active";

                        }
                        else
                        {
                            anchAnch.InnerText = "Me";

                           
                            //lbtnaddasConnection.Text = "Me.";
                            //lbtnaddasConnection.Enabled = false;
                        }

                    }
                    else {
                        anchAnch.InnerText = "Already in your contact list";

                        //lbtnaddasConnection.Text = "Already in your contact list";
                        //lbtnaddasConnection.Enabled = false;
                    }

                        break;
                }



            }

                  
        }
    }
}
