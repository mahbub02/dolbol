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
    public class OnlineUser
    {
        private Nullable<Int64> m_id = null;
        private String m_DisplayName= String.Empty;
        private String m_StatusMessage = String.Empty;
        private DateTime m_LastRefreshTime = DateTime.Now;

       
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
        public string StatusMessage
        {
            set
            {
                m_StatusMessage = value;
            }
            get
            {
                return m_StatusMessage;
            }
        }
        public DateTime LastRefreshTime
        {
            set {
                m_LastRefreshTime = value;
            }
            get {
                return m_LastRefreshTime; 
            }
        }
       
        
    }
}
