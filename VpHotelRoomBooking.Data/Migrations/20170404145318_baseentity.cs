using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VpHotelRoomBooking.Data.Migrations
{
    public partial class baseentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Bookings",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Bookings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Bookings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Bookings");
        }
    }
}
