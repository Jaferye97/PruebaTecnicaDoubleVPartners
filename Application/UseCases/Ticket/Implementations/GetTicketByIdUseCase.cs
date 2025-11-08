using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models;

namespace Application.UseCases.Ticket.Implementations
{
    public class GetTicketByIdUseCase : IGetTicketByIdUseCase
    {
        private readonly ITicketRepositoryPort _repository;

        public GetTicketByIdUseCase(ITicketRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<TicketModel?> ExecuteAsync(int id)
        {
            if (!await _repository.ExistRecordAsync(id))
            {
                return null;
            }

            return await _repository.GetAsync(id);
        }
    }
}
