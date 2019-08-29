using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BirthdayBuddyFW.Models
{
    public class Request
    {
        public bool ValidateUser(Register rc)
        {
            int count = 0;

            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString =
            //"Data Source=ServerName;" +
            //"Initial Catalog=DataBaseName;" +
            //"Integrated Security=SSPI;";
            //conn.Open();


            string strConString = "Data Source=INBENNAISHWARYA\\SQLEXPRESS;  Initial Catalog=BirthDayBuddy;Integrated Security=SSPI";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select count(UserName) from UserProfile where UserName='" + rc.UserName + "'", con);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            return count > 0;
        }

        public bool Register(Register rc)
        {
            string strConString = "Data Source=INBENNAISHWARYA\\SQLEXPRESS;  Initial Catalog=BirthDayBuddy;Integrated Security=SSPI";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Insert into UserProfile (UserName, Password, IsActive, LoginLevel) values(@username , @password, @isactive, @loginlevel)";
                SqlCommand cmd = new SqlCommand(query, con);
                // cmd.Parameters.AddWithValue("@userId", rc.UserId);
                cmd.Parameters.AddWithValue("@username", rc.UserName);
                cmd.Parameters.AddWithValue("@password", rc.Password);
                cmd.Parameters.AddWithValue("@isactive", 1);
                cmd.Parameters.AddWithValue("@loginlevel", 0);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
        }
    }
}