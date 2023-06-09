using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
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
        DataSet dataset;

        string connectionstring = "server=localhost;database=hotel_db;user id=root;Password=";
        public DataSet tables_fill(string cmnd)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                dbadapter = new MySqlDataAdapter(cmnd, connection);
                dataset = new DataSet();
                try
                {
                    dbadapter.Fill(dataset);
                }
                catch (MySql.Data.Types.MySqlConversionException) { }

                connection.Close();
            }

            return dataset;
        }
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
        public string GetSigninDetails(string email, string colName)
        {
            string columnValue = string.Empty;

            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                string query = $"SELECT {colName} FROM contact_info_table WHERE email_address = @Email";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    columnValue = reader.GetString(0);
                }

                reader.Close();
            }

            return columnValue;
        }


        public bool IsEmailExisting(string email)
        {
            bool isExisting = false;

            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                string query = "SELECT COUNT(*) FROM contact_info_table WHERE email_address = @Email";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();

                int count = Convert.ToInt32(command.ExecuteScalar());
                isExisting = count > 0;
            }

            return isExisting;
        }

        public string[] GetRoomInformation(string roomID)
        {
            string query = "SELECT roomPrice, roomType FROM room_options WHERE roomID = @roomID";

            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@roomID", roomID);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string roomPrice = reader.GetString("roomPrice");
                            string roomType = reader.GetString("roomType");

                            return new string[] { roomPrice.ToString(), roomType };
                        }
                    }
                }
            }

            return null; // Return null if no matching roomID found or an error occurred
        }
        public void InsertReservation(string ID, string roomID, string guest, string checkin, string checkout, string bill)
        { 

            string query = "INSERT INTO reservation (ID, roomID, guestCount, dateReserved, dateOut, bill) " +
                             "VALUES (@ID, @roomID, @guest, @checkin, @checkout, @bill)";

            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                connection.Open();

                MySqlCommand insrtcmd = new MySqlCommand(query, connection);
                insrtcmd.Parameters.AddWithValue("@ID", ID);
                insrtcmd.Parameters.AddWithValue("@roomID", roomID);
                insrtcmd.Parameters.AddWithValue("@guest", guest);
                insrtcmd.Parameters.AddWithValue("@checkin", checkin);
                insrtcmd.Parameters.AddWithValue("@checkout", checkout);
                insrtcmd.Parameters.AddWithValue("@bill", bill);

                insrtcmd.ExecuteNonQuery();
            }
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
            }
        }
        public void UpdateRegistrationInfo(string firstName, string lastName, string phone, string email, string password, string id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                connection.Open();

                string sql = "UPDATE contact_info_table " +
                             "SET first_name = @firstName, last_name = @lastName, phone_number = @phone, email_address = @email, password = @password " +
                             "WHERE ID = @id";

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

    }
}