using EmployeePos.Application.Position.Command;
using EmployeePos.Domain.IRepositories;
using EmployeePos.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePos.Application.Employees.Commands
{
    public class DeleteEmployeeCommand : IRequest<DeleteEmployeeCommand>
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
    }

    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, DeleteEmployeeCommand>
    {
        private readonly PositionDbContext _context;
        private readonly IEmployeeRepository _repo;
        public DeleteEmployeeHandler(PositionDbContext context, IEmployeeRepository repo)
        {
            _context = context;
            _repo = repo;
        }
        public async Task<DeleteEmployeeCommand> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repo.GetByIdAsync(request.EmployeeId); 
            if (employee != null) 
            {
                throw new Exception("no employees found");
            }
            employee.DeleteAsync(request.Id);
            await _repo.UpdateAsync(employee);
            return request;

        }
    }
}
