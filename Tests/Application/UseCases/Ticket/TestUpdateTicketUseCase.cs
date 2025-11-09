using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Application.UseCases.Ticket.Implementations;
using Domain.Models;
using Moq;

namespace Tests.Application.UseCases.Ticket
{
    public class TestUpdateTicketUseCase
    {
        private readonly Mock<ITicketRepositoryPort> _repositoryMock;
        private readonly UpdateTicketUseCase _updateTicketUseCase;

        public TestUpdateTicketUseCase()
        {
            _repositoryMock = new Mock<ITicketRepositoryPort>();

            _updateTicketUseCase = new UpdateTicketUseCase(_repositoryMock.Object);
        }

        [Fact(DisplayName = "Debería actualizar el ticket cuando el registro existe")]
        public async Task ExecuteAsync_ShouldUpdateTicket_WhenRecordExists()
        {
            // Arrange
            var ticketModel = new TicketModel
            {
                Id = 1,
                Usuario = "Yeimer",
                Estatus = "Abierto",
            };

            _repositoryMock.Setup(r => r.ExistRecordAsync(ticketModel.Id))
                           .ReturnsAsync(true);

            _repositoryMock.Setup(r => r.UpdateAsync(ticketModel))
                           .ReturnsAsync(ticketModel);

            // Act
            var result = await _updateTicketUseCase.ExecuteAsync(ticketModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ticketModel.Id, result.Id);
            Assert.Equal(ticketModel.Usuario, result.Usuario);

            _repositoryMock.Verify(r => r.ExistRecordAsync(ticketModel.Id), Times.Once);
            _repositoryMock.Verify(r => r.UpdateAsync(ticketModel), Times.Once);
        }

        [Fact(DisplayName = "Debería retornar null cuando el ticket no existe")]
        public async Task ExecuteAsync_ShouldReturnNull_WhenRecordDoesNotExist()
        {
            // Arrange
            var ticketModel = new TicketModel
            {
                Id = 99,
                Usuario = "Carlos",
                Estatus = "Cerrado",
            };

            _repositoryMock.Setup(r => r.ExistRecordAsync(ticketModel.Id))
                           .ReturnsAsync(false);

            // Act
            var result = await _updateTicketUseCase.ExecuteAsync(ticketModel);

            // Assert
            Assert.Null(result);

            _repositoryMock.Verify(r => r.ExistRecordAsync(ticketModel.Id), Times.Once);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<TicketModel>()), Times.Never);
        }
    }
}
