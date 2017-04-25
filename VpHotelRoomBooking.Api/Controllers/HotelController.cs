using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VpHotelRoomBooking.Services;
using VpHotelRoomBooking.Domain;

namespace VpHotelRoomBooking.Api.Controllers
{
    [Route("api/[controller]")]
    public class HotelController : Controller
    {
        IGenericService _service;
        public HotelController(IGenericService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Hotel> Get()
        {
            return _service.GetAll<Hotel>();
        }

        [HttpGet("{id}")]
        public Hotel Get(int id)
        {
            return _service.Get<Hotel>(id);
        }

        [HttpPost]
        public int Post(Hotel hotel)
        {
            return 0;
        }

        [HttpPut("{id}")]
        public int Put(Hotel hotel)
        {
            return _service.Create(hotel);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
   
        }
    }
}
