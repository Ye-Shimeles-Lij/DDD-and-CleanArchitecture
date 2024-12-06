using AutoMapper;
using EmployeePos.Application.Services;
using EmployeePos.Domain.IRepositories;
using EmployeePos.Domain.Models;
using EmployeePos.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePos.Application.Projects.Commands
{
    public class UpdateProjectCommand : IRequest<Project>
    {
        public Guid Id { get; set; }
       /* public string Title { get; set; }
        public string Description { get; set; } */
        public Guid EmployeeId { get; set; }
        public Project Project { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

    }
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, Project>
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;

        public UpdateProjectHandler(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Project> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repo.GetByIdAsync(request.EmployeeId);
            if (employee == null)
            {
                throw new Exception("employee not found");
            }
            //  employee.UpdateAsync(request.Title, request.Description);
            employee.UpdateAsync(request.Project);
            await _repo.UpdateAsync(employee);
            return request.Project;

        }

    }
}
