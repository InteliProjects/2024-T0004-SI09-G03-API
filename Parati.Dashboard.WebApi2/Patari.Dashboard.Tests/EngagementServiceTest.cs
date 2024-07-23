using Moq;
using NUnit.Framework;
using Parari.Dashboard.Repository;
using Parati.Dashboard.Repository; // Usar o namespace correto para IEngagementRepository
using Parati.Dashboard.Services; // Usar o namespace correto para IEngagementService
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parati.Dashboard.Tests
{
    public class EngagementTests
    {
        private Mock<IEngagementRepository> _mock;
        private IEngagementeService _engagementService; // Corrigido para IEngagementService

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<IEngagementRepository>();
            _engagementService = new EngagementServiceImpl(_mock.Object);
        }

        [Test]
        public async Task Should_GetDepartmentStatsWithSuccess()
        {
            #region Arrange
            var expectedResult = new List<EngagementModel>
            {
                new EngagementModel { year = 2022, engagement_percent = 75, trust_index = 85, culture_audit = 90 },
                new EngagementModel { year = 2021, engagement_percent = 70, trust_index = 80, culture_audit = 88 },
                // Adicione mais exemplos conforme necessário
            };

            _mock.Setup(repo => repo.GetEngagiment()).ReturnsAsync(expectedResult); // Corrigido para GetEngagementData
            #endregion

            #region Act
            var result = await _engagementService.GetData(); // Corrigido para GetEngagementData
            #endregion

            #region Assert
            // Ajustar assertivas para corresponder às propriedades do EngagementModel
            Assert.That(result.First().year, Is.EqualTo(expectedResult.First().year));
            Assert.That(result.First().engagement_percent, Is.EqualTo(expectedResult.First().engagement_percent));
            Assert.That(result.First().trust_index, Is.EqualTo(expectedResult.First().trust_index));
            Assert.That(result.First().culture_audit, Is.EqualTo(expectedResult.First().culture_audit));
            #endregion
        }
    }
}
