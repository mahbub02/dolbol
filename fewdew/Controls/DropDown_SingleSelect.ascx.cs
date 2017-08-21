using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace BDDoctors.Controls
{
    public partial class DropDown_SingleSelect : BDDoctors.Controls.ControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblPropertyName.Text = this.Node.Attribute_Name.ToString();
            //switch ((BDDoctors.Type.DisplayMood)this.DisplayMood)
            //{
            //    case BDDoctors.Type.DisplayMood.Display:
            //        lblPropertyValue.Text = Node.Node_value.ToString();
            //        DropDownList1.Visible = false;
            //        break;
            //    case BDDoctors.Type.DisplayMood.Edit:
            //        BDDoctors.UIhelper.PopulateDropDown(DropDownList1, 1);
            //        DropDownList1.Visible = true;
            //        break;
            //}
           
           
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

      
    }
}