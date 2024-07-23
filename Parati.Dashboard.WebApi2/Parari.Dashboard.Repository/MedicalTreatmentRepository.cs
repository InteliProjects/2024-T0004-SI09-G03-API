using Dapper;
using Npgsql;

namespace Parari.Dashboard.Repository;

public class MedicalTreatmentRepository : IMedicalTreatmentRepository
{
    private readonly string _dbConfig;

    public MedicalTreatmentRepository(string dbConfig)
    {
        _dbConfig = dbConfig;
    }
    public async Task<IEnumerable<MedicalTreatmentModel>> getMedicalTreatment(string unidade)
    {
        try {
                using (var conn = new NpgsqlConnection(_dbConfig))
                {
                    await conn.OpenAsync();
                    var query = @"WITH all_months AS (
                    SELECT DISTINCT
                        TO_CHAR(TO_DATE(EXTRACT(MONTH FROM TO_DATE(data_evento, 'DD/MM/YYYY'))::text, 'MM'), 'TMMonth') AS mes
                    FROM ps_amil
                    WHERE EXTRACT(YEAR FROM TO_DATE(data_evento, 'DD/MM/YYYY')) = 2023
                    ),
                    all_services AS (
                        SELECT DISTINCT
                            LOWER(descricao_servico) AS descricao_servico
                        FROM ps_amil
                    ),
                    month_service_combinations AS (
                        SELECT
                            m.mes,
                            s.descricao_servico
                        FROM all_months m
                        CROSS JOIN all_services s
                    ),
                    aggregated_data AS (
                        SELECT
                            TO_CHAR(TO_DATE(EXTRACT(MONTH FROM TO_DATE(data_evento, 'DD/MM/YYYY'))::text, 'MM'), 'TMMonth') AS mes,
                            LOWER(descricao_servico) AS descricao_servico,
                            COUNT(*) AS quantidade_consultas
                        FROM ps_amil
                        WHERE EXTRACT(YEAR FROM TO_DATE(data_evento, 'DD/MM/YYYY')) = 2023
                            AND planta = @Planta
                        GROUP BY 1, 2
                    ),
                    ranked_services AS (
                        SELECT
                            mes,
                            descricao_servico,
                            quantidade_consultas,
                            ROW_NUMBER() OVER(PARTITION BY mes ORDER BY quantidade_consultas DESC, descricao_servico) AS rn
                        FROM (
                            SELECT
                                msc.mes,
                                msc.descricao_servico,
                                COALESCE(ad.quantidade_consultas, 0) AS quantidade_consultas
                            FROM month_service_combinations msc
                            LEFT JOIN aggregated_data ad ON msc.mes = ad.mes AND msc.descricao_servico = ad.descricao_servico
                        ) AS combined_data
                    )
                    SELECT
                        mes,
                        descricao_servico,
                        quantidade_consultas
                    FROM ranked_services
                    WHERE rn <= 5
                    ORDER BY mes, quantidade_consultas DESC;
                    ";

                    var parameters = new { Planta = unidade };
                    
                    return await conn.QueryAsync<MedicalTreatmentModel>(query, parameters);
                }
            }
            catch (Exception ex)
            {
                // TODO: Log.Error(ex, "Erro ao obter informações do GPTW.");
                throw new Exception("An error occurred while trying to fetch Medical treatment data.", ex);
            }
    }
}