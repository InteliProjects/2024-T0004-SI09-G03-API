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
    public class GeneralDatasRepository : IGeneralDataRepository
    {
        private readonly string _dbConfig;

        public GeneralDatasRepository(string dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public async Task<IEnumerable<GeneralDataModel>> GetData()
        {
            try
            {
                using (var conn = new NpgsqlConnection(_dbConfig))
                {

                    await conn.OpenAsync();
                    var query = @"
                      SELECT 
    zenklub.departamento,
    SUM(zenklub.total_sessoes) AS total_sessoes,
    ROUND(SUM(CAST(REPLACE(cid_f_2023_geral.dias, ',', '.') AS DECIMAL))) AS total_dias, 
    SUM(cid_f_2023_geral.atestados) AS total_atestados
FROM cid_f_2023_geral
INNER JOIN zenklub 	
    ON cid_f_2023_geral.n_pessoal = zenklub.n_pessoal
GROUP BY zenklub.departamento;      
                    ";

                    return await conn.QueryAsync<GeneralDataModel>(query);
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