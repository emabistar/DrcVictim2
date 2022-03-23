using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VictimData.Models;

namespace VictimData
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) {  }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Victim> Victims { get; set; }
        
    }
}
