using Moq;
using NUnit.Framework;
using Parari.Dashboard.Repository;
using Parati.Dashboard.Repository; // Usando o namespace correto
using Parati.Dashboard.Services; // Assumindo a existência de IGptwService
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parati.Dashboard.Tests
{
    public class GPTWTests
    {
        private Mock<IGPTWRepository> _mock;
        private IGptwService _gptwService; // Corrigido para refletir o tipo correto

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<IGPTWRepository>();
            _gptwService = new GptwServiceImpl(_mock.Object); // Assumindo a existência de GptwServiceImpl
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

            // Corrigido para passar um parâmetro de exemplo e usar o tipo correto
            _mock.Setup(repo => repo.GetGPTWsFrequenciaProblemasSaudeMentalMes("UnidadeExemplo")).ReturnsAsync(expectedResult);
            #endregion

            #region Act
            // Corrigido para refletir a chamada do método e passar o parâmetro correto
            var result = await _gptwService.GetGptw("UnidadeExemplo");
            #endregion

            #region Assert
            // Ajustado para verificar as propriedades do CidModel
            Assert.That(result.First().Mes, Is.EqualTo(expectedResult.First().Mes));
            Assert.That(result.First().descricao, Is.EqualTo(expectedResult.First().descricao));
            Assert.That(result.First().quantidade_atestados, Is.EqualTo(expectedResult.First().quantidade_atestados));
            #endregion
        }
    }
}
