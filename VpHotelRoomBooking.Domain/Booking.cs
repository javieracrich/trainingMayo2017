using System;

namespace VpHotelRoomBooking.Domain
{
    public class Booking:BaseEntity
    {
        public Room Room { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
