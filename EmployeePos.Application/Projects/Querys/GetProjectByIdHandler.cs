using EmployeePos.Application.DTOs;
using MediatR;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AutoMapper;
using EmployeePos.Domain.IRepositories;
using EmployeePos.Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmployeePos.Application.Projects.Querys
{
    public class GetProjectByIdQuery : IRequest<Project> 
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
    }
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, Project>
    {
        public readonly IDbConnection _dbConnection;
        public GetProjectByIdHandler (IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<Project> Handle ( GetProjectByIdQuery request , CancellationToken cancellationToken)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            var sql = "SELECT * FROM pos.projects WHERE id=@employee_id";
            var project= await _dbConnection.QueryFirstOrDefaultAsync<Project>(sql, new { Id = request.Id });
            return project;
        }
    }
}
