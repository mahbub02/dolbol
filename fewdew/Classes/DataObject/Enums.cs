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


    public enum JagPlaceLevel
    {
        WorldHomeManage  = 0,
        WorldPlace = 1,
        Building = 2,
        Home = 3,
        Room = 4
    }
    public enum japPlaceAccessLevel
    {
        Everyone = 1,
        FriendLevel = 2
        
    }


}
