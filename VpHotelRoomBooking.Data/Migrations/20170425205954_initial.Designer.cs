using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using VpHotelRoomBooking.Data;

namespace VpHotelRoomBooking.Data.Migrations
{
    [DbContext(typeof(VpAppContext))]
    [Migration("20170425205954_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VpHotelRoomBooking.Domain.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CheckIn");

                    b.Property<DateTime>("CheckOut");

                    b.Property<DateTime?>("Created");

                    b.Property<string>("FirstName");

                    b.Property<bool?>("IsDisabled");

                    b.Property<string>("LastName");

                    b.Property<int?>("RoomId");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("VpHotelRoomBooking.Domain.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Created");

                    b.Property<bool?>("IsDisabled");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("VpHotelRoomBooking.Domain.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Created");

                    b.Property<int?>("HotelId");

                    b.Property<bool?>("IsDisabled");

                    b.Property<int>("Number");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("VpHotelRoomBooking.Domain.Booking", b =>
                {
                    b.HasOne("VpHotelRoomBooking.Domain.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("VpHotelRoomBooking.Domain.Room", b =>
                {
                    b.HasOne("VpHotelRoomBooking.Domain.Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId");
                });
        }
    }
}
