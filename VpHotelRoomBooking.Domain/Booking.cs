using System;

namespace VpHotelRoomBooking.Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
