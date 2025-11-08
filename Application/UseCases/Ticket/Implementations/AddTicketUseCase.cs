using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models;

namespace Application.UseCases.Ticket.Implementations
{
    public class AddTicketUseCase : IAddTicketUseCase
    {
        private readonly ITicketRepositoryPort _repository;

        public AddTicketUseCase(ITicketRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<TicketModel> ExecuteAsync(TicketModel model)
        {
            return await _repository.AddAsync(model);
        }
    }
}
