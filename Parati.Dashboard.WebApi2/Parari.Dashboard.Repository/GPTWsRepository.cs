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
    public class GPTWsRepository : IGPTWRepository
    {
        private readonly string _dbConfig;

        public GPTWsRepository(string dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public async Task<IEnumerable<CidModel>> GetGPTWsFrequenciaProblemasSaudeMentalMes(string unidade)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_dbConfig))
                {
                    
                    await conn.OpenAsync();
                    var query = @"
                    WITH meses AS (
                      SELECT DISTINCT mes
                      FROM cid_f_2023
                      WHERE unidade = @Unidade
                    ),
                    causa_ranking_total AS (
                      SELECT 
                        LOWER(descricao) as descricao_lower,
                        COUNT(*) as quantidade_total_atestados
                      FROM cid_f_2023
                      WHERE unidade = @Unidade
                      GROUP BY LOWER(descricao)
                      ORDER BY COUNT(*) DESC
                      LIMIT 3
                    ),
                    causas_por_mes AS (
                      SELECT 
                        m.mes,
                        crt.descricao_lower,
                        COALESCE(SUM(cf.quantidade_atestados), 0) as quantidade_atestados
                      FROM meses m
                      CROSS JOIN causa_ranking_total crt
                      LEFT JOIN (
                          SELECT 
                            mes, 
                            LOWER(descricao) as descricao_lower, 
                            COUNT(*) as quantidade_atestados
                          FROM cid_f_2023
                          WHERE unidade = @Unidade
                          GROUP BY mes, LOWER(descricao)
                      ) cf ON m.mes = cf.mes AND crt.descricao_lower = cf.descricao_lower
                      GROUP BY m.mes, crt.descricao_lower
                    )
                    SELECT 
                      cpm.mes, 
                      cpm.descricao_lower as descricao, 
                      cpm.quantidade_atestados
                    FROM causas_por_mes cpm
                    ORDER BY cpm.mes, cpm.quantidade_atestados DESC;
                    ";

                    var parameters = new { Unidade = unidade };
                    
                    return await conn.QueryAsync<CidModel>(query, parameters);
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