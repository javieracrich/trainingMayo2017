using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VpHotelRoomBooking.Data;
using VpHotelRoomBooking.Domain;
using Xunit;

namespace VpHotelRoomBooking.Tests
{

    public class SeedTests
    {
        public SeedTests()
        {

        }

        [Fact(DisplayName = "seeds db with test data")]
        public void Seed()
        {

            var builder = new DbContextOptionsBuilder<VpAppContext>();
            builder.UseSqlServer("Server=.\\sqlexpress;Database=VpTrainingMayo;Trusted_Connection=True;");

            using (var db = new VpAppContext(builder.Options))
            {

                var hotels = new List<Hotel>() {
                    new Hotel{
                        Name = "Hotel 1",
                        Rooms = new List<Room>{
                            new Room() { Number = 11 },
                            new Room() { Number = 12 },
                            new Room() { Number = 13 }
                        }
                    },
                    new Hotel{
                        Name = "Hotel 2",
                        Rooms = new List<Room>{
                            new Room() { Number = 21 },
                            new Room() { Number = 22 },
                            new Room() { Number = 23 }
                        }
                    },
                    new Hotel{
                        Name = "Hotel 3",
                        Rooms = new List<Room>{
                            new Room() { Number = 31 },
                            new Room() { Number = 32 },
                            new Room() { Number = 33 }
                        }
                    },

                };


                db.Hotels.AddRange(hotels);
                db.SaveChanges();


            }
            Assert.True(true);
        }

    }
}
