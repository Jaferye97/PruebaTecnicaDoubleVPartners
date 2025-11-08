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
    }
}
