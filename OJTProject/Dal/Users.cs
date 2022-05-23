using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using OJTProject.Core;

namespace OJTProject.Dal
{
    public class Users
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Fullname { get; set; }
        public virtual DateTime LastLogin { get; set; }

        private static string ConnectionString()
        {
            return PublicVariables.ConnectionString;
        }

        /*START YOUR CODE AFTER THIS LINE*/
        public static bool LoginIsSuccessfull = false;
        public static string LoginErrorMessage = string.Empty;
        public static DataTable Login(string Username, string Password)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_users_login", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_username", Username));
                    cmd.Parameters.Add(new MySqlParameter("_password", Password));
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adp.Fill(table);
                    con.Close();
                    LoginIsSuccessfull = true;
                    LoginErrorMessage = string.Empty;
                    return table;
                }
            }
            catch (Exception ex)
            {
                LoginIsSuccessfull = false;
                LoginErrorMessage = ex.Message + "\nFunction : GetCount";
                return null;
            }
        }

    }
}