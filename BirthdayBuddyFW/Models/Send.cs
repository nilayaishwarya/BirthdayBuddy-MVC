using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BirthdayBuddyFW.Models
{
    public class Send
    {
        public bool ValidateUser(Login rc)
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
                SqlCommand cmd = new SqlCommand("Select count(UserName) from UserProfile where UserName='" + rc.UserName + "' AND password = '" + rc.Password + "'", con);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            return count > 0;
        }

        public int ValidateUserLevel(Login rc)
        {
            int level = 0;

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
                SqlCommand cmd = new SqlCommand("Select LoginLevel from UserProfile where UserName='" + rc.UserName + "' AND password = '" + rc.Password + "'", con);
                level = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            return level;
        }

    }
}