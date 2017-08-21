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
    public class Friend
    {
        private Nullable<Int64> m_UserId = null;
        private String m_Display_Name = string.Empty;
        private Nullable<Int64> m_Status = null;
        private DateTime m_Action_date = DateTime.Now;



        public Nullable<Int64> UserId
        {
            set
            {
                m_UserId = value;
            }
            get
            {
                return m_UserId;
            }
        }
        public String DisplayName
        {
            set
            {
                m_Display_Name = value;
            }
            get
            {
                return m_Display_Name;
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
     
        public DateTime ActionDate
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
    }
}
