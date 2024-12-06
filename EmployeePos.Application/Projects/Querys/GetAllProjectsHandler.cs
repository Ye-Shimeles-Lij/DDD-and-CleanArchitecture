using AutoMapper;
using Dapper;
using EmployeePos.Application.DTOs;
using EmployeePos.Domain.IRepositories;
using EmployeePos.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePos.Application.Projects.Querys
{
    public class GetAllProjectsQuery : IRequest<List<ProjectDto>>
    {
         public Guid EmployeeId { get; set; }
    }
    public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectDto>>
    {
        private readonly IDbConnection _dbConnection;
        public GetAllProjectsHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<List<ProjectDto>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
   
            var sql = " SELECT * FROM pos.projects WHERE projects.employee_id = @EmployeeId";
            var projects = await _dbConnection.QueryAsync<ProjectDto>(sql, new { EmployeeId = request.EmployeeId });
            return projects.ToList();
        }
    }
}
