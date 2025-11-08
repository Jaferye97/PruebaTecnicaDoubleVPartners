using Domain.Models;

namespace Application.Ports.RepositoryEntityFrameworkSqlServer
{
    public interface ITicketRepositoryPort
    {
        Task<TicketModel> AddAsync(TicketModel model);
    }
}
