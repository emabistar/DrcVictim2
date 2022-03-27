using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrcVictim2.Models;
using VictimData.Models;

namespace DrcVictim2.ViewModels
{
    public class VictimVMAsset
    {

        //[Display(Name="Date")]


        public DateTime RegisteredDate { get; set; }


        public int RegionId { get; set; }


        public string City { get; set; }

        public Models.VictimCategory VictimCategory { get; set; }

        public int NumberofDeath { get; set; }


        public int Rescue { get; set; }


        public string Source { get; set; }

        public Region Region {get;set;}
    }
}
