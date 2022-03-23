using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictimData.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Region
    {
        public Region()
        {
            Victim = new HashSet<Victim>();
        }

        public int RegionId { get; set; }
        [Required(ErrorMessage = " Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date is required")]


        public DateTime RegisteredDate { get; set; }

        IEnumerable<Victim> Victim { get; set; }
    }
}
