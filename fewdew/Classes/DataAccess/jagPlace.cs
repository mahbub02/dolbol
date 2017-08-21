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
    public class jagPlace
    {
        private static DataObject.JagPlace CreateJagPlaceObject(DataRow dr)
        {
            DataObject.JagPlace objJagplace = new DataObject.JagPlace();
            objJagplace.Id = Common.ToInt64(dr["id"]);
            objJagplace.Parent_Id = Common.ToInt64(dr["parent_id"]);
            objJagplace.Name = Common.ToString(dr["name"]);
            objJagplace.Description = Common.ToString(dr["description"]);
            objJagplace.OwnerId = Common.ToInt64(dr["owner_id"]);
            objJagplace.OwnerName = Common.ToString(dr["owner_name"]);
            objJagplace.RenterId = Common.ToInt64(dr["renter_id"]);
            objJagplace.RenterName = Common.ToString(dr["renter_name"]);
            objJagplace.AccessType = Common.ToInt64(dr["Access_type"]);
            objJagplace.Level = Common.ToInt64(dr["level"]);
            objJagplace.Left = Common.ToInt64(dr["left"]);
            objJagplace.Top = Common.ToInt64(dr["top"]);
            objJagplace.width = Common.ToInt64(dr["zindex"]);
            objJagplace.Height = Common.ToInt64(dr["height"]);
            objJagplace.width = Common.ToInt64(dr["width"]);
            
            return objJagplace;
        }

        public static Boolean SaveJagPlace(DataObject.JagPlace objJagplace)
        {
            Int64 ReturnId = 0;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_JagPlage_Save_JagPlace";
            SqlCmd.Parameters.AddWithValue("@id", objJagplace.Id);
            SqlCmd.Parameters.AddWithValue("@parent_id", objJagplace.Parent_Id);
            SqlCmd.Parameters.AddWithValue("@name", objJagplace.Name);
            SqlCmd.Parameters.AddWithValue("@description", objJagplace.Description);
            SqlCmd.Parameters.AddWithValue("@owner_id", objJagplace.OwnerId);
            SqlCmd.Parameters.AddWithValue("@owner_name", objJagplace.OwnerName);
            SqlCmd.Parameters.AddWithValue("@renter_id", objJagplace.RenterId);
            SqlCmd.Parameters.AddWithValue("@renter_name", objJagplace.RenterName);
            SqlCmd.Parameters.AddWithValue("@access_type", objJagplace.AccessType);
            SqlCmd.Parameters.AddWithValue("@level", objJagplace.Level);
            SqlCmd.Parameters.AddWithValue("@left", objJagplace.Left);
            SqlCmd.Parameters.AddWithValue("@top", objJagplace.Top);
            SqlCmd.Parameters.AddWithValue("@width", objJagplace.width);
            SqlCmd.Parameters.AddWithValue("@height", objJagplace.Height);
            SqlCmd.Parameters.AddWithValue("@zindex", objJagplace.zindex);

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (SqlCmd.Connection.State == ConnectionState.Open)
            {
                if (SqlCmd.ExecuteNonQuery() > 0)
                {
                    SqlCmd.Parameters.Clear();
                    objJagplace.Id = ReturnId;
                    SqlCmd.CommandText = "Select max(id) from State";
                    SqlCmd.CommandType = CommandType.Text;
                    objJagplace.Id = (Int64)SqlCmd.ExecuteScalar();
                    SqlCmd.Connection.Close();
                    return true;
                }
            }
            SqlCmd.Connection.Close();
            return false;
        }

        public static System.Collections.Generic.List<DataObject.JagPlace> GetChildJagPlaceByParentIdAndLevel(int parentId, DAL.DataObject.JagPlaceLevel Level)
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_jagplace_GetJagPlaceByParentAndLevel";
            SqlCmd.Parameters.AddWithValue("@parent_id", parentId);
            SqlCmd.Parameters.AddWithValue("@Level", Level);

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            System.Collections.Generic.List<DataObject.JagPlace> StateList = new System.Collections.Generic.List<DataObject.JagPlace>();
            if (SqlCmd.Connection.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                SqlCmd.Connection.Close();

                if ((dset != null) && dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dset.Tables[0].Rows)
                    {
                        StateList.Add(CreateJagPlaceObject(dr));
                    }

                }
            }
            return StateList;
        }


        public static DataObject.JagPlace GetJagPlaceById(int Id)
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_JapPlace_GetJagPlaceById";
            SqlCmd.Parameters.AddWithValue("@id", Id);
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (SqlCmd.Connection.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                SqlCmd.Connection.Close();
                if ((dset != null) && dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
                {
                    return CreateJagPlaceObject(dset.Tables[0].Rows[0]);
                }
            }
            return null;
        }
        public static System.Collections.Generic.List<DataObject.JagPlace> GetJagPlaceMap(int id)
        {
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_jagPlace_GetJagPlaceMap";
            SqlCmd.Parameters.AddWithValue("@place_id", id);
            

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            System.Collections.Generic.List<DataObject.JagPlace> StateList = new System.Collections.Generic.List<DataObject.JagPlace>();
            if (SqlCmd.Connection.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                SqlCmd.Connection.Close();
                if (dset != null && dset.Tables.Count > 0)
                {
                    foreach (DataTable dt in dset.Tables) 
                    {
                        if (dt.Rows.Count > 0 && dt.Rows.Count == 1)
                        {
                            StateList.Add(CreateJagPlaceObject(dt.Rows[0]));
                        }
                    }
                }

               
            }
            return StateList;
        }

        public static bool DeleteJagPlace(int id)
        {
            Int64 ReturnId = 0;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_Jagplace_Delete_JagPlace";
            SqlCmd.Parameters.AddWithValue("@id", id);



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
