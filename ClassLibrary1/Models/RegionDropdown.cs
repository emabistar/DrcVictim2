using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VictimData.Models;

namespace VictimData.Models
{
    public class RegionDropdown
    {
        public RegionDropdown()
        {

            Regions = new List<Region>();

        }

        public List<Region> Regions { get; set; }
    }
}
