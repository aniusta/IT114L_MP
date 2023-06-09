using MySqlX.XDevAPI;
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
    public partial class Customer_Reservations : System.Web.UI.Page
    {
        DataTable statusview;
        DataTable billview;
        string query;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["firstname"] == null)
            {
                title.Text = "No Reservations Made";
            }
            else
            {
                query = "SELECT reservation.reservationID AS 'Reservation ID', reservation.guestCount AS 'Guest Count'," +
                "room_options.roomType AS 'Room Type',reservation.dateReserved AS 'Check-in',reservation.dateOut AS 'Check-Out'," +
                "reservation.bill AS 'Bill' FROM reservation JOIN room_options ON reservation.roomID = room_options.roomID " +
                "WHERE reservation.ID = " + Session["user"].ToString() + ";";

                title.Text = Session["firstname"].ToString() + "'s Reservations";

                DatabaseClass bookingview = new DatabaseClass();
                DataSet bookingset = bookingview.tables_fill(query);
                statusview = datetostring(bookingset);

                booked_rooms_tbl.DataSource = statusview;
                booked_rooms_tbl.DataBind();
            }
            
        }
        protected void booking_tbl_PageIndexChanged(object sender, GridViewPageEventArgs e)
        {
            booked_rooms_tbl.PageIndex = e.NewPageIndex;
            bindtogrid(query, booked_rooms_tbl);
        }

        private void bindtogrid(string query, GridView gridView)
        {
            DatabaseClass bookingview = new DatabaseClass();
            DataSet dataset = bookingview.tables_fill(query);

            gridView.DataSource = dataset;
            gridView.DataBind();
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