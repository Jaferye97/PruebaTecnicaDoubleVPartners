using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Application.UseCases.Ticket.Implementations;
using Domain.Models;
using Moq;

namespace Tests.Application.UseCases.Ticket
{
    public class TestAddTicketUseCase
    {
        private readonly Mock<ITicketRepositoryPort> _repositoryMock;
        private readonly AddTicketUseCase _addTicketUseCase;

        public TestAddTicketUseCase()
        {
            _repositoryMock = new Mock<ITicketRepositoryPort>();

            _addTicketUseCase = new AddTicketUseCase(_repositoryMock.Object);
        }

        [Fact(DisplayName = "Debería agregar un ticket correctamente")]
        public async Task ExecuteAsync_ShouldAddTicket_WhenModelIsValid()
        {
            // Arrange
            var ticketModel = new TicketModel
            {
                Id = 1,
                Usuario = "Yeimer",
                Estatus = "Abierto",
            };

            // Simular que el repositorio devuelve el mismo ticket agregado
            _repositoryMock
                .Setup(r => r.AddAsync(ticketModel))
                .ReturnsAsync(ticketModel);

            // Act
            var result = await _addTicketUseCase.ExecuteAsync(ticketModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ticketModel.Id, result.Id);
            Assert.Equal(ticketModel.Usuario, result.Usuario);
            Assert.Equal(ticketModel.Estatus, result.Estatus);

            // Verificar que el repositorio fue llamado exactamente una vez
            _repositoryMock.Verify(r => r.AddAsync(ticketModel), Times.Once);
        }

        [Fact(DisplayName = "Debería retornar null si el repositorio falla")]
        public async Task ExecuteAsync_ShouldReturnNull_WhenRepositoryReturnsNull()
        {
            // Arrange
            var ticketModel = new TicketModel
            {
                Id = 2,
                Usuario = "Carlos",
                Estatus = "Cerrado"
            };

            _repositoryMock
                .Setup(r => r.AddAsync(ticketModel))
                .ReturnsAsync((TicketModel)null);

            // Act
            var result = await _addTicketUseCase.ExecuteAsync(ticketModel);

            // Assert
            Assert.Null(result);
            _repositoryMock.Verify(r => r.AddAsync(ticketModel), Times.Once);
        }
    }
}
