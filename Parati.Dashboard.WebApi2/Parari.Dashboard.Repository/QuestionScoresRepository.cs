using Dapper;
using Npgsql;
using Parari.Dashboard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parati.Dashboard.Repository
{
    public class QuestionScoresRepository : IQuestionScoreRepository
    {
        private readonly string _dbConfig;

        public QuestionScoresRepository(string dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public async Task<IEnumerable<QuestionScoreModel>> GetQuestionScore()
        {
            try
            {
                using (var conn = new NpgsqlConnection(_dbConfig))
                {

                    await conn.OpenAsync();
                    var query = @"
                    SELECT

              
                    FROM
                        gptw_company_t;
                    ";

                    return await conn.QueryAsync<QuestionScoreModel>(query);
                }
            }
            catch (Exception ex)
            {
                // TODO: Log.Error(ex, "Erro ao obter informações do GPTW.");
                throw new Exception("An error occurred while trying to fetch GPTW data.", ex);
            }
        }
    }
}