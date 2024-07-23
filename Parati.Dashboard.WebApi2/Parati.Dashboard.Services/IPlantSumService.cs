using Parari.Dashboard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parati.Dashboard.Services
{
    public interface IPlantSumService 
    {
         Task<IEnumerable<PlantSumModel>> GetPlanSum();
    }
}
