using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using EmployeePos.Application.DTOs;
using EmployeePos.Application.Position.Query;
using MediatR;

namespace EmployeePos.Application.Employees.Querys
{
    public class GetAllEmployeesQuery : IRequest<List<GetEmployeeDto>>
    {
    }
     
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, List<GetEmployeeDto>>
    {
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _mapper;
        public GetAllEmployeesHandler(IDbConnection dbConnection, IMapper mapper)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
        }
        public async Task<List<GetEmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            const string sql = "SELECT *  FROM pos.employees ";
            var employees = await _dbConnection.QueryAsync<GetEmployeeDto>(sql);
            return employees.ToList();
        }

    }


}

   

