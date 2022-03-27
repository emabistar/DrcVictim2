using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictimData;
using VictimData.Models;

namespace VictimService
{
    public class RegionService : IRegionAsset
    {

        protected readonly AppDbContext _context;

        public RegionService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddRegionAsync(Region data)
        {

            var newRegion = new Region()
            {
                RegisteredDate = data.RegisteredDate,
                Name = data.Name
            };
            await _context.AddAsync(newRegion);
            await _context.SaveChangesAsync();
           
        }

        public void  DeleteRegionAsync(int id)
        {
            var model = _context.Regions.FirstOrDefault(r => r.RegionId == id);
            _context.Remove(model);
            _context.SaveChanges();
          
        }

        public Region GetRegion(int id)
        {
            var model = _context.Regions.FirstOrDefault(r => r.RegionId == id);

            return model;
        }
    }
}
