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
using System.Data.Sql;
using System.Data.SqlClient;


namespace BDDoctors.DAL.DataObject
{
    public class Node
    {
        private Nullable<Int64> m_id = null;
        private Nullable<Int64> m_Parent_Node_id = null;
        //private String m_feature_Name = String.Empty;
        private Nullable<Int64> m_Attribute_id = null;
        //private String m_Attribute_name = String.Empty;
        //private String m_Control_Type= null;
        private Nullable<Int64> m_User_id = null;
        private string m_User_Name = string.Empty;
        private Nullable<Int64> m_WallOwnerId = null;
        private string m_WallOwnerName = string.Empty;
        private String m_Node_value = String.Empty;
        private Nullable<DateTime> m_Action_date = null;
        private Nullable<Boolean> m_Created_Or_Updated = false;
        //private Nullable<Int32> m_Source_id = null;

        public Nullable<Int64> Id{
            set{m_id = value;
            }
            get {return m_id;
            }
        }
        public Nullable<Int64> Parent_Node_Id{
            set{
                m_Parent_Node_id = value;
            }
            get{
                return m_Parent_Node_id;
            }
        }

        //public string feature_Name
        //{
        //    set{
        //        m_feature_Name = value;
        //    }
        //    get{
        //        return m_feature_Name;
        //    }
        //}
        //public string Attribute_Name
        //{
        //    set
        //    {
        //        m_Attribute_name = value;
        //    }
        //    get
        //    {
        //        return m_Attribute_name;
        //    }
        //}
        public Nullable<Int64> Attribute_id
        {
            set{
                m_Attribute_id = value;
            }
            get{
                return m_Attribute_id;
            }
        }
        //public String Control_Type
        //{
        //    set{
        //        m_Control_Type = value;
        //    }
        //    get{
        //        return m_Control_Type;
        //    }
        //}


        public Nullable<Int64> User_id
        {
            set{
                m_User_id = value;
            }
            get{
                return m_User_id;
            }
        }
        public Nullable<Int64> Wall_Owner_id
        {
            set
            {
                m_WallOwnerId = value;
            }
            get
            {
                return m_WallOwnerId;
            }
        }
        public String User_Name
        {
            set
            {
                m_User_Name = value;
            }
            get
            {
                return m_User_Name;
            }
        }
        public String Wall_Owner_Name
        {
            set
            {
                m_WallOwnerName = value;
            }
            get
            {
                return m_WallOwnerName;
            }
        }
        public String Node_value
        {
            set{
                m_Node_value = value;
            }
            get{
                return m_Node_value;
            }
        }
        public Nullable< DateTime> Action_date
        {
            set{
                m_Action_date = value;
            }
            get{
                return m_Action_date;
            }
        }

        public Nullable<Boolean> Created_Or_Updated
        {
            set{
                m_Created_Or_Updated = value;
            }
            get{
                return m_Created_Or_Updated;
            }
        }

        //public Nullable<Int32> Source_id
        //{
        //    set{
        //        m_Source_id = value;
        //    }
        //    get{
        //        return m_Source_id;
        //    }
        //}
        
    }
}
