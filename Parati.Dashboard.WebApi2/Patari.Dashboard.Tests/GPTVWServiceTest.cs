using Moq;
using NUnit.Framework;
using Parari.Dashboard.Repository;
using Parati.Dashboard.Repository; // Usando o namespace correto
using Parati.Dashboard.Services; // Assumindo a existência de IGptwVWService
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parati.Dashboard.Tests
{
    public class GPTWWTests
    {
        private Mock<IGPTWVWRepository> _mock;
        private IGptwVWService _gptvwService; // Correto, assumindo a existência de IGptwVWService

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<IGPTWVWRepository>();
            // Supondo que você tenha uma implementação chamada GptwVWServiceImpl para IGptwVWService
            _gptvwService = new GptwVWServiceImpl(_mock.Object);
        }

        [Test]
        public async Task Should_GetDepartmentStatsWithSuccess()
        {
            #region Arrange
            var expectedResult = new List<CidModel>
            {
                new CidModel { Mes = "Janeiro", descricao = "Estresse", quantidade_atestados = 10 },
                new CidModel { Mes = "Fevereiro", descricao = "Ansiedade", quantidade_atestados = 8 },
                // Adicione mais exemplos conforme necessário
            };

            // Não é necessário passar parâmetro, conforme a nova interface IGPTWVWRepository
            _mock.Setup(repo => repo.GetGPTWsVWFrequenciaProblemasSaudeMentalMes()).ReturnsAsync(expectedResult);
            #endregion

            #region Act
            // Atualizando para o método correto, que não recebe parâmetros
            var result = await _gptvwService.GetGptwVW();
            #endregion

            #region Assert
            // Verificações ajustadas para corresponder às propriedades do CidModel
            Assert.That(result.First().Mes, Is.EqualTo(expectedResult.First().Mes));
            Assert.That(result.First().descricao, Is.EqualTo(expectedResult.First().descricao));
            Assert.That(result.First().quantidade_atestados, Is.EqualTo(expectedResult.First().quantidade_atestados));
            #endregion
        }
    }
}
