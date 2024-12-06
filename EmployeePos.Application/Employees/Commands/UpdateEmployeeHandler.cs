using AutoMapper;
using EmployeePos.Application.DTOs;
using EmployeePos.Domain.IRepositories;
using EmployeePos.Persistence;
using MediatR;
using EmployeePos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePos.Domain.ValueObjects;

namespace EmployeePos.Application.Employees.Commands
{
    public class UpdateEmployeeCommand : IRequest<UpdateEmployeeCommand>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // public FullName Name { get; set; }
        public string Email { get; set; }
        // public Guid PositionId { get; set; }
    }
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, UpdateEmployeeCommand>
    {
        private readonly PositionDbContext _context;
        private readonly IMapper _mapper;
        public UpdateEmployeeHandler(PositionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UpdateEmployeeCommand> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == request.Id);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            };

            employee.FullName = new FullName(request.FirstName, request.LastName);
            employee.Email = request.Email;
            //  employee.PositionId = request.PositionId;

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync(cancellationToken);
            // return _mapper.Map<GetEmployeeDto>(employee);
            return request;
        }
    }

}
