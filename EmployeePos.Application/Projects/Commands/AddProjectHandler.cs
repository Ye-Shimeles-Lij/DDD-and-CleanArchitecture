using AutoMapper;
using EmployeePos.Application.Position.Command;
using EmployeePos.Application.Services;
using EmployeePos.Domain.IRepositories;
using EmployeePos.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePos.Application.Projects.Commands
{
    public class AddProjectCommand : IRequest <AddProjectCommand>
    {
        public Guid Id { get; set; }
        /* public string Title { get; set; }
        public string Description { get; set; }*/
        public Guid EmployeeId { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
    }
    public class AddProjectHandler : IRequestHandler<AddProjectCommand, AddProjectCommand>
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;

        public AddProjectHandler(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }
        public async Task<AddProjectCommand> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repo.GetByIdAsync(request.EmployeeId);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            
            employee.AddAsync(request.Title, request.Description);
            await _repo.UpdateAsync(employee);
            return request;
        }
    }
}
