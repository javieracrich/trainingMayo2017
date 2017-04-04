﻿using System;

namespace VpHotelRoomBooking.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool? IsDisabled { get; set; }

    }
}
