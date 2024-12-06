using AutoMapper;
using EmployeePos.Application.DTOs;
using EmployeePos.Application.Position.Command;
using EmployeePos.Application.Employees.Commands;
using EmployeePos.Application.Projects.Commands;

namespace EmployeePos.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Models.Position, PositionDto>().ReverseMap();
            CreateMap<Domain.Models.Position, AddPositionCommand>().ReverseMap();
            CreateMap<Domain.Models.Position, UpdatePositionCommand>().ReverseMap();
            CreateMap<GetPo, Domain.Models.Position>().ReverseMap();
            CreateMap<Domain.Models.Employee, EmployeeDto>().ReverseMap();
            CreateMap<Domain.Models.Employee, AddEmployeeCommand>().ReverseMap();
            CreateMap<Domain.Models.Employee, UpdateEmployeeCommand>().ReverseMap();
            CreateMap<GetEmployeeDto, Domain.Models.Employee>().ReverseMap();
            CreateMap<Domain.Models.Project, ProjectDto>().ReverseMap();
            CreateMap<Domain.Models.Project, AddProjectCommand>().ReverseMap();
            CreateMap<Domain.Models.Project, UpdateProjectCommand>().ReverseMap();
            CreateMap<GetProjectDto, Domain.Models.Project>().ReverseMap();
        }
    }

    /*public class Dummy
    {

    }*/
}
