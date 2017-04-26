using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
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
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var cnn = config.GetConnectionString("DefaultConnection");
            Console.WriteLine("CONNECTIONSTRING USED FOR MIGRATIONS:" + cnn);
            optionsBuilder.UseSqlServer(cnn, b => b.MigrationsAssembly("VpHotelRoomBooking.Data"));
        }
    }
}

