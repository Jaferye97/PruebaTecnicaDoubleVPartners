namespace Application.UseCases.Ticket
{
    public interface IDeleteTicketByIdUseCase
    {
        Task ExecuteAsync(int id);
    }
}
