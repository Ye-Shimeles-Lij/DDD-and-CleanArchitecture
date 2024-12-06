using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Dapper;
using EmployeePos.Application.DTOs;
using AutoMapper;
using System.Data;
using EmployeePos.Application.Position.Query;

namespace EmployeePos.Application.Employees.Querys
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeDto>
    {
        public Guid Id { get; set; }
    } 

    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _mapper;
        public GetEmployeeByIdHandler(IDbConnection dbConnection, IMapper mapper)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
        }
        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            const string sql = "SELECT * FROM pos.employees WHERE id = @id";
            var employee = await _dbConnection.QuerySingleOrDefaultAsync<EmployeeDto>(sql, new { Id = request.Id });
            return employee;

        }
    }
}
