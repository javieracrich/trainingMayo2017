﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using VpHotelRoomBooking.Domain;

namespace VpHotelRoomBooking.Data
{
    public class VpAppContext : DbContext
    {

        public VpAppContext(DbContextOptions options) : base(options)
        {

        }

        public VpAppContext()
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                var cnn = config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(cnn);
            }
        }
    }
}