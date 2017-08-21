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
using BDDoctors.DAL;
using BDDoctors;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BDDoctors.DAL.DataAccess
{
    public class Email
    {
        private static DAL.DataObject.Email CreateEmailObject(DataRow dr)
        {
            DAL.DataObject.Email objEmail = new DAL.DataObject.Email();
            objEmail.Id = Common.ToInt64(dr["id"]);
            objEmail.Parent_Id = Common.ToInt64(dr["parent_id"]);
            objEmail.Sender_Id = Common.ToInt64(dr["sender_id"]);
            objEmail.Sender_Name = Common.ToString(dr["sender_name"]);
            objEmail.Reciever_Id = Common.ToInt64(dr["reciever_id"]);
            objEmail.Reciever_Name = Common.ToString(dr["reciever_name"]);
            objEmail.Subject = Common.ToString(dr["subject"]);
            objEmail.Message = Common.ToString(dr["message"]);
            objEmail.Status = Common.ToInt64(dr["status"]);

            objEmail.ActionDate = Common.ToDateTime(dr["action_date"]);
            objEmail.User_Id1 = Common.ToInt64(dr["user_id1"]);
            objEmail.Folder_Name1 = Common.ToString(dr["folder_name1"]);
            objEmail.User_Id2 = Common.ToInt64(dr["user_id2"]);
            objEmail.Folder_Name2 = Common.ToString(dr["folder_name2"]);

            return objEmail;

        }
        public static System.Collections.Generic.List<DAL.DataObject.Email> GetEmailListByParentEmailID(Int64 parent_email_id)
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_Get_Email_With_Parent_Id";
            SqlCmd.Parameters.AddWithValue("@Parent_id_of_Email", parent_email_id);

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            System.Collections.Generic.List<DAL.DataObject.Email> EmailList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Email>();
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                BDDoctors.DAL.DBConn.Disconnect();
                if (dset != null && dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dset.Tables[0].Rows)
                    {
                        EmailList.Add(CreateEmailObject(dr));
                    }

                }
            }
            return EmailList;
        }
        public static System.Collections.Generic.List<DAL.DataObject.Email> GetInBoxEmail(Int64 UserId)
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_BLL_Get_Inbox_Email";
            SqlCmd.Parameters.AddWithValue("@userid", UserId);
            
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            System.Collections.Generic.List<DAL.DataObject.Email> EmailList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Email>();
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                BDDoctors.DAL.DBConn.Disconnect();
                if (dset != null && dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dset.Tables[0].Rows)
                    {
                        EmailList.Add(CreateEmailObject(dr));
                    }
 
                }
            }
            return EmailList;
        }
      
        public static System.Collections.Generic.List<DAL.DataObject.Email> GetSentEmail(Int64 UserId)
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_BLL_Get_Send_Email";
            SqlCmd.Parameters.AddWithValue("@userid", UserId);

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            System.Collections.Generic.List<DAL.DataObject.Email> EmailList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Email>();
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                BDDoctors.DAL.DBConn.Disconnect();
                if (dset != null && dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dset.Tables[0].Rows)
                    {
                        EmailList.Add(CreateEmailObject(dr));
                    }

                }
            }
            return EmailList;
        }

        public static System.Collections.Generic.List<DAL.DataObject.Email> GetEmailFromFolder(Int64 UserId,string folderName)
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_BLL_Get_Email_From_Folder";
            SqlCmd.Parameters.AddWithValue("@userid", UserId);
            SqlCmd.Parameters.AddWithValue("@folderName", folderName);

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            System.Collections.Generic.List<DAL.DataObject.Email> EmailList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Email>();
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                BDDoctors.DAL.DBConn.Disconnect();
                if (dset != null && dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dset.Tables[0].Rows)
                    {
                        EmailList.Add(CreateEmailObject(dr));
                    }

                }
            }
            return EmailList;
        }
        public static Boolean MoveEmail(Int64 userId,Int64 Parent_id,string folder_name)
        {
            Int64 ReturnId = 0;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.CommandText = "sp_Move_Email";
            SqlCmd.Parameters.AddWithValue("@user_id", userId);
            SqlCmd.Parameters.AddWithValue("@parent_id", Parent_id);
            SqlCmd.Parameters.AddWithValue("@folder_name", folder_name);

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
        
        public static Boolean SaveEmail(DAL.DataObject.Email objEmail)
        {
            Int64 ReturnId = 0;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.CommandText = "sp_Save_Email";
            SqlCmd.Parameters.AddWithValue("@id", objEmail.Id);
            SqlCmd.Parameters.AddWithValue("@parent_id", objEmail.Parent_Id);
            SqlCmd.Parameters.AddWithValue("@sender_id", objEmail.Sender_Id);
            SqlCmd.Parameters.AddWithValue("@reciever_id", objEmail.Reciever_Id);
            SqlCmd.Parameters.AddWithValue("@subject", objEmail.Subject);
            SqlCmd.Parameters.AddWithValue("@message", objEmail.Message);
            SqlCmd.Parameters.AddWithValue("@status", objEmail.Status);
           
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

        public static Boolean ChangeEmailStatus(Int64 parent_id,Int64 status)
        {
            Int64 ReturnId = 0;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.CommandText = "sp_Change_Email_Status";

            SqlCmd.Parameters.AddWithValue("@parent_id", parent_id);

            SqlCmd.Parameters.AddWithValue("@status", status);

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

        public static Int64 NumberOfUnreadMessageAtInbox (Int64 userId)
        {
            //Int64 ReturnId = 0;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.CommandText = "sp_NumberUnreadMaillAtInbox";
            SqlCmd.Parameters.AddWithValue("@userid", userId);
            Nullable< Int64> Count=0;
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                Count= DAL.Common.ToInt64(SqlCmd.ExecuteScalar());
                 BDDoctors.DAL.DBConn.Disconnect();
            }
            if (Count != null)
            {
                return Count.Value;
            }
            return 0;
            
        }
    }
}
