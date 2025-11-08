using Application.UseCases.Ticket;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IAddTicketUseCase _addTicketUseCase;

        public TicketController(IAddTicketUseCase addTicketUseCase)
        {
            _addTicketUseCase = addTicketUseCase;
        }

        [HttpPost()]
        public async Task<IActionResult> AddAsync([FromBody] TicketModel model)
        {
            var result = await _addTicketUseCase.ExecuteAsync(model);
            return Ok(result);
        }
    }
}
