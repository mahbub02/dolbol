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
    public class Speech

    {
        private Nullable<Int64> m_User1Id = null;
        private Nullable<Int64> m_User2Id = null;

        private String m_User1DisplayName = String.Empty;
        private String m_User2DisplayName = String.Empty;
        private String m_Message = null;
        private Int32 m_WindowStatus = 1;
        private Int32 m_IsDelivered = 0;
        private DateTime m_LastModifiedDate = DateTime.Now;

        public Nullable<Int64> User1Id
        {
            set
            {
                m_User1Id = value;
            }
            get
            {
                return m_User1Id;
            }
        }

        public Nullable<Int64> User2Id
        {
            set
            {
                m_User2Id = value;
            }
            get
            {
                return m_User2Id;
            }
        }
        public string User1DisplayName
        {
            set{
                m_User1DisplayName = value;
            }
            get{
                return m_User1DisplayName;
            }
        }

        public string User2DisplayName
        {
            set
            {
                m_User2DisplayName = value;
            }
            get
            {
                return m_User2DisplayName;
            }
        }

        public String Message
        {
            set{
                m_Message = value;
            }
            get{
                return m_Message;
            }
        }
        public Int32 WindowStatus
        {
            get { return m_WindowStatus; }
            set { m_WindowStatus = value; }
        }
        public Int32 IsDelivered
        {
            get { return m_IsDelivered; }
            set { m_IsDelivered = value; }
        }
        public DateTime LastModifiedDate {
            get {
                return m_LastModifiedDate;
            }
            set {
                 m_LastModifiedDate=value;
            }
        }



        //int IComparable<Conversation>.CompareTo(Conversation other)
        //{
            
        //    if (other.Id.Value > this.Id.Value)
        //        return -1;
        //    else if (other.Id.Value == this.Id.Value)
        //        return 0;
        //    else
        //        return 1;
        //}

        
    }
}
