using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MP
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string connectionString = "server=localhost;database=hotel_db;user id=root;Password=";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initial page load code
                checkindate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                checkoutdate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                for (int i = 1; i <= 8; i++)
                {
                    ListItem item = new ListItem(i.ToString(), i.ToString());
                    GuestCount.Items.Add(item);
                }
            }
            LoadDynamicControls();
            UpdateBookingBtn("");
        }

        private void LoadDynamicControls()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT roomID, roomPrice, roomType, roomDescription, roomPictureLoc FROM room_options";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        int availablerooms = 0;
                            while (reader.Read())
                            {
                            int room_ID = reader.GetInt32("roomID");
                            //DYNAMICALLY ADD CARDS FOR AVAILABLE ROOMS
                            if (!IsRoomOccupied(room_ID, checkindate.Text, checkoutdate.Text))
                            {
                                // Access the values from the reader for each row
                                int roomID = reader.GetInt32("roomID");
                                decimal roomPrice = reader.GetDecimal("roomPrice");
                                string roomType = reader.GetString("roomType");
                                string roomDescription = reader.GetString("roomDescription");
                                string roomPictureLoc = reader.GetString("roomPictureLoc");

                                // Create the room container div
                                Panel roomContainerDiv = new Panel();
                                roomContainerDiv.CssClass = "card-container";
                                roomContainerDiv.Style["border"] = "1px black solid";

                                // Create the left column div
                                Panel leftColumnDiv = new Panel();
                                leftColumnDiv.CssClass = "col-lg-4 container-padding";

                                // Create the image element
                                Image image = new Image();
                                image.ImageUrl = roomPictureLoc;
                                image.CssClass = "card-img";
                                leftColumnDiv.Controls.Add(image);

                                roomContainerDiv.Controls.Add(leftColumnDiv);

                                // Create the middle column div
                                Panel middleColumnDiv = new Panel();
                                middleColumnDiv.CssClass = "col-lg-5 container-padding";

                                // Create the room type heading
                                Label roomTypeLabel = new Label();
                                roomTypeLabel.CssClass = "app_heading1";
                                roomTypeLabel.Text = roomType;
                                middleColumnDiv.Controls.Add(roomTypeLabel);
                                middleColumnDiv.Controls.Add(new LiteralControl("<br />"));
                                // Create the sleeps and bed info
                                Label sleepsLabel = new Label();
                                sleepsLabel.Text = "<small>Sleeps 3 | 1 King</small>";
                                middleColumnDiv.Controls.Add(sleepsLabel);
                                middleColumnDiv.Controls.Add(new LiteralControl("<br />"));

                                // Create the room description
                                Label roomDescriptionLabel = new Label();
                                roomDescriptionLabel.CssClass = "typography-regular";
                                roomDescriptionLabel.Text = roomDescription;
                                middleColumnDiv.Controls.Add(roomDescriptionLabel);

                                roomContainerDiv.Controls.Add(middleColumnDiv);

                                // Create the right column div
                                Panel rightColumnDiv = new Panel();
                                rightColumnDiv.CssClass = "col-lg-3 container-padding rightmost-card";

                                // Create the room price
                                Label roomPriceLabel = new Label();
                                roomPriceLabel.Text = "<strong>$ " + roomPrice.ToString() + "</strong>";
                                rightColumnDiv.Controls.Add(roomPriceLabel);
                                rightColumnDiv.Controls.Add(new LiteralControl("<br />"));
                                // Create the per night label
                                Label perNightLabel = new Label();
                                perNightLabel.Text = "Per Night";
                                rightColumnDiv.Controls.Add(perNightLabel);
                                rightColumnDiv.Controls.Add(new LiteralControl("<br />"));
                                // Create the taxes and fees label
                                Label taxesFeesLabel = new Label();
                                taxesFeesLabel.CssClass = "text-muted";
                                taxesFeesLabel.Text = "<small>Including Taxes and Fees</small>";
                                rightColumnDiv.Controls.Add(taxesFeesLabel);
                                rightColumnDiv.Controls.Add(new LiteralControl("<br />"));
                                // Create the book button
                                Button bookButton = new Button();
                                bookButton.CssClass = "btn button_primary";
                                bookButton.Text = "Book Now";
                                bookButton.CommandArgument = roomID.ToString(); // Set the room ID as CommandArgument
                                bookButton.Command += bookbtn_Command; // Attach the command event handler
                                rightColumnDiv.Controls.Add(bookButton);

                                roomContainerDiv.Controls.Add(rightColumnDiv);

                                // Add the room container div to the container control
                                cardContainer.Controls.Add(roomContainerDiv);

                                availablerooms += 1;
                            }
                        }
                        if (availablerooms == 0)
                        {
                            Label noroom = new Label();
                            noroom.CssClass = "app_pageTitle";
                            noroom.Text = "No Rooms Available";
                            cardContainer.Controls.Add(noroom);
                        }
                        
                    }
                }
                connection.Close();
                //DYNAMICALLY CREATE THE BOOKING SUMMARY
                // Create a new <label> element for checkin date
                DateTime date = DateTime.ParseExact(checkindate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                string checkin = date.ToString("MMMM dd, yyyy");

                Label checkinLabel = new Label();
                checkinLabel.ID = "checkinValue";
                checkinLabel.Text = checkin + " - ";
                bookingContainer.Controls.Add(checkinLabel);

                // Create a new <label> element for checkout date
                DateTime date2 = DateTime.ParseExact(checkoutdate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                string checkout = date2.ToString("MMMM dd, yyyy");
                Label checkoutLabel = new Label();
                checkoutLabel.ID = "checkoValue";
                checkoutLabel.Text = checkout;
                bookingContainer.Controls.Add(checkoutLabel);

                bookingContainer.Controls.Add(new LiteralControl("<br />"));
                Label guestcountLabel = new Label();
                guestcountLabel.ID = "guestcountValue";
                guestcountLabel.Text = GuestCount.SelectedValue + " Guests";
                bookingContainer.Controls.Add(guestcountLabel);
            }
        }
        private void UpdateBookingBtn(string roomID)
        {
            bool isBookingContainerEmpty = Panel1.Controls.Count == 0;
            if (isBookingContainerEmpty)
            {
                bookingbtn.Style["display"] = "none";
            }
            else
            {
                if (Session["LoggedIn"] != null && (bool)Session["LoggedIn"])
                {
                    bookingbtn.Style["display"] = "block";
                    bookingbtn.Text = Session["roomID"].ToString();
                }
                else
                {
                    bookingbtn.Style["display"] = "block";
                    bookingbtn.Text = "Please sign in to continue";
                    bookingbtn.Attributes.Add("disabled", "disabled");
                }
            }
        }

        protected void checkindate_TextChanged(object sender, EventArgs e)
        {
            DateTime selectedDate;

            if (DateTime.TryParse(checkindate.Text, out selectedDate))
            {
                if (selectedDate < DateTime.Now.Date)
                {
                    // Set the checkindate to the minimum valid value (current date)
                    checkindate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                    DateTime checkoutDate = selectedDate.AddDays(1);
                    checkoutdate.Text = checkoutDate.ToString("yyyy-MM-dd");
                }
            }
        }
        private bool IsRoomOccupied(int roomID, string checkindate, string checkoutdate)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM reservation WHERE roomID = @roomID AND dateReserved <= @checkoutdate AND dateOut >= @checkindate";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@roomID", roomID);
                    command.Parameters.AddWithValue("@checkindate", checkindate);
                    command.Parameters.AddWithValue("@checkoutdate", checkoutdate);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
                }
            }
        }

        protected void checkoutdate_TextChanged(object sender, EventArgs e)
        {
            //Validator for checkout date calendar
            DateTime checkIn;
            DateTime checkOut;

            if (DateTime.TryParse(checkindate.Text, out checkIn) && DateTime.TryParse(checkoutdate.Text, out checkOut))
            {
                if (checkOut < checkIn)
                {
                    // Set the checkoutdate to the minimum valid value (checkIn + 1 day)
                    checkoutdate.Text = checkIn.AddDays(1).ToString("yyyy-MM-dd");
                }
            }
        }

        protected void modal_Click(object sender, EventArgs e)
        {
            //guestsModal.Style["display"] = "block";
        }

        protected void bookbtn_Command(object sender, CommandEventArgs e)
        {
            string roomID = e.CommandArgument.ToString();
            Session["roomID"] = roomID;
            DatabaseClass database = new DatabaseClass();
            string[] roomInfo = database.GetRoomInformation(roomID);

            decimal roomPrice = decimal.Parse(roomInfo[0]);
            string roomType = roomInfo[1];

            // Parse the check-in and check-out dates
            DateTime checkInDate = DateTime.Parse(checkindate.Text);
            DateTime checkOutDate = DateTime.Parse(checkoutdate.Text);

            // Calculate the number of nights
            int numberOfNights = (int)(checkOutDate - checkInDate).TotalDays;
            // Create the container div
            Panel roomBookingContainer = new Panel();
            roomBookingContainer.CssClass = "booking-summary";

            // Create the left column div
            Panel leftColumnDiv = new Panel();

            // Create the room type label
            Label roomTypeLabel = new Label();
            roomTypeLabel.Text = roomType + "<br />";
            roomTypeLabel.CssClass = "bold-underlined";
            leftColumnDiv.Controls.Add(roomTypeLabel);

            // Create the bed & breakfast label
            Label bedBreakfastLabel = new Label();
            bedBreakfastLabel.Text = "Bed & Breakfast <br />";
            leftColumnDiv.Controls.Add(bedBreakfastLabel);

            // Create the number of nights label
            Label nightsLabel = new Label();
            nightsLabel.Text = "<small><b>" + numberOfNights + " nights</b></small><br /><br />";
            leftColumnDiv.Controls.Add(nightsLabel);

            // Create the add/remove button
            Button removeButton = new Button();
            removeButton.CssClass = "btn btn-danger";
            removeButton.Text = "Remove";
            leftColumnDiv.Controls.Add(removeButton);

            roomBookingContainer.Controls.Add(leftColumnDiv);

            // Create the right column div
            Panel rightColumnDiv = new Panel();

            // Create the room price label
            Label roomPriceLabel = new Label();
            roomPriceLabel.Text = "<b>$ " + roomPrice + "</b>";
            rightColumnDiv.Controls.Add(roomPriceLabel);

            roomBookingContainer.Controls.Add(rightColumnDiv);

            // Add the room booking container to the bookingContainer
            bookingContainer.Controls.Add(roomBookingContainer);

            // Calculate and display the total
            decimal total = roomPrice * numberOfNights;
            Session["total"] = total;

            // Create the total container div
            Panel totalContainer = new Panel();
            totalContainer.CssClass = "booking-total";
            LiteralControl horizontalRule = new LiteralControl("<hr />");
            bookingContainer.Controls.Add(horizontalRule);
            // Create the total label
            Label totalLabel = new Label();
            totalLabel.Text = "<h5><b>Total: </b></h5>";
            totalContainer.Controls.Add(totalLabel);

            // Create the total value label
            Label totalValueLabel = new Label();
            totalValueLabel.Text = "<h5><b>$ " + total + "</b></h5>";
            totalContainer.Controls.Add(totalValueLabel);

            // Add the total container div to the bookingContainer
            Panel1.Controls.Add(totalContainer);

            UpdateBookingBtn(roomID);
        }
        protected void bookingbtn_Click(object sender, EventArgs e)
        {
            // Your existing code here
            DatabaseClass insertreservation = new DatabaseClass();
            insertreservation.InsertReservation(Session["user"].ToString(), Session["roomID"].ToString(), GuestCount.SelectedValue, checkindate.Text, checkoutdate.Text, Session["total"].ToString());
            Response.Redirect(Request.RawUrl);
        }

    }
}