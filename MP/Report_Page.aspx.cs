using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MP
{
    public partial class Report_Page : System.Web.UI.Page
    {
        DataTable statusview;

        private string billsQuery = "SELECT reservationID AS 'Reservation ID', CONCAT(first_name, ' ', last_name) AS Name, roomType AS 'Room Type', " +
                "phone_number AS 'Phone Number', dateReserved AS 'Check-in', dateOut AS 'Check-Out', bill AS Bill " +
                "FROM contact_info_table, reservation, room_options " +
                "WHERE contact_info_table.ID = reservation.ID AND reservation.roomID = room_options.roomID;";

        private string incomeQuery = "SELECT sum(bill) AS 'Net Income' FROM reservation";

        private string customersQuery = "SELECT reservation.ID, CONCAT(first_name, ' ', last_name) AS Name, phone_number AS 'Phone Number', " +
                "email_address AS 'Email Address', COUNT(reservation.ID) AS 'Times Reserved' FROM contact_info_table INNER JOIN reservation ON " +
                "contact_info_table.ID = reservation.ID GROUP BY ID, Name, 'Phone Number', 'Email Address';";

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void booking_tbl_PageIndexChanged(object sender, GridViewPageEventArgs e)
        {
            booked_rooms_tbl.PageIndex = e.NewPageIndex;
            bindtogrid(billsQuery, booked_rooms_tbl);
        }
        protected void total_tbl_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            total_tbl.PageIndex = e.NewPageIndex;
            bindtogrid(customersQuery, total_tbl);
        }

        private void bindtogrid(string query, GridView gridView)
        {
            DatabaseClass bookingview = new DatabaseClass();
            DataSet dataset = bookingview.tables_fill(query);

            gridView.DataSource = dataset;
            gridView.DataBind();
        }

        protected void booked_rooms_btn_Click(object sender, EventArgs e)
        {
            total_tbl.Visible = true;

            DatabaseClass bookingview = new DatabaseClass();
            DataSet bookingset = bookingview.tables_fill(billsQuery);
            statusview = datetostring(bookingset);

            booked_rooms_tbl.DataSource = statusview;
            booked_rooms_tbl.DataBind();

            DatabaseClass net_income = new DatabaseClass();
            DataSet incomeset = net_income.tables_fill(incomeQuery);

            total_tbl.DataSource = incomeset;
            total_tbl.DataBind();
        }

        public void customer_info_click(object sender, EventArgs e)
        {
            total_tbl.Visible = false;
            DatabaseClass something = new DatabaseClass();
            DataSet customerset = something.tables_fill(customersQuery);

            booked_rooms_tbl.DataSource = customerset;
            booked_rooms_tbl.DataBind();
        }

        private DataTable datetostring(DataSet dataset)
        {
            DataTable datatable = new DataTable();
            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                if (row["Check-in"] != DBNull.Value && row["Check-in"] is DateTime checkinDateTime)
                {
                    checkinDateTime = checkinDateTime.Date.AddHours(15); // Set check-in time to 3 PM
                    row["Check-in"] = checkinDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                }

                if (row["Check-Out"] != DBNull.Value && row["Check-Out"] is DateTime checkoutDateTime)
                {
                    checkoutDateTime = checkoutDateTime.Date.AddHours(12); // Set check-out time to 12 PM (noon)
                    row["Check-Out"] = checkoutDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }

            datatable = dataset.Tables[0];
            return datatable;
        }
    }
}