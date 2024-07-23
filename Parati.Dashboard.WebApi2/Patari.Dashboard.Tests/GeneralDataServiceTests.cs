using Moq;
using NUnit.Framework;
using Parari.Dashboard.Repository; // Este namespace parece estar incorreto com base em outros usos.
using Parati.Dashboard.Repository; // Correto para IGeneralDataRepository
using Parati.Dashboard.Services; // Correto para IGeneralDataService
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parati.Dashboard.Tests
{
    public class Tests
    {
        private Mock<IGeneralDataRepository> _mock;
        private IGeneralDataService _generalDataService;

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<IGeneralDataRepository>();
            _generalDataService = new GeneralDataService(_mock.Object);
        }

        [Test]
        public async Task Should_GetDepartmentStatsWithSuccess()
        {
            #region Arrange
            var expectedResult = new List<GeneralDataModel>
            {
                new GeneralDataModel { total_sessoes = "14", Departamento = "Curitiba", total_dias = "14", total_atestados = "8", Anc = "null" },
                new GeneralDataModel { total_sessoes = "136", Departamento = "Taubate", total_dias = "595", total_atestados = "107", Anc = "null" },
                new GeneralDataModel { total_sessoes = "5", Departamento = "São Carlos", total_dias = "21", total_atestados = "12", Anc = "null" },
                new GeneralDataModel { total_sessoes = "839", Departamento = "Anchieta", total_dias = "1585", total_atestados = "266", Anc = "null" }
            };

            _mock.Setup(repo => repo.GetData()).ReturnsAsync(expectedResult);
            #endregion

            #region Act
            var result = await _generalDataService.GetData();
            #endregion

            #region Assert
            Assert.That(result.First().total_sessoes, Is.EqualTo(expectedResult.First().total_sessoes));
            Assert.That(result.First().Departamento, Is.EqualTo(expectedResult.First().Departamento));
            Assert.That(result.First().total_dias, Is.EqualTo(expectedResult.First().total_dias));
            Assert.That(result.First().total_atestados, Is.EqualTo(expectedResult.First().total_atestados));
            // Adicione mais assertivas conforme necessário
            #endregion
        }
    }
}
