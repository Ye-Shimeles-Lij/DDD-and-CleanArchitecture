using EmployeePos.Application.Projects.Querys;
using EmployeePos.Application.Projects.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeePos.Domain.Models;
using EmployeePos.Persistence.Migrations;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, Guid employeeId)
        {
            var project = await _mediator.Send(new GetProjectByIdQuery { EmployeeId = employeeId, Id = id });
            return Ok(project);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(Guid employeeId)
        {
            var projects = await _mediator.Send(new GetAllProjectsQuery { EmployeeId = employeeId }); 
            return Ok(projects);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProjectCommand command)
        {
             var result = await _mediator.Send(command);
             return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
          
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateProjectCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("id not match");
            }
            var result = await _mediator.Send(command);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteProjectCommand { Id = id });
            return NoContent();
        }

    }
}
