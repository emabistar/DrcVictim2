using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VictimData;
using VictimData.Models;
using VictimData.Models.DashBoard;

namespace VictimService
{
    public  class VictimAssetService: IVictimAsset
    {


        protected readonly AppDbContext _context;

        public VictimAssetService(AppDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task AddVictimsAsync(Victim data)
        {
            var newVictim = new Victim()
            {
                RegisteredDate = data.RegisteredDate,
                NumberofDeath = data.NumberofDeath,
                City = data.City,
                VictimCategory =data.VictimCategory,
                Region = data.Region,
                Source = data.Source,
                Rescue = data.Rescue,
                RegionId = data.RegionId
            };
            await _context.Victims.AddAsync(newVictim);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<ChartData> VictimsPerCity()
        {
            var listOfVictims = _context.Victims;
            var chartdata = listOfVictims.Include(r => r.Region).AsEnumerable().GroupBy(a => a.City).Select(result => new ChartData
            {

                Key = result.Key.ToString(),
                Value = result.Sum(t => t.NumberofDeath)

            }); ;
            return chartdata;
        }

        public IEnumerable<ChartData> VictimsPerRegion()
        {
            var listOfVictims = _context.Victims;
            var chartdata = listOfVictims.Include(r => r.Region).AsEnumerable().GroupBy(a => a.Region).Select(result => new ChartData
            {

                Key = result.Key.Name.ToString(),
                Value = result.Sum(t => t.NumberofDeath)

            }); ;
            return chartdata;
        }

        public IEnumerable<ChartData> VictimsPerMonth()
        {
            var listOfVictims = _context.Victims;


            var chartdata = listOfVictims.Include(r => r.Region).AsEnumerable().GroupBy(a => a.RegisteredDate).Select(result => new ChartData
            {

                Key = result.Key.ToString(),
                Value = result.Sum(t => t.NumberofDeath)

            }); ;
            return chartdata;
        }

        public IEnumerable<ChartData> VictimsPerYear()
        {
            var listOfVictims = _context.Victims;


            var chartdata = listOfVictims.Include(r => r.Region).AsEnumerable().AsEnumerable().GroupBy(a => a.RegisteredDate.Year).Select(result => new ChartData
            {

                Key = result.Key.ToString(),
                Value = result.Sum(t => t.NumberofDeath)

            }); ;
            return chartdata;
        }

        public Victim GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int TotalVictims()
        {
            // todo sum

            var numberOfVictims = _context.Victims.Select(n => n.NumberofDeath).Sum();
            return numberOfVictims;
        }

        public int TotalRescues()
        {
            var rescuesVictims = _context.Victims.Select(n => n.Rescue).Sum();
            return rescuesVictims;
        }

        public async Task<RegionDropdown> GetRegionDropdownValues()
        {
            var response = new RegionDropdown()
            {
                Regions = await _context.Regions.OrderBy(n => n.Name).ToListAsync(),

            };

            return response;
        }

        public IEnumerable<Victim>GettAllVictims()
        {
            return _context.Victims.Include(r => r.Region);

           
        }

        public Region GetRegionById(int id)
        {
            var region = _context.Regions.FirstOrDefault(r=> r.RegionId == id);
            return region;
        }
    }
}
