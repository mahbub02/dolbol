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
using System.Data.Sql;
using System.Data.SqlClient;
namespace BDDoctors
{
    public partial class World : System.Web.UI.Page
    {
        

        
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

            if (Page.IsPostBack == false)
            {
                BindUserLocation(1);
                BindCurrentMemberList();
                
            }

        }
        private void BindUserLocation(Int64 worldId)
        {
            string tempQ = string.Empty;
            tempQ = "SELECT * FROM Room WHERE Room.World_id=@world_id";
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = tempQ;
            SqlCmd.Parameters.AddWithValue("@world_id", worldId);
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                BDDoctors.DAL.DBConn.Disconnect();
            }
            dlUsers.DataSource = dset;
            dlUsers.DataBind();
        }

      
        protected void imgbtnSetHome_Click(object sender, ImageClickEventArgs e)
        {
            SaveLocation();
        }

        private Boolean SaveLocation()
        {
            string tempQ = string.Empty;



            tempQ = "SELECT * FROM Room WHERE Room.user_id=@user_id";
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = tempQ;
            SqlCmd.Parameters.AddWithValue("@user_id", LoginHandler.LoggedInUser().Id.Value);
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                BDDoctors.DAL.DBConn.Disconnect();
            }


            if (dset.Tables!=null && dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
            {
                Int64 ReturnId = 0;
                SqlCmd = new SqlCommand();
                SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
                SqlCmd.CommandType = CommandType.Text;

                SqlCmd.CommandText = "Update room set location=@location where user_id=@user_id";
                SqlCmd.Parameters.AddWithValue("@location", txtMyDetails.Value);
                SqlCmd.Parameters.AddWithValue("@user_id", LoginHandler.LoggedInUser().Id.Value);

                SqlDa = new SqlDataAdapter(SqlCmd);
                if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
                {

                    if (SqlCmd.ExecuteNonQuery() > 0)
                    {
                        SqlCmd.Parameters.Clear();
                        BDDoctors.DAL.DBConn.Disconnect();
                        
                    }
                }
                BDDoctors.DAL.DBConn.Disconnect();
            }
            else
            {
                Int64 ReturnId = 0;
               SqlCmd = new SqlCommand();
                SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
                SqlCmd.CommandType = CommandType.Text;

                SqlCmd.CommandText = "Insert into room values(@user_id,@user_name,@world_id,@location)";
                SqlCmd.Parameters.AddWithValue("@user_id", LoginHandler.LoggedInUser().Id.Value);
                SqlCmd.Parameters.AddWithValue("@user_name", LoginHandler.LoggedInUser().DisplayName);
                SqlCmd.Parameters.AddWithValue("@world_id",GetWorldId());
                SqlCmd.Parameters.AddWithValue("@location", txtMyDetails.Value);
                

              
                if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
                {

                    if (SqlCmd.ExecuteNonQuery() > 0)
                    {
                        SqlCmd.Parameters.Clear();
                        BDDoctors.DAL.DBConn.Disconnect();
                        
                    }

                }
                BDDoctors.DAL.DBConn.Disconnect();
                
            }
           
            BindUserLocation(1);
            return true;
        }
        public Int64 GetWorldId()
        {
            return 1;
        }
       public void BindCurrentMemberList()
       {
           System.Collections.Generic.List<RoomAndNumberOfMember> RoomMemberList = new System.Collections.Generic.List<RoomAndNumberOfMember>();
           RoomAndNumberOfMember rnm;
           for(int i=1;i<=10;i++)
           {
           rnm=new RoomAndNumberOfMember();
              rnm.RoomId=i;
              System.Collections.Generic.List<DAL.DataObject.RoomChatter> RoomChatters = DAL.DataAccess.RoomChatter.GetRoomChatters(i);
              rnm.CurrentMember = RoomChatters.Count();
              RoomMemberList.Add(rnm);
           }
           datalistRoomChater.DataSource = RoomMemberList;
           datalistRoomChater.DataBind();
           
       
       }




    }
    public class RoomAndNumberOfMember
    {
        public Int64 m_roomId = 0;
        public Int64 m_CurrentMember;
        public Int64 RoomId
        {
            set
            {
                m_roomId = value;
            }
            get
            {
                return m_roomId;
            }
        }
        public Int64 CurrentMember
        {
            set
            {
                m_CurrentMember = value;
            }
            get
            {
                return m_CurrentMember;
            }
        }
    
    }
}
