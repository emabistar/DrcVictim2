using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictimData.Models;

namespace VictimData
{
    public interface IRegionAsset
    {

        string GetRegion(int id);
        Task AddRegionAsync(Region data);
        void DeleteRegionAsync(int id);
       


    }
}
