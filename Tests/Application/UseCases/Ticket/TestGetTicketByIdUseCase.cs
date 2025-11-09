using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Application.UseCases.Ticket.Implementations;
using Domain.Models;
using Moq;

namespace Tests.Application.UseCases.Ticket
{
    public class TestGetTicketByIdUseCase
    {
        private readonly Mock<ITicketRepositoryPort> _repositoryMock;
        private readonly GetTicketByIdUseCase _getTicketByIdUseCase;

        public TestGetTicketByIdUseCase()
        {
            _repositoryMock = new Mock<ITicketRepositoryPort>();

            _getTicketByIdUseCase = new GetTicketByIdUseCase(_repositoryMock.Object);
        }

        [Fact(DisplayName = "Debería retornar el ticket cuando el ID existe")]
        public async Task ExecuteAsync_ShouldReturnTicket_WhenIdExists()
        {
            // Arrange
            int ticketId = 1;
            var expectedTicket = new TicketModel
            {
                Id = ticketId,
                Usuario = "Yeimer",
                Estatus = "Abierto",
            };

            _repositoryMock.Setup(r => r.ExistRecordAsync(ticketId))
                           .ReturnsAsync(true);

            _repositoryMock.Setup(r => r.GetAsync(ticketId))
                           .ReturnsAsync(expectedTicket);

            // Act
            var result = await _getTicketByIdUseCase.ExecuteAsync(ticketId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ticketId, result.Id);
            Assert.Equal("Yeimer", result.Usuario);
            Assert.Equal("Abierto", result.Estatus);

            _repositoryMock.Verify(r => r.ExistRecordAsync(ticketId), Times.Once);
            _repositoryMock.Verify(r => r.GetAsync(ticketId), Times.Once);
        }

        [Fact(DisplayName = "Debería retornar null cuando el ID no existe")]
        public async Task ExecuteAsync_ShouldReturnNull_WhenIdDoesNotExist()
        {
            // Arrange
            int ticketId = 99;

            _repositoryMock.Setup(r => r.ExistRecordAsync(ticketId))
                           .ReturnsAsync(false);

            // Act
            var result = await _getTicketByIdUseCase.ExecuteAsync(ticketId);

            // Assert
            Assert.Null(result);

            _repositoryMock.Verify(r => r.ExistRecordAsync(ticketId), Times.Once);
            _repositoryMock.Verify(r => r.GetAsync(It.IsAny<int>()), Times.Never);
        }
    }
}
