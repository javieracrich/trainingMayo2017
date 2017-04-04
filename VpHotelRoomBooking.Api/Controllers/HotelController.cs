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
            var hotels = _service.GetAll<Hotel>();
            return hotels;
        }

        [HttpGet("{id}")]
        public Hotel Get(int id)
        {
            var hotel = _service.Get<Hotel>(id);
            return hotel;
        }

        [HttpPost]
        public int Post(Hotel hotel)
        {
            return _service.Update<Hotel>(hotel);
        }

        [HttpPut("{id}")]
        public int Put(Hotel hotel)
        {
            return _service.Create<Hotel>(hotel);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var hotel = _service.Get<Hotel>(id);
            _service.Delete(hotel);
        }
    }
}
