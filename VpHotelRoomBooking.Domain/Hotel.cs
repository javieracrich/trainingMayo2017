using System;
using System.Collections.Generic;

namespace VpHotelRoomBooking.Domain
{
    public class Hotel: BaseEntity
    {

        public string Name { get; set; }
        public List<Room> Rooms { get; set; }

    }
}
