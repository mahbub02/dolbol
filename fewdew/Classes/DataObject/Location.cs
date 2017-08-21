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

namespace BDDoctors.Classes.DataObject
{
    public class Location
    {
        private Nullable<Int64> m_Id = null;
        private Nullable<Int64> m_Parent_Id = null;
        private string m_Name = string.Empty;
        private string m_Description = string.Empty;
        private Nullable<Int64> m_OwnerId = null;
        private string m_OwnerName = string.Empty;
        private Nullable<Int64> m_RenterId = null;
        private string m_RenterName = string.Empty;
        private Nullable<Int64> m_AccessType = null;
        private Nullable<Int64> m_Level = null;
        private Nullable<Int64> m_Left = null;
        private Nullable<Int64> m_Top = null;
        private Nullable<Int64> m_Width = null;
        private Nullable<Int64> m_Height = null;





        public Nullable<Int64> Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }
        public Nullable<Int64> Parent_Id
        {
            get { return m_Parent_Id; }
            set { m_Parent_Id = value; }
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

        public Nullable<Int64> OwnerId
        {
            get { return m_OwnerId; }
            set { m_OwnerId = value; }
        }
        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }
        public Nullable<Int64> RenterId
        {
            get { return m_RenterId; }
            set { m_RenterId = value; }
        }
        public string RenterName
        {
            get { return m_RenterName; }
            set { m_RenterName = value; }
        }
        public Nullable<Int64> AccessType
        {
            get { return m_AccessType; }
            set { m_AccessType = value; }
        }
        public Nullable<Int64> Level
        {
            get { return m_Level; }
            set { m_Level = value; }
        }

        public Nullable<Int64> Left
        {
            get { return m_Left; }
            set { m_Left = value; }
        }
        public Nullable<Int64> Top
        {
            get { return m_Top; }
            set { m_Top = value; }
        }

        public Nullable<Int64> Height
        {
            get { return m_Height; }
            set { m_Height = value; }
        }
        public Nullable<Int64> width
        {
            get { return m_Width; }
            set { m_Width = value; }
        }
    }

}
