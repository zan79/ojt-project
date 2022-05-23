using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using OJTProject.Core;

namespace OJTProject.Dal
{
    public class Products
    {
        public virtual int Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual string Status { get; set; }
        public virtual DateTime ExpiryDate { get; set; }
        public virtual decimal Price { get; set; }
        public virtual double QtyInstock { get; set; }
        public virtual double QtySold { get; set; }
        public virtual int AddedBy { get; set; }
        public virtual DateTime AddedOn { get; set; }
        public virtual string Category { get; set; }

        private static string ConnectionString()
        {
            return PublicVariables.ConnectionString;
        }

        /*START YOUR CODE AFTER THIS LINE*/
        public static bool GetIsSuccessfull = false;
        public static string GetErrorMessage = string.Empty;
        public static DataTable Get()
        {
            DataSet dt = new DataSet();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_products_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    con.Close();
                    GetIsSuccessfull = true;
                    GetErrorMessage = string.Empty;
                    return dt.Tables[0];
                }
            }
            catch (Exception ex)
            {
                GetIsSuccessfull = false;
                GetErrorMessage = ex.Message + "\nFunction : Get";
                return null;
            }
        }

        public static string AddErrorMessage = string.Empty;
        public static bool AddIsSuccessfull = false;
        public static void Add(string Code, string Name)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_products_insert", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_code", Code));
                    cmd.Parameters.Add(new MySqlParameter("_name", Name));
                    int temp = cmd.ExecuteNonQuery();
                    con.Close();
                    AddIsSuccessfull = true; AddErrorMessage = string.Empty;
                }
            }
            catch (Exception ex)
            {
                AddIsSuccessfull = false;
                AddErrorMessage = ex.Message + "\nFunction : Add";
            }
        }

        public static bool EditProductsIsSuccessfull = false;
        public static string EditProductsErrorMessage = string.Empty;
        public static void EditProducts(string Code, string Name, int Id)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_products_edit_products", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_code", Code));
                    cmd.Parameters.Add(new MySqlParameter("_name", Name));
                    cmd.Parameters.Add(new MySqlParameter("_id", Id));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    EditProductsIsSuccessfull = true;
                    EditProductsErrorMessage = string.Empty;
                }
            }
            catch (Exception ex) { EditProductsIsSuccessfull = false; EditProductsErrorMessage = ex.Message + "\nFunction : EditProducts"; }
        }

        public static bool DeleteIsSuccessfull = false;
        public static string DeleteErrorMessage = string.Empty;
        public static void Delete(int Id)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_products_delete", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_id", Id));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DeleteIsSuccessfull = true;
                    DeleteErrorMessage = string.Empty;
                }
            }
            catch (Exception ex) { DeleteIsSuccessfull = false; DeleteErrorMessage = ex.Message + "\nFunction : Delete"; }
        }

    }
}