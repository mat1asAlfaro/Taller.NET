using Microsoft.AspNetCore.Mvc;
using tarea_4.Infrastructure.Data;
using tarea_4.Models;
using System.Collections.Generic;

namespace tarea_4.Controllers
{
    [Route("Excursions")]
    public class ExcursionController : Controller
    {
        private readonly IExcursionRepository _excursionRepository;

        public ExcursionController(IExcursionRepository excursionRepository)
        {
            _excursionRepository = excursionRepository;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return PartialView("_ExcursionsTable", this._excursionRepository.GetAllExcursions());
        }

        [HttpGet("Detail")]
        public IActionResult Details(string id)
        {
            var excursion = this._excursionRepository.GetExcursionById(id);
            return PartialView("_ExcursionDetails", excursion);
        }
    }
}
