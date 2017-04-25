using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VpHotelRoomBooking.Services;

namespace VpHotelRoomBooking.Api.Controllers
{
    [Route("api/[controller]")]
    public class BookingController : Controller
    {
        IGenericService _service;
        public BookingController(IGenericService service)
        {
            _service = service;
        }



    }
}
