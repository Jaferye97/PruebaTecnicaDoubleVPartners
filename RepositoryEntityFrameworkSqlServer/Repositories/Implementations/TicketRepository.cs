using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models;
using RepositoryEntityFrameworkSqlServer.Context;
using RepositoryEntityFrameworkSqlServer.Entities;
using RepositoryEntityFrameworkSqlServer.Mappers;

namespace RepositoryEntityFrameworkSqlServer.Repositories.Implementations
{
    public class TicketRepository : BaseRepository<TicketEntity, TicketModel, int>, ITicketRepositoryPort
    {
        public TicketRepository(EntityDbContext context) : base(context, entity => entity.ToDomain(), entity => entity.ToEntity())
        {
        }

        public async Task<TicketModel> AddAsync(TicketModel model) => TicketMapper.ToDomain(await base.AddAsync(model));

        public async Task<bool> ExistRecordAsync(int id) => await base.CountAsync(x => x.Id == id) == 0 ? false : true;

        public async Task<TicketModel> GetAsync(int id) => await base.GetAsync(id);

        public async Task<TicketModel> UpdateAsync(TicketModel model) => TicketMapper.ToDomain(await base.UpdateAsync(model));
        public async Task DeleteAsync(TicketModel model) => await base.DeleteAsync(model);
    }
}
