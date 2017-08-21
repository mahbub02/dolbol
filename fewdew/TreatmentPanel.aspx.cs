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
using System.Data.Sql;
using System.Data.SqlClient;
namespace BDDoctors
{
    public partial class TreatmentPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                BindRecentPosts();
            }
        }
       
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim().Length > 0)
            {
                BindSearchResult();
            }
            else {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        private void BindSearchResult()
        {
            string tempQ = string.Empty;
          
                string[] queries = txtSearch.Text.Split(' ');

                tempQ = "SELECT TOP 50 * FROM NODE WHERE (";
                for (int i = 0; i < queries.Length; i++)
                {
                    tempQ = tempQ + "node_value like N'%" + queries[i].Trim() + "%'";
                    if (i != queries.Length - 1)
                    {
                        tempQ = tempQ + " OR ";
                    }
                }
                tempQ = tempQ + ") AND attribute_id=46";
           
            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = tempQ;

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                BDDoctors.DAL.DBConn.Disconnect();
            }
            //if (dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
            //{
                GridView1.DataSource = dset;
                GridView1.DataBind();
            //}

            //return dset;

        }

        protected void btnRecentPost_Click(object sender, EventArgs e)
        {
            BindRecentPosts();
        }
        private void BindRecentPosts()
        {
            string tempQ = string.Empty;

            string[] queries = txtSearch.Text.Split(' ');

            tempQ = "SELECT TOP 40 * FROM NODE WHERE attribute_id=46 ORDER BY Action_date DESC";
           

            DataSet dset = new DataSet();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = BDDoctors.DAL.DBConn.Connect();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = tempQ;

            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            if (BDDoctors.DAL.DBConn.Con.State == ConnectionState.Open)
            {
                SqlDa.Fill(dset);
                BDDoctors.DAL.DBConn.Disconnect();
            }
            //if (dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
            //{
            GridView1.DataSource = dset;
            GridView1.DataBind();
            //}

            //return dset;

        }
    }
}
