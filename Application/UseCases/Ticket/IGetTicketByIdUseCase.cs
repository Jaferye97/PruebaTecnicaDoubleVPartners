using Domain.Models;

namespace Application.UseCases.Ticket
{
    public interface IGetTicketByIdUseCase
    {
        Task<TicketModel> ExecuteAsync(int id);
    }
}
