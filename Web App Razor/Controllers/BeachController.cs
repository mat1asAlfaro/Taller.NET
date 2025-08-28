using Microsoft.AspNetCore.Mvc;
using tarea_4.Infrastructure.Data;
using tarea_4.Models;

namespace tarea_4.Controllers
{
    [Route("Beaches")]
    public class BeachController : Controller
    {
        private readonly IBeachRepository _beachRepository;

        public BeachController(IBeachRepository beachRepository)
        {
            _beachRepository = beachRepository;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return PartialView("_BeachesTable", this._beachRepository.GetAllBeaches());
        }

        [HttpGet("Detail")]
        public IActionResult Details(string id)
        {
            var beach = this._beachRepository.GetBeachById(id);
            return PartialView("_BeachDetails", beach);
        }
    }
}
