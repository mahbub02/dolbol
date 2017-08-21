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
    public class User
    {
        private Nullable<Int64> m_id = null;
        private String m_DisplayName= String.Empty;
        private String m_Email = String.Empty;
        private String m_Password = String.Empty;
        private String m_ActivationKey = String.Empty;
        private Nullable< Int32> m_Status= null;
        private String m_AvatarName = String.Empty;
        private DateTime m_LastRefreshTime = DateTime.Now;
        private bool m_Sex = true;
        private Nullable<DateTime> m_Birthday = DateTime.Now;
       
        public Nullable<Int64> Id
        {
            set
            {
                m_id = value;
            }
            get
            {
                return m_id;
            }
        }
        public string Password
        {
            set
            {
                m_Password = value;
            }
            get
            {
                return m_Password;
            }
        }
        public string Email
        {
            set
            {
                m_Email = value;
            }
            get
            {
                return m_Email;
            }
        }
        public Nullable< Int32> Status
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
        public string ActivationKey
        {
            set
            {
                m_ActivationKey = value;
            }
            get
            {
                return m_ActivationKey;
            }
        }
        public string DisplayName
        {
            set
            {
                m_DisplayName = value;
            }
            get
            {
                return m_DisplayName;
            }
        }
        public string AvatarName
        {
            set
            {
                m_AvatarName = value;
            }
            get
            {
                return m_AvatarName;
            }
        }
        public DateTime LastRefreshTime
        {
            set
            {
                m_LastRefreshTime = value;
            }
            get
            {
                return m_LastRefreshTime;
            }
        }
        public bool Sex
        {
            set
            {
                m_Sex = value;
            }
            get
            {
                return m_Sex;
            }
        }
        public Nullable<DateTime> BirthDay 
        {
            set {
                m_Birthday = value;
            }
            get {
              return m_Birthday;
            }
        }
        
       
        
    }
}
