using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parari.Dashboard.Repository
{
    public interface IPlantSumRepository
    {
        Task<IEnumerable<PlantSumModel>> GetPlanSum();
    }
}
