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
    public class RoomChatter:DAL.DataObject.User
    {
        private Nullable<Int64> m_CurrentRoom = null;
        private String m_Avatar = String.Empty;
        private String m_BackGroundPosition = String.Empty;
        private String m_Left = "2px";
        private String m_Top ="2px";
        private DateTime m_RefreshTime = DateTime.Now;
        private string m_Message = string.Empty;
        private DateTime m_SentTime = DateTime.Now;
        
        public string Avatar
        {
            set
            {
                m_Avatar = value;
            }
            get
            {
                return m_Avatar;
            }
        }
        public string BackGroundPosition
        {
            set
            {
                m_BackGroundPosition = value;
            }
            get
            {
                return m_BackGroundPosition;
            }
        }
        public string Left
        {
            set
            {
                m_Left = value;
            }
            get
            {
                return m_Left;
            }
        }
        public string Top
        {
            set
            {
                m_Top = value;
            }
            get
            {
                return m_Top;
            }
        }
        public Nullable<Int64> CurrentRoom
        {
            set
            {
                m_CurrentRoom = value;
            }
            get
            {
                return m_CurrentRoom;
            }
        }
        public DateTime RefreshTime
        {
            get {
                return m_RefreshTime;
            }
            set { m_RefreshTime = value; }
        }
        public string Message
        {
            get { return m_Message; }
            set { m_Message = value; }
        }
        public DateTime SentTime {
            get { return m_SentTime; }
            set { m_SentTime = value; }
        }

        
        
       
    }
}
