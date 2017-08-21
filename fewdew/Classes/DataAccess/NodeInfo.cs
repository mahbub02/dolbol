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
    public class NodeInfo
    {
       
           private static DAL.DataObject.NodeInfo CreateNodeInfoObject(DataRow dr)
        {
            DAL.DataObject.NodeInfo objNodeInfo = new DAL.DataObject.NodeInfo();
            objNodeInfo.Id = Common.ToInt64(dr["id"]);
            objNodeInfo.NodeId = Common.ToInt64(dr["node_id"]);

            objNodeInfo.User_id = Common.ToInt64(dr["user_id"]);
            objNodeInfo.Info = Common.ToString(dr["Info"]);
            return objNodeInfo;


        }
           public static System.Collections.Generic.List<DAL.DataObject.NodeInfo> GetNodeInfos(Int64 userId, Int64 nodeId)
           {
               System.Collections.Generic.List<DAL.DataObject.NodeInfo> NodeInfos = new System.Collections.Generic.List<DAL.DataObject.NodeInfo>();
               DataSet ds = new DataSet();
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
               SqlCmd.CommandType = CommandType.Text;
               SqlCmd.CommandText = "SELECT * FROM NODE_INFO WHERE user_id=@user_id AND node_id=@Node_Id";

               SqlCmd.Parameters.AddWithValue("@User_Id", userId);
               SqlCmd.Parameters.AddWithValue("@Node_id", nodeId);
               SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
               if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
               {
                   SqlDa.Fill(ds);
                   BDDoctors.DAL.DBConn.Disconnect();
               }



               if (ds != null && ds.Tables.Count > 0)
               {

                   foreach (DataRow dr in ds.Tables[0].Rows)
                   {
                       NodeInfos.Add(CreateNodeInfoObject(dr));
                   }

               }

               return NodeInfos;
           }

           public static Boolean SaveNodeInfo(DAL.DataObject.NodeInfo ndInfo)
           {
               Int64 ReturnId = 0;
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
               SqlCmd.CommandType = CommandType.Text;

               SqlCmd.CommandText = "Insert into node_info(node_id,user_id,info)values(@node_id,@user_id,@info)";
               SqlCmd.Parameters.AddWithValue("@node_id", ndInfo.NodeId);
               SqlCmd.Parameters.AddWithValue("@user_id", ndInfo.User_id);
               SqlCmd.Parameters.AddWithValue("@info", ndInfo.Info);
               
               SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
               if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
               {

                   if (SqlCmd.ExecuteNonQuery() > 0)
                   {
                       SqlCmd.Parameters.Clear();
                       ndInfo.Id = ReturnId;
                       SqlCmd.CommandText = "Select max(id)from node_info";
                       SqlCmd.CommandType = CommandType.Text;
                       ndInfo.Id = DAL.Common.ToInt64(SqlCmd.ExecuteScalar());

                       BDDoctors.DAL.DBConn.Disconnect();
                       return true;
                   }

               }
               BDDoctors.DAL.DBConn.Disconnect();

               return false;
           }

    }
}
