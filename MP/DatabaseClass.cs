using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace MP
{
    public class DatabaseClass
    {
        MySqlConnection dbconnect;
        MySqlCommand dbcommand;
        MySqlDataReader dbreader;
        MySqlDataAdapter dbadapter;
        DataTable datatable;

        string connectionstring = "server=localhost;database=hotel_db;user id=root;Password=";

        public string password_encryptor(string command)
        {
            dbconnect = new MySqlConnection(connectionstring);
            dbconnect.Open();
            dbcommand = new MySqlCommand(command, dbconnect);
            string encrypted_pw = dbcommand.ExecuteScalar().ToString();
            dbconnect.Close();

            return encrypted_pw;
        }
        public MySqlDataReader user_sign_in(string command)
        {

            dbconnect = new MySqlConnection(connectionstring);
            dbconnect.Open();
            dbcommand = new MySqlCommand(command, dbconnect);
            dbreader = dbcommand.ExecuteReader();

            return dbreader;
        }
        public string GetFirstName(string email)
        {
            string firstName = string.Empty;

            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                string query = "SELECT first_name FROM contact_info_table WHERE email_address = @Email";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                firstName = command.ExecuteScalar().ToString();
                connection.Close();
            }

            return firstName;
        }
        public DataTable tables_fill(string cmnd)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                dbadapter = new MySqlDataAdapter(cmnd, connection);
                datatable = new DataTable();
                dbadapter.Fill(datatable);
                connection.Close();
            }

            return datatable;
        }

        public void InsertRegistrationInfo(string firstName, string lastName, string phone, string email, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                connection.Open();

                string sql = "INSERT INTO contact_info_table (first_name, last_name, phone_number, email_address, password) " +
                             "VALUES (@firstName, @lastName, @phone, @email, @password)";

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            
        }
    }
}