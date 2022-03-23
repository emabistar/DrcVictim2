using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VictimData.Models;

namespace DrcVictim2.Models
{
    public class VictimsViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = " Date is required")]

        //[Display(Name="Date")]

        [DataType(DataType.Date)]
        public DateTime RegisteredDate { get; set; }

        [Display(Name = "Region")]
        [Required(ErrorMessage = " Region is required")]
        public int RegionId { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Display(Name = "Ville")]
        public string City { get; set; }

        [Required(ErrorMessage = " Number of death is required")]
        public int NumberofDeath { get; set; }

        [Required(ErrorMessage = " Rescue  is required")]
        public int Rescue { get; set; }

        [Required(ErrorMessage = " Source is required")]
        public string Source { get; set; }
        public virtual RegionViewModel Region { get; set; }
    }
}
