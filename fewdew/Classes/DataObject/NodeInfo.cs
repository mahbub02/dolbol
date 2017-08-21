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
    public class NodeInfo
    {
        private Nullable<Int64> m_id = null;
        private Nullable<Int64> m_NodeId = null;   
        private Nullable<Int64> m_User_id = null;
        private string m_Info = string.Empty;
        

        public Nullable<Int64> Id{
            set{m_id = value;
            }
            get {return m_id;
            }
        }
        public Nullable<Int64> NodeId{
            set{
                m_NodeId = value;
            }
            get{
                return m_NodeId;
            }
        }

       

        public Nullable<Int64> User_id
        {
            set{
                m_User_id = value;
            }
            get{
                return m_User_id;
            }
        }
        public String Info
        {
            set
            {
                m_Info = value;
            }
            get
            {
                return m_Info;
            }
        }
                
    }
}
