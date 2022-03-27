using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictimData.Models;
using VictimData.Models.DashBoard;

namespace VictimData
{
    public  interface IVictimAsset
    {
      
        Victim GetById(int id);
        Region GetRegionById(int id);
        int TotalVictims();
        int TotalRescues();
        IEnumerable<ChartData> VictimsPerYear();
        IEnumerable<ChartData> VictimsPerMonth();
        IEnumerable<ChartData> VictimsPerRegion();
        IEnumerable<ChartData> VictimsPerCity();
        Task AddVictimsAsync(Victim data);
        IEnumerable<Victim> GettAllVictims();

        Task<RegionDropdown> GetRegionDropdownValues();
    }
}
