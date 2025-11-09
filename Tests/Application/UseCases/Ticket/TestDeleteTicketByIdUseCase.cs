using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Application.UseCases.Ticket.Implementations;
using Application.UseCases.Ticket;
using Moq;
using Domain.Models;

namespace Tests.Application.UseCases.Ticket
{
    public class TestDeleteTicketByIdUseCase
    {
        private readonly Mock<ITicketRepositoryPort> _repositoryMock;
        private readonly Mock<IGetTicketByIdUseCase> _getTicketByIdUseCaseMock;
        private readonly DeleteTicketByIdUseCase _deleteTicketByIdUseCase;

        public TestDeleteTicketByIdUseCase()
        {
            _repositoryMock = new Mock<ITicketRepositoryPort>();
            _getTicketByIdUseCaseMock = new Mock<IGetTicketByIdUseCase>();

            _deleteTicketByIdUseCase = new DeleteTicketByIdUseCase(
                _repositoryMock.Object,
                _getTicketByIdUseCaseMock.Object
            );
        }

        [Fact(DisplayName = "Debería eliminar ticket cuando el ticket existe")]
        public async Task ExecuteAsync_ShouldDeleteTicket_WhenTicketExists()
        {
            int ticketId = 1;
            var existingTicket = new TicketModel { Id = ticketId, Usuario = "Yeimer", Estatus = "Abierto" };

            _getTicketByIdUseCaseMock
                .Setup(x => x.ExecuteAsync(ticketId))
                .ReturnsAsync(existingTicket);

            _repositoryMock
                .Setup(x => x.DeleteAsync(existingTicket))
                .Returns(Task.CompletedTask);

            await _deleteTicketByIdUseCase.ExecuteAsync(ticketId);

            _getTicketByIdUseCaseMock.Verify(x => x.ExecuteAsync(ticketId), Times.Once);
            _repositoryMock.Verify(x => x.DeleteAsync(existingTicket), Times.Once);
        }

        [Fact(DisplayName = "No debería intentar eliminar cuando el ticket no existe")]
        public async Task ExecuteAsync_ShouldNotDelete_WhenTicketDoesNotExist()
        {
            int ticketId = 99;

            _getTicketByIdUseCaseMock
                .Setup(x => x.ExecuteAsync(ticketId))
                .ReturnsAsync((TicketModel)null);

            await _deleteTicketByIdUseCase.ExecuteAsync(ticketId);

            _getTicketByIdUseCaseMock.Verify(x => x.ExecuteAsync(ticketId), Times.Once);
            _repositoryMock.Verify(x => x.DeleteAsync(It.IsAny<TicketModel>()), Times.Never);
        }
    }
}
