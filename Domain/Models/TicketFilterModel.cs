namespace Domain.Models
{
    public class TicketFilterModel
    {
        public string? Usuario { get; set; }
        public string? Estatus { get; set; }
        public DateTime? FechaCreacionDesde { get; set; }
        public DateTime? FechaCreacionHasta { get; set; }
        public DateTime? FechaActualizacionDesde { get; set; }
        public DateTime? FechaActualizacionHasta { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
