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
using System.Data.Sql;
using System.Data.SqlClient;

namespace BDDoctors
{
    public partial class SendFriendRequest : System.Web.UI.Page
    {
        public string User2Name
        {
            get
            {
                DAL.DataObject.User usr = DAL.DataAccess.User.GetUser(User2Id);
                return usr.DisplayName;
            }
        }
        public Int64 User2Id
        {
            get { return Convert.ToInt64(Request["user_id"]); }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddAsConnection_Click(object sender, EventArgs e)
        {

            DAL.DataObject.FriendShip frndshp = new BDDoctors.DAL.DataObject.FriendShip();
            frndshp.User1 = LoginHandler.LoggedInUser().Id;
            frndshp.User2 = User2Id;
            frndshp.Status = 0;
            DAL.DataAccess.FriendShip.SaveFriendShip(frndshp);
            DAL.DataObject.Friend frnd = new BDDoctors.DAL.DataObject.Friend();
            frnd.UserId = User2Id;
            frnd.ActionDate = DateTime.Now;
            frnd.Status = 0;
            frnd.DisplayName = LoginHandler.LoggedInUser().DisplayName.ToString();
            LoginHandler.AddFriendToLoggedInUserFriendList(frnd);
            btnAddAsConnection.Visible = false;

            //lblMessage.Text = "Your request has been sent. He has to confirm that you are friend";
           

        }
        protected DataRow GetFriendRequestRow()
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.Text;

            SqlCmd.CommandText = "SELECT * FROM friendship where (user1=@user and user2=@ami) or (user1=@ami and user2=@user)";
            SqlCmd.Parameters.AddWithValue("@user", Convert.ToInt64(Request["user_id"]));
            SqlCmd.Parameters.AddWithValue("@ami", LoginHandler.LoggedInUser().Id.Value );
           

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                BDDoctors.DAL.DBConn.Disconnect();

                if (dset != null && dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
                {
                    return dset.Tables[0].Rows[0];
                }
            }
          

            return null;
        }

      

    }
}
