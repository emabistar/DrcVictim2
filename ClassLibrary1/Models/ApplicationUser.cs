using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace VictimData.Models
{
    public class ApplicationUser:IdentityUser
    {

        [Display(Name="Full name")]
        public string FullName { get; set; }
    }
}
