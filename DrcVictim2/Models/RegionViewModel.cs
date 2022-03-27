using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VictimData.Models;

namespace DrcVictim2.Models
{
    public class RegionViewModel
    {

        public RegionViewModel()
        {
            Victim = new HashSet<Victim>();
        }

        public int RegionId { get; set; }
        [Required(ErrorMessage = " Name is required")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Date is required")]


        public DateTime RegisteredDate { get; set; }

        IEnumerable<Victim> Victim { get; set; }

        public static explicit operator RegionViewModel(Region v)
        {
            throw new NotImplementedException();
        }
    }
}
