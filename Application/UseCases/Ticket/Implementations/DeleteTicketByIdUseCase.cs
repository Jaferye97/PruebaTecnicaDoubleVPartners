using Application.Ports.RepositoryEntityFrameworkSqlServer;

namespace Application.UseCases.Ticket.Implementations
{
    public class DeleteTicketByIdUseCase : IDeleteTicketByIdUseCase
    {
        private readonly ITicketRepositoryPort _repository;

        private readonly IGetTicketByIdUseCase _getTicketByIdUseCase;

        public DeleteTicketByIdUseCase(ITicketRepositoryPort repository, IGetTicketByIdUseCase getTicketByIdUseCase)
        {
            _repository = repository;
            _getTicketByIdUseCase = getTicketByIdUseCase;
        }

        public async Task ExecuteAsync(int id)
        {
            var model = await _getTicketByIdUseCase.ExecuteAsync(id);
            if (model != null)
            {
                await _repository.DeleteAsync(model);
            }

            return;
        }
    }
}
