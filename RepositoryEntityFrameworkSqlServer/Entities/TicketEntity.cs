using System.ComponentModel.DataAnnotations.Schema;
using RepositoryEntityFrameworkSqlServer.Entities.Constants;

namespace RepositoryEntityFrameworkSqlServer.Entities
{
    [Table("Ticket")]
    public class TicketEntity : IEntity<int>
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaActualizacion { get; set; }
        public string Estatus { get; set; } = "Abierto";
    }
}
