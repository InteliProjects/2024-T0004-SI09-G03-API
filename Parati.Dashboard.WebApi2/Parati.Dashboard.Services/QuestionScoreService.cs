using Parari.Dashboard.Repository;

namespace Parati.Dashboard.Services
{
    public class QuestionScoreService : IQuestionScoreService
    {
        private readonly IQuestionScoreRepository _questionScoreRepository;

        public QuestionScoreService(IQuestionScoreRepository questionScoreRepository)
        {
            _questionScoreRepository = questionScoreRepository;
        }
        async Task<IEnumerable<QuestionScoreModel>> IQuestionScoreService.GetQuestionScore()
        {
            try
            {
                return await _questionScoreRepository.GetQuestionScore();
            }
            catch (Exception ex)
            {
                // TODO: Log.Error(ex, "Erro ao obter informações do GPTW do repositório.");
                throw new ServiceException("An error occurred while retrieving GPTW data.", ex);
            }
        }
    }

    }

