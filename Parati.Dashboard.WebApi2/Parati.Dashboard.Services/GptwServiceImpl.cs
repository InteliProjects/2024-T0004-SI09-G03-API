using Parari.Dashboard.Repository;
using Parati.Dashboard.Repository;

namespace Parati.Dashboard.Services
{
    public class GptwServiceImpl : IGptwService
        {
            private readonly IGPTWRepository _gptwRepository;

            public GptwServiceImpl(IGPTWRepository gptwRepository)
            {
                _gptwRepository = gptwRepository;
            }

        public async Task<IEnumerable<CidModel>> GetGptw(string unidade)
        {
            // Example implementation, replace with actual data access code
            // This could involve calling a method on _plantSumRepository to get data based on 'unidade'
            return await _gptwRepository.GetGPTWsFrequenciaProblemasSaudeMentalMes(unidade);
        }
    }
        
     
}
