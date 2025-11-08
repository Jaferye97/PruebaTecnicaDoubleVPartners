using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models;

namespace Application.UseCases.Ticket.Implementations
{
    public class UpdateTicketUseCase : IUpdateTicketUseCase
    {
        private readonly ITicketRepositoryPort _repository;

        public UpdateTicketUseCase(ITicketRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<TicketModel?> ExecuteAsync(TicketModel model)
        {
            if (!await _repository.ExistRecordAsync(model.Id))
            {
                return null;
            }

            return await _repository.UpdateAsync(model);
        }
    }
}
