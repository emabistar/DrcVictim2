using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrcVictim2.ViewModels
{
    public class LoginVM
    {

        [Required(ErrorMessage="Email is required")]
        public  string EmailAddress { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
