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
    public class Node
    {
        #region Private Methods
           private static DAL.DataObject.Node CreateNodeObject(DataRow dr)
        {
            DAL.DataObject.Node objNode = new DAL.DataObject.Node();
            objNode.Id = Common.ToInt64(dr["id"]);
            objNode.Parent_Node_Id = Common.ToInt64(dr["parent_node_id"]);
            //objNode.feature_Name = Common.ToString(dr["feature_name"]);
            objNode.Attribute_id = Common.ToInt64(dr["attribute_id"]);
            //objNode.Attribute_Name = Common.ToString(dr["attribute_name"]);
            //objNode.Control_Type = Common.ToString(dr["control_type"]);

            objNode.User_id = Common.ToInt64(dr["user_id"]);
            objNode.Wall_Owner_id = Common.ToInt64(dr["wall_owner_id"]);

            objNode.User_Name = Common.ToString(dr["user_name"]);
            objNode.Wall_Owner_Name = Common.ToString(dr["wall_owner_name"]);
               
            objNode.Node_value =  Common.ToString(dr["node_value"]);
            objNode.Action_date = Common.ToDateTime(dr["action_date"]);
            objNode.Created_Or_Updated = Common.ToBoolean(dr["created_or_updated"]);
            //objNode.Source_id = Common.ToInt32(dr["source_id"]);
            return objNode;


        }
           private static DAL.DataObject.Node CreateShortNodeObject(DataRow dr)
           {
               DAL.DataObject.Node objNode = new DAL.DataObject.Node();
               objNode.Id = Common.ToInt64(dr["id"]);
               objNode.Parent_Node_Id = Common.ToInt64(dr["parent_node_id"]);              
               objNode.Attribute_id = Common.ToInt64(dr["attribute_id"]);
               objNode.User_id = Common.ToInt64(dr["user_id"]);
               objNode.User_Name = Common.ToString(dr["user_name"]);
               objNode.Node_value =  Common.ToString(dr["node_value"]);
               objNode.Action_date = Common.ToDateTime(dr["action_date"]);
               objNode.Created_Or_Updated = Common.ToBoolean(dr["created_or_updated"]);
              
               return objNode;


           }


           private static DataSet GetDataSetOfNodesOrAttribute(int attribute_id, Int64 user_id)
           {
               DataSet dset = new DataSet();
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.CommandText = "sp_BLL_Get_Nodes";
               SqlCmd.Parameters.AddWithValue("@attributeid", attribute_id);
               SqlCmd.Parameters.AddWithValue("@userId", user_id);
               SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
               if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
               {
                   SqlDa.Fill(dset);
                   BDDoctors.DAL.DBConn.Disconnect();
               }
               return dset;
           }

           private static DataSet GetDataSetOfNodesOnly(int attributeid, Int64 user_id)
           {
               DataSet dset = new DataSet();
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.CommandText = "sp_BLL_Get_Nodes_Only";
               SqlCmd.Parameters.AddWithValue("@attributeid", attributeid);
               SqlCmd.Parameters.AddWithValue("@userId", user_id);
               SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
               if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
               {
                   SqlDa.Fill(dset);
                   BDDoctors.DAL.DBConn.Disconnect();
               }
               return dset;
           }
           private static DataSet GetDataSetForWall(Int64 user_id)
           {
               DataSet dset = new DataSet();
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.CommandText = "sp_BLL_Get_UserWallContent";
              
               SqlCmd.Parameters.AddWithValue("@userId", user_id);
               SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
               if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
               {
                   SqlDa.Fill(dset);
                   BDDoctors.DAL.DBConn.Disconnect();
               }
               return dset;
           }

           private static DataSet GetDataSetOfPublicContentBasedNotification()
           {
               DataSet dset = new DataSet();
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.CommandText = "sp_BLL_Get_Public_Content_Based_Notification";

               SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
               if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
               {
                   SqlDa.Fill(dset);
                   BDDoctors.DAL.DBConn.Disconnect();
               }
               return dset;
           }
           private static DataSet GetDataSetForClubUserFeed(Nullable<Int64> Wll_Owner_Id, Nullable<Int64> Max_Id)
           {
               DataSet dset = new DataSet();
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.CommandText = "sp_Club_GetUserFeeds";
               SqlCmd.Parameters.AddWithValue("@WallOwnerId", Wll_Owner_Id);
               SqlCmd.Parameters.AddWithValue("@Max_Id", Max_Id);

               SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
               if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
               {
                   SqlDa.Fill(dset);
                   BDDoctors.DAL.DBConn.Disconnect();
               }
               return dset;
           }
           private static DataSet GetDataSetForClubFriendsFeed(Nullable<Int64> WhoseFriend, Nullable<Int64> Max_Id)
           {
               DataSet dset = new DataSet();
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.CommandText = "sp_Club_GetFriendsFeeds";
               SqlCmd.Parameters.AddWithValue("@WhoseFriend", WhoseFriend);
               SqlCmd.Parameters.AddWithValue("@Max_Id", Max_Id);

               SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
               if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
               {
                   SqlDa.Fill(dset);
                   BDDoctors.DAL.DBConn.Disconnect();
               }
               return dset;
           }
           private static DataSet GetDataSetForPublicFeed(Nullable<Int64> Max_Id)
           {
               DataSet dset = new DataSet();
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.CommandText = "sp_Club_GetPublicFeeds";
               SqlCmd.Parameters.AddWithValue("@Max_Id", Max_Id);

               SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
               if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
               {
                   SqlDa.Fill(dset);
                   BDDoctors.DAL.DBConn.Disconnect();
               }
               return dset;
           }


           private static DataSet GetDataSetOfBlogList()
           {
               DataSet dset = new DataSet();
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.CommandText = "sp_BLL_Get_BlogList";

               SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
               if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
               {
                   SqlDa.Fill(dset);
                   BDDoctors.DAL.DBConn.Disconnect();
               }
               return dset;
           }
           private static DataSet GetDataSetOfBlogListByCategory( string Category)
           {
               DataSet dset = new DataSet();
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.CommandText = "sp_BLL_Get_BlogList_ByCategory";
               SqlCmd.Parameters.AddWithValue("@Category", Category);
               SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
               if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
               {
                   SqlDa.Fill(dset);
                   BDDoctors.DAL.DBConn.Disconnect();
               }
               return dset;
           }
           private static DataSet GetDataSetOfFriendsContentBasedNotification(Int64 UserId)
           {
               DataSet dset = new DataSet();
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.CommandText = "sp_BLL_Get_Content_Based_Notification_Of_Friendz";
               SqlCmd.Parameters.AddWithValue("@UserId", UserId);
               SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
               if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
               {
                   SqlDa.Fill(dset);
                   BDDoctors.DAL.DBConn.Disconnect();
               }
               return dset;
           }

           private static DataSet GetDatasetOfMyFavourite(Int64 UserId)
           {
               DataSet dset = new DataSet();
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.CommandText = "sp_BLL_Get_My_Favourites";
               SqlCmd.Parameters.AddWithValue("@UserId", UserId);
               SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
               if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
               {
                   SqlDa.Fill(dset);
                   BDDoctors.DAL.DBConn.Disconnect();
               }
               return dset;
           }

           private static DataSet GetDataSetOfSource(Int64 Source_id)
           {
               DataSet dset = new DataSet();
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.CommandText = "Get_Text_List";
               SqlCmd.Parameters.AddWithValue("@Source_Id", Source_id);
               SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
               if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
               {
                   SqlDa.Fill(dset);
                   BDDoctors.DAL.DBConn.Disconnect();
               }
               return dset;
           }
        #endregion

        #region NodeRetrival
           public static System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> GetListNodesOrAttribute(int attribute_id, Int64 user_id)
           {
               System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListOfNodes = new System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>>();
               DataSet ds = GetDataSetOfNodesOrAttribute(attribute_id, user_id);
               if (ds != null && ds.Tables.Count > 0)
               {
                   Int64 key = 0;
                   foreach (DataTable tbl in ds.Tables)
                   {
                       System.Collections.Generic.List<DAL.DataObject.Node> NodeList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();
                       key = key + 1;
                       foreach (DataRow dr in tbl.Rows)
                       {
                           NodeList.Add(CreateNodeObject(dr));
                       }
                       ListOfNodes.Add(NodeList);
                   }
               }

               return ListOfNodes;
           }
           public static System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> GetListNodesOnly(int attributeId, Int64 user_id)
           {
               System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListOfNodes = new System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>>();
               DataSet ds = GetDataSetOfNodesOnly(attributeId, user_id);
               if (ds != null && ds.Tables.Count > 0)
               {
                   Int64 key = 0;
                   foreach (DataTable tbl in ds.Tables)
                   {
                       System.Collections.Generic.List<DAL.DataObject.Node> NodeList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();
                       key = key + 1;
                       foreach (DataRow dr in tbl.Rows)
                       {
                           NodeList.Add(CreateNodeObject(dr));
                       }
                       ListOfNodes.Add(NodeList);
                   }
               }

               return ListOfNodes;
           }
           public static System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> GetUserWallNodesList(Int64 user_id)
           {
               System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListOfNodes = new System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>>();
               DataSet ds = GetDataSetForWall( user_id);
               if (ds != null && ds.Tables.Count > 0)
               {
                   Int64 key = 0;
                   foreach (DataTable tbl in ds.Tables)
                   {
                       System.Collections.Generic.List<DAL.DataObject.Node> NodeList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();
                       key = key + 1;
                       foreach (DataRow dr in tbl.Rows)
                       {
                           NodeList.Add(CreateNodeObject(dr));
                       }
                       ListOfNodes.Add(NodeList);
                   }
               }

               return ListOfNodes;
           }


        public static DAL.DataObject.Node  GetShortNodeByID(Int64 NodeId)
        {
            DataSet ds = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = "Select * from node where id=@Node_Id";

            SqlCmd.Parameters.AddWithValue("@Node_id", NodeId);
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(ds);
                BDDoctors.DAL.DBConn.Disconnect();
            }
            if (ds != null && ds.Tables.Count > 0&& ds.Tables[0].Rows.Count>0)
            {
                 return  CreateShortNodeObject(ds.Tables[0].Rows[0]);
            }
            return null;
        }
        public static DAL.DataObject.Node GetNodeByID(Int64 NodeId)
        {
            DataSet ds = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = "Select * from node where id=@Node_Id";

            SqlCmd.Parameters.AddWithValue("@Node_id", NodeId);
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(ds);
                BDDoctors.DAL.DBConn.Disconnect();
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return CreateNodeObject(ds.Tables[0].Rows[0]);
            }
            return null;
        }

           public static System.Collections.Generic.List<DAL.DataObject.Node> GetNodesOnly(Int64 parent_node_id)
           {
               System.Collections.Generic.List<DAL.DataObject.Node> Nodes = new System.Collections.Generic.List<DAL.DataObject.Node>();
               DataSet ds = new DataSet();
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.CommandText = "sp_DAL_Get_Nodes";
               SqlCmd.Parameters.AddWithValue("@parent_node_id", parent_node_id);
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
                       Nodes.Add(CreateNodeObject(dr));
                   }

               }

               return Nodes;
           }
          
        public static System.Collections.Generic.List<DAL.DataObject.Node> GetShortNodesByParentNodeId(Int64 parent_node_id)
           {
               System.Collections.Generic.List<DAL.DataObject.Node> Nodes = new System.Collections.Generic.List<DAL.DataObject.Node>();
               DataSet ds = new DataSet();
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.CommandText = "sp_Dal_Get_Nodes_By_Parent_Node_id";
              
               SqlCmd.Parameters.AddWithValue("@parent_node_id", parent_node_id);
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
                       Nodes.Add(CreateShortNodeObject(dr));
                   }

               }

               return Nodes;
           }
           #endregion
   
        #region SaveOrDelete

        public static Int64 SaveNodes(System.Collections.Generic.List <DataObject.Node> NodeList)
        {
            
           
            var orderedNodeList = from DataObject.Node n in NodeList
                             orderby n.Attribute_id
                             select n;
            Nullable<Int64> Parent_id = GetParentIdFromNodeList(NodeList); 

            foreach (DataObject.Node nd in orderedNodeList)
            {
                if (Parent_id == null)
                {
                    SaveNode(nd);
                    Parent_id = nd.Id;
                    nd.Parent_Node_Id = Parent_id;
                }
                else {
                    nd.Parent_Node_Id = Parent_id;
                    SaveNode(nd);
                    //Parent_id = nd.Id;
                }
                //nd.Parent_Node_Id = Parent_id;
                //SaveNode(nd);
            }
            return Parent_id.Value;
     
        }
          
        public static Boolean SaveNode(DAL.DataObject.Node nd)
        {
            Int64 ReturnId = 0;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.CommandText = "sp_Save_Node";
            SqlCmd.Parameters.AddWithValue("@Id", nd.Id);
            SqlCmd.Parameters.AddWithValue("@parent_node_id", nd.Parent_Node_Id);
            SqlCmd.Parameters.AddWithValue("@attribute_id", nd.Attribute_id);
            SqlCmd.Parameters.AddWithValue("@user_id", nd.User_id);
            SqlCmd.Parameters.AddWithValue("@user_name", nd.User_Name);
            SqlCmd.Parameters.AddWithValue("@wall_owner_id", nd.Wall_Owner_id);
            SqlCmd.Parameters.AddWithValue("@wall_owner_name", nd.Wall_Owner_Name);
            SqlCmd.Parameters.AddWithValue("@node_value", DAL.Common.GetTextWithBr( nd.Node_value));
            
            SqlCmd.Parameters.AddWithValue("@Returned_id", ReturnId);
           
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {

                if (SqlCmd.ExecuteNonQuery() > 0)
                {
                    SqlCmd.Parameters.Clear();
                    nd.Id = ReturnId;
                    SqlCmd.CommandText = "Select max(id)from node";
                    SqlCmd.CommandType = CommandType.Text;
                    nd.Id = DAL.Common.ToInt64(SqlCmd.ExecuteScalar());

                    BDDoctors.DAL.DBConn.Disconnect();
                    return true;
                }

            }
            BDDoctors.DAL.DBConn.Disconnect();

            return false;
        }

        public static Boolean SaveMultipleNodeWithSameAttribute(DAL.DataObject.Node nd)
        {
            Int64 ReturnId = 0;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.CommandText = "sp_Save_Multiple_Node_With_Same_Attribute";
            SqlCmd.Parameters.AddWithValue("@Id", nd.Id);
            SqlCmd.Parameters.AddWithValue("@parent_node_id", nd.Parent_Node_Id);
            SqlCmd.Parameters.AddWithValue("@attribute_id", nd.Attribute_id);
            SqlCmd.Parameters.AddWithValue("@user_id", nd.User_id);
            SqlCmd.Parameters.AddWithValue("@user_name", nd.User_Name);
            SqlCmd.Parameters.AddWithValue("@node_value", DAL.Common.GetTextWithBr( nd.Node_value));
            SqlCmd.Parameters.AddWithValue("@Returned_id", ReturnId);

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {

                if (SqlCmd.ExecuteNonQuery() > 0)
                {
                    SqlCmd.Parameters.Clear();
                    nd.Id = ReturnId;
                    SqlCmd.CommandText = "Select max(id)from node";
                    SqlCmd.CommandType = CommandType.Text;
                    nd.Id = DAL.Common.ToInt64(SqlCmd.ExecuteScalar());

                    BDDoctors.DAL.DBConn.Disconnect();
                    return true;
                }

            }
            BDDoctors.DAL.DBConn.Disconnect();

            return false;
        }

        public static Boolean SaveCommentOrImageOrVideo(DAL.DataObject.Node nd)
        {
            Int64 ReturnId = 0;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.CommandText = "sp_Save_Comment_or_Image_Video";
            SqlCmd.Parameters.AddWithValue("@Id", nd.Id);
            SqlCmd.Parameters.AddWithValue("@parent_node_id", nd.Parent_Node_Id);
            SqlCmd.Parameters.AddWithValue("@attribute_id", nd.Attribute_id);
            SqlCmd.Parameters.AddWithValue("@user_id", nd.User_id);
            SqlCmd.Parameters.AddWithValue("@user_name", nd.User_Name);
            SqlCmd.Parameters.AddWithValue("@node_value", DAL.Common.GetTextWithBr( nd.Node_value));
            SqlCmd.Parameters.AddWithValue("@Returned_id", ReturnId);

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {

                if (SqlCmd.ExecuteNonQuery() > 0)
                {
                    SqlCmd.Parameters.Clear();
                    nd.Id = ReturnId;
                    SqlCmd.CommandText = "Select max(id)from node";
                    SqlCmd.CommandType = CommandType.Text;
                    nd.Id = DAL.Common.ToInt64(SqlCmd.ExecuteScalar());

                    BDDoctors.DAL.DBConn.Disconnect();
                    return true;
                }

            }
            BDDoctors.DAL.DBConn.Disconnect();

            return false;
        }

        public static Boolean SaveToFavList(Int64 parent_node_id, Int64 UserId,string feature_name)
        {
            Int64 ReturnId = 0;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.CommandText = "sp_Save_Favourite";
            SqlCmd.Parameters.AddWithValue("@parent_node_id", parent_node_id);
            SqlCmd.Parameters.AddWithValue("@feature_name", feature_name);
            SqlCmd.Parameters.AddWithValue("@user_id", UserId);          

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

        public static Boolean RemoveFromFavList(Int64 parent_node_id, Int64 UserId, string feature_name)
        {
            Int64 ReturnId = 0;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.Text;

            SqlCmd.CommandText = "Delete from favourite where user_id=@user_id AND parent_node_id=@parent_node_id AND feature_name=@feature_name ";
            SqlCmd.Parameters.AddWithValue("@parent_node_id", parent_node_id);
            SqlCmd.Parameters.AddWithValue("@feature_name", feature_name);
            SqlCmd.Parameters.AddWithValue("@user_id", UserId);

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

        public static Boolean UpdateNodes(Int64 parent_node_id,Int64 attribute_id,string node_value)
        {
            Int64 ReturnId = 0;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.CommandText = "sp_Bll_Update_Nodes";
            SqlCmd.Parameters.AddWithValue("@parent_node_id", parent_node_id);
            SqlCmd.Parameters.AddWithValue("@attribute_id", attribute_id);
            SqlCmd.Parameters.AddWithValue("@node_value", DAL.Common.GetTextWithBr( node_value));
           
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

        public static Boolean DeleteNodes(Int64 node_id)
        {
            Int64 ReturnId = 0;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.CommandText = "sp_Bll_Delete_Nodes";
            SqlCmd.Parameters.AddWithValue("@node_id", node_id);
            

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

        #endregion

        #region CommentFiltering
        public static System.Collections.Generic.List<DAL.DataObject.Node> FilterNodeComments(System.Collections.Generic.List<DAL.DataObject.Node> NodeList)
        {
            System.Collections.Generic.IEnumerable<DAL.DataObject.Node> Conversations = from DAL.DataObject.Node nd in NodeList
                                                                                        where nd.Attribute_id == 36 && nd.Node_value!=null // && nd.Node_value != null
                                                                                        select nd;

            return Conversations.ToList<DAL.DataObject.Node>();
        }
        public static System.Collections.Generic.List<DAL.DataObject.Node> FilterNodeImage(System.Collections.Generic.List<DAL.DataObject.Node> NodeList)
        {
            System.Collections.Generic.IEnumerable<DAL.DataObject.Node> Conversations = from DAL.DataObject.Node nd in NodeList
                                                                                        where nd.Attribute_id == 37 // && nd.Node_value != null
                                                                                        select nd;

            return Conversations.ToList<DAL.DataObject.Node>();
        }
        public static System.Collections.Generic.List<DAL.DataObject.Node> FilterNodeVideo(System.Collections.Generic.List<DAL.DataObject.Node> NodeList)
        {
            System.Collections.Generic.IEnumerable<DAL.DataObject.Node> Conversations = from DAL.DataObject.Node nd in NodeList
                                                                                        where nd.Attribute_id == 38 // && nd.Node_value != null
                                                                                        select nd;

            return Conversations.ToList<DAL.DataObject.Node>();
        }

        public static System.Collections.Generic.List<DAL.DataObject.Node> FilterNodeButCommentsAndImageAndVideo(System.Collections.Generic.List<DAL.DataObject.Node> NodeList)
        {
            System.Collections.Generic.IEnumerable<DAL.DataObject.Node> Conversations = from DAL.DataObject.Node nd in NodeList
                                                                                        where nd.Attribute_id != 36 && nd.Attribute_id != 37 && nd.Attribute_id != 38 
                                                                                        select nd;

            return Conversations.ToList<DAL.DataObject.Node>();
        }
        public static System.Collections.Generic.List<DAL.DataObject.Node> FilterNodeButComments(System.Collections.Generic.List<DAL.DataObject.Node> NodeList)
        {
            System.Collections.Generic.IEnumerable<DAL.DataObject.Node> Conversations = from DAL.DataObject.Node nd in NodeList
                                                                                        where nd.Attribute_id != 36
                                                                                        select nd;

            return Conversations.ToList<DAL.DataObject.Node>();
        }
        #endregion


        #region Other
        public static System.Collections.Generic.List<String> GetSourceTextList(Int64 Source_id)
        {
            System.Collections.Generic.List<String> TextList = new System.Collections.Generic.List<string>();
            DataSet ds = GetDataSetOfSource(Source_id);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TextList.Add(Common.ToString(dr["Text"]));
                }
            }
            return TextList;
        }
        public static Nullable<Int64> GetParentIdFromNodeList(System.Collections.Generic.List<DataObject.Node> NodeList)
        {
            System.Collections.Generic.IEnumerable<Nullable<Int64>> Parent_Ids = from DAL.DataObject.Node nd in NodeList
                                                                                 where (nd.Parent_Node_Id != null)
                                                                                 select nd.Parent_Node_Id;
            Nullable<Int64> Parent_id = null;
            if (Parent_Ids != null)
            {
                Parent_id = Parent_Ids.Max();
            }
            return Parent_id;
        }
        public static System.Collections.Generic.List<DataObject.Node> GetParentNode(System.Collections.Generic.List<DataObject.Node> NodeList)
        {
            System.Collections.Generic.IEnumerable<DataObject.Node> Parent_IdEnu = from DAL.DataObject.Node nd in NodeList
                                                                                   where nd.Id!=null &&nd.Parent_Node_Id!=null && nd.Id.Value==nd.Parent_Node_Id
                                                                                   select nd;
            System.Collections.Generic.List<DataObject.Node> temp = Parent_IdEnu.ToList<DAL.DataObject.Node>();
            return  Parent_IdEnu.ToList<DAL.DataObject.Node>();
        }

        #endregion

        #region NotificationRelated
        public static System.Collections.Generic.List<DAL.DataObject.Node> GetPublicBasicInfoChangeNotification(Int64 User_id)
        {
            System.Collections.Generic.List<DAL.DataObject.Node> Nodes = new System.Collections.Generic.List<DAL.DataObject.Node>();
            DataSet ds = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_Get_Public_Info_Notification";

            SqlCmd.Parameters.AddWithValue("@User_Id", User_id);
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
                    Nodes.Add(CreateNodeObject(dr));
                }

            }

            return Nodes;
        }
        public static System.Collections.Generic.List<DAL.DataObject.Node> GetFriendsBasicInfoChangeNotification(Int64 User_id)
        {
            System.Collections.Generic.List<DAL.DataObject.Node> Nodes = new System.Collections.Generic.List<DAL.DataObject.Node>();
            DataSet ds = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_Get_Info_Notification_Of_Friendz";

            SqlCmd.Parameters.AddWithValue("@User_Id", User_id);
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
                    Nodes.Add(CreateNodeObject(dr));
                }

            }

            return Nodes;
        }

            public static System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> GetPublicContentBasedNotification()
            {
                System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListOfNodes = new System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>>();
                DataSet ds = GetDataSetOfPublicContentBasedNotification();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count>0)
                {
                    Int64 key = 0;
                    foreach (DataTable tbl in ds.Tables)
                    {
                        System.Collections.Generic.List<DAL.DataObject.Node> NodeList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();
                        key = key + 1;
                        foreach (DataRow dr in tbl.Rows)
                        {
                            NodeList.Add(CreateNodeObject(dr));
                        }
                        ListOfNodes.Add(NodeList);
                    }
                }

                return ListOfNodes;
            }

            public static System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> GetClubUserFeed(Nullable<Int64> WallOwnerId, Nullable<Int64> MaxId)
            {
                System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListOfNodes = new System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>>();
                DataSet ds = GetDataSetForClubUserFeed(WallOwnerId, MaxId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Int64 key = 0;
                    foreach (DataTable tbl in ds.Tables)
                    {
                        System.Collections.Generic.List<DAL.DataObject.Node> NodeList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();
                        key = key + 1;
                        foreach (DataRow dr in tbl.Rows)
                        {
                            NodeList.Add(CreateNodeObject(dr));
                        }
                        ListOfNodes.Add(NodeList);
                    }
                }

                return ListOfNodes;
            }
            public static System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> GetClubFriendsFeed(Nullable<Int64> WhoseFriends, Nullable<Int64> MaxId)
            {
                System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListOfNodes = new System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>>();
                DataSet ds = GetDataSetForClubFriendsFeed(WhoseFriends, MaxId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Int64 key = 0;
                    foreach (DataTable tbl in ds.Tables)
                    {
                        System.Collections.Generic.List<DAL.DataObject.Node> NodeList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();
                        key = key + 1;
                        foreach (DataRow dr in tbl.Rows)
                        {
                            NodeList.Add(CreateNodeObject(dr));
                        }
                        ListOfNodes.Add(NodeList);
                    }
                }

                return ListOfNodes;
            }

            public static System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> GetClubPublicFeed( Nullable<Int64> MaxId)
            {
                System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListOfNodes = new System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>>();
                DataSet ds = GetDataSetForPublicFeed(MaxId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Int64 key = 0;
                    foreach (DataTable tbl in ds.Tables)
                    {
                        System.Collections.Generic.List<DAL.DataObject.Node> NodeList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();
                        key = key + 1;
                        foreach (DataRow dr in tbl.Rows)
                        {
                            NodeList.Add(CreateNodeObject(dr));
                        }
                        ListOfNodes.Add(NodeList);
                    }
                }

                return ListOfNodes;
            }

            public static System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> GetBlogList()
            {
                System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListOfNodes = new System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>>();
                DataSet ds = GetDataSetOfBlogList();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Int64 key = 0;
                    foreach (DataTable tbl in ds.Tables)
                    {
                        System.Collections.Generic.List<DAL.DataObject.Node> NodeList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();
                        key = key + 1;
                        foreach (DataRow dr in tbl.Rows)
                        {
                            NodeList.Add(CreateNodeObject(dr));
                        }
                        ListOfNodes.Add(NodeList);
                    }
                }

                return ListOfNodes;
            }
            public static System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> GetBlogListByCategory(string Category)
            {
                System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListOfNodes = new System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>>();
                DataSet ds = GetDataSetOfBlogListByCategory(Category);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Int64 key = 0;
                    foreach (DataTable tbl in ds.Tables)
                    {
                        System.Collections.Generic.List<DAL.DataObject.Node> NodeList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();
                        key = key + 1;
                        foreach (DataRow dr in tbl.Rows)
                        {
                            NodeList.Add(CreateNodeObject(dr));
                        }
                        ListOfNodes.Add(NodeList);
                    }
                }

                return ListOfNodes;
            }
            public static System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> GetMyFavouriteFeeds( Int64 userId)
            {
                System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListOfNodes = new System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>>();
                DataSet ds = GetDatasetOfMyFavourite( userId);
                if (ds != null && ds.Tables.Count > 0&& ds.Tables[0].Rows.Count>0)
                {
                    Int64 key = 0;
                    foreach (DataTable tbl in ds.Tables)
                    {
                        System.Collections.Generic.List<DAL.DataObject.Node> NodeList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();
                        key = key + 1;
                        foreach (DataRow dr in tbl.Rows)
                        {
                            NodeList.Add(CreateNodeObject(dr));
                        }
                        ListOfNodes.Add(NodeList);
                    }
                }

                return ListOfNodes;
            }
           
        
        
        
        public static System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> GetFriendzContentBasedNotification( Int64 UserId)
            {
                System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListOfNodes = new System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>>();
                DataSet ds = GetDataSetOfFriendsContentBasedNotification( UserId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Int64 key = 0;
                    foreach (DataTable tbl in ds.Tables)
                    {
                        System.Collections.Generic.List<DAL.DataObject.Node> NodeList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();
                        key = key + 1;
                        foreach (DataRow dr in tbl.Rows)
                        {
                            NodeList.Add(CreateNodeObject(dr));
                        }
                        ListOfNodes.Add(NodeList);
                    }
                }

                return ListOfNodes;
            }

        #endregion


    }
}
