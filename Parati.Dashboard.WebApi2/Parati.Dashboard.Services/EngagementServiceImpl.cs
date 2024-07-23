using Parari.Dashboard.Repository;

namespace Parati.Dashboard.Services
{
    public class EngagementServiceImpl : IEngagementeService
    {
        private readonly IEngagementRepository _engagimentModel;

        public EngagementServiceImpl(IEngagementRepository questionScoreRepository)
        {
            _engagimentModel = questionScoreRepository;
        }

        public async Task<IEnumerable<EngagementModel>> GetData()
        {
            try
            {
                return await _engagimentModel.GetEngagiment();
            }
            catch (Exception ex)
            {
                // TODO: Log.Error(ex, "Erro ao obter informações do GPTW do repositório.");
                throw new ServiceException("An error occurred while retrieving GPTW data.", ex);
            }
        }
    }
}