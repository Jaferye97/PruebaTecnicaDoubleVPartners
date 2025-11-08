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
        private readonly IUpdateTicketUseCase _updateTicketUseCase;

        public TicketController(
            IAddTicketUseCase addTicketUseCase,
            IGetTicketByIdUseCase getByIdTicketUseCase,
            IUpdateTicketUseCase updateTicketUseCase)
        {
            _addTicketUseCase = addTicketUseCase;
            _getByIdTicketUseCase = getByIdTicketUseCase;
            _updateTicketUseCase = updateTicketUseCase;
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

        [HttpPut()]
        public async Task<IActionResult> UpdateAsync([FromBody] TicketModel model)
        {
            var result = await _updateTicketUseCase.ExecuteAsync(model);
            
            return result == null ? NotFound() : Ok(result);
        }
    }
}
