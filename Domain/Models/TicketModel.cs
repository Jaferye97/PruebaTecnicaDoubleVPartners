using System.Diagnostics.CodeAnalysis;

namespace Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class TicketModel
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaActualizacion { get; set; }
        public string Estatus { get; set; } = "Abierto";
    }
}
