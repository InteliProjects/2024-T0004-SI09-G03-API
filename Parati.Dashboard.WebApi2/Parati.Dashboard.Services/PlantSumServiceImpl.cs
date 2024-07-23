using System.Threading.Tasks;
using System.Collections.Generic;
using Parari.Dashboard.Repository;

namespace Parati.Dashboard.Services
{
    public class PlantSumServiceImpl : IPlantSumService
    {
        private readonly IPlantSumRepository _plantSumRepository;

        public PlantSumServiceImpl(IPlantSumRepository plantSumRepository)
        {
            _plantSumRepository = plantSumRepository;
        }

        public async Task<IEnumerable<PlantSumModel>> GetPlanSum()
        {
            // Example implementation, replace with actual data access code
            // This could involve calling a method on _plantSumRepository to get data based on 'unidade'
            return await _plantSumRepository.GetPlanSum();
        }
    }

    public class ServiceException : Exception
    {
        public ServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
