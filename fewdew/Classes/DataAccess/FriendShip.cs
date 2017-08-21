using System;
using System.Data;
using System.Configuration;
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


namespace BDDoctors.DAL.DataAccess
{
    public class FriendShip
    {
        private static DAL.DataObject.FriendShip CreateFriendShipObject(DataRow dr)
        {
            DAL.DataObject.FriendShip objFriendShip = new DAL.DataObject.FriendShip();
            objFriendShip.User1 = Common.ToInt64(dr["user1"]);
            objFriendShip.User2 = Common.ToInt64(dr["user2"]);
            objFriendShip.Status = Common.ToInt64(dr["status"]);
            objFriendShip.ActionDate = Convert.ToDateTime(dr["action_date"]);
            return objFriendShip;
        }
        private static DAL.DataObject.Friend CreateFriendObject(DataRow dr)
        {
            DAL.DataObject.Friend objFriendShip = new DAL.DataObject.Friend();
            objFriendShip.UserId = Common.ToInt64(dr["user_id"]);
            objFriendShip.Status = Common.ToInt64(dr["status"]);
            objFriendShip.DisplayName = Common.ToString(dr["display_name"]);
            objFriendShip.ActionDate = Convert.ToDateTime(dr["action_date"]);
            return objFriendShip;
        }
        public static Boolean SaveFriendShip(DAL.DataObject.FriendShip frndShip)
        {
           
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.CommandText = "sp_Save_FriendShip";
            SqlCmd.Parameters.AddWithValue("@user1_id", frndShip.User1);
            SqlCmd.Parameters.AddWithValue("@user2_id", frndShip.User2);
            SqlCmd.Parameters.AddWithValue("@status", frndShip.Status);

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {

                if (SqlCmd.ExecuteNonQuery() > 0)
                {
                    BDDoctors.DAL.DBConn.Disconnect();
                    return true;
                }

            }
            BDDoctors.DAL.DBConn.Disconnect();

            return false;
        }
        public static Boolean DeleteFriendShip(Int64 user1 , Int64 user2)
        {

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.CommandText = "sp_Delete_FriendShip";
            SqlCmd.Parameters.AddWithValue("@user1", user1);
            SqlCmd.Parameters.AddWithValue("@user2", user2);
          
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {

                if (SqlCmd.ExecuteNonQuery() > 0)
                {
                    BDDoctors.DAL.DBConn.Disconnect();
                    return true;
                }

            }
            BDDoctors.DAL.DBConn.Disconnect();

            return false;
        }
        public static System.Collections.Generic.List<DAL.DataObject.Friend> GetFriendList(Int64 user_id)
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_GetFriendList";
            SqlCmd.Parameters.AddWithValue("@user", user_id);
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            System.Collections.Generic.List<DAL.DataObject.Friend> FriendList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Friend>();

            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                if (dset != null && dset.Tables.Count > 0)
                {
                    foreach (DataRow dr in dset.Tables[0].Rows)
                    {
                        FriendList.Add(CreateFriendObject(dr));
                    }
                }
               
                
            }
            BDDoctors.DAL.DBConn.Disconnect();
            return FriendList;
        }
        public static System.Collections.Generic.List<DAL.DataObject.Friend> GetShortFriendList(Int64 user_id)
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_GetFriendList";
            SqlCmd.Parameters.AddWithValue("@user", user_id);
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            System.Collections.Generic.List<DAL.DataObject.Friend> FriendList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Friend>();

            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                if (dset != null && dset.Tables.Count > 0)
                {
                    foreach (DataRow dr in dset.Tables[0].Rows)
                    {
                        FriendList.Add(CreateFriendObject(dr));
                    }
                }


            }
            BDDoctors.DAL.DBConn.Disconnect();
            return FriendList;
        }
      
        public static System.Collections.Generic.List<DAL.DataObject.Friend> GetFriendListUnionAwaitingForResponse(Int64 user_id)
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_GetFriendListUnionAwaitedList";
            SqlCmd.Parameters.AddWithValue("@user", user_id);
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            System.Collections.Generic.List<DAL.DataObject.Friend> FriendList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Friend>();

            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                if (dset != null && dset.Tables.Count > 0)
                {
                    foreach (DataRow dr in dset.Tables[0].Rows)
                    {
                        FriendList.Add(CreateFriendObject(dr));
                    }
                }


            }
            BDDoctors.DAL.DBConn.Disconnect();
            return FriendList;
        }
        public static System.Collections.Generic.List<DAL.DataObject.Friend> GetFriendAwaitingForMyResponse(Int64 user_id)
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_GetFriendListAwaitingForResponse";
            SqlCmd.Parameters.AddWithValue("@user", user_id);
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            System.Collections.Generic.List<DAL.DataObject.Friend> FriendList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Friend>();

            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                if (dset != null && dset.Tables.Count > 0)
                {
                    foreach (DataRow dr in dset.Tables[0].Rows)
                    {
                        FriendList.Add(CreateFriendObject(dr));
                    }
                }


            }
            BDDoctors.DAL.DBConn.Disconnect();
            return FriendList;
        }
        public static Boolean IsHeExistInTheList( Nullable < Int64> userId,System.Collections.Generic.List<BDDoctors.DAL.DataObject.Friend> PeopleList )
        {
            System.Collections.Generic.IEnumerable<Nullable<Int64>> Parent_Ids = from DAL.DataObject.Friend frnd in PeopleList
                                                                                 where ( frnd.UserId.Value == userId)
                                                                                 select frnd.UserId;
            if (Parent_Ids.Max()>0)
            {
                return true;
            }
            return false;
        }
        public static Int64 NumberOfFriendRequest(Int64 userId)
        {
            Int64 Count = 0;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
               
                    SqlCmd.CommandText = "SELECT  Count(*) FROM FRIENDSHIP WHERE USER2=@USER AND STATUS=@STATUS";
                    SqlCmd.Parameters.AddWithValue("@USER", userId);
                    SqlCmd.Parameters.AddWithValue("@STATUS", 0);                    
                    SqlCmd.CommandType = CommandType.Text;
                    Count = DAL.Common.ToInt64(SqlCmd.ExecuteScalar()).Value;
                    BDDoctors.DAL.DBConn.Disconnect();
      
            }
        
            return Count;
        }
        public static DAL.DataObject.FriendShip GetFriendShipStatusBetweenThem(Int64 user1, Int64 user2) 
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = "Select * from Friendship where (user1=@user1 and user2=@user2)or(user1=@user2 and user2=@user1)";
            SqlCmd.Parameters.AddWithValue("@user1", user1);
            SqlCmd.Parameters.AddWithValue("@user2", user2);

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            DAL.DataObject.FriendShip FriendShip = null;

            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                if (dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
                {
                   FriendShip= CreateFriendShipObject(dset.Tables[0].Rows[0]);
                }


            }
            BDDoctors.DAL.DBConn.Disconnect();
            return FriendShip;

        }
 

    }
}
