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
    public class PlantSumRepository : IPlantSumRepository
    {
        private readonly string _dbConfig;

        public PlantSumRepository(string dbConfig)
        {
            _dbConfig = dbConfig;
        }

    
        public async Task<IEnumerable<PlantSumModel>> GetPlanSum()
        {
            try
            {
                using (var conn = new NpgsqlConnection(_dbConfig))
                {
                    
                    await conn.OpenAsync();
                    var query = @"
SELECT AVG(""% particip"") AS avg_particip, AVG(CAST(REPLACE(""Nota Stiba"", ',', '.') AS float)) AS average_nota_stiba
FROM stiba_2023
                    ";
                    
                    return await conn.QueryAsync<PlantSumModel>(query);
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