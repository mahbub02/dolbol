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
using BDDoctors.DAL;

namespace BDDoctors.Controls
{
    public class ControlBase : System.Web.UI.UserControl
    {
        private BDDoctors.Type.DisplayMood m_DisplayMood = BDDoctors.Type.DisplayMood.Display;
        public BDDoctors.Type.DisplayMood DisplayMood
        {
            get
            {
                return m_DisplayMood;
            }
            set
            {
                m_DisplayMood = value;
               
            }
        }
    
        public Nullable<Int64> Node_Id
        {
            get
            {
               // return m_Id;
               return  Common.ToInt64(ViewState["node_id"]);
            }
            set
            {
               ViewState["node_id"] = value;
            }
        }

        public Nullable<Int64> Parent_node_Id
        {
            get
            {
                return Common.ToInt64(ViewState["parent_node_id"]);
            }
            set
            {
               ViewState["parent_node_id"] = value;
            }
        }

        public Nullable<Int64> Attribute_Id
        {
            get
            {
                return Common.ToInt64(ViewState["attribute_id"]);
            }
            set
            {
               ViewState["attribute_id"]= value;
            }
        }

        public String Attribute_Name
        {
            get
            {
                return Common.ToString(ViewState["Attribute_Name"]);
            }
            set
            {
                ViewState["Attribute_Name"] = value;
            }
        }
        public String Node_Value
        {
            get
            {
                return Common.ToString(ViewState["Node_Value"]);
            }
            set
            {
                ViewState["Node_Value"] = value;
            }
        }
  

        public DAL.DataObject.Node Node
        {
            get {
                DAL.DataObject.Node m_node = new DAL.DataObject.Node();
                m_node.Id = this.Node_Id;
                m_node.Parent_Node_Id = this.Parent_node_Id;
                m_node.Attribute_id = this.Attribute_Id;
                m_node.Node_value = this.Node_Value;
                m_node.Attribute_Name = this.Attribute_Name;
                return m_node;
            }
            set {

                this.Node_Id = value.Id;
                this.Parent_node_Id = value.Parent_Node_Id;
                this.Attribute_Id = value.Attribute_id;
                this.Node_Value = value.Node_value;
                this.Attribute_Name = value.Attribute_Name;
            }
        }
    }
}
