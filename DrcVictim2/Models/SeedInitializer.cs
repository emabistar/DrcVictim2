using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using VictimData;
using VictimData.Models;

namespace DrcVictim2.Models
{
    public class SeedInitializer
    {


        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                if (context.Victims.Any())
                {
                    return; // DB has been seeded
                }

                
                if (context.Regions.Any())
                {
                    return; // DB has been seeded
                }


             

                var regions = new List<Region>
                    {
                        new Region
                        {

                            Name = "Nord-kivu",
                            RegisteredDate = DateTime.Parse("2022-02-02"),
                           

                        },
                        new Region
                        {

                            Name = "Ituri",
                            RegisteredDate = DateTime.Parse("2022-02-02"),
                         

                        }
                    };
                regions.ForEach(r => context.Regions.Add(r));
                context.SaveChanges();



                var deaths = new List<Victim>
                    {
                       new Victim {
                           RegisteredDate = DateTime.Parse("2022-01-02"),
                           City="Beni",
                           RegionId = 1,
                           NumberofDeath = 3,
                           Source="RadioOkap",
                           Rescue=2
                       },
                        new Victim {
                                 RegisteredDate = DateTime.Parse("2022-02-02"),
                                 City="Bunia",
                                 RegionId = 2,
                                 NumberofDeath = 5,
                                 Source="RadioOkap",
                            Rescue=12}

                    };
                deaths.ForEach(d => context.Victims.Add(d));
                context.SaveChanges();

            }





        }

    }
}
