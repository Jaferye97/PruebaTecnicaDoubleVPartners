using Domain.Models;

namespace Application.Ports.RepositoryEntityFrameworkSqlServer
{
    public interface ITicketRepositoryPort
    {
        Task<TicketModel> AddAsync(TicketModel model);
        Task<bool> ExistRecordAsync(int id);
        Task<TicketModel> GetAsync(int id);
        Task<TicketModel> UpdateAsync(TicketModel model);
        Task DeleteAsync(TicketModel model);
        Task<PagedResult<TicketModel>> GetAllAsync(TicketFilterModel filter);
    }
}
