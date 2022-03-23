using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VictimData.Models.DashBoard;

namespace DrcVictim2.Models
{
    public class DashBoard
    {
        
        public int TotalDeath { get; set; }
        public int TotalRescue { get; set; }
        public IEnumerable<ChartData> TotalDeathPerYear { get; set; }
        public IEnumerable<ChartData> TotalDeathPerMonth { get; set; }
        public IEnumerable<ChartData> DeathPerRegion { get; set; }
        public IEnumerable<ChartData> DeathPerCity { get; set; }
    }
}
