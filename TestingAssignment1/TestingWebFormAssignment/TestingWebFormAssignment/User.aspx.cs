using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace TestingWebFormAssignment
{
    public partial class User : System.Web.UI.Page
    {
        int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                {
                    generateautonumber();
                }
            }
        }
            private void generateautonumber()
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand("proc_AutoGenNumber", con);
                cmd.CommandType = CommandType.StoredProcedure;
                string value = cmd.ExecuteScalar().ToString();
                i++;
                int rv = Int32.Parse(value) + 1;
                lblrecordid.Text = rv.ToString();

            }
            protected void btn_autogeneratenumber_Click(object sender, EventArgs e)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand("proc_InsertAutoGenNumber", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@passengerNumber", SqlDbType.VarChar).Value = lblpassengerNumber.Text;
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = txtFirstname.Text;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    lblerror.Text = "Record Inserted Successfully...";
                }
                else
                {
                    lblerror.Text = "Error in Record Inserting...";
                }
                con.Close();
            }
        }

    }
}
    

