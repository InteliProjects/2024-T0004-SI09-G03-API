using Parari.Dashboard.Repository;

namespace Parati.Dashboard.Services
{
    public class GeneralDataService : IGeneralDataService
    {
        private readonly IGeneralDataRepository _generalDataRepository;

        public GeneralDataService(IGeneralDataRepository generalDataRepository)
        {
            _generalDataRepository = generalDataRepository;
        }

        public Task<IEnumerable<GeneralDataModel>> GetData()
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<GeneralDataModel>> IGeneralDataService.GetData()
        {
            try
            {
                return await _generalDataRepository.GetData();
            }
            catch (Exception ex)
            {
                // TODO: Log.Error(ex, "Erro ao obter informações do GPTW do repositório.");
                throw new ServiceException("An error occurred while retrieving GPTW data.", ex);
            }
        }
    }
}
