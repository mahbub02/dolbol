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
    public class ClubPlace
    {
        private Nullable<Int64> m_Id = null;
        private Nullable<Int64> m_club_id = null;
        private string m_Name = string.Empty;
        private string m_Description = string.Empty;
        private System.Collections.Generic.List<string> m_Xs = null;
        private System.Collections.Generic.List<string> m_Ys = null;
        private Nullable<Int64> m_link_to = null;
  
        public Nullable<Int64> Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }
        public Nullable<Int64> clubId
        {
            get { return m_club_id; }
            set { m_club_id = value; }
        }
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }


        public System.Collections.Generic.List<string>  Xs
        {
            get { return m_Xs; }
            set { m_Xs = value; }
        }

        public System.Collections.Generic.List<string> Ys
        {
            get { return m_Ys; }
            set { m_Ys = value; }
        }
        public Nullable<Int64> LinkTo
        {
            get { return m_link_to; }
            set { m_link_to = value; }
        }
       

       
    }

}
