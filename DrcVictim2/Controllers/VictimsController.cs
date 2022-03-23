using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrcVictim2.Models;
using Microsoft.AspNetCore.Mvc;
using VictimData;

namespace DrcVictim2.Controllers
{
    [Produces("application/json")]
    [Route("api/victims")]
    public class VictimsController : Controller
    {
        protected readonly IVictimAsset _service;

      
        public VictimsController(IVictimAsset service)
        {
            _service = service;
        }

       // GET: api/victms
        [HttpGet]
        public IActionResult Get()
        {

            var dashboardResult = new DashBoard
            {
                TotalDeath = _service.TotalVictims(),
                TotalRescue = _service.TotalRescues(),
                TotalDeathPerYear = _service.VictimsPerYear(),
                TotalDeathPerMonth = _service.VictimsPerMonth(),
                DeathPerCity = _service.VictimsPerCity(),
                DeathPerRegion = _service.VictimsPerRegion()

            };



            return Json(dashboardResult);
        }
    }
}
