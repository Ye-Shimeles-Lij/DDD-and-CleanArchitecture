using EmployeePos.Domain.IRepositories;
using EmployeePos.Domain.Models;
using EmployeePos.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePos.Application.Projects.Commands
{
    public class DeleteProjectCommand : IRequest<DeleteProjectCommand>
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
    }
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, DeleteProjectCommand>
    {
        private readonly IEmployeeRepository _context;
        public DeleteProjectHandler (IEmployeeRepository context)
        {
            _context = context;
        }
        public async Task<DeleteProjectCommand> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.GetByIdAsync(request.EmployeeId); 
            if (employee != null)
            {
                employee.DeleteAsync(request.Id); 
                await _context.UpdateAsync(employee); 
                return request;
            }
            else
            {
                throw new Exception("Employee not found");
            }
        }

    }
}
