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
    public class FriendShip
    {
        private Nullable<Int64> m_User1 = null;
        private Nullable<Int64> m_User2 = null;
        private Nullable<Int64> m_Status = null;
        private DateTime m_Action_date = DateTime.Now;


        public Nullable<Int64> User1
        {
            set
            {
                m_User1 = value;
            }
            get
            {
                return m_User1;
            }
        }
        public Nullable<Int64> User2
        {
            set
            {
                m_User2 = value;
            }
            get
            {
                return m_User2;
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
