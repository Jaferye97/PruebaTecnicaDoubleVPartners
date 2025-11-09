using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> ExistRecordAsync(int id) => await base.CountAsync(x => x.Id == id) > 0;

        public async Task<TicketModel> GetAsync(int id) => await base.GetAsync(id);

        public async Task<TicketModel> UpdateAsync(TicketModel model) => TicketMapper.ToDomain(await base.UpdateAsync(model));
        public async Task DeleteAsync(TicketModel model) => await base.DeleteAsync(model);

        public async Task<PagedResult<TicketModel>> GetAllAsync(TicketFilterModel filter)
        {
            IQueryable<TicketEntity> query = _dbSet;

            if (!string.IsNullOrEmpty(filter.Usuario))
                query = query.Where(t => t.Usuario.Contains(filter.Usuario));

            if (!string.IsNullOrEmpty(filter.Estatus))
                query = query.Where(t => t.Estatus == filter.Estatus);

            if (filter.FechaCreacionDesde.HasValue)
                query = query.Where(t => t.FechaCreacion >= filter.FechaCreacionDesde.Value);

            if (filter.FechaCreacionHasta.HasValue)
                query = query.Where(t => t.FechaCreacion <= filter.FechaCreacionHasta.Value);

            if (filter.FechaActualizacionDesde.HasValue)
                query = query.Where(t => t.FechaActualizacion >= filter.FechaActualizacionDesde.Value);

            if (filter.FechaActualizacionHasta.HasValue)
                query = query.Where(t => t.FechaActualizacion <= filter.FechaActualizacionHasta.Value);

            var totalItems = await query.CountAsync();

            filter.Page = filter.Page <= 0 ? 1 : filter.Page;
            filter.PageSize = filter.PageSize <= 0 ? 10 : filter.PageSize;

            var entities = await query
                .OrderByDescending(t => t.FechaCreacion)
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResult<TicketModel>
            {
                Items = entities.Select(TicketMapper.ToDomain).ToList(),
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / filter.PageSize),
                CurrentPage = filter.Page
            };
        }
    }
}
