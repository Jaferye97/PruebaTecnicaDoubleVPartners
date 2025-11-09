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
        private readonly IDeleteTicketByIdUseCase _deleteTicketByIdUseCase;
        private readonly IGetTicketByFiltersUseCase _getTicketByFiltersUseCase;

        public TicketController(
            IAddTicketUseCase addTicketUseCase,
            IGetTicketByIdUseCase getByIdTicketUseCase,
            IUpdateTicketUseCase updateTicketUseCase,
            IDeleteTicketByIdUseCase deleteTicketByIdUseCase,
            IGetTicketByFiltersUseCase getTicketByFiltersUseCase)
        {
            _addTicketUseCase = addTicketUseCase;
            _getByIdTicketUseCase = getByIdTicketUseCase;
            _updateTicketUseCase = updateTicketUseCase;
            _deleteTicketByIdUseCase = deleteTicketByIdUseCase;
            _getTicketByFiltersUseCase = getTicketByFiltersUseCase;
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _deleteTicketByIdUseCase.ExecuteAsync(id);

            return Ok();
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync([FromBody] TicketFilterModel filters)
        {
            var result = await _getTicketByFiltersUseCase.ExecuteAsync(filters);

            return Ok(result);
        }
    }
}
