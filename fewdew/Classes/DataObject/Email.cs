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

namespace BDDoctors.DAL.DataObject
{
    public class Email
    {
        private Nullable<Int64> m_Id = null;
        private Nullable<Int64> m_Parent_Id = null;
        private Nullable<Int64> m_Sender_Id = null;
        private String m_Sender_Name = string.Empty;
        private Nullable<Int64> m_Reciever_Id = null;
        private String m_Reciever_Name = string.Empty;
        private String m_Subject = string.Empty;
        private String m_Message = string.Empty;
        private Nullable<Int64> m_Status = 0;
        private Nullable< DateTime>m_Action_date = DateTime.Now;
        private Nullable<Int64> m_User_Id1 = null;
        private String m_Folder_Name1 = string.Empty;
        private Nullable<Int64> m_User_Id2 = null;
        private String m_Folder_Name2 = string.Empty;


        public Nullable<Int64> Id
        {
            set
            {
                m_Id = value;
            }
            get
            {
                return m_Id;
            }
        }
        public Nullable<Int64> Parent_Id
        {
            set
            {
                m_Parent_Id = value;
            }
            get
            {
                return m_Parent_Id;
            }
        }
        public Nullable<Int64> Sender_Id
        {
            set
            {
                m_Sender_Id = value;
            }
            get
            {
                return m_Sender_Id;
            }
        }
        public String Sender_Name
        {
            set
            {
                m_Sender_Name = value;
            }
            get
            {
                return m_Sender_Name;
            }
        }
        public Nullable<Int64> Reciever_Id
        {
            set
            {
                m_Reciever_Id = value;
            }
            get
            {
                return m_Reciever_Id;
            }
        }
        public String Reciever_Name
        {
            set
            {
                m_Reciever_Name = value;
            }
            get
            {
                return m_Reciever_Name;
            }
        }
        public String Subject
        {
            set
            {
                m_Subject = value;
            }
            get
            {
                return m_Subject;
            }
        }
        public String Message
        {
            set
            {
                m_Message = value;
            }
            get
            {
                return m_Message;
            }
        }
        public Nullable<Int64> Status
        {
            set
            {
                m_Status = value;
            }
            get
            {
                return m_Status;
            }
        }
        public Nullable<DateTime> ActionDate
        {
            set
            {
                m_Action_date = value;
            }
            get
            {
                return m_Action_date;
            }
        }
        public Nullable<Int64> User_Id1
        {
            set
            {
                m_User_Id1 = value;
            }
            get
            {
                return m_User_Id1;
            }
        }
        public String Folder_Name1
        {
            set
            {
                m_Folder_Name1 = value;
            }
            get
            {
                return m_Folder_Name1;
            }
        }
        public Nullable<Int64> User_Id2
        {
            set
            {
                m_User_Id2 = value;
            }
            get
            {
                return m_User_Id2;
            }
        }
        public String Folder_Name2
        {
            set
            {
                m_Folder_Name2 = value;
            }
            get
            {
                return m_Folder_Name2;
            }
        }
    }
}
