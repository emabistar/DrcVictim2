using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VictimData;
using VictimData.Models;
using VictimData.Static;

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


        public static async Task SeedUserAndRoleAsync(IApplicationBuilder applicationBuilder)
        {

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope() )
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Role


                 // If Admin role  does not exit create one Admin and User
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                // User

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string adminUserEmail = "admin@websky.dk";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                

                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin user",
                        UserName = "admin-user",
                        Email = "admin@websky.dk",
                        EmailConfirmed = true,
                    };
                    //  Admin user admin and  and role

                    await userManager.CreateAsync(newAdminUser, "Bio@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@websky.dk";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if(appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = " Application  User ",
                        UserName = "app-user",
                        Email = "emabi@websky.dk",
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAppUser, "Bio@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }


            }


        }


    }


}
