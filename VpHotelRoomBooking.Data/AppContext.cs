using Microsoft.EntityFrameworkCore;

using System;
using VpHotelRoomBooking.Domain;

namespace VpHotelRoomBooking.Data
{
    public class VpAppContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cnn = @"Server=.\sqlexpress;Database=VpTrainingMayo;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(cnn);
        }

    }
}
