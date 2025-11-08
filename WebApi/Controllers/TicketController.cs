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
        private readonly IGetTicketByIdUseCase _getByIdTicketUseCase;

        public TicketController(
            IAddTicketUseCase addTicketUseCase, 
            IGetTicketByIdUseCase getByIdTicketUseCase)
        {
            _addTicketUseCase = addTicketUseCase;
            _getByIdTicketUseCase = getByIdTicketUseCase;
        }

        [HttpPost()]
        public async Task<IActionResult> AddAsync([FromBody] TicketModel model)
        {
            var result = await _addTicketUseCase.ExecuteAsync(model);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var result = await _getByIdTicketUseCase.ExecuteAsync(id);

            return result == null ? NotFound() : Ok(result);
        }
    }
}
