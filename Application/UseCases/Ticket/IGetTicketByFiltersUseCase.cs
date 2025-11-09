using Domain.Models;

namespace Application.UseCases.Ticket
{
    public interface IGetTicketByFiltersUseCase
    {
        Task<PagedResult<TicketModel>> ExecuteAsync(TicketFilterModel filter);
    }
}
