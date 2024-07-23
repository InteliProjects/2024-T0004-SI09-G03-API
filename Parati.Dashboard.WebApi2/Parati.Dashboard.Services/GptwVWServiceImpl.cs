using Parari.Dashboard.Repository;
using Parati.Dashboard.Repository;

namespace Parati.Dashboard.Services
{
    public class GptwVWServiceImpl : IGptwVWService
        {
            private readonly IGPTWVWRepository _gptwVWRepository;

            public GptwVWServiceImpl(IGPTWVWRepository gptwVWRepository)
            {
                _gptwVWRepository = gptwVWRepository;
            }

        public async Task<IEnumerable<CidModel>> GetGptwVW()
        {
            // Example implementation, replace with actual data access code
            // This could involve calling a method on _plantSumRepository to get data based on 'unidade'
            return await _gptwVWRepository.GetGPTWsVWFrequenciaProblemasSaudeMentalMes();
        }
    }
        
     
}
