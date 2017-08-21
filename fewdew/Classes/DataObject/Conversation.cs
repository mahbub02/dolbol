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
    public class Conversation:IComparable<Conversation>

    {
        private Nullable<Int64> m_Id = null;
        private String m_Sender_Name = String.Empty;
        private Nullable<Int64> m_Sender_id = null;
        private String m_Reciever_name = String.Empty;
        private Nullable<Int64> m_Reciever_id = null;
        private string m_Message= string.Empty;
        private Nullable<DateTime> m_Action_date = DateTime.Now;
        private Nullable<Boolean> m_IsDelivered = false;
        private Nullable<Int64> m_Room_id = null;

        public Nullable<Int64> Id{
            set
            {
                m_Id = value;
            }
            get
            {
                return m_Id;
            }
        }

        public Nullable<Int64> Sender_id
        {
            set
            {
                m_Sender_id = value;
            }
            get
            {
                return m_Sender_id;
            }
        }
        public string Sender_Name
        {
            set{
                m_Sender_Name = value;
            }
            get{
                return m_Sender_Name;
            }
        }
        public Nullable<Int64> Reciever_id
        {
            set
            {
                m_Reciever_id = value;
            }
            get
            {
                return m_Reciever_id;
            }
        }
        public string Reciever_name
        {
            set
            {
                m_Reciever_name = value;
            }
            get
            {
                return m_Reciever_name;
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


       
        
       
        public Nullable< DateTime> Action_date
        {
            set{
                m_Action_date = value;
            }
            get{
                return m_Action_date;
            }
        }

        public Nullable<Boolean> IsDelivered
        {
            set{
                m_IsDelivered = value;
            }
            get{
                return m_IsDelivered;
            }
        }

        public Nullable<Int64> Room_id
        {
            set{
                m_Room_id = value;
            }
            get{
                return m_Room_id;
            }
        }
        int IComparable<Conversation>.CompareTo(Conversation other)
        {
            
            if (other.Id.Value > this.Id.Value)
                return -1;
            else if (other.Id.Value == this.Id.Value)
                return 0;
            else
                return 1;
        }

        
    }
}
