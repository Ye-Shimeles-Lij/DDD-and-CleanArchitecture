using AutoMapper;
using EmployeePos.Application.Position.Command;
using EmployeePos.Domain.IRepositories;
using EmployeePos.Domain.Models;
using EmployeePos.Application.DTOs;
using EmployeePos.Persistence.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeePos.Domain.ValueObjects;
using System.Threading.Tasks;

namespace EmployeePos.Application.Employees.Commands
{
    public class AddEmployeeCommand : IRequest<AddEmployeeCommand>
    { 
        public Guid Id  { get; set; } 
        public FullName FullName { get; set; }
        public string Email { get; set; }
       // public Guid PositionId { get; set; }
    }
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, AddEmployeeCommand>
    {

        private readonly IEmployeeRepository _context;
       
        public AddEmployeeHandler(IEmployeeRepository context)
        {
            _context = context;
            
        }
        public async Task<AddEmployeeCommand> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
           // var employees = new Domain.Models.Employee(request.Name, request.Email);
            var employee = new Employee(request.FullName, request.Email);
            await _context.AddAsync(employee);
            request.Id = employee.Id;

            return request;
        }
    }
}
