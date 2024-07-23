// using Moq;
// using Parati.Dashboard.Repository;
// using Parati.Dashboard.Services;
// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Xunit;

namespace Parati.Dashboard.Test
{
    public class TestEngagementServiceImpl
    {
    //     private readonly Mock<IEngagementRepository> _mockRepository;
    //     private readonly EngagementServiceImpl _service;
    //     private readonly List<EngagementModel> _fakeData;
    //
    //     public TestEngagementServiceImpl()
    //     {
    //         // Setup mock
    //         _mockRepository = new Mock<IEngagementRepository>();
    //
    //         // Instantiate the service with the mock
    //         _service = new EngagementServiceImpl(_mockRepository.Object);
    //
    //         // Fake data for testing
    //         _fakeData = new List<EngagementModel>
    //         {
    //             // Adicione instâncias de EngagementModel conforme necessário
    //             new EngagementModel { /* Inicialize as propriedades aqui */ },
    //             new EngagementModel { /* Inicialize as propriedades aqui */ }
    //         };
    //     }
    //
    //     [Fact]
    //     public async Task GetData_ReturnsDataFromRepository()
    //     {
    //         // Arrange
    //         _mockRepository.Setup(repo => repo.GetEngagiment())
    //                        .ReturnsAsync(_fakeData);
    //
    //         // Act
    //         var result = await _service.GetData();
    //
    //         // Assert
    //         Assert.NotNull(result);
    //         Assert.Equal(_fakeData.Count, ((List<EngagementModel>)result).Count);
    //         _mockRepository.Verify(repo => repo.GetEngagiment(), Times.Once);
    //     }
    //
    //     [Fact]
    //     public async Task GetData_ThrowsServiceExceptionOnRepositoryError()
    //     {
    //         // Arrange
    //         _mockRepository.Setup(repo => repo.GetEngagiment())
    //                        .ThrowsAsync(new Exception("Database connection failed"));
    //
    //         // Act & Assert
    //         await Assert.ThrowsAsync<ServiceException>(() => _service.GetData());
    //     }
    }
}

