using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models;

namespace Application.UseCases.Ticket.Implementations
{
    public class GetTicketByFiltersUseCase : IGetTicketByFiltersUseCase
    {
        private readonly ITicketRepositoryPort _repository;

        public GetTicketByFiltersUseCase(ITicketRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<TicketModel>> ExecuteAsync(TicketFilterModel filter)
        {
            return await _repository.GetAllAsync(filter);
        }
    }
}
