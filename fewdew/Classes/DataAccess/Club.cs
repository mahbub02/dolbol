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
    public class ClubLocation
    {
        private static DataObject.ClubPlace CreateClubPlaceObject(DataRow dr)
        {
            DataObject.ClubPlace objClub = new DataObject.ClubPlace();
            objClub.Id = Common.ToInt64(dr["id"]);
            objClub.clubId = Common.ToInt64(dr["club_id"]);
            objClub.Name = Common.ToString(dr["name"]);
            objClub.Description = Common.ToString(dr["description"]);
            objClub.Xs = ConvertToList( Common.ToString(dr["Xs"]));
            objClub.Ys =ConvertToList( Common.ToString(dr["Ys"]));
            objClub.LinkTo = Common.ToInt64(dr["link_to"]);
           
            return objClub;
        }

        public static System.Collections.Generic.List<string> ConvertToList(string str)
        { 
           return   str.Split(',').ToList<string>();
        }
        public static string ConvertToString(System.Collections.Generic.List<string> StrList)
        {
            string OutPutStr = string.Empty;
            foreach (string str in StrList)
            {
                OutPutStr += "," + str;
            }
            return OutPutStr.Remove(0, 1);
        }

        public static Boolean SaveClubPlace(DataObject.ClubPlace objClub)
        {
            Int64 ReturnId = 0;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_Club_Save_Club_Place";
            SqlCmd.Parameters.AddWithValue("@id", objClub.Id);
            SqlCmd.Parameters.AddWithValue("@club_id", objClub.clubId);
            SqlCmd.Parameters.AddWithValue("@name", objClub.Name);
            SqlCmd.Parameters.AddWithValue("@description", objClub.Description);
            SqlCmd.Parameters.AddWithValue("@Xs", ConvertToString( objClub.Xs));
            SqlCmd.Parameters.AddWithValue("@Ys", ConvertToString(  objClub.Ys));
            SqlCmd.Parameters.AddWithValue("@link_to", objClub.LinkTo);

            try
            { 
            
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (SqlCmd.Connection.State == ConnectionState.Open)
            {
                if (SqlCmd.ExecuteNonQuery() > 0)
                {
                    SqlCmd.Parameters.Clear();
                    objClub.Id = ReturnId;
                    SqlCmd.CommandText = "Select max(id) from ClubPlace";
                    SqlCmd.CommandType = CommandType.Text;
                    objClub.Id = (Int64)SqlCmd.ExecuteScalar();
                    SqlCmd.Connection.Close();
                    return true;
                }
            }
            SqlCmd.Connection.Close();
            }
            catch(Exception e)
            {
                string s = e.Message.ToString();
            }
            return false;
        }



        public static System.Collections.Generic.List<DataObject.ClubPlace> GetClubPlacesByClubId(int @club_Id)
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_Club_GetClubPlacesByClubId";
            SqlCmd.Parameters.AddWithValue("@club_Id", club_Id);
           
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            System.Collections.Generic.List<DataObject.ClubPlace> ClubList = new System.Collections.Generic.List<DataObject.ClubPlace>();
            if (SqlCmd.Connection.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                SqlCmd.Connection.Close();
                if ((dset != null) && dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dset.Tables[0].Rows)
                    {
                        ClubList.Add(CreateClubPlaceObject(dr));
                    }

                }
            }
            return ClubList;
        }


        public static bool DeleteClubPlace(int Placeid)
        {
            Int64 ReturnId = 0;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = "delete from ClubPlace where id=@Placeid";
            SqlCmd.Parameters.AddWithValue("@id", Placeid);
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (SqlCmd.Connection.State == ConnectionState.Open)
            {
                if (SqlCmd.ExecuteNonQuery() > 0)
                {
                    SqlCmd.Connection.Close();
                    return true;
                }
            }
            SqlCmd.Connection.Close();
            return false;
        }

    }
 
}
