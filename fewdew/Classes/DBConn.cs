using System;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace BDDoctors.DAL
{
    public class DBConn
    {

        private static string ConnectionString = "";

        public static SqlConnection Con = null;

        public static SqlConnection Connect()
        {
            try
            {
                if (Con == null || Con.State != ConnectionState.Open)
                {
                    Con = new SqlConnection(ConnectionString);
                    Con.Open();
                }
                return Con;
            }
            catch(Exception ex)
            {
                return Con;  
            }

            return Con;
        }

        public static Boolean Disconnect()
        {
            try
            {

                if (Con != null || Con.State == ConnectionState.Open)
                    Con.Close();
                return true;
                //return "";
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
