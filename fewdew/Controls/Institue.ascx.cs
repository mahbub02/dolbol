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
    public partial class Institue : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UIhelper.PopulateDropDownClassYear(ddlYear, null);
        }

        protected void imgBtnRemove_Click(object sender, ImageClickEventArgs e)
        {
            RemoveOne();
        }

        private void RemoveOne()
        {
            throw new NotImplementedException();
        }

       
        
    }
}