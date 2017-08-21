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
    public class User
    {
        public static DAL.DataObject.User CreateUserObject(DataRow dr)
        {
            DAL.DataObject.User objUser = new DAL.DataObject.User();
            objUser.Id =  Common.ToInt64(dr["id"]);
            objUser.DisplayName = Common.ToString(dr["display_name"]);
            objUser.Email = Common.ToString(dr["email"]);
            objUser.Password = Common.ToString(dr["password"]);
            objUser.Status = Common.ToInt32(dr["status"]);
            objUser.ActivationKey = Common.ToString(dr["activation_key"]);
            objUser.AvatarName = Common.ToString(dr["avatar_name"]);
            objUser.Sex = Common.ToBool(dr["sex"]);
            objUser.BirthDay = Common.ToDateTime(dr["birthday"]);
            return objUser;

        }
        
        public static BDDoctors.DAL.DataObject.User GetUser(string Email)
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = "SELECT TOP 1 * FROM USERS WHERE Email=@Email";
            SqlCmd.Parameters.AddWithValue("@Email", Email);

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                BDDoctors.DAL.DBConn.Disconnect();
                if (dset != null && dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
                {
                    return CreateUserObject(dset.Tables[0].Rows[0]);
                }

            }
            BDDoctors.DAL.DBConn.Disconnect();
            return null;
        }
        public static System.Collections.Generic.List< BDDoctors.DAL.DataObject.User> SearchUser(string token,Int64 MaxId)
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.CommandText = "sp_SearchUser";


            SqlCmd.Parameters.AddWithValue("@Token", token);
            SqlCmd.Parameters.AddWithValue("@MaxId", MaxId);

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            System.Collections.Generic.List<BDDoctors.DAL.DataObject.User> UserList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.User>();
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                BDDoctors.DAL.DBConn.Disconnect();
                if (dset != null && dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
                {
                    foreach(DataRow dr in dset.Tables[0].Rows)
                    {
                        UserList.Add(CreateUserObject(dr));
                    }
                    //return CreateUserObject(dset.Tables[0].Rows[0]);
                }

            }
            BDDoctors.DAL.DBConn.Disconnect();
            return UserList;
        }
        public static System.Collections.Generic.List<DAL.DataObject.User> GetAllPersona(string Email, string Password)
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = "SELECT * FROM USERS WHERE Email=@Email AND Password=@Password";
            SqlCmd.Parameters.AddWithValue("@Email", Email);
            SqlCmd.Parameters.AddWithValue("@Password", Password);

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            System.Collections.Generic.List<DAL.DataObject.User> PersonaList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.User>();
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                BDDoctors.DAL.DBConn.Disconnect();
                if (dset != null && dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dset.Tables[0].Rows)
                    {
                        PersonaList.Add(CreateUserObject(dr));
                    }
                    return PersonaList;
                }

            }
            BDDoctors.DAL.DBConn.Disconnect();
            return null;
        }
        public static BDDoctors.DAL.DataObject.User GetUser( Int64 UserId)
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = "SELECT * FROM USERS WHERE id=@id";
            SqlCmd.Parameters.AddWithValue("@id", UserId);

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                BDDoctors.DAL.DBConn.Disconnect();
                if (dset != null && dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
                {
                    return CreateUserObject(dset.Tables[0].Rows[0]);
                }

            }
            BDDoctors.DAL.DBConn.Disconnect();
            return null;
        }
        public static BDDoctors.DAL.DataObject.User GetUserByDisplayName(string DisplayName)
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = "SELECT * FROM USERS WHERE display_name=@DisplayName";
            SqlCmd.Parameters.AddWithValue("@DisplayName", DisplayName);

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                BDDoctors.DAL.DBConn.Disconnect();
                if (dset != null && dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
                {
                    return CreateUserObject(dset.Tables[0].Rows[0]);
                }

            }
            BDDoctors.DAL.DBConn.Disconnect();
            return null;
        }
        public static Boolean SaveUser(DAL.DataObject.User usr)
        {
            
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.Text;
            if (usr.Id.HasValue)
            {
                SqlCmd.CommandText = "UPDATE USERS SET Email=@Email,Password=@Password,display_name=@display_name,avatar_name=@avatar_name,activation_key=@activation_key,status=@status,sex=@sex,birthday=@birthday WHERE id=@id";
                SqlCmd.Parameters.AddWithValue("@Email", usr.Email);
                SqlCmd.Parameters.AddWithValue("@password", usr.Password);
                SqlCmd.Parameters.AddWithValue("@display_name", usr.DisplayName);
                SqlCmd.Parameters.AddWithValue("@avatar_name", usr.AvatarName);
                SqlCmd.Parameters.AddWithValue("@activation_key", usr.ActivationKey);
                SqlCmd.Parameters.AddWithValue("@status", usr.Status);
                SqlCmd.Parameters.AddWithValue("@sex", usr.Sex);
                SqlCmd.Parameters.AddWithValue("@birthday", usr.BirthDay);

                SqlCmd.Parameters.AddWithValue("@id", usr.Id);
            }
            else {
                SqlCmd.CommandText = "INSERT INTO USERS(Email,Password,display_name,avatar_name,activation_key,status,sex,birthday)Values(@Email,@Password,@display_name,@avatar_name,@activation_key,@status,@sex,@birthday)";
                SqlCmd.Parameters.AddWithValue("@Email", usr.Email);
                SqlCmd.Parameters.AddWithValue("@password", usr.Password);
                SqlCmd.Parameters.AddWithValue("@display_name", usr.DisplayName);
                SqlCmd.Parameters.AddWithValue("@avatar_name", usr.AvatarName);
                SqlCmd.Parameters.AddWithValue("@activation_key", usr.ActivationKey);
                SqlCmd.Parameters.AddWithValue("@status", usr.Status);
                SqlCmd.Parameters.AddWithValue("@sex", usr.Sex);
                SqlCmd.Parameters.AddWithValue("@birthday", usr.BirthDay);
            }

            

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                
                if(SqlCmd.ExecuteNonQuery()>0)
                {
                    SqlCmd.CommandText = "Select max(id)from users";
                    if (usr.Id == null)
                    {
                        usr.Id = DAL.Common.ToInt64(SqlCmd.ExecuteScalar());
                    }
                    BDDoctors.DAL.DBConn.Disconnect();
                    return true;
                }
            
            }
            BDDoctors.DAL.DBConn.Disconnect();
            
            return false;
        }

        //public static System.Collections.Generic.List<DAL.DataObject.User> FindUser(Int64 AttributeId, string attributeValue)
        //{
        //    DataSet dset = new DataSet();
        //    SqlCommand SqlCmd = new SqlCommand();
        //    SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
        //    SqlCmd.CommandType = CommandType.Text;
        //    SqlCmd.CommandText = "SELECT * FROM USERS WHERE Email=@Email AND Password=@Password";
        //    SqlCmd.Parameters.AddWithValue("@Email", Email);
        //    SqlCmd.Parameters.AddWithValue("@Password", Password);

        //    SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
        //    System.Collections.Generic.List<DAL.DataObject.User> PersonaList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.User>();
        //    if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
        //    {
        //        SqlDa.Fill(dset);
        //        BDDoctors.DAL.DBConn.Disconnect();
        //        if (dset != null && dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
        //        {
        //            foreach (DataRow dr in dset.Tables[0].Rows)
        //            {
        //                PersonaList.Add(CreateUserObject(dr));
        //            }
        //            return PersonaList;
        //        }

        //    }
        //    BDDoctors.DAL.DBConn.Disconnect();
        //    return null;
        //}
    }
}
