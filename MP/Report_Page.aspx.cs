using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MP
{
    public partial class Report_Page : System.Web.UI.Page
    {
        DataTable statusview;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void booked_rooms_btn_Click(object sender, EventArgs e)
        {
            DatabaseClass bookingview = new DatabaseClass();
            string query1 = "SELECT roomType AS RoomType, reservationID AS ReservationID, CONCAT(first_name, ' ', last_name) AS Name, phone_number AS PhoneNumber " +
                "FROM contact_info_table, reservation, room_options " +
                "WHERE contact_info_table.ID = reservation.ID AND reservation.roomID = room_options.roomID;";

            statusview = bookingview.tables_fill(query1);
            booked_rooms_tbl.DataSource = statusview;
            booked_rooms_tbl.DataBind();
        }

        public void something(object sender, EventArgs e)
        {
            DatabaseClass something = new DatabaseClass();
            string query1 = "SELECT ID, CONCAT(first_name, ' ', last_name) AS Name, phone_number AS PhoneNumber, email_address AS EmailAddress " +
                "FROM contact_info_table; ";

            statusview = something.tables_fill(query1);
            booked_rooms_tbl.DataSource = statusview;
            booked_rooms_tbl.DataBind();
        }
    }
}