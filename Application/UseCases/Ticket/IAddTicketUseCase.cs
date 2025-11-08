using Domain.Models;

namespace Application.UseCases.Ticket
{
    public interface IAddTicketUseCase
    {
        Task<TicketModel> ExecuteAsync(TicketModel model);
    }
}
