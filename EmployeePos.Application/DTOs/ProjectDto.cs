using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePos.Application.DTOs
{
    public class ProjectDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid EmployeeId { get; set; }
    }
    public class GetProjectDto : ProjectDto
    {
        public Guid Id { get; set; }
    }
}
