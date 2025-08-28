using Microsoft.AspNetCore.Mvc;
using tarea_4.Infrastructure.Data;
using tarea_4.Models;

namespace tarea_4.Controllers
{
    [Route("Cities")]
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return PartialView("_CitiesTable", this._cityRepository.GetAllCities());
        }

        [HttpGet("Detail")]
        public IActionResult Details(string id)
        {
            var city = this._cityRepository.GetCityById(id);
            return PartialView("_CityDetails", city);
        }
    }
}
