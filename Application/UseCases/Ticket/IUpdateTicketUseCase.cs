using Domain.Models;

namespace Application.UseCases.Ticket
{
    public interface IUpdateTicketUseCase
    {
        Task<TicketModel> ExecuteAsync(TicketModel model);
    }
}
