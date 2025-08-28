using Microsoft.AspNetCore.Mvc;
using tarea_4.Infrastructure.Data;
using tarea_4.Models;
using System.Collections.Generic;

namespace tarea_4.Controllers
{
    [Route("Hotels")]
    public class HotelController : Controller
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return PartialView("_HotelsTable", this._hotelRepository.GetAllHotels());
        }

        [HttpGet("Detail")]
        public IActionResult Details(string id)
        {
            var hotel = this._hotelRepository.GetHotelById(id);
            return PartialView("_HotelDetails", hotel);
        }
    }
}
