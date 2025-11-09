using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Application.UseCases.Ticket.Implementations;
using Domain.Models;
using Moq;

namespace Tests.Application.UseCases.Ticket
{
    public class TestGetTicketByFiltersUseCase
    {
        private readonly Mock<ITicketRepositoryPort> _repositoryMock;
        private readonly GetTicketByFiltersUseCase _getTicketByFiltersUseCase;

        public TestGetTicketByFiltersUseCase()
        {
            _repositoryMock = new Mock<ITicketRepositoryPort>();

            _getTicketByFiltersUseCase = new GetTicketByFiltersUseCase(_repositoryMock.Object);
        }

        [Fact(DisplayName = "Debería retornar una lista paginada de tickets cuando el filtro es válido")]
        public async Task ExecuteAsync_ShouldReturnPagedResult_WhenFilterIsValid()
        {
            // Arrange
            var filter = new TicketFilterModel { Page = 1, PageSize = 2 };

            var expectedPagedResult = new PagedResult<TicketModel>
            {
                Items = new List<TicketModel>
                {
                    new TicketModel { Id = 1, Usuario = "Yeimer", Estatus = "Abierto" },
                    new TicketModel { Id = 2, Usuario = "Carlos", Estatus = "Cerrado" }
                },
                TotalItems = 2,
                TotalPages = 1,
                CurrentPage = 1
            };

            _repositoryMock
                .Setup(r => r.GetAllAsync(filter))
                .ReturnsAsync(expectedPagedResult);

            // Act
            var result = await _getTicketByFiltersUseCase.ExecuteAsync(filter);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.TotalItems);
            Assert.Equal(1, result.CurrentPage);
            Assert.Equal(2, result.Items.Count);
            Assert.Equal("Yeimer", result.Items[0].Usuario);

            _repositoryMock.Verify(r => r.GetAllAsync(filter), Times.Once);
        }

        [Fact(DisplayName = "Debería retornar null si el repositorio no devuelve resultados")]
        public async Task ExecuteAsync_ShouldReturnNull_WhenRepositoryReturnsNull()
        {
            // Arrange
            var filter = new TicketFilterModel { Page = 1, PageSize = 10 };

            _repositoryMock
                .Setup(r => r.GetAllAsync(filter))
                .ReturnsAsync((PagedResult<TicketModel>)null);

            // Act
            var result = await _getTicketByFiltersUseCase.ExecuteAsync(filter);

            // Assert
            Assert.Null(result);
            _repositoryMock.Verify(r => r.GetAllAsync(filter), Times.Once);
        }
    }
}
