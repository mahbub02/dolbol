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
using BDDoctors.DAL;
using System.Data.Sql;
using System.Data.SqlClient;
namespace BDDoctors
{
    public partial class Tester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnScaler_Click(object sender, EventArgs e)
        {
            if (LoginHandler.LoggedInUser().Id.Value != 1)
            {
                return;
            }
            
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = txtScaler.Text;
            
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (SqlCmd.Connection.State == ConnectionState.Open)
            {
                Int32 count = SqlCmd.ExecuteNonQuery();
                
                 lblscaler.Text = count.ToString();   
                 
            }
            SqlCmd.Connection.Close();
          
        }

        protected void btnReader_Click(object sender, EventArgs e)
        {
            if (LoginHandler.LoggedInUser().Id.Value != 1)
            {
                return;
            }

            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = txtReader.Text;
           

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
           
            if (SqlCmd.Connection.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                SqlCmd.Connection.Close();

                DataList1.DataSource = dset;
                DataList1.DataBind();
            }
            
        }
    }
}
