using System;
using System.Collections.Generic;

namespace VpHotelRoomBooking.Domain
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }

    }
}
