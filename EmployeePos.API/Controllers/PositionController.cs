using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeePos.Application.Service;
using EmployeePos.Application;
using MediatR;
using EmployeePos.Application.Position.Query;
using EmployeePos.Application.Position.Command;
using Microsoft.AspNetCore.Http.HttpResults;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace EmployeePos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PositionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPositionById(Guid id)
        {
            var result = await _mediator.Send(new GetPositionByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPositions()
        {
            var result = await _mediator.Send(new GetAllPositionsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddPosition(AddPositionCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetPositionById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePosition(Guid id, UpdatePositionCommand command)
        {
            if (id != command.Id)
            { 
                return BadRequest("id"); 
            }
            var result = await _mediator.Send(command); 
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(Guid id)
        {
            await _mediator.Send(new DeletePositionCommand { Id = id });
            return NoContent();
        }

        [HttpGet("hierarchy")]
        public async Task<IActionResult> GetPositionHierarchy()
        {
            var result = await _mediator.Send(new GetPositionHierarchyQuery());
            return Ok(result);
        }
    }
}
