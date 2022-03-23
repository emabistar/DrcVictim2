using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrcVictim2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VictimData;
using VictimData.Models;

namespace DrcVictim2.Controllers
{
    public class DataController : Controller
    {
        private readonly IVictimAsset _service;
        private readonly IRegionAsset _serviceRegion;
        public DataController(IVictimAsset service,IRegionAsset serviceRegion)
        {
            _service = service;
            _serviceRegion = serviceRegion;
        }
        public async Task<IActionResult> Create()
        {

            var RegionDropdown = await _service.GetRegionDropdownValues();

            ViewBag.Regions = new SelectList(RegionDropdown.Regions, "RegionId", "Name");
           
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create(Victim victims)
        {
            if (!ModelState.IsValid)
            {
                var RegionDropdown = await _service.GetRegionDropdownValues();
                ViewBag.Regions = new SelectList(RegionDropdown.Regions, "RegionId", "Name");
                return View(victims);
            }
            await _service.AddVictimsAsync(victims);
            return RedirectToAction("Index","Home",null,null);


        }
        [HttpGet]
        public IActionResult Region()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Region(Region region)
        {
            if (!ModelState.IsValid)
            {
               
                return View(region);
            }
            await _serviceRegion.AddRegionAsync(region);
            return RedirectToAction("Index", "Home", null, null);


        }
    }
}
