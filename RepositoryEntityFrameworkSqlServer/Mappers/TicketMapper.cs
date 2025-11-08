using Domain.Models;
using RepositoryEntityFrameworkSqlServer.Entities;

namespace RepositoryEntityFrameworkSqlServer.Mappers
{
    internal static class TicketMapper
    {
        public static TicketModel ToDomain(this TicketEntity entity) => new TicketModel
        {
            Id = entity.Id,
            Usuario = entity.Usuario,
            FechaCreacion = entity.FechaCreacion,
            FechaActualizacion = entity.FechaActualizacion,
            Estatus = entity.Estatus,
        };

        public static TicketEntity ToEntity(this TicketModel domain) => new TicketEntity
        {
            Id = domain.Id,
            Usuario = domain.Usuario,
            FechaCreacion = domain.FechaCreacion,
            FechaActualizacion = domain.FechaActualizacion,
            Estatus = domain.Estatus,
        };
    }
}
