using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeePos.Application.Employees;
using EmployeePos.Application.Employees.Commands;
using EmployeePos.Application.Employees.Querys;
using EmployeePos.Domain.Models;


namespace EmployeePos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery { Id = id });
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPost]
       
        public async Task<IActionResult> AddEmployeeWithProject(Employee employee, Domain.Models.Project project)
        {
            var command = new AddEmployeeWithProjectcommand(employee, project);
            var result = await _mediator.Send(command);
            if (result==null)
            {
                return BadRequest("Add Failed");
            }
            return Ok(result);
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid empid, UpdateEmployeeCommand command)
        {
            if (empid != command.Id)
            {
                return BadRequest("id not match");
            }
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteEmployeeCommand { Id = id });
            return NoContent();
        }
    }
}
