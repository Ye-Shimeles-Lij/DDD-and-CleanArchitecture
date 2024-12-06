using EmployeePos.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePos.Application.Services
{
    public interface IProjectService
    {
        Task<ProjectDto> GetProjectByIdAsync(Guid ProId);
        Task<IReadOnlyList<ProjectDto>> GetAllProjectsAsync();
        Task<ProjectDto> AddProjectAsync(ProjectDto projectDto);
        Task<ProjectDto> UpdateProjectAsync(ProjectDto projectDto);
        Task<bool> DeleteProjectByIdAsync(Guid ProId);
    }
}
